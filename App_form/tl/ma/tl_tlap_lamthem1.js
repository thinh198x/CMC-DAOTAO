
var tl_tlap_lamthem_lkeCho, b_vungId, tl_tlap_lamthem_choAct,b_grlkeId, b_slideId, b_gocId, b_lngId;
function tl_tlap_lamthem_P_KD() {
    tl_tlap_lamthem_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'NGAY');b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_slideId = b_grlkeId + '_slide'; tl_tlap_lamthem_DAT_GTRI();
    tl_tlap_lamthem_lkeCho = setInterval('tl_tlap_lamthem_P_LKE_CHO()', 200);
}
function tl_tlap_lamthem_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "NGAY": b_maId = b_gocId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "NGAY") {
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ngay", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); tl_tlap_lamthem_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); tl_tlap_lamthem_P_CHUYEN_HANG(); }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function tl_tlap_lamthem_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            stl_ma.Fs_TL_TLAP_LAMTHEM_MA(b_ma, b_TrangKt, a_cot, tl_tlap_lamthem_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function tl_tlap_lamthem_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); tl_tlap_lamthem_P_CHUYEN_HANG(); }
}
function tl_tlap_lamthem_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_datGtri(b_grctId, "1", ["lamthem", "lamdem"], ["", ""]);
    GridX_datGtri(b_grctId, "2", ["lamthem", "lamdem"], ["", ""]);
    GridX_datGtri(b_grctId, "3", ["lamthem", "lamdem"], ["", ""]);
    GridX_datGtri(b_grctId, "4", ["lamthem", "lamdem"], ["", ""]);
    GridX_thoiA(b_grlkeId);
    $get(b_gocId).focus();
    return false;
}
function tl_tlap_lamthem_P_NH() {
    //var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    //if (b_loi != "") { form_P_LOI(b_loi); return false; }
    //var b_so_id = $get(b_so_idId).value;
    //var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fdt_cotGtri(b_grctId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
    //stl_ma.Fs_TL_TLAP_LAMTHEM_NH(b_so_id, b_TrangKt, a_dt_ct, a_cot, a_cot_lke, tl_tlap_lamthem_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    //return false;
    var b_loi = form_Fs_TEXT_KTRA(b_vungId), b_so_id = '0';
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang > 0) b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fdt_cotGtri(b_grctId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
    stl_ma.Fs_TL_TLAP_LAMTHEM_NH(b_so_id, b_TrangKt, a_dt_ct, a_cot, a_cot_lke, tl_tlap_lamthem_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function tl_tlap_lamthem_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        form_P_LOI("Nhập dữ liệu thành công");
        $get(b_gocId).focus();
    }
    return false;
}
function tl_tlap_lamthem_P_XOA() { 
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; };
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); tl_tlap_lamthem_P_MOI(); return false; }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_ma.Fs_TL_TLAP_LAMTHEM_XOA(b_so_id, a_tso, a_cot, tl_tlap_lamthem_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function tl_tlap_lamthem_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) tl_tlap_lamthem_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); tl_tlap_lamthem_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
}
function tl_tlap_lamthem_GR_lke_RowChange() {
    if (tl_tlap_lamthem_choAct != 0) clearTimeout(tl_tlap_lamthem_choAct);
    tl_tlap_lamthem_choAct = setTimeout("tl_tlap_lamthem_P_CHUYEN_HANG()", 300);
    return false;
}
function tl_tlap_lamthem_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")),
        a_cot = GridX_Fas_tenCot(b_grctId);
        if (b_so_id == "") {
            form_P_MOI(b_vungId, "XGL");
            GridX_datGtri(b_grctId, "1", ["lamthem", "lamdem"], ["", ""]);
            GridX_datGtri(b_grctId, "2", ["lamthem", "lamdem"], ["", ""]);
            GridX_datGtri(b_grctId, "3", ["lamthem", "lamdem"], ["", ""]);
            GridX_datGtri(b_grctId, "4", ["lamthem", "lamdem"], ["", ""]);
        }
        else stl_ma.Fs_TL_TLAP_LAMTHEM_CT(b_so_id, a_cot, tl_tlap_lamthem_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        $get(b_so_idId).value = b_so_id;
    }
    catch (err) { form_P_LOI(err); }
}
function tl_tlap_lamthem_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_ngay = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ngay"));
        GridX_datBang(b_grctId, b_kq); $get(b_gocId).value = b_ngay;
    }
}
function tl_tlap_lamthem_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (tl_tlap_lamthem_lkeCho != 0) clearTimeout(tl_tlap_lamthem_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        tl_tlap_lamthem_P_LKE('K');
    } 
}
function tl_tlap_lamthem_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_ma.Fs_TL_TLAP_LAMTHEM_LKE(a_cot, a_tso, tl_tlap_lamthem_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function tl_tlap_lamthem_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
    } 
}
function tl_tlap_lamthem_DAT_GTRI() {
    a_cot = GridX_Fas_tenCot(b_grctId);
    stl_ma.Fs_TL_TLAP_LAMTHEM_GT(a_cot, tl_tlap_lamthem_DAT_GTRI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function tl_tlap_lamthem_DAT_GTRI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else GridX_datBang(b_grctId, b_kq);
}
function form_dong() {
    location.reload(false);
}