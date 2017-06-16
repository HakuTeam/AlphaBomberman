namespace AlphaBomberman.Models
{
    using System;
    using System.Diagnostics;
    using System.Timers;

    public class Bomb
    {
        public Bomb(int row, int column, LevelModel level, int range = 3)
        {
            Row = row;
            Column = column;
            Level = level;
            Range = range;
            Timer = new Stopwatch();
            Timer.Start();
            Level.Matrix[Row][Column] = GameChars.bombChar;
            Print();
            Clock = 200; //miliseconds to boom
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
            Console.WriteLine(GameChars.bombChar);
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
                    if (Level.Matrix[rowIndex][bombCoordinatesCol] == GameChars.destructibleWall)
                    {
                        Level.Matrix[rowIndex][bombCoordinatesCol] = ' ';
                        Console.SetCursorPosition(bombCoordinatesCol, rowIndex);
                        Console.Write(' ');
                        break;
                    }
                    else if (Level.Matrix[rowIndex][bombCoordinatesCol] == '#')
                    {
                        break;
                    }
                    else if (Level.Matrix[rowIndex][bombCoordinatesCol] == 'P' || Level.Matrix[rowIndex][bombCoordinatesCol] == 'K')
                    {
                        Level.Matrix[rowIndex][bombCoordinatesCol] = ' ';
                    }
                    else if (Level.Matrix[rowIndex][bombCoordinatesCol] == 'B')
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
                    if (Level.Matrix[rowIndex][bombCoordinatesCol] == GameChars.destructibleWall)
                    {
                        Level.Matrix[rowIndex][bombCoordinatesCol] = ' ';
                        Console.SetCursorPosition(bombCoordinatesCol, rowIndex);
                        Console.Write(' ');
                        break;
                    }
                    else if (Level.Matrix[rowIndex][bombCoordinatesCol] == '#')
                    {
                        break;
                    }
                    else if (Level.Matrix[rowIndex][bombCoordinatesCol] == 'P' || Level.Matrix[rowIndex][bombCoordinatesCol] == 'K')
                    {
                        Level.Matrix[rowIndex][bombCoordinatesCol] = ' ';
                    }
                    else if (Level.Matrix[rowIndex][bombCoordinatesCol] == 'B')
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
                    if (Level.Matrix[bombCoordinatesRow][colIndex] == GameChars.destructibleWall)
                    {
                        Level.Matrix[bombCoordinatesRow][colIndex] = ' ';
                        Console.SetCursorPosition(colIndex, bombCoordinatesRow);
                        Console.Write(' ');
                        break;
                    }
                    else if (Level.Matrix[bombCoordinatesRow][colIndex] == '#')
                    {
                        break;
                    }
                    else if (Level.Matrix[bombCoordinatesRow][colIndex] == 'P' || Level.Matrix[bombCoordinatesRow][colIndex] == 'K')
                    {
                        Level.Matrix[bombCoordinatesRow][colIndex] = ' ';
                    }
                    else if (Level.Matrix[bombCoordinatesRow][colIndex] == 'B')
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
                    if (Level.Matrix[bombCoordinatesRow][colIndex] == GameChars.destructibleWall)
                    {
                        Level.Matrix[bombCoordinatesRow][colIndex] = ' ';
                        Console.SetCursorPosition(colIndex, bombCoordinatesRow);
                        Console.Write(' ');
                        break;
                    }
                    else if (Level.Matrix[bombCoordinatesRow][colIndex] == '#')
                    {
                        break;
                    }
                    else if (Level.Matrix[bombCoordinatesRow][colIndex] == 'P' || Level.Matrix[bombCoordinatesRow][colIndex] == 'K')
                    {
                        Level.Matrix[bombCoordinatesRow][colIndex] = ' ';
                    }
                    else if (Level.Matrix[bombCoordinatesRow][colIndex] == 'B')
                    {
                        BombExplosion.Explosion(bombCoordinatesRow, colIndex);
                    }
                }
            }
            //Level[bombCoordinatesRow][bombCoordinatesCol] = ' '; //-> NOT WORKING FOR SOME REASON

            //for (int i = 0; i < Level.Matrix.Length; i++)
            //{
            //    Console.WriteLine(string.Join("", Level.Matrix[i]));
            //}
            //return Level;
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
