using System;
using BoardModel;

namespace Battleship
{
    class Program
    {
        //Fields
        Board myBoard = new Board(11, 11);
        Pieces myPieces = new Pieces();

        static void Main(string[] args)
        {
            (new Program()).Run();
        }

        //Main method to run the program
        void Run()
        {
            SetPieces();
            Console.WriteLine("START");
            while(true)
            {    
                myBoard.DisplayBoard();
                Console.Write("Select coordinates: ");
                int[] input = myBoard.GetCoordinates(Console.ReadLine());
                Console.Clear();
                myBoard.CheckHit(input[0], input[1]);
            }
            
            Console.Read();
        }

        //Hard coding pieces onto the board
        void SetPieces()
        {
            //Various boat pieces
            myBoard.SetPieces(4, 2, myPieces.Carrier, false);
            myBoard.SetPieces(5, 6, myPieces.BattleShip, true);
            myBoard.SetPieces(6, 5, myPieces.Destroyer, false);
            myBoard.SetPieces(2, 4, myPieces.Submarine, true);
            myBoard.SetPieces(3, 5, myPieces.Patrol, true);

            //Mark to show where placing of the piece will start
            myBoard.SetMark(8,8);
        }
    }
}
