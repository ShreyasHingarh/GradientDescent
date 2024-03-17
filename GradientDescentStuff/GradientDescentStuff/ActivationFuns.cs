using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradientDescentStuff
{
    public class ActivationFuncs
    {
        public Func<double, double> Function { get; init; }
        public Func<double, double> Derivative { get; init; }

        private ActivationFuncs() { }
        public ActivationFuncs(Func<double, double> function, Func<double, double> derivative)
        {
            Function = function;
            Derivative = derivative;
        }

        public static ActivationFuncs BinaryStep = new ActivationFuncs()
        {
            Function = a => a < 0 ? 0 : 1,
            Derivative = _ => 0
        };
        public static ActivationFuncs Sigmoid = new ActivationFuncs()
        {
            Function = a => 1 / (1 + Math.Pow(Math.E, -a)),
            Derivative = a => Sigmoid.Function(a) * (1 - Sigmoid.Function(a))
        };
        public static ActivationFuncs TanH = new ActivationFuncs()
        {
            Function = a => (Math.Pow(Math.E, a) - Math.Pow(Math.E, -a)) / (Math.Pow(Math.E, a) + Math.Pow(Math.E, -a)),
            Derivative = a => 1 - Math.Pow(TanH.Function(a), 2)
        };

    }
}
