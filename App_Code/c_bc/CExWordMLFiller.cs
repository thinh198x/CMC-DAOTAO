using System;
using System.Xml;
using System.Collections;
using System.Data;
using System.IO;
using System.Globalization;
using Cthuvien;

public class CExWordMLFiller
{
    private DataSet dsData;
    private string templateContent;
    private XmlDocument xmlTemplateDoc;
    private XmlDocument xmlDataset;
    private XmlNamespaceManager nsmgr = new XmlNamespaceManager(new NameTable());
    private ArrayList errorList = new ArrayList();
    private bool bOperationFailed = false;
    private static string wordmlPrefix = "http://schemas.microsoft.com/office/word/2003/wordml";
    private static string amlPrefix = "http://schemas.microsoft.com/aml/2001/core";
    //private static string xslPrefix = "http://www.w3.org/1999/XSL/Transform";
    private static string xsPrefix = "http://www.w3.org/2001/XMLSchema";
    private const string repeatAttribute = "WMLRepeat";

    private string languageName;
    private CultureInfo ci;
    private string dateTimeFormat;
    private NumberFormatInfo numberFormat;
    private string numberDecimalSeparator;
    private string numberGroupSeparator;
    private int numberDecimalDigits;

    public CExWordMLFiller(DataSet dsData, string templateContent)
    {
        this.dsData = dsData;
        xmlDataset = new XmlDocument();
        MemoryStream stream = new MemoryStream();
        dsData.WriteXml(stream, XmlWriteMode.WriteSchema);
        stream.Seek(0, SeekOrigin.Begin);
        XmlReader reader = new XmlTextReader(stream);
        xmlDataset.Load(reader);
        this.templateContent = templateContent;
        LoadTemplate();
    }

    private void LoadTemplate()
    {
        errorList = new ArrayList();
        bOperationFailed = false;
        try
        {
            xmlTemplateDoc = new XmlDocument();
            xmlTemplateDoc.LoadXml(this.templateContent);
            nsmgr.AddNamespace("w", wordmlPrefix);
            nsmgr.AddNamespace("aml", amlPrefix);

            XmlNode varNode = xmlTemplateDoc.SelectSingleNode("//w:docVar[@w:name='LanguageName']/@w:val", nsmgr);
            if (varNode != null)
            {
                languageName = varNode.Value;
                try
                {
                    ci = new CultureInfo(languageName, false);
                    numberFormat = ci.NumberFormat;
                }
                catch
                {
                    languageName = null;
                    numberFormat = null;
                }
            }
            else
            {
                languageName = null;
            }
            varNode = xmlTemplateDoc.SelectSingleNode("//w:docVar[@w:name='DateTimeFormat']/@w:val", nsmgr);
            if (varNode != null)
            {
                dateTimeFormat = varNode.Value;
            }
            else
            {
                dateTimeFormat = "dd/MM/yyyy";
            }
            varNode = xmlTemplateDoc.SelectSingleNode("//w:docVar[@w:name='NumberDecimalSeparator']/@w:val", nsmgr);
            if (varNode != null)
            {
                numberDecimalSeparator = varNode.Value;
                if (numberFormat == null) numberFormat = new NumberFormatInfo();
                numberFormat.NumberDecimalSeparator = numberDecimalSeparator.Trim() == string.Empty ? "." : numberDecimalSeparator;
            }
            else
            {
                numberDecimalSeparator = ".";
            }
            varNode = xmlTemplateDoc.SelectSingleNode("//w:docVar[@w:name='NumberGroupSeparator']/@w:val", nsmgr);
            if (varNode != null)
            {
                numberGroupSeparator = varNode.Value;
                if (numberFormat == null) numberFormat = new NumberFormatInfo();
                numberFormat.NumberGroupSeparator = numberGroupSeparator.Trim() == string.Empty ? "," : numberGroupSeparator;
            }
            else
            {
                numberGroupSeparator = ",";
            }
            varNode = xmlTemplateDoc.SelectSingleNode("//w:docVar[@w:name='NumberDecimalDigits']/@w:val", nsmgr);
            if (varNode != null)
            {
                try
                {
                    numberDecimalDigits = int.Parse(varNode.Value);
                }
                catch
                {
                    numberDecimalDigits = -1;
                }
                if (numberFormat == null) numberFormat = new NumberFormatInfo();
                numberFormat.NumberDecimalDigits = numberDecimalDigits == -1 ? 2 : numberDecimalDigits;
            }
            else
            {
                numberDecimalDigits = 0;
            }
        }
        catch (Exception ex)
        {
            while (ex != null)
            {
                errorList.Add(ex.Message);
                ex = ex.InnerException;
            }
            bOperationFailed = true;
        }
    }

    #region Public properties

    public bool OperationFailed
    {
        get
        {
            return bOperationFailed;
        }
    }

    public XmlDocument WordMLDocument
    {
        get
        {
            return xmlTemplateDoc;
        }
    }

