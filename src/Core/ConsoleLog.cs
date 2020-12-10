using System;

namespace src.Core
{
    internal static class ConsoleLog
    {
        internal static void WriteError( string message )
        {
            var saved = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = saved;
        }
        
        internal static void WriteWarning( string message )
        {
            var saved = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ForegroundColor = saved;
        }
    }
}
