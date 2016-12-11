using System;
using PatternRecognition.NeuralNetworks.Teaching;

namespace PatternRecognition.NeuralNetworks.Neurons
{
    public class MemoryNeuron : Neuron
    {
        private static readonly string 
            TEACHING_NOT_SUPPORTED_MSG = "Memory neurons are not to be taught, they are for memorization. Use 'Memorize' method instead of 'Teach'";
        
        private double previousSignal;
        
        public static MemoryNeuron Create(int dim) 
        {
            MemoryNeuron neuron = new MemoryNeuron();
            neuron.previousSignal = -1;
            neuron.ActivationFunc = s => (s > 0) ? 1 : (s < 0) ? -1 : neuron.previousSignal;
            neuron.Weights = new double[dim];
            return neuron;
        }
        
        public double PreviousSignal 
        {
            get { return previousSignal; }
            internal set 
            {
                previousSignal = value;
            }
        }
        
        public override void Teach(TeachingPair pair, double ratio) 
        {
            throw new NotSupportedException(TEACHING_NOT_SUPPORTED_MSG);
        }
        
        protected MemoryNeuron()
            :base() { }
    }
}
