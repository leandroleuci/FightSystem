using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fight.Tablero.Formularios
{
    public partial class CambiarNombre : Form
    {

       public String nombreRojo;
       public String nombreAzul;

        public CambiarNombre()
        {
            InitializeComponent();
        }

        public CambiarNombre(String nombreRojo, String nombreAzul)
        {
            InitializeComponent();

            this.nombreRojo = txtNombreRojo.Text = nombreRojo;
            this.nombreAzul = txtNombreAzul.Text = nombreAzul;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de cambiar los nombres?", "Cambio de Nombres", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.nombreAzul = this.txtNombreAzul.Text.ToUpper().Trim();
                if (this.nombreAzul.Length >= 10 )
                    this.nombreAzul = this.nombreAzul.Substring(0, 10);

                this.nombreRojo = this.txtNombreRojo.Text.ToUpper().Trim();
                if (this.nombreRojo.Length >= 10)
                    this.nombreRojo = this.nombreRojo.Substring(0, 10);

                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}
