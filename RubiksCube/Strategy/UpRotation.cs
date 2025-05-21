using RubiksCubeChallenge.Enums;

namespace RubiksCubeChallenge.Strategy
{
    public class UpRotation : IFaceRotationStrategy
    {
        public void Rotate(Dictionary<Face, Color[,]> f, Rotation dir)
        {
            var front = f[Face.Front];
            var right = f[Face.Right];
            var back = f[Face.Back];
            var left = f[Face.Left];
            var temp = new Color[3];
            for (int i = 0; i < 3; i++) temp[i] = front[0, i];

            if (dir == Rotation.CCW)
            {
                for (int i = 0; i < 3; i++) front[0, i] = left[0, i];
                for (int i = 0; i < 3; i++) left[0, i] = back[0, i];
                for (int i = 0; i < 3; i++) back[0, i] = right[0, 2 - i];
                for (int i = 0; i < 3; i++) right[0, i] = temp[i];
            }
            else
            {
                for (int i = 0; i < 3; i++) front[0, i] = right[0, i];
                for (int i = 0; i < 3; i++) right[0, i] = back[0, i];
                for (int i = 0; i < 3; i++) back[0, i] = left[0, i];
                for (int i = 0; i < 3; i++) left[0, i] = temp[i];
            }
        }
    }
}
