using System.Collections.Generic;
using src.Interface;

namespace src.Core
{
    public class Exemptions : IExemptions
    {
        readonly List<MerchandiseTypes> _exemptions;
        public virtual List<MerchandiseTypes> GetExemptions()
        {
            return _exemptions;
        }

        public Exemptions()
        {
            _exemptions = new List<MerchandiseTypes>()
            {
                MerchandiseTypes.Books,
                MerchandiseTypes.Food,
                MerchandiseTypes.MedicalProducts,
            };
        }
    }

}
