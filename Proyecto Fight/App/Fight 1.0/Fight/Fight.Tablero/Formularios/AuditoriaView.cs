using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fight.Tablero.Formularios
{
    public partial class AuditoriaView : Form
    {
        public AuditoriaView(Entidades.AuditoriaDTO.AuditoriaDTDataTable dt)
        {

            InitializeComponent();

            try
            {
                this.dgvAuditoriaDT.DataSource = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
