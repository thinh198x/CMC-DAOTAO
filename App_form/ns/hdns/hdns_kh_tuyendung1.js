
var hdns_kh_tuyendung_P_KD_lkeCho, b_vungId, b_vunggId, b_grlkeId, b_grctId, b_gocId, b_makh, b_thang, b_mt, b_gchuId, b_thangId, b_doi = 0, b_ncdId, b_ncd2Id;
function hdns_kh_tuyendung_P_KD() {
    hdns_kh_tuyendung_P_KD_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungGId = form_Fs_VUNG_ID('GR_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'nam');
    b_thang = form_Fs_TEN_ID(b_vungId, 'thang');
    b_makh = form_Fs_TEN_ID(b_vungId, 'ma');
    b_ncdId = form_Fs_TEN_ID(b_vungId, 'hincd'),
   b_ncd2Id = form_Fs_TEN_ID(b_vungId, 'hincd2');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'); b_slideId = b_grlkeId + '_slide';
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    hdns_kh_tuyendung_P_KD_lkeCho = setInterval('hdns_kh_tuyendung_P_KD_P_LKE_CHO()', 200);
}

var b_cho_control = 0;
function P_cho(b_nam, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_gocId).value = b_nam;
            $get(b_gchuId).innerHTML = b_ten;
            $get(b_gocId).focus();
            hdns_kh_tuyendung_P_KD_P_LKE();
            b_doi = 1;
            clearTimeout(b_cho_control);
        } else if (b_doi == 1) {
        }
    }
    catch (err) {
        b_doi = 0;
    }
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_kq == null || b_kq == "")
            return;
        b_doi = 0;
        if (b_dtuong.indexOf("SO_THE") >= 0 || b_dtuong.indexOf("THAMSO") >= 0) {
            $get(b_gocId).setAttribute("disabled", "disabled");
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
        } else if (b_dtuong.indexOf("NCDANH") >= 0) {
            b_doi = 0;
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grctId, b_hang, ["ten_ncdanh"], [a_tso[1]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["ncdanh"], [a_tso[0]], 'K');
            $get(b_ncdId).value = a_tso[0];
        } else if (b_dtuong.indexOf("BCDANH") >= 0) {
            b_doi = 1;
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grctId, b_hang, ["bcdanh"], [a_tso[0]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["heso"], [a_tso[1]], 'K');
        } else if (b_dtuong.indexOf("CDANH") >= 0) {
            b_doi = 0;
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grctId, b_hang, ["cdanh"], [a_tso[0]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["ten_cdanh"], [a_tso[1]], 'K');
            $get(b_ncd2Id).value = a_tso[0];
        }
        else if (b_dtuong.indexOf("PHONG") >= 0) {
            b_doi = 1;
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grctId, b_hang, ["phong"], [a_tso[0]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["ten_phong"], [a_tso[1]], 'K');
        } else if (b_dtuong.indexOf("BOPHAN_YC") >= 0) {
            b_doi = 1;
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grctId, b_hang, ["BOPHAN_YC"], [a_tso[0]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["TEN_BOPHAN_YC"], [a_tso[1]], 'K');
        }
    }
    catch (err) { form_P_LOI(err); }
}
function hdns_kh_tuyendung_P_KD_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; form_P_MOI("", "XGL"); GridX_datTrang(b_grctId); break;
            case "MA": b_maId = b_makh; break;
        }
        var b_ma = $get(b_maId);
        b_mt = b_maTen;
        if ($get(b_gocId).value != null && b_maTen == "NAM") hdns_kh_tuyendung_P_KD_P_MA_KTRA();
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen = "MA") {
            $get(b_makh).value = ($get(b_makh).value).validate_Ma();
        }
        if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), hdns_kh_tuyendung_P_KD_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            hdns_kh_tuyendung_P_KD_P_LKE();
        }
        else if (b_maTen == "NGAY") {
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ngayd", b_ma.value);
            if (b_hang < 0) { hdns_kh_tuyendung_P_KD_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); hdns_kh_tuyendung_P_KD_P_CHUYEN_HANG(); }
        } else if (b_maTen == "MA") {
            hdns_kh_tuyendung_P_KD_P_MA_KTRA();
        }
        

    }
    catch (err) { form_P_LOI(err); }
}

