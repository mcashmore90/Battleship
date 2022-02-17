using System;
using System.Collections.Generic;
using System.Text;

namespace BoardModel
{
    public class Pieces
    {
        public List<Cell> Carrier { get; set; }
        public List<Cell> BattleShip { get; set; }
        public List<Cell> Destroyer { get; set; }
        public List<Cell> Submarine { get; set; }
        public List<Cell> Patrol { get; set; }

        public Pieces()
        {
            SeedData();
        }

        //Seeds data for boat pieces
        //Coordinates set to 0,0 for constructor
        private void SeedData()
        {
            //Set Carrier pieces
            Carrier = new List<Cell> {
                new Cell(0,0,"[C]"),
                new Cell(0,0,"[C]"),
                new Cell(0,0,"[C]"),
                new Cell(0,0,"[C]"),
                new Cell(0,0,"[C]")
            };
            //Set Battleship
            BattleShip=new List<Cell> {
                new Cell(0,0,"[B]"),
                new Cell(0,0,"[B]"),
                new Cell(0,0,"[B]"),
                new Cell(0,0,"[B]")
            };

            //Set Destroyer
            Destroyer = new List<Cell> {
                new Cell(0,0,"[D]"),
                new Cell(0,0,"[D]"),
                new Cell(0,0,"[D]")
            };

            //Set Submarine
            Submarine = new List<Cell> {
                new Cell(0,0,"[S]"),
                new Cell(0,0,"[S]"),
                new Cell(0,0,"[S]")
            };

            //Set Patrol Boat
            Patrol = new List<Cell> {
                new Cell(0,0,"[P]"),
                new Cell(0,0,"[P]")
            };
        }
    }
}
