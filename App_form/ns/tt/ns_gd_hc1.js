
var ns_gd_hc_lkeCho, b_vungId, b_grlkeId, b_grctId, b_gocId, b_mt, b_gchuId, b_doi = 0;
function ns_gd_hc_P_KD() {
    ns_gd_hc_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
    b_ngayId = form_Fs_TEN_ID(b_vungId, 'ngayd'), b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'); b_slideId = b_grlkeId + '_slide';
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    ns_gd_hc_lkeCho = setInterval('ns_gd_hc_P_LKE_CHO()', 200);
}

var b_cho_control = 0;
function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_gocId).value = b_so_the;
            $get(b_gchuId).innerHTML = b_ten;
            $get(b_gocId).focus();
            ns_gd_hc_P_LKE();
            b_doi = 1;
            clearTimeout(b_cho_control);
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
        b_doi = 0;
        if (b_dtuong.indexOf("SO_THE") >= 0 || b_dtuong.indexOf("THAMSO") >= 0) {
            $get(b_gocId).setAttribute("disabled", "disabled");
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_gd_hc_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; form_P_MOI("", "XGL"); GridX_datTrang(b_grctId); break;
            case "NGAY": b_maId = b_ngayId; break;
        }
        var b_ma = $get(b_maId);
        b_mt = b_maTen;
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_gd_hc_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_gd_hc_P_LKE();
        }
        else if (b_maTen == "NGAY") {
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ngayd", b_ma.value);
            if (b_hang < 0) { ns_gd_hc_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_gd_hc_P_CHUYEN_HANG(); }
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_gd_hc_P_MA_KTRA() {
    try {
        var b_ngay = C_NVL($get(b_ngayId).value);
        if (b_ngay != "") {
            var b_so_the = $get(b_gocId).value;
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_tt.Fs_NS_GD_HC_MA(b_so_the, b_ngay, b_TrangKt, a_cot, ns_gd_hc_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_gd_hc_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        form_P_MOI(b_vungId, "X"); GridX_datTrang(b_grctId);
        $get(b_gocId).focus(); $get(b_so_idId).value = "0";
    }
    else { GridX_datA(b_grlkeId, b_hang); ns_gd_hc_P_CHUYEN_HANG(); }
}
function ns_gd_hc_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    $get(b_gchuId).innerHTML = b_kq;
}

var ns_gd_hc_choAct = 0;
function ns_gd_hc_GR_lke_RowChange() {
    if (ns_gd_hc_choAct != 0) clearTimeout(ns_gd_hc_choAct);
    ns_gd_hc_choAct = setTimeout("ns_gd_hc_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_gd_hc_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_gd_hc_lkeCho); ns_gd_hc_P_LKE(); }
}

function ns_gd_hc_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    $get(b_so_idId).value = "0";
    $get(b_gocId).focus();
    return false;
}
function ns_gd_hc_P_LKE() {
    try {
        var b_so_the = $get(b_gocId).value,
            a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_tt.Fs_NS_GD_HC_LKE(b_so_the, a_tso, a_cot, ns_gd_hc_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_gd_hc_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_gd_hc_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_dt = form_Faa_TEXT_ROW(b_vungId),
                a_cot_ct = GridX_Fdt_cotGtri(b_grctId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
            sns_tt.Fs_NS_GD_HC_NH(b_so_id, b_TrangKt, b_dt, a_cot_ct, a_cot_lke, ns_gd_hc_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_gd_hc_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        form_P_LOI("Nhập thành công");
        $get(b_gocId).focus();
    }
    return false;
}
function ns_gd_hc_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == null || b_so_id == "") { form_P_MOI("", "XGL"); GridX_datTrang(b_grctId); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        sns_tt.Fs_NS_GD_HC_CT(b_so_id, a_cot_ct, ns_gd_hc_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function ns_gd_hc_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    $get(b_so_idId).value = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
}
function ns_gd_hc_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") ns_gd_hc_P_MOI();
    else {
        var b_so_the = $get(b_gocId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_tt.Fs_NS_GD_HC_XOA(b_so_id, b_so_the, a_tso, a_cot, ns_gd_hc_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_gd_hc_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_gd_hc_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_gd_hc_P_CHUYEN_HANG(); }
    }
}
function ns_gd_hc_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_gd_hc_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_gd_hc_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function ns_gd_hc_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}
