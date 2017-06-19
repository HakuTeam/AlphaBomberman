namespace AlphaBomberman.Models
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class Bomb
    {
        public static List<Bomb> Bombs = new List<Bomb>();
        //public static bool playerOneBombReady = true;
        //public static bool playerTwoBombReady = true;
        //public static Bomb playerOneBomb;
        //public static Bomb playerTwoBomb;

        public Bomb(int row, int column, LevelModel level, int range = 3)
        {
            this.Row = row;
            this.Column = column;
            this.Level = level;
            this.Range = range;
            this.Timer = new Stopwatch();
            this.Timer.Start();
            this.Level.Matrix[this.Row][this.Column] = GameChars.BombChar;
            this.Print();
            this.Clock = 500; //miliseconds to boom
        }

        public int Power;

        public int Row { get; set; }

        public int Column { get; set; }

        public int Range { get; set; }

        public LevelModel Level { get; set; }

        public Stopwatch Timer { get; set; }

        public int Clock { get; set; }

        public void Print()
        {
            Console.SetCursorPosition(this.Column, this.Row);
            Console.WriteLine(GameChars.BombChar);
        }

        public void Explode()
        {
            //Blow UP
            for (int explodeRow = this.Row - 1; explodeRow >= this.Row - this.Range; explodeRow--)
            {
                if (this.Level.Matrix[explodeRow][this.Column] == GameChars.IndestructibleWall)
                {
                    break;
                }

                if (this.Level.Matrix[explodeRow][this.Column] == GameChars.DestructibleWall)
                {
                    this.Level.Matrix[explodeRow][this.Column] = GameChars.EmptySpace;
                    PrintBlownUpToEmpty(explodeRow, this.Column);
                    break;
                }

                if (this.Level.Matrix[explodeRow][this.Column] == GameChars.PlayerOneChar)
                {
                    this.Level.Matrix[explodeRow][this.Column] = GameChars.EmptySpace;
                    Player.PlayerOneIsAlive = false;
                }

                if (this.Level.Matrix[explodeRow][this.Column] == GameChars.PlayerTwoChar)
                {
                    this.Level.Matrix[explodeRow][this.Column] = GameChars.EmptySpace;
                    Player.PlayerTwoIsAlive = false;
                }
            }

            //Blow Down
            for (int explodeRow = this.Row; explodeRow <= this.Row + this.Range; explodeRow++)
            {
                if (this.Level.Matrix[explodeRow][this.Column] == GameChars.IndestructibleWall)
                {
                    break;
                }

                if (this.Level.Matrix[explodeRow][this.Column] == GameChars.DestructibleWall)
                {
                    this.Level.Matrix[explodeRow][this.Column] = GameChars.EmptySpace;
                    PrintBlownUpToEmpty(explodeRow, this.Column);
                    break;
                }

                if (this.Level.Matrix[explodeRow][this.Column] == GameChars.PlayerOneChar)
                {
                    this.Level.Matrix[explodeRow][this.Column] = GameChars.EmptySpace;
                    Player.PlayerOneIsAlive = false;
                }

                if (this.Level.Matrix[explodeRow][this.Column] == GameChars.PlayerTwoChar)
                {
                    this.Level.Matrix[explodeRow][this.Column] = GameChars.EmptySpace;
                    Player.PlayerTwoIsAlive = false;
                }
            }

            //Blow Right
            for (int explodeColumn = this.Column; explodeColumn <= this.Column + this.Range; explodeColumn++)
            {
                if (this.Level.Matrix[this.Row][explodeColumn] == GameChars.IndestructibleWall)
                {
                    break;
                }

                if (this.Level.Matrix[this.Row][explodeColumn] == GameChars.DestructibleWall)
                {
                    this.Level.Matrix[this.Row][explodeColumn] = GameChars.EmptySpace;
                    PrintBlownUpToEmpty(this.Row, explodeColumn);
                    break;
                }

                if (this.Level.Matrix[this.Row][explodeColumn] == GameChars.PlayerOneChar)
                {
                    this.Level.Matrix[this.Row][explodeColumn] = GameChars.EmptySpace;
                    Player.PlayerOneIsAlive = false;
                }

                if (this.Level.Matrix[this.Row][explodeColumn] == GameChars.PlayerTwoChar)
                {
                    this.Level.Matrix[this.Row][explodeColumn] = GameChars.EmptySpace;
                    Player.PlayerTwoIsAlive = false;
                }
            }

            //Blow Left
            for (int explodeColumn = this.Column; explodeColumn >= this.Column - this.Range; explodeColumn--)
            {
                if (this.Level.Matrix[this.Row][explodeColumn] == GameChars.IndestructibleWall)
                {
                    break;
                }

                if (this.Level.Matrix[this.Row][explodeColumn] == GameChars.DestructibleWall)
                {
                    this.Level.Matrix[this.Row][explodeColumn] = GameChars.EmptySpace;
                    PrintBlownUpToEmpty(this.Row, explodeColumn);
                    break;
                }

                if (this.Level.Matrix[this.Row][explodeColumn] == GameChars.PlayerOneChar)
                {
                    this.Level.Matrix[this.Row][explodeColumn] = GameChars.EmptySpace;
                    Player.PlayerOneIsAlive = false;
                }

                if (this.Level.Matrix[this.Row][explodeColumn] == GameChars.PlayerTwoChar)
                {
                    this.Level.Matrix[this.Row][explodeColumn] = GameChars.EmptySpace;
                    Player.PlayerTwoIsAlive = false;
                }
            }
        }

        public static void CheckBombs()
        {
            while (Player.PlayerOneIsAlive || Player.PlayerTwoIsAlive)
            {
                for (int i = 0; i < Bombs.Count; i++)
                {
                    if (Bombs[i].Timer.ElapsedMilliseconds >= Bombs[i].Clock)
                    {
                        Bombs[i].Explode();
                        Bombs.Remove(Bombs[i]);
                    }
                }
            }
        }

        private static void PrintBlownUpToEmpty(int row, int col)
        {
            Console.SetCursorPosition(col, row);
            Console.Write(GameChars.EmptySpace);
        }
    }
}