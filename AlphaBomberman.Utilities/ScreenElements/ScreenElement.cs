namespace AlphaBomberman.Utilities.ScreenElements
{
    /// <summary>
    /// This class is used as a model for every object
    /// that is shown on the screen. It can be used only
    /// when inherited by another class.
    /// </summary>
    /// <remarks>
    /// If you do not understand what an abstract class is,
    /// look at the other classes in the ScreenElements
    /// folder.
    /// </remarks>
    public abstract class ScreenElement
    {
        protected int _column;
        protected int _row;

        protected ScreenElement(int row, int column)
        {
            _column = column;
            _row = row;
        }

        protected ScreenElement(int row)
        {
            _column = 0;
            _row = row;
        }

        public int Column
        {
            get { return _column; }
            set { _column = value; }
        }

        public int Row
        {
            get { return _row; }
            set { _row = value; }
        }

        public abstract void Print();
    }
}
