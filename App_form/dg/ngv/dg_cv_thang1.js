var dg_cv_thang_lkeCho, b_vungId, b_grlkeId, b_tm, dg_cv_thang_ds_lkeCho, b_gr_ct_qlctId, b_gr_ct_qlcdid, b_gr_ct_qlncid, b_ngay_xacnhanId, b_yeucau_td, b_slideId, b_grctId, b_nam, b_ma, b_trangthai,
    b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C', dg_cv_thang_choAct = 0, b_datgrid, b_ma_nsd, b_so_idId, b_hs_dg, b_xl_dg;
function dg_cv_thang_P_KD(b_nsd) {
    b_ma_nsd = b_nsd;
    dg_cv_thang_lkeCho, dg_cv_thang_ds_lkeCho,
    b_vungId = form_Fs_VUNG_ID('UPa_ct'),
    b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_grctId = form_Fs_VUNG_ID('GR_ct'),
    b_ky_dg = form_Fs_TEN_ID('', 'KY_DG'),
    b_namtk = form_Fs_TEN_ID('', 'nam_tk'),
    b_trangthai_Idtk = form_Fs_TEN_ID('', 'trangthai_tk'),
    b_trangthai = form_Fs_TEN_ID(b_vungId, 'trangthai'),
    b_so_idId = form_Fs_VTEN_ID('', 'so_id');
    b_diem_tbId = form_Fs_TEN_ID(b_vungId, 'ketqua_tong');
    b_hs_dg = form_Fs_TEN_ID(b_vungId, 'heso');
    b_xl_dg = form_Fs_TEN_ID(b_vungId, 'xeploai');
    //b_nhom_cdanhId = form_Fs_TEN_ID(b_vungId, 'nhom_cdanh'),
    b_slideId = b_grlkeId + '_slide';
    dg_cv_thang_lkeCho = setInterval('dg_cv_thang_P_LKE_CHO()', 200);
}
//Kiểm tra
function dg_cv_thang_P_KTRA(b_maTen) {
    try {
        var b_maId = form_Fs_TEN_ID('', b_maTen);
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        var b_nam = b_ma.value;
        sdg.Fdt_NS_DG_MA_KDG_DG_NHL(window.name, b_nam, "DT_KY_DG", dg_cv_thang_P_KTRA_DR_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function dg_cv_thang_P_KTRA_DR_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        drop_P_LKE(b_ky_dg, b_kq);
    }
    return false;
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[0];
        b_doi = 0;
        if (b_dtuong.indexOf("MA_DX") >= 0) {
            $get(b_yeucau_td).value = b_kq;
            dg_cv_thang_P_LKE_DS();
        }
        else if (b_dtuong.indexOf("TEN_PHONGBAN") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grctId, b_hang, ["PHONGBAN"], [a_tso[0]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["TEN_PHONGBAN"], [a_tso[1]], 'K');
        }
        if (b_dtuong.indexOf("MENU") < 0) {
            ns_hdns_gan_cdanhdvi_P_LAY();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}
// Nhập
function dg_cv_thang_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_datTrang(b_grctId);
    GridX_thoiA(b_grlkeId);
    return false;
}

function dg_cv_thang_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    else {
        var a_dt = form_Faa_TEXT_ROW(b_vungId);
        var b_dt_ct = GridX_Fdt_cotGtri(b_grctId);
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        var b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "trangthai"));
        if (b_trangthai != "" && b_trangthai != "2" && b_trangthai != "CG") { form_P_LOI('loi:Phải chọn bản ghi chưa có trạng thái hoặc bị từ chối:loi'); return false; }
        else { a_dt[1][7] = 'CG'; }
        if (b_hang < 0) { b_so_id = 0; }
        else {
            b_so_id = C_NVL(GridX_Fas_layGtriA(b_grlkeId, "so_id"));
        }
        var b_nam = $get(b_namtk).value, b_trangthai_tk = lke_Fs_TRA($get(b_trangthai_Idtk));
        sdg.Fs_NS_DG_CV_THANG_NH(form_Fs_nsd(), b_so_id, b_nam, b_trangthai_tk, b_ma_nsd, b_TrangKt, a_dt, b_dt_ct, a_cot_lke, dg_cv_thang_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
}
function dg_cv_thang_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        form_P_LOI("loi:Nhập thành công!:loi");
    }
    return false;
}
// Xóa
function dg_cv_thang_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (so_id > 0) {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_DG_CV_THANG_XOA(form_Fs_nsd(), so_id, b_ma_nsd, a_tso, a_cot, dg_cv_thang_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function dg_cv_thang_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI("loi:Xóa thành công!:loi")
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        dg_cv_thang_P_MOI();
        dg_cv_thang_P_LKE();
        //dg_cv_thang_P_LKE_DS();
    }
}

function ns_td_thutuc_P_LKE_KQ_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang(b_grttId, b_kq);
}
// CHuyển hàng
function dg_cv_thang_GR_lke_RowChange() {
    if (dg_cv_thang_choAct != 0) clearTimeout(dg_cv_thang_choAct);
    dg_cv_thang_choAct = setTimeout("dg_cv_thang_P_CHUYEN_HANG()", 300);
    return false;
}

