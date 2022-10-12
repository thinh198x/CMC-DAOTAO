var b_choAct = 0, b_lkeCho, b_vungId, b_grlkeId, b_slideId, b_grnnnghiepId, b_grcdanhId, b_grlevelId, b_grlhdId,
b_gchuId, b_so_idId, b_moiId, b_noteId, b_bh_cmc_care, b_thamnienId;
function ns_tlap_dk_cmccare_P_KD() {
    b_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grnnnghiepId = form_Fs_VUNG_ID('GR_nnnghiep'),
    b_grcdanhId = form_Fs_VUNG_ID('GR_cdanh'), b_grlevelId = form_Fs_VUNG_ID('GR_level'), b_grlhdId = form_Fs_VUNG_ID('GR_lhd'),
    b_bh_cmc_care = form_Fs_TEN_ID(b_vungId, 'BH_CMC_CARE'), b_ngaydId = form_Fs_TEN_ID(b_vungId, 'NGAYD'), b_ngaycId = form_Fs_TEN_ID(b_vungId, 'NGAYC');
    b_thamnienId = form_Fs_TEN_ID(b_vungId, 'thamnien'), b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'), b_gchuId = form_Fs_VTEN_ID('', 'gchu'),
    b_moiId = form_Fs_VTEN_ID('', 'moi'), b_slideId = b_grlkeId + '_slide';
    b_lkeCho = setInterval('ns_tlap_dk_cmccare_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("MA_NNNGHIEP") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grnnnghiepId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grnnnghiepId, b_hang, ["ma_nnnghiep"], [a_tso[0]], 'K');
            GridX_datGtri(b_grnnnghiepId, b_hang, ["ten_nnnghiep"], [a_tso[1]], 'K');
        }
        else if (b_dtuong.indexOf("MA_CD") >= 0) {
            ns_tlap_dk_cmccare_P_LAY();
            //var b_hang = GridX_Fi_timHangA(b_grcdanhId);
            //if (b_hang < 0) return;
            //GridX_datGtri(b_grcdanhId, b_hang, ["ma_cdanh"], [a_tso[0]], 'K');
            //GridX_datGtri(b_grcdanhId, b_hang, ["ten_cdanh"], [a_tso[1]], 'K');
        }
        else if (b_dtuong.indexOf("MA_LEVEL") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grlevelId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grlevelId, b_hang, ["ma_level_cdanh"], [a_tso[0]], 'K');
            GridX_datGtri(b_grlevelId, b_hang, ["ten_level_cdanh"], [a_tso[1]], 'K');
        }
        else if (b_dtuong.indexOf("MA_LHD") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grlhdId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grlhdId, b_hang, ["ma_lhd"], [a_tso[0]], 'K');
            GridX_datGtri(b_grlhdId, b_hang, ["ten_lhd"], [a_tso[1]], 'K');
        }
        else if (b_dtuong.indexOf("BH_CMC_CARE") >= 0) {
            $get(b_bh_cmc_care).value = b_kq;
            $get(b_gchuId).value = a_tso[0];
            $get(b_bh_cmc_care).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tlap_dk_cmccare_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "NAM": b_maId = b_namId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "NAM") {
            ns_tlap_dk_cmccare_P_LKE();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tlap_dk_cmccare_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}
