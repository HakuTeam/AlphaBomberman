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
        public static int MiddleRow;
        public static int MiddleColumn;


        public static void RunHomeScreen(int width, int height)
        {
            PrepareConsole();
            music.Play();

            //Calculate screen position

            int startRow = StartRow(height);
            int startColumn = StartColumn(width);

            //create menu
            var homeMenu = new Menu(
                width: width,
                height: height,
                row: startRow,
                column: startColumn,
                colorForeground: GameColors.DefaultForeground,
                colorBackground: GameColors.DefaultBackground,
                colorFrame: GameColors.MenuFrame,
                colorSelectedForeground: GameColors.MenuSelectedForeground,
                colorSelectedBackground: GameColors.MenuSelectedBackground
                );

            //add menu items
            homeMenu.Add(startRow, startColumn, "START GAME", Command.StartGame);
            homeMenu.Add(startRow, startColumn, "EXIT GAME", Command.Exit);
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

        private static int StartColumn(int width)
        {
            return MiddleColumn - (width / 2);
        }

        private static int StartRow(int height)
        {
            return MiddleRow - (height / 2);
        }

        public static void GameOverScreen(int width, int height)
        {
            int startRow = StartRow(height);
            int startColumn = StartColumn(width);

            var gameOverScreen = new Menu(startRow, startColumn, width, height);

            gameOverScreen.Add(startRow, startColumn, "Restart?", Command.HomeScreen);
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

        private static void ShowGameOverScreen()
        {
            int startRow = StartRow(GameSettings.HomeHeight);
            int startColumn = StartColumn(GameSettings.HomeWidth);

            var menu = new Menu(
                width: GameSettings.HomeWidth,
                height: GameSettings.HomeHeight,
                row: startRow,
                column: startColumn
                );

            menu.Add(startRow, startColumn, "Restart?", Command.HomeScreen);
            menu.Print();
            PrintGameOverScreen(startColumn,startRow);

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

        private static void PrintGameOverScreen(int leftOffset, int topOffset)
        {
            Console.WriteLine();
            var left = 3 + leftOffset;
            Console.SetCursorPosition(left, 3 + topOffset);
            if (Player.PlayerOneIsAlive)
            {
                Console.WriteLine("P won the beer");
            }
            else
            {
                Console.WriteLine("K won the beer");
            }

            Console.WriteLine();
            Console.SetCursorPosition(left, 4 + topOffset);
            Console.WriteLine("    oOOOOOo");
            Console.SetCursorPosition(left, 5 + topOffset);
            Console.WriteLine("   ,|    oO");
            Console.SetCursorPosition(left, 6 + topOffset);
            Console.WriteLine("  //|     |");
            Console.SetCursorPosition(left, 7 + topOffset);
            Console.WriteLine("  \\\\|     |");
            Console.SetCursorPosition(left, 8 + topOffset);
            Console.WriteLine("    `-----`");
        }

        public static void ShowExitMenu(int width, int height)
        {
            PrepareConsole();
            music.Play();

            //Calculate screen position

            int startRow = StartRow(height);
            int startColumn = StartColumn(width);


            //create menu
            var menu = new Menu(
                width: width,
                height: height,
                row: startRow,
                column: startColumn,
                colorForeground: GameColors.DefaultForeground,
                colorBackground: GameColors.DefaultBackground,
                colorFrame: GameColors.MenuFrame,
                colorSelectedForeground: GameColors.MenuSelectedForeground,
                colorSelectedBackground: GameColors.MenuSelectedBackground);

            //add menu items
            menu.Add(startRow,startColumn,"Resume Game", Command.ResumeGame);
            menu.Add(startRow, startColumn, "Home Screen", Command.HomeScreen);
            menu.Add(startRow, startColumn, "Exit Game", Command.Exit);
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

            //Calculate the middle of the screen
            MiddleRow = Console.BufferHeight / 2;
            MiddleColumn = Console.BufferWidth / 2;
        }

        private static int GetUserIntInput(string message, int inputLength)
        {
            int startRow = StartRow(GameSettings.HomeHeight);
            int startColumn = StartColumn(GameSettings.HomeWidth);

            int firstRow = startRow + GameSettings.HomeHeight / 2 - Input.Padding;
            int result;

            Input inputAlert = new Input(firstRow, startColumn, message, inputLength);

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
                    ShowGameOverScreen();
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