namespace AlphaBomberman.Models
{
    using System;
    using Utilities.Ennumetation;
    using Utilities.Input;
    using Utilities.ScreenElementsComposite;
    using Utilities.Composer;
    using Utilities.ScreenElements;
    using System.Threading.Tasks;

    public class Game
    {
        public const int HomeWidth = 20;
        public const int HomeHeight = 10;

        public static int GameWidth = 17;
        public static int GameHeight = 11;

        public static void RunHomeScreen(int width, int height)
        {
            PrepareConsole();

            //create menu
            var homeMenu = new Menu(width, height);

            //add menu items
            homeMenu.Add("START GAME", Command.StartGame);
            homeMenu.Add("EXIT GAME", Command.Exit);
            homeMenu.Print();


            while (homeMenu.IsShown)
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
                        homeMenu.IsShown = false;
                        break;
                }
            }
        }

        public static void ShowExitMenu(int width, int height)
        {
            //create menu
            var menu = new Menu(width, height);

            //add menu items
            menu.Add("Resume Game", Command.ResumeGame);
            menu.Add("Home Screen", Command.HomeScreen);
            menu.Add("Exit Game", Command.Exit);
            menu.Print();


            while (menu.IsShown)
            {
                // Keayboard funtionality
                var keyInput = new KeyboardInput();
                var command = keyInput.Listen();
                switch (command)
                {
                    case Command.MoveUp:
                        menu.MoveUp();
                        menu.Print();
                        break;
                    case Command.MoveDown:
                        menu.MoveDown();
                        menu.Print();
                        break;
                    case Command.Execute:
                        Command menuCommand = (menu.GetSelected()).Command;
                        ExecCommand(menuCommand);
                        menu.IsShown = false;
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

            Console.WindowWidth = (Console.LargestWindowWidth / 3) * 2;

            Console.WindowHeight = Console.LargestWindowHeight - 5;
            Console.BufferWidth = (Console.LargestWindowWidth / 3) * 2;
            Console.BufferHeight = Console.LargestWindowHeight;

            Console.Clear();
            Console.SetCursorPosition(1, 1);
        }

        private static int GetUserIntInput(string message, int inputLength)
        {
            int firstRow = HomeHeight / 2 - Input.Padding;
            int firstColumn = 0;
            int result;

            Input inputAlert = new Input(firstRow, firstColumn, message, inputLength);

            inputAlert.Print();
            string uInput = Console.ReadLine();

            //Check for null or empty
            if (string.IsNullOrEmpty(uInput))
            {
                return 21;
            }
            if (!int.TryParse(uInput, out result))
            {
                return 21;
            }

            if (uInput.Length > inputLength)
            {
                uInput = uInput.Substring(0, inputLength);
            }

            return int.Parse(uInput);
        }

        public static void ExecCommand(Command command)
        {
            switch (command)
            {
                case Command.StartGame:
                    var userIntInput = GetUserIntInput("Level width:", 3);

                    if (userIntInput > Console.WindowWidth)
                    {
                        GameWidth = Console.WindowWidth;
                    }
                    else
                    {
                        GameWidth = userIntInput;
                    }

                    userIntInput = GetUserIntInput("Level height:", 3);
                    if (userIntInput > Console.WindowHeight)
                    {
                        GameHeight = Console.WindowHeight;
                    }
                    else
                    {
                        GameHeight = userIntInput;
                    }

                    Console.Clear();
                    var player = new Player(new LevelModel(GameWidth, GameHeight));
                    Player.PlayerOneIsAlive = true;
                    Player.PlayerTwoIsAlive = true;
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
                    RunHomeScreen(HomeWidth, HomeHeight);
                    break;
                case Command.ExitMenu:
                    //end game clear then go to home screen
                    Console.Clear();
                    ShowExitMenu(HomeWidth, HomeHeight);
                    break;
                case Command.ResumeGame:
                    //end game clear then go to home screen
                    PrintLevel(Player.Level);
                    Console.CursorVisible = false;
                    Player.Move();
                    break;
            }
        }

        public static void PrintLevel(LevelModel level)
        {
            var levelPrintable = Composer.Compose(level.Matrix);
            var levelState = new StaticElement(levelPrintable);
            levelState.Print();
        }

        static void RestConsoleColors()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}