var b_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timIdb_nhomId, b_nhomId, b_trangthai_Id, b_nsd, b_cho_control = 0, dg_dm_tieuchi_choAct = 0;
function dg_dm_tieuchi_P_KD() {
    b_lkeCho = setInterval('dg_dm_tieuchi_P_LKE_CHO()', 200);
}
function P_cho(b_ma_nhom, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_nhomId).value = b_ma_nhom;
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
        if (b_dtuong.indexOf("NHOM") >= 0) {
            $get(b_nhomId).value = b_kq;
            dg_dm_tieuchi_P_LKE(); form_P_MOI(b_vungId, "GX");
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_nhomId).focus();
        } else if (b_dtuong.indexOf("THAMSO") >= 0) {
            //$get(b_nhomId).value = b_kq;
            lke_P_IdDAT(b_nhomId, b_kq);
            $get(b_trangthai_Id).value = "A";
            dg_dm_tieuchi_P_LKE_NHOM();
            form_P_MOI(b_vungId, "GX");
            $get(b_gocId).focus();
        } else if (b_dtuong.indexOf("TAI_IMPORT") >= 0) {
            dg_dm_tieuchi_P_LKE();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function dg_dm_tieuchi_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
            case "MA_NHOM": b_maId = b_nhomId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
            var b_ma_nhom = C_NVL(form_Fs_TEN_GTRI(b_vungId, 'MA_NHOM'));
            var b_ten_nhom = $get(b_nhomId).value;
            var a_ma = [b_ma.value, b_ma_nhom + "{" + b_ten_nhom];
            var b_hang = GridX_Fi_timHangD(b_grlkeId, ["ma", "ma_nhom"], a_ma);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); dg_dm_tieuchi_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); dg_dm_tieuchi_P_CHUYEN_HANG(); }
            b_ten.focus();
        } else if (b_maTen == "MA_NHOM") {
            dg_dm_tieuchi_P_LKE();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function dg_dm_tieuchi_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sdg.Fs_DG_DM_TIEUCHI_MA(b_nsd, b_ma, b_TrangKt, a_cot, dg_dm_tieuchi_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function dg_dm_tieuchi_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); dg_dm_tieuchi_P_CHUYEN_HANG(); }
}
function dg_dm_tieuchi_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}
function dg_dm_tieuchi_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    var b_kytudau = "TC", b_tenbang = "DG_DM_TIEUCHI", b_tencot = "MA";
    hts_dungchung.Fs_AutoGenCode(b_kytudau, b_tenbang, b_tencot, dg_dm_tieuchi_P_GENCODE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    GridX_thoiA(b_grlkeId);
    var b_tt = "TT;A";
    form_P_CH_TEXT(b_vungId, b_tt);
    $get(b_gocId).focus();
    return false;
}
function dg_dm_tieuchi_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sdg.Fs_DG_DM_TIEUCHI_NH(b_nsd, b_TrangKt, a_dt_ct, a_cot, dg_dm_tieuchi_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function dg_dm_tieuchi_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI("loi:Ghi thành công!:loi");
    }
    return false;
}
function dg_dm_tieuchi_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    if (b_ma == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); dg_dm_tieuchi_P_MOI(); }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_DG_DM_TIEUCHI_XOA(b_nsd, b_ma, a_tso, a_cot, dg_dm_tieuchi_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function dg_dm_tieuchi_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
        var b_dong = GridX_Fi_timHangC(b_grlkeId);
        if (b_hang > b_dong) b_hang = b_dong;
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) dg_dm_tieuchi_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); dg_dm_tieuchi_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
}
function dg_dm_tieuchi_GR_lke_RowChange() {
    if (dg_dm_tieuchi_choAct != 0) clearTimeout(dg_dm_tieuchi_choAct);
    dg_dm_tieuchi_choAct = setTimeout("dg_dm_tieuchi_P_CHUYEN_HANG()", 300);
    return false;
}
function dg_dm_tieuchi_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        if (b_ma == "") dg_dm_tieuchi_P_MOI(); else form_P_GridX_TEXT(b_vungId, b_grlkeId);
    }
    catch (err) { form_P_LOI(err); }
}
function dg_dm_tieuchi_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(b_lkeCho); b_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'), b_nhomId = form_Fs_TEN_ID(b_vungId, 'MA_NHOM');
        b_slideId = $get(b_grlkeId).getAttribute('slideId'); slide_P_MOI(b_slideId);
        b_gchuId = form_Fs_VTEN_ID('', 'gchu1');
        b_trangthai_Id = form_Fs_VTEN_ID('UPa_hi', 'trangthai');
        b_nsd = form_Fs_nsd();
        var b_kytudau = "TC", b_tenbang = "DG_DM_TIEUCHI", b_tencot = "MA";
        hts_dungchung.Fs_AutoGenCode(b_kytudau, b_tenbang, b_tencot, dg_dm_tieuchi_P_GENCODE_KQ, P_LOI_CSDL, P_LOI_TGIAN); dg_dm_tieuchi_P_LKE();
    }
}
function dg_dm_tieuchi_P_LKE() {
    try {
        if ($get(b_trangthai_Id).value != "")
            dg_dm_tieuchi_P_LKE_NHOM();
        else {
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            sdg.Fs_DG_DM_TIEUCHI_LKE(b_nsd, a_tso, a_cot, dg_dm_tieuchi_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function dg_dm_tieuchi_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function dg_dm_tieuchi_P_LKE_NHOM() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_ma_nhom = lke_Fs_TRA(b_nhomId), b_tt = $get(b_trangthai_Id).value;
        sdg.Fs_DG_DM_TIEUCHI_LKE_NHOM(b_nsd, b_ma_nhom, b_tt, a_tso, a_cot, dg_dm_tieuchi_P_LKE_KQ_NHOM, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function dg_dm_tieuchi_P_LKE_KQ_NHOM(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function dg_dm_tieuchi_P_GENCODE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        $get(b_gocId).value = b_kq;
    }
}
function dg_dm_tieuchi_FILE_Import() {//import từ file Excel
    var b_tenf = '/App_form/ns/ma/file_Import.aspx';
    form_P_MO(b_tenf, window.name + ',THAMSO', ['THAMSO', [window.name, 'TIEUCHI_DG_IMP', null, "Import tiêu chí đánh giá"]], null); 
    form_P_LOI('');
    return false;
}
function ktra_ngay(tungay, denngay, loai, ten1, ten2) {
    if (denngay == "" || denngay == null) {
        return "";
    }
    if (loai == 1 && tungay > denngay) {
        return "loi: " + ten1 + " không được lớn hơn " + ten2 + " :loi";
    } else if (loai == 2 && tungay >= denngay) {
        return "loi: " + ten1 + " không được lớn hơn hoặc bằng " + ten2 + " :loi";
    }
    return "";
}
function parseDate(str) {
    var mdy = str.split('/');
    return new Date(mdy[2], mdy[1], mdy[0]);
}
function form_dong() {
    location.reload(false);
}