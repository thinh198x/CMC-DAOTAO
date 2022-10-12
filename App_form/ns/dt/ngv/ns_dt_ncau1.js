var ns_dt_ncau_lkeCho, b_vungId, b_grlkeId, b_ngaydId, b_ngaycId, b_vungTkId, ns_dt_ncau_choAct = 0, b_slideId, b_gocId, b_sothe_tnId,
    b_tenId, b_tuoiId, b_so_idId, b_gchuId, b_moiId, b_nsd, b_ten, b_thang_tkId, b_kyluongTKId, b_athang_tkId, b_ngaydkyId, b_giodId, b_namId, b_nam_tkId, b_giocId, b_sophutId;
function ns_dt_ncau_P_KD() {
    ns_dt_ncau_lkeCho, b_vungTkId = form_Fs_VUNG_ID('UPa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
    b_nam_tkId = form_Fs_TEN_ID(b_vungTkId, 'nam_tk'); b_thang_tkId = form_Fs_TEN_ID(b_vungTkId, 'thang_tk');
    b_athang_tkId = form_Fs_TEN_ID('UPa_hi', 'athang_tk');
    b_so_idId = form_Fs_VTEN_ID('', 'so_id');
    ns_dt_ncau_lkeCho = setInterval('ns_dt_ncau_P_LKE_CHO()', 200);
}
// kiểm tra
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "" || a_tso[0] == "FILE_HTOAN") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ncau_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "NAM_TK": b_maId = b_nam_tkId; form_P_MOI("", "T"); break;
            case "THANG_TK": b_maId = b_thang_tkId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "THANG_TK") {
            $get(b_athang_tkId).value = form_Fs_TEN_GTRI(b_vungTkId, 'thang_tk');
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ncau_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}
// Nhập
function ns_dt_ncau_P_MOI() {
    form_P_MOI(b_vungId, "GXLMN");
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = "0";
    $get(b_giodId).value = "";
    $get(b_giocId).value = "";
    $get(b_gocId).focus();
    return false;
}
function ns_dt_ncau_P_NH() {
    var b_dt_ct = GridX_Fdt_cotGtri(b_grlkeId);
    sns_dt.Fs_NS_DT_TGIAN_GDAY_HVIEN_NH(b_dt_ct, ns_dt_ncau_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
} 
function ns_dt_ncau_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_LOI("loi:triển khai thành công:loi");
    GridX_datTrang(b_grlkeId);
    ns_dt_ncau_P_LKE('K');
    return false;
}
// Chuyển hàng
function ns_dt_ncau_GR_lke_RowChange() {
    if (ns_dt_ncau_choAct != 0) clearTimeout(ns_dt_ncau_choAct);
    ns_dt_ncau_choAct = setTimeout("ns_dt_ncau_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_dt_ncau_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "") form_P_MOI(b_vungId, "XGLMN");
    else sns_dt.Fs_NS_GT_CC_CT(form_Fs_nsd(), window.name, b_so_id, ns_dt_ncau_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = b_so_id;
}
function ns_dt_ncau_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    return false;
}
// liệt kê
function ns_dt_ncau_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ns_dt_ncau_lkeCho != 0) clearTimeout(ns_dt_ncau_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_dt_ncau_P_LKE('K');
    }
}
function ns_dt_ncau_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_nam = $get(b_nam_tkId).value, b_thang_tk = form_Fs_TEN_GTRI(b_vungTkId, 'thang_tk');
        sns_dt.Fs_NS_DT_NCAU_LKE(form_Fs_nsd(), b_nam, b_thang_tk, a_tso, a_cot, ns_dt_ncau_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ncau_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
    }
}
function ns_dt_ncau_P_CT() {
    var b_ngaydky = $get(b_ngaydkyId).value;
    var b_loaidky = $get(b_loaidkyId).value;
    if (b_ngaydky == "" || b_ngaydky == null || b_loaidky == "" || b_loaidky == null) { form_P_MOI("", "XGL"); return; }
    else sns_dt.Fs_NS_GT_CC_CT2(form_Fs_nsd(), b_ngaydky, b_loaidky, ns_dt_ncau_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = b_so_id;
}
function ns_dt_ncau_GIO() {
    try {
        var b_giobd = $get(b_giodId).value, b_giokt = $get(b_giocId).value;
        sns_dt.Fs_KIEMTRA_PHUT(b_giobd, b_giokt, ns_dt_ncau_GIO_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ncau_GIO_kq(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    if (b_kq != "") $get(b_sophutId).value = b_kq;
}
function ns_dt_ncau_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function ns_dt_ncau_P_MAU() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'btn_excel_mau');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function ns_dt_ncau_FILE_Import() {
    var b_tenf = '/App_form/ns/ma/file_Import.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "DKY_DMVS_IMP", "DKY_DMVS_IMP", "Import đăng ký đi muộn về sớm"]], null);
    form_P_LOI('');
    return false;
}

function isTime(txtHour) {
    var data = C_NVL(txtHour.value);
    if (data == "") return true;

    if (data.indexOf(":") < 0) {
        data = formatTime(data);
        if (data != '')
            txtHour.value = data;
        else {
            txtHour.value = "";
            return false;
        }
    }

    var rxHourPattern = /^(\d{1,2})(:)(\d{1,2})$/;
    var dtArray = data.match(rxHourPattern); // is format OK?
    if (dtArray == null) {
        rxHourPattern = /^(\d{1,2})$/;
        dtArray = data.match(rxHourPattern);
    }
    if (dtArray == null) {
        txtHour.value = "";
        return false;
    }
    //Checks for hh:mm format.
    const hour = parseInt(dtArray[1], 10);
    var minute = 0;
    if (dtArray.length >= 4)
        minute = parseInt(dtArray[3], 10);
    if (hour < 0 || hour >= 24 || minute < 0 || minute >= 60) {
        txtHour.value = "";
        return false;
    }
    txtHour.value = pad(hour) + ":" + pad(minute);
    return true;
}
function formatTime(data) {
    if (data.indexOf(":") >= 0) return data;

    var b_length = data.length;
    if (b_length < 4) {
        if (b_length == 0)
            data = "00:00";
        else if (b_length == 1)
            data = "0" + data + ":00";
        else if (b_length == 2)
            data = data + ":00";
        else if (b_length == 3)
            data = data.substr(0, 2) + ":0" + data.substr(2);
    }
    else data = data.substr(0, 2) + ':' + data.substr(2);
    return data;
}
function pad(s) { return (s < 10) ? '0' + s : s; }
function form_dong() {
    location.reload(false);
}
function ns_dt_ncau_P_GUI() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) { form_P_LOI("loi:Chưa chọn đăng ký cần gửi:loi"); return false; }
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "") { form_P_LOI("loi:Chưa chọn đăng ký cần gửi:loi"); return false; }
        var b_so_the = $get(b_so_theId).value, a_cot = GridX_Fas_tenCot(b_grlkeId)
        var b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tt"));
        if (b_trangthai == "CG")
            sns_dt.Fs_NS_GT_CC_GUI(form_Fs_nsd(), b_so_id, ns_dt_ncau_GUI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        else
            form_P_LOI("loi:Đăng ký đã được gửi hoặc phê duyệt:loi");
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ncau_GUI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else form_P_LOI("loi:Gửi phê duyệt thành công:loi");
    ns_dt_ncau_P_LKE('K');
    return false;
}