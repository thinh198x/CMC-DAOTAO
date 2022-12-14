var tl_khenthuong_lkeCho, b_choAct = 0, b_vungId, b_vungtk, b_grlkeId, b_slideId, b_gocId, b_phong_tk, b_ten_nv_nv, b_kyluong, b_timId;
function tl_khenthuong_P_KD() {
    tl_khenthuong_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtk = form_Fs_VUNG_ID('UPa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_slideId = b_grlkeId + '_slide';
    tl_khenthuong_lkeCho = setInterval('tl_khenthuong_P_LKE_CHO()', 200);
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        var b_hso = a_tso[1];
        b_doi = 0;
        if (b_dtuong.indexOf("SO_THE") >= 0 || b_dtuong.indexOf("THAMSO") >= 0) {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "','" + a_tso[6] + "')", 200);
        } else if (b_dtuong.indexOf("LOAI_BD") >= 0) {
            $get(b_loaibd).value = b_kq;
            $get(b_gchuId).innerhtml = b_hso;
        }
    }
    catch (err) { form_P_LOI(err); }
}
var b_cho_control = 0;
function P_cho(b_so_the, b_ten, b_phong, b_chucdanh) {
    try {
        if (b_doi == 0) {
            $get(b_gocId).value = b_so_the;
            $get(b_tenNV).value = b_ten;
            $get(b_phongban).value = b_phong;
            $get(b_cdanh).value = b_chucdanh;
            tl_khenthuong_load_luong();
            $get(b_gocId).focus();
            tl_khenthuong_P_LKE();
            b_doi = 1;
            clearTimeout(b_cho_control);
        }
    }
    catch (err) {
        b_doi = 0;
    }
}
function tl_khenthuong_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_biendong_bh_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            var b_ten_nv = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
            b_hang = GridX_Fi_timHangD(b_grlkeId, "SO_THE", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_biendong_bh_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_biendong_bh_P_CHUYEN_HANG(); }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function tl_khenthuong_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            //stl_ma.Fs_tl_khenthuong_MA(b_ma, b_TrangKt, a_cot, tl_khenthuong_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function tl_khenthuong_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); tl_khenthuong_P_CHUYEN_HANG(); }
}

var tl_khenthuong_choAct = 0;
function tl_khenthuong_GR_lke_RowChange() {
    if (tl_khenthuong_choAct != 0) clearTimeout(tl_khenthuong_choAct);
    tl_khenthuong_choAct = setTimeout("tl_khenthuong_P_CHUYEN_HANG()", 300);
    return false;
}

function tl_khenthuong_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(tl_khenthuong_lkeCho); tl_khenthuong_P_LKE(); ht_maph_P_LKE(); }
}

function tl_khenthuong_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    stl_ch.Fs_GIULUONG_NH(b_TrangKt, a_dt_ct, a_cot, tl_khenthuong_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function tl_khenthuong_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        tl_khenthuong_P_LKE();
    }
    return false;
}
function tl_khenthuong_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    $get(b_gocId).focus();
    return false;
}

function tl_khenthuong_P_XOA() {
    var r = confirm("Bạn có chắc chắn xóa không?");
    if (r == false) {
        return false;
    }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var a_so_the = GridX_Fas_layGtri(b_grlkeId, b_hang, "SO_THE");
    if (a_so_the == "") tl_khenthuong_P_MOI();
    else {
        var a_phong = $get(b_phong_tk).value, a_ten = $get(b_ten_nv_tk).value, a_kyluong = $get(b_kyluong_tk).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_ch.Fs_GIULUONG_XOA(a_so_the, a_phong, a_ten, a_kyluong, a_tso, a_cot, tl_khenthuong_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function tl_khenthuong_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) tl_khenthuong_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); tl_khenthuong_P_CHUYEN_HANG(); }
    }
}

function tl_khenthuong_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "SO_THE"));
        if (b_ma == "") form_P_MOI(b_vungId, "XGL"); else form_P_GridX_TEXT(b_vungId, b_grlkeId);
    }
    catch (err) { form_P_LOI(err); }
}

function tl_khenthuong_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var a_phong = $get(b_phong_tk).value, a_ten = $get(b_ten_nv_tk).value, a_kyluong = $get(b_kyluong_tk).value;
        stl_ch.Fs_GIULUONG_LKE(a_phong, a_ten, a_kyluong, a_tso, a_cot, tl_khenthuong_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        
    }
    catch (err) { form_P_LOI(err); }
}
function tl_khenthuong_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
//Bộ phận
function ht_maph_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId);
        sht_ma.Fs_MA_PH_LKE3(form_Fs_nsd(), '', a_cot, ht_maph_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ht_maph_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else { GridX_datBang(b_grlkeId, b_kq); slide_P_SOTRANG(b_slideId); }
}
function ht_maph_GR_lke_RowChange() {
    if (b_choAct != 0) clearTimeout(b_choAct);
    b_choAct = setTimeout("ht_maph_P_CHUYEN_HANG()", 300);
    return false;
}
function ht_maph_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    //if (b_hang < 1 || GridX_Fb_hangTrang(b_grlkeId, b_hang)) form_P_MOI(b_vungId, "GXL");
    //else form_P_GridX_TEXT(b_vungId, b_grlkeId);
}
//end
function tl_khenthuong_load_luong() {
    try {
        var a_so_the = C_NVL($get(b_gocId).value), a_kyluong = C_NVL($get(b_kyluong).value);
        if (a_so_the != "") {
            stl_ch.Fs_GET_LUONG_BY_SOTHE(a_so_the, a_kyluong, tl_khenthuong_load_luong_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function tl_khenthuong_load_luong_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    $get(b_tienluong).value = b_kq;
    return false;
}

function tl_khenthuong_P_IN() {
    __doPostBack('ctl00$ContentPlaceHolder1$Nhap2', '');
}

function ns_danhsach_P_NAM() {
    try {
        var b_nam = form_Fs_TEN_GTRI(b_vungtk, 'nam_tk');
        stl_ch.Fs_DANHSACH_KYLUONG_LKE(b_nam, ns_danhsach_P_KYLUONG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_danhsach_P_KYLUONG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_kyluongId = form_Fs_TEN_ID(b_vungtk, 'kyluong_tk');
        drop_P_LKE(b_kyluongId, b_kq);
    }
}
function form_dong() {
    location.reload(false);
}