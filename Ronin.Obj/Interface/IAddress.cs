using System;
using System.Collections.Generic;
using System.Text;

namespace Ronin.Obj.Interface
{
    public interface IAddress
    {
        string FormattedAddress { get; set; }

        string Route { get; set; }
        string PostalCode { get; set; }
        string Locality { get; set; }

    }
}
