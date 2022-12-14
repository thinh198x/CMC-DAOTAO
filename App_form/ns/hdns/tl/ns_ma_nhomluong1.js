var ns_ma_nhomluong_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timId, b_tlId, b_ma_tl_Id, b_luudayId = '', b_thso_ma_tl = '', b_drop, b_nsd, ns_ma_nhomluong_choAct = 0;
function ns_ma_nhomluong_P_KD() {
    ns_ma_nhomluong_lkeCho = setInterval('ns_ma_nhomluong_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("MA_TL") >= 0) {
            var b_ma_thang_luong = a_tso[0], b_ten_thang_luong = a_tso[1];
            var b_ma_tl_Id1 = form_Fctr_TEN_DTUONG(b_vungId, 'MA_TL');
            lke_P_DAT(b_ma_tl_Id1, b_ma_thang_luong + '{' + b_ten_thang_luong);
            form_P_MOI(b_vungId, "LX");
            $get(b_gchuId).innerHTML = a_tso[1]; $get(b_tlId).focus();
        } else if (b_dtuong.indexOf("THAMSO") >= 0) {
            $get(b_luudayId).value = a_tso[1]; ns_ma_nhomluong_P_LKE();
            $get(b_gocId).focus();
            lke_P_DAT($get(b_tlId), a_tso[0] + '{' + a_tso[1]);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_nhomluong_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
            case "MA_TL": b_maId = b_tlId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            $get(b_gocId).value = ($get(b_gocId).value).validate_Ma();
            var b_ma_tl = C_NVL(form_Fs_TEN_GTRI(b_vungId, 'MA_TL'));
            //var b_ten_tl = $get(b_ma_tl_Id).value;
            //var a_ma = [b_ma.value, b_ma_tl + "{" + b_ten_tl];
            //var b_hang = GridX_Fi_timHangD(b_grlkeId, ["ma", "ma_tl"], a_ma);
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) {
                GridX_thoiA(b_grlkeId);
                ns_ma_nhomluong_P_MA_KTRA();
            }
            else {
                GridX_datA(b_grlkeId, b_hang);
                ns_ma_nhomluong_P_CHUYEN_HANG();
            }
            var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
            b_ten.focus();
        }
        else if (b_maTen == "MA_TL") {
            $get(b_gchuId).innerHTML = form_Fs_TEN_GTRI(b_vungId, 'MA_TL'); form_P_MOI(b_vungId, "GX");
            $get(b_thso_ma_tl).value = form_Fs_TEN_GTRI(b_vungId, 'MA_TL');
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_nhomluong_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            var b_matl = form_Fs_TEN_GTRI(b_vungId, 'MA_TL');
            sns_ma_ch.Fs_NS_MA_NL_MA(b_nsd, b_matl, b_ma, b_TrangKt, a_cot, ns_ma_nhomluong_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_nhomluong_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    if (a_kq[3] != "")
        GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_ma_nhomluong_P_CHUYEN_HANG(); }
}
function ns_ma_nhomluong_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_gocId).focus();
    list_P_DAT(b_drop, 'A');
    return false;
}
function ns_ma_nhomluong_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);

    var b_ma_tl = C_NVL(form_Fs_TEN_GTRI(b_vungId, 'MA_TL'));
    if (b_ma_tl == '') form_P_LOI("loi:Bạn phải chọn thang lương:loi");
    else sns_ma_ch.Fs_NS_MA_NL_NH(b_nsd, b_TrangKt, b_ma_tl, a_dt_ct, a_cot, ns_ma_nhomluong_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_ma_nhomluong_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI("loi:Ghi thành công!:loi");
    }
    return false;
}
function ns_ma_nhomluong_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    if (b_ma == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); ns_ma_nhomluong_P_MOI(); }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_matl = C_NVL(form_Fs_TEN_GTRI(b_vungId, 'MA_TL'));
        sns_ma_ch.Fs_NS_MA_NL_XOA(b_nsd, b_ma, b_matl, a_tso, a_cot, ns_ma_nhomluong_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_ma_nhomluong_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        if (b_kq.indexOf("ton tai bac luong") > 0) b_kq = "loi:Bản ghi đã được sử dụng ở chức năng khác, không được xóa:loi";
        form_P_LOI(b_kq);
    }
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        form_P_LOI('loi:Xóa thành công!:loi');
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_ma_nhomluong_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_ma_nhomluong_P_CHUYEN_HANG(); }
    }
}
function ns_ma_nhomluong_GR_lke_RowChange() {
    if (ns_ma_nhomluong_choAct != 0) clearTimeout(ns_ma_nhomluong_choAct);
    ns_ma_nhomluong_choAct = setTimeout("ns_ma_nhomluong_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_ma_nhomluong_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        if (b_ma == "") { form_P_MOI(b_vungId, "XGL"); list_P_DAT(b_drop, 'A'); }
        else { form_P_GridX_TEXT(b_vungId, b_grlkeId); return false; }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_nhomluong_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        ns_ma_nhomluong_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
        b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'); b_tlId = form_Fs_TEN_ID(b_vungId, 'MA_TL'), b_drop = form_Fctr_TEN_DTUONG(b_vungId, 'TT');
        b_ma_tl_Id = form_Fs_TEN_ID(b_vungId, 'MA_TL');
        b_slideId = $get(b_grlkeId).getAttribute('slideId'); slide_P_MOI(b_slideId);
        b_gchuId = form_Fs_VTEN_ID('', 'gchu'); b_thso_ma_tl = form_Fs_VTEN_ID(b_vungId, 'day2');
        b_luudayId = form_Fs_VTEN_ID('UPa_hi', 'luu_day');
        b_nsd = form_Fs_nsd();
        clearTimeout(ns_ma_nhomluong_lkeCho); ns_ma_nhomluong_P_LKE();
    }
}
function ns_ma_nhomluong_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_matl = '';//$get(b_thso_ma_tl).value;
        var b_day = $get(b_luudayId).value;
        sns_ma_ch.Fs_NS_MA_NL_LKE(b_nsd, b_matl, b_day, a_tso, a_cot, ns_ma_nhomluong_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_nhomluong_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_ma_nhomluong_P_EXCEL() {
    __doPostBack('ctl00$ContentPlaceHolder1$Nhap2', '');
}
function form_dong() {
    location.reload(false);
}