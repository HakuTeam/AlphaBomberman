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
    
    public class MovingElement : ScreenElement
    {
        private char _elementChar;
        public int _columnDestination;
        protected bool _visible;
        
        public MovingElement(int row, int column)
            : base(row, column)
        {
            RowDestination = _row;
            _columnDestination = _column;
            _elementChar = ' ';
            _visible = false;
        }

        public int RowDestination { get; set; }

        public int ColumnDestination { get; set; }

        public void SetChar(char layout)
        {
            _elementChar = layout;
        }

        public void Move()
        {
            if (_visible && (RowDestination != _row || _columnDestination != _column))
            {
                Console.MoveBufferArea(
                    _column,
                    _row,
                    1,
                    1,
                    _columnDestination,
                    RowDestination
                );
                _row = RowDestination;
                _column = _columnDestination;
            }
        }

        public override void Print()
        {
            Console.SetCursorPosition(Column, Row);
            Console.Write(_elementChar);
            _visible = true;
        }
    }
}
