
var b_tmf, ns_bhxh_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_sothe_tnId, b_tenId, b_tuoiId, b_so_idId, b_gchuId, b_moiId, b_doi = 0;
function ns_bhxh_P_KD(b_tm) {
    ns_bhxh_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'),
    b_tmf = b_tm, b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE'), b_tenId = form_Fs_TEN_ID(b_vungId, 'ten'), b_dk_kcbId = form_Fs_TEN_ID(b_vungId, 'dk_kcb');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu'); b_sobhxhId = form_Fs_TEN_ID(b_vungId, 'sobhxh');
}
var b_cho_control = 0;
function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_gocId).value = b_so_the;
            $get(b_tenId).value = b_ten;
            $get(b_gocId).focus();
            ns_bhxh_P_CHUYEN_HANG();
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
        if (b_dtuong.indexOf("DK_KCB") >= 0) {
            $get(b_dk_kcbId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_gocId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
var b_check = "";
function ns_bhxh_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_check = b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; form_P_MOI("", "XL"); break;
            case "DK_KCB": b_maId = b_dk_kcbId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_bhxh_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_bhxh_P_CHUYEN_HANG();
        }
        if (b_maTen=="DK_KCB")
        {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_bhxh_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_bhxh_P_DatGchu(b_kq) {    
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        if (b_check == "SO_THE") {
            $get(b_tenId).value = b_kq;
        }
        else form_P_DatGchu(b_gchuId, b_kq);
    }
}

function ns_bhxh_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_bhxh_lkeCho); ns_bhxh_P_LKE(); }
}

function ns_bhxh_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = "0";
    $get(b_gocId).focus();
    return false;
}

function ns_bhxh_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_so_the = $get(b_gocId).value;
        sns_tt.Fs_NS_BHXH_LKE(b_so_the, a_tso, a_cot, ns_bhxh_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function ns_bhxh_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}

function ns_bhxh_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
            sns_cd.Fs_NS_BHXH_NH(a_dt_ct, ns_bhxh_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}

function ns_bhxh_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI("loi:Nhập dữ liệu thành công! :loi");
        $get(b_gocId).focus();
    }
    return false;
}

function ns_bhxh_P_CHUYEN_HANG() {
    var b_so_the = $get(b_gocId).value;
    sns_cd.Fs_NS_BHXH_CT(b_so_the, ns_bhxh_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}

function ns_bhxh_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}

function ns_bhxh_P_XOA() {
    var b_so_the = $get(b_gocId).value;
    sns_cd.Fs_NS_BHXH_XOA(b_so_the, ns_bhxh_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_bhxh_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI("loi:Xóa dữ liệu thành công! :loi");
        form_P_MOI(b_vungId, "XL");
        $get(b_gocId).focus();
    }
}

function open_thaydoi()
{
    var b_so_the = $get(b_gocId).value,
        b_ten = $get(b_tenId).value;
    form_P_MO("ns_bhxh_thaydoi.aspx", null, ["KQ", [b_so_the, b_ten]]);
    return false;
}

function open_quatrinh() {
    var b_so_the = $get(b_gocId).value,
        b_ten = $get(b_tenId).value,
        b_sobhxh = $get(b_sobhxhId).value;
    form_P_MO("ns_bhxh_qt.aspx", null, ["KQ", [b_so_the, b_ten,b_sobhxh]]);
    return false;
}

function nhap_file() {
    var b_tenf = b_tmf + '/ns/ma/file_luu.aspx';
    var b_so_the = $get(b_gocId).value;
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "BHXH", b_so_the, "Lưu Bảo Hiểm"]], null);
    return false;
}