namespace AlphaBomberman.Models
{
    using System;

    public class Player
    {
        private const char EmptySpace = ' ';
        private const char Wall = '#';
        private const char PlayerOneChar = 'P';//☺
        private const char PlayerTwoChar = 'K';//☻
        private const char Bomb = 'B';

        public static void Move()
        {
            char[][] matrix = new char[11][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new char[17];
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (row == 0 || row == matrix.Length - 1 || col == 0 || col == matrix[row].Length - 1) // Print matrix borders;
                    {
                        matrix[row][col] = Wall;
                    }
                    else if (row % 2 == 0 && col % 2 == 0)
                    {
                        matrix[row][col] = Wall;
                    }
                }
            }

            matrix[1][1] = PlayerOneChar;
            int playerOneRow = 1;
            int playerOneCol = 1;

            matrix[9][15] = PlayerTwoChar;
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
            if (keyInfo.Key == ConsoleKey.UpArrow && matrix[playerRow - 1][playerCol] != Wall && matrix[playerRow - 1][playerCol] != PlayerTwoChar)
            {
                matrix[playerRow][playerCol] = EmptySpace;
                playerRow--;
                matrix[playerRow][playerCol] = PlayerOneChar;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow && matrix[playerRow + 1][playerCol] != Wall && matrix[playerRow + 1][playerCol] != PlayerTwoChar)
            {
                matrix[playerRow][playerCol] = EmptySpace;
                playerRow++;
                matrix[playerRow][playerCol] = PlayerOneChar;
            }
            else if (keyInfo.Key == ConsoleKey.LeftArrow && matrix[playerRow][playerCol - 1] != Wall && matrix[playerRow][playerCol - 1] != PlayerTwoChar)
            {
                matrix[playerRow][playerCol] = EmptySpace;
                playerCol--;
                matrix[playerRow][playerCol] = PlayerOneChar;
            }
            else if (keyInfo.Key == ConsoleKey.RightArrow && matrix[playerRow][playerCol + 1] != Wall && matrix[playerRow][playerCol + 1] != PlayerTwoChar)
            {
                matrix[playerRow][playerCol] = EmptySpace;
                playerCol++;
                matrix[playerRow][playerCol] = PlayerOneChar;
            }
            else if (keyInfo.Key == ConsoleKey.NumPad0)
            {
                matrix[playerRow][playerCol] = Bomb;
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