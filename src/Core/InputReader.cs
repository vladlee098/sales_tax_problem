using System;
using System.Collections.Generic;
using System.Linq;
using src.Interface;

namespace src.Core
{
    public class InputReader : IInputReader
    {

        readonly List<ILineParser> _parsers = new List<ILineParser>();

        public InputReader( List<string> backet )
        {
            foreach( var mecrh in backet )
            {
                _parsers.Add( new LineParser(mecrh) );
            }
        }

        public List<ILineParser> GetParsers()
        {
            return _parsers;
        }
    }
}
