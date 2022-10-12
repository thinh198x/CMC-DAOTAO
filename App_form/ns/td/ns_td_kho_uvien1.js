
var ns_td_kho_uvien_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gtId,b_gocId, b_timId, b_ncdanhId, b_cdanh, b_cmt2Id, b_GioitinhId;
function ns_td_kho_uvien_P_KD(b_tm) {
    b_tmf = b_tm, ns_td_kho_uvien_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_vung2Id = form_Fs_VUNG_ID('UPa_cd'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'CMT');
    b_ngaysinh = form_Fs_TEN_ID(b_vungId, 'ngay_sinh');
    b_ncdanhId = form_Fs_TEN_ID(b_vung2Id, 'NCDANH');
    b_cdanhId = form_Fs_TEN_ID(b_vung2Id, 'CDANH');
    b_cmt2Id = form_Fs_TEN_ID(b_vung2Id, 'CMT2');
    b_GioitinhId = form_Fs_TEN_ID(b_vung2Id, 'dGT');
    b_gtId = form_Fs_TEN_ID(b_vungId, 'gioi_tinh');
    b_slideId = b_grlkeId + '_slide';
    ns_td_kho_uvien_lkeCho = setInterval('ns_td_kho_uvien_P_LKE_CHO()', 200);

}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (C_NVL(b_dtuong) == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        if (b_dtuong.indexOf("NCDANH") >= 0) {
            $get(b_ncdanhId).value = a_tso[0];
        }
        else if (b_dtuong.indexOf("CDANH") >= 0) {
            $get(b_cdanhId).value = a_tso[0];
        }


    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_kho_uvien_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "CMT": b_maId = b_gocId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "CMT") {
            var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
            b_hang = GridX_Fi_timHangD(b_grlkeId, "CMT", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_td_kho_uvien_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_td_kho_uvien_P_CHUYEN_HANG(); }
            b_ten.focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_kho_uvien_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_td.Fs_NS_TD_KHO_UVIEN_MA(b_ma, b_TrangKt, a_cot, ns_td_kho_uvien_P_MA_KTRA_2KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_kho_uvien_P_MA_KTRA_2KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_td_kho_uvien_P_CHUYEN_HANG(); }
}
function ns_td_kho_uvien_P_TIM() {
    try {
        var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
        var b_ncdanh = C_NVL($get(b_ncdanhId).value);
        var b_cdanh = C_NVL($get(b_cdanhId).value);
        var b_cmtId = C_NVL($get(b_cmt2Id).value);
        var b_GioiTinh = C_NVL($get(b_GioitinhId).value);
        var a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_td.Fs_NS_TD_KHO_UVIEN_TIM(b_ncdanh, b_cdanh, b_cmtId, b_GioiTinh, b_TrangKt, a_cot, a_tso,ns_td_kho_uvien_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_kho_uvien_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    return false;
}
var ns_td_kho_uvien_choAct = 0;
function ns_td_kho_uvien_GR_lke_RowChange() {
    if (ns_td_kho_uvien_choAct != 0) clearTimeout(ns_td_kho_uvien_choAct);
    ns_td_kho_uvien_choAct = setTimeout("ns_td_kho_uvien_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_td_kho_uvien_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_td_kho_uvien_lkeCho); ns_td_kho_uvien_P_TIM(); }
}

function ns_td_kho_uvien_P_NH() {

   
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var dateNow = new Date();
    var ktra = ktra_ngay(parseDate($get(b_ngaysinh).value).getFullYear(), dateNow.getFullYear(), 1, "Năm sinh", "năm hiện tại");
    if (ktra.length > 0) {
        ns_td_kho_uvien_P_NH_KQ(ktra);
        return false;
    }
    var a_tso = slide_Faobj_TUDEN(b_slideId);
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_td.Fs_NS_TD_KHO_UVIEN_NH(b_TrangKt, a_dt_ct, a_cot,a_tso, ns_td_kho_uvien_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_td_kho_uvien_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI("loi:Nhập bản ghi thành công:loi");

        form_P_MOI(b_vung2Id, "GXL");
        $get(b_GioitinhId).value = $get(b_gtId).value;
        //ns_td_kho_uvien_P_TIM();
    }
    return false;
}
function ns_td_kho_uvien_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    $get(b_gocId).focus();
    return false;
}

function ns_td_kho_uvien_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "CMT");
    if (b_ma == "") ns_td_kho_uvien_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_td.Fs_NS_TD_KHO_UVIEN_XOA(b_ma, a_tso, a_cot, ns_td_kho_uvien_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_td_kho_uvien_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_td_kho_uvien_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_td_kho_uvien_P_CHUYEN_HANG(); }
    }
}

function ns_td_kho_uvien_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "cmt"));
        if (b_ma == "") form_P_MOI(b_vungId, "XGL"); else form_P_GridX_TEXT(b_vungId, b_grlkeId);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_kho_uvien_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId), b_ma_cmt = $get(b_gocId).value;
        sns_td.Fs_NS_TD_KHO_UVIEN_LKE(b_ma_cmt, a_tso, a_cot, ns_td_kho_uvien_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function ktra_ngay(tungay, denngay, loai, ten1, ten2) {
    if (denngay == "" || denngay == null) {
        return "";
    }
    if (loai == 1 && tungay >= denngay) {
        return "loi: " + ten1 + " không được lớn hơn hoặc bằng " + ten2 + " :loi";
    } 
    return "";
}
function parseDate(str) {
    var mdy = str.split('/');
    return new Date(mdy[2], mdy[1], mdy[0]);
}

function ns_td_kho_uvien_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
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