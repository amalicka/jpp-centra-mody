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

        public ConsoleColor changeColor(int val1, int val2)
        {
            ConsoleColor rndmColor = new ConsoleColor();
            //rndmColor = (ConsoleColor)this.arrayOfColors.GetValue(myRandom.Next(0,this.arrayOfColors.Length));
            rndmColor = (ConsoleColor)this.arrayOfColors.GetValue(myRandom.Next(val1, val2));
            color = rndmColor;
            return color;
        }

        public double calculateDistance(Point p)
        {
            double distance;
            distance = Math.Sqrt(Math.Pow(Math.Abs(p.x - localisation.x), 2) + Math.Pow(Math.Abs(p.y - localisation.y), 2));
            return distance;
        }
        public void move(int p)
        {
            Random myRandom = new Random(p);
            int direction = (int)myRandom.Next(4);
            //0-up, 1-right, 2-down, 3-left
            switch (direction)
            {
                case 0:
                    if (!(localisation.y - 2 < 0))
                        localisation.y -= 1;
                    break;
                case 1:
                    if (!(localisation.x + 3 > Console.WindowWidth))
                        localisation.x += 2;
                    break;
                case 2:
                    if (!(localisation.y + 3 > Console.WindowHeight))
                        localisation.y += 1;
                    break;
                case 3:
                    if (!(localisation.x - 3 < 0))
                        localisation.x -= 2;
                    break;
                default:
                    break;
            }
        }
    }
}
