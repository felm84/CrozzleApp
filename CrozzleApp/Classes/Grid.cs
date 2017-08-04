using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrozzleApp.Classes
{
    class Grid
    {
        private int rows;
        private int columns;

        public Grid(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
        }

        public int Rows { get => rows; set => rows = value; }
        public int Columns { get => columns; set => columns = value; }
    }
}
