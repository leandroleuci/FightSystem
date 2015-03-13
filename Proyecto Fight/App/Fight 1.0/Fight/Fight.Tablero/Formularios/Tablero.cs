using System;
using System.Drawing;
using System.Windows.Forms;
using Fight.Tablero.Entidades;

namespace Fight.Tablero.Formularios
{
    public partial class Tablero : Form
    {
        #region ' Flag Habilitacion Botones Votacion

        private bool Habil_J1_Azul_PA = true, Habil_J1_Azul_PB = true, Habil_J1_Azul_PC = true;

        private bool Habil_J1_Rojo_PA = true, Habil_J1_Rojo_PB = true, Habil_J1_Rojo_PC = true;

        private bool Habil_J2_Azul_PA = true, Habil_J2_Azul_PB = true, Habil_J2_Azul_PC = true;

        private bool Habil_J2_Rojo_PA = true, Habil_J2_Rojo_PB = true, Habil_J2_Rojo_PC = true;

        private bool Habil_J3_Azul_PA = true, Habil_J3_Azul_PB = true, Habil_J3_Azul_PC = true;

        private bool Habil_J3_Rojo_PA = true, Habil_J3_Rojo_PB = true, Habil_J3_Rojo_PC = true;

        private bool Habil_J4_Azul_PA = true, Habil_J4_Azul_PB = true, Habil_J4_Azul_PC = true;

        private bool Habil_J4_Rojo_PA = true, Habil_J4_Rojo_PB = true, Habil_J4_Rojo_PC = true;

        #endregion

        #region ' Joystick

        private Joystick jst1, jst2, jst3, jst4, jstTemp;

        int cantJoystick = 0;

        bool habilitaVotacion = false;

        #endregion

        #region CronometroTablero

        private string cronometroTime { get; set; }
        private int Cronometrointerval { get; set; }
        private bool Cronometrodescendente { get; set; }
        private bool cronometroflagColorIntermitente = false;

        #endregion

        private bool mediaFaltaAzul;
        private bool mediaFaltaRojo;

        private bool pause = true;
        private bool ganadorIntermitente = false;

        Ataque objAtaque = null;
        Punto objPunto = null;

        Clases.Fight objFight = null;
        Clases.Parametrizacion objParametrizacion = null;
        Clases.RegistroErrores objRegErr = null;

        #region Auditoria
        Auditoria exportarAuditoria;
        AuditoriaDTO dsAtuditoria;
        bool habilitarArchAuditoria = false;
        int auditoriaPuntosRojo = 0;
        int auditoriaPuntosAzul = 0;
        int[] auditoriaAzul;
        int[] auditoriaRojo;
        #endregion Auditoria

        public Tablero()
        {
            InitializeComponent();

            objRegErr = new Clases.RegistroErrores(Application.StartupPath + "\\TableroErrorLog.txt");

            try
            {
                objParametrizacion = new Clases.Parametrizacion();
            }
            catch (Exception err)
            {
                MessageBox.Show("Ocurrió un error en la carga de los datos de Parametrización. Por favor póngase en contacto con el proveedor de la aplicación.", "Carga de Parametrización");
                objRegErr.RegistrarError("Carga de Parametrización.", err.Message.ToString());
                Application.Exit();
            }

            objFight = new Clases.Fight();

            CargarConfiguraciones();

            objFight.DiferenciaPuntos += new EventHandler(DiferenciaPutos_EventHandler);
            objFight.MaximaFaltas += new EventHandler(MaximaFaltas_EventHandler);
            objFight.PuntuacionMaxima += new EventHandler(PuntuacionMaxima_EventHandler);



        }

        private void Tablero_Load(object sender, EventArgs e)
        {
            AboutBox1 objAboutBox1 = new AboutBox1();

            objAboutBox1.ShowDialog();

            DialogResult result = DialogResult.Yes;
            //result = MessageBox.Show("¿Habilitamos la Validación de Seguridad?", "Fight", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //ValidarSeguridad
                try
                {
                    string error = "";

                    if (!ValidarKey(ref error))
                    {
                        MessageBox.Show("Se produjo un error en la validación de seguridad de la aplicación. Motivo: " + error, "Validación de copia");
                        MessageBox.Show("La aplicación se cerrará.");

                        Application.Exit();
                    }
                }
                catch (Exception err)
                {
                    objRegErr.RegistrarError("Validación de Seguridad", err.Message.ToString());
                }
            }

            #region Deshabilitación de imagenes
            this.pbCruzCerrar.Visible = false;
            this.pbMediaFalta_Izq.BackgroundImage = null;
            this.pbMediaFalta_Der.BackgroundImage = null;
            this.pPausePlay.BackgroundImage = null;
            this.pStop.BackgroundImage = null;
            this.pCruzMedico.BackgroundImage = null;
            #endregion


            result = MessageBox.Show("¿Habilitamos el manejo de Joysticks?", "Fight", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                #region Manejo de Joystick - Deshabilito para testing
                int cantJoysticks = 0;

                try
                {
                    if (!ObtenerJoysticksConectados(ref cantJoysticks))
                    {
                        #region Deshabilitación de controles por no encontrar joysticks instalados
                        //habilitaVotacion = false;
                        //this.tmrCalcularVotacion.Enabled = false;
                        this.tmrLeerJoysticks.Enabled = false;

                        foreach (System.Windows.Forms.Control ctrl in this.Controls)
                        {

                            if (ctrl.Name.ToString() == "pCerrar" || ctrl.Name.ToString() == "pbCruzCerrar" || ctrl.Name.ToString() == "btnAuditoria")
                                ctrl.Enabled = true;
                            else
                                ctrl.Enabled = false;

                        }

                        if (cantJoystick == 0)
                            MessageBox.Show("No se ha encontrado ningún Joystick conectado. El Tablero no podrá leer los votos.", "Búsqueda de Joysticks");
                        else
                            MessageBox.Show("Joysticks encontrados: " + cantJoystick.ToString() + " . El parámetro de cantidad de votaciónes mínimas supera la cantidad de Joysticks conectados. No podrá funcionar el Tablero", "Búsqueda de Joysticks");
                        #endregion

                    }
                    else
                        this.tmrCalcularVotacion.Enabled = true;
                }
                catch (Exception err)
                {
                    objRegErr.RegistrarError("Obtención de joysticks conectados", err.Message.ToString());
                    AvisoReinicioApp();
                }
                #endregion Manejo de Joystick - Deshabilito para testing
            }

            #region - Inicio objetos para Auditoria -
            //Se crea por única vez, recrear al dar Stop.
            auditoriaAzul = new int[objParametrizacion.cantJueces.GetHashCode()];
            auditoriaRojo = new int[objParametrizacion.cantJueces.GetHashCode()];


            dsAtuditoria = new AuditoriaDTO();
            exportarAuditoria = new Auditoria();
            #endregion

            Auditar(enumEventosAuditoria.InicioAuditoria);

        }

        #region Eventos

        public void DiferenciaPutos_EventHandler(object sender, EventArgs e)
        {
            try
            {
                CronometroPause();
                FinPelea(false, true, false);
            }
            catch (Exception err)
            {
                objRegErr.RegistrarError("Diferencia de Puntos. Finalizar Pelea", err.Message.ToString());
                AvisoReinicioApp();
            }

        }

        public void MaximaFaltas_EventHandler(object sender, EventArgs e)
        {
            try
            {
                CronometroPause();
                FinPelea(true, false, false);
            }
            catch (Exception err)
            {
                objRegErr.RegistrarError("Máximo de faltas. Finalizar Pelea", err.Message.ToString());
                AvisoReinicioApp();
            }
        }

        public void PuntuacionMaxima_EventHandler(object sender, EventArgs e)
        {
            try
            {
                CronometroPause();
                FinPelea(false, false, true);
            }
            catch (Exception err)
            {
                objRegErr.RegistrarError("Puntuación Máxima. Finalizar Pelea", err.Message.ToString());
                AvisoReinicioApp();
            }

        }

