var ns_ctt_pdkhdt_lkeCho, b_vungtkId, b_grlkeId, b_slideId, b_namId, b_thangId, b_nsd;

function ns_ctt_pdkhdt_P_KD() {
    b_vungtkId = form_Fs_VUNG_ID('UPa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_nam_Id = form_Fs_TEN_ID(b_vungtkId, 'NAM_LST'),
    b_thang_Id = form_Fs_TEN_ID(b_vungtkId, 'thang_lst'),
    b_slideId = b_grlkeId + '_slide';
    b_nsd = form_Fs_nsd();
    //ns_ctt_pdkhdt_lkeCho = setInterval('ns_ctt_pdkhdt_P_LKE_CHO()', 200);
}

// use
function ns_ctt_pdkhdt_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_ctt_pdkhdt_lkeCho); ns_ctt_pdkhdt_P_LKE(); }
}
// use
function ns_ctt_pdkhdt_P_LKE() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_grlkeId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }

        var nam = form_Fs_TEN_GTRI(b_vungtkId, 'NAM_LST');
        if (nam == "") {
            form_P_LOI("Bạn chưa chọn năm"); return false;
        }        
        var trthai_pd = form_Fs_TEN_GTRI(b_vungtkId, 'TTPD_LST');
        if (trthai_pd == "") {
            form_P_LOI("Bạn chưa chọn trạng thái phê duyệt"); return false;
        }
        var thang = form_Fs_TEN_GTRI(b_vungtkId, 'thang_lst');
        if (thang == "") thang = 0;

        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.Fs_Fdt_NS_DT_KH_CT_PD_LKE(b_nsd, a_tso, a_cot, nam, thang, trthai_pd, ns_ctt_pdkhdt_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
    return false;
}
// use
function ns_ctt_pdkhdt_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
// use
function ns_ctt_pdkhdt_P_TK() {
    var b_so_id = '';
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang > 0) {
        b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    }
    if (b_so_id == '' || b_so_id == '0') {
        form_P_LOI('Bạn chưa chọn kế hoạch đào tạo nào!');
        return false;
    }
    form_P_MO('/App_form/ns/ctt/ngv/ns_ctt_pdkhdt_ct.aspx', window.name, ["THAMSO", [window.name, b_so_id]]);
    return false;
}
// use
function ns_ctt_pdkhdt_P_EXCEL() {

}
// use
function form_dong() {
    location.reload(false);
}