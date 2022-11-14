var b_tmf, b_lkeCho = 0, b_choAct = 0, b_vungId, b_vungtkId, b_td_chenId, b_grlkeId, b_slideId, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C',
    b_grnvId, b_grnhomId, b_grdviId, b_grbcId, b_gocId, b_klkId, b_dviId, b_phongId, b_loginId, b_moiId, b_tabId, b_slideIdct, b_slide_bcId,
    b_all_GhiId, b_all_XemId, b_all_XoaId, b_all_PdId, b_all_InId, b_all_MoPdId, b_all_DongId, b_all_XuatBCId, b_loai_slId, b_phanheId, b_tenformId, b_all_BcId,
    b_ma_tkId, b_ten_tkId;

function ht_mansd_KD(b_tm) {
    b_tmf = b_tm, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtkId = form_Fs_VUNG_ID('UPa_tk'), b_td_chenId = form_Fs_VUNG_ID('id_chen'),
    b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grnvId = form_Fs_VUNG_ID('GR_nv'), b_slideId = b_grlkeId + '_slide',
    b_slideIdct = $get(b_grnvId).getAttribute('slideId'),
    b_grnhomId = form_Fs_VUNG_ID('GR_nhom'), b_grdviId = form_Fs_VUNG_ID('GR_dvi'), b_grbcId = form_Fs_VUNG_ID('GR_bcao'),
    b_slide_bcId = $get(b_grbcId).getAttribute('slideId');
    b_ma_tkId = form_Fs_TEN_ID(b_vungtkId, 'ma_tk'), b_ten_tkId = form_Fs_TEN_ID(b_vungtkId, 'ten_tk');
    b_phongId = form_Fs_TEN_ID(b_vungId, 'PHONG'); b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'); b_tabId = form_Fs_VTEN_ID('', 'NPa_dk');
    b_tenId = form_Fs_TEN_ID(b_vungId, 'TEN'); b_dviId = form_Fs_TEN_ID(b_vungId, 'dvi');
    b_klkId = form_Fs_TEN_ID('', 'klk'); b_loginId = form_Fs_TEN_ID(b_vungId, 'MA_LOGIN'); b_moiId = form_Fs_VTEN_ID('', 'moi');
    b_loai_slId = form_Fs_TEN_ID(b_vungId, 'loai_sl'), b_phanheId = form_Fs_TEN_ID(b_vungId, 'phanhe'), b_tenformId = form_Fs_TEN_ID(b_vungId, 'ten_form');
    b_all_GhiId = form_Fs_VTEN_ID('UPa_hi', 'all_ghi'); b_all_XemId = form_Fs_VTEN_ID('UPa_hi', 'all_xem');
    b_all_XoaId = form_Fs_VTEN_ID('UPa_hi', 'all_xoa'); b_all_PdId = form_Fs_VTEN_ID('UPa_hi', 'all_pd');
    b_all_InId = form_Fs_VTEN_ID('UPa_hi', 'all_in'); b_all_MoPdId = form_Fs_VTEN_ID('UPa_hi', 'all_moPd');
    b_all_DongId = form_Fs_VTEN_ID('UPa_hi', 'all_dong'); b_all_XuatBCId = form_Fs_VTEN_ID('UPa_hi', 'all_xuatbc');
    b_all_BcId = form_Fs_VTEN_ID('UPa_hi', 'all_Bc');
    lke_P_DAT($get(b_phanheId), 'TATCA' + '{' + 'Tất cả');
    lke_P_DAT($get(b_loai_slId), 'TATCA' + '{' + 'Tất cả');
    lke_P_DAT($get(b_dviId), 'TATCA' + '{' + 'Tất cả');
    form_F_GOC().P_MENUBf(window.name, 'M');
    b_lkeCho = setInterval('ht_mansd_P_LKE_CHO()', 200); 
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (C_NVL(b_dtuong) == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("FILE") >= 0) ht_mansd_P_FILE();
        else if (b_dtuong.indexOf("KLK") >= 0) ht_mansd_P_LKE('K');
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}
function ht_mansd_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
            case "MA_LOGIN": b_maId = b_loginId; break;
            case "LOAI_SL": b_maId = b_loai_slId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            $get(b_tenId).value = "";
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ht_mansd_P_MA_KTRA('K'); }
            else { GridX_datA(b_grlkeId, b_hang); $get(b_tenId).focus(); ht_mansd_P_CHUYEN_HANG(); }
        } else if (b_maTen == "MA_LOGIN") { ht_mansd_P_TEST("K"); }
        else if (b_maTen == "LOAI_SL") {
            ht_mansd_bc_P_TAO();
        }
    }
    catch (ex) { form_P_LOI(ex.message); }
}

