//This will set up the grid for the simulation

using System.Windows.Forms;
using System.Drawing;

namespace Conways
{
    public class Grid:DataGridView
    {
        private const int NCELLS = 50;
        private const int CELLSIZE = 10;
        private const int SPACESIZE = 5;
    
        public Grid()//constructor
            : base()
        { 
            // set position of world on the Form:
            Top = 20;
            Left = 20;
                
            // then we can tell the world the number of rows and columns we want to display:
            RowCount = NCELLS;
            ColumnCount = NCELLS;

            // set the properties of the world (which is a DataGridView object):
            Height = NCELLS * CELLSIZE + SPACESIZE;
            Width = NCELLS * CELLSIZE + SPACESIZE; 
            ScrollBars = ScrollBars.None;
            ColumnHeadersVisible = false;
            RowHeadersVisible = false;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                
            foreach (DataGridViewRow r in this.Rows)
                r.Height = CELLSIZE;

            foreach (DataGridViewColumn c in this.Columns)
                c.Width = CELLSIZE;

            // rows and columns should never resize themselves to fit cell contents:
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        
            AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            // prevent user from resizing rows or columns:
            AllowUserToResizeColumns = false;
            AllowUserToResizeRows = false; 
        }

        public void SetCellColour(int index, Color colour)//setting the colour of the blank grid
        {
            int column = index % 50;
            int row = index / 50;
            Rows[row].Cells[column].Style.BackColor = colour;
        }
    }
}
