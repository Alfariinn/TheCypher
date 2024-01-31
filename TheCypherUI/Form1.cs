using System;
using System.Windows.Forms;
using TheCypherLib;


namespace TheCypherUI
{
    public partial class MainForm : Form
    {
        private Label inputLabel;
        private Label keyLabel;
        private TextBox inputTextBox;
        private TextBox keyTextBox;
        private NumericUpDown keyNumericUpDown;
        private Button encodeButton;
        private Button decodeButton;
        private TextBox resultTextBox;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabControl cipherTabControl;

        public MainForm()
        {
            InitializeComponent();
        }



        private void InitializeComponent()
        {
            keyNumericUpDown = new NumericUpDown();
            inputTextBox = new TextBox();
            keyTextBox = new TextBox();
            encodeButton = new Button();
            decodeButton = new Button();
            resultTextBox = new TextBox();
            cipherTabControl = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            inputLabel = new Label();
            keyLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)keyNumericUpDown).BeginInit();
            cipherTabControl.SuspendLayout();
            SuspendLayout();
            // 
            // keyNumericUpDown
            // 
            keyNumericUpDown.Location = new Point(12, 167);
            keyNumericUpDown.Maximum = 34;
            keyNumericUpDown.Minimum = 1;
            keyNumericUpDown.Name = "keyNumericUpDown";
            keyNumericUpDown.Size = new Size(50, 23);
            keyNumericUpDown.TabIndex = 1;
            keyNumericUpDown.Value = 1;
            // 
            // inputTextBox
            // 
            inputTextBox.Location = new Point(12, 47);
            inputTextBox.Multiline = true;
            inputTextBox.Name = "inputTextBox";
            inputTextBox.Size = new Size(300, 100);
            inputTextBox.TabIndex = 0;
            // 
            // keyTextBox
            // 
            keyTextBox.Location = new Point(12, 167);
            keyTextBox.Name = "keyTextBox";
            keyTextBox.Size = new Size(300, 23);
            keyTextBox.TabIndex = 1;
            keyTextBox.Visible = false;
            // 
            // encodeButton
            // 
            encodeButton.Location = new Point(12, 197);
            encodeButton.Name = "encodeButton";
            encodeButton.Size = new Size(75, 23);
            encodeButton.TabIndex = 2;
            encodeButton.Text = "Encode";
            encodeButton.Click += encodeButton_Click;
            // 
            // decodeButton
            // 
            decodeButton.Location = new Point(93, 197);
            decodeButton.Name = "decodeButton";
            decodeButton.Size = new Size(75, 23);
            decodeButton.TabIndex = 3;
            decodeButton.Text = "Decode";
            decodeButton.Click += decodeButton_Click;
            // 
            // resultTextBox
            // 
            resultTextBox.Location = new Point(12, 227);
            resultTextBox.Multiline = true;
            resultTextBox.Name = "resultTextBox";
            resultTextBox.ReadOnly = true;
            resultTextBox.Size = new Size(300, 100);
            resultTextBox.TabIndex = 4;
            // 
            // cipherTabControl
            // 
            cipherTabControl.Controls.Add(tabPage1);
            cipherTabControl.Controls.Add(tabPage2);
            cipherTabControl.Controls.Add(tabPage3);
            cipherTabControl.Controls.Add(tabPage4);
            cipherTabControl.Controls.Add(tabPage5);
            cipherTabControl.Location = new Point(12, 1);
            cipherTabControl.Name = "cipherTabControl";
            cipherTabControl.SelectedIndex = 0;
            cipherTabControl.Size = new Size(300, 22);
            cipherTabControl.TabIndex = 4;
            cipherTabControl.SelectedIndexChanged += cipherTabControl_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(292, 0);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Caesar";
            tabPage1.Visible = false;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Size = new Size(292, 0);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Vigenere";
            tabPage2.Visible = false;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(292, 0);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Polybius";
            tabPage3.Visible = false;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(292, 0);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Homophonic";
            tabPage4.Visible = false;
            // 
            // tabPage5
            // 
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(292, 0);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Playfair";
            tabPage5.Visible = false;
            // 
            // inputLabel
            // 
            inputLabel.AutoSize = true;
            inputLabel.BackColor = Color.Transparent;
            inputLabel.Location = new Point(12, 27);
            inputLabel.Name = "inputLabel";
            inputLabel.Size = new Size(56, 15);
            inputLabel.TabIndex = 0;
            inputLabel.Text = "Message:";
            // 
            // keyLabel
            // 
            keyLabel.AutoSize = true;
            keyLabel.BackColor = Color.Transparent;
            keyLabel.Location = new Point(12, 147);
            keyLabel.Name = "keyLabel";
            keyLabel.Size = new Size(29, 15);
            keyLabel.TabIndex = 1;
            keyLabel.Text = "Key:";
            // 
            // MainForm
            // 
            ClientSize = new Size(322, 340);
            Controls.Add(inputLabel);
            Controls.Add(keyLabel);
            Controls.Add(keyNumericUpDown);
            Controls.Add(inputTextBox);
            Controls.Add(keyTextBox);
            Controls.Add(encodeButton);
            Controls.Add(decodeButton);
            Controls.Add(resultTextBox);
            Controls.Add(cipherTabControl);
            Name = "MainForm";
            Text = "TheCypher";
            ((System.ComponentModel.ISupportInitialize)keyNumericUpDown).EndInit();
            cipherTabControl.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private void encodeButton_Click(object sender, EventArgs e)
        {
            string inputText = inputTextBox.Text;
            string key = keyTextBox.Text;
            int keyNumeric = Convert.ToInt32(keyNumericUpDown.Value);
            string result = "";
            if (inputText != null && key != null)
            {
                switch (cipherTabControl.SelectedIndex)
                {
                    case 0: // Caesar
                        result = Caesar.Encode(inputText, keyNumeric);
                        break;
                    case 1: // Vigenere
                        result = Vigenere.Encode(inputText, key);
                        break;
                    case 2: // Polybius
                        result = Polybius.Encode(inputText, key);
                        break;
                    case 3: // Homophonic
                        result = Homophonic.Encode(inputText);
                        break;
                    case 4: // Playfair
                        result = Playfair.Encode(inputText, key);
                        break;
                }

                resultTextBox.Text = result;
            }

        }

