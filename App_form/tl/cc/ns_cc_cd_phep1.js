var b_lkeCho, b_vungId, b_grlkeId, b_nngoai, b_grctId, b_slideId, b_gocId, b_ma_nnn_Id, b_check, b_so_phep_Id, b_ngay_hl_Id, b_ma_nnn_day_Id, b_nsd, ns_cc_cd_phep_choAct = 0, b_gchuId,
    b_ngay_bdId, b_ngay_ktId;
function ns_cc_cd_phep_P_KD() {
    b_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'ma_cdanh'); b_ngay_bdId = form_Fs_TEN_ID(b_vungId, 'ngay_bd'), b_ngay_ktId = form_Fs_TEN_ID(b_vungId, 'ngay_kt')
    b_so_phep_Id = form_Fctr_TEN_DTUONG(b_vungId, 'PHEP');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_slideId = $get(b_grlkeId).getAttribute('slideId');
    b_nngoai = form_Fs_TEN_ID(b_vungId, 'phep_nn');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_check = form_Fs_TEN_ID(b_vungId, 'nngoai');
    b_nsd = form_Fs_nsd();
    b_lkeCho = setInterval('ns_cc_cd_phep_P_LKE_CHO()', 200);
    ns_cc_cd_phep_P_KTRA_NNGOAI($get(b_check).value);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        b_dtuong = b_dtuong.toUpperCase();
        if (b_dtuong.indexOf("MA") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grctId, b_hang, ["ma_cdanh"], [a_tso[0]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["ten_cdanh"], [a_tso[1]], 'K');
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
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_cc_cd_phep_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN); $get(b_dchiId).focus();
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
        GridX_datTrang(b_grctId);
        $get(b_ma_nnn_Id).focus();
    }
    else {
        GridX_datA(b_grlkeId, b_hang);
        ns_cc_cd_phep_P_CHUYEN_HANG();
    }
}
function ns_cc_cd_phep_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId); GridX_datTrang(b_grctId);
    $get(b_so_idId).value = "0";
    ns_cc_cd_phep_P_KTRA_NNGOAI($get(b_check).value);
    return false;
}
function ns_cc_cd_phep_P_NH() {

    try {
        var ktra = ktra_ngay(parseDate($get(b_ngay_bdId).value).getTime(), parseDate($get(b_ngay_ktId).value).getTime(), 1, "Áp dụng từ ngày", "Áp dụng đến ngày");
        if (ktra.length > 0) {
            ns_cc_cd_phep_P_NH_KQ(ktra);
            return false;
        }
        var b_hang = GridX_Fi_timHangA(b_grlkeId), b_so_id = "0";
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_dt = form_Faa_TEXT_ROW(b_vungId);
            if (b_hang > 0) b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId), b_dt_ct = GridX_Fdt_cotGtri(b_grctId);
            sns_cc.Fs_NS_CC_CD_PHEP_NH(b_nsd, b_TrangKt, b_so_id, b_dt, b_dt_ct, a_cot_lke, ns_cc_cd_phep_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_cc_cd_phep_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        form_P_LOI("loi:Nhập thành công!:loi");
    }
}
function ns_cc_cd_phep_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_hang < 1 || b_so_id == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); ns_cc_cd_phep_P_MOI(); return false; }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_cc.Fs_NS_CC_CD_PHEP_XOA(b_nsd, b_so_id, a_tso, a_cot, ns_cc_cd_phep_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
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
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")),
        a_cot = GridX_Fas_tenCot(b_grctId);
    if (b_so_id == "") ns_cc_cd_phep_P_MOI();
    else sns_cc.Fs_NS_CC_CD_PHEP_CT(form_Fs_nsd(), b_so_id, a_cot, ns_cc_cd_phep_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    GridX_datA(b_grlkeId, b_hang);
}
function ns_cc_cd_phep_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId);
    else GridX_datBang(b_grctId, a_kq[1]);
    ns_cc_cd_phep_P_KTRA_NNGOAI($get(b_check).value);
}
function ns_cc_cd_phep_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (b_lkeCho != 0) clearTimeout(b_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_cc_cd_phep_P_LKE('K');
    }
}
function ns_cc_cd_phep_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_cc.Fs_NS_CC_CD_PHEP_LKE(b_nsd, a_tso, a_cot, ns_cc_cd_phep_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_cc_cd_phep_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_cc_cd_phep_P_LKE_KQ_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang(b_grctId, b_kq);
}
function ns_cc_cd_phep_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}
function ns_cc_cd_phep_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function ktra_ngay(tungay, denngay, loai, ten1, ten2) {
    if (denngay == "" || denngay == null) {
        return "";
    }
    if (loai == 1 && tungay > denngay) {
        return "loi: " + ten1 + " không được lớn hơn " + ten2 + " :loi";
    } else if (loai == 2 && tungay >= denngay) {
        return "loi: " + ten1 + " không được lớn hơn hoặc bằng " + ten2 + " :loi";
    }
    return "";
}
function parseDate(str) {
    var mdy = str.split('/');
    return new Date(mdy[2], mdy[1], mdy[0]);
}
function addDays(date, days) {
    date = date.substring(6, 10) + "-" + date.substring(3, 5) + "-" + date.substring(0, 2);
    var result = new Date(date);
    result.setMonth(result.getMonth() + Number(days));
    result.setDate(result.getDate() - Number(1));
    var kq = NG_CNG(result);
    return kq;
}
function form_dong() {
    location.reload(false);
}
function ns_cc_cd_phep_P_KTRA_NNGOAI(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = $get(b_check).value;
        b_maTen = b_maTen.toUpperCase();
        if (b_maTen == "X") {
            $get(b_nngoai).style.display = "";
            $get("ctl00_ContentPlaceHolder1_blbngayhuong").style.display = "";
        }
        else {
            $get(b_nngoai).style.display = "none";
            $get("ctl00_ContentPlaceHolder1_blbngayhuong").style.display = "none";
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_cd_phep_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else if (b_mt == "SO_THE_GT") { $get(b_gocId).value = b_kq; }
    else form_P_DatGchu(b_gchuId, b_kq);
}