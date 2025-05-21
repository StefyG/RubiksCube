using RubiksCubeChallenge.Enums;
using RubiksCubeChallenge.Tests.Helpers;

namespace RubiksCubeChallenge.Tests
{
    public class RubiksCubeTests
    {
        [Theory]
        [InlineData(Face.Front)]
        [InlineData(Face.Back)]
        [InlineData(Face.Left)]
        [InlineData(Face.Right)]
        [InlineData(Face.Up)]
        [InlineData(Face.Down)]
        public void Rotate_Clockwise_And_CounterClockwise_ShouldRestoreInitialState(Face face)
        {
            // Arrange
            var cube = new RubiksCube();

            // Act
            cube.Rotate(face, Rotation.CW);
            cube.Rotate(face, Rotation.CCW);

            // Assert
            Assert.True(CubeAssertions.IsSolved(cube));
        }

        [Fact]
        public void Rotate_MultipleFacesAndRevert_ShouldReturnToInitialState()
        {
            var cube = new RubiksCube();

            var sequence = new List<(Face face, Rotation rotation)>
            {
                (Face.Right, Rotation.CW),
                (Face.Front, Rotation.CW),
                (Face.Left, Rotation.CW),
                (Face.Back, Rotation.CW),
                (Face.Up, Rotation.CW),
                (Face.Down, Rotation.CW),
            };

            // Apply sequence
            foreach (var move in sequence)
                cube.Rotate(move.face, move.rotation);

            // Apply inverse sequence (reverse order, reverse rotation)
            foreach (var move in sequence.AsEnumerable().Reverse())
            {
                var inverse = move.rotation == Rotation.CW ? Rotation.CCW : Rotation.CW;
                cube.Rotate(move.face, inverse);
            }

            Assert.True(CubeAssertions.IsSolved(cube));
        }
    }
}
