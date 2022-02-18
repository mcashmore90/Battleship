using System;
using System.Collections.Generic;
using System.Text;

namespace BoardModel
{
    //Public class to hold all the Pieces/boats for the game
    public class Pieces
    {
        public List<Piece> PieceItems { get; set; }

        public Pieces()
        {
            SeedData();
        }

        //Seeds data for boat pieces
        //Coordinates set to 0,0 for constructor
        void SeedData()
        {
            List<Piece> p = new List<Piece>
            {
                new Piece()
                {
                    Name = "Carrier",
                    Tokens = new List<Cell>
                    {
                        new Cell(0,0,"[C]"),
                        new Cell(0,0,"[C]"),
                        new Cell(0,0,"[C]"),
                        new Cell(0,0,"[C]"),
                        new Cell(0,0,"[C]")
                    }
                },
                new Piece()
                {
                    Name = "BattleShip",
                    Tokens = new List<Cell>
                    {
                        new Cell(0,0,"[B]"),
                        new Cell(0,0,"[B]"),
                        new Cell(0,0,"[B]"),
                        new Cell(0,0,"[B]")
                    }
                },
                new Piece()
                {
                    Name = "Destroyer",
                    Tokens = new List<Cell>
                    {
                        new Cell(0,0,"[D]"),
                        new Cell(0,0,"[D]"),
                        new Cell(0,0,"[D]")
                    }
                },
                new Piece()
                {
                    Name = "Submarine",
                    Tokens = new List<Cell>
                    {
                        new Cell(0,0,"[S]"),
                        new Cell(0,0,"[S]"),
                        new Cell(0,0,"[S]")
                    }
                },
                new Piece()
                {   Name = "Patrol Boat",
                    Tokens = new List<Cell>
                    {
                        new Cell(0,0,"[P]"),
                        new Cell(0,0,"[P]")
                    }
                }
            };
            PieceItems = new List<Piece>();
            PieceItems.AddRange(p);
        }
    }
}
