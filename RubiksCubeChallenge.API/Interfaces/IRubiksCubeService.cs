using RubiksCubeChallenge.Enums;

namespace RubiksCubeChallenge.API.Interfaces
{
    public interface IRubiksCubeService
    {
        Dictionary<Face, string[][]> GetCubeState();
        void Rotate(Face face, Rotation direction);
        void Reset();
    }

}
