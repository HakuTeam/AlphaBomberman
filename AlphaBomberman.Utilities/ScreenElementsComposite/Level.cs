namespace AlphaBomberman.Utilities.ScreenElementsComposite
{
    using Composer;

    public class Level : ScreenDecoration
    {
        public Level(int levelNumber, int width, int height)
        {
            Number = levelNumber;
            Width = width;
            Height = height;

            Elements.Add(Composer.GetBox(width,height,0,0));
        }

        public int Number { get; }

        public int Width { get; }

        public int Height { get; }
    }
}
