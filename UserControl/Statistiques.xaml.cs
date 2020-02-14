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

        public Statistiques(MainWindow mainWindow)
        {
            InitializeComponent();
            ListProjectBuild();
            mw = mainWindow;
        }

        private void Button_retour(object sender, RoutedEventArgs e)
        {
            mw.MainPageScreen();
        }

        private void ListProjectBuild()
        {
            SQLiteConnection connection = new SQLiteConnection(Constantes.pathDb);
            List<Projet> items = connection.Table<Projet>().OrderByDescending(x => x.nombrePomodoro).ToList();
            StatsProjets.ItemsSource = items;
        }
    }
}
