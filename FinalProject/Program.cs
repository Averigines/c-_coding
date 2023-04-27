using System;
using System.Collections.Generic;
using System.IO;

namespace FinalProject {

    public class Program {

        public static int newColor = 0;
        static int startX = 0;
        static int startY = 0;
 
	    public static void Main(string[] args) {

		    int[,] grid = ReadInput("input.txt"); // Get input data

		    FloodFill(grid, startX, startY, newColor); //Execute algorithm with new color (represented as number)

		    WriteOutput(grid, "output.txt"); // Generate output.txt with applied algorithm result
	    }

        // Function to read data from inputfile and return a 2-dimensional Grid with data
        static int[,] ReadInput(string filename) {
            List<List<int>> rows = new List<List<int>>(); // List to store values

            using (StreamReader sr = new StreamReader(filename)) {
                string? line;
                // Get complete line of textfile
                while ((line = sr.ReadLine()) != null) {
                    
                    if (line.Contains("Color")) {
                        foreach (string numStr in line.Split(' ')) {
                            if (int.TryParse(numStr, out int num)) newColor = num;
                        }
                    }
                    else if (line.Contains("StartX")) {
                        foreach (string numStr in line.Split(' ')) {
                            if (int.TryParse(numStr, out int num)) startX = num;
                        }
                    }
                    else if (line.Contains("StartY")) {
                        foreach (string numStr in line.Split(' ')) {
                            if (int.TryParse(numStr, out int num)) startY = num;
                        }
                    }
                    else if (line != "") {
                        List<int> row = new List<int>();

                        // Divide line into values by spaces
                        foreach (string numStr in line.Split(' ')) {
                            if (int.TryParse(numStr, out int num)) {
                                row.Add(num); // Add value to current row
                            }
                        }
                        rows.Add(row); // Add row with all values to list
                    }  
                }
                sr.Close();
            }

            // Get size of grid and create 2D-Array
            int numRows = rows.Count;
            int numCols = rows[0].Count;
            int[,] grid = new int[numRows, numCols];

            // Convert List to 2D-Array
            for (int i = 0; i < numRows; i++) {
                for (int j = 0; j < numCols; j++) {
                    grid[i, j] = rows[i][j];
                }
            }

            return grid;
        }

        // Function to write result of algorithm to outputfile
        static void WriteOutput(int[,] grid, string filename) {
            using (StreamWriter sw = new StreamWriter(filename)) {

                // Write every value and divide by space. After each row, write a new line if it's not the last line.
                for (int i = 0; i < grid.GetLength(0); i++) {
                    for (int j = 0; j < grid.GetLength(1); j++) {
                        sw.Write(grid[i, j] + " ");
                    }
                    if (i < grid.GetLength(0) - 1) {
                        sw.WriteLine();
                    }
                    
                }
                sw.Close();
            }
        }

        // Function to apply FloodFill algorithm to grid. Takes the grid, a starting x and y value and a new color to be applied.
	    static void FloodFill(int[,] grid, int x, int y, int newColor) {
    	    int oldColor = grid[x, y]; // Get old color of starting point
    	    if (oldColor == newColor) return; // Don't change anything if color is the same.
    
            // Create a new Queue and enqueue the starting point.
    	    Queue<(int, int)> queue = new Queue<(int, int)>();
    	    queue.Enqueue((x, y));

            int maxColumn = grid.GetLength(0) - 1;
            int maxRow = grid.GetLength(1) - 1;
    
            /*
            As long as there is a value in the queue, dequeue last value in queue
            and check for the color of all 4 orthogonaly connected cells in the grid.
            Put all values that are filled with the old color in the queue.
            */
    	    while (queue.Count > 0) {
        	    (int currX, int currY) = queue.Dequeue();
        	    grid[currX, currY] = newColor;
                AnimateGrid.AnimateProgress(grid, currX, currY);

        	    if (currX > 0 && grid[currX - 1, currY] == oldColor) queue.Enqueue((currX - 1, currY));
        	    if (currX < maxColumn && grid[currX + 1, currY] == oldColor) queue.Enqueue((currX + 1, currY));
        	    if (currY > 0 && grid[currX, currY - 1] == oldColor) queue.Enqueue((currX, currY - 1));
        	    if (currY < maxRow && grid[currX, currY + 1] == oldColor) queue.Enqueue((currX, currY + 1));
    	    }
            AnimateGrid.AnimateFinal(grid);
	    }

        

        
    }
}