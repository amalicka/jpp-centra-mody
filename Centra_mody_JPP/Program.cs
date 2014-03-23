using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centra_mody_JPP
{
    class Program
    {
        static void Main(string[] args)
        {
            Board myBoard = new Board();
            bool czyZmienicKolorCentrumMody1 = false;
            bool czyZmienicKolorCentrumMody2 = false;
            Random myRandom1 = new Random();
            Random myRandom2 = new Random();

            System.Diagnostics.Stopwatch swMovingObjects = System.Diagnostics.Stopwatch.StartNew();
            System.Diagnostics.Stopwatch swCentrumMody1 = System.Diagnostics.Stopwatch.StartNew();
            System.Diagnostics.Stopwatch swCentrumMody2 = System.Diagnostics.Stopwatch.StartNew();
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

                if (swMovingObjects.Elapsed.TotalMilliseconds > 300)
                {
                    Console.Clear();
                    //Console.WriteLine(sw.Elapsed);
                    myBoard.narysuj();
                    myBoard.modifyListOfMovingObj();
                    swMovingObjects.Reset();
                }
                if (swCentrumMody1.Elapsed.TotalSeconds > myRandom1.Next(22,27))
                {
                    myBoard.centrumMody1.changeColor();
                    swCentrumMody1.Reset();
                    czyZmienicKolorCentrumMody1 = true;
                }
                if (swCentrumMody2.Elapsed.TotalSeconds > myRandom2.Next(67,615))
                {
                    myBoard.centrumMody2.changeColor();
                    swCentrumMody2.Reset();
                    czyZmienicKolorCentrumMody2 = true;
                }

            } while (true);
        }
    }
}
