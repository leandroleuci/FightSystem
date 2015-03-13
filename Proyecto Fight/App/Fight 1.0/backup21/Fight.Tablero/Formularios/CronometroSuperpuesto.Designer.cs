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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCronometro = new System.Windows.Forms.Label();
            this.tmrCronometro = new System.Windows.Forms.Timer(this.components);
            this.tmrRelojColorIntermitente = new System.Windows.Forms.Timer(this.components);
            this.pbCruzMedico = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCruzMedico)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Fight.Tablero.Properties.Resources.FondoCronoVerde;
            this.pictureBox1.Location = new System.Drawing.Point(-9, -6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(547, 201);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.YellowGreen;
            this.panel1.Controls.Add(this.lblCronometro);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(171, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(537, 188);
            this.panel1.TabIndex = 7;
            // 
            // lblCronometro
            // 
            this.lblCronometro.AutoSize = true;
            this.lblCronometro.Font = new System.Drawing.Font("Arial", 80F, System.Drawing.FontStyle.Bold);
            this.lblCronometro.Location = new System.Drawing.Point(34, 34);
            this.lblCronometro.Name = "lblCronometro";
            this.lblCronometro.Size = new System.Drawing.Size(482, 124);
            this.lblCronometro.TabIndex = 7;
            this.lblCronometro.Text = "00:00:00";
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
            // pbCruzMedico
            // 
            this.pbCruzMedico.BackColor = System.Drawing.Color.Transparent;
            this.pbCruzMedico.Image = global::Fight.Tablero.Properties.Resources.IconoTiempoMedico;
            this.pbCruzMedico.Location = new System.Drawing.Point(40, 90);
            this.pbCruzMedico.Name = "pbCruzMedico";
            this.pbCruzMedico.Size = new System.Drawing.Size(116, 123);
            this.pbCruzMedico.TabIndex = 8;
            this.pbCruzMedico.TabStop = false;
            this.pbCruzMedico.Click += new System.EventHandler(this.pbCruzMedico_Click);
            // 
            // CronometroSuperpuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Fight.Tablero.Properties.Resources.FondoCronometroSuperpuesto;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(751, 302);
            this.Controls.Add(this.pbCruzMedico);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CronometroSuperpuesto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CronometroSuperpuesto";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.Load += new System.EventHandler(this.CronometroSuperpuesto_Load);
            this.DoubleClick += new System.EventHandler(this.CronometroSuperpuesto_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCruzMedico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        // private Fight.Controles.Cronometro cronometro;
       // private Fight.Controles.Cronometro cronometro;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer tmrCronometro;
        private System.Windows.Forms.Timer tmrRelojColorIntermitente;
        private System.Windows.Forms.Label lblCronometro;
        private System.Windows.Forms.PictureBox pbCruzMedico;
    }
}