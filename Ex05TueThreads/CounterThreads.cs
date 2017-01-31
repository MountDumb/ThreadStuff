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
        private bool _lastRanPostive = false;
        //private static object _padLock = new object();

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


            lock (this)
            {
                if (_lastRanPostive == true)
                {
                    Monitor.Wait(this);
                }
                _counter += 2;
                Console.WriteLine(_counter);
                Thread.Sleep(1000);
                _lastRanPostive = true;
                Monitor.Pulse(this);
                

            }


        }

        public void NegativeIncrement()
        {

            lock (this)
            {
                if (_lastRanPostive == false)
                {
                    Monitor.Wait(this);
                }
                _counter -= 1;
                Console.WriteLine(_counter);

                _lastRanPostive = false;
                Monitor.Pulse(this);
            }


        }


    }
}
