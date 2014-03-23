using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Centra_mody_JPP
{
    class MovingObject
    {
        public Point localisation { get; set; }
        public ConsoleColor color { get; set;}
        public System.Diagnostics.Stopwatch sw { get; set; }

        public MovingObject()
        {
            localisation = new Point();
            color = ConsoleColor.Red;
            sw = System.Diagnostics.Stopwatch.StartNew();
        }
        public MovingObject(Point loc, ConsoleColor c)
        {
            localisation = loc;
            color = c;
            sw = System.Diagnostics.Stopwatch.StartNew();
        }

        public void wypisz()
        {
            Console.WriteLine("x: "+localisation.x + " y: " + localisation.y +"\t" + color);
        }

        public void wypiszWlogach()
        {
            System.Diagnostics.Debug.Write("x: " + localisation.x + " \ty: " + localisation.y + "\t\n" /*+ color*/);
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
            int direction = (int)myRandom.Next(0, 3);
            //0-up, 1-right, 2-down, 3-left
            switch(direction)
            {
                case 0:
                    if(!(localisation.y-2 <0))
                        localisation.y -= 1;
                    break;
                case 1:
                    if (!(localisation.x + 2 > Console.BufferWidth))
                        localisation.x += 1;
                    break;
                case 2:
                    if (!(localisation.y + 2 > Console.BufferHeight))
                        localisation.y += 1;
                    break;
                case 3:
                    if (!(localisation.x - 2 < 0))
                        localisation.x -= 1;
                    break;
                default:
                    break;
            }
        }


    }
}
