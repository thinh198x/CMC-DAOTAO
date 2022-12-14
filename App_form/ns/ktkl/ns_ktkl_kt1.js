var ns_ktkl_kt_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_hinhthucId, b_so_idId, b_gchuId, b_doi = 0;
function ns_ktkl_kt_P_KD(b_tm) {
    ns_ktkl_kt_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
     b_tmf = b_tm, b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE'); b_hinhthucId = form_Fs_TEN_ID(b_vungId, 'hinhthuc'); b_tenId = form_Fs_TEN_ID(b_vungId, 'ten');
    b_phongId = form_Fs_TEN_ID(b_vungId, 'phong');
    b_cap_ktklId = form_Fs_TEN_ID(b_vungId, 'cap_ktkl'); b_noi_ktklId = form_Fs_TEN_ID(b_vungId, 'noi_ktkl');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_slideId = b_grlkeId + '_slide';

}

var b_cho_control = 0;
function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_gocId).value = b_so_the;
            $get(b_tenId).value = b_ten;
            //$get(b_phongId).value = b_phong;
            $get(b_gchuId).innerHTML = b_ten;
            $get(b_gocId).focus();
            ns_ktkl_kt_P_LKE();
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
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            $get(b_gocId).setAttribute("disabled", "disabled");
            $get(b_gocId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            ns_ktkl_kt_P_LKE();
            $get(b_gocId).focus();
        }
        else if (b_dtuong.indexOf("HINHTHUC") >= 0) {
            $get(b_hinhthucId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_hinhthucId).focus();
        }
        else if (b_dtuong.indexOf("CAP_KTKL") >= 0) {
            $get(b_cap_ktklId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_cap_ktklId).focus();
        }
        else if (b_dtuong.indexOf("NOI_KTKL") >= 0) {
            $get(b_noi_ktklId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_noi_ktklId).focus();
        }
        else if (b_dtuong.indexOf("THAMSO") >= 0) {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ktkl_kt_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; form_P_MOI("", "XGL"); break;
            case "HINHTHUC": b_maId = b_hinhthucId; break;
            case "CAP_KTKL": b_maId = b_cap_ktklId; break;
            case "NOI_KTKL": b_maId = b_noi_ktklId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_ktkl_kt_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_ktkl_kt_P_LKE();
        }
        else if (b_maTen == "HINHTHUC") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_ktkl_kt_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_maTen == "CAP_KTKL") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_ktkl_kt_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_maTen == "NOI_KTKL") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_ktkl_kt_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ktkl_kt_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else form_P_DatGchu(b_gchuId, b_kq);
}

var ns_ktkl_kt_choAct = 0;
function ns_ktkl_kt_GR_lke_RowChange() {
    if (ns_ktkl_kt_choAct != 0) clearTimeout(ns_ktkl_kt_choAct);
    ns_ktkl_kt_choAct = setTimeout("ns_ktkl_kt_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_ktkl_kt_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_ktkl_kt_lkeCho); ns_ktkl_kt_P_LKE(); }
}
function ns_ktkl_kt_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = "0";
    $get(b_gocId).focus();
    return false;
}
function ns_ktkl_kt_P_MOI_FULL() {
    form_P_MOI(b_vungId, "X");
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = "0";
    $get(b_gocId).focus();
    return false;
}
function ns_ktkl_kt_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_so_the = $get(b_gocId).value;
        sns_ktkl.Fs_NS_KTKL_KT_LKE(b_so_the, a_tso, a_cot, ns_ktkl_kt_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ktkl_kt_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}

function ns_ktkl_kt_P_NH() {

    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
            sns_ktkl.Fs_NS_KTKL_KT_NH(b_so_id, b_TrangKt, a_dt_ct, a_cot_lke, ns_ktkl_kt_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}

function ns_ktkl_kt_NH_KQ(b_kq) {
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

function ns_ktkl_kt_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "0") form_P_MOI(b_vungId, "XGL");
    else sns_ktkl.Fs_NS_KTKL_KT_CT(b_so_id, ns_ktkl_kt_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = b_so_id;
}
function ns_ktkl_kt_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == "") form_P_MOI(b_vungId, "XGL");
    else form_P_CH_TEXT(b_vungId, b_kq);
}
function ns_ktkl_kt_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }

    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }

    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"),
        b_so_the = $get(b_gocId).value;
    if (b_so_id == "") ns_ktkl_kt_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ktkl.Fs_NS_KTKL_KT_XOA(b_so_id, b_so_the, a_tso, a_cot, ns_ktkl_kt_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_ktkl_kt_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_ktkl_kt_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_ktkl_kt_P_CHUYEN_HANG(); }
    }
}
function nhap_file() {

    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) {
        form_P_LOI('loi:Bạn phải chọn 1 bản ghi:loi')
        return false;
    }
    var b_tenf = b_tmf + '/ns/ma/file_Import_chung.aspx';
    var b_so_the = $get(b_gocId).value;
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "KTKL_KT", b_so_the, "Lưu File khen thưởng cá nhân"]], null);
    return false;
}
function form_dong() {
    location.reload(false);
}
function ns_ktkl_kt_P_IN() {
    __doPostBack('ctl00$ContentPlaceHolder1$Nhap2', '');//Xuất Excel
}
