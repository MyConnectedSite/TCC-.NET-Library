using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using TCC2.API;

namespace FileNotification
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    class SetEventsResult : ApiCallResult
    {
    }
}
