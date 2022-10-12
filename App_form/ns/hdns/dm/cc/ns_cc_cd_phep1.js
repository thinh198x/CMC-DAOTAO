var b_lkeCho, b_vungId, b_grlkeId, b_gr_chucDanh_Id, b_slideId, b_gocId, b_ma_nnn_Id, b_so_phep_Id, b_ngay_hl_Id, b_ma_nnn_day_Id, b_nsd, ns_cc_cd_phep_choAct = 0;
function ns_cc_cd_phep_P_KD() {
    b_lkeCho = setInterval('ns_cc_cd_phep_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        b_dtuong = b_dtuong.toUpperCase();
        if (b_dtuong.indexOf("MA") >= 0) {
            ns_cc_cd_phep_P_LAY();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_cd_phep_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
            case "MA_NNN": b_maId = b_ma_nnn_Id; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            $get(b_maId).value = ($get(b_maId).value).validate_Ma();
            var b_hang = GridX_Fi_timHangD(b_grlkeId, ["ma"], [b_ma.value]);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_cc_cd_phep_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_cc_cd_phep_P_CHUYEN_HANG(); }            
        }
        else if (b_maTen == "MA_NNN") {
            var b_ma_nnn = lke_Fs_TRA(b_ma_nnn_Id);
            $get(b_ma_nnn_day_Id).value = b_ma_nnn;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_cd_phep_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_ma = $get(b_gocId).value;
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_cc.Fs_NS_CC_CD_PHEP_MA(b_nsd, b_ma, b_TrangKt, a_cot, ns_cc_cd_phep_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_cd_phep_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        form_P_MOI(b_vungId, "X");
        GridX_datTrang(b_gr_chucDanh_Id);
        $get(b_ma_nnn_Id).focus();
    }
    else {
        GridX_datA(b_grlkeId, b_hang);
        ns_cc_cd_phep_P_CHUYEN_HANG();
    }
}
function ns_cc_cd_phep_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_gr_chucDanh_Id);
    $get(b_gocId).focus();
    return false;
}
function ns_cc_cd_phep_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var b_soDong = GridX_Fi_hangSo(b_gr_chucDanh_Id), b_ma_nnn_grd;
    var b_ma_nnn_drp = lke_Fs_TRA(b_ma_nnn_Id);
    if (b_ma_nnn_drp != "") {
        for (var i = 1; i <= b_soDong; i++) {
            if (!GridX_Fb_hangTrang(b_gr_chucDanh_Id, i, "ma_cd")) {
                b_ma_nnn_grd = C_NVL(GridX_Fas_layGtri(b_gr_chucDanh_Id, i, "ma_nnn"));
                if (b_ma_nnn_grd != 'undefined' && b_ma_nnn_grd != b_ma_nnn_drp) {
                    var b_cd = C_NVL(GridX_Fas_layGtri(b_gr_chucDanh_Id, i, "ten"));
                    form_P_LOI("loi:Chức danh " + b_cd + " trên lưới không thuộc ngạch nghề nghiệp được chọn:loi");
                    return false;
                }
            }
        }
    }
    var a_cot_ct = GridX_Fdt_cotGtri(b_gr_chucDanh_Id);
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
    var b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_cc.Fs_NS_CC_CD_PHEP_NH(b_nsd, b_TrangKt, a_dt_ct, a_cot_ct, a_cot_lke, ns_cc_cd_phep_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_cc_cd_phep_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
    }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) { GridX_datA(b_grlkeId, b_hang); ns_cc_cd_phep_P_CHUYEN_HANG(); }
        $get(b_gocId).focus();
        form_P_LOI("loi:Ghi thành công!:loi");
    }
}
function ns_cc_cd_phep_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
    if (b_ma == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); ns_cc_cd_phep_P_MOI(); }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);        
        sns_cc.Fs_NS_CC_CD_PHEP_XOA(b_nsd, b_ma, a_tso, a_cot, ns_cc_cd_phep_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_cc_cd_phep_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_dong = CSO_SO(a_kq[0], 0);
        slide_P_SOTRANG(b_slideId, b_dong);
        GridX_datBang(b_grlkeId, a_kq[1]);
        if (b_hang > b_dong) b_hang = b_dong;
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_cc_cd_phep_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_cc_cd_phep_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
}
function ns_cc_cd_phep_GR_lke_RowChange() {
    if (ns_cc_cd_phep_choAct != 0) clearTimeout(ns_cc_cd_phep_choAct);
    ns_cc_cd_phep_choAct = setTimeout("ns_cc_cd_phep_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_cc_cd_phep_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        if (b_ma == "") { ns_cc_cd_phep_P_MOI(); GridX_datA(b_grlkeId, b_hang); }
        else {            
            var a_cot = GridX_Fas_tenCot(b_gr_chucDanh_Id);
            sns_cc.Fs_NS_CC_CD_PHEP_CT(b_nsd, b_ma, a_cot, ns_cc_cd_phep_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_cd_phep_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else if (b_kq == '') ns_cc_cd_phep_P_MOI();
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        form_P_CH_TEXT(b_vungId, a_kq[0]);
        var b_dong = CSO_SO(a_kq[2]);
        if (b_dong < 5) b_dong = 5;
        GridX_P_hangKt(b_gr_chucDanh_Id, b_dong);
        GridX_datBang(b_gr_chucDanh_Id, a_kq[1]);
        $get(b_ma_nnn_day_Id).value = lke_Fs_TRA(b_ma_nnn_Id);
    }
}
function ns_cc_cd_phep_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        b_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_gr_chucDanh_Id = form_Fs_VUNG_ID('GR_nh');
        b_gocId = form_Fs_TEN_ID(b_vungId, 'MA');
        b_ma_nnn_Id = form_Fs_TEN_ID(b_vungId, 'ma_nnn');
        b_so_phep_Id = form_Fctr_TEN_DTUONG(b_vungId, 'PHEP');
        b_ngay_hl_Id = form_Fctr_TEN_DTUONG(b_vungId, 'NGAY_HL');
        b_ma_nnn_day_Id = form_Fs_VTEN_ID('UPa_hi', 'ma_nnn_day');
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        b_nsd = form_Fs_nsd();
        clearTimeout(b_lkeCho); ns_cc_cd_phep_P_LKE();
    }
}
function ns_cc_cd_phep_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_cc.Fs_NS_CC_CD_PHEP_LKE(b_nsd, a_tso, a_cot, ns_cc_cd_phep_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_cd_phep_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_cc_cd_phep_P_LKE_KQ_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang(b_gr_chucDanh_Id, b_kq);
}
function ns_cc_cd_phep_P_LAY() {
    try {
        var a_cot = ["ma", "ten"];//GridX_Fas_tenCot(b_gr_chucDanh_Id);
        sns_hdns.Fs_NS_HDNS_GAN_CDANHDVI_LAY(b_nsd, a_cot, ns_cc_cd_phep_P_LAY_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_cd_phep_P_LAY_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_dong = CSO_SO(a_kq[0]);
    if (b_dong < 5) b_dong = 5;
    GridX_P_hangKt(b_gr_chucDanh_Id, b_dong);
    GridX_datBang(b_gr_chucDanh_Id, a_kq[1]);
}
function ns_cc_cd_phep_CatDong() {
    GridX_boChon(b_gr_chucDanh_Id, 'C');
    return false;
}
function form_dong() {
    location.reload(false);
}