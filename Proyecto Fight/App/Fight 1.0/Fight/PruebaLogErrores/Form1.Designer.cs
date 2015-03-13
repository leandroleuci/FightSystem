namespace PruebaLogErrores
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.btnNewLogError = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtError = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnNewLogError
            // 
            this.btnNewLogError.Location = new System.Drawing.Point(40, 30);
            this.btnNewLogError.Name = "btnNewLogError";
            this.btnNewLogError.Size = new System.Drawing.Size(99, 23);
            this.btnNewLogError.TabIndex = 0;
            this.btnNewLogError.Text = "btnNewLogError";
            this.btnNewLogError.UseVisualStyleBackColor = true;
            this.btnNewLogError.Click += new System.EventHandler(this.btnNewLogError_Click);
            // 
            // txtError
            // 
            this.txtError.Location = new System.Drawing.Point(170, 32);
            this.txtError.Multiline = true;
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(235, 136);
            this.txtError.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 202);
            this.Controls.Add(this.txtError);
            this.Controls.Add(this.btnNewLogError);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNewLogError;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtError;
    }
}

