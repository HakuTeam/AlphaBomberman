namespace AlphaBomberman.Utilities.ScreenElementsComposite
{
    using Composer;
    using ScreenElements;

    public class Input : ScreenDecoration
    {
        public const int Padding = 2;
        public const int Height = 1 + 2 * Padding;

        public Input(int row, int column, string text, int inputFieldLength)
        {
            int boxWidth = text.Length + inputFieldLength + Padding;

            Add(Composer.GetBox(boxWidth,Height,row,column));

            int labelColumn = column + Padding;
            int labelRow = row + Padding;

            Add(new Label(labelRow, labelColumn, text));
        }
    }
}
