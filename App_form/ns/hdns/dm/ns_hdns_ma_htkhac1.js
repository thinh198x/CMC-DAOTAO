var b_lkeCho = 0, b_choAct = 0, b_vungId, b_grlkeId, b_slideId, b_gchuId, b_gocId, b_tenId, b_sotienId, b_hinhthucId, b_trangthaiId, b_vungHi, b_tthaiHi,
    b_drop;
function ns_hdns_ma_htkhac_P_KD() {
    b_lkeCho = setInterval('ns_hdns_ma_htkhac_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
        }
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            form_P_MOI(b_vungId, "GLX");
            ns_hdns_ma_htkhac_P_LKE();
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_gocId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_htkhac_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            $get(b_gocId).value = b_ma.value.validate_Ma();
            var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_hdns_ma_htkhac_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_hdns_ma_htkhac_P_CHUYEN_HANG(); }
            b_ten.focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_htkhac_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_hdns.Fs_NS_HDNS_MA_HTKHAC_MA(form_Fs_nsd(), b_ma, b_TrangKt, a_cot, ns_hdns_ma_htkhac_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_htkhac_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X"); else { GridX_datA(b_grlkeId, b_hang); ns_hdns_ma_htkhac_P_CHUYEN_HANG(); }
}
function ns_hdns_ma_htkhac_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    $get(b_gocId).focus();
    list_P_DAT(b_drop, 'A');
    GridX_thoiA(b_grlkeId);
    var b_kytudau = "HTK", b_tenbang = "ns_hdns_ma_htkhac", b_tencot = "MA";
    hts_dungchung.Fs_AutoGenCode(b_kytudau, b_tenbang, b_tencot, ns_hdns_ma_htkhac_P_GENCODE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_hdns_ma_htkhac_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_hdns.Fs_NS_HDNS_MA_HTKHAC_NH(form_Fs_nsd(), b_TrangKt, a_dt_ct, a_cot, ns_hdns_ma_htkhac_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_hdns_ma_htkhac_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) { GridX_datA(b_grlkeId, b_hang); ns_hdns_ma_htkhac_P_CHUYEN_HANG(); }
        $get(b_gocId).focus();
        form_P_LOI("loi:Ghi thành công!:loi");
    }
    return false;
}
function ns_hdns_ma_htkhac_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    if (b_ma == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); ns_hdns_ma_htkhac_P_MOI(); }
    else {
        if (b_ma == 'HTK001' || b_ma == 'HTK002' || b_ma == 'HTK003' || b_ma == 'HTK004') { form_P_LOI('loi:Không thể xóa phụ cấp này:loi'); return false; }


        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_NS_HDNS_MA_HTKHAC_XOA(form_Fs_nsd(), b_ma, a_tso, a_cot, ns_hdns_ma_htkhac_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_hdns_ma_htkhac_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
        var b_dong = GridX_Fi_hangSo(b_grlkeId);
        if (b_hang > b_dong) b_hang = b_dong;
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_hdns_ma_htkhac_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_hdns_ma_htkhac_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
}
function ns_hdns_ma_htkhac_GR_lke_RowChange() {
    if (b_choAct != 0) clearTimeout(b_choAct);
    b_choAct = setTimeout("ns_hdns_ma_htkhac_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_hdns_ma_htkhac_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        if (b_ma == "") {
            form_P_MOI(b_vungId, "XGL");
            list_P_DAT(b_drop, 'A');
            var b_kytudau = "HTK", b_tenbang = "ns_hdns_ma_htkhac", b_tencot = "MA";
            hts_dungchung.Fs_AutoGenCode(b_kytudau, b_tenbang, b_tencot, ns_hdns_ma_htkhac_P_GENCODE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else form_P_GridX_TEXT(b_vungId, b_grlkeId);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_htkhac_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(b_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_vungHi = form_Fs_VUNG_ID('UPa_hi');
        b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'), b_tenId = form_Fs_TEN_ID(b_vungId, 'TEN'), b_sotienId = form_Fs_TEN_ID(b_vungId, 'SOTIEN');
        b_hinhthucId = form_Fs_TEN_ID(b_vungId, 'HINHTHUC'), b_trangthaiId = form_Fs_TEN_ID(b_vungId, 'trangthai'),
            b_gchuId = form_Fs_VTEN_ID('', 'gchu'); b_slideId = b_grlkeId + '_slide_ctrdivL'; slide_P_MOI(b_slideId);
        b_drop = form_Fctr_TEN_DTUONG(b_vungId, 'trangthai');
        ns_hdns_ma_htkhac_P_LKE();
    }
}
function ns_hdns_ma_htkhac_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_NS_HDNS_MA_HTKHAC_LKE(form_Fs_nsd(), a_tso, a_cot, ns_hdns_ma_htkhac_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_htkhac_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_hdns_ma_htkhac_P_EXCEL() {
    __doPostBack('ctl00$ContentPlaceHolder1$Nhap2', '');
}
function ns_hdns_ma_htkhac_P_GENCODE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        $get(b_gocId).value = b_kq;
    }
}

function form_P_TRA_CHON_GRID(b_ten) {
    try {

        var b_grid = $get(b_grlkeId);
        var b_tbo = b_grid.getElementsByTagName('tbody')[0];
        var b_c = b_tbo.rows.length - 1;
        var b_chon = '';
        var b_kq = [], a_kq = [];
        b_kq[0] = "CMC-1M";
        var f = 1;
        b_r = b_tbo.rows[1].cloneNode(true);
        for (var i = b_c; i > 0; i--) {
            b_chon = GridX_Fb_hangChon(b_grlkeId, i);
            if (b_chon == true) {
                b_kq[f] = form_P_TRA_GTRI_GRID(b_ten, i);
                f++;
            }
        }
        var b_l = b_kq.length;
        if (b_l == 2) {
            a_kq = b_kq[1];
            form_P_DONG(window.name, a_kq);
        }
        else {
            b_kq[0] = "CMC-2M";
            form_P_DONG(window.name, b_kq);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
// Tra mang gia tri theo ten
function form_P_TRA_GTRI_GRID(b_ten, b_hang) {
    try {
        var a_ten = b_ten.split(','), a_kq = [];
        for (var i = 0; i < a_ten.length; i++) {
            var a_grid = a_ten[i].split(':');
            var b_gridId = form_Fs_VUNG_ID(a_grid[0]);
            a_kq[i] = GridX_Fas_layGtri(b_gridId, b_hang, a_grid[1]);
        }
        return a_kq;
    }
    catch (err) { return null; }
}
function form_dong() {
    location.reload(false);
}