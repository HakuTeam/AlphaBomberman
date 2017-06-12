namespace AlphaBomberman.Models
{
    using System;

    public class LevelModels
    {
        private const char EmptySpace = ' ';
        private const char Wall = '#';
        private const char BreakingWall = '*';
        private const char FirstPlayer = 'P';
        private const char SecondPlayer = 'K';

        public static char DrawMatrix()
        {
            char[][] matrix = new char[11][];

            var rnd = new Random();

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new char[17];
            }
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    bool firstPlayerPosition = row == 1 && col == 1;
                    bool firstPlayerPositionRight = row == 1 && col == 2;
                    bool firstPlayerPositionDown = row == 2 && col == 1;

                    bool secondPlayerPosition = row == matrix.Length - 2 && col == matrix[matrix.Length - 2].Length - 2;
                    bool secondPlayerPositionleft = row == matrix.Length - 2 && col == matrix[matrix.Length - 2].Length - 3;
                    bool secondPlayerPositionUp = row == matrix.Length - 3 && col == matrix[matrix.Length - 2].Length - 2;

                    if (row == 0 || row == matrix.Length - 1 || col == 0 || col == matrix[row].Length - 1) // Print matrix borders;
                    {
                        //matrix[row][col] = Wall;
                        matrix[row][col] = Wall;
                        Console.SetCursorPosition(col, row);
                        Console.Write(Wall);
                    }
                    else if (row % 2 == 0 && col % 2 == 0)
                    {
                        //matrix[row][col] = Wall;
                        matrix[row][col] = Wall;
                        Console.SetCursorPosition(col, row);
                        Console.Write(Wall);
                    }
                    else if (secondPlayerPositionUp || secondPlayerPositionleft || secondPlayerPosition)
                    {
                        matrix[matrix.Length - 2][matrix[matrix.Length - 2].Length - 2] = SecondPlayer;
                        Console.SetCursorPosition(matrix[matrix.Length - 2].Length - 2, matrix.Length - 2);
                        Console.Write(SecondPlayer);

                        matrix[matrix.Length - 2][matrix[matrix.Length - 2].Length - 3] = EmptySpace;
                        Console.SetCursorPosition(matrix[matrix.Length - 2].Length - 3, matrix.Length - 2);
                        Console.Write(EmptySpace);

                        matrix[matrix.Length - 3][matrix[matrix.Length - 2].Length - 2] = EmptySpace;
                        Console.SetCursorPosition(matrix[matrix.Length - 2].Length - 2, matrix.Length - 3);
                        Console.Write(EmptySpace);

                    }
                    else if (firstPlayerPosition || firstPlayerPositionDown || firstPlayerPositionRight)
                    {
                        matrix[1][1] = FirstPlayer;
                        Console.SetCursorPosition(1, 1);
                        Console.Write(FirstPlayer);

                        matrix[1][2] = EmptySpace;
                        Console.SetCursorPosition(1, 2);
                        Console.Write(EmptySpace);

                        matrix[2][1] = EmptySpace;
                        Console.SetCursorPosition(2, 1);
                        Console.Write(EmptySpace);
                    }
                    else
                    {
                        matrix[row][col] = (char)rnd.Next(' ', '"');

                        if (matrix[row][col] == EmptySpace)
                        {
                            matrix[row][col] = EmptySpace;
                            Console.SetCursorPosition(col, row);
                            Console.Write(EmptySpace);
                        }
                        else
                        {
                            matrix[row][col] = BreakingWall;
                            Console.SetCursorPosition(col, row);
                            Console.Write(BreakingWall);
                        }
                    }
                }
            }
            return EmptySpace;
        }
    }
}