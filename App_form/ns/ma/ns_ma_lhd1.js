var ns_ma_lhd_lkeCho, b_vungId, b_grlkeId, b_slideId, b_attrangId, b_gocId, b_timId, b_tmf, b_ma_dvi, b_tenId, ns_ma_lhd_choAct = 0;
function ns_ma_lhd_P_KD(b_dvi) {
    b_tmf = form_Fs_TM('f'); b_ma_dvi = b_dvi;
    ns_ma_lhd_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'), b_tenId = form_Fs_TEN_ID(b_vungId, 'TEN');
    b_is_thue_lt = form_Fs_TEN_ID(b_vungId, 'is_thue_lt'), b_is_thue_pt = form_Fs_TEN_ID(b_vungId, 'is_thue_pt'), b_thue_pt = form_Fs_TEN_ID(b_vungId, 'thue_pt');
    b_slideId = b_grlkeId + '_slide'
    ns_ma_lhd_lkeCho = setInterval('ns_ma_lhd_P_LKE_CHO()', 200);
    $get(b_thue_pt).style.display = "none";// $get("ctl00_ContentPlaceHolder1_lbltile").style.display = "none";
}
// Mã
function ns_ma_lhd_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            $get(b_gocId).value = ($get(b_gocId).value).validate_Ma();
            var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_ma_lhd_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_ma_lhd_P_CHUYEN_HANG(); }
            b_ten.focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_lhd_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_ma_ch.Fs_NS_MA_LHD_MA(form_Fs_nsd(), b_ma, b_TrangKt, a_cot, ns_ma_lhd_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_lhd_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_ma_lhd_P_CHUYEN_HANG(); }
}
// Nhập
function ns_ma_lhd_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    var b_kytudau = "LHD", b_tenbang = "NS_MA_LHD", b_tencot = "MA";
    hts_dungchung.Fs_AutoGenCode(b_kytudau, b_tenbang, b_tencot, ns_ma_lhd_P_GENCODE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    GridX_thoiA(b_grlkeId);
    var b_drop = form_Fctr_TEN_DTUONG(b_vungId, 'tt');
    list_P_DAT(b_drop, 'A');
    $get(b_thue_pt).style.display = "none";
    $get(b_is_thue_lt).value = "X";
    // $get("ctl00_ContentPlaceHolder1_lbltile").style.display = "none";
    $get(b_gocId).focus();
    return false;
}
function ns_ma_lhd_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_ma_ch.Fs_NS_MA_LHD_NH(form_Fs_nsd(), b_TrangKt, a_dt_ct, a_cot, ns_ma_lhd_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_ma_lhd_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        form_P_LOI("loi:Nhập thành công!:loi");
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
    }
    return false;
}
// Xóa
function ns_ma_lhd_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId), b_loi = form_Fs_TEXT_KTRA(b_vungId);;
    if (b_hang < 1) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    if (b_hang < 1) return;
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    if (b_ma == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); ns_ma_lhd_P_MOI(); return false; }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_NS_MA_LHD_XOA(form_Fs_nsd(), b_ma, a_tso, a_cot, ns_ma_lhd_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_ma_lhd_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_ma_lhd_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_ma_lhd_P_CHUYEN_HANG(); }
        form_P_LOI('loi:Xóa thành công!:loi');
    }
}
// Chuyển hàng
function ns_ma_lhd_GR_lke_RowChange() {
    if (ns_ma_lhd_choAct != 0) clearTimeout(ns_ma_lhd_choAct);
    ns_ma_lhd_choAct = setTimeout("ns_ma_lhd_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_ma_lhd_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        if (b_ma == "") {
            //$get(b_thue_pt).style.display = "none";
            //$get("ctl00_ContentPlaceHolder1_lbltile").style.display = "none";
            form_P_MOI(b_vungId, "XGL");
            var b_kytudau = "LHD", b_tenbang = "NS_MA_LHD", b_tencot = "MA";
            hts_dungchung.Fs_AutoGenCode(b_kytudau, b_tenbang, b_tencot, ns_ma_lhd_P_GENCODE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        } else {
            form_P_GridX_TEXT(b_vungId, b_grlkeId);
            if ($get(b_is_thue_pt).value == 'X') {
                //$get(b_thue_pt).style.display = "";
                //$get(b_is_thue_lt).value = "";
                //$get("ctl00_ContentPlaceHolder1_lbltile").style.display = "";
            } else {
                //$get(b_is_thue_pt).style.display = "";
                //$get(b_thue_pt).style.display = "none";
                //$get("ctl00_ContentPlaceHolder1_lbltile").style.display = "none";
            }
        }
    }
    catch (err) { form_P_LOI(err); }
}
// Liệt kê
function ns_ma_lhd_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        ns_ma_lhd_P_MOI();
        if (ns_ma_lhd_lkeCho != 0) clearTimeout(ns_ma_lhd_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_ma_lhd_P_LKE('K');
    }
}
function ns_ma_lhd_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_NS_MA_LHD_LKE(form_Fs_nsd(), a_tso, a_cot, ns_ma_lhd_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_ma_lhd_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_ma_lhd_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function ns_ma_nuoc_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function ns_ma_lhd_P_GENCODE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else $get(b_gocId).value = b_kq;
}
function ns_ms_lhd_P_KTRA_THUE(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        if (b_maTen == "IS_THUE_LT") {
            $get(b_thue_pt).style.display = "none";
            $get(b_is_thue_pt).value = "";
            $get(b_thue_pt).value = "";
            $get("ctl00_ContentPlaceHolder1_lbltile").style.display = "none";

        }
        else if (b_maTen == "IS_THUE_PT") {
            if ($get(b_is_thue_pt).value == 'X') {
                $get(b_thue_pt).style.display = "";
                $get(b_is_thue_lt).value = "";
                $get("ctl00_ContentPlaceHolder1_lbltile").style.display = "";
            } else {
                $get(b_is_thue_pt).style.display = "";
                $get(b_thue_pt).style.display = "none";
                $get(b_thue_pt).value = "";
                $get("ctl00_ContentPlaceHolder1_lbltile").style.display = "none";
            }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function form_dong() {
    location.reload(false);
}
function ns_ma_lhd_FI_NH() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) {
            form_P_LOI('loi:Vui lòng chọn loại hợp đồng:loi')
            return false;
        }
        var b_tenf = '/App_form/ns/ma/file_Import_chung.aspx';
        var b_f = C_NVL($get(b_gocId).value), b_nd = C_NVL($get(b_tenId).value);
        b_t = '/' + b_f;
        form_P_MO(b_tenf, window.name + ',THAMSO', ['THAMSO', [window.name, 'NS_LHD', null, "Lưu file mẫu hợp đồng", b_t, b_f, "MA", b_nd]], null);
        form_P_LOI('');
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}