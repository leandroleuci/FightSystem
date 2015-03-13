namespace PruebaPuntaje
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
            this.btnRojo_A = new System.Windows.Forms.Button();
            this.btnRojo_B = new System.Windows.Forms.Button();
            this.btnRojo_C = new System.Windows.Forms.Button();
            this.btnAzul_C = new System.Windows.Forms.Button();
            this.btnAzul_B = new System.Windows.Forms.Button();
            this.btnAzul_A = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRojo_A
            // 
            this.btnRojo_A.BackColor = System.Drawing.Color.Red;
            this.btnRojo_A.Location = new System.Drawing.Point(80, 29);
            this.btnRojo_A.Name = "btnRojo_A";
            this.btnRojo_A.Size = new System.Drawing.Size(75, 23);
            this.btnRojo_A.TabIndex = 0;
            this.btnRojo_A.Text = "btnRojo_A";
            this.btnRojo_A.UseVisualStyleBackColor = false;
            this.btnRojo_A.Click += new System.EventHandler(this.btnRojo_A_Click);
            // 
            // btnRojo_B
            // 
            this.btnRojo_B.BackColor = System.Drawing.Color.Red;
            this.btnRojo_B.Location = new System.Drawing.Point(161, 29);
            this.btnRojo_B.Name = "btnRojo_B";
            this.btnRojo_B.Size = new System.Drawing.Size(75, 23);
            this.btnRojo_B.TabIndex = 1;
            this.btnRojo_B.Text = "btnRojo_B";
            this.btnRojo_B.UseVisualStyleBackColor = false;
            // 
            // btnRojo_C
            // 
            this.btnRojo_C.BackColor = System.Drawing.Color.Red;
            this.btnRojo_C.Location = new System.Drawing.Point(242, 29);
            this.btnRojo_C.Name = "btnRojo_C";
            this.btnRojo_C.Size = new System.Drawing.Size(75, 23);
            this.btnRojo_C.TabIndex = 2;
            this.btnRojo_C.Text = "btnRojo_C";
            this.btnRojo_C.UseVisualStyleBackColor = false;
            // 
            // btnAzul_C
            // 
            this.btnAzul_C.BackColor = System.Drawing.Color.Blue;
            this.btnAzul_C.Location = new System.Drawing.Point(242, 58);
            this.btnAzul_C.Name = "btnAzul_C";
            this.btnAzul_C.Size = new System.Drawing.Size(75, 23);
            this.btnAzul_C.TabIndex = 5;
            this.btnAzul_C.Text = "btnAzul_C";
            this.btnAzul_C.UseVisualStyleBackColor = false;
            // 
            // btnAzul_B
            // 
            this.btnAzul_B.BackColor = System.Drawing.Color.Blue;
            this.btnAzul_B.Location = new System.Drawing.Point(161, 58);
            this.btnAzul_B.Name = "btnAzul_B";
            this.btnAzul_B.Size = new System.Drawing.Size(75, 23);
            this.btnAzul_B.TabIndex = 4;
            this.btnAzul_B.Text = "btnAzul_B";
            this.btnAzul_B.UseVisualStyleBackColor = false;
            // 
            // btnAzul_A
            // 
            this.btnAzul_A.BackColor = System.Drawing.Color.Blue;
            this.btnAzul_A.Location = new System.Drawing.Point(80, 58);
            this.btnAzul_A.Name = "btnAzul_A";
            this.btnAzul_A.Size = new System.Drawing.Size(75, 23);
            this.btnAzul_A.TabIndex = 3;
            this.btnAzul_A.Text = "btnAzul_A";
            this.btnAzul_A.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 111);
            this.Controls.Add(this.btnAzul_C);
            this.Controls.Add(this.btnAzul_B);
            this.Controls.Add(this.btnAzul_A);
            this.Controls.Add(this.btnRojo_C);
            this.Controls.Add(this.btnRojo_B);
            this.Controls.Add(this.btnRojo_A);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRojo_A;
        private System.Windows.Forms.Button btnRojo_B;
        private System.Windows.Forms.Button btnRojo_C;
        private System.Windows.Forms.Button btnAzul_C;
        private System.Windows.Forms.Button btnAzul_B;
        private System.Windows.Forms.Button btnAzul_A;
    }
}

