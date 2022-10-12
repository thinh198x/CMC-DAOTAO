var ns_cp_lkeCho, b_doi, ns_cp_choAct, b_vungId, ns_test_choAct = 0, b_grlkeId, b_slideId, b_vungtkId, b_gocId, b_so_idId, b_cho_control = 0, b_so_theId,
    b_tenId, b_cdanh_cuId, b_phong_cuId, b_ma_tlId, b_ma_nlId, b_ma_blId, b_luong_cbId, b_thunhap_thangId, b_cong_tyId, b_phongId, b_cdanhId, b_ten_phongId, b_ten_cdanhId,
    b_hinhthucId, b_so_qdId, b_ngaydId, b_ngaycId, b_ttId, b_nguoi_kyId, b_cdanh_kyId, b_thuong_thangId, b_ngay_kyId, b_tentk_id, b_so_the_tkId, b_phong_tkId, b_ctyId, b_ctyValue, b_ctrbeforId;
function ns_cp_P_KD() {

    ns_cp_lkeCho = setInterval('ns_cp_P_LKE_CHO()', 200);
}
function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_so_theId).value = b_so_the;
            $get(b_tenId).value = b_ten;
            ns_cp_P_TTCB();
            ns_hdct_P_CB();
            ns_cp_P_LKE('K');
            b_doi = 1;
            clearTimeout(b_cho_control);
        }
    }
    catch (err) { b_doi = 0; }
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        b_doi = 0;
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
        } else if (b_dtuong.indexOf("SO_THE") >= 0) {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
        }
        else if (b_dtuong.indexOf("NGUOI_KY") >= 0) {
            ns_thongtin_nguoiky(a_tso[0], "NGUOI_KY");
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cp_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_t = b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_so_theId; form_P_MOI("", "XGL"); break;
            case "CONG_TY": b_ma = form_Fs_TEN_GTRI(b_vungId, 'cong_ty'); break;
        }
        b_chonId = b_maTen;
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        else if (b_maTen == "SO_THE") {
            ns_cp_P_TTCB(); ns_hdct_P_CB();
            return;
        } else if (b_maTen == "DONVI") {
            var b_cty = form_Fs_TEN_GTRI(b_vungId, 'donvi');
            var b_kq = "{";
            lke_P_DAT($get(form_Fs_TEN_ID('', 'phong')), b_kq);
            hts_dungchung.Fs_PHONG_LEVEL_DR(2, b_cty, 'DT_PHONG', 'ns_cp', ns_cb_P_KTRA_DR_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        } else if (b_dtuong.indexOf("NGUOI_KY") >= 0) {
            ns_thongtin_nguoiky(a_tso[0], "NGUOI_KY");
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cp_P_KTRA_DR(b_maTen) {
    try {
        var b_maId = "";
        b_t = b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "CONG_TY": b_ma = form_Fs_TEN_GTRI(b_vungId, 'cong_ty'); break;
            case "PHONG": b_ma = form_Fs_TEN_GTRI(b_vungId, 'phong'); break;
        }
        if (b_maTen == "CONG_TY") {
            var b_cty = form_Fs_TEN_GTRI(b_vungId, 'cong_ty');
            var b_kq = "{";
            lke_P_DAT($get(form_Fs_TEN_ID('', 'phong')), b_kq);
            hts_dungchung.Fs_PHONG_LEVEL_DR(2, b_cty, 'DT_PHONG', 'ns_cp', ns_cp_P_KTRA_DR_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        } else if (b_maTen == "PHONG") {
            var b_kq = "{";
            lke_P_DAT($get(form_Fs_TEN_ID('', 'cdanh')), b_kq);
            var b_cty = form_Fs_TEN_GTRI(b_vungId, 'cong_ty');
            var b_phong = form_Fs_TEN_GTRI(b_vungId, 'phong');
            if (b_phong != '')
                sns_qt.Fs_MA_CDANH_BY_PHONG_CP('ns_cp', b_cty, b_phong, ns_cp_P_CDANH_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }

    }
    catch (err) { form_P_LOI(err); }
}
function ns_cp_P_KTRA_DR_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        //ns_hdns_ma_vtcdanh_P_LKE();
    }
}
function ns_cp_P_CDANH_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
    }
}
function ns_cp_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
    }
    else { form_P_DatGchu(b_gchuId, b_kq); }
}
//sinh ma 
//function ns_cp_P_SOQD() {
//    try {
//        var b_ma_lqd = lke_Fs_TRA($get(b_hinhthucId));
//        var b_ngayhd = $get(b_ngaydsmId).value;
//        sns_qt.Fs_NS_HDCT_SO_QD(form_Fs_nsd(), b_ngayhd, b_ma_lqd, ns_cp_P_SOQD_KQ, P_LOI_CSDL, P_LOI_TGIAN);
//    }
//    catch (ex) { form_P_LOI(ex.message); }
//}
function ns_cp_P_SOQD_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq))
        form_P_LOI(b_kq);
    else $get(b_so_qdId).value = b_kq;
}

