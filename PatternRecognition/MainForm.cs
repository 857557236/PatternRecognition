using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using System.Linq;

using PatternRecognition.UI;
using Commons = PatternRecognition.PatternRecognitionCommons;
using PatternRecognition.NeuralNetworks;
using PatternRecognition.NeuralNetworks.Networks;
using PatternRecognition.NeuralNetworks.Neurons;
using PatternRecognition.NeuralNetworks.Teaching;

namespace PatternRecognition
{
    public partial class MainForm : Form
    {
        private LabelTable patternInput;
        
        private NetworkLayer oneLayerNetwork;
        private MultiLayerNetwork twoLayerNetwork;
        
        public MainForm()
        {
            InitializeComponent();
            InitializePatternInput();
            SetGeometry();
            InitializeOneLayerNetwork();
            InitializeTwoLayerNetwork();
            FillPatternComboBox();
        }
        
        private void InitializePatternInput()
        {
            this.patternInput = new LabelTable(Commons.PATTERN_HEIGHT, Commons.PATTERN_WIDTH, Commons.PATTERN_LABEL_SIZE, Commons.BACK_COLOR);
            this.Controls.Add(this.patternInput);
            this.patternInput.SetLabelMouseClickEventHandler(new MouseEventHandler(OnLabelMouseClick));
        } 
        
        private void SetGeometry()
        {
            this.patternInput.Location = new Point(20, 20);
            
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
               this.MinimizeBox = false;                     
        }
        
        private void InitializeOneLayerNetwork()
        {
            oneLayerNetwork = NeuralNetworksUtils.CreatePerceptronLayer(
                Commons.ONE_LAYER_NETWORK_DIM, Commons.NEURONS_DIM);
        }
        
        private void InitializeTwoLayerNetwork()
        {
            twoLayerNetwork = NeuralNetworksUtils.CreateTwoLayerPerceptronNetwork(
                Commons.FIRST_LAYER_DIM, Commons.SECOND_LAYER_DIM, Commons.NEURONS_DIM);
        }
        
        private void OnLabelMouseClick(object sender, MouseEventArgs e) {
            Label label = (Label)sender;            
            Color backColor = label.BackColor;
            MouseButtons pushed = e.Button;
            switch (pushed) 
            {
                case MouseButtons.Left:
                    if (backColor == Commons.BACK_COLOR)
                        backColor = Commons.PATTERN_COLOR;
                break;
                case MouseButtons.Right:
                    if (backColor == Commons.PATTERN_COLOR)
                        backColor = Commons.BACK_COLOR;
                break;
                default: break;
            }
            label.BackColor = backColor;
            recognizedByOneLayerTextBox.Text = "";
            recognizedByTwoLayerTextBox.Text = "";
        }
        
        private void FillPatternComboBox()
        {
            patternsComboBox.Items.Clear();
            patternsComboBox.Items.AddRange(PatternDictionary.GetInstance().Entries.Keys.ToArray());
        }
        
        void ManagePatternsBtnClick(object sender, EventArgs e)
        {
            AddPatternForm form = new AddPatternForm();
            form.Show();
        }
        
        void RecognizeBtnClick(object sender, EventArgs e)
        {
            PatternDictionary dict = PatternDictionary.GetInstance();
            double[] input = patternInput.GetNetworkInput();
            double[] output = oneLayerNetwork.FireSignal(input);
            string patternName = dict.FindPatternName(output);
            recognizedByOneLayerTextBox.Text = patternName != null ? patternName : "Not recognized properly";
            output = twoLayerNetwork.FireSignal(input);
            patternName = dict.FindPatternName(output);
            recognizedByTwoLayerTextBox.Text = patternName != null ? patternName : "Not recognized properly";
        }
        
        void ClearBtnClick(object sender, EventArgs e)
        {
            patternInput.Clear();
        }
        
        void TeachBtnClick(object sender, EventArgs e)
        {
            string sizeStr = teachingSetSizeTextBox.Text;
            int teachingSetSize = 100;
            try
            {
                teachingSetSize = Convert.ToInt32(sizeStr);
                if (teachingSetSize <= 0)
                    throw new FormatException();
            }
            catch (FormatException)
            {
                MessageBox.Show("Teaching set size should be a positive integer", "Wrong Teaching Set Size");
                return;
            }
            oneLayerNetwork.SetRandomWeights();
            IList<NetworkTeachingPair> teachingSet = PatternDictionary.GetInstance().GenerateTeachingSetOfSize(teachingSetSize);
            oneLayerNetwork.Teach(teachingSet, Commons.TEACHING_RATIO);
            errorProbabilityTextBox.Text = oneLayerNetwork.CalculateErrorProbability(teachingSet).ToString();
            //oneLayerNetwork.TeachContinuously(teachingSet, Commons.TEACHING_RATIO);
            MessageBox.Show("Taught successfully.", "Neural Network Training Completed");
        }
        
        void CorrectBtnClick(object sender, EventArgs e)
        {
            object selectedItem = patternsComboBox.SelectedItem;
            if (selectedItem != null && selectedItem.ToString().Trim().Length != 0)
            {
                string patternName = selectedItem.ToString();
                NetworkTeachingPair dictPair = PatternDictionary.GetInstance().GetTeachingPairForPattern(patternName);
                double[] currentPattern = patternInput.GetNetworkInput();
                oneLayerNetwork.Teach(new NetworkTeachingPair(currentPattern, dictPair.Output), Commons.TEACHING_RATIO);
                MessageBox.Show("Taught successfully.", "Correction Completed");
            }
        }
        
        void PatternsComboBoxDropDown(object sender, EventArgs e)
        {
            FillPatternComboBox();
        }
        
        void ShowBtnClick(object sender, EventArgs e)
        {
            object selectedItem = patternsComboBox.SelectedItem;
            if (selectedItem != null && selectedItem.ToString().Trim().Length != 0)
            {
                string patternName = selectedItem.ToString();
                NetworkTeachingPair dictPair = PatternDictionary.GetInstance().GetTeachingPairForPattern(patternName);
                patternInput.LoadPattern(dictPair.Input);
            }
        }
    }
}
