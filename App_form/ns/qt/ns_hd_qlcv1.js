var ns_hd_qlcv_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_gchuId, b_so_idId, b_moiId, b_doi = 0, b_ten_cb, b_so_hd, b_sl_ycId;
function ns_hd_qlcv_P_KD(b_tm) {
    try {
        ns_hd_qlcv_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_tmf = b_tm;
        b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE'), b_hspcId = form_Fs_TEN_ID(b_vungId, 'hspc'),
            b_bcdId = form_Fs_TEN_ID(b_vungId, 'bcd'), b_cdanhId = form_Fs_TEN_ID(b_vungId, 'cdanh'), b_ncdId = form_Fs_TEN_ID(b_vungId, 'ncd'), b_sl_ycId = form_Fs_TEN_ID(b_vungId, 'sl_yc')
            b_ma_nteId = form_Fs_TEN_ID(b_vungId, 'ma_nte'), b_hscdId = form_Fs_TEN_ID(b_vungId, 'hscd'), b_lhdId = form_Fs_TEN_ID(b_vungId, 'lhd'),
            b_ngaydId = form_Fs_TEN_ID(b_vungId, 'ngayd'), b_ngaykId = form_Fs_TEN_ID(b_vungId, 'ngay_ky'), b_ngaycId = form_Fs_TEN_ID(b_vungId, 'ngayc'), b_phongId = form_Fs_TEN_ID(b_vungId, 'PHONG'),
            b_cvuId = form_Fs_TEN_ID(b_vungId, 'cvu');
        b_so_hd = form_Fs_TEN_ID(b_vungId, 'SO_HD');
        b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
        b_gchuId = form_Fs_VTEN_ID('', 'gchu');
        b_moiId = form_Fs_VTEN_ID('', 'moi');
        b_slideId = b_grlkeId + '_slide';
    }
    catch (err) { return; }
}

