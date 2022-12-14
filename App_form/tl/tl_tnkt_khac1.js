var tl_tnkt_khac_lkeCho, b_vungId, b_grlkeId, b_gocId,b_mt, b_gchuId;
function tl_tnkt_khac_P_KD() {
    tl_tnkt_khac_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
    b_ngayId = form_Fs_TEN_ID(b_vungId, 'NGAY'); b_loaiId = form_Fs_TEN_ID(b_vungId, 'loai');
    b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE');
    b_tienId = form_Fs_TEN_ID(b_vungId, 'tien'); b_chiuthueId = form_Fs_TEN_ID(b_vungId, 'chiuthue');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_slideId = b_grlkeId + '_slide';
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            $get(b_gocId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            tl_tnkt_khac_P_LKE();
            $get(b_gocId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function tl_tnkt_khac_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; form_P_MOI("", "XGL"); break;
            case "NGAY": b_maId = b_ngayId; break;
            case "LOAI": b_maId = b_loaiId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), tl_tnkt_khac_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            tl_tnkt_khac_P_LKE();
        }
        else if (b_maTen == "LOAI") {
            tl_tnkt_khac_P_LKE();
            tl_tnkt_khac_P_MOI();
        }
        else if (b_maTen == "NGAY") {
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ngay", b_ma.value);
            if (b_hang < 0) { tl_tnkt_khac_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); tl_tnkt_khac_P_CHUYEN_HANG(); }
        }
    }
    catch (err) { form_P_LOI(err); }
}

function tl_tnkt_khac_P_MA_KTRA() {
    try {
        var b_ngay = C_NVL($get(b_ngayId).value);
        if (b_ngay != "") {
            var b_ngay = $get(b_ngayId).value,b_so_the = $get(b_gocId).value, b_loai = $get(b_loaiId).value;
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            stl_ch.Fs_TL_TNKT_KHAC_MA(b_so_the,b_loai, b_ngay, b_TrangKt, a_cot, tl_tnkt_khac_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function tl_tnkt_khac_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        form_P_MOI(b_vungId, "X"); 
        $get(b_tienId).focus();
    }
    else { GridX_datA(b_grlkeId, b_hang); tl_tnkt_khac_P_CHUYEN_HANG(); }
}

function tl_tnkt_khac_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}
var tl_tnkt_khac_choAct = 0;
function tl_tnkt_khac_GR_lke_RowChange() {
    if (tl_tnkt_khac_choAct != 0) clearTimeout(tl_tnkt_khac_choAct);
    tl_tnkt_khac_choAct = setTimeout("tl_tnkt_khac_P_CHUYEN_HANG()", 300);
    return false;
}

function tl_tnkt_khac_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(tl_tnkt_khac_lkeCho); tl_tnkt_khac_P_LKE(); }
}

function tl_tnkt_khac_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_ngayId).focus();
}

function tl_tnkt_khac_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_so_the = $get(b_gocId).value, b_loai = $get(b_loaiId).value;
        stl_ch.Fs_TL_TNKT_KHAC_LKE(b_so_the,b_loai, a_tso, a_cot, tl_tnkt_khac_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function tl_tnkt_khac_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}

function tl_tnkt_khac_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            stl_ch.Fs_TL_TNKT_KHAC_NH(b_TrangKt, a_dt_ct, a_cot_lke, tl_tnkt_khac_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}

function tl_tnkt_khac_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI('loi:Nhập thành công:loi');
    }
    return false;
}

function tl_tnkt_khac_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_ngay = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ngay"));
    if (b_ngay == "") form_P_MOI(b_vungId, "XGL");
    else {
        var b_so_the = $get(b_gocId).value, b_loai = $get(b_loaiId).value;
        stl_ch.Fs_TL_TNKT_KHAC_CT(b_so_the,b_loai,b_ngay, tl_tnkt_khac_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function tl_tnkt_khac_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
function tl_tnkt_khac_P_XOA() {
    var r = confirm("Bạn có chắc chắn xóa không?");
    if (r == false) {
        return false;
    }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_ngay = GridX_Fas_layGtri(b_grlkeId, b_hang, "ngay");
    if (b_ngay == "") tl_tnkt_khac_P_MOI();
    else {
        var b_so_the = $get(b_gocId).value, b_loai = $get(b_loaiId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_ch.Fs_TL_TNKT_KHAC_XOA(b_so_the, b_loai, b_ngay, a_tso, a_cot, tl_tnkt_khac_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function tl_tnkt_khac_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) tl_tnkt_khac_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); tl_tnkt_khac_P_CHUYEN_HANG(); }
    }
}
function form_dong() {
    location.reload(false);
}