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

            System.Diagnostics.Stopwatch swMovingObjects = System.Diagnostics.Stopwatch.StartNew();
            System.Diagnostics.Stopwatch swcentraMody = System.Diagnostics.Stopwatch.StartNew();
            do
            {
                swMovingObjects.Start();
                if (swMovingObjects.Elapsed.TotalMilliseconds > 300)
                {
                    Console.Clear();
                    //Console.WriteLine(sw.Elapsed);
                    //myBoard.wypiszLokalizacje();
                    myBoard.narysuj();
                    myBoard.modifyListOfMovingObj();
                    swMovingObjects.Reset();
                }
            } while (true);

            Console.ReadLine();
        }
    }
}