function ns_tlap_dk_cmccare_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_datTrang(b_grnnnghiepId);
    GridX_datTrang(b_grcdanhId);
    GridX_datTrang(b_grlevelId);
    GridX_datTrang(b_grlhdId);
    $get(b_so_idId).value = "0";
    $get(b_bh_cmc_care).focus();
    return false;
}
function ns_tlap_dk_cmccare_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_so_id = $get(b_so_idId).value, b_dt = form_Faa_TEXT_ROW(b_vungId), a_nnnghiep = GridX_Fdt_cotGtri(b_grnnnghiepId),
                a_cdanh = GridX_Fdt_cotGtri(b_grcdanhId), a_level = GridX_Fdt_cotGtri(b_grlevelId), a_loadhd = GridX_Fdt_cotGtri(b_grlhdId);
            sns_ma_ch.Fs_NS_TLAP_DK_CMCCARE_NH(form_Fs_nsd(), b_so_id, b_dt, a_nnnghiep, a_cdanh, a_level, a_loadhd, ns_tlap_dk_cmccare_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tlap_dk_cmccare_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        $get(b_so_idId).value = b_kq;
        var b_hang = GridX_Fi_timHangT(b_grlkeId);
        if (b_hang < 0) {
            GridX_ThemHang(b_grlkeId);
            b_hang = GridX_Fi_timHangT(b_grlkeId);
        }
        ns_tlap_dk_cmccare_P_LKE();
        form_P_LOI("loi:Ghi thành công:loi");
    }
    return false;
}
function ns_tlap_dk_cmccare_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId), b_ma = $get(b_bh_cmc_care).value;
    if (b_so_id == "0" || b_so_id == "") ns_tlap_dk_cmccare_P_MOI();
    else {
        sns_ma_ch.Fs_NS_TLAP_DK_CMCCARE_XOA(form_Fs_nsd(), b_so_id, b_ma, a_tso, a_cot, ns_tlap_dk_cmccare_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_tlap_dk_cmccare_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_tlap_dk_cmccare_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_tlap_dk_cmccare_P_CHUYEN_HANG(); }
        form_P_LOI('loi:Xóa thành công!:loi');
    }
}
function ns_tlap_dk_cmccare_GR_lke_RowChange() {
    if (b_choAct != 0) clearTimeout(b_choAct);
    b_choAct = setTimeout("ns_tlap_dk_cmccare_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_tlap_dk_cmccare_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")),
    a_nnnghiep = GridX_Fas_tenCot(b_grnnnghiepId), a_cdanh = GridX_Fas_tenCot(b_grcdanhId), a_level = GridX_Fas_tenCot(b_grlevelId), a_loadhd = GridX_Fas_tenCot(b_grlhdId);
    if (b_so_id == "0" || b_so_id == "") ns_tlap_dk_cmccare_P_MOI();
    else sns_ma_ch.Fs_NS_TLAP_DK_CMCCARE_CT(form_Fs_nsd(), b_so_id, a_nnnghiep, a_cdanh, a_level, a_loadhd, ns_tlap_dk_cmccare_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = b_so_id;
}
function ns_tlap_dk_cmccare_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    //if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_ma_bh = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "bh_cmc_care"));
    var b_ten_bh = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten_bh_cmc_care"));
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    lke_P_DAT($get(b_bh_cmc_care), b_ma_bh + '{' + b_ten_bh);
    if (a_kq[1] == "") GridX_datTrang(b_grnnnghiepId);
    else GridX_datBang(b_grnnnghiepId, a_kq[1]);

    if (a_kq[2] == "") GridX_datTrang(b_grcdanhId);
    else GridX_datBang(b_grcdanhId, a_kq[2]);

    if (a_kq[3] == "") GridX_datTrang(b_grlevelId);
    else GridX_datBang(b_grlevelId, a_kq[3]);

    if (a_kq[4] == "") GridX_datTrang(b_grlhdId);
    else GridX_datBang(b_grlhdId, a_kq[4]);
}
function ns_tlap_dk_cmccare_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(b_lkeCho); ns_tlap_dk_cmccare_P_LKE(); }
}
function ns_tlap_dk_cmccare_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);//, b_ma = $get(b_bh_cmc_care).value;
        sns_ma_ch.Fs_NS_TLAP_DK_CMCCARE_LKE(form_Fs_nsd(), a_tso, a_cot, ns_tlap_dk_cmccare_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tlap_dk_cmccare_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang(b_grlkeId, b_kq);
}
function ns_tlap_dk_cmccare_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grctId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        if (b_value != "") {
            if (b_cot == "SO_THE") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Mã cán bộ", b_value, "ns_cb,so_the,ten", tl_phanca_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        if (b_value != "") GridX_ThemHang(b_grctId);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function nnnghiep_HangLen() {
    GridX_chuyenHang(b_grnnnghiepId, -1);
    return false;
}
function nnnghiep_HangXuong() {
    GridX_chuyenHang(b_grnnnghiepId, 1);
    return false;
}
function nnnghiep_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grnnnghiepId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grnnnghiepId);
    return false;
}
function nnnghiep_CatDong() {
    GridX_boChon(b_grnnnghiepId, 'C');
    return false;
}
function cdanh_HangLen() {
    GridX_chuyenHang(b_grcdanhId, -1);
    return false;
}
function cdanh_HangXuong() {
    GridX_chuyenHang(b_grcdanhId, 1);
    return false;
}
function cdanh_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grcdanhId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grcdanhId);
    return false;
}
function cdanh_CatDong() {
    GridX_boChon(b_grcdanhId, 'C');
    return false;
}
function level_cdanh_HangLen() {
    GridX_chuyenHang(b_grlevelId, -1);
    return false;
}
function level_cdanh_HangXuong() {
    GridX_chuyenHang(b_grlevelId, 1);
    return false;
}
function level_cdanh_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grlevelId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grlevelId);
    return false;
}
function level_cdanh_CatDong() {
    GridX_boChon(b_grlevelId, 'C');
    return false;
}
function loai_hd_HangLen() {
    GridX_chuyenHang(b_grlhdId, -1);
    return false;
}
function loai_hd_HangXuong() {
    GridX_chuyenHang(b_grlhdId, 1);
    return false;
}
function loai_hd_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grlhdId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grlhdId);
    return false;
}
function loai_hd_CatDong() {
    GridX_boChon(b_grlhdId, 'C');
    return false;
}
function form_dong() {
    location.reload(false);
}
function ns_tlap_dk_cmccare_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function ns_tlap_dk_cmccare_P_LAY() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grcdanhId);
        sns_hdns.Fs_NS_HDNS_GAN_CDANHDVI_LAY(form_Fs_nsd(), a_cot, ns_tlap_dk_cmccare_P_LAY_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tlap_dk_cmccare_P_LAY_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    GridX_datBang(b_grcdanhId, a_kq[1]);
    //slide_P_SOTRANG(b_slidectId);
}