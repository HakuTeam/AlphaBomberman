namespace AlphaBomberman
{
    using Models;

    class Startup
    {
        static void Main()
        {
            Game.RunHomeScreen(GameSettings.HomeWidth, GameSettings.HomeHeight);
        }
    }
}