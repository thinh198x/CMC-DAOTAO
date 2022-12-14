var ns_cdanh_kn_lkeCho, b_vungId, b_vungtkId, b_grlkeId, b_slideId, b_gocId, b_hotenId, b_phong_tkId, b_sothe_tkId, b_ten_tkId, b_lngId, ns_cdanh_kn_choAct,
    b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C', b_ctyId, b_ctyValue, b_ctrbeforId, b_ngaydId, b_ngaycId;

function ns_cdanh_kn_P_KD() {
    ns_cdanh_kn_lkeCho, ns_cdanh_kn_choAct = 0, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtkId = form_Fs_VUNG_ID('Upa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
        b_gocId = form_Fs_TEN_ID(b_vungId, 'so_the'), b_hotenId = form_Fs_TEN_ID(b_vungId, 'ho_ten'), b_ten_ctyId = form_Fs_TEN_ID(b_vungId, 'ten_cty'),
        b_ctyId = form_Fs_TEN_ID(b_vungId, 'cty'), b_ten_phongId = form_Fs_TEN_ID(b_vungId, 'ten_phong'), b_phongId = form_Fs_TEN_ID(b_vungId, 'phong'),
        b_ten_bophanId = form_Fs_TEN_ID(b_vungId, 'ten_bophan'), b_bophanId = form_Fs_TEN_ID(b_vungId, 'bophan'), b_ten_cdanhId = form_Fs_TEN_ID(b_vungId, 'ten_cdanh'),
        b_phong_tkId = form_Fs_TEN_ID(b_vungtkId, 'phong_tk'), b_sothe_tkId = form_Fs_TEN_ID(b_vungtkId, 'so_the_tk'), b_ten_tkId = form_Fs_TEN_ID(b_vungtkId, 'ten_tk'),
        b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_slideId = b_grlkeId + '_slide';
    lke_P_DAT($get(b_phong_tkId), 'TATCA' + '{' + 'Tất cả');
    ns_cdanh_kn_lkeCho = setInterval('ns_cdanh_kn_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("SO_THE") >= 0) {

            var b_hang = GridX_Fi_timHangD(b_grlkeId, "so_the", b_kq);
            if (b_hang < 0) { ns_cdanh_kn_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_cdanh_kn_P_CHUYEN_HANG(); }
            ns_thongtin_canbo(a_tso[0], "SO_THE");
        } else if (b_dtuong.indexOf("MA_PC") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang > -1) {
                GridX_datGtri(b_grctId, b_hang, "ma_pc", b_kq);
                GridX_datGtri(b_grctId, b_hang, "ten_pc", a_tso[1]);
                GridX_datGtri(b_grctId, b_hang, "giatri", a_tso[2]);
                GridX_datA(b_grctId, b_hang, "giatri");
            }
        }
    }
    catch (err) { form_P_LOI(err); }
}

