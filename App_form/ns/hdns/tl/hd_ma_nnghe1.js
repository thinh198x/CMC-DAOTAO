var hd_ma_nnghe_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_Ten, b_timId, b_luudayId = '';
function hd_ma_nnghe_P_KD() {
    hd_ma_nnghe_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_Ten = form_Fs_TEN_ID(b_vungId, 'TEN'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'); b_luudayId = form_Fs_VTEN_ID('UPa_hi', 'luu_day');
    b_slideId = b_grlkeId + '_slide';
    hd_ma_nnghe_lkeCho = setInterval('hd_ma_nnghe_P_LKE_CHO()', 200);

}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
            if (a_tso[0] == 'FILE_HTOAN') {                
                hd_ma_nnghe_P_LKE();
            }
        }
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            var b_day = b_kq; $get(b_luudayId).value = b_kq;
            hd_ma_nnghe_P_LKE();            
        }
    }
    catch (err) { form_P_LOI(err); }
}
function hd_ma_nnghe_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            $get(b_gocId).value = ($get(b_gocId).value).validate_Ma();
            var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); hd_ma_nnghe_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); hd_ma_nnghe_P_CHUYEN_HANG(); }
            //b_ten.focus();
            $get(b_Ten).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function hd_ma_nnghe_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_ma_ch.Fs_hd_ma_nnghe_MA(b_ma, b_TrangKt, a_cot, hd_ma_nnghe_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function hd_ma_nnghe_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); hd_ma_nnghe_P_CHUYEN_HANG(); }
}

var hd_ma_nnghe_choAct = 0;
function hd_ma_nnghe_GR_lke_RowChange() {
    if (hd_ma_nnghe_choAct != 0) clearTimeout(hd_ma_nnghe_choAct);
    hd_ma_nnghe_choAct = setTimeout("hd_ma_nnghe_P_CHUYEN_HANG()", 300);
    return false;
}

function hd_ma_nnghe_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(hd_ma_nnghe_lkeCho); GridX_taoScroll(b_grlkeId); hd_ma_nnghe_P_LKE(); }
}

function hd_ma_nnghe_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") {
        if (b_loi == "Phải nhập#Tên ngành nghề") { $get(b_Ten).focus(); }
        if (b_loi == "Phải nhập#Mã ngành nghề") { $get(b_gocId).focus(); }
        form_P_LOI(b_loi); return false;
    }
    if ($get(b_Ten).value == "" || $get(b_Ten).value == null) { $get(b_Ten).focus(); return false; }
    if ($get(b_gocId).value == "" || $get(b_gocId).value == null) { $get(b_gocId).focus(); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_ma_ch.Fs_hd_ma_nnghe_NH(b_TrangKt, a_dt_ct, a_cot, hd_ma_nnghe_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function hd_ma_nnghe_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        form_Fctr_TEN_DTUONG(b_vungId, 'TEN').focus();
    }
    return false;
}
function hd_ma_nnghe_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    return false;
}

function hd_ma_nnghe_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }

    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    if (b_ma == "") hd_ma_nnghe_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_hd_ma_nnghe_XOA(b_ma, a_tso, a_cot, hd_ma_nnghe_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function hd_ma_nnghe_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId); 
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) hd_ma_nnghe_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); hd_ma_nnghe_P_CHUYEN_HANG(); }
    }
}

function hd_ma_nnghe_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        if (b_ma == "") form_P_MOI(b_vungId, "XGL"); else form_P_GridX_TEXT(b_vungId, b_grlkeId);
    }
    catch (err) { form_P_LOI(err); }
}

function hd_ma_nnghe_P_LKE() {
    try {
        var b_day =  $get(b_luudayId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_hd_ma_nnghe_LKE(a_tso, a_cot, b_day,hd_ma_nnghe_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function hd_ma_nnghe_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function hd_ma_nnghe_P_IN() {
    __doPostBack('ctl00$ContentPlaceHolder1$Nhap2', '');//Xuất Excel
}
function form_dong() {
    location.reload(false);
}
function hd_ma_nnghe_P_MAU() {
    __doPostBack('ctl00$ContentPlaceHolder1$btn_excel_mau', '');//Xuất file Excel mẫu
    
}
function hd_ma_nnghe_FILE_Import() {//import từ file Excel
    var b_tenf = '/App_form/ns/hdns/file_hdns.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "MA_NNGHE_IMP", "MA_NNGHE_IMP", "Import nghề nghiệp"]], null);
    form_P_LOI('');
    return false;
}

