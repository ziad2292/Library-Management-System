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
    /// Interaction logic for Signup.xaml
    /// </summary>
    public partial class Signup : Window
    {
        string choice;
        Controller cntrl;
        public Signup()
        {
            InitializeComponent();
            cntrl = new Controller();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if(choice == "student")
            {
                ComboBoxItem genderSelect = (ComboBoxItem)Gender.SelectedItem;
                ComboBoxItem facultySelect = (ComboBoxItem)Faculty.SelectedItem;

                cntrl.InsertStudent(name.Text, email.Text, password.Password.ToString(), Date_Picker.SelectedDate.Value, genderSelect.Content.ToString(), facultySelect.Content.ToString());
                cntrl.setID(cntrl.SelectStudentID(email.Text, password.Password.ToString()));

                MessageBox.Show("Registration Is Done Successfully");
                StudentFunctions p = new StudentFunctions();
                p.Show();
                this.Close();
            }
            else if(choice == "admin")
            {
                ComboBoxItem genderSelect = (ComboBoxItem)Gender.SelectedItem;
                cntrl.InsertAdmin(name.Text, genderSelect.Content.ToString(), email.Text);
                cntrl.setID(cntrl.SelectAdminID(email.Text));

                MessageBox.Show("Registration Is Done Successfully");
                Admin p = new Admin();
                p.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please Complete The Sign Up Data");
            }
            
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            choice = "admin";
            Date_Picker.Visibility = Visibility.Hidden;
            Date_Title.Visibility = Visibility.Hidden;
            Faculty.Visibility = Visibility.Hidden;
            Faculty_Title.Visibility = Visibility.Hidden;
            password.Visibility = Visibility.Hidden;
            Password_Title.Visibility = Visibility.Hidden;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            choice = "student";
            Date_Picker.Visibility = Visibility.Visible;
            Date_Title.Visibility = Visibility.Visible;
            Faculty.Visibility = Visibility.Visible;
            Faculty_Title.Visibility = Visibility.Visible;
            password.Visibility = Visibility.Visible;
            Password_Title.Visibility = Visibility.Visible;
        }
    }
}
