using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Centra_mody_JPP
{
    class Program
    {
        static void Main(string[] args)
        {
            #region variables
            Board myBoard = new Board();
            bool czyZmienicKolorCentrumMody1 = false;
            bool czyZmienicKolorCentrumMody2 = false;
            Random myRandom = new Random();
            System.Diagnostics.Stopwatch swMain = System.Diagnostics.Stopwatch.StartNew();
            swMain.Start();
            System.Diagnostics.Stopwatch swMovingObjects = System.Diagnostics.Stopwatch.StartNew();
            System.Diagnostics.Stopwatch swCentrumMody1 = System.Diagnostics.Stopwatch.StartNew();
            System.Diagnostics.Stopwatch swCentrumMody2 = System.Diagnostics.Stopwatch.StartNew();
            #endregion
            do
            {
                swMovingObjects.Start();
                if (czyZmienicKolorCentrumMody1)
                {
                    swCentrumMody1.Start();
                    czyZmienicKolorCentrumMody1 = false;
                }
                if (czyZmienicKolorCentrumMody2)
                {
                    swCentrumMody2.Start();
                    czyZmienicKolorCentrumMody2 = false;
                }

                if (swCentrumMody1.Elapsed.TotalSeconds > myRandom.Next(20) /*&& swCentrumMody1.Elapsed.TotalSeconds % 2 == 0*/)
                {
                    ConsoleColor oldColor = myBoard.centrumMody1.color;
                    ConsoleColor newColor = myBoard.centrumMody1.changeColor(1,4);
                    myBoard.changeObjectColors(oldColor, newColor);
                    swCentrumMody1.Reset();
                    czyZmienicKolorCentrumMody1 = true;
                }

                if (swCentrumMody2.Elapsed.TotalSeconds > myRandom.Next(20) /*&& swCentrumMody2.Elapsed.TotalSeconds % 2 == 0*/)
                {
                    ConsoleColor oldColor = myBoard.centrumMody2.color;
                    ConsoleColor newColor = myBoard.centrumMody2.changeColor(5, 9);
                    myBoard.changeObjectColors(oldColor, newColor);
                    swCentrumMody2.Reset();
                    czyZmienicKolorCentrumMody2 = true;
                }

                if (swMovingObjects.Elapsed.TotalMilliseconds > 700) //co ile modyfikujemy liste obiektow
                {
                    myBoard.modifyListOfMovingObj(swMain.Elapsed);
                    swMovingObjects.Reset();
                }

                // Render scene
                Console.Clear();
                myBoard.narysuj();
                myBoard.policzKolkaWobuKolorach();

                // Sleep
                Thread.Sleep(200);
            } while (true);
        }
    }
}
