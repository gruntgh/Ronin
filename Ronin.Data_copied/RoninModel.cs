namespace Ronin.Data
{
    using Ronin.Obj;
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RoninModel : DbContext
    {
        public RoninModel()
            : base("name=RoninModelConnection")
        {
        }

        public virtual DbSet<MemberEF> MemberD { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
