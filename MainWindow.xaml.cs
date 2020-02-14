
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
        public MainWindow()
        {
            InitializeComponent();
            MainPageScreen();
            CreateBDD();
        }

        public void MainPageScreen()
        {
            MainPage mp = new MainPage(this);
            Content = mp;
        }

        public void PomodoroScreen()
        {
            Pomodoro po = new Pomodoro(this);
            Content = po;
        }

        public void GestionPomodoroScreen()
        {
            GestionPomodoro gp = new GestionPomodoro(this);
            Content = gp;
        }

        private void CreateBDD()
        {
            // Instanciation de notre connexion
            SQLiteConnection connection = new SQLiteConnection(Constantes.pathDb);
            connection.CreateTable<Projet>();
        }

    }

}
