using System.Text.Json.Serialization;

namespace WebAPI_Course.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TurnoEnum
    {
        Manha,
        Tarde,
        Noite

    }
}
