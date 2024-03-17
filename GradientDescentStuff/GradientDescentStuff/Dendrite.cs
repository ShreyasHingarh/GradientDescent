namespace GradientDescentStuff
{ 
    public class Dendrite
    {
        public Neuron Previous { get; }
        public double WeightUpdate { get; set; }
        public Neuron Next { get; }
        public double Weight { get; set; }

        public Dendrite(Neuron previous, Neuron next, double weight) 
        { 
            Previous = previous;
            Next = next;
            Weight = weight;
        }
        public double Compute() => Previous.Output * Weight;
        public void ApplyUpdates() 
        {
        }
    }
}