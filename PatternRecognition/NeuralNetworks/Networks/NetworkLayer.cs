using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

using PatternRecognition.NeuralNetworks.Neurons;
using PatternRecognition.NeuralNetworks.Teaching;

using PatternRecognition.Tools;

namespace PatternRecognition.NeuralNetworks.Networks
{
    public class NetworkLayer
    {        
        private const double TEACHING_RATIO_CHANGE = 0.99;
        
        private const string EMPTY_LAYER_MSG = "Empty or null neurons' collection is not allowed.",
                             MISALIGNED_NEURONS_MSG = "Neurons have different dimensions, cannot be wrapped in a neural network layer",
                             MISALIGNED_TEACHING_PAIR_MSG = "Non-equal neurons' and teaching pair dimensions: {0} and {1}";
                             
        private IList<Neuron> neurons;
        private int inputDim;
            
        public static NetworkLayer Of(IList<Neuron> neurons) 
        {            
            if (neurons == null || neurons.Count < 1) 
            {
                throw new ArgumentException(EMPTY_LAYER_MSG);
            }
            if (!AreOfConsistentDimension(neurons)) 
            {
                throw new ArgumentException(MISALIGNED_NEURONS_MSG);
            }
            NetworkLayer layer = new NetworkLayer();
            layer.neurons = neurons;
            layer.NeuronInputDimension = neurons.First().InputDim;
            return layer;
        }
        
        public void SetRandomWeights()
        {
            foreach (var neuron in neurons)
            {
                neuron.InitRandomWeights();
            }
        }
        
        public int NeuronInputDimension 
        {
            get { return inputDim; }
            private set { inputDim = value; } 
        }
        
        public int Size
        {
            get { return neurons.Count; }
        }
        
        public Neuron this[int index] 
        {
            get { return neurons[index]; }
        }
        
        public double[] FireSignal(params double[] args) 
        {
            double[] signal = new double[neurons.Count];
            for (int i = 0; i < signal.Length; i++) 
            {
                signal[i] = neurons[i].FireSignal(args);
            }
            return signal;
        }
        
        public void Teach(IEnumerable<NetworkTeachingPair> teachingSet, double ratio)
        {
            foreach (NetworkTeachingPair pair in teachingSet) 
            {
                Teach(pair, ratio);
            }
            ratio *= TEACHING_RATIO_CHANGE;
        }
        
        public void TeachContinuously(IEnumerable<NetworkTeachingPair> teachingSet, double ratio)
        {
            while (!IsSuccessfullyTaught(teachingSet)) 
            {
                Teach(teachingSet, ratio);
            }
        }
        
        public void Teach(NetworkTeachingPair pair, double ratio) 
        {
            if (NeuronInputDimension != pair.Input.Length) 
            {
                throw new ArgumentException(string.Format(MISALIGNED_TEACHING_PAIR_MSG, NeuronInputDimension, pair.Input.Length));
            }
            IList<TeachingPair> teachingPairs = pair.DecomposeToTeachingPairs();
            for (int i = 0; i < neurons.Count; i++) 
            {
                neurons[i].Teach(teachingPairs[i], ratio);
            }
        }
        
        public bool IsSuccessfullyTaught(IEnumerable<NetworkTeachingPair> teachingSet) 
        {
            foreach (NetworkTeachingPair pair in teachingSet) 
            {
                if (!FireSignal(pair.Input).EqualsElementwise(pair.Output))
                {
                    return false;
                }
            }
            return true;
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Neural network layer:\n");
            foreach (Neuron neuron in neurons) 
            {
                sb.Append(neuron.ToString()).Append("\n");
            }
            return sb.Remove(sb.Length - 1, 1).ToString();
        }

        private static bool AreOfConsistentDimension(IList<Neuron> neurons) 
        {
            int dim = neurons.First().InputDim;
            foreach (Neuron neuron in neurons) 
            {
                if (neuron.InputDim != dim) 
                {
                    return false;
                }
            }
            return true;
        }
        
        protected NetworkLayer() { }
    }
}
