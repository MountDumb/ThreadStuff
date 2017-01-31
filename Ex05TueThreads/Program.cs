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
            p.CountRunner();
            //p.FirstExRun();
                       

        }

        public void CountRunner()
        {
            CounterThreads ct = new CounterThreads();

            Thread posThread = new Thread(new ThreadStart(ct.RunPos));
            Thread negThread = new Thread(new ThreadStart(ct.RunNeg));

            posThread.Start();
            negThread.Start();
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
