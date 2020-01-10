using System;
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
        Boolean workTime = true;
        Boolean finalRestBool = true;
        TimeSpan work = new TimeSpan(0, 0, 0, 5, 0);
        TimeSpan rest = new TimeSpan(0, 0, 0, 2, 0);
        TimeSpan sec = new TimeSpan(0, 0, 0, 1, 0);
        TimeSpan finalRest = new TimeSpan(0, 0, 0, 15, 0);
        TimeSpan end = new TimeSpan(0, 0, 0, 0, 0);
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        TimeSpan tempsRestant = new TimeSpan();

        /// <summary>
        /// Code joué lors de l'initialisation du composant avec le Handler qui permet de faire le décompte
        /// </summary>
        public Pomodoro()
        {
            InitializeComponent();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            tempsRestant = tempsRestant + work;
            ButtonStart.IsEnabled = false;
            ButtonPause.IsEnabled = false;
            ButtonStop.IsEnabled = false;

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
                        ChronoTimer.Content = "Fini !";
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
            LabelPomodoro.IsEnabled = false;
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
            LabelPomodoro.IsEnabled = true;
            LabelPomodoro.Text = "";
        }

        /// <summary>
        /// Permet d'obliger la saisie d'un nom pour le pomodoro, pour un enregistrement future dans la BDD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelPomodoro_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Si Aucun nom renseigné, alors les boutons sont désactivés
            if (LabelPomodoro.Text.Length == 0)
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
        
        private void Storage() { 
        }
    }
}
