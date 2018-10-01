namespace Ronin.Data
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public partial class RoninModel : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Ronin;Trusted_Connection=True;");
        }
        public  DbSet<MemberEF> Member { get; set; }

       
    }
}
