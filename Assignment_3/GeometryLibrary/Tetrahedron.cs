namespace GeometryLibrary{
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
    }
}
