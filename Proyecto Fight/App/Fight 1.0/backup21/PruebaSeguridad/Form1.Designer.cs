namespace PruebaSeguridad
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
            this.btnObtenerUnidadDisco = new System.Windows.Forms.Button();
            this.txtUnidad = new System.Windows.Forms.TextBox();
            this.txtNumeroSerie = new System.Windows.Forms.TextBox();
            this.btnObtenerNumeroSerie = new System.Windows.Forms.Button();
            this.txtNumeroSerieEncriptado = new System.Windows.Forms.TextBox();
            this.btnEncriptar = new System.Windows.Forms.Button();
            this.txtNumeroSerieDesencriptado = new System.Windows.Forms.TextBox();
            this.btnDesencriptar = new System.Windows.Forms.Button();
            this.btnCrearArchivoKey = new System.Windows.Forms.Button();
            this.btnLeerArchivoKEY = new System.Windows.Forms.Button();
            this.txtKeyLeido = new System.Windows.Forms.TextBox();
            this.btnValidarKey = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnObtenerUnidadDisco
            // 
            this.btnObtenerUnidadDisco.Location = new System.Drawing.Point(245, 45);
            this.btnObtenerUnidadDisco.Name = "btnObtenerUnidadDisco";
            this.btnObtenerUnidadDisco.Size = new System.Drawing.Size(96, 23);
            this.btnObtenerUnidadDisco.TabIndex = 0;
            this.btnObtenerUnidadDisco.Text = "ObtenerUnidad";
            this.btnObtenerUnidadDisco.UseVisualStyleBackColor = true;
            this.btnObtenerUnidadDisco.Click += new System.EventHandler(this.btnObtenerUnidadDisco_Click);
            // 
            // txtUnidad
            // 
            this.txtUnidad.Location = new System.Drawing.Point(357, 48);
            this.txtUnidad.Name = "txtUnidad";
            this.txtUnidad.ReadOnly = true;
            this.txtUnidad.Size = new System.Drawing.Size(100, 20);
            this.txtUnidad.TabIndex = 1;
            // 
            // txtNumeroSerie
            // 
            this.txtNumeroSerie.Location = new System.Drawing.Point(357, 91);
            this.txtNumeroSerie.Name = "txtNumeroSerie";
            this.txtNumeroSerie.ReadOnly = true;
            this.txtNumeroSerie.Size = new System.Drawing.Size(169, 20);
            this.txtNumeroSerie.TabIndex = 3;
            // 
            // btnObtenerNumeroSerie
            // 
            this.btnObtenerNumeroSerie.Location = new System.Drawing.Point(245, 88);
            this.btnObtenerNumeroSerie.Name = "btnObtenerNumeroSerie";
            this.btnObtenerNumeroSerie.Size = new System.Drawing.Size(96, 23);
            this.btnObtenerNumeroSerie.TabIndex = 2;
            this.btnObtenerNumeroSerie.Text = "ObtenerNumeroSerie";
            this.btnObtenerNumeroSerie.UseVisualStyleBackColor = true;
            this.btnObtenerNumeroSerie.Click += new System.EventHandler(this.btnObtenerNumeroSerie_Click);
            // 
            // txtNumeroSerieEncriptado
            // 
            this.txtNumeroSerieEncriptado.Location = new System.Drawing.Point(357, 131);
            this.txtNumeroSerieEncriptado.Multiline = true;
            this.txtNumeroSerieEncriptado.Name = "txtNumeroSerieEncriptado";
            this.txtNumeroSerieEncriptado.ReadOnly = true;
            this.txtNumeroSerieEncriptado.Size = new System.Drawing.Size(169, 72);
            this.txtNumeroSerieEncriptado.TabIndex = 5;
            // 
            // btnEncriptar
            // 
            this.btnEncriptar.Location = new System.Drawing.Point(245, 131);
            this.btnEncriptar.Name = "btnEncriptar";
            this.btnEncriptar.Size = new System.Drawing.Size(96, 23);
            this.btnEncriptar.TabIndex = 4;
            this.btnEncriptar.Text = "Encriptar";
            this.btnEncriptar.UseVisualStyleBackColor = true;
            this.btnEncriptar.Click += new System.EventHandler(this.btnEncriptar_Click);
            // 
            // txtNumeroSerieDesencriptado
            // 
            this.txtNumeroSerieDesencriptado.Location = new System.Drawing.Point(357, 222);
            this.txtNumeroSerieDesencriptado.Name = "txtNumeroSerieDesencriptado";
            this.txtNumeroSerieDesencriptado.ReadOnly = true;
            this.txtNumeroSerieDesencriptado.Size = new System.Drawing.Size(169, 20);
            this.txtNumeroSerieDesencriptado.TabIndex = 7;
            // 
            // btnDesencriptar
            // 
            this.btnDesencriptar.Location = new System.Drawing.Point(245, 219);
            this.btnDesencriptar.Name = "btnDesencriptar";
            this.btnDesencriptar.Size = new System.Drawing.Size(96, 23);
            this.btnDesencriptar.TabIndex = 6;
            this.btnDesencriptar.Text = "Desencriptar";
            this.btnDesencriptar.UseVisualStyleBackColor = true;
            this.btnDesencriptar.Click += new System.EventHandler(this.btnDesencriptar_Click);
            // 
            // btnCrearArchivoKey
            // 
            this.btnCrearArchivoKey.Location = new System.Drawing.Point(245, 259);
            this.btnCrearArchivoKey.Name = "btnCrearArchivoKey";
            this.btnCrearArchivoKey.Size = new System.Drawing.Size(96, 23);
            this.btnCrearArchivoKey.TabIndex = 8;
            this.btnCrearArchivoKey.Text = "CrearArchivoKey";
            this.btnCrearArchivoKey.UseVisualStyleBackColor = true;
            this.btnCrearArchivoKey.Click += new System.EventHandler(this.btnCrearArchivoKey_Click);
            // 
            // btnLeerArchivoKEY
            // 
            this.btnLeerArchivoKEY.Location = new System.Drawing.Point(245, 298);
            this.btnLeerArchivoKEY.Name = "btnLeerArchivoKEY";
            this.btnLeerArchivoKEY.Size = new System.Drawing.Size(96, 23);
            this.btnLeerArchivoKEY.TabIndex = 9;
            this.btnLeerArchivoKEY.Text = "LeerArchivoKey";
            this.btnLeerArchivoKEY.UseVisualStyleBackColor = true;
            this.btnLeerArchivoKEY.Click += new System.EventHandler(this.btnLeerArchivoKEY_Click);
            // 
            // txtKeyLeido
            // 
            this.txtKeyLeido.Location = new System.Drawing.Point(357, 300);
            this.txtKeyLeido.Multiline = true;
            this.txtKeyLeido.Name = "txtKeyLeido";
            this.txtKeyLeido.ReadOnly = true;
            this.txtKeyLeido.Size = new System.Drawing.Size(169, 72);
            this.txtKeyLeido.TabIndex = 10;
            // 
            // btnValidarKey
            // 
            this.btnValidarKey.Location = new System.Drawing.Point(245, 381);
            this.btnValidarKey.Name = "btnValidarKey";
            this.btnValidarKey.Size = new System.Drawing.Size(75, 23);
            this.btnValidarKey.TabIndex = 11;
            this.btnValidarKey.Text = "Validar KEY";
            this.btnValidarKey.UseVisualStyleBackColor = true;
            this.btnValidarKey.Click += new System.EventHandler(this.btnValidarKey_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 416);
            this.Controls.Add(this.btnValidarKey);
            this.Controls.Add(this.txtKeyLeido);
            this.Controls.Add(this.btnLeerArchivoKEY);
            this.Controls.Add(this.btnCrearArchivoKey);
            this.Controls.Add(this.txtNumeroSerieDesencriptado);
            this.Controls.Add(this.btnDesencriptar);
            this.Controls.Add(this.txtNumeroSerieEncriptado);
            this.Controls.Add(this.btnEncriptar);
            this.Controls.Add(this.txtNumeroSerie);
            this.Controls.Add(this.btnObtenerNumeroSerie);
            this.Controls.Add(this.txtUnidad);
            this.Controls.Add(this.btnObtenerUnidadDisco);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnObtenerUnidadDisco;
        private System.Windows.Forms.TextBox txtUnidad;
        private System.Windows.Forms.TextBox txtNumeroSerie;
        private System.Windows.Forms.Button btnObtenerNumeroSerie;
        private System.Windows.Forms.TextBox txtNumeroSerieEncriptado;
        private System.Windows.Forms.Button btnEncriptar;
        private System.Windows.Forms.TextBox txtNumeroSerieDesencriptado;
        private System.Windows.Forms.Button btnDesencriptar;
        private System.Windows.Forms.Button btnCrearArchivoKey;
        private System.Windows.Forms.Button btnLeerArchivoKEY;
        private System.Windows.Forms.TextBox txtKeyLeido;
        private System.Windows.Forms.Button btnValidarKey;
    }
}

