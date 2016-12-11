using System;
using System.Collections.Generic;
using System.Diagnostics;
using PatternRecognition.NeuralNetworks.Teaching;

namespace PatternRecognition.NeuralNetworks.Neurons
{
    public class Perceptron: Neuron
    {
        private const double TEACHING_RATIO_CHANGE = 0.99;
        
        public Perceptron(int dim)
            :base(dim, s => (s >= 0) ? 1 : 0) { }
        
        public Perceptron(double[] weights)
            :base(weights, s => (s >= 0) ? 1 : 0) { }
        
        public void Teach(IEnumerable<TeachingPair> teachingSet, double ratio) 
        {
            foreach (TeachingPair pair in teachingSet) 
            {
                Teach(pair, ratio);
            }
        }
        
        public void TeachContinuously(IEnumerable<TeachingPair> teachingSet, double ratio)
        {
            while (!IsSuccessfullyTaught(teachingSet)) 
            {
                Teach(teachingSet, ratio);
            }
        }
        
        public override void Teach(TeachingPair pair, double ratio) 
        {
            double result = FireSignal(pair.Input);
            if (result != pair.Output) {
                double error = pair.Output - result;
                ChangeWeights(pair.Input, error, ratio);
            }
        }
        
        public bool IsSuccessfullyTaught(IEnumerable<TeachingPair> teachingSet) 
        {
            foreach (TeachingPair pair in teachingSet) 
            {
                if (FireSignal(pair.Input) != pair.Output) 
                {
                    return false;
                }
            }
            return true;
        }
        
        private void ChangeWeights(double[] args, double error, double teachingRatio) 
        {
            for (int i = 0; i < Weights.Length; i++) 
            {
                Weights[i] = Weights[i] + teachingRatio*error*args[i];
            }
        }
    }
}
