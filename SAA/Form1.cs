using System.Reflection.Emit;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using SAA.BinaryTree;
using SAA.BinaryTree;
using SAA;
using SAA.Function;
using SAA.Utilities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using SAA.LogicalExpression.DEFINE;
using System;
using System.ComponentModel.Design.Serialization;
using System.Windows.Forms;
using System.Data;
using SAA.Services;
using System.Data.Common;
using SAA.LogicalExpressionOperations.FIND;
using System.Drawing.Drawing2D;
using SAA.LogicalExpressionOperations.ALL;
using System.Diagnostics;

namespace SAA
{
    public partial class Form1 : Form
    {
        private KeyboardForm keyboardForm;
        private TreeForm treeForm;


        public int cursorPosition;
        private MyList<string> parameters = new MyList<string>(5);
        private string commandMode;

        public static MyList<DefinedFunction> _definedFunctions = new(5);
        MyHashTable<string, Node> hashTable = new MyHashTable<string, Node>(_definedFunctions.Count);

        public HashSet<Node> solvedNodes = new HashSet<Node>();

        TreeBuilder treeBuilder = new TreeBuilder();

        TreeSolver treeSolver = new TreeSolver();
        FunctionTruthTable truthTableGenerator = new FunctionTruthTable();
        HeuristicMethodFind exhaustiveSearch = new HeuristicMethodFind();


        private DataTable truthTableDataTable = new DataTable();

        public Form1()
        {
            InitializeComponent();
            keyboardForm = new KeyboardForm();
            treeForm = new TreeForm();


        }
        public TextBox GetTextBox1()
        {
            return textBox1;
        }

