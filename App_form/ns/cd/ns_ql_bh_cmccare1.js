
var ns_ql_bh_cmccare_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gtId, b_gocId, b_ho_ten, b_phongId, b_cdanh, b_ngaysinh, b_so_cmnd, b_timId, b_gchuId, b_goibhhtId, b_goibhdcId, b_mucphidcId,
    b_mucphiId, b_ngay_hl, b_ngay_giam;
function ns_ql_bh_cmccare_P_KD(b_tm) {
    b_tmf = b_tm, ns_ql_bh_cmccare_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_vung_tk = form_Fs_VUNG_ID('UPa_tk'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE'), b_ho_ten = form_Fs_VTEN_ID(b_vungId, 'TEN'), b_phongId = form_Fs_TEN_ID(b_vungId, 'PHONG'), b_cdanh = form_Fs_TEN_ID(b_vungId, 'CDANH'),
    b_ngaysinh = form_Fs_TEN_ID(b_vungId, 'NSINH'), b_so_cmnd = form_Fs_TEN_ID(b_vungId, 'SOCMT'), b_goibhhtId = form_Fs_TEN_ID(b_vungId, 'GOI_BH_HT'), b_mucphiId = form_Fs_TEN_ID(b_vungId, 'MUCPHI_HT'),
    b_ngay_thamgia = form_Fs_TEN_ID(b_vungId, 'ngay_hl'), b_ngay_giam = form_Fs_TEN_ID(b_vungId, 'ngaygiam_bh'), b_goibhdcId = form_Fs_TEN_ID(b_vungId, 'GOI_BH_DC'), b_mucphidcId = form_Fs_TEN_ID(b_vungId, 'MUCPHI_DC'),
    b_so_the_tk = form_Fs_TEN_ID(b_vung_tk, 'so_the_tk'), b_ten_tk = form_Fs_TEN_ID(b_vung_tk, 'ten_tk'), b_donvi_tk = form_Fs_TEN_ID(b_vung_tk, 'phong_tk');
    b_slideId = b_grlkeId + '_slide';
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    ns_ql_bh_cmccare_lkeCho = setInterval('ns_ql_bh_cmccare_P_LKE_CHO()', 200);

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
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}

function ns_thongtin_bh_cu() {
    try {
        var b_so_the = $get(b_gocId).value;
        sns_cd.Fs_THONGTIN_BH_CU(b_so_the, ns_thongtin_bh_cu_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_thongtin_bh_cu_kq(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}

var b_cho_control = 0;
function P_cho(b_so_the, b_ten, b_phong, b_chucdanh) {
    try {
        if (b_doi == 0) {
            $get(b_gocId).value = b_so_the;
            $get(b_ho_ten).value = b_ten;
            $get(b_phongId).value = b_phong;
            $get(b_cdanh).value = b_chucdanh;
            $get(b_gchuId).innerHTML = b_ten;
            $get(b_gocId).focus();
            ns_thongtin_canbo();
            ns_thongtin_bh_cu();
            ns_ql_bh_cmccare_P_LKE();
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
        if (C_NVL(b_dtuong) == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_doi = 0;
        if (b_dtuong.indexOf("SO_THE") >= 0 || b_dtuong.indexOf("THAMSO") >= 0) {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "','" + a_tso[6] + "')", 200);
        }
        if (b_dtuong.indexOf("GOI_BH_DC") >= 0) {
            $get(b_goibhdcId).value = a_tso[0];
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_mucphidcId).value = a_tso[3];
            $get(b_goibhdcId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}


function ns_ql_bh_cmccare_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "SO_THE") {
            var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
            b_hang = GridX_Fi_timHangD(b_grlkeId, "SO_THE", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_ql_bh_cmccare_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_ql_bh_cmccare_P_CHUYEN_HANG(); }
            b_ten.focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ql_bh_cmccare_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_cd.Fs_NS_QL_BH_CMCCARE_MA(b_ma, b_TrangKt, a_cot, ns_ql_bh_cmccare_P_MA_KTRA_2KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ql_bh_cmccare_P_MA_KTRA_2KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_ql_bh_cmccare_P_CHUYEN_HANG(); }
}
function ns_ql_bh_cmccare_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    return false;
}
var ns_ql_bh_cmccare_choAct = 0;
function ns_ql_bh_cmccare_GR_lke_RowChange() {
    if (ns_ql_bh_cmccare_choAct != 0) clearTimeout(ns_ql_bh_cmccare_choAct);
    ns_ql_bh_cmccare_choAct = setTimeout("ns_ql_bh_cmccare_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_ql_bh_cmccare_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_ql_bh_cmccare_lkeCho); ns_ql_bh_cmccare_P_LKE(); }
}

function ns_ql_bh_cmccare_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }

    var a_tso = slide_Faobj_TUDEN(b_slideId);
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_cd.Fs_NS_QL_BH_CMCCARE_NH(b_TrangKt, a_dt_ct, a_cot, a_tso, ns_ql_bh_cmccare_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_ql_bh_cmccare_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI("loi:Nhập bản ghi thành công:loi");
        //ns_ql_bh_cmccare_P_LKE();
    }
    return false;
}
function ns_ql_bh_cmccare_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    $get(b_gocId).focus();
    return false;
}

function ns_ql_bh_cmccare_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "SO_THE"), b_goiht = GridX_Fas_layGtri(b_grlkeId, b_hang, "GOI_BH_HT"), b_goidc = GridX_Fas_layGtri(b_grlkeId, b_hang, "GOI_BH_DC"), b_ngayhl = GridX_Fas_layGtri(b_grlkeId, b_hang, "NGAY_HL");
    if (b_ma == "") ns_ql_bh_cmccare_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
             b_so_thetk = $get(b_so_the_tk).value, b_tentk = $get(b_ten_tk).value, b_donvitk = $get(b_donvi_tk).value;
        sns_cd.Fs_NS_QL_BH_CMCCARE_XOA(b_ma, b_goiht, b_goidc, b_ngayhl, b_so_thetk, b_tentk, b_donvitk, a_tso, a_cot, ns_ql_bh_cmccare_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_ql_bh_cmccare_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_ql_bh_cmccare_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_ql_bh_cmccare_P_CHUYEN_HANG(); }
    }
}

