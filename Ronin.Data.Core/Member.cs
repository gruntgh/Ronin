namespace Ronin.Data
{
    using Ronin.Obj.Interface;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Ronin.Obj;

    [Table("Member")]
    public partial class MemberEF : IMember
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birth { get; set; }

        public int Gender { get; set; }

        public static implicit operator Member(MemberEF m)
        {
            return (Member)m;
        }
    }
}
