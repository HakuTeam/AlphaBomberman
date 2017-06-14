namespace AlphaBomberman
{
    using System;
    using Models;
    using Utilities.Ennumetation;
    using Utilities.Input;
    using Utilities.ScreenElements;
    using Utilities.ScreenElementsComposite;

    class Startup
    {

        public const int GameWidth = 17;
        public const int GameHeight = 11;

        static void Main()
        {
            RunHomeScreen(GameWidth, GameHeight);

        }

        static void RunHomeScreen(int width, int height)
        {
            Console.CursorVisible = false;
            Console.WindowWidth = width * 2 + 5;
            Console.WindowHeight = height * 2 + 5;
            Console.BufferWidth = width * 2 + 5;
            Console.BufferHeight = height * 2 + 5;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();

            //create menu
            var homeMenu = new Menu(width, height);

            //add menu items
            homeMenu.Add("START GAME", Command.StartGame);
            homeMenu.Add("EXIT GAME", Command.Exit);


            while (true)
            {
                // Keayboard funtionality
                var keyInput = new KeyboardInput();
                var command = keyInput.Listen();
                switch (command)
                {
                    case Command.MoveUp:
                        homeMenu.MoveUp();
                        homeMenu.Print();
                        break;
                    case Command.MoveDown:
                        homeMenu.MoveDown();
                        homeMenu.Print();
                        break;
                    case Command.Execute:
                        Command menuCommand = (homeMenu.GetSelected()).Command;
                        ExecCommand(menuCommand);
                        break;
                }
            }
        }

        public static void ExecCommand(Command command)
        {
            switch (command)
            {
                case Command.StartGame:
                    Player.Move();
                    break;
                case Command.Exit:
                    Console.Clear();
                    Console.WriteLine("Exit successful!");
                    Environment.Exit(0);
                    break;
                case Command.HomeScreen:
                    //end game clear da go to home screen
                    Console.Clear();
                    RunHomeScreen(GameWidth, GameHeight);
                    break;
            }
        }

        static void RestConsoleColors()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}