        private void FinCrono()
        {
            try
            {
                ReproducirSilbato();

                habilitaVotacion = false;

                if (objFight.roundActual.GetHashCode() == enumEstado.GoldenPoint.GetHashCode())
                {
                    FinPelea(false, false, false);
                    return;
                }

                if (objFight.roundActual.GetHashCode() == objParametrizacion.cantRounds)
                {
                    if (objParametrizacion.goldenPoint)
                        objFight.roundActual = enumEstado.GoldenPoint.GetHashCode();
                    else
                    {
                        FinPelea(false, false, false);
                        return;
                    }
                }
                else
                    if (objFight.roundActual.GetHashCode() < objParametrizacion.cantRounds)
                        objFight.roundActual += 1;

                objFight.estadoPelea = enumEstado.Descaso.GetHashCode();

                Auditar(enumEventosAuditoria.InicioDescanso);

                CronometroSuperpuesto objCronoDescanso = new CronometroSuperpuesto(true, false, objParametrizacion.tiempoDescanso, this.Location);

                objCronoDescanso.ShowDialog();

                Auditar(enumEventosAuditoria.FinDescanso);

                CronometroRestart();

                objFight.estadoPelea = enumEstado.Pause.GetHashCode();
                pause = true;

                this.pPausePlay.BackgroundImage = null;


                if (objFight.roundActual <= objParametrizacion.cantRounds)
                    ActualizarAvisoEstadoPelea("Round " + objFight.roundActual.GetHashCode().ToString());
                else
                    ActualizarAvisoEstadoPelea("Golden Point");
            }
            catch (Exception err)
            {
                objRegErr.RegistrarError("Fin cronometro", err.Message.ToString());
                AvisoReinicioApp();
            }

        }

        private void pCerrar_MouseClick(object sender, MouseEventArgs e)
        {
            this.pbCruzCerrar.Visible = true;
            if (MessageBox.Show("¿Está seguro de salir del tablero?", "Tablero", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                this.Close();
            else
                this.pbCruzCerrar.Visible = false;
        }

        private void Tablero_DoubleClick(object sender, EventArgs e)
        {

        }

        private void tsmiCambiarNombres_Click(object sender, EventArgs e)
        {
            CambiarNombre();
        }


        #region MenuOpciones
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                MostrarAuditoria((AuditoriaDTO.AuditoriaDTDataTable)dsAtuditoria.Tables[0]);
            }
            catch (Exception err)
            {
                objRegErr.RegistrarError("Carga Parametrización", err.Message.ToString());
                //   AvisoReinicioApp();
            }
        }

        private void tsmiConfiguraciones_Click(object sender, EventArgs e)
        {
            try
            {
                Parametrizacion objParametrizacion = new Parametrizacion(this.objParametrizacion);

                objParametrizacion.ShowDialog();
            }
            catch (Exception err)
            {
                objRegErr.RegistrarError("Carga Parametrización", err.Message.ToString());
                AvisoReinicioApp();
            }
        }
        #endregion MenuOpciones

        #endregion

        #region Cronometro

        private void pPausePlay_Click(object sender, EventArgs e)
        {

            this.habilitarArchAuditoria = true;

            if (pause == true || objFight.estadoPelea == enumEstado.Inicio.GetHashCode())
            {
                this.pPausePlay.BackgroundImage = global::Fight.Tablero.Properties.Resources.Pause;

                pause = false;

                habilitaVotacion = true;

                objFight.estadoPelea = enumEstado.EnCurso.GetHashCode();

                if (objFight.roundActual <= objParametrizacion.cantRounds)
                    ActualizarAvisoEstadoPelea("Round " + objFight.roundActual.GetHashCode().ToString());
                else
                    ActualizarAvisoEstadoPelea("Golden Point");

                this.CronometroStart();

                Auditar(enumEventosAuditoria.ContinuarPelea);
            }
            else
            {
                this.pPausePlay.BackgroundImage = null;

                this.pause = true;
                habilitaVotacion = false;

                objFight.estadoPelea = enumEstado.Pause.GetHashCode();
                ActualizarAvisoEstadoPelea("Round " + objFight.roundActual.GetHashCode().ToString() + " PAUSA");
                this.CronometroPause();

                Auditar(enumEventosAuditoria.Pausa);
            }

            //No agregar ctrlErrores

        }

        private void pCruzMedico_Click(object sender, EventArgs e)
        {

            if (objFight.estadoPelea == enumEstado.EnCurso.GetHashCode() || objFight.estadoPelea == enumEstado.Pause.GetHashCode())
            {
                this.pCruzMedico.BackgroundImage = global::Fight.Tablero.Properties.Resources.CruzMedico;

                habilitaVotacion = false;

                objFight.estadoPelea = enumEstado.TiempoMedico.GetHashCode();
                ActualizarAvisoEstadoPelea("Tiempo Médico");

                this.CronometroPause();

                Auditar(enumEventosAuditoria.InicioTiempoMedico);

                CronometroSuperpuesto objCronoTiempoMedico = new CronometroSuperpuesto(false, true, objParametrizacion.tiempoMedico, this.Location);

                objCronoTiempoMedico.ShowDialog();

                Auditar(enumEventosAuditoria.FinTiempoMedico);

                objFight.estadoPelea = enumEstado.Pause.GetHashCode();

                ActualizarAvisoEstadoPelea("En PAUSA");
                this.pPausePlay.BackgroundImage = null;
                this.pause = true;


                this.pCruzMedico.BackgroundImage = null;
            }
        }

        private void pStop_Click(object sender, EventArgs e)
        {
            if (objFight.estadoPelea != enumEstado.Inicio.GetHashCode())
            {
                var result = MessageBox.Show("¿Está seguro que desea parar la pelea?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    CargarConfiguraciones();

                    this.tmrGanadorIntermitente.Enabled = false;

                    this.pStop.BackgroundImage = global::Fight.Tablero.Properties.Resources.Stop;

                    habilitaVotacion = false;

                    objFight.estadoPelea = enumEstado.Inicio.GetHashCode();
                    objFight.roundActual = enumEstado.Round1.GetHashCode();

                    LimpiarControles();

                    this.mediaFaltaAzul = false;
                    this.mediaFaltaRojo = false;

                    this.CronometroStop();

                    objFight.ReiniciarPuntuaciones();

                    #region Reinicio Tabla Auditoria
                    Auditar(enumEventosAuditoria.PararPelea);

                    dsAtuditoria.Tables[0].Clear();

                    auditoriaPuntosRojo = 0;
                    auditoriaPuntosAzul = 0;
                    #endregion


                }

                this.pStop.BackgroundImage = null;

                this.habilitarArchAuditoria = false;

            }
        }


        #region Cronometro Tablero

        public void CronometroStart()
        {
            //this.cronometroDescendente = false;
            this.tmrCronometro.Enabled = true;
            this.tmrCronometro.Start();
        }

        public void CronometroRestart()
        {
            CronometroReiniciar();

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
            this.lblCronometro.Text = DateTime.Parse(lblCronometro.Text).AddSeconds(1).ToString("HH:mm:ss");

            if (this.lblCronometro.Text == cronometroTime)
            {
                tmrCronometro.Stop();
                FinCrono();
            }
            //No agregar ctrolErrores
        }


        public void ResaltarColores()
        {
            this.tmrRelojColorIntermitente.Enabled = true;
            this.tmrRelojColorIntermitente.Start();
        }

        private void tmrRelojColorIntermitente_Tick_1(object sender, EventArgs e)
        {
            if (cronometroflagColorIntermitente)
            {
                lblCronometro.ForeColor = Color.White;

                cronometroflagColorIntermitente = !cronometroflagColorIntermitente;
            }
            else
            {
                lblCronometro.ForeColor = Color.Black;

                cronometroflagColorIntermitente = !cronometroflagColorIntermitente;
            }
        }

        #endregion



        #endregion

        #region Faltas

