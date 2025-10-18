using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Prism.Commands;
using PetShop.Views;
using System.Windows.Automation.Provider;
namespace PetShop.UserControls
{
    /// <summary>
    /// Interaction logic for Heading.xaml
    /// </summary>
    public partial class Heading : UserControl 
        //ICommand
    {
        public DelegateCommand<Button> TheCommand
        {
            get; private set;
        }
        public Heading()
        {
            InitializeComponent();
//            TheCommand = new DelegateCommand<Button>(Execute, CanExecute);
        }

    
        //public void Execute(object button)
        //{

        //    return ;
        //}

        //public event EventHandler? CanExecuteChanged;

        //public bool CanExecute(object? button)
        //{
        //    return false;
        //}


        //public bool CanExecute(object? parameter)
        //{
        //    throw new NotImplementedException();
    }

    //public void Execute(object? parameter)
    //{
    //    throw new NotImplementedException();
    //}

}
