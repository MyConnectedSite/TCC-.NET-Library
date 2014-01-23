using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;

namespace TCC2.API
{
    public class AccessControlList<T> where T : AccessControlEntry
    {
        [JsonProperty(PropertyName = "acl")]
        public IEnumerable<T> Entries { get; set; }

        [JsonProperty(PropertyName = "ACLAnonymousAccess")]
        public bool AllowAnonymousAccess { get; set; }

        public IEnumerable<ApiParameter> ToInputParams()
        {
            var result = new List<ApiParameter>();
            result.Add(new ApiParameter("aclanonymousaccess", AllowAnonymousAccess.ToString().ToLower(CultureInfo.InvariantCulture)));

            if (Entries != null)
            {
                foreach (T ace in Entries)
                {
                    result.AddRange(ace.ToInputParams());
                }
            }

            return result;
        }
    }
}
