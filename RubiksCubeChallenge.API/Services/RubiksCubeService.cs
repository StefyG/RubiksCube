using RubiksCubeChallenge.API.Interfaces;
using RubiksCubeChallenge.Enums;

namespace RubiksCubeChallenge.API.Services
{
    public class RubiksCubeService : IRubiksCubeService
    {
        private readonly RubiksCube _cube = new();

        public Dictionary<Face, string[][]> GetCubeState()
        {
            var result = new Dictionary<Face, string[][]>();
            foreach (Face face in Enum.GetValues(typeof(Face)))
            {
                var matrix = _cube.GetFace(face);
                var faceColors = new string[3][];
                for (int i = 0; i < 3; i++)
                {
                    faceColors[i] = new string[3];
                    for (int j = 0; j < 3; j++)
                        faceColors[i][j] = matrix[i, j].ToString();
                }
                result[face] = faceColors;
            }
            return result;
        }

        public void Rotate(Face face, Rotation direction) => _cube.Rotate(face, direction);
        public void Reset() => _cube.Reset();
    }

}
