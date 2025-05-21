using RubiksCubeChallenge.Enums;

namespace RubiksCubeChallenge.Strategy
{
    public class BackRotation : IFaceRotationStrategy
    {
        public void Rotate(Dictionary<Face, Color[,]> f, Rotation dir)
        {
            var up = f[Face.Up];
            var down = f[Face.Down];
            var left = f[Face.Left];
            var right = f[Face.Right];
            var temp = new Color[3];
            for (int i = 0; i < 3; i++) temp[i] = up[0, i];

            if (dir == Rotation.CCW)
            {
                for (int i = 0; i < 3; i++) up[0, 2 - i] = left[i, 0];
                for (int i = 0; i < 3; i++) left[2 - i, 0] = down[2, 2 - i];
                for (int i = 0; i < 3; i++) down[2, 2 - i] = right[i, 2];
                for (int i = 0; i < 3; i++) right[i, 2] = temp[i];
            }
            else
            {
                for (int i = 0; i < 3; i++) up[0, i] = right[i, 2];
                for (int i = 0; i < 3; i++) right[2 - i, 2] = down[2, i];
                for (int i = 0; i < 3; i++) down[2, 2 - i] = left[2 - i, 0];
                for (int i = 0; i < 3; i++) left[2 - i, 0] = temp[i];
            }
        }
    }
}
