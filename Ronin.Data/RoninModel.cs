namespace Ronin.Data
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Ronin.Obj;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore.Diagnostics;

    partial class RoninModel : DbContext
    {
        public RoninModel() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Ronin;Trusted_Connection=True;MultipleActiveResultSets=true;").ConfigureWarnings(warnings => warnings.Throw(CoreEventId.IncludeIgnoredWarning));


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<JSONAddress>().HasBaseType((Type)null);
            //modelBuilder.Entity<AddressDb>().Property<string>("Discriminator");
            //modelBuilder.Entity<Address>().Property<string>("Discri");
            //modelBuilder.Entity<Address>().HasDiscriminator<string>("Discri");

            modelBuilder.Entity<JSONAddress>().ToTable("Address").HasKey("AddressID");
            // modelBuilder.Entity<AddressDb>().HasKey("AddressID");
            modelBuilder.Entity<JSONAddress>()
                .Ignore(x => x.FormattedAddress)
                .Ignore(x => x.Locality)
                .Ignore(x => x.PostalCode)
                .Ignore(x => x.Route)
                .Ignore(x => x.JSONGoogle)
                .Ignore(x => x.AdministrativeArea)
                .Ignore(x => x.JSONGoogle);
            //.Ignore(x => x.JSONAddress)
            //.HasColumnName("Data");
            // modelBuilder.Entity<Address>().
            modelBuilder.Entity<JSONAddress>().Property(x => x.Data).HasColumnName("Data");

            modelBuilder.Entity<DataMember>().HasBaseType((Type)null);
            modelBuilder.Entity<DataMember>().ToTable("Member").HasKey(x => x.Id).HasName("Id");
            modelBuilder.Entity<DataMember>().Ignore(x=>x.Affiliations);

            modelBuilder.Entity<DataStatus>().HasBaseType((Type)null);
            modelBuilder.Entity<DataStatus>().ToTable("MemberStatus").HasKey(x => x.Id).HasName("Id");
            modelBuilder.Entity<DataStatus>().Property("Name").HasColumnName("Title");

            modelBuilder.Entity<DataMember>().HasOne<JSONAddress>(x => (JSONAddress)x.Address);//.WithMany("Members").HasForeignKey("AddressID");
            modelBuilder.Entity<DataMember>().HasOne<DataStatus>(x => (DataStatus)x.Status);

            //modelBuilder.Entity<DataMember>().HasMany<MemberAffialiation>(x => x.MemberAffiliations);

            modelBuilder.Entity<MemberAffialiation>().ToTable("MemberAffiliation").HasKey(x => new { x.AffiliationId, x.MemberId });
            //modelBuilder.Entity<MemberAffialiation>().HasMany<DataMember>()

            modelBuilder.Entity<DataAffiliation>().HasBaseType((Type)null);
            modelBuilder.Entity<DataAffiliation>().ToTable("Affiliation").HasKey(x => x.Id).HasName("Id");

            modelBuilder.Entity<MemberAffialiation>().HasOne(ma => (DataMember)ma.Member).WithMany(m => m.MemberAffialiation).HasForeignKey(ma => ma.MemberId);
            modelBuilder.Entity<MemberAffialiation>().HasOne(ma => (DataAffiliation)ma.Affiliation).WithMany(m => m.MemberAffialiation).HasForeignKey(ma => ma.AffiliationId);

            //modelBuilder.Entity<Status>().Property("Id");
            //modelBuilder.Entity<Status>().ToTable("MemberStatus").HasKey(x => x.Id).HasName("Id");

            modelBuilder.Entity<ISTATCodecs>().HasKey(x => x.Code);
                    }

        public DbSet<DataMember> Member { get; set; }
        public DbSet<JSONAddress> Address { get; set; }
        public DbSet<DataStatus> Status { get; set; }
        public DbSet<DataAffiliation> Affiliation { get; set; }

        public DbSet<MemberAffialiation> MemberAffialiation { get; set; }
               
        public DbSet<ISTATCodecs> ISTATCodecs { get; set; }
    }
}
