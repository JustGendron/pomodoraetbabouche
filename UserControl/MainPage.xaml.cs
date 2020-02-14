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

        /// <summary>
        /// Méthode d'initiation de la page
        /// </summary>
        /// <param name="mainWindow"></param>
        public MainPage(MainWindow mainWindow)
        {
            InitializeComponent();
            mw = mainWindow;
        }

        /// <summary>
        /// Methode pour naviguer vers la page Chronomètre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Chronometre(object sender, RoutedEventArgs e)
        {
            mw.PomodoroScreen();
        }

        /// <summary>
        /// Méthode pour naviguer vers la page Gestion Pomodoro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Gestion_Pomodoros(object sender, RoutedEventArgs e)
        {
            mw.GestionPomodoroScreen();
        }

        /// <summary>
        /// Méthode pour naviguer vers la page Planification
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_PlanificationScreen(object sender, RoutedEventArgs e)
        {
            mw.PlanificationScreen();
        }

        /// <summary>
        /// Méthode pour naviguer vers la page Statistique
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Statistiques(object sender, RoutedEventArgs e)
        {
            mw.StatistiquesScreen();
        }
    }
}