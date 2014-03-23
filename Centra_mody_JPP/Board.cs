﻿using System;
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
            policzKolkaWobuKolorach();
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
                movingObjList.Add(new MovingObject(myRandom.Next(700)));
            }
        }
        public MovingObject chooseObjectToEliminate()
        {
            int index = 0;
            for (int i = 0; i < movingObjList.Count - 1; i++)
            {
                if (movingObjList[i].lifetime < movingObjList[i + 1].lifetime)
                    index = i;
            }
            return movingObjList[index];
        }
        public void modifyListOfMovingObj(TimeSpan timeFromStart)
        {
             //DODAWANIE i USUWANIE
            MovingObject objToAdd = new MovingObject();
            if(myRandom.Next(0,800) % 2 == 0)
            {
                movingObjList.Add(new MovingObject());
            }
            else 
            {
                if(movingObjList.Count > 1)
                    movingObjList.Remove(chooseObjectToEliminate());
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
            int sum1 = 0;
            int sum2 = 0;
            foreach (MovingObject element in movingObjList)
            {
                if (element.color == centrumMody1.color)
                    sum1++;
                else
                    sum2++;
            }
            Console.SetCursorPosition(0,0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("CM1: " + sum1 + "\nCM2: " + sum2);
        }

    }
}
