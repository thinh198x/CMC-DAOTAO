var ns_dt_khdt_nam_lkeCho = 0, ns_dt_khdt_nam_choAct = 0, b_vungId, b_grlkeId, b_slideId, b_ghichuId, b_vungTk, b_vungHi, b_nsd, b_gchuId,
    b_namTk, b_thangTk, b_namId, b_thangId, b_tonglopId, b_md_utienId, b_so_idHi, b_is_yeucauId, b_nhucau_Id,
b_nhom_ndId, b_kdtId, b_tonglop_id, b_ddiem_id, b_hinhthucId, b_dtuongId, b_thoiluongId, b_so_hvId, b_so_hv_lopId, b_cphiId, b_cphi_lopId;
// Kiểm tra
function ns_dt_khdt_nam_P_KD() {
    ns_dt_khdt_nam_lkeCho = setInterval('ns_dt_khdt_nam_P_LKE_CHO()', 200);
}
function ns_dt_khdt_nam_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "NAM": b_maId = b_namId; break;
            case "THANG": b_maId = b_thangId; break;
            case "NHOM_ND": b_maId = b_nhom_ndId; break;
            case "YEUCAU": b_maId = b_is_yeucauId; break;
            case "KDT": b_maId = b_kdtId; break;
            case "KDT_NHUCAU": b_maId = b_nhucau_Id; break;
            case "CPHI": b_maId = b_cphiId; break;
            case "SO_HV": b_maId = b_so_hvId; break;
        }
        var b_ma = $get(b_maId);

        if (b_maTen == "NAM" || b_maTen == "THANG" || b_maTen == "NHOM_ND" || b_maTen == "YEUCAU") {
            var b_nam = form_Fs_TEN_GTRI(b_vungId, 'NAM'), b_thang = lke_Fs_TRA($get(b_thangId)), b_nhom_nd = lke_Fs_TRA($get(b_nhom_ndId)), b_yeucau = $get(b_is_yeucauId).value;
            if (b_yeucau == "X") {
                $get(b_nhucau_Id).value = "";
                hts_dungchung.P_MA_KDT_NHUCAU(window.name, b_nam, b_thang);
            } else {
                $get(b_kdtId).value = "";
                hts_dungchung.P_MA_KDT_NAM(window.name, b_nam, b_nhom_nd);
            }
        }
        if (b_ma == null || C_NVL(b_ma.value) == "") {
            $get(b_cphi_lopId).value = null;
            return false;
        } else if (b_maTen == "KDT") {
            var b_ma_kdt = lke_Fs_TRA($get(b_kdtId));
            ns_dt_khdt_nam_KDT(b_ma_kdt);
        } else if (b_maTen == "KDT_NHUCAU") {
            var b_ma_kdt_nhucau = lke_Fs_TRA($get(b_nhucau_Id)), b_nam = form_Fs_TEN_GTRI(b_vungId, 'NAM'), b_thang = lke_Fs_TRA($get(b_thangId));
            ns_dt_khdt_nam_KDT_NHUCAU(b_ma_kdt_nhucau, b_nam, b_thang);
        } else if (b_maTen == "SO_HV") {
            var b_so_hv = CSO_SO($get(b_so_hvId).value), b_tonglop = CSO_SO($get(b_tonglopId).value);
            if (b_so_hv != 0 && b_tonglop != 0) {
                var b_so_hv_lop = Math.floor(b_so_hv / b_tonglop);
                $get(b_so_hv_lopId).value = SO_CSO(b_so_hv_lop);
            } else {
                $get(b_so_hv_lopId).value = null;
            }
        } else if (b_maTen == "CPHI") {
            var b_tonglop = CSO_SO($get(b_tonglopId).value), b_cphi_lop = CSO_SO($get(b_cphiId).value);
            if (b_tonglop != 0 && b_cphi_lop != 0) {
                var b_cphi_hv = Math.floor(b_cphi_lop / b_tonglop);
                $get(b_cphi_lopId).value = SO_CSO(b_cphi_hv);
            } else {
                $get(b_cphi_lopId).value = null;
            }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_khdt_nam_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        return false;
    } else form_P_DatGchu(b_ghichuId, b_kq);
}
// Nhập
function ns_dt_khdt_nam_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_so_idHi).value = "";
    lke_P_DAT(b_thangId, "");
    lke_P_DAT(b_kdtId, "");
    lke_P_DAT(b_hinhthucId, "");
    ns_dt_khdt_P_NPA();
    return false;
}
function ns_dt_khdt_nam_P_NH() {
    try {
        var b_kdt = $get(b_kdtId).value; var b_nhucau = $get(b_nhucau_Id).value;
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_kdt == "" && b_nhucau != "") { b_loi = "";}
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId); var b_hang = GridX_Fi_timHangA(b_grlkeId), b_so_id = '0';
            b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")); var a_tk = form_Faa_TEXT_ROW(b_vungTk);
            if (b_hang < 1) b_hang = -1;
            var a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            sns_dt.Fs_NS_DT_KHDT_NAM_NH(form_Fs_nsd(), b_so_id, a_tk, a_dt_ct, b_TrangKt, a_cot, ns_dt_khdt_nam_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_dt_khdt_nam_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        form_P_LOI("Nhập thành công!");
    }
    return false;
}
// Xóa
function ns_dt_khdt_nam_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") ns_dt_khdt_nam_P_MOI();
    else {
        var a_tk = form_Faa_TEXT_ROW(b_vungTk);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.Fs_NS_DT_KHDT_NAM_XOA(a_tk, b_so_id, a_tso, a_cot, ns_dt_khdt_nam_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_dt_khdt_nam_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dt_khdt_nam_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dt_khdt_nam_P_CHUYEN_HANG(); }
        form_P_LOI("Xóa thành công!");
    }
    return false;
}
// Chuyển hàng
function ns_dt_khdt_nam_GR_lke_RowChange() {
    if (ns_dt_khdt_nam_choAct != 0) clearTimeout(ns_dt_khdt_nam_choAct);
    ns_dt_khdt_nam_choAct = setTimeout("ns_dt_khdt_nam_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_dt_khdt_nam_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "") ns_dt_khdt_nam_P_MOI();
    else {
        $get(b_so_idHi).value = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        sns_dt.Fs_NS_DT_KHDT_NAM_CT(window.name, b_so_id, ns_dt_khdt_nam_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function ns_dt_khdt_nam_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    ns_dt_khdt_P_NPA();
}
// Liệt kê
function ns_dt_khdt_nam_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_vungTk = form_Fs_VUNG_ID('Upa_tk'), b_vungHi = form_Fs_VUNG_ID('UPa_hi');
        b_namTk = form_Fs_TEN_ID(b_vungTk, 'namtk'), b_thangTk = form_Fs_TEN_ID(b_vungTk, 'thangtk');
        b_namId = form_Fs_TEN_ID(b_vungId, 'nam'), b_thangId = form_Fs_TEN_ID(b_vungId, 'thang');
        b_nhom_ndId = form_Fs_TEN_ID(b_vungId, 'nhom_nd'), b_kdtId = form_Fs_TEN_ID(b_vungId, 'kdt'), b_tonglop_id = form_Fs_TEN_ID(b_vungId, 'tonglop');
        b_ddiem_id = form_Fs_TEN_ID(b_vungId, 'ddiem'), b_hinhthucId = form_Fs_TEN_ID(b_vungId, 'hthuc'), b_dtuongId = form_Fs_TEN_ID(b_vungId, 'dtuong'),
        b_thoiluongId = form_Fs_TEN_ID(b_vungId, 'thoiluong'), b_so_hvId = form_Fs_TEN_ID(b_vungId, 'so_hv'), b_so_hv_lopId = form_Fs_TEN_ID(b_vungId, 'so_hv_lop'),
        b_is_yeucauId = form_Fs_TEN_ID(b_vungId, 'is_yeucau'), b_nhucau_Id = form_Fs_TEN_ID(b_vungId, 'nhucau'),
        b_cphiId = form_Fs_TEN_ID(b_vungId, 'cphi'), b_cphi_lopId = form_Fs_TEN_ID(b_vungId, 'cphi_lop'), b_tonglopId = form_Fs_TEN_ID(b_vungId, 'tonglop');
        b_gchuId = form_Fs_VTEN_ID('', 'gchu');
        b_so_idHi = form_Fs_TEN_ID(b_vungHi, 'so_id');
        b_nsd = form_Fs_nsd();
        b_slideId = $get(b_grlkeId).getAttribute('slideId'); slide_P_MOI(b_slideId);
        clearTimeout(ns_dt_khdt_nam_lkeCho); ns_dt_khdt_nam_P_LKE();
        ns_dt_khdt_P_NPA();
    }
}
function ns_dt_khdt_nam_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var a_tk = form_Faa_TEXT_ROW(b_vungTk);
        sns_dt.Fs_NS_DT_KHDT_NAM_LKE(a_tk, a_tso, a_cot, ns_dt_khdt_nam_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
    return false;
}
function ns_dt_khdt_nam_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
// chọn khóa đào tạo không theo yêu cầu
function ns_dt_khdt_nam_KDT(b_kdt) {
    try {
        sns_dt.Fs_NS_DT_KHDT_NAM_KDT(b_kdt, ns_dt_khdt_nam_KDT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_khdt_nam_KDT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var b_drop = form_Fctr_TEN_DTUONG(b_vungId, 'hthuc');
    var a_kq = Fas_ChMang(b_kq, '#');
    list_P_DAT(b_drop, a_kq[0]);
    $get(b_thoiluongId).value = a_kq[1];
}
//chọn khóa đào tạo theo yêu cầu
function ns_dt_khdt_nam_KDT_NHUCAU(b_kdt_nhucau, b_nam, b_thang) {
    try {
        sns_dt.Fs_NS_DT_KHDT_NAM_KDT_NHUCAU(b_kdt_nhucau, b_nam, b_thang, ns_dt_khdt_nam_KDT_NHUCAU_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_khdt_nam_KDT_NHUCAU_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    $get(b_so_hvId).value = a_kq[0];
    //$get(b_lopId).value = a_kq[1];
    lke_P_DAT($get(b_nhom_ndId), a_kq[2]);
}
// Ẩn hiện controll
function ns_dt_khdt_P_NPA() {
    var b_nv = $get(b_is_yeucauId).value;
    if (b_nv == "X") {
        $get(b_nhucau_Id).style.display = '';
        $get(b_kdtId).style.display = 'none';
        document.getElementById(b_nhom_ndId).disabled = true;
        //document.getElementById(b_tonglop_id).disabled = true;
        //document.getElementById(b_ddiem_id).disabled = true;
        //document.getElementById(b_hinhthucId).disabled = true;
        //document.getElementById(b_dtuongId).disabled = true;
        //document.getElementById(b_thoiluongId).disabled = true;
        //document.getElementById(b_so_hvId).disabled = true;
        //document.getElementById(b_cphiId).disabled = true;
    } else {
        $get(b_nhucau_Id).style.display = 'none';
        $get(b_kdtId).style.display = '';
        document.getElementById(b_nhom_ndId).disabled = false;
        //document.getElementById(b_tonglop_id).disabled = false;
        //document.getElementById(b_ddiem_id).disabled = false;
        //document.getElementById(b_hinhthucId).disabled = false;
        //document.getElementById(b_dtuongId).disabled = false;
        //document.getElementById(b_thoiluongId).disabled = false;
        //document.getElementById(b_so_hvId).disabled = false;
        //document.getElementById(b_cphiId).disabled = false;
    }
}

function form_dong() {
    location.reload(false);
}