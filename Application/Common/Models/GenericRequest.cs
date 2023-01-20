using System.Text.Json;

namespace Application.Common.Models
{
    public record GenericRequest
    {
        public string Service { get; init; }
        public JsonDocument Data { get; init; }
    }
}
