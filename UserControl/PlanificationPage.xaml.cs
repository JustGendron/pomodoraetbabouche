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
        public PlanificationPage(MainWindow mainWindow)
        {
            InitializeComponent();
            mw = mainWindow;
        }

        private void Button_retour(object sender, RoutedEventArgs e)
        {
            mw.MainPageScreen() ;
        }
    }
}