function hdns_kh_tuyendung_P_KD_P_MA_KTRA() {
    try {
        var b_makhoach = $get(b_makh).value;
        var b_nam = $get(b_gocId).value;
        if ( b_nam != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_td.Fs_HDNS_KH_TUYENDUNG_MA(b_makhoach, b_nam, b_TrangKt, a_cot, hdns_kh_tuyendung_P_KD_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        if (b_makhoach != "" && b_nam != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_td.Fs_HDNS_KH_TUYENDUNG_MA(b_makhoach, b_nam, b_TrangKt, a_cot, hdns_kh_tuyendung_P_KD_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function hdns_kh_tuyendung_P_KD_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        form_P_MOI(b_vungId, "X"); GridX_datTrang(b_grctId);
        $get(b_so_idId).value = "0";
    }
    else { GridX_datA(b_grlkeId, b_hang); hdns_kh_tuyendung_P_KD_P_CHUYEN_HANG(); }
}
function hdns_kh_tuyendung_P_KD_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    $get(b_gchuId).innerHTML = b_kq;
}
function hdns_kh_tuyendung_Update_tt(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grctId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        var b_ktra = C_NVL(b_ctr.ktra), b_ten = C_NVL(b_ctr.ten);
        if (b_value != "") {
            if (b_cot == "PHONG") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Đơn vị/Phòng ban", b_value, "ht_ma_phong,ma,ten", hdns_kh_tuyendung_P_KD_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
            if (b_cot == "NCDANH") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Mã nhóm chức danh", b_value.toUpperCase(), "ns_ma_ncdanh,ma,ten", hsns_dinhbien_ns_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
            if (b_cot == "CDANH") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Mã chức danh", b_value.toUpperCase(), "ns_ma_cdanh,ma,ten", hsns_dinhbien_ns_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
            if (b_cot == "TEN_BCDANH") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Bậc chức danh", b_value, "ns_ma_baccdanh,bac,heso", hdns_kh_tuyendung_P_KD_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
            if (b_cot == "KHOACH_NGAY") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Bậc chức danh", b_value, "ns_ma_baccdanh,bac,heso", hdns_kh_tuyendung_P_KD_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        if (b_value != "") GridX_ThemHang(b_grttId);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}


var hdns_kh_tuyendung_P_KD_choAct = 0;
function hdns_kh_tuyendung_P_KD_GR_lke_RowChange() {
    if (hdns_kh_tuyendung_P_KD_choAct != 0) clearTimeout(hdns_kh_tuyendung_P_KD_choAct);
    hdns_kh_tuyendung_P_KD_choAct = setTimeout("hdns_kh_tuyendung_P_KD_P_CHUYEN_HANG()", 300);
    return false;
}

var hdns_kh_tuyendung_P_KD2_choAct = 0;
function hdns_kh_tuyendung_P_KD2_GR_lke_RowChange() {
    if (hdns_kh_tuyendung_P_KD2_choAct != 0) clearTimeout(hdns_kh_tuyendung_P_KD_choAct);
    hdns_kh_tuyendung_P_KD2_choAct = setTimeout("hdns_kh_tuyendung_P_KD2_P_CHUYEN_HANG()", 300);
    return false;
}
function hdns_kh_tuyendung_P_KD2_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grctId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grctId, b_hang, "thang"));
        if (b_ma == "") form_P_MOI(b_vungId, "XGL"); else form_P_GridX_TEXT(b_vungId, b_grctId);
    }
    catch (err) { form_P_LOI(err); }
}
function hdns_kh_tuyendung_P_KD_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(hdns_kh_tuyendung_P_KD_lkeCho); hdns_kh_tuyendung_P_KD_P_LKE(); }
}

