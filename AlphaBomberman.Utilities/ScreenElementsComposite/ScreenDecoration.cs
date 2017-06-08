namespace AlphaBomberman.Utilities.ScreenElementsComposite
{
    /// <summary>
    /// Just a bunch of elements that you want to show on screen at once.
    /// </summary>
    public class ScreenDecoration : ScreenGroup
    {
        public override void Print()
        {
            foreach (var element in Elements)
            {
                element.Print();
            }
        }
    }
}
