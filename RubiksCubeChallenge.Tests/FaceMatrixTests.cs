using RubiksCubeChallenge.Enums;
using RubiksCubeChallenge.Helpers;

namespace RubiksCubeChallenge.Tests
{
    public class FaceMatrixTests
    {
        [Fact]
        public void FaceMatrix_RotateClockwise_ShouldRotateCorrectly()
        {
            var original = new Color[3, 3]
            {
            { Color.White, Color.Green, Color.Blue },
            { Color.Yellow, Color.Red, Color.Orange },
            { Color.Blue, Color.Green, Color.White }
            };

            var expected = new Color[3, 3]
            {
            { Color.Blue, Color.Yellow, Color.White },
            { Color.Green, Color.Red, Color.Green },
            { Color.White, Color.Orange, Color.Blue }
            };

            var rotated = FaceMatrixHelper.Rotate(original, Rotation.CW);

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Assert.Equal(expected[i, j], rotated[i, j]);
        }

        [Fact]
        public void RotateAndReverse_ShouldReturnToOriginal()
        {
            var original = FaceMatrixHelper.Fill(Color.Red);
            var rotated = FaceMatrixHelper.Rotate(original, Rotation.CW);
            var reverted = FaceMatrixHelper.Rotate(rotated, Rotation.CCW);

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Assert.Equal(original[i, j], reverted[i, j]);
        }

        [Fact]
        public void Fill_ShouldCreateMatrixWithSingleColor()
        {
            var face = FaceMatrixHelper.Fill(Color.Green);

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Assert.Equal(Color.Green, face[i, j]);
        }
    }
}
