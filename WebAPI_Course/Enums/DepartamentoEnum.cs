using System.Text.Json.Serialization;

namespace WebAPI_Course.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DepartamentoEnum
    {
        Rg,
        Financeior,
        Compras,
        Atendimento,
        Zeladoria
    }
}