function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}
function ns_cdanh_kn_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; form_P_MOI("", "XL"); GridX_datTrang(b_grctId); break;
        }
        var b_ma = $get(b_maId);
        b_mt = b_maTen;
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        else if (b_maTen == "SO_THE") {
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "so_the", b_ma.value);
            if (b_hang < 0) { ns_cdanh_kn_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_cdanh_kn_P_CHUYEN_HANG(); }
            ns_thongtin_canbo(b_ma.value, "SO_THE");
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_cdanh_kn_P_MA_KTRA() {
    try {
        var b_so_the = C_NVL($get(b_gocId).value);
        if (b_so_the != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            var b_phong_tk = lke_Fs_TRA($get(b_phong_tkId)), b_sothe_tk = $get(b_sothe_tkId).value, b_hoten_tk = $get(b_ten_tkId).value;
            sns_qt.Fs_NS_CDANH_KN_MA(b_so_the, b_ctyValue, b_sothe_tk, b_hoten_tk, b_TrangKt, a_cot, ns_cdanh_kn_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cdanh_kn_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang2(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        form_P_MOI(b_vungId, "X"); GridX_datTrang(b_grctId);
        var b_vung_grctId = form_Fs_VUNG_ID('UPa_gr');
        form_P_MOI(b_vung_grctId, "GXL");
        $get(b_so_idId).value = "0";
    }
    else { GridX_datA(b_grlkeId, b_hang); ns_cdanh_kn_P_CHUYEN_HANG(); }
}
// Nhập
function ns_cdanh_kn_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_datTrang(b_grctId);
    var b_vung_grctId = form_Fs_VUNG_ID('UPa_gr');
    form_P_MOI(b_vung_grctId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_gocId).focus();
    $get(b_so_idId).value = "0";
    return false;
}
function ns_cdanh_kn_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var ktra = ktra_ngay(parseDate($get(b_ngaydId).value).getTime(), parseDate($get(b_ngaycId).value).getTime(), 1, "Ngày hiệu lực", "ngày hết hiệu lực");
    if (ktra.length > 0) {
        ns_cdanh_kn_P_NH_KQ(ktra);
        return false;
    }
    var b_so_id = $get(b_so_idId).value;
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fdt_cotGtri(b_grctId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
    var b_phong_tk = lke_Fs_TRA($get(b_phong_tkId)), b_sothe_tk = $get(b_sothe_tkId).value, b_hoten_tk = $get(b_ten_tkId).value;
    sns_qt.Fs_NS_CDANH_KN_NH(b_so_id, b_ctyValue, b_sothe_tk, b_hoten_tk, b_TrangKt, a_dt_ct, a_cot, a_cot_lke, ns_cdanh_kn_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_cdanh_kn_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang2(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI('loi:Nhập thành công:loi');
    }
    return false;
}
// Xóa
function ns_cdanh_kn_P_XOA() {

    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_hang < 1 || b_so_id == "") { form_P_LOI("loi:Chọn bản ghi để xóa.:loi"); return false; }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_phong = lke_Fs_TRA($get(b_phong_tkId)), b_sothe = $get(b_sothe_tkId).value, b_hoten = $get(b_ten_tkId).value;
        sns_qt.Fs_NS_CDANH_KN_XOA(b_so_id, b_ctyValue, b_sothe, b_hoten, a_tso, a_cot, ns_cdanh_kn_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_cdanh_kn_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI("loi:Xóa thành công!:loi");
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang2(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_cdanh_kn_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_cdanh_kn_P_CHUYEN_HANG(); }
    }
}
// Chuyển hàng
function ns_cdanh_kn_GR_lke_RowChange() {
    if (ns_cdanh_kn_choAct != 0) clearTimeout(ns_cdanh_kn_choAct);
    ns_cdanh_kn_choAct = setTimeout("ns_cdanh_kn_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_cdanh_kn_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")),
            a_cot = GridX_Fas_tenCot(b_grctId);
        if (b_so_id == "") {
            form_P_MOI(b_vungId, "XGL");
            GridX_datTrang(b_grctId);
            var b_vung_grctId = form_Fs_VUNG_ID('UPa_gr');
            form_P_MOI(b_vung_grctId, "GXL");
        }
        else sns_qt.Fs_NS_CDANH_KN_CT(b_so_id, a_cot, ns_cdanh_kn_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        $get(b_so_idId).value = b_so_id;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cdanh_kn_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_sothe = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the")), b_hoten = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ho_ten")),
            b_ten_cty = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten_cty")), b_ten_phong = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten_phong")),
            b_ten_bophan = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten_bophan")); b_ten_cdanh = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten_cdanh"))

        $get(b_gocId).value = b_sothe, $get(b_hotenId).value = b_hoten, $get(b_ten_ctyId).value = b_ten_cty,
            $get(b_ten_phongId).value = b_ten_phong, $get(b_ten_bophanId).value = b_ten_bophan, $get(b_ten_cdanhId).value = b_ten_cdanh;

        GridX_datBang2(b_grctId, b_kq), GridX_datA(b_grctId, 1);
    }
}

