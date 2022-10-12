using System;
using Cthuvien;

public partial class khud_slide : System.Web.UI.UserControl
{
    public int rong
    {
        get { return chuyen.OBJ_I(ViewState["rong"]); }
        set { ViewState["rong"] = value; }
    }
    public string ham
    {
        get { return chuyen.OBJ_S(ViewState["ham"]); }
        set { ViewState["ham"] = value; }
    }
    public string gridId
    {
        get { return chuyen.OBJ_S(ViewState["gridId"]); }
        set { ViewState["gridId"] = value; }
    }
    public string loai
    {
        get { return kytu.C_NVL(chuyen.OBJ_S(ViewState["loai"]),"X"); }
        set { ViewState["loai"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string b_slideId = this.ClientID;
            GridX b_gr = (GridX)form.Fc_CTR(this.Page, this.gridId);
            if (rong != 0) slide.Length = rong;
            else
            {
                int b_j, b_bn, b_rong;
                if (se.Fs_DUYET() == "IE") { b_rong = (int)khac.ROUNDN((b_gr.Columns.Count - 1) / 2, 0) - 141; b_bn = 2; }
                else { b_rong = -107; b_bn = 3; }
                for (int i = 0; i < b_gr.Columns.Count; i++)
                {
                    b_j = (int)b_gr.Columns[i].HeaderStyle.Width.Value;
                    if (b_j != 0) b_rong += b_j + b_bn;
                }
                slide.Length = b_rong;
            }
            an.Attributes.Add("gridId", b_gr.ClientID);
            an.Attributes.Add("ten_goc", this.ID + "_an");
            an.Attributes.Add("loai", this.loai);
            an.Attributes.Add("kieu", "N");
            an.Attributes.Add("onchange", this.ham);
            int b_trangKT = b_gr.hangKt;
            if (b_gr.loai == "I")
            {
                se.se_nsd b_se = new se.se_nsd();
                int b_list_kt = (int)chuyen.CSO_SO(b_se.list_kt);
                if (b_list_kt > 1) b_trangKT = b_list_kt;
            }
            an.Attributes.Add("TrangKt", b_trangKT.ToString());
            an.Attributes.Add("TrangCu", "1");
            trai.Attributes.Add("onclick", "return slide_P_CHUYEN('" + b_slideId + "','T');");
            phai.Attributes.Add("onclick", "return slide_P_CHUYEN('" + b_slideId + "','P');");
            b_gr.Attributes.Add("slideId", b_slideId);
        }
    }
}
