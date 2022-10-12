using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
/// Summary description for GridViewTemplate
/// </summary>
public class GridViewTemplate : ITemplate
{
    private DataControlRowType templateType;
    private string columnName;
    private string columnNameBinding;
    private string controlType;
    private string cssClass;
    private string kyTuXoa;
    private string onchangeEvent;
    private string lkeValue; // for Cthuvien.kieu
    private string defaultText; // for Cthuvien.kieu
    private string coDau; // nhập số có dấu không

    public GridViewTemplate(DataControlRowType type, string colname, string colNameBinding, string ctlType, string cssClassName, string ktXoa, string onchange)
    {
        templateType = type;
        columnName = colname;
        columnNameBinding = colNameBinding;
        controlType = ctlType;
        cssClass = cssClassName;
        kyTuXoa = ktXoa;
        onchangeEvent = onchange;
    }
    public GridViewTemplate(DataControlRowType type, string colname, string colNameBinding, string ctlType, string cssClassName, string ktXoa, string onchange, string co_Dau)
    {
        templateType = type;
        columnName = colname;
        columnNameBinding = colNameBinding;
        controlType = ctlType;
        cssClass = cssClassName;
        kyTuXoa = ktXoa;
        coDau = co_Dau;
        onchangeEvent = onchange;
    }

    public GridViewTemplate(DataControlRowType type, string colname, string colNameBinding, string ctlType, string cssClassName, string ktXoa, string onchange, string lkeVal, string defaultTxt)
    {
        templateType = type;
        columnName = colname;
        columnNameBinding = colNameBinding;
        controlType = ctlType;
        cssClass = cssClassName;
        kyTuXoa = ktXoa;
        onchangeEvent = onchange;
        lkeValue = lkeVal; 
        defaultText = defaultTxt;
    }

    public void InstantiateIn(System.Web.UI.Control container)
    {
        switch (templateType)
        {
            case DataControlRowType.Header:
                Literal lc = new Literal();
                lc.Text = columnName;
                container.Controls.Add(lc);
                break;
            case DataControlRowType.DataRow:
                if (controlType == "Label")
                {
                    Label lb = new Label();
                    lb.ID = columnNameBinding;
                    lb.DataBinding += new EventHandler(this.ctl_OnDataBinding);
                    container.Controls.Add(lb);
                }
                else if (controlType == "TextBox")
                {
                    TextBox tb = new TextBox();
                    tb.ID = columnNameBinding;
                    tb.Width = Unit.Percentage(100);
                    tb.DataBinding += new EventHandler(this.ctl_OnDataBinding);
                    container.Controls.Add(tb);
                }
                else if (controlType == "CheckBox")
                {
                    CheckBox cb = new CheckBox();
                    cb.ID = columnNameBinding;
                    cb.DataBinding += new EventHandler(this.ctl_OnDataBinding);
                    container.Controls.Add(cb);
                }
                else if (controlType == "HyperLink")
                {
                    HyperLink hl = new HyperLink();
                    hl.ID = columnNameBinding;
                    hl.DataBinding += new EventHandler(this.ctl_OnDataBinding);
                    container.Controls.Add(hl);
                }
                else if (controlType == "Cthuvien.kieu")
                {
                    Cthuvien.kieu ckieu = new Cthuvien.kieu();
                    ckieu.ID = columnNameBinding;
                    ckieu.Text = this.defaultText;
                    ckieu.lke = this.lkeValue;                    
                    ckieu.Width = Unit.Pixel(30);
                    if (this.cssClass != "")
                        ckieu.CssClass = this.cssClass;
                    ckieu.Attributes.Add("onchange", this.onchangeEvent);
                    ckieu.DataBinding += new EventHandler(this.ctl_OnDataBinding);
                    container.Controls.Add(ckieu);
                }
                else if (controlType == "Cthuvien.ma")
                {
                    Cthuvien.ma cma = new Cthuvien.ma();
                    cma.ID = columnNameBinding;
                    cma.Width = Unit.Percentage(100);
                    cma.kt_xoa = kyTuXoa;
                    if (this.cssClass != "")
                        cma.CssClass = this.cssClass;
                    //cma.Attributes.Add("onchange", this.onchangeEvent);
                    cma.DataBinding += new EventHandler(this.ctl_OnDataBinding);
                    container.Controls.Add(cma);
                }
                else if (controlType == "Cthuvien.ngay")
                {
                    Cthuvien.ngay cngay = new Cthuvien.ngay();
                    cngay.ID = columnNameBinding;
                    cngay.Width = Unit.Percentage(100);
                    cngay.kt_xoa = kyTuXoa;
                    if (this.cssClass != "")
                        cngay.CssClass = this.cssClass;
                    //cma.Attributes.Add("onchange", this.onchangeEvent);
                    cngay.DataBinding += new EventHandler(this.ctl_OnDataBinding);
                    container.Controls.Add(cngay);
                }
                else if (controlType == "Cthuvien.so")
                {
                    Cthuvien.so cso = new Cthuvien.so();
                    cso.ID = columnNameBinding;
                    cso.Width = Unit.Percentage(100);
                    cso.kt_xoa = kyTuXoa;
                    if (this.cssClass != "")
                        cso.CssClass = this.cssClass;
                    //cma.Attributes.Add("onchange", this.onchangeEvent);
                    cso.DataBinding += new EventHandler(this.ctl_OnDataBinding);
                    container.Controls.Add(cso);
                }
                break;
            default:
                break;
        }
    }

    public void ctl_OnDataBinding(object sender, EventArgs e)
    {
        if (sender.GetType().Name == "Label")
        {
            Label lb = (Label)sender;
            GridViewRow container = (GridViewRow)lb.NamingContainer;
            lb.Text = ((DataRowView)container.DataItem)[columnNameBinding].ToString();
        }
        else if (sender.GetType().Name == "TextBox")
        {
            TextBox tb = (TextBox)sender;
            GridViewRow container = (GridViewRow)tb.NamingContainer;
            tb.Text = ((DataRowView)container.DataItem)[columnNameBinding].ToString();
        }
        else if (sender.GetType().Name == "CheckBox")
        {
            CheckBox cb = (CheckBox)sender;
            GridViewRow container = (GridViewRow)cb.NamingContainer;
            cb.Checked = Convert.ToBoolean(((DataRowView)container.DataItem)[columnNameBinding].ToString());
        }
        else if (sender.GetType().Name == "HyperLink")
        {
            HyperLink hl = (HyperLink)sender;
            GridViewRow container = (GridViewRow)hl.NamingContainer;
            hl.Text = ((DataRowView)container.DataItem)[columnNameBinding].ToString();
            hl.NavigateUrl = ((DataRowView)container.DataItem)[columnNameBinding].ToString();
        }
    }
}