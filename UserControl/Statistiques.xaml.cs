using pomodoraetbabouche.Class;
using pomodoraetbabouche.Constante;
using SQLite;
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

namespace pomodoraetbabouche
{
    /// <summary>
    /// Logique d'interaction pour Statistiques.xaml
    /// </summary>
    public partial class Statistiques : UserControl
    {
        private MainWindow mw;

        /// <summary>
        /// Initialisation de l'ecran
        /// </summary>
        /// <param name="mainWindow"></param>
        public Statistiques(MainWindow mainWindow)
        {
            InitializeComponent();
            ListProjectBuild();
            mw = mainWindow;
        }

        /// <summary>
        /// Methode pour retourner sur la page principale
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_retour(object sender, RoutedEventArgs e)
        {
            mw.MainPageScreen();
        }

        /// <summary>
        /// Methode pour récuperer et afficher les projets et leurs pomodori
        /// </summary>
        private void ListProjectBuild()
        {
            SQLiteConnection connection = new SQLiteConnection(Constantes.pathDb);
            List<Projet> items = connection.Table<Projet>().OrderByDescending(x => x.nombrePomodoro).ToList();
            StatsProjets.ItemsSource = items;
        }
    }
}
