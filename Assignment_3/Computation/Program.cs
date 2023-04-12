using GeometryLibrary;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        List<Tetrahedron> tetrahedrons = new List<Tetrahedron>();
        List<Cuboid> cuboids = new List<Cuboid>();
        List<Cylinder> cylinders = new List<Cylinder>();

        //Create all shapes with random values
        for (int i = 0; i < 5; i++) {
            tetrahedrons.Add(new Tetrahedron {
                Vertex1 = randomDoubleArray(),
                Vertex2 = randomDoubleArray(),
                Vertex3 = randomDoubleArray(),
                Vertex4 = randomDoubleArray()
            });

            cuboids.Add(new Cuboid {
                Vertex1 = randomDoubleArray(),
                Vertex2 = randomDoubleArray(),
                Vertex3 = randomDoubleArray(),
                Vertex4 = randomDoubleArray(),
                Vertex5 = randomDoubleArray(),
                Vertex6 = randomDoubleArray(),
                Vertex7 = randomDoubleArray(),
                Vertex8 = randomDoubleArray()
            });

            cylinders.Add(new Cylinder {
                Radius = randomDouble(),
                Vertex1 = randomDoubleArray(),
                Vertex2 = randomDoubleArray()
            });
            
        }

        Stopwatch timer = Stopwatch.StartNew();

        //Create three tasks for every shape
        Task taskTetrahedronSurface = new Task(() => {
            for (int i = 0; i < 5; i++) {
                double surfaceArea = tetrahedrons[i].SurfaceArea();
                Console.WriteLine($"Surface area of Tetrahedron {i+1}: " + surfaceArea);
        }
        });

        Task taskCuboidSurface = new Task(() => {
            for (int i = 0; i < 5; i++) {
                double surfaceArea = cuboids[i].SurfaceArea();
                Console.WriteLine($"Surface area of Cuboid {i+1}: " + surfaceArea);
        }
        });

        Task taskCylinderSurface = new Task(() => {
            for (int i = 0; i < 5; i++) {
                double surfaceArea = cylinders[i].SurfaceArea();
                Console.WriteLine($"Surface area of Cylinder {i+1}: " + surfaceArea);
        }
        });
        
        taskTetrahedronSurface.Start();
        taskTetrahedronSurface.Wait();
        taskCylinderSurface.Start();
        taskCuboidSurface.Start();
        
        Task.WaitAll(taskCuboidSurface,taskCylinderSurface,taskTetrahedronSurface);
        
        timer.Stop();
        System.Console.WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed");
    }

    //get random double number ranging from 0 to 20
    static double randomDouble() {
        Random random = new Random();
        return random.NextDouble() * 20;
    }

    //get array with 3 random double numbers ranging from 0 to 20
    static double[] randomDoubleArray() {

        Random random = new Random();
        double[] randomArray = new double[3];
        randomArray[0] = random.NextDouble() * 20;
        randomArray[1] = random.NextDouble() * 20;
        randomArray[2] = random.NextDouble() * 20;
        return randomArray;
    }
}