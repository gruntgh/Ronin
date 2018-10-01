using Ronin.Obj;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ronin.Data
{
    public class MemberAffialiation
    {
        public int MemberId { get; set; }
        Member _member;
        public Member Member
        {
            get { return _member; }
            set
            {
                _member = value; if (value != null && _affiliation != null)
                {
                    int removedCount = _member.Affiliations.RemoveAll(a => a.Id == AffiliationId);
                    Member.Affiliations.Add(_affiliation);
                }
            }
        }

        public int AffiliationId { get; set; }
        //public Affiliation Affiliation { get; set; }
        public Affiliation Affiliation
        {
            get
            {
                if (Member != null)
                {
                    if (Member.Affiliations != null)
                        return Member.Affiliations.Find(a => a.Id == AffiliationId);
                }
                return _affiliation;
            }
            set
            {
                _affiliation = value;
                if (Member != null)
                {
                    int removedCount = Member.Affiliations.RemoveAll(a => a.Id == AffiliationId);
                    Member.Affiliations.Add(value);
                }
            }
        }
        Affiliation _affiliation;
    }
}
