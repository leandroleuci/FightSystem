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

namespace PruebaSeguridad
{
    public partial class Form1 : Form
    {
        string unidadEjecutable = "";
        string numeroSerie = "";
        string numeroSerieEncriptado = "";


        string pathKEY = "C:\\KEY.bat";


        // define the local key and vector byte arrays
        //byte[] key = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 
        //      13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24};
        //byte[] iv = { 8, 7, 6, 5, 4, 3, 2, 1};
        byte[] key = {131, 242, 35, 49, 58, 61, 78, 86, 95, 101, 111, 126, 
              133, 142, 153, 164, 177, 181, 196, 204, 213, 222, 234, 242};
        byte[] iv = { 82, 76, 60, 54, 47, 39, 23, 13 };



        public Form1()
        {
            InitializeComponent();
                     
        }

        private void btnObtenerUnidadDisco_Click(object sender, EventArgs e)
        {
            unidadEjecutable = Application.ExecutablePath.Substring(0, 1);

            this.txtUnidad.Text = unidadEjecutable;
            
        }

        private void btnObtenerNumeroSerie_Click(object sender, EventArgs e)
        {
            USBSerialNumber usb = new USBSerialNumber();
            numeroSerie = usb.getSerialNumberFromDriveLetter(this.unidadEjecutable);
            this.txtNumeroSerie.Text = numeroSerie;
        }


        #region tripleDES

        private void btnEncriptar_Click(object sender, EventArgs e)
        {

            this.txtNumeroSerieEncriptado.Text = Encriptar(numeroSerie);
        
        }

        private void btnDesencriptar_Click(object sender, EventArgs e)
        {
           this.txtNumeroSerieDesencriptado.Text = Desencriptar( numeroSerieEncriptado);
            
        }

        private string Encriptar(string numeroSerie)
        {
            cTripleDES des = new cTripleDES(key, iv);

            numeroSerieEncriptado = des.Encrypt(numeroSerie);
            
            return numeroSerieEncriptado;
        }

        private string Desencriptar(string numeroSerieEncriptado)
        {
            cTripleDES des = new cTripleDES(key, iv);

            return des.Decrypt(numeroSerieEncriptado);
        }


        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCrearArchivoKey_Click(object sender, EventArgs e)
        {
            CrearArchivoKey(pathKEY, numeroSerieEncriptado);
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

        private void btnLeerArchivoKEY_Click(object sender, EventArgs e)
        {
            LeerArchivoKey(pathKEY, ref numeroSerie);
            this.txtKeyLeido.Text = numeroSerie;

        }

        private bool LeerArchivoKey(string path, ref string numeroSerie)
        {
            string fic = path;
            string texto;
            bool retorno = false;

            try
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(fic);
                texto = sr.ReadToEnd();
                sr.Close();
                
                numeroSerie = texto;

                retorno = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }

        private void btnValidarKey_Click(object sender, EventArgs e)
        {
            Seguridad seguridad = new Seguridad();
            string error = "";

            if (seguridad.ValidarCopia( ref error))
                MessageBox.Show("ok");
            else
                MessageBox.Show("Error: " + error);

        }
    }               
}
