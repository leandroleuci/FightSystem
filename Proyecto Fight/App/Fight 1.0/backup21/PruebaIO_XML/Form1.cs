﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using System.IO;
using System.Xml;
//using Gtk;
//using Gnome;

namespace PruebaIO_XML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnObtenerPathXML_Click(object sender, EventArgs e)
        {
            this.txtPathXML.Text = ObtenerPathXML();
        }


        private void btnLeerXml_Campo_Click(object sender, EventArgs e)
        {
            this.txtValorCampoElegido.Text = "PuntoOro: " + LeerUnCampo(ObtenerPathXML(), "PuntoOro");

        }

        private void btnActualizarXML_Click(object sender, EventArgs e)
        {
            ActualizarXML(ObtenerPathXML(), "3000", "3", "1", "2", "3", "2", "00:01:30", "0", "00:01:00", "00:01:00", "00:01:00", "1", "1", "99", "99", "99");
        }



        #region Métodos Privados IO XML

        private string ObtenerPathXML()
        {
            return Application.StartupPath + "\\XmlPrueba.xml";
            //Path completo -> string sExe = Application.ExecutablePath;
            //nombre ejecutable -> System.IO.Path.GetFileName(Application.ExecutablePath);
        }

        //Esta Funcion permite Leer un Archivo XML
        public string LeerUnCampo(string pathXmlCompleto, string campoLeer)
        {
            string campo = "";
            //Declaramor un lector para el XML indicando el nombre de este
            StreamReader reader = new StreamReader(pathXmlCompleto, System.Text.Encoding.UTF8);

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

                        if (xml.Name == campoLeer)
                            campo = xml.ReadString();

                        //switch (xml.Name)
                        //{
                        //    case campoLeer:
                        //        //Leemos el valor elemento Nombre
                        //        campo = xml.ReadString();
                        //    break;
                        //}
                        break;
                }
            }

            //Cerramos el lector de XML
            xml.Close();

            return campo;

        }

        //Esta funcion permite escribir en un archivo XML
        public void ActualizarXML(string pathXmlCompleto, string TiempoMuerto, string CantVotosMin, string ValPuntoA, string ValPuntoB, string ValPuntoC, string CantRounds, string TiempoRound, string PuntoOro, string TiempoDescanso, string TiempoMedico, string TiempoPuntoOro, string ValFalta, string ValPuntacionManual, string DifPuntos, string PuntuacionMax, string FaltasMax)
        {

            //Declaramos un escritor de texto XML, indicando cual es el nombre del archivo XML
            XmlTextWriter xml = new XmlTextWriter(pathXmlCompleto, System.Text.Encoding.UTF8);

            xml.Formatting = Formatting.Indented;

            //Inicializamos el Documento XML
            xml.WriteStartDocument();

            //Escribimos el Elemento Principal (Persona)
            xml.WriteStartElement(null, "tablero", null);


            xml.WriteStartElement(null, "TiempoMuerto", null);
            xml.WriteString(TiempoMuerto);
            xml.WriteEndElement();

            xml.WriteStartElement(null, "CantVotosMin", null);
            xml.WriteString(CantVotosMin);
            xml.WriteEndElement();

            xml.WriteStartElement(null, "ValPuntoA", null);
            xml.WriteString(ValPuntoA);
            xml.WriteEndElement();

            xml.WriteStartElement(null, "ValPuntoB", null);
            xml.WriteString(ValPuntoB);
            xml.WriteEndElement();

            xml.WriteStartElement(null, "ValPuntoC", null);
            xml.WriteString(ValPuntoC);
            xml.WriteEndElement();

            xml.WriteStartElement(null, "CantRounds", null);
            xml.WriteString(CantRounds);
            xml.WriteEndElement();

            xml.WriteStartElement(null, "TiempoRound", null);
            xml.WriteString(TiempoRound);
            xml.WriteEndElement();

            xml.WriteStartElement(null, "PuntoOro", null);
            xml.WriteString(PuntoOro);
            xml.WriteEndElement();

            xml.WriteStartElement(null, "TiempoDescanso", null);
            xml.WriteString(TiempoDescanso);
            xml.WriteEndElement();

            xml.WriteStartElement(null, "TiempoMedico", null);
            xml.WriteString(TiempoMedico);
            xml.WriteEndElement();

            xml.WriteStartElement(null, "TiempoPuntoOro", null);
            xml.WriteString(TiempoPuntoOro);
            xml.WriteEndElement();

            xml.WriteStartElement(null, "ValFalta", null);
            xml.WriteString(ValFalta);
            xml.WriteEndElement();

            xml.WriteStartElement(null, "ValPuntacionManual", null);
            xml.WriteString(ValPuntacionManual);
            xml.WriteEndElement();

            xml.WriteStartElement(null, "DifPuntos", null);
            xml.WriteString(DifPuntos);
            xml.WriteEndElement();

            xml.WriteStartElement(null, "PuntuacionMax", null);
            xml.WriteString(PuntuacionMax);
            xml.WriteEndElement();

            xml.WriteStartElement(null, "FaltasMax", null);
            xml.WriteString(FaltasMax);
            xml.WriteEndElement();


            xml.WriteEndElement(); //Cerramos el Elemento Principal </persona>
            xml.WriteEndDocument(); //Cerramos el Documento XML
            xml.Close(); //Cerramos el Escritor XML
        }

        #endregion




    }
}
