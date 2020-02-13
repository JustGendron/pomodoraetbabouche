
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

    }

}
