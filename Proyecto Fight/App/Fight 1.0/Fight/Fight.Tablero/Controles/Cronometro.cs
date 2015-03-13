using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Fight.Controles
 {
    public partial class Cronometro : UserControl
    {
        public string time { get; set; }
        public int interval { get; set; }
      private bool descendente { get; set; }

        private bool flagColorIntermitente = false;

        public event EventHandler FinCrono; 

        public Cronometro(bool superpuesto)
        {
            InitializeComponent();

            if (superpuesto)
                lblCronometro.ForeColor = Color.Black;
            else
                lblCronometro.ForeColor = Color.GreenYellow;

                interval = 1000;
            ConfigurarCronometro();
        }

        private void ConfigurarCronometro()
        {
            this.tmrCronometro.Interval = interval;
        }

        public void Start()
        {
            this.descendente = false;
            this.tmrCronometro.Enabled = true;
            this.tmrCronometro.Start();
        }


        public void Restart()
        {
            this.lblCronometro.Text = "00:00:00";

            Pause();
        }

        public void StartDescendente()
        {
            //lblCronometro.ForeColor = Color.Black;
            this.lblCronometro.Text = time;

            this.descendente = true;
            this.tmrCronometro.Enabled = true;
            this.tmrCronometro.Start();
        }
        

        public void Stop()
        {
            this.tmrCronometro.Enabled = false;
            this.tmrCronometro.Stop();

            Reiniciar();
        }

        public void Reiniciar()
        {
            this.lblCronometro.Text = "00:00:00"; 
        }

        public void Pause()
        {
            this.tmrCronometro.Enabled = false;
            this.tmrCronometro.Stop();
        }

        private void tmrCronometro_Tick(object sender, EventArgs e)
        {
            if (!descendente)
            {
                this.lblCronometro.Text = DateTime.Parse(lblCronometro.Text).AddSeconds(1).ToString("HH:mm:ss");

                if (this.lblCronometro.Text == time)
                {
                    tmrCronometro.Stop();
                    //lblCronometro.ForeColor = Color.Blue;
                    FinCrono.Invoke(sender, e);
                }
            }
            else
            {
                this.lblCronometro.Text = DateTime.Parse(lblCronometro.Text).Subtract(new TimeSpan(0, 0, 0, 0, 1)).ToString("HH:mm:ss");
                if (lblCronometro.Text.Equals("00:00:00"))
                {
                    tmrCronometro.Stop();
                    //lblCronometro.ForeColor = Color.Red;
                    FinCrono.Invoke(sender, e);
                }
            }
     
          


        }

        private void Cronometro_Load(object sender, EventArgs e)
        {

        }


        public void ResaltarColores()
        {
            this.tmrRelojColorIntermitente.Enabled = true;
            this.tmrRelojColorIntermitente.Start();
        }

        private void tmrRelojColorIntermitente_Tick(object sender, EventArgs e)
        {
            if (flagColorIntermitente)
            {
                lblCronometro.ForeColor = Color.White;
               // this.BackColor = Color.Black;

                flagColorIntermitente = ! flagColorIntermitente;
            }
            else
            {
                lblCronometro.ForeColor = Color.Black;
                //this.BackColor = Color.White;

                flagColorIntermitente = !flagColorIntermitente;
            }
        }
    }
}
