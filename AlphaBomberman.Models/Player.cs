namespace AlphaBomberman.Models
{
    using System;

    public class Player
    {
        private const char EmptySpace = ' ';
        private const char Wall = '#';
        private const char PlayerChar = 'P';

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

            matrix[1][1] = 'P';
            int playerRow = 1;
            int playerCol = 1;

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

                if (keyInfo.Key == ConsoleKey.UpArrow && matrix[playerRow - 1][playerCol] != Wall)
                {
                    matrix[playerRow][playerCol] = EmptySpace;
                    playerRow--;
                    matrix[playerRow][playerCol] = PlayerChar;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow && matrix[playerRow + 1][playerCol] != Wall)
                {
                    matrix[playerRow][playerCol] = EmptySpace;
                    playerRow++;
                    matrix[playerRow][playerCol] = PlayerChar;
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow && matrix[playerRow][playerCol - 1] != Wall)
                {
                    matrix[playerRow][playerCol] = EmptySpace;
                    playerCol--;
                    matrix[playerRow][playerCol] = PlayerChar;
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow && matrix[playerRow][playerCol + 1] != Wall)
                {
                    matrix[playerRow][playerCol] = EmptySpace;
                    playerCol++;
                    matrix[playerRow][playerCol] = PlayerChar;
                }

                Console.Clear();
            }
        }
    }
}