using System.Collections.Generic;

namespace src.Interface
{
    public interface IPurchaseTaxes
    {
        List<ITax> CurrentTaxes { get; }
    }
}
