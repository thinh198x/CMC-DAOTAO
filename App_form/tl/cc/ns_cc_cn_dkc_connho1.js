var ns_cc_cn_dkc_connho_lkeCho, b_vungId, b_grlkeId, b_slideId, b_so_theId, b_nsd, b_loai, b_ngayd_tkId, b_ngayc_tkId,
    b_sothe_thaytheId, b_nguoiduyetId, b_ngaydId, b_ngaycId, b_loiNhap = 0, ns_cc_cn_dkc_connho_choAct = 0, c_thongtin_nghi_choAct, b_calvId,
    b_so_the_tkId, b_ten_tkId, b_aphongId, b_akyluongId, b_phong_tkId, b_vungTkId, b_gio_bdId, b_gio_ktId, b_gchuId,
    b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C', b_ctyValue, b_ctrbeforId;
function ns_cc_cn_dkc_connho_P_KD(nsd) {
    b_nsd = nsd;
    ns_cc_cn_dkc_connho_lkeCho = setInterval('ns_cc_cn_dkc_connho_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "" || a_tso[0] == "FILE_HTOAN") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("SOTHE_THAYTHE") >= 0) {
            $get(b_sothe_thaytheId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
        }
        else if (b_dtuong.indexOf("SO_THE") >= 0) {
            $get(b_so_theId).value = a_tso[0];
            $get(b_gchuId).innerHTML = a_tso[1];
            ns_cc_cn_dkc_connho_P_KTRA("SO_THE");
        }
        else if (b_dtuong.indexOf("KQ") >= 0) {
            $get(b_so_theId).value = a_tso[0];
            $get(b_ngayxnId).innerHTML = a_tso[1];
            $get(b_ngaydId).innerHTML = a_tso[2];
            ns_cc_cn_dkc_connho_P_MA_KTRA();
            return false;
        } else if (b_dtuong.indexOf("TAI_IMPORT") >= 0) {
            ns_cc_cn_dkc_connho_P_LKE('K');
        }
    }
    catch (err) { form_P_LOI(err); }
}
// kiểm tra
function ns_cc_cn_dkc_connho_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {

            case "SO_THE": b_maId = b_so_theId; break;
            case "KYLUONG": b_maId = b_kyluongId; break;
            case "PHONG_TK": b_maId = b_phong_tkId; break;
            case "NAM": b_maId = b_namId; break;
            case "CA_LV": b_maId = b_calvId; break;
        }

        var b_ma = $get(b_maId);
        if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_cc_cn_dkc_connho_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_cc_cn_dkc_connho_TTCB();
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) {
                GridX_thoiA(b_grlkeId);
            }
            else { GridX_datA(b_grlkeId, b_hang); ns_cc_cn_dkc_connho_P_CHUYEN_HANG(); }
        } else if (b_maTen == "PHONG_TK") {
            $get(b_aphongId).value = b_ctyValue;
            $get(b_akyluongId).value = lke_Fs_TRA($get(b_kyluongId));
        } else if (b_maTen == "NAM") {
            ns_cc_cn_dkc_connho_P_NAM_C();
        } else if (b_maTen == "CA_LV") {
            var b_calv = lke_Fs_TRA($get(b_calvId));
            stl_ma.Fs_NS_TL_TLAP_LAMCA_BYMA(form_Fs_nsd(), b_calv, ns_cc_cn_dkc_connho_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_cn_dkc_connho_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    $get(b_gio_bdId).value = a_kq[0];
    $get(b_gio_ktId).value = a_kq[1];
}
function ns_cc_cn_dkc_connho_P_MA_KTRA() {
    try {
        var b_so_the = b_nsd;
        if (b_so_the != "") {
            var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_qt.Fs_NS_CC_CN_DKC_CONNHO_MA(form_Fs_nsd(), b_so_the, b_so_id, b_TrangKt, a_cot, ns_cc_cn_dkc_connho_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_cc_cn_dkc_connho_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) { form_P_MOI(b_vungId, "X"); }
    else { GridX_datA(b_grlkeId, b_hang); ns_cc_cn_dkc_connho_P_CHUYEN_HANG(); }
}

function ns_cc_cn_dkc_connho_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        b_loiNhap = 1;
    }
    else { form_P_DatGchu(b_gchuId, b_kq); b_loiNhap = 0; }
}
function ns_cc_cn_dkc_connho_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_so_theId).focus();
    return false;
}
//nhập
function ns_cc_cn_dkc_connho_P_NH() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 0) {
            var b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tt"));
            if (b_trangthai == '0' || b_trangthai == '1') { form_P_LOI('loi:Bản ghi đã gửi hoặc đã phê duyệt, không thể chỉnh sửa:loi'); return false; }
        }

        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);

        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        var b_so_the_tk = b_nsd, b_ten_tk = $get(b_ten_tkId).value; var b_phong_tk = lke_Fs_TRA($get(b_phong_tkId));
        sns_qt.Fs_NS_CC_CN_DKC_CONNHO_NH(form_Fs_nsd(), b_so_the_tk, b_ten_tk, b_phong_tk, "1", b_so_id, b_TrangKt, a_dt_ct, a_cot_lke, ns_cc_cn_dkc_connho_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { throw (err); }
}
function ns_cc_cn_dkc_connho_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_so_theId).focus();
        form_P_LOI("loi:Nhập thành công!:loi");
    }
    return false;
}
// xóa
function ns_cc_cn_dkc_connho_P_XOA() {

    var b_hang = GridX_Fi_timHangA(b_grlkeId);


    var b_so_the = $get(b_so_theId).value, b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));;
    if (b_hang < 1 || b_so_id == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); ns_cc_cn_dkc_connho_P_MOI(); return false; }
    else {
        if (b_hang > 0) {
            var b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tt"));
            if (b_trangthai == '0' || b_trangthai == '1') { form_P_LOI('loi:Bản ghi đã gửi hoặc đã phê duyệt, không thể xóa:loi'); return false; }
        }

        var b_ngayd_tk = $get(b_ngayd_tkId).value, b_ngayc_tk = $get(b_ngayc_tkId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_so_the_tk = b_nsd, b_ten_tk = $get(b_ten_tkId).value;
        sns_qt.Fs_NS_CC_CN_DKC_CONNHO_XOA(form_Fs_nsd(), b_so_the_tk, b_ten_tk, b_ngayd_tk, b_ngayc_tk, b_so_id, a_tso, a_cot, ns_cc_cn_dkc_connho_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_cc_cn_dkc_connho_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_cc_cn_dkc_connho_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_cc_cn_dkc_connho_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
        ns_cc_cn_dkc_connho_P_LKE();
    }
    return false;
}
//hủy
function ns_cc_cn_dkc_connho_P_HUY() {
    var r = confirm("Bạn có chắc chắn hủy không?");
    if (r == false) return false;
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_the = $get(b_so_theId).value, b_ngayd = $get(b_ngaydId).value;
    if (b_so_the == "") ns_cc_cn_dkc_connho_P_MOI();
    else {
        var b_ngayd_tk = $get(b_ngayd_tkId).value, b_ngayc_tk = $get(b_ngayc_tkId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_so_the_tk = b_nsd, b_ten_tk = $get(b_ten_tkId).value;
        sns_qt.Fs_NS_CC_CN_DKC_CONNHO_XOA(form_Fs_nsd(), b_so_the_tk, b_ten_tk, b_ngayd_tk, b_ngayc_tk, a_tso, a_cot, ns_cc_cn_dkc_connho_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
// chuyển hàng
function ns_cc_cn_dkc_connho_GR_lke_RowChange() {
    if (ns_cc_cn_dkc_connho_choAct != 0) clearTimeout(ns_cc_cn_dkc_connho_choAct);
    ns_cc_cn_dkc_connho_choAct = setTimeout("ns_cc_cn_dkc_connho_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_cc_cn_dkc_connho_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_the = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the"),
        b_ngayd = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ngayd"));
    if (b_ngayd == "") { form_P_MOI(b_vungId, "X"); }
    else sns_qt.Fs_NS_CC_CN_DKC_CONNHO_CT(form_Fs_nsd(), b_so_the, b_ngayd, ns_cc_cn_dkc_connho_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    form_P_GridX_TEXT(b_vungId, b_grlkeId);
    return false;
}
function ns_cc_cn_dkc_connho_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
// liệt kê
function ns_cc_cn_dkc_connho_P_LKE_CHO() {
    if (document.readyState === 'complete') {

        b_tt_phep = 0;
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungTkId = form_Fs_VUNG_ID('UPa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
            b_so_theId = form_Fs_TEN_ID(b_vungId, 'SO_THE'); b_calvId = form_Fs_TEN_ID(b_vungId, 'CA');
        b_so_the_tkId = form_Fs_TEN_ID(b_vungTkId, 'so_the_tk'), b_ten_tkId = form_Fs_TEN_ID(b_vungTkId, 'ten_tk');
        b_phong_tkId = form_Fs_TEN_ID(b_vungTkId, 'phong_tk'); b_ngayd_tkId = form_Fs_TEN_ID(b_vungTkId, 'ngayd_tk'); b_ngayc_tkId = form_Fs_TEN_ID(b_vungTkId, 'ngayc_tk');
        b_gio_bdId = form_Fs_TEN_ID(b_vungId, 'giod'); b_gio_ktId = form_Fs_TEN_ID(b_vungId, 'gioc');
        b_gchuId = form_Fs_VTEN_ID('', 'gchu'), b_moiId = form_Fs_VTEN_ID('', 'moi');
        b_aphongId = form_Fs_VTEN_ID('UPa_hi', 'aphong'), b_akyluongId = form_Fs_TEN_ID('UPa_hi', 'akyluong'),
            b_slideId = b_grlkeId + '_slide';
        lke_P_DAT($get(b_phong_tkId), 'TATCA' + '{' + 'Tất cả');
        form_F_GOC().P_MENUBf(window.name, 'M');
        vb_cctc_P_SL('', 'D', '0', ' ', ' ', 'T');
        b_ctyValue = "TATCA";
        $get(b_so_theId).value = b_nsd;
        ns_cc_cn_dkc_connho_P_LKE('K');
        if (document.readyState == 'complete') {
            if (ns_cc_cn_dkc_connho_lkeCho != 0) clearTimeout(ns_cc_cn_dkc_connho_lkeCho);
            b_slideId = $get(b_grlkeId).getAttribute('slideId');
            ns_cc_cn_dkc_connho_TTCB();
            //ns_cc_cn_dkc_connho_CT_KYLUONG();
        }
    }
}

function ns_cc_cn_dkc_connho_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        //var time = new Date();
        if (b_dk == 'K') {
            var b_so_the = $get(b_so_theId).value;
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            var b_so_the_tk = b_nsd, b_ten_tk = $get(b_ten_tkId).value;
            var b_ngayd_tk = $get(b_ngayd_tkId).value, b_ngayc_tk = $get(b_ngayc_tkId).value;
            sns_qt.Fs_NS_CC_CN_DKC_CONNHO_LKE(form_Fs_nsd(), b_so_the_tk, b_ten_tk, b_ngayd_tk, b_ngayc_tk, a_tso, a_cot, ns_cc_cn_dkc_connho_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
        else {
            var b_so_the = $get(b_so_theId).value;
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            var b_so_the_tk = b_nsd, b_ten_tk = $get(b_ten_tkId).value;
            var b_ngayd_tk = $get(b_ngayd_tkId).value, b_ngayc_tk = $get(b_ngayc_tkId).value;
            sns_qt.Fs_NS_CC_CN_DKC_CONNHO_LKE(form_Fs_nsd(), b_so_the_tk, b_ten_tk, b_ngayd_tk, b_ngayc_tk, a_tso, a_cot, ns_cc_cn_dkc_connho_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }

    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_cn_dkc_connho_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#'); slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        //if (lke_Fs_TRA($get(b_macc_nghiId)) != "") ns_cc_cn_dkc_connho_SC();
        return false;
    }
    b_fcho = 'X';
}

// lấy thông tin cán bộ
function ns_cc_cn_dkc_connho_TTCB() {
    try {
        var b_so_the = $get(b_so_theId).value;
        hts_dungchung.Fs_THONGTIN_CANBO(b_so_the, ns_cc_cn_dkc_connho_TTCB_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_cn_dkc_connho_TTCB_kq(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == "") { form_P_LOI("loi:Nhân viên chưa được làm quyết định:loi"); return false; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
// so sánh ngày
function ns_cc_cn_dkc_connho_KT_NGAY(tungay, denngay, loai, ten1, ten2) {
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
function ns_cc_cn_dkc_connho_Date(str) {
    var mdy = str.split('/');
    return new Date(mdy[2] + "/" + mdy[1] + "/" + mdy[0]);
}
function mydiff(date1, date2, interval) {
    var second = 1000, minute = second * 60, hour = minute * 60, day = hour * 24, week = day * 7;
    date1 = new Date(date1);
    date2 = new Date(date2);
    var timediff = date2 - date1;
    if (isNaN(timediff)) return NaN;
    switch (interval) {
        case "years": return date2.getFullYear() - date1.getFullYear();
        case "months": return (
            (date2.getFullYear() * 12 + date2.getMonth())
            -
            (date1.getFullYear() * 12 + date1.getMonth())
        );
        case "weeks": return Math.floor(timediff / week);
        case "days": return Math.floor(timediff / day);
        case "hours": return Math.floor(timediff / hour);
        case "minutes": return Math.floor(timediff / minute);
        case "seconds": return Math.floor(timediff / second);
        default: return undefined;
    }
}

function ns_cc_cn_dkc_connho_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function ns_cc_cn_dkc_connho_P_MAU() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'btn_excel_mau');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;

}
function ns_cc_cn_dkc_connho_FILE_Import() {
    var b_tenf = '/App_form/ns/ma/file_Import.aspx';
    form_P_MO(b_tenf, window.name + ',THAMSO', ['THAMSO', [window.name, 'THONGTIN_NGHI_IMP', null, "Import thông tin nghỉ"]], null);
    form_P_LOI('');
    return false;
}

// Cập nhật trạng thái
function ns_cc_cn_dkc_connho_P_Update() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")), b_ngayd = $get(b_ngaydId).value;
        if (b_hang < 1 || b_so_id == "") { form_P_LOI("Bạn phải chọn một bản ghi để hủy"); ns_cc_cn_dkc_connho_P_MOI(); return false; }
        else {
            b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "huydon"));
            if (b_trangthai == '1') { form_P_LOI('loi:Bản ghi ghi đã bị hủy, bạn không thể hủy đơn này:loi'); return false; }

            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            var b_so_the_tk = b_nsd, b_ten_tk = $get(b_ten_tkId).value, b_nam_tk = lke_Fs_TRA($get(b_nam_tkId)), b_kyluong = lke_Fs_TRA($get(b_kyluongId)), b_phong_tk = b_ctyValue;

            sns_qt.Fs_ns_cc_cn_dkc_connho_UP(form_Fs_nsd(), b_so_id, b_so_the_tk, b_ten_tk, b_nam_tk, b_kyluong, b_phong_tk, "1", a_tso, a_cot, ns_cc_cn_dkc_connho_Update_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_cc_cn_dkc_connho_Update_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        form_P_LOI("loi:Hủy đơn thành công:loi");
    }
    return false;
}
function ns_cc_cn_dkc_connho_P_NAM() {
    try {
        var b_nam = form_Fs_TEN_GTRI(b_vungTkId, 'NAM_TK');
        if (b_nam != "")
            stl_cc.Fs_NS_KYLUONG_CHUNG2_LKE(form_Fs_nsd(), window.name, b_nam, ns_cc_cn_dkc_connho_P_NAM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_cc_cn_dkc_connho_P_NAM_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        ns_cc_cn_dkc_connho_P_KTRA("KYLUONG_TK");
    }
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
        ns_cc_cn_dkc_connho_P_LKE('K');
        $get(b_aphongId).value = b_ctyValue;
        $get(b_akyluongId).value = lke_Fs_TRA($get(b_kyluongId));
        return false;
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
function form_dong() {
    location.reload(false);
}

function isTime(txtHour) {
    var data = C_NVL(txtHour.value);
    if (data == "") return true;

    if (data.indexOf(":") < 0) {
        data = formatTime(data);
        if (data != '')
            txtHour.value = data;
        else {
            txtHour.value = "";
            return false;
        }
    }

    var rxHourPattern = /^(\d{1,2})(:)(\d{1,2})$/;
    var dtArray = data.match(rxHourPattern); // is format OK?
    if (dtArray == null) {
        rxHourPattern = /^(\d{1,2})$/;
        dtArray = data.match(rxHourPattern);
    }
    if (dtArray == null) {
        txtHour.value = "";
        return false;
    }
    //Checks for hh:mm format.
    const hour = parseInt(dtArray[1], 10);
    var minute = 0;
    if (dtArray.length >= 4)
        minute = parseInt(dtArray[3], 10);
    if (hour < 0 || hour >= 24 || minute < 0 || minute >= 60) {
        txtHour.value = "";
        return false;
    }
    txtHour.value = pad(hour) + ":" + pad(minute);
    return true;
}
function formatTime(data) {
    if (data.indexOf(":") >= 0) return data;

    var b_length = data.length;
    if (b_length < 4) {
        if (b_length == 0)
            data = "00:00";
        else if (b_length == 1)
            data = "0" + data + ":00";
        else if (b_length == 2)
            data = data + ":00";
        else if (b_length == 3)
            data = data.substr(0, 2) + ":0" + data.substr(2);
    }
    else data = data.substr(0, 2) + ':' + data.substr(2);
    return data;
}
function pad(s) { return (s < 10) ? '0' + s : s; }

function ns_cc_cn_dkc_connho_P_GUI() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) { form_P_LOI("loi:Chưa chọn đăng ký cần gửi:loi"); return false; }
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "") { form_P_LOI("loi:Chưa chọn đăng ký cần gửi:loi"); return false; }
        var b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tt"));
        if (b_trangthai == "CG" || b_trangthai == "2" || b_trangthai == "0" || b_trangthai == "" || b_trangthai == null)
            sns_qt.Fs_CC_CN_DKC_CONNHO_GUI(form_Fs_nsd(), b_so_id, ns_cc_cn_dkc_connho_GUI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        else
            form_P_LOI("loi:Đăng ký đã được gửi hoặc phê duyệt:loi");
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_cn_dkc_connho_GUI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else form_P_LOI("loi:Gửi phê duyệt thành công:loi");
    ns_cc_cn_dkc_connho_P_LKE('K');
    return false;
}