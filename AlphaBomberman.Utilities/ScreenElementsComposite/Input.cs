namespace AlphaBomberman.Utilities.ScreenElementsComposite
{
    using Composer;
    using ScreenElements;

    public class Input : ScreenDecoration
    {
        public static int Padding = 2;
        public static int Height = 1 + 2 * Padding;

        public Input(int row, int column, string text, int inputFieldLength)
        {
            int boxWidth = text.Length + inputFieldLength + Padding*2;

            Add(Composer.GetBox(boxWidth,Height,row,column));

            int labelColumn = column + Padding;
            int labelRow = row + Padding;

            Add(new Label(labelRow, labelColumn, text));
        }
    }
}
