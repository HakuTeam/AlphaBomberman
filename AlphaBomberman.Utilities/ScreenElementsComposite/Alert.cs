namespace AlphaBomberman.Utilities.ScreenElementsComposite
{
    using System;
    using ScreenElements;

    /// <summary>
    /// User to display messages to the user. It contains
    /// a text message surrouded with a frame.
    /// </summary>
    /// <remarks>
    /// The method Celar() removes it from the screen.
    /// </remarks>
    public class Alert : ScreenDecoration
    {
        // TODO - This class had some problems with long text, resolve them!
        public Alert(int row, int column, string text)
        {
            Elements.Add(Composer.GetBox(
                text.Length + 6,
                5,
                row - 2, column - (text.Length / 2) - 3));

            Elements.Add(
                new Label(
                    row,
                    column - (text.Length / 2),
                    text)
            );
        }

        public void Clear()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Black;
            Print();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
