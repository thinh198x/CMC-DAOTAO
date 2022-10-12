var hd_ma_quyluong_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_ncdanhId, b_gchuId, b_ncdanhten, b_gchu, b_dvi;
function hd_ma_quyluong_P_KD() {
    hd_ma_quyluong_lkeCho,
    b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),

    b_gchu = form_Fs_VUNG_ID('UPa_gchu')
    b_gocId = form_Fs_TEN_ID(b_vungId, 'DVI');
    //b_tenId = form_Fs_TEN_ID(b_vungId, 'TEN');
    b_ncdanhId = form_Fs_TEN_ID(b_vungId, 'MA_CDANH');
    b_dvi = form_Fs_TEN_ID(b_vungId, 'DVI');
    b_nam_db = form_Fs_TEN_ID(b_vungId, 'nam_db');
    b_gchuId = form_Fs_TEN_ID(b_gchu, 'gchu');
    b_slideId = b_grlkeId + '_slide';
    hd_ma_quyluong_lkeCho = setInterval('hd_ma_quyluong_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        switch (b_dtuong) {
            case 'CTL00_CONTENTPLACEHOLDER1_MA_CDANH':
                if (b_dtuong.indexOf("MA_CDANH") >= 0) {
                    $get(b_ncdanhId).value = a_tso[0];
                    var b_nam, b_madonvi, b_cdanh;
                    b_nam = $get(b_nam_db).value;
                    b_madonvi = $get(b_dvi).value;
                    b_cdanh = a_tso[0];
                    sns_td.Fs_HDNS_DINHBIEN_NS_LKE(b_nam, b_madonvi, b_cdanh, hdns_qluong_dinhbien_ns_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                }
                break;
            case 'CTL00_CONTENTPLACEHOLDER1_DVI':
                if (b_dtuong.indexOf("DVI") >= 0) {
                    $get(b_dvi).value = a_tso[0];
                    ns_ma_cdanh_P_LKE(); form_P_MOI(b_vungId, "GX");
                    $get(b_gchuId).innerHTML = a_tso[1];
                }
                break;
            case 'CTL00_CONTENTPLACEHOLDER1_MA2':
                if (b_dtuong.indexOf("MA2") >= 0) {
                    sns_td.Fs_HDNS_DINHBIEN_NS_CT_CT(a_tso[0], hd_ma_quyluong_CT_CT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                }
                break;
        }
    }
    catch (err) { form_P_LOI(err); }
}

function hdns_qluong_dinhbien_ns_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq != "") {
        var a_kq = Fas_ChMang(b_kq, '|');
        $get(form_Fs_TEN_ID(b_vungId, 'NS_HT')).value = a_kq[3]
        $get(form_Fs_TEN_ID(b_vungId, 'DB_tb')).value = a_kq[16]
    }
    return false;
}


function hd_ma_quyluong_CT_CT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
    }
    return false;
}
function hd_ma_quyluong_P_KTRA(b_maTen) {
    try {
        //skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), hd_ma_quyluong_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
        //hd_ma_quyluong_P_LKE();
        //var b_mannghe = $get(b_ma_manghe_Id).value, b_ma_cmon = $get(b_ma_cmon_Id).value, b_ma_nngiep = $get(b_ma_nnnghe_Id).value, b_capbac = $get(b_ma_capbac_Id).value;
        //b_m.value = b_mannghe + '.' + b_ma_cmon + '.' + b_ma_nngiep + '.' + b_capbac;
        //$get(b_ma_cmon_Id).focus();
        switch (b_maTen) {
            case 'DVI':
                var b_ma = $get(b_gocId);
                skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), hd_ma_quyluong_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
                break;
            case 'MA_CDANH':
                var b_ma = $get(b_ncdanhId);
                skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), hd_ma_quyluong_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
                break;
            default:
                var b_dat = Fas_ChMang(b_maTen, '=');
                var ktra = Fas_ChMang(b_dat[0], ',');
                if (ktra.length > 1) {
                    if (b_dat.length > 1) {
                        var b_datgtri = SO_CSO(tinhtong(b_dat[0]));
                        var b_ctrdatgtri = form_Fs_TEN_ID(b_vungId, '' + b_dat[1] + '');
                        $get(b_ctrdatgtri).value = b_datgtri;
                        tinhtongtong('TONG_DB_NCONG,DB_TGIO_TONG,THUONG_TONG,DB_PC_TD_TONG=QUYL_TONG');
                    }
                }
        }
        
    }
    catch (err) { form_P_LOI(err); }
}
function hd_ma_quyluong_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    form_P_MOI(b_vungId, "X");
    //$get(b_gocId).focus();
}
var hd_ma_quyluong_choAct = 0;
function hd_ma_quyluong_GR_lke_RowChange() {
    if (hd_ma_quyluong_choAct != 0) clearTimeout(hd_ma_quyluong_choAct);
    hd_ma_quyluong_choAct = setTimeout("hd_ma_quyluong_P_CHUYEN_HANG()", 300);
    return false;
}

