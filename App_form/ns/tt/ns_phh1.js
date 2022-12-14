
var ns_phh_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId,b_nhomcnganhId,b_cnganhId,b_hochamId,b_so_idId,b_gchuId,b_moiId;
function ns_phh_P_KD() {
    ns_phh_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE'), b_nhomcnganhId = form_Fs_TEN_ID(b_vungId, 'nhom_cnganh'),
        b_cnganhId = form_Fs_TEN_ID(b_vungId, 'cnganh'), b_hochamId = form_Fs_TEN_ID(b_vungId, 'HOCHAM');
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
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            $get(b_gocId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            ns_phh_P_LKE();
            $get(b_gocId).focus();
        }
        else if (b_dtuong.indexOf("NHOM_CNGANH") >= 0) {
            $get(b_nhomcnganhId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_cnganhId).focus();
        }
        else if (b_dtuong.indexOf("CNGANH") >= 0) {
            $get(b_cnganhId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_hochamId).focus();
        }
        else if (b_dtuong.indexOf("HOCHAM") >= 0) {
            $get(b_hochamId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_hochamId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_phh_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; form_P_MOI("", "XGL"); break;
            case "CNGANH": b_maId = b_cnganhId; break;
            case "NHOM_CNGANH": b_maId = b_nhomcnganhId; break;
            case "HOCHAM": b_maId = b_hochamId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_phh_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_phh_P_LKE();
        }
        else skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_phh_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_phh_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}

var ns_phh_choAct = 0;
function ns_phh_GR_lke_RowChange() {
    if (ns_phh_choAct != 0) clearTimeout(ns_phh_choAct);
    ns_phh_choAct = setTimeout("ns_phh_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_phh_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_phh_lkeCho); ns_phh_P_LKE(); }
}

function ns_phh_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = "0";
    $get(b_gocId).focus();
    return false;
}

function ns_phh_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_so_the = $get(b_gocId).value;
        sns_tt.Fs_NS_PHH_LKE(b_so_the, a_tso, a_cot, ns_phh_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_phh_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}

function ns_phh_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var b_so_id = $get(b_so_idId).value;
            sns_tt.Fs_NS_PHH_NH(b_so_id, b_TrangKt, a_dt_ct, a_cot_lke, ns_phh_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}

function ns_phh_NH_KQ(b_kq) {
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

function ns_phh_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "0") form_P_MOI(b_vungId, "XGL");
    else sns_tt.Fs_NS_PHH_CT(b_so_id, ns_phh_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = b_so_id;
}
function ns_phh_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
function ns_phh_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"),
        b_so_the = $get(b_gocId).value;
    if (b_so_id == "") ns_phh_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_tt.Fs_NS_PHH_XOA(b_so_id, b_so_the, a_tso, a_cot, ns_phh_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_phh_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_phh_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_phh_P_CHUYEN_HANG(); }
    }
}

function nhap_file() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) {
        form_P_LOI('loi:Chọn hàng trước:loi')
        return false;
    }
    var b_tenf = form_Fs_TM('f') + '/ns/ma/file_luu.aspx';
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "FILE_PHH", b_so_id, "Lưu hồ sơ học hàm/danh hiệu"]], null);
    return false;
}