namespace GeometryLibrary{
public class Cylinder
    {
        public double Radius { get; set; }
        public double[] Vertex1 { get; set; }
        public double[] Vertex2 { get; set; }
    
        public override bool Equals(object obj)
        {
            if (!(obj is Cylinder))
            {
                return false;
            }

            Cylinder other = (Cylinder)obj;
            return Radius == other.Radius && Vertex1 == other.Vertex1 && Vertex2 == other.Vertex2;
        }

        public double Height() {
            double a = Vertex1[2];
            double b = Vertex2[2];
            double height = Math.Abs(a-b);
            return height;
        }

        public double BottomArea() {
            double area = Math.PI * Math.Pow(Radius, 2);
            return area;
        }

        public double Volume() {
            double volume = BottomArea() * Height();
            return volume;
        }

        public double SurfaceArea() {
            Thread.Sleep(1000);
            double baseArea = 2 * BottomArea();
            double lateralArea = 2 * Math.PI * Radius * Height();
            double area = baseArea + lateralArea;
            return area;
        }
    }
}