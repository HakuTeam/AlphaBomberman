namespace AlphaBomberman.Models
{
    using System;
    using Utilities.Composer;

    public class Player
    {
        private const char EmptySpace = ' ';
        private const char Wall = '#';
        private const char PlayerOneChar = 'P';//☺
        private const char PlayerTwoChar = 'K';//☻

        public static void Move()
        {
            char[][] matrix = Composer.MakeBoxLayout(17,11);

            for (int row = 1; row < matrix.Length-1; row++)
            {
                for (int col = 1; col < matrix[row].Length-1; col++)
                {
                    if (row % 2 == 0 && col % 2 == 0)
                    {
                        matrix[row][col] = Wall;
                    }
                }
            }

            matrix[1][1] = Composer.PlayerOne;
            int playerOneRow = 1;
            int playerOneCol = 1;

            matrix[9][15] = Composer.PlayerTwo;
            int playerTwoRow = 9;
            int playerTwoCol = 15;


            while (true)
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        Console.Write(matrix[i][j]);
                    }

                    Console.WriteLine();
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                PlayerOneMovement(keyInfo, matrix, ref playerOneRow, ref playerOneCol);

                PlayerTwoMovement(keyInfo, matrix, ref playerTwoRow, ref playerTwoCol);

                Console.Clear();
            }
        }

        private static void PlayerOneMovement(ConsoleKeyInfo keyInfo, char[][] matrix, ref int playerRow, ref int playerCol)
        {
            if (
                keyInfo.Key == ConsoleKey.UpArrow 
                && matrix[playerRow - 1][playerCol] != Composer.Wall 
                && matrix[playerRow - 1][playerCol] != Composer.LineHorizontal
                && matrix[playerRow - 1][playerCol] != Composer.Bomb
                && matrix[playerRow - 1][playerCol] != PlayerTwoChar
                )
            {
                matrix[playerRow][playerCol] = EmptySpace;
                playerRow--;
                matrix[playerRow][playerCol] = PlayerOneChar;
            }
            else if (
                keyInfo.Key == ConsoleKey.DownArrow 
                && matrix[playerRow + 1][playerCol] != Composer.Wall
                && matrix[playerRow + 1][playerCol] != Composer.LineHorizontal
                && matrix[playerRow + 1][playerCol] != Composer.Bomb
                && matrix[playerRow + 1][playerCol] != PlayerTwoChar
                )
            {
                matrix[playerRow][playerCol] = EmptySpace;
                playerRow++;
                matrix[playerRow][playerCol] = PlayerOneChar;
            }
            else if (
                keyInfo.Key == ConsoleKey.LeftArrow 
                && matrix[playerRow][playerCol - 1] != Composer.Wall
                && matrix[playerRow][playerCol - 1] != Composer.LineVertical
                && matrix[playerRow][playerCol - 1] != Composer.Bomb
                && matrix[playerRow][playerCol - 1] != PlayerTwoChar
                )
            {
                matrix[playerRow][playerCol] = EmptySpace;
                playerCol--;
                matrix[playerRow][playerCol] = PlayerOneChar;
            }
            else if (
                keyInfo.Key == ConsoleKey.RightArrow 
                && matrix[playerRow][playerCol + 1] != Composer.Wall
                && matrix[playerRow][playerCol + 1] != Composer.LineVertical
                && matrix[playerRow][playerCol + 1] != Composer.Bomb
                && matrix[playerRow][playerCol + 1] != PlayerTwoChar
                )
            {
                matrix[playerRow][playerCol] = EmptySpace;
                playerCol++;
                matrix[playerRow][playerCol] = PlayerOneChar;
            }
            else if (keyInfo.Key == ConsoleKey.NumPad0)
            {
                matrix[playerRow][playerCol+1] = Composer.Bomb;
            }
        }

        private static void PlayerTwoMovement(ConsoleKeyInfo keyInfo, char[][] matrix, ref int playerRow, ref int playerCol)
        {
            if (keyInfo.Key == ConsoleKey.W && matrix[playerRow - 1][playerCol] != Wall && matrix[playerRow - 1][playerCol] != PlayerOneChar)
            {
                matrix[playerRow][playerCol] = EmptySpace;
                playerRow--;
                matrix[playerRow][playerCol] = PlayerTwoChar;
            }
            else if (keyInfo.Key == ConsoleKey.S && matrix[playerRow + 1][playerCol] != Wall && matrix[playerRow + 1][playerCol] != PlayerOneChar)
            {
                matrix[playerRow][playerCol] = EmptySpace;
                playerRow++;
                matrix[playerRow][playerCol] = PlayerTwoChar;
            }
            else if (keyInfo.Key == ConsoleKey.A && matrix[playerRow][playerCol - 1] != Wall && matrix[playerRow][playerCol-1] != PlayerOneChar)
            {
                matrix[playerRow][playerCol] = EmptySpace;
                playerCol--;
                matrix[playerRow][playerCol] = PlayerTwoChar;
            }
            else if (keyInfo.Key == ConsoleKey.D && matrix[playerRow][playerCol + 1] != Wall && matrix[playerRow][playerCol+1] != PlayerOneChar)
            {
                matrix[playerRow][playerCol] = EmptySpace;
                playerCol++;
                matrix[playerRow][playerCol] = PlayerTwoChar;
            }
        }
    }
}