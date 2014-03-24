using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Centra_mody_JPP
{
    class MovingObject
    {
        #region variables
        
        public Point localisation { get; set; }
        public ConsoleColor color { get; set;}
        public System.Diagnostics.Stopwatch sw { get; set; }
        public TimeSpan lifetime {get; set;}
        public Array arrayOfColors = Enum.GetValues(typeof(ConsoleColor));
        public Random myRandom = new Random();
        #endregion

        public MovingObject()
        {
            localisation = new Point(Console.WindowWidth / 2, Console.WindowHeight / 2);
            do{
                color = (ConsoleColor)this.arrayOfColors.GetValue(myRandom.Next(this.arrayOfColors.Length));
            } while (color == ConsoleColor.Black);
            lifetime = new TimeSpan(0, 0, 0, 0, 800);
            sw = System.Diagnostics.Stopwatch.StartNew();
            sw.Start();
        }
        public MovingObject(int milisec)
        {
             localisation = new Point(myRandom.Next(Console.WindowWidth), myRandom.Next(Console.WindowHeight));
            do{
                color = (ConsoleColor)this.arrayOfColors.GetValue(myRandom.Next(this.arrayOfColors.Length));
            } while (color == ConsoleColor.Black);
            lifetime = new TimeSpan(0, 0, 0, 0, milisec);
            sw = System.Diagnostics.Stopwatch.StartNew();
            sw.Start();
        }
        public MovingObject(Point loc, ConsoleColor c, int milisec)
        {
            localisation = loc;
            color = c;
            lifetime = new TimeSpan(0,0,0,0, milisec);
            sw = System.Diagnostics.Stopwatch.StartNew();
            sw.Start();
        }

        public void wypiszWlogach()
        {
            System.Diagnostics.Debug.Write("life: " + lifetime + "x: " + localisation.x + " \ty: " + localisation.y + "\t\n" /*+ color*/);
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
            //int direction = (int)myRandom.Next(0, 800)%4;
            int direction = (int)myRandom.Next(4);
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
        public void actualiseLifeTime()
        {
            lifetime = sw.Elapsed;
        }

        public double probabilityOfDeath()
        {
            double probability = (1.0 / (double)this.lifetime.Seconds) * 100;

            if (probability > 95)
                return 95;
            else
                return probability;
            return 10;
        }
    }
}
