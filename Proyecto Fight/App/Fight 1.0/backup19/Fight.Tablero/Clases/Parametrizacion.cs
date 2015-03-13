using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Fight.Tablero.Clases
{
    public class Parametrizacion
    {
        public struct Puntuacion
        {
            public int puntaje;
            public int boton;
        };

        public Puntuacion PuntoA;
        public Puntuacion PuntoB;
        public Puntuacion PuntoC;

        public int tiempoMuerto { get; set; }
        public int cantJueces { get; set; }
        public int cantVotosMinimos { get; set; }

        public int cantRounds { get; set; }
        public string tiempoRound { get; set; }
        public bool goldenPoint { get; set; }

        public string tiempoDescanso { get; set; }
        public string tiempoMedico { get; set; }
        public string tiempoPuntoOro { get; set; }

        public int valorFalta { get; set; }
        public int valorPuntuacionManual { get; set; }

        public int diferenciaPuntos { get; set; }
        public int puntuacionMaxima { get; set; }
        public int faltasMaximas { get; set; }

        public Parametrizacion()
        {
            try
            {
         
            LecturaEscrituraXml objIOXML = new LecturaEscrituraXml(Application.StartupPath + "\\ParametrizacionTablero.xml");

            if (!System.IO.File.Exists(Application.StartupPath + "\\ParametrizacionTablero.xml"))
                objIOXML.GenerarXmlNuevo();

            tiempoMuerto = int.Parse(objIOXML.LeerUnCampo("TiempoMuerto"));
            cantVotosMinimos = int.Parse(objIOXML.LeerUnCampo("CantVotosMin"));

            PuntoA.boton = 1;
            PuntoA.puntaje = int.Parse(objIOXML.LeerUnCampo("ValPuntoA"));

            PuntoB.boton = 2;
            PuntoB.puntaje = int.Parse(objIOXML.LeerUnCampo("ValPuntoB"));

            PuntoC.boton = 3;
            PuntoC.puntaje = int.Parse(objIOXML.LeerUnCampo("ValPuntoC"));

            cantRounds = int.Parse(objIOXML.LeerUnCampo("CantRounds"));
            tiempoRound = objIOXML.LeerUnCampo("TiempoRound");//"00:00:00";
          
            goldenPoint = bool.Parse(objIOXML.LeerUnCampo("PuntoOro"));

            tiempoDescanso = objIOXML.LeerUnCampo("TiempoDescanso");
            tiempoMedico = objIOXML.LeerUnCampo("TiempoMedico");
            tiempoPuntoOro = objIOXML.LeerUnCampo("TiempoPuntoOro");

            valorFalta = int.Parse(objIOXML.LeerUnCampo("ValFalta"));
            valorPuntuacionManual = int.Parse(objIOXML.LeerUnCampo("ValPuntacionManual"));

            diferenciaPuntos = int.Parse(objIOXML.LeerUnCampo("DifPuntos"));
            puntuacionMaxima = int.Parse(objIOXML.LeerUnCampo("PuntuacionMax"));
            faltasMaximas = int.Parse(objIOXML.LeerUnCampo("FaltasMax"));

            }
            catch (Exception err)
            {
                throw err;
            }

        }

        public bool CargarConfiguracion()
        {
            //Obtener los parametros desde un xml
            return true;
        }


        public bool GuardarConfiguracion()
        {
            //Actualiza los valores actuales en el Xml
            return true;
        }

        public bool ReestablecerValoresIniciales()
        {
            //Vuelve a generar el Xml con los valores por defecto
            return true;
        }



    }
}
