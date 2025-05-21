using RubiksCubeChallenge.Enums;

namespace RubiksCubeChallenge.Helpers
{
    public static class FaceMatrixHelper
    {
        public static Color[,] Fill(Color color)
        {
            var face = new Color[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    face[i, j] = color;
            return face;
        }

        public static Color[,] Rotate(Color[,] face, Rotation dir)
        {
            var rotated = new Color[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    rotated[i, j] = dir == Rotation.CW ? face[2 - j, i] : face[j, 2 - i];
            return rotated;
        }

        public static void Print(Color[,] face)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    Console.Write(GetColorChar(face[i, j]) + " ");
                Console.WriteLine();
            }
        }

        private static char GetColorChar(Color color) => color switch
        {
            Color.White => 'W',
            Color.Yellow => 'Y',
            Color.Green => 'G',
            Color.Blue => 'B',
            Color.Orange => 'O',
            Color.Red => 'R',
            _ => '?'
        };

    }
}
