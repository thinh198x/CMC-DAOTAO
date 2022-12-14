
var ns_tl_tlap_nghiphep_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timId;
function ns_tl_tlap_nghiphep_P_KD() {
    ns_tl_tlap_nghiphep_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'),
    b_ngaycdId = form_Fs_TEN_ID(b_vungId, 'ngaycd');
    b_congdonId = form_Fs_TEN_ID(b_vungId, 'congdon');
    b_ma1ngayId = form_Fs_TEN_ID(b_vungId, 'ma1ngay');
    b_manuangayId = form_Fs_TEN_ID(b_vungId, 'manuangay');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    ns_tl_tlap_nghiphep_lkeCho = setInterval('ns_tl_tlap_nghiphep_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("MA1NGAY") >= 0) {
            $get(b_ma1ngayId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_manuangayId).focus();
        }
        else if (b_dtuong.indexOf("MANUANGAY") >= 0) {
            $get(b_manuangayId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_tl_tlap_nghiphep_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "NGAYCD": b_maId = b_ngaycdId; break;
            case "MA1NGAY": b_maId = b_ma1ngayId; break;
            case "MANUANGAY": b_maId = b_manuangayId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "NGAYCD") {
            var b_ngaythang = b_ma.value;
            var b_ngay = b_ngaythang.substring(0, 2);
            var b_thang = b_ngaythang.substring(3, 5);
            var b_chan = b_ngaythang.substring(2, 3);
            if (b_ngay > 31) { form_P_LOI("loi:Sai ngày tháng (định dạng kiểu dd/MM ):loi"); b_ma.value = ""; b_ma.focus(); return false; }
            if (b_thang > 12 || b_thang < 1) { form_P_LOI("loi:Sai kiểu tháng (định dạng kiểu dd/MM ):loi"); b_ma.value = ""; b_ma.focus(); return false; }
            if (b_chan != "/") { form_P_LOI("loi:Sai định dạng (định dạng kiểu dd/MM ví dụ: 31/12 ):loi"); b_ma.value = ""; b_ma.focus(); return false; }
            $get(b_congdonId).focus();
        }
        else if (b_maTen == "MA1NGAY") {
            skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_tl_tlap_nghiphep_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_maTen == "MANUANGAY") {
            skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_tl_tlap_nghiphep_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_tlap_nghiphep_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}

function ns_tl_tlap_nghiphep_P_LKE_CHO() {
    clearTimeout(ns_tl_tlap_nghiphep_lkeCho); ns_tl_tlap_nghiphep_P_CHUYEN_HANG(); 
}


function ns_tl_tlap_nghiphep_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
    stl_ma.Fs_NS_TL_TLAP_NGHIPHEP_NH(a_dt_ct, ns_tl_tlap_nghiphep_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_tl_tlap_nghiphep_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI("loi:Nhập thành công:loi");
    }
    return false;
}


function ns_tl_tlap_nghiphep_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    $get(b_gocId).focus();
}

function ns_tl_tlap_nghiphep_P_XOA() {
    var r = confirm("Bạn có chắc chắn xóa không?");
    if (r == false) {
        return false;
    }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    if (b_ma == "") ns_tl_tlap_nghiphep_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_ma.Fs_ns_tl_tlap_nghiphep_XOA(b_ma, a_tso, a_cot, ns_tl_tlap_nghiphep_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_tl_tlap_nghiphep_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_tl_tlap_nghiphep_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_tl_tlap_nghiphep_P_CHUYEN_HANG(); }
    }
}

function ns_tl_tlap_nghiphep_P_CHUYEN_HANG() {
    try {
        stl_ma.Fs_NS_TL_TLAP_NGHIPHEP_CT(ns_tl_tlap_nghiphep_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_tl_tlap_nghiphep_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
function form_dong() {
    location.reload(false);
}