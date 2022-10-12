
var dgnl_tl_nl_cho_cdanh_lkeCho, b_vungId, b_grlkeId, b_grctId, b_gocId,b_nhom_nl_ten, b_mt, b_gchuId, b_doi = 0;
function dgnl_tl_nl_cho_cdanh_P_KD() {
    dgnl_tl_nl_cho_cdanh_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'CDANH'), b_ncdId = form_Fs_TEN_ID(b_vungId, 'hincd');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'); b_slideId = b_grlkeId + '_slide';
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    dgnl_tl_nl_cho_cdanh_lkeCho = setInterval('dgnl_tl_nl_cho_cdanh_P_LKE_CHO()', 200);
}

var b_cho_control = 0;
function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_gocId).value = b_so_the;
            $get(b_gchuId).innerHTML = b_ten;
            dgnl_tl_nl_cho_cdanh_P_LKE();
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
        var b_hso = a_tso[1];
        b_doi = 0;
        if (b_dtuong.indexOf("SO_THE") >= 0 || b_dtuong.indexOf("THAMSO") >= 0) {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
        }
        else if (b_dtuong.indexOf("CDANH") >= 0) {
            $get(b_gocId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
        }
        else if (b_dtuong.indexOf("NHOM_NL_TEN") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grctId, b_hang, ["NHOM_NL"], [a_tso[0]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["NHOM_NL_TEN"], [a_tso[1]], 'K');
            $get(b_gchuId).innerHTML = a_tso[0];
            $get(b_ncdId).value = b_kq;
        }
        else if (b_dtuong.indexOf("NANGLUC_TEN") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grctId, b_hang, ["nangluc"], [a_tso[0]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["NANGLUC_TEN"], [a_tso[1]], 'K');
            $get(b_gchuId).innerHTML = a_tso[0];
        }
    }
    catch (err) { form_P_LOI(err); }
}
function dgnl_tl_nl_cho_cdanh_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "CDANH": b_maId = b_gocId; break;
        }
        var b_ma = $get(b_maId);
        b_mt = b_maTen;
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "CDANH") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), dgnl_tl_nl_cho_cdanh_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
            b_hang = GridX_Fi_timHangD(b_grlkeId, "cdanh", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); dgnl_tl_nl_cho_cdanh_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); dgnl_tl_nl_cho_cdanh_P_CHUYEN_HANG(); }
           
        }
    }
    catch (err) { form_P_LOI(err); }
}

function dgnl_tl_nl_cho_cdanh_P_MA_KTRA() {
    try {
        var b_cdanh = $get(b_gocId).value;
        if (b_cdanh != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sdg.Fs_DGNL_TL_NL_CHO_CDANH_MA(b_cdanh, b_TrangKt, a_cot, dgnl_tl_nl_cho_cdanh_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function dgnl_tl_nl_cho_cdanh_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        form_P_MOI(b_vungId, "X"); GridX_datTrang(b_grctId);
       $get(b_so_idId).value = "0";
    }
    else { GridX_datA(b_grlkeId, b_hang); dgnl_tl_nl_cho_cdanh_P_CHUYEN_HANG(); }
}
function dgnl_tl_nl_cho_cdanh_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    $get(b_gchuId).innerHTML = b_kq;
}

var dgnl_tl_nl_cho_cdanh_choAct = 0;
function dgnl_tl_nl_cho_cdanh_GR_lke_RowChange() {
    if (dgnl_tl_nl_cho_cdanh_choAct != 0) clearTimeout(dgnl_tl_nl_cho_cdanh_choAct);
    dgnl_tl_nl_cho_cdanh_choAct = setTimeout("dgnl_tl_nl_cho_cdanh_P_CHUYEN_HANG()", 300);
    return false;
}
function dgnl_tl_nl_cho_cdanh_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grctId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        var b_ktra = C_NVL(b_ctr.ktra), b_ten = C_NVL(b_ctr.ten);
        if (b_value != "") {
            if (b_cot == "NHOM_NL_TEN") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Nhóm năng lực", b_value, "dg_dm_nhom_nl,ma,ten", dgnl_tl_nl_cho_cdanh_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
            if (b_cot == "NANGLUC_TEN") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Năng lực", b_value, "dg_dm_nl,ma,ten", dgnl_tl_nl_cho_cdanh_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        if (b_value != "") GridX_ThemHang(b_grctId);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
var dgnl_tl_nl_cho_cdanh2_choAct = 0;
function dgnl_tl_nl_cho_cdanh2_GR_lke_RowChange() {
    if (dgnl_tl_nl_cho_cdanh2_choAct != 0) clearTimeout(dgnl_tl_nl_cho_cdanh_choAct);
    dgnl_tl_nl_cho_cdanh2_choAct = setTimeout("dgnl_tl_nl_cho_cdanh2_P_CHUYEN_HANG()", 300);
    return false;
}
function dgnl_tl_nl_cho_cdanh2_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grctId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grctId, b_hang, "cdanh"));
        if (b_ma == "") form_P_MOI(b_vungId, "XGL"); else form_P_GridX_TEXT(b_vungId, b_grctId);
    }
    catch (err) { form_P_LOI(err); }
}
function dgnl_tl_nl_cho_cdanh_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(dgnl_tl_nl_cho_cdanh_lkeCho); dgnl_tl_nl_cho_cdanh_P_LKE(); }
}

function dgnl_tl_nl_cho_cdanh_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    $get(b_so_idId).value = "0";
    $get(b_gocId).value = "";
    return false;
}
function dgnl_tl_nl_cho_cdanh_P_LKE() {
    try {
        var b_so_the = $get(b_gocId).value,
            a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_DGNL_TL_NL_CHO_CDANH_LKE(a_tso, a_cot, dgnl_tl_nl_cho_cdanh_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function dgnl_tl_nl_cho_cdanh_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function dgnl_tl_nl_cho_cdanh_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_so_id = $get(b_so_idId).value, b_dt = form_Faa_TEXT_ROW(b_vungId),
                a_cot_ct = GridX_Fdt_cotGtri(b_grctId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
            sdg.Fs_DGNL_TL_NL_CHO_CDANH_NH(b_TrangKt, b_so_id, b_dt, a_cot_ct, a_cot_lke, dgnl_tl_nl_cho_cdanh_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function dgnl_tl_nl_cho_cdanh_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
    }
    return false;
}
function dgnl_tl_nl_cho_cdanh_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == null || b_so_id == "") { form_P_MOI("", "XGL"); GridX_datTrang(b_grctId); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        sdg.Fs_DGNL_TL_NL_CHO_CDANH_CT(b_so_id, a_cot_ct, dgnl_tl_nl_cho_cdanh_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function dgnl_tl_nl_cho_cdanh_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    $get(b_so_idId).value = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
}
function dgnl_tl_nl_cho_cdanh_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") dgnl_tl_nl_cho_cdanh_P_MOI();
    else {
        var b_so_the = $get(b_gocId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_DGNL_TL_NL_CHO_CDANH_XOA(b_so_id, a_tso, a_cot, dgnl_tl_nl_cho_cdanh_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function dgnl_tl_nl_cho_cdanh_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) dgnl_tl_nl_cho_cdanh_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); dgnl_tl_nl_cho_cdanh_P_CHUYEN_HANG(); }
    }
}
function dgnl_tl_nl_cho_cdanh_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function dgnl_tl_nl_cho_cdanh_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function dgnl_tl_nl_cho_cdanh_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function dgnl_tl_nl_cho_cdanh_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}

function form_dong() {
    location.reload(false);
}