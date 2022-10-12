var ns_hdns_ma_bacluong_lkeCho = 0, ns_hdns_ma_bacluong_choAct = 0, b_vungId, b_grlkeId, b_slideId, b_vungHi, b_grCt, b_so_idHi,
    b_ma_tlId, b_ma_nlId, b_ma_nnnghiepId, b_slidectId;
function ns_hdns_ma_bacluong_P_KD() {
    b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
    b_grCt = form_Fs_VUNG_ID('GR_ct');
    b_vungHi = form_Fs_VUNG_ID('UPa_hi');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_ma_tlId = form_Fs_TEN_ID(b_vungId, 'MA_TL');
    b_ma_nlId = form_Fs_TEN_ID(b_vungId, 'MA_NL');
    b_ma_nnnghiepId = form_Fs_TEN_ID(b_vungId, 'ma_nnnghiep');
    b_so_idHi = form_Fs_TEN_ID(b_vungHi, 'so_id');
    b_slideId = $get(b_grlkeId).getAttribute('slideId'); slide_P_MOI(b_slideId);
    b_slidectId = $get(b_grCt).getAttribute('slideId'); slide_P_MOI(b_slidectId);
    ns_hdns_ma_bacluong_lkeCho = setInterval('ns_hdns_ma_bacluong_P_LKE_CHO()', 200);
    ns_hdns_ma_bacluong_P_KTRA('MA_TL');
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
            if (a_tso[0] == 'FILE_HTOAN') {
                ns_hdns_ma_bacluong_P_LKE(); form_P_MOI(b_vungId, "GLX");
            }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_bacluong_P_KTRA(b_maTen) {
    try {
        var b_ma_Id = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA_TL": b_ma_Id = b_ma_tlId; break;
            case "MA_NL": b_ma_Id = b_ma_nlId; break;
            case "MA_NNNGHIEP": b_ma_Id = b_ma_nnnghiepId; break;
        }
        var b_ma = $get(b_ma_Id);
        if (b_maTen == "MA_TL") {
            var b_ma_tl = form_Fs_TEN_GTRI(b_vungId, 'MA_TL');
            $get(b_ma_nlId).value = "";
            $get(b_ma_nnnghiepId).value = "";
            GridX_thoiA(b_grlkeId);
            GridX_datTrang(b_grCt);
            $get(b_so_idHi).value = "";
            $get(b_gchuId).innerHTML = "";
            if (b_ma_tl != "") {
                sns_ma_ch.Fs_NS_MA_TL_NL(window.name, b_ma_tl, ns_hdns_ma_bacluong_P_NL_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            } else return false;
        }
        else if (b_maTen == "MA_NL") {
            $get(b_ma_nnnghiepId).value = "";
            GridX_thoiA(b_grlkeId);
            GridX_datTrang(b_grCt);
            $get(b_so_idHi).value = "";
            $get(b_gchuId).innerHTML = "";
            var b_ma_tl = lke_Fs_TRA(b_ma_tlId);
            var b_ma_nl = lke_Fs_TRA(b_ma_nlId);
            var b_ma_nnnghiep = "";
            b_hang = GridX_Fi_timHangM(b_grlkeId, ["ma_tl", "ma_nl", "ma_nnnghiep"], [b_ma_tl, b_ma_nl, b_ma_nnnghiep]);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_hdns_ma_bacluong_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_hdns_ma_bacluong_P_CHUYEN_HANG(); }
        }
        else if (b_maTen == "MA_NNNGHIEP") {
            var b_ma_tl = lke_Fs_TRA(b_ma_tlId);
            var b_ma_nl = lke_Fs_TRA(b_ma_nlId);
            var b_ma_nnnghiep = lke_Fs_TRA(b_ma_nnnghiepId);
            b_hang = GridX_Fi_timHangM(b_grlkeId, ["ma_tl", "ma_nl", "ma_nnnghiep"], [b_ma_tl, b_ma_nl, b_ma_nnnghiep]);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_hdns_ma_bacluong_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_hdns_ma_bacluong_P_CHUYEN_HANG(); }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_bacluong_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    $get(b_gchuId).innerHTML = b_kq;
}
function ns_hdns_ma_bacluong_P_MA_KTRA() {
    try {
        var b_ma_tl = lke_Fs_TRA(b_ma_tlId);
        var b_ma_nl = lke_Fs_TRA(b_ma_nlId);
        var b_ma_nnnghiep = lke_Fs_TRA(b_ma_nnnghiepId);
        if (b_ma_tl != "" && b_ma_nl != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_ma_ch.Fs_NS_HDNS_MA_BACLUONG_MA(b_ma_tl, b_ma_nl, b_ma_nnnghiep, b_TrangKt, a_cot, ns_hdns_ma_bacluong_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_bacluong_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    $get(b_so_idHi).value = a_kq[4];
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_hdns_ma_bacluong_P_CHUYEN_HANG(); }
}
function ns_hdns_ma_bacluong_P_MOI() {
    form_P_MOI(b_vungId, "GLX");
    ns_hdns_ma_bacluong_P_KTRA('MA_TL')
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grCt);
    $get(b_so_idHi).value = "";
    $get(b_gchuId).innerHTML = "";
    return false;
}
function ns_hdns_ma_bacluong_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        else {
            var b_so_id = CSO_SO($get(b_so_idHi).value, 0);
            var a_dt = form_Faa_TEXT_ROW(b_vungId), a_cot_ct = GridX_Fdt_cotGtri(b_grCt);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            sns_ma_ch.Fs_NS_HDNS_MA_BACLUONG_NH(form_Fs_nsd(), b_so_id, a_dt, a_cot_ct, b_TrangKt, a_cot_lke, ns_hdns_ma_bacluong_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_hdns_ma_bacluong_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_so_idHi).value = a_kq[4];
        form_P_LOI("loi:Ghi thành công!:loi");
    }
    return false;
}
function ns_hdns_ma_bacluong_P_XOA() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
        var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
        if (b_so_id == "") { ns_hdns_ma_bacluong_P_MOI(); }
        else {
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            sns_ma_ch.Fs_NS_HDNS_MA_BACLUONG_XOA(form_Fs_nsd(), b_so_id, a_tso, a_cot, ns_hdns_ma_bacluong_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
    return false;
}
function ns_hdns_ma_bacluong_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_hdns_ma_bacluong_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_hdns_ma_bacluong_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
}
function ns_hdns_ma_bacluong_GR_lke_RowChange() {
    if (ns_hdns_ma_bacluong_choAct != 0) clearTimeout(ns_hdns_ma_bacluong_choAct);
    ns_hdns_ma_bacluong_choAct = setTimeout("ns_hdns_ma_bacluong_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_hdns_ma_bacluong_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) { return false; }
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        GridX_datTrang(b_grCt);
        if (b_so_id == "" || b_so_id == 0) {
            form_P_MOI(b_vungId, "GLX");
            $get(b_so_idHi).value = "";
        }
        else {
            var a_cot_ct = GridX_Fas_tenCot(b_grCt);
            sns_ma_ch.Fs_NS_HDNS_MA_BACLUONG_CT(form_Fs_nsd(), window.name, b_so_id, a_cot_ct, ns_hdns_ma_bacluong_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            $get(b_so_idHi).value = b_so_id;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_bacluong_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    GridX_datBang(b_grCt, a_kq[1]);
    slide_P_SOTRANG(b_slidectId);
}
function ns_hdns_ma_bacluong_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_hdns_ma_bacluong_lkeCho); ns_hdns_ma_bacluong_P_LKE(); }
}
function ns_hdns_ma_bacluong_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_NS_HDNS_MA_BACLUONG_LKE(a_tso, a_cot, ns_hdns_ma_bacluong_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_bacluong_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_hdns_ma_bacluong_HangLen(mode) {
    var b_grct;
    if (mode == 1) b_grct = b_grCt;
    else return false;
    GridX_chuyenHang(b_grct, -1);
    return false;
}
function ns_hdns_ma_bacluong_HangXuong(mode) {
    var b_grct;
    if (mode == 1) b_grct = b_grCt;
    else return false;
    GridX_chuyenHang(b_grct, 1);
    return false;
}
function ns_hdns_ma_bacluong_CatDong(mode) {
    var b_grct;
    if (mode == 1) b_grct = b_grCt;
    else return false;
    GridX_boChon(b_grct, 'C');
    return false;
}
function ns_hdns_ma_bacluong_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grCt) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grCt);
    return false;
}
function ns_hdns_ma_bacluongTL_NL_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    ns_hdns_ma_bacluong_P_LKE();

}
function ns_hdns_ma_bacluong_NL_NNN_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else list_P_LKE(form_Fs_TEN_ID(b_vungId, 'MA_NNNGHE'), b_kq);
    ns_hdns_ma_bacluong_P_LKE();
    return false;
}
function ns_hdns_ma_bacluong_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function form_dong() {
    location.reload(false);
}
function ns_hdns_ma_bacluong_P_TLUONG() {
    try {
        var b_tl = CSO_SO($get(b_tluongId).value, 2), b_lcb = CSO_SO($get(b_lcbId).value, 2);
        var b_tdg = SO_CSO(b_tl - b_lcb);
        $get(b_tdgId).value = b_tdg;
    }
    catch (err) { form_P_LOI(err); }
}
function ktra_tien(b_tongluong, b_luong_cb) {
    if (b_luong_cb == 0 || b_luong_cb == null) {
        return "";
    }
    if (b_tongluong < b_luong_cb) {
        return "loi:Lương cơ bản không được lớn hơn Tổng lương:loi";
    }
    return "";
}
function ns_hdns_ma_bacluong_FILE_IMPORT() {
    var b_tenf = '/App_form/ns/ma/file_import_hdns.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "MA_BACLUONG_IMP", "MA_BACLUONG_IMP", "Import mã bậc lương"]], null);
    form_P_LOI('');
    return false;
}
function ns_hdns_ma_bacluong_P_MAU() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'btn_excel_mau');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function ns_hdns_ma_bacluong_GR_Update() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grCt);
        if (b_hang < 0) return;
        var b_bacluong = GridX_Fas_layGtriA(b_grCt, "bacluong");
        var b_hang_d = GridX_Fi_timHangD(b_grCt, "bacluong", b_bacluong);
        if (b_hang_d > 0 && b_hang_d != b_hang) {
            GridX_datGtri(b_grCt, b_hang, ["bacluong"], "", 'K');
            GridX_datA(b_grCt, b_hang, ["bacluong"], 'C');
            form_P_LOI("loi:Tồn tại bậc lương giống nhau:loi");
            return false;

        }
        var b_tongluong = CSO_SO(GridX_Fas_layGtriA(b_grCt, "tongluong"));
        var b_luong_cb = CSO_SO(GridX_Fas_layGtriA(b_grCt, "luong_cb"));
        if (b_luong_cb == 0) {
            GridX_datGtri(b_grCt, b_hang, ["thuong_dg"], "", 'K');
            return false;
        } else {
            var ktra = ktra_tien(b_tongluong, b_luong_cb);
            //if (Fb_LOI_KTRA(ktra)) {
            //    form_P_LOI(ktra); return false;
            //    GridX_datGtri(b_grCt, b_hang, ["thuong_dg"], "", 'K');
            //}
            var b_thuong_dg = b_tongluong - b_luong_cb;
            GridX_datGtri(b_grCt, b_hang, ["thuong_dg"], SO_CSO(b_thuong_dg), 'K');
            GridX_datGtri(b_grCt, b_hang, ["tongluong"], SO_CSO(b_luong_cb), 'K');
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_bacluong_P_NL_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
}