namespace AlphaBomberman.Utilities.ScreenElementsComposite
{
    using System;
    using ScreenElements;
    using Composer;

    /// <summary>
    /// Useed to display messages to the user. It contains
    /// a text message surrouded with a frame.
    /// </summary>
    /// <remarks>
    /// The method Celar() removes it from the screen.
    /// Currently supports only one row of text.
    /// </remarks>
    public class Alert : ScreenDecoration
    {
        private const int Padding = 2;

        //one row of text
        private const int Height = 1 + 2 * Padding;

        public Alert(int row, int column, string text)
        {
            int boxWidth = text.Length + Padding * 2;

            Add(Composer.GetBox(boxWidth,Height,row,column));

            int labelColumn = column + Padding;
            int labelRow = row + Padding;

            Add(new Label(labelRow,labelColumn,text));
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
