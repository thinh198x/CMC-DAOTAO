
var tl_ems_imp_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_gchuId, b_ctrbeforId, b_ctyValue, b_khoadtId, b_gchu, b_phongId, b_aphongId, b_aNhomluongId, b_akyluongId, b_nhomluongId, b_kycongId;
function tl_ems_imp_P_KD() {
    tl_ems_imp_lkeCho = setInterval('tl_ems_imp_P_LKE_CHO()', 200);
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "" || a_tso[0] == "FILE_HTOAN")
            return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        b_doi = 0;
        if (b_dtuong.indexOf("SO_THE") >= 0 || b_dtuong.indexOf("THAMSO") >= 0) {
            $get(b_gchu).value = a_tso[1];
            $get(b_so_the).value = a_tso[0];
        }
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function tl_ems_imp_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_so_the;
                form_P_MOI("", "XGL");
                break;
            case "PHONG":
                b_maId = b_phongId;
            case "KYLUONG":
                b_maId = b_kycongId;
            case "NHOMLUONG":
                b_maId = b_nhomluongId;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "")
            return;
        if (b_maTen == "PHONG" || b_maTen == "KYLUONG" || b_maTen == "NHOMLUONG") {
            $get(b_akyluongId).value = lke_Fs_TRA($get(b_kycongId));
            $get(b_aNhomluongId).value = form_Fs_TEN_GTRI(b_vungId, 'NHOMLUONG');
            tl_ems_imp_P_LKE('K');
        }
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function tl_ems_imp_P_MA_KTRA() {
    try {
        var b_ma = "";
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId),
                a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_qt.Fs_tl_ems_imp_MA(b_ma, b_TrangKt, a_cot, tl_ems_imp_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function tl_ems_imp_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        return;
    }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1,
        b_trang = CSO_SO(a_kq[1]),
        b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1)
        form_P_MOI(b_vungId, "X");
    else {
        GridX_datA(b_grlkeId, b_hang);
        tl_ems_imp_P_CHUYEN_HANG();
    }
}

var tl_ems_imp_choAct = 0;
function tl_ems_imp_GR_lke_RowChange() {
    try {
        if (tl_ems_imp_choAct != 0)
            clearTimeout(tl_ems_imp_choAct);
        tl_ems_imp_choAct = setTimeout("tl_ems_imp_P_CHUYEN_HANG()", 300);
        return false;
    }
    catch (err) {
        form_P_LOI(err);
    }
}

