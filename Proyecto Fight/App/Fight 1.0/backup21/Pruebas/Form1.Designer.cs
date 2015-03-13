namespace Fight.Tablero
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
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnMedico = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.mtxtTiempoMedico = new System.Windows.Forms.MaskedTextBox();
            this.tmrCronometro = new System.Windows.Forms.Timer(this.components);
            this.lblCronometro = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(42, 88);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(52, 34);
            this.btnPlay.TabIndex = 14;
            this.btnPlay.Text = "PLAY";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnMedico
            // 
            this.btnMedico.Location = new System.Drawing.Point(158, 88);
            this.btnMedico.Name = "btnMedico";
            this.btnMedico.Size = new System.Drawing.Size(59, 34);
            this.btnMedico.TabIndex = 13;
            this.btnMedico.Text = "MEDICO";
            this.btnMedico.UseVisualStyleBackColor = true;
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(100, 88);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(52, 34);
            this.btnPause.TabIndex = 12;
            this.btnPause.Text = "PAUSE";
            this.btnPause.UseVisualStyleBackColor = true;
            // 
            // mtxtTiempoMedico
            // 
            this.mtxtTiempoMedico.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtTiempoMedico.ForeColor = System.Drawing.Color.Red;
            this.mtxtTiempoMedico.Location = new System.Drawing.Point(79, 162);
            this.mtxtTiempoMedico.Mask = "00:00:00";
            this.mtxtTiempoMedico.Name = "mtxtTiempoMedico";
            this.mtxtTiempoMedico.ReadOnly = true;
            this.mtxtTiempoMedico.Size = new System.Drawing.Size(100, 31);
            this.mtxtTiempoMedico.TabIndex = 15;
            this.mtxtTiempoMedico.Text = "000000";
            // 
            // tmrCronometro
            // 
            this.tmrCronometro.Enabled = true;
            this.tmrCronometro.Interval = 1000;
            this.tmrCronometro.Tick += new System.EventHandler(this.tmrCronometro_Tick);
            // 
            // lblCronometro
            // 
            this.lblCronometro.AutoSize = true;
            this.lblCronometro.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.lblCronometro.Location = new System.Drawing.Point(83, 9);
            this.lblCronometro.Name = "lblCronometro";
            this.lblCronometro.Size = new System.Drawing.Size(96, 25);
            this.lblCronometro.TabIndex = 16;
            this.lblCronometro.Text = "00:00:00";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.lblCronometro);
            this.Controls.Add(this.mtxtTiempoMedico);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnMedico);
            this.Controls.Add(this.btnPause);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnMedico;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.MaskedTextBox mtxtTiempoMedico;
        private System.Windows.Forms.Timer tmrCronometro;
        private System.Windows.Forms.Label lblCronometro;
    }
}

