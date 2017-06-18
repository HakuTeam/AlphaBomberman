namespace AlphaBomberman.Models
{
    using System;
    using AlphaBomberman.Utilities.Ennumetation;
    using AlphaBomberman.Utilities.Input;
    using AlphaBomberman.Utilities.ScreenElementsComposite;

    public class Game
    {
        public static int GameWidth = 17;
        public static int GameHeight = 11;

        public const int HomeWidth = 20;
        public const int HomeHeight = 10;

        public static void RunHomeScreen(int width, int height)
        {
            PrepareConsole();

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

        /// <summary>
        /// Prepares the console size. Does not allow values larger then the largest posible for the current screen resolution.
        /// </summary>
        /// <param name="width">The width of the window and buffer.</param>
        /// <param name="height">The heightof the window and buffer.</param>
        public static void PrepareConsole()
        {
            Console.CursorVisible = false;

            Console.WindowWidth = Console.LargestWindowWidth-5;

            Console.WindowHeight = Console.LargestWindowHeight-5;
            Console.BufferWidth = Console.LargestWindowWidth;
            Console.BufferHeight = Console.LargestWindowHeight;

            Console.Clear();
            Console.SetCursorPosition(1,1);
        }

        private static int GetUserInput(string message)
        {
            string uInput;

            Input inputAlert = new Input(HomeHeight / 2, HomeWidth / 2, message, 3);

            inputAlert.Print();
            uInput = Console.ReadLine();

            if (string.IsNullOrEmpty(uInput))
            {
                return 21;
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
