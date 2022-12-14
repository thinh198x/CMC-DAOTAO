var ns_ma_khungluong_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timId, b_tlId, b_ma_tl_Id, b_luudayId = '', b_thso_ma_tl = '', b_drop,
    b_nsd, ns_ma_khungluong_choAct = 0, b_grctId, b_mucminId, b_mucmaxId, b_diemgiuaId;
function ns_ma_khungluong_P_KD() {
    ns_ma_khungluong_lkeCho = setInterval('ns_ma_khungluong_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("MA_NCD") >= 0) {
            var b_ma_thang_luong = a_tso[0], b_ten_thang_luong = a_tso[1];
            var b_ma_tl_Id1 = form_Fctr_TEN_DTUONG(b_vungId, 'MA_NCD');
            lke_P_DAT(b_ma_tl_Id1, b_ma_thang_luong + '{' + b_ten_thang_luong);
            form_P_MOI(b_vungId, "LX");
            $get(b_gchuId).innerHTML = a_tso[1]; $get(b_tlId).focus();
        } else if (b_dtuong.indexOf("THAMSO") >= 0) {
            $get(b_luudayId).value = a_tso[1]; ns_ma_khungluong_P_LKE();
            $get(b_gocId).focus();
            lke_P_DAT($get(b_tlId), a_tso[0] + '{' + a_tso[1]);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_khungluong_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
            case "MA_TL": b_maId = b_tlId; break;
            case "MA_NCD": b_maId = b_ma_ncdlId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            // kiểm tra mã không được có ký tự đặc biệt 
            //$get(b_gocId).value = ($get(b_gocId).value).validate_Ma();
            var b_ma_tl = C_NVL(form_Fs_TEN_GTRI(b_vungId, 'MA_TL'));
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) {
                GridX_thoiA(b_grlkeId);
                ns_ma_khungluong_P_MA_KTRA();
            }
            else {
                GridX_datA(b_grlkeId, b_hang);
                ns_ma_khungluong_P_CHUYEN_HANG();
            }
            var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
            b_ten.focus();
        }
        else if (b_maTen == "MA_NCD") {
            //$get(b_gchuId).innerHTML = form_Fs_TEN_GTRI(b_vungId, 'MA_NCD');
            var b_ma_ncd = form_Fs_TEN_GTRI(b_vungId, 'MA_NCD');
            if (b_ma_tl != "") {
                var a_cot = GridX_Fas_tenCot(b_grctId);
                sns_ma_ch.Fs_NS_MA_CDANH(window.name, b_ma_ncd, a_cot, ns_ma_khungluong_P_NL_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            } else {
                GridX_datTrang(b_grctId);
            };
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_khungluong_P_NL_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    if (a_kq[0] == "")
        GridX_datTrang(b_grctId);
    else
        GridX_datBang(b_grctId, b_kq);
    return false;

}
function ns_ma_khungluong_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            var b_matl = form_Fs_TEN_GTRI(b_vungId, 'MA_TL');
            sns_ma_ch.Fs_NS_MA_KHUNGLUONG_MA(b_nsd, b_matl, b_ma, b_TrangKt, a_cot, ns_ma_khungluong_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_khungluong_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    if (a_kq[3] != "")
        GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_ma_khungluong_P_CHUYEN_HANG(); }
}
function ns_ma_khungluong_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_datTrang(b_grctId);
    GridX_thoiA(b_grlkeId);
    $get(b_gocId).focus();
    return false;
}
function ns_ma_khungluong_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId),
    a_cot_ct = GridX_Fdt_cotGtri(b_grctId);
    sns_ma_ch.Fs_NS_MA_KHUNGLUONG_NH(b_nsd, b_TrangKt, a_dt_ct, a_cot, a_cot_ct, ns_ma_khungluong_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_ma_khungluong_P_NH_KQ(b_kq) {
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
function ns_ma_khungluong_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    if (b_ma == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); ns_ma_khungluong_P_MOI(); }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_NS_MA_KHUNGLUONG_XOA(b_nsd, b_ma, a_tso, a_cot, ns_ma_khungluong_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_ma_khungluong_P_XOA_KQ(b_kq) {
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
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_ma_khungluong_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_ma_khungluong_P_CHUYEN_HANG(); }
    }
}
function ns_ma_khungluong_GR_lke_RowChange() {
    if (ns_ma_khungluong_choAct != 0) clearTimeout(ns_ma_khungluong_choAct);
    ns_ma_khungluong_choAct = setTimeout("ns_ma_khungluong_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_ma_khungluong_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        if (b_ma == "") { form_P_MOI(b_vungId, "XGL"); GridX_datTrang(b_grctId); }
        else {
            var a_cot_ct = GridX_Fas_tenCot(b_grctId)
            sns_ma_ch.Fs_NS_MA_KHUNGLUONG_CT(b_nsd, b_ma, a_cot_ct, ns_ma_khungluong_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_khungluong_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
    return false;
}
function ns_ma_khungluong_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        ns_ma_khungluong_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct');
        b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'); b_ma_ncdlId = form_Fs_TEN_ID(b_vungId, 'MA_NCD'), b_grqtct = form_Fs_VUNG_ID('GR_ct'),
        b_mucminId = form_Fs_TEN_ID(b_vungId, 'mucmin'); b_mucmaxId = form_Fs_TEN_ID(b_vungId, 'mucmax'); b_diemgiuaId = form_Fs_TEN_ID(b_vungId, 'diemgiua');
        //b_drop = form_Fctr_TEN_DTUONG(b_vungId, 'TT');
        //b_ma_cdanhId = form_Fs_TEN_ID(b_vungId, 'MA_CDANH');
        b_slideId = $get(b_grlkeId).getAttribute('slideId'); slide_P_MOI(b_slideId);
        b_gchuId = form_Fs_VTEN_ID('', 'gchu'); b_thso_ma_tl = form_Fs_VTEN_ID(b_vungId, 'day2');
        b_luudayId = form_Fs_VTEN_ID('UPa_hi', 'luu_day');
        b_nsd = form_Fs_nsd();
        clearTimeout(ns_ma_khungluong_lkeCho); ns_ma_khungluong_P_LKE();
    }
}
function ns_ma_khungluong_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_matl = '';//$get(b_thso_ma_tl).value;
        var b_day = $get(b_luudayId).value;
        sns_ma_ch.Fs_NS_MA_KHUNGLUONG_LKE(b_nsd, a_tso, a_cot, ns_ma_khungluong_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_khungluong_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    var a_cot = GridX_Fas_tenCot(b_grctId);
    sns_ma_ch.Fs_NS_MA_CDANH(window.name, "", a_cot, ns_ma_khungluong_P_NL_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function ns_ma_khungluong_P_EXCEL() {
    __doPostBack('ctl00$ContentPlaceHolder1$Nhap2', '');
}
function ns_ma_khungluong_P_TINH() {
    var b_mucmin = $get(b_mucminId).value, b_mucmax = $get(b_mucmaxId).value;
    $get(b_diemgiuaId).value = SO_CSO((CSO_SO(b_mucmin) + CSO_SO(b_mucmax)) / 2);
}

function form_dong() {
    location.reload(false);
}