using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork1
{
    public static class Utility
    {

        public static double Sigmoid(double value)
        {
            return 1.0 / (1.0 + Math.Exp(-value));
        }

        public static double Derivative(double value)
        {
            return Sigmoid(value) * (1 - Sigmoid(value));
        }

        public static double NextDouble()
        {
            Random random = new Random();
            return random.NextDouble();
        }




    }
}
