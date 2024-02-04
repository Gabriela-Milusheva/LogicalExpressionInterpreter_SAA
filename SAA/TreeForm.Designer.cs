namespace SAA
{
    partial class TreeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeForm));
            this.treePictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.treePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // treePictureBox
            // 
            this.treePictureBox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.treePictureBox.BackgroundImage = global::SAA.Properties.Resources.vecteezy_abstract_gradient_blue_liquid_wave_background_23059101323;
            this.treePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treePictureBox.Location = new System.Drawing.Point(0, 0);
            this.treePictureBox.Name = "treePictureBox";
            this.treePictureBox.Size = new System.Drawing.Size(1842, 863);
            this.treePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.treePictureBox.TabIndex = 0;
            this.treePictureBox.TabStop = false;
            // 
            // TreeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1842, 863);
            this.Controls.Add(this.treePictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TreeForm";
            this.Text = "Expression Binary Tree";
            ((System.ComponentModel.ISupportInitialize)(this.treePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public PictureBox treePictureBox;
    }
}