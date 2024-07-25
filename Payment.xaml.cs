using DBapplication;
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
using System.Windows.Shapes;

namespace Phase_2_App
{
    /// <summary>
    /// Interaction logic for Payment.xaml
    /// </summary>
    public partial class Payment : Window
    {
        Controller cntrl;
        public Payment()
        {
            InitializeComponent();
            cntrl = new Controller();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int orderID = cntrl.SelectOrderID();
            cntrl.InsertPayment(method.Text, orderID);
            StudentFunctions p = new StudentFunctions();
            p.Show();
            this.Close();
        }
    }
}
