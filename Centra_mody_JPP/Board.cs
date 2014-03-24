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

        public Board()
        {
            int tmpWidth = Console.WindowWidth / 6;
            movingObjList = new List<MovingObject>();
            centrumMody1 = new CenterObject(new Point(tmpWidth, Console.WindowHeight / 2), ConsoleColor.Red);
            centrumMody2 = new CenterObject(new Point(Console.WindowWidth - tmpWidth, Console.WindowHeight / 2), ConsoleColor.Yellow);
            timer = new TimeSpan();
            this.generateListOfMovingObj(100);
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
            Console.WriteLine((char)64);
            Console.SetCursorPosition(centrumMody2.localisation.x, centrumMody2.localisation.y);
            Console.ForegroundColor = centrumMody2.color;
            Console.WriteLine((char)64);
            foreach (MovingObject element in movingObjList)
            {
                Console.SetCursorPosition(element.localisation.x, element.localisation.y);
                Console.ForegroundColor = element.color;
                Console.WriteLine("o");
            }
        }
        public void generateListOfMovingObj(int numberOfObjects)
        {
            for (int i = 0; i < numberOfObjects; i++)
            {
                movingObjList.Add(new MovingObject(myRandom.Next()));
            }
        }

        public void changeObjectColors(ConsoleColor oldColor, ConsoleColor newColor)
        {
            foreach(MovingObject element in movingObjList)
            {
                if (element.color == oldColor)
                    element.color = newColor;
            }
        }
        public void modifyListOfMovingObj(TimeSpan timeFromStart)
        {
            int counter = 0;
             //DODAWANIE i USUWANIE MovingObjects
            for (int i = 0; i < movingObjList.Count; i++)
            {
                double czyZabic = (double)myRandom.Next(100);
                double probab = movingObjList[i].probabilityOfDeath();
                //System.Diagnostics.Debug.Write(movingObjList[i].probabilityOfDeath() + "\n");
                if (czyZabic < probab && movingObjList.Count > 1)
                {
                    movingObjList.Remove(movingObjList[i]);
                    counter++;
                }
            }

            for (int i = 0; i < counter; i++)
            {
                movingObjList.Add(new MovingObject());
            }
            
            foreach (MovingObject element in movingObjList)
            {
                element.move(myRandom.Next(0,500));
                element.actualiseLifeTime();
                //ZMIANA KOLORU
                double sumaOdlObiektuOdCentrowMody = element.calculateDistance(centrumMody1.localisation) + element.calculateDistance                                           (centrumMody2.localisation);
                double odlOdCM1 = element.calculateDistance(centrumMody1.localisation);
                double odlOdCM2 = element.calculateDistance(centrumMody2.localisation);
                double szansa = myRandom.Next(0, 100);
                //wyrownanie do 100
                odlOdCM1 = (odlOdCM1 * 100) / sumaOdlObiektuOdCentrowMody;
                odlOdCM2 = (odlOdCM2 * 100) / sumaOdlObiektuOdCentrowMody;
                //nadanie koloru w zal od odleglosci od Centrum Mody 1 lub 2
                if(szansa >= odlOdCM1)
                    element.color = centrumMody1.color;
                else
                    element.color = centrumMody2.color;
            }
            wypiszLokalizacjeWlogach();
        }
        public void policzKolkaWobuKolorach()
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
            int sum1 = 0;
            int sum2 = 0;
            foreach (MovingObject element in movingObjList)
            {
                if (element.color == centrumMody1.color)
                    sum1++;
                else if (element.color == centrumMody2.color)
                    sum2++;
            }
            Console.WriteLine("CM1: " + sum1);
            Console.WriteLine("CM2: " + sum2);
        }

    }
}
