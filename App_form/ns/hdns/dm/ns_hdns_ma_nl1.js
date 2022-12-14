var b_lkeCho, b_choAct = 0, b_vungId, b_vunghiId, b_grlkeId, b_slideId, b_slidectId, b_soId, b_gocId, b_tenId, b_nhomId, b_ttId, b_ma, b_dayId = '', form_chay;
function ns_hdns_ma_nl_P_KD() {
    b_lkeCho = setInterval('ns_hdns_ma_nl_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
            if (a_tso[0] == 'FILE_HTOAN') { ns_hdns_ma_nl_P_LKE(); form_P_MOI(b_vungId, "GLX"); }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_nl_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA_NL": b_maId = b_gocId; break;
        }
        var b_ma = $get(b_maId);
        if ($get(b_maId).value == "") return;
        if (b_maTen == "MA_NL") {
            $get(b_gocId).value = ($get(b_gocId).value).validate_Ma();
            var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ma_nl", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_hdns_ma_nl_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_hdns_ma_nl_P_CHUYEN_HANG(); }
            b_ten.focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_nl_P_MA_KTRA() {
    try {
        var b_so_id = C_NVL($get(b_soId).value);
        var b_nhom = C_NVL($get(b_nhomId).value);
        if (b_so_id != "" && b_nhom != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_hdns.Fs_NS_HDNS_MA_NL_MA(form_Fs_nsd(), b_so_id, b_TrangKt, a_cot, ns_hdns_ma_nl_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_nl_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_hdns_ma_nl_P_CHUYEN_HANG(); }
}
function ns_hdns_ma_nl_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    ns_hdns_ma_nl_moi();
    list_P_DAT(b_ttId, 'A');
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    $get(b_tenId).focus();
    return false;
}
function ns_hdns_ma_nl_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var b_so_id = C_NVL(GridX_Fas_layGtriA(b_grlkeId, "so_id"));
    var a_dt = form_Faa_TEXT_ROW(b_vungId), a_dt_ct = GridX_Fdt_cotGtri(b_grctId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_hdns.Fs_NS_HDNS_MA_NL_NH(form_Fs_nsd(), b_so_id, b_TrangKt, a_dt, a_dt_ct, a_cot_lke, ns_hdns_ma_nl_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_hdns_ma_nl_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang > 0) { GridX_datA(b_grlkeId, b_hang); ns_hdns_ma_nl_P_CHUYEN_HANG(); }
        $get(b_gocId).value = $get(b_ma).value;
        $get(b_gocId).focus();
        form_P_LOI('loi:Ghi thành công!:loi');
    }
    return false;
}
function ns_hdns_ma_nl_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI('loi:Bạn phải chọn một bản ghi để xóa!:loi'); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
    sns_hdns.Fs_NS_HDNS_MA_NL_XOA(form_Fs_nsd(), b_so_id, a_tso, a_cot, ns_hdns_ma_nl_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_hdns_ma_nl_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_hdns_ma_nl_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_hdns_ma_nl_P_CHUYEN_HANG(); }
        form_P_LOI('loi:Xóa thành công!:loi');
    }
}
function ns_hdns_ma_nl_P_CHON() {
    form_P_TRA_CHON_GRID('GR_ct:ten_muc_nl,GR_ct:mota,GR_ct:so_id_nl');
}
function ns_hdns_ma_nl_GR_lke_RowChange() {
    if (b_choAct != 0) clearTimeout(b_choAct);
    b_choAct = setTimeout("ns_hdns_ma_nl_P_CHUYEN_HANG()", 200);
    return false;
}
function ns_hdns_ma_nl_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == null || b_so_id == "") {
            form_P_MOI(b_vungId, "XGL");
            list_P_DAT(b_ttId, '');
            GridX_datTrang(b_grctId);
            ns_hdns_ma_nl_moi();
        } else {
            var a_cot_ct = GridX_Fas_tenCot(b_grctId);
            sns_hdns.Fs_NS_HDNS_MA_NL_CT(form_Fs_nsd(), b_so_id, a_cot_ct, ns_hdns_ma_nl_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_nl_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId);
    else { GridX_datBang(b_grctId, a_kq[1]); slide_P_SOTRANG(b_slidectId); }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_ma_nhom = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "MA_NHOM"));
    var b_ten_nhom = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten_nhom"));
    lke_P_DAT($get(b_nhomId), b_ma_nhom + '{' + b_ten_nhom);
    $get(b_gocId).value = $get(b_ma).value;
}
function ns_hdns_ma_nl_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(b_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
            b_soId = form_Fs_TEN_ID(b_vungId, 'so_id'), b_gocId = form_Fs_TEN_ID(b_vungId, 'ma_nl'), b_tenId = form_Fs_TEN_ID(b_vungId, 'TEN'),
            b_nhomId = form_Fs_TEN_ID(b_vungId, 'MA_NHOM'), b_ttId = form_Fctr_TEN_DTUONG(b_vungId, 'TT'), b_ma = form_Fs_TEN_ID(b_vungId, 'ma'),
            b_slideId = $get(b_grlkeId).getAttribute('slideId'), b_slidectId = $get(b_grctId).getAttribute('slideId');
        slide_P_MOI(b_slideId), slide_P_MOI(b_slidectId);
        ns_hdns_ma_nl_P_LKE(); ns_hdns_ma_nl_moi();
    }
}
function ns_hdns_ma_nl_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_NS_HDNS_MA_NL_LKE(form_Fs_nsd(), b_dayId, a_tso, a_cot, ns_hdns_ma_nl_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_nl_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    GridX_datBang(b_grlkeId, a_kq[1]);
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
}
function ns_hdns_ma_nl_P_GENCODE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else { $get(b_ma).value = b_kq; }
}
function ns_hdns_ma_nl_moi() {
    var b_kytudau = "NL", b_tenbang = "NS_HDNS_MA_NL", b_tencot = "MA";
    hts_dungchung.Fs_AutoGenCode(b_kytudau, b_tenbang, b_tencot, ns_hdns_ma_nl_P_GENCODE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function form_dong() {
    location.reload(false);
}
function ns_hdns_ma_nl_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function ns_hdns_ma_nl_P_MAU() {
    __doPostBack('ctl00$ContentPlaceHolder1$btn_excel_mau', '');//Xuất file Excel mẫu
    //var b_btn_excel = form_Fs_VTEN_ID('', 'FileMau');
    //$get(b_btn_excel).click(); form_chay = 0;
    //return false;
}
function ns_hdns_ma_nl_FILE_IMPORT() {
    var b_tenf = '/App_form/ns/ma/file_import_hdns.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "MA_NL_IMP", "MA_NL_IMP", "Import mã năng lực"]], null);
    form_P_LOI('');
    return false;
}
function ns_hdns_ma_nl_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_hdns_ma_nl_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_hdns_ma_nl_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}
function ns_hdns_ma_nl_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
// START: Trả giá trị chọn trên lưới //       
// Tra gia tri chon cho form goi
function form_P_TRA_CHON_GRID(b_tenchon) {
    try {
        var b_kq = [];
        b_kq[0] = $get(b_gocId).value;
        b_kq[1] = $get(b_tenId).value;
        var a_kq = form_P_TRA_GTRI_GRID(b_tenchon);
        var b_nhomnl = $get(b_nhomId).value;
        var b_so_id = $get(b_soId).value;
        var b_nh_nl = form_Fs_TEN_GTRI(b_vungId, 'MA_NHOM');
        var b_so_id_ct = GridX_Fas_layGtriA(b_grctId, 'so_id_ct');
        b_kq = b_kq + "," + a_kq + "," + b_nhomnl + "," + b_nh_nl + "," + b_so_id + "," + b_so_id_ct; b_kq = Fas_ChMang(b_kq, ',');
        form_P_DONG(window.name, b_kq);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
// Tra mang gia tri theo ten
function form_P_TRA_GTRI_GRID(b_ten) {
    try {
        var a_ten = b_ten.split(','), a_kq = [];
        for (var i = 0; i < a_ten.length; i++) {
            var a_grid = a_ten[i].split(':');
            var b_gridId = form_Fs_VUNG_ID(a_grid[0]);
            var b_hang = GridX_Fi_timHangA(b_gridId);
            a_kq[i] = GridX_Fas_layGtri(b_gridId, b_hang, a_grid[1]);
        }
        return a_kq;
    }
    catch (err) { return null; }
}
// END: Trả giá trị chọn trên lưới //  