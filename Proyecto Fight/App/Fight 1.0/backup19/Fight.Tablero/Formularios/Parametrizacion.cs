using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Fight.Tablero.Clases;

namespace Fight.Tablero.Formularios
{
    public partial class Parametrizacion : Form
    {
        LecturaEscrituraXml objIOXML = null;

        Clases.RegistroErrores objRegErr = null;

        //leer el obj de parametrizacion para cargar los valores del formulario
        Fight.Tablero.Clases.Parametrizacion objParametrizacion = null;

        #region Eventos

        private void Parametrizacion_Load(object sender, EventArgs e)
        {

            //Cargar valores del obj parametrizacion que esta cargado en la sesion actual.
            //TiempoCalcPuntaje int
            this.nudTiempoCalculoPuntaje.Value = this.objParametrizacion.tiempoMuerto; // int.Parse(objIOXML.LeerUnCampo("TiempoMuerto"));//1;

            //CantVotosMin int
            this.nudCantVotosMinimos.Value = this.objParametrizacion.cantVotosMinimos; // int.Parse(objIOXML.LeerUnCampo("CantVotosMin")); //1;

            //ValPuntoA int
            nudValPuntuacionA.Value = this.objParametrizacion.PuntoA.puntaje; // int.Parse(objIOXML.LeerUnCampo("ValPuntoA")); //1;

            //ValPuntoB int
            nudValPuntuacionB.Value = this.objParametrizacion.PuntoB.puntaje; // int.Parse(objIOXML.LeerUnCampo("ValPuntoB")); //1;

            //ValPuntoC int
            nudValPuntuacionC.Value = this.objParametrizacion.PuntoC.puntaje; // int.Parse(objIOXML.LeerUnCampo("ValPuntoC")); //1;

            //CantRounds int
            this.nudCantRounds.Value = this.objParametrizacion.cantRounds; //int.Parse(objIOXML.LeerUnCampo("CantRounds")); //1;

            //TiempoRound string
            this.mtxtTiempoRound.Text = this.objParametrizacion.tiempoRound; // objIOXML.LeerUnCampo("TiempoRound");//"00:00:00";

            //PuntoOro bool
            chkPuntoOro.Checked = this.objParametrizacion.goldenPoint; // Boolean.Parse(objIOXML.LeerUnCampo("PuntoOro"));//true;

            //TiempoDescanso string
            this.mtxtTiempoDescanso.Text = this.objParametrizacion.tiempoDescanso; //objIOXML.LeerUnCampo("TiempoDescanso");//"00:00:00";

            //TiempoMedico string
            mtxtTiempoMedico.Text = this.objParametrizacion.tiempoMedico; //objIOXML.LeerUnCampo("TiempoMedico");//"00:00:00";

            //TiempoPuntoOro string
            mtxtTiempoPuntoOro.Text = this.objParametrizacion.tiempoPuntoOro; //objIOXML.LeerUnCampo("TiempoPuntoOro");//"00:00:00";

            //ValFalta int
            nudValFalta.Value = this.objParametrizacion.valorFalta; //int.Parse(objIOXML.LeerUnCampo("ValFalta")); //1;

            //ValPuntacionManual int
            nudValPuntuacionManual.Value = this.objParametrizacion.valorPuntuacionManual; //int.Parse(objIOXML.LeerUnCampo("ValPuntacionManual")); //1;

            //DifPuntos int
            nudDiferenciaPuntos.Value = this.objParametrizacion.diferenciaPuntos; //int.Parse(objIOXML.LeerUnCampo("DifPuntos")); //1;

            //PuntuacionMax int
            nudPuntuacionMaxima.Value = this.objParametrizacion.puntuacionMaxima; //int.Parse(objIOXML.LeerUnCampo("PuntuacionMax")); //1;

            //FaltasMax int
            nudFaltasMaximas.Value = this.objParametrizacion.faltasMaximas; //int.Parse(objIOXML.LeerUnCampo("FaltasMax")); //1;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de cancelar los cambios?", "Parametrización", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                this.Close();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("¿Está seguro de guardar los cambios? Si acepta, el sistema se reiniciará.", "Parametrización", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    objIOXML.ActualizarXML(
                                    (nudTiempoCalculoPuntaje.Value).ToString(),
                                    nudCantVotosMinimos.Value.ToString(),
                                    nudValPuntuacionA.Value.ToString(),
                                    nudValPuntuacionB.Value.ToString(),
                                    nudValPuntuacionC.Value.ToString(),
                                    nudCantRounds.Value.ToString(),
                                    mtxtTiempoRound.Text,
                                    chkPuntoOro.Checked.ToString(),
                                    mtxtTiempoDescanso.Text,
                                    mtxtTiempoMedico.Text,
                                    mtxtTiempoPuntoOro.Text,
                                    nudValFalta.Value.ToString(),
                                    nudValPuntuacionManual.Value.ToString(),
                                    nudDiferenciaPuntos.Value.ToString(),
                                    nudPuntuacionMaxima.Value.ToString(),
                                    nudFaltasMaximas.Value.ToString()

                                  );
                    ReinicioApp();
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Ocurrió un error al intentar guardar los cambios de Parametrización. Los cambios no se guardarán.");
                objRegErr.RegistrarError("Guardar cambios de Parametrización.", err.Message.ToString());
                this.Close();
            }

        }

        private void btnResetParam_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Está seguro de volver a los valores por defecto? Si acepta el sistema se reiniciará.", "Parametrización", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    objIOXML.ResetearParametrizacion();
                    ReinicioApp();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Ocurrió un error al intentar reestablecer los valores por defecto de Parametrización. Los cambios no se guardarán.");
                objRegErr.RegistrarError("Guardar cambios de Parametrización.", err.Message.ToString());
                this.Close();
            }

        }

        #endregion

        public Parametrizacion(Fight.Tablero.Clases.Parametrizacion _objParametrizacion)
        {
            InitializeComponent();

            this.objParametrizacion = _objParametrizacion;

            objIOXML = new LecturaEscrituraXml(Application.StartupPath + "\\ParametrizacionTablero.xml");
        }
        
        private void ReinicioApp()
        {
            String executablePath = Application.ExecutablePath;
            Application.Exit();
            System.Diagnostics.Process Proceso = new System.Diagnostics.Process();

            if (System.IO.File.Exists(executablePath))
                Proceso = System.Diagnostics.Process.Start(executablePath);

        }

    }
}
