using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork1
{
    public class Neuron
    {
        public double Input { get; set; }
        public double Weight { get; set; }
        public double UpdatedWeight { get; set; }
        public double Gradient { get; set; }
        public double Bias { get; set; }

        public Neuron(double value, double weight)
        {
            this.Input = value;
            this.Weight = weight;
        }
        public Neuron()
        {

        }

    }
}