        private void pbFalta_Izq_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (objFight.estadoPelea == enumEstado.Pause.GetHashCode() || objFight.estadoPelea == enumEstado.EnCurso.GetHashCode())
                {

                    if (e.Button == MouseButtons.Left)
                    {
                        objFight.FaltaCombatienteRojo(true);

                        //Sumo puntaje al contrincante
                        int valor;
                        valor = this.objFight.PuntoCombatienteAzul(objParametrizacion.valorPuntuacionManual.GetHashCode(), true);

                        if (valor >= 10)
                            this.lblPuntoAzul.Location = new Point(-69, -22);

                        this.lblPuntoAzul.Text = Convert.ToString(valor);

                        Auditar(enumEventosAuditoria.FaltaRojo);
                    }
                    else
                    {
                        objFight.FaltaCombatienteRojo(false);

                        //Resto puntaje al contrincante
                        int valor;
                        valor = this.objFight.PuntoCombatienteAzul(objParametrizacion.valorPuntuacionManual.GetHashCode(), false);

                        if (valor < 10)
                            this.lblPuntoAzul.Location = new Point(48, -22);

                        this.lblPuntoAzul.Text = Convert.ToString(valor);

                        Auditar(enumEventosAuditoria.QuitarFaltaRojo);
                    }

                    if (objFight.ObtenerFaltasCombatienteRojo() >= 10)
                        this.lblFaltasRojo.Location = new Point(206, 533);
                    else
                        this.lblFaltasRojo.Location = new Point(236, 533);

                    this.lblFaltasRojo.Text = Convert.ToString(objFight.ObtenerFaltasCombatienteRojo());

                }
            }
            catch (Exception err)
            {
                objRegErr.RegistrarError("Asignación de media falta", err.Message.ToString());
                AvisoReinicioApp();
            }
        }

        private void pbFalta_Der_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (objFight.estadoPelea == enumEstado.Pause.GetHashCode() || objFight.estadoPelea == enumEstado.EnCurso.GetHashCode())
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        objFight.FaltaCombatienteAzul(true);

                        //Sumo puntaje al contrincante
                        int valor;
                        valor = this.objFight.PuntoCombatienteRojo(objParametrizacion.valorPuntuacionManual.GetHashCode(), true);

                        if (valor >= 10)
                            this.lblPuntoRojo.Location = new Point(-69, -22);

                        this.lblPuntoRojo.Text = Convert.ToString(valor);

                        Auditar(enumEventosAuditoria.FaltaAzul);
                    }
                    else
                    {
                        objFight.FaltaCombatienteAzul(false);

                        //Resto puntaje al contrincante
                        int valor;
                        valor = this.objFight.PuntoCombatienteRojo(objParametrizacion.valorPuntuacionManual.GetHashCode(), false);

                        if (valor < 10)
                            this.lblPuntoRojo.Location = new Point(48, -22);

                        this.lblPuntoRojo.Text = Convert.ToString(valor);

                        Auditar(enumEventosAuditoria.QuitarFaltaAzul);
                    }

                    if (objFight.ObtenerFaltasCombatienteAzul() >= 10)
                        this.lblFaltasAzul.Location = new Point(648, 533);
                    else
                        this.lblFaltasAzul.Location = new Point(677, 533);

                    this.lblFaltasAzul.Text = Convert.ToString(objFight.ObtenerFaltasCombatienteAzul());
                }
            }
            catch (Exception err)
            {
                objRegErr.RegistrarError("Asignación de falta", err.Message.ToString());
                AvisoReinicioApp();
            }
        }


        private void pbMediaFalta_Izq_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (objFight.estadoPelea == enumEstado.Pause.GetHashCode() || objFight.estadoPelea == enumEstado.EnCurso.GetHashCode())
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        this.mediaFaltaRojo = false;
                        this.pbMediaFalta_Izq.BackgroundImage = null;

                        Auditar(enumEventosAuditoria.QuitarMediaFaltaRojo);
                    }
                    else
                    {
                        this.mediaFaltaRojo = !this.mediaFaltaRojo;

                        if (this.mediaFaltaRojo)
                            this.pbMediaFalta_Izq.BackgroundImage = global::Fight.Tablero.Properties.Resources.Falta_Activado;
                        else
                        {
                            this.pbMediaFalta_Izq.BackgroundImage = null;

                            objFight.FaltaCombatienteRojo(true);

                            if (objFight.ObtenerFaltasCombatienteRojo() >= 10)
                                this.lblFaltasRojo.Location = new Point(206, 533);
                            else
                                this.lblFaltasRojo.Location = new Point(236, 533);

                            this.lblFaltasRojo.Text = Convert.ToString(objFight.ObtenerFaltasCombatienteRojo());

                            //Sumo puntaje al contrincante
                            int valor;
                            valor = this.objFight.PuntoCombatienteAzul(objParametrizacion.valorPuntuacionManual.GetHashCode(), true);

                            if (valor >= 10)
                                this.lblPuntoAzul.Location = new Point(-69, -22);

                            this.lblPuntoAzul.Text = Convert.ToString(valor);

                            Auditar(enumEventosAuditoria.MediaFaltaRojo);

                        }

                    }
                }
            }
            catch (Exception err)
            {
                objRegErr.RegistrarError("Asignación de falta", err.Message.ToString());
                AvisoReinicioApp();
            }
        }

        private void pbMediaFalta_Der_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (objFight.estadoPelea == enumEstado.Pause.GetHashCode() || objFight.estadoPelea == enumEstado.EnCurso.GetHashCode())
                {

                    if (e.Button == MouseButtons.Right)
                    {
                        this.mediaFaltaAzul = false;
                        this.pbMediaFalta_Der.BackgroundImage = null;

                        Auditar(enumEventosAuditoria.QuitarMediaFaltaAzul);
                    }
                    else
                    {
                        this.mediaFaltaAzul = !this.mediaFaltaAzul;

                        if (this.mediaFaltaAzul)
                            this.pbMediaFalta_Der.BackgroundImage = global::Fight.Tablero.Properties.Resources.Falta_Activado;
                        else
                        {
                            this.pbMediaFalta_Der.BackgroundImage = null;

                            objFight.FaltaCombatienteAzul(true);

                            if (objFight.ObtenerFaltasCombatienteAzul() >= 10)
                                this.lblFaltasAzul.Location = new Point(648, 533);
                            else
                                this.lblFaltasAzul.Location = new Point(677, 533);

                            this.lblFaltasAzul.Text = Convert.ToString(objFight.ObtenerFaltasCombatienteAzul());

                            //Sumo puntaje al contrincante
                            int valor;
                            valor = this.objFight.PuntoCombatienteRojo(objParametrizacion.valorPuntuacionManual.GetHashCode(), true);

                            if (valor >= 10)
                                this.lblPuntoRojo.Location = new Point(-69, -22);

                            this.lblPuntoRojo.Text = Convert.ToString(valor);

                            Auditar(enumEventosAuditoria.MediaFaltaAzul);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                objRegErr.RegistrarError("Asignación de media falta", err.Message.ToString());
                AvisoReinicioApp();
            }
        }

        private void pbMediaFalta_Der_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Votacion

        #region Sumar Puntaje Manual

        private void lblPuntoRojo_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                int valor;

                if (objFight.estadoPelea == enumEstado.Pause.GetHashCode())
                    if (e.Button == MouseButtons.Left)
                    {
                        valor = this.objFight.PuntoCombatienteRojo(objParametrizacion.valorPuntuacionManual.GetHashCode(), true);

                        if (valor >= 10)
                            this.lblPuntoRojo.Location = new Point(-69, -22);

                        this.lblPuntoRojo.Text = Convert.ToString(valor);

                        Auditar(enumEventosAuditoria.VotacionManualRojo);
                    }
                    else
                        if (e.Button == MouseButtons.Right)
                        {
                            valor = this.objFight.PuntoCombatienteRojo(objParametrizacion.valorPuntuacionManual.GetHashCode(), false);

                            if (valor < 10)
                                this.lblPuntoRojo.Location = new Point(48, -22);

                            this.lblPuntoRojo.Text = Convert.ToString(valor);

                            Auditar(enumEventosAuditoria.QuitarVotacionManualRojo);
                        }
            }
            catch (Exception err)
            {
                objRegErr.RegistrarError("Asignación de puntaje manual al Rojo", err.Message.ToString());
                AvisoReinicioApp();
            }
        }

        private void lblPuntoAzul_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                int valor;

                if (objFight.estadoPelea == enumEstado.Pause.GetHashCode())
                    if (e.Button == MouseButtons.Left)
                    {
                        valor = this.objFight.PuntoCombatienteAzul(objParametrizacion.valorPuntuacionManual.GetHashCode(), true);

                        if (valor >= 10)
                            this.lblPuntoAzul.Location = new Point(-69, -22);

                        this.lblPuntoAzul.Text = Convert.ToString(valor);

                        Auditar(enumEventosAuditoria.VotacionManualAzul);
                    }
                    else
                        if (e.Button == MouseButtons.Right)
                        {
                            valor = this.objFight.PuntoCombatienteAzul(objParametrizacion.valorPuntuacionManual.GetHashCode(), false);

                            if (valor < 10)
                                this.lblPuntoAzul.Location = new Point(48, -22);

                            this.lblPuntoAzul.Text = Convert.ToString(valor);

                            Auditar(enumEventosAuditoria.QuitarVotacionManualAzul);
                        }
            }
            catch (Exception err)
            {
                objRegErr.RegistrarError("Asignación de puntaje manual al Azul", err.Message.ToString());
                AvisoReinicioApp();
            }
        }

        private void AvisoReinicioApp()
        {

            MessageBox.Show("Ocurrió un error en la aplicación y esta se reiniciará. Informe al proveedor de la aplicación.", "Manejo de Errores", MessageBoxButtons.OK, MessageBoxIcon.Error);

            String executablePath = Application.ExecutablePath;
            Application.Exit();
            System.Diagnostics.Process Proceso = new System.Diagnostics.Process();

            if (System.IO.File.Exists(executablePath))
                Proceso = System.Diagnostics.Process.Start(executablePath);
        }

        #endregion

        private void tmrCalcularVotacion_Tick(object sender, EventArgs e)
        {
            try
            {
                if (habilitaVotacion)
                {
                    auditoriaPuntosRojo = 0;
                    auditoriaPuntosAzul = 0;

                    CalcularPuntosAtaque(ref  auditoriaPuntosRojo, ref  auditoriaPuntosAzul, ref  auditoriaAzul, ref  auditoriaRojo);

                    if (auditoriaPuntosRojo > 0 || auditoriaPuntosAzul > 0)
                        Auditar(enumEventosAuditoria.Votacion);
                }
                else
                    if (cantJoystick > 0)
                        objAtaque.ReiniciarPuntaje();
            }
            catch (Exception err)
            {
                objRegErr.RegistrarError("Cálculo de puntaje", err.Message.ToString());
                AvisoReinicioApp();
            }
        }

        private void CalcularPuntosAtaque(ref int auditoriaPuntosRojo, ref int auditoriaPuntosAzul, ref int[] azul, ref int[] rojo)
        {
            int puntosRojo = 0;
            int puntosAzul = 0;

            try
            {
                objAtaque.CalcularPuntaje(ref puntosRojo, ref puntosAzul, ref azul, ref rojo);

                //obtengo los valores netos calculados de las votaciones antes del calculo total para Auditoría.
                auditoriaPuntosRojo = puntosRojo;
                auditoriaPuntosAzul = puntosAzul;

                if (puntosAzul > 0)
                {
                    puntosAzul = this.objFight.PuntoCombatienteAzul(puntosAzul, true);

                    if (puntosAzul >= 10)
                        this.lblPuntoAzul.Location = new Point(-69, -22);  //48 ->    -69

                    this.lblPuntoAzul.Text = Convert.ToString(puntosAzul);
                }

                if (puntosRojo > 0)
                {
                    puntosRojo = this.objFight.PuntoCombatienteRojo(puntosRojo, true);

                    if (puntosRojo >= 10)
                        this.lblPuntoRojo.Location = new Point(-69, -22);  //48 ->    -69

                    this.lblPuntoRojo.Text = Convert.ToString(puntosRojo);
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        private void tmrLeerJoysticks_Tick(object sender, EventArgs e)
        {
            try
            {
                if (habilitaVotacion)
                {
                    if (cantJoystick >= 1)
                    {
                        #region ' Joystick 1
                        jst1.UpdateStatus();

                        #region ' Botones no utilizados

                        //  Ejes
                        //if (jst1.AxisC < 32511)
                        //    this.J1_button13.BackColor = Color.Red;
                        //else
                        //    this.J1_button13.BackColor = Color.Gray;

                        //if (jst1.AxisC > 32511)
                        //    this.J1_button14.BackColor = Color.Red;
                        //else
                        //    this.J1_button14.BackColor = Color.Gray;

                        //if (jst1.AxisD < 32511)
                        //    this.J1_button11.BackColor = Color.Red;
                        //else
                        //    this.J1_button11.BackColor = Color.Gray;

                        //   R
                        //if (jst1.Buttons[0])
                        //    this.J1_button1.BackColor = Color.Red;
                        //else
                        //    this.J1_button1.BackColor = Color.Gray;

                        //if (jst1.Buttons[1])
                        //    this.J1_button2.BackColor = Color.Red;
                        //else
                        //    this.J1_button2.BackColor = Color.Gray;

                        //if (jst1.Buttons[3])
                        //    this.J1_button4.BackColor = Color.Red;
                        //else
                        //    this.J1_button4.BackColor = Color.Gray;

                        // Superiores

                        // Select  / Start
                        //if (jst1.Buttons[8])
                        //    this.J1_button9.BackColor = Color.Red;
                        //else
                        //    this.J1_button9.BackColor = Color.Gray;

                        //if (jst1.Buttons[9])
                        //    this.J1_button10.BackColor = Color.Red;
                        //else
                        //    this.J1_button10.BackColor = Color.Gray;

                        #endregion

                        //ROJO - PUNTO A
                        if (jst1.AxisD > 32511)
                        {
                            if (this.Habil_J1_Rojo_PA)
                            {
                                objPunto = new Punto(Ataque.nroJuez.J1, Ataque.tipoPunto.A, Ataque.Peleador.Rojo);

                                objAtaque.Add(objPunto);

                                ReiniciartmrCalcularVotacion();
                                this.Habil_J1_Rojo_PA = false;
                            }
                        }
                        else
                            this.Habil_J1_Rojo_PA = true;
                        //END - ROJO - PUNTO A

                        //AZUL - PUNTO A
                        if (jst1.Buttons[2])
                        {
                            if (this.Habil_J1_Azul_PA)
                            {
                                objPunto = new Punto(Ataque.nroJuez.J1, Ataque.tipoPunto.A, Ataque.Peleador.Azul);

                                objAtaque.Add(objPunto);

                                ReiniciartmrCalcularVotacion();
                                this.Habil_J1_Azul_PA = false;
                            }
                        }
                        else
                            this.Habil_J1_Azul_PA = true;
                        //END AZUL - PUNTO A

                        //ROJO - PUNTO B
                        if (jst1.Buttons[4])
                        {
                            if (this.Habil_J1_Rojo_PB)
                            {
                                objPunto = new Punto(Ataque.nroJuez.J1, Ataque.tipoPunto.B, Ataque.Peleador.Rojo);

                                objAtaque.Add(objPunto);

                                ReiniciartmrCalcularVotacion();
                                this.Habil_J1_Rojo_PB = false;
                            }
                        }
                        else
                            this.Habil_J1_Rojo_PB = true;
                        //END - ROJO - PUNTO B

                        //AZUL - PUNTO B
                        if (jst1.Buttons[5])
                        {
                            if (this.Habil_J1_Azul_PB)
                            {
                                objPunto = new Punto(Ataque.nroJuez.J1, Ataque.tipoPunto.B, Ataque.Peleador.Azul);

                                objAtaque.Add(objPunto);

                                ReiniciartmrCalcularVotacion();
                                this.Habil_J1_Azul_PB = false;
                            }
                        }
                        else
                            this.Habil_J1_Azul_PB = true;
                        //END AZUL - PUNTO B

                        //ROJO - PUNTO C
                        if (jst1.Buttons[6])
                        {
                            if (this.Habil_J1_Rojo_PC)
                            {
                                objPunto = new Punto(Ataque.nroJuez.J1, Ataque.tipoPunto.C, Ataque.Peleador.Rojo);

                                objAtaque.Add(objPunto);

                                ReiniciartmrCalcularVotacion();
                                this.Habil_J1_Rojo_PC = false;
                            }
                        }
                        else
                            this.Habil_J1_Rojo_PC = true;
                        //END - ROJO - PUNTO C

                        //AZUL - PUNTO C
                        if (jst1.Buttons[7])
                        {
                            if (this.Habil_J1_Azul_PC)
                            {
                                objPunto = new Punto(Ataque.nroJuez.J1, Ataque.tipoPunto.C, Ataque.Peleador.Azul);

                                objAtaque.Add(objPunto);

                                ReiniciartmrCalcularVotacion();
                                this.Habil_J1_Azul_PC = false;
                            }
                        }
                        else
                            this.Habil_J1_Azul_PC = true;
                        //END AZUL - PUNTO C

                        #endregion
                    }

                    if (cantJoystick >= 2)
                    {
                        #region ' Joystick 2
                        jst2.UpdateStatus();

                        #region ' Botones no utilizados

                        //  Ejes
                        //if (jst2.AxisC < 32511)
                        //    this.J2_button13.BackColor = Color.Red;
                        //else
                        //    this.J2_button13.BackColor = Color.Gray;

                        //if (jst2.AxisC > 32511)
                        //    this.J2_button14.BackColor = Color.Red;
                        //else
                        //    this.J2_button14.BackColor = Color.Gray;

                        //if (jst2.AxisD < 32511)
                        //    this.J2_button11.BackColor = Color.Red;
                        //else
                        //    this.J2_button11.BackColor = Color.Gray;

                        //   R
                        //if (jst2.Buttons[0])
                        //    this.J2_button1.BackColor = Color.Red;
                        //else
                        //    this.J2_button1.BackColor = Color.Gray;

                        //if (jst2.Buttons[1])
                        //    this.J2_button2.BackColor = Color.Red;
                        //else
                        //    this.J2_button2.BackColor = Color.Gray;

                        //if (jst2.Buttons[3])
                        //    this.J2_button4.BackColor = Color.Red;
                        //else
                        //    this.J2_button4.BackColor = Color.Gray;

                        // Superiores

                        // Select  / Start
                        //if (jst2.Buttons[8])
                        //    this.J2_button9.BackColor = Color.Red;
                        //else
                        //    this.J2_button9.BackColor = Color.Gray;

                        //if (jst2.Buttons[9])
                        //    this.J2_button10.BackColor = Color.Red;
                        //else
                        //    this.J2_button10.BackColor = Color.Gray;

                        #endregion

                        //ROJO - PUNTO A
                        if (jst2.AxisD > 32511)
                        {
                            if (this.Habil_J2_Rojo_PA)
                            {
                                objPunto = new Punto(Ataque.nroJuez.J2, Ataque.tipoPunto.A, Ataque.Peleador.Rojo);

                                objAtaque.Add(objPunto);

                                ReiniciartmrCalcularVotacion();
                                this.Habil_J2_Rojo_PA = false;
                            }
                        }
                        else
                            this.Habil_J2_Rojo_PA = true;
                        //END - ROJO - PUNTO A

                        //AZUL - PUNTO A
                        if ((jst2.Buttons[2]))
                        {
                            if (this.Habil_J2_Azul_PA)
                            {
                                objPunto = new Punto(Ataque.nroJuez.J2, Ataque.tipoPunto.A, Ataque.Peleador.Azul);

                                objAtaque.Add(objPunto);
                                ReiniciartmrCalcularVotacion();

                                this.Habil_J2_Azul_PA = false;
                            }
                        }
                        else
                            this.Habil_J2_Azul_PA = true;
                        //END AZUL - PUNTO A

                        //ROJO - PUNTO B
                        if (jst2.Buttons[4])
                        {
                            if (this.Habil_J2_Rojo_PB)
                            {
                                objPunto = new Punto(Ataque.nroJuez.J2, Ataque.tipoPunto.B, Ataque.Peleador.Rojo);

                                objAtaque.Add(objPunto);

                                ReiniciartmrCalcularVotacion();
                                this.Habil_J2_Rojo_PB = false;
                            }
                        }
                        else
                            this.Habil_J2_Rojo_PB = true;
                        //END - ROJO - PUNTO B

                        //AZUL - PUNTO B
                        if (jst2.Buttons[5])
                        {
                            if (this.Habil_J2_Azul_PB)
                            {
                                objPunto = new Punto(Ataque.nroJuez.J2, Ataque.tipoPunto.B, Ataque.Peleador.Azul);

                                objAtaque.Add(objPunto);

                                ReiniciartmrCalcularVotacion();
                                this.Habil_J2_Azul_PB = false;
                            }
                        }
                        else
                            this.Habil_J2_Azul_PB = true;
                        //END AZUL - PUNTO B

                        //ROJO - PUNTO C
                        if (jst2.Buttons[6])
                        {
                            if (this.Habil_J2_Rojo_PC)
                            {
                                objPunto = new Punto(Ataque.nroJuez.J2, Ataque.tipoPunto.C, Ataque.Peleador.Rojo);

                                objAtaque.Add(objPunto);

                                ReiniciartmrCalcularVotacion();
                                this.Habil_J2_Rojo_PC = false;
                            }
                        }
                        else
                            this.Habil_J2_Rojo_PC = true;
                        //END - ROJO - PUNTO C

                        //AZUL - PUNTO C
                        if (jst2.Buttons[7])
                        {
                            if (this.Habil_J2_Azul_PC)
                            {
                                objPunto = new Punto(Ataque.nroJuez.J2, Ataque.tipoPunto.C, Ataque.Peleador.Azul);

                                objAtaque.Add(objPunto);

                                ReiniciartmrCalcularVotacion();
                                this.Habil_J2_Azul_PC = false;
                            }
                        }
                        else
                            this.Habil_J2_Azul_PC = true;
                        //END AZUL - PUNTO C

                        #endregion
                    }

                    if (cantJoystick >= 3)
                    {
                        #region ' Joystick 3
                        jst3.UpdateStatus();

                        #region ' Botones no utilizados

                        //  Ejes
                        //if (jst3.AxisC < 32511)
                        //    this.J3_button13.BackColor = Color.Red;
                        //else
                        //    this.J3_button13.BackColor = Color.Gray;

                        //if (jst3.AxisC > 32511)
                        //    this.J3_button14.BackColor = Color.Red;
                        //else
                        //    this.J3_button14.BackColor = Color.Gray;

                        //if (jst3.AxisD < 32511)
                        //    this.J3_button11.BackColor = Color.Red;
                        //else
                        //    this.J3_button11.BackColor = Color.Gray;

                        //   R
                        //if (jst3.Buttons[0])
                        //    this.J3_button1.BackColor = Color.Red;
                        //else
                        //    this.J3_button1.BackColor = Color.Gray;

                        //if (jst3.Buttons[1])
                        //    this.J3_button2.BackColor = Color.Red;
                        //else
                        //    this.J3_button2.BackColor = Color.Gray;

                        //if (jst3.Buttons[3])
                        //    this.J3_button4.BackColor = Color.Red;
                        //else
                        //    this.J3_button4.BackColor = Color.Gray;

                        // Superiores

                        // Select  / Start
                        //if (jst3.Buttons[8])
                        //    this.J3_button9.BackColor = Color.Red;
                        //else
                        //    this.J3_button9.BackColor = Color.Gray;

                        //if (jst3.Buttons[9])
                        //    this.J3_button10.BackColor = Color.Red;
                        //else
                        //    this.J3_button10.BackColor = Color.Gray;

                        #endregion

                        //ROJO - PUNTO A
                        if (jst3.AxisD > 32511)
                        {
                            if (this.Habil_J3_Rojo_PA)
                            {
                                objPunto = new Punto(Ataque.nroJuez.J3, Ataque.tipoPunto.A, Ataque.Peleador.Rojo);

                                objAtaque.Add(objPunto);

                                ReiniciartmrCalcularVotacion();
                                this.Habil_J3_Rojo_PA = false;
                            }
                        }
                        else
                            this.Habil_J3_Rojo_PA = true;
                        //END - ROJO - PUNTO A

                        //AZUL - PUNTO A
                        if (jst3.Buttons[2])
                        {
                            if (this.Habil_J3_Azul_PA)
                            {
                                objPunto = new Punto(Ataque.nroJuez.J3, Ataque.tipoPunto.A, Ataque.Peleador.Azul);

                                objAtaque.Add(objPunto);

                                ReiniciartmrCalcularVotacion();
                                this.Habil_J3_Azul_PA = false;
                            }
                        }
                        else
                            this.Habil_J3_Azul_PA = true;
                        //END AZUL - PUNTO A

                        //ROJO - PUNTO B
                        if (jst3.Buttons[4])
                        {
                            if (this.Habil_J3_Rojo_PB)
                            {
                                objPunto = new Punto(Ataque.nroJuez.J3, Ataque.tipoPunto.B, Ataque.Peleador.Rojo);

                                objAtaque.Add(objPunto);

                                ReiniciartmrCalcularVotacion();
                                this.Habil_J3_Rojo_PB = false;
                            }
                        }
                        else
                            this.Habil_J3_Rojo_PB = true;
                        //END - ROJO - PUNTO B

                        //AZUL - PUNTO B
                        if (jst3.Buttons[5])
                        {
                            if (this.Habil_J3_Azul_PB)
                            {
                                objPunto = new Punto(Ataque.nroJuez.J3, Ataque.tipoPunto.B, Ataque.Peleador.Azul);

                                objAtaque.Add(objPunto);

                                ReiniciartmrCalcularVotacion();
                                this.Habil_J3_Azul_PB = false;
                            }
                        }
                        else
                            this.Habil_J3_Azul_PB = true;
                        //END AZUL - PUNTO B

                        //ROJO - PUNTO C
                        if (jst3.Buttons[6])
                        {
                            if (this.Habil_J3_Rojo_PC)
                            {
                                objPunto = new Punto(Ataque.nroJuez.J3, Ataque.tipoPunto.C, Ataque.Peleador.Rojo);

                                objAtaque.Add(objPunto);

                                ReiniciartmrCalcularVotacion();
                                this.Habil_J3_Rojo_PC = false;
                            }
                        }
                        else
                            this.Habil_J3_Rojo_PC = true;
                        //END - ROJO - PUNTO C

                        //AZUL - PUNTO C
                        if (jst3.Buttons[7])
                        {
                            if (this.Habil_J3_Azul_PC)
                            {
                                objPunto = new Punto(Ataque.nroJuez.J3, Ataque.tipoPunto.C, Ataque.Peleador.Azul);

                                objAtaque.Add(objPunto);

                                ReiniciartmrCalcularVotacion();
                                this.Habil_J3_Azul_PC = false;
                            }
                        }
                        else
                            this.Habil_J3_Azul_PC = true;
                        //END AZUL - PUNTO C

                        #endregion
                    }

                    if (cantJoystick >= 4)
                    {
                        #region ' Joystick 4
                        jst4.UpdateStatus();

                        #region ' Botones no utilizados

                        //  Ejes
                        //if (jst4.AxisC < 32511)
                        //    this.J4_button13.BackColor = Color.Red;
                        //else
                        //    this.J4_button13.BackColor = Color.Gray;

                        //if (jst4.AxisC > 32511)
                        //    this.J4_button14.BackColor = Color.Red;
                        //else
                        //    this.J4_button14.BackColor = Color.Gray;

                        //if (jst4.AxisD < 32511)
                        //    this.J4_button11.BackColor = Color.Red;
                        //else
                        //    this.J4_button11.BackColor = Color.Gray;

                        //   R
                        //if (jst4.Buttons[0])
                        //    this.J4_button1.BackColor = Color.Red;
                        //else
                        //    this.J4_button1.BackColor = Color.Gray;

                        //if (jst4.Buttons[1])
                        //    this.J4_button2.BackColor = Color.Red;
                        //else
                        //    this.J4_button2.BackColor = Color.Gray;

                        //if (jst4.Buttons[3])
                        //    this.J4_button4.BackColor = Color.Red;
                        //else
                        //    this.J4_button4.BackColor = Color.Gray;

                        // Superiores

                        // Select  / Start
                        //if (jst4.Buttons[8])
                        //    this.J4_button9.BackColor = Color.Red;
                        //else
                        //    this.J4_button9.BackColor = Color.Gray;

                        //if (jst4.Buttons[9])
                        //    this.J4_button10.BackColor = Color.Red;
                        //else
                        //    this.J4_button10.BackColor = Color.Gray;

                        #endregion

                        //ROJO - PUNTO A
                        if (jst4.AxisD > 32511)
                        {
                            if (this.Habil_J4_Rojo_PA)
                            {
                                objPunto = new Punto(Ataque.nroJuez.J4, Ataque.tipoPunto.A, Ataque.Peleador.Rojo);

                                objAtaque.Add(objPunto);

                                ReiniciartmrCalcularVotacion();
                                this.Habil_J4_Rojo_PA = false;
                            }
                        }
                        else
                            this.Habil_J4_Rojo_PA = true;
                        //END - ROJO - PUNTO A

                        //AZUL - PUNTO A
                        if (jst4.Buttons[2])
                        {
                            if (this.Habil_J4_Azul_PA)
                            {
                                objPunto = new Punto(Ataque.nroJuez.J4, Ataque.tipoPunto.A, Ataque.Peleador.Azul);

                                objAtaque.Add(objPunto);

                                ReiniciartmrCalcularVotacion();
                                this.Habil_J4_Azul_PA = false;
                            }
                        }
                        else
                            this.Habil_J4_Azul_PA = true;
                        //END AZUL - PUNTO A

                        //ROJO - PUNTO B
                        if (jst4.Buttons[4])
                        {
                            if (this.Habil_J4_Rojo_PB)
                            {
                                objPunto = new Punto(Ataque.nroJuez.J4, Ataque.tipoPunto.B, Ataque.Peleador.Rojo);

                                objAtaque.Add(objPunto);

                                ReiniciartmrCalcularVotacion();
                                this.Habil_J4_Rojo_PB = false;
                            }
                        }
                        else
                            this.Habil_J4_Rojo_PB = true;
                        //END - ROJO - PUNTO B

                        //AZUL - PUNTO B
                        if (jst4.Buttons[5])
                        {
                            if (this.Habil_J4_Azul_PB)
                            {
                                objPunto = new Punto(Ataque.nroJuez.J4, Ataque.tipoPunto.B, Ataque.Peleador.Azul);

                                objAtaque.Add(objPunto);

                                ReiniciartmrCalcularVotacion();
                                this.Habil_J4_Azul_PB = false;
                            }
                        }
                        else
                            this.Habil_J4_Azul_PB = true;
                        //END AZUL - PUNTO B

                        //ROJO - PUNTO C
                        if (jst4.Buttons[6])
                        {
                            if (this.Habil_J4_Rojo_PC)
                            {
                                objPunto = new Punto(Ataque.nroJuez.J4, Ataque.tipoPunto.C, Ataque.Peleador.Rojo);

                                objAtaque.Add(objPunto);

                                ReiniciartmrCalcularVotacion();
                                this.Habil_J4_Rojo_PC = false;
                            }
                        }
                        else
                            this.Habil_J4_Rojo_PC = true;
                        //END - ROJO - PUNTO C

                        //AZUL - PUNTO C
                        if (jst4.Buttons[7])
                        {
                            if (this.Habil_J4_Azul_PC)
                            {
                                objPunto = new Punto(Ataque.nroJuez.J4, Ataque.tipoPunto.C, Ataque.Peleador.Azul);

                                objAtaque.Add(objPunto);

                                ReiniciartmrCalcularVotacion();
                                this.Habil_J4_Azul_PC = false;
                            }
                        }
                        else
                            this.Habil_J4_Azul_PC = true;
                        //END AZUL - PUNTO C
                        #endregion
                    }
                }
            }
            catch (Exception err)
            {
                objRegErr.RegistrarError("Lectura de votaciones en joysticks", err.Message.ToString());
                AvisoReinicioApp();
            }
        }

        private void ReiniciartmrCalcularVotacion()
        {
            this.tmrCalcularVotacion.Enabled = false;
            this.tmrCalcularVotacion.Stop();
            this.tmrCalcularVotacion.Enabled = true;
            this.tmrCalcularVotacion.Start();
        }

        #endregion

        #region Métodos Privados

        private void CargarConfiguraciones()
        {
            try
            {
                this.mediaFaltaAzul = false;
                this.mediaFaltaRojo = false;

                this.cronometroTime = objParametrizacion.tiempoRound;

                this.tmrCalcularVotacion.Interval = objParametrizacion.tiempoMuerto * 1000;

                ActualizarAvisoEstadoPelea("En espera");
            }
            catch (Exception err)
            {
                objRegErr.RegistrarError("Cargar configuraciones", err.Message.ToString());
                AvisoReinicioApp();
            }

        }

        private bool ObtenerJoysticksConectados(ref int cantJoysticks)
        {
            bool retorno = false;

            try
            {
                jst1 = new Joystick(this.Handle);
                jst2 = new Joystick(this.Handle);
                jst3 = new Joystick(this.Handle);
                jst4 = new Joystick(this.Handle);

                string[] sticks = jst1.FindJoysticks();

                if (sticks != null)
                {

                    if (sticks.Length > 0)
                    {
                        jst1.AcquireJoystick(sticks[0]);
                        cantJoystick = 1;
                    }

                    if (sticks.Length > 1)
                    {
                        jst2.AcquireJoystick(sticks[1]);
                        cantJoystick = 2;
                    }

                    if (sticks.Length > 2)
                    {
                        jst3.AcquireJoystick(sticks[2]);
                        cantJoystick = 3;
                    }

                    if (sticks.Length > 3)
                    {
                        jst4.AcquireJoystick(sticks[3]);
                        cantJoystick = 4;
                    }

                    tmrLeerJoysticks.Enabled = true;

                    objParametrizacion.cantJueces = cantJoystick;

                    if (objParametrizacion.cantJueces >= objParametrizacion.cantVotosMinimos)
                    {
                        objAtaque = new Ataque(
                                       objParametrizacion.PuntoA.puntaje.GetHashCode(),
                                       objParametrizacion.PuntoB.puntaje.GetHashCode(),
                                       objParametrizacion.PuntoC.puntaje.GetHashCode(),
                                       objParametrizacion.cantJueces.GetHashCode(),
                                       objParametrizacion.cantVotosMinimos.GetHashCode()
                                     );

                        retorno = true;
                    }
                    else
                    {
                        retorno = false;
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;

        }

        private void LimpiarControles()
        {
            this.CronometroReiniciar();
            this.lblEstadoPelea.Text = "En Espera";

            this.lblFaltasAzul.Location = new Point(677, 533);
            this.lblFaltasAzul.Text = "0";

            this.lblFaltasRojo.Location = new Point(236, 533);
            this.lblFaltasRojo.Text = "0";

            this.lblPuntoAzul.Text = "0";
            this.lblPuntoAzul.Location = new Point(48, -22);

            this.lblPuntoRojo.Text = "0";
            this.lblPuntoRojo.Location = new Point(48, -22);

            this.pFondoAzul.Visible = true;
            this.pFondoRojo.Visible = true;

            this.pbMediaFalta_Izq.BackgroundImage = null;
            this.pbMediaFalta_Izq.Enabled = true;

            this.pbMediaFalta_Der.BackgroundImage = null;
            this.pbMediaFalta_Der.Enabled = true;

            this.pPausePlay.Enabled = true;
            this.pCruzMedico.Enabled = true;

            this.pbCruzCerrar.Visible = false;
            this.pPausePlay.BackgroundImage = null;
            this.pStop.BackgroundImage = null;
            this.pCruzMedico.BackgroundImage = null;

            this.lblPuntoRojo.ForeColor = Color.Black;
            this.lblNombreRojo.ForeColor = Color.Black;
            this.lblPuntoAzul.ForeColor = Color.Black;
            this.lblNombreAzul.ForeColor = Color.Black;

        }

        private void FinPelea(bool PorMaxFaltas, bool PorDiferenciaPuntos, bool PuntuacionMaxima)
        {

            objFight.estadoPelea = enumEstado.Fin.GetHashCode();

            habilitaVotacion = false;

            try
            {
                if (PorMaxFaltas)
                    ActualizarAvisoEstadoPelea("Máximo de Faltas");
                else
                    if (PorDiferenciaPuntos)
                        ActualizarAvisoEstadoPelea("Diferencia de Puntos");
                    else
                        if (PuntuacionMaxima)
                            ActualizarAvisoEstadoPelea("Puntuación Máxima");
                        else
                        {
                            bool rojo = false;
                            bool azul = false;
                            bool empate = false;

                            objFight.ResultadoFinal(ref rojo, ref azul, ref empate);

                            if (rojo)
                            {
                                ActualizarAvisoEstadoPelea("GANADOR ROJO");
                            }
                            else
                                if (azul)
                                {
                                    ActualizarAvisoEstadoPelea("GANADOR AZUL");
                                }
                                else
                                {
                                    ActualizarAvisoEstadoPelea("EMPATE");
                                }
                        }

                this.tmrGanadorIntermitente.Enabled = true;

                this.pbMediaFalta_Izq.BackgroundImage = null;
                this.pbMediaFalta_Izq.Enabled = false;

                this.pbMediaFalta_Der.BackgroundImage = null;
                this.pbMediaFalta_Der.Enabled = false;

                this.pPausePlay.BackgroundImage = null;
                this.pPausePlay.Enabled = false;

                this.pCruzMedico.BackgroundImage = null;
                this.pCruzMedico.Enabled = false;

                Auditar(enumEventosAuditoria.FinRound);
            }
            catch (Exception err)
            {
                objRegErr.RegistrarError("Fin Pelea", err.Message.ToString());
                AvisoReinicioApp();
            }

        }

        private bool ComprobrarEstadoJoysticksConectados()
        {
            bool retorno = false;

            try
            {
                jstTemp = new Joystick(this.Handle);

                string[] sticks = jstTemp.FindJoysticks();

                if (sticks != null)
                    if (sticks.Length == cantJoystick)
                        retorno = true;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return retorno = true;

        }

        private void ActualizarAvisoEstadoPelea(string estado)
        {
            this.lblEstadoPelea.Text = estado;
        }

        private bool ValidarKey(ref string error)
        {
            try
            {
                Seguridad seguridad = new Seguridad();

                if (!seguridad.ValidarCopia(ref error))
                {
                    error = "Error: " + error;
                    return false;
                }
                else
                    return true;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

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

        private void CambiarNombre()
        {
            try
            {
                CambiarNombre objCambioNombre = new CambiarNombre(this.lblNombreRojo.Text, this.lblNombreAzul.Text);

                objCambioNombre.ShowDialog();

                this.lblNombreRojo.Text = objCambioNombre.nombreRojo;
                this.lblNombreAzul.Text = objCambioNombre.nombreAzul;

                objCambioNombre.Dispose();
            }
            catch (Exception err)
            {
                objRegErr.RegistrarError("Cambiar Nombre", err.Message.ToString());
                AvisoReinicioApp();
            }
        }



        #endregion

        #region Auditoria

        private void Auditar(enumEventosAuditoria evento)
        {
            AuditoriaDTO.AuditoriaDTDataTable tabla;

            try
            {
                tabla = new Fight.Tablero.Entidades.AuditoriaDTO.AuditoriaDTDataTable();
                AuditoriaDTO.AuditoriaDTRow row = (AuditoriaDTO.AuditoriaDTRow)tabla.NewRow();

                row.FechaHora = DateTime.Now.ToString();
                row.Evento = evento.ToString();

                row.NomLuchadorRojo = this.lblNombreRojo.Text;
                row.PuntuacionTotalRojo = this.lblPuntoRojo.Text;
                row.FaltasRojo = this.lblFaltasRojo.Text;

                row.NomLuchadorAzul = this.lblNombreAzul.Text;
                row.PuntuacionTotalAzul = this.lblPuntoAzul.Text;
                row.FaltasAzul = this.lblFaltasAzul.Text;

                row.NºRound = objFight.roundActual.ToString() + " / " + objParametrizacion.cantRounds.ToString();
                row.TiempoReloj = this.lblCronometro.Text;

                #region EventosAuditoria
                switch (evento)
                {
                    case enumEventosAuditoria.InicioAuditoria:
                        break;
                    case enumEventosAuditoria.InicioRound:
                        break;
                    case enumEventosAuditoria.FinRound:
                        break;
                    case enumEventosAuditoria.InicioTiempoMedico:
                        break;
                    case enumEventosAuditoria.FinTiempoMedico:
                        break;
                    case enumEventosAuditoria.InicioDescanso:
                        break;
                    case enumEventosAuditoria.FinDescanso:
                        break;
                    case enumEventosAuditoria.Votacion:
                        row.VotoJuez1_Rojo = auditoriaRojo.Length >= 1 ? auditoriaRojo[0].ToString() : "0";
                        row.VotoJuez1_Azul = auditoriaAzul.Length >= 1 ? auditoriaAzul[0].ToString() : "0";

                        row.VotoJuez2_Rojo = auditoriaRojo.Length >= 2 ? auditoriaRojo[1].ToString() : "0";
                        row.VotoJuez2_Azul = auditoriaAzul.Length >= 2 ? auditoriaAzul[1].ToString() : "0";

                        row.VotoJuez3_Rojo = auditoriaRojo.Length >= 3 ? auditoriaRojo[2].ToString() : "0";
                        row.VotoJuez3_Azul = auditoriaAzul.Length >= 3 ? auditoriaAzul[2].ToString() : "0";

                        row.VotoJuez4_Rojo = auditoriaRojo.Length >= 4 ? auditoriaRojo[3].ToString() : "0";
                        row.VotoJuez4_Azul = auditoriaAzul.Length >= 4 ? auditoriaAzul[3].ToString() : "0";

                        row.VotoRojo = auditoriaPuntosRojo.ToString();
                        row.VotoAzul = auditoriaPuntosAzul.ToString();
                        break;
                    case enumEventosAuditoria.FaltaRojo:
                        row.VotoRojo = "-" + objParametrizacion.valorPuntuacionManual.GetHashCode().ToString();
                        row.VotoAzul = objParametrizacion.valorPuntuacionManual.GetHashCode().ToString();
                        break;
                    case enumEventosAuditoria.QuitarFaltaRojo:
                        row.VotoRojo = objParametrizacion.valorPuntuacionManual.GetHashCode().ToString();
                        row.VotoAzul = "-" + objParametrizacion.valorPuntuacionManual.GetHashCode().ToString();
                        break;
                    case enumEventosAuditoria.MediaFaltaRojo:
                        break;
                    case enumEventosAuditoria.QuitarMediaFaltaRojo:
                        break;
                    case enumEventosAuditoria.FaltaAzul:
                        row.VotoRojo = objParametrizacion.valorPuntuacionManual.GetHashCode().ToString();
                        row.VotoAzul = "-" + objParametrizacion.valorPuntuacionManual.GetHashCode().ToString();
                        break;
                    case enumEventosAuditoria.QuitarFaltaAzul:
                        row.VotoRojo = "-" + objParametrizacion.valorPuntuacionManual.GetHashCode().ToString();
                        row.VotoAzul = objParametrizacion.valorPuntuacionManual.GetHashCode().ToString();
                        break;
                    case enumEventosAuditoria.MediaFaltaAzul:
                        break;
                    case enumEventosAuditoria.QuitarMediaFaltaAzul:
                        break;
                    case enumEventosAuditoria.VotacionManualRojo:
                        row.VotoRojo = objParametrizacion.valorPuntuacionManual.GetHashCode().ToString();
                        break;
                    case enumEventosAuditoria.QuitarVotacionManualRojo:
                        row.VotoRojo = "-" + objParametrizacion.valorPuntuacionManual.GetHashCode().ToString();
                        break;
                    case enumEventosAuditoria.VotacionManualAzul:
                        row.VotoAzul = objParametrizacion.valorPuntuacionManual.GetHashCode().ToString();
                        break;
                    case enumEventosAuditoria.QuitarVotacionManualAzul:
                        row.VotoAzul = "-" + objParametrizacion.valorPuntuacionManual.GetHashCode().ToString();
                        break;
                    case enumEventosAuditoria.PararPelea:

                        if (habilitarArchAuditoria)
                        {
                            string pathArchivoCreado = string.Empty;
                            CrearArchivoAuditoria(dsAtuditoria, ref pathArchivoCreado);

                            MessageBox.Show("Archivo de auditoría creado en el directorio: " + pathArchivoCreado);


                        }

                        break;
                    case enumEventosAuditoria.Pausa:
                        break;
                    case enumEventosAuditoria.ContinuarPelea:
                        break;
                    default:
                        break;
                }

                #endregion EventosAuditoria

                dsAtuditoria.Tables[0].Rows.Add(row.ItemArray);
                tabla.Dispose();
                row.Delete();
            }
            catch (Exception ex)
            {
                objRegErr.RegistrarError("Error al intentar auditar el evento: " + evento, ex.Message.ToString());
            }

        }

        private void CrearArchivoAuditoria(AuditoriaDTO dsAuditoria, ref string pathArhivoCreado)
        {
            try
            {
                exportarAuditoria.crearArchivoAuditoria(dsAtuditoria, ref pathArhivoCreado);
            }
            catch (Exception ex)
            {
                objRegErr.RegistrarError("Error al intentar crear el archivo de auditoría: " + pathArhivoCreado, ex.Message.ToString());
                MessageBox.Show("Se produjo un error al intentar crear el archivo de auditoría: " + pathArhivoCreado);
            }
        }

        private void MostrarAuditoria(AuditoriaDTO.AuditoriaDTDataTable dt)
        {
            AuditoriaView frmAuditoria;

            try
            {
                frmAuditoria = new AuditoriaView(dt);
                frmAuditoria.ShowDialog();

                frmAuditoria.Dispose();
            }
            catch (Exception ex)
            {
                objRegErr.RegistrarError("Error al intentar mostar la pantalla de auditoría.", ex.Message.ToString());
                MessageBox.Show("Se produjo un error al intentar mostrar la auditoría.");
            }
        }
        #endregion Auditoria

        #region Timers
        private void tmrComprobrarEstadoJoysticksConectados_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!ComprobrarEstadoJoysticksConectados())
                {
                    this.tmrLeerJoysticks.Enabled = false;

                    foreach (System.Windows.Forms.Control ctrl in this.Controls)
                    {
                        ctrl.Enabled = false;

                        if (ctrl.Name.ToString() == "pCerrar" || ctrl.Name.ToString() == "pbCruzCerrar")
                            ctrl.Enabled = true;
                    }

                    //Pause
                    this.pPausePlay.BackgroundImage = null;

                    this.pause = true;
                    habilitaVotacion = false;

                    objFight.estadoPelea = enumEstado.Pause.GetHashCode();
                    ActualizarAvisoEstadoPelea("Round " + objFight.roundActual.GetHashCode().ToString() + " PAUSA");
                    this.CronometroPause();
                    //

                    MessageBox.Show("Se ha perdido la conexión con algunos de los joysticks. Verifique las conexiones y reinicie la aplicación.", "Control de Joysticks");
                }
            }
            catch (Exception err)
            {
                objRegErr.RegistrarError("Comprobar estado de los Joysticks", err.Message.ToString());
                AvisoReinicioApp();
            }

        }

        private void tmrComprobarPenDrive_Tick(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(Application.StartupPath + "\\ParametrizacionTablero.xml"))
            {
                this.tmrComprobarPenDrive.Interval = 10000;

                this.lblPuntoRojo.Visible = false;
                this.lblPuntoAzul.Visible = false;

                if (this.tmrComprobarPenDrive.Interval == 60000)
                    MessageBox.Show("Conecte el pendrive para que la aplicación siga funcionando correctamente.");

            }
            else
            {
                this.tmrComprobarPenDrive.Interval = 60000;

                this.lblPuntoRojo.Visible = true;
                this.lblPuntoAzul.Visible = true;
            }

        }

        private void tmrGanadorIntermitente_Tick(object sender, EventArgs e)
        {
            try
            {
                bool rojo = false, azul = false, empate = false;
                ganadorIntermitente = !ganadorIntermitente;

                objFight.ResultadoFinal(ref rojo, ref azul, ref empate);

                if (rojo)
                    if (ganadorIntermitente)
                    {
                        lblPuntoRojo.ForeColor = Color.Black;
                        lblNombreRojo.ForeColor = Color.Black;
                    }
                    else
                    {
                        lblPuntoRojo.ForeColor = Color.Red;
                        lblNombreRojo.ForeColor = Color.Red;
                    }

                //lblPuntoRojo.Visible = ! lblPuntoRojo.Visible;
                //this.pFondoRojo.Visible = !this.pFondoRojo.Visible;


                if (azul)
                    if (ganadorIntermitente)
                    {
                        lblPuntoAzul.ForeColor = Color.Black;
                        lblNombreAzul.ForeColor = Color.Black;
                    }
                    else
                    {
                        lblPuntoAzul.ForeColor = Color.Blue;
                        lblNombreAzul.ForeColor = Color.Blue;
                    }

                //lblPuntoAzul.Visible = ! lblPuntoAzul.Visible;

                //    this.pFondoAzul.Visible = !this.pFondoAzul.Visible;

                if (empate)
                {
                    if (ganadorIntermitente)
                    {
                        lblPuntoRojo.ForeColor = Color.Black;
                        lblPuntoAzul.ForeColor = Color.Black;
                        lblNombreAzul.ForeColor = Color.Black;
                        lblNombreRojo.ForeColor = Color.Black;
                    }
                    else
                    {
                        lblPuntoRojo.ForeColor = Color.Red;
                        lblNombreRojo.ForeColor = Color.Red;
                        lblPuntoAzul.ForeColor = Color.Blue;
                        lblNombreAzul.ForeColor = Color.Blue;
                    }

                    //lblPuntoRojo.Visible = !lblPuntoRojo.Visible;
                    //lblPuntoAzul.Visible = !lblPuntoAzul.Visible;
                    //this.pFondoRojo.Visible = !this.pFondoRojo.Visible;
                    //this.pFondoAzul.Visible = !this.pFondoAzul.Visible;
                }
            }
            catch (Exception err)
            {
                objRegErr.RegistrarError("Resartar en intermitente el ganador", err.Message.ToString());
                AvisoReinicioApp();
            }
        }
        #endregion Timers

        

    }


}