namespace Fight.Controles
{
    partial class Cronometro
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblCronometro = new System.Windows.Forms.Label();
            this.tmrCronometro = new System.Windows.Forms.Timer(this.components);
            this.tmrRelojColorIntermitente = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblCronometro
            // 
            this.lblCronometro.AutoSize = true;
            this.lblCronometro.Font = new System.Drawing.Font("Arial", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCronometro.Location = new System.Drawing.Point(3, 0);
            this.lblCronometro.Name = "lblCronometro";
            this.lblCronometro.Size = new System.Drawing.Size(301, 78);
            this.lblCronometro.TabIndex = 17;
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
            // Cronometro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblCronometro);
            this.Name = "Cronometro";
            this.Size = new System.Drawing.Size(299, 80);
            this.Load += new System.EventHandler(this.Cronometro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCronometro;
        private System.Windows.Forms.Timer tmrCronometro;
        private System.Windows.Forms.Timer tmrRelojColorIntermitente;
    }
}
