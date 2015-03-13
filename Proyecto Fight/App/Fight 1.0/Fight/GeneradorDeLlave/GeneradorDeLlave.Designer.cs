namespace GeneradorDeLlave
{
    partial class GeneradorDeLlave
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
            this.btnGenerarLlave = new System.Windows.Forms.Button();
            this.cboUnidades = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGenerarLlave
            // 
            this.btnGenerarLlave.Location = new System.Drawing.Point(241, 33);
            this.btnGenerarLlave.Name = "btnGenerarLlave";
            this.btnGenerarLlave.Size = new System.Drawing.Size(91, 23);
            this.btnGenerarLlave.TabIndex = 0;
            this.btnGenerarLlave.Text = "Generar Llave";
            this.btnGenerarLlave.UseVisualStyleBackColor = true;
            this.btnGenerarLlave.Click += new System.EventHandler(this.btnGenerarLlave_Click);
            // 
            // cboUnidades
            // 
            this.cboUnidades.FormattingEnabled = true;
            this.cboUnidades.Items.AddRange(new object[] {
            "A:\\",
            "B:\\",
            "C:\\",
            "D:\\",
            "E:\\",
            "F:\\",
            "G:\\",
            "H:\\",
            "I:\\",
            "J:\\",
            "K:\\",
            "L:\\",
            "M:\\",
            "N:\\",
            "O:\\",
            "P:\\",
            "Q:\\",
            "R:\\",
            "S:\\",
            "T:\\",
            "U:\\",
            "V:\\",
            "X:\\",
            "Y:\\",
            "Z:\\"});
            this.cboUnidades.Location = new System.Drawing.Point(156, 35);
            this.cboUnidades.Name = "cboUnidades";
            this.cboUnidades.Size = new System.Drawing.Size(56, 21);
            this.cboUnidades.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccionar la Unidad:";
            // 
            // GeneradorDeLlave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 89);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboUnidades);
            this.Controls.Add(this.btnGenerarLlave);
            this.MaximizeBox = false;
            this.Name = "GeneradorDeLlave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generador de Llaves";
            this.Load += new System.EventHandler(this.GeneradorDeLlave_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerarLlave;
        private System.Windows.Forms.ComboBox cboUnidades;
        private System.Windows.Forms.Label label1;
    }
}

