//initialise the books and the datagridview. Also controls whether the book is issued or return

using System.Collections.Generic;
using System.Windows.Forms;

namespace Libary
{
    public class Controller
    {
        private const int TWO = 2;
        private const int THREE = 3;
        private const int FOUR = 4;
        private const int FIVE = 5;
        private const int SIX = 6;
        private const int SEVEN = 7;
        private const int EIGHT = 8;
        private const int NINE = 9;
        private const int TEN = 10;

        private List<Book> books;
        private DataGridView dataGridView;

        public Controller(DataGridView dataGridView)//constructor
        {
            books = new List<Book>();
            this.dataGridView = dataGridView;
            AddingBook();
            AddingDataRows();
            DisplayAllBook();
        }

        private void AddingBook()//initilizing the books and adding it to a list
        {
            books.Add(new Book(1, "Green Eggs and Ham"));
            books.Add(new Book(TWO, "Horton Hears a Who"));
            books.Add(new Book(THREE, "Horton Hatches an Egg"));
            books.Add(new Book(FOUR, "The Cat in the Hat"));
            books.Add(new Book(FIVE, "How the Grinch Stole Christmas"));
            books.Add(new Book(SIX, "You're Only Old Once"));
            books.Add(new Book(SEVEN, "Fox in Socks"));
            books.Add(new Book(EIGHT, "Yertle the Turtle"));
            books.Add(new Book(NINE, "The 500 Hats of Bartholomew Cubbins"));
            books.Add(new Book(TEN, "If I Ran The Circus"));
        }

        private void AddingDataRows()//setting the amount of datagridview rows to the amount of books in the list
        {
            foreach (Book book in books)
            {
                string[] newRow = new string[THREE];
                dataGridView.Rows.Add(newRow);
            }
        }

        private void DisplayBook(Book book)//displaying one book to the datagridview
        {
            int i = book.ID - 1;//this will be use to call the row in the datagridview

            dataGridView.Rows[i].Cells[0].Value = book.ID;
            dataGridView.Rows[i].Cells[1].Value = book.Title;

            if (book.Issued == true)
            {
                dataGridView.Rows[i].Cells[TWO].Value = book.Borrower;
            }

            else if (book.Issued == false)
            {
                dataGridView.Rows[i].Cells[TWO].Value = "In";
            }
        }

        private void DisplayAllBook()//displaying all the books in the list to the datagridview
        {
            foreach (Book book in books)
            {
                DisplayBook(book);
            }
        }

        private void CheckIssued(int iD)//checking if the book has already been issued
        {
            if (books[iD - 1].Issued == true)
            {
                MessageBox.Show("Sorry the book has already been issued to " + books[iD - 1].Borrower);
            }
        }

        public void LibaryIssued(int iD, string borrower)//issueing the book
        {
            CheckIssued(iD);
            books[iD - 1].BookIssued(borrower);
            DisplayAllBook();
        }

        public void LibaryReturn(int iD)//returning the book
        {
            books[iD - 1].BookReturn();
            DisplayAllBook();
        }

        public List<Book> Books
        {
            get
            {
                return books;
            }
        }
    }
}
