using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace DBapplication
{
    public class Controller
    {
        DBManager dbMan;

        static int id;
        public Controller()
        {
            dbMan = new DBManager();
        }

        public void setID(int studentid)
        {
            Controller.id = studentid;
        }

        public int getID()
        {
            return id;
        }



        //Insert Statements

        public int InsertBook(string bookName, int bookId, int isbn, string genre, int feePerDay, int authorId, string publisher, int publisherYear)
        {
            string query = "INSERT INTO Books (book_name, book_ID, ISBN, genre,borrowing_status , fee_per_day, author_ID, publisher, publisher_year) " +
                           "VALUES ('" + bookName + "', " + bookId + ", " + isbn + ", '" + genre + "', 'NotBorrowed', " + feePerDay + ", " + authorId + ", '" + publisher + "', '" + publisherYear + "');";
            return dbMan.ExecuteNonQuery(query);
        }

        public int InsertStudent(string name, string email, string password, DateTime dateOfBirth, string gender, string faculty)
        {
            string query = "INSERT INTO students (student_name, student_email, student_password, date_of_birth, gender, faculty) " +
                           "VALUES ('" + name + "', '" + email + "', '" + password + "', '" + dateOfBirth.ToString("yyyy-MM-dd") + "', '" + gender + "', '" + faculty + "');";
            return dbMan.ExecuteNonQuery(query);
        }

        public int InsertAdmin(string name, string gender, string email)
        {
            string query = "INSERT INTO Admins (Admin_Name, Gender, Admin_Email) " +
                           "VALUES ('" + name + "', '" + gender + "', '" + email + "');";
            return dbMan.ExecuteNonQuery(query);
        }

        public int InsertOrder(int borrowingDays, int fees, int studentId, int bookId)
        {
            string query = "INSERT INTO orders (borrowing_days, fees, student_ID, book_ID) " +
                           "VALUES (" + borrowingDays + ", " + fees + ", " + studentId + ", " + bookId + ");";
            return dbMan.ExecuteNonQuery(query);
        }

        public int InsertPayment(string paymentMethod, int orderId)
        {
            string query = "INSERT INTO payments (payment_method, payment_status, order_ID) " +
                           "VALUES ('" + paymentMethod + "', 'Done', " + orderId + ");";
            return dbMan.ExecuteNonQuery(query);
        }

        public int InsertAuthor(int authorId, string authorName, int bookId)
        {
            string query = "INSERT INTO authors (author_ID, author_name) " +
                           "VALUES (" + authorId + ", '" + authorName + "');";
            return dbMan.ExecuteNonQuery(query);
        }

        public int InsertCategory(int categoryNumber, string genre, int bookId)
        {
            string query = "INSERT INTO category (category_number, genre, book_ID) " +
                           "VALUES (" + categoryNumber + ", '" + genre + "', " + bookId + ");";
            return dbMan.ExecuteNonQuery(query);
        }





        //Delete Statements
        public int DeleteBook(int bookId)
        {
            string query = "DELETE FROM Books WHERE book_ID = " + bookId;
            return dbMan.ExecuteNonQuery(query);
        }

        public int deleteStudent(int studentId)
        {
            string query = "DELETE FROM students WHERE student_ID = " + studentId;
            return dbMan.ExecuteNonQuery(query);

        }




        //Select Statements
        public DataTable select(string table)
        {
            string query = "select * from "+ table;
            return dbMan.ExecuteReader(query);

        }

        public DataTable SelectBook(string bookName)
        {
            string query = "SELECT book_name AS 'book name', ISBN, genre, fee_per_day AS 'fee per day', publisher_year AS 'publish year' FROM books WHERE book_name = '" + bookName + "'";

            return dbMan.ExecuteReader(query);
        }

        public int SelectFee(string bookName)
        {
            string query = "SELECT fee_per_day FROM books WHERE book_name = '" + bookName + "'";

            return (int)dbMan.ExecuteScalar(query);
        }

        public int SelectBookID(string bookName)
        {
            string query = "SELECT book_ID FROM books WHERE book_name = '" + bookName + "'";

            return (int)dbMan.ExecuteScalar(query);
        }

        public int SelectStudentID(string email, string password)
        {
            string query = "SELECT student_ID FROM students WHERE student_email = '" + email + "' AND student_password = '" + password + "'" ;

            return (int)dbMan.ExecuteScalar(query);
        }

        public int SelectAdminID(string email)
        {
            string query = "SELECT Admin_ID FROM Admins WHERE Admin_email = '" + email +"'";

            return (int)dbMan.ExecuteScalar(query);
        }

        public DataTable selectAuthorBooks(string authorName)
        {

            string query = "SELECT Books.book_name, authors.author_name, Books.book_ID, Books.genre " +
                         "FROM Books " +
                         "JOIN authors ON Books.author_ID = authors.author_ID " +
                         "WHERE authors.author_name LIKE '%" + authorName + "%';";


            return dbMan.ExecuteReader(query);

}

        public DataTable SelectPubYear(string publisher_year)
        {
            string query = "SELECT book_name AS 'book name', ISBN, genre, fee_per_day AS 'fee per day', publisher_year AS 'publish year' FROM books WHERE publisher_year = " + publisher_year;

            return dbMan.ExecuteReader(query);
        }

        public DataTable SelectISBN(string isbn)
        {
            string query = "SELECT book_name AS 'book name', ISBN, genre, fee_per_day AS 'fee per day', publisher_year AS 'publish year' FROM books WHERE isbn = " + isbn;

            return dbMan.ExecuteReader(query);
        }

        public int SelectOrderID()
        {
            string query = "SELECT MAX(order_ID) FROM orders ";

            return (int)dbMan.ExecuteScalar(query);
        }







        //Update Statements
        public int UpdateBook(int bookId, int borrowerId, int fee_per_day, string borrowingStatus)
        {
            string query = "UPDATE Books SET borrowing_status = '" + borrowingStatus + "', fee_per_day = " + fee_per_day + " , borrower_ID = " + borrowerId + "   WHERE book_ID = " + bookId;
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateStudent(int studentId, string eligibilityToBorrow)
        {
            string query = "UPDATE students SET " + "eligibility_to_borrow = '" + eligibilityToBorrow + "' WHERE student_ID = " + studentId;
            return dbMan.ExecuteNonQuery(query);
        }


        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }
    }
}
