namespace Fight.Tablero.Formularios
{
    partial class Tablero
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblPuntoAzul = new System.Windows.Forms.Label();
            this.lblPuntoRojo = new System.Windows.Forms.Label();
            this.lblFaltasRojo = new System.Windows.Forms.Label();
            this.lblFaltasAzul = new System.Windows.Forms.Label();
            this.lblEstadoPelea = new System.Windows.Forms.Label();
            this.tmrCalcularVotacion = new System.Windows.Forms.Timer(this.components);
            this.tmrLeerJoysticks = new System.Windows.Forms.Timer(this.components);
            this.pPausePlay = new System.Windows.Forms.Panel();
            this.pCruzMedico = new System.Windows.Forms.Panel();
            this.pCerrar = new System.Windows.Forms.Panel();
            this.pbCruzCerrar = new System.Windows.Forms.PictureBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.pbFalta_Izq = new System.Windows.Forms.PictureBox();
            this.pbFalta_Der = new System.Windows.Forms.PictureBox();
            this.pbMediaFalta_Izq = new System.Windows.Forms.PictureBox();
            this.pbMediaFalta_Der = new System.Windows.Forms.PictureBox();
            this.pStop = new System.Windows.Forms.Panel();
            this.lblCronometro = new System.Windows.Forms.Label();
            this.tmrCronometro = new System.Windows.Forms.Timer(this.components);
            this.tmrRelojColorIntermitente = new System.Windows.Forms.Timer(this.components);
            this.tmrGanadorIntermitente = new System.Windows.Forms.Timer(this.components);
            this.pFondoRojo = new System.Windows.Forms.Panel();
            this.pFondoAzul = new System.Windows.Forms.Panel();
            this.lblNombreRojo = new System.Windows.Forms.Label();
            this.lblNombreAzul = new System.Windows.Forms.Label();
            this.pNombreRojo = new System.Windows.Forms.Panel();
            this.pNombreAzul = new System.Windows.Forms.Panel();
            this.tmrComprobarPenDrive = new System.Windows.Forms.Timer(this.components);
            this.tmrComprobrarEstadoJoysticksConectados = new System.Windows.Forms.Timer(this.components);
            this.cmsOpciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiConfiguraciones = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAuditoria = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAuditoria = new System.Windows.Forms.Button();
            this.tsmiCambiarNombres = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbCruzCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFalta_Izq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFalta_Der)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMediaFalta_Izq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMediaFalta_Der)).BeginInit();
            this.pFondoRojo.SuspendLayout();
            this.pFondoAzul.SuspendLayout();
            this.pNombreAzul.SuspendLayout();
            this.cmsOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPuntoAzul
            // 
            this.lblPuntoAzul.AutoSize = true;
            this.lblPuntoAzul.BackColor = System.Drawing.Color.Transparent;
            this.lblPuntoAzul.Font = new System.Drawing.Font("Arial", 320F, System.Drawing.FontStyle.Bold);
            this.lblPuntoAzul.ForeColor = System.Drawing.Color.Black;
            this.lblPuntoAzul.Location = new System.Drawing.Point(48, -22);
            this.lblPuntoAzul.Name = "lblPuntoAzul";
            this.lblPuntoAzul.Size = new System.Drawing.Size(437, 477);
            this.lblPuntoAzul.TabIndex = 21;
            this.lblPuntoAzul.Tag = "visible";
            this.lblPuntoAzul.Text = "0";
            this.lblPuntoAzul.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblPuntoAzul_MouseDown);
            // 
            // lblPuntoRojo
            // 
            this.lblPuntoRojo.AutoSize = true;
            this.lblPuntoRojo.BackColor = System.Drawing.Color.Transparent;
            this.lblPuntoRojo.Font = new System.Drawing.Font("Arial", 320F, System.Drawing.FontStyle.Bold);
            this.lblPuntoRojo.ForeColor = System.Drawing.Color.Black;
            this.lblPuntoRojo.Location = new System.Drawing.Point(48, -22);
            this.lblPuntoRojo.Name = "lblPuntoRojo";
            this.lblPuntoRojo.Size = new System.Drawing.Size(437, 477);
            this.lblPuntoRojo.TabIndex = 23;
            this.lblPuntoRojo.Tag = "visible";
            this.lblPuntoRojo.Text = "0";
            this.lblPuntoRojo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblPuntoRojo_MouseDown);
            // 
            // lblFaltasRojo
            // 
            this.lblFaltasRojo.AutoSize = true;
            this.lblFaltasRojo.BackColor = System.Drawing.Color.Transparent;
            this.lblFaltasRojo.Font = new System.Drawing.Font("Arial", 90F, System.Drawing.FontStyle.Bold);
            this.lblFaltasRojo.ForeColor = System.Drawing.Color.Red;
            this.lblFaltasRojo.Location = new System.Drawing.Point(236, 533);
            this.lblFaltasRojo.Name = "lblFaltasRojo";
            this.lblFaltasRojo.Size = new System.Drawing.Size(126, 139);
            this.lblFaltasRojo.TabIndex = 27;
            this.lblFaltasRojo.Tag = "visible";
            this.lblFaltasRojo.Text = "0";
            // 
            // lblFaltasAzul
            // 
            this.lblFaltasAzul.AutoSize = true;
            this.lblFaltasAzul.BackColor = System.Drawing.Color.Transparent;
            this.lblFaltasAzul.Font = new System.Drawing.Font("Arial", 90F, System.Drawing.FontStyle.Bold);
            this.lblFaltasAzul.ForeColor = System.Drawing.Color.Blue;
            this.lblFaltasAzul.Location = new System.Drawing.Point(677, 533);
            this.lblFaltasAzul.Name = "lblFaltasAzul";
            this.lblFaltasAzul.Size = new System.Drawing.Size(126, 139);
            this.lblFaltasAzul.TabIndex = 26;
            this.lblFaltasAzul.Tag = "visible";
            this.lblFaltasAzul.Text = "0";
            // 
            // lblEstadoPelea
            // 
            this.lblEstadoPelea.AutoSize = true;
            this.lblEstadoPelea.BackColor = System.Drawing.Color.Transparent;
            this.lblEstadoPelea.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoPelea.ForeColor = System.Drawing.Color.Lime;
            this.lblEstadoPelea.Location = new System.Drawing.Point(29, 23);
            this.lblEstadoPelea.Name = "lblEstadoPelea";
            this.lblEstadoPelea.Size = new System.Drawing.Size(222, 32);
            this.lblEstadoPelea.TabIndex = 29;
            this.lblEstadoPelea.Tag = "visible";
            this.lblEstadoPelea.Text = "Muestra estado ";
            // 
            // tmrCalcularVotacion
            // 
            this.tmrCalcularVotacion.Tick += new System.EventHandler(this.tmrCalcularVotacion_Tick);
            // 
            // tmrLeerJoysticks
            // 
            this.tmrLeerJoysticks.Tick += new System.EventHandler(this.tmrLeerJoysticks_Tick);
            // 
            // pPausePlay
            // 
            this.pPausePlay.BackColor = System.Drawing.Color.Transparent;
            this.pPausePlay.BackgroundImage = global::Fight.Tablero.Properties.Resources.Pause;
            this.pPausePlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pPausePlay.Location = new System.Drawing.Point(705, 15);
            this.pPausePlay.Name = "pPausePlay";
            this.pPausePlay.Size = new System.Drawing.Size(52, 39);
            this.pPausePlay.TabIndex = 35;
            this.pPausePlay.Click += new System.EventHandler(this.pPausePlay_Click);
            // 
            // pCruzMedico
            // 
            this.pCruzMedico.BackColor = System.Drawing.Color.Transparent;
            this.pCruzMedico.BackgroundImage = global::Fight.Tablero.Properties.Resources.CruzMedico;
            this.pCruzMedico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pCruzMedico.Location = new System.Drawing.Point(834, 10);
            this.pCruzMedico.Name = "pCruzMedico";
            this.pCruzMedico.Size = new System.Drawing.Size(59, 46);
            this.pCruzMedico.TabIndex = 36;
            this.pCruzMedico.Click += new System.EventHandler(this.pCruzMedico_Click);
            // 
            // pCerrar
            // 
            this.pCerrar.BackColor = System.Drawing.Color.Transparent;
            this.pCerrar.Location = new System.Drawing.Point(967, 4);
            this.pCerrar.Name = "pCerrar";
            this.pCerrar.Size = new System.Drawing.Size(52, 47);
            this.pCerrar.TabIndex = 36;
            this.pCerrar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pCerrar_MouseClick);
            // 
            // pbCruzCerrar
            // 
            this.pbCruzCerrar.BackColor = System.Drawing.Color.Transparent;
            this.pbCruzCerrar.BackgroundImage = global::Fight.Tablero.Properties.Resources.Cruz_Cerrar;
            this.pbCruzCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbCruzCerrar.Location = new System.Drawing.Point(978, 13);
            this.pbCruzCerrar.Name = "pbCruzCerrar";
            this.pbCruzCerrar.Size = new System.Drawing.Size(30, 30);
            this.pbCruzCerrar.TabIndex = 37;
            this.pbCruzCerrar.TabStop = false;
            this.pbCruzCerrar.Tag = "visible";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Transparent;
            this.panel9.Location = new System.Drawing.Point(842, 563);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(76, 77);
            this.panel9.TabIndex = 31;
            // 
            // pbFalta_Izq
            // 
            this.pbFalta_Izq.BackColor = System.Drawing.Color.Transparent;
            this.pbFalta_Izq.BackgroundImage = global::Fight.Tablero.Properties.Resources.Falta_Activado;
            this.pbFalta_Izq.Location = new System.Drawing.Point(95, 552);
            this.pbFalta_Izq.Name = "pbFalta_Izq";
            this.pbFalta_Izq.Size = new System.Drawing.Size(100, 100);
            this.pbFalta_Izq.TabIndex = 40;
            this.pbFalta_Izq.TabStop = false;
            this.pbFalta_Izq.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbFalta_Izq_MouseDown);
            // 
            // pbFalta_Der
            // 
            this.pbFalta_Der.BackColor = System.Drawing.Color.Transparent;
            this.pbFalta_Der.BackgroundImage = global::Fight.Tablero.Properties.Resources.Falta_Activado;
            this.pbFalta_Der.Location = new System.Drawing.Point(830, 551);
            this.pbFalta_Der.Name = "pbFalta_Der";
            this.pbFalta_Der.Size = new System.Drawing.Size(100, 100);
            this.pbFalta_Der.TabIndex = 41;
            this.pbFalta_Der.TabStop = false;
            this.pbFalta_Der.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbFalta_Der_MouseDown);
            // 
            // pbMediaFalta_Izq
            // 
            this.pbMediaFalta_Izq.BackColor = System.Drawing.Color.Transparent;
            this.pbMediaFalta_Izq.BackgroundImage = global::Fight.Tablero.Properties.Resources.Falta_Activado;
            this.pbMediaFalta_Izq.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbMediaFalta_Izq.Location = new System.Drawing.Point(31, 553);
            this.pbMediaFalta_Izq.Name = "pbMediaFalta_Izq";
            this.pbMediaFalta_Izq.Size = new System.Drawing.Size(54, 54);
            this.pbMediaFalta_Izq.TabIndex = 42;
            this.pbMediaFalta_Izq.TabStop = false;
            this.pbMediaFalta_Izq.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbMediaFalta_Izq_MouseDown);
            // 
            // pbMediaFalta_Der
            // 
            this.pbMediaFalta_Der.BackColor = System.Drawing.Color.Transparent;
            this.pbMediaFalta_Der.BackgroundImage = global::Fight.Tablero.Properties.Resources.Falta_Activado;
            this.pbMediaFalta_Der.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbMediaFalta_Der.Location = new System.Drawing.Point(937, 555);
            this.pbMediaFalta_Der.Name = "pbMediaFalta_Der";
            this.pbMediaFalta_Der.Size = new System.Drawing.Size(54, 54);
            this.pbMediaFalta_Der.TabIndex = 43;
            this.pbMediaFalta_Der.TabStop = false;
            this.pbMediaFalta_Der.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbMediaFalta_Der_MouseDown);
            // 
            // pStop
            // 
            this.pStop.BackColor = System.Drawing.Color.Transparent;
            this.pStop.BackgroundImage = global::Fight.Tablero.Properties.Resources.Stop;
            this.pStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pStop.Location = new System.Drawing.Point(770, 15);
            this.pStop.Name = "pStop";
            this.pStop.Size = new System.Drawing.Size(52, 39);
            this.pStop.TabIndex = 44;
            this.pStop.Click += new System.EventHandler(this.pStop_Click);
            // 
            // lblCronometro
            // 
            this.lblCronometro.AutoSize = true;
            this.lblCronometro.BackColor = System.Drawing.Color.Transparent;
            this.lblCronometro.Font = new System.Drawing.Font("Arial", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCronometro.ForeColor = System.Drawing.Color.GreenYellow;
            this.lblCronometro.Location = new System.Drawing.Point(365, 0);
            this.lblCronometro.Name = "lblCronometro";
            this.lblCronometro.Size = new System.Drawing.Size(301, 78);
            this.lblCronometro.TabIndex = 18;
            this.lblCronometro.Tag = "visible";
            this.lblCronometro.Text = "00:00:00";
            // 
            // tmrCronometro
            // 
            this.tmrCronometro.Interval = 1000;
            this.tmrCronometro.Tick += new System.EventHandler(this.tmrCronometro_Tick_1);
            // 
            // tmrRelojColorIntermitente
            // 
            this.tmrRelojColorIntermitente.Interval = 500;
            this.tmrRelojColorIntermitente.Tick += new System.EventHandler(this.tmrRelojColorIntermitente_Tick_1);
            // 
            // tmrGanadorIntermitente
            // 
            this.tmrGanadorIntermitente.Interval = 1000;
            this.tmrGanadorIntermitente.Tick += new System.EventHandler(this.tmrGanadorIntermitente_Tick);
            // 
            // pFondoRojo
            // 
            this.pFondoRojo.BackColor = System.Drawing.Color.Transparent;
            this.pFondoRojo.BackgroundImage = global::Fight.Tablero.Properties.Resources.FondoRojo;
            this.pFondoRojo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pFondoRojo.Controls.Add(this.lblPuntoRojo);
            this.pFondoRojo.Location = new System.Drawing.Point(22, 109);
            this.pFondoRojo.Name = "pFondoRojo";
            this.pFondoRojo.Size = new System.Drawing.Size(487, 432);
            this.pFondoRojo.TabIndex = 45;
            // 
            // pFondoAzul
            // 
            this.pFondoAzul.BackColor = System.Drawing.Color.Transparent;
            this.pFondoAzul.BackgroundImage = global::Fight.Tablero.Properties.Resources.FondoAzul;
            this.pFondoAzul.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pFondoAzul.Controls.Add(this.lblPuntoAzul);
            this.pFondoAzul.Location = new System.Drawing.Point(517, 109);
            this.pFondoAzul.Name = "pFondoAzul";
            this.pFondoAzul.Size = new System.Drawing.Size(491, 432);
            this.pFondoAzul.TabIndex = 46;
            // 
            // lblNombreRojo
            // 
            this.lblNombreRojo.AutoSize = true;
            this.lblNombreRojo.BackColor = System.Drawing.Color.Transparent;
            this.lblNombreRojo.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreRojo.Location = new System.Drawing.Point(36, 73);
            this.lblNombreRojo.Name = "lblNombreRojo";
            this.lblNombreRojo.Size = new System.Drawing.Size(132, 37);
            this.lblNombreRojo.TabIndex = 47;
            this.lblNombreRojo.Tag = "visible";
            this.lblNombreRojo.Text = "HONGH";
            // 
            // lblNombreAzul
            // 
            this.lblNombreAzul.AutoSize = true;
            this.lblNombreAzul.BackColor = System.Drawing.Color.Transparent;
            this.lblNombreAzul.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblNombreAzul.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreAzul.Location = new System.Drawing.Point(144, 0);
            this.lblNombreAzul.Name = "lblNombreAzul";
            this.lblNombreAzul.Size = new System.Drawing.Size(153, 37);
            this.lblNombreAzul.TabIndex = 48;
            this.lblNombreAzul.Tag = "visible";
            this.lblNombreAzul.Text = "TCHONG";
            // 
            // pNombreRojo
            // 
            this.pNombreRojo.BackColor = System.Drawing.Color.Transparent;
            this.pNombreRojo.Location = new System.Drawing.Point(31, 73);
            this.pNombreRojo.Name = "pNombreRojo";
            this.pNombreRojo.Size = new System.Drawing.Size(251, 37);
            this.pNombreRojo.TabIndex = 49;
            // 
            // pNombreAzul
            // 
            this.pNombreAzul.BackColor = System.Drawing.Color.Transparent;
            this.pNombreAzul.Controls.Add(this.lblNombreAzul);
            this.pNombreAzul.Location = new System.Drawing.Point(700, 73);
            this.pNombreAzul.Name = "pNombreAzul";
            this.pNombreAzul.Size = new System.Drawing.Size(297, 37);
            this.pNombreAzul.TabIndex = 50;
            // 
            // tmrComprobarPenDrive
            // 
            this.tmrComprobarPenDrive.Enabled = true;
            this.tmrComprobarPenDrive.Interval = 60000;
            this.tmrComprobarPenDrive.Tick += new System.EventHandler(this.tmrComprobarPenDrive_Tick);
            // 
            // tmrComprobrarEstadoJoysticksConectados
            // 
            this.tmrComprobrarEstadoJoysticksConectados.Enabled = true;
            this.tmrComprobrarEstadoJoysticksConectados.Interval = 10000;
            this.tmrComprobrarEstadoJoysticksConectados.Tick += new System.EventHandler(this.tmrComprobrarEstadoJoysticksConectados_Tick);
            // 
            // cmsOpciones
            // 
            this.cmsOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiConfiguraciones,
            this.tsmiAuditoria,
            this.tsmiCambiarNombres});
            this.cmsOpciones.Name = "cmsOpciones";
            this.cmsOpciones.Size = new System.Drawing.Size(170, 70);
            // 
            // tsmiConfiguraciones
            // 
            this.tsmiConfiguraciones.Name = "tsmiConfiguraciones";
            this.tsmiConfiguraciones.Size = new System.Drawing.Size(169, 22);
            this.tsmiConfiguraciones.Text = "Configuraciones";
            this.tsmiConfiguraciones.Click += new System.EventHandler(this.tsmiConfiguraciones_Click);
            // 
            // tsmiAuditoria
            // 
            this.tsmiAuditoria.Name = "tsmiAuditoria";
            this.tsmiAuditoria.Size = new System.Drawing.Size(169, 22);
            this.tsmiAuditoria.Text = "Auditoría";
            this.tsmiAuditoria.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // btnAuditoria
            // 
            this.btnAuditoria.BackColor = System.Drawing.Color.DarkGray;
            this.btnAuditoria.ContextMenuStrip = this.cmsOpciones;
            this.btnAuditoria.Location = new System.Drawing.Point(0, 745);
            this.btnAuditoria.Name = "btnAuditoria";
            this.btnAuditoria.Size = new System.Drawing.Size(22, 23);
            this.btnAuditoria.TabIndex = 51;
            this.btnAuditoria.UseVisualStyleBackColor = false;
            // 
            // tsmiCambiarNombres
            // 
            this.tsmiCambiarNombres.Name = "tsmiCambiarNombres";
            this.tsmiCambiarNombres.Size = new System.Drawing.Size(169, 22);
            this.tsmiCambiarNombres.Text = "Cambiar nombres";
            this.tsmiCambiarNombres.Click += new System.EventHandler(this.tsmiCambiarNombres_Click);
            // 
            // Tablero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.BackgroundImage = global::Fight.Tablero.Properties.Resources.Fondo_Desactivado_2;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.btnAuditoria);
            this.Controls.Add(this.pNombreAzul);
            this.Controls.Add(this.lblNombreRojo);
            this.Controls.Add(this.pNombreRojo);
            this.Controls.Add(this.pbFalta_Der);
            this.Controls.Add(this.pbFalta_Izq);
            this.Controls.Add(this.pFondoAzul);
            this.Controls.Add(this.pFondoRojo);
            this.Controls.Add(this.lblCronometro);
            this.Controls.Add(this.pStop);
            this.Controls.Add(this.pbMediaFalta_Der);
            this.Controls.Add(this.pbMediaFalta_Izq);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.pbCruzCerrar);
            this.Controls.Add(this.pCerrar);
            this.Controls.Add(this.pCruzMedico);
            this.Controls.Add(this.pPausePlay);
            this.Controls.Add(this.lblFaltasRojo);
            this.Controls.Add(this.lblFaltasAzul);
            this.Controls.Add(this.lblEstadoPelea);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Tablero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tablero";
            this.Load += new System.EventHandler(this.Tablero_Load);
            this.DoubleClick += new System.EventHandler(this.Tablero_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.pbCruzCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFalta_Izq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFalta_Der)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMediaFalta_Izq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMediaFalta_Der)).EndInit();
            this.pFondoRojo.ResumeLayout(false);
            this.pFondoRojo.PerformLayout();
            this.pFondoAzul.ResumeLayout(false);
            this.pFondoAzul.PerformLayout();
            this.pNombreAzul.ResumeLayout(false);
            this.pNombreAzul.PerformLayout();
            this.cmsOpciones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private Controles.Crono cronometro;
        private System.Windows.Forms.Label lblPuntoAzul;
        private System.Windows.Forms.Label lblPuntoRojo;
        private System.Windows.Forms.Label lblFaltasRojo;
        private System.Windows.Forms.Label lblFaltasAzul;
        private System.Windows.Forms.Label lblEstadoPelea;
        private System.Windows.Forms.Timer tmrCalcularVotacion;
        private System.Windows.Forms.Timer tmrLeerJoysticks;
        private System.Windows.Forms.Panel pPausePlay;
        private System.Windows.Forms.Panel pCruzMedico;
        private System.Windows.Forms.Panel pCerrar;
        private System.Windows.Forms.PictureBox pbCruzCerrar;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.PictureBox pbFalta_Izq;
        private System.Windows.Forms.PictureBox pbFalta_Der;
        private System.Windows.Forms.PictureBox pbMediaFalta_Izq;
        private System.Windows.Forms.PictureBox pbMediaFalta_Der;
        private System.Windows.Forms.Panel pStop;
        private System.Windows.Forms.Label lblCronometro;
        private System.Windows.Forms.Timer tmrCronometro;
        private System.Windows.Forms.Timer tmrRelojColorIntermitente;
        private System.Windows.Forms.Timer tmrGanadorIntermitente;
        private System.Windows.Forms.Panel pFondoRojo;
        private System.Windows.Forms.Panel pFondoAzul;
        private System.Windows.Forms.Label lblNombreRojo;
        private System.Windows.Forms.Label lblNombreAzul;
        private System.Windows.Forms.Panel pNombreRojo;
        private System.Windows.Forms.Panel pNombreAzul;
        private System.Windows.Forms.Timer tmrComprobarPenDrive;
        private System.Windows.Forms.Timer tmrComprobrarEstadoJoysticksConectados;
        private System.Windows.Forms.ContextMenuStrip cmsOpciones;
        private System.Windows.Forms.ToolStripMenuItem tsmiConfiguraciones;
        private System.Windows.Forms.ToolStripMenuItem tsmiAuditoria;
        private System.Windows.Forms.Button btnAuditoria;
        private System.Windows.Forms.ToolStripMenuItem tsmiCambiarNombres;
        //private Fight.Controles.Cronometro cronometro;
    }
}