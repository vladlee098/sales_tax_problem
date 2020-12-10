using System;
using src.Interface;

namespace src.Core
{
    public class ImportTax : ITax
    {
        public virtual decimal Estimate(IMerchandise merchandise)
        {
            if ( !merchandise.Import)
            {
                return 0M;
            }
            
            return Math.Round( merchandise.Price / 20M, 1, MidpointRounding.AwayFromZero);
        }
    }
}