function tl_ems_imp_P_LKE_CHO() {
    try {

        if (document.readyState === 'complete') {
            b_vungId = form_Fs_VUNG_ID('UPa_ct');
            b_grlkeId = form_Fs_VUNG_ID('GR_lke');
            b_gchu = form_Fs_VTEN_ID('', 'GCHU');
            b_phongId = form_Fs_TEN_ID(b_vungId, 'phong');
            b_namId = form_Fs_TEN_ID(b_vungId, 'nam');
            b_nhomluongId = form_Fs_TEN_ID(b_vungId, 'Nhomluong');
            b_kycongId = form_Fs_TEN_ID(b_vungId, 'kyluong');
            b_aphongId = form_Fs_VTEN_ID('UPa_hi', 'aphong');
            b_akyluongId = form_Fs_VTEN_ID('UPa_hi', 'akyluong');
            b_aNhomluongId = form_Fs_VTEN_ID('UPa_hi', 'anhomluong');
            if (tl_ems_imp_lkeCho != 0)
                clearTimeout(tl_ems_imp_lkeCho);
            b_slideId = $get(b_grlkeId).getAttribute('slideId');
            slide_P_SOTRANG(b_slideId, 0);
            form_F_GOC().P_MENUBf(window.name, 'M');
            vb_cctc_P_SL('', 'D', '0', ' ', ' ', 'T');
            b_ctyValue = "TATCA";
            tl_ems_imp_CT_KYLUONG();
        }
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function tl_ems_imp_CT_KYLUONG() {
    try {
        var b_form = "tl_ems_imp", b_nam = "DT_NAM", b_thang = "DT_KY";
        hts_dungchung.Fs_NS_CC_KY(form_Fs_nsd(), b_form, b_nam, b_thang, tl_ems_imp_CT_KYLUONG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function tl_ems_imp_CT_KYLUONG_KQ(b_kq) {
    if (b_kq != "") {
        form_P_CH_TEXT(b_vungId, b_kq);
    }
    //tl_ems_imp_P_LKE('K');
}
function tl_ems_imp_P_LKE() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") {
            form_P_LOI(b_loi);
            return false;
        }
        var a_cot = GridX_Fas_tenCot(b_grlkeId);
        var a_tso = slide_Faobj_TUDEN(b_slideId);
        var a_kycong = form_Fs_TEN_GTRI(b_vungId, 'KYLUONG');

        stl_ch.Fs_TL_EMS_IMP_LKE(b_ctyValue, a_kycong, a_tso, a_cot, tl_ems_imp_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function tl_ems_imp_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        return;
    }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);

}

function tl_ems_imp_P_NAM() {
    try {
        var b_nam = form_Fs_TEN_GTRI(b_vungId, 'NAM');
        stl_cc.Fs_NS_TL_MA_KYLUONG_LKE(form_Fs_nsd(), b_nam, tl_ems_imp_P_NAM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function tl_ems_imp_P_NAM_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        tl_ems_imp_P_KTRA("KYLUONG");
    }
}
function form_dong() {
    location.reload(false);
}

function tl_ems_imp_Export() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }

    $get(b_aphongId).value = b_ctyValue;
    $get(b_aNhomluongId).value = form_Fs_TEN_GTRI(b_vungId, 'NHOMLUONG');
    $get(b_akyluongId).value = form_Fs_TEN_GTRI(b_vungId, 'KYLUONG');
    __doPostBack('ctl00$ContentPlaceHolder1$xuatexcel', '');
    //var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    //$get(b_btn_excel).click(); form_chay = 0;
    form_P_LOI('');
    return false;
}

function tl_ems_imp_Import() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") {
        form_P_LOI(b_loi);
        return false;
    }

    var b_tenf = '/App_form/ns/ma/file_Import.aspx';
    form_P_MO(b_tenf, window.name + ',THAMSO', ['THAMSO', [window.name, 'TL_EMS_IMP', null, "Import EMS", $get(b_namId).value, lke_Fs_TRA($get(b_kycongId))]], null);
    form_P_LOI('');
    return false;
}

function vb_cctc_P_CLICK(b_event, b_id) {
    b_event.stopPropagation();
    var b_targetClassNam = b_event.target.className;
    if (b_targetClassNam == "ico_bptt") {
        var b_ctr = $get(b_id), b_div = $get(b_id + '_Div');
        var a_tso = Attribute_Fas_LAY(b_ctr, 'loai,cap,dvi,ma,ma_ct');
        if (b_ctrbeforId != null) b_ctrbeforId.style.fontWeight = "100";
        $get(b_aphongId).value = b_ctyValue;
        b_ctr.style.fontWeight = "700";
        b_ctrbeforId = b_ctr;
        b_ctyValue = a_tso[3];
        // load lại dữ liệu 
        $get(b_aphongId).value = b_ctyValue;
        if (b_ctyValue != "") tl_ems_imp_P_LKE();
        return false;
    }
    else {
        var b_ctr = $get(b_id),
            b_div = $get(b_id + '_Div');
        var a_tso = Attribute_Fas_LAY(b_ctr, 'loai,cap,dvi,ma,ma_ct');
        if (a_tso[0] == 'A')
            return false;
        if (a_tso[0] != 'C') {
            if (b_div == null)
                vb_cctc_P_SL(b_id, a_tso[0], a_tso[1], a_tso[2], a_tso[3]);
            else {
                b_id = (C_NVL(b_div.style.display) == '') ? '' : b_id;
                vb_cctc_HIEN(a_tso[4], b_id);
            }
        }
    }
    return false;
}
