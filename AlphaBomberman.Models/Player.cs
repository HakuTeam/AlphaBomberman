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
        public static char[][] level = new char[10][];
        public  static int PlayerOneX = 1;
        public  static int PlayerOneY = 1;
        private static int PlayerTwoX = level.Length - 2;
        private static int PlayerTwoY = level.Length - 2;

        public static void Move()
        {
            ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                PlayerOneMove(keyInfo);
                PlayerTwoMove(keyInfo);
            }
        }

        private static void PlayerOneMove(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.DownArrow && level[PlayerOneX][PlayerOneY + 1] != Wall && level[PlayerOneX][PlayerOneY + 1] != PlayerTwoChar)
            {
                level[PlayerOneX][PlayerOneY] = EmptySpace;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.WriteLine(EmptySpace);
                PlayerOneY++;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.Write(PlayerOneChar);
                level[PlayerOneX][PlayerOneY] = PlayerOneChar;
            }
            else if (keyInfo.Key == ConsoleKey.UpArrow && level[PlayerOneX][PlayerOneY - 1] != Wall && level[PlayerOneX][PlayerOneY - 1] != PlayerTwoChar)
            {
                level[PlayerOneX][PlayerOneY] = EmptySpace;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.WriteLine(EmptySpace);
                PlayerOneY--;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.Write(PlayerOneChar);
                level[PlayerOneX][PlayerOneY] = PlayerOneChar;
            }
            else if (keyInfo.Key == ConsoleKey.LeftArrow && level[PlayerOneX - 1][PlayerOneY] != Wall && level[PlayerOneX - 1][PlayerOneY] != PlayerTwoChar)
            {
                level[PlayerOneX][PlayerOneY] = EmptySpace;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.WriteLine(EmptySpace);
                PlayerOneX--;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.Write(PlayerOneChar);
                level[PlayerOneX][PlayerOneY] = PlayerOneChar;
            }
            else if (keyInfo.Key == ConsoleKey.RightArrow && level[PlayerOneX + 1][PlayerOneY] != Wall && level[PlayerOneX + 1][PlayerOneY] != PlayerTwoChar)
            {
                level[PlayerOneX][PlayerOneY] = EmptySpace;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.WriteLine(EmptySpace);
                PlayerOneX++;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.Write(PlayerOneChar);
                level[PlayerOneX][PlayerOneY] = PlayerOneChar;
            }
        }

        private static void PlayerTwoMove(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.S && level[PlayerTwoX][PlayerTwoY + 1] != Wall && level[PlayerTwoX][PlayerTwoY + 1] != PlayerOneChar)
            {
                level[PlayerTwoX][PlayerTwoY] = EmptySpace;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.WriteLine(EmptySpace);
                PlayerTwoY++;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.Write(PlayerTwoChar);
                level[PlayerTwoX][PlayerTwoY] = PlayerTwoChar;
            }
            else if (keyInfo.Key == ConsoleKey.W && level[PlayerTwoX][PlayerTwoY - 1] != Wall && level[PlayerTwoX][PlayerTwoY - 1] != PlayerOneChar)
            {
                level[PlayerTwoX][PlayerTwoY] = EmptySpace;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.WriteLine(EmptySpace);
                PlayerTwoY--;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.Write(PlayerTwoChar);
                level[PlayerTwoX][PlayerTwoY] = PlayerTwoChar;
            }
            else if (keyInfo.Key == ConsoleKey.A && level[PlayerTwoX - 1][PlayerTwoY] != Wall && level[PlayerTwoX - 1][PlayerTwoY] != PlayerOneChar)
            {
                level[PlayerTwoX][PlayerTwoY] = EmptySpace;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.WriteLine(EmptySpace);
                PlayerTwoX--;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.Write(PlayerTwoChar);
                level[PlayerTwoX][PlayerTwoY] = PlayerTwoChar;
            }
            else if (keyInfo.Key == ConsoleKey.D && level[PlayerTwoX + 1][PlayerTwoY] != Wall && level[PlayerTwoX + 1][PlayerTwoY] != PlayerOneChar)
            {
                level[PlayerTwoX][PlayerTwoY] = EmptySpace;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.WriteLine(EmptySpace);
                PlayerTwoX++;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.Write(PlayerTwoChar);
                level[PlayerTwoX][PlayerTwoY] = PlayerTwoChar;
            }
        }

        public static void DrawLevel()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 10; i++)
            {
                level[i] = new char[10];
                for (int j = 0; j < 10; j++)
                {
                    if (i == 0 || i == 9 || j == 0 || j == 9)
                    {
                        level[i][j] = '#';
                        Console.SetCursorPosition(j, i);
                        Console.Write('#');
                    }
                }
            }

            Console.SetCursorPosition(PlayerOneX, PlayerOneY);
            Console.Write(PlayerOneChar);
            Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
            Console.Write(PlayerTwoChar);
        }
    }
}