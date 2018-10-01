//using Ronin.Data;
using Ronin.Data;
using Ronin.Obj;
using Ronin.Obj.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ronin.Core
{
    public class Members
    {
        protected List<Member> _members;
        protected bool _dirty = true;
        MemberDataModel _model = new MemberDataModel();

        public IEnumerable<Member> Items
        {
            get
            {
                return _model.Get();
            }
        }

        //protected void Load()
        //{

        //    //var pippo = rm.Address.ToList();

        //    _members = _model.Member.Include(x => x.Address).ToList();
        //}

        public bool Add(Member member)
        {           
            if (member.IsValid())
                _model.Add(member);
            else return false;
            _dirty = true;
            return true;
        }



        public Member getMember(int Id)
        {
            return _model.Get(Id);
        }
    }
}
