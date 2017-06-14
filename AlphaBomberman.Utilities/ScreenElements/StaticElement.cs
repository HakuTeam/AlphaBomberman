namespace AlphaBomberman.Utilities.ScreenElements
{
    using System;

    public class StaticElement: ScreenElement
    {
        public string[] _layout;
        public bool Visible;
        private readonly ConsoleColor _color;

        public StaticElement(string[] layout, int row = 0, int col = 0):base(row,col)
        {
            _layout = layout;
            _color = Console.ForegroundColor;
        }

        public StaticElement(string[] layout, ConsoleColor color, int row = 0, int col = 0) : base(row, col)
        {
            _layout = layout;
            _color = color;
        }

        public int Width()
        {
            return _layout[0].Length;
        }

        public int Height()
        {
            return _layout.Length;
        }

        public override void Print()
        {
            Console.SetCursorPosition(Column, Row);

            //manage colors
            var prevColor = Console.ForegroundColor;
            Console.ForegroundColor = _color;

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
            Visible = true;
            Console.ForegroundColor = prevColor;
        }
    }
}