        private void keyboardToolStripMenuItem_Click(object sender, EventArgs e)
        {

            keyboardForm.Show();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (infoLabel.Visible)
            {
                infoLabel.Visible = false;
            }
            else
            {
                infoLabel.Visible = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            definedFunctionsListBox.Items.Add("Defined functions:");
            solvedFunctionsListBox.Items.Add("Solved functions:");


        }
        private void UpdateDefinedFunctionsListBox()
        {
            definedFunctionsListBox.Items.Clear();
            definedFunctionsListBox.Items.Add("Defined functions:");
            for (int i = 0; i < _definedFunctions.Count; i++)
            {
                var definedFunction = _definedFunctions.GetElementAt(i);
                int index = i + 1;
                definedFunctionsListBox.Items.Add($"{index}. {definedFunction.ToString()}");
            }
        }

        private void keyboardToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenKeyboardForm();
        }
        private void OpenKeyboardForm()
        {
            KeyboardForm keyboardForm = new KeyboardForm(this, textBox1); 
            keyboardForm.TopMost = true; 
            keyboardForm.Show();

        }
        private void infoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (infoLabel.Visible)
            {
                infoLabel.Visible = false;
            }
            else
            {
                infoLabel.Visible = true;
            }
        }
        private void deleteTextButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            cursorPosition = 0;
            parameters.Clear();
            keyboardForm.ChangePanelButtons(keyboardForm.commandsPanel, true, Color.SteelBlue, Color.White);
            keyboardForm.ChangePanelButtons(keyboardForm.numbersPanel, false, Color.DarkGray, Color.DimGray);
            keyboardForm.ChangePanelButtons(keyboardForm.lettersPanel, false, Color.DarkGray, Color.DimGray);
            keyboardForm.ChangePanelButtons(keyboardForm.operatorsPanel, false, Color.DarkGray, Color.DimGray);
            keyboardForm.ChangePanelButtons(keyboardForm.punctuationPanel, false, Color.DarkGray, Color.DimGray);
            keyboardForm.ChangePanelButtons(keyboardForm.bracketsPanel, false, Color.DarkGray, Color.DimGray);

        }
        private void UpdateSolvedFunctionsListBox(DefinedFunction function, string[] argumentValues, bool result)
        {
            string replacedBody = function.Body;
            for (int i = 0; i < argumentValues.Length; i++)
            {
                string variableName = function.Operands[i];
                string variableValue = argumentValues[i];
                replacedBody = MyMethods.Replace(replacedBody, variableName, variableValue);
            }

            string functionString = $"{function.Name}({string.Join(",", argumentValues)}): {replacedBody} --> result: {result}";

            solvedFunctionsListBox.Items.Add(functionString);

        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Height = 27;

                string userInput = textBox1.Text;
                string[] lines = MyMethods.Split(MyMethods.RemoveChar(MyMethods.RemoveChar(userInput, ';'),'\r'),'\n');
                string firstLine = lines[0];

                string[] userInputParts = MyMethods.SplitIntoParts(textBox1.Text, 2, ' ');

                if (MyMethods.ConvertLetterCase(userInputParts[0], "upper") == "DEFINE")
                {
                    var newFunction = new DefinedFunction(MyMethods.ConvertLetterCase(userInputParts[1], "lower"));

                    _definedFunctions.Add(newFunction);
                    
                    textBox1.Clear();
                    UpdateDefinedFunctionsListBox();
                }

                MyHashTable<string, Node> hashTable = new MyHashTable<string, Node>(_definedFunctions.Count);
                foreach (DefinedFunction f in _definedFunctions)
                {
                    MyList<Token> tokens = f.Tokens;

                    MyList<Token> postokens = ConvertNotation.ToPostfix(tokens);


                    Node root = TreeBuilder.BuildTree(postokens, _definedFunctions);
                    string rootValue = root.nodeValue;
                    Node leftChild = root.GetLeftChild();
                    string lValue = leftChild.nodeValue;
                    Node rightChild = root.GetRightChild();
                    string rValue = rightChild.nodeValue;

                    hashTable.Add(f.Name, root);
                    var value = hashTable.GetValue(f.Name);

                    MyList<string> operands = f.Operands;
                    int operandsCount = operands.Count;
                }

                if (MyMethods.ConvertLetterCase(userInputParts[0], "upper") == "SOLVE")
                {
                    string funcName = MyMethods.SplitIntoParts(userInputParts[1], 2, '(')[0];
                    DefinedFunction function = MyMethods.SearchForFunction(funcName, _definedFunctions);
                    string body = MyMethods.SearchForFunction(funcName, _definedFunctions).Body;
                    string[] boo = function.LastBoolArguments;
                    Node root = hashTable.GetFunction(funcName).GetValue();

                    MyList<string> funcOperands = MyMethods.SearchForFunction(funcName, _definedFunctions).Operands;
                    int operandsCount = funcOperands.Count;

                    string[] funcBoolsArray = MyMethods.Split(MyMethods.RemoveChar(MyMethods.SplitIntoParts(userInputParts[1], 2, '(')[1], ')'), ',');

                    bool result = treeSolver.SolveFunction(function, funcBoolsArray, _definedFunctions);
                    textBox1.Clear();
                    UpdateSolvedFunctionsListBox(function, funcBoolsArray, result);
                }
                else if (MyMethods.ConvertLetterCase(userInputParts[0], "upper") == "ALL")
                {

                    string funcName = MyMethods.ConvertLetterCase(userInputParts[1], "lower");
                    DefinedFunction function = MyMethods.SearchForFunction(funcName, _definedFunctions);

                    if (function != null)
                    {
                        dataGridView1.Visible = true;

                        DisplayTruthTable(function);
                    }
                    else
                    {
                        MessageBox.Show($"Function '{funcName}' not found.");
                    }
                    textBox1.Clear();
                }
                else if (MyMethods.ConvertLetterCase(userInputParts[0], "upper") == "REMOVE")
                {
                    string funcNameToRemove = MyMethods.ConvertLetterCase(userInputParts[1], "lower");


                    int indexToRemove = -1;
                    for (int i = 0; i < _definedFunctions.Count; i++)
                    {
                        if (MyMethods.ConvertLetterCase(_definedFunctions.GetElementAt(i).Name, "lower") == funcNameToRemove)
                        {
                            indexToRemove = i;
                            break;
                        }
                    }

                    if (indexToRemove != -1)
                    {
                        _definedFunctions.RemoveAt(indexToRemove);

                        UpdateDefinedFunctionsListBox();

                        textBox1.Clear();
                    }
                }
                
                else if (MyMethods.ConvertLetterCase(MyMethods.SplitIntoParts(firstLine, 2, ' ')[0], "upper") == "FIND")
                {
                    string filePath = MyMethods.SplitIntoParts(userInputParts[1], 2, ' ')[0];

                    string operandsArray;
                    int numFunc;
                    string foundFunctionString;
                    DefinedFunction foundFunction;
                    string foundFunctionExpressionString = "";

                    if (File.Exists(filePath))
                    {
                        string[] fileLines = File.ReadAllLines(filePath);
                       
                        int columns = MyMethods.Split(fileLines[0], ',', ':').Length;
                        string[,] fileTruthTable = new string[fileLines.Length, columns];

                        for (int i = 0; i < fileLines.Length; i++)
                        {
                            string[] lineValues = MyMethods.Split(MyMethods.RemoveChar(fileLines[i],';'), ',', ':');
                            for (int j = 0; j < columns; j++)
                            {
                                fileTruthTable[i, j] = lineValues[j];
                            }
                        }
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();
                        do
                        {
                           
                            string result = exhaustiveSearch.FindFitestBooleanExpression(fileTruthTable, _definedFunctions);
                            foundFunctionExpressionString = exhaustiveSearch.FindFitestBooleanExpression(fileTruthTable, _definedFunctions);
                        }
                        while (foundFunctionExpressionString == "");
                        stopwatch.Stop();
                        double elapsedSeconds = stopwatch.Elapsed.TotalSeconds;
                       // double elapsedMilliseconds = stopwatch.Elapsed.TotalMilliseconds;

                        operandsArray = MyMethods.GenerateOperands(fileTruthTable.GetLength(1) - 1);
                        numFunc = _definedFunctions.Count + 2;
                        foundFunctionString = $"func{numFunc}({operandsArray}):{foundFunctionExpressionString}";
                        foundFunction = new DefinedFunction(foundFunctionString);

                        _definedFunctions.Add(foundFunction);

                        UpdateDefinedFunctionsListBox();
                        textBox1.Clear();
                    }
                    else
                    {

                        string[] tableDataLines = new string[lines.Length - 1];
                        for (int i = 1; i < lines.Length; i++)
                        {
                            tableDataLines[i - 1] = lines[i];
                        }

                        int cols = MyMethods.Split(tableDataLines[0], ',', ':').Length;
                        string[,] truthTable = new string[tableDataLines.Length, cols];

                        for (int i = 0; i < tableDataLines.Length; i++)
                        {
                            string[] lineValues = MyMethods.Split(tableDataLines[i], ',', ':');
                            for (int j = 0; j < cols; j++)
                            {
                                truthTable[i, j] = lineValues[j];
                            }
                        }

                        do
                        {
                            foundFunctionExpressionString = exhaustiveSearch.FindFitestBooleanExpression(truthTable, _definedFunctions);
                        }
                        while (foundFunctionExpressionString == "");


                        operandsArray = MyMethods.GenerateOperands(truthTable.GetLength(1) - 1);
                        numFunc = _definedFunctions.Count + 1;
                        foundFunctionString = $"func{numFunc}({operandsArray}):{foundFunctionExpressionString}";
                        foundFunction = new DefinedFunction(foundFunctionString);

                        _definedFunctions.Add(foundFunction);

                        UpdateDefinedFunctionsListBox();
                        textBox1.Clear();
                    }
                
                }
                else if (MyMethods.ConvertLetterCase(userInputParts[0], "upper") == "VISUALIZE")
                {
                    string funcName = MyMethods.ConvertLetterCase(userInputParts[1], "lower");
                    DefinedFunction function = MyMethods.SearchForFunction(funcName, _definedFunctions);
                    Node root = hashTable.GetFunction(funcName).GetValue();

                    if (function != null)
                    {
                        VisualizeFunctionTree(root);
                    }
                    else
                    {
                        MessageBox.Show($"Функция '{funcName}' не беше открита.");
                    }
                    textBox1.Clear();
                }

                textBox1.Clear();
                textBox1.Multiline = false;
                textBox1.Height = 27;



            }

            if (e.KeyCode == Keys.Down)
            {
                textBox1.Multiline = true;
                textBox1.Height += 27; 
                textBox1.AppendText(Environment.NewLine);
                textBox1.ScrollToCaret();
            }
        }


        public static List<DefinedFunction> GetFunctionsWithOperandCount(int operandCount)
        {
            List<DefinedFunction> matchingFunctions = new();
            for (int i = 0; i < _definedFunctions.Count; i++)
            {
                if (_definedFunctions[i].Operands.Count <= operandCount)
                {
                    matchingFunctions.Add(_definedFunctions[i]);
                }
            }

            return matchingFunctions;
        }
        private void VisualizeFunctionTree(Node root)
        {
            TreeForm treeForm = new TreeForm();

            Bitmap bitmap = new Bitmap(treeForm.treePictureBox.Width, treeForm.treePictureBox.Height);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                int treeDepth = treeBuilder.CalculateTreeDepth(root);
                treeForm.DrawTree(graphics, root, treeForm.treePictureBox.Width / 2, 50, 350, treeDepth);
            }

            treeForm.UpdatePictureBox(bitmap);

            treeForm.Show();
        }

      
        private void DisplayTruthTable(DefinedFunction function)
        {
            bool[,] truthTable = truthTableGenerator.GenerateTruthTable(function, _definedFunctions);

            truthTableDataTable = new DataTable();

            for (int i = 0; i < function.Operands.Count; i++)
            {
                truthTableDataTable.Columns.Add(function.Operands[i]);
            }

            truthTableDataTable.Columns.Add($"{function.Name}");

            for (int row = 0; row < truthTable.GetLength(0); row++)
            {
                DataRow dataRow = truthTableDataTable.NewRow();

                for (int col = 0; col < function.Operands.Count; col++)
                {
                    dataRow[col] = (truthTable[row, col] == true) ? 1 : 0;
                }

               dataRow[$"{function.Name}"] = (truthTable[row, function.Operands.Count] == true) ? 1 : 0;
               // dataRow[$"{function.Name}"] = truthTable[row, function.Operands.Count];

                truthTableDataTable.Rows.Add(dataRow);
            }

            dataGridView1.DataSource = truthTableDataTable;

            dataGridView1.CellFormatting += dataGridView1_CellFormatting;

            int totalColumnWidth = dataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);

            int totalRowHeight = dataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.Visible);

            dataGridView1.Size = new Size(totalColumnWidth + 50, totalRowHeight + 50);
        }


        private void textBox1_Click(object sender, EventArgs e)
        {
            cursorPosition = textBox1.SelectionStart;
            if (textBox1.Text.Length > 0)
            {
                if (textBox1.Text[cursorPosition - 1] == '(' || textBox1.Text[cursorPosition] == ')')
                {
                    if (commandMode == "DEFINE")
                    {
                        keyboardForm.ChangePanelButtons(keyboardForm.numbersPanel, false, Color.DarkGray, Color.DimGray);
                        keyboardForm.ChangePanelButtons(keyboardForm.lettersPanel, true, Color.AliceBlue, Color.SteelBlue);
                        keyboardForm.commaButton.Enabled = true;
                        keyboardForm.commaButton.BackColor = Color.LightSteelBlue;
                    }
                    else if (commandMode == "SOLVE")
                    {
                        keyboardForm.ChangePanelButtons(keyboardForm.numbersPanel, false, Color.DarkGray, Color.DimGray);
                        keyboardForm.commaButton.Enabled = true;
                        keyboardForm.commaButton.BackColor = Color.LightSteelBlue;
                        keyboardForm.button0.Enabled = true;
                        keyboardForm.button0.BackColor = Color.LightSteelBlue;
                        keyboardForm.button1.Enabled = true;
                        keyboardForm.button1.BackColor = Color.LightSteelBlue;

                    }
                }
                if (textBox1.Text[cursorPosition - 1] == ':')
                {
                    keyboardForm.ChangePanelButtons(keyboardForm.operatorsPanel, true, Color.LightSteelBlue, Color.White);
                    keyboardForm.ChangePanelButtons(keyboardForm.bracketsPanel, true, Color.LightSlateGray, Color.White);
                    keyboardForm.ChangePanelButtons(keyboardForm.numbersPanel, false, Color.DarkGray, Color.DimGray);
                    keyboardForm.ChangePanelButtons(keyboardForm.punctuationPanel, false, Color.DarkGray, Color.DimGray);
                    foreach (Button letterButton in keyboardForm.lettersPanel.Controls.OfType<Button>())
                    {
                        if (parameters.Contains(letterButton.Name))
                        {
                            letterButton.Enabled = true;
                            letterButton.BackColor = Color.LightSteelBlue;
                        }
                        else
                        {
                            letterButton.Enabled = false;
                            letterButton.BackColor = Color.Silver;
                        }
                    }
                }
            }

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is bool)
            {
                e.Value = ((bool)e.Value) ? 1 : 0;
                e.FormattingApplied = true;
            }

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Value != null && !(e.Value is bool))
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    MyList<DefinedFunction> functionsList = FileOperations.ReadFromFile(filePath);

                    _definedFunctions.Clear();
                    _definedFunctions.AddRange(functionsList);
                    UpdateDefinedFunctionsListBox(); 

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saveFunctionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files|*.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    FileOperations.SaveToFile(_definedFunctions, filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private List<DefinedFunction> GetFunctionsList()
        {
            List<DefinedFunction> functionsList = new List<DefinedFunction>();

            functionsList.Add(new DefinedFunction("Function1: Body1"));
            functionsList.Add(new DefinedFunction("Function2: Body2"));

            return functionsList;
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox1, "DEFINE- дефиниране на функция\r\n               " +
               "Пример: DEFINE funcX(a,b): a&b" +
               "\r\n\r\n" +
               "" +
               "SOLVE- решаване на дефинирана за определени стойности на аргументите\r\n               " +
               "Пример: SOLVE funcX(0,1)" +
               "" +
               "\r\n\r\nALL- ршаване на  функция за всички стойности на аргументите\r\n               " +
               "Пример: ALL funcX" +
               "" +
               "\r\n\r\nFIND- намеране на недфинирана функция по въведена таблица на истинност \r\n               " +
               "Пример: FIND \r\n                               " +
               "0,0:0;  \r\n                               " +
               "0,1:0;  \r\n                               " +
               "1,0:0;  \r\n                               " +
               "0,1:1\r\n\r\n" +
               "" +
               "REMOVE- премахване на дефинирана функция\r\n               " +
               "Пример: REMOVE funcX\r\n\r\n" +
               "" +
               "VISUALIZE- визуализиране на функцията като дървовидна структура\r\n               " +
               "Пример: VISUALIZE funcX\r\n");

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_definedFunctions.Count > 0)
            {
                DialogResult result = MessageBox.Show("Искате ли да запазите текущите функции преди да създадете нов проект?",
                                                      "Запазване на функции", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Text Files|*.txt";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;

                        try
                        {
                            FileOperations.SaveToFile(_definedFunctions, filePath);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Грешка при запазване на файл: {ex.Message}", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            _definedFunctions.Clear();

            hashTable.table.Clear();

            solvedNodes.Clear();

            textBox1.Clear();

            definedFunctionsListBox.Items.Clear();
            definedFunctionsListBox.Items.Add("Defined functions:");

            solvedFunctionsListBox.Items.Clear();
            solvedFunctionsListBox.Items.Add("Solved functions:");

            dataGridView1.DataSource = null;
            dataGridView1.Visible = false;
        }
    }
}