var ns_tt_bh_lkeCho, b_vungId, b_vungtkId, b_grlkeId, b_slideId, b_gocId, b_timId, b_gchuId, b_phongId, b_cdanh, b_ho_ten, b_loaibd, b_noikham, b_nhapCho = 0,
    b_cho_control = 0, ns_tt_bh_choAct = 0, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C', b_tinhtrang_soId, b_tinhtrang_theId, b_sothe_tkId, b_ten_tkId, b_nghi_viec_tkId,
    b_ngayhlId, b_ngayhhlId, b_tuthang_bhxhId, b_denthang_bhxhId, b_tuthang_bhytId, b_denthang_bhytId, b_ctrbeforId, b_ctyValue, b_aphongId, b_tuthang_bhtnId, b_denthang_bhtnId;
function ns_tt_bh_P_KD() {
    ns_tt_bh_lkeCho = setInterval('ns_tt_bh_P_LKE_CHO()', 200);
}
// Kiểm tra
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "" || a_tso[0] == "FILE_HTOAN") return;
        b_dtuong = b_dtuong.toUpperCase();
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[0];
        var b_hso = a_tso[1];
        b_doi = 0;
        if (b_dtuong.indexOf("SO_THE") >= 0 || b_dtuong.indexOf("THAMSO") >= 0) {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "','" + a_tso[6] + "')", 200);
        }
        else if (b_dtuong.indexOf("NOIKHAM_CHUABENH") >= 0) {
            $get(b_noikham).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_noikham).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}
