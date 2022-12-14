var b_lkeCho, b_vungId, b_grlkeId, b_grctId, b_slideId, b_slidectId, b_phongId, b_ngay_hlId, b_choAct = 0;
function ns_hdns_gan_cdanhdvi_P_KD() {
    b_lkeCho = setInterval('ns_hdns_gan_cdanhdvi_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        b_dtuong = b_dtuong.toUpperCase();
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
            if (a_tso[0] == 'FILE_HTOAN') {
                ns_hdns_gan_cdanhdvi_P_LKE('K');
            }
        } else if (b_dtuong.indexOf("MA") >= 0) {
            ns_hdns_gan_cdanhdvi_P_LAY();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_gan_cdanhdvi_P_KTRA(b_maTen) {
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
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_hdns_gan_cdanhdvi_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_hdns_gan_cdanhdvi_P_CHUYEN_HANG(); }
            $get(b_tenId).focus();
        }
        else if (b_maTen == "MA_NN") {
            ns_hdns_gan_cdanhdvi_P_CT_MOI("XL");
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_gan_cdanhdvi_P_MA_KTRA() {
    try {
        var b_ma = form_Fs_TEN_GTRI(b_vungId, 'PHONG'), b_ngay_hl = form_Fs_TEN_GTRI(b_vungId, 'NGAY_HL');
        if (b_ma != "" && b_ngay_hl != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_hdns.Fs_NS_HDNS_GAN_CDANHDVI_MA(form_Fs_nsd(), b_ma, b_ngay_hl, b_TrangKt, a_cot, ns_hdns_gan_cdanhdvi_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_gan_cdanhdvi_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_hdns_gan_cdanhdvi_P_CHUYEN_HANG(); }
}
function ns_hdns_gan_cdanhdvi_P_CT_MOI(b_dk) {
    form_P_MOI(b_vungId, b_dk);
    return false;
}
function ns_hdns_gan_cdanhdvi_P_MOI() {
    form_P_MOI(b_vungId, "GXL"); GridX_thoiA(b_grlkeId); $get(b_ngay_hlId).focus();
    return false;
}
function ns_hdns_gan_cdanhdvi_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot_cd = GridX_Fdt_cotGtriH(b_grctId, "SO_ID_CD,MA_CD");
    sns_hdns.Fs_NS_HDNS_GAN_CDANHDVI_NH(form_Fs_nsd(), b_TrangKt, a_dt_ct, a_cot_cd, a_cot, ns_hdns_gan_cdanhdvi_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_hdns_gan_cdanhdvi_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        form_P_LOI("loi:Ghi thành công!:loi");
    }
    return false;
}
function ns_hdns_gan_cdanhdvi_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_so_id = CSO_SO(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"), 0);
    if (b_so_id == "") ns_hdns_gan_cdanhdvi_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_NS_HDNS_GAN_CDANHDVI_XOA(form_Fs_nsd(), b_so_id, a_tso, a_cot, ns_hdns_gan_cdanhdvi_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_hdns_gan_cdanhdvi_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        form_P_LOI("loi:Xóa thành công!:loi");
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_hdns_gan_cdanhdvi_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_hdns_gan_cdanhdvi_P_CHUYEN_HANG(); }
    }
}
function ns_hdns_gan_cdanhdvi_GR_lke_RowChange() {
    if (b_choAct != 0) clearTimeout(b_choAct);
    b_choAct = setTimeout("ns_hdns_gan_cdanhdvi_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_hdns_gan_cdanhdvi_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = CSO_SO(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"), 0), a_cot_nv = GridX_Fas_tenCot(b_grctId);
        if (b_so_id <= 0) form_P_MOI(b_vungId, "XGL"); else sns_hdns.Fs_NS_HDNS_GAN_CDANHDVI_CT(form_Fs_nsd(), b_so_id, a_cot_nv, ns_hdns_gan_cdanhdvi_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_gan_cdanhdvi_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
    slide_P_SOTRANG(b_slidectId);
}
function ns_hdns_gan_cdanhdvi_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(b_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
        b_tenId = form_Fs_TEN_ID(b_vungId, 'TEN'), b_phongId = form_Fs_TEN_ID(b_vungId, 'PHONG'); b_ngay_hlId = form_Fs_TEN_ID(b_vungId, 'NGAY_HL');
        b_slideId = $get(b_grlkeId).getAttribute('slideId');b_slidectId = $get(b_grctId).getAttribute('slideId');
        slide_P_MOI(b_slideId);slide_P_MOI(b_slidectId);
        GridX_taoScroll(b_grlkeId); ns_hdns_gan_cdanhdvi_P_LKE('K');
    }
}
function ns_hdns_gan_cdanhdvi_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_NS_HDNS_GAN_CDANHDVI_LKE(form_Fs_nsd(), a_tso, a_cot, ns_hdns_gan_cdanhdvi_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_gan_cdanhdvi_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_hdns_gan_cdanhdvi_P_EXCEL() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'XuatExcel'); $get(b_btn_excel).click(); form_chay = 0; return false;
}
function ns_hdns_gan_cdanhdvi_P_MAU() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'FileMau'); $get(b_btn_excel).click(); form_chay = 0; return false;
}
function ns_hdns_gan_cdanhdvi_FILE_IMPORT() {//import từ file Excel
    var b_tenf = '/App_form/ns/hdns/file_hdns.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "NS_HDNS_GAN_CDANHDVI", "NS_HDNS_GAN_CDANHDVI", "Import vị trí chức danh cho đơn vị "]], null);
    form_P_LOI('');
    return false;
}
function ns_hdns_gan_cdanhdvi_P_LAY() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grctId), b_ma = form_Fs_TEN_GTRI(b_vungId, 'PHONG');
        var b_so_id = 0, a_luoi;
        slide_P_SOTRANG(b_slidectId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) b_so_id = 0;
        else
            b_so_id = CSO_SO(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"), 0),
        GridX_datA(b_grlkeId, 1); a_luoi = GridX_Fdt_cotGtri(b_grctId); GridX_datA(b_grctId, b_hang);
        sns_hdns.Fs_NS_HDNS_GAN_CDANHDVI_LAY(form_Fs_nsd(), a_cot, b_so_id, a_luoi, ns_hdns_gan_cdanhdvi_P_LAY_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_gan_cdanhdvi_P_LAY_KQ(b_kq) {
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
        var b_hang = GridX_Fi_timHangA(b_grCt);
        if (b_hang >= 1) {
            var b_tthai = C_NVL(GridX_Fas_layGtri(b_grCt, b_hang, "trangthai"));
            if (b_tthai == 'N') { form_P_LOI("loi:Bản ghi đang ở trạng thái không áp dụng, Vui lòng chọn bản ghi khác:loi"); return false; }
        }
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

function form_dong() {
    location.reload(false);
}

function ns_hdns_gan_cdanhdvi_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}
function ns_hdns_gan_cdanhdvi_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_hdns_gan_cdanhdvi_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_hdns_gan_cdanhdvi_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}