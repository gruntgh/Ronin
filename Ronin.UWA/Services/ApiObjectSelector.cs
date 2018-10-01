using Ronin.Obj;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ronin.UWA.Services
{

    public static class ApiObjectSelector
    {
        private const string _baseUrl = "http://localhost:60409/api/";

        private static Dictionary<Type, Uri> _touples = new Dictionary<Type, Uri>() {
            { typeof(Member), new Uri(_baseUrl + "Member") }
        };

        public static ApiObjectsTuple? GetObjectProfile(Type t)
        {
            var ret = _touples.GetValueOrDefault(t);
            if (ret != null)
            {
                return new ApiObjectsTuple() { ObjectType = t, Uri = ret };
            }
            return null;
        }
    }
}
