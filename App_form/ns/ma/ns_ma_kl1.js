     function ns_ma_kl_P_KTRA(b_maTen) {
         try {
             var b_maId = "";
             b_maTen = b_maTen.toUpperCase();
             switch (b_maTen) {
                 case "MA": b_maId = '<%=MA.ClientID%>'; break;
             }
             var b_ma = $get(b_maId);
             if (b_ma == null || C_NVL(b_ma.value) == "") return;
             skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_ma_kl_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
             ns_ma_kl_P_LKE();
         }
         catch (err) { form_P_LOI(err); }
     }
function ns_ma_kl_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    $get('<%=gchu.ClientID%>').innerHTML = b_kq;
}
    function ns_ma_kl_GR_lke_ActiveRowChange(gridId, rowId) {
        if (ns_ma_kl_choAct != 0) { clearTimeout(ns_ma_kl_choAct); ns_ma_kl_choAct = 0; }
        ns_ma_kl_choAct = setTimeout("ns_ma_kl_GR_lke_P_CHO()", 300);
        return true;
    }
var ns_ma_kl_choAct = 0;
function ns_ma_kl_GR_lke_P_CHO() {
    var b_ma = Grid_Fobj_LayGtri_Act('<%=GR_lke.ClientID%>', "ma");
    if (b_ma == null || b_ma == "") form_P_MOI("", "GXL"); else ns_ma_kl_P_CHUYEN_HANG(b_ma);
}
function ns_ma_kl_P_MOI() {
    form_P_MOI('<%=UPa_ct.ClientID%>', "GXL");
    $get('<%=MA.ClientID%>').focus();
    return false;
}
function ns_ma_kl_P_NH() {
    try {
        var b_vungId = '<%=UPa_ct.ClientID%>';
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
            sns_ma_ch.Fs_NS_MA_KL_NH(a_dt_ct, ns_ma_kl_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_ma_kl_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var b_gridId = '<%=GR_lke.ClientID%>',
        b_ma = $get('<%=MA.ClientID%>').value,
        b_ten = $get('<%=TEN.ClientID%>').value;
    var b_hang = Grid_Fi_TimHang(b_gridId, "ma", b_ma), b_soDong = Grid_Fi_soDong(b_gridId);
    if (b_hang < 0) {
        b_hang = Grid_Fi_TimHangD(b_gridId, "ma", b_ma, ">");
        if (b_hang >= 0) Grid_ChenTai(b_gridId, b_hang);
        else {
            b_hang = Grid_Fi_HangTrang(b_gridId);
            if (b_hang < 0) { b_hang = b_soDong; Grid_ThemCuoi(b_gridId); }
        }
    }
    GridX_datA(b_gridId, b_hang);
    Grid_P_DatGtriN(b_gridId, b_hang, ["ma", "ten"], [b_ma, b_ten]);
    $get('<%=MA.ClientID%>').focus();
    return false;
}
function ns_ma_kl_P_XOA() {
    try {
        var b_ma = C_NVL(Grid_Fobj_LayGtri_Act('<%=GR_lke.ClientID%>', "ma"));
        if (b_ma == "") khma_makvuc_P_MOI();
        else sns_ma_ch.Fs_NS_MA_KL_XOA(b_ma, ns_ma_kl_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return true;
    }
    catch (err) { throw (err); }
}
function ns_ma_kl_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var b_gridId = '<%=GR_lke.ClientID%>';
    Grid_cutRowAct(b_gridId);
    var b_ma = C_NVL(Grid_Fobj_LayGtri_Act(b_gridId, "ma"));
    if (b_ma == "") ns_ma_kl_P_MOI(); else ns_ma_kl_P_CHUYEN_HANG(b_ma);
}
function ns_ma_kl_P_CHUYEN_HANG(b_ma) {
    if (b_ma == null || b_ma == "") form_P_MOI("", "XGL");
    else {
        var b_gridId = '<%=GR_lke.ClientID%>';
        var b_hang = Grid_Fi_TimHang(b_gridId, "ma", b_ma);
        if (b_hang < 0) form_P_MOI("", "X");
        else { GridX_datA(b_gridId, b_hang); form_P_Grid_TEXT('<%=UPa_ct.ClientID%>', b_gridId); }
    }
}
function ns_ma_kl_P_LKE() {
    try {
        var a_cot = Grid_Fas_TenCot('<%=GR_lke.ClientID%>'),
        b_ma = $get('<%=MA.ClientID%>').value;
        var b_ham = "PNS_MA_KL_LKE";
        sns_ma_ch.Fs_NS_MA_KL_LKE(b_ma, a_cot, b_ham, ns_ma_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_kl_P_LKE_KQ(b_kq) {
    var b_gridId = '<%=GR_lke.ClientID%>';
    if (b_kq == "") Grid_DatTrangCa(b_gridId);
    else Grid_P_DatBangCH(b_gridId, b_kq);
}