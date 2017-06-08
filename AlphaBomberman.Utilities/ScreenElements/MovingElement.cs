namespace AlphaBomberman.Utilities.ScreenElements
{
    using System;

    /// <summary>
    /// MovingElement class is used as a model for every
    /// moving object that is shown on the screen.
    /// It inherits from the ScreenElement class and
    /// has all its properties and method but also adds
    /// destination fields, a layout, and display status.
    /// </summary>
    /// <remarks>
    /// If you debug objects from this class you will see
    /// an example of inheritence
    /// </remarks>
    
    // TODO - refactor the class to match the new game with x movement
    public class MovingElement : ScreenElement
    {
        public string[] _layout;
        protected int _rowDestination;
        protected int _columnDestination;
        protected bool _visible;
        
        public MovingElement(int row, int column)
            : base(row, column)
        {
            _rowDestination = _row;
            _columnDestination = column;
            _layout = new[] { "" };
            _visible = false;
        }

        public int RowDestination
        {
            get { return _rowDestination; }
            set { _rowDestination = value; }
        }

        public int ColumnDestination
        {
            get { return _columnDestination; }
            set { _columnDestination = value; }
        }

        public void SetLayout(string[] layout)
        {
            _layout = layout;
        }

        public virtual void Move()
        {
            if (_visible && (_rowDestination != _row || _columnDestination != _column))
            {
                Console.MoveBufferArea(
                    _column,
                    _row,
                    _layout[0].Length,
                    _layout.Length,
                    _columnDestination,
                    _rowDestination
                );
                _row = _rowDestination;
                _column = _columnDestination;
            }
        }

        public override void Print()
        {
            Console.SetCursorPosition(Column, Row);

            foreach (string line in _layout)
            {
                int colAfter = Console.CursorLeft + line.Length;
                Console.Write(line);
                Console.CursorLeft = Column;
                if (colAfter < Console.WindowWidth && Console.CursorTop < Console.BufferHeight - 1)
                {
                    Console.CursorTop++;
                }

            }
            _visible = true;
        }
    }
}
