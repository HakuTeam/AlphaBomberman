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
            if (keyInfo.Key == ConsoleKey.RightArrow && Level.Matrix[PlayerOneRow][PlayerOneColumn + 1] != GameChars.IndestructibleWall && Level.Matrix[PlayerOneRow][PlayerOneColumn + 1] != GameChars.PlayerTwoChar && Level.Matrix[PlayerOneRow][PlayerOneColumn + 1] != GameChars.DestructibleWall && Level.Matrix[PlayerOneRow][PlayerOneColumn + 1] != GameChars.BombChar)
            {
                MoveRight(Level.Matrix, PlayerOneRow, PlayerOneColumn, GameChars.PlayerOneChar);
                PlayerOneColumn++;
            }
            else if (keyInfo.Key == ConsoleKey.LeftArrow && Level.Matrix[PlayerOneRow][PlayerOneColumn - 1] != GameChars.IndestructibleWall && Level.Matrix[PlayerOneRow][PlayerOneColumn - 1] != GameChars.PlayerTwoChar && Level.Matrix[PlayerOneRow][PlayerOneColumn - 1] != GameChars.DestructibleWall && Level.Matrix[PlayerOneRow][PlayerOneColumn - 1] != GameChars.BombChar)
            {
                MoveLeft(Level.Matrix, PlayerOneRow, PlayerOneColumn, GameChars.PlayerOneChar);
                PlayerOneColumn--;
            }
            else if (keyInfo.Key == ConsoleKey.UpArrow && Level.Matrix[PlayerOneRow - 1][PlayerOneColumn] != GameChars.IndestructibleWall && Level.Matrix[PlayerOneRow - 1][PlayerOneColumn] != GameChars.PlayerTwoChar && Level.Matrix[PlayerOneRow - 1][PlayerOneColumn] != GameChars.DestructibleWall && Level.Matrix[PlayerOneRow - 1][PlayerOneColumn] != GameChars.BombChar)
            {
                MoveUp(Level.Matrix, PlayerOneRow, PlayerOneColumn, GameChars.PlayerOneChar);
                PlayerOneRow--;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow && Level.Matrix[PlayerOneRow + 1][PlayerOneColumn] != GameChars.IndestructibleWall && Level.Matrix[PlayerOneRow + 1][PlayerOneColumn] != GameChars.PlayerTwoChar && Level.Matrix[PlayerOneRow + 1][PlayerOneColumn] != GameChars.DestructibleWall && Level.Matrix[PlayerOneRow + 1][PlayerOneColumn] != GameChars.BombChar)
            {
                MoveDown(Level.Matrix, PlayerOneRow, PlayerOneColumn, GameChars.PlayerOneChar);
                PlayerOneRow++;
            }
            else if (keyInfo.Key == ConsoleKey.NumPad0)
            {
                SetBomb(PlayerOneRow, PlayerOneColumn);
            }
        }

        private static void PlayerTwoMove(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.D && Level.Matrix[PlayerTwoRow][PlayerTwoColumn + 1] != GameChars.IndestructibleWall && Level.Matrix[PlayerTwoRow][PlayerTwoColumn + 1] != GameChars.PlayerOneChar && Level.Matrix[PlayerTwoRow][PlayerTwoColumn + 1] != GameChars.DestructibleWall && Level.Matrix[PlayerTwoRow][PlayerTwoColumn + 1] != GameChars.BombChar)
            {
                MoveRight(Level.Matrix, PlayerTwoRow, PlayerTwoColumn, GameChars.PlayerTwoChar);
                PlayerTwoColumn++;
            }
            else if (keyInfo.Key == ConsoleKey.A && Level.Matrix[PlayerTwoRow][PlayerTwoColumn - 1] != GameChars.IndestructibleWall && Level.Matrix[PlayerTwoRow][PlayerTwoColumn - 1] != GameChars.PlayerOneChar && Level.Matrix[PlayerTwoRow][PlayerTwoColumn - 1] != GameChars.DestructibleWall && Level.Matrix[PlayerTwoRow][PlayerTwoColumn - 1] != GameChars.BombChar)
            {
                MoveLeft(Level.Matrix, PlayerTwoRow, PlayerTwoColumn, GameChars.PlayerTwoChar);
                PlayerTwoColumn--;
            }
            else if (keyInfo.Key == ConsoleKey.W && Level.Matrix[PlayerTwoRow - 1][PlayerTwoColumn] != GameChars.IndestructibleWall && Level.Matrix[PlayerTwoRow - 1][PlayerTwoColumn] != GameChars.PlayerOneChar && Level.Matrix[PlayerTwoRow - 1][PlayerTwoColumn] != GameChars.DestructibleWall && Level.Matrix[PlayerTwoRow - 1][PlayerTwoColumn] != GameChars.BombChar)
            {
                MoveUp(Level.Matrix, PlayerTwoRow, PlayerTwoColumn, GameChars.PlayerTwoChar);
                PlayerTwoRow--;
            }
            else if (keyInfo.Key == ConsoleKey.S && Level.Matrix[PlayerTwoRow + 1][PlayerTwoColumn] != GameChars.IndestructibleWall && Level.Matrix[PlayerTwoRow + 1][PlayerTwoColumn] != GameChars.PlayerOneChar && Level.Matrix[PlayerTwoRow + 1][PlayerTwoColumn] != GameChars.DestructibleWall && Level.Matrix[PlayerTwoRow + 1][PlayerTwoColumn] != GameChars.BombChar)
            {
                MoveDown(Level.Matrix, PlayerTwoRow, PlayerTwoColumn, GameChars.PlayerTwoChar);
                PlayerTwoRow++;
            }
            else if (keyInfo.Key == ConsoleKey.Spacebar/* bombs left and player is not dead */)
            {
                SetBomb(PlayerTwoRow, PlayerTwoColumn);
            }
        }

        private static void SetBomb(int row, int column)
        {
            var bomb = new Bomb(row, column, Level, 3);
            Bombs.Add(bomb);
            bomb.Print();
        }

        private static void CheckBombs()
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

        private static void MoveRight(char[][] matrix, int row, int col, char playerChar)
        {
            matrix[row][col] = GameChars.EmptySpace;
            Console.SetCursorPosition(col, row);
            Console.WriteLine(GameChars.EmptySpace);
            col++;
            Console.SetCursorPosition(col, row);
            Console.Write(playerChar);
            matrix[row][col] = playerChar;
        }

        private static void MoveLeft(char[][] matrix, int row, int col, char playerChar)
        {
            matrix[row][col] = GameChars.EmptySpace;
            Console.SetCursorPosition(col, row);
            Console.WriteLine(GameChars.EmptySpace);
            col--;
            Console.SetCursorPosition(col, row);
            Console.Write(playerChar);
            matrix[row][col] = playerChar;
        }

        private static void MoveUp(char[][] matrix, int row, int col, char playerChar)
        {
            matrix[row][col] = GameChars.EmptySpace;
            Console.SetCursorPosition(col, row);
            Console.WriteLine(GameChars.EmptySpace);
            row--;
            Console.SetCursorPosition(col, row);
            Console.Write(playerChar);
            matrix[row][col] = playerChar;
        }

        private static void MoveDown(char[][] matrix, int row, int col, char playerChar)
        {
            matrix[row][col] = GameChars.EmptySpace;
            Console.SetCursorPosition(col, row);
            Console.WriteLine(GameChars.EmptySpace);
            row++;
            Console.SetCursorPosition(col, row);
            Console.Write(playerChar);
            matrix[row][col] = playerChar;
        }
    }
}