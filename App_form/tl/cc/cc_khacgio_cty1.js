
var cc_khacgio_cty_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timIdb_nhomId, b_nhomId, b_so_theId, b_TENId, b_gchuId, b_so_theId, b_tu_ngayId, b_den_ngayId,b_khoadtId;
function cc_khacgio_cty_P_KD() {
    cc_khacgio_cty_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_so_theId = form_Fs_TEN_ID(b_vungId, 'so_the'), b_tu_ngayId = form_Fs_TEN_ID(b_vungId, 'tu_ngay'), b_den_ngayId = form_Fs_TEN_ID(b_vungId, 'den_ngay');
    b_slideId = b_grlkeId + '_slide';
    cc_khacgio_cty_lkeCho = setInterval('cc_khacgio_cty_P_LKE_CHO()', 200);
}
var b_cho_control = 0;
function P_cho(b_ma_nhom, b_ten, b_phong) {
    try {
        if (b_doi == 0) {  
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
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            $get(b_so_theId).value = b_kq;
        }  
    }
    catch (err) { form_P_LOI(err); }
}
function cc_khacgio_cty_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) { 
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); cc_khacgio_cty_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); cc_khacgio_cty_P_CHUYEN_HANG(); }
            b_ten.focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function cc_khacgio_cty_P_MA_KTRA() {
    try {
        var b_ma = "";//C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            //stl_cc.Fs_cc_khacgio_cty_MA(b_ma, b_TrangKt, a_cot, cc_khacgio_cty_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function cc_khacgio_cty_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); cc_khacgio_cty_P_CHUYEN_HANG(); }
}

var cc_khacgio_cty_choAct = 0;
function cc_khacgio_cty_GR_lke_RowChange() {
    if (cc_khacgio_cty_choAct != 0) clearTimeout(cc_khacgio_cty_choAct);
    cc_khacgio_cty_choAct = setTimeout("cc_khacgio_cty_P_CHUYEN_HANG()", 300);
    return false;
}

function cc_khacgio_cty_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(cc_khacgio_cty_lkeCho); cc_khacgio_cty_P_LKE(); }
}

function cc_khacgio_cty_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    //stl_cc.Fs_cc_khacgio_cty_NH(b_TrangKt, a_dt_ct, a_cot, cc_khacgio_cty_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function cc_khacgio_cty_P_NH_KQ(b_kq) {
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
function cc_khacgio_cty_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    $get(b_gocId).focus();
    return false;
}

function cc_khacgio_cty_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    if (b_ma == "") cc_khacgio_cty_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        return false;
        //stl_cc.Fs_cc_khacgio_cty_XOA(b_ma, a_tso, a_cot, cc_khacgio_cty_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function cc_khacgio_cty_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId); 
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) cc_khacgio_cty_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); cc_khacgio_cty_P_CHUYEN_HANG(); }
    }
}

function cc_khacgio_cty_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_ma == "") form_P_MOI(b_vungId, "XGL"); else form_P_GridX_TEXT(b_vungId, b_grlkeId);
    }
    catch (err) { form_P_LOI(err); }
}

function cc_khacgio_cty_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_so_the = $get(b_so_theId).value, b_tungay = $get(b_tu_ngayId).value, b_denngay= $get(b_den_ngayId).value;
         
        var b_phong = 'BSS';
        stl_cc.Fs_CC_KHACGIO_CTY_LKE(b_so_the, b_tungay, b_denngay,b_phong, a_tso, a_cot, cc_khacgio_cty_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function cc_khacgio_cty_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function form_dong() {
    location.reload(false);
}