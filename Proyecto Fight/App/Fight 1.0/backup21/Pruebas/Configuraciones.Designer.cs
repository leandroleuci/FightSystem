namespace Fight.WIN
{
    partial class Configuraciones
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.nudRounds = new System.Windows.Forms.NumericUpDown();
            this.mtxtTiempoRound1 = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mtxtTiempoRound2 = new System.Windows.Forms.MaskedTextBox();
            this.mtxtTiempoDescanso1 = new System.Windows.Forms.MaskedTextBox();
            this.mtxtTiempoDescanso2 = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudRounds)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(287, 232);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // nudRounds
            // 
            this.nudRounds.Location = new System.Drawing.Point(127, 35);
            this.nudRounds.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudRounds.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRounds.Name = "nudRounds";
            this.nudRounds.Size = new System.Drawing.Size(57, 20);
            this.nudRounds.TabIndex = 1;
            this.nudRounds.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // mtxtTiempoRound1
            // 
            this.mtxtTiempoRound1.Location = new System.Drawing.Point(126, 87);
            this.mtxtTiempoRound1.Mask = "00:00:00";
            this.mtxtTiempoRound1.Name = "mtxtTiempoRound1";
            this.mtxtTiempoRound1.Size = new System.Drawing.Size(57, 20);
            this.mtxtTiempoRound1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Rounds";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tiempo Round 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tiempo Round 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tiempo Descanso 1";
            // 
            // mtxtTiempoRound2
            // 
            this.mtxtTiempoRound2.Location = new System.Drawing.Point(126, 113);
            this.mtxtTiempoRound2.Mask = "00:00:00";
            this.mtxtTiempoRound2.Name = "mtxtTiempoRound2";
            this.mtxtTiempoRound2.Size = new System.Drawing.Size(57, 20);
            this.mtxtTiempoRound2.TabIndex = 9;
            // 
            // mtxtTiempoDescanso1
            // 
            this.mtxtTiempoDescanso1.Location = new System.Drawing.Point(126, 161);
            this.mtxtTiempoDescanso1.Mask = "00:00:00";
            this.mtxtTiempoDescanso1.Name = "mtxtTiempoDescanso1";
            this.mtxtTiempoDescanso1.Size = new System.Drawing.Size(57, 20);
            this.mtxtTiempoDescanso1.TabIndex = 10;
            // 
            // mtxtTiempoDescanso2
            // 
            this.mtxtTiempoDescanso2.Location = new System.Drawing.Point(126, 190);
            this.mtxtTiempoDescanso2.Mask = "00:00:00";
            this.mtxtTiempoDescanso2.Name = "mtxtTiempoDescanso2";
            this.mtxtTiempoDescanso2.Size = new System.Drawing.Size(57, 20);
            this.mtxtTiempoDescanso2.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tiempo Descanso 2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(368, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Configuraciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 267);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mtxtTiempoDescanso2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mtxtTiempoDescanso1);
            this.Controls.Add(this.mtxtTiempoRound2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mtxtTiempoRound1);
            this.Controls.Add(this.nudRounds);
            this.Controls.Add(this.btnAceptar);
            this.Name = "Configuraciones";
            this.Text = "Configuraciones";
            ((System.ComponentModel.ISupportInitialize)(this.nudRounds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.NumericUpDown nudRounds;
        private System.Windows.Forms.MaskedTextBox mtxtTiempoRound1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox mtxtTiempoRound2;
        private System.Windows.Forms.MaskedTextBox mtxtTiempoDescanso1;
        private System.Windows.Forms.MaskedTextBox mtxtTiempoDescanso2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
    }
}

