var b_tmf, b_lkeCho, b_choAct = 0, b_vungId, b_td_chenId, b_grlkeId, b_slideId,
    b_grnvId, b_grnhomId, b_grdviId, b_gocId, b_klkId, b_dviId, b_phongId, b_loginId, b_moiId, b_tabId;
function ht_mansd_KD() {
    b_tmf = form_Fs_TM("f"); b_vungId = form_Fs_VUNG_ID('UPa_ct'); b_td_chenId = form_Fs_VUNG_ID('id_chen');
    b_grlkeId = form_Fs_VUNG_ID('GR_lke'); b_slideId = b_grlkeId + '_slide';
    b_grnvId = form_Fs_VUNG_ID('GR_nv'); b_grnhomId = form_Fs_VUNG_ID('GR_nhom'); b_grdviId = form_Fs_VUNG_ID('GR_dvi');
    b_phongId = form_Fs_TEN_ID(b_vungId, 'PHONG'); b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'); b_tabId = form_Fs_VTEN_ID('', 'NPa_dk');
    b_tenId = form_Fs_TEN_ID(b_vungId, 'TEN'); b_dviId = form_Fs_TEN_ID(b_vungId, 'dvi');
    b_klkId = form_Fs_VTEN_ID('', 'klk'); b_loginId = form_Fs_TEN_ID(b_vungId, 'MA_LOGIN'); b_moiId = form_Fs_VTEN_ID('', 'moi');
    b_lkeCho = setInterval('ht_mansd_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (C_NVL(b_dtuong) == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("FILE") >= 0) ht_mansd_P_FILE();
        else if (b_dtuong.indexOf("KLK") >= 0) ht_mansd_P_LKE('K');
    }
    catch (err) { form_P_LOI(err); }
}
function ht_mansd_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
            case "MA_LOGIN": b_maId = b_loginId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            $get(b_tenId).value = "";
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ht_mansd_P_MA_KTRA('K'); }
            else { GridX_datA(b_grlkeId, b_hang); $get(b_tenId).focus(); ht_mansd_P_CHUYEN_HANG(); }
        }
        else if (b_maTen == "MA_LOGIN") ht_mansd_P_TEST("K");
    }
    catch (err) { form_P_LOI(err); }
}
function ht_mansd_P_MA_KTRA(b_dk) {
    try {
        var b_klk = ($get(b_klkId).innerHTM=="Tất cả")?"T":"KT";
        var b_hangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId),
            b_ma = C_NVL($get(b_gocId).value), b_dvi = $get(b_dviId).value;
        sht_ma.Fs_MA_NSD_MA(b_dvi, b_klk, b_ma, b_dk, b_hangKt, a_cot, ht_mansd_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ht_mansd_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]), b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    slide_P_MOI(b_slideId, b_trang, b_soDong); GridX_datBang(b_grlkeId, a_kq[3]);
    if (b_hang < 1) ht_mansd_P_CT_MOI('X'); else { GridX_datA(b_grlkeId, b_hang, null, "K"); ht_mansd_P_CHUYEN_HANG(); }
    if (a_kq[4] != 'M') $get(b_loginId).focus(); else $get(b_moiId).focus();
}
function ht_mansd_P_TEST(b_dk) {
    try {
        var b_ma = C_NVL($get(b_gocId).value); b_ma_login = C_NVL($get(b_loginId).value);
        if (b_ma != "" && b_ma_login != "") {
            var b_dvi = C_NVL($get(b_dviId).value);
            sht_ma.Fs_MA_NSD_MA_LOGIN(b_dvi, b_ma, b_ma_login,b_dk, P_LOI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
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
        sht_ma.Fs_MA_DVI_NB(a_cot, ht_mansd_KQ_ChenDong, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ht_mansd_KQ_ChenDong(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        GridX_datBang(b_grdviId,b_kq);
        if (b_kq=='') alert('Không có đơn vị cấp dưới');
    }
}
function ht_mansd_Chon() {
    var b_ma = C_NVL($get(b_gocId).value);
    form_P_MO(b_tmf + '/ht/ht_mansd_lhnv.aspx', null, ["MA", [b_ma]])
    return false;
}
// Nhap
function ht_mansd_P_CT_MOI(b_dk) {
    form_P_MOI(b_vungId, b_dk); P_TAB($get(b_tabId));
    GridX_moi(b_grdviId); GridX_thayGtriT(b_grnhomId, "CHON", "");
    GridX_thayGtriT(b_grnvId, "ma,nhap,xem,han,qly", "K,K,K,K,K");
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
                a_dt_nh = GridX_Fdt_cotGtriH(b_grnhomId, 'CHON,NHOM'), a_dt_dvi = GridX_Fdt_cotGtriH(b_grdviId, 'DVI');
            a_cot.splice(0, 1);
            var a_dt_nv = GridX_Fdt_cotGtriH(b_grnvId, a_cot);
            sht_ma.Fs_MA_NSD_NH(a_dt_ct, a_dt_nv, a_dt_nh, a_dt_dvi, ht_mansd_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ht_mansd_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else ht_mansd_P_MA_KTRA('M');
}
function ht_mansd_P_XOA() {
    try {
        var b_ma = C_NVL(GridX_Fas_layGtriA(b_grlkeId, "ma"));
        if (b_ma == "") ht_mansd_P_MOI();
        else {
            var b_klk = ($get(b_klkId).innerHTM == "Tất cả") ? "T" : "KT";
            var b_dvi = $get(b_dviId).value,a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            sht_ma.Fs_MA_NSD_XOA(b_dvi, b_ma, b_klk, a_cot, a_tso, ht_mansd_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ht_mansd_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang == 1 && GridX_Fb_hangTrang(b_grlkeId, 2)) b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang) && b_hang > 1) b_hang--;
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ht_mansd_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang, null, "K"); ht_mansd_P_CHUYEN_HANG(); }
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
        if (b_ma == "") ht_mansd_P_CT_MOI('XGL');
        else {
            var b_dvi = $get(b_dviId).value, a_cot = GridX_Fas_tenCot(b_grnvId); a_cot.splice(0, 1);
            sht_ma.Fs_MA_NSD_CT(b_dvi, b_ma, a_cot, ht_mansd_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ht_mansd_P_CHUYEN_HANG_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
        else if (b_kq == '') ht_mansd_P_CT_MOI('XGL');
        else {
            var a_kq = Fas_ChMang(b_kq, '#'), a_cot = GridX_Fas_tenCot(b_grnvId), b_hangSo = GridX_Fi_timHangC(b_grnhomId)+1;
            form_P_CH_TEXT(b_vungId, a_kq[0]);
            a_cot.splice(0, 1); GridX_thayGtri(b_grnvId, 'MD,NV', 'ma,nhap,xem,han,qly', a_cot, a_kq[1]);
            GridX_thayGtriT(b_grnhomId, 'CHON', '');
            if (a_kq[2]!='') GridX_thayGtri(b_grnhomId, 'NHOM', 'CHON', 'CHON,NHOM', a_kq[2]);
            GridX_datBang(b_grdviId, a_kq[3]);
        }
    }
    catch (err) { form_P_LOI(err); }
}
// Liệt kê
function ht_mansd_P_LKE_CHO() {
    if (b_grlkeId != null && $get(b_grlkeId) != null && b_grnvId != null && $get(b_grnvId) != null && b_grnhomId != null && $get(b_grnhomId) != null)
    { clearTimeout(b_lkeCho); ht_mansd_P_TAO(); GridX_taoScroll(b_grlkeId); ht_mansd_P_LKE('C'); }
}
function ht_mansd_P_TAO() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grnvId);
        sht_ma.Fs_MA_NSD_TAO(a_cot, ht_mansd_P_TAO_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ht_mansd_P_TAO_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        a_kq = Fas_ChMang(b_kq, '#');
        GridX_datBang(b_grnvId, a_kq[0]); GridX_datBang(b_grnhomId, a_kq[1]);
    }
}
function ht_mansd_P_LKE(b_dk) {
    try {
        if (C_NVL(b_dk) == 'C') slide_P_MOI(b_slideId, 1, 1);
        var b_klk = ($get(b_klkId).innerHTM == "Tất cả") ? "T" : "KT";
        var b_dvi = $get(b_dviId).value,a_cot = GridX_Fas_tenCot(b_grlkeId),a_tso = slide_Faobj_TUDEN(b_slideId);
        sht_ma.Fs_MA_NSD_LKE(b_dvi, b_klk, b_dk, a_cot, a_tso, ht_mansd_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ht_mansd_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (a_kq[1] != "" && b_hang > 0) GridX_datA(b_grlkeId, b_hang, null, "K");
        if (a_kq.length > 2) drop_P_LKE(b_phongId, a_kq[2]);
    }
}
function ht_mansd_FILE() {
    var b_tm1 = form_Fs_TM("f");
    form_P_MO(b_tmf + '/khud/khud_Excel.aspx', window.name + ",FILE", null);
    return false;
}
function ht_mansd_P_FILE() {
    try { sht_ma.Fs_MA_NSD_FILE(ht_mansd_P_FILE_KQ, P_LOI_CSDL, P_LOI_TGIAN); }
    catch (err) { form_P_LOI(err); }
}
function ht_mansd_P_FILE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else ht_mansd_P_LKE('K');
}
