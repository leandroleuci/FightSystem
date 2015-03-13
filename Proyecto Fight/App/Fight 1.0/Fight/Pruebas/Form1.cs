using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fight.Tablero
{
    public partial class Form1 : Form
    {
        private int horas = 0;
        private int minutos = 0;
        private int segundos = 0;

        private string strHoras = "00";
        private string strMinutos = "00";
        private string strSegundos = "00";

        public Form1()
        {
            InitializeComponent();

        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            this.tmrCronometro.Enabled = true;
            this.tmrCronometro.Start();
        }

        private void tmrCronometro_Tick(object sender, EventArgs e)
        {
            segundos = segundos + 1;

            if (segundos > 59)
            {
                minutos = minutos + 1;
                segundos = 0;
            }

            if (minutos > 59)
            {
                horas = horas + 1;
                minutos = 0;
            }

            if (segundos < 10)
            {
                strSegundos = "0" + segundos.ToString();
            }
            else
            {
                strSegundos = segundos.ToString();
            }


            if (minutos < 10)
            {
                strMinutos = "0" + minutos.ToString();
            }
            else
            {
                strMinutos = minutos.ToString();
            }


            if (horas < 10)
            {
                strHoras = "0" + horas.ToString();
            }
            else
            {
                strHoras = horas.ToString();
            }

            this.lblCronometro.Text = strHoras + ":" + strMinutos + ":" + strSegundos;
        }


        //Private Sub Command1_Click()
        //Timer1.Interval = 1000
        //End Sub

        //Private Sub Command2_Click()
        //Timer1.Interval = 0
        //End Sub

        //Private Sub Timer1_Timer()
        //    Segundos = Segundos + 1
        //    If Segundos > 59 Then
        //        Minutos = Minutos + 1
        //        Segundos = 0
        //    End If

        //    If Minutos > 59 Then
        //        Horas = Horas + 1
        //        Minutos = 0
        //    End If

        //        Text1 = Horas & ":" & Minutos & ":" & Segundos
        //End Sub

    }
}
