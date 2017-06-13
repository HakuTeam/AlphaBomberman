namespace AlphaBomberman.Models
{
    using System;
    using System.Timers;

    public class Bomb
    {
        public int Power;
        public static int Range()
        {
            var range = 3;
            return range;
        }
        public Player Owner;
        public static Timer Timer()
        {
            var timer = new Timer(4000);
            return timer;
        }
        //Not quite sure whether to put it with the mobs or the player so I decided both 
    }
}
