var b_lkeCho, b_choAct = 0, b_vungId, b_so_the_chon, b_aphong, b_akyluong, b_phong_tkId, b_vungtkId, b_kyluongId, b_namId, b_phongId,
    b_grlkeId, b_d_tuongId, b_slideId, b_gocId, b_ma_ctId, b_capId, b_ten_ctId, b_ten_form, b_tmf, b_ma_dvi, b_imgId, b_no_anhId, b_logoId,
    b_cdanh_qlId, b_ten_cdanh_qlId, b_gtId, b_phong_qlId, b_an_ngaydId, b_an_ngaycId;
function ns_cc_ma_ccnv_KD() {
    b_lkeCho = setInterval('ns_cc_ma_ccnv_P_LKE_CHO()', 200);
}

function ns_cc_ccnv_P_NAM() {
    try {
        var b_nam = form_Fs_TEN_GTRI(b_vungId, 'NAM');
        if (b_nam != "")
            stl_cc.Fs_NS_KYLUONG_CHUNG2_LKE(form_Fs_nsd(), window.name, b_nam, ns_cc_ccnv_P_NAM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_cc_ccnv_P_NAM_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_kyluong = form_Fs_TEN_ID(b_vungId, 'KYLUONG');
        drop_P_LKE(b_kyluong, b_kq);
        ns_cc_ccnv_P_LKE('');
    }
}

function ns_cc_ccnv_P_CT_KYLUONG() {
    try {
        var b_form = "ns_cc_ccnv", b_nam = "DT_NAM", b_thang = "DT_KY";
        hts_dungchung.Fs_NS_CC_KY(form_Fs_nsd(), b_form, b_nam, b_thang, ns_cc_ccnv_P_CT_KYLUONG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_ccnv_P_CT_KYLUONG_KQ(b_kq) {
    if (b_kq != "") {
        form_P_CH_TEXT(b_vungId, b_kq);
    }
    ns_cc_ccnv_P_KTRA("KYLUONG");
}

function ns_cc_ccnv_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "PHONG": b_maId = b_phongId; break;
            case "KYLUONG": b_maId = b_kyluongId; break;
            case "NAM": b_maId = b_namId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null) return;
        if (b_maTen == "KYLUONG") {
            $get(b_akyluong).value = form_Fs_TEN_GTRI(b_vungId, 'KYLUONG');
            var b_thang = form_Fs_TEN_GTRI(b_vungId, 'KYLUONG');

            ns_cc_ccnv_P_LKE('M');
        }
        else if (b_maTen == "PHONG") {
            $get(b_akyluong).value = form_Fs_TEN_GTRI(b_vungId, 'PHONG');
            ns_cc_ccnv_P_LKE('M');
        }
        else if (b_maTen == "NAM" || b_maTen == "PHONG") {
            ns_cc_ccnv_P_LKE('M');
        }
        else if (b_hang < 0) form_P_LOI_DICH("loi:Mã quản lý chưa đăng ký:loi");
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_ccnv_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_datTrang(b_grctId);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang < 0) return;
            var b_kyluong = form_Fs_TEN_GTRI(b_vungId, 'NAM');
            if (b_kyluong == "") {
                form_P_LOI("loi:Bạn chưa chọn năm:loi"); return false;
            }
            b_so_the_chon = a_tso[0];
            ns_thongtin_canbo(a_tso[0]);
        } else if (b_dtuong.indexOf("TAI_IMPORT") >= 0) {
            ns_cc_ma_ccnv_P_LKE('M');
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_thongtin_canbo(b_so_the) {
    try {
        var a_luoi = GridX_Fdt_cotGtri(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
        var b_kyluong = lke_Fs_TRA($get(b_kyluongId)), b_phong = lke_Fs_TRA($get(b_phongId));
        hts_dungchung.Fs_THONGTIN_CANBO_QD_KHOANG(b_so_the, b_kyluong, b_phong, a_luoi, a_cot, ns_thongtin_canbo_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_thongtin_canbo_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    if (a_kq[0] <= 0) {
        form_P_LOI("loi:Nhân viên " + b_so_the_chon + " Chưa có quyết định:loi"); return false;
    }
    GridX_datBang(b_grlkeId, a_kq[1]);

}

//lke
function ns_cc_ma_ccnv_P_LKE_CHO() {
    if (b_lkeCho != 0) clearTimeout(b_lkeCho);
    b_vungAnId = form_Fs_VUNG_ID('UPa_hi');
    b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
    b_kyluongId = form_Fs_TEN_ID(b_vungId, 'KYLUONG'); b_akyluong = form_Fs_VTEN_ID('UPa_hi', 'akyluong'); b_namId = form_Fs_TEN_ID(b_vungId, 'NAM');
    b_phongId = form_Fs_TEN_ID(b_vungId, 'PHONG'); b_an_ngaydId = form_Fs_VTEN_ID('UPa_hi', 'ngayd'), b_an_ngaycId = form_Fs_VTEN_ID('UPa_hi', 'ngayc');
    b_slideId = $get(b_grlkeId).getAttribute('slideId');
    GridX_taoScroll(b_grlkeId);
    b_ten_form = "ns_cc_ma_ccnv";
    ns_cc_ccnv_P_LKE('M');
}
function ns_cc_ccnv_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_nam = form_Fs_TEN_GTRI(b_vungId, 'NAM'),
            b_kyluong = form_Fs_TEN_GTRI(b_vungId, 'KYLUONG'),
            b_dtuong = form_Fs_TEN_GTRI(b_vungId, 'PHONG')
        stl_cc.Fs_NS_CC_CCNV_LKE(form_Fs_nsd(), window.name, b_nam, b_kyluong, b_dtuong, a_cot, a_tso, ns_cc_ccnv_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_cc_ccnv_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
}

//nhap
function ns_cc_ma_ccnv_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        a_cot_ct = GridX_Fdt_cotGtri(b_grlkeId);
        stl_cc.Fs_NS_CC_CCNV_NH(form_Fs_nsd(), b_so_id, b_TrangKt, a_dt_ct, a_cot_lke, a_cot_ct, ns_cc_ma_ccnv_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { throw (err); }
}
function ns_cc_ma_ccnv_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    form_P_LOI('loi:Ghi thành công:loi'); return false;
}

function ns_cc_ma_ccnv_HangLen(mode) {
    GridX_chuyenHang(b_grlkeId, -1);
    return false;
}
function ns_cc_ma_ccnv_HangXuong() {
    GridX_chuyenHang(b_grlkeId, 1);
    return false;
}
function ns_cc_ma_ccnv_CatDong() {

    GridX_boChon(b_grlkeId, 'C');
    return false;
}
function ns_cc_ma_ccnv_ChenDong(b_dk) {
    GridX_chenHang(b_grlkeId);
    return false;
}
function form_dong() {
    location.reload(false);
}

//IMPORT EXCEL
function ns_cc_ma_ccnv_P_Import() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var b_tenf = '/App_form/ns/ma/file_Import.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "ns_cc_ma_ccnv", "ns_cc_ma_ccnv_IMP", "Import công chuẩn theo nhân viên"]], null);
    form_P_LOI('');
    return false;
}
