var b_lkeCho, b_vungId, b_grlkeId, b_grctId, b_slideId, b_slidectId, b_nnghiep, b_cdanh, b_ngay_hl, b_choAct = 0;
function ns_hdns_gan_nl_cdanh_P_KD() {
    b_lkeCho = setInterval('ns_hdns_gan_nl_cdanh_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        b_dtuong = b_dtuong.toUpperCase();
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
            if (a_tso[0] == 'FILE_HTOAN') {
                ns_hdns_gan_nl_cdanh_P_LKE();
            }
        } else if (b_dtuong.indexOf("MUC_NL") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            var b_ten_nhom_nl = a_tso[5], b_ma_nhom_nl = a_tso[6], b_ma_nl = a_tso[0], b_ten_nl = a_tso[1], b_muc_nl = a_tso[2], b_mota_nl = a_tso[3],
                b_so_id_nl = a_tso[7], b_so_id_nl_ct = a_tso[8];
            var b_hang_d = GridX_Fi_timHangD(b_grctId, "so_id_nl_ct", b_so_id_nl_ct);
            if (b_hang_d > 0) {
                form_P_LOI("loi:Năng lực đã được chọn trước đó:loi");
                return false;
            }
            GridX_datGtri(b_grctId, b_hang, ["so_id_nl"], b_so_id_nl, 'K'), GridX_datGtri(b_grctId, b_hang, ["so_id_nl_ct"], b_so_id_nl_ct, 'K'),
            GridX_datGtri(b_grctId, b_hang, ["nhom_nl"], b_ma_nhom_nl, 'K'), GridX_datGtri(b_grctId, b_hang, ["ma_nl"], b_ma_nl, 'K'),
            GridX_datGtri(b_grctId, b_hang, ["ten_nhom_nl"], b_ten_nhom_nl, 'K'), GridX_datGtri(b_grctId, b_hang, ["ten_nl"], b_ten_nl, 'K'),
            GridX_datGtri(b_grctId, b_hang, ["muc_nl"], b_muc_nl, 'K'), GridX_datGtri(b_grctId, b_hang, ["mota"], b_mota_nl, 'K');
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_gan_nl_cdanh_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "NNNGHIEP":
                b_maId = b_nnghiep; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "NNNGHIEP") {
            ns_hdns_gan_nl_cdanh_P_CT_MOI("XL");
            var b_nnghiepId = C_NVL(form_Fs_TEN_GTRI(b_vungId, 'NNNGHIEP')), b_form = window.name;
            sns_hdns.Fs_NS_HDNS_NNN_CDANH_DROP_MA(form_Fs_nsd(), b_nnghiepId, b_form, "DT_CD", ns_hdns_gan_nl_cdanh_P_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        if (b_maTen == "NGAY_HL") {
            var b_nnghiepId = lke_Fs_TRA(b_nnghiep), b_cdanhId = lke_Fs_TRA(b_cdanh), b_ngay_hlId = $get(b_ngay_hl).value;
            if (b_nnghiepId == "" || b_cdanhId == "" || b_ngay_hlId == "") return;
            var a_ma = [b_nnghiepId, b_cdanhId, b_ngay_hlId];
            var b_hang = GridX_Fi_timHangD(b_grlkeId, ["nnnghiep", "cdanh", "ngay_hl"], a_ma);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_hdns_gan_nl_cdanh_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_hdns_gan_nl_cdanh_P_CHUYEN_HANG(); }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_gan_nl_cdanh_P_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
}
function ns_hdns_gan_nl_cdanh_P_MA_KTRA() {
    try {
        var b_nnghiepId = lke_Fs_TRA(b_nnghiep), b_cdanhId = lke_Fs_TRA(b_cdanh), b_ngay_hlId = $get(b_ngay_hl).value;
        if (b_nnghiepId != "" && b_cdanhId != "" && b_ngay_hlId != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_hdns.Fs_NS_HDNS_GAN_NL_CDANH_MA(form_Fs_nsd(), 0, b_nnghiepId, b_cdanhId, b_ngay_hlId, b_TrangKt, a_cot, ns_hdns_gan_nl_cdanh_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_gan_nl_cdanh_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_hdns_gan_nl_cdanh_P_CHUYEN_HANG(); }
}
function ns_hdns_gan_nl_cdanh_P_CT_MOI(b_dk) {
    form_P_MOI(b_vungId, b_dk);
    return false;
}
function ns_hdns_gan_nl_cdanh_P_MOI() {
    form_P_MOI(b_vungId, "GXL"); get_DateDDMMYYYY(); GridX_thoiA(b_grlkeId); $get(b_ngay_hl).focus(); GridX_datTrang(b_grctId);
    return false;
}
function ns_hdns_gan_nl_cdanh_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var b_so_id = C_NVL(GridX_Fas_layGtriA(b_grlkeId, "so_id"));
    var a_dt = form_Faa_TEXT_ROW(b_vungId), a_dt_ct = GridX_Fdt_cotGtri(b_grctId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_hdns.Fs_NS_HDNS_GAN_NL_CDANH_NH(form_Fs_nsd(), b_so_id, b_TrangKt, a_dt, a_dt_ct, a_cot_lke, ns_hdns_gan_nl_cdanh_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_hdns_gan_nl_cdanh_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang > 0) { GridX_datA(b_grlkeId, b_hang); ns_hdns_gan_nl_cdanh_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Ghi thành công!:loi");
    }
    return false;
}
function ns_hdns_gan_nl_cdanh_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_so_id = CSO_SO(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"), 0);
    if (b_so_id == "") ns_hdns_gan_nl_cdanh_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_NS_HDNS_GAN_NL_CDANH_XOA(form_Fs_nsd(), b_so_id, a_tso, a_cot, ns_hdns_gan_nl_cdanh_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_hdns_gan_nl_cdanh_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_hdns_gan_nl_cdanh_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_hdns_gan_nl_cdanh_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
}
function ns_hdns_gan_nl_cdanh_GR_lke_RowChange() {
    if (b_choAct != 0) clearTimeout(b_choAct);
    b_choAct = setTimeout("ns_hdns_gan_nl_cdanh_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_hdns_gan_nl_cdanh_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = CSO_SO(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"), 0);
        if (b_so_id <= 0) {
            form_P_MOI(b_vungId, "XGL");
            get_DateDDMMYYYY();
            GridX_datTrang(b_grctId); slide_P_MOI(b_slidectId);
        } else {
            var a_cot_nv = GridX_Fas_tenCot(b_grctId);
            sns_hdns.Fs_NS_HDNS_GAN_NL_CDANH_CT(form_Fs_nsd(), b_so_id, a_cot_nv, ns_hdns_gan_nl_cdanh_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_gan_nl_cdanh_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_ma_nnghiep = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "nnnghiep"));
    var b_ten_nnghiep = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten_nnnghiep"));
    var b_ma_cdanh = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "cdanh"));
    var b_ten_cdanh = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten_cdanh"));
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    lke_P_DAT($get(b_nnghiep), b_ma_nnghiep + '{' + b_ten_nnghiep);
    lke_P_DAT($get(b_cdanh), b_ma_cdanh + '{' + b_ten_cdanh);
    if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
    slide_P_SOTRANG(b_slidectId);
}
function ns_hdns_gan_nl_cdanh_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(b_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct');
        b_nnghiep = form_Fs_TEN_ID(b_vungId, 'NNNGHIEP'), b_cdanh = form_Fs_TEN_ID(b_vungId, 'CDANH'), b_ngay_hl = form_Fs_TEN_ID(b_vungId, 'NGAY_HL');
        b_slideId = $get(b_grlkeId).getAttribute('slideId'), b_slidectId = $get(b_grctId).getAttribute('slideId');
        slide_P_MOI(b_slideId), slide_P_MOI(b_slidectId);
        get_DateDDMMYYYY(); ns_hdns_gan_nl_cdanh_P_LKE();
    }
}
function ns_hdns_gan_nl_cdanh_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_NS_HDNS_GAN_NL_CDANH_LKE(form_Fs_nsd(), a_tso, a_cot, ns_hdns_gan_nl_cdanh_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_gan_nl_cdanh_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_hdns_gan_nl_cdanh_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2'); $get(b_btn_excel).click(); form_chay = 0; return false;
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

function ns_hdns_gan_nl_cdanh_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_hdns_gan_nl_cdanh_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_hdns_gan_nl_cdanh_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function ns_hdns_gan_nl_cdanh_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}
function form_dong() {
    location.reload(false);
}
function ns_hdns_gan_nl_cdanh_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function get_DateDDMMYYYY() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1;
    var yyyy = today.getFullYear();
    if (dd < 10) { dd = '0' + dd }
    if (mm < 10) { mm = '0' + mm }
    $get(b_ngay_hl).value = dd + '/' + mm + '/' + yyyy;
    return false;
}