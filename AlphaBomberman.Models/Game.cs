namespace AlphaBomberman.Models
{
    using System;
    using System.Threading;
    using Utilities.Ennumetation;
    using Utilities.Input;
    using Utilities.ScreenElementsComposite;
    using Utilities.Composer;
    using Utilities.ScreenElements;

    public class Game
    {

        public static int GameWidth = GameSettings.GameWidthDefault;
        public static int GameHeight = GameSettings.GameHeightDefault;
        public static System.Media.SoundPlayer music = new System.Media.SoundPlayer(GameSettings.HomeMusic);


        public static void RunHomeScreen(int width, int height)
        {
            PrepareConsole();
            music.Play();

            //create menu
            var homeMenu = new Menu(
                width: width,
                height: height,
                colorForeground: GameColors.DefaultForeground,
                colorBackground: GameColors.DefaultBackground,
                colorFrame: GameColors.MenuFrame,
                colorSelectedForeground: GameColors.MenuSelectedForeground,
                colorSelectedBackground: GameColors.MenuSelectedBackground
                );

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

        public static void GameOverScreen(int width, int height)
        {
            var gameOverScreen = new Menu(width, height);

            gameOverScreen.Add("Restart?", Command.HomeScreen);
        }

        public static ConsoleKey Tick()
        {
            ConsoleKey result;

            DateTime beginWait = DateTime.Now;
            while (!Console.KeyAvailable && DateTime.Now.Subtract(beginWait).TotalMilliseconds < GameSettings.BombClock)
                Thread.Sleep(250);

            if (!Console.KeyAvailable)
                result = ConsoleKey.T;
            else
            {
                result = Console.ReadKey(true).Key;
            }
            return result;
        }

        private static void ShowGameOverScreen(int homeWidth, int homeHeight)
        {
            var menu = new Menu(homeWidth, homeHeight);

            menu.Add("Restart?", Command.HomeScreen);
            menu.Print();
            PrintGameOverScreen();

            while (menu.IsShown)
            {
                var keyInput = new KeyboardInput();
                var command = keyInput.Listen();
                switch (command)
                {
                    case Command.Execute:
                        Command menuCommand = (menu.GetSelected()).Command;
                        ExecCommand(menuCommand);
                        menu.IsShown = false;
                        break;
                }
            }
        }

        private static void PrintGameOverScreen()
        {
            Console.WriteLine();
            Console.SetCursorPosition(3, 3);
            if (Player.PlayerOneIsAlive)
            {
                Console.WriteLine("P won the beer");
            }
            else
            {
                Console.WriteLine("K won the beer");
            }

            Console.WriteLine();
            Console.SetCursorPosition(3, 4);
            Console.WriteLine("    oOOOOOo");
            Console.SetCursorPosition(3, 5);
            Console.WriteLine("   ,|    oO");
            Console.SetCursorPosition(3, 6);
            Console.WriteLine("  //|     |");
            Console.SetCursorPosition(3, 7);
            Console.WriteLine("  \\\\|     |");
            Console.SetCursorPosition(3, 8);
            Console.WriteLine("    `-----`");
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

            Console.WindowHeight = Console.LargestWindowHeight - 10;
            Console.BufferWidth = (Console.LargestWindowWidth / 3) * 2;
            Console.BufferHeight = Console.LargestWindowHeight - 10;

            Console.Clear();
            Console.SetCursorPosition(1, 1);
        }

        private static int GetUserIntInput(string message, int inputLength)
        {
            int firstRow = GameSettings.HomeHeight / 2 - Input.Padding;
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

                    music.Stop();
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
                    RunHomeScreen(GameSettings.HomeWidth, GameSettings.HomeHeight);
                    break;
                case Command.ExitMenu:
                    //end game clear then go to home screen
                    Console.Clear();
                    ShowExitMenu(GameSettings.HomeWidth, GameSettings.HomeHeight);
                    break;
                case Command.GameOverScreen:
                    //end game clear then go to home screen
                    Console.Clear();
                    ShowGameOverScreen(GameSettings.HomeWidth, GameSettings.HomeHeight);
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
            string[] levelPrintable = Composer.Compose(level.Matrix);
            var levelState = new StaticElement(levelPrintable);
            levelState.Print();
        }

        public static void RestConsoleColors()
        {
            Console.BackgroundColor = GameColors.DefaultBackground;
            Console.ForegroundColor = GameColors.DefaultForeground;
        }
    }
}