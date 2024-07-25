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
    /// Interaction logic for StudentFunctions.xaml
    /// </summary>
    public partial class StudentFunctions : Window
    {
        Controller cntrl;

        public StudentFunctions()
        {
            InitializeComponent();
            cntrl = new Controller();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Search p = new Search();
            p.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int fees = (cntrl.SelectFee(BookName.Text)) * Int32.Parse(Days.Text);
            int bookid = cntrl.SelectBookID(BookName.Text);
            int studentid = cntrl.getID();
            cntrl.InsertOrder(Int32.Parse(Days.Text), fees, studentid, bookid);

            Payment p = new Payment();
            p.Show();
            this.Close();
        }
    }
}
