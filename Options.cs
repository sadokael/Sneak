using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sneak
{
    public enum Directions
    {
        Left,
        Rigth,
        Up,
        Down
    };

    class Options
    {
        public static int Width {get;set;}
        public static int Height {get;set;}
        public static int Speed {get;set;}
        public static int Score {get;set;}
        public static int Points {get;set;}
        public static bool Gameover {get;set;}
        public static Directions direction {get;set;}

        public Options()
        {
            Width = 16;
            Height = 16;
            Speed = 7;
            Score = 0;
            Points = 100;
            Gameover = false;
            direction = Directions.Down;
        }
    }
}
