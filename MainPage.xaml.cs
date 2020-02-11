using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;


namespace pomodoraetbabouche
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {
        private MainWindow mw;

        public MainPage(MainWindow mainWindow)
        {
            InitializeComponent();
            mw = mainWindow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mw.PomodoroScreen();
        }

    }
}