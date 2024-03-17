using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradientDescentStuff
{
    public class NeuralNetwork
    {
        public Layer[] layers;
        ErrorFunction errorFunc;

        public NeuralNetwork(ActivationFuncs activation, ErrorFunction errorFunc, params int[] neuronsPerLayer)
        {
            layers = new Layer[neuronsPerLayer.Length];
            for (int i = 0; i < layers.Length; i++)
            {
                if(i == 0)
                {
                    layers[0] = new Layer(activation, neuronsPerLayer[0], null);
                    continue;
                }
                layers[i] = new Layer(activation, neuronsPerLayer[i], layers[i - 1]);
            }
            this.errorFunc = errorFunc;
        }
        
        public void Randomize(double min, double max) 
        { 
            for (int i = 0; i < layers.Length; i++)
            {
                if(i != 0)
                {
                    layers[i].Randomize(min, max);
                }
            }
        }
        public void ApplyUpdates() 
        {

        }
        void Backprop(double learningRate, double[] desiredOutputs)
        {

        }

        /*
         * The computation of the neural network will occur layer by layer. Starting with the input layer and propagating
         * forward until the output layer is calculated. 
         * First the input layer is set to the input values; Each layer after will compute its output in order until the output layer. 
         * The output of the output layer is the output of the entire neural network.
         */
        public double[] Compute(double[] inputs) 
        {
            double[] output = null;
            if (inputs.Length != layers[0].Neurons.Length) return null;
            for(int i = 0;i < layers[0].Neurons.Length;i++)
            {
                layers[0].Neurons[i].Output = inputs[i]; 
            }
            for (int i = 1; i < layers.Length; i++)
            {
                output = layers[i].Compute();
            }
            return output;
        }
        public double GetError(double[] desiredOutputs, double[] inputs) 
        {
            double sum = 0.0;
            double[] actualOutput = Compute(inputs);
            for (int i = 0; i < desiredOutputs.Length; i++)
            {
                sum += errorFunc.Function(actualOutput[i], desiredOutputs[i]);
            }
            return sum / desiredOutputs.Length;
        }
    }
}
