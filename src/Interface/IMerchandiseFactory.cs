using System.Collections.Generic;

namespace src.Interface
{
    public interface IMerchandiseFactory
    {
         IPurchase BuildPurchase(IInputReader inputReader);
    }
}
