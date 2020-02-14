using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;


namespace pomodoraetbabouche
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {
        private MainWindow mw;

        public MainPage(MainWindow mainWindow)
        {
            InitializeComponent();
            mw = mainWindow;
        }

        private void Button_Chronometre(object sender, RoutedEventArgs e)
        {
            mw.PomodoroScreen();
        }

        private void Button_Gestion_Pomodoros(object sender, RoutedEventArgs e)
        {
            mw.GestionPomodoroScreen();
        }

        private void Button_PlanificationScreen(object sender, RoutedEventArgs e)
        {
            mw.PlanificationScreen();
        }

        private void Button_Statistiques(object sender, RoutedEventArgs e)
        {
            mw.StatistiquesScreen();
        }
    }
}