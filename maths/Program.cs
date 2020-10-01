using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace maths
{
    class Program
    {
        //f(x) = x^2 + 2x - 7
        static int Func1(int i)
        {
            int x = i*i;
            int y = i * 2;
            int j = x + y;
            j -= 7;
            return j;
        }
        //f(a,b,c) = (-b +\- _/b^2-4ac)/2a, if < 0 return polynomial has no roots
        static bool Func2(float a, float b, float c)
        {
            float sqrdB = b * b;
            float i = sqrdB - (4 * a * c);
            double sqrt = Math.Sqrt(i);
            double posNumerator = -b + sqrt;
            double negNumerator = -b - sqrt;
            double posFrac = posNumerator / (2 * a);
            double negFrac = negNumerator / (2 * a);
            //float j = Math.Sqrt(i);
            int y = 0;
            if (posFrac < 0 && negFrac < 0)
                return false;
            else
                return true;
        }
        //𝐿(𝑠, 𝑒,𝑡) = 𝑠 + 𝑡(𝑒 − 𝑠)
        static int Func3(int s,int e,int t)
        {
            //L(s,e,t) = s+t(e-s)
            int i = e - s;
            int j = t * i;
            int L = s + j;
            return L;
        }
        //𝐷(𝑃↓1, 𝑃↓2) = √(𝑥↓2 − 𝑥↓1)^2 + (𝑦↓2 − 𝑦↓1)^2
        static double Func4(Vector2 point1, Vector2 point2)
        {
            float xDist = (point2.X - point1.X);
            float xSqrd = xDist * xDist;
            float yDist = (point2.Y - point1.Y);
            float ySqrd = yDist * yDist;
            float distSqrd = ySqrd + xSqrd;
            double distance = Math.Sqrt(distSqrd);
            return distance;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Func1(5));
            if (Func2(5,14,6))
                Console.WriteLine("function 2 has no roots");
            else
                Console.WriteLine("function 2 has roots");
            Console.WriteLine(Func3(5,10,15));
            Vector2 pointOne = new Vector2(10, 10);
            Vector2 pointTwo = new Vector2(20, 20);
            Console.WriteLine(Func4(pointOne,pointTwo));
        }
    }
}
