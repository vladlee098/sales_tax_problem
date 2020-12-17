using System.Collections.Generic;
using src.Interface;

namespace src.Core
{
    public class PurchaseTaxes : IPurchaseTaxes
    {
        List<ITax> _availableTaxes;

        public PurchaseTaxes()
        {
            // set default taxes
            _availableTaxes = new List<ITax>
            {
                new SalesTax( new Exemptions() ),
                new ImportTax()
            };
        }

        public PurchaseTaxes( List<ITax> availableTaxes)
        {
            _availableTaxes = availableTaxes;
        }
        
        public List<ITax> CurrentTaxes 
        {
            get 
            { 
                return _availableTaxes; 
            }
        }
    }
}
