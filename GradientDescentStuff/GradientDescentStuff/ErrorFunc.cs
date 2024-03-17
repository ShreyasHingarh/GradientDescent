using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradientDescentStuff
{
    public class ErrorFunction
    {
        public Func<double, double, double> Function { get; init; }
        public Func<double, double, double> Derivative { get; init; }
        public ErrorFunction() { }
        public ErrorFunction(Func<double, double, double> function, Func<double, double, double> derivative)
        {
            Function = function;
            Derivative = derivative;
        }
        public static ErrorFunction ErrorSquared = new ErrorFunction()
        {
            Function = (a, d) => Math.Pow(a - d, 2),
            Derivative = (a, d) => 2 * (a - d)
        };
        public static ErrorFunction ErrorAbs = new ErrorFunction()
        {
            Function = (a, d) => Math.Abs(a - d),
            Derivative = (a, d) => a >= d ? a : -a
        };


    }
}
