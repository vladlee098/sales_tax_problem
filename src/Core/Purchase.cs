using System.Collections.Generic;
using src.Interface;

namespace src.Core
{
    public class Purchase : IPurchase
    {
        readonly List<IMerchandise> _goods;

        public virtual List<IMerchandise> GetGoods()
        {
            return _goods;
        }

        public Purchase()
        {
            _goods = new List<IMerchandise>();
        }

        public Purchase( List<IMerchandise> goods)
        {
            _goods = goods;
        }

        public virtual void Add(IMerchandise merchandise)
        {
            _goods.Add(merchandise);
        }

    }
}
