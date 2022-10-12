var ns_tt_cbql_dgia_hdld_lkeCho, b_grlkeId, b_grtdlkeId, b_slidetdId, b_tt, b_tm, b_han, b_lkectId, b_lkecdanhId;
function ns_tt_cbql_dgia_hdld_P_KD(b_tm) {
    b_tmf = b_tm, b_grlkeId = form_Fs_VUNG_ID('GR_lke');
    b_vungId = form_Fs_VUNG_ID('UPa_ct');
    b_slideId = b_grlkeId + '_slide'; b_slidetdId = b_grtdlkeId + '_slide';
    ns_tt_cbql_dgia_hdld_lkeCho = setInterval('ns_tt_cbql_dgia_hdld_P_LKE_CHO()', 200);

}

function ns_tt_cbql_dgia_hdld_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_tt_cbql_dgia_hdld_lkeCho); ns_tt_cbql_dgia_hdld_P_LKE(); }
}

function ns_tt_cbql_dgia_hdld_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        b_tt = "1";
        sns_tt.Fs_NS_TT_CBQL_DGIA_HDLD_LKE(form_Fs_nsd(),b_tt, a_tso, a_cot, ns_tt_cbql_dgia_hdld_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
    return false;
}
function ns_tt_cbql_dgia_hdld_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_tt_cbql_dgia_hdld_EXCEL() {
    var b_han_ctr = form_Fctr_TEN_DTUONG(b_vungId, "NV_SN");
    if (b_han_ctr.value == "" || b_han_ctr.value == null) { form_P_LOI("loi:Chưa chọn điều kiện :loi"); return; }
    else {
        __doPostBack('ctl00$ContentPlaceHolder1$Nhap2', '');
    }
}
function P_EXCEL_KQ(b_kq) {
    //?md=TT
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_MO(b_tmf + '/App_form/bc/xexcel.aspx?md=TT', null, null, "C");
}
function form_caidat() {
    var b_tf = form_Fs_TM() + "/App_form/ns/ma/ns_tbao_menu_tlap.aspx";
    form_P_MO(b_tf, null, null, "C");
}

function ns_tt_cbql_dgia_hdld_CB() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI('loi:Chọn cán bộ:loi'); return false; }
    else {
        var b_so_the = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the");
        var b_tenf = form_Fs_TM('f') + '/ns/tt/ns_cb.aspx';
        form_P_MO(b_tenf, window.name, ["THONGKE", [b_so_the]]);
        return false;
    }
}

function ns_tt_cbql_dgia_hdld_P_CB() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) {
        form_P_LOI('loi:Chưa chọn cán bộ:loi');
        return false;
    }
    try {
        var b_so_the = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the");
        var b_tenf = form_Fs_TM('f') + '/ns/tt/cbql/ns_hd_dg_tt_cbql.aspx';
        form_P_MO(b_tenf, null, ["THONGKE", [b_so_the]], "");
        form_P_LOI();
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
