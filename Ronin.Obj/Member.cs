namespace Ronin.Obj
{
    using Ronin.Obj.Interface;
    using System;
    using System.Collections.Generic;

    public partial class Member : IMember
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime Birth { get; set; }

        public Gender Gender { get; set; }

        public string FiscalCode { get; set; }

        public string BirthLocality { get; set; }

        public string Job { get; set; }

        public Address Address { get; set; }

        public string Mail { get; set; }

        public string Phone { get; set; }

        public DateTime? HealthCertificate { get; set; }

        public Status Status { get; set; }

        public List<Affiliation> Affiliations { get; set; }

        public Member() {
            
        }

        public Member(IMember m)
        {
            if (m != null)
            {
                Id = m.Id;
                Name = m.Name;
                LastName = m.LastName;
                Birth = m.Birth;
                Gender = m.Gender;
                FiscalCode = m.FiscalCode;
                Job = m.Job;
                //Address = m.Address;
                Mail = m.Mail;
                Phone = m.Phone;


                

            }
        }

        public Member(Member m)
        {           
            if (m != null)
            {
                Id = m.Id;
                Name = m.Name;
                LastName = m.LastName;
                Birth = m.Birth;
                Gender = m.Gender;
                FiscalCode = m.FiscalCode;
                Job = m.Job;
                //Address = m.Address;
                Mail = m.Mail;
                Phone = m.Phone;

                this.BirthLocality = m.BirthLocality;
                this.Address = m.Address;
                this.HealthCertificate = m.HealthCertificate;
                this.Status = m.Status;
                this.Affiliations = m.Affiliations;
            }
        }

    }
}
