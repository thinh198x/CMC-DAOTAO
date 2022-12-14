var ns_cc_dtcc_lkeCho, b_vungId, b_vungmtdId, b_vungdmvsId, b_vungonsiteId, b_vungkgId, b_phongidId, b_tdId, b_dmvsId, b_onsiteId, b_kgId, b_grlkeId, b_grmtdId, b_grdmvsId, b_gronsiteId, b_grkgId, b_slideId, b_slidemtdId, b_slidedmvsId, b_slideonsiteId, b_slidekgId, b_gocId, b_ncdanhId, ns_cc_dtcc_choAct = 0;
function ns_cc_dtcc_P_KD() {
    ns_cc_dtcc_lkeCho = setInterval('ns_cc_dtcc_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        b_dtuong = b_dtuong.toUpperCase();
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
            if (a_tso[0] == 'FILE_HTOAN') {
                ns_cc_dtcc_P_LKE();
            }
        } else if (b_dtuong.indexOf("MTD") >= 0) {
            ns_cc_dtcc_P_LAY_MTD();
        } else if (b_dtuong.indexOf("DMVS") >= 0) {
            ns_cc_dtcc_P_LAY_DMVS();
        } else if (b_dtuong.indexOf("ONSITE") >= 0) {
            ns_cc_dtcc_P_LAY_ONSITE();
        } else if (b_dtuong.indexOf("KG") >= 0) {
            ns_cc_dtcc_P_LAY_KG();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_dtcc_P_KTRA(b_maTen) {
    try {
        b_maTen = b_maTen.toUpperCase();
        if (b_maTen == "PHONG") {
            $get(b_phongidId).value = form_Fs_TEN_GTRI(b_vungId, 'PHONG');
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_dtcc_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    ns_cc_dtcc_P_MOI_CT("GXL");
    anhien();
    GridX_thoiA(b_grlkeId);

    return false;
}
function ns_cc_dtcc_P_MOI_CT(b_xoa) {
    form_P_MOI("", b_xoa);
    GridX_datTrang(b_grmtdId);
    GridX_datTrang(b_grdmvsId);
    GridX_datTrang(b_gronsiteId);
    GridX_datTrang(b_grkgId);
    return false;
}
function ns_cc_dtcc_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    var a_dt_td = GridX_Fdt_cotGtri(b_grmtdId), a_dt_dmvs = GridX_Fdt_cotGtri(b_grdmvsId),
        a_dt_onsite = GridX_Fdt_cotGtri(b_gronsiteId), a_dt_kg = GridX_Fdt_cotGtri(b_grkgId);
    sns_hdns.Fs_NS_CC_DTCC_NH(form_Fs_nsd(), b_TrangKt, a_dt_ct, a_cot, a_dt_td, a_dt_dmvs, a_dt_onsite, a_dt_kg, ns_cc_dtcc_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_cc_dtcc_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        ns_cc_dtcc_P_CHUYEN_HANG();
        form_P_LOI("loi:Ghi thành công!:loi");
    }
    return false;
}
function ns_cc_dtcc_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_so_id = CSO_SO(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"), 0);
    if (b_so_id == 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_NS_CC_DTCC_XOA(form_Fs_nsd(), b_so_id, a_tso, a_cot, ns_cc_dtcc_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_cc_dtcc_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        form_P_LOI("loi:Xóa thành công!:loi");
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_cc_dtcc_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_cc_dtcc_P_CHUYEN_HANG(); }
    }
}
function ns_cc_dtcc_GR_lke_RowChange() {
    if (ns_cc_dtcc_choAct != 0) clearTimeout(ns_cc_dtcc_choAct);
    ns_cc_dtcc_choAct = setTimeout("ns_cc_dtcc_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_cc_dtcc_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = CSO_SO(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"), 0), a_cot_mtd = GridX_Fas_tenCot(b_grmtdId)
        , a_cot_dmvs = GridX_Fas_tenCot(b_grdmvsId), a_cot_onsite = GridX_Fas_tenCot(b_gronsiteId), a_cot_kg = GridX_Fas_tenCot(b_grkgId);
        if (b_so_id <= 0) ns_cc_dtcc_P_MOI(); else sns_hdns.Fs_NS_CC_DTCC_CT(form_Fs_nsd(), b_so_id, a_cot_mtd, a_cot_dmvs, a_cot_onsite, a_cot_kg, ns_cc_dtcc_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_dtcc_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    slide_P_MOI(b_slidemtdId); slide_P_MOI(b_slidedmvsId); slide_P_MOI(b_slideonsiteId); slide_P_MOI(b_slidekgId);
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grmtdId); else GridX_datBang(b_grmtdId, a_kq[1]);
    if (a_kq[2] == "") GridX_datTrang(b_grdmvsId); else GridX_datBang(b_grdmvsId, a_kq[2]);
    if (a_kq[3] == "") GridX_datTrang(b_gronsiteId); else GridX_datBang(b_gronsiteId, a_kq[3]);
    if (a_kq[4] == "") GridX_datTrang(b_grkgId); else GridX_datBang(b_grkgId, a_kq[4]);
    $get(b_phongidId).value = form_Fs_TEN_GTRI(b_vungId, 'PHONG');
    slide_P_SOTRANG(b_slidemtdId);
    slide_P_SOTRANG(b_slidedmvsId);
    slide_P_SOTRANG(b_slideonsiteId);
    slide_P_SOTRANG(b_slidekgId);
    anhien();
}
function ns_cc_dtcc_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(ns_cc_dtcc_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungmtdId = form_Fs_VUNG_ID('UPa_mtd'), b_vungdmvsId = form_Fs_VUNG_ID('UPa_dmvs'),
        b_vungonsiteId = form_Fs_VUNG_ID('UPa_onsite'), b_vungkgId = form_Fs_VUNG_ID('UPa_kg'),
        b_phongidId = form_Fs_TEN_ID('', 'phongid'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_gchuId = form_Fs_VTEN_ID('', 'gchu');
        b_tdId = form_Fs_TEN_ID(b_vungId, 'mtd'); b_dmvsId = form_Fs_TEN_ID(b_vungId, 'dmvs');
        b_onsiteId = form_Fs_TEN_ID(b_vungId, 'onsite'); b_kgId = form_Fs_TEN_ID(b_vungId, 'kg');
        b_grmtdId = form_Fs_VUNG_ID('GR_mtd'); b_grdmvsId = form_Fs_VUNG_ID('GR_dmvs');
        b_gronsiteId = form_Fs_VUNG_ID('GR_onsite'); b_grkgId = form_Fs_VUNG_ID('GR_kg'); b_grdmvsId = form_Fs_VUNG_ID('GR_dmvs');
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        b_slidemtdId = $get(b_grmtdId).getAttribute('slideId');
        b_slidedmvsId = $get(b_grdmvsId).getAttribute('slideId');
        b_slideonsiteId = $get(b_gronsiteId).getAttribute('slideId');
        b_slidekgId = $get(b_grkgId).getAttribute('slideId');
        slide_P_MOI(b_slideId); slide_P_MOI(b_slidemtdId); slide_P_MOI(b_slidedmvsId); slide_P_MOI(b_slideonsiteId); slide_P_MOI(b_slidekgId);
        ns_cc_dtcc_P_LKE();
    }
}
function ns_cc_dtcc_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_NS_CC_DTCC_LKE(form_Fs_nsd(), a_tso, a_cot, ns_cc_dtcc_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_dtcc_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_cc_dtcc_P_LAY_MTD() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grmtdId);
        sns_hdns.Fs_NS_HDNS_GAN_CDANHDVI_LAY(form_Fs_nsd(), a_cot, ns_cc_dtcc_P_LAY_MTD_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_dtcc_P_LAY_MTD_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    GridX_datBang(b_grmtdId, a_kq[1]);
    slide_P_SOTRANG(b_slidemtdId);
}
function ns_cc_dtcc_P_LAY_DMVS() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grdmvsId);
        sns_hdns.Fs_NS_HDNS_GAN_CDANHDVI_LAY(form_Fs_nsd(), a_cot, ns_cc_dtcc_P_LAY_DMVS_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_dtcc_P_LAY_DMVS_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    GridX_datBang(b_grdmvsId, a_kq[1]);
    slide_P_SOTRANG(b_slidedmvsId);
}
function ns_cc_dtcc_P_LAY_ONSITE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_gronsiteId);
        sns_hdns.Fs_NS_HDNS_GAN_CDANHDVI_LAY(form_Fs_nsd(), a_cot, ns_cc_dtcc_P_LAY_ONSITE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_dtcc_P_LAY_ONSITE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    GridX_datBang(b_gronsiteId, a_kq[1]);
    slide_P_SOTRANG(b_slideonsiteId);
}
function ns_cc_dtcc_P_LAY_KG() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grkgId);
        sns_hdns.Fs_NS_HDNS_GAN_CDANHDVI_LAY(form_Fs_nsd(), a_cot, ns_cc_dtcc_P_LAY_KG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_dtcc_P_LAY_KG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    GridX_datBang(b_grkgId, a_kq[1]);
    slide_P_SOTRANG(b_slidekgId);
}
function anhien() {
    if ($get(b_tdId).value == 'X')
        $get(b_vungmtdId).style.display = "";
    else {
        $get(b_vungmtdId).style.display = "none";
    }
    if ($get(b_dmvsId).value == 'X')
        $get(b_vungdmvsId).style.display = "";
    else {
        $get(b_vungdmvsId).style.display = "none";
    }
    if ($get(b_onsiteId).value == 'X')
        $get(b_vungonsiteId).style.display = "";
    else {
        $get(b_vungonsiteId).style.display = "none";
    } if ($get(b_kgId).value == 'X')
        $get(b_vungkgId).style.display = "";
    else {
        $get(b_vungkgId).style.display = "none";
    }
}
function ns_cc_dtcc_mtd_cat() {
    GridX_boChon(b_grmtdId);
    return false;
}
function ns_cc_dtcc_dmvs_cat() {
    GridX_boChon(b_grdmvsId);
    return false;
}
function ns_cc_dtcc_onsite_cat() {
    GridX_boChon(b_gronsiteId);
    return false;
}
function ns_cc_dtcc_kg_cat() {
    GridX_boChon(b_grkgId);
    return false;
}
function form_dong() {
    location.reload(false);
}