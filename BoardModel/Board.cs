using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoardModel
{
    public class Board
    {
        private int SizeX = 11;
        private int SizeY = 11;
        //public Cell[,] TheBoard { get; set; }
        List<Cell> TheBoard = new List<Cell>();

        //Constructor
        public Board()
        { 
            string[] top = new string[] { "    ", " A ", " B ", " C ", " D ", " E ", " F ", " G ", " H ", " I ", " J ", };

            //Row
            for (int i = 0; i<this.SizeY;i++)
            {
                //Column
                for(int j = 0; j<this.SizeX;j++)
                {
                    Cell c = new Cell();
                    c.ColNumber = j;
                    c.RowNumber = i;

                    //Sets the top of the board
                    if (i == 0)
                    {
                        c.Token = top[j];
                    }
                    //Sets the side of the board
                    else if (j == 0)
                    {
                        c.Token = $"[ {i}]";
                        if (i >= 10)
                            c.Token = $"[{i}]";
                    }
                    //Regular board piece
                    else
                        c.Token = "[~]";

                    TheBoard.Add(c);
                }
            }
        }

        //Display the board to the screen
        public void DisplayBoard()
        {
            foreach (Cell c in TheBoard)
            {
                if (c.Token == "[~]")
                {
                    Console.Write("[");//Colors piece 
                    Console.Write("~", Console.ForegroundColor = ConsoleColor.Blue);
                    Console.ResetColor();
                    Console.Write("]");
                }
                else if (c.Token == "[0]")
                {
                    Console.Write("[");
                    Console.Write("0", Console.ForegroundColor = ConsoleColor.DarkGray);
                    Console.ResetColor();
                    Console.Write("]");
                }
                else if (c.Token == "[X]")
                {
                    Console.Write("[");
                    Console.Write("X", Console.ForegroundColor = ConsoleColor.Red);
                    Console.ResetColor();
                    Console.Write("]");
                }
                else if (c.Token == "[T]")
                {
                    Console.Write("[");
                    Console.Write("T", Console.ForegroundColor = ConsoleColor.Green);
                    Console.ResetColor();
                    Console.Write("]");
                }
                //ONLY for board edges
                else
                    Console.Write(c.Token);
                //Puts row onto new line
                if (c.ColNumber == SizeX - 1)
                    Console.WriteLine();
            }
        }

        //Takes in X and Y coordinates, boat, and if it's set vertically
        //Asigns the cells to the boat pieces
        public void SetPieces(int x, int y, List<Cell> boat, bool vert)
        {

            if (vert)
            {
                for (int i = 0; i < boat.Count; i++)
                {
                    Cell c = TheBoard.Find(b => (b.ColNumber == x) && (b.RowNumber == y + i));
                    c.Token = boat[i].Token;
                    c.IsPiece = boat[i].IsPiece;
                }
            }
            else
            {
                for (int i = 0; i < boat.Count; i++)
                {
                    Cell c = TheBoard.Find(b => (b.ColNumber == x + i) && (b.RowNumber == y));
                    c.Token = boat[i].Token;
                    c.IsPiece = boat[i].IsPiece;
                }
            }
        }

        //Mark to show placement of piece
        public void SetMark(int x, int y)
        {
            var c = TheBoard.Find(b => (b.ColNumber == x) && (b.RowNumber == y));
            c.Token = "[T]";
        }

        public void SetHit(int x, int y, bool hit)
        {
            Cell c = TheBoard.Find(b => (b.ColNumber == x) && (b.RowNumber == y));
            if (hit)
                c.Token = "[X]";
            else
                c.Token = "[O]";
        }

        //Takes in X and Y cordinates
        //returns if it's a HIT or MISS
        public Cell CheckHit(int x, int y)
        {
            Cell c = TheBoard.Find(b => (b.ColNumber == x) && (b.RowNumber == y));
            Cell boat = new Cell();
            boat.Token = c.Token;

            if (c.IsPiece)
            {
                c.Token = "[X]";
            }
                
            else
                c.Token = "[O]";

            return boat;
        }

        //Takes in user input for coordinates and converts to an array[2]
        //index 0 is Vertical X
        //index 1 is horizontal Y
        public int[] GetCoordinates(string input)
        {
            //converts input to a char[] for proper iteration
            char[] inputArray;
            inputArray = input.ToCharArray();

            //checks if index is either a number or letter
            //assigns value to index in proper format.
            int[] coord = new int[2];

            for (int i = 0; i < inputArray.Length; i++)
            {
                //assigns number
                if (int.TryParse(inputArray[i].ToString(), out _))
                {
                    int num = int.Parse(inputArray[i].ToString());
                    if (num == 0)
                    {
                        coord[1] = 10;
                    }
                    else
                        coord[1] = num;
                }

                //assigns char to number
                else
                    coord[0] = char.ToUpper(inputArray[i]) - 64;
            }

            return coord;
        }
    }
}
