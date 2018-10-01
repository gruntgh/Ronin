using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ronin.UWA.Services
{
    public struct ApiObjectsTuple
    {
        public Type ObjectType { get; set; }
        public Uri Uri { get; set; }
    }
}