function ns_ql_bh_cmccare_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the"));
        if (b_ma == "") form_P_MOI(b_vungId, "XGL"); else form_P_GridX_TEXT(b_vungId, b_grlkeId);
    }
    catch (err) { form_P_LOI(err); }
}

function ns_ql_bh_cmccare_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_sothe = $get(b_so_the_tk).value, b_ten = $get(b_ten_tk).value, b_donvitk = $get(b_donvi_tk).value;
        sns_cd.Fs_NS_QL_BH_CMCCARE_LKE(b_sothe, b_ten, b_donvitk, a_tso, a_cot, ns_ql_bh_cmccare_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ql_bh_cmccare_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}

function mydiff(date1, date2, interval) {
    var second = 1000, minute = second * 60, hour = minute * 60, day = hour * 24, week = day * 7;
    date1 = new Date(date1);
    date2 = new Date(date2);
    var timediff = date2 - date1;
    if (isNaN(timediff)) return NaN;
    switch (interval) {
        case "years": return date2.getFullYear() - date1.getFullYear();
        case "months": return (
            (date2.getFullYear() * 12 + date2.getMonth())
            -
            (date1.getFullYear() * 12 + date1.getMonth())
        );
        case "weeks": return Math.floor(timediff / week);
        case "days": return Math.floor(timediff / day);
        case "hours": return Math.floor(timediff / hour);
        case "minutes": return Math.floor(timediff / minute);
        case "seconds": return Math.floor(timediff / second);
        default: return undefined;
    }
}

function ns_biendong_bh_Export() {
    __doPostBack('ctl00$ContentPlaceHolder1$Nhap', '');
}
function nhap_file() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một ứng viên"); return false; }

    //var b_tenf = b_tmf + '/ns/ma/file_luu.aspx';
    //var b_so_the = $get(b_gocId).value;
    //form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "CV_UV", b_so_the, "Lưu CV ứng viên"]], null);
    //return false;


    var b_tenf = '/App_form/ns/ma/file_import_Anh.aspx';
    var b_so_the = $get(b_gocId).value;
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "CV_UV", b_so_the, "Lưu CV ứng viên"]], null);
    form_P_LOI('');
    return false;
}
function form_dong() {
    location.reload(false);
}