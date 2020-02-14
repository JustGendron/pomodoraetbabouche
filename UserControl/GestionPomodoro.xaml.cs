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
    /// Logique d'interaction pour GestionPomodoro.xaml
    /// </summary>
    public partial class GestionPomodoro : UserControl
    {

        private MainWindow mw;

        private string entry;

        /// <summary>
        /// Méthode d'initialisation de la page
        /// </summary>
        /// <param name="mainWindow"></param>
        public GestionPomodoro(MainWindow mainWindow)
        {
            InitializeComponent();
            mw = mainWindow;
            ListProjectBuild();
            DockListeProjets.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Méthode qui permet d'afficher les composants liste des projets
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Liste_Projets(object sender, RoutedEventArgs e)
        {
            CollapseAll();
            DockListeProjets.Visibility = Visibility.Visible;
            
        }

        /// <summary>
        /// Méthode qui permet d'afficher les composants ajout projet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Ajout_Projet(object sender, RoutedEventArgs e)
        {
            CollapseAll();
            entry = "";
            DockAjouter.Visibility = Visibility.Visible;
            ButtonAjoutProjet.IsEnabled = false;

        }

        /// <summary>
        /// Méthode qui permet d'afficher les composants Modifier projet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Modification_Projet(object sender, RoutedEventArgs e)
        {
            CollapseAll();
            entry = "";
            DockModifProjets.Visibility = Visibility.Visible;
            ButtonModifProjet.IsEnabled = false;
        }

        /// <summary>
        /// Méthode qui permet d'afficher les composants Suppression projet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Suppression_Projet(object sender, RoutedEventArgs e)
        {
            CollapseAll();
            entry = "";
            DockSupprProjets.Visibility = Visibility.Visible;
            ButtonSuppresionProjet.IsEnabled = false;
        }

        /// <summary>
        /// Methode pour retourner a la page principale
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Retour(object sender, RoutedEventArgs e)
        {
            mw.MainPageScreen();
        }

        /// <summary>
        /// Méthode appeler lors de la validation de Ajout projet pour insertion en base
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Ajout(object sender, RoutedEventArgs e)
        {
            SQLiteConnection connection = new SQLiteConnection(Constantes.pathDb);
            Projet pro = new Projet() { name = entry, nombrePomodoro = 0 };
            connection.Insert(pro);
            LabelProjet.Text = "";
            entry = "";
            ListProjectBuild();
        }

        /// <summary>
        /// Méthode appeler lors de la validation de Modification Projet pour update en base
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Modif(object sender, RoutedEventArgs e)
        {
            SQLiteConnection connection = new SQLiteConnection(Constantes.pathDb);
            Projet proj = (Projet)ComboBoxProjets.SelectedValue;
            proj.name = entry;
            connection.Update(proj);
            LabelModifProjet.Text = "";
            entry = "";
            ListProjectBuild();
        }

        /// <summary>
        /// Méthode appeler lors de la validation de Suppresion Projet pour delete en base
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Suppression(object sender, RoutedEventArgs e)
        {
            SQLiteConnection connection = new SQLiteConnection(Constantes.pathDb);
            Projet proj = (Projet)ComboBoxProjetsASuppr.SelectedValue;
            connection.Delete(proj);
            ListProjectBuild();
        }

        /// <summary>
        /// Méthode appeler lors de changements dans LabelNomProjet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelNomProjet_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (LabelProjet.Text.Length == 0)
            {
                ButtonAjoutProjet.IsEnabled = false;
            } 
            else
            {
                ButtonAjoutProjet.IsEnabled = true;
                entry = LabelProjet.Text;
            }
        }

        /// <summary>
        /// Méthode appeler lors de changements dans LabelModifNomProjet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelModifNomProjet_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (LabelModifProjet.Text.Length == 0)
            {
                ButtonModifProjet.IsEnabled = false;
            }
            else
            {
                ButtonModifProjet.IsEnabled = true;
                entry = LabelModifProjet.Text;
            }
        }

        /// <summary>
        /// Méthode appeler lors de changements de selection dans ComboBoxProjet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxProjets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Si Aucun nom renseigné, alors les boutons sont désactivés
            if (ComboBoxProjets.SelectedIndex == -1)
            {
                ButtonModifProjet.IsEnabled = false;
            }
            // Si un nom est renseigné, alors les boutons sont activés
            else
            {
                ButtonModifProjet.IsEnabled = true;
            }
        }

        /// <summary>
        /// Méthode appeler lors de changements de selection dans ComboBoxProjetsASuppr
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxProjetsASuppr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Si Aucun nom renseigné, alors les boutons sont désactivés
            if (ComboBoxProjetsASuppr.SelectedIndex == -1)
            {
                ButtonSuppresionProjet.IsEnabled = false;
            }
            // Si un nom est renseigné, alors les boutons sont activés
            else
            {
                ButtonSuppresionProjet.IsEnabled = true;
            }
        }

        /// <summary>
        /// Methode pour collapse tout les dockPanel afin de préparer l'affichage d'un DockPanel
        /// </summary>
        private void CollapseAll()
        {
            DockAjouter.Visibility = Visibility.Collapsed;
            DockListeProjets.Visibility = Visibility.Collapsed;
            DockModifProjets.Visibility = Visibility.Collapsed;
            DockSupprProjets.Visibility = Visibility.Collapsed;

        }

        /// <summary>
        /// Méthode qui permet de mettre a jour la liste des Projets présent en base
        /// </summary>
        private void ListProjectBuild()
        {
            SQLiteConnection connection = new SQLiteConnection(Constantes.pathDb);
            List<Projet> items = connection.Table<Projet>().ToList();            
            NomsProjets.ItemsSource = items;
            ComboBoxProjets.ItemsSource = items;
            ComboBoxProjetsASuppr.ItemsSource = items;
        }
    }
}
