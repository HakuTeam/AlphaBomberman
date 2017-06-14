namespace AlphaBomberman.Models
{
    using System;

    public class Player
    {
        public static LevelModel level = new LevelModel(11,17);
        public static int PlayerOneX = 1;
        public static int PlayerOneY = 1;
        public static int PlayerTwoX = level.GetDownRightIndex();
        public static int PlayerTwoY = level.Matrix[level.GetDownRightIndex()].Length - 2;

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
            if (keyInfo.Key == ConsoleKey.DownArrow && level.Matrix[PlayerOneX][PlayerOneY + 1] != GameChars.indestructibleWall && level.Matrix[PlayerOneX][PlayerOneY + 1] != GameChars.playerTwoChar && level.Matrix[PlayerOneX][PlayerOneY + 1] != GameChars.destructibleWall)
            {
                level.Matrix[PlayerOneX][PlayerOneY] = GameChars.emptySpace;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.WriteLine(GameChars.emptySpace);
                PlayerOneY++;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.Write(GameChars.playerOneChar);
                level.Matrix[PlayerOneX][PlayerOneY] = GameChars.playerOneChar;
            }
            else if (keyInfo.Key == ConsoleKey.UpArrow && level.Matrix[PlayerOneX][PlayerOneY - 1] != GameChars.indestructibleWall && level.Matrix[PlayerOneX][PlayerOneY - 1] != GameChars.playerTwoChar && level.Matrix[PlayerOneX][PlayerOneY - 1] != GameChars.destructibleWall)
            {
                level.Matrix[PlayerOneX][PlayerOneY] = GameChars.emptySpace;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.WriteLine(GameChars.emptySpace);
                PlayerOneY--;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.Write(GameChars.playerOneChar);
                level.Matrix[PlayerOneX][PlayerOneY] = GameChars.playerOneChar;
            }
            else if (keyInfo.Key == ConsoleKey.LeftArrow && level.Matrix[PlayerOneX - 1][PlayerOneY] != GameChars.indestructibleWall && level.Matrix[PlayerOneX - 1][PlayerOneY] != GameChars.playerTwoChar && level.Matrix[PlayerOneX - 1][PlayerOneY] != GameChars.destructibleWall)
            {
                level.Matrix[PlayerOneX][PlayerOneY] = GameChars.emptySpace;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.WriteLine(GameChars.emptySpace);
                PlayerOneX--;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.Write(GameChars.playerOneChar);
                level.Matrix[PlayerOneX][PlayerOneY] = GameChars.playerOneChar;
            }
            else if (keyInfo.Key == ConsoleKey.RightArrow && level.Matrix[PlayerOneX + 1][PlayerOneY] != GameChars.indestructibleWall && level.Matrix[PlayerOneX + 1][PlayerOneY] != GameChars.playerTwoChar && level.Matrix[PlayerOneX + 1][PlayerOneY] != GameChars.destructibleWall)
            {
                level.Matrix[PlayerOneX][PlayerOneY] = GameChars.emptySpace;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.WriteLine(GameChars.emptySpace);
                PlayerOneX++;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.Write(GameChars.playerOneChar);
                level.Matrix[PlayerOneX][PlayerOneY] = GameChars.playerOneChar;
            }
            else if (keyInfo.Key == ConsoleKey.NumPad0/* bombs left and player is not dead */)
            {

            }
        }

        private static void PlayerTwoMove(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.S && level.Matrix[PlayerTwoX][PlayerTwoY + 1] != GameChars.indestructibleWall && level.Matrix[PlayerTwoX][PlayerTwoY + 1] != GameChars.playerOneChar && level.Matrix[PlayerTwoX][PlayerTwoY + 1] != GameChars.destructibleWall)
            {
                level.Matrix[PlayerTwoX][PlayerTwoY] = GameChars.emptySpace;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.WriteLine(GameChars.emptySpace);
                PlayerTwoY++;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.Write(GameChars.playerTwoChar);
                level.Matrix[PlayerTwoX][PlayerTwoY] = GameChars.playerTwoChar;
            }
            else if (keyInfo.Key == ConsoleKey.W && level.Matrix[PlayerTwoX][PlayerTwoY - 1] != GameChars.indestructibleWall && level.Matrix[PlayerTwoX][PlayerTwoY - 1] != GameChars.playerOneChar && level.Matrix[PlayerTwoX][PlayerTwoY - 1] != GameChars.destructibleWall)
            {
                level.Matrix[PlayerTwoX][PlayerTwoY] = GameChars.emptySpace;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.WriteLine(GameChars.emptySpace);
                PlayerTwoY--;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.Write(GameChars.playerTwoChar);
                level.Matrix[PlayerTwoX][PlayerTwoY] = GameChars.playerTwoChar;
            }
            else if (keyInfo.Key == ConsoleKey.A && level.Matrix[PlayerTwoX - 1][PlayerTwoY] != GameChars.indestructibleWall && level.Matrix[PlayerTwoX - 1][PlayerTwoY] != GameChars.playerOneChar && level.Matrix[PlayerTwoX - 1][PlayerTwoY] != GameChars.destructibleWall)
            {
                level.Matrix[PlayerTwoX][PlayerTwoY] = GameChars.emptySpace;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.WriteLine(GameChars.emptySpace);
                PlayerTwoX--;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.Write(GameChars.playerTwoChar);
                level.Matrix[PlayerTwoX][PlayerTwoY] = GameChars.playerTwoChar;
            }
            else if (keyInfo.Key == ConsoleKey.D && level.Matrix[PlayerTwoX + 1][PlayerTwoY] != GameChars.indestructibleWall && level.Matrix[PlayerTwoX + 1][PlayerTwoY] != GameChars.playerOneChar && level.Matrix[PlayerTwoX + 1][PlayerTwoY] != GameChars.destructibleWall)
            {
                level.Matrix[PlayerTwoX][PlayerTwoY] = GameChars.emptySpace;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.WriteLine(GameChars.emptySpace);
                PlayerTwoX++;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.Write(GameChars.playerTwoChar);
                level.Matrix[PlayerTwoX][PlayerTwoY] = GameChars.playerTwoChar;
            }
            else if (keyInfo.Key == ConsoleKey.Spacebar/* bombs left and player is not dead */)
            {

            }
        }
    }
}