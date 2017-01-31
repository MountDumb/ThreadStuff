using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ex05TueThreads
{

    
    public class Symbolism
    {
        private enum _symbolType { Asterisk, Hash }
        private static int _totalSymbolCount = new int();
        private static object _lockpad = new object();
        //private static string _output = "";
        private static _symbolType _availableSymbols = _symbolType.Asterisk;
        

        public Symbolism()
        {
            
        }

        public void DoAsterisk()
        {
            while (true)
            {
                Asterisker();
                Thread.Sleep(1000);
            }
        }

        public void Dohash()
        {
            while (true)
            {
                Hasher();
                Thread.Sleep(1000);
            }
        }
        public void Asterisker()
        {
          
            lock (_lockpad)
            {

            string _output = "";

            if (_availableSymbols != _symbolType.Asterisk)
            {
                Monitor.Wait(_lockpad);
            }

            for (int i = 0; i < 60; i++)
            {
                _output = _output + "*";
                _totalSymbolCount++;
            }

            _output = _output + " " + _totalSymbolCount;
            _availableSymbols = _symbolType.Hash;
            Console.WriteLine(_output);
            Monitor.Pulse(_lockpad);
          //Thread.Sleep(1000);



            }

        }

        public void Hasher()
        {
           
            lock (_lockpad)
            {
            string _output = "";
            if (_availableSymbols != _symbolType.Hash)
                {
                    Monitor.Wait(_lockpad);
                }

            for (int i = 0; i < 60; i++)
            {
                _output = _output + "#";
                _totalSymbolCount++;
            }

            _output = _output + " " + _totalSymbolCount;
            _availableSymbols = _symbolType.Asterisk;
            Console.WriteLine(_output);
            Monitor.Pulse(_lockpad);
          //Thread.Sleep(1000);
            }
        }
    }
}
