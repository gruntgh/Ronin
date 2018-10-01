using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ronin.Obj.Interface
{
    public interface IMember
    {
        int Id {
            get;
            set; }

        string Name { get; set; }

        string LastName { get; set; }

        DateTime Birth { get; set; }

        Gender Gender { get; set; }

        string FiscalCode { get; set; }

        string BirthLocality { get; set; }

        string Job { get; set; }

        //IAddress Address { get; set; }

        string Mail { get; set; }

        string Phone { get; set; }
    }
}
