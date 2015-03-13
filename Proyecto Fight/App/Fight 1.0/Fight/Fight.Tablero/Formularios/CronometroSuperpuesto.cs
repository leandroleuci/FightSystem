using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fight.Tablero.Formularios
{
    public partial class CronometroSuperpuesto : Form
    {
        private bool Descanso = false;
        private bool Medico = false;

        private string tiempo = "";

        bool descendente = true;

        bool flagColorIntermitente = false;

        System.Drawing.Point parentPoint;

        #region CronometroTablero
        public string Cronometrotime { get; set; }
        public int Cronometrointerval { get; set; }
        private bool Cronometrodescendente { get; set; }

        private bool CronometroflagColorIntermitente = false;

        //public event EventHandler FinCrono;
        #endregion

        Clases.Parametrizacion objParametrizacion;

        public CronometroSuperpuesto(bool Descanso, bool Medico, string tiempo, System.Drawing.Point _parentPoint)
        {
            InitializeComponent();

            objParametrizacion = new Clases.Parametrizacion();

            this.tiempo = tiempo;

            this.Descanso = Descanso;
            this.Medico = Medico;

            this.parentPoint = _parentPoint;
        }

        private void CronometroSuperpuesto_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Parent - > X = " + this.Parent.Location.X + " Y = " + this.Parent.Location.Y);

            //System.Drawing.Point a = new System.Drawing.Point(parentPoint.X + 322, parentPoint.Y + 3);

            // this.Parent.Location.X + 
            // this.Parent.Location.Y + 

            this.Location = new System.Drawing.Point(parentPoint.X + 322, parentPoint.Y + 100); ;

            //MessageBox.Show("This - > X = " + this.Location.X + " Y = " + this.Location.Y); 

            if (Medico)
            {
                this.Cronometrotime = tiempo;

                this.pbIconoTipoCrono.Image = Fight.Tablero.Properties.Resources.IconoTiempoMedico;
            }
            else
                if (Descanso)
                {
                    this.Cronometrotime = tiempo;

                    this.pbIconoTipoCrono.Image = Fight.Tablero.Properties.Resources.IconoTiempoDescanso;
                }

            //if (Descanso)
            this.CronometroStartDescendente();
            //else
            // if (Medico)
            //    this.CronometroStart();
        }



        private void cronometro_FinCrono(object sender, EventArgs e)
        {
        }

        private void cronometro_FinCrono_1(object sender, EventArgs e)
        {
            ReproducirSilbato();
        }

        private void cronometro_Load(object sender, EventArgs e)
        {

        }






        #region '   Cronometro

        //private void pPausePlay_Click(object sender, EventArgs e)
        //{
        //    if (pause == true)
        //    {
        //        this.pPausePlay.BackgroundImage = null;

        //        pause = false;

        //        habilitaVotacion = true;

        //        objFight.estadoPelea = enumEstado.EnCurso.GetHashCode();

        //        if (objFight.roundActual <= objParametrizacion.cantRounds)
        //            ActualizarAvisoEstadoPelea("Round " + objFight.roundActual.GetHashCode().ToString());
        //        else
        //            ActualizarAvisoEstadoPelea("Por comenzar round: Golden Point");

        //        this.CronometroStart();
        //    }
        //    else
        //    {
        //        this.pPausePlay.BackgroundImage = global::Fight.Tablero.Properties.Resources.Pause;

        //        this.pause = true;
        //        habilitaVotacion = false;

        //        objFight.estadoPelea = enumEstado.Pause.GetHashCode();
        //        ActualizarAvisoEstadoPelea("Round " + objFight.roundActual.GetHashCode().ToString() + " PAUSA");
        //        this.CronometroPause();
        //    }

        //}

        //private void pCruzMedico_Click(object sender, EventArgs e)
        //{

        //    if (objFight.estadoPelea == enumEstado.EnCurso.GetHashCode() || objFight.estadoPelea == enumEstado.Pause.GetHashCode())
        //    {
        //        this.pCruzMedico.BackgroundImage = global::Fight.Tablero.Properties.Resources.CruzMedico;

        //        habilitaVotacion = false;

        //        objFight.estadoPelea = enumEstado.TiempoMedico.GetHashCode();
        //        ActualizarAvisoEstadoPelea("Tiempo Médico");

        //        this.CronometroPause();

        //        CronometroSuperpuesto objCronoTiempoMedico = new CronometroSuperpuesto(false, true);

        //        objCronoTiempoMedico.ShowDialog();

        //        objFight.estadoPelea = enumEstado.Pause.GetHashCode();

        //        ActualizarAvisoEstadoPelea("En PAUSA");
        //        this.pPausePlay.BackgroundImage = global::Fight.Tablero.Properties.Resources.Pause;
        //        this.pause = true;


        //        this.pCruzMedico.BackgroundImage = null;
        //    }
        //}

        //private void pStop_Click(object sender, EventArgs e)
        //{
        //    this.pStop.BackgroundImage = global::Fight.Tablero.Properties.Resources.Stop;

        //    habilitaVotacion = false;

        //    this.CronometroPause();
        //    objFight.estadoPelea = enumEstado.Pause.GetHashCode();
        //    ActualizarAvisoEstadoPelea("En PAUSA");

        //    var result = MessageBox.Show("¿Está seguro que desea parar la pelea?", "Advertencia",
        //                               MessageBoxButtons.OKCancel,
        //                               MessageBoxIcon.Question);

        //    // If the no button was pressed ...
        //    if (result == DialogResult.OK)
        //    {
        //        objFight.estadoPelea = enumEstado.Inicio.GetHashCode();
        //        LimpiarControles();
        //        this.CronometroStop();

        //        ActualizarAvisoEstadoPelea("En Espera");
        //    }

        //    this.pStop.BackgroundImage = null;
        //}



        #region cronometro superpuesto



        public void CronometroStart()
        {
            this.Cronometrodescendente = false;
            this.tmrCronometro.Enabled = true;
            this.tmrCronometro.Start();
        }


        public void CronometroRestart()
        {
            this.lblCronometro.Text = "00:00:00";

            CronometroPause();
        }


        public void CronometroStop()
        {
            this.tmrCronometro.Enabled = false;
            this.tmrCronometro.Stop();

            CronometroReiniciar();
        }

        public void CronometroReiniciar()
        {
            this.lblCronometro.Text = "00:00:00";
        }

        public void CronometroPause()
        {
            this.tmrCronometro.Enabled = false;
            this.tmrCronometro.Stop();
        }

        private void tmrCronometro_Tick_1(object sender, EventArgs e)
        {

        }


        public void ResaltarColores()
        {
            this.tmrRelojColorIntermitente.Enabled = true;
            this.tmrRelojColorIntermitente.Start();
        }

        private void tmrRelojColorIntermitente_Tick_1(object sender, EventArgs e)
        {

        }

        public void CronometroStartDescendente()
        {
            //lblCronometro.ForeColor = Color.Black;
            this.lblCronometro.Text = tiempo;

            this.descendente = true;
            this.tmrCronometro.Enabled = true;
            this.tmrCronometro.Start();
        }


        #endregion

        private void tmrCronometro_Tick(object sender, EventArgs e)
        {
            if (!descendente)
            {
                this.lblCronometro.Text = DateTime.Parse(lblCronometro.Text).AddSeconds(1).ToString("HH:mm:ss");

                if (this.lblCronometro.Text == tiempo)
                {
                    tmrCronometro.Stop();
                    //lblCronometro.ForeColor = Color.Blue;
                    this.tmrRelojColorIntermitente.Enabled = true;

                    ReproducirSilbato();
                }
            }
            else
            {
                this.lblCronometro.Text = DateTime.Parse(lblCronometro.Text).Subtract(new TimeSpan(0, 0, 0, 0, 1)).ToString("HH:mm:ss");
                if (lblCronometro.Text.Equals("00:00:00"))
                {
                    tmrCronometro.Stop();
                    //lblCronometro.ForeColor = Color.Red;
                    this.tmrRelojColorIntermitente.Enabled = true;

                    ReproducirSilbato();
                }
            }

        }



        #endregion

        private void tmrRelojColorIntermitente_Tick(object sender, EventArgs e)
        {
            if (flagColorIntermitente)
            {
                lblCronometro.ForeColor = Color.White;
                // this.BackColor = Color.Black;

                flagColorIntermitente = !flagColorIntermitente;
            }
            else
            {
                lblCronometro.ForeColor = Color.Black;
                //this.BackColor = Color.White;

                flagColorIntermitente = !flagColorIntermitente;
            }
        }



        #region Close
        private void CronometroSuperpuesto_DoubleClick(object sender, EventArgs e)
        {
            this.tmrCronometro.Stop();
            Close();
        }

        private void cronometro_DoubleClick(object sender, EventArgs e)
        {
            this.tmrCronometro.Stop();
            Close();
        }

        private void pbCruzMedico_Click(object sender, EventArgs e)
        {
            this.tmrCronometro.Stop();
            Close();
        }
        #endregion

        private void ReproducirSilbato()
        {
            try
            {
                System.Media.SoundPlayer mediaSoundPlayer = new System.Media.SoundPlayer();

                mediaSoundPlayer.Stream = Properties.Resources.Silbato;
                mediaSoundPlayer.Play();
            }
            catch (Exception ex)
            {
                //do naranja
            }
        }


    }
}
