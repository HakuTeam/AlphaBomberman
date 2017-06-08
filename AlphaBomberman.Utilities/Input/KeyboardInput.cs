namespace AlphaBomberman.Utilities.Input
{
    using System;
    using Ennumetation;

    /// <summary>
    /// KeyboardInput class contains commads for listening the
    /// user input</summary>
    /// <remarks>
    /// TODO - add example or notes here 
    /// </remarks>
    public class KeyboardInput
    {
        /// <summary>
        /// Listens until a key is pressed and translates it 
        /// to the corresponding command.
        /// </summary>
        /// <remarks>
        /// If you need a new commad, first add it to the
        /// Command class.
        /// </remarks>
        public Command Listen()
        {
            var next = Console.ReadKey(true);
            switch (next.Key.ToString())
            {
                case "UpArrow":
                    return Command.MoveUp;
                case "DownArrow":
                    return Command.MoveDown;
                case "LeftArrow":
                    return Command.MoveLeft;
                case "RightArrow":
                    return Command.MoveRight;
                case "NumPad0":
                    return Command.PlaceBomb;
                case "Enter":
                    return Command.Execute;
                case "Escape":
                    return Command.Exit;
                default:
                    return Command.Unknown;
            }
        }

        public string Read()
        {
            var input = Console.ReadLine();
            return input;
        }
    }
}