function dg_cv_thang_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { lke_P_DAT($get(b_trangthai), 'CG{Chưa gửi'); return; }
    var a_cot_ct = GridX_Fas_tenCot(b_grctId);
    var b_ma_dx = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    var b_nam = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "nam"));
    var b_kydg = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ky_dg"));
    if (b_ma_dx == "") {
        dg_cv_thang_P_MOI(); lke_P_DAT($get(b_trangthai), 'CG{Chưa gửi');
    }
    else {
        sdg.Fs_NS_DG_CV_THANG_CT(form_Fs_nsd(), b_ma_dx, b_nam, b_kydg, b_ma_nsd, a_cot_ct, dg_cv_thang_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function dg_cv_thang_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#')
    GridX_datBang(b_grctId, a_kq[1]);
    form_P_CH_TEXT(b_vungId, a_kq[0]);
}
// Gửi mail
function sendMail(b_tso) {
    var a_tso = Fas_ChMang(b_tso, ';');
    var b_toAddress = a_tso[0],
        b_subject = a_tso[1],
        b_body = a_tso[2];
    if (b_toAddress == "" || b_toAddress == null || b_toAddress == undefined) return false;
    else {
        sSmtpMail.SendMail(b_toAddress, b_subject, b_body, sendMail_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
}
function sendMail_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); return false;
}

function dg_cv_thang_P_XEM() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    form_P_MO("ns_td_hsuv_online.aspx", null, ["KQ", [b_so_id]]);
    return false;
}
// Liệt kê
function dg_cv_thang_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (dg_cv_thang_lkeCho != 0) clearTimeout(dg_cv_thang_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        dg_cv_thang_P_LKE('K');
        cbql_ctcv_ht_P_CB();
    }

}
function cbql_ctcv_ht_P_CB() {
    try {
        var b_ma_nv = b_ma_nsd;
        sdg.Fs_THONGTIN_CANBO111(b_ma_nv, cbql_ctcv_ht_P_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function cbql_ctcv_ht_P_CB_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
function dg_cv_thang_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_nam = $get(b_namtk).value, b_trangthai = lke_Fs_TRA($get(b_trangthai_Idtk));
        sdg.Fs_NS_DG_CV_THANG_LKE(form_Fs_nsd(), b_nam, b_trangthai, b_ma_nsd, a_tso, a_cot, dg_cv_thang_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function dg_cv_thang_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        // var a_cot = GridX_Fas_tenCot(b_grttId);
    }
}
//Gửi
function dg_cv_thang_P_GUI() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) { form_P_LOI("loi:Chưa chọn bản ghi cần gửi:loi"); return false; }
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "") { form_P_LOI("loi:Chưa chọn bản ghi cần gửi:loi"); return false; }
        var a_cot = GridX_Fas_tenCot(b_grlkeId);
        var b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "trangthai"));
        if (b_trangthai == "CG")
            sdg.Fs_DG_CV_THANG_GUI(form_Fs_nsd(), b_so_id, dg_cv_thang_P_GUI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        else
            form_P_LOI("loi:Đăng ký đã được gửi hoặc phê duyệt:loi");
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function dg_cv_thang_P_GUI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else form_P_LOI("loi:Gửi phê duyệt thành công:loi");
    dg_cv_thang_P_LKE('K');
    return false;
}

