namespace AlphaBomberman.Models
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class Bomb
    {
        public static List<Bomb> Bombs = new List<Bomb>();

        private char _bombChar;
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
            this.Clock = 1500000; //miliseconds to boom
            this._bombChar = GameChars.BombChar;
        }

        public int Power;

        public int Row { get; set; }

        public int Column { get; set; }

        public int Range { get; set; }

        public LevelModel Level { get; set; }

        public Stopwatch Timer { get; set; }

        public int Clock { get; set; }

        public void Print(char showCharacter = GameChars.BombChar)
        {
            Console.BackgroundColor = GameColors.BombBackground;
            Console.ForegroundColor = GameColors.BombForeground;
            this.Level.Matrix[Row][Column] = this._bombChar;
            Console.SetCursorPosition(this.Column, this.Row);
            Console.WriteLine(showCharacter);
            Game.RestConsoleColors();
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
            //Blow bomb position
            if (this.Row == Player.PlayerTwoRow && this.Column == Player.PlayerTwoColumn)
            {
                Player.PlayerTwoIsAlive = false;
            }
            if (this.Row == Player.PlayerOneRow && this.Column == Player.PlayerOneColumn)
            {
                Player.PlayerOneIsAlive = false;
            }

            this.Level.Matrix[this.Row][this.Column] = GameChars.EmptySpace;
            Console.SetCursorPosition(this.Column, this.Row);
            Console.Write(GameChars.EmptySpace);
        }

        public static void CheckBombs()
        {
            for (int i = 0; i < Bombs.Count; i++)
            {
                Bomb bomb = Bombs[i];

                if (bomb.Level.Matrix[bomb.Row][bomb.Column] == GameChars.EmptySpace)
                {
                    bomb.Print();
                }

                if (bomb.Timer.ElapsedMilliseconds >= bomb.Clock)
                {
                    bomb.Explode();
                    Bombs.Remove(bomb);
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