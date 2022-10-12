using Aspose.Cells;
using Aspose.Words;
using Aspose.Words.MailMerging;
using Aspose.Words.Reporting;
using Cthuvien;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
/// <summary>
/// Summary description for ImportKiemTra
/// </summary>
public class Word_dungchung
{
    public static string ExportWord(string ReportFile, string saveFile, DataSet ds, string TableNameLstData, System.Web.HttpResponse response)
    {
        string strResult = "";
        try
        {
            string strRoot = HttpContext.Current.Server.MapPath("~");
            //Aspose.Words.License l = new Aspose.Words.License();
            //string strLicense = strRoot + "\\Bin\\Aspose.Words.lic";
            //l.SetLicense(strLicense);
            string filePath = ReportFile;
            Aspose.Words.Document doc = new Aspose.Words.Document(filePath);
            foreach (DataTable dt in ds.Tables)
            {
                doc.MailMerge.Execute(dt);
            }
            doc.Save(response, saveFile, Aspose.Words.ContentDisposition.Attachment, Aspose.Words.Saving.SaveOptions.CreateSaveOptions(Aspose.Words.SaveFormat.Docx));
        }
        catch (Exception ex)
        {
            strResult = ex.Source;
        }
        return strResult;
    }
    public static void ExportMailMerge(string link, string filename, DataTable dtData, System.Web.HttpResponse response)
    {
        try
        {
            string strRoot = HttpContext.Current.Server.MapPath("~");
            //Aspose.Words.License l = new Aspose.Words.License();
            //string strLicense = strRoot + "\\Bin\\Aspose.Words.lic";
            //l.SetLicense(strLicense);

            Document doc = new Document(link);
            doc.MailMerge.Execute(dtData);
            doc.MailMerge.ExecuteWithRegions(dtData);
            doc.MailMerge.DeleteFields();
            doc.MailMerge.CleanupOptions = MailMergeCleanupOptions.RemoveUnusedRegions;
            doc.MailMerge.CleanupOptions = MailMergeCleanupOptions.RemoveEmptyParagraphs;

            doc.Save(response, filename + ".doc",
                     Aspose.Words.ContentDisposition.Attachment,
                     Aspose.Words.Saving.SaveOptions.CreateSaveOptions(Aspose.Words.SaveFormat.Doc));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public static void ExportMailMerge(string link, string filename, DataSet dsData, System.Web.HttpResponse response)
    {
        try
        {
            string strRoot = HttpContext.Current.Server.MapPath("~");
            //Aspose.Words.License l = new Aspose.Words.License();
            //string strLicense = strRoot + "\\Bin\\Aspose.Words.lic";
            //l.SetLicense(strLicense);
            Document doc = new Document(link);
            doc.MailMerge.Execute(dsData.Tables[0]);
            for (int i = 1; i <= dsData.Tables.Count - 1; i++)
            {
                doc.MailMerge.ExecuteWithRegions(dsData.Tables[i]);
            }
            doc.MailMerge.DeleteFields();
            doc.MailMerge.CleanupOptions = MailMergeCleanupOptions.RemoveUnusedRegions;
            doc.MailMerge.CleanupOptions = MailMergeCleanupOptions.RemoveEmptyParagraphs;

            doc.Save(response, filename + ".doc",
                     Aspose.Words.ContentDisposition.Attachment,
                     Aspose.Words.Saving.SaveOptions.CreateSaveOptions(Aspose.Words.SaveFormat.Doc));
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    public static void ExportMailMergeImages(string link, string filename, byte[] fileImage1, DataSet dsData, System.Web.HttpResponse response)
    {
        try
        {
            string strRoot = HttpContext.Current.Server.MapPath("~");
            //Aspose.Words.License l = new Aspose.Words.License();
            //string strLicense = strRoot + "\\Bin\\Aspose.Words.lic";
            //l.SetLicense(strLicense);
            Document doc = new Document(link);

            doc.MailMerge.Execute(dsData.Tables[0]);
            for (int i = 1; i <= dsData.Tables.Count - 1; i++)
            {
                doc.MailMerge.ExecuteWithRegions(dsData.Tables[i]);
            }
            doc.MailMerge.DeleteFields();
            doc.MailMerge.CleanupOptions = MailMergeCleanupOptions.RemoveUnusedRegions;
            doc.MailMerge.CleanupOptions = MailMergeCleanupOptions.RemoveEmptyParagraphs;

            if (fileImage1 != null)
            {
                DocumentBuilder builder = new DocumentBuilder(doc);
                MemoryStream imageStream = new MemoryStream(fileImage1);
                builder.InsertImage(imageStream, Aspose.Words.Drawing.RelativeHorizontalPosition.LeftMargin, 50, Aspose.Words.Drawing.RelativeVerticalPosition.Margin, 0, 90, 120, Aspose.Words.Drawing.WrapType.None);
            }
            doc.Save(response, filename + ".doc",
                     Aspose.Words.ContentDisposition.Attachment,
                     Aspose.Words.Saving.SaveOptions.CreateSaveOptions(Aspose.Words.SaveFormat.Doc));
        }
        catch (Exception ex)
        {

            throw;
        }
    }
}