function dg_cv_thang_P_NHOM_CDANH(b_tenctr, b_kieu) {
    try {
        b_nhom_cdanhId = form_Fs_TEN_ID('', b_tenctr)
        var b_nhom_cdanh = lke_Fs_TRA($get(b_nhom_cdanhId));
        var b_ktra = "DT_CDANH";
        if (b_tenctr == "N_CHUCDANH_TK") b_ktra = "DT_CHUCDANH_TK";
        if (b_nhom_cdanh != '') {
            var a_tso = lke_Fa_TSO(b_kieu);
            sdg.Fs_CDANH(form_Fs_nsd(), b_nhom_cdanh, a_tso[3], window.name, b_ktra, form_LIST_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function dg_cv_thang_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function form_dong() {
    location.reload(false);
}
//-------------------Lấy 
function ns_hdns_gan_cdanhdvi_P_LAY() {
    try {
        var a_cot = GridX_Fas_tenCot(b_gr_ct_qlctId), b_ma = form_Fs_TEN_GTRI(b_vungId, 'PHONG');
        var b_so_id = 0, a_luoi;
        //slide_P_SOTRANG(b_slideId);
        var b_hang = GridX_Fi_timHangA(b_gr_ct_qlctId);
        if (b_hang > 0) b_datgrid = 'qlct';
        b_hang = GridX_Fi_timHangA(b_gr_ct_qlcdid);
        if (b_hang > 0) b_datgrid = 'qlcd';
        b_hang = GridX_Fi_timHangA(b_gr_ct_qlncid);
        if (b_hang > 0) b_datgrid = 'qlnc';
        a_luoi = GridX_Fdt_cotGtri(b_gr_ct_qlctId);
        sdg.Fs_LAY_TRACHON(form_Fs_nsd(), a_cot, a_luoi, ns_hdns_gan_cdanhdvi_P_LAY_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_gan_cdanhdvi_P_LAY_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    b_datgrid = b_datgrid.toUpperCase();
    switch (b_datgrid) {
        case "QLCT": GridX_datBang(b_gr_ct_qlctId, a_kq[1]); break;
        case "QLCD": GridX_datBang(b_gr_ct_qlcdid, a_kq[1]); break;
        case "QLNC": GridX_datBang(b_gr_ct_qlncid, a_kq[1]); break;
    }

    //slide_P_SOTRANG(b_slidectId);
}
function dg_cv_Update() {
    GridX_sott(b_grctId, 'stt');
    return false;
}
function myfunction1() {
    var x = 1;
}
function dg_cv_thang_P_KY_DG(b_dk) {
    try {
        if (b_dk == 'K') var b_kydg = lke_Fs_TRA($get(b_ky_dgId));
        else var b_kydg = "";
        var ktra = "DT_DOT_DG";
        //sdg.Fdt_NS_DG_MA_DDG_DG_NHL(window.name, b_kydg, ktra, ns_cb_dgia_kpi_nv_P_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        var b_nam_lke = lke_Fs_TRA($get(b_namId));
        var a_cot_ct = GridX_Fas_tenCot(b_grctId), a_cot_nl_ct = GridX_Fas_tenCot(b_grnlctId);
        sdg.Fs_DG_CV_THANG_CT_LKE(form_Fs_nsd(), b_nam_lke, b_kydg, a_cot_ct, a_cot_nl_ct, dg_cv_thang_P_KQ2, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(err); }
}
function dg_cv_thang_P_KQ2(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = b_kq.split('#');
        if (a_kq[0] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[0]);
    }
}

//son them
var b_kq = 0; var b_kq_nv_tong = 0; var b_kq_ql_tong = 0;
function xulydulieu(b_dk) {
    var b_hang = GridX_Fi_timHangA(b_grctId);
    var b_tyle_ht_nv = GridX_Fas_layGtri(b_grctId, b_hang, "tl_hthanh");
    var b_trongso = GridX_Fas_layGtri(b_grctId, b_hang, "trong_so");
    //var b_tyle_ht_ql = GridX_Fas_layGtri(b_grctId, b_hang, "tyle_ht_ql");
    if (b_trongso == "") return false;


    var b_tylenv = CSO_SO(b_tyle_ht_nv, 0);
    var b_tso = CSO_SO(b_trongso, 0);
    //var b_tyleql = CSO_SO(b_tyle_ht_ql, 0);

    if (b_tylenv > 100) {
        GridX_datGtriA(b_grctId, 'tl_hthanh', 0);
    }
    //if (b_dk == "ts") {
    //    var tyleXtrongso_nv = b_tylenv * b_tso;
    //    var tyleXtrongso_ql = b_tyleql * b_tso;
    //    GridX_datGtriA(b_grctId, 'tyle_ht_tso_nv', tyleXtrongso_nv);
    //    GridX_datGtriA(b_grctId, 'tyle_ht_tso_ql', tyleXtrongso_ql);
    //}
    if (b_dk == "nv") {
        var tyleXtrongso_nv = SO_CSO(Math.round(b_tylenv / 100 * b_tso, 2));
        GridX_datGtriA(b_grctId, 'tl_hthanh_ts', tyleXtrongso_nv);
    }
    //if (b_dk == "ql") {
    //    var tyleXtrongso_ql = b_tyleql * b_tso;
    //    GridX_datGtriA(b_grctId, 'tyle_ht_tso_ql', tyleXtrongso_ql);
    //}
    // Tinh tong cac cot
    a_cot_ct = GridX_Fdt_cotGtri(b_grctId);
    for (var i = 0; i < 10; i++) {
        var b_kq_nv = a_cot_ct[1][i][8];
        //var b_ts = a_cot_ct[1][i][2];
        if (CSO_SO(b_kq_nv, 0) > 0) {
            b_kq_nv_tong = b_kq_nv_tong + CSO_SO(b_kq_nv, 0);
        }
        //var b_kq_ql = a_cot_ct[1][i][10];
        //if (CSO_SO(b_kq_ql, 0) > 0) {
        //    b_kq_ql_tong = b_kq_ql_tong + CSO_SO(b_kq_ql, 0);
        //}
    }
    b_kq = b_kq_nv_tong;//+ b_kq_ql_tong;
    //
    $get(b_diem_tbId).value = b_kq;
    sdg.Fs_DG_CV_HT_LAY_HESO_XEPLOAI(form_Fs_nsd(), $get(b_diem_tbId).value, ql_dg_cv_ht_P_LAY_HESO_XEPLOAI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    b_kq = 0; b_kq_nv_tong = 0;
}

function ql_dg_cv_ht_P_LAY_HESO_XEPLOAI_KQ(b_kq) {
    var a_kq = Fas_ChMang(b_kq, '#');
    $get(b_hs_dg).value = a_kq[0];
    $get(b_xl_dg).value = a_kq[1];
}