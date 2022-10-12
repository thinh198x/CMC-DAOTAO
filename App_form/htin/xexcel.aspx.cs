using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_xexcel : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable b_dt = (DataTable)Session["XEXCEL"];
            P_TABLE_EXCEL(b_dt, "TOTAL");
        }
    }
    public void P_TABLE_EXCEL(DataTable table, string b_ten)
    {
        //////////////////////////////////////////////
        string attachment = "attachment; filename=" + b_ten + ".xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/vnd.ms-excel";
        string tab = "";
        foreach (DataColumn dc in table.Columns)
        {
            Response.Write(tab + dc.ColumnName);
            tab = "\t";
        }
        Response.Write("\n");
        int i;
        foreach (DataRow dr in table.Rows)
        {
            tab = "";
            for (i = 0; i < table.Columns.Count; i++)
            {
                Response.Write(tab + dr[i].ToString());
                tab = "\t";
            }
            Response.Write("\n");
        }
        Response.End();
    }
}
