namespace project
{
    partial class TestForm
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
            this.panelDrawingArea = new System.Windows.Forms.Panel();
            this.buttonTry = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // panelDrawingArea
            // 
            this.panelDrawingArea.BackColor = System.Drawing.SystemColors.ControlText;
            this.panelDrawingArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDrawingArea.Location = new System.Drawing.Point(12, 12);
            this.panelDrawingArea.Name = "panelDrawingArea";
            this.panelDrawingArea.Size = new System.Drawing.Size(656, 314);
            this.panelDrawingArea.TabIndex = 0;
            // 
            // buttonTry
            // 
            this.buttonTry.Location = new System.Drawing.Point(13, 332);
            this.buttonTry.Name = "buttonTry";
            this.buttonTry.Size = new System.Drawing.Size(75, 23);
            this.buttonTry.TabIndex = 1;
            this.buttonTry.Text = "Try To Move";
            this.buttonTry.UseVisualStyleBackColor = true;
            this.buttonTry.Click += new System.EventHandler(this.buttonTry_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(188, 332);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(301, 141);
            this.textBox1.TabIndex = 2;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 503);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonTry);
            this.Controls.Add(this.panelDrawingArea);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelDrawingArea;
        private System.Windows.Forms.Button buttonTry;
        private System.Windows.Forms.TextBox textBox1;
    }
}