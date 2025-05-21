using RubiksCubeChallenge.Enums;
using System.Text.Json.Serialization;

namespace RubiksCubeChallenge.API.Models
{
    public class RotationRequest
    {
        [JsonConverter(typeof(JsonStringEnumConverter<Face>))]
        public Face Face { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter<Rotation>))]
        public Rotation Direction { get; set; }
    }
}