    public ArrayList ErrorList
    {
        get
        {
            return errorList;
        }
    }

    #endregion

    private void RemoveMailMergeNode()
    {
        errorList = new ArrayList();
        bOperationFailed = false;
        XmlNode mailMergeNode = xmlTemplateDoc.SelectSingleNode("//w:mailMerge", nsmgr);
        if (mailMergeNode == null)
        {
            errorList.Add("Invalid mail merge node!");
            bOperationFailed = true;
            return;
        }
        XmlNode parentNode = mailMergeNode.ParentNode;
        if (parentNode == null)
        {
            errorList.Add("Invalid mail merge parent node!");
            bOperationFailed = true;
            return;
        }
        parentNode.RemoveChild(mailMergeNode);
    }

    private void RemoveUnfilledFields()
    {
        errorList = new ArrayList();
        bOperationFailed = false;
        nsmgr.AddNamespace("xs", xsPrefix);
        XmlNodeList oColl = xmlDataset.SelectNodes("//xs:element", nsmgr);
        if (oColl == null || oColl.Count == 0)
            return;
        string fieldName;
        foreach (XmlNode node in oColl)
        {
            fieldName = ((XmlElement)node).GetAttribute("name");
            ReplaceFieldData(xmlTemplateDoc.DocumentElement, fieldName, string.Empty, Type.Missing.GetType());
        }
    }

    private void ReplaceFieldData(XmlNode baseNode, string fieldName, string data, Type colType)
    {
        errorList = new ArrayList();
        bOperationFailed = false;
        XmlNode dataNode, oDelNode;
        //select the collection of paragraph elements containing merge field definition
        XmlNodeList oColl, oDelColl;
        oColl = baseNode.SelectNodes("//w:fldSimple[@w:instr=' MERGEFIELD  " + fieldName + " ']", nsmgr);
        if (oColl == null || oColl.Count == 0)
            oColl = baseNode.SelectNodes("//w:p[w:r/w:instrText=' MERGEFIELD  " + fieldName + " ']", nsmgr);


        foreach (XmlNode fieldNode in oColl)
        {
            //select run element containing the underlying data
            dataNode = fieldNode.SelectSingleNode("//w:t[.='«" + fieldName + "»']", nsmgr);
            if (dataNode == null)
            {
                errorList.Add("The field data is selected from the fields definition data source or merge document is corrupted!");
                bOperationFailed = true;
                return;
            }
            if (colType == typeof(DateTime))
            {
                if (dateTimeFormat != null)
                {
                    DateTime dt = DateTime.Parse(data);
                    dataNode.InnerText = dt.ToString(dateTimeFormat);
                }
                else
                {
                    dataNode.InnerText = data;
                }
            }
            else if (colType == typeof(int))
            {
                if (numberFormat != null)
                {
                    int i = int.Parse(data);
                    dataNode.InnerText = i.ToString(numberFormat);
                }
                else
                {
                    dataNode.InnerText = data;
                }
            }
            else if (colType == typeof(decimal)
                || colType == typeof(float)
                || colType == typeof(double)
                )
            {
                try
                {
                    dataNode.InnerText = (chuyen.CH_CSO(data, 0) == "0") ? "" : chuyen.CH_CSO(data, 0);
                }
                catch { dataNode.InnerText = data; }
            }
            else
            {
                dataNode.InnerText = data;
            }
            oDelColl = fieldNode.SelectNodes("w:r[w:fldChar]", nsmgr);
            if (oDelColl != null && oDelColl.Count > 0)
            {
                int i = oDelColl.Count - 1;
                while (i >= 0)
                {
                    oDelColl[i].ParentNode.RemoveChild(oDelColl[i]);
                    i--;
                }
            }
            oDelNode = fieldNode.SelectSingleNode("w:r[w:instrText]", nsmgr);
            if (oDelNode != null)
            {
                oDelNode.ParentNode.RemoveChild(oDelNode);
            }
        }
    }

    public void Transform()
    {
        foreach (DataTable dt in dsData.Tables)
        {
            TransformDataTable(dt);
        }
        RemoveMailMergeNode();
        RemoveUnfilledFields();
    }

    private void TransformDataTable(DataTable dt)
    {
        //First check tables in templates
        TransformWordMLTableRepeat(dt);
        //Next check other word ML elements
        TransformWordMLElementRepeat(dt);
        //Next check all other objects for non-repeating elements
        TransformNoRepeat(dt);
    }

