using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ex05TueThreads
{
    public class CounterThreads
    {
        private static int _counter = 0;
        private static bool _lastRanPostive = false;
        private static object _padLock = new object();

        public CounterThreads()
        {

        }

       public void RunPos()
        {
            while (true)
            {
                PositiveIncrement();
            }
        }

        public void RunNeg()
        {
            while (true)
            {
                NegativeIncrement();
            }
        }

        public void PositiveIncrement()
        {


            lock (_padLock)
            {
                if (_lastRanPostive == true)
                {
                    Monitor.Wait(_padLock);
                }
                _counter += 2;
                _lastRanPostive = true;
                Console.WriteLine(_counter);              
                Monitor.Pulse(_padLock);
                Thread.Sleep(1000);
            }


        }

        public void NegativeIncrement()
        {

            lock (_padLock)
            {
                if (_lastRanPostive == false)
                {
                    Monitor.Wait(_padLock);
                }
                _counter -= 1;
                _lastRanPostive = false;
                Console.WriteLine(_counter);
                Monitor.Pulse(_padLock);
                Thread.Sleep(1000);
            }


        }


    }
}