function ht_mansd_P_MA_KTRA(b_dk) {
    try {
        var b_klk = ($get(b_klkId).innerHTM == "Tất cả") ? "T" : "CC", b_ma = C_NVL($get(b_gocId).value);
        var b_hangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_dvi = lke_Fs_TRA($get(b_dviId));
        sht_ma.Fs_MA_NSD_MA(form_Fs_nsd(), b_dvi, b_klk, b_ma, b_dk, b_hangKt, a_cot, ht_mansd_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ht_mansd_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]), b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    slide_P_MOI(b_slideId, b_trang, b_soDong); GridX_datBang(b_grlkeId, a_kq[3]);
    if (b_hang < 1) ht_mansd_P_CT_MOI('X'); else { GridX_datA(b_grlkeId, b_hang); ht_mansd_P_CHUYEN_HANG(); }
    if (a_kq[4] != 'M') $get(b_loginId).focus(); else $get(b_moiId).focus();
}
function ht_mansd_P_TEST(b_dk) {
    try {
        var b_ma = C_NVL($get(b_gocId).value); b_ma_login = C_NVL($get(b_loginId).value);
        if (b_ma != "" && b_ma_login != "") {
            var b_dvi = C_NVL(lke_Fs_TRA($get(b_dviId)));
            sht_ma.Fs_MA_NSD_MA_LOGIN(form_Fs_nsd(), b_dvi, b_ma, b_ma_login, b_dk, P_LOI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ht_mansd_P_NPA(b_nv) {
    $get(b_td_chenId).style.display = (b_nv == "dvi") ? "" : "none";
}
function ht_mansd_CatDong() {
    GridX_boChon(b_grdviId);
    return false;
}
function ht_mansd_ChenDong() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grdviId);
        sht_ma.Fs_MA_DVI_NB(form_Fs_nsd(), a_cot, ht_mansd_KQ_ChenDong, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ht_mansd_KQ_ChenDong(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        GridX_datBang(b_grdviId, b_kq);
        if (b_kq == '') alert('Không có đơn vị cấp dưới');
    }
}
function ht_mansd_Chon() {
    var b_ma = C_NVL($get(b_gocId).value);
    form_P_MO(b_tmf + '/pcchs/pcchs_ccv.aspx', null, ["MA", [b_ma]])
    return false;
}
// Nhap
function ht_mansd_P_CT_MOI(b_dk) {
    form_P_MOI(b_vungId, b_dk); P_TAB($get(b_tabId));
    GridX_thoiA(b_grnvId); GridX_thoiA(b_grnhomId); GridX_moi(b_grdviId);
    GridX_thayGtriT(b_grnhomId, "CHON", "");
    GridX_thayGtriT(b_grnvId, "ghi,xem,xoa,pd,in,mo_cpd,active,export", "K,K,K,K,K,K,K,K");
    GridX_thayGtriT(b_grbcId, "CHON", "");
}
function ht_mansd_P_MOI() {
    ht_mansd_P_CT_MOI('GXL'); GridX_thoiA(b_grlkeId);
    $get(b_gocId).focus();
    return false;
}
function ht_mansd_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grnvId),
                a_dt_nh = GridX_Fdt_cotGtriH(b_grnhomId, 'CHON,NHOM'), a_dt_dvi = GridX_Fdt_cotGtriH(b_grdviId, 'dvi_chon,DVI'),
                a_dt_bc = GridX_Fdt_cotGtriH(b_grbcId, 'CHON,MA_BC,TEN,LOAI');
            var a_dt_nv = GridX_Fdt_cotGtri(b_grnvId);
            var b_all_ghi = $get(b_all_GhiId).value, b_all_xem = $get(b_all_XemId).value, b_all_Xoa = $get(b_all_XoaId).value, b_all_pd = $get(b_all_PdId).value,
                b_all_in = $get(b_all_InId).value, b_all_mpd = $get(b_all_MoPdId).value, b_all_dong = $get(b_all_DongId).value, b_all_xuatbc = $get(b_all_XuatBCId).value,
                b_all_bc = $get(b_all_BcId).value;
            sht_ma.Fs_MA_NSD_NH(form_Fs_nsd(), a_dt_ct, a_dt_nv, a_dt_nh, a_dt_dvi, a_dt_bc, ht_mansd_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}

function ht_mansd_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else { form_P_LOI("loi:Nhập thành công:loi"); ht_mansd_P_MA_KTRA('M'); }
}

function ht_mansd_P_XOA() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }

        var message = confirm("Bạn có chắc chắn xóa không?");
        if (message == false) { return false; }
        var b_ma = C_NVL(GridX_Fas_layGtriA(b_grlkeId, "ma"));
        if (b_ma == "") ht_mansd_P_MOI();
        else {
            var b_klk = ($get(b_klkId).innerHTM == "Tất cả") ? "T" : "CC", b_dvi = lke_Fs_TRA($get(b_dviId)),
                a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            var b_ma_tk = $get(b_ma_tkId).value, b_ten_tk = $get(b_ten_tkId).value;
            sht_ma.Fs_MA_NSD_XOA(form_Fs_nsd(), b_ma_tk, b_ten_tk, b_dvi, b_ma, b_klk, a_cot, a_tso, ht_mansd_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}

function ht_mansd_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI("loi:Xóa thành công:loi");
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang == 1 && GridX_Fb_hangTrang(b_grlkeId, 2)) b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang) && b_hang > 1) b_hang--;
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ht_mansd_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ht_mansd_P_CHUYEN_HANG(); }
    }
}

