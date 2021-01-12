using System;
using System.Collections.Generic;

namespace IntegerCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string expression = "2*x + 4*y + 5";
            List<string> variables = new List<string>() { new string("y"),new string("x")};
            List<double> begin = new List<double>() { 0,0 };
            List<double> end = new List<double>() { 5,6 };
            double step = 0.01;

            double result = Integer.Solve(expression,variables,begin,end,step);
            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
