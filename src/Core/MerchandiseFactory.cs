using System.Collections.Generic;
using src.Interface;

namespace src.Core
{
    public class MerchandiseFactory : IMerchandiseFactory
    {

        Dictionary< string, MerchandiseTypes> _warehouse = new Dictionary< string, MerchandiseTypes>()
        {
            { "book", MerchandiseTypes.Books},
            { "books", MerchandiseTypes.Books},
            { "music", MerchandiseTypes.AllGoods},
            { "music CD", MerchandiseTypes.AllGoods},
            { "chocolate", MerchandiseTypes.Food},
            { "chocolate bar", MerchandiseTypes.Food},
            { "box of chocolates", MerchandiseTypes.Food},
            { "bottle of perfume", MerchandiseTypes.AllGoods},
            { "packet of headache pills", MerchandiseTypes.MedicalProducts},
        };

        private MerchandiseTypes MerchandiseTypeByName( string name )
        {
            if ( _warehouse.ContainsKey(name) )
            {
                return _warehouse[name];
            }
            ConsoleLog.WriteWarning($" Merchandise '{name}' not found in warehouse, using 'AllGoods' type");
            return MerchandiseTypes.AllGoods;
        }

        public MerchandiseFactory()
        {
        }

        public virtual IPurchase BuildPurchase(IInputReader inputReader)
        {
            // "1 book at 12.49"
            // "1 imported bottle of perfume at 27.99 1"
            
            var merchandises = new List<IMerchandise>();
            var parsers = inputReader.GetParsers();
            foreach( ILineParser parser in parsers)
            {
                var mecrhType = MerchandiseTypeByName( parser.GetName() );
                var merchandise = new Merchandise(mecrhType, parser.GetFullName(), parser.GetAmount(), parser.GetPrice(), parser.IsImport() );
                merchandises.Add(merchandise);
            }
            
            return new Purchase(merchandises);
        }
    }
}
