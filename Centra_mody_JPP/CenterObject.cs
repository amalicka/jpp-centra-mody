﻿using System;
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

        public void changeColor()
        {
            ConsoleColor rndmColor = new ConsoleColor();
            do
            {
                rndmColor = (ConsoleColor)this.arrayOfColors.GetValue(myRandom.Next(0,this.arrayOfColors.Length));
                color = rndmColor;
            } while (color == ConsoleColor.Black);
        }

        public double calculateDistance(Point p)
        {
            double distance;
            distance = Math.Sqrt(Math.Pow(Math.Abs(p.x - localisation.x), 2) + Math.Pow(Math.Abs(p.y - localisation.y), 2));
            return distance;
        }
    }
}
