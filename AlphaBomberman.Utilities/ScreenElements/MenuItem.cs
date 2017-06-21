namespace AlphaBomberman.Utilities.ScreenElements
{
    using System;
    using Ennumetation;

    /// <summary>
    /// MenuItem class inherits from Label class.
    /// This is a Label with a command that can be executed.
    /// </summary>
    /// <remarks>
    /// If you debug objects from this class you will see
    /// an example of double/two level inheritence.
    /// </remarks>

    public class MenuItem : Label
    {
        public Command Command { get; set; }

        public MenuItem(int row, int column, string content, Command command) :
            base(row, column, content)
        {
            Command = command;
        }
    }
}
