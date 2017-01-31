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
        private bool _lockFlag = false;
        private static object _padLock = new object();

        public CounterThreads()
        {

        }

        public static int Counter
        {
         get
            {
                
               return _counter;
                
            }  
        }

        public void PositiveIncrement()
        {

            while (true)
            {
                lock (this)
                {
                    if (_lockFlag == true)
                    {
                        Monitor.Wait(this);
                    }
                    _counter += 2;
                    Console.WriteLine(_counter);
                    Thread.Sleep(1000);
                    _lockFlag = false;
                    Monitor.Pulse(this);
                    return;
                    
                }
            }

        }

        public void NegativeIncrement()
        {
            while (true)
            {
                lock (this)
                {
                    if (_lockFlag == true)
                    {
                        Monitor.Wait(this);
                    }
                    _counter -= 1;
                    Console.WriteLine(_counter);
                    
                    _lockFlag = true;
                    Monitor.Pulse(this);
                    

                }
                
            }
            
        }


    }
}
