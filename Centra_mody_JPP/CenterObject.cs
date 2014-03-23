using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centra_mody_JPP
{
    class CenterObject
    {
        public Point localisation { get; set; }
        public ConsoleColor color;
        Array arrayOfColors = Enum.GetValues(typeof(ConsoleColor));
        public Random myRandom = new Random();
        
        public CenterObject()
        {
            localisation = new Point();
            color = ConsoleColor.Red;
        }
        public CenterObject(Point loc, ConsoleColor c)
        {
            localisation = loc;
            color = c;
        }

        public void changeColor(int var)
        {
            ConsoleColor rndmColor = new ConsoleColor();
            rndmColor = (ConsoleColor)this.arrayOfColors.GetValue(myRandom.Next(this.arrayOfColors.Length/var));
            color = rndmColor;
        }
    }
}
