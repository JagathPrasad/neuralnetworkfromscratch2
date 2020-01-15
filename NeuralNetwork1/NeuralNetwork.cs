using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork1
{
    public class NeuralNetwork
    {
        public NeuralLayer[] layers;

        List<double[]> inputs = new List<double[]>();
        double[] input1 = new double[] { 0, 0 };
        double[] input2 = new double[] { 0, 1 };
        double[] input3 = new double[] { 1, 0 };
        double[] input4 = new double[] { 1, 1 };

        //XOR Gate Outputs
        double[] expectedOutput = new double[4] { 0, 1, 1, 0 };

        //AND Gate Outputs
        //double[] expectedOutput = new double[4] { 0, 0, 0, 1 };


        //OR Gate Outputs
        //double[] expectedOutput = new double[4] { 0, 1, 1, 1 };

        public NeuralNetwork()
        {
            int i = 0;
            inputs.Add(input1);
            inputs.Add(input2);
            inputs.Add(input3);
            inputs.Add(input4);
            layers = new NeuralLayer[3];
            layers[0] = new NeuralLayer(2);//input layer with 2 neuron
            layers[1] = new NeuralLayer(6);//hidden layer with 6 neuron
            layers[2] = new NeuralLayer(1);//output layer with 1 neuron
            Console.WriteLine("Output Before Training");
            foreach (var input in inputs)
            {
                var output = FeedForward(input);
                Console.WriteLine($"Output {layers[2].Output}");
            }
            while (i < 100000)
            {
                this.Train();
                i++;
            }
            Console.WriteLine("Output After Traingin");
            foreach (var input in inputs)
            {
                var output = FeedForward(input);
                Console.WriteLine($"Output {layers[2].Output}");
            }
            Console.ReadLine();
        }
        public void Train()
        {
            int i = 0;
            foreach (var input in inputs)
            {
                var output = this.FeedForward(input);
                this.BackPropagate(0.05, expectedOutput[i]);
                i++;
            }
        }


        /// <summary>
        /// Feed Forward
        /// </summary>
        public double FeedForward(double[] input)
        {
            double sum = 0;
            for (int a = 0; a < layers[0].neurons.Count; a++)
            {
                layers[0].neurons[a].Input = input[a];
            }
            for (int i = 0; i < layers.Length; i++)
            {
                for (int j = 0; j < layers[i].neurons.Count; j++)
                {
                    sum = sum + (layers[i].neurons[j].Input * layers[i].neurons[j].Weight);
                }
                sum = Utility.Sigmoid(sum);
                layers[i].Output = sum;
            }
            //layers[2].Output = sum;
            return sum;
        }

        /// <summary>
        /// BackPropagation
        /// </summary>
        public void BackPropagate(double learningRate, double expectedOutput)
        {
            double error;
            //output layer to hidden layer
            for (int i = 0; i < layers[1].neurons.Count; i++)
            {
                var output = layers[1].Output;
                var delta = (output - expectedOutput) * (output * (1 - output));
                layers[1].neurons[i].Gradient = delta;
                error = delta * layers[2].Output;
                layers[1].neurons[i].UpdatedWeight = layers[1].neurons[i].Weight - (learningRate * error);
            }
            //hidden layer to input layer
            //for (int j = 1; j <= layers.Length; j--)
            //{
            for (int k = 0; k < layers[0].neurons.Count; k++)
            {
                var output = layers[0].Output;
                var gradient = UpdateGradient(layers[0].neurons[k].Weight, layers[1].neurons[k].Gradient);// layers[0].neurons[k].Weight + layers[1].neurons[k].Gradient;
                var delta = (gradient) * (output * (1 - output));
                layers[0].neurons[k].Gradient = delta;
                error = delta * layers[1].Output;
                layers[0].neurons[k].UpdatedWeight = layers[0].neurons[k].Weight - (learningRate * error);
            }
            //}
            //update weights
            this.UpdateWeights();
        }

        /// <summary>
        /// Updating the Weights.
        /// </summary>
        public void UpdateWeights()
        {
            for (int i = 0; i < layers.Length; i++)
            {
                for (int j = 0; j < layers[i].neurons.Count; j++)
                {
                    layers[i].neurons[j].Weight = layers[i].neurons[j].UpdatedWeight;
                }
            }
        }

        public double UpdateGradient(double weight, double graident)
        {
            double gradientSum = 0;
            for (int i = 0; i < layers[0].neurons.Count; i++)
            {
                gradientSum = gradientSum + weight * graident;// layers[0].neurons[k].Weight + layers[1].neurons[k].Gradient;
            }
            return gradientSum;
        }
    }
}
