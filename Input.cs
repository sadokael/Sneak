using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Windows.Forms;

namespace Sneak
{
    class Input
    {
        private static Hashtable keyTable = new Hashtable();
        //Hashtable class para lidar com os key press

        public static bool keyPress(Keys key)
        {
            if (keyTable[key] == null)
            { return false; } //retorna falso se a hashtable está empty
            return (bool)keyTable[key]; //retorna true se não está
        }

        public static void changeState(Keys key, bool state)
        {
            keyTable[key] = state;
        }
    }
}
