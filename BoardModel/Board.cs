using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoardModel
{
    public class Board
    {
        private int SizeX { get; set; }
        private int SizeY { get; set; }
        private Cell[,] TheBoard { get; set; }

        //Constructor
        public Board(int x, int y)
        {
            this.SizeX = x;
            this.SizeY = y;

            //2D array
            this.TheBoard = new Cell[x, y];

            //Sets 2D array with X and Y coordinates
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    if (i == 0 && j == 0)
                        //The top left corner of the board
                        this.TheBoard[j, i] = new Cell(x, y, "    ");
                    else
                        //The rest of the board
                        this.TheBoard[j, i] = new Cell(x, y, "[~]");
                }
            }

            //Sets up the coordinates on the edge of the board
            SetBoardEdge();
        }

        //Display the board to the screen
        public void DisplayBoard()
        {
            for (int i = 0; i < this.SizeX; i++)
            {
                for (int j = 0; j < this.SizeY; j++)
                {
                    if (this.TheBoard[i, j].Token == "[~]")
                    {
                        Console.Write("[");//Colors piece 
                        Console.Write("~", Console.ForegroundColor = ConsoleColor.Blue);
                        Console.ResetColor();
                        Console.Write("]");
                    }
                    else if (this.TheBoard[i, j].Token == "[0]")
                    {
                        Console.Write("[");
                        Console.Write("0", Console.ForegroundColor = ConsoleColor.DarkGray);
                        Console.ResetColor();
                        Console.Write("]");
                    }
                    else if (this.TheBoard[i, j].Token == "[X]")
                    {
                        Console.Write("[");
                        Console.Write("X", Console.ForegroundColor = ConsoleColor.Red);
                        Console.ResetColor();
                        Console.Write("]");
                    }
                    else if (this.TheBoard[i, j].Token == "[T]")
                    {
                        Console.Write("[");
                        Console.Write("T", Console.ForegroundColor = ConsoleColor.Green);
                        Console.ResetColor();
                        Console.Write("]");
                    }
                    //ONLY for board edges
                    else
                        Console.Write(this.TheBoard[i, j].Token);
                }
                Console.WriteLine();
            }
        }

        //Sets the edge of the board with coordinates
        private void SetBoardEdge()
        {
            //Set top bar coordinates
            string[] top = new string[] { "    ", " A ", " B ", " C ", " D ", " E ", " F ", " G ", " H ", " I ", " J ", };
            for (int i = 1; i < this.SizeX; i++)
            {
                this.TheBoard[0, i].Token = top[i];
            }

            //Set side bar coordinates
            for (int i = 1; i < this.SizeY; i++)
            {
                this.TheBoard[i, 0].Token = $"[ {i}]";
                if (i >= 10)
                    this.TheBoard[i, 0].Token = $"[{i}]";
            }
        }

        //Takes in X and Y coordinates, boat, and if it's set vertically
        //Asigns the cells to the boat pieces
        public void SetPieces(int x, int y, List<Cell> boat, bool vert)
        {

            //Validation to be implemented to ensure placement isn't ontop
            //of another piece or off the edge of the board.

            //int placement = 0;
            //try
            //{
                if (vert)
                {
                    for (int i = 0; i < boat.Count; i++)
                    {
                        this.TheBoard[y + i, x].Token = boat[i].Token;
                    }
                }
                else
                {
                    for (int i = 0; i < boat.Count; i++)
                    {
                        this.TheBoard[y, x + i].Token = boat[i].Token;
                        //placement++;
                        //throw new Exception();
                    }
                }
            //}
            //catch
            //{
            //    Console.WriteLine("Hello");
            //    for (int i = 0; i < placement; i++)
            //    {
            //        this.TheBoard[y, x + i].Token = "[~]";
            //    }
            //}
        }

        //Mark to show placement of piece
        public void SetMark(int x, int y)
        {
            this.TheBoard[y, x].Token = "[T]";
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
                    coord[1] = int.Parse(inputArray[i].ToString());
                //assigns char to number
                else
                    coord[0] = char.ToUpper(inputArray[i]) - 64;
            }

            return coord;
        }

        //Takes in X and Y cordinates
        //Checks if it's a HIT or MISS
        //Sets token
        public void CheckHit(int x, int y)
        {
            switch (this.TheBoard[y, x].Token)
            {
                case "[~]":
                    Console.WriteLine("MISS");
                    this.TheBoard[y, x].Token = "[0]";
                    break;
                //Boat tokens
                case "[C]":
                case "[B]":
                case "[D]":
                case "[S]":
                case "[P]":
                    Console.WriteLine("HIT");
                    this.TheBoard[y, x].Token = "[X]";
                    break;
                case "[0]":
                case "[X]":
                default:
                    Console.WriteLine("Invalid");
                    break;
            }
        }
    }
}
