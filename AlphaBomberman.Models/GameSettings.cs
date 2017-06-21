namespace AlphaBomberman.Models
{
    public class GameSettings
    {
        //Bombs
        public const int BombClock = 2000;

        //Home screen
        public const int HomeWidth = 20;
        public const int HomeHeight = 10;

        //default level size
        public static int GameWidthDefault = 17;
        public static int GameHeightDefault = 11;

        //Sounds
        public static string HomeMusic = @"../../Sounds/Home-screen.wav";
        public static string BombSound = @"../../Sounds/Bomb1.wav";
    }
}
