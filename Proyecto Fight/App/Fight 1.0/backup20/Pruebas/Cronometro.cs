using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Pruebas
{
    public partial class Cronometro : UserControl
    {
        public string time { get; set; }
        public int interval { get; set; }


        private int horas = 0;
        private int minutos = 0;
        private int segundos = 0;

        private string strHoras = "00";
        private string strMinutos = "00";
        private string strSegundos = "00";


        public Cronometro()
        {
            InitializeComponent();
            interval = 1000;
            ConfigurarCronometro();
        }

        private void ConfigurarCronometro()
        {
            this.tmrCronometro.Interval = interval;
        }

        public void Start()
        {
            this.tmrCronometro.Enabled = true;
            this.tmrCronometro.Start();
        }

        public void Stop()
        {
            this.tmrCronometro.Enabled = false;
            this.tmrCronometro.Stop();

            horas = 0;
            minutos = 0;
            segundos = 0;

            strHoras = "00";
            strMinutos = "00";
            strSegundos = "00";
        }

        public void Pause()
        {
            this.tmrCronometro.Enabled = false;
            this.tmrCronometro.Stop();
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





    }
}
