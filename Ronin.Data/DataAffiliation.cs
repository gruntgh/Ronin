using Ronin.Obj;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ronin.Data
{
    public class DataAffiliation : Affiliation
    {
        //public virtual ICollection<Member> Member { get; set; }
        public virtual List<MemberAffialiation> MemberAffialiation { get; set; }
    }
}
