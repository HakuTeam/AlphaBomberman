namespace AlphaBomberman.Utilities.ScreenElementsComposite
{
    using Composer;

    public class Input : Alert
    {
        private int _fildSize;

        public Input(int row, int column, string text, int fildSize) : base(row, column, text)
        {
            _fildSize = fildSize;

            Elements[0] = Composer.GetBox(
                text.Length + 6 + _fildSize,
                5,
                row - 2, column - (text.Length / 2) - 3);
        }
    }
}