var b_cho_control = 0;
function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_gocId).value = b_so_the;
            $get(b_gchuId).innerHTML = b_ten;
            $get(b_phongId).value = b_phong;
            $get(b_gocId).focus();
            ns_hd_qlcv_P_LKE();
            b_doi = 1;
            clearTimeout(b_cho_control);
            b_ten_cb = b_ten;
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
        var b_hso = a_tso[1];
        b_doi = 0;
        if (b_dtuong.indexOf("SO_THE") >= 0 || b_dtuong.indexOf("THAMSO") >= 0) {
            //$get(b_gocId).setAttribute("disabled", "disabled");
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
            b_ten_cb = a_tso[1];
        }
        else if (b_dtuong.indexOf("CVU") >= 0) {
            $get(b_cvuId).value = b_kq;
            $get(b_hspcId).value = a_tso[2];
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_lngId).focus();
        }
        else if (b_dtuong.indexOf("LNG") >= 0) {
            $get(b_lngId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_ngachId).focus();
        }
        else if (b_dtuong.indexOf("NGACH") >= 0) {
            $get(b_ngachId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_bacId).focus();
        }
        else if (b_dtuong.indexOf("BAC") >= 0) {
            $get(b_bacId).value = b_kq;
            $get(b_hsoId).value = b_hso;
            $get(b_ncdId).focus();
        }
        else if (b_dtuong.indexOf("NCD") >= 0) {
            $get(b_ncdId).value = b_kq;
            $get(b_gchuId).value = b_hso;
            $get(b_cdanhId).focus();
        }
        else if (b_dtuong.indexOf("CDANH") >= 0) {
            $get(b_cdanhId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_bcdId).focus();
        }
        else if (b_dtuong.indexOf("BCD") >= 0) {
            $get(b_bcdId).value = b_kq;
            $get(b_hscdId).value = b_hso;
            $get(b_sl_ycId).value = a_tso[2];
            $get(b_hscdId).focus();
        }
        else if (b_dtuong.indexOf("MA_NTE") >= 0) {
            $get(b_ma_nteId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_ma_nteId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_hd_qlcv_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; form_P_MOI("", "XGL"); break;
            case "CVU": b_maId = b_cvuId; break;
            case "LNG": b_maId = b_lngId; break;
            case "NGACH": b_maId = b_ngachId; break;
            case "BAC": b_maId = b_bacId; break;
            case "MA_NTE": b_maId = b_ma_nteId; break;
            case "NCD": b_maId = b_ncdId; break;
            case "CDANH": b_maId = b_cdanhId; break;
            case "BCD": b_maId = b_bcdId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_hd_qlcv_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
        if (b_maTen == "SO_THE") ns_hd_qlcv_P_LKE();
        else if (b_maTen == "NGACH") {
            var b_ma = $get(b_ngachId).value;
            var b_lng = $get(b_lngId).value;
            if (b_lng == "") { alert("Phải nhập loại ngạch chức danh"); return; $get(b_lngId).focus(); }
        }
        else if (b_maTen == "BAC") {
            var b_lng = $get(b_lngId).value, b_ngach = $get(b_ngachId).value, b_ma = $get(b_bacId).value;
            if (b_lng == "") { alert("Phải nhập loại ngạch chức danh"); $get(b_bacId).value = ""; $get(b_lngId).focus(); return; }
            if (b_ngach == "") { alert("Phải nhập ngạch chức danh"); $get(b_bacId).value = ""; $get(b_ngachId).focus(); return; }
            sns_ma_ch.Fs_NS_MA_NGBAC_HOI(b_lng, b_ngach, b_ma, ns_hd_qlcv_hoi_NGBAC_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
        else if (b_maTen == "CDANH") {
            var b_ma = $get(b_cdanhId).value;
            var b_ncd = $get(b_ncdId).value;
            if (b_ncd == "") { alert("Phải nhập nhóm chức danh công việc"); return; $get(b_ncdId).focus(); }
        }
        else if (b_maTen == "BCD") {
            var b_ncd = $get(b_ncdId).value, b_cdanh = $get(b_cdanhId).value, b_ma = $get(b_bcdId).value;
            if (b_ncd == "") { alert("Phải nhập nhóm chức danh công việc"); $get(b_bcdId).value = ""; $get(b_ncdId).focus(); return; }
            if (b_cdanh == "") { alert("Phải nhập chức danh công việc"); $get(b_bcdId).value = ""; $get(b_ncdId).focus(); return; }
            sns_ma_ch.Fs_NS_MA_BACCDANH_HOI(b_ncd, b_cdanh, b_ma, ns_hd_qlcv_hoi_BCD_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_maTen == "CVU") {
            var b_ma = $get(b_cvuId).value;
            sns_qt.Fs_NS_MA_CVU_HOI(b_ma, ns_hd_qlcv_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hd_qlcv_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}
function ns_hd_qlcv_hoi_NGH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == "") { alert("Chưa đăng ký mã ngạch trong nhóm ngạch này!"); $get(b_ngachId).value = ""; $get(b_ngachId).focus(); }
    else {
        var a_kq = b_kq.split("#");
        $get(b_gchuId).innerHTML = a_kq[1];
    }
}
function ns_hd_qlcv_hoi_NGBAC_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq != "") {
        $get(b_hsoId).value = b_kq; $get(b_hsoId).focus();
    }
}
function ns_hd_qlcv_hoi_CDANH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == "") { alert("Chưa đăng ký mã chức danh trong nhóm chức danh này!"); $get(b_cdanhId).value = ""; $get(b_cdanhId).focus(); }
    else {
        var a_kq = b_kq.split("#");
        $get(b_gchuId).innerHTML = a_kq[1];
    }
    return false;
}
function ns_hd_qlcv_hoi_BCD_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq != "") {
        $get(b_hscdId).value = b_kq; $get(b_hscdId).focus();
    }
}
function ns_hd_qlcv_hoi_cvu_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        return;
    }
    if (b_kq != "") {
        var a_kq = b_kq.split("#");
        $get(b_hspcId).value = a_kq[0]; $get(b_gchuId).innerHTML = a_kq[1];
        $get(b_lngId).focus();
    }
}
var ns_hd_qlcv_choAct = 0;
function ns_hd_qlcv_GR_lke_RowChange() {
    if (ns_hd_qlcv_choAct != 0) clearTimeout(ns_hd_qlcv_choAct);
    ns_hd_qlcv_choAct = setTimeout("ns_hd_qlcv_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_hd_qlcv_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_hd_qlcv_lkeCho); ns_hd_qlcv_P_LKE(); }
}

function ns_hd_qlcv_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = "0";
    $get(b_gocId).focus();
    return false;
}

