namespace AlphaBomberman.Models
{
    using System;
    using Utilities.Ennumetation;

    public class Player
    {
        public static LevelModel Level;
        public static int PlayerOneRow;
        public static int PlayerOneColumn;
        public static int PlayerTwoRow;
        public static int PlayerTwoColumn;
        public static bool PlayerOneIsAlive = true;
        public static bool PlayerTwoIsAlive = true;

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
            ConsoleKey currentKey = ConsoleKey.T;
            while (currentKey != ConsoleKey.Escape)
            {
                currentKey = Game.Tick();
                PlayerOneMove(currentKey);
                PlayerTwoMove(currentKey);
                Bomb.CheckBombs();

                if (!PlayerOneIsAlive || !PlayerTwoIsAlive)
                {
                    Game.ExecCommand(Command.GameOverScreen);
                    break;
                }
            }
            if (PlayerOneIsAlive && PlayerTwoIsAlive)
            {
                Game.ExecCommand(Command.ExitMenu);
            }
            
        }

        private static void PlayerOneMove(ConsoleKey keyInfo)
        {
            if (keyInfo == ConsoleKey.RightArrow && Level.Matrix[PlayerOneRow][PlayerOneColumn + 1] != GameChars.IndestructibleWall && Level.Matrix[PlayerOneRow][PlayerOneColumn + 1] != GameChars.PlayerTwoChar && Level.Matrix[PlayerOneRow][PlayerOneColumn + 1] != GameChars.DestructibleWall && Level.Matrix[PlayerOneRow][PlayerOneColumn + 1] != GameChars.BombChar)
            {
                MoveRight(Level.Matrix, PlayerOneRow, PlayerOneColumn, GameChars.PlayerOneChar);
                PlayerOneColumn++;
            }
            else if (keyInfo == ConsoleKey.LeftArrow && Level.Matrix[PlayerOneRow][PlayerOneColumn - 1] != GameChars.IndestructibleWall && Level.Matrix[PlayerOneRow][PlayerOneColumn - 1] != GameChars.PlayerTwoChar && Level.Matrix[PlayerOneRow][PlayerOneColumn - 1] != GameChars.DestructibleWall && Level.Matrix[PlayerOneRow][PlayerOneColumn - 1] != GameChars.BombChar)
            {
                MoveLeft(Level.Matrix, PlayerOneRow, PlayerOneColumn, GameChars.PlayerOneChar);
                PlayerOneColumn--;
            }
            else if (keyInfo == ConsoleKey.UpArrow && Level.Matrix[PlayerOneRow - 1][PlayerOneColumn] != GameChars.IndestructibleWall && Level.Matrix[PlayerOneRow - 1][PlayerOneColumn] != GameChars.PlayerTwoChar && Level.Matrix[PlayerOneRow - 1][PlayerOneColumn] != GameChars.DestructibleWall && Level.Matrix[PlayerOneRow - 1][PlayerOneColumn] != GameChars.BombChar)
            {
                MoveUp(Level.Matrix, PlayerOneRow, PlayerOneColumn, GameChars.PlayerOneChar);
                PlayerOneRow--;
            }
            else if (keyInfo == ConsoleKey.DownArrow && Level.Matrix[PlayerOneRow + 1][PlayerOneColumn] != GameChars.IndestructibleWall && Level.Matrix[PlayerOneRow + 1][PlayerOneColumn] != GameChars.PlayerTwoChar && Level.Matrix[PlayerOneRow + 1][PlayerOneColumn] != GameChars.DestructibleWall && Level.Matrix[PlayerOneRow + 1][PlayerOneColumn] != GameChars.BombChar)
            {
                MoveDown(Level.Matrix, PlayerOneRow, PlayerOneColumn, GameChars.PlayerOneChar);
                PlayerOneRow++;
            }
            else if (keyInfo == ConsoleKey.NumPad0)
            {
                SetBomb(PlayerOneRow, PlayerOneColumn, GameChars.PlayerOneChar);
            }
        }

