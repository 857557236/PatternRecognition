using System;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

using log4net.Config;

using PatternRecognition.NeuralNetworks.Teaching;

namespace PatternRecognition
{
    internal sealed class Program
    {
        /// <summary>
        /// Program entry point.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            SetCustomSettings();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
        
        private static void SetCustomSettings()
        {
            PatternDictionary.SetOutputSize(PatternRecognitionCommons.ONE_LAYER_NETWORK_DIM);
            TeachingUtils.LoadPatternDictionaryFromFile(PatternRecognitionCommons.DICTIONARY_FILE_NAME);
            XmlConfigurator.Configure();
            SetLocaleSettings();
        }
        
        private static void SetLocaleSettings()
        {                        
            CultureInfo customCulture = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = customCulture;
        }
    }
}
