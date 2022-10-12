var b_lkeCho = 0, b_choAct = 0, b_vungId, b_vungtkId, b_grlkeId, b_grnvId, b_phanheId, b_tenformId, b_slideIdct, b_all_GhiId, b_all_XemId, b_all_XoaId, b_all_PdId,
    b_all_InId, b_all_MoPdId, b_all_DongId, b_all_XuatBCId, b_slideId, b_ma_tkId, b_ten_tkId;
function ht_manhom_KD() {
    b_vungId = form_Fs_VUNG_ID('UPa_ct'); b_vungtkId = form_Fs_VUNG_ID('UPa_tk'); b_grlkeId = form_Fs_VUNG_ID('GR_lke'); b_grnvId = form_Fs_VUNG_ID('GR_nv');
    b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'); b_phanheId = form_Fs_TEN_ID(b_vungId, 'phanhe'), b_tenformId = form_Fs_TEN_ID(b_vungId, 'ten_form');
    b_ma_tkId = form_Fs_TEN_ID(b_vungtkId, 'ma_tk'), b_ten_tkId = form_Fs_TEN_ID(b_vungtkId, 'ten_tk');
    b_all_GhiId = form_Fs_VTEN_ID('UPa_hi', 'all_ghi'); b_all_XemId = form_Fs_VTEN_ID('UPa_hi', 'all_xem');
    b_all_XoaId = form_Fs_VTEN_ID('UPa_hi', 'all_xoa'); b_all_PdId = form_Fs_VTEN_ID('UPa_hi', 'all_pd');
    b_all_InId = form_Fs_VTEN_ID('UPa_hi', 'all_in'); b_all_MoPdId = form_Fs_VTEN_ID('UPa_hi', 'all_moPd');
    b_all_DongId = form_Fs_VTEN_ID('UPa_hi', 'all_dong'); b_all_XuatBCId = form_Fs_VTEN_ID('UPa_hi', 'all_xuatbc');
    b_slideId = $get(b_grlkeId).getAttribute('slideId'),
    b_slideIdct = $get(b_grnvId).getAttribute('slideId'),
    //b_btn_xoaId = form_Fs_VUNG_ID('btn_xoa');
    lke_P_DAT($get(b_phanheId), 'TATCA' + '{' + 'Tất cả');
    b_lkeCho = setInterval('ht_manhom_P_LKE_CHO()', 200);
}
function ht_manhom_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        var b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
        if (b_maTen == "MA") {
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); form_P_MOI(b_vungId, "X"); }
            else { GridX_datA(b_grlkeId, b_hang); ht_manhom_P_CHUYEN_HANG(); }
        }
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ht_manhom_P_MOI() {
    ht_manhom_P_CT_MOI('GXL');
    GridX_thoiA(b_grlkeId); $get(b_gocId).focus();
    return false;
}
function ht_manhom_P_CT_MOI(b_dk) {
    form_P_MOI(b_vungId, b_dk);
    GridX_thoiA(b_grnvId);
    GridX_thayGtriT(b_grnvId, "ghi,xem,xoa,pd,in,mo_cpd,active,export", "K,K,K,K,K,K,K,K");
}
function ht_manhom_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grnvId);
            a_cot.splice(0, 1);
            var a_dt_nv = GridX_Fdt_cotGtriH(b_grnvId, a_cot), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var b_ma_tk = $get(b_ma_tkId).value, b_ten_tk = $get(b_ten_tkId).value;
            sht_ma.Fs_MA_NHOM_NH(form_Fs_nsd(), b_ma_tk, b_ten_tk, a_dt_ct, a_dt_nv, "NH", a_cot, b_TrangKt, ht_manhom_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ht_manhom_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        form_P_LOI("loi:Ghi thành công!:loi");
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
    }
    return false;
}
function ht_manhom_P_XOA() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }

        var message = confirm("Bạn có chắc chắn xóa không?");
        if (message == false) { return false; }
        var b_ma = C_NVL(GridX_Fas_layGtriA(b_grlkeId, "ma"));
        if (b_ma == "") ht_manhom_P_MOI();
        else sht_ma.Fs_MA_NHOM_XOA(form_Fs_nsd(), b_ma, ht_manhom_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ht_manhom_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        GridX_boChon(b_grlkeId);
        if (b_hang > 1 && GridX_Fb_hangTrang(b_grlkeId, b_hang)) b_hang--;
        GridX_datA(b_grlkeId, b_hang); ht_manhom_P_CHUYEN_HANG();
    }
}
function ht_manhom_GR_lke_RowChange() {
    if (b_choAct != 0) clearTimeout(b_choAct);
    b_choAct = setTimeout("ht_manhom_P_CHUYEN_HANG()", 300);
    return false;
}
function ht_manhom_P_CHUYEN_HANG() {
    var b_ma = C_NVL(GridX_Fas_layGtriA(b_grlkeId, "ma"));
    var a_cot = GridX_Fas_tenCot(b_grnvId);
    var b_phanhe = lke_Fs_TRA($get(b_phanheId)), b_tenform = $get(b_tenformId).value, a_tso = slide_Faobj_TUDEN(b_slideIdct);
    sht_ma.Fs_MA_NHOM_CT(form_Fs_nsd(), b_ma, b_phanhe, b_tenform, a_cot, a_tso, ht_manhom_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);

}
function ht_manhom_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else if (b_kq == "") form_P_MOI(b_vungId, "X");
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), a_cot = GridX_Fas_tenCot(b_grnvId); a_cot.splice(0, 1);
        if (a_kq[0] != 0) { form_P_CH_TEXT(b_vungId, a_kq[1]); }
        GridX_thayGtri(b_grnvId, 'MD,NV', 'ghi,xem,xoa,pd,in,mo_cpd,active,export', a_cot, a_kq[2]);
        GridX_datBang(b_grnvId, a_kq[2]); slide_P_SOTRANG(b_slideIdct, CSO_SO(a_kq[3], 0));
        ht_manhom_disable();
    }
}
function ht_manhom_P_LKE_CHO() {
    if (b_grlkeId != null && $get(b_grlkeId) != null && b_grnvId != null && $get(b_grnvId) != null) { clearTimeout(b_lkeCho); ht_manhom_P_LKE(); }
}
function ht_manhom_P_LKE() {
    try {
        var a_cot_nv = GridX_Fas_tenCot(b_grnvId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
        var b_phanhe = lke_Fs_TRA($get(b_phanheId)), b_tenform = $get(b_tenformId).value, a_tso = slide_Faobj_TUDEN(b_slideIdct);
        var b_ma_tk = $get(b_ma_tkId).value, b_ten_tk = $get(b_ten_tkId).value;
        sht_ma.Fs_MA_NHOM_LKE(form_Fs_nsd(), "NH", b_ma_tk, b_ten_tk, b_phanhe, b_tenform, a_cot_nv, a_cot_lke, a_tso, ht_manhom_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ht_manhom_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideIdct, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grnvId, a_kq[1]); GridX_datBang(b_grlkeId, a_kq[2]);
    }
}

function ht_manhom_disable() {
    var b_goc = $get(b_gocId).value;
    if (b_goc == "SND" || b_goc == "NVNGHIEPVU" || b_goc == "TPCC") {
        $get(b_gocId).setAttribute("disabled", "disabled");
        //$get(b_btn_xoaId).style.display = 'none';
    }
    else {
        $get(b_gocId).removeAttribute("disabled");;
        //$get(b_btn_xoaId).style.display = '';
    }
}

function CheckAll(oCheckbox, oTencot) {
    var b_count = GridX_Fi_timHangT(b_grnvId);
    if (oTencot == "GHI") $get(b_all_GhiId).value = "ALL"; else $get(b_all_GhiId).value = "";
    if (oTencot == "XEM") $get(b_all_XemId).value = "ALL"; else $get(b_all_XemId).value = "";
    if (oTencot == "XOA") $get(b_all_XoaId).value = "ALL"; else $get(b_all_XoaId).value = "";
    if (oTencot == "PD") $get(b_all_PdId).value = "ALL"; else $get(b_all_PdId).value = "";
    if (oTencot == "IN") $get(b_all_InId).value = "ALL"; else $get(b_all_InId).value = "";
    if (oTencot == "MO_CPD") $get(b_all_MoPdId).value = "ALL"; else $get(b_all_MoPdId).value = "";
    if (oTencot == "ACTIVE") $get(b_all_DongId).value = "ALL"; else $get(b_all_DongId).value = "";
    if (oTencot == "EXPORT") $get(b_all_XuatBCId).value = "ALL"; else $get(b_all_XuatBCId).value = "";
    var b_ten_nv = "";
    if (oCheckbox.checked == true) {
        for (i = 1; i < 31; i++) {
            b_ten_nv = C_NVL(GridX_Fas_layGtri(b_grnvId, i, "TEN"));
            if (b_ten_nv != "")
                GridX_datGtri(b_grnvId, i, [oTencot], 'C', 'K');
        }
    }
    else
        for (i = 1; i < 31; i++) {
            b_ten_nv = C_NVL(GridX_Fas_layGtri(b_grnvId, i, "TEN"));
            if (b_ten_nv != "") GridX_datGtri(b_grnvId, i, [oTencot], 'K', 'K');
        }
}
function form_dong() {
    location.reload(false);
}