using src.Interface;

namespace src.Core
{
    public class Merchandise : IMerchandise
    {
        public MerchandiseTypes MerchandiseType { get; private set; }
        public string Name { get; private set; }
        public int Amount { get; private set; }
        public decimal Price { get; private set; }
        public bool Import { get; private set; }

        public Merchandise(MerchandiseTypes merchandiseType, string name, int amount, decimal price, bool import)
        {
            MerchandiseType = merchandiseType;
            Name = name;
            Amount = amount;
            Price = price;
            Import = import;
        }
        public Merchandise(string name, int amount, decimal price, bool import)
        {
            MerchandiseType = MerchandiseTypes.AllGoods;
            Name = name;
            Amount = amount;
            Price = price;
            Import = import;
        }

    }
}
