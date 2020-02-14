using pomodoraetbabouche.Class;
using pomodoraetbabouche.Constante;
using SQLite;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace pomodoraetbabouche
{
    /// <summary>
    /// Logique d'interaction pour Pomodoro.xaml
    /// </summary>
    public partial class Pomodoro : UserControl
    {
        /// <summary>
        /// Initiation des variables utilisé dans le programme
        /// </summary>
        int iteration = 1;
        int nbpomodoro;
        Boolean workTime = true;
        Boolean finalRestBool = true;
        TimeSpan work = new TimeSpan(0, 0, 25, 0, 0);
        TimeSpan rest = new TimeSpan(0, 0, 5, 0, 0);
        TimeSpan sec = new TimeSpan(0, 0, 0, 1, 0);
        TimeSpan finalRest = new TimeSpan(0, 0, 0, 10, 0);
        TimeSpan end = new TimeSpan(0, 0, 0, 0, 0);
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        TimeSpan tempsRestant = new TimeSpan();
        MainWindow mw = new MainWindow();

        /// <summary>
        /// Code joué lors de l'initialisation du composant avec le Handler qui permet de faire le décompte
        /// </summary>
        public Pomodoro(MainWindow mainWindow)
        {            
            InitializeComponent();
            SQLiteConnection connection = new SQLiteConnection(Constantes.pathDb);
            List<Projet> items = connection.Table<Projet>().ToList();
            ComboBoxSelectPomodoro.ItemsSource = items;
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            tempsRestant = tempsRestant + work;
            ButtonStart.IsEnabled = false;
            ButtonPause.IsEnabled = false;
            ButtonStop.IsEnabled = false;
            mw = mainWindow;
        }

        /// <summary>
        /// Methode du déroulé de la session du pomodoro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // Permet de définir le nombre d'itération de phase de working + rest
            if (iteration < 4)
            {
                iterationaff.Content = iteration;
                nbpomodoro = iteration - 1;
                tempsRestant = tempsRestant.Subtract(sec);
                ChronoTimer.Content = tempsRestant.ToString(@"mm\:ss");
                // Quand le décompte arrive à 0
                if (end == tempsRestant)
                {
                    tempsRestant = new TimeSpan();
                    if (!workTime)
                    {
                        iteration++;
                        iterationaff.Content = iteration;
                        tempsRestant += work;
                        workTime = true;
                    }
                    else
                    {
                        //Permet d'éviter de jouer la petite pause avant la grande pause finale
                        if (iteration < 4)
                        {
                            tempsRestant += rest;
                            workTime = false;
                        }
                    }
                }

            }
            // Une fois les iterations défini écoulé
            else
            {
                tempsRestant = tempsRestant.Subtract(sec);
                ChronoTimer.Content = tempsRestant.ToString(@"mm\:ss");

                // Quand le décompte arrive à zéro
                if (end == tempsRestant)
                {
                    // Permet de passé une fois dans la boucle pour jouer la grande pause
                    if (finalRestBool)
                    {

                        tempsRestant = new TimeSpan();
                        tempsRestant += finalRest;
                        finalRestBool = false;
                    }
                    // Une fois que la grande pause est fini
                    else
                    {
                        dispatcherTimer.Stop();
                        iterationaff.Content = "";
                        nbpomodoro = iteration;
                        ChronoTimer.Content = "Fini !";
                        savePomodoro();
                        nbpomodoro = 0;
                    }
                }
            }
            CommandManager.InvalidateRequerySuggested();
        }

        /// <summary>
        /// Methode appelé lors du clic du Bouton Start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Start(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Start();
            ComboBoxSelectPomodoro.IsEnabled = false;
        }

        /// <summary>
        /// Méthode appelé lors du clic du Bouton Pause
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Pause(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
        }

        /// <summary>
        /// Méthode appelé lors du clic du Bouton Stop, déclenche la reinitialisation des variables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            ComboBoxSelectPomodoro.IsEnabled = true;
            savePomodoro();
            nbpomodoro = 0;
        }

        /// <summary>
        /// Permet d'obliger la selection d'un nom pour le pomodoro, pour un enregistrement future dans la BDD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxSelectPomodoro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Si Aucun nom renseigné, alors les boutons sont désactivés
            if (ComboBoxSelectPomodoro.SelectedIndex == -1)
            {
                ButtonStart.IsEnabled = false;
                ButtonPause.IsEnabled = false;
                ButtonStop.IsEnabled = false;
            }
            // Si un nom est renseigné, alors les boutons sont activés
            else
            {
                ButtonStart.IsEnabled = true;
                ButtonPause.IsEnabled = true;
                ButtonStop.IsEnabled = true;
            }
        }

        /// <summary>
        /// Methode pour retourner sur la page principale
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_return(object sender, RoutedEventArgs e)
        {
            mw.MainPageScreen();
        }   
        
        /// <summary>
        /// Methode pour update la quantitée de pomodori effetuer en selectionnant le projet de la combobox
        /// </summary>
        private void savePomodoro()
        {
            SQLiteConnection connection = new SQLiteConnection(Constantes.pathDb);
            Projet proj = (Projet)ComboBoxSelectPomodoro.SelectedValue;            
            proj.nombrePomodoro += nbpomodoro;
            connection.Update(proj);
        }
    }
}
