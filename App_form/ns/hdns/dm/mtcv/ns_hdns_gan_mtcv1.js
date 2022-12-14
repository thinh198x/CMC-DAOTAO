
var ns_hdns_gan_mtcvdvi_lkeCho, b_vungId, b_grlkeId, b_grctId, b_slideId, b_slidectId, b_phongId, b_ngay_hlId, ns_hdns_gan_mtcvdvi_choAct = 0, b_so_id_mtcvId;
function ns_hdns_gan_mtcvdvi_P_KD() {
    ns_hdns_gan_mtcvdvi_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
    b_tenId = form_Fs_TEN_ID(b_vungId, 'TEN_CD'), b_so_id_mtcvId = form_Fs_TEN_ID(b_vungId, 'so_id_mtcv'),
    b_phongId = form_Fs_TEN_ID(b_vungId, 'PHONG'); b_ngay_hlId = form_Fs_TEN_ID(b_vungId, 'NGAY_HL');
    b_slidectId = $get(b_grctId).getAttribute('slideId');
    b_slideId = $get(b_grlkeId).getAttribute('slideId');
    slide_P_MOI(b_slideId);
    slide_P_MOI(b_slidectId);
    ns_hdns_gan_mtcvdvi_lkeCho = setInterval('ns_hdns_gan_mtcvdvi_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
            if (a_tso[0] == 'FILE_HTOAN') {
                ns_hdns_gan_mtcvdvi_P_LKE();
            }
        }
        else {
            b_dtuong = b_dtuong.toUpperCase();
            if (b_dtuong == null || b_dtuong == "") {
                if (a_tso.length == 0) return;
                if (a_tso[0] == 'FILE_HTOAN') {
                    ns_hdns_gan_mtcvdvi_P_LKE();
                }
            } else if (b_dtuong.indexOf("TEN_NNN") >= 0) {
                var b_hang = GridX_Fi_timHangA(b_grctId);
                GridX_datGtri(b_grctId, b_hang, ["SO_ID_MTCV"], [a_tso[0]], 'K');
                GridX_datGtri(b_grctId, b_hang, ["ten_nnn"], [a_tso[1]], 'K');
                GridX_datGtri(b_grctId, b_hang, ["ten_cd"], [a_tso[2]], 'K');
            }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_gan_mtcvdvi_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
            case "MA_NN": b_maId = b_ma_nnId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            var b_ma_nn = form_Fs_TEN_GTRI(b_vungId, 'MA_NN');
            b_hang = GridX_Fi_timHangD(b_grlkeId, ["ma_nn", "ma"], [b_ma_nn, b_ma.value]);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_hdns_gan_mtcvdvi_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_hdns_gan_mtcvdvi_P_CHUYEN_HANG(); }
            $get(b_tenId).focus();
        }
        else if (b_maTen == "MA_NN") {
            ns_hdns_gan_mtcvdvi_P_CT_MOI("XL");
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_gan_mtcvdvi_P_MA_KTRA() {
    try {
        var b_ma = form_Fs_TEN_GTRI(b_vungId, 'PHONG'), b_ngay_hl = form_Fs_TEN_GTRI(b_vungId, 'NGAY_HL');
        if (b_ma != "" && b_ngay_hl != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_hdns.Fs_NS_HDNS_GAN_MTCVDVI_MA(form_Fs_nsd(), b_ma, b_ngay_hl, b_TrangKt, a_cot, ns_hdns_gan_mtcvdvi_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_gan_mtcvdvi_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) { form_P_MOI(b_vungId, "X"); GridX_datTrang(b_grctId); slide_P_MOI(b_slidectId); }
    else { GridX_datA(b_grlkeId, b_hang); ns_hdns_gan_mtcvdvi_P_CHUYEN_HANG(); }
}
function ns_hdns_gan_mtcvdvi_P_CT_MOI(b_dk) {
    form_P_MOI(b_vungId, b_dk);
    GridX_datTrang(b_grctId);
    return false;
}
function ns_hdns_gan_mtcvdvi_P_MOI() {
    form_P_MOI(b_vungId, "GXL"); GridX_thoiA(b_grlkeId); $get(b_ngay_hlId).focus();
    GridX_datTrang(b_grctId);
    slide_P_MOI(b_slidectId);
    return false;
}
function ns_hdns_gan_mtcvdvi_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot_cd = GridX_Fdt_cotGtriH(b_grctId, "SO_ID_MTCV");
    sns_hdns.Fs_NS_HDNS_GAN_MTCVDVI_NH(form_Fs_nsd(), b_TrangKt, a_dt_ct, a_cot_cd, a_cot, ns_hdns_gan_mtcvdvi_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_hdns_gan_mtcvdvi_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) { GridX_datA(b_grlkeId, b_hang); ns_hdns_gan_mtcvdvi_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Ghi thành công!:loi");
    }
    return false;
}
function ns_hdns_gan_mtcvdvi_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_so_id = CSO_SO(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"), 0);
    if (b_so_id == "") ns_hdns_gan_mtcvdvi_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_NS_HDNS_GAN_MTCVDVI_XOA(form_Fs_nsd(), b_so_id, a_tso, a_cot, ns_hdns_gan_mtcvdvi_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_hdns_gan_mtcvdvi_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        form_P_LOI("loi:Xóa thành công!:loi");
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_hdns_gan_mtcvdvi_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_hdns_gan_mtcvdvi_P_CHUYEN_HANG(); }
    }
}
function ns_hdns_gan_mtcvdvi_GR_lke_RowChange() {
    if (ns_hdns_gan_mtcvdvi_choAct != 0) clearTimeout(ns_hdns_gan_mtcvdvi_choAct);
    ns_hdns_gan_mtcvdvi_choAct = setTimeout("ns_hdns_gan_mtcvdvi_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_hdns_gan_mtcvdvi_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = CSO_SO(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"), 0), a_cot_nv = GridX_Fas_tenCot(b_grctId);
        if (b_so_id <= 0) { form_P_MOI(b_vungId, "XGL"); GridX_datTrang(b_grctId); slide_P_MOI(b_slidectId); } else sns_hdns.Fs_NS_HDNS_GAN_MTCVDVI_CT(form_Fs_nsd(), b_so_id, a_cot_nv, ns_hdns_gan_mtcvdvi_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_gan_mtcvdvi_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
    slide_P_SOTRANG(b_slidectId);
}
function ns_hdns_gan_mtcvdvi_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_hdns_gan_mtcvdvi_lkeCho); GridX_taoScroll(b_grlkeId); ns_hdns_gan_mtcvdvi_P_LKE(); }
}
function ns_hdns_gan_mtcvdvi_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_NS_HDNS_GAN_MTCVDVI_LKE(form_Fs_nsd(), a_tso, a_cot, ns_hdns_gan_mtcvdvi_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_gan_mtcvdvi_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_hdns_gan_mtcvdvi_P_EXCEL() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'XuatExcel'); $get(b_btn_excel).click(); form_chay = 0; return false;
}
function ns_hdns_gan_mtcvdvi_P_MAU() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'FileMau'); $get(b_btn_excel).click(); form_chay = 0; return false;
}
function ns_hdns_gan_mtcvdvi_FILE_IMPORT() {//import từ file Excel
    var b_tenf = '/App_form/ns/ma/file_import_hdns.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "GAN_MTCV", "GAN_MTCV", "Gán mô tả công việc cho đơn vị"]], null);
    form_P_LOI('');
    return false;
}
function ns_hdns_gan_mtcvdvi_P_LAY() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grctId);
        sns_hdns.Fs_NS_HDNS_GAN_CDANHDVI_LAY(form_Fs_nsd(), a_cot, ns_hdns_gan_mtcvdvi_P_LAY_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_gan_mtcvdvi_P_LAY_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    GridX_datBang(b_grctId, a_kq[1]);
    slide_P_SOTRANG(b_slidectId);
}
// START: Trả giá trị chọn trên lưới //       
// Tra gia tri chon cho form goi
function form_P_TRA_CHON_GRID(b_ten) {
    try {
        var a_kq = form_P_TRA_GTRI_GRID(b_ten);
        form_P_DONG(window.name, a_kq);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
// Tra mang gia tri theo ten
function form_P_TRA_GTRI_GRID(b_ten) {
    try {
        var a_ten = b_ten.split(','), a_kq = [];
        for (var i = 0; i < a_ten.length; i++) {
            var a_grid = a_ten[i].split(':');
            var b_gridId = form_Fs_VUNG_ID(a_grid[0]);
            var b_hang = GridX_Fi_timHangA(b_gridId);
            a_kq[i] = GridX_Fas_layGtri(b_gridId, b_hang, a_grid[1]);
        }
        return a_kq;
    }
    catch (err) { return null; }
}
// END: Trả giá trị chọn trên lưới //  


function ns_hdns_gan_mtcvdvi_CT_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grctId);
        var b_so_id = CSO_SO(GridX_Fas_layGtri(b_grctId, b_hang, "SO_ID_MTCV"), 0);
        $get(b_so_id_mtcvId).value = b_so_id;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_gan_mtcvdvi_P_EXCEL() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'XuatExcel'); $get(b_btn_excel).click(); form_chay = 0; return false;
}

function ns_hdns_gan_mtcvdvi_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'InExcel'); $get(b_btn_excel).click(); form_chay = 0; return false;
}

function ns_hdns_gan_mtcvdvi_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}


function form_dong() {
    location.reload(false);
}