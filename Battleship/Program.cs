using System;
using System.Collections.Generic;
using BoardModel;

namespace Battleship
{
    class Program
    {
        //Fields
       // Controller myBoard = new Controller(11, 11);
        Board myBoard = new Board();
        List<Piece> myPieces = new Pieces().PieceItems;

        static void Main(string[] args)
        {
            (new Program()).Run();
        }

        //Main method to run the program
        void Run()
        {
            SetPieces();
            while(true)
            {    
                
                myBoard.DisplayBoard();
                Console.Write("Select coordinates: ");
                int[] input = myBoard.GetCoordinates(Console.ReadLine());
                Console.Clear();

                CheckDestroyed(myBoard.CheckHit(input[0], input[1]));  
            }
        }

        //Hard coding pieces onto the board
        void SetPieces()
        {
            //Various boat pieces
            myBoard.SetPieces(4, 2, myPieces[0].Tokens, false);
            myBoard.SetPieces(5, 6, myPieces[1].Tokens, true);
            myBoard.SetPieces(6, 5, myPieces[2].Tokens, false);
            myBoard.SetPieces(2, 4, myPieces[3].Tokens, true);
            myBoard.SetPieces(3, 5, myPieces[4].Tokens, true);

            //Mark to show where placing of the piece will start
            myBoard.SetMark(8,8);
        }

        public void CheckDestroyed(Cell piece)
        {
            //NOTE: work in progress. checking if the boat/piece is destroyed

            foreach(Piece p in myPieces)
            {
                //var t = p.Tokens.Find(d=>d.Token ==piece.Token);
                var t = p.Tokens.Exists(d=>d.Token == piece.Token);
                if(t)
                {
                    p.Tokens.RemoveAt(p.Tokens.Count-1);
                }
            }
            //var i = myPieces.Find(c => c.Tokens.Find(t=>t.Token.Contains(piece.Token)));
            //myPieces.Remove();
            //var c = myPieces.Find(c => c.Tokens.Contains(piece));
        }
    }
}