function ns_hd_qlcv_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), b_so_the = $get(b_gocId).value;
        sns_qt.Fs_NS_HD_LKE(b_so_the, a_cot, ns_hd_qlcv_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hd_qlcv_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang(b_grlkeId, b_kq);
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
function ns_hd_qlcv_P_NH() {
    try {
        var ktra = ktra_ngay(parseDate($get(b_ngaydId).value).getTime(), parseDate($get(b_ngaycId).value).getTime(), 1, "Từ ngày", "Đến ngày");
        if (ktra.length > 0) {
            ns_hd_qlcv_NH_KQ(ktra);
            return false;
        }
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), b_so_id = $get(b_so_idId).value;
            sns_qt.Fs_NS_HD_QLCV_NH(b_so_id, a_dt_ct, ns_hd_qlcv_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}

function ns_hd_qlcv_P_TL() {
    try {
        var b_tenf = b_tmf + '/ns/qt/ns_hd_qlcv_tl.aspx';
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = $get(b_so_idId).value;
        if (b_so_id == "0") {
            form_P_LOI("loi:Bạn phải chọn 1 hợp đồng để thanh lý:loi");
            return false;
        } else {
            var ten_cb = GridX_Fas_layGtri(b_grlkeId, b_hang, "ten");
            var so_the = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the");
            var ngay_tl = GridX_Fas_layGtri(b_grlkeId, b_hang, "ngay_tl");
            var ngayd = $get(b_ngaydId).value, ngayc = $get(b_ngaycId).value;
            form_P_MO(b_tenf, window.name, ["THAMSO", ["NS,TL,Thanh lý hợp đồng," + b_so_id + "," + so_the + "," + ten_cb + "," + ngayd + "," + ngayc + "," + ngay_tl + ""]], null);
            return false;
        }

    }
    catch (err) { form_P_LOI(err); }
}

function ns_hd_qlcv_CHECK_TONTAI_KQ(b_kq) {
    if (b_kq > 0) {
        form_P_LOI("loi:Tồn tại hợp đồng có cùng thời gian hiệu lực:loi");
        return false;
    } else {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), b_so_id = $get(b_so_idId).value;
            sns_qt.Fs_NS_HD_NH(b_so_id, a_dt_ct, ns_hd_qlcv_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
}

function ns_hd_qlcv_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        $get(b_so_idId).value = b_kq;
        var b_hang = GridX_Fi_timHangD(b_grlkeId, "so_id", b_kq);
        if (b_hang < 0) {
            b_hang = GridX_Fi_timHangT(b_grlkeId);
            if (b_hang < 0) {
                GridX_ThemHang(b_grlkeId);
                b_hang = GridX_Fi_timHangT(b_grlkeId);
            }
        }
        var b_lhd = $get(b_lhdId).value,
            b_ngayd = $get(b_ngaydId).value,
            b_ngayc = $get(b_ngaycId).value;
        GridX_datGtri(b_grlkeId, b_hang, ["so_id", "lhd", "ngayd", "ngayc"], [b_kq, b_lhd, b_ngayd, b_ngayc]);
        GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI("loi:Nhập thành công:loi");
    }
    return false;
}

function ns_hd_qlcv_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "0" || b_so_id == "") form_P_MOI(b_vungId, "XGL");
    else sns_qt.Fs_NS_HD_CT(b_so_id, ns_hd_qlcv_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = b_so_id;
}
function ns_hd_qlcv_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
function ns_hd_qlcv_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") ns_hd_qlcv_P_MOI();
    else {
        sns_qt.Fs_NS_HD_XOA(b_so_id, ns_hd_qlcv_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_hd_qlcv_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        GridX_boHang(b_grlkeId, b_hang);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_hd_qlcv_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_hd_qlcv_P_CHUYEN_HANG(); }
    }
}
function ns_hd_qlcv_P_NGAYKETTHUC() {
    try {
        var b_ma_lhd = form_Fs_TEN_GTRI(b_vungId, 'lhd');
        var b_ngayhd = $get(b_ngaydId).value;
        sns_ma_ch.Fs_NS_MA_LHD_SOTHANG(b_ngayhd,b_ma_lhd, ns_hd_qlcv_P_NGAYKETTHUC_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}

function ns_hd_qlcv_P_NGAYKETTHUC_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = b_kq.split("#");
        $get(b_so_hd).value = a_kq[1];
        if ($get(b_ngaydId).value == "" || a_kq[0] == 0) return false;
        else {
            var b_ngayd = $get(b_ngaydId).value;
            $get(b_ngaycId).value = addDays(b_ngayd, a_kq[0]); 
        }
    }
}
function addDays(date, days) {
    var result = new Date(date);
    result.setMonth(result.getMonth() + days + 1);
    result.setDate(result.getDate() - 1);
    var kq = result.format("dd/MM/yyyy");
    return kq;
}