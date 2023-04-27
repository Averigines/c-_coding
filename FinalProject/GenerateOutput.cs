using System.Drawing;

namespace FinalProject {
    public static class GenerateOutput {
        // Function to write result of algorithm to outputfile
        public static void WriteOutput(string[,] grid, string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {

                // Write every value and divide by space. After each row, write a new line if it's not the last line.
                for (int i = 0; i < grid.GetLength(0); i++)
                {
                    for (int j = 0; j < grid.GetLength(1); j++)
                    {
                        sw.Write(grid[i, j] + " ");
                    }
                    if (i < grid.GetLength(0) - 1)
                    {
                        sw.WriteLine();
                    }
                }
                sw.Close();
            }
        }

        public static void DrawOutput(string[,] grid, Graphics g, Bitmap bmp)
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
            bmp.Save("output.png", System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}