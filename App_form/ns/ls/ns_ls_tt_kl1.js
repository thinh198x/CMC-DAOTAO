var b_cho_control = 0, b_choAct = 0, b_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_gchuId, b_doi = 0, b_tenId, b_so_the_an_Id;
function ns_ls_tt_kl_P_KD(b_tm) {
    b_tmf = b_tm, b_lkeCho = setInterval('ns_ls_tt_kl_P_LKE_CHO()', 200);
}
function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_gocId).value = b_so_the;
            $get(b_tenId).value = b_ten;
            $get(b_gocId).focus();
            ns_ls_tt_kl_P_LKE();
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
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
            if (a_tso[0] == 'FILE_HTOAN') {
                ns_ls_tt_kl_P_LKE();
            }
        }
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            $get(b_gocId).setAttribute("disabled", "disabled");
            $get(b_gocId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            ns_ls_tt_kl_P_LKE();
            $get(b_gocId).focus();
        }
        else if (b_dtuong.indexOf("THAMSO") >= 0) {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ls_tt_kl_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; form_P_MOI("", "XGL"); break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_ls_tt_kl_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_ls_tt_kl_P_LKE();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ls_tt_kl_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        $get(b_tenId).value = b_kq;
    }
}
function ns_ls_tt_kl_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(b_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE'); b_tenId = form_Fs_TEN_ID(b_vungId, 'TEN'), b_gchuId = form_Fs_VTEN_ID('', 'gchu');
        b_slideId = $get(b_grlkeId).getAttribute('slideId'); slide_P_MOI(b_slideId);
        b_so_the_an_Id = form_Fs_TEN_ID(b_vungId, 'ASOTHE');
        ns_ls_tt_kl_P_LKE();
    }
}
function ns_ls_tt_kl_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_so_the = $get(b_gocId).value;
        sns_ls.Fs_NS_LS_KL_LKE(b_so_the, a_tso, a_cot, ns_ls_tt_kl_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ls_tt_kl_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
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
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "KTKL_KL", b_so_the, "Lưu File kỷ luật cá nhân"]], null);
    return false;
}
function sosanh_Date(str1, str2) {
    var kq;
    if (str1 == "" || str2 == "")
        kq = false;
    else {
        var mdy_str1 = str1.split('/');
        var mdy_str1 = mdy_str1[2] + mdy_str1[1] + mdy_str1[0];
        var mdy_str1 = parseInt(mdy_str1);
        var mdy_str2 = str2.split('/');
        var mdy_str2 = mdy_str2[2] + mdy_str2[1] + mdy_str2[0];
        var mdy_str2 = parseInt(mdy_str2);
        kq = mdy_str2 - mdy_str1;
    }
    return kq;
}
function form_dong() {
    location.reload(false);
}
function ns_ls_tt_kl_P_IN() {
    var b_so_the = $get(b_gocId).value;
    $get(b_so_the_an_Id).value = b_so_the;
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
