using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;

namespace PruebaLogErrores
{
    public partial class Form1 : Form
    {
        string pathLogCompleto = Application.StartupPath + "\\errorPrueba.txt"; //string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        public void PruebaLogErrores(string _pathLogCompleto)
        {
            this.pathLogCompleto = _pathLogCompleto;
        }

        private void btnNewLogError_Click(object sender, EventArgs e)
        {
            escribirTxtLogError(this.txtError.Text);

            MessageBox.Show(pathLogCompleto);
        }

        //************************
        //   escribirTxtLogError
        //************************
        //   Private Sub escribirTxtLogError(ByVal computerName As String, ByVal NombreProcedimiento As String, ByVal AccionID As Integer, ByVal ExceptionDescription As String)
        //Try

        //    Dim fechaHora As String = Now.Date.Day.ToString & "/" & Now.Date.Month.ToString & "/" & Now.Date.Year.ToString & " " & Now.TimeOfDay.Hours.ToString & ":" & Now.TimeOfDay.Minutes.ToString & ":" & Now.TimeOfDay.Seconds.ToString

        //    Dim text As String = fechaHora & "      " & computerName & "	" & NombreProcedimiento & "     " & AccionID & "	" & ExceptionDescription

        //    Using sw As IO.StreamWriter = New IO.StreamWriter(My.Settings.PathLogErrores & My.Settings.LogErroresFile, True)
        //        With sw
        //            .WriteLine(text)
        //        End With
        //        sw.Close()
        //    End Using

        //Catch ex As Exception
        //End Try

        private void escribirTxtLogError(string error)
        {
            string fechaHora = string.Empty;

            try
            {
                if ( ! System.IO.File.Exists(pathLogCompleto))
                    System.IO.File.Create(pathLogCompleto);
    
                using (StreamWriter sw = new StreamWriter(pathLogCompleto, true))
                    sw.WriteLine(DateTime.Now.ToString() + " -> Error: " + error);

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message.ToString());
            }

        }
    }
}
