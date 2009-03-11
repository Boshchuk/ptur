namespace project
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCallTestForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCallTestForm
            // 
            this.buttonCallTestForm.Location = new System.Drawing.Point(211, 13);
            this.buttonCallTestForm.Name = "buttonCallTestForm";
            this.buttonCallTestForm.Size = new System.Drawing.Size(75, 23);
            this.buttonCallTestForm.TabIndex = 0;
            this.buttonCallTestForm.Text = "Run Test";
            this.buttonCallTestForm.UseVisualStyleBackColor = true;
            this.buttonCallTestForm.Click += new System.EventHandler(this.buttonCallTestForm_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 262);
            this.Controls.Add(this.buttonCallTestForm);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCallTestForm;
    }
}

