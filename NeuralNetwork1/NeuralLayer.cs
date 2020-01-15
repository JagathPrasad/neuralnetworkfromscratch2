using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork1
{
    public class NeuralLayer
    {

        public List<Neuron> neurons = new List<Neuron>();
        public double Output;

        public NeuralLayer()
        {

        }
        public NeuralLayer(int neuronCount)
        {
            for (int i = 0; i < neuronCount; i++)
            {
                Neuron neuron = new Neuron();
                neuron.Input = Utility.NextDouble();
                neuron.Weight = Utility.NextDouble();
                neurons.Add(neuron);
            }
        }
    }
}
