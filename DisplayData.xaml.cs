using DBapplication;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace Phase_2_App
{
    /// <summary>
    /// Interaction logic for DisplayData.xaml
    /// </summary>
    public partial class DisplayData : Window
    {
        Controller cntrl;

        public DisplayData()
        {
            InitializeComponent();
            cntrl = new Controller();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Admin p = new Admin();
            p.Show();
            this.Close();
        }

        private void SearchType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)SearchType.SelectedItem;
            DataTable dt = cntrl.select(typeItem.Content.ToString());
            Table.ItemsSource = dt.DefaultView;
            
        }
    }
}
