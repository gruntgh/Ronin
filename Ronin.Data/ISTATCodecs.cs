using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ronin.Data
{
    [Table("ISTATCodecs")]
    public class ISTATCodecs
    {        
        public string Code { get; set; }
        public string Title { get; set; }
        public string Acronym { get; set; }
    }
}
