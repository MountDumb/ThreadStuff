using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ex05TueThreads
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Symbolicist();
            //p.CountRunner();
            //p.FirstExRun();
                       

        }

        public void Symbolicist()
        {
            Symbolism symbols = new Symbolism();

            Thread astThread = new Thread(new ThreadStart(symbols.DoAsterisk));
            Thread Hashthread = new Thread(new ThreadStart(symbols.Dohash));

            astThread.Start();
            Hashthread.Start();

            Console.ReadKey();

            Console.WriteLine("Aborting...");

            astThread.Abort();
            Hashthread.Abort();

            Console.ReadKey();

        }

        public void CountRunner()
        {
            CounterThreads ct = new CounterThreads();

            Thread posThread = new Thread(new ThreadStart(ct.RunPos));
            Thread negThread = new Thread(new ThreadStart(ct.RunNeg));

            posThread.Start();
            negThread.Start();

            Console.ReadKey();

            Console.WriteLine("Aborting...");

            posThread.Abort();
            negThread.Abort();

            Console.ReadKey();
        }

        public void FirstExRun()
        {
            Thread easeThread = new Thread(new ThreadStart(MyThreads.EaseThread));
            Thread alsoThread = new Thread(new ThreadStart(MyThreads.AlsoThread));
            Thread tempThread = new Thread(new ThreadStart(MyThreads.TempThread));

            easeThread.Start();
            alsoThread.Start();
            tempThread.Start();
                    

            while (true)
            {
                if (!tempThread.IsAlive)
                {
                    Console.WriteLine("Three strikes! Press any key to exit");
                    easeThread.Join();
                    alsoThread.Join();
                    //tempThread.Join();

                    Console.ReadKey();
                    Environment.Exit(0);

                }
                else
                {
                    Thread.Sleep(10000);
                }

            }
        }
    }
}
