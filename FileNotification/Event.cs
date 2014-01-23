using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using TCC2.API;

namespace FileNotification
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    class Event
    {
        [JsonProperty(PropertyName = "eventid")]
        public string EventId { get; protected set; }

        [JsonProperty(PropertyName = "eventparams")]
        public string EventParams { get; protected set; }

        [JsonProperty(PropertyName = "filepath")]
        public string FilePath { get; protected set; }

        [JsonProperty(PropertyName = "filespaceid")]
        public string FilespaceId { get; protected set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; protected set; }

        [JsonProperty(PropertyName = "statusdate")]
        public string StatusDate { get; protected set; }

        [JsonProperty(PropertyName = "statusprovider")]
        public string StatusProvider { get; protected set; }

        [JsonProperty(PropertyName = "updatecount")]
        public int UpdateCount { get; protected set; }
    }
}

/*
{ "events" : [ { "eventdate" : "2013-05-13 14:37:07",
        "eventid" : "a45033f2-6adc-4ec4-baff-81d099c7fb71",
        "eventparams" : "[fileoperation:new, filepath:/file.tag, filespaceid:ue60dbbee-bbe9-11e2-9250-000c2985969e]",
        "filepath" : "/file.tag",
        "filespaceid" : "ue60dbbee-bbe9-11e2-9250-000c2985969e",
        "status" : null,
        "statusdate" : null,
        "statusprovider" : null,
        "updatecount" : 0
      } ],
  "success" : true,
  "total" : 1
}
*/