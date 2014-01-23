using System;
using Newtonsoft.Json;

namespace TCC2.API.CloudTracker
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class SetCloudTrackerItemResult : ApiCallResult
    {
        [JsonProperty(PropertyName = "itemId")]
        public string ItemId { get; protected set; }

        protected override void ValidateInstance(IRequestDataProvider provider)
        {
            base.ValidateInstance(provider);

            string displayName = "item ID";
            ValidateHasValue(ItemId, displayName);
            ValidateValueMatchesInputParam(ItemId, provider, "itemid", displayName);
        }
    }
}