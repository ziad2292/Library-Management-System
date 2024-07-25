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
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        Controller cntrl;

        bool book = false, year = false, isbn = false, author = false;
        public Search()
        {
            InitializeComponent();
            cntrl = new Controller();
            Author.Text = "Author";
            ISBN.Text = "ISBN";
            Year.Text = "Publication Year";
            bookName.Text = "Book Name";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StudentPage p = new StudentPage();
            p.Show();
            this.Close();
        }

        private void Search1_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt;
            if (book)
            {
                dt = cntrl.SelectBook(bookName.Text);
                table.ItemsSource = dt.DefaultView;
            }
            else if(isbn)
            {
                dt = cntrl.SelectISBN(ISBN.Text);
                table.ItemsSource = dt.DefaultView;

            }
            else if (author)
            {
                dt = cntrl.selectAuthorBooks(Author.Text);
                table.ItemsSource = dt.DefaultView;

            }
            else if(year)
            {
                dt = cntrl.SelectPubYear(Year.Text);
                table.ItemsSource = dt.DefaultView;

            }
        }

        private void bookName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Author.Text = "Author";
            ISBN.Text = "ISBN";
            Year.Text = "Publication Year";

            book = true;
            isbn = author = year = false;
        }

        private void SearchAll_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt;
            dt = cntrl.select("Books");
            table.ItemsSource = dt.DefaultView;
        }

        private void Author_TextChanged(object sender, TextChangedEventArgs e)
        {
            bookName.Text = "Book Name";
            ISBN.Text = "ISBN";
            Year.Text = "Publication Year";

            author = true;
            isbn = book = year = false;
        }

        private void Year_TextChanged(object sender, TextChangedEventArgs e)
        {
            bookName.Text = "Book Name";
            ISBN.Text = "ISBN";
            Author.Text = "Author";

            year = true;
            isbn = author = book = false;
        }

        private void ISBN_TextChanged(object sender, TextChangedEventArgs e)
        {
            bookName.Text = "Book Name";
            Year.Text = "Publication Year";
            Author.Text = "Author";

            isbn = true;
            book = author = year = false;
        }
    }
}
