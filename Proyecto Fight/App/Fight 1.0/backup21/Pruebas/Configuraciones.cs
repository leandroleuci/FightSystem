//http://www.mono-hispano.org/wiki/Tutorial_de_XML_con_C_Sharp

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using System.IO;
using System.Xml;

namespace Fight.WIN
{
    public partial class Configuraciones : Form
    {

        static string xmlPath = "D:\\AppVs2008\\Fight\\Fight.WIN\\Configuraciones\\Configuraciones.xml";
        private int rounds;
        private string tiempoRound1;
        private string tiempoRound2;
        private string tiempoDescanso1;
        private string tiempoDescanso2;

        public Configuraciones()
        {
            InitializeComponent();

            CargarConfiguraciones(xmlPath);
            MostrarValoresConfiguracionEnPantalla();
        }


        //Esta Funcion permite Leer un Archivo XML
        private void CargarConfiguraciones(string xmlPath)
        {
            //Declaramor un lector para el XML indicando el nombre de este
            StreamReader reader = new StreamReader(xmlPath, System.Text.Encoding.UTF8);

            //Indicamos cual es el nombre de lector XML a usar en este caso es reader
            XmlTextReader xml = new XmlTextReader(reader);
            xml.Namespaces = false;

            //Hacemos un ciclo para leer cada uno de los nodos del XML
            while (xml.Read())
            {
                //Vamos a leer cada uno de los elementos que contiene el archivo XML
                //En este ejemplo los elementos son nombre,apellido_p,apellido_,
                // y edad incluidos dentro del Nodo principal llamado Persona

                switch (xml.NodeType)
                {
                    case XmlNodeType.Element:
                        switch (xml.Name)
                        {
                            case "fight":
                                break;
                            case "rounds":
                                //Leemos el valor elemento Nombre
                                rounds = Convert.ToInt16(xml.ReadString());
                                break;
                            case "tiempoRound1":
                                tiempoRound1 = xml.ReadString();
                                break;
                            case "tiempoRound2":
                                tiempoRound2 = xml.ReadString();
                                break;
                            case "tiempoDescanso1":
                                tiempoDescanso1 = xml.ReadString();
                                break;
                            case "tiempoDescanso2":
                                tiempoDescanso2 = xml.ReadString();
                                break;
                        }
                        break;
                }
            }

            //Cerramos el lector de XML
            xml.Close();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            GuardarConfiguraciones(xmlPath);
        }


        //Esta funcion permite escribir en un archivo XML
        public void GuardarConfiguraciones(string xmlPath)
        {

            //Declaramos un escritor de texto XML, indicando cual es el nombre del archivo XML
            XmlTextWriter xml = new XmlTextWriter(xmlPath, System.Text.Encoding.UTF8);

            xml.Formatting = Formatting.Indented;

            //Inicializamos el Documento XML
            xml.WriteStartDocument();

                //Escribimos el Elemento Principal (Persona)
                xml.WriteStartElement(null, "fight", null);

                    xml.WriteStartElement(null, "rounds", null);
                    xml.WriteString(this.nudRounds.Value.ToString());
                    xml.WriteEndElement();

                    xml.WriteStartElement(null, "tiempoRound1", null);
                    xml.WriteString(this.mtxtTiempoRound1.Text);
                    xml.WriteEndElement();

                    xml.WriteStartElement(null, "tiempoRound2", null);
                    xml.WriteString(this.mtxtTiempoRound2.Text);
                    xml.WriteEndElement();

                    xml.WriteStartElement(null, "tiempoDescanso1", null);
                    xml.WriteString(this.mtxtTiempoDescanso1.Text);
                    xml.WriteEndElement();

                    xml.WriteStartElement(null, "tiempoDescanso2", null);
                    xml.WriteString(this.mtxtTiempoDescanso2.Text);
                    xml.WriteEndElement();

                xml.WriteEndElement(); //Cerramos el Elemento Principal </persona>
            
            xml.WriteEndDocument(); //Cerramos el Documento XML

            xml.Close(); //Cerramos el Escritor XML
        }

        //Esta Funcion carga en pantalla los valores extraidos del XML configuración
        private void MostrarValoresConfiguracionEnPantalla()
        {
            this.nudRounds.Value = this.rounds;

            this.mtxtTiempoRound1.Text = tiempoRound1;
            this.mtxtTiempoRound2.Text = tiempoRound2;

            this.mtxtTiempoDescanso1.Text = tiempoDescanso1;
            this.mtxtTiempoDescanso2.Text = tiempoDescanso2;
        }
    }
}
