var b_lkeCho, b_vungId, b_grlkeId, b_grctId, b_slideId, b_slidectId, b_phong_Id, b_nnghiep_Id, b_cdanh_Id, b_ngay_hl_Id, b_choAct = 0, b_nsd;
function ns_hdns_nl_cdanh_dvi_P_KD() {
    b_lkeCho = setInterval('ns_hdns_nl_cdanh_dvi_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        b_dtuong = b_dtuong.toUpperCase();
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
            if (a_tso[0] == 'FILE_HTOAN') {
                ns_hdns_nl_cdanh_dvi_P_LKE();
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
            GridX_datGtri(b_grctId, b_hang, ["ten_nhom_nl"], b_ten_nhom_nl, 'K'), GridX_datGtri(b_grctId, b_hang, ["ten_nl"], b_ten_nl, 'K'),
            GridX_datGtri(b_grctId, b_hang, ["muc_nl"], b_muc_nl, 'K'), GridX_datGtri(b_grctId, b_hang, ["mota"], b_mota_nl, 'K');
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_nl_cdanh_dvi_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "PHONG": b_maId = b_phong_Id; break;
            case "NNNGHIEP": b_maId = b_nnghiep_Id; break;
            case "CDANH": b_maId = b_cdanh_Id; break;
            case "NGAY_HL": b_maId = b_ngay_hl_Id; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return true;
        switch (b_maTen) {
            case "NNNGHIEP":
                var b_nnghiepId = C_NVL(form_Fs_TEN_GTRI(b_vungId, 'NNNGHIEP'));
                sns_hdns.Fs_NS_HDNS_NNN_CDANH_DROP_MA(b_nsd, b_nnghiepId, "ns_hdns_nl_cdanh_dvi", "NL_CD_DVI_CDANH", ns_hdns_nl_cdanh_dvi_P_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                break;
            case "PHONG":
            case "CDANH":
            case "NGAY_HL":
                var b_phong = lke_Fs_TRA(b_phong_Id), b_nnghiep = lke_Fs_TRA(b_nnghiep_Id), b_cdanh = lke_Fs_TRA(b_cdanh_Id), b_ngay_hl = $get(b_ngay_hl_Id).value;
                //var b_phong = $get(b_phong_Id).value, b_nnghiep = $get(b_nnghiep_Id).value, b_cdanh = $get(b_cdanh_Id).value, b_ngay_hl = $get(b_ngay_hl_Id).value;
                if (b_phong == "" || b_nnghiep == "" || b_cdanh == "" || b_ngay_hl == "") return;
                var b_hang = GridX_Fi_timHangD(b_grlkeId, ["phong", "nnnghiep", "cdanh", "ngay_hl"], [b_phong, b_nnghiep, b_cdanh, b_ngay_hl]);
                if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_hdns_nl_cdanh_dvi_P_MA_KTRA(); }
                else { GridX_datA(b_grlkeId, b_hang); ns_hdns_nl_cdanh_dvi_P_CHUYEN_HANG(); }
                break;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_nl_cdanh_dvi_P_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
}
function ns_hdns_nl_cdanh_dvi_P_MA_KTRA() {
    try {
        var b_phong = lke_Fs_TRA(b_phong_Id), b_nnghiep = lke_Fs_TRA(b_nnghiep_Id), b_cdanh = lke_Fs_TRA(b_cdanh_Id), b_ngay_hl = $get(b_ngay_hl_Id).value;
        if (b_phong != "" && b_phong != "" && b_nnghiep != "" && b_nnghiep != "" && b_ngay_hl != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_hdns.Fs_NS_HDNS_GAN_NLCD_DVI_MA(b_nsd, 0, b_phong, b_nnghiep, b_cdanh, b_ngay_hl, b_TrangKt, a_cot, ns_hdns_nl_cdanh_dvi_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_nl_cdanh_dvi_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        form_P_MOI(b_vungId, "X");
        var b_nnghiep = lke_Fs_TRA(b_nnghiep_Id), b_cdanh = lke_Fs_TRA(b_cdanh_Id), b_ngay_hl = CNG_SO($get(b_ngay_hl_Id).value);
        var a_cot = GridX_Fas_tenCot(b_grctId);
        sns_hdns.Fs_NS_HDNS_GAN_NLCD_DVI_CHA(b_nsd, b_nnghiep, b_cdanh, b_ngay_hl, a_cot, ns_hdns_nl_cdanh_dvi_P_NLCD_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    else { GridX_datA(b_grlkeId, b_hang); ns_hdns_nl_cdanh_dvi_P_CHUYEN_HANG(); }
}
function ns_hdns_nl_cdanh_dvi_P_NLCD_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang(b_grctId, b_kq);
}
function ns_hdns_nl_cdanh_dvi_P_CT_MOI(b_dk) {
    form_P_MOI(b_vungId, b_dk);
    return false;
}
function ns_hdns_nl_cdanh_dvi_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    slide_P_SOTRANG(b_slidectId);
    $get(b_phong_Id).focus();
    return false;
}
function ns_hdns_nl_cdanh_dvi_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var b_so_id = CSO_SO(C_NVL(GridX_Fas_layGtriA(b_grlkeId, "so_id")), 0);
    var a_dt = form_Faa_TEXT_ROW(b_vungId), a_dt_ct = GridX_Fdt_cotGtri(b_grctId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_hdns.Fs_NS_HDNS_GAN_NLCD_DVI_NH(b_nsd, b_so_id, b_TrangKt, a_dt, a_dt_ct, a_cot_lke, ns_hdns_nl_cdanh_dvi_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_hdns_nl_cdanh_dvi_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang > 0) { GridX_datA(b_grlkeId, b_hang); ns_hdns_nl_cdanh_dvi_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Ghi thành công!:loi");
    }
    return false;
}
function ns_hdns_nl_cdanh_dvi_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_so_id = CSO_SO(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"), 0);
    if (b_so_id == "") ns_hdns_nl_cdanh_dvi_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_NS_HDNS_GAN_NLCD_DVI_XOA(b_nsd, b_so_id, a_tso, a_cot, ns_hdns_nl_cdanh_dvi_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_hdns_nl_cdanh_dvi_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_hdns_nl_cdanh_dvi_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_hdns_nl_cdanh_dvi_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
}
function ns_hdns_nl_cdanh_dvi_GR_lke_RowChange() {
    if (b_choAct != 0) clearTimeout(b_choAct);
    b_choAct = setTimeout("ns_hdns_nl_cdanh_dvi_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_hdns_nl_cdanh_dvi_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = CSO_SO(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"), 0);
        if (b_so_id <= 0) {
            form_P_MOI(b_vungId, "XGL");
            GridX_datTrang(b_grctId); slide_P_MOI(b_slidectId);
        } else {
            var a_cot_nv = GridX_Fas_tenCot(b_grctId), b_nnghiep = lke_Fs_TRA(b_nnghiep_Id);
            sns_hdns.Fs_NS_HDNS_GAN_NLCD_DVI_CT(b_nsd, b_so_id, b_nnghiep, a_cot_nv, ns_hdns_nl_cdanh_dvi_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_nl_cdanh_dvi_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_ma_nnghiep = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "nnnghiep"));
    var b_ten_nnghiep = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten_nnnghiep"));
    var b_ma_cdanh = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "cdanh"));
    var b_ten_cdanh = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten_cdanh"));
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    lke_P_DAT($get(b_nnghiep_Id), b_ma_nnghiep + '{' + b_ten_nnghiep);
    lke_P_DAT($get(b_cdanh_Id), b_ma_cdanh + '{' + b_ten_cdanh);
    if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
    slide_P_SOTRANG(b_slidectId);
}
function ns_hdns_nl_cdanh_dvi_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(b_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct');
        b_phong_Id = form_Fs_TEN_ID(b_vungId, 'PHONG'), b_nnghiep_Id = form_Fs_TEN_ID(b_vungId, 'NNNGHIEP'), b_cdanh_Id = form_Fs_TEN_ID(b_vungId, 'CDANH'), b_ngay_hl_Id = form_Fs_TEN_ID(b_vungId, 'NGAY_HL');
        b_slideId = $get(b_grlkeId).getAttribute('slideId'), b_slidectId = $get(b_grctId).getAttribute('slideId');
        slide_P_MOI(b_slideId), slide_P_MOI(b_slidectId); b_nsd = form_Fs_nsd();
        ns_hdns_nl_cdanh_dvi_P_LKE();
    }
}
function ns_hdns_nl_cdanh_dvi_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_NS_HDNS_GAN_NLCD_DVI_LKE(b_nsd, a_tso, a_cot, ns_hdns_nl_cdanh_dvi_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_nl_cdanh_dvi_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_hdns_nl_cdanh_dvi_P_EXCEL() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'excel_an'); $get(b_btn_excel).click(); form_chay = 0; return false;
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
function ns_hdns_nl_cdanh_dvi_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_hdns_nl_cdanh_dvi_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_hdns_nl_cdanh_dvi_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function ns_hdns_nl_cdanh_dvi_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}
function form_dong() {
    location.reload(false);
}