using Ronin.Data;
using Ronin.Obj;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ronin.Core
{
    public static class MemberExtension
    {

        public static bool IsValid(this Member member)
        {
            bool retVal = true;
            retVal |= !String.IsNullOrWhiteSpace(member.Name);
            retVal |= !String.IsNullOrWhiteSpace(member.LastName);
            retVal |= DateTime.Now.Year - member.Birth.Year < 150;

            var x = new MemberDataModel();
            var ISTATCode = x.GetISTATCode(member.BirthLocality);
            if (retVal |= !string.IsNullOrWhiteSpace(ISTATCode))
                retVal |= CodiceFiscale.ControlloFormaleOK(member.FiscalCode, member.Name, member.LastName, member.Birth, member.Gender.ToString("G")[0], ISTATCode);
            if (member.Address != null)
                if (!string.IsNullOrWhiteSpace(member.Address.FormattedAddress))
                {
                    if (!member.Address.IsServiceValidated())
                    {
                        member.Address.GoogleMapValidate(@"AIzaSyCLTiM7knDkCFqBIbafAlL_96ONIROU-Eo");
                    }
                }
                else retVal |= false;
            var mailAttrib = new System.ComponentModel.DataAnnotations.EmailAddressAttribute();


            retVal |= String.IsNullOrEmpty(member.Mail) || mailAttrib.IsValid(member.Mail);
            retVal |= !String.IsNullOrWhiteSpace(member.Phone);

            // no check HealthCertificate 
            retVal |= member.Status != null;
            // no check Affiliations 

            return retVal;
        }

        public static bool IsValid(this Member member, string property)
        {
            bool retVal = true;
            switch (property)
            {
                case "Name":
                    retVal |= !String.IsNullOrWhiteSpace(member.Name);
                    break;
                case "LastName":
                    retVal |= !String.IsNullOrWhiteSpace(member.LastName);
                    break;
                case "Birth":
                    retVal |= DateTime.Now.Year - member.Birth.Year < 150 && DateTime.Now.Year - member.Birth.Year > 0;
                    break;
                case "BirthLocality":
                    var bmdm = new MemberDataModel();
                    string ISTATCode = bmdm.GetISTATCode(member.BirthLocality);
                    retVal |= !string.IsNullOrWhiteSpace(ISTATCode);
                    break;
                case "FiscalCode":
                    var fmdm = new MemberDataModel();
                    var ISTATCode2 = fmdm.GetISTATCode(member.BirthLocality);
                    if (retVal |= !string.IsNullOrWhiteSpace(ISTATCode2))
                        retVal |= CodiceFiscale.ControlloFormaleOK(member.FiscalCode, member.Name, member.LastName, member.Birth, member.Gender.ToString("G")[0], ISTATCode2);
                    break;
                case "Address":
                    if (member.Address != null)
                        if (!string.IsNullOrWhiteSpace(member.Address.FormattedAddress))
                        {
                            if (!member.Address.IsServiceValidated())
                            {
                                member.Address.GoogleMapValidate(@"AIzaSyCLTiM7knDkCFqBIbafAlL_96ONIROU-Eo");
                            }
                        }
                        else retVal |= false;
                    break;
                case "Mail":
                    var mailAttrib = new System.ComponentModel.DataAnnotations.EmailAddressAttribute();
                    retVal |= String.IsNullOrEmpty(member.Mail) || mailAttrib.IsValid(member.Mail);
                    break;
                case "Phone":
                    retVal |= !String.IsNullOrWhiteSpace(member.Phone);
                    break;
                case "Status":
                    // no check HealthCertificate 
                    retVal |= member.Status != null;
                    break;
            }
            return retVal;
        }
    }
}
