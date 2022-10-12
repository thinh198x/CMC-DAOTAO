var tl_ktru_thue_lkeCho,tl_ktru_thue_lkecbCho, b_vungId,b_grlkeId, b_grctId, b_mt;
function tl_ktru_thue_P_KD() {
    tl_ktru_thue_lkeCho, tl_ktru_thue_lkecbCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct');
    b_thangId = form_Fs_TEN_ID(b_vungId, 'THANG'), b_phongId = form_Fs_TEN_ID(b_vungId, 'PHONG'), b_so_idId = form_Fs_TEN_ID(form_Fs_VUNG_ID('UPa_hidden'), 'so_id');
    b_slideId = b_grlkeId + '_slide';
    tl_ktru_thue_lkeCho = setInterval('tl_ktru_thue_P_LKE_CHO()', 200);
    tl_ktru_thue_lkecbCho = setInterval('tl_ktru_thue_P_LKE_CB_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        if (b_dtuong.indexOf("DAYPHONG") >= 0) {
            $get(b_phongId).value = a_tso[0];
            tl_ktru_thue_P_MOI();
            tl_ktru_thue_P_LKE();
            tl_ktru_thue_P_LKE_CB();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function tl_ktru_thue_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "PHONG": b_maId = b_phongId; break;
            case "THANG": b_maId = b_thangId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null) return;
        if (b_maTen == "PHONG") {
            tl_ktru_thue_P_MOI();
            tl_ktru_thue_P_LKE();
            tl_ktru_thue_P_LKE_CB();
        }
        if (b_maTen == "THANG") {
            var b_thang = $get(b_thangId).value;
            if (b_thang != "") {
                var b_hang = GridX_Fi_timHangD(b_grlkeId, "thang", b_thang);
                if (b_hang > -1) {
                    GridX_datA(b_grlkeId, b_hang);
                    tl_ktru_thue_P_CHUYEN_HANG();
                }
                else {
                    tl_ktru_thue_P_LKE_CB();
                    GridX_thoiA(b_grlkeId);
                }
            }
            else $get(b_thangId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function tl_ktru_thue_P_LKE_CB() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grctId),b_phong = $get(b_phongId).value;
        stl_ch.Fs_TL_KTRU_THUE_LKE_CB(b_phong, a_cot, tl_ktru_thue_P_LKE_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function tl_ktru_thue_P_LKE_CB_KQ(b_kq) {
    if (b_kq == "") GridX_datTrang(b_grctId);
    else {
        GridX_datBang(b_grctId, b_kq);
    }
}
var tl_ktru_thue_choAct = 0;
function tl_ktru_thue_GR_lke_RowChange() {
    if (tl_ktru_thue_choAct != 0) clearTimeout(tl_ktru_thue_choAct);
    tl_ktru_thue_choAct = setTimeout("tl_ktru_thue_P_CHUYEN_HANG()", 300);
    return false;
}
function tl_ktru_thue_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(tl_ktru_thue_lkeCho); tl_ktru_thue_P_LKE(); }
}
function tl_ktru_thue_P_LKE_CB_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(tl_ktru_thue_lkecbCho); tl_ktru_thue_P_LKE_CB(); }
}
function tl_ktru_thue_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    tl_ktru_thue_P_LKE_CB();
    $get(b_so_idId).value = "0";
}
function tl_ktru_thue_P_LKE() {
    try {
        var b_phong = $get(b_phongId).value,a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_ch.Fs_TL_KTRU_THUE_LKE(b_phong,a_tso, a_cot, tl_ktru_thue_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function tl_ktru_thue_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}

function tl_ktru_thue_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_so_id = $get(b_so_idId).value, b_dt = form_Faa_TEXT_ROW(b_vungId),
                a_cot_ct = GridX_Fdt_cotGtri(b_grctId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
            stl_ch.Fs_TL_KTRU_THUE_NH(b_so_id, b_TrangKt, b_dt, a_cot_ct, a_cot_lke, tl_ktru_thue_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function tl_ktru_thue_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_thangId).focus();
    }
    return false;
}
function tl_ktru_thue_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == null || b_so_id == "") { form_P_MOI("", "XGL"); tl_ktru_thue_P_LKE_CB(); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        stl_ch.Fs_TL_KTRU_THUE_CT(b_so_id, a_cot_ct, tl_ktru_thue_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function tl_ktru_thue_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    $get(b_so_idId).value = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
}
function tl_ktru_thue_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") tl_ktru_thue_P_MOI();
    else {
        var b_phong = $get(b_phongId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_ch.Fs_TL_KTRU_THUE_XOA(b_so_id, b_phong, a_tso, a_cot, tl_ktru_thue_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function tl_ktru_thue_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) tl_ktru_thue_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); tl_ktru_thue_P_CHUYEN_HANG(); }
    }
}

function tl_ktru_thue_P_TINH() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grctId),
            b_phong = $get(b_phongId).value,
            b_thang = $get(b_thangId).value;
        stl_ch.Fs_TL_BLUONG_TINH(b_phong, b_thang, a_cot, tl_ktru_thue_P_TINH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function tl_ktru_thue_P_TINH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == "") GridX_datTrang(b_grctId);
    else GridX_datBang(b_grctId, b_kq);
    return false;
}
function tl_ktru_thue_HangLen() {
    GridX_chuyenHang(b_grdsId, -1);
    return false;
}
function tl_ktru_thue_HangXuong() {
    GridX_chuyenHang(b_grdsId, 1);
    return false;
}
function tl_ktru_thue_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grdsId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grdsId);
    return false;
}
function tl_ktru_thue_CatDong() {
    GridX_boChon(b_grdsId, 'C');
    return false;
}

function tl_ktru_thue_P_IN() {
    var a_cot = GridX_Fdt_cotGtri(b_grctId);
    var b_ma_bc = 'ns_ktru_thue.xml',
        b_ddan = '~/Templates/ns/', a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
    var b_kieu_in = 'E', b_ten_rp = b_ma_bc;
    var a_dt = GridX_Fdt_cotGtri(b_grctId);
    if (b_ten_rp == "") { form_P_LOI('Chưa chọn đúng báo cáo'); return; }
    sti_ch.Fs_EXCEL_TIENLUONG("ns_ngbc", "TT", b_ma_bc, b_ddan, b_ten_rp, b_kieu_in, a_dt_ct, a_dt, P_EXCEL_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function P_EXCEL_KQ(b_kq) {
    //?md=TT
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_MO(form_Fs_TM() + '/App_form/bc/xexcel.aspx?md=TT', null, null, "C");
}
function tl_ktru_thue_phong() {
    try {
        var b_tenf = form_Fs_TM() + '/App_form/ht/ht_maph.aspx';
        form_P_MO(b_tenf, null, ["tl_ktru_thue", [""]]);
        return false;
    }
    catch (err) { }
}