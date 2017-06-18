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
            //Blow UP
            for (int explodeRow = Row - 1; explodeRow >= Row - Range; explodeRow--)
            {
                if (Level.Matrix[explodeRow][Column] == GameChars.IndestructibleWall)
                {
                    break;
                }
                if (Level.Matrix[explodeRow][Column] == GameChars.DestructibleWall)
                {
                    Level.Matrix[explodeRow][Column] = GameChars.EmptySpace;
                    PrintBlownUpToEmpty(explodeRow, Column);
                    break;
                }
                if (
                    Level.Matrix[explodeRow][Column] == GameChars.PlayerOneChar || Level.Matrix[explodeRow][Column] == GameChars.PlayerTwoChar
                    )
                {
                    Level.Matrix[explodeRow][Column] = GameChars.EmptySpace;
                    //TO DO: Player.Kill() or PLayer.Life --;
                }
                //TO DO: Destroy bombs Game.Bombs.RemoveByCoords(Rox,Column);
                //else if (Level.Matrix[explodeRow][Column] == GameChars.BombChar)
                //{
                //    //BombExplosion.Explosion(rowIndex, Column);
                //}
            }

            //Blow Down
            for (int explodeRow = Row; explodeRow <= Row + Range; explodeRow++)
            {
                if (Level.Matrix[explodeRow][Column] == GameChars.IndestructibleWall)
                {
                    break;
                }
                if (Level.Matrix[explodeRow][Column] == GameChars.DestructibleWall)
                {
                    Level.Matrix[explodeRow][Column] = GameChars.EmptySpace;
                    PrintBlownUpToEmpty(explodeRow, Column);
                    break;
                }
                if (
                    Level.Matrix[explodeRow][Column] == GameChars.PlayerOneChar || Level.Matrix[explodeRow][Column] == GameChars.PlayerTwoChar
                    )
                {
                    Level.Matrix[explodeRow][Column] = GameChars.EmptySpace;
                    //TO DO: Player.Kill() or PLayer.Life --;
                }
                //TO DO: Destroy bombs Game.Bombs.RemoveByCoords(Rox,Column);
                //else if (Level.Matrix[explodeRow][Column] == GameChars.BombChar)
                //{
                //    //BombExplosion.Explosion(rowIndex, Column);
                //}
            }

            //Blow Right
            for (int explodeColumn = Column; explodeColumn <= Column + Range; explodeColumn++)
            {
                if (Level.Matrix[Row][explodeColumn] == GameChars.IndestructibleWall)
                {
                    break;
                }
                if (Level.Matrix[Row][explodeColumn] == GameChars.DestructibleWall)
                {
                    Level.Matrix[Row][explodeColumn] = GameChars.EmptySpace;
                    PrintBlownUpToEmpty(Row, explodeColumn);
                    break;
                }
                if (
                    Level.Matrix[Row][explodeColumn] == GameChars.PlayerOneChar || Level.Matrix[Row][explodeColumn] == GameChars.PlayerTwoChar
                    )
                {
                    Level.Matrix[Row][explodeColumn] = GameChars.EmptySpace;
                    //TO DO: Player.Kill() or PLayer.Life --;
                }
                //TO DO: Destroy bombs Game.Bombs.RemoveByCoords(Rox,Column);
                //else if (Level.Matrix[colIndex][Column] == GameChars.BombChar)
                //{
                //    //BombExplosion.Explosion(rowIndex, Column);
                //}
            }

            //Blow Left
            for (int explodeColumn = Column; explodeColumn >= Column-Range; explodeColumn--)
            {
                if (Level.Matrix[Row][explodeColumn] == GameChars.IndestructibleWall)
                {
                    break;
                }
                if (Level.Matrix[Row][explodeColumn] == GameChars.DestructibleWall)
                {
                    Level.Matrix[Row][explodeColumn] = GameChars.EmptySpace;
                    PrintBlownUpToEmpty(Row, explodeColumn);
                    break;
                }
                if (Level.Matrix[Row][explodeColumn] == GameChars.PlayerOneChar || Level.Matrix[Row][explodeColumn] == GameChars.PlayerTwoChar)
                {
                    Level.Matrix[Row][explodeColumn] = GameChars.EmptySpace;
                    //TO DO: Player.Kill() or PLayer.Life --;
                }
                //TO DO: Destroy bombs Game.Bombs.RemoveByCoords(Rox,Column);
                //else if (Level.Matrix[colIndex][Column] == GameChars.BombChar)
                //{
                //    //BombExplosion.Explosion(rowIndex, Column);
                //}
            }
        }

        private static void PrintBlownUpToEmpty(int row, int col)
        {
            Console.SetCursorPosition(col,row);
            Console.Write(GameChars.EmptySpace);
        }
    }
}