// Nhập
function ns_cp_P_MOI() {
    form_P_MOI(b_vungId, "GXLK");
    GridX_thoiA(b_grlkeId);
    return false;
}
function ns_cp_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var ktra = ktra_ngay(parseDate($get(b_ngaydId).value).getTime(), parseDate($get(b_ngaycId).value).getTime(), 1, "Ngày hiệu lực", "Ngày hết hiệu lực");
        if (ktra.length > 0) {
            ns_cp_P_NH_KQ(ktra);
            return false;
        }
        var dateNow = getDateNow();
        var ktraky = ktra_ngay(parseDate($get(b_ngay_kyId).value).getTime(), parseDate(dateNow).getTime(), 1, "Ngày ký QĐ", "ngày hiện tại");
        if (ktraky.length > 0) {
            ns_cp_P_NH_KQ(ktraky);
            return false;
        }
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 0) {
            b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tt"));
            if (b_trangthai == 'PD') { form_P_LOI('loi:Bản ghi đang ở trạng thái phê duyệt, không thể chỉnh sửa:loi'); return false; }
            if (b_trangthai == 'KPD') { form_P_LOI('loi:Bản ghi đang ở trạng thái không phê duyệt, không thể chỉnh sửa:loi'); return false; }
        }
        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        var b_so_the = $get(b_so_the_tkId).value, b_ten = $get(b_tentk_id).value, b_phong = lke_Fs_TRA($get(b_phong_tkId)), b_ngayd = $get(b_ngaydId).value,
            b_ngayc = $get(b_ngaycId).value, b_tt = lke_Fs_TRA($get(b_ttId));

        sns_qt.Fs_NS_CP_NH(form_Fs_nsd(), b_so_id, b_so_the, b_ten, b_ctyValue, b_ngayd, b_ngayc, b_tt, b_TrangKt, a_dt_ct, a_cot_lke, ns_cp_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { throw (err); }
}
function ns_cp_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        form_P_LOI("loi:Nhập thành công!:loi");
        var message = confirm("Bạn muốn làm quyết định nghỉ việc cho CBNV không?");
        if (message == false) { return false; }
        var b_tenf = '/App_form/ns/qt/ns_tv.aspx';
        var b_so_the = $get(b_so_theId).value, b_ten = $get(b_tenId).value, b_phong = lke_Fs_TRA($get(b_phongId));
        //form_P_MO(b_tenf, window.name, ["THAMSO_CB", [b_so_the, b_ten, b_phong, "NS_TV", "Quản lý thôi việc"]], null);
        form_P_MO(b_tenf, window.name + ',THAMSO', ['THAMSO', [b_so_the, b_ten, b_phong, 'NS_TV', null, "Quản lý thôi việc"]], null);
    }
    return false;
}
// Xóa
function ns_cp_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); ns_cp_P_MOI(); return false; }
    else {
        b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tt"));
        if (b_trangthai == 'PD') { form_P_LOI('loi:Bản ghi đang ở trạng thái phê duyệt, không thể xóa:loi'); return false; }
        if (b_trangthai == 'KPD') { form_P_LOI('loi:Bản ghi đang ở trạng thái không phê duyệt, không thể xóa:loi'); return false; }

        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_so_the = $get(b_so_the_tkId).value, b_ten = $get(b_tentk_id).value, b_phong = lke_Fs_TRA($get(b_phong_tkId)), b_ngayd = $get(b_ngaydId).value, b_ngayc = $get(b_ngaycId).value, b_tt = $get(b_ttId).value;
        sns_qt.Fs_NS_CP_XOA(form_Fs_nsd(), b_so_id, b_so_the, b_ten, b_ctyValue, b_ngayd, b_ngayc, b_tt, a_tso, a_cot, ns_cp_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_cp_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_cp_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_cp_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
    return false;
}
//Chuyển hàng 
function ns_cp_GR_lke_RowChange() {
    if (ns_cp_choAct != 0) clearTimeout(ns_cp_choAct);
    ns_cp_choAct = setTimeout("ns_cp_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_cp_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "0" || b_so_id == "") { form_P_MOI(b_vungId, "XGL"); }
    else sns_qt.Fs_NS_CP_CT(form_Fs_nsd(), b_so_id, ns_cp_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function ns_cp_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
//Liệt kê
function ns_cp_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ns_cp_lkeCho != 0) clearTimeout(ns_cp_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'); b_vungtkId = form_Fs_VUNG_ID('UPa_tk'),
        b_so_theId = form_Fs_TEN_ID(b_vungId, 'so_the'), b_tenId = form_Fs_TEN_ID(b_vungId, 'ten'),
        b_ma_tlId = form_Fs_TEN_ID(b_vungId, 'ma_tl'), b_ma_nlId = form_Fs_TEN_ID(b_vungId, 'ma_nl'), b_ma_blId = form_Fs_TEN_ID(b_vungId, 'ma_bl'),
        b_luong_cbId = form_Fs_TEN_ID(b_vungId, 'luong_cb'), b_thunhap_thangId = form_Fs_TEN_ID(b_vungId, 'thunhap_thang'), b_thuong_thangId = form_Fs_TEN_ID(b_vungId, 'thuong_thang'),
        b_ten_phongId = form_Fs_TEN_ID(b_vungId, 'phong_cu'), b_ten_cdanhId = form_Fs_TEN_ID(b_vungId, 'cdanh_cu'),
        b_cong_tyId = form_Fs_TEN_ID(b_vungId, 'cong_ty'), b_phongId = form_Fs_TEN_ID(b_vungId, 'phong'),
        b_phong_tkId = form_Fs_TEN_ID(b_vungtkId, 'phong_tk'), b_ngaydId = form_Fs_TEN_ID(b_vungtkId, 'ngayd_tk'), b_ngaydsmId = form_Fs_TEN_ID(b_vungtkId, 'NGAYD'),
        b_cdanhId = form_Fs_TEN_ID(b_vungId, 'cdanh'), b_hinhthucId = form_Fs_TEN_ID(b_vungId, 'hinhthuc'),
        b_so_the_tkId = form_Fs_TEN_ID(b_vungtkId, 'so_the_tk'), b_tentk_id = form_Fs_TEN_ID(b_vungtkId, 'ten_tk'),
        b_so_qdId = form_Fs_TEN_ID(b_vungId, 'so_qd'),
        b_ngaycId = form_Fs_TEN_ID(b_vungtkId, 'ngayc_tk'), b_ttId = form_Fs_TEN_ID(b_vungtkId, 'tt_tk');
        b_nguoi_kyId = form_Fs_TEN_ID(b_vungId, 'nguoi_ky'), b_cdanh_kyId = form_Fs_TEN_ID(b_vungId, 'cdanh_ky'),
        b_ngay_kyId = form_Fs_TEN_ID(b_vungId, 'ngay_ky');
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        lke_P_DAT($get(b_phong_tkId), 'TATCA' + '{' + 'Tất cả');
        form_F_GOC().P_MENUBf(window.name, 'M');
        vb_cctc_P_SL('', 'D', '0', ' ', ' ', 'T');
        b_ctyValue = "TATCA";
        ns_cp_P_LKE('K');
    }
}
function ns_cp_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_so_the = $get(b_so_the_tkId).value, b_ten = $get(b_tentk_id).value, b_phong = lke_Fs_TRA($get(b_phong_tkId)),
            b_ngayd = $get(b_ngaydId).value, b_ngayc = $get(b_ngaycId).value, b_tt = form_Fs_TEN_GTRI(b_vungtkId, 'tt_tk');
        sns_qt.Fs_NS_CP_LKE(form_Fs_nsd(), b_so_the, b_ten, b_ctyValue, b_ngayd, b_ngayc, b_tt, a_tso, a_cot, ns_cp_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_cp_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
// Thông tin người ký
function ns_thongtin_nguoiky(b_so_the, b_loai) {
    try {
        var b_listcotcu = "", b_listcotmoi = "";
        if (b_loai == "NGUOI_KY") { b_kt_loai = "NGUOI_KY"; b_listcotcu = "SO_THE,TEN_CDANH", b_listcotmoi = "NGUOI_KY,CDANH_KY" }
        else { b_kt_loai = ""; b_listcotcu = "SO_THE,TEN,TEN_CDANH,TEN_PHONG", b_listcotmoi = "SO_THE,TEN,TEN_CDANH,TEN_PHONG" }
        hts_dungchung.Fs_THONGTIN_CANBO_HD(b_so_the, b_listcotcu, b_listcotmoi, ns_thongtin_nguoiky_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_thongtin_nguoiky_kq(b_kq) {
    if (b_kq == "") {
        if (b_kt_loai == "NGUOI_KY") {
            $get(b_nguoi_kyId).value = ""; $get(b_ten_cdanhnkId).value = "";
        }

    }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
function ns_cp_P_TTCB() {
    try {
        var b_so_the = $get(b_so_theId).value;
        hts_dungchung.Fs_NS_CB_TTCB(b_so_the, ns_cp_P_TTCB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cp_P_TTCB_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq) || b_kq == "") { form_P_MOI(b_vungId, "GXL"); form_P_LOI(b_kq); return false; }
    var a_kq = Fas_ChMang(b_kq, '#');
    $get(b_tenId).value = a_kq[1];
    $get(b_ten_phongId).value = a_kq[7];
    $get(b_ten_cdanhId).value = a_kq[8];

    //$get(b_ma_tlId).value = a_kq[9];
    //$get(b_ma_nlId).value = a_kq[10];
    //$get(b_ma_blId).value = a_kq[11];

    //$get(b_luong_cbId).value = a_kq[12];
    //$get(b_thunhap_thangId).value = a_kq[13];
    //$get(b_thuong_thangId).value = a_kq[14];
    return false;
}
// Thông tin lương mới nhất
function ns_hdct_P_CB() {
    try {
        b_so_the = $get(b_so_theId).value;
        b_ngayd = getDateNow();
        sns_qt.Fs_NS_HDCT_CB(form_Fs_nsd(), b_so_the, b_ngayd, ns_hdct_P_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdct_P_CB_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    if (a_kq == "") return;
    else { // lấy dữ liệu vào con troll lương cũ
        // làm mới các control thang bảng lương thay đổi
        $get(b_ma_tlId).value = ""; $get(b_ma_nlId).value = ""; $get(b_ma_blId).value = "";
        $get(b_luong_cbId).value = ""; $get(b_thunhap_thangId).value = ""; $get(b_thuong_thangId).value = "";
        // đẩy dữ liệu vào các controll thang bảng lương hiện tại
        $get(b_luong_cbId).value = a_kq[3];
        $get(b_thunhap_thangId).value = a_kq[4];
        $get(b_thuong_thangId).value = a_kq[5];
        $get(b_ma_tlId).value = a_kq[7];
        $get(b_ma_nlId).value = a_kq[8];
        $get(b_ma_blId).value = a_kq[9];
    }

    return false;
}
//Kiểm tra ngày tháng
function ns_cp_P_NGAY(str) {
    var mdy_str = str.split('/');
    var mdy_str = mdy_str[2] + mdy_str[1] + mdy_str[0];
    var mdy_str = parseInt(mdy_str);
    var dateht = new Date();
    var m = "0" + (1 + dateht.getMonth());
    var y = parseInt("2" + dateht.getYear()) - 100;
    var d = parseInt("0" + dateht.getDate());
    var dmy = y + m + d;
    var dmy = parseInt(dmy);
    var kq = mdy_str - dmy;
    if (kq > 0) {
        return 'loi:Ngày ký không được lớn hơn ngày hiện tại:loi';
    }
    return "";
}
function ktra_ngay(tungay, denngay, loai, ten1, ten2) {
    if (denngay == "" || denngay == null) {
        return "";
    }
    if (loai == 1 && tungay > denngay) {
        return "loi: " + ten1 + " không được lớn hơn " + ten2 + " :loi";
    } else if (loai == 2 && tungay >= denngay) {
        return "loi: " + ten1 + " không được nhỏ hơn hoặc bằng " + ten2 + " :loi";
    }
    return "";
}
function parseDate(str) {
    var mdy = str.split('/');
    return new Date(mdy[2], mdy[1], mdy[0]);
}
function getDateNow() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();
    if (dd < 10) {
        dd = '0' + dd;
    }
    if (mm < 10) {
        mm = '0' + mm;
    }
    var datenow = dd + '/' + mm + '/' + yyyy;
    return datenow;
}
function form_dong() {
    location.reload(false);
}

function vb_cctc_P_CLICK(b_event, b_id) {
    b_event.stopPropagation();
    var b_targetClassNam = b_event.target.className;
    if (b_targetClassNam == "ico_bptt") {
        var b_ctr = $get(b_id), b_div = $get(b_id + '_Div');
        var a_tso = Attribute_Fas_LAY(b_ctr, 'loai,cap,dvi,ma,ma_ct');
        if (b_ctrbeforId != null) b_ctrbeforId.style.fontWeight = "100";
        b_ctr.style.fontWeight = "700";
        b_ctrbeforId = b_ctr;
        b_ctyValue = a_tso[3];
        ns_cp_P_LKE('K'); return false;
    }
    else {
        var b_ctr = $get(b_id), b_div = $get(b_id + '_Div');
        var a_tso = Attribute_Fas_LAY(b_ctr, 'loai,cap,dvi,ma,ma_ct');
        if (a_tso[0] == 'A') return false;
        if (a_tso[0] != 'C') {
            if (b_div == null) vb_cctc_P_SL(b_id, a_tso[0], a_tso[1], a_tso[2], a_tso[3]);
            else {
                b_id = (C_NVL(b_div.style.display) == '') ? '' : b_id;
                vb_cctc_HIEN(a_tso[4], b_id);
            }
        }
    }
    return false;
}

function ns_cp_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(form_Fs_TEN_ID('', 'so_the_luu')).value = $get(b_so_the_tkId).value;
    $get(form_Fs_TEN_ID('', 'ten_luu')).value = $get(b_tentk_id).value;
    $get(form_Fs_TEN_ID('', 'phong_luu')).value = lke_Fs_TRA($get(b_phong_tkId));
    $get(form_Fs_TEN_ID('', 'tt_tk_luu')).value = form_Fs_TEN_GTRI(b_vungtkId, 'tt_tk');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}