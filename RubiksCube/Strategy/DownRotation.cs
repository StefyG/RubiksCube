using RubiksCubeChallenge.Enums;

namespace RubiksCubeChallenge.Strategy
{
    public class DownRotation : IFaceRotationStrategy
    {
        public void Rotate(Dictionary<Face, Color[,]> f, Rotation dir)
        {
            var front = f[Face.Front];
            var right = f[Face.Right];
            var back = f[Face.Back];
            var left = f[Face.Left];
            var temp = new Color[3];
            for (int i = 0; i < 3; i++) temp[i] = front[2, i];

            if (dir == Rotation.CW)
            {
                for (int i = 0; i < 3; i++) front[2, i] = left[2, i];
                for (int i = 0; i < 3; i++) left[2, i] = back[2, i];
                for (int i = 0; i < 3; i++) back[2, i] = right[2, i];
                for (int i = 0; i < 3; i++) right[2, i] = temp[i];
            }
            else
            {
                for (int i = 0; i < 3; i++) front[2, i] = right[2, i];
                for (int i = 0; i < 3; i++) right[2, i] = back[2, i];
                for (int i = 0; i < 3; i++) back[2, i] = left[2, i];
                for (int i = 0; i < 3; i++) left[2, i] = temp[i];
            }
        }
    }
}
