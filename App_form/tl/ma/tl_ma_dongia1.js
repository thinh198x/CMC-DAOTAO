var tl_ma_dongia_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_grctId, b_dongiaId, b_so_idId, b_gchuId, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C';
function tl_ma_dongia_P_KD() {
    tl_ma_dongia_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'MASP'),
    b_dongiaId = form_Fs_TEN_ID(b_vungId, 'DONGIA'), b_ngayId = form_Fs_TEN_ID(b_vungId, 'NGAY');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');

    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_slideId = $get(b_grlkeId).getAttribute('slideId');
    tl_ma_dongia_lkeCho = setInterval('tl_ma_dongia_P_LKE_CHO()', 200);
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("MASP") >= 0) {
            $get(b_gocId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_gocId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}

function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}

function tl_ma_dongia_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MASP": b_maId = b_gocId; form_P_MOI("", "XGL"); break;
            case "NGAY": b_maId = b_ngayId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        else if (b_maTen == "NGAY") {
            GridX_thoiA(b_grlkeId); tl_ma_dongia_P_MA_KTRA();
        }
    }
    catch (err) { form_P_LOI(err); }
}

function tl_ma_dongia_P_MA_KTRA() {
    try {
        var b_masp = C_NVL(lke_Fs_TRA(b_gocId));
        if (b_masp != "") {
            var b_ngay = $get(b_ngayId).value;
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            stl_ma.Fs_TL_MA_DONGIA_MA(b_masp, b_ngay, b_TrangKt, a_cot, tl_ma_dongia_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function tl_ma_dongia_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) { form_P_MOI(b_vungId, "X");  }
    else { GridX_datA(b_grlkeId, b_hang); tl_ma_dongia_P_CHUYEN_HANG(); }
}

function tl_ma_dongia_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    $get(b_gchuId).innerHTML = b_kq;
    form_P_MOI(b_vungId, "GX");
}
var tl_ma_dongia_choAct = 0;
function tl_ma_dongia_GR_lke_RowChange() {
    if (tl_ma_dongia_choAct != 0) clearTimeout(tl_ma_dongia_choAct);
    tl_ma_dongia_choAct = setTimeout("tl_ma_dongia_P_CHUYEN_HANG()", 300);
    return false;
}

function tl_ma_dongia_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (tl_ma_dongia_lkeCho != 0) clearTimeout(tl_ma_dongia_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        tl_ma_dongia_P_LKE('K');
    }
}
function tl_ma_dongia_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_gocId).value = "";
    $get(b_dongiaId).value = "";
    $get(b_gocId).focus();
    return false;
}

function tl_ma_dongia_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_ma.Fs_TL_MA_DONGIA_LKE(a_cot, a_tso, tl_ma_dongia_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function tl_ma_dongia_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    b_fcho = 'X';
}
function tl_ma_dongia_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        $get(b_so_idId).value = b_so_id;
        if (b_so_id == "") { form_P_MOI(b_vungId, "XGL"); }
        else stl_ma.Fs_TL_MA_DONGIA_CT(b_so_id, Fs_MA_DONGIA_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function Fs_MA_DONGIA_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
}
function tl_ma_dongia_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var b_so_id = $get(b_so_idId).value;
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
    stl_ma.Fs_TL_MA_DONGIA_NH(b_so_id, b_TrangKt, a_dt_ct, a_cot_lke, tl_ma_dongia_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function tl_ma_dongia_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = b_kq.split('#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        form_P_LOI("loi:Nhập thành công!:loi");
    }
    return false;
}
function tl_ma_dongia_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") tl_ma_dongia_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_ma.Fs_TL_MA_DONGIA_XOA(b_so_id, a_tso, a_cot, tl_ma_dongia_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function tl_ma_dongia_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) tl_ma_dongia_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); tl_ma_dongia_P_CHUYEN_HANG(); }
    }
}

function form_dong() {
    location.reload(false);
}