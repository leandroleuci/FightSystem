namespace Fight.Tablero.Formularios
{
    partial class CronometroSuperpuesto
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tmrCronometro = new System.Windows.Forms.Timer(this.components);
            this.tmrRelojColorIntermitente = new System.Windows.Forms.Timer(this.components);
            this.pbIconoTipoCrono = new System.Windows.Forms.PictureBox();
            this.lblCronometro = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIconoTipoCrono)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Fight.Tablero.Properties.Resources.FondoCronoVerde;
            this.pictureBox1.Location = new System.Drawing.Point(71, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(294, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // tmrCronometro
            // 
            this.tmrCronometro.Interval = 1000;
            this.tmrCronometro.Tick += new System.EventHandler(this.tmrCronometro_Tick);
            // 
            // tmrRelojColorIntermitente
            // 
            this.tmrRelojColorIntermitente.Interval = 500;
            this.tmrRelojColorIntermitente.Tick += new System.EventHandler(this.tmrRelojColorIntermitente_Tick);
            // 
            // pbIconoTipoCrono
            // 
            this.pbIconoTipoCrono.BackColor = System.Drawing.Color.Transparent;
            this.pbIconoTipoCrono.Location = new System.Drawing.Point(22, 38);
            this.pbIconoTipoCrono.Name = "pbIconoTipoCrono";
            this.pbIconoTipoCrono.Size = new System.Drawing.Size(43, 37);
            this.pbIconoTipoCrono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbIconoTipoCrono.TabIndex = 8;
            this.pbIconoTipoCrono.TabStop = false;
            this.pbIconoTipoCrono.Click += new System.EventHandler(this.pbCruzMedico_Click);
            // 
            // lblCronometro
            // 
            this.lblCronometro.AutoSize = true;
            this.lblCronometro.Font = new System.Drawing.Font("Arial", 40F, System.Drawing.FontStyle.Bold);
            this.lblCronometro.Location = new System.Drawing.Point(3, -4);
            this.lblCronometro.Name = "lblCronometro";
            this.lblCronometro.Size = new System.Drawing.Size(241, 63);
            this.lblCronometro.TabIndex = 7;
            this.lblCronometro.Text = "00:00:00";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.YellowGreen;
            this.panel1.Controls.Add(this.lblCronometro);
            this.panel1.Location = new System.Drawing.Point(101, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(243, 56);
            this.panel1.TabIndex = 7;
            // 
            // CronometroSuperpuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Fight.Tablero.Properties.Resources.FondoCronometroSuperpuesto_MenorTamaño;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(377, 110);
            this.Controls.Add(this.pbIconoTipoCrono);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(322, 3);
            this.Name = "CronometroSuperpuesto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CronometroSuperpuesto";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.Load += new System.EventHandler(this.CronometroSuperpuesto_Load);
            this.DoubleClick += new System.EventHandler(this.CronometroSuperpuesto_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIconoTipoCrono)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // private Fight.Controles.Cronometro cronometro;
       // private Fight.Controles.Cronometro cronometro;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer tmrCronometro;
        private System.Windows.Forms.Timer tmrRelojColorIntermitente;
        private System.Windows.Forms.PictureBox pbIconoTipoCrono;
        private System.Windows.Forms.Label lblCronometro;
        private System.Windows.Forms.Panel panel1;
    }
}