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
            this.SuspendLayout();
            // 
            // panelDrawingArea
            // 
            this.panelDrawingArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDrawingArea.Location = new System.Drawing.Point(12, 12);
            this.panelDrawingArea.Name = "panelDrawingArea";
            this.panelDrawingArea.Size = new System.Drawing.Size(656, 296);
            this.panelDrawingArea.TabIndex = 0;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 503);
            this.Controls.Add(this.panelDrawingArea);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDrawingArea;
    }
}