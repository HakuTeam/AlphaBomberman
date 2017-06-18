namespace AlphaBomberman.Utilities.ScreenElementsComposite
{
    using System;
    using System.Collections.Generic;
    using ScreenElements;


    /// <summary>
    /// ScreenGroup is an abstract class that should be inherited by all
    /// object made of more that one ScreenElement object.
    /// For example a box with a label.
    /// </summary>
    /// <remarks>
    /// To add new elements use the Add() method.
    /// </remarks>

    public abstract class ScreenGroup
    {
        protected List<ScreenElement> _elements;
        private int _row;
        private int _colum;

        public int Row
        {
            get { return _row; }
        }

        public int Colum
        {
            get { return _colum; }
        }

        /// <summary>
        /// Initiate empty.
        /// </summary>
        protected ScreenGroup()
        {
            Elements = new List<ScreenElement>();
            _row = 0;
            _colum = 0;
        }
        /// <summary>
        /// Initiate from a list of elements.
        /// </summary>
        protected ScreenGroup(List<ScreenElement> elements)
        {
            Elements = elements;
        }

        public List<ScreenElement> Elements
        {
            get { return _elements; }
            set { _elements = value; }
        }

        public void Add(ScreenElement element)
        {
            if (element.Row < 0 || element.Column < 0)
            {
                throw new Exception("Alements with negative coordinates are not allowed!");
            }

            if (element.Row < _row)
            {
                _row = element.Row;
            }

            if (element.Column < _colum)
            {
                _colum = element.Column;
            }

            _elements.Add(element);
        }
        /// <summary>
        /// Display the elements in the group on the screen.
        /// </summary>
        public abstract void Print();
    }
}
