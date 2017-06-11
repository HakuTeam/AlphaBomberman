namespace AlphaBomberman.Models
{
    using System;

    public class LevelModels
    {
        private const char EmptySpace = ' ';
        private const char Wall = '#';
        private const char BreakingWall = '*';

        public static char[][] Generate()
        {
            char[][] matrix = new char[11][];
            var rnd = new Random();

            matrix = FillMatrix(matrix);
            matrix = PlayerPositions(matrix);
            return matrix;
        }

        public static char[][] Print(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join("", matrix[i]));
            }

            return matrix;
        }

        private static char[][] FillMatrix(char[][] matrix)
        {
            var rnd = new Random();

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
                    else
                    {
                        matrix[row][col] = (char)rnd.Next(' ', '"');
                    }
                }
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == '!')
                    {
                        matrix[row][col] = '*';
                    }
                }
            }

            return matrix;
        }

        private static char[][] PlayerPositions(char[][] matrix)
        {
            //First player position 
            matrix[1][1] = ' ';
            matrix[1][2] = ' ';
            matrix[2][1] = ' ';

            //Second player position
            matrix[matrix.Length - 2][matrix[matrix.Length - 1].Length - 2] = ' ';
            matrix[matrix.Length - 2][matrix[matrix.Length - 1].Length - 3] = ' ';
            matrix[matrix.Length - 3][matrix[matrix.Length - 1].Length - 2] = ' ';
            return matrix;
        }
    }
}
