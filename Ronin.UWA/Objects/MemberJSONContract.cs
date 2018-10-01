using Ronin.Obj.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Ronin.Obj;

namespace Ronin.UWA.Objects
{
    [DataContract]
    internal class MemberJSONContract1 : IMember
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public DateTime Birth { get; set; }

        [DataMember]
        public Gender Gender { get; set; }
        public string FiscalCode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string BirthLocality { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Job { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IAddress Address { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Mail { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Phone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    }
}
