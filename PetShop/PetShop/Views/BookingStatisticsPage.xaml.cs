using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Wpf;
using OxyPlot.Annotations;
using OxyPlot.Legends;
using OxyPlot.Series;
using PetShop.Data;

namespace PetShop.Views
{
    /// <summary>
    /// Statistics Page (Appointment Count by Service Name)
    /// Data Source: Appointment.Details (Free Text)
    /// Display: KPI + Bar/Pie Chart
    /// </summary>
    public partial class BookingStatisticsPage : Page
    {
        private readonly PetShopContext _context = new PetShopContext();

        private string _currentRange = "Day";       // current selected time range
        private string _currentChart = "Bar Chart"; // current selected chart type

        public BookingStatisticsPage()
        {
            InitializeComponent();
            LoadStats("Day");  // the startistics for current day by default
        }

        // click the button: to change between Day/Week/Month/Year
        
        private void BtnDay_Click(object sender, RoutedEventArgs e) => LoadStats("Day");
        private void BtnWeek_Click(object sender, RoutedEventArgs e) => LoadStats("Week");
        private void BtnMonth_Click(object sender, RoutedEventArgs e) => LoadStats("Month");
        private void BtnYear_Click(object sender, RoutedEventArgs e) => LoadStats("Year");

        // changing chart type (Bar / Pie)
        private void ChartSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ChartSelector.SelectedItem is ComboBoxItem item)
            {
                _currentChart = item.Content?.ToString() ?? "Bar Chart";
                LoadStats(_currentRange);
            }
        }

        // main process: KPI card and chart
        private void LoadStats(string range)
        {
            _currentRange = range;
            // 1) calculation time interval
            var (start, end) = GetRange(range);
            // 2)counts by service name
            var counts = QueryCountsByService(start, end);
            // 3)calculate previous period for trend
            var prevCounts = QueryPrevCountsByService(start, end); 

            // 4) update KPI
            var total = counts.Values.Sum();
            KpiTotal.Text = total.ToString();
            KpiTopService.Text = counts.Count > 0 ? counts.OrderByDescending(kv => kv.Value).First().Key : "—";
            KpiTrend.Text = FormatTrend(total, prevCounts.Values.Sum());

            // 5) update Chart
            NoDataHint.Visibility = counts.Count == 0 ? Visibility.Visible : Visibility.Collapsed;
            ChartView.Model = _currentChart.Contains("Pie") ? BuildPieModel(counts) : BuildBarModel_WithBarSeries(counts);
        }

        // EF queriy , group by appointment detail(free text)
        private Dictionary<string, int> QueryCountsByService(DateTime start, DateTime end)
        {
            DateOnly dStart = DateOnly.FromDateTime(start.Date);
            DateOnly dEnd = DateOnly.FromDateTime(end.Date);

            var raw = _context.Appointments
                .AsNoTracking()
                .Where(a => a.Date >= dStart && a.Date < dEnd)
                .Select(a => a.Details)
                .ToList();
            //normalization (remove spaces/lowercase/merge synonyms) + group counting
            return raw
                .Select(r => string.IsNullOrWhiteSpace(r) ? "unknown" : r.Trim().ToLowerInvariant())
                .GroupBy(n => n)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        private Dictionary<string, int> QueryPrevCountsByService(DateTime start, DateTime end)
        {
            var prevStart = start - (end - start);
            var prevEnd = start;
            return QueryCountsByService(prevStart, prevEnd);
        }


        // select time range
        private (DateTime start, DateTime end) GetRange(string range)
        {
            var today = DateTime.Today;
            return range switch
            {
                "Day" => (today, today.AddDays(1)),
                "Week" => (today.AddDays(-((int)today.DayOfWeek + 6) % 7),
                            today.AddDays(-((int)today.DayOfWeek + 6) % 7).AddDays(7)),
                "Month" => (new DateTime(today.Year, today.Month, 1),
                            new DateTime(today.Year, today.Month, 1).AddMonths(1)),
                "Year" => (new DateTime(today.Year, 1, 1),
                            new DateTime(today.Year, 1, 1).AddYears(1)),
                _ => (today, today.AddDays(1))
            };
        }

        // KPI trend counting and formatting
        private string FormatTrend(int current, int previous)
        {
            if (previous == 0 && current == 0) return "No change";
            if (previous == 0 && current > 0) return "Up from 0";
            if (current == previous) return "No change";

            var diff = current - previous;
            var sign = diff > 0 ? "↑" : "↓";
            var pct = Math.Round(Math.Abs(diff) * 100.0 / Math.Max(previous, 1));
            return $"{sign} {Math.Abs(diff)} ({pct}% vs prev)";
        }

        // bar chart (using OxyPlot bar series)
        //The horizontal axis is the value (X), and the vertical axis is the category (Y)
        private OxyPlot.PlotModel BuildBarModel_WithBarSeries(Dictionary<string, int> counts)
        {
            var model = new OxyPlot.PlotModel { Title = "Bookings Service" };
            // Category axis (Y axis)
            var catAxis = new OxyPlot.Axes.CategoryAxis { Position = OxyPlot.Axes.AxisPosition.Left };
            foreach (var name in counts.Keys) catAxis.Labels.Add(name);
            model.Axes.Add(catAxis);
            // Value axis (X axis)
            var valAxis = new OxyPlot.Axes.LinearAxis { Position = OxyPlot.Axes.AxisPosition.Bottom, Minimum = 0 };
            model.Axes.Add(valAxis);
            // Bar series
            var series = new OxyPlot.Series.BarSeries { Title = "Bookings" };
            foreach (var v in counts.Values) series.Items.Add(new OxyPlot.Series.BarItem(v));
            model.Series.Add(series);

            return model;
        }


        // pie chart (used OxyPlot)
        private PlotModel BuildPieModel(Dictionary<string, int> counts)
        {
            var model = new PlotModel { Title = "Share by Service" };
            var pie = new PieSeries
            {
                StrokeThickness = 0.5,
                InsideLabelPosition = 0.7,
                AngleSpan = 360,
                StartAngle = 0
            };
            foreach (var kv in counts) pie.Slices.Add(new PieSlice(kv.Key, kv.Value));
            model.Series.Add(pie);
            return model;
        }
    }
}
