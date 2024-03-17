using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradientDescentStuff
{
    public class Layer
    {
        public Neuron[] Neurons { get; }
        public double[] Outputs { get; set; }

        public Layer(ActivationFuncs activation, int neuronCount, Layer previousLayer) 
        {
            Neurons = new Neuron[neuronCount];
            Outputs = new double[neuronCount];
            if(previousLayer == null)
            {
                for (int i = 0; i < Neurons.Length; i++)
                {
                    Neurons[i] = new Neuron(activation);
                }
            }
            else
            {
                for (int i = 0; i < Neurons.Length; i++)
                {
                    Neurons[i] = new Neuron(activation, previousLayer.Neurons);
                }
            }
        }
        public void Randomize(double min, double max) 
        {
            for(int i = 0;i < Neurons.Length;i++)
            {
                Neurons[i].Randomize(min, max);
            }
        }
        public void ApplyUpdates() 
        {

        }
        public void Backprop(double learningRate) 
        {
            /* Backprops all of the layer's neurons */ 
        }
        public double[] Compute() 
        {
            for (int i = 0; i < Neurons.Length; i++)
            {
                Outputs[i] = Neurons[i].Compute();
            }
            return Outputs;
        }
    }
}
