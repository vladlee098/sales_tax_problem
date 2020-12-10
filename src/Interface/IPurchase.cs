using System.Collections.Generic;

namespace src.Interface
{
    public interface IPurchase
    {
        List<IMerchandise> GetGoods();
        void Add(IMerchandise merchandise);
    }
}
