namespace AlphaBomberman.Models
{
    using System;
    using System.Collections.Generic;
    using Utilities.Ennumetation;

    public class Player
    {
        public static LevelModel Level;
        public static int PlayerOneRow;
        public static int PlayerOneColumn;
        public static int PlayerTwoRow;
        public static int PlayerTwoColumn;
        public static List<Bomb> Bombs = new List<Bomb>();

        public Player(LevelModel level)
        {
            Level = level;
            PlayerOneRow = 1;
            PlayerOneColumn = 1;
            PlayerTwoRow = Level.GetDownRightIndex();
            PlayerTwoColumn = Level.Matrix[Level.GetDownRightIndex()].Length - 2;
        }

        public static void Move()
        {
            ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                PlayerOneMove(keyInfo);
                PlayerTwoMove(keyInfo);
                CheckBombs();
            }

            Game.ExecCommand(Command.ExitMenu);
        }

        private static void PlayerOneMove(ConsoleKeyInfo keyInfo)
        {
            if (
                keyInfo.Key == ConsoleKey.RightArrow
                && Level.Matrix[PlayerOneRow][PlayerOneColumn + 1] != GameChars.IndestructibleWall 
                && Level.Matrix[PlayerOneRow][PlayerOneColumn + 1] != GameChars.PlayerTwoChar 
                && Level.Matrix[PlayerOneRow][PlayerOneColumn + 1] != GameChars.DestructibleWall 
                && Level.Matrix[PlayerOneRow][PlayerOneColumn + 1] != GameChars.BombChar
                )
            {
                Level.Matrix[PlayerOneRow][PlayerOneColumn] = GameChars.EmptySpace;
                Console.SetCursorPosition(PlayerOneColumn, PlayerOneRow);
                Console.WriteLine(GameChars.EmptySpace);
                PlayerOneColumn++;
                Console.SetCursorPosition(PlayerOneColumn, PlayerOneRow);
                Console.Write(GameChars.PlayerOneChar);
                Level.Matrix[PlayerOneRow][PlayerOneColumn] = GameChars.PlayerOneChar;
            }
            else if (
                keyInfo.Key == ConsoleKey.LeftArrow 
                && Level.Matrix[PlayerOneRow][PlayerOneColumn - 1] != GameChars.IndestructibleWall 
                && Level.Matrix[PlayerOneRow][PlayerOneColumn - 1] != GameChars.PlayerTwoChar 
                && Level.Matrix[PlayerOneRow][PlayerOneColumn - 1] != GameChars.DestructibleWall 
                && Level.Matrix[PlayerOneRow][PlayerOneColumn - 1] != GameChars.BombChar
                )
            {
                Level.Matrix[PlayerOneRow][PlayerOneColumn] = GameChars.EmptySpace;
                Console.SetCursorPosition(PlayerOneColumn, PlayerOneRow);
                Console.WriteLine(GameChars.EmptySpace);
                PlayerOneColumn--;
                Console.SetCursorPosition(PlayerOneColumn, PlayerOneRow);
                Console.Write(GameChars.PlayerOneChar);
                Level.Matrix[PlayerOneRow][PlayerOneColumn] = GameChars.PlayerOneChar;
            }
            else if (
                keyInfo.Key == ConsoleKey.UpArrow 
                && Level.Matrix[PlayerOneRow - 1][PlayerOneColumn] != GameChars.IndestructibleWall 
                && Level.Matrix[PlayerOneRow - 1][PlayerOneColumn] != GameChars.PlayerTwoChar 
                && Level.Matrix[PlayerOneRow - 1][PlayerOneColumn] != GameChars.DestructibleWall 
                && Level.Matrix[PlayerOneRow - 1][PlayerOneColumn] != GameChars.BombChar
                )
            {
                Level.Matrix[PlayerOneRow][PlayerOneColumn] = GameChars.EmptySpace;
                Console.SetCursorPosition(PlayerOneColumn, PlayerOneRow);
                Console.WriteLine(GameChars.EmptySpace);
                PlayerOneRow--;
                Console.SetCursorPosition(PlayerOneColumn, PlayerOneRow);
                Console.Write(GameChars.PlayerOneChar);
                Level.Matrix[PlayerOneRow][PlayerOneColumn] = GameChars.PlayerOneChar;
            }
            else if (
                keyInfo.Key == ConsoleKey.DownArrow 
                && Level.Matrix[PlayerOneRow + 1][PlayerOneColumn] != GameChars.IndestructibleWall 
                && Level.Matrix[PlayerOneRow + 1][PlayerOneColumn] != GameChars.PlayerTwoChar 
                && Level.Matrix[PlayerOneRow + 1][PlayerOneColumn] != GameChars.DestructibleWall 
                && Level.Matrix[PlayerOneRow + 1][PlayerOneColumn] != GameChars.BombChar
                )
            {
                Level.Matrix[PlayerOneRow][PlayerOneColumn] = GameChars.EmptySpace;
                Console.SetCursorPosition(PlayerOneColumn, PlayerOneRow);
                Console.WriteLine(GameChars.EmptySpace);
                PlayerOneRow++;
                Console.SetCursorPosition(PlayerOneColumn, PlayerOneRow);
                Console.Write(GameChars.PlayerOneChar);
                Level.Matrix[PlayerOneRow][PlayerOneColumn] = GameChars.PlayerOneChar;
            }
            else if (keyInfo.Key == ConsoleKey.NumPad0)
            {
                SetBomb(PlayerOneRow,PlayerOneColumn);
            }
        }

