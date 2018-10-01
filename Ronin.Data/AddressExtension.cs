using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Ronin.Obj;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ronin.Data
{
    public static class AddressExtension
    {
        public static bool IsServiceValidated(this Address address)
        {
            if (address != null)
                if (address.JSONGoogle != null)
                    //     return address.JSONGoogle.HasValues; 
                    try
                    {
                        return JObject.Parse(address.JSONGoogle.ToString()).HasValues;
                    }
                    catch (Exception ex) {
                    }
            return false;
        }

        private static async Task test(this Address address, string key)
        {
            string url = @"https://maps.googleapis.com/maps/api/geocode/json?address=" + address.FormattedAddress.Replace(' ', '+') + @"&key=" + key;
            WebClient wc = new WebClient();
            using (Stream s = wc.OpenRead(new Uri(url)))
            {

                using (StreamReader sr = new StreamReader(s))
                {
                    sr.ReadToEnd();
                }
            }

        }

        public static void GoogleMapValidate(this Address address, string key)
        {
            if (address != null)

                if (address.FormattedAddress != null)
                {


                    string url = @"https://maps.googleapis.com/maps/api/geocode/json?address=" + address.FormattedAddress.Replace(' ', '+') + @"&key=" + key;
                    //WebRequest request = WebRequest.Create(url);
                    //WebResponse response = request.GetResponse();
                    //Stream data = response.GetResponseStream();
                    //StreamReader reader = new StreamReader(data);
                    //// json-formatted string from maps api
                    string responseFromServer;


                    WebClient wc = new WebClient();
                    using (Stream s = wc.OpenRead(new Uri(url)))
                    {

                        using (StreamReader sr = new StreamReader(s))
                        {
                            responseFromServer = sr.ReadToEnd();
                        }
                    }
                    try
                    {
                        JObject googleResult = JObject.Parse(responseFromServer);
                        if (googleResult["results"] != null)
                        {
                            var results = new JArray(googleResult["results"]);
                            if (results.Count == 1)
                            {
                                address.JSONGoogle = googleResult["results"][0];
                                address.IsValidated = true;
                            }
                            else
                                address.JSONGoogle = JObject.Parse(responseFromServer);
                        }
                        //address.JSONGoogle = JObject.Parse(responseFromServer);
                    }
                    catch (JsonReaderException ex)
                    {

                    }
                }
        }
    }
}
