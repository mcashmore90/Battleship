using System;
using System.Collections.Generic;
using System.Text;

namespace BoardModel
{
    //Class to hold a piece/boat with the tokens that they take up on the board
    public class Piece
    {
        public string Name { get; set; }
        public bool IsDestroyed { get; set; }
        public List<Cell> Tokens { get; set; }

        //public Piece()
        //{ }
    }
}
