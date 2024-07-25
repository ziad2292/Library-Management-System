using DBapplication;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Phase_2_App
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        string check;
        Controller cntrl;

        public Login()
        {
            InitializeComponent();
            cntrl = new Controller();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (check == "student")
            {

                cntrl.setID(cntrl.SelectStudentID(email.Text, password1.Password.ToString()));
                StudentFunctions p = new StudentFunctions();
                p.Show();
                this.Close();
            }
            else if(check == "admin")
            {
                cntrl.setID(cntrl.SelectAdminID(email.Text));
                Admin p = new Admin();
                p.Show();
                this.Close();
            }
            else
            {
                System.Windows.MessageBox.Show("Please Complete The Login Data");

            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            check = "admin";
            password.Text = "Admin ID";
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            check = "student";
            password.Text = "Password";

        }
    }
}
