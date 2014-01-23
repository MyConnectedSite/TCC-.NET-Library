using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using TCC2.API;

namespace FileNotification
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    class GetEventsResult : ApiCallResult
    {
        [JsonProperty(PropertyName = "events")]
        public List<Event> Events { get; protected set; }

        [JsonProperty(PropertyName = "total")]
        public int total { get; protected set; }


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