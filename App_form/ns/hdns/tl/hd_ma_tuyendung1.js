var hd_ma_tuyendung_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_ncdanhId, b_gchuId, b_ncdanhten, b_gchu, hd_ma_tuyendung_choAct = 0;
function hd_ma_tuyendung_P_KD() {
    hd_ma_tuyendung_lkeCho = setInterval('hd_ma_tuyendung_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
            if (a_tso[0] == 'FILE_HTOAN') {
                hd_ma_tuyendung_P_LKE();
            }
            else {
                b_dtuong = b_dtuong.toUpperCase();
                switch (b_dtuong) {
                    case 'CTL00_CONTENTPLACEHOLDER1_MA_CDANH':
                        $get(b_gocId).value = a_tso[0];
                        //$get(b_ncdanhten).value = a_tso[1];
                        hd_ma_tuyendung_P_LKE();
                        $get(b_gchuId).innerHTML = a_tso[1];
                        break;
                    case 'CTL00_CONTENTPLACEHOLDER1_MA2':
                        sns_td.Fs_HDNS_DINHBIEN_NS_CT_CT(a_tso[0], hd_ma_tuyendung_CT_CT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                        break;
                    default:
                        hd_ma_tuyendung_P_LKE();
                        break;
                }
            }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function hd_ma_tuyendung_CT_CT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
    }
    return false;
}
function hd_ma_tuyendung_P_KTRA(b_maTen) {
    try {
        b_maTen = b_maTen.toUpperCase();
        var b_ma = $get(b_gocId)
        if (b_ma == null || C_NVL(b_ma.value) == "") return false;
        if (b_maTen.indexOf("BATSO") >= 0) {
            var a_kq = Fas_ChMang(b_maTen, ',');
            b_maTen = a_kq[1];
        }
        switch (b_maTen) {
            case "MA_CDANH":
                hd_ma_tuyendung_P_MA();
                break;
            case "BATSO":
                var b_so = form_Fs_TEN_ID(b_vungId, a_kq[0]);
                var b_so2 = form_Fs_TEN_ID(b_vungId, a_kq[2]);
                var b_sosanh = $get(b_so).value;
                var b_sosanh2 = $get(b_so2).value;
                if (parseInt(b_sosanh) > parseInt(b_sosanh2))
                    switch (a_kq[2].toUpperCase()) {
                        case "MON_I_DMAX":
                            form_P_LOI("loi:Đạt điểm vòng 1 không được lớn hơn thang điểm vòng 1:loi");
                            break;
                        case "MON_II_DMAX":
                            form_P_LOI("loi:Đạt điểm vòng 2 không được lớn hơn thang điểm vòng 2:loi");
                            break;
                        case "MON_III_DMAX":
                            form_P_LOI("loi:Đạt điểm vòng 3 không được lớn hơn thang điểm vòng 3:loi");
                            break;
                    }
                break;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function hd_ma_tuyendung_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    form_P_MOI(b_vungId, "X");
    $get(b_gocId).focus();
}
function hd_ma_tuyendung_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    hd_ma_tuyendung_P_LKE();
    $get(b_gocId).focus();
    return false;
}
function hd_ma_tuyendung_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_hdns.Fs_HD_MA_TUYENDUNG_NH(form_Fs_nsd(), b_TrangKt, a_dt_ct, a_cot, hd_ma_tuyendung_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function hd_ma_tuyendung_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI("loi:Ghi thành công!:loi");
        hd_ma_tuyendung_P_CHUYEN_HANG();
    }
    return false;
}
function hd_ma_tuyendung_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    //var message = confirm("Bạn có chắc chắn xóa không?");
    //if (message == false) { return false; }
    var b_so_id = CSO_SO(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == 0) hd_ma_tuyendung_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_HD_MA_TUYENDUNG_XOA(b_so_id, a_tso, a_cot, hd_ma_tuyendung_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function hd_ma_tuyendung_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        form_P_LOI("loi:Xóa thành công!:loi");
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) hd_ma_tuyendung_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); hd_ma_tuyendung_P_CHUYEN_HANG(); }
    }
}
function hd_ma_tuyendung_GR_lke_RowChange() {
    if (hd_ma_tuyendung_choAct != 0) clearTimeout(hd_ma_tuyendung_choAct);
    hd_ma_tuyendung_choAct = setTimeout("hd_ma_tuyendung_P_CHUYEN_HANG()", 300);
    return false;
}
function hd_ma_tuyendung_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        var b_ma_cdanh = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma_cdanh"));
        if (b_ma == "") form_P_MOI(b_vungId, "XGL"); else
            sns_hdns.Fs_HD_MA_TUYENDUNG_CT(form_Fs_nsd(), b_ma_cdanh, b_ma, ns_hdns_ma_nnn_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_nnn_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    var b_d1 = form_Fs_TEN_ID(b_vungId, 'mon_I_diem'), b_dmax1 = form_Fs_TEN_ID(b_vungId, 'mon_I_dmax'),
        b_d2 = form_Fs_TEN_ID(b_vungId, 'mon_II_diem'), b_dmax2 = form_Fs_TEN_ID(b_vungId, 'mon_II_dmax'),
        b_d3 = form_Fs_TEN_ID(b_vungId, 'mon_III_diem'), b_dmax3 = form_Fs_TEN_ID(b_vungId, 'mon_III_dmax');
    if ($get(b_d1).value == 0) $get(b_d1).value = '';
    if ($get(b_dmax1).value == 0) $get(b_dmax1).value = '';
    if ($get(b_d2).value == 0) $get(b_d2).value = '';
    if ($get(b_dmax2).value == 0) $get(b_dmax2).value = '';
    if ($get(b_d3).value == 0) $get(b_d3).value = '';
    if ($get(b_dmax3).value == 0) $get(b_dmax3).value = '';
}
function hd_ma_tuyendung_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        hd_ma_tuyendung_lkeCho;
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
        b_gchu = form_Fs_VUNG_ID('UPa_gchu');
        b_gocId = form_Fs_TEN_ID(b_vungId, 'MA_CDANH');
        b_gchuId = form_Fs_TEN_ID(b_gchu, 'gchu');
        b_slideId = b_grlkeId + '_slide_ctrdivL';
        clearTimeout(hd_ma_tuyendung_lkeCho); hd_ma_tuyendung_P_LKE();
    }
}
function hd_ma_tuyendung_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_HD_MA_TUYENDUNG_LKE(a_tso, a_cot, hd_ma_tuyendung_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function hd_ma_tuyendung_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function hd_ma_tuyendung_P_MA() {
    try {
        var b_ma_cdanh = $get(b_gocId).value
        var a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        sns_hdns.Fs_HD_MA_TUYENDUNG_MA(b_ma_cdanh, b_TrangKt, a_cot, hd_ma_tuyendung_P_MA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function hd_ma_tuyendung_P_MA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        GridX_thoiA(b_grlkeId);
        form_P_MOI(b_vungId, "XL");
        return false;
    }
    else {
        GridX_datA(b_grlkeId, b_hang)
        hd_ma_tuyendung_P_CHUYEN_HANG();
    }
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
function hd_ma_tuyendung_P_EXCEL() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'XuatExcel'); $get(b_btn_excel).click(); form_chay = 0; return false;
}
function hd_ma_tuyendung_P_MAU() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'FileMau'); $get(b_btn_excel).click(); form_chay = 0; return false;
}
function hd_ma_tuyendung_FILE_IMPORT() {//import từ file Excel
    var b_tenf = '/App_form/ns/ma/file_import_hdns.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "HD_MA_TUYENDUNG", "HD_MA_TUYENDUNG", "Import số vòng tuyển dụng"]], null);
    return false;
}