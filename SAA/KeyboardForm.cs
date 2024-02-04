using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAA.Utilities;
using static System.Windows.Forms.DataFormats;

namespace SAA
{
    public partial class KeyboardForm : Form
    {



        //private Form1 form1Instance;

        private int cursorPosition;
        private MyList<string> parameters = new MyList<string>(5);
        private string commandMode;


        System.Windows.Forms.TextBox textBox1;
        private Form1 form1Instance;

        public KeyboardForm(Form1 form1)
        {
            InitializeComponent();
            form1Instance = form1;
        }
        public KeyboardForm()
        {
            InitializeComponent();
            //form1Instance = new Form1();
            // textBox1 = form1Instance.GetTextBox1();
        }

        public KeyboardForm(Form1 form1, TextBox textBox)
        {
            this.textBox1 = textBox;
            form1Instance = form1;
            InitializeComponent();
        }

        public void ChangePanelButtons(Panel panel, bool buttonEnabled, Color backColor, Color foreColor)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is Button button)
                {
                    button.Enabled = buttonEnabled;
                    button.BackColor = backColor;
                    button.ForeColor = foreColor;
                }
            }
        }

        private void defineButton_Click(object sender, EventArgs e)
        {
            commandMode = "DEFINE";
            ChangePanelButtons(commandsPanel, false, Color.DarkGray, Color.DimGray);
            textBox1.Text += "DEFINE func():";
            cursorPosition = textBox1.Text.Length - 3;
            ChangePanelButtons(numbersPanel, true, Color.White, Color.SteelBlue);
        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            commandMode = "SOLVE";
            ChangePanelButtons(commandsPanel, false, Color.DarkGray, Color.DimGray);
            textBox1.Text += "SOLVE func()";
            cursorPosition = textBox1.Text.Length - 2;

            ChangePanelButtons(numbersPanel, true, Color.White, Color.SteelBlue);
        }

        private void allButton_Click(object sender, EventArgs e)
        {
            commandMode = "All";
            ChangePanelButtons(commandsPanel, false, Color.DarkGray, Color.DimGray);
            textBox1.Text += "ALL func";
            cursorPosition = textBox1.Text.Length;
            ChangePanelButtons(numbersPanel, true, Color.White, Color.SteelBlue);
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            commandMode = "FIND";
            ChangePanelButtons(commandsPanel, false, Color.DarkGray, Color.DimGray);
            textBox1.Text += "FIND ";
            cursorPosition = textBox1.Text.Length;
            ChangePanelButtons(punctuationPanel, true, Color.LightSlateGray, Color.White);
            button0.Enabled = true;
            button0.BackColor = Color.LightSteelBlue;
            button1.Enabled = true;
            button1.BackColor = Color.LightSteelBlue;
        }

        private void andButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(cursorPosition, "&");
            cursorPosition++;
            textBox1.SelectionStart = cursorPosition;
        }

        private void orButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(cursorPosition, "|");
            cursorPosition++;
            textBox1.SelectionStart = cursorPosition;
        }

        private void notButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(cursorPosition, "!");
            cursorPosition++;
            textBox1.SelectionStart = cursorPosition;
        }

        private void openBracketButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(cursorPosition, "(");
            cursorPosition++;
            textBox1.SelectionStart = cursorPosition;
        }

        private void closeBracketButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(cursorPosition, ")");
            cursorPosition++;
            textBox1.SelectionStart = cursorPosition;
        }


        private void a_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(cursorPosition, "a");
            parameters.Add("a");
            cursorPosition++;
            textBox1.SelectionStart = cursorPosition;
        }

        private void b_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(cursorPosition, "b");
            parameters.Add("b");
            cursorPosition++;
            textBox1.SelectionStart = cursorPosition;
        }

        private void c_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(cursorPosition, "c");
            parameters.Add("c");
            cursorPosition++;
            textBox1.SelectionStart = cursorPosition;
        }

        private void d_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(cursorPosition, "d");
            parameters.Add("d");
            cursorPosition++;
            textBox1.SelectionStart = cursorPosition;
        }

        private void e_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(cursorPosition, "e");
            parameters.Add("e");
            cursorPosition++;
            textBox1.SelectionStart = cursorPosition;
        }

        private void f_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(cursorPosition, "f");
            parameters.Add("f");
            cursorPosition++;
            textBox1.SelectionStart = cursorPosition;
        }

        private void g_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(cursorPosition, "g");
            parameters.Add("g");
            cursorPosition++;
            textBox1.SelectionStart = cursorPosition;
        }

        private void h_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(cursorPosition, "h");
            parameters.Add("h");
            cursorPosition++;
            textBox1.SelectionStart = cursorPosition;
        }

        private void commaButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(cursorPosition, ",");
            cursorPosition++;
            textBox1.SelectionStart = cursorPosition;
        }

        private void semicolonButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(cursorPosition, ";");
            cursorPosition++;
            textBox1.SelectionStart = cursorPosition;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(cursorPosition, "0");
            cursorPosition++;
            textBox1.SelectionStart = cursorPosition;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(cursorPosition, "1");
            cursorPosition++;
            textBox1.SelectionStart = cursorPosition;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(cursorPosition, "2");
            cursorPosition++;
            textBox1.SelectionStart = cursorPosition;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(cursorPosition, "3");
            cursorPosition++;
            textBox1.SelectionStart = cursorPosition;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(cursorPosition, "4");
            cursorPosition++;
            textBox1.SelectionStart = cursorPosition;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(cursorPosition, "5");
            cursorPosition++;
            textBox1.SelectionStart = cursorPosition;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(cursorPosition, "6");
            cursorPosition++;
            textBox1.SelectionStart = cursorPosition;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(cursorPosition, "7");
            cursorPosition++;
            textBox1.SelectionStart = cursorPosition;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(cursorPosition, "8");
            cursorPosition++;
            textBox1.SelectionStart = cursorPosition;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(cursorPosition, "9");
            cursorPosition++;
            textBox1.SelectionStart = cursorPosition;
        }

    }
}
