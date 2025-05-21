using RubiksCubeChallenge;
using RubiksCubeChallenge.Enums;

var cube = new RubiksCube();

Console.WriteLine("Initial (Solved) Cube:");
cube.Print();

Console.WriteLine("\nApplying rotation sequence:");
cube.Rotate(Face.Front, Rotation.CW);
cube.Rotate(Face.Right, Rotation.CCW);
cube.Rotate(Face.Up, Rotation.CW);
cube.Rotate(Face.Back, Rotation.CCW);
cube.Rotate(Face.Left, Rotation.CW);
cube.Rotate(Face.Down, Rotation.CCW);

Console.WriteLine("\nFinal Cube State:");
cube.Print();
