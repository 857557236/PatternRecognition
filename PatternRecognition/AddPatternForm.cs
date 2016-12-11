using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using log4net;

using PatternRecognition.NeuralNetworks.Teaching;
using PatternRecognition.Tools;
using PatternRecognition.UI;
using Commons = PatternRecognition.PatternRecognitionCommons;

namespace PatternRecognition
{
    public partial class AddPatternForm : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(AddPatternForm));
        
        private LabelTable patternInputLabelTable;
        
        public AddPatternForm()
        {
            InitializeComponent();
            InitializePatternInput();
            SetGeometry();
            LoadSavedPatterns();
        }
        
        private void InitializePatternInput()
        {
            this.patternInputLabelTable = new LabelTable(Commons.PATTERN_HEIGHT, Commons.PATTERN_WIDTH, Commons.PATTERN_LABEL_SIZE, Commons.BACK_COLOR);
            this.Controls.Add(this.patternInputLabelTable);
            this.patternInputLabelTable.SetLabelMouseClickEventHandler(new MouseEventHandler(OnLabelMouseClick));
        }
        
        private void SetGeometry()
        {
            this.patternInputLabelTable.Location = new Point(20, 20);
            
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
               this.MaximizeBox = false;
               this.MinimizeBox = false;            
               this.StartPosition = FormStartPosition.CenterScreen;               
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
        }
        
        void PutPatternBtnClick(object sender, EventArgs e)
        {
            string patternName = patternNameTextBox.Text;
            if (patternName == null || patternName.Trim(' ').Length == 0)
            {
                MessageBox.Show("Pattern name is empty. Please fill the field.", "Can't add pattern");                
            } 
            else
            {
                double[] input = patternInputLabelTable.GetNetworkInput();
                PatternDictionary.GetInstance().PutPattern(patternName, input);
                if (log.IsDebugEnabled)
                    log.Debug(input.GetContentsString());
                if (!patternListBox.Items.Contains(patternName))
                    patternListBox.Items.Add(patternName);
            }
            patternNameTextBox.Text = "";
            patternInputLabelTable.SetColor(Commons.BACK_COLOR);
        }
        
        private void LoadSavedPatterns()
        {
            ICollection<string> keys = PatternDictionary.GetInstance().Entries.Keys;
            foreach (string key in keys)
            {
                patternListBox.Items.Add(key);
            }
        }
        
        void PatternListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            object selectedItem = patternListBox.SelectedItem;
            if (selectedItem != null)
            {
                string patternName = selectedItem.ToString();
                double[] pattern = PatternDictionary.GetInstance().GetTeachingPairForPattern(patternName).Input;
                patternInputLabelTable.LoadPattern(pattern);                
                patternNameTextBox.Text = patternName;
            }
        }
        
        void SavePatternsBtnClick(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to save current configuration of the dictionary?", "Save Patterns", MessageBoxButtons.YesNoCancel);
            switch (dialogResult)
            {
                case DialogResult.Yes:
                    TeachingUtils.SavePatternDictionaryToFile(Commons.DICTIONARY_FILE_NAME);
                break;
                default: return;
            }
        }
        
        void RemovePatternBtnClick(object sender, EventArgs e)
        {
            object selectedItem = patternListBox.SelectedItem;
            if (selectedItem != null)
            {
                string patternName = selectedItem.ToString();
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove the selected pattern?", "Remove Pattern", MessageBoxButtons.YesNoCancel);
                switch (dialogResult)
                {
                    case DialogResult.Yes:
                        PatternDictionary.GetInstance().RemovePattern(patternName);
                        patternListBox.Items.Remove(patternName);
                        patternInputLabelTable.Clear();
                    break;
                    default: return;
                }
            }
            else MessageBox.Show("Please select pattern to remove first.", "Remove Pattern");
        }
    }
}
