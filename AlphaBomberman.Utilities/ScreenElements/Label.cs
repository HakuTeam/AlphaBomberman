namespace AlphaBomberman.Utilities.ScreenElements
{
    using System;

    /// <summary>
    /// Label class is used as for every
    /// static text that is shown on the screen.
    /// It inherits from the ScreenElement class and
    /// has all its properties and methods but add a content
    /// string containing the text to be displayed.
    /// </summary>
    /// <remarks>
    /// Be careful - the class does not chech if the message
    /// goes outside the creen yet.
    /// If you debug objects from this class you will see
    /// an example of inheritence.
    /// </remarks>

    public class Label : ScreenElement
    {
        private string _content;

        public Label(int row, int column, string content)
            : base(row, column)
        {
            _content = content;
        }

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public override void Print()
        {
            Console.SetCursorPosition(Column, Row);
            Console.Write(_content);
        }
    }
}
