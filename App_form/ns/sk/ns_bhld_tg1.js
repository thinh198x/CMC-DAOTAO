var ns_bhld_tg_lkeCho, b_vungId, b_grlkeId, b_slideId, b_grctId,
b_gchuId, b_so_idId, b_moiId, b_noteId;
function ns_bhld_tg_P_KD() {
    ns_bhld_tg_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
    b_namId = form_Fs_TEN_ID(b_vungId, 'NAM'), b_tenId = form_Fs_TEN_ID(b_vungId, 'ten'),
    b_ngaydId = form_Fs_TEN_ID(b_vungId, 'NGAYD'), b_ngaycId = form_Fs_TEN_ID(b_vungId, 'NGAYC'); b_noteId = form_Fs_TEN_ID(b_vungId, 'note');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_moiId = form_Fs_VTEN_ID('', 'moi');
    b_slideId = b_grlkeId + '_slide';
    ns_bhld_tg_lkeCho = setInterval('ns_bhld_tg_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grctId, b_hang, ["so_the"], [a_tso[0]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["ten"], [a_tso[1]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["phong"], [a_tso[2]], 'K');
            b_hang = GridX_Fi_timHangT(b_grctId);
            if (b_hang < 0) {
                GridX_ThemHang(b_grctId);
                b_hang = GridX_Fi_timHangT(b_grctId);
            }
            GridX_datA(b_grctId, b_hang, "tt");
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_bhld_tg_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "NAM": b_maId = b_namId; break;
            case "NOTE": b_maId = b_noteId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "NAM") {
            ns_bhld_tg_P_LKE();
        }
        else if (b_maTen == "NOTE") {
            var b_hang = GridX_Fi_timHangT(b_grctId);
            if (b_hang < 0) {
                GridX_ThemHang(b_grctId);
                b_hang = GridX_Fi_timHangT(b_grctId);
            }
            GridX_datA(b_grctId, b_hang, "tt");
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_bhld_tg_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}
function ns_bhld_tg_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grctId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        if (b_value != "") {
            if (b_cot == "SO_THE") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Mã cán bộ", b_value, "ns_cb,so_the,ten", tl_phanca_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
                //sns_tt.Fs_NS_CB_HOI(b_value, ns_bhld_tg_P_CB_HOI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        if (b_value != "") GridX_ThemHang(b_grctId);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_bhld_tg_P_CB_HOI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var b_hang = GridX_Fi_timHangA(b_grctId);
    var a_kq = Fas_ChMang(b_kq, '#');
    GridX_datGtri(b_grctId, b_hang, ["so_the"], [a_kq[0]], 'K');
    GridX_datGtri(b_grctId, b_hang, ["phong"], [a_kq[1]], 'K');
    GridX_datGtri(b_grctId, b_hang, ["ten"], [a_kq[2]], 'K');
    b_hang = GridX_Fi_timHangT(b_grctId);
    if (b_hang < 0) {
        GridX_ThemHang(b_grctId);
        b_hang = GridX_Fi_timHangT(b_grctId);
    }
    GridX_datA(b_grctId, b_hang, "tt");
}

var ns_bhld_tg_choAct = 0;
function ns_bhld_tg_GR_lke_RowChange() {
    if (ns_bhld_tg_choAct != 0) clearTimeout(ns_bhld_tg_choAct);
    ns_bhld_tg_choAct = setTimeout("ns_bhld_tg_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_bhld_tg_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_bhld_tg_lkeCho); ns_bhld_tg_P_LKE(); }
}

function ns_bhld_tg_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    $get(b_so_idId).value = "0";
    $get(b_namId).focus();
    return false;
}
// lke
function ns_bhld_tg_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), b_nam = $get(b_namId).value, a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_sk.Fs_NS_BHLD_TG_LKE(b_nam, a_tso, a_cot, ns_bhld_tg_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_bhld_tg_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang(b_grlkeId, b_kq);
}
//Nhap
function ns_bhld_tg_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_so_id = $get(b_so_idId).value, b_dt = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fdt_cotGtri(b_grctId);
            sns_sk.Fs_NS_BHLD_TG_NH(b_so_id, b_dt, a_cot, ns_bhld_tg_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_bhld_tg_P_NH_KQ(b_kq) {
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
function ns_bhld_tg_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")),
        a_cot = GridX_Fas_tenCot(b_grctId);
    if (b_so_id == "0") form_P_MOI(b_vungId, "XGL");
    else sns_sk.Fs_NS_BHLD_TG_CT(b_so_id, a_cot, ns_bhld_tg_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = b_so_id;
}
function ns_bhld_tg_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId);
    else GridX_datBang(b_grctId, a_kq[1]);
}
function ns_bhld_tg_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }

    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") ns_bhld_tg_P_MOI();
    else {
        sns_sk.Fs_NS_BHLD_TG_XOA(b_so_id, ns_bhld_tg_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_bhld_tg_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        GridX_boChon(b_grlkeId, 'C');
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_bhld_tg_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_bhld_tg_P_CHUYEN_HANG(); }
    }
}
function ns_bhld_tg_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_bhld_tg_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_bhld_tg_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function ns_bhld_tg_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}
function form_dong() {
    location.reload(false);
}