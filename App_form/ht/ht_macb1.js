var b_lkeCho, b_choAct = 0, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timId, b_gchuId, b_phongId, b_cvId, b_tenId;
function ht_macb_KD() {
    b_vungId = form_Fs_VUNG_ID('UPa_ct');
    b_grlkeId = form_Fs_VUNG_ID('GR_lke'); b_slideId = b_grlkeId + '_slide';
    b_phongId = form_Fs_TEN_ID(b_vungId, 'PHONG'); b_gocId = form_Fs_TEN_ID(b_vungId, 'MA');
    b_cvId = form_Fs_TEN_ID(b_vungId, 'cv'); b_tenId = form_Fs_TEN_ID(b_vungId, 'TEN');
    b_timId = form_Fs_VTEN_ID('', 'tim_ten'); b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_lkeCho = setInterval('ht_macb_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (C_NVL(b_dtuong) == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("FILE") >= 0) ht_macb_P_FILE();
        else if (b_dtuong.indexOf("PHONG") >= 0) { $get(b_phongId).value = b_kq; $get(b_phongId).focus(); }
        else if (b_dtuong.indexOf("CV") >= 0) { $get(b_cvId).value = b_kq; $get(b_cvId).focus(); }
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ht_macb_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "PHONG": b_maId = b_phongId; break;
            case "MA": b_maId = b_gocId; break;
            case "CV": b_maId = b_cvId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            if (C_NVL($get(b_phongId).value) == "") return;
            $get(b_tenId).value = $get(b_timId).value = "";
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ht_macb_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); $get(b_tenId).focus(); ht_macb_P_CHUYEN_HANG(); }
        }
        else skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ht_macb_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ht_macb_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}
function ht_macb_P_MA_KTRA() {
    try {
        var b_phong = C_NVL($get(b_phongId).value), b_ma = C_NVL($get(b_gocId).value);
        if (b_phong == "" || b_ma == "") return;
        var b_hangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
        sht_ma.Fs_MA_CB_MA(form_Fs_nsd(),b_phong, b_ma, b_hangKt, a_cot, ht_macb_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ht_macb_P_MA_KTRA_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]), b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong); GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang < 1) form_P_MOI(b_vungId, "X");
        else { GridX_datA(b_grlkeId, b_hang,null,"K"); ht_macb_P_CHUYEN_HANG(); }
        $get(b_tenId).focus();
    }
    catch (ex) { form_P_LOI(ex.message); }
}
// Nhap
function ht_macb_P_MOI() {
    form_P_MOI(b_vungId, "GXL"); GridX_thoiA(b_grlkeId);
    $get(b_gocId).focus();
}
function ht_macb_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI_DICH(b_loi); return false; }
        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_hangKt = GridX_Fi_hangKt(b_grlkeId);;
        sht_ma.Fs_MA_CB_NH(form_Fs_nsd(),b_hangKt, a_dt_ct,a_cot, ht_macb_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ht_macb_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0], 0), b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong); GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang > 0) GridX_datA(b_grlkeId, b_hang,null,"K");
        $get(b_gocId).focus();
    }
}
function ht_macb_P_XOA() {
    try {
        var b_ma = C_NVL(GridX_Fas_layGtriA(b_grlkeId, "ma"));
        if (b_ma == "") ht_macb_P_MOI();
        else {
            var b_tim = C_NVL($get(b_timId).value), a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            sht_ma.Fs_MA_CB_XOA(form_Fs_nsd(),b_ma, b_tim, a_cot, a_tso, ht_macb_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ht_macb_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang == 1 && GridX_Fb_hangTrang(b_grlkeId, 2)) b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang) && b_hang > 1) b_hang--;
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ht_macb_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang,null,"K"); ht_macb_P_CHUYEN_HANG(); }
    }
}
function ht_macb_GR_lke_RowChange() {
    if (b_choAct != 0) clearTimeout(b_choAct);
    b_choAct = setTimeout("ht_macb_P_CHUYEN_HANG()", 300);
    return false;
}
function ht_macb_P_CHUYEN_HANG() {
    try {
        var b_ma = C_NVL(GridX_Fas_layGtriA(b_grlkeId, "ma"));
        if (b_ma == "") form_P_MOI(b_vungId, "XGL");
        else sht_ma.Fs_MA_CB_CT(form_Fs_nsd(),b_ma, ht_macb_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ht_macb_P_CHUYEN_HANG_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
        else if (b_kq == "") form_P_MOI(b_vungId, "X");
        else form_P_CH_TEXT(b_vungId, b_kq);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
// Liệt kê
function ht_macb_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(b_lkeCho); GridX_taoScroll(b_grlkeId); ht_macb_P_LKE(); }
}
function ht_macb_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId), b_tim = C_NVL($get(b_timId).value);
        sht_ma.Fs_MA_CB_LKE(form_Fs_nsd(),b_tim, a_cot, a_tso, ht_macb_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ht_macb_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (a_kq[1] != "") { if (b_hang>0) GridX_datA(b_grlkeId, b_hang, null, "K"); }
        else if (C_NVL($get(b_timId).value) != "") form_P_LOI_DICH("Không tìm thấy");
    }
}
function ht_macb_FILE() {
    form_P_MO(form_Fs_TM('f') + '/khud/khud_Excel.aspx', window.name + ",FILE", null);
    return false;
}
function ht_macb_P_FILE() {
    try { sht_ma.Fs_MA_CB_FILE(form_Fs_nsd(),ht_macb_P_FILE_KQ, P_LOI_CSDL, P_LOI_TGIAN); }
    catch (ex) { form_P_LOI(ex.message); }
}
function ht_macb_P_FILE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        $get(b_timId).value = ""; slide_P_MOI(b_slideId, 1, 1);
        ht_macb_P_LKE();
    }
}
