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
                        matrix[row][col] = GameChars.IndestructibleWall;
                        Console.SetCursorPosition(col,row);
                        Console.Write(GameChars.IndestructibleWall);
                    }
                    else if (row % 2 == 0 && col % 2 == 0)
                    {
                        //matrix[row][col] = Wall;
                        matrix[row][col] = GameChars.IndestructibleWall;
                        Console.SetCursorPosition(col,row);
                        Console.Write(GameChars.IndestructibleWall);
                    }
                    else if (secondPlayerPositionUp || secondPlayerPositionleft || secondPlayerPosition)
                    {
                        matrix[matrix.Length - 2][matrix[matrix.Length - 2].Length - 2] = GameChars.PlayerTwoChar;
                        Console.SetCursorPosition(matrix[matrix.Length - 2].Length - 2, matrix.Length - 2);
                        Console.Write(GameChars.PlayerTwoChar);

                        matrix[matrix.Length - 2][matrix[matrix.Length - 2].Length - 3] = GameChars.EmptySpace;
                        Console.SetCursorPosition(matrix[matrix.Length - 2].Length - 3, matrix.Length - 2);
                        Console.Write(GameChars.EmptySpace);

                        matrix[matrix.Length - 3][matrix[matrix.Length - 2].Length - 2] = GameChars.EmptySpace;
                        Console.SetCursorPosition(matrix[matrix.Length - 2].Length - 2, matrix.Length - 3);
                        Console.Write(GameChars.EmptySpace);

                    }
                    else if (firstPlayerPosition || firstPlayerPositionDown || firstPlayerPositionRight)
                    {
                        matrix[1][1] = GameChars.PlayerOneChar;
                        Console.SetCursorPosition(1, 1);
                        Console.Write(GameChars.PlayerOneChar);

                        matrix[1][2] = GameChars.EmptySpace;
                        Console.SetCursorPosition(1, 2);
                        Console.Write(GameChars.EmptySpace);

                        matrix[2][1] = GameChars.EmptySpace;
                        Console.SetCursorPosition(2, 1);
                        Console.Write(GameChars.EmptySpace);
                    }
                    else
                    {
                        //matrix[row][col] = (char)rnd.Next(' ', '"');

                        //if (matrix[row][col] == GameChars.EmptySpace)
                        //{
                        //    matrix[row][col] = GameChars.EmptySpace;
                        //    Console.SetCursorPosition(col,row);
                        //    Console.Write(GameChars.EmptySpace);
                        //}
                        //else
                        //{
                            matrix[row][col] = GameChars.DestructibleWall;
                            Console.SetCursorPosition(col,row);
                            Console.Write(GameChars.DestructibleWall);
                        //}
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