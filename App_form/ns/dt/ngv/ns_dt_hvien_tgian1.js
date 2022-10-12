var ns_dt_hvien_tgian_lkeCho, b_vungId, b_gchuId, ns_dt_hvien_tgian_choAct = 0, b_grlkeId, b_slideId, b_thang_an, b_lop_an, b_kdt_an, b_vungHi,
    b_vungtkId, b_namId, b_so_idId, b_slidectId, b_cho_control = 0, b_namId, b_thangId, b_grctId, b_athangId, b_khoa_dtId, b_lop_dtId, b_nhom_ndId, b_tluongId, b_ngaydId, b_ngaycId, b_nam_tkId, b_thang_tkId, b_khoa_dt_tkId, b_lop_dt_tkId;
function ns_dt_hvien_tgian_P_KD() {
    ns_dt_hvien_tgian_lkeCho = setInterval('ns_dt_hvien_tgian_P_LKE_CHO()', 200);
}
function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_namId).value = b_so_the;
            $get(b_gchuId).innerHTML = b_ten;
            $get(b_namId).focus();
            ns_dt_hvien_tgian_P_LKE('K');
            b_doi = 1;
            clearTimeout(b_cho_control);
        }
    }
    catch (err) { b_doi = 0; }
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "" || a_tso[0] == "FILE_HTOAN") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];

        if (b_dtuong.indexOf("THAMSO") >= 0) {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
        } else if (b_dtuong.indexOf("SO_THE") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            ns_dt_hvien_tgian_P_TTCB(b_kq);
        }
        else if (b_dtuong.indexOf("TAI_IMPORT") >= 0) {
            ns_dt_hvien_tgian_P_LKE();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_hvien_tgian_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_t = b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_namId; form_P_MOI("", "XGL"); break
            case "KHOA_DT": b_maId = b_khoa_dtId; break;
            case "NAM_TK": b_maId = b_nam_tkId; break;
            case "KHOA_DT_TK": b_maId = b_khoa_dt_tkId; break;
        }
        b_chonId = b_maTen;
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "NAM_TK") {
            var b_nam = form_Fs_TEN_GTRI(b_vungtkId, 'NAM_TK');
            $get(b_athangId).value = form_Fs_TEN_GTRI(b_vungtkId, 'thang_tk');
            if (b_nam != "") hts_dungchung.Fs_NS_MA_KDT_DT_NAM(window.name, "DT_KHOA_DT_TK", b_nam);
        } else if (b_maTen == "KHOA_DT") {
            ns_dt_hvien_tgian_P_LHOC();
        } else if (b_maTen == "KHOA_DT_TK") {
            ns_dt_hvien_tgian_P_LHOC_TK();
        } else if (b_maTen == "NAM") {
            var b_nam = form_Fs_TEN_GTRI(b_vungId, 'NAM');
            if (b_nam != "") hts_dungchung.P_MA_KDT_NAM(window.name, b_nam);
        }

    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_hvien_tgian_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
    }
    else { form_P_DatGchu(b_gchuId, b_kq); }
}
function ns_dt_hvien_tgian_P_MOI() {
    form_P_MOI(b_vungId, "GXLK");
    GridX_thoiA(b_grlkeId);
    GridX_datBang(b_grctId, "");
    $get(b_namId).focus();
    return false;
}
function ns_dt_hvien_tgian_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }

        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        var b_nam = $get(b_namId).value, b_thang = lke_Fs_TRA($get(b_thang_tkId)), b_khoa_dt = lke_Fs_TRA($get(b_khoa_dt_tkId)), b_lop_dt = lke_Fs_TRA($get(b_lop_dt_tkId));
        a_cot_ct = GridX_Fdt_cotGtri(b_grctId);
        sns_dt.Fs_NS_DT_HVIEN_TGIAN_NH(form_Fs_nsd(), b_so_id, b_nam, b_thang, b_khoa_dt, b_lop_dt, b_TrangKt, a_dt_ct, a_cot_lke, a_cot_ct, ns_dt_hvien_tgian_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { throw (err); }
}
function ns_dt_hvien_tgian_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        ns_dt_hvien_tgian_P_LKE();
        form_P_LOI("loi:Nhập thành công!:loi");
    }
    return false;
}
function ns_dt_hvien_tgian_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1) { form_P_LOI("loi:Chọn bản ghi:loi"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") { form_P_LOI("loi:Chọn bản ghi:loi"); ns_dt_hvien_tgian_P_MOI(); return false; }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_nam = $get(b_nam_tkId).value, b_thang = lke_Fs_TRA($get(b_thang_tkId)), b_khoa_dt = lke_Fs_TRA($get(b_khoa_dt_tkId)), b_lop_dt = lke_Fs_TRA($get(b_lop_dt_tkId));
        sns_dt.Fs_NS_DT_HVIEN_TGIAN_XOA(form_Fs_nsd(), b_so_id, b_nam, b_thang, b_khoa_dt, b_lop_dt, a_tso, a_cot, ns_dt_hvien_tgian_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_dt_hvien_tgian_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dt_hvien_tgian_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dt_hvien_tgian_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
    return false;
}
//Chuy?n hàng
function ns_dt_hvien_tgian_GR_lke_RowChange() {
    if (ns_dt_hvien_tgian_choAct != 0) clearTimeout(ns_dt_hvien_tgian_choAct);
    ns_dt_hvien_tgian_choAct = setTimeout("ns_dt_hvien_tgian_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_dt_hvien_tgian_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var a_cot_ct = GridX_Fas_tenCot(b_grctId);
    a_tso = slide_Faobj_TUDEN(b_slidectId);
    GridX_datBang(b_grctId, "");
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "0" || b_so_id == "") { form_P_MOI(b_vungId, "XGLK"); GridX_datBang(b_grctId, ""); }
    else sns_dt.Fs_NS_DT_HVIEN_TGIAN_CT(form_Fs_nsd(), b_so_id, a_cot_ct, a_tso, ns_dt_hvien_tgian_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_dt_hvien_tgian_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == '') return;
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slidectId, CSO_SO(a_kq[0], 0));
    form_P_CH_TEXT(b_vungId, a_kq[1]);
    GridX_datBang(b_grctId, a_kq[2]);

}

function ns_dt_hvien_tgian_P_TH(b_dk) {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        if (b_dk == 'C') slide_P_MOI(b_slidectId);
        var a_cot = GridX_Fas_tenCot(b_grctId), a_tso = slide_Faobj_TUDEN(b_slidectId);
        var b_nam = $get(b_namId).value, b_thang = lke_Fs_TRA($get(b_thangId)), b_khoa_dt = lke_Fs_TRA($get(b_khoa_dtId)), b_lop_dt = $get(b_lop_dtId).value;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "0" || b_so_id == "") { form_P_MOI(b_vungId, "XGLK"); GridX_datBang(b_grctId, ""); }
        sns_dt.Fs_NS_DT_HVIEN_TGIAN_TH(form_Fs_nsd(), b_nam, b_thang, b_khoa_dt, b_lop_dt, b_so_id, a_tso, a_cot, ns_dt_hvien_tgian_P_TH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_dt_hvien_tgian_P_TH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slidectId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grctId, a_kq[1]);
    form_P_LOI("loi:Tổng hợp thành công:loi");
}
//Liệt kê
function ns_dt_hvien_tgian_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ns_dt_hvien_tgian_lkeCho != 0) clearTimeout(ns_dt_hvien_tgian_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'),
        b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_grctId = form_Fs_VUNG_ID('GR_ct');
        b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
        b_vungtkId = form_Fs_VUNG_ID('UPa_tk'),
        b_vungHi = form_Fs_VUNG_ID('UPa_hi'),
        b_namId = form_Fs_TEN_ID(b_vungId, 'nam'), b_thangId = form_Fs_TEN_ID(b_vungId, 'thang'),
        b_khoa_dtId = form_Fs_TEN_ID(b_vungId, 'khoa_dt'), b_lop_dtId = form_Fs_TEN_ID(b_vungId, 'lop_dt'),
        b_nhom_ndId = form_Fs_TEN_ID(b_vungId, 'nhom_nd'), b_tluongId = form_Fs_TEN_ID(b_vungId, 'tluong'),
        b_ngaydId = form_Fs_TEN_ID(b_vungId, 'ngayd'), b_ngaycId = form_Fs_TEN_ID(b_vungId, 'ngayc');
        b_nam_tkId = form_Fs_TEN_ID(b_vungtkId, 'nam_tk'), b_thang_tkId = form_Fs_TEN_ID(b_vungtkId, 'thang_tk'),
        b_khoa_dt_tkId = form_Fs_TEN_ID(b_vungtkId, 'khoa_dt_tk'), b_lop_dt_tkId = form_Fs_TEN_ID(b_vungtkId, 'lop_dt_tk');
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        b_slidectId = $get(b_grctId).getAttribute('slideId');
        b_kdt_an = form_Fs_TEN_ID(b_vungHi, 'kdt_an');
        b_lop_an = form_Fs_TEN_ID(b_vungHi, 'lop_dt_an');
        b_thang_an = form_Fs_TEN_ID(b_vungHi, 'thang_an');
        ns_dt_hvien_tgian_P_LKE('K');
        slide_P_SOTRANG(b_slidectId, 0);
    }
}
function ns_dt_hvien_tgian_P_LKE(b_dk) {
    try {
        //if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_nam = $get(b_nam_tkId).value, b_thang = list_Fs_TRA(b_thang_tkId), b_khoa_dt = lke_Fs_TRA(b_khoa_dt_tkId), b_lop_dt = lke_Fs_TRA(b_lop_dt_tkId);
        sns_dt.Fs_NS_DT_HVIEN_TGIAN_LKE(form_Fs_nsd(), b_nam, b_thang, b_khoa_dt, b_lop_dt, a_tso, a_cot, ns_dt_hvien_tgian_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_dt_hvien_tgian_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    ns_dt_hvien_tgian_P_CHUYEN_HANG();
}
function ns_dt_hvien_tgian_P_LHOC_LKE() {
    try {
        var b_khoa_dt = form_Fs_TEN_GTRI(b_vungtkId, 'KHOA_DT_TK'), b_nam = form_Fs_TEN_GTRI(b_vungtkId, 'NAM_TK');
        if (b_nam != "" && b_khoa_dt != "")
            sns_dt.Fs_NS_DT_LOPHOC(form_Fs_nsd(), window.name, "DT_LOP_DT_TK", b_nam, b_khoa_dt, ns_dt_hvien_tgian_P_LHOC_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_dt_hvien_tgian_P_LHOC_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
}
function ns_dt_hvien_tgian_P_LHOC() {
    try {
        var b_khoa_dt = form_Fs_TEN_GTRI(b_vungId, 'KHOA_DT'), b_nam = form_Fs_TEN_GTRI(b_vungId, 'NAM');
        if (b_nam != "" && b_khoa_dt != "")
            sns_dt.Fs_NS_DT_LOPHOC(form_Fs_nsd(), window.name, "DT_LOP_DT", b_nam, b_khoa_dt, ns_dt_hvien_tgian_P_LHOC_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_dt_hvien_tgian_P_LHOC_TK() {
    try {
        var b_nam = $get(b_nam_tkId).value, b_khoa_dt = lke_Fs_TRA(b_khoa_dt_tkId);
        if (b_nam != "" && b_khoa_dt != "")
            sns_dt.Fs_NS_DT_LOPHOC(form_Fs_nsd(), window.name, "DT_LOP_DT_TK", b_nam, b_khoa_dt, ns_dt_hvien_tgian_P_LHOC_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_dt_hvien_tgian_P_LHOC_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
}
function ns_dt_hvien_tgian_P_LHOC_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
}
function ns_dt_P_KHOA_DT() {
    try {
        var b_nam = form_Fs_TEN_GTRI(b_vungtkId, 'NAM_TK');
        if (b_nam != "")
            sns_dt.Fs_NS_DT_KHOA_DT_NAM(form_Fs_nsd(), window.name, "DT_NAM_TK", b_nam, ns_dt_P_KHOA_DT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_dt_P_KHOA_DT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
}
// lấy thông tin cán bộ
function ns_dt_hvien_tgian_P_TTCB(b_so_the) {
    try {
        hts_dungchung.Fs_THONGTIN_CANBO_LUOI(b_so_the, ns_dt_hvien_tgian_P_TTCB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_hvien_tgian_P_TTCB_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = GridX_Fi_timHangA(b_grctId);
    if (b_hang < 0) return;
    GridX_datGtri(b_grctId, b_hang, ["so_the"], a_kq[1], 'K');
    GridX_datGtri(b_grctId, b_hang, ["ten"], a_kq[2], 'K');
    GridX_datGtri(b_grctId, b_hang, ["ten_cdanh"], a_kq[3], 'K');
    GridX_datGtri(b_grctId, b_hang, ["ten_phong"], a_kq[6], 'K');
    GridX_datGtri(b_grctId, b_hang, ["so_dt"], a_kq[7], 'K');
    GridX_datGtri(b_grctId, b_hang, ["email"], a_kq[8], 'K');
    GridX_datGtri(b_grctId, b_hang, ["email_qly"], a_kq[9], 'K');
    GridX_datGtri(b_grctId, b_hang, ["loai_hv"], 1, 'K');
    return false;
}
function ns_dt_hvien_tgian_P_EXCEL() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'XuatExcel');
    $get(b_btn_excel).click(); form_chay = 0; return false;
}
function ns_dt_hvien_tgian_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_kdt_an).value = form_Fs_TEN_GTRI(b_vungtkId, 'khoa_dt_tk');
    $get(b_lop_an).value = form_Fs_TEN_GTRI(b_vungtkId, 'lop_dt_tk');
    $get(b_thang_an).value = form_Fs_TEN_GTRI(b_vungtkId, 'thang_tk');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function ns_dt_hvien_tgian_Import() {
    var b_tenf = '/App_form/ns/ma/file_Import.aspx';
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1) { form_P_LOI("loi:Chọn bản ghi:loi"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") { form_P_LOI("loi:Chọn bản ghi:loi"); ns_dt_hvien_tgian_P_MOI(); return false; }
    form_P_MO(b_tenf, window.name + ',THAMSO', ['THAMSO', [window.name, 'NS_DT_HVIEN_TGIAN', null, "Import danh sách học viên", b_so_id]], null);
    form_P_LOI('');
    return false;
}
//Ki?m tra ngày tháng
function ns_dt_hvien_tgian_P_NGAY(str) {
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
        return 'loi:Ngày c?p không du?c l?n hon ngày hi?n t?i:loi';
    }
    return "";
}
function ktra_ngay(tungay, denngay, loai, ten1, ten2) {
    if (denngay == "" || denngay == null) {
        return "";
    }
    if (loai == 1 && tungay > denngay) {
        return "loi: " + ten1 + " không du?c l?n hon " + ten2 + " :loi";
    } else if (loai == 2 && tungay >= denngay) {
        return "loi: " + ten1 + " không du?c l?n hon ho?c b?ng " + ten2 + " :loi";
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