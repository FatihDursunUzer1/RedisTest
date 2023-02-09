using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RedisTest.API.Models
{
    public class Preferences
    {
        public string Theme{get;set;}
        public bool Beta {get;set;}
        public override string ToString()
        {
            return $" {{\"Theme\": \"{Theme}\", \n \"beta\": \"{Beta}\" }}";
        }
        public byte[] ToByte()
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(this));
        }

        public static Preferences ToPreferences(byte[] preferencesByteArray)
        {
            return JsonConvert.DeserializeObject<Preferences>(Encoding.UTF8.GetString(preferencesByteArray));
        }
    }
}