using RubiksCubeChallenge.Enums;
using System.Reflection;

namespace RubiksCubeChallenge.Tests.Helpers
{
    public static class CubeAssertions
    {
        public static bool IsSolved(RubiksCube cube)
        {
            var field = typeof(RubiksCube).GetField("_faces", BindingFlags.NonPublic | BindingFlags.Instance);
            var faces = (Dictionary<Face, Color[,]>)field!.GetValue(cube)!;

            foreach (Face face in Enum.GetValues(typeof(Face)))
            {
                var faceMatrix = faces[face];
                var color = faceMatrix[0, 0];

                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        if (faceMatrix[i, j] != color)
                            return false;
            }

            return true;
        }
    }
}