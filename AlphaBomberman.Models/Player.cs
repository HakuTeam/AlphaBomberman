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
            if (keyInfo.Key == ConsoleKey.DownArrow && Level.Matrix[PlayerOneX][PlayerOneY + 1] != GameChars.IndestructibleWall && Level.Matrix[PlayerOneX][PlayerOneY + 1] != GameChars.PlayerTwoChar && Level.Matrix[PlayerOneX][PlayerOneY + 1] != GameChars.DestructibleWall && Level.Matrix[PlayerOneX][PlayerOneY + 1] != GameChars.BombChar)
            {
                Level.Matrix[PlayerOneX][PlayerOneY] = GameChars.EmptySpace;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.WriteLine(GameChars.EmptySpace);
                PlayerOneY++;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.Write(GameChars.PlayerOneChar);
                Level.Matrix[PlayerOneX][PlayerOneY] = GameChars.PlayerOneChar;
            }
            else if (keyInfo.Key == ConsoleKey.UpArrow && Level.Matrix[PlayerOneX][PlayerOneY - 1] != GameChars.IndestructibleWall && Level.Matrix[PlayerOneX][PlayerOneY - 1] != GameChars.PlayerTwoChar && Level.Matrix[PlayerOneX][PlayerOneY - 1] != GameChars.DestructibleWall && Level.Matrix[PlayerOneX][PlayerOneY - 1] != GameChars.BombChar)
            {
                Level.Matrix[PlayerOneX][PlayerOneY] = GameChars.EmptySpace;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.WriteLine(GameChars.EmptySpace);
                PlayerOneY--;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.Write(GameChars.PlayerOneChar);
                Level.Matrix[PlayerOneX][PlayerOneY] = GameChars.PlayerOneChar;
            }
            else if (keyInfo.Key == ConsoleKey.LeftArrow && Level.Matrix[PlayerOneX - 1][PlayerOneY] != GameChars.IndestructibleWall && Level.Matrix[PlayerOneX - 1][PlayerOneY] != GameChars.PlayerTwoChar && Level.Matrix[PlayerOneX - 1][PlayerOneY] != GameChars.DestructibleWall && Level.Matrix[PlayerOneX - 1][PlayerOneY] != GameChars.BombChar)
            {
                Level.Matrix[PlayerOneX][PlayerOneY] = GameChars.EmptySpace;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.WriteLine(GameChars.EmptySpace);
                PlayerOneX--;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.Write(GameChars.PlayerOneChar);
                Level.Matrix[PlayerOneX][PlayerOneY] = GameChars.PlayerOneChar;
            }
            else if (keyInfo.Key == ConsoleKey.RightArrow && Level.Matrix[PlayerOneX + 1][PlayerOneY] != GameChars.IndestructibleWall && Level.Matrix[PlayerOneX + 1][PlayerOneY] != GameChars.PlayerTwoChar && Level.Matrix[PlayerOneX + 1][PlayerOneY] != GameChars.DestructibleWall && Level.Matrix[PlayerOneX + 1][PlayerOneY] != GameChars.BombChar)
            {
                Level.Matrix[PlayerOneX][PlayerOneY] = GameChars.EmptySpace;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.WriteLine(GameChars.EmptySpace);
                PlayerOneX++;
                Console.SetCursorPosition(PlayerOneX, PlayerOneY);
                Console.Write(GameChars.PlayerOneChar);
                Level.Matrix[PlayerOneX][PlayerOneY] = GameChars.PlayerOneChar;
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
            if (keyInfo.Key == ConsoleKey.S && Level.Matrix[PlayerTwoX][PlayerTwoY + 1] != GameChars.IndestructibleWall && Level.Matrix[PlayerTwoX][PlayerTwoY + 1] != GameChars.PlayerOneChar && Level.Matrix[PlayerTwoX][PlayerTwoY + 1] != GameChars.DestructibleWall && Level.Matrix[PlayerTwoX][PlayerTwoY + 1] != GameChars.BombChar)
            {
                Level.Matrix[PlayerTwoX][PlayerTwoY] = GameChars.EmptySpace;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.WriteLine(GameChars.EmptySpace);
                PlayerTwoY++;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.Write(GameChars.PlayerTwoChar);
                Level.Matrix[PlayerTwoX][PlayerTwoY] = GameChars.PlayerTwoChar;
            }
            else if (keyInfo.Key == ConsoleKey.W && Level.Matrix[PlayerTwoX][PlayerTwoY - 1] != GameChars.IndestructibleWall && Level.Matrix[PlayerTwoX][PlayerTwoY - 1] != GameChars.PlayerOneChar && Level.Matrix[PlayerTwoX][PlayerTwoY - 1] != GameChars.DestructibleWall && Level.Matrix[PlayerTwoX][PlayerTwoY - 1] != GameChars.BombChar)
            {
                Level.Matrix[PlayerTwoX][PlayerTwoY] = GameChars.EmptySpace;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.WriteLine(GameChars.EmptySpace);
                PlayerTwoY--;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.Write(GameChars.PlayerTwoChar);
                Level.Matrix[PlayerTwoX][PlayerTwoY] = GameChars.PlayerTwoChar;
            }
            else if (keyInfo.Key == ConsoleKey.A && Level.Matrix[PlayerTwoX - 1][PlayerTwoY] != GameChars.IndestructibleWall && Level.Matrix[PlayerTwoX - 1][PlayerTwoY] != GameChars.PlayerOneChar && Level.Matrix[PlayerTwoX - 1][PlayerTwoY] != GameChars.DestructibleWall && Level.Matrix[PlayerTwoX - 1][PlayerTwoY] != GameChars.BombChar)
            {
                Level.Matrix[PlayerTwoX][PlayerTwoY] = GameChars.EmptySpace;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.WriteLine(GameChars.EmptySpace);
                PlayerTwoX--;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.Write(GameChars.PlayerTwoChar);
                Level.Matrix[PlayerTwoX][PlayerTwoY] = GameChars.PlayerTwoChar;
            }
            else if (keyInfo.Key == ConsoleKey.D && Level.Matrix[PlayerTwoX + 1][PlayerTwoY] != GameChars.IndestructibleWall && Level.Matrix[PlayerTwoX + 1][PlayerTwoY] != GameChars.PlayerOneChar && Level.Matrix[PlayerTwoX + 1][PlayerTwoY] != GameChars.DestructibleWall && Level.Matrix[PlayerTwoX + 1][PlayerTwoY] != GameChars.BombChar)
            {
                Level.Matrix[PlayerTwoX][PlayerTwoY] = GameChars.EmptySpace;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.WriteLine(GameChars.EmptySpace);
                PlayerTwoX++;
                Console.SetCursorPosition(PlayerTwoX, PlayerTwoY);
                Console.Write(GameChars.PlayerTwoChar);
                Level.Matrix[PlayerTwoX][PlayerTwoY] = GameChars.PlayerTwoChar;
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