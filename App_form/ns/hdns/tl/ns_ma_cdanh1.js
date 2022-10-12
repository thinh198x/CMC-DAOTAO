var ns_ma_cdanh_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_tenId, b_ma_manghe_Id, b_ma_cmon_Id, b_ma_nnnghe_Id, b_ma_capbac_Id, b_drop;
function ns_ma_cdanh_P_KD() {
    ns_ma_cdanh_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_slideId = b_grlkeId + '_slide';
    b_ma_manghe_Id = form_Fs_TEN_ID(b_vungId, 'MA_NNGHE'), b_ma_cmon_Id = form_Fs_TEN_ID(b_vungId, 'MA_CMON');
    b_ma_nnnghe_Id = form_Fs_TEN_ID(b_vungId, 'MA_NNNGHE'), b_ma_capbac_Id = form_Fs_TEN_ID(b_vungId, 'MA_CAPBAC');
    b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'), b_tenId = form_Fs_TEN_ID(b_vungId, 'TEN');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    ns_ma_cdanh_lkeCho = setInterval('ns_ma_cdanh_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {

        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
            if (a_tso[0] == 'FILE_HTOAN') {
                ns_ma_cdanh_P_LKE();
            }
        }
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        var b_m = form_Fctr_TEN_DTUONG(b_vungId, 'ma');
        if (b_dtuong.indexOf("THAMSO") >= 0 && a_tso.length == 4) {
            $get(b_ma_nnnghe_Id).value = a_tso[0];
            $get(b_ma_capbac_Id).value = a_tso[1];
            $get(b_ma_manghe_Id).value = a_tso[2];
            $get(b_ma_cmon_Id).value = a_tso[3];
            ns_ma_cdanh_P_KTRA('MA_CAPBAC');
        }
        else if (b_dtuong.indexOf("MA_NNGHE") >= 0) {
            $get(b_ma_manghe_Id).value = b_kq;
            ns_ma_cdanh_P_LKE(); form_P_MOI(b_vungId, "GLNMX");
            $get(b_gchuId).innerHTML = a_tso[1];
            var b_mannghe = $get(b_ma_manghe_Id).value, b_ma_cmon = $get(b_ma_cmon_Id).value, b_ma_nngiep = $get(b_ma_nnnghe_Id).value, b_capbac = $get(b_ma_capbac_Id).value;
            b_m.value = b_mannghe + '.' + b_ma_cmon + '.' + b_ma_nngiep + '.' + b_capbac;
            $get(b_ma_cmon_Id).focus();
        }

        else if (b_dtuong.indexOf("MA_CMON") >= 0) {
            $get(b_ma_cmon_Id).value = b_kq;
            ns_ma_cdanh_P_LKE(); form_P_MOI(b_vungId, "GNMX");
            $get(b_gchuId).innerHTML = a_tso[1];
            var b_mannghe = $get(b_ma_manghe_Id).value, b_ma_cmon = $get(b_ma_cmon_Id).value, b_ma_nngiep = $get(b_ma_nnnghe_Id).value, b_capbac = $get(b_ma_capbac_Id).value;
            b_m.value = b_mannghe + '.' + b_ma_cmon + '.' + b_ma_nngiep + '.' + b_capbac;
            $get(b_ma_nnnghe_Id).focus();
        }

        else if (b_dtuong.indexOf("MA_NNNGHE") >= 0) {
            $get(b_ma_nnnghe_Id).value = b_kq;
            ns_ma_cdanh_P_LKE(); form_P_MOI(b_vungId, "NMX");
            $get(b_gchuId).innerHTML = a_tso[1];
            var b_mannghe = $get(b_ma_manghe_Id).value, b_ma_cmon = $get(b_ma_cmon_Id).value, b_ma_nngiep = $get(b_ma_nnnghe_Id).value, b_capbac = $get(b_ma_capbac_Id).value;
            b_m.value = b_mannghe + '.' + b_ma_cmon + '.' + b_ma_nngiep + '.' + b_capbac;
            $get(b_ma_capbac_Id).focus();
        }

        else if (b_dtuong.indexOf("MA_CAPBAC") >= 0) {
            $get(b_ma_capbac_Id).value = b_kq;
            ns_ma_cdanh_P_LKE(); form_P_MOI(b_vungId, "MX");
            $get(b_gchuId).innerHTML = a_tso[1];
            var b_mannghe = $get(b_ma_manghe_Id).value, b_ma_cmon = $get(b_ma_cmon_Id).value, b_ma_nngiep = $get(b_ma_nnnghe_Id).value, b_capbac = $get(b_ma_capbac_Id).value;
            b_m.value = b_mannghe + '.' + b_ma_cmon + '.' + b_ma_nngiep + '.' + b_capbac;
            $get(b_gocId).focus();
        }

        else if (b_dtuong.indexOf("THAMSO") >= 0) {
            $get(b_ma_nnnghe_Id).value = b_kq;
            ns_ma_cdanh_P_LKE(); form_P_MOI(b_vungId, "MX");
            $get(b_gchuId).innerHTML = a_tso[1];
            var b_mannghe = $get(b_ma_manghe_Id).value, b_ma_cmon = $get(b_ma_cmon_Id).value, b_ma_nngiep = $get(b_ma_nnnghe_Id).value, b_capbac = $get(b_ma_capbac_Id).value;
            b_m.value = b_mannghe + '.' + b_ma_cmon + '.' + b_ma_nngiep + '.' + b_capbac;
            $get(b_gocId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_cdanh_P_KTRA(b_maTen) {
    try {
        var b_ma = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA_NN": b_ma = form_Fs_TEN_GTRI(b_vungId, 'MA_NNGHE'); break;
            case "MA_CM": b_ma = form_Fs_TEN_GTRI(b_vungId, 'MA_CMON'); break;
            case "MA_NL": b_ma = form_Fs_TEN_GTRI(b_vungId, 'MA_NNNGHE'); break;
            case "MA_CB": b_ma = form_Fs_TEN_GTRI(b_vungId, 'MA_CAPBAC'); break;
            case "MA": b_ma = $get(b_gocId).value; break;
        }

        if (b_maTen == "MA_NN") {
            form_P_MOI(b_vungId, "GXLN");
            sns_hdns.Fs_NS_MA_CMON_XEM(b_ma, ns_ma_cdanh_P_NN_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_maTen == "MA_CM") {
            form_P_MOI(b_vungId, "XLN");
            var b_mannghe = form_Fs_TEN_GTRI(b_vungId, 'MA_NNGHE'), b_ma_cmon = form_Fs_TEN_GTRI(b_vungId, 'MA_CMON'),
            b_ma_nngiep = form_Fs_TEN_GTRI(b_vungId, 'MA_NNNGHE'), b_capbac = form_Fs_TEN_GTRI(b_vungId, 'MA_CAPBAC'), b_ma = $get(b_gocId).value;

            if (C_NVL(b_mannghe) != '' && C_NVL(b_ma_cmon) != '' && C_NVL(b_ma_nngiep) != '' && C_NVL(b_capbac) != '') {
                $get(b_gocId).value = C_NVL(b_mannghe) + '.' + C_NVL(b_ma_cmon) + '.' + C_NVL(b_ma_nngiep) + '.' + C_NVL(b_capbac);
            }
            ns_ma_cdanh_P_MA_KTRA();
        }
        else if (b_maTen == "MA_NL") {
            form_P_MOI(b_vungId, "XLMN");
            sns_hdns.Fs_NS_MA_CAPBAC_XEM(b_ma, ns_ma_cdanh_P_NL_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }

        else if (b_maTen == "MA_CB") {
            form_P_MOI(b_vungId, "XLN");

            var b_mannghe = form_Fs_TEN_GTRI(b_vungId, 'MA_NNGHE'), b_ma_cmon = form_Fs_TEN_GTRI(b_vungId, 'MA_CMON'),
            b_ma_nngiep = form_Fs_TEN_GTRI(b_vungId, 'MA_NNNGHE'), b_capbac = form_Fs_TEN_GTRI(b_vungId, 'MA_CAPBAC'), b_ma = $get(b_gocId).value;

            if (C_NVL(b_mannghe) != '' && C_NVL(b_ma_cmon) != '' && C_NVL(b_ma_nngiep) != '' && C_NVL(b_capbac) != '') {
                $get(b_gocId).value = C_NVL(b_mannghe) + '.' + C_NVL(b_ma_cmon) + '.' + C_NVL(b_ma_nngiep) + '.' + C_NVL(b_capbac);
            }
            ns_ma_cdanh_P_MA_KTRA();
        }
        else if (b_maTen == "MA") {
            //var b_tt = form_Fctr_TEN_DTUONG(b_vungId, 'tt');
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma);
            if (b_hang < 1) {
                GridX_thoiA(b_grlkeId); ns_ma_cdanh_P_MA_KTRA();
            }
            else { GridX_datA(b_grlkeId, b_hang); ns_ma_cdanh_P_CHUYEN_HANG(); }
            $get(b_tenId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_ma_cdanh_P_NN_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        ns_ma_cdanh_P_LKE();
    }
}


function ns_ma_cdanh_P_NL_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        ns_ma_cdanh_P_LKE();
    }
}

function ns_ma_cdanh_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_ma_nnghe = form_Fs_TEN_GTRI(b_vungId, 'MA_NNGHE'), b_ma_cmon = form_Fs_TEN_GTRI(b_vungId, 'MA_CMON'),
        b_ma_nnnghe = form_Fs_TEN_GTRI(b_vungId, 'MA_NNNGHE'), b_ma_capbac = form_Fs_TEN_GTRI(b_vungId, 'MA_CAPBAC'), b_ma = $get(b_gocId).value;
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_hdns.Fs_NS_MA_CDANH_MA(b_ma_nnghe, b_ma_cmon, b_ma_nnnghe, b_ma_capbac, b_ma, b_TrangKt, a_cot, ns_ma_cdanh_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_cdanh_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) { GridX_thoiA(b_grlkeId); return false; }
    else { GridX_datA(b_grlkeId, b_hang); ns_ma_cdanh_P_CHUYEN_HANG(); }
}
function ns_ma_cdanh_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    $get(b_gchuId).innerHTML = b_kq;
    form_P_MOI(b_vungId, "X");
    //$get(b_gocId).focus();
}
var ns_ma_cdanh_choAct = 0;
function ns_ma_cdanh_GR_lke_RowChange() {
    if (ns_ma_cdanh_choAct != 0) clearTimeout(ns_ma_cdanh_choAct);
    ns_ma_cdanh_choAct = setTimeout("ns_ma_cdanh_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_ma_cdanh_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_ma_cdanh_lkeCho); ns_ma_cdanh_P_LKE(); }
}

function ns_ma_cdanh_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    sns_hdns.Fs_NS_MA_CDANH_NH(b_TrangKt, a_dt_ct, a_cot, ns_ma_cdanh_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_ma_cdanh_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        ns_ma_cdanh_P_CHUYEN_HANG();
    }
    return false;
}
function ns_ma_cdanh_P_MOI() {
    form_P_MOI(b_vungId, "KGXLMN");
    $get(b_gocId).focus();
    return false;
}

function ns_ma_cdanh_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == 0) ns_ma_cdanh_P_MOI();
    else {
        var b_mannghe = form_Fs_TEN_GTRI(b_vungId, 'MA_NNGHE'), b_ma_cmon = form_Fs_TEN_GTRI(b_vungId, 'MA_CMON'),
        b_ma_nngiep = form_Fs_TEN_GTRI(b_vungId, 'MA_NNNGHE'), b_capbac = form_Fs_TEN_GTRI(b_vungId, 'MA_CAPBAC'), b_ma = $get(b_gocId).value;
        var b_so_id = CSO_SO(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_NS_MA_CDANH_XOA(b_so_id, b_mannghe, b_ma_cmon, b_ma_nngiep, b_capbac, b_ma, a_tso, a_cot, ns_ma_cdanh_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_ma_cdanh_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_ma_cdanh_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_ma_cdanh_P_CHUYEN_HANG(); }
    }
}