function ns_cdanh_kn_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grctId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        b_mt = b_cot;
        if (b_value != "") {
            if (b_cot == "CTY") {
                b_value = lke_Fs_TRA(b_ctr);
                hts_dungchung.Fs_PHONG_LEVEL_DR(2, b_value, 'DT_PHONG', 'ns_cdanh_kn', ns_cdanh_kn_P_KTRA_DR_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
            if (b_cot == "PHONG") {

            }
            if (b_cot == "BOPHAN") {

            }
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_cdanh_kn_P_KTRA_DR_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else if (b_kq != '') {
        var a_kq = Fas_ChMang(b_kq, '#');
        GridX_datGtriA(b_grctId, 'PHONG', a_kq[0]);
        GridX_sott(b_grctId, 'bt');
    }
}
function ns_cdanh_kn_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_mt == "MAPC") {
        var b_hang = GridX_Fi_timHangA(b_grctId);
        GridX_datGtri(b_grctId, b_hang, "tenpc", b_kq);
        GridX_datA(b_grctId, b_hang, "giatri");
    }
    else if (b_mt == "SO_THE") {
        $get(b_gchuId).innerHTML = b_kq;
        GridX_datA(b_grctId, 0, "mapc");
    }
}
// Liệt kê
function ns_cdanh_kn_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (ns_cdanh_kn_lkeCho != 0) clearTimeout(ns_cdanh_kn_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        b_ngaydId = form_Fs_TEN_ID(b_grctId, 'ngay_hl'), b_ngaycId = form_Fs_TEN_ID(b_grctId, 'ngay_het_hl')
        form_F_GOC().P_MENUBf(window.name, 'M');
        vb_cctc_P_SL('', 'D', '0', ' ', ' ', 'T');
        b_ctyValue = "TATCA";
        ns_cdanh_kn_P_LKE('K');
    }
}
function ns_cdanh_kn_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_phong = lke_Fs_TRA($get(b_phong_tkId)), b_sothe = $get(b_sothe_tkId).value, b_hoten = $get(b_ten_tkId).value;
        sns_qt.Fs_NS_CDANH_KN_LKE(b_ctyValue, b_sothe, b_hoten, a_cot, a_tso, ns_cdanh_kn_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cdanh_kn_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang2(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}

function ns_thongtin_canbo(b_so_the, b_loai) {
    try {
        var b_listcotcu = "", b_listcotmoi = "";
        if (b_loai == "SO_THE") {
            b_kt_loai = "SO_THE"; b_listcotcu = "SO_THE,HO_TEN,CDANH,TEN_CDANH,PHONG,TEN_PHONG,TEN_VITRI,VITRI,DONVI,BAN,TEN_DONVI,TEN_BAN",
                //b_listcotmoi = "SO_THE,HO_TEN,CDANH,TEN_CDANH,PHONG,TEN_PHONG,TEN_VITRI,VITRI,DONVI,BAN,TEN_DONVI,TEN_BAN"
                b_listcotmoi = "SO_THE,HO_TEN,CDANH,TEN_CDANH,BOPHAN,TEN_BOPHAN,TEN_VITRI,VITRI,CTY,PHONG,TEN_CTY,TEN_PHONG"
        }
        else if (b_loai == "MA_NGUOIKY") { b_kt_loai = "MA_NGUOIKY"; b_listcotcu = "SO_THE,TEN_CDANH", b_listcotmoi = "MA_NGUOIKY,TEN_CDANH_NGUOIKY" }
        else { b_kt_loai = ""; b_listcotcu = "SO_THE,HO_TEN,TEN_CDANH,TEN_PHONG", b_listcotmoi = "SO_THE,HO_TEN,TEN_CDANH,TEN_PHONG" }
        hts_dungchung.Fs_THONGTIN_CANBO_HD(b_so_the, b_listcotcu, b_listcotmoi, ns_thongtin_canbo_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_thongtin_canbo_kq(b_kq) {
    if (b_kq == "") {
        if (b_kt_loai == "SO_THE" || b_kt_loai == "") {
            form_P_MOI(b_vungId, "GXL"); $get(b_gocId).focus(); form_P_LOI(b_kq); return false;
        } else if (b_kt_loai == "MA_NGUOIKY") {
            $get(b_ma_nguoikyId).value = ""; $get(b_ten_cdanhnkId).value = "";
        }

    }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
// lấy phòng ban theo công ty
function ns_phong_P_LIST(b_ctrId, b_kieu, b_vtri) {
    try {
        var b_ma_cty = C_NVL(GridX_Fas_layGtriA(b_grctId, 'CTY'));
        if (b_ma_cty != '') {
            var a_tso = lke_Fa_TSO(b_kieu);
            hts_dungchung.Fs_PHONG_LEVEL_DR_KN(form_Fs_nsd(), "2", b_ma_cty, a_tso[3], form_LIST_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
// lấy bộ phận theo phòng ban
function ns_bophan_P_LIST(b_ctrId, b_kieu, b_vtri) {
    try {
        var b_ma_phong = C_NVL(GridX_Fas_layGtriA(b_grctId, 'PHONG'));
        if (b_ma_phong != '') {
            var a_tso = lke_Fa_TSO(b_kieu);
            hts_dungchung.Fs_PHONG_LEVEL_DR_KN(form_Fs_nsd(), "3", b_ma_phong, a_tso[3], form_LIST_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
// lấy chức danh theo bộ phận hoặc phòng ban
function ns_cdanh_P_LIST(b_ctrId, b_kieu, b_vtri) {
    try {
        var b_congty = C_NVL(GridX_Fas_layGtriA(b_grctId, 'cty')), b_ma_bophan = C_NVL(GridX_Fas_layGtriA(b_grctId, 'BOPHAN'));
        if (b_ma_bophan == "") b_ma_bophan = C_NVL(GridX_Fas_layGtriA(b_grctId, 'PHONG'));
        if (b_ma_bophan != '') {
            var a_tso = lke_Fa_TSO(b_kieu);
            hts_dungchung.Fs_NS_CB_PHONG_CDANH_KN(form_Fs_nsd(), b_congty, b_ma_bophan, a_tso[3], form_LIST_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}

function form_dong() {
    location.reload(false);
}

function vb_cctc_P_CLICK(b_event, b_id) {
    b_event.stopPropagation();
    var b_targetClassNam = b_event.target.className;
    if (b_targetClassNam == "ico_bptt") {
        var b_ctr = $get(b_id), b_div = $get(b_id + '_Div');
        var a_tso = Attribute_Fas_LAY(b_ctr, 'loai,cap,dvi,ma,ma_ct');
        if (b_ctrbeforId != null) b_ctrbeforId.style.fontWeight = "100";
        b_ctr.style.fontWeight = "700";
        b_ctrbeforId = b_ctr;
        b_ctyValue = a_tso[3];
        ns_cdanh_kn_P_LKE('K'); return false;
    }
    else {
        var b_ctr = $get(b_id), b_div = $get(b_id + '_Div');
        var a_tso = Attribute_Fas_LAY(b_ctr, 'loai,cap,dvi,ma,ma_ct');
        if (a_tso[0] == 'A') return false;
        if (a_tso[0] != 'C') {
            if (b_div == null) vb_cctc_P_SL(b_id, a_tso[0], a_tso[1], a_tso[2], a_tso[3]);
            else {
                b_id = (C_NVL(b_div.style.display) == '') ? '' : b_id;
                vb_cctc_HIEN(a_tso[4], b_id);
            }
        }
    }
    return false;
}

function ns_cdanh_kn_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_cdanh_kn_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_cdanh_kn_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function ns_cdanh_kn_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}

// so sánh ngày 
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
function getDateNow() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();
    if (dd < 10) {
        dd = '0' + dd;
    }
    if (mm < 10) {
        mm = '0' + mm;
    }
    var datenow = dd + '/' + mm + '/' + yyyy;
    return datenow;
}