        private void decodeButton_Click(object sender, EventArgs e)
        {
            string inputText = inputTextBox.Text;
            string key = keyTextBox.Text;
            int keyNumeric = (int)keyNumericUpDown.Value;
            string result = "";
            if (inputText != null && key != null)
            {
                switch (cipherTabControl.SelectedIndex)
                {
                    case 0: // Caesar
                        result = Caesar.Decode(inputText, keyNumeric);
                        break;
                    case 1: // Vigenere
                        result = Vigenere.Decode(inputText, key);
                        break;
                    case 2: // Polybius
                        result = Polybius.Decode(inputText, key);
                        break;
                    case 3: // Homophonic
                        result = Homophonic.Decode(inputText);
                        break;
                    case 4: // Playfair
                        result = Playfair.Decode(inputText, key);
                        break;
                }

                resultTextBox.Text = result;
            }

        }

        private void cipherTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (cipherTabControl.SelectedIndex)
            {
                case 0: // Caesar
                    keyTextBox.Visible = false;
                    keyNumericUpDown.Visible = true;
                    break;
                case 1: // Vigenere
                    keyNumericUpDown.Visible = false;
                    keyTextBox.Visible = true;
                    break;
                case 2: // Polybius
                    keyNumericUpDown.Visible = false;
                    keyTextBox.Visible = true;
                    break;
                case 3: // Homophonic
                    keyNumericUpDown.Visible = false;
                    keyTextBox.Visible = false;
                    break;
                case 4: // Playfair
                    keyNumericUpDown.Visible = false;
                    keyTextBox.Visible = true;
                    break;
            }
        }

    }
}
