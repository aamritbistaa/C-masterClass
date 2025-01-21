using System.Collections.Specialized;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace GymManagement.Contracts.Subscriptions;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SubscriptionType
{
    [Description("Free")]
    Free,
    [Description("Starter")]
    Starter,
    [Description("Pro")]
    Pro
}
