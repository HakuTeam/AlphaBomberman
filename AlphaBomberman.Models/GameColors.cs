namespace AlphaBomberman.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class GameColors
    {
        //Default
        public const ConsoleColor DefaultForeground = ConsoleColor.White;

        public const ConsoleColor DefaultBackground = ConsoleColor.Black;

        //Players
        public const ConsoleColor PlayerOne = ConsoleColor.Cyan;

        public const ConsoleColor PlayerTwo = ConsoleColor.Magenta;

        //Bomb
        public const ConsoleColor BombForeground = ConsoleColor.Yellow;

        public const ConsoleColor BombBackground = ConsoleColor.Red;

        // Menus
        public const ConsoleColor MenuSelectedForeground = ConsoleColor.Black;
        
        public const ConsoleColor MenuSelectedBackground = ConsoleColor.Yellow;

        public const ConsoleColor MenuFrame = ConsoleColor.Green;

        //walls
        public const ConsoleColor IndestructibleWall = ConsoleColor.DarkYellow;
        public const ConsoleColor DestructibleWall = ConsoleColor.DarkRed;
    }
}
