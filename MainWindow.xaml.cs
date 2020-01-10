using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using test;

namespace pomodoraetbabouche
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int iteration = 1;
        Boolean workTime = true;
        Boolean finalRestBool = true;
        TimeSpan work = new TimeSpan(0,0,0,5,0);
        TimeSpan rest = new TimeSpan(0,0,0,2,0);
        TimeSpan sec = new TimeSpan(0,0,0,1,0);
        TimeSpan end = new TimeSpan(0, 0, 0, 0, 0);
        TimeSpan finalRest = new TimeSpan(0, 0, 0, 15, 0);
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        TimeSpan tempsRestant = new TimeSpan();

        public MainWindow()
        {
            InitializeComponent();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            tempsRestant = tempsRestant + work;
            ButtonStart.IsEnabled = false;
            ButtonPause.IsEnabled = false;
            ButtonStop.IsEnabled = false;

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (iteration < 4)
            {
                iterationaff.Content = iteration;
                tempsRestant = tempsRestant.Subtract(sec);
                ChronoTimer.Content = tempsRestant.ToString(@"mm\:ss");

                if (end == tempsRestant)
                {
                    tempsRestant = new TimeSpan();
                    if (!workTime)
                    {
                        iteration++;
                        iterationaff.Content = iteration;
                        tempsRestant += work;
                        workTime = true;
                    } else
                    {
                        if (iteration < 4)
                        {
                            tempsRestant += rest;
                            workTime = false;
                        }
                    }
                }

            }
            else
            {
                tempsRestant = tempsRestant.Subtract(sec);
                ChronoTimer.Content = tempsRestant.ToString(@"mm\:ss");

                if (end == tempsRestant)
                {
                    if (finalRestBool)
                    {

                        tempsRestant = new TimeSpan();
                        tempsRestant += finalRest;
                        finalRestBool = false;
                    } else
                    {
                        dispatcherTimer.Stop();
                        iterationaff.Content = "";
                        ChronoTimer.Content = "Fini !";
                    }
                }
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
            dispatcherTimer.Stop();
            ChronoTimer.Content = "25:00";
            iteration = 1;
            iterationaff.Content = "";
            tempsRestant = new TimeSpan();
            tempsRestant += work;
            workTime = true;
            finalRestBool = true;
        }

        private void LabelPomodoro_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if(LabelPomodoro.Text.Length == 0)
            {
                ButtonStart.IsEnabled = false;
                ButtonPause.IsEnabled = false;
                ButtonStop.IsEnabled = false;
            } else
            {
                ButtonStart.IsEnabled = true;
                ButtonPause.IsEnabled = true;
                ButtonStop.IsEnabled = true;
            }

        }
    }
}
