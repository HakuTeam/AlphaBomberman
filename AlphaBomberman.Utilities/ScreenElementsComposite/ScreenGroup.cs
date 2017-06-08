namespace AlphaBomberman.Utilities.ScreenElementsComposite
{
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
        
        /// <summary>
        /// Initiate empty.
        /// </summary>
        protected ScreenGroup()
        {
            Elements = new List<ScreenElement>();
        }
        /// <summary>
        /// Initiate from a list of elements.
        /// </summary>
        protected ScreenGroup(List<ScreenElement> elements)
        {
            Elements = elements;
        }

        protected List<ScreenElement> Elements
        {
            get { return _elements; }
            set { _elements = value; }
        }

        public void Add(ScreenElement element)
        {
            _elements.Add(element);
        }
        /// <summary>
        /// Display the elements in the group on the screen.
        /// </summary>
        public abstract void Print();
    }
}
