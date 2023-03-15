using System.Text.Json.Serialization;

namespace dotnet_tutorial.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Knight, Mage, Cleric
    }
}