using System;
using System.Numerics;

namespace maths
{
    class Program
    {
        //f(x) = x^2 + 2x - 7
        static int QuadraticFunc(int x)
        {
            int xSqrd = x*x;
            int j = xSqrd + (2*x);
            j -= 7;
            return j;
        }
        //f(a,b,c) = (-b +\- _/b^2-4ac)/2a, if < 0 return polynomial has no roots
        static bool FindQuadraticRoot(float a, float b, float c)
        {
            float sqrdB = b * b;
            float i = sqrdB - (4 * a * c);
            double sqrt = Math.Sqrt(i);
            double posNumerator = -b + sqrt;
            double negNumerator = -b - sqrt;
            double posFrac = posNumerator / (2 * a);
            double negFrac = negNumerator / (2 * a);
            //float j = Math.Sqrt(i);
            if (posFrac < 0 && negFrac < 0)
                return false;
            else
                return true;
        }
        //𝐿(𝑠, 𝑒,𝑡) = 𝑠 + 𝑡(𝑒 − 𝑠)
        static int LinearBlend(int s,int e,int t)
        {
            //L(s,e,t) = s+t(e-s)
            int i = e - s;
            int j = t * i;
            int L = s + j;
            return L;
        }
        //𝐷(𝑃↓1, 𝑃↓2) = √(𝑥↓2 − 𝑥↓1)^2 + (𝑦↓2 − 𝑦↓1)^2
        static double PointDistance(Vector2 point1, Vector2 point2)
        {
            float xDist = (point2.X - point1.X);
            float xSqrd = xDist * xDist;
            float yDist = (point2.Y - point1.Y);
            float ySqrd = yDist * yDist;
            float distSqrd = ySqrd + xSqrd;
            double distance = Math.Sqrt(distSqrd);
            return distance;
        }
        //𝐼𝑛𝑛𝑒𝑟(𝑃,𝑄) = 𝑃↓𝑥𝑄↓𝑥 + 𝑃↓𝑦𝑄↓𝑦 + 𝑃↓𝑧𝑄↓z
        static float PointInnerProduct(Vector3 Point1, Vector3 point2)
        {
            float midX = Point1.X * point2.X;
            float midY = Point1.Y * point2.Y;
            float midZ = Point1.Z * point2.Z;
            float inner = midX + midY + midZ;
            return inner;
        }
        //𝐷(𝑃, 𝑋0) = (𝑎𝑥↓0+𝑏𝑦↓0+𝑐𝑧↓𝑜+𝑑)/√(𝑎^2+𝑏^2+𝑐^2)
        static double PointDistFromPlane(Vector4 plane, Vector3 point)
        {
            float distX = plane.X * point.X;
            float distY = plane.Y * point.Y;
            float distZ = plane.Z * point.Z;
            float numerator = distX + distY + distZ + plane.W;
            float aSqrd = plane.X * plane.X;
            float bSqrd = plane.Y * plane.Y;
            float cSqrd = plane.Z * plane.Z;
            double denominator = Math.Sqrt((aSqrd + bSqrd + cSqrd));
            return (numerator / denominator);
        }

        //𝐵(𝑡, 𝑃↓0, 𝑃↓1,𝑃↓2,𝑃↓3) = (1 − 𝑡)^3𝑃↓0 + 3(1 − 𝑡)^2𝑡𝑃↓1 + 3(1 − 𝑡)𝑡^2𝑃↓2 + 𝑡^3𝑃↓3
        static float CubicBeizerCurve(float t, float P0, float P1, float P2, float P3)
        {
            float tSqrd = t * t;
            float tCubd = tSqrd * t;

            //(1 − 𝑡)^3*𝑃↓0
            float parOne = 1 - t;
            parOne = parOne * parOne * parOne;
            parOne *= P0;

            //3(1 − 𝑡)^2𝑡𝑃↓1
            float parTwo = 1 - t;
            parTwo = parTwo * parTwo;
            parTwo *= 3;
            parTwo *= t;
            parTwo *= P1;

            //3(1 − 𝑡)𝑡^2𝑃↓2
            float parThree = 1 - t;
            parThree *= 3;
            parThree *= tSqrd;
            parThree *= P2;

            //𝑡^3𝑃↓3
            float parFour = tCubd * P3;

            float final = parOne + parTwo + parThree + parFour;
            return final;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(QuadraticFunc(5));

            if (FindQuadraticRoot(5,14,6))
                Console.WriteLine("function 2 has no roots");
            else
                Console.WriteLine("function 2 has roots");
            Console.WriteLine(LinearBlend(5,10,15));

            Vector2 pointOne = new Vector2(10, 10);
            Vector2 pointTwo = new Vector2(20, 20);
            Console.WriteLine(PointDistance(pointOne,pointTwo));

            Vector3 pointThree = new Vector3(1, 2, 8);
            Vector3 pointFour = new Vector3(1, 5, 7);
            Console.WriteLine(PointInnerProduct(pointThree,pointFour));

            Vector3 pointFive = new Vector3(15, 64, 55);
            Vector4 planeOne = new Vector4(55, 87, 64, 35);
            Console.WriteLine(PointDistFromPlane(planeOne, pointFive));
            Console.WriteLine(CubicBeizerCurve(1,2,3,4,5));
        }
    }
}
