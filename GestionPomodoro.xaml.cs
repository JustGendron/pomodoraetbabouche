using pomodoraetbabouche.Class;
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
    /// Logique d'interaction pour GestionPomodoro.xaml
    /// </summary>
    public partial class GestionPomodoro : UserControl
    {

        private MainWindow mw;
        public GestionPomodoro(MainWindow mainWindow)
        {
            InitializeComponent();
            mw = mainWindow;
            ListProjectBuild();
            DockListeProjets.Visibility = Visibility.Visible;
        }

        private void Button_Liste_Projets(object sender, RoutedEventArgs e)
        {
            CollapseAll();
            DockListeProjets.Visibility = Visibility.Visible;
            
        }

        private void Button_Ajout_Projet(object sender, RoutedEventArgs e)
        {
            CollapseAll();
            DockAjouter.Visibility = Visibility.Visible;
        }

        private void Button_Modification_Projet(object sender, RoutedEventArgs e)
        {
            CollapseAll();
            DockModifProjets.Visibility = Visibility.Visible;
        }

        private void Button_Suppression_Projet(object sender, RoutedEventArgs e)
        {
            CollapseAll();
            DockSupprProjets.Visibility = Visibility.Visible;
        }

        private void Button_Retour(object sender, RoutedEventArgs e)
        {
            mw.MainPageScreen();
        }

        private void Button_Ajout(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Modif(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Suppression(object sender, RoutedEventArgs e)
        {

        }

        private void LabelNomProjet_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            
        }

        private void LabelModifNomProjet_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            
        }

        private void CollapseAll()
        {
            DockAjouter.Visibility = Visibility.Collapsed;
            DockListeProjets.Visibility = Visibility.Collapsed;
            DockModifProjets.Visibility = Visibility.Collapsed;
            DockSupprProjets.Visibility = Visibility.Collapsed;

        }

        private void ListProjectBuild()
        {
            List<Projet> items = new List<Projet>();
            items.Add(new Projet() { id = 1, name = "epsi", nombrePomodoro = 8 });
            items.Add(new Projet() { id = 2, name = "Gerard", nombrePomodoro = 5 });
            items.Add(new Projet() { id = 3, name = "Philipe", nombrePomodoro = 6 });
            items.Add(new Projet() { id = 4, name = "Antoine", nombrePomodoro = 4 });
            items.Add(new Projet() { id = 5, name = "Alan", nombrePomodoro = 3 });
            items.Add(new Projet() { id = 6, name = "kowabunga", nombrePomodoro = 12 });
            items.Add(new Projet() { id = 6, name = "kowabunga", nombrePomodoro = 12 });
            items.Add(new Projet() { id = 7, name = "kowabunga", nombrePomodoro = 12 });
            items.Add(new Projet() { id = 8, name = "kowabunga", nombrePomodoro = 12 });
            items.Add(new Projet() { id = 9, name = "kowabunga", nombrePomodoro = 12 });
            items.Add(new Projet() { id = 10, name = "kowabunga", nombrePomodoro = 12 });
            items.Add(new Projet() { id = 11, name = "kowabunga", nombrePomodoro = 12 });
            items.Add(new Projet() { id = 12, name = "kowabunga", nombrePomodoro = 12 });
            items.Add(new Projet() { id = 13, name = "kowabunga", nombrePomodoro = 12 });
            items.Add(new Projet() { id = 14, name = "kowabunga", nombrePomodoro = 12 });
            items.Add(new Projet() { id = 18, name = "kowabunga", nombrePomodoro = 12 });
            NomsProjets.ItemsSource = items;
            ComboBoxProjets.ItemsSource = items;
            ComboBoxProjetsASuppr.ItemsSource = items;
        }
    }
}
