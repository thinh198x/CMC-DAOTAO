var ns_khbh_lkeCho, b_vungId, ns_khbh_P_LKECHO, b_grlkeId, b_slideId, b_gocId, b_loai_khId, b_gchuId, b_namId, b_so_idId, b_moiId;
function ns_khbh_P_KD() {
    ns_khbh_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'), b_namId = form_Fs_TEN_ID(b_vungId, 'NAM'),
    b_loai_khId = form_Fs_TEN_ID(b_vungId, 'LOAI_KH'), b_ngaydId = form_Fs_TEN_ID(b_vungId, 'NGAYD'), b_ngaycId = form_Fs_TEN_ID(b_vungId, 'NGAYC');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_moiId = form_Fs_VTEN_ID('', 'moi');
    b_slideId = b_grlkeId + '_slide';
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("LOAI_KH") >= 0) {
            $get(b_loai_khId).value = b_kq; 
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_loai_khId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_khbh_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "NAM": b_maId = b_namId; form_P_MOI("", "XGL"); break;
            case "LOAI_KH": b_maId = b_loai_khId ; break;
            case "MA": b_maId = b_gocId; break; 
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "NAM") {
            ns_khbh_P_LKE();
        }
        if (b_maTen == "LOAI_KH") {
            skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_khbh_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_maTen == "MA") {
            $get(b_gocId).value = ($get(b_gocId).value).validate_Ma();
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_khbh_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_khbh_P_CHUYEN_HANG(); }
        }
        else { GridX_thoiA(b_grlkeId); form_P_MOI("", "X"); }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_khbh_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_nam = $get(b_namId).value;
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_sk.Fs_NS_KHBH_MA(b_nam, b_ma, b_TrangKt, a_cot, ns_khbh_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_khbh_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_khbh_P_LKECHO); ns_khbh_P_LKE_KHOITAO(); }
}
function ns_khbh_P_LKE_KHOITAO() {
    ns_khbh_P_LKE();
}
function ns_khbh_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_khbh_P_CHUYEN_HANG(); }
}

function ns_khbh_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}

var ns_khbh_choAct = 0;
function ns_khbh_GR_lke_RowChange() {
    if (ns_khbh_choAct != 0) clearTimeout(ns_khbh_choAct);
    ns_khbh_choAct = setTimeout("ns_khbh_P_CHUYEN_HANG()", 300);
    return false;
}
 
function ns_khbh_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = "0";
    $get(b_gocId).focus();
    return false;
}
function ns_khbh_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
        b_nam = $get(b_namId).value;
        sns_sk.Fs_NS_KHBH_LKE(b_nam, a_tso, a_cot, ns_khbh_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_khbh_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}

function ns_khbh_P_NH() {
    try {
        var ktra = ktra_ngay(parseDate($get(b_ngaydId).value).getTime(), parseDate($get(b_ngaycId).value).getTime(), 1, "Từ ngày", "Đến ngày");
        if (ktra.length > 0) {
            ns_khbh_NH_KQ(ktra);
            return false;
        }
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        var b_ma = $get(b_gocId).value;
        sns_sk.Fs_NS_KHBH_NH(b_ma,b_TrangKt, a_dt_ct, a_cot_lke, ns_khbh_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { throw (err); }
}

function ns_khbh_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {        
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
    }
    return false;
}

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

function ns_khbh_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
    var b_nam = $get(b_namId).value;
    if (b_ma == "") form_P_MOI(b_vungId, "XGL");
    else sns_sk.Fs_NS_KHBH_CT(b_nam,b_ma, ns_khbh_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function ns_khbh_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
function ns_khbh_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }

    var b_ma = $get(b_gocId).value;
    var b_nam = $get(b_namId).value;
    if (b_ma == "") ns_khbh_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_sk.Fs_NS_KHBH_XOA(b_nam,b_ma, a_tso, a_cot, ns_khbh_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_khbh_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_khbh_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_khbh_P_CHUYEN_HANG(); }
    }
}
function form_dong() {
    location.reload(false);
}