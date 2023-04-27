namespace FinalProject {
    public static class AnimateGrid {
        public static void AnimateProgress(int[,] grid, int x, int y) {
            Console.Clear();
            Console.WriteLine("Current Grid: ");
            for (int i = 0; i < grid.GetLength(0); i++) {
                for (int j = 0; j < grid.GetLength(1); j++) {
                    if (x == i && y == j) Console.ForegroundColor = ConsoleColor.Red; //red color for currently changed value
                    else if (grid[i, j] == Program.newColor) Console.ForegroundColor = ConsoleColor.Blue; //blue color for all values changed so far
                    else Console.ResetColor(); // standard color for all other values

                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }
            Thread.Sleep(500);
        }

        public static void AnimateFinal(int[,] grid) {
            Console.Clear();
            Console.WriteLine("Final Grid: ");
            for (int i = 0; i < grid.GetLength(0); i++) {
                for (int j = 0; j < grid.GetLength(1); j++) {
                    if (grid[i, j] == Program.newColor) Console.ForegroundColor = ConsoleColor.Blue; //blue color for all values changed
                    else Console.ResetColor(); // standard color for all other values

                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }
            Thread.Sleep(500);
        }
    }
}