function ns_ma_cdanh_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return false;
        var b_so_id = CSO_SO(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == 0) { form_P_MOI(b_vungId, "KXGLNM"); return false; }
        else
        {
            sns_hdns.Fs_NS_MA_CDANH_CT(b_so_id, ns_ma_cdanh_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_ma_cdanh_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}


function ns_ma_cdanh_P_LKE() {
    try {
        var b_ma_nnghe = form_Fs_TEN_GTRI(b_vungId, 'MA_NNGHE'), b_ma_cmon = form_Fs_TEN_GTRI(b_vungId, 'MA_CMON'),
        b_ma_nnnghe = form_Fs_TEN_GTRI(b_vungId, 'MA_NNNGHE'), b_ma_capbac = form_Fs_TEN_GTRI(b_vungId, 'MA_CAPBAC');
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_NS_MA_CDANH_LKE(b_ma_nnghe, b_ma_cmon, b_ma_nnnghe, b_ma_capbac, a_tso, a_cot, ns_ma_cdanh_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function ns_ma_cdanh_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);

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
function ns_ma_cdanh_P_IN() {
    __doPostBack('ctl00$ContentPlaceHolder1$Nhap2', '');//Xuất Excel
}
function ns_ma_cdanh_P_MAU() {
    __doPostBack('ctl00$ContentPlaceHolder1$btn_excel_mau', '');//Xuất file Excel mẫu

}
function ns_ma_cdanh_FILE_Import() {//import từ file Excel
    var b_tenf = '/App_form/ns/hdns/file_hdns.aspx';
    form_P_MO(b_tenf, window.name + ',THAMSO', ['THAMSO', [window.name, 'MA_CDANH_IMP', null, "Import mã chức danh"]], null);
    form_P_LOI('');
    return false;
}

function ns_ma_cdanh_P_DUYET() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        sns_hdns.Fs_NS_MA_CDANH_DUYET(b_so_id, ns_ma_cdanh_P_DUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { throw (err); }
}
function ns_ma_cdanh_P_DUYET_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        GridX_datGtri(b_grlkeId, b_hang, ["pduyet"], 'X');
        form_P_LOI('loi:Duyệt thành công:loi');
    }
}