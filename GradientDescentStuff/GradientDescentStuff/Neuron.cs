using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradientDescentStuff
{
    public class Neuron
    {
        public double bias;
        public Dendrite[] dendrites;
        public double Output { get; set; }
        public double Input { get; private set; }
        public double Delta { get; set; }
        double biasUpdate;
        public ActivationFuncs Activation { get; set; }
        Random random = new Random();

        public Neuron(ActivationFuncs activation)
        {
            Activation = activation;
        }
        public Neuron(ActivationFuncs activation, Neuron[] previousNerons) 
        {
            Activation = activation;
            dendrites = new Dendrite[previousNerons.Length];

            for (int i = 0; i < dendrites.Length; i++)
            {
                dendrites[i] = new Dendrite(previousNerons[i],this,0);
            }
            Randomize(-1,1);
        }
        public Neuron(double input)
        {
            Input = input;
            Output = input;
        }
        public void Randomize(double min, double max) //Set Up dendrites
        {
            for (int i = 0; i < dendrites.Length; i++)
            {
                dendrites[i].Weight = GenerateRandomDouble(min, max);
            }
            bias = GenerateRandomDouble(min, max);
        }
        public void ApplyUpdates() 
        {

        }
        public void Backprop(double learningRate) 
        { 

        }
        private double GenerateRandomDouble( double min, double max) => random.NextDouble() * (max - min) + min;
        
        //should compute the Input by summing the outputs of the dendrites and the bias,
        //and the Output by putting the input through the activation function. The Output is returned.
        public double Compute()       
        {
            double input = bias;
            foreach(var dendrite in dendrites)
            {
                input += dendrite.Compute();
            }
            Input = input;
            Output = Activation.Function(input);
            return Output;
        }
    }
}