function hd_ma_quyluong_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(hd_ma_quyluong_lkeCho); hd_ma_quyluong_P_LKE(); }
}

function hd_ma_quyluong_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_hdns.Fs_HD_MA_QUYLUONG_NH(form_Fs_nsd(), b_TrangKt, a_dt_ct, a_cot, hd_ma_quyluong_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}

function hd_ma_quyluong_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        hd_ma_quyluong_P_CHUYEN_HANG();
        $get(b_gocId).focus();
    }
    return false;
}

function hd_ma_quyluong_P_MOI() {
    var b_nam = new Date().getFullYear();
    form_P_MOI(b_vungId, "GXL");
    $get(b_gocId).focus();
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang > 0) GridX_thoiA(b_grlkeId, b_hang);
    //skhac.Fdt_NAM(window.name, hd_ma_quyluong_nam_P_KQ, P_LOI_CSDL, P_LOI_TGIAN)
    var b_nam_db = form_Fctr_TEN_DTUONG(b_vungId, 'NAM_DB');
    b_outerHTML = "<input name=\"ctl00$ContentPlaceHolder1$NAM_DB\" class=\"css_form\" id=\"ctl00_ContentPlaceHolder1_NAM_DB\" style=\"width: 160px;\" onkeydown=\"lke_XUONG(event);\" onblur=\"form_LIST_AN(event);\" type=\"text\" ten_goc=\"NAM_DB\" ham_list=\"DT_NAM\" xep=\"2\" ten=\"NAM_DB\" dropl=\"K\" nhap=\"C\" traan=\"" + b_nam + "\">";
    b_nam_db.outerHTML = b_outerHTML;
    return false;
}
//function hd_ma_quyluong_nam_P_KQ(b_kq) {
//    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
//    return false;
//}

function hd_ma_quyluong_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }

    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_ma == "") hd_ma_quyluong_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_HD_MA_QUYLUONG_XOA(form_Fs_nsd(), b_ma, a_tso, a_cot, hd_ma_quyluong_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function hd_ma_quyluong_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) hd_ma_quyluong_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); hd_ma_quyluong_P_CHUYEN_HANG(); }
    }
}
function hd_ma_quyluong_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_ma == "") form_P_MOI(b_vungId, "XGL"); else { form_P_GridX_TEXT(b_vungId, b_grlkeId); }
    }
    catch (err) { form_P_LOI(err); }
}

function hd_ma_quyluong_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_HD_MA_QUYLUONG_LKE(form_Fs_nsd(), a_cot, a_tso, hd_ma_quyluong_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function hd_ma_quyluong_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    $get(b_dvi).focus();
}

function form_P_CHON() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang > 0 && C_NVL($get(b_gocId).value) != '') {
        var b_ten = $get(b_tenId).value, b_ma = $get(b_gocId).value;
        form_P_DAY(window.name, "ns_hoachdinh", "MA_CDANH", [b_ma, b_ten]);
        form_P_TRA_CHON('MA,TEN,NCDANH');
    }
    else
        form_P_LOI('loi:Chưa chọn mã chức danh:loi');
    return false;
}
function form_dong() {
    location.reload(false);
}
function hd_ma_quyluong_P_IN() {
    __doPostBack('ctl00$ContentPlaceHolder1$Nhap2', '');//Xuất Excel
}
function tinhtong(b_kq) {
    var arr = Fas_ChMang(b_kq, ',');
    var kq = 0;
    for (var i = 0; i < arr.length; i++) {
        kq += CSO_SO(($get(form_Fs_TEN_ID(b_vungId, '' + arr[i] + '')).value), 0);
    }
    return kq;
}

function tinhtongtong(b_kq) {
    var b_dat = Fas_ChMang(b_kq, '=');
    if (b_dat.length > 1) {
        var b_datgtri = SO_CSO(tinhtong(b_dat[0]));
        var b_ctrdatgtri = form_Fs_TEN_ID(b_vungId, '' + b_dat[1] + '');
        $get(b_ctrdatgtri).value = b_datgtri;
    }
}