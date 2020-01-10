using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;


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

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Pomodoro p = new Pomodoro();
            this.Content = p;
        }
    }
}