namespace AlphaBomberman.Models
{
    using Utilities.ScreenElements;
    public class PlayerNew: MovingElement
    {
        private int _rowLimit;
        private int _colLimit;

        public PlayerNew(int row, int column, int rowLimit = 44, int colLimit = 100):base(row,column)
        {
            _rowLimit = rowLimit;
            _colLimit = colLimit;
        }

        public void MoveLeft()
        {
            if (ColumnDestination > 1)
            {
                ColumnDestination -= 1;
            }
        }

        public void MoveRight()
        {
            if (ColumnDestination < _colLimit)
            {
                ColumnDestination += 1;
            }
            
        }

        public void MoveUp()
        {
            if (RowDestination > 1)
            {
                RowDestination -= 1;
            }
        }

        public void MoveDown()
        {
            if (RowDestination < _rowLimit)
            {
                RowDestination += 1;
            }
            
        }
    }
}
