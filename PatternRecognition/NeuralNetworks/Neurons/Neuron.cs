using System;

using PatternRecognition.NeuralNetworks.Teaching;

namespace PatternRecognition.NeuralNetworks.Neurons
{
    public abstract class Neuron
    {
        private static readonly string 
            NULL_WEIGHTS_MSG = "Null or empty weights' array is not allowed",
            WRONG_NUMBER_OF_INPUTS_ARGS_MSG = "Wrong number of inputs: {0}, expected - {1}";
        
        private double[] weights;
        private ActivationFunction func;
        private int inputDim;
        
        public abstract void Teach(TeachingPair pair, double ratio);
        
        public Neuron(int dim, ActivationFunction func) 
        {
            this.Weights = new double[dim];
            this.func = func;
            this.inputDim = dim;
        }
        
        public Neuron(double[] weights, ActivationFunction func)
        {
            this.Weights = weights;
            this.func = func;
            this.inputDim = weights.Length;
        }
        
        public void InitRandomWeights() 
        {
            Random generator = new Random();
            for (int i = 0; i < Weights.Length; i++) 
            {
                Weights[i] = generator.NextDouble() - 0.5;
            }
        }
        
        public int InputDim
        {
            get { return inputDim; }
        }
        
        public double[] Weights 
        {
            get { return weights; }
            set 
            {
                if (value == null || value.Length < 1) 
                {
                    throw new ArgumentException(NULL_WEIGHTS_MSG);
                }
                weights = value;
            }
        }
        
        public double FireSignal(params double[] args) 
        {
            if (args.Length != weights.Length)             
                throw new ArgumentException(string.Format(WRONG_NUMBER_OF_INPUTS_ARGS_MSG, args.Length, weights.Length));            
            double sum = 0;
            for (int i = 0; i < args.Length; i++) 
            {
                sum += weights[i]*args[i];
            }
            return func(sum);
        }        
        
        public override string ToString()
        {
            return string.Format("[Neuron Weights=[{0}]]", string.Join(", ", weights));
        }        
        
        protected ActivationFunction ActivationFunc 
        {
            get { return func; }
            set { func = value; }
        }
        
        protected Neuron() { }
    }
}
