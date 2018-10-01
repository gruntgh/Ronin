using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Ronin.Obj;
using Ronin.Obj.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ronin.Data
{
    [Table("Address")]
    public class JSONAddress : Address
    {
        protected const string schemaJson = @"{
  'definitions': {},
  '$schema': 'http://json-schema.org/draft-06/schema#',
  '$id': 'http://example.com/example.json',
  'type': 'object',
  'properties': {
    'id': {
      '$id': '/properties/id',
      'type': 'integer',
      'title': 'The Id Schema.',
      'description': 'An explanation about the purpose of this instance.',
      'default': 0,
      'examples': [
        1
      ]
    },
    'JSONGoogle': {
      '$id': '/properties/JSONGoogle',
      'type': 'object',
      'properties': {
        '$id': 'eurasianbear',
        'title': 'Empty Object',
        'description': 'This accepts anything, as long as it's valid JSON.'
      }
    },
    'FormattedAddress': {
      '$id': '/properties/FormattedAddress',
      'type': 'string',
      'title': 'The Formattedaddress Schema.',
      'description': 'An explanation about the purpose of this instance.',
      'default': '',
      'examples': [
        'Viale Giovanni Pascoli, 22, 42046 Reggiolo RE, Italia'
      ]
    },
    'Route': {
      '$id': '/properties/Route',
      'type': 'string',
      'title': 'The Route Schema.',
      'description': 'An explanation about the purpose of this instance.',
      'default': '',
      'examples': [
        'Viale Giovanni Pascoli'
      ]
    },
    'PostalCode': {
      '$id': '/properties/PostalCode',
      'type': 'string',
      'title': 'The Postalcode Schema.',
      'description': 'An explanation about the purpose of this instance.',
      'default': '',
      'examples': [
        '42046'
      ]
    },
    'Locality': {
      '$id': '/properties/Locality',
      'type': 'string',
      'title': 'The Locality Schema.',
      'description': 'An explanation about the purpose of this instance.',
      'default': '',
      'examples': [
        'Reggilo'
      ]
    },
    'AdministrativeArea': {
      '$id': '/properties/AdministrativeArea',
      'type': 'string',
      'title': 'The Administrativearea Schema.',
      'description': 'An explanation about the purpose of this instance.',
      'default': '',
      'examples': [
        'RE'
      ]
    }
  }
}";

        //JsonSchema schema = JsonSchema.Parse(schemaJson);

        //public new JObject JSONGoogle
        //{
        //    get { return JObject.Parse(base.JSONGoogle); }
        //    set { base.JSONGoogle = value.ToString(); }
        //}

        internal string Data
        {
            get
            {
                //string retVal;
                //JsonSerializer serializer = new JsonSerializer();
                ////serializer.Converters.Add(new JavaScriptDateTimeConverter());                
                //serializer.NullValueHandling = NullValueHandling.Ignore;

                //JsonWriter writer = new JsonTextWriter()
                //    JsonConverter
                //serializer.Serialize(retVal, product);
                var settings = new JsonSerializerSettings { ContractResolver = new JSONAddressContractResolver() };
                var retVal = JsonConvert.SerializeObject((Address)this, Formatting.Indented, settings);
                return retVal;
            }

            set
            {
                //JObject pippo = (JObject)JsonConvert.DeserializeObject(value, new JsonSerializerSettings { ContractResolver = new JSONAddressContractResolver() });
                // this.JSONGoogle = pippo.SelectToken("JSONGoogle").ToString();
                var settings = new JsonSerializerSettings { ContractResolver = new JSONAddressContractResolver() };
                //settings.Converters.Add(new PlainJsonStringConverter());
                var t = JsonConvert.DeserializeObject<Address>(value, settings);
                JsonConvert.PopulateObject(value, this, settings);
            }
        }

        public JSONAddress()
        { }

        public JSONAddress(Address address)
        {
            //this.Data = JsonConvert.SerializeObject((Address)this, Formatting.Indented);
            base.AddressID = address.AddressID;
            base.AdministrativeArea = address.AdministrativeArea;
            base.FormattedAddress = address.FormattedAddress;
            base.IsValidated = address.IsValidated;
            base.JSONGoogle = address.JSONGoogle;
            base.Locality = address.Locality;
            base.PostalCode = address.PostalCode;
            base.Route = address.Route;
        }

        //public static implicit operator JSONAddress(Address v)
        //{
        //    return new JSONAddress() { Test = "{}" };
        //}
    }
}
