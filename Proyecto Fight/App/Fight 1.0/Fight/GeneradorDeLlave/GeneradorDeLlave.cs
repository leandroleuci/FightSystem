using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Management;
using System.Reflection;

namespace GeneradorDeLlave
{
    public partial class GeneradorDeLlave : Form
    {

        string numeroSerie = "";
        string nombreArchivoKEY = "KEY.bat";

        // define the local key and vector byte arrays
        //byte[] key = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 
        //      13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24};
        //byte[] iv = { 8, 7, 6, 5, 4, 3, 2, 1};
        byte[] key = {131, 242, 35, 49, 58, 61, 78, 86, 95, 101, 111, 126, 
              133, 142, 153, 164, 177, 181, 196, 204, 213, 222, 234, 242};
        byte[] iv = { 82, 76, 60, 54, 47, 39, 23, 13 };

        public GeneradorDeLlave()
        {
            InitializeComponent();
        }

        private void GeneradorDeLlave_Load(object sender, EventArgs e)
        {
            
        }

        private void btnGenerarLlave_Click(object sender, EventArgs e)
        {
            if (this.cboUnidades.SelectedItem.ToString() != "")
            {

                if (!ObtenerNumeroSerie(cboUnidades.SelectedItem.ToString(), ref numeroSerie))
                    MessageBox.Show("No se encontro la unidad seleccionada. Verifique que el dispositivo este conectado.");
                else
                    if (CrearArchivoKey(cboUnidades.SelectedItem.ToString() + nombreArchivoKEY, Encriptar(numeroSerie)))
                        MessageBox.Show("Llave generada correctamente.");
                    else
                        MessageBox.Show("No se pudo generar la Llave. Verifique que el dispositivo este conectado.");
            }
            else
            {
                MessageBox.Show("Debe seleccionar una unidad.");
            }
        }


        private bool ObtenerNumeroSerie(string unidad, ref string numeroSerie)
        {
            bool retorno = false;

            try
            {

                USBSerialNumber usb = new USBSerialNumber();
                numeroSerie = usb.getSerialNumberFromDriveLetter(unidad.Substring(0,1));

                if ( numeroSerie != null )
                    retorno = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;

        }


        private bool CrearArchivoKey(string path, string numeroSerieEncriptado)
        {

            string fic = path;
            string texto = numeroSerieEncriptado;
            bool retorno = false;

            try
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(fic);
                sw.WriteLine(texto);
                sw.Close();

                retorno = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }

        private string Encriptar(string numeroSerie)
        {
            string numeroSerieEncriptado = "";

            cTripleDES des = new cTripleDES(key, iv);

            numeroSerieEncriptado = des.Encrypt(numeroSerie);

            return numeroSerieEncriptado;
        }

    }
}
