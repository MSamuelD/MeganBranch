using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PetShop.Models
{
    public class Ticker : INotifyPropertyChanged
    {
        //https://stackoverflow.com/questions/3354793/binding-to-datetime-now-update-the-value
        public Ticker()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000; // 1 second updates
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        public TimeOnly Now
        {
            get { return TimeOnly.FromDateTime(DateTime.Now); }
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Now"));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