        private static void PlayerTwoMove(ConsoleKey keyInfo)
        {
            if (keyInfo == ConsoleKey.D && Level.Matrix[PlayerTwoRow][PlayerTwoColumn + 1] != GameChars.IndestructibleWall && Level.Matrix[PlayerTwoRow][PlayerTwoColumn + 1] != GameChars.PlayerOneChar && Level.Matrix[PlayerTwoRow][PlayerTwoColumn + 1] != GameChars.DestructibleWall && Level.Matrix[PlayerTwoRow][PlayerTwoColumn + 1] != GameChars.BombChar)
            {
                MoveRight(Level.Matrix, PlayerTwoRow, PlayerTwoColumn, GameChars.PlayerTwoChar);
                PlayerTwoColumn++;
            }
            else if (keyInfo == ConsoleKey.A && Level.Matrix[PlayerTwoRow][PlayerTwoColumn - 1] != GameChars.IndestructibleWall && Level.Matrix[PlayerTwoRow][PlayerTwoColumn - 1] != GameChars.PlayerOneChar && Level.Matrix[PlayerTwoRow][PlayerTwoColumn - 1] != GameChars.DestructibleWall && Level.Matrix[PlayerTwoRow][PlayerTwoColumn - 1] != GameChars.BombChar)
            {
                MoveLeft(Level.Matrix, PlayerTwoRow, PlayerTwoColumn, GameChars.PlayerTwoChar);
                PlayerTwoColumn--;
            }
            else if (keyInfo == ConsoleKey.W && Level.Matrix[PlayerTwoRow - 1][PlayerTwoColumn] != GameChars.IndestructibleWall && Level.Matrix[PlayerTwoRow - 1][PlayerTwoColumn] != GameChars.PlayerOneChar && Level.Matrix[PlayerTwoRow - 1][PlayerTwoColumn] != GameChars.DestructibleWall && Level.Matrix[PlayerTwoRow - 1][PlayerTwoColumn] != GameChars.BombChar)
            {
                MoveUp(Level.Matrix, PlayerTwoRow, PlayerTwoColumn, GameChars.PlayerTwoChar);
                PlayerTwoRow--;
            }
            else if (keyInfo == ConsoleKey.S && Level.Matrix[PlayerTwoRow + 1][PlayerTwoColumn] != GameChars.IndestructibleWall && Level.Matrix[PlayerTwoRow + 1][PlayerTwoColumn] != GameChars.PlayerOneChar && Level.Matrix[PlayerTwoRow + 1][PlayerTwoColumn] != GameChars.DestructibleWall && Level.Matrix[PlayerTwoRow + 1][PlayerTwoColumn] != GameChars.BombChar)
            {
                MoveDown(Level.Matrix, PlayerTwoRow, PlayerTwoColumn, GameChars.PlayerTwoChar);
                PlayerTwoRow++;
            }
            else if (keyInfo == ConsoleKey.Spacebar/* bombs left and player is not dead */)
            {
                SetBomb(PlayerTwoRow, PlayerTwoColumn, GameChars.PlayerTwoChar);
            }
        }

        private static void SetBomb(int row, int column, char playerChar)
        {
            var bomb = new Bomb(row, column, Level, 3);
            Bomb.Bombs.Add(bomb);
            bomb.Print(playerChar);
        }

        private static void MoveRight(char[][] matrix, int row, int col, char playerChar)
        {
            SetPlayerColor(playerChar);

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
            SetPlayerColor(playerChar);

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
            SetPlayerColor(playerChar);

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
            SetPlayerColor(playerChar);

            matrix[row][col] = GameChars.EmptySpace;
            Console.SetCursorPosition(col, row);
            Console.WriteLine(GameChars.EmptySpace);
            row++;
            Console.SetCursorPosition(col, row);
            Console.Write(playerChar);
            matrix[row][col] = playerChar;

            Game.RestConsoleColors();
        }

        public static void SetPlayerColor(char playerChar)
        {
            switch (playerChar)
            {
                case GameChars.PlayerOneChar:
                    Console.ForegroundColor = GameColors.PlayerOne;
                    break;
                case GameChars.PlayerTwoChar:
                    Console.ForegroundColor = GameColors.PlayerTwo;
                    break;
            }
        }
    }
}