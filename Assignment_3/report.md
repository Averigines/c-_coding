# Assignment 3: 3D Geometrics

## Main

In the main program, we just initialize all the shapes and give them random values and positions. 

``` c#
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
```

Then we create three tasks for each shape in which we iterate through all instances of a shape.

``` c#
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
```

<br>

## Library

The GeometryLibrary is a class library using a solution in my main folder. All the shapes are constructed very similarly.

``` c#
public class Tetrahedron
    {
        public double[] Vertex1 { get; set; }
        public double[] Vertex2 { get; set; }
        public double[] Vertex3 { get; set; }
        public double[] Vertex4 { get; set; }
    
        public override bool Equals(object obj)
        {
            if (!(obj is Tetrahedron))
            {
                return false;
            }

            Tetrahedron other = (Tetrahedron)obj;
            return Vertex1 == other.Vertex1 && Vertex2 == other.Vertex2 && Vertex3 == other.Vertex3 && Vertex4 == other.Vertex4;
        }
```

I overwrite the == operator and defined getters and setters for the data that needs to be assigned to the shape when initialized.

``` c#
    public double[] Centroid()
        {
            double x = (Vertex1[0] + Vertex2[0] + Vertex3[0] + Vertex4[0]) / 4;
            double y = (Vertex1[1] + Vertex2[1] + Vertex3[1] + Vertex4[1]) / 4;
            double z = (Vertex1[2] + Vertex2[2] + Vertex3[2] + Vertex4[2]) / 4;
            return new double[] { x, y, z };
        }

        public double SurfaceArea()
        {
            Thread.Sleep(1000);
            double a = Distance(Vertex1, Vertex2);
            double b = Distance(Vertex2, Vertex3);
            double c = Distance(Vertex3, Vertex1);
            double d = Distance(Vertex1, Vertex4);
            double e = Distance(Vertex2, Vertex4);
            double f = Distance(Vertex3, Vertex4);
            double s1 = (a + b + c) / 2;
            double s2 = (a + d + e) / 2;
            double s3 = (b + e + f) / 2;
            double s4 = (c + d + f) / 2;
            double area = Math.Sqrt(s1 * (s1 - a) * (s1 - b) * (s1 - c)) + Math.Sqrt(s2 * (s2 - a) * (s2 - d) * (s2 - e)) + Math.Sqrt(s3 * (s3 - b) * (s3 - e) * (s3 - f)) + Math.Sqrt(s4 * (s4 - c) * (s4 - d) * (s4 - f));
            return area;
        }

        private double Distance(double[] p1, double[] p2)
        {
            double dx = p1[0] - p2[0];
            double dy = p1[1] - p2[1];
            double dz = p1[2] - p2[2];
            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }
```

These are the calculations for the Tetrahedron. The calculations for the shapes were very similar, especially for the Tetrahedron and the Cuboid.