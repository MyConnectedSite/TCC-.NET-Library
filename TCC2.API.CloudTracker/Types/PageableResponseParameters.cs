using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TCC2.API.CloudTracker
{
    using ParamEntry = KeyValuePair<string, string>;

    public enum SortDirection
    {
        Asc,
        Desc
    }

    public class PageableResponseParameters
    {
        public int? Start { get; set; }
        public int? Limit { get; set; }
        public SortDirection? SortDirection { get; set; }
        public string Sort { get; set; }
        public string Query { get; set; }
        public IEnumerable<string> Fields { get; set; }

        public IEnumerable<ParamEntry> GetParameters()
        {
            string fields = null;
            if (Fields != null)
            {
                StringBuilder sb = new StringBuilder();
                foreach (string field in Fields)
                {
                    sb.Append(field).Append(',');
                }
                if (sb.Length > 0)
                    sb.Remove(sb.Length - 1, 1); // remove trailing comma

                fields = sb.ToString();
            }

            ParamEntry[] result =
                {
                    new ParamEntry("start", Start.HasValue ? Start.Value.ToString(CultureInfo.InvariantCulture) : null),
                    new ParamEntry("limit", Limit.HasValue ? Limit.Value.ToString(CultureInfo.InvariantCulture) : null),
                    new ParamEntry("dir", SortDirection.HasValue ? SortDirection.Value.ToString().ToLower(CultureInfo.InvariantCulture) : null),
                    new ParamEntry("sort", Sort),
                    new ParamEntry("query", Query),
                    new ParamEntry("fields", fields)
                };

            return result;
        }
    }
}