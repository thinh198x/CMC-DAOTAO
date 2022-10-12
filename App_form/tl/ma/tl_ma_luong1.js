
var tl_ma_luong_lkeCho, b_vungId, b_grctId, b_gocId, b_mt, b_gchuId, b_nhomluongId, b_doi = 0;
function tl_ma_luong_P_KD() {
    tl_ma_luong_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'MA');
    b_nhomluongId = form_Fs_TEN_ID(b_vungId, 'NLUONG');
    b_slideId = b_grctId + '_slide';
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    tl_ma_luong_lkeCho = setInterval('tl_ma_luong_P_LKE_CHO()', 200);
}

var b_cho_control = 0;
function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_gocId).value = b_so_the;
            $get(b_gchuId).innerHTML = b_ten;
            $get(b_gocId).focus();
            tl_ma_luong_P_LKE();
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
            $get(b_gocId).setAttribute("disabled", "disabled");
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function tl_ma_luong_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; form_P_MOI("", "XGL"); GridX_datTrang(b_grctId); break;
            case "NLUONG": b_maId = b_nhomluongId; break;
        }
        var b_ma = $get(b_maId);
        b_mt = b_maTen;
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), tl_ma_luong_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            tl_ma_luong_P_LKE();
        }
        else if (b_maTen == "NGAY") {
            var b_hang = GridX_Fi_timHangD(b_grctId, "ngayd", b_ma.value);
            if (b_hang < 0) { tl_ma_luong_P_MA_KTRA(); }
            else { GridX_datA(b_grctId, b_hang); tl_ma_luong_P_CHUYEN_HANG(); }
        } else if (b_maTen == "NLUONG") {
            tl_ma_luong_P_LKE();
        }
    }
    catch (err) { form_P_LOI(err); }
}

function tl_ma_luong_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_nhomluong = $get(b_nhomluongId).value;
            var b_TrangKt = GridX_Fi_hangKt(b_grctId), a_cot = GridX_Fas_tenCot(b_grctId);
            stl_ma.Fs_TL_MA_LUONG_MA(b_nhomluong,b_ma, b_TrangKt, a_cot, tl_ma_luong_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function tl_ma_luong_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grctId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        form_P_MOI(b_vungId, "X"); GridX_datTrang(b_grctId);
        $get(b_gocId).focus(); $get(b_so_idId).value = "0";
    }
    else { GridX_datA(b_grctId, b_hang); tl_ma_luong_P_CHUYEN_HANG(); }
}
function tl_ma_luong_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    $get(b_gchuId).innerHTML = b_kq;
}

var tl_ma_luong_choAct = 0;
function tl_ma_luong_GR_lke_RowChange() {
    if (tl_ma_luong_choAct != 0) clearTimeout(tl_ma_luong_choAct);
    tl_ma_luong_choAct = setTimeout("tl_ma_luong_P_CHUYEN_HANG()", 300);
    return false;
}

var tl_ma_luong2_choAct = 0;
function tl_ma_luong2_GR_lke_RowChange() {
    if (tl_ma_luong2_choAct != 0) clearTimeout(tl_ma_luong_choAct);
    tl_ma_luong2_choAct = setTimeout("tl_ma_luong2_P_CHUYEN_HANG()", 300);
    return false;
}
function tl_ma_luong2_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grctId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grctId, b_hang, "cdanh"));
        if (b_ma == "") form_P_MOI(b_vungId, "XGL"); else form_P_GridX_TEXT(b_vungId, b_grctId);
    }
    catch (err) { form_P_LOI(err); }
}
function tl_ma_luong_P_LKE_CHO() {
    if ($get(b_grctId) != null) { clearTimeout(tl_ma_luong_lkeCho); tl_ma_luong_P_LKE(); }
}

function tl_ma_luong_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grctId);
    GridX_datTrang(b_grctId);
    $get(b_gocId).focus();
    return false;
}
function tl_ma_luong_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grctId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_nhomluong = $get(b_nhomluongId).value;
        stl_ma.Fs_TL_MA_LUONG_LKE(b_nhomluong, a_tso, a_cot, tl_ma_luong_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function tl_ma_luong_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grctId, a_kq[1]);
}
function tl_ma_luong_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var b_nluong = $get(b_nhomluongId).value;
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grctId), b_TrangKt = GridX_Fi_hangKt(b_grctId);
    stl_ma.Fs_TL_MA_LUONG_NH(b_nluong,b_TrangKt, a_dt_ct, a_cot, tl_ma_luong_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function tl_ma_luong_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grctId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grctId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI('loi:Nhập thành công:loi');
    }
    return false;
}
function tl_ma_luong_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grctId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grctId, b_hang, "ma"));
        if (b_ma == "") form_P_MOI(b_vungId, "XGL"); else form_P_GridX_TEXT(b_vungId, b_grctId);
    }
    catch (err) { form_P_LOI(err); }
}
function tl_ma_luong_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
    var b_hang = GridX_Fi_timHangA(b_grctId);
}
function tl_ma_luong_P_XOA() {
    var r = confirm("Bạn có chắc chắn xóa không?");
    if (r == false) {
        return false;
    }
    var b_hang = GridX_Fi_timHangA(b_grctId);
    if (b_hang < 1) return;
    var b_ma = GridX_Fas_layGtri(b_grctId, b_hang, "MA");
    if (b_ma == "") tl_ma_luong_P_MOI();
    else {
        var b_nhomluong = $get(b_nhomluongId).value;
        var a_cot = GridX_Fas_tenCot(b_grctId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_ma.Fs_TL_MA_LUONG_XOA(b_nhomluong,b_ma, a_tso, a_cot, tl_ma_luong_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function tl_ma_luong_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grctId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grctId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grctId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grctId, b_hang)) tl_ma_luong_P_MOI();
        else { GridX_datA(b_grctId, b_hang); tl_ma_luong_P_CHUYEN_HANG(); }
    }
}
function tl_ma_luong_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function tl_ma_luong_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function tl_ma_luong_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function tl_ma_luong_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}

function form_dong() {
    location.reload(false);
}