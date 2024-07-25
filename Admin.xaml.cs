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
    public partial class Admin : Window
    {

        Controller cntrl;
        public Admin()
        {
            InitializeComponent();
            cntrl = new Controller();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StudentPage p = new StudentPage();
            p.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Search p = new Search();
            p.Show();
            this.Close();
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            cntrl.InsertBook(BookName.Text, Int32.Parse(BookID.Text), Int32.Parse(ISBN.Text), Genre.Text, Int32.Parse(Fee.Text), Int32.Parse(AuthorID.Text), Publisher.Text, Int32.Parse(PublishYear.Text));
        }

        private void AddAuthor_Click(object sender, RoutedEventArgs e)
        {
            cntrl.InsertAuthor(Int32.Parse(AuthorID1.Text), AuthorName.Text, 0);
        }

        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            cntrl.DeleteBook(Int32.Parse(BookID.Text));
        }

        private void UpdateBook_Click(object sender, RoutedEventArgs e)
        {
            cntrl.UpdateBook(Int32.Parse(BookID1.Text), Int32.Parse(BorrowerID.Text), Int32.Parse(Fee1.Text), Status.Text);
        }

        private void UpdateStudent_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)Eligibility.SelectedItem;
            cntrl.UpdateStudent(Int32.Parse(StudentID.Text), typeItem.Content.ToString());
        }

        private void ViewDatabase_Click(object sender, RoutedEventArgs e)
        {
            DisplayData p = new DisplayData();
            p.Show();
            this.Close();
        }

        private void DeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            cntrl.deleteStudent(Int32.Parse(StudentIDDelete.Text));
        }
    }
}
