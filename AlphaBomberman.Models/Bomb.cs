namespace AlphaBomberman.Models
{
    using System;
    using System.Timers;

    public class Bomb
    {
        public int Power;
        public int Range;
        public Player Owner;
        public Timer Timer;
        //Not quite sure whether to put it with the mobs or the player so I decided both 
    }
}
