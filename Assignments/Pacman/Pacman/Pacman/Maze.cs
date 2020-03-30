//This will inherit the data grid view component which will allow the maze to be form into a 21 x 21 grid by using images with data grid view properties. 

using System.Drawing;
using System.Windows.Forms;

namespace Pacman
{
    public class Maze : DataGridView
    {
        private const int NROWSCOLUMNS = 21; 
        private const int CELLSIZE = 27;
        private const int SPACESIZE = 4;
        private const int NKIBBLES = 151;
        private const string INITMAP =  "bwwwwwwwwwwwwwwwwwwwb" +
                                        "bwkkkkkkkkwkkkkkkkkwb" +
                                        "bwkwwkwwwkwkwwwkwwkwb" +
                                        "bwkkkkkkkkkkkkkkkkkwb" +
                                        "bwkwwkwkwwwwwkwkwwkwb" +
                                        "bwkkkkwkkkwkkkwkkkkwb" +
                                        "bwwwwkwwwbwbwwwkwwwwb" +
                                        "bbbbwkwbbbbbbbwkwbbbb" +
                                        "wwwwwkwbwwbwwbwkwwwww" +
                                        "bbbbbkbbwbbbwbbkbbbbb" +
                                        "wwwwwkwbwwwwwbwkwwwww" +
                                        "bbbbwkwbbbbbbbwkwbbbb" +
                                        "bwwwwkwbwwwwwbwkwwwwb" +
                                        "bwkkkkkkkkwkkkkkkkkwb" +
                                        "bwkwwkwwwkwkwwwkwwkwb" +
                                        "bwkkwkkkkkkkkkkkwkkwb" +
                                        "bwwkwkwkwwwwwkwkwkwwb" +
                                        "bwkkkkwkkkwkkkwkkkkwb" +
                                        "bwkwwwwwwkwkwwwwwwkwb" +
                                        "bwkkkkkkkkkkkkkkkkkwb" +
                                        "bwwwwwwwwwwwwwwwwwwwb";

        private string map;
        private int nKibbles;
        private Bitmap wall;
        private Bitmap kibble;
        private Bitmap blank;

        public Maze(Bitmap k, Bitmap w, Bitmap b)//constructor
            : base()
        {
            map = INITMAP;
            wall = w;
            kibble = k;
            blank = b;
            nKibbles = NKIBBLES; 
            Top = 0;
            Left = 0;
           
            // setup the columns to display images
            for (int x = 0; x < NROWSCOLUMNS; x++)
            {
                Columns.Add(new DataGridViewImageColumn());
            }
            RowCount = NROWSCOLUMNS; //numbers of rows according to number of columns

            // set the properties of the Maze(which is a DataGridView object)
            Height = NROWSCOLUMNS * CELLSIZE + SPACESIZE;
            Width = NROWSCOLUMNS * CELLSIZE + SPACESIZE;
            ScrollBars = ScrollBars.None;
            ColumnHeadersVisible = false;
            RowHeadersVisible = false;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            AllowUserToResizeColumns = false;
            AllowUserToResizeRows = false;

            //setting the size of the cells
            foreach (DataGridViewRow r in this.Rows)
                r.Height = CELLSIZE;

            foreach (DataGridViewColumn c in this.Columns)
                c.Width = CELLSIZE;
        }

        public void Draw()//drawing the maze onto the form
        {
            int totalCells = NROWSCOLUMNS * NROWSCOLUMNS;

            for (int i = 0; i < totalCells; i++)
            {
                int nRow = i / NROWSCOLUMNS;
                int nColumn = i % NROWSCOLUMNS;

                switch (map.Substring(i, 1))//retrieving the string at position 'i' and retrieve the lenght of 1
                {
                    case "w":
                        Rows[nRow].Cells[nColumn].Value = wall;
                        break;
                    case "k":
                        Rows[nRow].Cells[nColumn].Value = kibble;
                        break;
                    case "b":
                        Rows[nRow].Cells[nColumn].Value = blank;
                        break;
                    default:
                        break;
                }
            }
        }

        public Bitmap Kibble
        {
            get
            {
                return kibble;
            }

            set
            {
                kibble = value;
            }
        }

        public Bitmap Wall
        {
            get
            {
                return wall;
            }

            set
            {
                wall = value;
            }
        }

        public Bitmap Blank
        {
            get
            {
                return blank;
            }

            set
            {
                blank = value;
            }
        }

        public int NKibbles
        {
            get
            {
                return nKibbles;
            }

            set
            {
                nKibbles = value;
            }
        }

        public string Map
        {
            get
            {
                return map;
            }

            set
            {
                map = value;
            }
        }
    }
}