    private void TransformWordMLTableRepeat(DataTable dt)
    {
        string tableName = dt.TableName;
        XmlNodeList oColl = xmlTemplateDoc.SelectNodes("//w:tbl[contains(descendant::aml:annotation/@w:name, '" + tableName + repeatAttribute
            + "') and (contains(descendant::w:instrText, ' MERGEFIELD  \"" + tableName + "') or contains(descendant::w:instrText, ' MERGEFIELD  " + tableName + "'))]"
            , nsmgr);
        XmlNode templateRowNode;
        if (oColl != null && oColl.Count > 0)
        {
            foreach (XmlNode tableNode in oColl)
            {
                templateRowNode = tableNode.SelectSingleNode("w:tr[contains(descendant::w:instrText, ' MERGEFIELD  \"" + tableName + "') or contains(descendant::w:instrText, ' MERGEFIELD  " + tableName + "')]", nsmgr);
                if (templateRowNode != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        TransformDataRow(dr, tableNode, templateRowNode);
                    }
                    tableNode.RemoveChild(templateRowNode);
                }
            }
        }
    }

    private void TransformWordMLElementRepeat(DataTable dt)
    {
        string tableName = dt.TableName;
        XmlNodeList oColl = xmlTemplateDoc.SelectNodes("//w:p[contains(descendant::aml:annotation/@w:name, '" + tableName + repeatAttribute
            + "') and (contains(descendant::w:instrText, ' MERGEFIELD \"" + tableName + "') or contains(descendant::w:instrText, ' MERGEFIELD " + tableName + "'))]"
            , nsmgr);
        if (oColl != null && oColl.Count > 0)
        {
            foreach (XmlNode node in oColl)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TransformDataRow(dr, node);
                }
            }
        }
    }

    private void TransformNoRepeat(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            DataRow firstRow = dt.Rows[0];
            string templateFieldName;
            for (int i = 0; i < firstRow.ItemArray.Length; i++)
            {
                templateFieldName = dt.TableName + dt.Columns[i].ColumnName;
                ReplaceFieldData(xmlTemplateDoc.DocumentElement, templateFieldName, firstRow[i].ToString(), dt.Columns[i].DataType);
            }
        }
    }

    private void TransformDataRow(DataRow dr, XmlNode tableNode, XmlNode templateRowNode)
    {
        DataTable dt = dr.Table;
        string tableName = dt.TableName;
        string templateFieldName;
        XmlNode cloneNode;
        cloneNode = templateRowNode.CloneNode(true);
        for (int i = 0; i < dr.ItemArray.Length; i++)
        {
            templateFieldName = dt.TableName + dt.Columns[i].ColumnName;
            ReplaceFieldData(cloneNode, templateFieldName, dr[i].ToString(), dt.Columns[i].DataType);
        }
        tableNode.InsertBefore(cloneNode, templateRowNode);
    }

    private void TransformDataRow(DataRow dr, XmlNode baseNode)
    {
        DataTable dt = dr.Table;
        string tableName = dt.TableName;
        string templateFieldName;
        XmlNode cloneNode, parentNode = baseNode.ParentNode;
        if (parentNode != null)
        {
            cloneNode = baseNode.CloneNode(true);
            for (int i = 0; i < dr.ItemArray.Length; i++)
            {
                templateFieldName = dt.TableName + dt.Columns[i].ColumnName;
                ReplaceFieldData(cloneNode, templateFieldName, dr[i].ToString(), dt.Columns[i].DataType);
            }
            parentNode.InsertBefore(cloneNode, baseNode);
            parentNode.RemoveChild(baseNode);
        }
    }

    public static string GetDataStructure(DataSet ds)
    {
        string sHeaderRow = string.Empty, sDummyRow = string.Empty;
        int i;
        foreach (DataTable dt in ds.Tables)
        {
            for (i = 0; i < dt.Columns.Count; i++)
            {
                if (sHeaderRow == string.Empty)
                {
                    sHeaderRow += dt.TableName + dt.Columns[i].ColumnName;
                    sDummyRow += " ";
                }
                else
                {
                    sHeaderRow += "\t" + dt.TableName + dt.Columns[i].ColumnName;
                    sDummyRow = "\t" + " ";
                }
            }
        }
        return sHeaderRow + Environment.NewLine + sDummyRow;
    }

    public void Transform_row()
    {
        foreach (DataTable dt in dsData.Tables)
        {
            TransformDataTable_row(dt);
        }
        RemoveMailMergeNode();
        RemoveUnfilledFields();
    }
    private void TransformDataTable_row(DataTable dt)
    {
        //First check tables in templates
        TransformWordMLTableRepeat(dt);
        //Next check other word ML elements
        TransformWordMLElementRepeat(dt);
        //Next check all other objects for non-repeating elements
        TransformNoRepeat_row(dt);
    }
    private void TransformNoRepeat_row(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            string templateFieldName;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (bang.Fi_TIM_COL(dt, "ma") >= 0)
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        templateFieldName = dt.TableName + dt.Columns[i].ColumnName + dt.Rows[j]["ma"].ToString().Trim();
                        ReplaceFieldData(xmlTemplateDoc.DocumentElement, templateFieldName, dt.Rows[j][i].ToString(), dt.Columns[i].DataType);
                    }
                }
            }
        }
    }
}