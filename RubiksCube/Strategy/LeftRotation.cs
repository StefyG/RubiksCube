using RubiksCubeChallenge.Enums;

namespace RubiksCubeChallenge.Strategy
{
    public class LeftRotation : IFaceRotationStrategy
    {
        public void Rotate(Dictionary<Face, Color[,]> f, Rotation dir)
        {
            var up = f[Face.Up];
            var down = f[Face.Down];
            var front = f[Face.Front];
            var back = f[Face.Back];
            var temp = new Color[3];
            for (int i = 0; i < 3; i++) temp[i] = up[i, 0];

            if (dir == Rotation.CW)
            {
                for (int i = 0; i < 3; i++) up[i, 0] = back[2 - i, 2];
                for (int i = 0; i < 3; i++) back[i, 2] = down[2 - i, 0];
                for (int i = 0; i < 3; i++) down[i, 0] = front[i, 0];
                for (int i = 0; i < 3; i++) front[i, 0] = temp[i];
            }
            else
            {
                for (int i = 0; i < 3; i++) up[i, 0] = front[i, 0];
                for (int i = 0; i < 3; i++) front[i, 0] = down[i, 0];
                for (int i = 0; i < 3; i++) down[i, 0] = back[2 - i, 2];
                for (int i = 0; i < 3; i++) back[i, 2] = temp[2 - i];
            }
        }
    }
}
