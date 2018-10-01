using System;
using System.Collections.Generic;
using System.Text;

namespace Ronin.Obj
{
    public class Affiliation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }

        public override string ToString()
        {
            return Title;
        }
        //public virtual ICollection<Member> Member { get; set; }
    }
}
