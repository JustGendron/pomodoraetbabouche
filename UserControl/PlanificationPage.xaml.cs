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
    /// Logique d'interaction pour PlanificationPage.xaml
    /// </summary>
    public partial class PlanificationPage : UserControl
    {
        private MainWindow mw;

        /// <summary>
        /// Methode d'initiation de la page
        /// </summary>
        /// <param name="mainWindow"></param>
        public PlanificationPage(MainWindow mainWindow)
        {
            InitializeComponent();
            mw = mainWindow;
        }

        /// <summary>
        /// Methode pour retourner sur la page principale
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_retour(object sender, RoutedEventArgs e)
        {
            mw.MainPageScreen() ;
        }
    }
}
