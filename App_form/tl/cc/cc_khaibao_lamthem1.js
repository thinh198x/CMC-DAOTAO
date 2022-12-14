
var cc_khaibao_lamthem_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_sothe_tnId, b_tenId, b_tuoiId, b_so_idId, b_gchuId, b_moiId, b_nsd, b_ten, b_ngaydkyId, b_loaidkyId;
function cc_khaibao_lamthem_P_KD(nsd, ten) {
    b_nsd = nsd, b_ten = ten;
    cc_khaibao_lamthem_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
    b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE'); b_loaidkyId = form_Fs_TEN_ID(b_vungId, 'nghibu'); b_ngaydkyId = form_Fs_TEN_ID(b_vungId, 'ngay_dky');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu'); b_giobdId = form_Fs_TEN_ID(b_vungId, 'GIO_BD'); b_gioktId = form_Fs_TEN_ID(b_vungId, 'GIO_KT'); b_sogioId = form_Fs_TEN_ID(b_vungId, 'so_gio');
    b_thangId = form_Fs_VTEN_ID('', 'thang');
    b_so_idId = form_Fs_VTEN_ID('', 'so_id');
    b_slideId = b_grlkeId + '_slide';
    cc_khaibao_lamthem_lkeCho = setInterval('cc_khaibao_lamthem_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            
            $get(b_gocId).value = b_kq; 
            $get(b_gchuId).innerHTML = a_tso[1]; 
            cc_khaibao_lamthem_P_LKE();
            $get(b_gocId).focus();
            ns_thongtin_canbo();
        }
    }
    catch (err) { form_P_LOI(err); }
}

function cc_khaibao_lamthem_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; form_P_MOI("", "XGL"); break;
            case "LOAI_DKY": b_maId = b_loaidkyId;
            case "NGAY_DKY": b_maId = b_ngaydkyId;
            case "GIO_BD": b_maId = b_giobdId;
            case "GIO_KT": b_maId = b_gioktId;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), cc_khaibao_lamthem_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_thongtin_canbo();
            cc_khaibao_lamthem_P_LKE();
        } else if (b_maTen == "GIO_BD" || b_maTen == "GIO_KT") {
            cc_kiemtra_gio();
        }
        cc_khaibao_lamthem_P_CT();
    }
    catch (err) { form_P_LOI(err); }
}
function cc_kiemtra_gio() {
    try {
        var b_giobd = $get(b_giobdId).value, b_giokt = $get(b_gioktId).value;
        stl_cc.Fs_KIEMTRA_GIO(b_giobd, b_giokt, cc_kiemtra_gio_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function cc_kiemtra_gio_kq(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    $get(b_sogioId).value = b_kq;
    return false;
}
function ns_thongtin_canbo() {
    try {
        var b_so_the = $get(b_gocId).value;
        hts_dungchung.Fs_THONGTIN_CANBO(b_so_the, ns_thongtin_canbo_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_thongtin_canbo_kq(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
function cc_khaibao_lamthem_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}

var cc_khaibao_lamthem_choAct = 0;
function cc_khaibao_lamthem_GR_lke_RowChange() {
    if (cc_khaibao_lamthem_choAct != 0) clearTimeout(cc_khaibao_lamthem_choAct);
    cc_khaibao_lamthem_choAct = setTimeout("cc_khaibao_lamthem_P_CHUYEN_HANG()", 300);
    return false;
}

function cc_khaibao_lamthem_P_LKE_CHO() {
    $get(b_gocId).value = b_nsd;
    if ($get(b_grlkeId) != null) { clearTimeout(cc_khaibao_lamthem_lkeCho); cc_khaibao_lamthem_P_LKE(); }
}

function cc_khaibao_lamthem_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = "0";
    $get(b_gocId).focus();
}

function cc_khaibao_lamthem_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_so_the = $get(b_gocId).value, b_thang = $get(b_thangId).value;
        stl_cc.Fs_CC_KHAIBAO_LAMTHEM_LKE(b_so_the, b_thang, a_tso, a_cot, cc_khaibao_lamthem_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function cc_khaibao_lamthem_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}

function cc_khaibao_lamthem_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { alert(b_loi); return true; }
        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        var b_so_id = $get(b_so_idId).value;
        stl_cc.Fs_CC_KHAIBAO_LAMTHEM_NH(b_so_id, b_TrangKt, a_dt_ct, a_cot_lke, cc_khaibao_lamthem_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { throw (err); }
}
function cc_khaibao_lamthem_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[1]) + 1, b_trang = CSO_SO(a_kq[2]), b_soDong = CSO_SO(a_kq[3]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[4]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        sendMail(a_kq[0]);
        form_P_LOI('loi:Nhập thành công:loi') 
    }
    return false;
}

function sendMail(b_tso) {
    var a_tso = Fas_ChMang(b_tso, ';');
    var b_toAddress = a_tso[0],
        b_subject = a_tso[1],
        b_body = a_tso[2];
    if (b_toAddress == "" || b_toAddress == null || b_toAddress == undefined) return false;
    else {
        sSmtpMail.SendMail(b_toAddress, b_subject, b_body, sendMail_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
}
function sendMail_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); return false;
}

function cc_khaibao_lamthem_P_CT() {
    var b_ngaydky = $get(b_ngaydkyId).value;
    var b_loaidky = $get(b_loaidkyId).value;
    if (b_ngaydky == "" || b_ngaydky == null || b_loaidky == "" || b_loaidky == null) { form_P_MOI("", "XGL"); return; }
    else stl_cc.Fs_CC_KHAIBAO_LAMTHEM_CT2(b_ngaydky, b_loaidky, cc_khaibao_lamthem_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = b_so_id;
}
function cc_khaibao_lamthem_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "") form_P_MOI(b_vungId, "XGL");
    else stl_cc.Fs_CC_KHAIBAO_LAMTHEM_CT(b_so_id, cc_khaibao_lamthem_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = b_so_id;
}

function cc_khaibao_lamthem_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}

function cc_khaibao_lamthem_P_XOA() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"),
            b_so_the = $get(b_gocId).value;
        if (b_so_id == "") cc_khaibao_lamthem_P_MOI();
        else {
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId), b_thang = $get(b_thangId).value;;
            stl_cc.Fs_CC_KHAIBAO_LAMTHEM_XOA(b_so_id, b_so_the,b_thang, a_tso, a_cot, cc_khaibao_lamthem_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { throw (err); }
    return false;
}
function cc_khaibao_lamthem_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) cc_khaibao_lamthem_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); cc_khaibao_lamthem_P_CHUYEN_HANG(); }
    }
}
function form_dong() {
    location.reload(false);
}
function cc_khaibao_lamthem_P_IN() {
    __doPostBack('ctl00$ContentPlaceHolder1$Nhap2', '');//Xuất Excel
}
function cc_khaibao_lamthem_P_MAU() {
    __doPostBack('ctl00$ContentPlaceHolder1$btn_excel_mau', '');//Xuất file Excel mẫu

}
function cc_khaibao_lamthem_FILE_Import() {//import từ file Excel
    var b_tenf = '/App_form/ns/hdns/file_hdns.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "KHAIBAO_LAMTHEM_IMP", "KHAIBAO_LAMTHEM_IMP", "Khai báo làm thêm"]], null);
    form_P_LOI('');
    return false;
}