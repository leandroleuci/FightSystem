using System.Text;
using System;
using System.Data;
using System.IO;
using System.Web;
//using System.Web.UI;
//using System.Web.UI.HtmlControls;
//using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;




        /// <summary>
        /// Clase encargada de la gestion de ficheros excel. 
        /// </summary>
        public class ExportarExcelNPOI
        {
            #region --[Propiedades]--
            /// <summary>
            /// String con formato HTML.
            /// </summary>
            public string TextoFormateado { get; private set; }

            /// <summary>
            /// String con el nombre de archivo
            /// </summary>
            public string NombreArchivo { get; private set; }

            /// <summary>
            /// String con el nombre de archivo completo
            /// </summary>
            public string NombreArchivoCompleto { get; private set; }

            /// <summary>
            /// Un String con la url de destino donde se grabara el fichero. 
            /// </summary>
            public string UrlDestino { get; private set; }

            /// <summary>
            /// Contenido del TextoFormateado
            /// </summary>
            public Byte[] ArrayBytesFichero { get; private set; }
            #endregion

            #region --[Constructor]--

            public ExportarExcelNPOI()
            {
            }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="textoFormateado"></param>
            /// <param name="nombreArchivo"></param>
            /// <param name="urlDestino"></param>
            public ExportarExcelNPOI(String textoFormateado, String nombreArchivo, String urlDestino)
            {
                TextoFormateado = textoFormateado;
                NombreArchivo = nombreArchivo;
                UrlDestino = urlDestino;
            }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="textoFormateado"></param>
            /// <param name="nombreArchivo"></param>
            public ExportarExcelNPOI(String textoFormateado, String nombreArchivo)
            {
                TextoFormateado = textoFormateado;
                NombreArchivo = nombreArchivo;
            }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="nombreArchivo"></param>
            public ExportarExcelNPOI(String nombreArchivo)
            {
                NombreArchivo = nombreArchivo;
            }
            #endregion

            #region --[Métodos Publicos]--

            public Boolean GenerarArchivoExcel()
            {
                return GenerarArchivoExcel(true);
            }

            /// <summary>
            /// Genera un fichero Excel con el contenido del parámetro con formato HTML en 
            /// la dirección URL con el nombre recibido por parámetro de la siguiente forma nombre_[timestamp].xls 
            /// donde timestamp  es el instante preciso en que se genera este fichero)
            /// <param name="listaCamposFiltro">Lista con los nombres de las columnas en el DT</param>
            /// <param name="listaColumnas">Nombre de las columnas a mostrar en el archivo excel, separadas por comas</param>
            /// <param name="objDataTable">Objeto Datatable que contiene todos los datos a exportar</param>
            /// </summary>
            /// <returns></returns>
            public Boolean GenerarArchivoExcel(String listaCamposFiltro, String listaColumnas, DataTable objDataTable)
            {
                Boolean retorno;

                try
                {
                    String textoFormateado = "";
                    DataTable dtFiltadra = objDataTable.Copy();
                    String[] Columnas;
                    Int32 indice = 0;

                    Columnas = listaColumnas.Split(',');
                    //Columnas
                    textoFormateado +=
                        "<TR style='font-family: Taoma, Verdana, Arial, Helvetica, sans-serif, Symbol;font-size: 15px;font-weight: bold;'>";
                    foreach (DataColumn colum in objDataTable.Columns)
                    {
                        if (listaCamposFiltro.ToLower().Contains(colum.ColumnName.ToLower()))
                        {
                            textoFormateado +=
                            String.Format(
                                "<TD style='font-family: Taoma, Verdana, Arial, Helvetica, sans-serif, Symbol;font-size: 15px;font-weight: bold;'>{0}</TD>",
                                Columnas[indice].ToString().Trim().ToUpper());
                            indice++;
                        }
                        else
                        {
                            if (!colum.Unique)
                                dtFiltadra.Columns.Remove(colum.ColumnName);
                        }


                    }

                    //Filas
                    foreach (DataRow row in dtFiltadra.Rows)
                    {
                        textoFormateado += "<TR>";
                        foreach (DataColumn colum in dtFiltadra.Columns)
                        {
                            if (listaCamposFiltro.ToLower().Contains(colum.ColumnName.ToLower()))
                                textoFormateado += "<TD>" + row[colum.ColumnName] + "</TD>";
                        }
                        textoFormateado += "</TR>";
                    }

                    TextoFormateado = "<HTML><meta http-equiv='Content-Type' content='text/html; charset=utf-8'/> <BODY><TABLE border='1'>" + textoFormateado + "</TABLE> </BODY></HTML>";
                    GenerarBytesExcel();
                    retorno = true;
                }
                catch (Exception ex)
                {
                    string exmsn = ex.Message;
                    retorno = false;
                }
                return retorno;
            }

            public Boolean GenerarArchivoExcel(String listaCamposFiltro, DataTable objDataTable)
            {
                Boolean retorno;

                try
                {
                    String textoFormateado = "";
                    DataTable dtFiltadra = objDataTable.Copy();

                    //Columnas
                    textoFormateado +=
                        "<TR style='font-family: Taoma, Verdana, Arial, Helvetica, sans-serif, Symbol;font-size: 15px;font-weight: bold;'>";
                    foreach (DataColumn colum in objDataTable.Columns)
                    {
                        if (listaCamposFiltro.ToLower().Contains(colum.ColumnName.ToLower()))
                            textoFormateado +=
                            String.Format(
                                "<TD style='font-family: Taoma, Verdana, Arial, Helvetica, sans-serif, Symbol;font-size: 15px;font-weight: bold;'>{0}</TD>",
                                colum.ColumnName);
                        else
                        {
                            if (!colum.Unique)
                                dtFiltadra.Columns.Remove(colum.ColumnName);
                        }


                    }

                    //Filas
                    foreach (DataRow row in dtFiltadra.Rows)
                    {
                        textoFormateado += "<TR>";
                        foreach (DataColumn colum in dtFiltadra.Columns)
                        {
                            if (listaCamposFiltro.ToLower().Contains(colum.ColumnName.ToLower()))
                                textoFormateado += "<TD align='Center'>" + row[colum.ColumnName] + "</TD>";
                        }
                        textoFormateado += "</TR>";
                    }

                    TextoFormateado = "<HTML><meta http-equiv='Content-Type' content='text/html; charset=utf-8'/> <BODY><TABLE border='1'>" + textoFormateado + "</TABLE> </BODY></HTML>";
                    GenerarBytesExcel();
                    retorno = true;
                }
                catch (Exception ex)
                {
                    string exmsn = ex.Message;
                    retorno = false;
                }
                return retorno;
            }

            /// <summary>
            /// Genera un fichero Excel con el contenido del parámetro con formato HTML en 
            /// la dirección URL con el nombre recibido por parámetro de la siguiente forma nombre_[timestamp].xls 
            /// donde timestamp  es el instante preciso en que se genera este fichero)
            /// </summary>
            /// <returns></returns>
            public Boolean GenerarArchivoExcel(bool generarNombre)
            {
                Boolean retorno;

                try
                {
                    if (generarNombre)
                        NombreArchivo = String.Format("{0}_{1}.xls", NombreArchivo, DateTime.Now.ToString("yyyy.MM.dd_hh.mm.ss"));

                    // Formateamos la Ruta 
                    NombreArchivoCompleto = String.Format("{0}\\{1}", UrlDestino, NombreArchivo);

                    //En caso de no existir el directorio lo crea. 
                    if (!Directory.Exists(UrlDestino))
                        Directory.CreateDirectory(UrlDestino);

                    //Obtiene el array de Bytes del String Recibido. 
                    //ASCIIEncoding encoding = new ASCIIEncoding();
                    //ArrayBytesFichero = encoding.GetBytes(TextoFormateado);
                    ArrayBytesFichero = System.Text.Encoding.Default.GetBytes(TextoFormateado);


                    //Guarda el Fichero en Disco. 
                    FileStream fs = new FileStream(NombreArchivoCompleto, FileMode.Create);
                    fs.Write(ArrayBytesFichero, 0, ArrayBytesFichero.Length);
                    fs.Close();
                    //fs.Dispose();


                    //System.Runtime.InteropServices.Marshal.FinalReleaseComObject(fs);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    retorno = true;

                }
                catch (Exception ex)
                {
                    string exmsn = ex.Message;
                    retorno = false;
                }
                return retorno;
            }

            public Boolean GenerarArchivoExcel(bool generarNombre, Byte[] ArrayBytesFichero)
            {
                Boolean retorno;

                try
                {
                    if (generarNombre)
                        NombreArchivo = String.Format("{0}_{1}.xls", NombreArchivo, DateTime.Now.ToString("yyyy.MM.dd_hh.mm.ss"));

                    // Formateamos la Ruta 
                    NombreArchivoCompleto = String.Format("{0}\\{1}", UrlDestino, NombreArchivo);

                    this.ArrayBytesFichero = ArrayBytesFichero;

                    retorno = true;

                }
                catch (Exception ex)
                {
                    string exmsn = ex.Message;
                    retorno = false;
                }
                return retorno;
            }

            /// <summary>
            /// Genera un Array de Bytes en base al un String que contiene un formato HTML.
            /// </summary>
            /// <returns></returns>
            public Byte[] GenerarBytesExcel()
            {
                NombreArchivo = String.Format("{0}_{1}.xls", NombreArchivo, DateTime.Now.ToString("yyyy.MM.dd_hh.mm.ss"));
                UTF8Encoding encoding = new UTF8Encoding();
                ArrayBytesFichero = encoding.GetBytes(TextoFormateado);
                return ArrayBytesFichero;
            }


            //public void PresentarArchivoExcel(GridView grillaOculta, string nombreFichero)
            //{
            //    StringBuilder strB = new StringBuilder();
            //    StringWriter strW = new StringWriter(strB);
            //    HtmlTextWriter grillaHTML = new HtmlTextWriter(strW);
            //    Page page = new Page();
            //    HtmlForm form = new HtmlForm();
            //    grillaOculta.EnableViewState = false;

            //    page.Controls.Add(form);
            //    form.Controls.Add(grillaOculta);
            //    page.RenderControl(grillaHTML);

            //    //HttpContext.Current.Request.c . .Clear();
            //    HttpContext.Current.Response.Buffer = true;
            //    HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            //    HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}.xls", nombreFichero));
            //    HttpContext.Current.Response.Charset = "UTF-8";
            //    HttpContext.Current.Response.ContentEncoding = Encoding.Default;
            //    HttpContext.Current.Response.Write(strB.ToString());
            //    HttpContext.Current.Response.Flush();
            //    HttpContext.Current.Response.End();

            //}


            /// <summary>
            /// Método que permite exportar a excel las tablas de un dataset y generar las hojas por parámetros
            /// </summary>
            /// <param name="dsDatos">Dataset con las tablas</param>
            /// <param name="hojas">strings con los nombres de las hojas</param>
            public void ExportarExcelProcesos(DataSet DSDatos, string filename, string[] hojas)
            {
                HSSFWorkbook WORKBOOK = null;
                CellStyle CELLSTYLE = null;
                CellStyle CELLSTYLEFILAS = null;
                Sheet sheet = null;
                Font font = null;
                int numColumna = 0;
                FileStream file = null;
                try
                {
                    if (DSDatos != null && hojas.Length == DSDatos.Tables.Count)
                    {
                        WORKBOOK = new HSSFWorkbook();
                        CELLSTYLEFILAS = WORKBOOK.CreateCellStyle();
                        CELLSTYLE = WORKBOOK.CreateCellStyle();
                        CELLSTYLE.BorderBottom = CellBorderType.THIN;
                        CELLSTYLE.BorderLeft = CellBorderType.THIN;
                        CELLSTYLE.BorderRight = CellBorderType.THIN;
                        CELLSTYLE.BorderTop = CellBorderType.THIN;
                        CELLSTYLEFILAS.BorderBottom = CellBorderType.THIN;
                        CELLSTYLEFILAS.BorderLeft = CellBorderType.THIN;
                        CELLSTYLEFILAS.BorderRight = CellBorderType.THIN;
                        CELLSTYLEFILAS.BorderTop = CellBorderType.THIN;
                        font = WORKBOOK.CreateFont();
                        font.Boldweight =
                        font.Boldweight = font.Boldweight;
                        CELLSTYLE.SetFont(font);
                        CELLSTYLE.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.LIGHT_TURQUOISE.index;
                        CELLSTYLE.FillPattern = FillPatternType.SOLID_FOREGROUND;


                        //Rellena cada DataTable del DataSet en una hoja de excel(Sheet) recorriendo fila por fila
                        for (int nTabla = 0; nTabla < DSDatos.Tables.Count; nTabla++)
                        {
                            //si la tabla tiene filas continúa y las carga
                            if (DSDatos.Tables[nTabla].Rows.Count > 0)
                            {
                                sheet = WORKBOOK.CreateSheet(hojas[nTabla]);
                                Row row = sheet.CreateRow(0);
                                Cell cell;
                                int iColumna = 0;
                                //Primero genera las columnas y les da un estilo(Font Negrita con fondo gris)
                                //if (nTabla == 0)
                                //    numColumna = 28;
                                //else
                                numColumna = DSDatos.Tables[nTabla].Columns.Count;
                                for (int nColumna = 0; nColumna < numColumna; nColumna++)
                                {
                                    cell = row.CreateCell(nColumna);
                                    cell.SetCellValue(DSDatos.Tables[nTabla].Columns[iColumna].ColumnName);
                                    sheet.AutoSizeColumn(nColumna);
                                    cell.CellStyle = CELLSTYLE;
                                    iColumna++;
                                }

                                //Genero la carga de datos del DataTable en las celdas de Excel
                                int iFila = 0;
                                for (int fila = 1; fila <= DSDatos.Tables[nTabla].Rows.Count; fila++)
                                {
                                    iColumna = 0;
                                    row = sheet.CreateRow(fila);
                                    for (int nColumna = 0; nColumna < numColumna; nColumna++)
                                    {
                                        cell = row.CreateCell(nColumna);
                                        if (DSDatos.Tables[nTabla].Columns[iColumna].ColumnName.Equals("Fecha 6 meses") || DSDatos.Tables[nTabla].Columns[iColumna].ColumnName.Equals("Fecha Alta") || DSDatos.Tables[nTabla].Columns[iColumna].ColumnName.Equals("Fecha Registro") || DSDatos.Tables[nTabla].Columns[iColumna].ColumnName.Equals("Fecha Estado"))
                                        {
                                            if (!DSDatos.Tables[nTabla].Rows[iFila][iColumna].ToString().Equals(""))
                                                cell.SetCellValue(DateTime.Parse(DSDatos.Tables[nTabla].Rows[iFila][iColumna].ToString()).ToShortDateString());
                                            else
                                                cell.SetCellValue("");
                                        }

                                        else
                                            cell.SetCellValue(DSDatos.Tables[nTabla].Rows[iFila][iColumna].ToString());

                                        sheet.AutoSizeColumn(nColumna);
                                        cell.CellStyle = CELLSTYLEFILAS;
                                        iColumna++;
                                    }
                                    iFila++;
                                }
                            }
                        }
                        file = new FileStream(filename, FileMode.Create);
                        WORKBOOK.Write(file);
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (WORKBOOK != null)
                        WORKBOOK.Dispose();
                    CELLSTYLE = null;
                    if (sheet != null)
                        sheet.Dispose();
                    if (font != null)
                        font = null;
                    if (DSDatos != null)
                        DSDatos = null;
                    if (file != null)
                    {
                        file.Close();
                        file.Dispose();
                        GC.WaitForPendingFinalizers();
                        GC.Collect();
                    }
                }
            }


            /// <summary>
            /// Método que permite exportar a excel las tablas de un dataset y generar las hojas por parámetros
            /// </summary>
            /// <param name="dsDatos">Dataset con las tablas</param>
            /// <param name="hojas">strings con los nombres de las hojas</param>
            //public void ExportarExcel(DataSet DSDatos, string filename, string[] hojas)
            //{
            //    HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            //    HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", filename));
            //    HttpContext.Current.Response.Clear();

            //    HSSFWorkbook WORKBOOK = null;
            //    CellStyle CELLSTYLE = null;
            //    Sheet sheet = null;
            //    MemoryStream file = null;
            //    Font font = null;
            //    int numColumna = 0;
            //    try
            //    {
            //        if (hojas.Length == DSDatos.Tables.Count)
            //        {
            //            WORKBOOK = new HSSFWorkbook();
            //            CELLSTYLE = WORKBOOK.CreateCellStyle();
            //            CELLSTYLE.FillPattern = FillPatternType.SOLID_FOREGROUND;
            //            font = WORKBOOK.CreateFont();
            //            font.Boldweight = font.Boldweight;
            //            CELLSTYLE.SetFont(font);
            //            CELLSTYLE.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.GREY_25_PERCENT.index;

            //            //Rellena cada DataTable de DataSet en una hoja de excel(Sheet)
            //            for (int nTabla = 0; nTabla < DSDatos.Tables.Count; nTabla++)
            //            {
            //                sheet = WORKBOOK.CreateSheet(hojas[nTabla]);
            //                Row row = sheet.CreateRow(0);
            //                Cell cell;
            //                int iColumna = 0;
            //                //Primero genera las columnas y les da un estilo(Font Negrita con fondo gris)
            //                if (nTabla == 0)
            //                    numColumna = 28;
            //                else
            //                    numColumna = DSDatos.Tables[nTabla].Columns.Count;
            //                for (int nColumna = 0; nColumna < numColumna; nColumna++)
            //                {
            //                    cell = row.CreateCell(nColumna);
            //                    cell.SetCellValue(DSDatos.Tables[nTabla].Columns[iColumna].ColumnName);
            //                    sheet.AutoSizeColumn(nColumna);
            //                    cell.CellStyle = CELLSTYLE;
            //                    iColumna++;
            //                }

            //                //Genero la carga de datos del DataTable en las celdas de Excel
            //                int iFila = 0;
            //                for (int fila = 1; fila <= DSDatos.Tables[nTabla].Rows.Count; fila++)
            //                {
            //                    iColumna = 0;
            //                    row = sheet.CreateRow(fila);
            //                    for (int nColumna = 0; nColumna < numColumna; nColumna++)
            //                    {
            //                        cell = row.CreateCell(nColumna);
            //                        if (DSDatos.Tables[nTabla].Columns[iColumna].ColumnName.Equals("Fecha 6 meses") || DSDatos.Tables[nTabla].Columns[iColumna].ColumnName.Equals("Fecha Alta") || DSDatos.Tables[nTabla].Columns[iColumna].ColumnName.Equals("Fecha Registro") || DSDatos.Tables[nTabla].Columns[iColumna].ColumnName.Equals("Fecha Estado"))
            //                        {
            //                            if (!DSDatos.Tables[nTabla].Rows[iFila][iColumna].ToString().Equals(""))
            //                                cell.SetCellValue(DateTime.Parse(DSDatos.Tables[nTabla].Rows[iFila][iColumna].ToString()).ToShortDateString());
            //                            else
            //                                cell.SetCellValue("");
            //                        }

            //                        else
            //                            cell.SetCellValue(DSDatos.Tables[nTabla].Rows[iFila][iColumna].ToString());

            //                        sheet.AutoSizeColumn(nColumna);
            //                        iColumna++;
            //                    }
            //                    iFila++;
            //                }
            //            }

            //            file = new MemoryStream();
            //            WORKBOOK.Write(file);
            //            HttpContext.Current.Response.BinaryWrite(file.GetBuffer());
            //        }
            //        else
            //        {
            //            throw new Exception();
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        throw new Exception(ex.Message);
            //    }
            //    finally
            //    {
            //        if (WORKBOOK != null)
            //            WORKBOOK.Dispose();
            //        CELLSTYLE = null;
            //        if (sheet != null)
            //            sheet.Dispose();
            //        if (file != null)
            //            file.Close();
            //        if (font != null)
            //            font = null;
            //    }
            //}


            //public void ExportarExcel1(DataSet DSDatos, string filename, string[] hojas)
            //{
            //    HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            //    HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", filename));
            //    HttpContext.Current.Response.Clear();

            //    HSSFWorkbook WORKBOOK = null;
            //    CellStyle CELLSTYLE = null;
            //    Sheet sheet = null;
            //    MemoryStream file = null;
            //    Font font = null;
            //    int numColumna = 0;
            //    try
            //    {
            //        if (hojas.Length == DSDatos.Tables.Count)
            //        {
            //            WORKBOOK = new HSSFWorkbook();
            //            CELLSTYLE = WORKBOOK.CreateCellStyle();
            //            CELLSTYLE.FillPattern = FillPatternType.SOLID_FOREGROUND;
            //            font = WORKBOOK.CreateFont();
            //            font.Boldweight = font.Boldweight;
            //            CELLSTYLE.SetFont(font);
            //            CELLSTYLE.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.GREY_25_PERCENT.index;

            //            //Rellena cada DataTable de DataSet en una hoja de excel(Sheet)
            //            for (int nTabla = 0; nTabla < DSDatos.Tables.Count; nTabla++)
            //            {
            //                sheet = WORKBOOK.CreateSheet(hojas[nTabla]);
            //                Row row = sheet.CreateRow(0);
            //                Cell cell;
            //                int iColumna = 0;
            //                //Primero genera las columnas y les da un estilo(Font Negrita con fondo gris)
            //                numColumna = DSDatos.Tables[nTabla].Columns.Count;
            //                for (int nColumna = 0; nColumna < numColumna; nColumna++)
            //                {
            //                    cell = row.CreateCell(nColumna);
            //                    cell.SetCellValue(DSDatos.Tables[nTabla].Columns[iColumna].ColumnName);
            //                    sheet.AutoSizeColumn(nColumna);
            //                    cell.CellStyle = CELLSTYLE;
            //                    iColumna++;
            //                }

            //                //Genero la carga de datos del DataTable en las celdas de Excel
            //                int iFila = 0;
            //                for (int fila = 1; fila <= DSDatos.Tables[nTabla].Rows.Count; fila++)
            //                {
            //                    iColumna = 0;
            //                    row = sheet.CreateRow(fila);
            //                    for (int nColumna = 0; nColumna < numColumna; nColumna++)
            //                    {
            //                        cell = row.CreateCell(nColumna);
            //                        cell.SetCellValue(DSDatos.Tables[nTabla].Rows[iFila][iColumna].ToString());
            //                        sheet.AutoSizeColumn(nColumna);
            //                        iColumna++;
            //                    }
            //                    iFila++;
            //                }
            //            }

            //            file = new MemoryStream();
            //            WORKBOOK.Write(file);
            //            HttpContext.Current.Response.BinaryWrite(file.GetBuffer());
            //        }
            //        else
            //        {
            //            throw new Exception();
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        throw new Exception(ex.Message);
            //    }
            //    finally
            //    {
            //        if (WORKBOOK != null)
            //            WORKBOOK.Dispose();
            //        CELLSTYLE = null;
            //        if (sheet != null)
            //            sheet.Dispose();
            //        if (file != null)
            //            file.Close();
            //        if (font != null)
            //            font = null;
            //    }
            //}


            #endregion
        }

