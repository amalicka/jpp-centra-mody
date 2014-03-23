﻿using System;
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
        public Array arrayOfColors = Enum.GetValues(typeof(ConsoleColor));
        private Random myRandomWidth = new Random(100);
        private Random myRandomHeight = new Random(5000);
        public Random myRandom = new Random();

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

        public MovingObject generateObj()
        {
            ConsoleColor rndmColor = new ConsoleColor();
            rndmColor = (ConsoleColor)this.arrayOfColors.GetValue(myRandom.Next(this.arrayOfColors.Length));
            return new MovingObject(new Point(Console.WindowWidth/2, Console.WindowHeight / 2), rndmColor);
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
            int direction = (int)myRandom.Next(0, 800)%4;
            //0-up, 1-right, 2-down, 3-left
            switch(direction)
            {
                case 0:
                    if(!(localisation.y-2 <0))
                        localisation.y -= 1;
                    break;
                case 1:
                    if (!(localisation.x + 3 > Console.WindowWidth))
                        localisation.x += 2;
                    break;
                case 2:
                    if (!(localisation.y + 2 > Console.WindowHeight))
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
