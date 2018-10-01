using System;
using System.Collections.Generic;
using System.Text;

namespace Ronin.Obj
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }        
    }
}
