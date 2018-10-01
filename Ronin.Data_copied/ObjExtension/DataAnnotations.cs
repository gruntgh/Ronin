namespace Ronin.Data
{
    using Ronin.Obj;
    using Ronin.Obj.Interface;
    using System.ComponentModel.DataAnnotations;
    using System;

    [MetadataTypeAttribute(typeof(MemberEFMetadata))]
    public class MemberEF : IMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birth { get; set; }
        public int Gender { get; set; }

        public static explicit operator Member(MemberEF mef)
        {
            return new Member();
        }

        public static implicit operator MemberEF(Member mef)
        {
            return new MemberEF() { Name = mef.Name, LastName= mef.LastName };
        }

    }


}