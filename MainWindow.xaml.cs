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
using System.Windows.Threading;
using test;

namespace pomodoraetbabouche
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int i = 100;
        TimeSpan work = new TimeSpan(0,0,25,0,0);
        TimeSpan rest = new TimeSpan(0,0,5,0,0);
        TimeSpan sec = new TimeSpan(0,0,0,1,0);
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            work = work.Subtract(sec);
            Timer.Content =  work.ToString(@"mm\:ss");
            CommandManager.InvalidateRequerySuggested();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Start();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            UserControl3 l = new UserControl3();
            this.Content = l;
        }
    }
}
