using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Fight.Tablero.Clases
{
    public class RegistroErrores
    {
        public string pathLogCompleto = string.Empty;

        public RegistroErrores(string _pathLogCompleto)
        {
            this.pathLogCompleto = _pathLogCompleto;
        }

        public void RegistrarError(string accion, string error)
        {
            string fechaHora = string.Empty;

            try
            {
                if (!System.IO.File.Exists(pathLogCompleto))
                    System.IO.File.Create(pathLogCompleto);

                using (StreamWriter sw = new StreamWriter(pathLogCompleto, true))
                    sw.WriteLine(DateTime.Now.ToString() + " En -> " + accion + " -> Error: " + error);

            }
            catch (Exception err)
            {
                //do naranja
            }

        }
    }
}