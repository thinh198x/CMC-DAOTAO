
var dgnl_ngv_nl_nv_lkeCho, b_vungId, b_grlkeId, b_grctId,  b_mt, b_gchuId,b_ncdId, b_doi = 0;
function dgnl_ngv_nl_nv_P_KD() {
    dgnl_ngv_nl_nv_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'); b_slideId = b_grlkeId + '_slide', b_ncdId = form_Fs_TEN_ID(b_vungId, 'hincd');
    b_dot_dgia = form_Fs_TEN_ID(b_vungId, 'DOT_DGIA');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    dgnl_ngv_nl_nv_lkeCho = setInterval('dgnl_ngv_nl_nv_P_LKE_CHO()', 200);
    b_nam = form_Fs_TEN_ID(b_vungId, 'NAM');
}

var b_cho_control = 0;
function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_so_idId).value = b_so_the;
            $get(b_gchuId).innerHTML = b_ten;
            $get(b_so_idId).focus();
            dgnl_ngv_nl_nv_P_LKE();
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
        if (b_dtuong.indexOf("DOT") >= 0) {
            $get(b_dot_dgia).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_nam).value = a_tso[2];
            $get(b_dot_dgia).focus();
        }
        else if (b_dtuong.indexOf("SO_THE") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grctId, b_hang, ["so_the"], [a_tso[0]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["ten"], [a_tso[1]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["phong"], [a_tso[2]], 'K');
        } else if (b_dtuong.indexOf("NHOM_NL_TEN") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grctId, b_hang, ["nhom_nl"], [a_tso[0]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["nhom_nl_ten"], [a_tso[1]], 'K');
            $get(b_gchuId).innerHTML = a_tso[0];
            $get(b_ncdId).value = b_kq;
        }
        else if (b_dtuong.indexOf("NANGLUC_TEN") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grctId, b_hang, ["nangluc"], [a_tso[0]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["nangluc_ten"], [a_tso[1]], 'K');
            $get(b_gchuId).innerHTML = a_tso[0];
        } 
    }
    catch (err) { form_P_LOI(err); }
}
function dgnl_ngv_nl_nv_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_so_idId; form_P_MOI("", "XGL"); GridX_datTrang(b_grctId); break;
            case "DOT": b_maId = b_dot_dgia; break;
        }
        var b_ma = $get(b_maId);
        b_mt = b_maTen;
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "DOT") {
            skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), dgnl_ngv_nl_nv_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            b_hang = GridX_Fi_timHangD(b_grlkeId, "dot_dgia", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); dgnl_ngv_nl_nv_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); dgnl_ngv_nl_nv_P_CHUYEN_HANG(); }
        }
    }
    catch (err) { form_P_LOI(err); }
}

function dgnl_ngv_nl_nv_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grctId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        if (b_value != "") {
            if (b_cot == "SO_THE") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Mã cán bộ", b_value, "ns_cb,so_the,ten", dgnl_ngv_nl_nv_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
                b_ctr.value = ""
            }
            else if (b_cot == "NHOM_NL_TEN") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Nhóm năng lực", b_value, "dg_dm_nhom_nl,ma,ten", dgnl_ngv_nl_nv_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
                b_ctr.value = ""
            }
            else if (b_cot == "NANGLUC_TEN") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Năng lực", b_value, "dg_dm_nl,ma,ten", dgnl_ngv_nl_nv_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
                b_ctr.value = ""
            }
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function dgnl_ngv_nl_nv_P_MA_KTRA() {
    try {
        //var b_ngay = C_NVL($get(b_ngayId).value);
        //if (b_ngay != "") {
        //    var b_so_the = $get(b_so_idId).value;
        //    var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
        //    sdg.Fs_DGNL_NGV_NL_NV_MA(b_so_the, b_ngay, b_TrangKt, a_cot, dgnl_ngv_nl_nv_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        //}
    }
    catch (err) { form_P_LOI(err); }
}
function dgnl_ngv_nl_nv_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        form_P_MOI(b_vungId, "X"); GridX_datTrang(b_grctId);
        $get(b_so_idId).focus(); $get(b_so_idId).value = "0";
    }
    else { GridX_datA(b_grlkeId, b_hang); dgnl_ngv_nl_nv_P_CHUYEN_HANG(); }
}
function dgnl_ngv_nl_nv_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}

var dgnl_ngv_nl_nv_choAct = 0;
function dgnl_ngv_nl_nv_GR_lke_RowChange() {
    if (dgnl_ngv_nl_nv_choAct != 0) clearTimeout(dgnl_ngv_nl_nv_choAct);
    dgnl_ngv_nl_nv_choAct = setTimeout("dgnl_ngv_nl_nv_P_CHUYEN_HANG()", 300);
    return false;
}

var dgnl_ngv_nl_nv2_choAct = 0;
function dgnl_ngv_nl_nv2_GR_lke_RowChange() {
    if (dgnl_ngv_nl_nv2_choAct != 0) clearTimeout(dgnl_ngv_nl_nv_choAct);
    dgnl_ngv_nl_nv2_choAct = setTimeout("dgnl_ngv_nl_nv2_P_CHUYEN_HANG()", 300);
    return false;
}
function dgnl_ngv_nl_nv2_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grctId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grctId, b_hang, "nam"));
        if (b_ma == "") form_P_MOI(b_vungId, "XGL"); else form_P_GridX_TEXT(b_vungId, b_grctId);
    }
    catch (err) { form_P_LOI(err); }
}
function dgnl_ngv_nl_nv_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(dgnl_ngv_nl_nv_lkeCho); dgnl_ngv_nl_nv_P_LKE(); }
}

function dgnl_ngv_nl_nv_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    $get(b_so_idId).value = "0";
    $get(b_so_idId).focus();
    return false;
}
function dgnl_ngv_nl_nv_P_LKE() {
    try {
        var b_so_the = $get(b_so_idId).value,
            a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_DGNL_NGV_NL_NV_LKE(a_tso, a_cot, dgnl_ngv_nl_nv_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function dgnl_ngv_nl_nv_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function dgnl_ngv_nl_nv_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_dt = form_Faa_TEXT_ROW(b_vungId),
               b_so_id = $get(b_so_idId).value, b_dt_ct = GridX_Fdt_cotGtri(b_grctId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            sdg.Fs_DGNL_NGV_NL_NV_NH(b_TrangKt, b_so_id, b_dt, b_dt_ct, a_cot_lke, dgnl_ngv_nl_nv_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function dgnl_ngv_nl_nv_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_so_idId).focus();
    }
    return false;
}
function dgnl_ngv_nl_nv_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == null || b_so_id == "") { form_P_MOI("", "XGL"); GridX_datTrang(b_grctId); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        sdg.Fs_DGNL_NGV_NL_NV_CT(b_so_id, a_cot_ct, dgnl_ngv_nl_nv_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function dgnl_ngv_nl_nv_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    $get(b_so_idId).value = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
}
function dgnl_ngv_nl_nv_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") dgnl_ngv_nl_nv_P_MOI();
    else {
        var b_so_the = $get(b_so_idId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_DGNL_NGV_NL_NV_XOA(b_so_id, a_tso, a_cot, dgnl_ngv_nl_nv_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function dgnl_ngv_nl_nv_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) dgnl_ngv_nl_nv_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); dgnl_ngv_nl_nv_P_CHUYEN_HANG(); }
    }
}
function dgnl_ngv_nl_nv_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function dgnl_ngv_nl_nv_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function dgnl_ngv_nl_nv_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function dgnl_ngv_nl_nv_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}

function form_dong() {
    location.reload(false);
}