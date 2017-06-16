namespace AlphaBomberman
{
    using System;
    using System.Reflection.Emit;
    using Models;
    using Utilities.Ennumetation;
    using Utilities.Input;
    using Utilities.ScreenElements;
    using Utilities.ScreenElementsComposite;

    class Startup
    {

        public static int GameWidth = 17;
        public static int GameHeight = 11;

        public const int HomeWidth = 20;
        public const int HomeHeight = 10;

        static void Main()
        {
            RunHomeScreen(HomeWidth, HomeHeight);
        }

        static void RunHomeScreen(int width, int height)
        {
            PrepareConsole(width, height);

            //create menu
            var homeMenu = new Menu(width, height);

            //add menu items
            homeMenu.Add("START GAME", Command.StartGame);
            homeMenu.Add("EXIT GAME", Command.Exit);
            homeMenu.Print();


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

        private static void PrepareConsole(int width, int height)
        {
            Console.CursorVisible = false;
            Console.WindowWidth = width +5;
            Console.WindowHeight = height +5;
            Console.BufferWidth = width + 5;
            Console.BufferHeight = height + 5;
            Console.Clear();
        }

        private static int GetUserInput(string message)
        {
            string uInput;

            Input inputAlert = new Input(HomeHeight / 2, HomeWidth / 2, message, 5);

            inputAlert.Print();
            uInput = Console.ReadLine();

            if (string.IsNullOrEmpty(uInput))
            {
                return 20;
            }
            return int.Parse(uInput);
        }

        public static void ExecCommand(Command command)
        {
            switch (command)
            {
                case Command.StartGame:
                    var size = GetUserInput("Level width:");
                    GameHeight = size;

                    size = GetUserInput("Level height:");
                    GameWidth = size;

                    PrepareConsole(GameWidth,GameHeight);
                    var player = new Player(new LevelModel(GameWidth, GameHeight));
                    Player.Move();
                    break;
                case Command.Exit:
                    Console.Clear();
                    Console.WriteLine("Exit successful!");
                    Environment.Exit(0);
                    break;
                case Command.HomeScreen:
                    //end game clear then go to home screen
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