
using pomodoraetbabouche.Class;
using pomodoraetbabouche.Constante;
using SQLite;
using System;
using System.Windows;

namespace pomodoraetbabouche
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Méthode appelé lors de l'initialisation de l'appli
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            MainPageScreen();
            CreateBDD();
        }

        /// <summary>
        /// Methode appeler pour naviguer vers MainPageScreen
        /// </summary>
        public void MainPageScreen()
        {
            MainPage mp = new MainPage(this);
            Content = mp;
        }

        /// <summary>
        /// Methode appeler pour naviguer vers PomodoroScreen
        /// </summary>
        public void PomodoroScreen()
        {
            Pomodoro po = new Pomodoro(this);
            Content = po;
        }

        /// <summary>
        /// Methode appeler pour naviguer vers GestionPomodoroScreen
        /// </summary>
        public void GestionPomodoroScreen()
        {
            GestionPomodoro gp = new GestionPomodoro(this);
            Content = gp;
        }

        /// <summary>
        /// Methode appeler pour naviguer vers PlanificationScreen
        /// </summary>
        public void PlanificationScreen()
        {
            PlanificationPage pp = new PlanificationPage(this);
            Content = pp;
        }

        /// <summary>
        /// Methode appeler pour naviguer vers StatistiquesScreen
        /// </summary>
        public void StatistiquesScreen()
        {
            Statistiques st = new Statistiques(this);
            Content = st;
        }

        /// <summary>
        /// Methode de creation de base de donnée + table, ne supprime pas le/la fichier/table si déjà existant
        /// </summary>
        private void CreateBDD()
        {
            // Instanciation de notre connexion
            SQLiteConnection connection = new SQLiteConnection(Constantes.pathDb);
            connection.CreateTable<Projet>();
        }

    }

}
