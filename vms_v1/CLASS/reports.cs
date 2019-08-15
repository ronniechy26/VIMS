using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Shared;
using vms_v1.DATASETS;
using vms_v1.REPORTS;
using MySql.Data.MySqlClient;
using System.Data;
using vms_v1.FORMS;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Excel;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace vms_v1.CLASS
{
        
    class reports
    {
        static MySqlDataAdapter adp = new MySqlDataAdapter();
        static frm_rptviewer rptviewer = new frm_rptviewer();
        static MySqlCommand cmd = new MySqlCommand();

            public static void ExportToExcel(DataTable tbl, string excelFilePath = null)
            {
                try
                {
                    if (tbl == null || tbl.Columns.Count == 0)
                        throw new Exception("ExportToExcel: Null or empty input table!\n");

                    var excelApp = new Excel.Application();
                    excelApp.Workbooks.Add();
                    Excel._Worksheet workSheet = excelApp.ActiveSheet;
                    for (var i = 0; i < tbl.Columns.Count; i++)
                    {
                        workSheet.Cells[1, i + 1] = tbl.Columns[i].ColumnName;
                    }

                    for (var i = 0; i < tbl.Rows.Count; i++)
                    {
                        for (var j = 0; j < tbl.Columns.Count; j++)
                        {
                            workSheet.Cells[i + 2, j + 1] = tbl.Rows[i][j];
                        }
                    }
                    if (!string.IsNullOrEmpty(excelFilePath))
                    {
                        try
                        {
                            workSheet.EnableOutlining = true;
                            workSheet.DisplayPageBreaks = true;
                            workSheet.PageSetup.BottomMargin = 10;
                            workSheet.PageSetup.FirstPageNumber = 1;
                            workSheet.PageSetup.HeaderMargin = 10;
                            workSheet.PageSetup.CenterHeader = "LPI";
                            workSheet.SaveAs(excelFilePath);
                            excelApp.Quit();
                            MessageBox.Show("Excel file saved!");
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                                                + ex.Message);
                        }
                    }
                    else
                    {
                        excelApp.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("ExportToExcel: \n" + ex.Message);
                }
            }

            public static void createPDF(DataTable dataTable, string destinationPath)
            {
                Document document = new Document(iTextSharp.text.PageSize.A4.Rotate(), 10, 10, 10, 10);
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(destinationPath, FileMode.Create));
                document.Open();
                BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);

                PdfPTable table = new PdfPTable(dataTable.Columns.Count);
                table.WidthPercentage = 100;

                //Set columns names in the pdf file
                for (int k = 0; k < dataTable.Columns.Count; k++)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(dataTable.Columns[k].ColumnName,font));

                    cell.HorizontalAlignment = PdfPCell.ALIGN_MIDDLE;
                    cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(51, 102, 102);

                    table.AddCell(cell);
                }

                //Add values of DataTable in pdf file
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(dataTable.Rows[i][j].ToString(),font));

                        //Align the cell in the center
                        cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;

                        table.AddCell(cell);
                        
                    }
                }
                document.Add(table);
                document.Close();
            }


        public static void setCommand(string cmdtxt) 
        {
            cmd = new MySqlCommand(cmdtxt);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = DBConnection.connection();
        }

        #region LPI

        public static void LPI_export(string type, string cmdtxt, int id)
        {
            rpt_LPI rpt = new rpt_LPI();
            MySqlDataReader reader = null;
            DataTable dt = new DataTable();
            try
            {
                rpt.Load();
                setCommand(cmdtxt);
                cmd.Parameters.AddWithValue("ID", id);
                cmd.Parameters["@ID"].MySqlDbType = MySqlDbType.Int32;
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                rpt.SetDataSource(dt);

                if(type == "pdf")
                {
                    SaveFileDialog save = new SaveFileDialog();
                    string back_up_file_name = String.Format("{0:MM-dd-yyyy}", DateTime.Now);
                    save.FileName = back_up_file_name;
                    save.Filter = "PDF(*.pdf)|*.pdf";
                    if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        DiskFileDestinationOptions dest = new DiskFileDestinationOptions();
                        dest.DiskFileName = save.FileName;
                        PdfFormatOptions formatOpt = new PdfFormatOptions();
                        formatOpt.FirstPageNumber = 0;
                        formatOpt.LastPageNumber = 0;
                        formatOpt.UsePageRange = false;
                        formatOpt.CreateBookmarksFromGroupTree = false;
                        ExportOptions ex = new ExportOptions();
                        ex.ExportDestinationType = ExportDestinationType.DiskFile;
                        ex.ExportDestinationOptions = dest;
                        ex.ExportFormatType = ExportFormatType.PortableDocFormat;
                        ex.ExportFormatOptions = formatOpt;
                        rpt.Export(ex);
                        MessageBox.Show("Reports Save!");
                    }
                }
                else if (type == "excel")
                {
                    SaveFileDialog save = new SaveFileDialog();
                    string back_up_file_name = String.Format("{0:MM-dd-yyyy}", DateTime.Now);
                    save.FileName = back_up_file_name;
                    save.Filter = "Excel(*.xlsx)|*.xlsx";
                    if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        ExportToExcel(dt, save.FileName);
                    }
                }
                else 
                {
                    SaveFileDialog save = new SaveFileDialog();
                    string back_up_file_name = String.Format("{0:MM-dd-yyyy}", DateTime.Now);
                    save.FileName = back_up_file_name;
                    save.Filter = "Word 2003(*.doc)|*.doc";
                    if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        DiskFileDestinationOptions dest = new DiskFileDestinationOptions();
                        dest.DiskFileName = save.FileName;
                        PdfRtfWordFormatOptions formatOpt =new PdfRtfWordFormatOptions();
                        formatOpt.FirstPageNumber = 0;
                        formatOpt.LastPageNumber = 0;
                        formatOpt.UsePageRange = false;
                        ExportOptions ex = new ExportOptions();
                        ex.ExportDestinationType = ExportDestinationType.DiskFile;
                        ex.ExportDestinationOptions = dest;
                        ex.ExportFormatType = ExportFormatType.WordForWindows;
                        ex.ExportFormatOptions = formatOpt;
                        rpt.Export(ex);
                        MessageBox.Show("Reports Save!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        public static void LPI_view(string cmdtxt,object obj)
        {
           // rpt_LPI rpt = (rpt_LPI )obj;
            rpt_LPI rpt = new rpt_LPI();
            MySqlDataReader reader = null;
            DataTable dt = new DataTable();
            try
            {
                rpt.Load();
                setCommand(cmdtxt);
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                rpt.SetDataSource(dt);
                rptviewer.crystalReportViewer1.ReportSource = rpt;
                rptviewer.crystalReportViewer1.Refresh();
                rptviewer.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        public static void LPI_view(string cmdtxt)
        {
            rpt_LPI rpt = new rpt_LPI();
            MySqlDataReader reader = null;
            DataTable dt = new DataTable();
            try
            {
                rpt.Load();
                setCommand(cmdtxt);
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                rpt.SetDataSource(dt);
                rptviewer.crystalReportViewer1.ReportSource = rpt;
                rptviewer.crystalReportViewer1.Refresh();
                rptviewer.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        public static void LPI_view(string cmdtxt, int id)
        {
            rpt_LPI rpt = new rpt_LPI();
            MySqlDataReader reader = null;
            DataTable dt = new DataTable();
            try
            {
                rpt.Load();
                setCommand(cmdtxt);
                cmd.Parameters.AddWithValue("ID", id);
                cmd.Parameters["@ID"].MySqlDbType = MySqlDbType.Int32;
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                rpt.SetDataSource(dt);
                rptviewer.crystalReportViewer1.ReportSource = rpt;
                rptviewer.crystalReportViewer1.Refresh();
                rptviewer.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }

        }


        #endregion


        #region volunteer statistics


        public static void vol_ivso(string cmdtxt)
        {
            rpt_vol_ivso rpt = new rpt_vol_ivso();
            MySqlDataReader reader = null;
            DataTable dt = new DataTable();
            try
            {
                rpt.Load();
                setCommand(cmdtxt);
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                rpt.SetDataSource(dt);
                rptviewer.crystalReportViewer1.ReportSource = rpt;
                rptviewer.crystalReportViewer1.Refresh();
                rptviewer.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        public static void vol_sex(string cmdtxt)
        {
            rpt_vol_sex rpt = new rpt_vol_sex();
            MySqlDataReader reader = null;
            DataTable dt = new DataTable();
            try
            {
                rpt.Load();
                setCommand(cmdtxt);
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                rpt.SetDataSource(dt);
                rptviewer.crystalReportViewer1.ReportSource = rpt;
                rptviewer.crystalReportViewer1.Refresh();
                rptviewer.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        public static void vol_age(string cmdtxt)
        {
            rpt_vol_age_range rpt = new rpt_vol_age_range();
            MySqlDataReader reader = null;
            DataTable dt = new DataTable();
            try
            {
                rpt.Load();
                setCommand(cmdtxt);
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                rpt.SetDataSource(dt);
                rptviewer.crystalReportViewer1.ReportSource = rpt;
                rptviewer.crystalReportViewer1.Refresh();
                rptviewer.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        public static void vol_sector(string cmdtxt)
        {
            rpt_vol_sector rpt = new rpt_vol_sector();
            MySqlDataReader reader = null;
            DataTable dt = new DataTable();
            try
            {
                rpt.Load();
                setCommand(cmdtxt);
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                rpt.SetDataSource(dt);
                rptviewer.crystalReportViewer1.ReportSource = rpt;
                rptviewer.crystalReportViewer1.Refresh();
                rptviewer.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        public static void vol_lpi_type(string cmdtxt)
        {
            rpt_vol_lpi_type rpt = new rpt_vol_lpi_type();
            MySqlDataReader reader = null;
            DataTable dt = new DataTable();
            try
            {
                rpt.Load();
                setCommand(cmdtxt);
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                rpt.SetDataSource(dt);
                rptviewer.crystalReportViewer1.ReportSource = rpt;
                rptviewer.crystalReportViewer1.Refresh();
                rptviewer.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }


        public static void vol_reg(string cmdtxt)
        {
            rpt_vol_reg rpt = new rpt_vol_reg();
            MySqlDataReader reader = null;
            DataTable dt = new DataTable();
            try
            {
                rpt.Load();
                setCommand(cmdtxt);
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                rpt.SetDataSource(dt);
                rptviewer.crystalReportViewer1.ReportSource = rpt;
                rptviewer.crystalReportViewer1.Refresh();
                rptviewer.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        #endregion




    }//
}
