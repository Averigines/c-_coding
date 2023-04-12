namespace GeometryLibrary{
public class Cuboid
    {
        public double[] Vertex1 { get; set; }
        public double[] Vertex2 { get; set; }
        public double[] Vertex3 { get; set; }
        public double[] Vertex4 { get; set; }
        public double[] Vertex5 { get; set; }
        public double[] Vertex6 { get; set; }
        public double[] Vertex7 { get; set; }
        public double[] Vertex8 { get; set; }
    
        public override bool Equals(object obj)
        {
            if (!(obj is Cuboid))
            {
                return false;
            }

            Cuboid other = (Cuboid)obj;
            return Vertex1 == other.Vertex1 && Vertex2 == other.Vertex2 && Vertex3 == other.Vertex3 && Vertex4 == other.Vertex4 && Vertex5 == other.Vertex5 && Vertex6 == other.Vertex6 && Vertex7 == other.Vertex7 && Vertex8 == other.Vertex8;
        }

        public double[] Centroid()
        {
            double x = (Vertex1[0] + Vertex2[0] + Vertex3[0] + Vertex4[0] + Vertex5[0] + Vertex6[0] + Vertex7[0] + Vertex8[0]) / 8;
            double y = (Vertex1[1] + Vertex2[1] + Vertex3[1] + Vertex4[1] + Vertex5[1] + Vertex6[1] + Vertex7[1] + Vertex8[1]) / 8;
            double z = (Vertex1[2] + Vertex2[2] + Vertex3[2] + Vertex4[2] + Vertex5[2] + Vertex6[2] + Vertex7[2] + Vertex8[2]) / 8;
            return new double[] { x, y, z };
        }

        public double SurfaceArea()
        {
            Thread.Sleep(1000);
            double a = Distance(Vertex1, Vertex2);
            double b = Distance(Vertex2, Vertex3);
            double c = Distance(Vertex1, Vertex5);
            double area = 2 * (a * b + a * c + b * c);
            return area;
        }

        public double Volume()
        {
            double a = Distance(Vertex1, Vertex2);
            double b = Distance(Vertex2, Vertex3);
            double c = Distance(Vertex1, Vertex5);
            return a * b * c;
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
