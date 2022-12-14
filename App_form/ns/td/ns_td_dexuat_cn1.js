var ns_td_dexuat_cn_lkeCho, b_vungId, b_grlkeId, b_slideId, b_trangthaiId, b_maId, b_grhdId, b_nam_tkId, b_phong_tkId, b_trangthaipd_tkId, b_gchuId, b_namId, b_cdanhId, b_donviId, b_banId, b_phongId,
    b_so_idId, b_moiId, b_doi = 0, ns_td_dexuat_cn_choAct, b_cho_control, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C', b_cotheo_kh_namId, b_kehoach_namId,
    b_ns_hientaiId, b_db_duocduyetId;
function ns_td_dexuat_cn_P_KD() {
    ns_td_dexuat_cn_lkeCho, ns_td_dexuat_cn_choAct = 0, b_cho_control = 0, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtkId = form_Fs_VUNG_ID('UPa_tk'),
    b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grhdId = form_Fs_VUNG_ID('Gr_hd'), b_nam_tkId = form_Fs_TEN_ID(b_vungtkId, 'nam_tk'), b_phong_tkId = form_Fs_TEN_ID(b_vungtkId, 'phong_tk'),
    b_trangthaipd_tkId = form_Fs_TEN_ID(b_vungtkId, 'trangthaitk_pd'), b_donviId = form_Fs_TEN_ID(b_vungId, 'donvi'), b_banId = form_Fs_TEN_ID(b_vungId, 'ban'),
    b_phongId = form_Fs_TEN_ID(b_vungId, 'phong'), b_cdanhId = form_Fs_TEN_ID(b_vungId, 'cdanh'),
    b_namId = form_Fs_TEN_ID(b_vungId, 'nam'), b_maId = form_Fs_TEN_ID(b_vungId, 'ma'), b_trangthaiId = form_Fs_TEN_ID(b_vungId, 'trangthai_pd'),
    b_cotheo_kh_namId = form_Fs_TEN_ID(b_vungId, 'cotheo_kh_nam'), b_kehoach_namId = form_Fs_TEN_ID(b_vungId, 'kehoach_nam'), b_ns_hientaiId = form_Fs_TEN_ID(b_vungId, 'sl_hientai'),
    b_db_duocduyetId = form_Fs_TEN_ID(b_vungId, 'db_duocduyet'),
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'); b_gchuId = form_Fs_VTEN_ID('', 'gchu'); b_moiId = form_Fs_VTEN_ID('', 'moi');
    b_slideId = b_grlkeId + '_slide';
    ns_td_dexuat_cn_lkeCho = setInterval('ns_td_dexuat_cn_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[0];
    }
    catch (err) { form_P_LOI(err); }
}
function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}
function ns_td_dexuat_cn_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_t = b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_madxId; break;
            case "NAM": b_maId = b_namId; break;
            case "DONVI": b_ma = form_Fs_TEN_GTRI(b_vungId, 'donvi'); break;
            case "BAN": b_ma = form_Fs_TEN_GTRI(b_vungId, 'ban'); break;
            case "PHONG": b_ma = form_Fs_TEN_GTRI(b_vungId, 'phong'); break;
            case "CDANH": b_ma = form_Fs_TEN_GTRI(b_vungId, 'cdanh'); break;
            case "KEHOACH_NAM": b_ma = b_kehoach_namId; break;
        }
        if (b_maTen == "DONVI" || b_maTen == "BAN" || b_maTen == "PHONG" || b_maTen == "NAM") {
            var b_donvi = lke_Fs_TRA($get(b_donviId)), b_ban = lke_Fs_TRA($get(b_banId)), b_phong = lke_Fs_TRA($get(b_phongId)), b_nam = $get(b_namId).value;
            sns_td.Fs_HDNS_DBIEN_BY_PHONGBAN(form_Fs_nsd(), b_nam, b_donvi, b_ban, b_phong, ns_td_dexuat_P_TONG_DBIEN_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        if (b_maTen == "DONVI") {
            var b_cty = form_Fs_TEN_GTRI(b_vungId, 'donvi');
            var b_kq = "{";
            lke_P_DAT($get(form_Fs_TEN_ID(b_vungId, 'BAN')), b_kq);
            lke_P_DAT($get(form_Fs_TEN_ID(b_vungId, 'PHONG')), b_kq);
            hts_dungchung.Fs_PHONG_LEVEL_DR(2, b_cty, 'DT_BAN', 'ns_td_dexuat_cn', ns_td_dexuat_cn_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        } else if (b_maTen == "BAN") {
            var b_kq = "{";
            lke_P_DAT($get(form_Fs_TEN_ID(b_vungId, 'PHONG')), b_kq);
            var b_ban = form_Fs_TEN_GTRI(b_vungId, 'BAN');
            hts_dungchung.Fs_PHONG_LEVEL_DR(3, b_ban, 'DT_PHONG', 'ns_td_dexuat_cn', ns_td_dexuat_cn_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            hts_dungchung.Fs_NS_CB_PHONG_CDANH('ns_td_dexuat_cn', b_ban);
        } else if (b_maTen == "PHONG") {
            var b_kq = "{";
            lke_P_DAT($get(form_Fs_TEN_ID(b_vungId, 'cdanh')), b_kq);
            var b_phongban = form_Fs_TEN_GTRI(b_vungId, 'PHONG');
            if (b_phongban != '')
                hts_dungchung.Fs_NS_CB_PHONG_CDANH('ns_td_dexuat_cn', b_phongban, ns_td_dexuat_cn_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            hts_dungchung.Fs_NS_CB_PHONG_CDANH('ns_td_dexuat_cn', b_phongban);
        } else if (b_maTen == "CDANH" || b_maTen == "NAM") {
            var b_cdanh = form_Fs_TEN_GTRI(b_vungId, 'cdanh');
            var b_nam = form_Fs_TEN_GTRI(b_vungId, 'nam')
            if (b_cdanh != '' && b_nam != '') {
                sns_td.Fs_HDNS_DBIEN_BY_CDANH(form_Fs_nsd(), b_nam, b_cdanh, ns_td_dexuat_cn_P_NS_HIENTAI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
        } else if (b_maTen == "KEHOACH_NAM") {
            var b_ma_kh = lke_Fs_TRA($get(b_kehoach_namId));
            if (b_ma_kh != '') {
                sns_td.Fs_TD_KH_NAM_BY_ID(form_Fs_nsd(), b_ma_kh, ns_td_dexuat_cn_KEHOACH_NAM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        var b_ma = $get(b_maId);

    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_dexuat_cn_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
    }
}
function ns_td_dexuat_cn_P_NS_HIENTAI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    $get(b_ns_hientaiId).value = a_kq[0];
}

function ns_td_dexuat_P_TONG_DBIEN_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    $get(b_db_duocduyetId).value = CSO_SO(a_kq[0]);
}
function ns_td_dexuat_cn_KEHOACH_NAM_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    $get(b_db_duocduyetId).value = a_kq[0];
}
function ns_td_dexuat_cn_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else { form_P_DatGchu(b_gchuId, b_kq); }
}
// ẩn hiện controll
function ns_td_dexuat_P_NPA() {
    var b_nv = $get(b_cotheo_kh_namId).value;
    if (b_nv == "X") {
        var b_nam = form_Fs_TEN_GTRI(b_vungId, 'NAM'), b_donvi = form_Fs_TEN_GTRI(b_vungId, 'donvi'), b_ban = form_Fs_TEN_GTRI(b_vungId, 'ban'),
            b_phong = form_Fs_TEN_GTRI(b_vungId, 'phong'), b_cdanh = form_Fs_TEN_GTRI(b_vungId, 'cdanh');
        sns_td.Fs_TD_KH_NAM_BYSORT(form_Fs_nsd(), b_nam, b_donvi, b_ban, b_phong, b_cdanh, 'ns_td_dexuat_cn', 'DT_KEHOACH_NAM', ns_td_dexuat_cn_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        document.getElementById(b_kehoach_namId).disabled = false;
    }
    else {
        document.getElementById(b_kehoach_namId).disabled = true;
    }
}
// Nhập
function ns_td_dexuat_cn_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = "0";
    $get(b_namId).focus();
    var b_drop = form_Fctr_TEN_DTUONG(b_vungId, 'trangthai_pd');
    list_P_DAT(b_drop, '0');

    var b_kytudau = "DX", b_tenbang = "NS_TD_DEXUAT", b_tencot = "MA";
    hts_dungchung.Fs_AutoGenCode(b_kytudau, b_tenbang, b_tencot, ns_td_dexuat_P_GENCODE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_td_dexuat_cn_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }

        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        var b_trangthaipd = GridX_Fas_layGtri(b_grlkeId, b_hang, "trangthai_pd");
        if (b_trangthaipd == '1' || b_trangthaipd == '2') {
            form_P_LOI("loi:Đề xuất đã qua phê duyệt, bạn không thể sửa:loi"); return false;
        }
        var a_gt_hd = GridX_Fdt_cotGtri(b_grhdId), a_cot_hd = GridX_Fas_tenCot(b_grhdId);
        var b_nam = $get(b_nam_tkId).value, b_phong = lke_Fs_TRA($get(b_phong_tkId)), b_trangthai_pd = form_Fs_TEN_GTRI(b_vungtkId, 'trangthaitk_pd');
        sns_td.Fs_NS_TD_DEXUAT_CN_NH(form_Fs_nsd(), b_so_id, b_nam, b_phong, b_trangthai_pd, b_TrangKt, a_dt_ct, a_gt_hd, a_cot_lke, a_cot_hd, ns_td_dexuat_cn_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { throw (err); }
}
function ns_td_dexuat_cn_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_namId).focus();
        form_P_LOI("loi:Nhập thành công:loi");
    }
    return false;
}
// Gửi phê duyệt
function ns_td_dexuat_cn_P_GUI() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }

        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        var b_trangthaipd = GridX_Fas_layGtri(b_grlkeId, b_hang, "trangthai_pd");
        if (b_trangthaipd == '1' || b_trangthaipd == '2') {
            form_P_LOI("loi:Đề xuất đã qua phê duyệt, bạn không thể sửa:loi"); return false;
        }
        var a_gt_hd = GridX_Fdt_cotGtri(b_grhdId), a_cot_hd = GridX_Fas_tenCot(b_grhdId);
        var b_nam = $get(b_nam_tkId).value, b_phong = lke_Fs_TRA($get(b_phong_tkId)), b_trangthai_pd = form_Fs_TEN_GTRI(b_vungtkId, 'trangthaitk_pd');
        sns_td.Fs_NS_TD_DEXUAT_CN_GUI(form_Fs_nsd(), b_so_id, b_nam, b_phong, b_trangthai_pd, b_TrangKt, a_dt_ct, a_gt_hd, a_cot_lke, a_cot_hd, ns_td_dexuat_cn_P_GUI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { throw (err); }
}
function ns_td_dexuat_cn_P_GUI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_namId).focus();
        form_P_LOI("loi:Gửi phê duyệt thành công:loi");
    }
    return false;
}
// Xóa
function ns_td_dexuat_cn_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }

    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"),
        b_trangthaipd = GridX_Fas_layGtri(b_grlkeId, b_hang, "trangthai_pd");
    if (b_trangthaipd != '0') {
        form_P_LOI("loi:Đề xuất đã qua phê duyệt, bạn không thể xóa:loi"); return false;
    }
    if (b_so_id == "") ns_td_dexuat_cn_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId), a_cot_ct = GridX_Fas_tenCot(b_grhdId);
        var b_nam = $get(b_nam_tkId).value, b_phong = lke_Fs_TRA($get(b_phong_tkId)), b_trangthai_pd = form_Fs_TEN_GTRI(b_vungtkId, 'trangthaitk_pd');
        sns_td.Fs_NS_TD_DEXUAT_CN_XOA(form_Fs_nsd(), b_so_id, b_nam, b_phong, b_trangthai_pd, a_tso, a_cot, a_cot_ct, ns_td_dexuat_cn_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_td_dexuat_cn_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI("loi:Xóa thành công:loi");
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_td_dexuat_cn_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_td_dexuat_cn_P_CHUYEN_HANG(); }
    }
}
// Chuyển hàng
function ns_td_dexuat_cn_GR_lke_RowChange() {
    if (ns_td_dexuat_cn_choAct != 0) clearTimeout(ns_td_dexuat_cn_choAct);
    ns_td_dexuat_cn_choAct = setTimeout("ns_td_dexuat_cn_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_td_dexuat_cn_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_cot_ct = GridX_Fas_tenCot(b_grhdId);
        if (b_so_id == "0" || b_so_id == "") {
            form_P_MOI(b_vungId, "XGL");
            var b_kytudau = "DX", b_tenbang = "NS_TD_DEXUAT", b_tencot = "MA";
            hts_dungchung.Fs_AutoGenCode(b_kytudau, b_tenbang, b_tencot, ns_td_dexuat_P_GENCODE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else sns_td.Fs_NS_TD_DEXUAT_CN_CT(form_Fs_nsd(), b_so_id, a_cot, a_cot_ct, ns_td_dexuat_cn_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        $get(b_so_idId).value = b_so_id;
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_dexuat_cn_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] != "") GridX_datBang(b_grhdId, a_kq[1]);
}
// Liệt kê
function ns_td_dexuat_cn_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (ns_td_dexuat_cn_lkeCho != 0) clearTimeout(ns_td_dexuat_cn_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_td_dexuat_cn_P_LKE('K');
    }
    if ($get(b_grlkeId) != null) { clearTimeout(ns_td_dexuat_cn_lkeCho); ns_td_dexuat_cn_P_LKE(); }
}
function ns_td_dexuat_cn_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_nam = $get(b_nam_tkId).value, b_phong = lke_Fs_TRA($get(b_phong_tkId)), b_trangthai_pd = form_Fs_TEN_GTRI(b_vungtkId, 'trangthaitk_pd');
        sns_td.Fs_NS_TD_DEXUAT_CN_LKE(form_Fs_nsd(), b_nam, b_phong, b_trangthai_pd, a_tso, a_cot, ns_td_dexuat_cn_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_dexuat_cn_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}
function ns_td_dexuat_cn_P_SL_CANTUYEN() {
    try {
        var b_nam = $get(b_namId).value, b_thang = $get(b_thangId).value, b_phong = $get(b_phongId).value, b_cdanh = $get(b_cdanhId).value;
        sns_td.Fs_HDNS_DINHBIEN_NS_THANG(form_Fs_nsd(), b_nam, b_thang, b_phong, b_cdanh, ns_td_dexuat_cn_P_SL_CANTUYEN_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_dexuat_cn_P_SL_CANTUYEN_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq != "") $get(b_sl_cantuyenId).value = b_kq;
    $get(b_sl_cantuyenId).focus();
}
// them dong vao luoi
function loai_hd_HangLen() {
    GridX_chuyenHang(b_grhdId, -1);
    return false;
}
function loai_hd_HangXuong() {
    GridX_chuyenHang(b_grhdId, 1);
    return false;
}
function loai_hd_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grhdId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grhdId);
    return false;
}
function loai_hd_CatDong() {
    GridX_boChon(b_grhdId, 'C');
    return false;
}

function ns_td_dexuat_P_GENCODE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else { $get(b_maId).value = b_kq; }
}
function form_dong() {
    location.reload(false);
}