function P_cho(b_so_the, b_ten, b_phong, b_chucdanh) {
    try {
        if (b_doi == 0) {
            $get(b_gocId).value = b_so_the;
            $get(b_ho_ten).value = b_ten;
            $get(b_phongId).value = b_phong;
            $get(b_cdanh).value = b_chucdanh;
            $get(b_gchuId).innerhtml = b_ten;
            $get(b_gocId).focus();
            ns_thongtin_canbo();
            ns_tt_bh_P_LKE('K');
            b_doi = 1;
            clearTimeout(b_cho_control);
        }
    }
    catch (err) {
        b_doi = 0;
    }
}
function ns_tt_bh_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; form_P_MOI("", "XGL"); break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_tt_bh_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_thongtin_canbo($get(b_maId).value, b_maTen);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tt_bh_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
    $get(b_gocId).value = "";
}
function ns_tt_bh_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_cd.Fs_NS_TT_BH_MA(b_ma, b_TrangKt, a_cot, ns_tt_bh_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tt_bh_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_tt_bh_P_CHUYEN_HANG(); }
}
// Nhập
function ns_tt_bh_P_MOI() {
    $get(b_tinhtrang_theId).value = ""; $get(b_tinhtrang_soId).value = "";
    form_P_MOI(b_vungId, "GXL");
    $get(b_gocId).focus();
    return false;
}
function ns_tt_bh_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId); b_so_id = "0";
    if (b_loi != "") { form_P_LOI(b_loi); return false; }

    var ktra = ktra_ngay(parseDate($get(b_ngayhlId).value).getTime(), 1, "Ngày hiệu lực");
    if (ktra.length > 0) {
        ns_TT_BH_P_NH_KQ(ktra);
        return false;
    }
    var ktra = sosanh_Date($get(b_tuthang_bhxhId).value, $get(b_denthang_bhxhId).value);
    if (ktra.length > 0) {
        form_P_LOI(ktra);
        return false;
    }
    var ktra = sosanh_Date($get(b_tuthang_bhytId).value, $get(b_denthang_bhytId).value);
    if (ktra.length > 0) {
        form_P_LOI(ktra);
        return false;
    }
   
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang >= 0) b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    var b_phong = b_ctyValue;
    var a_tso = slide_Faobj_TUDEN(b_slideId), b_so_the = $get(b_sothe_tkId).value, b_ten = $get(b_ten_tkId).value, b_nghi_viec = $get(b_nghi_viec_tkId).value;
    sns_cd.Fs_NS_TT_BH_NH(b_so_id, b_phong,b_so_the, b_ten, b_nghi_viec, b_TrangKt, a_dt_ct, a_cot, a_tso, ns_TT_BH_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_TT_BH_P_NH_KQ(b_kq) {
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
function ns_tt_bh_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var so_the = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the"));
    if (so_the == "") ns_tt_bh_P_MOI("XGL");
    else {
        var a_tso = slide_Faobj_TUDEN(b_slideId), a_cot = GridX_Fas_tenCot(b_grlkeId),
             b_sothe_tk = $get(b_sothe_tkId).value, b_ten = $get(b_ten_tkId).value, b_nghi_viec = $get(b_nghi_viec_tkId).value;
        var b_phong = b_ctyValue;
        sns_cd.Fs_NS_TT_BH_XOA(b_phong,so_the, b_sothe_tk, b_ten, b_nghi_viec, a_tso, a_cot, ns_tt_bh_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_tt_bh_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        $get(b_gocId).value = ""; form_P_LOI('loi:Xóa thành công!:loi');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_tt_bh_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_tt_bh_P_CHUYEN_HANG(); }
    }
}
// chuyển hàng
function ns_tt_bh_GR_lke_RowChange() {
    if (ns_tt_bh_choAct != 0) clearTimeout(ns_tt_bh_choAct);
    ns_tt_bh_choAct = setTimeout("ns_tt_bh_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_tt_bh_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var so_the = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the"));
        if (so_the == "") ns_tt_bh_P_MOI();
        else sns_cd.Fs_NS_TT_BH_CT(so_the, ns_tt_bh_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tt_bh_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
// Liệt kê
function ns_tt_bh_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (ns_tt_bh_lkeCho != 0) clearTimeout(ns_tt_bh_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'),
        b_vungtkId = form_Fs_VUNG_ID('UPa_tk'),
        b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_sothe_tkId = form_Fs_TEN_ID(b_vungtkId, 'so_the_tk'),
        b_ten_tkId = form_Fs_TEN_ID(b_vungtkId, 'ten_tk'),
        b_nghi_viec_tkId = form_Fs_TEN_ID(b_vungtkId, 'nghi_viec_tk'),
        b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE'),
        b_phongId = form_Fs_TEN_ID(b_vungId, 'PHONG'),
        b_cdanh = form_Fs_TEN_ID(b_vungId, 'CDANH'),
        b_noikham = form_Fs_TEN_ID(b_vungId, 'noikham_chuabenh'),
        b_tinhtrang_soId = form_Fs_TEN_ID(b_vungId, 'tinhtrang_so'),
        b_tinhtrang_theId = form_Fs_TEN_ID(b_vungId, 'tinhtrang_the');
        b_ngayhlId = form_Fs_TEN_ID(b_vungId, 'ngay_hl'),
        b_tuthang_bhxhId = form_Fs_TEN_ID(b_vungId, 'tuthang_bhxh'),
        b_denthang_bhxhId = form_Fs_TEN_ID(b_vungId, 'denthang_bhxh'),
        b_tuthang_bhytId = form_Fs_TEN_ID(b_vungId, 'tuthang_bhyt'),
        b_denthang_bhytId = form_Fs_TEN_ID(b_vungId, 'denthang_bhyt'),
        b_gchuId = form_Fs_VTEN_ID('', 'gchu1');
        b_ho_ten = form_Fs_VTEN_ID(b_vungId, 'ho_ten');
        b_aphongId = form_Fs_VTEN_ID('UPa_hi', 'aphong'),
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        form_F_GOC().P_MENUBf(window.name, 'M');
        vb_cctc_P_SL('', 'D', '0', ' ', ' ', 'T');
        b_ctyValue = "TATCA";
        ns_tt_bh_P_LKE('K');
    }
}
function ns_tt_bh_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_so_the = $get(b_sothe_tkId).value, b_ten = $get(b_ten_tkId).value, b_nghi_viec = $get(b_nghi_viec_tkId).value;
        var b_phong = b_ctyValue;
        sns_cd.Fs_NS_TT_BH_LKE(a_tso, a_cot, b_phong,b_so_the, b_ten, b_nghi_viec, ns_tt_bh_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tt_bh_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
// Thông tin nhân viên
function ns_thongtin_canbo() {
    try {
        var b_sothe = $get(b_gocId).value;
        hts_dungchung.Fs_THONGTIN_CANBO(b_sothe, ns_thongtin_canbo_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_thongtin_canbo_kq(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
// Import
function ns_tt_bh_Import() {
    var b_tenf = '/App_form/ns/ma/file_Import.aspx';
    form_P_MO(b_tenf, window.name + ',THAMSO', ['THAMSO', [window.name, 'NS_BH', null, "Import thông tin bảo hiểm"]], null);
    form_P_LOI('');
    return false;
}
// kiem tra ngày 
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
function addDays(date, days) {
    date = date.substring(6, 10) + "-" + date.substring(3, 5) + "-" + date.substring(0, 2);
    var result = new Date(date);
    result.setMonth(result.getMonth() + Number(days));
    result.setDate(result.getDate() - Number(1));
    var kq = NG_CNG(result);
    return kq;
}
function sosanh_Date(str1, str2) {
    if (str1 == "" || str2 == "")
        return "";
    else {
        var mdy_str1 = str1.split('/');
        if (mdy_str1[0] < 0 || mdy_str1[0] > 12) {
            return "loi:Tháng của từ tháng không được nhỏ hơn 0 và lơn hơn 12:loi";
        } else if (mdy_str1[1].length != 4) {
            return "loi:Năm của từ tháng không đúng định dạng:loi";
        }
        var mdy_str1 = mdy_str1[1] + mdy_str1[0];
        var mdy_str1 = parseInt(mdy_str1);


        var mdy_str2 = str2.split('/');
        if (mdy_str2[0] < 0 || mdy_str2[0] > 12) {
            return "loi: Tháng của đến tháng không được nhỏ hơn 0 và lơn hơn 12:loi";
        } else if (mdy_str2[1].length != 4) {
            return "loi:Năm của đến tháng không đúng định dạng:loi";
        }
        var mdy_str2 = mdy_str2[1] + mdy_str2[0];
        var mdy_str2 = parseInt(mdy_str2);
        if (mdy_str2 - mdy_str1 < 0) {
            return "loi:Từ tháng không được lớn hơn đến tháng:loi";
        } else return "";
    }
} 
function vb_cctc_P_CLICK(b_event, b_id) {
    b_event.stopPropagation();
    var b_targetClassNam = b_event.target.className;
    if (b_targetClassNam == "ico_bptt") {
        var b_ctr = $get(b_id), b_div = $get(b_id + '_Div');
        var a_tso = Attribute_Fas_LAY(b_ctr, 'loai,cap,dvi,ma,ma_ct');
        if (b_ctrbeforId != null) b_ctrbeforId.style.fontWeight = "100";
        $get(b_aphongId).value = b_ctyValue;
        b_ctr.style.fontWeight = "700";
        b_ctrbeforId = b_ctr;
        b_ctyValue = a_tso[3];
        // load lại dữ liệu 
        $get(b_aphongId).value = b_ctyValue;
        if (b_ctyValue != "") ns_tt_bh_P_LKE('K');
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
//xuat excel
function ns_tt_bh_P_EXCEL() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'XuatExcel');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}