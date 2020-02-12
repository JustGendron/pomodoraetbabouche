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
    /// Logique d'interaction pour planification.xaml
    /// </summary>
    public partial class planification : UserControl
    {
        public planification()
        {
            InitializeComponent();
            DateTime localDate = DateTime.Now;
            selectTag.ItemsSource = typeof(Colors).GetProperties();
            titre.Content = "Ma journée du " + localDate.ToString("dd/MM/yyyy");
        }

        private void cmbColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Pomodoro p = new Pomodoro(selectTag.SelectedItem.ToString());

        }
    }
}
