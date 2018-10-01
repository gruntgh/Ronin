using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ronin.Core;
using Ronin.Obj;

namespace UnitTestRoninCore
{
    [TestClass]
    public class MemberTest1
    {
        [TestMethod]
        public void Member_Add()
        {
            Members m = new Members();

            m.Add(new Member()
            {
                Name = "Test",
                LastName = "Surname",
                  Address = new Address() {  FormattedAddress = "via mantova 1 parma"}
            });
       
        }
    }
}