function ht_mansd_GR_lke_RowChange() {
    if (b_choAct != 0) clearTimeout(b_choAct);
    b_choAct = setTimeout("ht_mansd_P_CHUYEN_HANG()", 300);
    return false;
}

function ht_mansd_P_CHUYEN_HANG() {
    try {
        var b_ma = C_NVL(GridX_Fas_layGtriA(b_grlkeId, "ma"));
        var b_dvi = lke_Fs_TRA($get(b_dviId)), b_loai_sl = lke_Fs_TRA($get(b_loai_slId)), a_cot = GridX_Fas_tenCot(b_grnvId);
        a_cot_bc = GridX_Fas_tenCot(b_grbcId), b_phanhe = lke_Fs_TRA($get(b_phanheId)), b_tenform = $get(b_tenformId).value, a_tso = slide_Faobj_TUDEN(b_slideIdct);

        sht_ma.Fs_MA_NSD_CT(form_Fs_nsd(), b_dvi, b_ma, b_loai_sl, b_phanhe, b_tenform, a_cot, a_cot_bc, a_tso, ht_mansd_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);

    }
    catch (ex) { form_P_LOI(ex.message); }
}

function ht_mansd_P_CHUYEN_HANG_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
        else if (b_kq == '') ht_mansd_P_CT_MOI('XGL');
        else {
            var a_kq = Fas_ChMang(b_kq, '#'), a_cot = GridX_Fas_tenCot(b_grnvId), b_hangSo = GridX_Fi_timHangC(b_grnhomId) + 1;
            if (a_kq[0] != 0) { form_P_CH_TEXT(b_vungId, a_kq[1]); GridX_thoiA(b_grnvId); GridX_thoiA(b_grnhomId); }
            a_cot.splice(0, 1); GridX_thayGtri(b_grnvId, 'MD,NV', 'ghi,xem,xoa,pd,in,mo_cpd,active,export', a_cot, a_kq[2]);
            GridX_thayGtriT(b_grnhomId, 'CHON', '');
            if (a_kq[3] != '') GridX_thayGtri(b_grnhomId, 'NHOM', 'CHON', 'CHON,NHOM', a_kq[3]);
            GridX_datBang(b_grdviId, a_kq[4]);
            GridX_datBang(b_grnvId, a_kq[2]);
            GridX_datBang(b_grbcId, a_kq[6]);
            slide_P_SOTRANG(b_slideIdct, CSO_SO(a_kq[7], 0));
        }
    }
    catch (ex) { form_P_LOI(ex.message); }
}

