namespace AlphaBomberman.Models
{
    using System;

    public class Player
    {
        public static char[][] level = LevelModels.DrawMatrix();
        public static int PlayerOneX = 1;
        public static int PlayerOneY = 1;
        public static int PlayerTwoX = level.Length - 2;
        public static int PlayerTwoY = level[level.Length - 2].Length - 2;

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
            if (keyInfo.Key == ConsoleKey.DownArrow && level[PlayerOneX][PlayerOneY + 1] != GameChars.indestructibleWall && level[PlayerOneX][PlayerOneY + 1] != GameChars.playerTwoChar && level[PlayerOneX][PlayerOneY + 1] != GameChars.destructibleWall)
            {
                level[PlayerOneX][PlayerOneY] = GameChars.emptySpace;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.WriteLine(GameChars.emptySpace);
                PlayerOneY++;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.Write(GameChars.playerOneChar);
                level[PlayerOneX][PlayerOneY] = GameChars.playerOneChar;
            }
            else if (keyInfo.Key == ConsoleKey.UpArrow && level[PlayerOneX][PlayerOneY - 1] != GameChars.indestructibleWall && level[PlayerOneX][PlayerOneY - 1] != GameChars.playerTwoChar && level[PlayerOneX][PlayerOneY - 1] != GameChars.destructibleWall)
            {
                level[PlayerOneX][PlayerOneY] = GameChars.emptySpace;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.WriteLine(GameChars.emptySpace);
                PlayerOneY--;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.Write(GameChars.playerOneChar);
                level[PlayerOneX][PlayerOneY] = GameChars.playerOneChar;
            }
            else if (keyInfo.Key == ConsoleKey.LeftArrow && level[PlayerOneX - 1][PlayerOneY] != GameChars.indestructibleWall && level[PlayerOneX - 1][PlayerOneY] != GameChars.playerTwoChar && level[PlayerOneX - 1][PlayerOneY] != GameChars.destructibleWall)
            {
                level[PlayerOneX][PlayerOneY] = GameChars.emptySpace;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.WriteLine(GameChars.emptySpace);
                PlayerOneX--;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.Write(GameChars.playerOneChar);
                level[PlayerOneX][PlayerOneY] = GameChars.playerOneChar;
            }
            else if (keyInfo.Key == ConsoleKey.RightArrow && level[PlayerOneX + 1][PlayerOneY] != GameChars.indestructibleWall && level[PlayerOneX + 1][PlayerOneY] != GameChars.playerTwoChar && level[PlayerOneX + 1][PlayerOneY] != GameChars.destructibleWall)
            {
                level[PlayerOneX][PlayerOneY] = GameChars.emptySpace;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.WriteLine(GameChars.emptySpace);
                PlayerOneX++;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.Write(GameChars.playerOneChar);
                level[PlayerOneX][PlayerOneY] = GameChars.playerOneChar;
            }
            else if (keyInfo.Key == ConsoleKey.NumPad0/* bombs left and player is not dead */)
            {

            }
        }

        private static void PlayerTwoMove(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.S && level[PlayerTwoX][PlayerTwoY + 1] != GameChars.indestructibleWall && level[PlayerTwoX][PlayerTwoY + 1] != GameChars.playerOneChar && level[PlayerTwoX][PlayerTwoY + 1] != GameChars.destructibleWall)
            {
                level[PlayerTwoX][PlayerTwoY] = GameChars.emptySpace;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.WriteLine(GameChars.emptySpace);
                PlayerTwoY++;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.Write(GameChars.playerTwoChar);
                level[PlayerTwoX][PlayerTwoY] = GameChars.playerTwoChar;
            }
            else if (keyInfo.Key == ConsoleKey.W && level[PlayerTwoX][PlayerTwoY - 1] != GameChars.indestructibleWall && level[PlayerTwoX][PlayerTwoY - 1] != GameChars.playerOneChar && level[PlayerTwoX][PlayerTwoY - 1] != GameChars.destructibleWall)
            {
                level[PlayerTwoX][PlayerTwoY] = GameChars.emptySpace;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.WriteLine(GameChars.emptySpace);
                PlayerTwoY--;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.Write(GameChars.playerTwoChar);
                level[PlayerTwoX][PlayerTwoY] = GameChars.playerTwoChar;
            }
            else if (keyInfo.Key == ConsoleKey.A && level[PlayerTwoX - 1][PlayerTwoY] != GameChars.indestructibleWall && level[PlayerTwoX - 1][PlayerTwoY] != GameChars.playerOneChar && level[PlayerTwoX - 1][PlayerTwoY] != GameChars.destructibleWall)
            {
                level[PlayerTwoX][PlayerTwoY] = GameChars.emptySpace;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.WriteLine(GameChars.emptySpace);
                PlayerTwoX--;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.Write(GameChars.playerTwoChar);
                level[PlayerTwoX][PlayerTwoY] = GameChars.playerTwoChar;
            }
            else if (keyInfo.Key == ConsoleKey.D && level[PlayerTwoX + 1][PlayerTwoY] != GameChars.indestructibleWall && level[PlayerTwoX + 1][PlayerTwoY] != GameChars.playerOneChar && level[PlayerTwoX + 1][PlayerTwoY] != GameChars.destructibleWall)
            {
                level[PlayerTwoX][PlayerTwoY] = GameChars.emptySpace;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.WriteLine(GameChars.emptySpace);
                PlayerTwoX++;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.Write(GameChars.playerTwoChar);
                level[PlayerTwoX][PlayerTwoY] = GameChars.playerTwoChar;
            }
            else if (keyInfo.Key == ConsoleKey.Spacebar/* bombs left and player is not dead */)
            {

            }
        }
    }
}