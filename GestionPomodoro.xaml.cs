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
        }

        private void Button_Liste_Projets(object sender, RoutedEventArgs e)
        {
            CollapseAll();
            DockListeProjets.Visibility = Visibility.Visible;

            //List<User> items = new List<User>();
            //items.Add(new User() { Name = "John Doe", Age = 42, Mail = "john@doe-family.com" });
            //items.Add(new User() { Name = "Jane Doe", Age = 39, Mail = "jane@doe-family.com" });
            //items.Add(new User() { Name = "Sammy Doe", Age = 7, Mail = "sammy.doe@gmail.com" });
            //lvUsers.ItemsSource = items;
        }

        private void Button_Ajout_Projet(object sender, RoutedEventArgs e)
        {
            CollapseAll();
            DockAjouter.Visibility = Visibility.Visible;
        }

        private void Button_Modification_Projet(object sender, RoutedEventArgs e)
        {
            CollapseAll();
        }

        private void Button_Suppression_Projet(object sender, RoutedEventArgs e)
        {
            CollapseAll();
        }

        private void Button_Retour(object sender, RoutedEventArgs e)
        {
            mw.MainPageScreen();
        }

        private void Button_Ajout(object sender, RoutedEventArgs e)
        {

        }

        private void LabelNomProjet_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            
        }

        private void CollapseAll()
        {
            DockAjouter.Visibility = Visibility.Collapsed;
            DockListeProjets.Visibility = Visibility.Collapsed;

        }
    }
}
