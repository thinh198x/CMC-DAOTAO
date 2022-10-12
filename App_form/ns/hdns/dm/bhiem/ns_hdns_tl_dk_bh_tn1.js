var b_choAct = 0, b_lkeCho, b_vungId, b_vungHi, b_grlkeId, b_slideId, b_slidennnghiepId, b_slidecdanhId, b_slidelevelId, b_slidelhdId, b_grcdanhId, b_grlevelId,
b_grlhdId, b_gchuId, b_so_idId, b_moiId, b_noteId, b_loai_bh, b_goi_bh, b_cong_ty, b_thamnienId, b_nnnghiep, b_ma_nnnghiep;
function ns_hdns_tl_dk_bh_tn_P_KD() {
    b_lkeCho = setInterval('ns_hdns_tl_dk_bh_tn_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("MA_CD") >= 0) {
            ns_hdns_tl_dk_bh_tn_P_LAY();
        }
        else if (b_dtuong.indexOf("MA_LEVEL") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grlevelId);
            if (b_hang < 0) return;
            var b_hang_d = GridX_Fi_timHangD(b_grlevelId, "ma_level_cdanh", a_tso[0]);
            if (b_hang_d > 0) {
                form_P_LOI("loi:Level chức danh đã được chọn trước đó:loi");
                return false;
            }
            GridX_datGtri(b_grlevelId, b_hang, ["ma_level_cdanh"], [a_tso[0]], 'K');
            GridX_datGtri(b_grlevelId, b_hang, ["ten_level_cdanh"], [a_tso[1]], 'K');
        }
        else if (b_dtuong.indexOf("MA_LHD") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grlhdId);
            if (b_hang < 0) return;
            var b_hang_d = GridX_Fi_timHangD(b_grlhdId, "ma_lhd", a_tso[0]);
            if (b_hang_d > 0) {
                form_P_LOI("loi:Loại hợp đồng đã được chọn trước đó:loi");
                return false;
            }
            GridX_datGtri(b_grlhdId, b_hang, ["ma_lhd"], [a_tso[0]], 'K');
            GridX_datGtri(b_grlhdId, b_hang, ["ten_lhd"], [a_tso[1]], 'K');
        }
        else if (b_dtuong.indexOf("GOI_BH") >= 0) {
            $get(b_goi_bh).value = b_kq;
            $get(b_gchuId).value = a_tso[0];
            $get(b_goi_bh).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_tl_dk_bh_tn_P_KTRA(b_maTen) {
    try {
        var b_ma = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "LOAI_BH": b_ma = form_Fs_TEN_GTRI(b_vungId, 'LOAI_BH'); break;
            case "NNNGHIEP": b_ma = form_Fs_TEN_GTRI(b_vungId, 'NNNGHIEP'); break;
        }
        if (b_maTen == "LOAI_BH") {
            form_P_MOI(b_vungId, "G");
            b_loai_bh = form_Fs_TEN_GTRI(b_vungId, 'LOAI_BH');
            sns_hdns.Fs_NS_HDNS_GOI_BH_TN_DR_MA(form_Fs_nsd(), b_loai_bh, ns_hdns_tl_dk_bh_tn_P_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_maTen == "NNNGHIEP") { $get(b_ma_nnnghiep).value = lke_Fs_TRA($get(b_nnnghiep)); GridX_datTrang(b_grcdanhId); }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_tl_dk_bh_tn_P_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
}
function ns_hdns_tl_dk_bh_tn_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}
function ns_hdns_tl_dk_bh_tn_P_MOI() {
    form_P_MOI(b_vungId, "KGXL");
    //$get(b_ma_nnnghiep).value = '-';
    slide_P_MOI(b_slidecdanhId), slide_P_MOI(b_slidelevelId), slide_P_MOI(b_slidelhdId);
    GridX_thoiA(b_grlkeId);
    lke_P_DAT($get(b_cong_ty), $get(b_madvi).value);
    GridX_datTrang(b_grcdanhId);
    GridX_datTrang(b_grlevelId);
    GridX_datTrang(b_grlhdId);
    $get(b_so_idId).value = "0";
    $get(b_goi_bh).focus();
    return false;
}
function ns_hdns_tl_dk_bh_tn_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        var ktra = ktra_ngay(parseDate($get(b_ngaydId).value).getTime(), parseDate($get(b_ngaycId).value).getTime(), 1, "Ngày áp dụng", "Ngày ngừng áp dụng");
        if (b_loi != "") form_P_LOI(b_loi);
        else if (ktra.length > 0) { ns_hdns_tl_dk_bh_tn_P_NH_KQ(ktra); return false; }
        else {
            var b_so_id = $get(b_so_idId).value, b_dt = form_Faa_TEXT_ROW(b_vungId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId),
                a_cdanh = GridX_Fdt_cotGtri(b_grcdanhId), a_level = GridX_Fdt_cotGtri(b_grlevelId), a_loaihd = GridX_Fdt_cotGtri(b_grlhdId);
            sns_hdns.Fs_NS_HDNS_TL_DK_BH_TN_NH(form_Fs_nsd(), b_so_id, b_TrangKt, b_dt, a_cdanh, a_level, a_loaihd, a_cot_lke, ns_hdns_tl_dk_bh_tn_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_tl_dk_bh_tn_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang > 0) { GridX_datA(b_grlkeId, b_hang); ns_hdns_tl_dk_bh_tn_P_CHUYEN_HANG(); }
        form_P_LOI('loi:Ghi thành công!:loi');
    }
    return false;
}
function ns_hdns_tl_dk_bh_tn_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"), b_trang_thai = GridX_Fas_layGtri(b_grlkeId, b_hang, "trang_thai");
    if (b_trang_thai == 0) { form_P_LOI("loi:Bạn không được xóa bản ghi này:loi"); return false; }
    var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
    if (b_so_id == "0" || b_so_id == "") ns_hdns_tl_dk_bh_tn_P_MOI();
    else {
        sns_hdns.Fs_NS_HDNS_TL_DK_BH_TN_XOA(form_Fs_nsd(), b_so_id, a_tso, a_cot, ns_hdns_tl_dk_bh_tn_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_hdns_tl_dk_bh_tn_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        form_P_LOI("loi:Xóa thành công!:loi");
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_hdns_tl_dk_bh_tn_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_hdns_tl_dk_bh_tn_P_CHUYEN_HANG(); }
    }
}
function ns_hdns_tl_dk_bh_tn_GR_lke_RowChange() {
    if (b_choAct != 0) clearTimeout(b_choAct);
    b_choAct = setTimeout("ns_hdns_tl_dk_bh_tn_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_hdns_tl_dk_bh_tn_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")),
    a_cdanh = GridX_Fas_tenCot(b_grcdanhId), a_level = GridX_Fas_tenCot(b_grlevelId), a_loaihd = GridX_Fas_tenCot(b_grlhdId);
    if (b_so_id == "0" || b_so_id == "") { ns_hdns_tl_dk_bh_tn_P_MOI(); GridX_datTrang(b_grcdanhId); GridX_datTrang(b_grlevelId); GridX_datTrang(b_grlhdId); }
    else sns_hdns.Fs_NS_HDNS_TL_DK_BH_TN_CT(form_Fs_nsd(), b_so_id, a_cdanh, a_level, a_loaihd, ns_hdns_tl_dk_bh_tn_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = b_so_id;
}
function ns_hdns_tl_dk_bh_tn_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    //var b_ma_loai_bh = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "loai_bh"));
    //var b_ten_loai_bh = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten_loai_bh"));
    //var b_ma_goi = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "goi_bh"));
    //var b_ten_goi = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten_goi_bh"));
    //var b_ma_cty = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma_dvi"));
    //var b_ten_cty = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten_cong_ty"));
    //var b_ma_nnn = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "nnnghiep"));
    //var b_ten_nnn = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten_nnnghiep"));
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    //lke_P_DAT($get(b_loai_bh), b_ma_loai_bh + '{' + b_ten_loai_bh);
    //lke_P_DAT($get(b_goi_bh), b_ma_goi + '{' + b_ten_goi);
    //lke_P_DAT($get(b_cong_ty), b_ma_cty + '{' + b_ten_cty);
    //lke_P_DAT($get(b_nnnghiep), b_ma_nnn + '{' + b_ten_nnn);
    if (a_kq[1] == null || a_kq[1] == "") GridX_datTrang(b_grcdanhId);
    else { GridX_datBang(b_grcdanhId, a_kq[1]); slide_P_SOTRANG(b_slidecdanhId); }
    if (a_kq[2] == null || a_kq[2] == "") GridX_datTrang(b_grlevelId);
    else { GridX_datBang(b_grlevelId, a_kq[2]); slide_P_SOTRANG(b_slidelevelId); }
    if (a_kq[3] == null || a_kq[3] == "") GridX_datTrang(b_grlhdId);
    else { GridX_datBang(b_grlhdId, a_kq[3]); slide_P_SOTRANG(b_slidelhdId); }
}
function ns_hdns_tl_dk_bh_tn_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(b_lkeCho);
        b_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungHi = form_Fs_VUNG_ID('UPa_hi'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_grcdanhId = form_Fs_VUNG_ID('GR_cdanh'), b_grlevelId = form_Fs_VUNG_ID('GR_level'), b_grlhdId = form_Fs_VUNG_ID('GR_lhd'),
        b_loai_bh = form_Fs_TEN_ID(b_vungId, 'LOAI_BH'), b_goi_bh = form_Fs_TEN_ID(b_vungId, 'goi_bh'), b_cong_ty = form_Fs_TEN_ID(b_vungId, 'ma_dvi'),
        b_ngaydId = form_Fs_TEN_ID(b_vungId, 'NGAYD'), b_ngaycId = form_Fs_TEN_ID(b_vungId, 'NGAYC'), b_thamnienId = form_Fs_TEN_ID(b_vungId, 'thamnien'),
        b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'), b_gchuId = form_Fs_VTEN_ID('', 'gchu'), b_moiId = form_Fs_VTEN_ID('', 'moi'),
        b_nnnghiep = form_Fs_TEN_ID(b_vungId, 'nnnghiep'), b_ma_nnnghiep = form_Fs_TEN_ID(b_vungId, 'ma_nnnghiep'), b_madvi = form_Fs_TEN_ID(b_vungHi, 'madvi');
        b_slideId = $get(b_grlkeId).getAttribute('slideId'), b_slidecdanhId = $get(b_grcdanhId).getAttribute('slideId'),
        b_slidelevelId = $get(b_grlevelId).getAttribute('slideId'), b_slidelhdId = $get(b_grlhdId).getAttribute('slideId');
        slide_P_MOI(b_slideId), slide_P_MOI(b_slidecdanhId), slide_P_MOI(b_slidelevelId), slide_P_MOI(b_slidelhdId);
        lke_P_DAT($get(b_cong_ty), $get(b_madvi).value);
        form_Fctr_TEN_DTUONG(b_vungId, 'ma_dvi').disabled = true;
        ns_hdns_tl_dk_bh_tn_P_LKE();
    }
}
function ns_hdns_tl_dk_bh_tn_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_NS_HDNS_TL_DK_BH_TN_LKE(form_Fs_nsd(), a_tso, a_cot, ns_hdns_tl_dk_bh_tn_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_tl_dk_bh_tn_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    GridX_datBang(b_grlkeId, a_kq[1]);
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
}
function ns_hdns_tl_dk_bh_tn_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grctId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        if (b_value != "") {
            if (b_cot == "SO_THE") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Mã cán bộ", b_value, "ns_cb,so_the,ten", tl_phanca_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        if (b_value != "") GridX_ThemHang(b_grctId);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function cdanh_HangLen() {
    GridX_chuyenHang(b_grcdanhId, -1);
    return false;
}
function cdanh_HangXuong() {
    GridX_chuyenHang(b_grcdanhId, 1);
    return false;
}
function cdanh_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grcdanhId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grcdanhId);
    return false;
}
function cdanh_CatDong() {
    GridX_boChon(b_grcdanhId, 'C');
    return false;
}
function level_cdanh_HangLen() {
    GridX_chuyenHang(b_grlevelId, -1);
    return false;
}
function level_cdanh_HangXuong() {
    GridX_chuyenHang(b_grlevelId, 1);
    return false;
}
function level_cdanh_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grlevelId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grlevelId);
    return false;
}
function level_cdanh_CatDong() {
    GridX_boChon(b_grlevelId, 'C');
    return false;
}
function loai_hd_HangLen() {
    GridX_chuyenHang(b_grlhdId, -1);
    return false;
}
function loai_hd_HangXuong() {
    GridX_chuyenHang(b_grlhdId, 1);
    return false;
}
function loai_hd_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grlhdId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grlhdId);
    return false;
}
function loai_hd_CatDong() {
    GridX_boChon(b_grlhdId, 'C');
    return false;
}
function form_dong() {
    location.reload(false);
}
function ns_hdns_tl_dk_bh_tn_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function ns_hdns_tl_dk_bh_tn_P_LAY() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grcdanhId);
        sns_hdns.Fs_NS_HDNS_GAN_CDANHDVI_LAY(form_Fs_nsd(), a_cot, ns_hdns_tl_dk_bh_tn_P_LAY_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_tl_dk_bh_tn_P_LAY_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    GridX_datBang(b_grcdanhId, a_kq[1]);
}
function ktra_ngay(tungay, denngay, loai, ten1, ten2) {
    if (denngay == "" || denngay == null) {
        return "";
    }
    if (loai == 1 && tungay > denngay) {
        return "loi: " + ten1 + " không được lớn hơn " + ten2 + " :loi";
    } else if (loai == 2 && tungay >= denngay) {
        return "loi: " + ten1 + " không được lớn hơn hoặc bằng " + ten2 + " :loi";
    }
    return "";
}
function parseDate(str) {
    var mdy = str.split('/');
    return new Date(mdy[2], mdy[1], mdy[0]);
}