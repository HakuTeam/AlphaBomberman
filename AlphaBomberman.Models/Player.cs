namespace AlphaBomberman.Models
{
    using System;
    using System.Collections.Generic;
    using System.Timers;

    public class Player
    {
        public static LevelModel Level;
        public static int PlayerOneX;
        public static int PlayerOneY;
        public static int PlayerTwoX;
        public static int PlayerTwoY;
        public static List<Bomb> bombs = new List<Bomb>();

        public Player(LevelModel level)
        {
            Level = level;
            PlayerOneX = 1;
            PlayerOneY = 1;
            PlayerTwoX = Level.GetDownRightIndex();
            PlayerTwoY = Level.Matrix[Level.GetDownRightIndex()].Length - 2;
        }

        public static void Move()
        {
            ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                PlayerOneMove(keyInfo);
                PlayerTwoMove(keyInfo);
            }
            Console.Clear();
            Console.WriteLine("Exit successful!");
            Environment.Exit(0);
        }

        private static void PlayerOneMove(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.DownArrow && Level.Matrix[PlayerOneX][PlayerOneY + 1] != GameChars.indestructibleWall && Level.Matrix[PlayerOneX][PlayerOneY + 1] != GameChars.playerTwoChar && Level.Matrix[PlayerOneX][PlayerOneY + 1] != GameChars.destructibleWall)
            {
                Level.Matrix[PlayerOneX][PlayerOneY] = GameChars.emptySpace;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.WriteLine(GameChars.emptySpace);
                PlayerOneY++;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.Write(GameChars.playerOneChar);
                Level.Matrix[PlayerOneX][PlayerOneY] = GameChars.playerOneChar;
            }
            else if (keyInfo.Key == ConsoleKey.UpArrow && Level.Matrix[PlayerOneX][PlayerOneY - 1] != GameChars.indestructibleWall && Level.Matrix[PlayerOneX][PlayerOneY - 1] != GameChars.playerTwoChar && Level.Matrix[PlayerOneX][PlayerOneY - 1] != GameChars.destructibleWall)
            {
                Level.Matrix[PlayerOneX][PlayerOneY] = GameChars.emptySpace;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.WriteLine(GameChars.emptySpace);
                PlayerOneY--;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.Write(GameChars.playerOneChar);
                Level.Matrix[PlayerOneX][PlayerOneY] = GameChars.playerOneChar;
            }
            else if (keyInfo.Key == ConsoleKey.LeftArrow && Level.Matrix[PlayerOneX - 1][PlayerOneY] != GameChars.indestructibleWall && Level.Matrix[PlayerOneX - 1][PlayerOneY] != GameChars.playerTwoChar && Level.Matrix[PlayerOneX - 1][PlayerOneY] != GameChars.destructibleWall)
            {
                Level.Matrix[PlayerOneX][PlayerOneY] = GameChars.emptySpace;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.WriteLine(GameChars.emptySpace);
                PlayerOneX--;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.Write(GameChars.playerOneChar);
                Level.Matrix[PlayerOneX][PlayerOneY] = GameChars.playerOneChar;
            }
            else if (keyInfo.Key == ConsoleKey.RightArrow && Level.Matrix[PlayerOneX + 1][PlayerOneY] != GameChars.indestructibleWall && Level.Matrix[PlayerOneX + 1][PlayerOneY] != GameChars.playerTwoChar && Level.Matrix[PlayerOneX + 1][PlayerOneY] != GameChars.destructibleWall)
            {
                Level.Matrix[PlayerOneX][PlayerOneY] = GameChars.emptySpace;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.WriteLine(GameChars.emptySpace);
                PlayerOneX++;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.Write(GameChars.playerOneChar);
                Level.Matrix[PlayerOneX][PlayerOneY] = GameChars.playerOneChar;
            }
            //else if (keyInfo.Key == ConsoleKey.NumPad0/* bombs left and player is not dead */)
            //{
            //    Level.Matrix[PlayerOneX][PlayerOneY] = GameChars.bombChar;
            //    Console.SetCursorPosition(PlayerOneX, PlayerOneY);
            //    Console.WriteLine(GameChars.bombChar);
            //    var timer = this.Timer();
            //    timer.Start();
            //    timer.Elapsed += new ElapsedEventHandler(MakeBoomP);
            //}
        }

        private static void MakeBoomP(object sender, ElapsedEventArgs e)
        {
            BombExplosion.Explosion(PlayerOneX, PlayerOneY);
        }

        private static void PlayerTwoMove(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.S && Level.Matrix[PlayerTwoX][PlayerTwoY + 1] != GameChars.indestructibleWall && Level.Matrix[PlayerTwoX][PlayerTwoY + 1] != GameChars.playerOneChar && Level.Matrix[PlayerTwoX][PlayerTwoY + 1] != GameChars.destructibleWall)
            {
                Level.Matrix[PlayerTwoX][PlayerTwoY] = GameChars.emptySpace;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.WriteLine(GameChars.emptySpace);
                PlayerTwoY++;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.Write(GameChars.playerTwoChar);
                Level.Matrix[PlayerTwoX][PlayerTwoY] = GameChars.playerTwoChar;
            }
            else if (keyInfo.Key == ConsoleKey.W && Level.Matrix[PlayerTwoX][PlayerTwoY - 1] != GameChars.indestructibleWall && Level.Matrix[PlayerTwoX][PlayerTwoY - 1] != GameChars.playerOneChar && Level.Matrix[PlayerTwoX][PlayerTwoY - 1] != GameChars.destructibleWall)
            {
                Level.Matrix[PlayerTwoX][PlayerTwoY] = GameChars.emptySpace;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.WriteLine(GameChars.emptySpace);
                PlayerTwoY--;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.Write(GameChars.playerTwoChar);
                Level.Matrix[PlayerTwoX][PlayerTwoY] = GameChars.playerTwoChar;
            }
            else if (keyInfo.Key == ConsoleKey.A && Level.Matrix[PlayerTwoX - 1][PlayerTwoY] != GameChars.indestructibleWall && Level.Matrix[PlayerTwoX - 1][PlayerTwoY] != GameChars.playerOneChar && Level.Matrix[PlayerTwoX - 1][PlayerTwoY] != GameChars.destructibleWall)
            {
                Level.Matrix[PlayerTwoX][PlayerTwoY] = GameChars.emptySpace;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.WriteLine(GameChars.emptySpace);
                PlayerTwoX--;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.Write(GameChars.playerTwoChar);
                Level.Matrix[PlayerTwoX][PlayerTwoY] = GameChars.playerTwoChar;
            }
            else if (keyInfo.Key == ConsoleKey.D && Level.Matrix[PlayerTwoX + 1][PlayerTwoY] != GameChars.indestructibleWall && Level.Matrix[PlayerTwoX + 1][PlayerTwoY] != GameChars.playerOneChar && Level.Matrix[PlayerTwoX + 1][PlayerTwoY] != GameChars.destructibleWall)
            {
                Level.Matrix[PlayerTwoX][PlayerTwoY] = GameChars.emptySpace;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.WriteLine(GameChars.emptySpace);
                PlayerTwoX++;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.Write(GameChars.playerTwoChar);
                Level.Matrix[PlayerTwoX][PlayerTwoY] = GameChars.playerTwoChar;
            }
            else if (keyInfo.Key == ConsoleKey.Spacebar/* bombs left and player is not dead */)
            {
                var bomb = new Bomb(PlayerTwoY, PlayerTwoX, Level, 3);
                bombs.Add(bomb);
            }

            for (int i = 0; i < bombs.Count; i++)
            {
                if (bombs[i].Timer.ElapsedMilliseconds >= bombs[i].Clock)
                {
                    bombs[i].Explode();
                    bombs.Remove(bombs[i]);
                }
            }
        }

        private static void MakeBoomK(object sender, ElapsedEventArgs e)
        {
            BombExplosion.Explosion(PlayerTwoX, PlayerTwoY);
        }
    }
}