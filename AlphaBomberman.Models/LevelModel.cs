namespace AlphaBomberman.Models
{
    using System;

    public class LevelModel
    {
        public char[][] Matrix { get; }

        public int Width { get; set; }
        public int Height { get; set; }

        public char[][] DrawMatrix()
        {
            char[][] matrix = new char[Height][];

            var rnd = new Random();

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new char[Width];
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
                        matrix[row][col] = GameChars.indestructibleWall;
                        Console.SetCursorPosition(row, col);
                        Console.Write(GameChars.indestructibleWall);
                    }
                    else if (row % 2 == 0 && col % 2 == 0)
                    {
                        //matrix[row][col] = Wall;
                        matrix[row][col] = GameChars.indestructibleWall;
                        Console.SetCursorPosition(row, col);
                        Console.Write(GameChars.indestructibleWall);
                    }
                    else if (secondPlayerPositionUp || secondPlayerPositionleft || secondPlayerPosition)
                    {
                        matrix[matrix.Length - 2][matrix[matrix.Length - 2].Length - 2] = GameChars.playerTwoChar;
                        Console.SetCursorPosition(matrix.Length - 2, matrix[matrix.Length - 2].Length - 2);
                        Console.Write(GameChars.playerTwoChar);

                        matrix[matrix.Length - 2][matrix[matrix.Length - 2].Length - 3] = GameChars.emptySpace;
                        Console.SetCursorPosition(matrix[matrix.Length - 2].Length - 3, matrix.Length - 2);
                        Console.Write(GameChars.emptySpace);

                        matrix[matrix.Length - 3][matrix[matrix.Length - 2].Length - 2] = GameChars.emptySpace;
                        Console.SetCursorPosition(matrix[matrix.Length - 2].Length - 2, matrix.Length - 3);
                        Console.Write(GameChars.emptySpace);

                    }
                    else if (firstPlayerPosition || firstPlayerPositionDown || firstPlayerPositionRight)
                    {
                        matrix[1][1] = GameChars.playerOneChar;
                        Console.SetCursorPosition(1, 1);
                        Console.Write(GameChars.playerOneChar);

                        matrix[1][2] = GameChars.emptySpace;
                        Console.SetCursorPosition(1, 2);
                        Console.Write(GameChars.emptySpace);

                        matrix[2][1] = GameChars.emptySpace;
                        Console.SetCursorPosition(2, 1);
                        Console.Write(GameChars.emptySpace);
                    }
                    else
                    {
                        matrix[row][col] = (char)rnd.Next(' ', '"');

                        if (matrix[row][col] == GameChars.emptySpace)
                        {
                            matrix[row][col] = GameChars.emptySpace;
                            Console.SetCursorPosition(row, col);
                            Console.Write(GameChars.emptySpace);
                        }
                        else
                        {
                            matrix[row][col] = GameChars.destructibleWall;
                            Console.SetCursorPosition(row, col);
                            Console.Write(GameChars.destructibleWall);
                        }
                    }
                }
            }
            //return EmptySpace;
            return matrix;
        }

        public LevelModel(int width, int height)
        {
            Width = width;
            Height = height;
            Matrix = DrawMatrix();
        }

        public int GetDownRightIndex()
        {
            return Matrix.Length - 2;
        }
    }
}