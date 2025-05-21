using RubiksCubeChallenge.Enums;

namespace RubiksCubeChallenge.Strategy
{
    public interface IFaceRotationStrategy
    {
        void Rotate(Dictionary<Face, Color[,]> faces, Rotation dir);
    }
}
