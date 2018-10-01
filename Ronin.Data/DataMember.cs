namespace Ronin.Data
{
    using Ronin.Obj.Interface;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Ronin.Obj;

    public partial class DataMember : Member
    {
        IEnumerable<MemberAffialiation> _affiliations;

        // public List<MemberAffialiation> MemberAffialiation { get; set; }
        //MemberAffialiation _memberAffiliation;
        public List<MemberAffialiation> MemberAffialiation
        {
            get
            {
                if (Affiliations != null)
                    return this.Affiliations.ConvertAll<MemberAffialiation>(x => new MemberAffialiation() { Affiliation = x, AffiliationId = x.Id, Member = this, MemberId = Id });
                return null;
            }
            set
            {
                this.Affiliations = value.ConvertAll<Affiliation>(x => x.Affiliation);
            }
        }

        public DataMember(Member b) : base(b)
        {
        
            Status = new DataStatus() { Id = Status.Id, Name = Status.Name };
        }
        public DataMember() : base()
        {

        }

        //public IEnumerable<MemberAffialiation> MemberAffialiation
        //{
        //    get { return _affiliations; }
        //    set
        //    {
        //        _affiliations = value;
        //        //base.Affiliations = _affiliations.ConvertAll<Affiliation>(x => x.Affiliation);
        //    }
        //}
        //public int AddressId { get; set; }
        //public int StatusId { get; set; }
        //public IEnumerable<MemberAffialiation> MemberAffiliations
        //{
        //    get { return _affiliations; }
        //    set { _affiliations = value; }
        //}

    }
}
