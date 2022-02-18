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
                    IsDestroyed = false,
                    Tokens = new List<Cell>
                    {
                        new Cell(0,0,"[C]",true),
                        new Cell(0,0,"[C]",true),
                        new Cell(0,0,"[C]",true),
                        new Cell(0,0,"[C]",true),
                        new Cell(0,0,"[C]",true)
                    }
                },
                new Piece()
                {
                    Name = "BattleShip",
                    IsDestroyed = false,
                    Tokens = new List<Cell>
                    {
                        new Cell(0,0,"[B]",true),
                        new Cell(0,0,"[B]",true),
                        new Cell(0,0,"[B]",true),
                        new Cell(0,0,"[B]",true)
                    }
                },
                new Piece()
                {
                    Name = "Destroyer",
                    IsDestroyed = false,
                    Tokens = new List<Cell>
                    {
                        new Cell(0,0,"[D]",true),
                        new Cell(0,0,"[D]",true),
                        new Cell(0,0,"[D]",true)
                    }
                },
                new Piece()
                {
                    Name = "Submarine",
                    IsDestroyed = false,
                    Tokens = new List<Cell>
                    {
                        new Cell(0,0,"[S]",true),
                        new Cell(0,0,"[S]",true),
                        new Cell(0,0,"[S]",true)
                    }
                },
                new Piece()
                {   
                    Name = "Patrol Boat",
                    IsDestroyed = false,
                    Tokens = new List<Cell>
                    {
                        new Cell(0,0,"[P]",true),
                        new Cell(0,0,"[P]",true)
                    }
                }
            };
            PieceItems = new List<Piece>();
            PieceItems.AddRange(p);
        }
    }
}
