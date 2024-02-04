namespace SAA
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.deleteTextButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.solvedFunctionsListBox = new System.Windows.Forms.ListBox();
            this.definedFunctionsListBox = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFunctionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveBinaryTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // deleteTextButton
            // 
            this.deleteTextButton.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.deleteTextButton.ForeColor = System.Drawing.Color.SteelBlue;
            this.deleteTextButton.Location = new System.Drawing.Point(675, 32);
            this.deleteTextButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.deleteTextButton.Name = "deleteTextButton";
            this.deleteTextButton.Size = new System.Drawing.Size(94, 22);
            this.deleteTextButton.TabIndex = 16;
            this.deleteTextButton.Text = "Delete";
            this.deleteTextButton.Click += new System.EventHandler(this.deleteTextButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Bookman Old Style", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.ForeColor = System.Drawing.Color.SteelBlue;
            this.textBox1.Location = new System.Drawing.Point(11, 32);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(655, 27);
            this.textBox1.TabIndex = 10;
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.textBox1.MouseEnter += new System.EventHandler(this.textBox1_MouseEnter);
            // 
            // solvedFunctionsListBox
            // 
            this.solvedFunctionsListBox.BackColor = System.Drawing.Color.AliceBlue;
            this.solvedFunctionsListBox.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.solvedFunctionsListBox.ForeColor = System.Drawing.Color.SteelBlue;
            this.solvedFunctionsListBox.FormattingEnabled = true;
            this.solvedFunctionsListBox.ItemHeight = 19;
            this.solvedFunctionsListBox.Location = new System.Drawing.Point(565, 67);
            this.solvedFunctionsListBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.solvedFunctionsListBox.Name = "solvedFunctionsListBox";
            this.solvedFunctionsListBox.Size = new System.Drawing.Size(618, 327);
            this.solvedFunctionsListBox.TabIndex = 15;
            // 
            // definedFunctionsListBox
            // 
            this.definedFunctionsListBox.BackColor = System.Drawing.Color.AliceBlue;
            this.definedFunctionsListBox.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.definedFunctionsListBox.ForeColor = System.Drawing.Color.SteelBlue;
            this.definedFunctionsListBox.FormattingEnabled = true;
            this.definedFunctionsListBox.ItemHeight = 19;
            this.definedFunctionsListBox.Location = new System.Drawing.Point(11, 67);
            this.definedFunctionsListBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.definedFunctionsListBox.Name = "definedFunctionsListBox";
            this.definedFunctionsListBox.Size = new System.Drawing.Size(544, 327);
            this.definedFunctionsListBox.TabIndex = 14;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1613, 28);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveFunctionsToolStripMenuItem,
            this.saveBinaryTreeToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.SteelBlue;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(52, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.ForeColor = System.Drawing.Color.SteelBlue;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.ForeColor = System.Drawing.Color.SteelBlue;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveFunctionsToolStripMenuItem
            // 
            this.saveFunctionsToolStripMenuItem.ForeColor = System.Drawing.Color.SteelBlue;
            this.saveFunctionsToolStripMenuItem.Name = "saveFunctionsToolStripMenuItem";
            this.saveFunctionsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveFunctionsToolStripMenuItem.Text = "Save Functions";
            this.saveFunctionsToolStripMenuItem.Click += new System.EventHandler(this.saveFunctionsToolStripMenuItem_Click);
            // 
            // saveBinaryTreeToolStripMenuItem
            // 
            this.saveBinaryTreeToolStripMenuItem.ForeColor = System.Drawing.Color.SteelBlue;
            this.saveBinaryTreeToolStripMenuItem.Name = "saveBinaryTreeToolStripMenuItem";
            this.saveBinaryTreeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveBinaryTreeToolStripMenuItem.Text = "Save Binary Tree";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keyboardToolStripMenuItem});
            this.viewToolStripMenuItem.ForeColor = System.Drawing.Color.SteelBlue;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // keyboardToolStripMenuItem
            // 
            this.keyboardToolStripMenuItem.ForeColor = System.Drawing.Color.SteelBlue;
            this.keyboardToolStripMenuItem.Name = "keyboardToolStripMenuItem";
            this.keyboardToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.keyboardToolStripMenuItem.Text = "Keyboard";
            this.keyboardToolStripMenuItem.Click += new System.EventHandler(this.keyboardToolStripMenuItem_Click_1);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.ForeColor = System.Drawing.Color.SteelBlue;
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click_1);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoEllipsis = true;
            this.infoLabel.AutoSize = true;
            this.infoLabel.BackColor = System.Drawing.Color.Transparent;
            this.infoLabel.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.infoLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.infoLabel.Location = new System.Drawing.Point(13, 435);
            this.infoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(625, 399);
            this.infoLabel.TabIndex = 19;
            this.infoLabel.Text = resources.GetString("infoLabel.Text");
            this.infoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.infoLabel.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.SteelBlue;
            this.dataGridView1.Location = new System.Drawing.Point(1193, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(411, 767);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.Tag = "";
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 1000000;
            this.toolTip1.BackColor = System.Drawing.Color.AliceBlue;
            this.toolTip1.ForeColor = System.Drawing.Color.SteelBlue;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ShowAlways = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SAA.Properties.Resources.vecteezy_abstract_gradient_blue_liquid_wave_background_2305910132;
            this.ClientSize = new System.Drawing.Size(1613, 873);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.deleteTextButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.solvedFunctionsListBox);
            this.Controls.Add(this.definedFunctionsListBox);
            this.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.SteelBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Logical Expression Interpreter ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button deleteTextButton;
        private TextBox textBox1;
        private ListBox solvedFunctionsListBox;
        private ListBox definedFunctionsListBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveFunctionsToolStripMenuItem;
        private ToolStripMenuItem saveBinaryTreeToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem keyboardToolStripMenuItem;
        private ToolStripMenuItem infoToolStripMenuItem;
        private Label infoLabel;
        private DataGridView dataGridView1;
        private ToolTip toolTip1;
    }
}