        private static void SetBomb(int row, int column)
        {
            var bomb = new Bomb(row, column, Level, 3);
            Bombs.Add(bomb);
            bomb.Print();
        }

        private static void PlayerTwoMove(ConsoleKeyInfo keyInfo)
        {
            if (
                keyInfo.Key == ConsoleKey.D
                && Level.Matrix[PlayerTwoRow][PlayerTwoColumn + 1] != GameChars.IndestructibleWall 
                && Level.Matrix[PlayerTwoRow][PlayerTwoColumn + 1] != GameChars.PlayerOneChar 
                && Level.Matrix[PlayerTwoRow][PlayerTwoColumn + 1] != GameChars.DestructibleWall 
                && Level.Matrix[PlayerTwoRow][PlayerTwoColumn + 1] != GameChars.BombChar
                )
            {
                Level.Matrix[PlayerTwoRow][PlayerTwoColumn] = GameChars.EmptySpace;
                Console.SetCursorPosition(PlayerTwoColumn, PlayerTwoRow);
                Console.WriteLine(GameChars.EmptySpace);
                PlayerTwoColumn++;
                Console.SetCursorPosition(PlayerTwoColumn, PlayerTwoRow);
                Console.Write(GameChars.PlayerTwoChar);
                Level.Matrix[PlayerTwoRow][PlayerTwoColumn] = GameChars.PlayerTwoChar;
            }
            else if (
                (keyInfo.Key == ConsoleKey.A || keyInfo.Key == ConsoleKey.Q)
                && Level.Matrix[PlayerTwoRow][PlayerTwoColumn - 1] != GameChars.IndestructibleWall 
                && Level.Matrix[PlayerTwoRow][PlayerTwoColumn - 1] != GameChars.PlayerOneChar 
                && Level.Matrix[PlayerTwoRow][PlayerTwoColumn - 1] != GameChars.DestructibleWall 
                && Level.Matrix[PlayerTwoRow][PlayerTwoColumn - 1] != GameChars.BombChar
                )
            {
                Level.Matrix[PlayerTwoRow][PlayerTwoColumn] = GameChars.EmptySpace;
                Console.SetCursorPosition(PlayerTwoColumn, PlayerTwoRow);
                Console.WriteLine(GameChars.EmptySpace);
                PlayerTwoColumn--;
                Console.SetCursorPosition(PlayerTwoColumn, PlayerTwoRow);
                Console.Write(GameChars.PlayerTwoChar);
                Level.Matrix[PlayerTwoRow][PlayerTwoColumn] = GameChars.PlayerTwoChar;
            }
            else if (
                (keyInfo.Key == ConsoleKey.W || keyInfo.Key == ConsoleKey.Z)
                && Level.Matrix[PlayerTwoRow - 1][PlayerTwoColumn] != GameChars.IndestructibleWall 
                && Level.Matrix[PlayerTwoRow - 1][PlayerTwoColumn] != GameChars.PlayerOneChar 
                && Level.Matrix[PlayerTwoRow - 1][PlayerTwoColumn] != GameChars.DestructibleWall 
                && Level.Matrix[PlayerTwoRow - 1][PlayerTwoColumn] != GameChars.BombChar
                )
            {
                Level.Matrix[PlayerTwoRow][PlayerTwoColumn] = GameChars.EmptySpace;
                Console.SetCursorPosition(PlayerTwoColumn, PlayerTwoRow);
                Console.WriteLine(GameChars.EmptySpace);
                PlayerTwoRow--;
                Console.SetCursorPosition(PlayerTwoColumn, PlayerTwoRow);
                Console.Write(GameChars.PlayerTwoChar);
                Level.Matrix[PlayerTwoRow][PlayerTwoColumn] = GameChars.PlayerTwoChar;
            }
            else if (
                keyInfo.Key == ConsoleKey.S 
                && Level.Matrix[PlayerTwoRow + 1][PlayerTwoColumn] != GameChars.IndestructibleWall 
                && Level.Matrix[PlayerTwoRow + 1][PlayerTwoColumn] != GameChars.PlayerOneChar 
                && Level.Matrix[PlayerTwoRow + 1][PlayerTwoColumn] != GameChars.DestructibleWall 
                && Level.Matrix[PlayerTwoRow + 1][PlayerTwoColumn] != GameChars.BombChar
                )
            {
                Level.Matrix[PlayerTwoRow][PlayerTwoColumn] = GameChars.EmptySpace;
                Console.SetCursorPosition(PlayerTwoColumn, PlayerTwoRow);
                Console.WriteLine(GameChars.EmptySpace);
                PlayerTwoRow++;
                Console.SetCursorPosition(PlayerTwoColumn, PlayerTwoRow);
                Console.Write(GameChars.PlayerTwoChar);
                Level.Matrix[PlayerTwoRow][PlayerTwoColumn] = GameChars.PlayerTwoChar;
            }
            else if (keyInfo.Key == ConsoleKey.Spacebar/* bombs left and player is not dead */)
            {
                SetBomb(PlayerTwoRow, PlayerTwoColumn);
            }
        }

        private static void CheckBombs()
        {
            for (int i = 0; i < Bombs.Count; i++)
            {
                var bomb = Bombs[i];

                if (Level.Matrix[bomb.Row][bomb.Column] != GameChars.BombChar)
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
    }
}