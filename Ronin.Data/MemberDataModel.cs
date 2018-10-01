using Microsoft.EntityFrameworkCore;
using Ronin.Obj;
using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

namespace Ronin.Data
{
    public class MemberDataModel : IDataModel<Member, int>
    {
        RoninModel _model = new RoninModel();

        public void Delete(Member item)
        {
            throw new NotImplementedException();
        }

        public Member Get(int id)
        {
            //return _model.Member.Include(x => x.Address).FirstOrDefault(x => x.Id == id);
            //var pippo = _model.Affiliation.Include(x => x.MemberAffialiation);
            var retVal = _model.Member.Include(x => x.Address).Include(x => x.Status).Include(x => x.MemberAffialiation).ThenInclude(x => x.Affiliation).FirstOrDefault(x => x.Id == id);
            //var y = retVal.MemberAffialiation;
            return retVal;
        }

        public Member Get(int id, bool includeAddress)
        {
            if (includeAddress)
                return _model.Member.Include(x => x.Address).FirstOrDefault(x => x.Id == id);
            return _model.Member.Include(x => x.Address).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Member> Get()
        {
            //var aff = _model.Affiliation.FirstOrDefault();
            //var a = _model.MemberAffialiation.Include(x => x.Affiliation).FirstOrDefault();
            //// return _model.Member.Include(x => x.Address).Include(x => x.MemberAffialiation).Where(x => x.MemberAffialiation != null).ToList();
            //var retVal = _model.Member.Include(x => x.Address).Include(x => x.MemberAffialiation);//.ThenInclude(x => x.Affiliation).AsEnumerable();
            return _model.Member.OrderBy(x => x.LastName).Include(x => x.Address).Include(x => x.Status).Include(x => x.MemberAffialiation).ThenInclude(x => x.Affiliation).AsEnumerable();
            //return retVal;
        }

        public IEnumerable<Member> Get(bool includeAddress)
        {
            if (includeAddress)
                return _model.Member.OrderBy(x => x.LastName).Include(x => x.Address).AsEnumerable();
            return _model.Member.OrderBy(x => x.LastName).AsEnumerable();
        }

        public Member Update(Member item)
        {
            throw new NotImplementedException();
        }

        public void Add(Member item)
        {
            var ja = new JSONAddress(item.Address);
            var jaRes = _model.Address.Add(ja);
            //_model.SaveChanges();
            DataMember dMember = new DataMember(item) { Address = ja };
            _model.Status.Attach(dMember.Status as DataStatus);
            _model.Member.Add(dMember);
            //Gestire l'indirizzo. Ora si ha eccezione per AddressID null
            _model.SaveChanges();
        }

        public string GetISTATCode(string locality)
        {
            var retVal = _model.ISTATCodecs.FirstOrDefault(x => x.Title == locality);
            if (retVal == null)
                return "";
            return retVal.Code;
        }
    }
}
