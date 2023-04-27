using System.Drawing;

namespace FinalProject {
    public static class GenerateInput {
        // Function to read data from inputfile and return a 2-dimensional Grid with data
        public static string[,] ReadInput(string filename)
        {
            List<List<string>> rows = new List<List<string>>(); // List to store values

            using (StreamReader sr = new StreamReader(filename))
            {
                string? line;
                // Get complete line of textfile
                while ((line = sr.ReadLine()) != null)
                {
                    List<string> row = new List<string>();

                    // Divide line into values by spaces
                    foreach (string numStr in line.Split(' '))
                    {
                        row.Add(numStr); // Add value to current row
                    }
                    rows.Add(row); // Add row with all values to list
                }
                sr.Close();
            }

            // Get size of grid and create 2D-Array
            int numRows = rows.Count;
            int numCols = rows[0].Count;
            string[,] grid = new string[numRows, numCols];

            // Convert List to 2D-Array
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    grid[i, j] = rows[i][j];
                }
            }

            return grid;
        }  

        public static void DrawInput(string[,] grid, Graphics g, Bitmap bmp)
        {
            SolidBrush brush = new SolidBrush(Color.White);

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    brush.Color = Color.FromName(grid[i, j]);
                    g.FillRectangle(brush, j * Program.rectSize, i * Program.rectSize, Program.rectSize, Program.rectSize);
                }
            }
            bmp.Save("input.png", System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}