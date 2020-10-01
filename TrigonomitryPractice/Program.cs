using System;

namespace TrigonomitryPractice
{
    class Program
    {
        static void AngleFinder(float sidea,float sideb,float sidec)
        {
            //1 radian = 57.2958 degrees
            double deg = 57.2958;
            //cosA = (b^2+c^2-a^2)/2bc
            //give each side the power of 2
            float sqrA = sidea * sidea;
            float sqrB = sideb * sideb;
            float sqrC = sidec * sidec;
            //combine the numurator to the equation
            float numeratorA = (sqrB + sqrC) - sqrA;
            //
            double numA = numeratorA / (2 * sideb * sidec);
            double angleA = Math.Acos(numA);
            angleA *= deg;
            //find angle B
            double numeratorB = (sqrC + sqrA) - sqrB;
            double numB = numeratorB / (2*sidec*sidea);
            double angleB = Math.Acos(numB);
            angleB *= deg;
            //angle c is ver ease
            double angleC = 180 - angleA - angleB;
            Console.WriteLine($"Angle A:{angleA}");
            Console.WriteLine($"Angle B:{angleB}");
            Console.WriteLine($"Angle C:{angleC}");
        }
        static void Main(string[] args)
        {
            AngleFinder(6, 8, 9);
        }
    }
}
