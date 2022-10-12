var ns_kthuong_lkeCho, b_choAct = 0, b_vungId, b_grlkeId, b_slideId, b_gocId, b_tenId, b_ma_manghe_Id, b_ma_cmon_Id, b_ma_nnnghe_Id, b_ma_capbac_Id;
function ns_kthuong_P_KD() {
    ns_kthuong_lkeCho,b_vungId = form_Fs_VUNG_ID('UPa_ct'); b_grlkeId = form_Fs_VUNG_ID('GR_lke'); b_slideId = b_grlkeId + '_slide';
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    ns_kthuong_lkeCho = setInterval('ns_kthuong_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {

    }
    catch (err) { form_P_LOI(err); }
}
function ns_kthuong_P_KTRA(b_maTen) {
    try {
        switch (b_maTen.toUpperCase()) {
          
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_kthuong_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_mannghe = $get(b_ma_manghe_Id).value, b_ma_cmon = $get(b_ma_cmon_Id).value, b_ma_nngiep = $get(b_ma_nnnghe_Id).value, b_capbac = $get(b_ma_capbac_Id).value, b_ma = $get(b_gocId).value;
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_ns.Fs_NS_KTHUONG_MA(b_mannghe, b_ma_cmon, b_ma_nngiep, b_capbac, b_ma, b_TrangKt, a_cot, ns_kthuong_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_kthuong_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    //GridX_datBang(b_grlkeId, a_kq[3]);
    //slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) { form_P_MOI(b_vungId, "X"); return false; }
    else { GridX_datA(b_grlkeId, b_hang); ns_kthuong_P_CHUYEN_HANG(); }
}
function ns_kthuong_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    $get(b_gchuId).innerHTML = b_kq;
    form_P_MOI(b_vungId, "X");
    //$get(b_gocId).focus();
}
var ns_kthuong_choAct = 0;
function ns_kthuong_GR_lke_RowChange() {
    if (ns_kthuong_choAct != 0) clearTimeout(ns_kthuong_choAct);
    ns_kthuong_choAct = setTimeout("ns_kthuong_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_kthuong_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_kthuong_lkeCho); GridX_taoScroll(b_grlkeId); ht_maph_P_LKE(); }
}

function ns_kthuong_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_ns.Fs_NS_KTHUONG_NH(b_TrangKt, a_dt_ct, a_cot, ns_kthuong_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_kthuong_P_NH_KQ(b_kq) {
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
function ns_kthuong_P_MOI() {
    form_P_MOI(b_vungId, "KGXLMN");
    $get(b_gocId).focus();
    return false;
}

function ns_kthuong_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == 0) ns_kthuong_P_MOI();
    else {
        var b_mannghe = $get(b_ma_manghe_Id).value, b_ma_cmon = $get(b_ma_cmon_Id).value, b_ma_nngiep = $get(b_ma_nnnghe_Id).value, b_capbac = $get(b_ma_capbac_Id).value, b_ma = $get(b_gocId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ns.Fs_NS_KTHUONG_XOA(b_mannghe, b_ma_cmon, b_ma_nngiep, b_capbac, b_ma, a_tso, a_cot, ns_kthuong_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_kthuong_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_kthuong_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_kthuong_P_CHUYEN_HANG(); }
    }
}

function ns_kthuong_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return false;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == 0) { form_P_MOI(b_vungId, "KXGLNM"); return false; }
        else form_P_GridX_TEXT(b_vungId, b_grlkeId);
    }
    catch (err) { form_P_LOI(err); }
}

function ns_kthuong_P_LKE() {
    try {
        //var b_ma_nnghe = $get(b_ma_manghe_Id).value, b_ma_cmon = $get(b_ma_cmon_Id).value, b_ma_nnnghe = $get(b_ma_nnnghe_Id).value, b_ma_capbac = $get(b_ma_capbac_Id).value;
        //var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        //sns_ns.Fs_NS_KTHUONG_LKE(b_ma_nnghe, b_ma_cmon, b_ma_nnnghe, b_ma_capbac, a_tso, a_cot, ns_kthuong_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function ns_kthuong_P_LKE_KQ(b_kq) {
    //if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    //var a_kq = Fas_ChMang(b_kq, '#');
    //slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    //GridX_datBang(b_grlkeId, a_kq[1]);
}
//Bộ phận
function ht_maph_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId);
        //var b_tim = $get(b_timId).value;
        sht_ma.Fs_MA_PH_LKE3(form_Fs_nsd(), '', a_cot, ht_maph_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ht_maph_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else { GridX_datBang(b_grlkeId, b_kq); slide_P_SOTRANG(b_slideId); }
}
function ht_maph_GR_lke_RowChange() {
    if (b_choAct != 0) clearTimeout(b_choAct);
    b_choAct = setTimeout("ht_maph_P_CHUYEN_HANG()", 300);
    return false;
}
function ht_maph_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1 || GridX_Fb_hangTrang(b_grlkeId, b_hang)) form_P_MOI(b_vungId, "GXL");
    else form_P_GridX_TEXT(b_vungId, b_grlkeId);
}
//end
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
function ns_kthuong_P_IN() {
    __doPostBack('ctl00$ContentPlaceHolder1$Nhap2', '');//Xuất Excel
}
function ns_kthuong_P_MAU() {
    __doPostBack('ctl00$ContentPlaceHolder1$btn_excel_mau', '');//Xuất file Excel mẫu

}
function ns_kthuong_FILE_Import() {//import từ file Excel
    var b_tenf = '/App_form/ns/hdns/file_hdns.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "MA_CDANH_IMP", "MA_CDANH_IMP", "Import mã chức danh"]], null);
    form_P_LOI('');
    return false;
}