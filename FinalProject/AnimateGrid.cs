namespace FinalProject {
    public static class AnimateGrid {
        public static void AnimateProgress(string[,] grid) {
            Console.Clear();
            Console.WriteLine("Current Grid: ");
            for (int i = 0; i < grid.GetLength(0); i++) {
                for (int j = 0; j < grid.GetLength(1); j++) {
                    Console.ForegroundColor = (ConsoleColor) Enum.Parse(typeof(ConsoleColor), grid[i,j]); // Get correct color
                    Console.Write("+" + " ");
                }
                Console.WriteLine();
            }
            Console.ResetColor();
            Thread.Sleep(500);
        }

        public static void AnimateFinal(string[,] grid) {
            Console.Clear();
            Console.WriteLine("Final Grid: ");
            for (int i = 0; i < grid.GetLength(0); i++) {
                for (int j = 0; j < grid.GetLength(1); j++) {
                    Console.ForegroundColor = (ConsoleColor) Enum.Parse(typeof(ConsoleColor), grid[i,j]); // Get correct color
                    Console.Write("+" + " ");
                }
                Console.WriteLine();
            }
            Console.ResetColor();
            Thread.Sleep(500);
        }
    }
}