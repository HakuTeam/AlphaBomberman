namespace AlphaBomberman
{
    using Models;

    class Startup
    {
        static void Main()
        {
            Game.PrepareConsole(15,15);
            Game.RunHomeScreen(Game.HomeWidth, Game.HomeHeight);
        }
    }
}