using System;
using src.Interface;

namespace src.Core
{
    public class SalesTax : ITax
    {
        readonly IExemptions _exemptions;
        public SalesTax(IExemptions exemptions)
        {
            _exemptions = exemptions;
        }

        public virtual decimal Estimate(IMerchandise merchandise)
        {
            if (_exemptions.GetExemptions().Contains(merchandise.MerchandiseType))
            {
                return 0M;
            }
            return Math.Round( merchandise.Price / 10M, 2, MidpointRounding.AwayFromZero);
        }
    }
}
