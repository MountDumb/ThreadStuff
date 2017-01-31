using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ex05TueThreads
{
    public class MyThreads
    {
        public static void EaseThread()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Threading in C# is easy!");
                Thread.Sleep(100);
            }
        }

     public static void AlsoThread()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Even with more multiple threads!");
                Thread.Sleep(100);

            }
        }

        public static void TempThread()
        {
            Random rand = new Random();
            int alarmCounter = 0;
            

            while (alarmCounter <= 2)
            {
                Thread.Sleep(2000);
                int temp = rand.Next(-20, 121);
                Console.WriteLine(temp);

                if (temp < 0 || temp > 100)
                {
                    Console.WriteLine("Temperature out of bounds");
                    alarmCounter++;
                }
                           
                
            }
        }
}
}
