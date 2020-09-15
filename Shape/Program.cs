using System;

namespace Shape
{
    public abstract class Shape
    {
        public abstract float CalcArea();
        protected abstract bool Judge();
        public Shape(int edgeNum,int[] edges)
        {
            EdgeNum = edgeNum;
            Edges = edges;
            if (!Judge())
            {
                throw new Exception("Invalid Shape !");
            }
        }
        protected int EdgeNum;
        protected int[] Edges;
    }
    public class Rect : Shape 
    {
        public Rect(int edgeNum,int[] edges) : base(edgeNum,edges)
        {
            
        }
        public override float CalcArea()
        {
            return Edges[0] * Edges[1];
        }
        protected override bool Judge()
        {
            if(EdgeNum != 4)
            {
                return false;
            }
            foreach(var c in Edges)
            {
                if(c <= 0)
                {
                    return false;
                }
            }
            if(Edges[0] != Edges[2] || Edges[1] != Edges[3])
            {
                return false;
            }
            return true;
        }
    }

    public class Squre : Rect
    {
        public Squre(int edgeNum,int[] edges) : base(edgeNum, edges)
        {
            
        }
        protected override bool Judge()
        {
            if (!base.Judge()) return false;
            if(Edges[0] != Edges[1])
            {
                return false;
            }
            return true;
        }
    }

    public static class ShapeFactory
    {
        public enum ShapeName
        {
            Rect,
            Triangle,
            Squre
        }
        public static Shape GenRandomShape()
        {
            Func<int,int,int> getRandom = (low,high) =>
            {
                Random random = new Random();
                return low + random.Next() % (high - low);
            };
            ShapeName shape = (ShapeName)(getRandom(0,3));
            int edgeNum;
            int[] edges;
            Shape s;
            switch (shape)
            {
                case ShapeName.Rect:
                    edgeNum = 4;
                    int w = getRandom(0,100), h = getRandom(0,100);
                    edges = new int[]{ w,h,w,h};
                    s = new Rect(edgeNum, edges);
                    break;
                case ShapeName.Triangle:
                    edgeNum = 3;
                    int a = getRandom(0, 100), b = getRandom(0, 100), c = getRandom(Math.Abs(a - b), a + b);
                    edges = new int[] { a, b, c };
                    s = new Triangle(edgeNum, edges);
                    break;
                case ShapeName.Squre:
                    edgeNum = 4;
                    int l = getRandom(0,100);
                    edges = new int[] { l, l, l, l };
                    s = new Squre(edgeNum, edges);
                    break;
                default:
                    throw new Exception();
            }
            return s;
        }
        public static Shape[] GenRandomShapes(int num)
        {
            Shape[] shapes = new Shape[num];
            for(int i = 0; i < num; i++)
            {
                shapes[i] = GenRandomShape();
            }
            return shapes;
        }
    }

    public class Triangle : Shape
    {
        public Triangle(int edgeNum, int[] edges) : base(edgeNum, edges)
        {
            
        }
        public override float CalcArea()
        {
            float p = (Edges[0] + Edges[1] + Edges[2]) / 2;
            double area = Math.Sqrt(p * (p - Edges[0]) * (p - Edges[1]) * (p - Edges[2]));
            return (float)area;
        }
        protected override bool Judge()
        {
            if(EdgeNum != 3)
            {
                return false;
            }
            for(int i = 0; i < 3; i++)
            {
                int j = (i + 2) % 3;
                int k = (i + 1) % 3;
                if(Edges[i] + Edges[k] < Edges[j])
                {
                    return false;
                }
                if(Edges[i] - Edges[k] > Edges[j])
                {
                    return false;
                }
            }
            return true;
        }
     
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            int[] RectEdges = { 1, 2, 1, 2 };
            Rect r = new Rect(4,RectEdges);


            int[] SqureEdges = { 1, 1, 1, 1 };
            Squre s = new Squre(4, SqureEdges);


            int[] TriangleEdges = { 3, 4, 5 };
            Triangle t = new Triangle(3, TriangleEdges);

            Shape[] shapes = ShapeFactory.GenRandomShapes(10);
            float sumArea = 0;
            foreach(var shape in shapes)
            {
                sumArea += shape.CalcArea();
            }
            Console.WriteLine($"sum area of 10 shapes is {sumArea}");
        }
    }
}
