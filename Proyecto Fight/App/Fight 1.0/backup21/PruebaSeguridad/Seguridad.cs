using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PruebaSeguridad
{
    public class Seguridad
    {

        byte[] key = {131, 242, 35, 49, 58, 61, 78, 86, 95, 101, 111, 126, 
              133, 142, 153, 164, 177, 181, 196, 204, 213, 222, 234, 242};
        byte[] iv = { 82, 76, 60, 54, 47, 39, 23, 13 };


        #region leer el key

        private bool LeerArchivoKey(ref string numeroSerie)
        {
            string fic = Application.ExecutablePath.Substring(0, 1) + ":\\KEY.bat";
            string texto;
            bool retorno = false;

            try
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(fic);
                texto = sr.ReadLine();
                //texto = sr.ReadToEnd();

                sr.Close();

                numeroSerie = texto;

                retorno = true;
            }
            catch (Exception ex)
            {
                //  throw ex;
            }

            return retorno;
        }

        #endregion

        #region leer el Id del pen

              
        private bool ObtenerNumeroSerie(ref string numeroSerie)
        {
            bool retorno = false;

            try
            {

                USBSerialNumber usb = new USBSerialNumber();
                numeroSerie = usb.getSerialNumberFromDriveLetter(Application.ExecutablePath.Substring(0, 1));

                if (numeroSerie != null)
                    retorno = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;

        }

        #endregion

        #region  generar el key

        private bool Encriptar(ref string numeroSerieEncriptado)
        {
            bool retorno = false;
            string numeroSerie = "";

            try
            {

                cTripleDES des = new cTripleDES(key, iv);

                if (ObtenerNumeroSerie(ref numeroSerie))
                {
                    numeroSerieEncriptado = des.Encrypt(numeroSerie);

                    retorno = true;
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }

            return retorno;
        }

        #endregion

        //comparar con el key.bat

        public bool ValidarCopia(ref string error)
        {
            bool retorno = false;

            string numeroSerieKey = "", numeroSerieEncriptado = "";

            if (LeerArchivoKey(ref numeroSerieKey))
                if (Encriptar(ref numeroSerieEncriptado))
                    if (String.Compare(numeroSerieKey, numeroSerieEncriptado) == 0)
                        retorno = true;
                    else
                        error = "CopiaIlegal";
                else
                    error = "EncriptadoNumeroSerie";
            else
                error = "LecturaKeyBat";


            return retorno;
        }
    }


}