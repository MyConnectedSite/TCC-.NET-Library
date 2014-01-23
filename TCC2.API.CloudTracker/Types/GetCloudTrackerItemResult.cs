using System;
using Newtonsoft.Json;

namespace TCC2.API.CloudTracker
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class GetCloudTrackerItemResult : BaseCloudTrackerItem, IApiCallResult
    {
        [JsonProperty(PropertyName = "success", Required = Required.Always)]
        protected bool Success { get; private set; }

        [JsonProperty(PropertyName = "errorid")]
        protected string ErrorId { get; private set; }

        [JsonProperty(PropertyName = "message")]
        protected string Message { get; private set; }

        void IApiCallResult.Validate(IRequestDataProvider provider)
        {
            ApiCallResult.Validate(provider, Success, ErrorId, Message);
            ApiCallResult.ValidateHasValue(ItemId, "item ID");
            ApiCallResult.ValidateHasValue(OrganizationId, "organization ID");
            ApiCallResult.ValidateHasValue(OrganizationName, "organization name");
            ApiCallResult.ValidateHasValue(OrganizationShortName, "organization short name");
            ApiCallResult.ValidateHasValue(ActiveEPC, "active EPC");
            ApiCallResult.ValidateHasValue(Category, "category");
            ApiCallResult.ValidateHasValue(Type, "type");
            ApiCallResult.ValidateHasValue(Manufacturer, "manufacturer");
            ApiCallResult.ValidateHasValue(Model, "model");
            ApiCallResult.ValidateHasValue(SerialNumber, "serial number");
            ApiCallResult.ValidateHasValue(CreateMember, "create member");
            ApiCallResult.ValidateHasValue(ModifyMember, "modify member");
        }
    }
}