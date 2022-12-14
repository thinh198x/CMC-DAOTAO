var ns_dt_kbd_lkeCho, b_vungId, b_grlkeId, b_slideId, b_grctId,b_gchuId,b_so_idId,b_moiId,b_noteId;
function ns_dt_kbd_P_KD() {
    ns_dt_kbd_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
    b_noidtId = form_Fs_TEN_ID(b_vungId, 'noidt'), b_namId = form_Fs_TEN_ID(b_vungId, 'NAM'), b_tenId = form_Fs_TEN_ID(b_vungId, 'TEN'),
    b_quocgiaId = form_Fs_TEN_ID(b_vungId, 'quocgia'), b_ngaydId = form_Fs_TEN_ID(b_vungId, 'NGAYD'),
    b_ngaycId = form_Fs_TEN_ID(b_vungId, 'NGAYC'), b_hinhthucId = form_Fs_TEN_ID(b_vungId, 'hinhthuc'),
    b_kinhphiId = form_Fs_TEN_ID(b_vungId, 'kinhphi'), b_giatriId = form_Fs_TEN_ID(b_vungId, 'giatri'), b_ma_nteId = form_Fs_TEN_ID(b_vungId, 'ma_nte');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_noteId = form_Fs_TEN_ID(b_vungId, 'note');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_moiId = form_Fs_VTEN_ID('', 'moi');
    b_slideId = b_grlkeId + '_slide';
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("QUOCGIA") >= 0) {
            $get(b_quocgiaId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_ngaydId).focus();
        }
        else if (b_dtuong.indexOf("HINHTHUC") >= 0) {
            $get(b_hinhthucId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_kinhphiId).focus();
        }
        else if (b_dtuong.indexOf("KINHPHI") >= 0) {
            $get(b_kinhphiId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_giatriId).focus();
        }
        else if (b_dtuong.indexOf("SO_THE") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grctId, b_hang, ["so_the"], [a_tso[0]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["ten"], [a_tso[1]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["phong"], [a_tso[2]], 'K');
            GridX_datA(b_grctId, b_hang, "kq");
        }
        else if (b_dtuong.indexOf("MA_NTE") >= 0) {
            $get(b_ma_nteId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_ma_nteId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_dt_kbd_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "NAM": b_maId = b_namId; form_P_MOI("", "XGL"); break;
            case "QUOCGIA": b_maId = b_quocgiaId; break;
            case "HINHTHUC": b_maId = b_hinhthucId; break;
            case "NOTE": b_maId = b_noteId; break;
            case "MA_NTE": b_maId = b_ma_nteId; break;
            case "KINHPHI": b_maId = b_kinhphiId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "NAM") {
            ns_dt_kbd_P_LKE();
        }
        else if (b_maTen == "NOTE") {
            var b_hang = GridX_Fi_timHangT(b_grctId);
            if (b_hang < 0) {
                GridX_ThemHang(b_grctId);
                b_hang = GridX_Fi_timHangT(b_grctId);
            }
            GridX_datA(b_grctId, b_hang, "tt");
        }
        else skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_dt_kbd_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_kbd_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}
function ns_dt_kbd_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grctId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        if (b_value != "") {
            if (b_cot == "SO_THE") {
                sns_tt.Fs_NS_CB_HOI(b_value, ns_dt_kbd_P_CB_HOI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        if (b_value != "") GridX_ThemHang(b_grctId);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_dt_kbd_P_CB_HOI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var b_hang = GridX_Fi_timHangA(b_grctId);
    var a_kq = Fas_ChMang(b_kq, '#');
    GridX_datGtri(b_grctId, b_hang, ["so_the"], [a_kq[0]], 'K');
    GridX_datGtri(b_grctId, b_hang, ["phong"], [a_kq[1]], 'K');
    GridX_datGtri(b_grctId, b_hang, ["ten"], [a_kq[2]], 'K');
}

var ns_dt_kbd_choAct = 0;
function ns_dt_kbd_GR_lke_RowChange() {
    if (ns_dt_kbd_choAct != 0) clearTimeout(ns_dt_kbd_choAct);
    ns_dt_kbd_choAct = setTimeout("ns_dt_kbd_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_dt_kbd_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_dt_kbd_lkeCho); ns_dt_kbd_P_LKE(); }
}

function ns_dt_kbd_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    $get(b_so_idId).value = "0";
    $get(b_namId).focus();
    return false;
}
// lke
function ns_dt_kbd_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), b_nam = $get(b_namId).value;
        sns_dt.Fs_NS_DT_KBD_LKE(b_nam, a_cot, ns_dt_kbd_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_kbd_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang(b_grlkeId, b_kq);
}
//Nhap
function ns_dt_kbd_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_so_id = $get(b_so_idId).value, b_dt = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fdt_cotGtri(b_grctId);
            sns_dt.Fs_NS_DT_KBD_NH(b_so_id, b_dt, a_cot, ns_dt_kbd_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_kbd_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        $get(b_so_idId).value = b_kq;
        var b_hang = GridX_Fi_timHangT(b_grlkeId);
        if (b_hang < 0) {
            GridX_ThemHang(b_grlkeId);
            b_hang = GridX_Fi_timHangT(b_grlkeId);
        }
        var b_ten = $get(b_tenId).value,
            b_ngayd = $get(b_ngaydId).value,
            b_ngayc = $get(b_ngaycId).value;
        GridX_datGtri(b_grlkeId, b_hang, ["so_id", "ten", "ngayd", "ngayc"], [b_kq, b_ten, b_ngayd, b_ngayc]);
        GridX_datA(b_grlkeId, b_hang);
        $get(b_namId).focus();
    }
    return false;
}
function ns_dt_kbd_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")),
        a_cot = GridX_Fas_tenCot(b_grctId);
    if (b_so_id == "0") form_P_MOI(b_vungId, "XGL");
    else sns_dt.Fs_NS_DT_KBD_CT(b_so_id, a_cot, ns_dt_kbd_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = b_so_id;
}
function ns_dt_kbd_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId);
    else GridX_datBang(b_grctId, a_kq[1]);
}
function ns_dt_kbd_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") ns_dt_kbd_P_MOI();
    else {
        sns_td.Fs_ns_dt_kbd_XOA(b_so_id, ns_dt_kbd_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_dt_kbd_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        GridX_boChon(b_grlkeId, 'C');
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dt_kbd_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dt_kbd_P_CHUYEN_HANG(); }
    }
    return false;
}
function ns_dt_kbd_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_dt_kbd_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_dt_kbd_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function ns_dt_kbd_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}