function hdns_kh_tuyendung_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    $get(b_so_idId).value = "0";
    $get(b_gocId).focus();
    return false;
}
function hdns_kh_tuyendung_P_KD_P_LKE() {
    try {
        var b_nam = $get(b_gocId).value,
            a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_td.Fs_HDNS_KH_TUYENDUNG_LKE(a_tso, a_cot, hdns_kh_tuyendung_P_KD_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function hdns_kh_tuyendung_P_KD_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function hdns_kh_tuyendung_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        var ktra = validate_month($get(b_thang).value);
        if (ktra == 0 || ktra > 12) { form_P_LOI("loi:Nhập sai tháng. Nhập không thành công:loi"); $get(b_thang).focus(); return false; }
        if (ktra_ktdb(C_NVL(form_Fs_TEN_GTRI(b_vungId, 'ten')))) { form_P_LOI("loi:Tên kế hoạch không được chứa ký tự đặc biệt:loi"); return false; }
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_nam = $get(b_gocId).value, b_dt = form_Faa_TEXT_ROW(b_vungId), b_makehoach = $get(b_makh).value,
                a_cot_ct = GridX_Fdt_cotGtri(b_grctId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
            sns_td.Fs_HDNS_KH_TUYENDUNG_NH(b_makehoach, b_nam, b_dt, b_TrangKt, a_cot_ct, a_cot_lke, hdns_kh_tuyendung_P_KD_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function hdns_kh_tuyendung_P_KD_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI('loi:Nhập thành công:loi');
    }
    return false;
}
function hdns_kh_tuyendung_P_KD_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "MA"));
    if (b_hang < 1) b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, 1, "MA"));
    if (b_ma == null || b_ma == "") { form_P_MOI("", "XGL"); GridX_datTrang(b_grctId); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        sns_td.Fs_HDNS_KH_TUYENDUNG_CT(b_ma, a_cot_ct, hdns_kh_tuyendung_P_KD_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function hdns_kh_tuyendung_P_KD_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
}
function hdns_kh_tuyendung_P_XOA() {
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) {
        return false;
    }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "MA"));
    if (b_ma == "") hdns_kh_tuyendung_P_MOI();
    else {

        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_td.Fs_HDNS_KH_TUYENDUNG_XOA(b_ma, a_tso, a_cot, hdns_kh_tuyendung_P_KD_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}

var hdns_kh_tuyendung_choAct = 0;
function hdns_kh_tuyendung_GR_lke_RowChange() {
    if (hdns_kh_tuyendung_choAct != 0) clearTimeout(hdns_kh_tuyendung_choAct);
    hdns_kh_tuyendung_choAct = setTimeout("hdns_kh_tuyendung_P_KD_P_CHUYEN_HANG()", 300);
    return false;
}
function hdns_kh_tuyendung_P_KD_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) hdns_kh_tuyendung_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); hdns_kh_tuyendung_P_KD_P_CHUYEN_HANG(); }
        hdns_kh_tuyendung_GR_lke_RowChange();
        form_P_LOI('loi:Xoá thành công:loi');
    }
}
function hdns_kh_tuyendung_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_datTrang(b_grctId);
    return false;
}
function hdns_kh_tuyendung_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function hdns_kh_tuyendung_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function hdns_kh_tuyendung_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function hdns_kh_tuyendung_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}
function hsns_dinhbien_ns_tinh() {
    var tong = 0;
    var b_maId = "", b_thamso;
    b_thamso = b_thamso.toUpperCase();
    if (b_thamso == "QUY1") {
        tong = nvl(GridX_Fas_layGtri(b_grctId, 1, "db_t1"), 0) + nvl(GridX_Fas_layGtri(b_grctId, 1, "db_t2"), 0) + nvl(GridX_Fas_layGtri(b_grctId, 1, "db_t3"), 0);
    }

    return false;
}
function nvl(value1, value2) {
    if (value1 == null || value1 == "")
        return value2;
    return value1;
}
function validate_month(str) {
    var m_str = str.split('/');
    var m_str = parseInt(m_str[0]);
    return m_str;
}
function form_dong() {
    location.reload(false);
}