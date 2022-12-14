
var ns_ls_qt_dt_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_noidtId, b_xeploaiId, b_so_idId, b_tenId, b_kh_dtaoId, b_ldt_Id,
    b_gchuId, b_moiId, b_moi = 0, b_hieuluc, b_ngaydId, b_ngaycId, b_cho_control = 0, b_doi, b_nsd;
function ns_ls_qt_dt_P_KD() {
    ns_ls_qt_dt_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE'),
    b_tenId = form_Fs_TEN_ID(b_vungId, 'TEN'), b_kh_dtaoId = form_Fs_TEN_ID(b_vungId, 'TEN_KDT'), b_ldt_Id = form_Fs_TEN_ID(b_vungId, 'ldt');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_moiId = form_Fs_VTEN_ID('', 'moi');
    b_slideId = $get(b_grlkeId).getAttribute('slideId');
    b_ngaydId = form_Fs_TEN_ID(b_vungId, 'NGAY_D'), b_ngaycId = form_Fs_TEN_ID(b_vungId, 'ngay_c');
    b_nsd = form_Fs_nsd();
}

function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_gocId).value = b_so_the;
            $get(form_Fs_VTEN_ID('UPa_hi', 'so_the_an')).value = b_so_the;
            $get(b_tenId).value = b_ten; //$get(b_gchuId).innerHTML = b_ten;
            $get(b_kh_dtaoId).focus();
            ns_ls_qt_dt_P_LKE();
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
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ls_qt_dt_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        b_mt = b_maTen;
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_ls_qt_dt_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_ls_qt_dt_P_LKE();
            $get(b_kh_dtaoId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ls_qt_dt_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else $get(b_tenId).value = b_kq; //form_P_DatGchu(b_tenId, b_kq);
}

var ns_ls_qt_dt_choAct = 0;
function ns_ls_qt_dt_GR_lke_RowChange() {
    if (ns_ls_qt_dt_choAct != 0) clearTimeout(ns_ls_qt_dt_choAct);
    ns_ls_qt_dt_choAct = setTimeout("ns_ls_qt_dt_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_ls_qt_dt_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_ls_qt_dt_lkeCho); ns_ls_qt_dt_P_LKE(); }
}

function ns_ls_qt_dt_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    $get(b_ldt_Id).value = '';
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = "0";
    return false;
}

function ns_ls_qt_dt_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_so_the = $get(b_gocId).value;
        sns_ls.Fs_NS_LS_QT_DT_LKE(b_nsd, b_so_the, a_tso, a_cot, ns_ls_qt_dt_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ls_qt_dt_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}

function ns_ls_qt_dt_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId); if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var b_ktra = sosanh_withDateTimeNow($get(b_ngaydId).value); if (b_ktra > 0) { form_P_LOI('loi:Ngày bắt đầu phải bằng hoặc nhỏ hơn ngày hiện tại:loi'); return false; }
        b_ktra = sosanh_withDateTimeNow($get(b_ngaycId).value); if (b_ktra > 0) { form_P_LOI('loi:Ngày bắt đầu phải bằng hoặc nhỏ hơn ngày hiện tại:loi'); return false; }
        b_ktra = sosanh_Date($get(b_ngaydId).value, $get(b_ngaycId).value); if (b_ktra != "false" && b_ktra < 0) { form_P_LOI('loi:Ngày bắt đầu không được lớn hơn ngày kết thúc:loi'); return false; }
        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);//, a_glke = GridX_Fdt_cotGtri(b_grlkeId);
        var b_so_id = 0;
        sns_ls.Fs_NS_LS_QT_DT_NH(b_nsd, b_so_id, b_TrangKt, a_dt_ct, a_cot_lke, ns_ls_qt_dt_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);

        return false;
    }
    catch (err) { throw (err); }
}

function ns_ls_qt_dt_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI("loi:Nhập thành công:loi");
    }
    return false;
}

function ns_ls_qt_dt_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return false;
    var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten_kdt"));
    if (b_ma == "") form_P_MOI(b_vungId, "XGL"); else form_P_GridX_TEXT(b_vungId, b_grlkeId);
    // var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    // if (b_so_id == "") form_P_MOI(b_vungId, "XGL");
    //  else sns_ls.Fs_NS_LS_QT_DT_CT(b_so_id, ns_ls_qt_dt_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    //  $get(b_so_idId).value = b_so_id;
}
function ns_ls_qt_dt_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
function ns_ls_qt_dt_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return false;
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"), b_so_the = $get(b_gocId).value;
    if (b_so_id == "") ns_ls_qt_dt_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ls.Fs_NS_LS_QT_DT_XOA(b_nsd, b_so_id, b_so_the, a_tso, a_cot, ns_ls_qt_dt_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_ls_qt_dt_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        var b_dong = CSO_SO(a_kq[0]);
        if (b_hang > b_dong) b_hang = b_dong;
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_ls_qt_dt_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_ls_qt_dt_P_CHUYEN_HANG(); }
    }
}
function ns_ls_qt_dt_P_Excel() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'excel_an');
    $get(b_btn_excel).click();
    form_chay = 0;
    return false;
}
function ns_ls_qt_dt_FILE_Import() {//import từ file Excel
    var b_tenf = '/App_form/ns/ma/file_import_hdns.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "NS_LS_QT_DT", "NS_LS_QT_DT", "Import quá trình đào tạo"]], null);
    form_P_LOI('');
    return false;
}
function nhap_file() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) {
        form_P_LOI('loi:Chọn khóa đào tạo cần đưa file mềm lên hệ thống:loi')
        return false;
    }
    var b_tenf = '/App_form/ns/ma/file_Import_chung.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "ns_ls_qt_dt", "Import_Vaora", "Lưu khóa đào tạo của nhân viên"]], null);
    form_P_LOI('');
    return false;
}
function sosanh_withDateTimeNow(str) {
    var mdy_str = str.split('/');
    var mdy_str = mdy_str[2] + mdy_str[1] + mdy_str[0];
    var mdy_str = parseInt(mdy_str);
    var dateht = new Date();
    var m = "0" + (1 + dateht.getMonth());
    var y = parseInt("2" + dateht.getYear()) - 100;
    var d = "0" + dateht.getDate();
    var dmy = y + m + d;
    var dmy = parseInt(dmy);
    var kq = mdy_str - dmy;
    return kq;
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
