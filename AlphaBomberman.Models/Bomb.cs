namespace AlphaBomberman.Models
{
    using System;
    using System.Diagnostics;

    public class Bomb
    {
        public Bomb(int row, int column, LevelModel level, int range = 3)
        {
            this.Row = row;
            this.Column = column;
            this.Level = level;
            this.Range = range;
            this.Timer = new Stopwatch();
            this.Timer.Start();
            this.Level.Matrix[Row][Column] = GameChars.BombChar;
            this.Print();
            this.Clock = 200; //miliseconds to boom
        }

        public int Row { get; set; }

        public int Column { get; set; }

        public int Power;

        public int Range { get; set; }

        public LevelModel Level { get; set; }

        public Stopwatch Timer { get; set; }
        public int Clock { get; set; }

        public void Print()
        {
            Console.SetCursorPosition(Column, Row);
            Console.WriteLine(GameChars.BombChar);
        }

        public void Explode()
        {
            var bombCoordinatesRow = this.Row;
            var bombCoordinatesCol = this.Column;


            //blow left
            for (int rowIndex = bombCoordinatesRow - this.Range; rowIndex < bombCoordinatesRow; rowIndex++)
            {
                if (IsInMatrix(rowIndex, bombCoordinatesCol, Level.Matrix))
                {
                    if (Level.Matrix[rowIndex][bombCoordinatesCol] == GameChars.DestructibleWall)
                    {
                        Level.Matrix[rowIndex][bombCoordinatesCol] = GameChars.EmptySpace;
                        //PrintBlownUpToEmpty(rowIndex, bombCoordinatesCol);
                        break;
                    }
                    else if (Level.Matrix[rowIndex][bombCoordinatesCol] == GameChars.IndestructibleWall)
                    {
                        break;
                    }
                    else if (Level.Matrix[rowIndex][bombCoordinatesCol] == GameChars.PlayerOneChar || Level.Matrix[rowIndex][bombCoordinatesCol] == GameChars.PlayerTwoChar)
                    {
                        Level.Matrix[rowIndex][bombCoordinatesCol] = GameChars.EmptySpace;
                    }
                    else if (Level.Matrix[rowIndex][bombCoordinatesCol] == GameChars.BombChar)
                    {
                        BombExplosion.Explosion(rowIndex, bombCoordinatesCol);
                    }
                }
            }
            //blow right
            for (int rowIndex = bombCoordinatesRow + 1; rowIndex <= bombCoordinatesRow + this.Range; rowIndex++)
            {
                if (IsInMatrix(rowIndex, bombCoordinatesCol, Level.Matrix))
                {
                    if (Level.Matrix[rowIndex][bombCoordinatesCol] == GameChars.DestructibleWall)
                    {
                        Level.Matrix[rowIndex][bombCoordinatesCol] = GameChars.EmptySpace;
                        //PrintBlownUpToEmpty(bombCoordinatesCol, rowIndex);
                        break;
                    }
                    else if (Level.Matrix[rowIndex][bombCoordinatesCol] == GameChars.IndestructibleWall)
                    {
                        break;
                    }
                    else if (Level.Matrix[rowIndex][bombCoordinatesCol] == GameChars.PlayerOneChar || Level.Matrix[rowIndex][bombCoordinatesCol] == GameChars.PlayerTwoChar)
                    {
                        Level.Matrix[rowIndex][bombCoordinatesCol] = GameChars.EmptySpace;
                    }
                    else if (Level.Matrix[rowIndex][bombCoordinatesCol] == GameChars.BombChar)
                    {
                        BombExplosion.Explosion(rowIndex, bombCoordinatesCol);
                    }
                }
            }
            //blow up
            for (int colIndex = bombCoordinatesCol - this.Range; colIndex < bombCoordinatesCol; colIndex++)
            {
                if (IsInMatrix(bombCoordinatesRow, colIndex, Level.Matrix))
                {
                    if (Level.Matrix[bombCoordinatesRow][colIndex] == GameChars.DestructibleWall)
                    {
                        Level.Matrix[bombCoordinatesRow][colIndex] = GameChars.EmptySpace;
                        //PrintBlownUpToEmpty(bombCoordinatesCol, colIndex);
                        break;
                    }
                    else if (Level.Matrix[bombCoordinatesRow][colIndex] == GameChars.IndestructibleWall)
                    {
                        break;
                    }
                    else if (Level.Matrix[bombCoordinatesRow][colIndex] == GameChars.PlayerOneChar || Level.Matrix[bombCoordinatesRow][colIndex] == GameChars.PlayerTwoChar)
                    {
                        Level.Matrix[bombCoordinatesRow][colIndex] = GameChars.EmptySpace;
                    }
                    else if (Level.Matrix[bombCoordinatesRow][colIndex] == GameChars.BombChar)
                    {
                        BombExplosion.Explosion(bombCoordinatesRow, colIndex);
                    }
                }
            }
            //blow down
            for (int colIndex = bombCoordinatesCol + 1; colIndex < bombCoordinatesCol + this.Range; colIndex++)
            {
                if (IsInMatrix(bombCoordinatesRow, colIndex, Level.Matrix))
                {
                    if (Level.Matrix[bombCoordinatesRow][colIndex] == GameChars.DestructibleWall)
                    {
                        Level.Matrix[bombCoordinatesRow][colIndex] = GameChars.EmptySpace;
                        //PrintBlownUpToEmpty(bombCoordinatesCol, colIndex);
                        break;
                    }
                    else if (Level.Matrix[bombCoordinatesRow][colIndex] == GameChars.IndestructibleWall)
                    {
                        break;
                    }
                    else if (Level.Matrix[bombCoordinatesRow][colIndex] == GameChars.PlayerOneChar || Level.Matrix[bombCoordinatesRow][colIndex] == GameChars.PlayerTwoChar)
                    {
                        Level.Matrix[bombCoordinatesRow][colIndex] = GameChars.EmptySpace;
                    }
                    else if (Level.Matrix[bombCoordinatesRow][colIndex] == GameChars.BombChar)
                    {
                        BombExplosion.Explosion(bombCoordinatesRow, colIndex);
                    }
                }
            }

            //Level[bombCoordinatesRow][bombCoordinatesCol] = GameChars.EmptySpace; //-> NOT WORKING FOR SOME REASON

            //for (int i = 0; i < Level.Matrix.Length; i++)
            //{
            //    Console.WriteLine(string.Join("", Level.Matrix[i]));
            //}
            // return Level;
        }

        private static void PrintBlownUpToEmpty(int row, int col)
        {
            Console.SetCursorPosition(row, col);
            Console.Write(GameChars.EmptySpace);
        }

        private static bool IsInMatrix(int currentRow, int currentCol, char[][] Level)
        {
            if (currentRow >= 0 && currentRow < Level.Length &&
                currentCol >= 0 && currentCol < Level[currentRow].Length)
            {
                return true;
            }

            return false;
        }

        //Not quite sure whether to put it with the mobs or the player so I decided both 
    }
}