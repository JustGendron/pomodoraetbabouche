using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace pomodoraetbabouche
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int i = 100;
        int iteration = 0;
        Boolean workTime = true;
        TimeSpan work = new TimeSpan(0,0,0,25,0);
        TimeSpan rest = new TimeSpan(0,0,0,5,0);
        TimeSpan sec = new TimeSpan(0,0,0,1,0);
        TimeSpan end = new TimeSpan(0, 0, 0, 0, 0);
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (iteration < 3)
            {
                if (workTime)
                {
                    work = work.Subtract(sec);
                    ChronoTimer.Content = work.ToString(@"mm\:ss");
                }
                else
                {
                    rest = rest.Subtract(sec);
                    ChronoTimer.Content = rest.ToString(@"mm\:ss");
                }

                if (end == work)
                {
                    iteration++;
                    work = new TimeSpan(0, 0, 0, 25, 0);
                    workTime = false;
                }
                if (end == rest)
                {
                    rest = new TimeSpan(0, 0, 0, 5, 0);
                    workTime = true;
                }

            }
            else
            {
                dispatcherTimer.Stop();
                ChronoTimer.Content = "Fini !";

            }
            CommandManager.InvalidateRequerySuggested();
        }

        private void Button_Start(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Start();
        }

        private void Button_Pause(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
        }

        private void Button_Stop(object sender, RoutedEventArgs e)
        {

        }
    }
}
