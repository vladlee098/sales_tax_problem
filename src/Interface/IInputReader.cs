using System.Collections.Generic;

namespace src.Interface
{
    public interface IInputReader
    {
        List<ILineParser> GetParsers();
    }
}
