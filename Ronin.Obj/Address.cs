using Newtonsoft.Json.Linq;
using Ronin.Obj.Interface;
using System;
using System.Collections.Generic;

using System.Text;

namespace Ronin.Obj
{
    public class Address : IAddress
    {
        public int AddressID { get; set; }

        public JToken JSONGoogle { get; set; }

        public string FormattedAddress { get; set; }

        public string Route { get; set; }

        public string PostalCode { get; set; }

        public string Locality { get; set; }

        public string AdministrativeArea { get; set; }

        public bool IsValidated { get; set; }

        //public string Discriminator { get; set; }

        //public bool Validated { get; protected set; }
    }
}
