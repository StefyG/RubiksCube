using RubiksCubeChallenge.Enums;
using RubiksCubeChallenge.Helpers;
using RubiksCubeChallenge.Strategy;

namespace RubiksCubeChallenge
{
    public class RubiksCube
    {
        private readonly Dictionary<Face, Color[,]> _faces;
        private readonly Dictionary<Face, IFaceRotationStrategy> _rotationHandlers;

        public RubiksCube()
        {
            _faces = new Dictionary<Face, Color[,]>
            {
                [Face.Up] = FaceMatrixHelper.Fill(Color.White),
                [Face.Down] = FaceMatrixHelper.Fill(Color.Yellow),
                [Face.Left] = FaceMatrixHelper.Fill(Color.Orange),
                [Face.Right] = FaceMatrixHelper.Fill(Color.Red),
                [Face.Front] = FaceMatrixHelper.Fill(Color.Green),
                [Face.Back] = FaceMatrixHelper.Fill(Color.Blue)
            };

            _rotationHandlers = new()
            {
                [Face.Front] = new FrontRotation(),
                [Face.Back] = new BackRotation(),
                [Face.Left] = new LeftRotation(),
                [Face.Right] = new RightRotation(),
                [Face.Up] = new UpRotation(),
                [Face.Down] = new DownRotation()
            };
        }

        public void Rotate(Face face, Rotation dir)
        {
            _faces[face] = FaceMatrixHelper.Rotate(_faces[face], dir);
            _rotationHandlers[face].Rotate(_faces, dir);
        }

        public void Print()
        {
            foreach (var face in Enum.GetValues<Face>())
            {
                Console.WriteLine($"{face}:");
                FaceMatrixHelper.Print(_faces[face]);
            }
        }

        public Color[,] GetFace(Face face) => _faces[face];

        public void Reset()
        {
            foreach (Face face in Enum.GetValues(typeof(Face)))
            {
                var color = face switch
                {
                    Face.Up => Color.White,
                    Face.Down => Color.Yellow,
                    Face.Left => Color.Orange,
                    Face.Right => Color.Red,
                    Face.Front => Color.Green,
                    Face.Back => Color.Blue,
                    _ => throw new InvalidOperationException()
                };

                var filled = FaceMatrixHelper.Fill(color);

                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        _faces[face][i, j] = filled[i, j];
            }
        }
    }
}
