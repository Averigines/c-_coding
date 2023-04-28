using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace FinalProject
{
    public class Program
    {
        static string newColor = "White";
        static int startX = 0;
        static int startY = 0;
        public static int rectSize = 50;

        public static void Main(string[] args)
        {
            string[,] grid = GenerateInput.ReadInput("input.txt"); // Get input data

            Bitmap bmp = new Bitmap(grid.GetLength(1) * rectSize, grid.GetLength(0) * rectSize);
            Graphics g = Graphics.FromImage(bmp);

            GenerateInput.DrawInput(grid, g, bmp);

            Console.Write("Enter a new color (Choose one between the following: Black, Blue, Cyan, DarkBlue, DarkCyan, DarkGray, DarkGreen, DarkMagenta, DarkRed, Gray, Green, Magenta, Red, White, Yellow): ");
            newColor = Console.ReadLine()!;

            Console.Write($"Enter the starting X coordinate (Min: 0, Max: {grid.GetLength(1) - 1}): ");
            startX = int.Parse(Console.ReadLine()!);

            Console.Write($"Enter the starting Y coordinate (Min: 0, Max: {grid.GetLength(0) - 1}): ");
            startY = int.Parse(Console.ReadLine()!);

            FloodFill(grid, startX, startY, newColor, g); //Execute algorithm with new color (represented as number)

            GenerateOutput.WriteOutput(grid, "output.txt"); // Generate output.txt with applied algorithm result
            GenerateOutput.DrawOutput(grid, g, bmp);

            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("The image got saved as a .txt and .png file in the root folder.");
        }

        // Function to apply FloodFill algorithm to grid. Takes the grid, a starting x and y value and a new color to be applied.
        static void FloodFill(string[,] grid, int x, int y, string newColor, Graphics g)
        {
            string oldColor = grid[y, x]; // Get old color of starting point
            if (oldColor == newColor) return; // Don't change anything if color is the same.

            // Create a new Queue and enqueue the starting point.
            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue((y, x));

            HashSet<(int, int)> enqueued = new HashSet<(int, int)>();
            enqueued.Add((y, x));

            int maxColumn = grid.GetLength(0) - 1;
            int maxRow = grid.GetLength(1) - 1;

            /*
            As long as there is a value in the queue, dequeue last value in queue
            and check for the color of all 4 orthogonaly connected cells in the grid.
            Put all values that are filled with the old color in the queue.
            */
            while (queue.Count > 0)
            {
                (int currY, int currX) = queue.Dequeue();
                grid[currY, currX] = newColor;
                AnimateGrid.AnimateProgress(grid);

                if (currX > 0 && grid[currY, currX - 1] == oldColor && !enqueued.Contains((currY, currX - 1))) 
                {
                    queue.Enqueue((currY, currX - 1));
                    enqueued.Add((currY, currX - 1));
                }
                if (currX < maxColumn && grid[currY, currX + 1] == oldColor && !enqueued.Contains((currY, currX + 1))) 
                {
                    queue.Enqueue((currY, currX + 1));
                    enqueued.Add((currY, currX + 1));
                }
                if (currY > 0 && grid[currY - 1, currX] == oldColor && !enqueued.Contains((currY - 1, currX))) 
                {
                    queue.Enqueue((currY - 1, currX));
                    enqueued.Add((currY - 1, currX));
                }
                if (currY < maxRow && grid[currY + 1, currX] == oldColor && !enqueued.Contains((currY + 1, currX)))
                {
                    queue.Enqueue((currY + 1, currX));
                    enqueued.Add((currY + 1, currX));
                }
            }
            AnimateGrid.AnimateFinal(grid);
        }
    }
}