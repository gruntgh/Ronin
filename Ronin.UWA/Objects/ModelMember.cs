using Ronin.Obj;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ronin.UWA.Objects
{
    public class ModelMember : Member, IDataErrorInfo
    {       
        public new string Phone { get { return base.Phone; }set { base.Phone = value; } }
        public string this[string columnName] {
            get {
                string result = null;
                bool retVal = true;
                switch (columnName)
                {
                    case "Name":
                        retVal |= !String.IsNullOrWhiteSpace(Name);
                        break;
                    case "LastName":
                        retVal |= !String.IsNullOrWhiteSpace(LastName);
                        break;
                    case "Birth":
                        retVal |= DateTime.Now.Year - Birth.Year < 150 && DateTime.Now.Year - Birth.Year > 0;
                        break;
                    case "BirthLocality":
                        //var bmdm = new MemberDataModel();
                        //var ISTATCode = bmdm.GetISTATCode(BirthLocality);
                        //retVal |= !string.IsNullOrWhiteSpace(ISTATCode);
                        break;
                    case "FiscalCode":
                        //var fmdm = new MemberDataModel();
                        //var ISTATCode2 = fmdm.GetISTATCode(BirthLocality);
                        //if (retVal |= !string.IsNullOrWhiteSpace(ISTATCode2))
                        //    retVal |= CodiceFiscale.ControlloFormaleOK(FiscalCode, Name, LastName, Birth, Gender.ToString("G")[0], ISTATCode);
                        break;
                    case "Address":
                        //if (Address != null)
                        //    if (!string.IsNullOrWhiteSpace(Address.FormattedAddress))
                        //    {
                        //        if (!Address.IsServiceValidated())
                        //        {
                        //            Address.GoogleMapValidate(@"AIzaSyCLTiM7knDkCFqBIbafAlL_96ONIROU-Eo");
                        //        }
                        //    }
                        //    else retVal |= false;
                        break;
                    case "Mail":
                        var mailAttrib = new System.ComponentModel.DataAnnotations.EmailAddressAttribute();
                        retVal |= String.IsNullOrEmpty(Mail) || mailAttrib.IsValid(Mail);
                        break;
                    case "Phone":
                        retVal |= !String.IsNullOrWhiteSpace(Phone);
                        result = "Age must not be less than 0 or greater than 150.";
                        break;
                    case "Status":
                        // no check HealthCertificate 
                        retVal |= Status != null;
                        break;
                }

                return result;
            }
        }

        public string Error
        {
            get
            {
                return null;
            }
        }
}
}
