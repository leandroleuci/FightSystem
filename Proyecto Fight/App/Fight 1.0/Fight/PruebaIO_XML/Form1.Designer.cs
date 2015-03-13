namespace PruebaIO_XML
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
            this.btnObtenerPathXML = new System.Windows.Forms.Button();
            this.txtPathXML = new System.Windows.Forms.TextBox();
            this.txtValorCampoElegido = new System.Windows.Forms.TextBox();
            this.btnLeerXml_Campo = new System.Windows.Forms.Button();
            this.txtActualizarXML = new System.Windows.Forms.TextBox();
            this.btnActualizarXML = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.txtEstadoReseteo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnObtenerPathXML
            // 
            this.btnObtenerPathXML.Location = new System.Drawing.Point(61, 66);
            this.btnObtenerPathXML.Name = "btnObtenerPathXML";
            this.btnObtenerPathXML.Size = new System.Drawing.Size(239, 23);
            this.btnObtenerPathXML.TabIndex = 0;
            this.btnObtenerPathXML.Text = "obtenerPathXML";
            this.btnObtenerPathXML.UseVisualStyleBackColor = true;
            this.btnObtenerPathXML.Click += new System.EventHandler(this.btnObtenerPathXML_Click);
            // 
            // txtPathXML
            // 
            this.txtPathXML.Location = new System.Drawing.Point(306, 68);
            this.txtPathXML.Name = "txtPathXML";
            this.txtPathXML.Size = new System.Drawing.Size(422, 20);
            this.txtPathXML.TabIndex = 1;
            // 
            // txtValorCampoElegido
            // 
            this.txtValorCampoElegido.Location = new System.Drawing.Point(306, 97);
            this.txtValorCampoElegido.Name = "txtValorCampoElegido";
            this.txtValorCampoElegido.Size = new System.Drawing.Size(422, 20);
            this.txtValorCampoElegido.TabIndex = 3;
            // 
            // btnLeerXml_Campo
            // 
            this.btnLeerXml_Campo.Location = new System.Drawing.Point(61, 95);
            this.btnLeerXml_Campo.Name = "btnLeerXml_Campo";
            this.btnLeerXml_Campo.Size = new System.Drawing.Size(239, 23);
            this.btnLeerXml_Campo.TabIndex = 2;
            this.btnLeerXml_Campo.Text = "leerXml_Campo1";
            this.btnLeerXml_Campo.UseVisualStyleBackColor = true;
            this.btnLeerXml_Campo.Click += new System.EventHandler(this.btnLeerXml_Campo_Click);
            // 
            // txtActualizarXML
            // 
            this.txtActualizarXML.Location = new System.Drawing.Point(306, 126);
            this.txtActualizarXML.Name = "txtActualizarXML";
            this.txtActualizarXML.Size = new System.Drawing.Size(422, 20);
            this.txtActualizarXML.TabIndex = 5;
            // 
            // btnActualizarXML
            // 
            this.btnActualizarXML.Location = new System.Drawing.Point(61, 124);
            this.btnActualizarXML.Name = "btnActualizarXML";
            this.btnActualizarXML.Size = new System.Drawing.Size(239, 23);
            this.btnActualizarXML.TabIndex = 4;
            this.btnActualizarXML.Text = "ActualizarXML";
            this.btnActualizarXML.UseVisualStyleBackColor = true;
            this.btnActualizarXML.Click += new System.EventHandler(this.btnActualizarXML_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(306, 154);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(422, 20);
            this.textBox4.TabIndex = 7;
            // 
            // txtEstadoReseteo
            // 
            this.txtEstadoReseteo.Location = new System.Drawing.Point(61, 152);
            this.txtEstadoReseteo.Name = "txtEstadoReseteo";
            this.txtEstadoReseteo.Size = new System.Drawing.Size(239, 23);
            this.txtEstadoReseteo.TabIndex = 6;
            this.txtEstadoReseteo.Text = "resetearXML";
            this.txtEstadoReseteo.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 309);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.txtEstadoReseteo);
            this.Controls.Add(this.txtActualizarXML);
            this.Controls.Add(this.btnActualizarXML);
            this.Controls.Add(this.txtValorCampoElegido);
            this.Controls.Add(this.btnLeerXml_Campo);
            this.Controls.Add(this.txtPathXML);
            this.Controls.Add(this.btnObtenerPathXML);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnObtenerPathXML;
        private System.Windows.Forms.TextBox txtPathXML;
        private System.Windows.Forms.TextBox txtValorCampoElegido;
        private System.Windows.Forms.Button btnLeerXml_Campo;
        private System.Windows.Forms.TextBox txtActualizarXML;
        private System.Windows.Forms.Button btnActualizarXML;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button txtEstadoReseteo;
    }
}

