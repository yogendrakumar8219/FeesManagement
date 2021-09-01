using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeesManagement.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Genders
    {
        Male,
        Female,
        Other
    }
 }
