using System;
using System.Collections.Generic;

using log4net;

using PatternRecognition.Tools;

namespace PatternRecognition.NeuralNetworks.Teaching
{
    public class PatternDictionary
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(PatternDictionary));
        
        private static readonly char 
            ZERO = '0',
            ONE = '1';
        
        private IDictionary<string, NetworkTeachingPair> patternToLayerTeachingPair;
        
        private static int outputSize;
        
        private static readonly PatternDictionary instance = new PatternDictionary();
        
        public static PatternDictionary GetInstance()
        {
            return instance;
        }
        
        public static void SetOutputSize(int networkOutputSize)
        {
            outputSize = networkOutputSize;
        }
        
        public IDictionary<string, NetworkTeachingPair> Entries
        {
            get { return new Dictionary<string, NetworkTeachingPair>(patternToLayerTeachingPair); }
            internal set
            {
                patternToLayerTeachingPair = new Dictionary<string, NetworkTeachingPair>(value);
            }
        }
        
        public void PutPattern(string patternName, double[] input)
        {
            NetworkTeachingPair pair = new NetworkTeachingPair(input, GeneratePerceptronOutput());
            try
            {
                patternToLayerTeachingPair.Add(patternName, pair);
            }
            catch (ArgumentException)
            {
                patternToLayerTeachingPair[patternName] = pair;
            }
            if (log.IsDebugEnabled)
                log.DebugFormat("Added pattern: {0} => {1}", patternName, pair);
        }
        
        public NetworkTeachingPair GetTeachingPairForPattern(string patternName)
        {
            try
            {
                return patternToLayerTeachingPair[patternName];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }
        
        public void RemovePattern(string patternName)
        {
            patternToLayerTeachingPair.Remove(patternName);
        }
        
        public string FindPatternName(double[] networkOutput)
        {
            foreach (var entry in patternToLayerTeachingPair)
            {
                if (entry.Value.Output.EqualsElementwise(networkOutput))
                {
                    return entry.Key;
                }
            }
            return null;
        }
        
        public IList<NetworkTeachingPair> GenerateTeachingSetOfSize(int size)
        {
            IList<NetworkTeachingPair> teachingSet = new List<NetworkTeachingPair>();
            IList<string> keys = new List<string>(patternToLayerTeachingPair.Keys);
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                string key = keys[rnd.Next(keys.Count)];
                teachingSet.Add(patternToLayerTeachingPair[key]);
            }
            return teachingSet;
        }
        
        private double[] GeneratePerceptronOutput()
        {
            double[] output = new double[outputSize];
            string binary = Convert.ToString(patternToLayerTeachingPair.Count+1, 2).PadLeft(outputSize, ZERO);
            for (int i = 0; i < outputSize; i++)
            {                
                output[i] = (binary[i] == ONE) ? 1.0 : 0.0;
            }
            return output;
        }
        
        private PatternDictionary()
        {
            patternToLayerTeachingPair = new Dictionary<string, NetworkTeachingPair>();
            outputSize = 1;
        }
    }
}
