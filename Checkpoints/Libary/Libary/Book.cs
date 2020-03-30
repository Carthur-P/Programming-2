//holds all the information about the book and who the borrower is if the book has been issued

namespace Libary
{
    public class Book
    {
        private int iD;
        private string title;
        private string borrower;
        private bool issued;

        public Book(int iD, string title)//constructor
        {
            this.iD = iD;
            this.title = title;
        }

        public void BookIssued(string borrower)//setting the borrowers name when the book is issued
        {
            issued = true;
            this.borrower = borrower;
        }

        public void BookReturn()//setting the borrower name to an empty string when the book is return
        {
            issued = false;
            borrower = " ";
        }

        public int ID
        {
            get
            {
                return iD;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
        }

        public string Borrower
        {
            get
            {
                return borrower;
            }
        }

        public bool Issued
        {
            get
            {
                return issued;
            }
        }
    }
}
