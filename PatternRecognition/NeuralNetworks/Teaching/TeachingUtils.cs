using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

using PatternRecognition.NeuralNetworks.Networks;
using PatternRecognition.UI;
using Commons = PatternRecognition.PatternRecognitionCommons;

namespace PatternRecognition.NeuralNetworks.Teaching
{
    public static class TeachingUtils
    {
        private static string INPUT_TAG = "Input", OUTPUT_TAG = "Output";
        
        public static void SaveTeachingSetToFile(IEnumerable<TeachingPair> teachingSet, string filename) 
        {
            using (StreamWriter writer = new StreamWriter(new FileStream(filename, FileMode.Create))) 
            {
                foreach (TeachingPair pair in teachingSet) 
                {
                    writer.WriteLine(string.Format("{0}:[{1}]|{2}:{3}", INPUT_TAG, string.Join(", ", pair.Input), 
                                                                        OUTPUT_TAG, pair.Output));
                }
            }                    
        }
        
        public static IList<TeachingPair> LoadTeachingSetFromFile(string filename) 
        {
            using (StreamReader reader = new StreamReader(new FileStream(filename, FileMode.Open))) 
            {
                IList<TeachingPair> teachingSet = new List<TeachingPair>();
                while (!reader.EndOfStream) 
                {
                    string str = reader.ReadLine();
                    TeachingPair pair = ParseTeachingPair(str);
                    teachingSet.Add(pair);
                }
                return teachingSet;
            }                                  
        }
        
        public static TeachingPair ParseTeachingPair(string str)
        {
            string[] values = str.Split('|');
            string input = values[0].TrimStart(INPUT_TAG.ToCharArray());                    
            double[] pairInput = ParseWeights(input);
            string output = values[1].TrimStart(OUTPUT_TAG.ToCharArray());
            double pairOutput = Convert.ToDouble(output);
            return new TeachingPair(pairInput, pairOutput);
        }
        
        public static double[] ParseWeights(string weights) 
        {
              string[] values = weights.TrimStart('[').TrimEnd(']').Split(' ');
              double[] result = new double[values.Length];
              for (int i = 0; i < result.Length; i++) 
              {
                result[i] = Convert.ToDouble(values[i].TrimEnd(','));
            }
            return result;
        }
        
        public static void SaveNetworkLayerWeightsToFile(NetworkLayer layer, string filename) 
        {
            using (StreamWriter writer = new StreamWriter(new FileStream(filename, FileMode.Create))) 
            {
                writer.Write(layer.ToString());
            }
        }
        
        public static IList<double[]> LoadNetworkLayerWeightsFromFile(string filename) 
        {
            using (StreamReader reader = new StreamReader(new FileStream(filename, FileMode.Open))) 
            {
                IList<double[]> weights = new List<double[]>();
                reader.ReadLine();
                while (!reader.EndOfStream) 
                {
                    string str = reader.ReadLine().TrimStart("[Neurons Weights=[".ToCharArray()).TrimEnd(']');            
                    double[] values = ParseWeights(str);
                    weights.Add(values);
                }
                return weights;
            }        
        }
        
        public static double[] GetNetworkInput(this LabelTable table)
        {
            IList<Label> labels = table.Labels;
            double[] result = new double[labels.Count];
            int i = 0;
            foreach (Label label in labels)
            {
                result[i++] = (label.BackColor == Commons.BACK_COLOR) ? -1 : 1;                
            }
            return result;
        }
        
        public static string LayerTeachingPairFileEntry(NetworkTeachingPair pair)
        {
            string input = string.Join(",", pair.Input);
            string output = string.Join(",", pair.Output);
            return string.Format("[{0}:{1}|{2}:{3}]", INPUT_TAG, input, OUTPUT_TAG, output);
        }
        
        public static KeyValuePair<string, NetworkTeachingPair> ParsePatternDictEntry(string str)
        {
            string[] patternDictEntry = str.Split(":".ToCharArray(), 2);
            string patternName = patternDictEntry[0];
            NetworkTeachingPair pair = ParseLayerTeachingPair(patternDictEntry[1]);
            return new KeyValuePair<string, NetworkTeachingPair>(patternName, pair);
        }
        
        public static NetworkTeachingPair ParseLayerTeachingPair(string str)
        {
            string[] inputAndOutput = str.TrimStart('[').TrimEnd(']').Split('|');
            string input = inputAndOutput[0].TrimStart(INPUT_TAG.ToCharArray()).TrimStart(':');
            string output = inputAndOutput[1].TrimStart(OUTPUT_TAG.ToCharArray()).TrimStart(':');
            double[] inputValues = ParseDoubles(input);
            double[] outputValues = ParseDoubles(output);
            return new NetworkTeachingPair(inputValues, outputValues);
        }
        
        public static double[] ParseDoubles(string str)
        {
            string[] inputValues = str.Split(',');
            double[] doubles = new double[inputValues.Length];
            for (int i = 0; i < doubles.Length; i++)
            {
                doubles[i] = Convert.ToDouble(inputValues[i]);
            }
            return doubles;
        }
        
        public static void SavePatternDictionaryToFile(string filename)
        {
            PatternDictionary dict = PatternDictionary.GetInstance();
            using (StreamWriter writer = new StreamWriter(new FileStream(filename, FileMode.Create))) 
            {
                foreach (var entry in dict.Entries) 
                {
                    NetworkTeachingPair pair = entry.Value;
                    writer.WriteLine(string.Format("{0}:{1}", entry.Key, LayerTeachingPairFileEntry(pair)));
                }
            }    
        }
        
        public static void LoadPatternDictionaryFromFile(string filename)
        {
            using (StreamReader reader = new StreamReader(new FileStream(filename, FileMode.Open))) 
            {
                IDictionary<string, NetworkTeachingPair> teachingSet = new Dictionary<string, NetworkTeachingPair>();
                while (!reader.EndOfStream) 
                {
                    string str = reader.ReadLine();
                    KeyValuePair<string, NetworkTeachingPair> pair = ParsePatternDictEntry(str);
                    teachingSet.Add(pair);
                }
                PatternDictionary.GetInstance().Entries = teachingSet;
            }    
        }
    }
}
