using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centra_mody_JPP
{
    class Board
    {
        public List<MovingObject> movingObjList {get; set;}
        public CenterObject centrumMody1 { get; set; }
        public CenterObject centrumMody2 { get; set; }
        public Random myRandom = new Random();
        public TimeSpan timer { get; set; }
        //public Array arrayOfColors = Enum.GetValues(typeof(Color));
        public Array arrayOfColors = Enum.GetValues(typeof(ConsoleColor));

        public Board()
        {
            int tmpWidth = Console.WindowWidth / 6;
            movingObjList = new List<MovingObject>();
            centrumMody1 = new CenterObject(new Point(tmpWidth, Console.WindowHeight / 2), ConsoleColor.Red);
            centrumMody2 = new CenterObject(new Point(Console.WindowWidth - tmpWidth, Console.WindowHeight / 2), ConsoleColor.Yellow);
            timer = new TimeSpan();
            this.generateListOfMovingObj(10);
        }

        public void wypiszLokalizacje()
        {
            Console.WriteLine("Lokalizacja centrum mody 1:\t" + centrumMody1.localisation.x + "\t"+ centrumMody1.localisation.y );
            Console.WriteLine("Lokalizacja centrum mody 2:\t" + centrumMody2.localisation.x + "\t"+ centrumMody2.localisation.y );
            foreach (MovingObject ob in movingObjList)
                ob.wypisz();
        }

        public void wypiszLokalizacjeWlogach()
        {
            System.Diagnostics.Debug.Write("Lokalizacja centrum mody 1:\t" + centrumMody1.localisation.x + "\t" + centrumMody1.localisation.y +"\n");
            System.Diagnostics.Debug.Write("Lokalizacja centrum mody 2:\t" + centrumMody2.localisation.x + "\t" + centrumMody2.localisation.y +"\n");
            foreach (MovingObject ob in movingObjList)
                ob.wypiszWlogach();
        }

        public void narysuj()
        {
            Console.SetCursorPosition(centrumMody1.localisation.x, centrumMody1.localisation.y);
            Console.ForegroundColor = centrumMody1.color;
            Console.WriteLine("o");
            Console.SetCursorPosition(centrumMody2.localisation.x, centrumMody2.localisation.y);
            Console.ForegroundColor = centrumMody2.color;
            Console.WriteLine("oo");
            foreach (MovingObject element in movingObjList)
            {
                Console.SetCursorPosition(element.localisation.x, element.localisation.y);
                Console.ForegroundColor = element.color;
                Console.WriteLine("*");
            }
        }

        public MovingObject generateObj()
        {
            ConsoleColor rndmColor = new ConsoleColor();
            rndmColor = (ConsoleColor)this.arrayOfColors.GetValue(myRandom.Next(this.arrayOfColors.Length));
            return new MovingObject(new Point((int)myRandom.Next(0, Console.WindowWidth), (int)myRandom.Next(0,                                                   Console.WindowHeight)), rndmColor);
        }

        public void generateListOfMovingObj(int numberOfObjects)
        {
            for (int i = 0; i < numberOfObjects; i++)
                movingObjList.Add(this.generateObj());   
        }

        public void modifyListOfMovingObj()
        {
            int indexElToRemove = (int)myRandom.Next(0, movingObjList.Count);
            if (movingObjList.Count > 4)
            {
                if (myRandom.Next(0, DateTime.Now.Millisecond) % 2 == 0)
                    movingObjList.Remove(movingObjList.ElementAt(indexElToRemove));
                else
                    movingObjList.Add(this.generateObj());

                foreach(MovingObject element in movingObjList)
                {
                    element.move();
                    //zmiana koloru zalezna od odleglosci od centrum mody
                    if (element.calculateDistance(centrumMody1.localisation) >= element.calculateDistance(centrumMody2.localisation))
                        element.color = centrumMody2.color;
                    else
                        element.color = centrumMody1.color;
                }
            }
            wypiszLokalizacjeWlogach();
        }

        public void modifyCentrumMody1()
        {
            centrumMody1.changeColor();
        }
        public void modifyCentrumMody2()
        {
            centrumMody2.changeColor();
        }


    }
}
