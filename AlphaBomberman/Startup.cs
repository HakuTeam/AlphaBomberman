namespace AlphaBomberman
{
    using System;
    using Models;
    using Utilities.ScreenElementsComposite;

    class Startup
    {
        static void Main()
        {
            Console.CursorVisible = false;
            //int gameWidth = 17;
            //int gameHeight = 11;


            //RunHomeScreen(gameWidth,gameHeight);
            Player.Move();
        }

        static void RunHomeScreen(int width, int height)
        {
            Console.WindowWidth = width*2+5;
            Console.WindowHeight = height * 2 + 5;
            Console.BufferWidth = width * 2 + 5;
            Console.BufferHeight = height * 2 + 5;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();

            Level levelOne = new Level(1,width,height);

            levelOne.Print();
            RestConsoleColors();
        }

        static void RestConsoleColors()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}