// liệt kê báo cáo
function ht_mansd_bc_P_TAO() {
    try {
        var b_dvi = lke_Fs_TRA($get(b_dviId)), b_ma = C_NVL(GridX_Fas_layGtriA(b_grlkeId, "ma")), b_loai_sl = lke_Fs_TRA($get(b_loai_slId)),
            a_cot_bc = GridX_Fas_tenCot(b_grbcId);
        sht_ma.Fs_MA_NSD_BC(form_Fs_nsd(), b_dvi, b_ma, b_loai_sl, a_cot_bc, ht_mansd_bc_P_TAO_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ht_mansd_bc_P_TAO_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slide_bcId, CSO_SO(a_kq[1], 0));
        GridX_datBang(b_grbcId, a_kq[1]);
    }
}
// liệt kê nghiệp vụ
function ht_mansd_P_TAO(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grnvId), b_phanhe = lke_Fs_TRA($get(b_phanheId)), b_tenform = $get(b_tenformId).value,
        a_tso = slide_Faobj_TUDEN(b_slideIdct),
        b_ma = C_NVL(GridX_Fas_layGtriA(b_grlkeId, "ma"));
        sht_ma.Fs_MA_NSD_TAO(form_Fs_nsd(), b_ma, "NH", b_phanhe, b_tenform, a_cot, a_tso, ht_mansd_P_TAO_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ht_mansd_P_TAO_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideIdct, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grnvId, a_kq[1]); GridX_datBang(b_grnhomId, a_kq[2]);
    }
}
// Liệt kê 
function ht_mansd_P_LKE_CHO() {
    if (b_grlkeId != null && $get(b_grlkeId) != null && b_grnvId != null && $get(b_grnvId) != null && b_grnhomId != null && $get(b_grnhomId) != null) {
        if (b_lkeCho != 0) clearTimeout(b_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        b_slideIdct = $get(b_grnvId).getAttribute('slideId');
        ht_mansd_P_TAO('K'); ht_mansd_P_LKE('C'); ht_mansd_bc_P_TAO(); ht_mansd_ChenDong();
    }
}
function ht_mansd_P_LKE(b_dk) {
    try {
        if (C_NVL(b_dk) == 'C') slide_P_MOI(b_slideId, 1, 1);
        var b_klk = ($get(b_klkId).innerHTM == "Tất cả") ? "T" : "CC", b_dvi = lke_Fs_TRA($get(b_dviId)),
            a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_ma_tk = $get(b_ma_tkId).value, b_ten_tk = $get(b_ten_tkId).value;
        sht_ma.Fs_MA_NSD_LKE(form_Fs_nsd(), b_ma_tk, b_ten_tk, b_dvi, b_klk, b_dk, a_cot, a_tso, ht_mansd_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ht_mansd_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}

function ht_mansd_FILE() {
    form_P_MO(b_tmf + '/khud/khud_Excel.aspx', window.name + ",FILE", null);
    return false;
}
function ht_mansd_P_FILE() {
    try { sht_ma.Fs_MA_NSD_FILE(form_Fs_nsd(), ht_mansd_P_FILE_KQ, P_LOI_CSDL, P_LOI_TGIAN); }
    catch (ex) { form_P_LOI(ex.message); }
}
function ht_mansd_P_FILE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else ht_mansd_P_LKE('K');
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
function CheckAll_BC(oCheckbox) {
    var b_count = GridX_Fi_timHangT(b_grbcId);
    if (oCheckbox.checked == true) {
        $get(b_all_BcId).value = "ALL";
        for (i = 1; i < b_count; i++) {
            var b_ten_bc = C_NVL(GridX_Fas_layGtri(b_grbcId, i, "TEN"));
            if (b_ten_bc != "") GridX_datGtri(b_grbcId, i, ["CHON"], ['X'], 'K');
        }
    } else {
        $get(b_all_BcId).value = "";
        for (i = 1; i < b_count; i++) {
            GridX_datGtri(b_grbcId, i, ["CHON"], [''], 'K');
        }
    }
}
function form_dong() {
    location.reload(false);
}

//LinhNV note
//Quyền ghi: Nhập, sửa, import, Gửi phê duyệt, Gửi mail, Tổng hợp, Đính kèm file. (G : ghi)
//Quyền Xem: Xem dữ liệu, xuất excel, Xuất file mẫu, (X: Xem)
//Quyền Xóa: Xóa, Hủy đăng ký, hủy bản ghi.	(D : Delete)
//Quyền Phê duyệt: Phê duyệt, không phê duyệt, Xác nhận. (P : Phê duyệt)
//Quyền In: In biểu mẫu theo file word, tải mẫu in. (I : in)
//Quyền mở chờ phê duyệt: Mở chờ phê duyệt. (M : Mở chờ phê duyệt)
//Quyền đóng mở bảng công lương: Đóng bảng công, mở bảng công, đóng bảng lương, mở bảng lương, khóa vĩnh viễn bảng lương. (A : Active / inactive)
//Quyền xuất báo cáo: Xuất báo cáo, Xuất báo cáo động. (E : Export)