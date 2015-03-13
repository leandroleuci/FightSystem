using System;
using System.Collections.Generic;
using System.Text;
using Fight.Tablero.Entidades;
using System.Windows.Forms;
using System.IO;


class Auditoria
{

    //public AuditoriaDTO dsAuditoria ;
    //public AuditoriaDTO.AuditoriaDataTableDT dtAuditoria;

    public Auditoria()
    {
        //dsAuditoria = new AuditoriaDTO();
        //dtAuditoria = new AuditoriaDTO.AuditoriaDataTable();

        crearPath();
    }

    private void crearPath()
    {
        if (!Directory.Exists(Application.ExecutablePath.Substring(0, 1) + ":\\Auditoria"))
            Directory.CreateDirectory(Application.ExecutablePath.Substring(0, 1) + ":\\Auditoria");

        if (!Directory.Exists(Application.ExecutablePath.Substring(0, 1) + ":\\Auditoria\\" + DateTime.Now.ToString("yyyyMMdd")))
            Directory.CreateDirectory(Application.ExecutablePath.Substring(0, 1) + ":\\Auditoria\\" + DateTime.Now.ToString("yyyyMMdd"));
    }

    //public void AgregarLog(AuditoriaDTO.AuditoriaRow rowAuditoria)
    //{

    //    dtAuditoria.AddAuditoriaRow(rowAuditoria);
    //}

    public void crearArchivoAuditoria(AuditoriaDTO dsAuditoria, ref string pathArchivoCreado)
    {
        try
        {
            ExportarExcelNPOI objExportarAExcel = new ExportarExcelNPOI();
            string nombreSistema = "FightSystem";
            pathArchivoCreado = Application.ExecutablePath.Substring(0, 1) + ":\\Auditoria\\" + DateTime.Now.ToString("yyyyMMdd") + "\\" + nombreSistema + "_" + DateTime.Now.ToString("HH.mm.ss fff") + ".xls";  // "C:\\aa.xls"; 

            if (!File.Exists(pathArchivoCreado))
                objExportarAExcel.ExportarExcelProcesos(dsAuditoria, pathArchivoCreado, new string[] { "Auditoria Combate" });

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }


}

