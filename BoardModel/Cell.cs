using System;
using System.Collections.Generic;
using System.Text;

namespace BoardModel
{
    public class Cell
    {
        //Properties required for a cell.
        public int RowNumber { get; set; }
        public int ColNumber { get; set; }
        public string Token  { get; set; }
        public bool IsPiece { get; set; }

        public Cell() { }

        public Cell(int row, int col, string token)
        {
            this.RowNumber = row;
            this.ColNumber = col;
            this.Token = token;
            this.IsPiece = false;
        }

        public Cell(int row, int col, string token, bool isPiece)
        {
            this.RowNumber = row;
            this.ColNumber = col;
            this.Token = token;
            this.IsPiece = isPiece;
        }
    }
}
