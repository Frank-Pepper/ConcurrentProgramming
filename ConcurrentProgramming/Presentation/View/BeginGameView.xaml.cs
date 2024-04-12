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

namespace Presentation.View
{
    /// <summary>
    /// Logika interakcji dla klasy BeginGameView.xaml
    /// </summary>
    public partial class BeginGameView : Window
    {
        public BeginGameView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TableView tableView = new TableView(); // TODO find another way to change window
            tableView.Show();
            this.Close();
        }
    }
}
