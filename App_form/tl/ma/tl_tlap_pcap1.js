var tl_tlap_pcap_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_lngId, b_luudayId = '';
function tl_tlap_pcap_P_KD() {
    tl_tlap_pcap_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'MA');
    b_slideId = b_grlkeId + '_slide';
    tl_tlap_pcap_lkeCho = setInterval('tl_tlap_pcap_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
            if (a_tso[0] == 'FILE_HTOAN') {
                ns_ma_taisan_P_LKE();
            }
        }
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            b_luudayId = b_kq;
            tl_tlap_pcap_P_LKE();
        }

    }
    catch (err) { form_P_LOI(err); }
}
function tl_tlap_pcap_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "MA", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); tl_tlap_pcap_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); tl_tlap_pcap_P_CHUYEN_HANG(); }
        }
    }
    catch (err) { form_P_LOI(err); }
}

function tl_tlap_pcap_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            stl_ma.Fs_TL_TLAP_PCAP_MA(b_ma, b_TrangKt, a_cot, tl_tlap_pcap_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function tl_tlap_pcap_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) { form_P_MOI(b_vungId, "X"); GridX_datTrang(b_grctId); }
    else { GridX_datA(b_grlkeId, b_hang); tl_tlap_pcap_P_CHUYEN_HANG(); }
}
var tl_tlap_pcap_choAct = 0;
function tl_tlap_pcap_GR_lke_RowChange() {
    if (tl_tlap_pcap_choAct != 0) clearTimeout(tl_tlap_pcap_choAct);
    tl_tlap_pcap_choAct = setTimeout("tl_tlap_pcap_P_CHUYEN_HANG()", 300);
    return false;
}

function tl_tlap_pcap_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(tl_tlap_pcap_lkeCho); tl_tlap_pcap_P_LKE(); }
}
function tl_tlap_pcap_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    var b_kytudau = "PC", b_tenbang = "NS_TL_TLAP_PCAP", b_tencot = "MA";
    hts_dungchung.Fs_AutoGenCode(b_kytudau, b_tenbang, b_tencot, tl_tlap_pcap_P_GENCODE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_gocId).focus();
    return false;
}
function tl_tlap_pcap_P_GENCODE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        $get(b_gocId).value = b_kq;
    }
}

function tl_tlap_pcap_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_day = b_luudayId;
        stl_ma.Fs_TL_TLAP_PCAP_LKE(a_cot, a_tso,b_day, tl_tlap_pcap_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function tl_tlap_pcap_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function tl_tlap_pcap_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        if (b_ma == "") form_P_MOI(b_vungId, "XGL"); else form_P_GridX_TEXT(b_vungId, b_grlkeId);
    }
    catch (err) { form_P_LOI(err); }
}

function tl_tlap_pcap_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_ngay = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ngay"));
        GridX_datBang(b_grctId, b_kq); $get(b_gocId).value = b_ngay;
        GridX_datA(b_grctId, 1);
    }
}

function tl_tlap_pcap_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
    stl_ma.Fs_TL_TLAP_PCAP_NH(b_TrangKt, a_dt_ct,  a_cot_lke, tl_tlap_pcap_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function tl_tlap_pcap_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI('loi:Nhập thành công:loi');
    }
    return false;
}

function tl_tlap_pcap_P_XOA() {
    var r = confirm("Bạn có chắc chắn xóa không?");
    if (r == false) {
        return false;
    }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    if (b_ma == "") tl_tlap_pcap_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_ma.Fs_TL_TLAP_PCAP_XOA(b_ma, a_tso, a_cot, tl_tlap_pcap_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function tl_tlap_pcap_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) tl_tlap_pcap_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); tl_tlap_pcap_P_CHUYEN_HANG(); }
    }
}

// START: Trả giá trị chọn trên lưới //       
// Tra gia tri chon cho form goi
function form_P_TRA_CHON_GRID(b_ten) {
    try {
        var a_kq = form_P_TRA_GTRI_GRID(b_ten);
        form_P_DONG(window.name, a_kq);
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

function form_dong() {
    location.reload(false);
}