var ns_td_kh_dieuchuyenbonhiem_lkeCho,
    b_vungId,
    b_vungtkId,
    b_grlkeId,
    b_grctId,
    b_slideId,
    b_donviId,
    b_donvi_tkId,
    b_banId,
    b_bantkId,
    b_phongId,
    b_phongtkId,
    b_cdanhId,
    b_cdanhtkId,
    b_bophanId,
    b_tonhomId,
    b_lngId,
    b_namId,
    b_namtkId,
    ns_td_kh_dieuchuyenbonhiem_choAct,
    b_choAct = 0,
    b_fdtuong,
    a_ftso,
    b_fcho = 'C',
    b_ctyId,
    b_ctyValue,
    b_ctrbeforId;

function ns_td_kh_dieuchuyenbonhiem_P_KD() {
    ns_td_kh_dieuchuyenbonhiem_lkeCho, ns_td_kh_dieuchuyenbonhiem_choAct = 0,
        b_vungId = form_Fs_VUNG_ID('UPa_ct'),
        b_vungtkId = form_Fs_VUNG_ID('Upa_tk'),
        b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_grctId = form_Fs_VUNG_ID('GR_ct'),
        b_donviId = form_Fs_TEN_ID(b_vungId, 'donvi_ct'),
        b_donvi_tkId = form_Fs_TEN_ID(b_vungtkId, 'donvi_tk'),
        b_banId = form_Fs_TEN_ID(b_vungId, 'ban_ct'),
        b_bantkId = form_Fs_TEN_ID(b_vungtkId, 'ban_tk'),
        b_phongId = form_Fs_TEN_ID(b_vungId, 'phong_ct'),
        b_phongtkId = form_Fs_TEN_ID(b_vungtkId, 'phong_tk'),
        b_bophanId = form_Fs_TEN_ID(b_vungId, 'bophan_ct'),
        b_tonhomId = form_Fs_TEN_ID(b_vungId, 'tonhom_ct'),
        b_namId = form_Fs_TEN_ID(b_vungId, 'nam_ct'),
        b_namtkId = form_Fs_TEN_ID(b_vungtkId, 'nam_tk'),
        //b_dieuchuyenbonhiem_tkId = form_Fs_TEN_ID(b_vungtkId, 'dieuchuyenbonhiem_tk');
        b_so_idId = form_Fs_VTEN_ID('UPa_hidden', 'so_id');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_slideId = b_grlkeId + '_slide';
    lke_P_DAT($get(b_donvi_tkId), 'TATCA' + '{' + 'Tất cả');
    ns_td_kh_dieuchuyenbonhiem_lkeCho = setInterval('ns_td_kh_dieuchuyenbonhiem_P_LKE_CHO()', 200);
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "" || a_tso[0] == "FILE_HTOAN") return;
        b_dtuong = b_dtuong.toUpperCase();
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();

        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("TAI_IMPORT") >= 0) {
            ns_td_kh_dieuchuyenbonhiem_P_LKE('M');
        }
    }
    catch (err) { form_P_LOI(err); }
}

function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}

function ns_td_kh_dieuchuyenbonhiem_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "NAM": b_maId = b_namctId; form_P_MOI("", "XL"); GridX_datTrang(b_grctId); break;
        }
        var b_ma = $get(b_maId);
        b_mt = b_maTen;
        if (b_ma == null || C_NVL(b_ma.value) == "") return;

    }
    catch (err) { form_P_LOI(err); }
}
// Nhập
function ns_td_kh_dieuchuyenbonhiem_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_datTrang(b_grctId);
    GridX_thoiA(b_grlkeId);
    $get(b_namId).focus();
    $get(b_so_idId).value = "";
    return false;
}

function ns_td_kh_dieuchuyenbonhiem_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }

        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        var b_trangthaipd = GridX_Fas_layGtri(b_grlkeId, b_hang, "trangthai_pd");
        if (b_trangthaipd == '1' || b_trangthaipd == '2') {
            form_P_LOI("loi:Đề xuất đã qua phê duyệt, bạn không thể sửa:loi"); return false;
        }
        var a_gt_hd = GridX_Fdt_cotGtri(b_grhdId), a_cot_hd = GridX_Fas_tenCot(b_grhdId);
        var b_nam = $get(b_namtkId).value, b_phong = lke_Fs_TRA($get(b_phongtkId));
        sns_td.Fs_NS_TD_DCBN_NH(form_Fs_nsd(), b_so_id, b_nam, b_ctyValue, b_TrangKt, a_dt_ct, a_gt_hd, a_cot_lke, a_cot_hd, ns_td_kh_dieuchuyenbonhiem_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { throw (err); }
}

function ns_td_kh_dieuchuyenbonhiem_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI('loi:Nhập thành công:loi');
        ns_td_kh_dieuchuyenbonhiem_P_CHUYEN_HANG();
    }
    return false;
}

// Xóa
function ns_td_kh_dieuchuyenbonhiem_P_XOA() {

    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_hang < 1 || b_so_id == "") { form_P_LOI("loi:Chọn bản ghi để xóa.:loi"); return false; }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_donvi_tk = lke_Fs_TRA($get(b_donvi_tkId)), b_nam_tk = $get(b_nam_tkId).value;
        sns_td.Fs_NS_TD_KH_DCBN_XOA(form_Fs_nsd(), b_so_id, b_nam_tk, b_ctyValue, a_tso, a_cot, ns_td_kh_dieuchuyenbonhiem_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}

function ns_td_kh_dieuchuyenbonhiem_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI("loi:Xóa thành công!:loi");
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_td_kh_dieuchuyenbonhiem_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_td_kh_dieuchuyenbonhiem_P_CHUYEN_HANG(); }
    }
}

// Chuyển hàng
function ns_td_kh_dieuchuyenbonhiem_GR_lke_RowChange() {
    if (ns_td_kh_dieuchuyenbonhiem_choAct != 0) clearTimeout(ns_td_kh_dieuchuyenbonhiem_choAct);
    ns_td_kh_dieuchuyenbonhiem_choAct = setTimeout("ns_td_kh_dieuchuyenbonhiem_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_td_kh_dieuchuyenbonhiem_P_CHUYEN_HANG() {
    try {
        form_P_MOI(b_vungId, "GXL");
        GridX_datTrang(b_grctId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")),
            a_cot = GridX_Fas_tenCot(b_grctId);
        if (b_so_id == "") { form_P_MOI(b_vungId, "XGL"); GridX_datTrang(b_grctId); }
        else sns_td.Fs_NS_TD_KH_NAM_CT(form_Fs_nsd(), b_so_id, a_cot, ns_td_kh_dieuchuyenbonhiem_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        $get(b_so_idId).value = b_so_id;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_td_kh_dieuchuyenbonhiem_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_dieuchuyenbonhiem = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "dieuchuyenbonhiem")), b_ten_donvi = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten_donvi")),
            b_donvi = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "donvi"));
        $get(b_gocId).value = b_dieuchuyenbonhiem; lke_P_DAT($get(b_donviId), b_donvi + '{' + b_ten_donvi);
        GridX_datBang2(b_grctId, b_kq), GridX_datA(b_grctId, 1);
    }
}

function ns_td_kh_dieuchuyenbonhiem_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grctId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        b_mt = b_cot;
        if (b_value != "") {
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_td_kh_dieuchuyenbonhiem_P_DatGchu(b_kq) {
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
function ns_td_kh_dieuchuyenbonhiem_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (ns_td_kh_dieuchuyenbonhiem_lkeCho != 0) clearTimeout(ns_td_kh_dieuchuyenbonhiem_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        form_F_GOC().P_MENUBf(window.name, 'M');
        b_ctyValue = "TATCA";
        ns_td_kh_dieuchuyenbonhiem_P_LKE('K');
    }
}

function ns_td_kh_dieuchuyenbonhiem_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_donvi_tk = lke_Fs_TRA($get(b_donvi_tkId)), b_nam_tk = $get(b_namtkId).value;
        sns_td.Fs_NS_TD_KH_DCBN_LKE(form_Fs_nsd(), b_nam_tk, b_ctyValue, a_tso, a_cot, ns_td_kh_dieuchuyenbonhiem_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_td_kh_dieuchuyenbonhiem_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang2(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}

// Lấy dữ liệu theo phòng ban
function ns_td_kh_dieuchuyenbonhiem_P_BY_PHONG() {
    try {
        var b_dieuchuyenbonhiem = $get(b_gocId).value, b_congty = lke_Fs_TRA($get(b_donviId)), a_cot = GridX_Fas_tenCot(b_grctId);
        if (b_dieuchuyenbonhiem == "" || b_congty == "") { GridX_datTrang(b_grctId); }
        else sns_td.Fs_NS_TD_KH_NAM_BY_PHONG(form_Fs_nsd(), b_dieuchuyenbonhiem, b_congty, a_cot, ns_td_kh_dieuchuyenbonhiem_P_BY_PHONG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function ns_td_kh_dieuchuyenbonhiem_P_BY_PHONG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        $get(b_so_idId).value = a_kq[0];
        GridX_datBang2(b_grctId, a_kq[1]), GridX_datA(b_grctId, 1);
    }
}

// lấy phòng ban theo công ty
function ns_phong_P_LIST(b_ctrId, b_kieu, b_vtri) {
    try {
        var b_ma_cty = lke_Fs_TRA($get(b_donviId));
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
        var b_ma_phong = C_NVL(GridX_Fas_layGtriA(b_grctId, 'PHONG_CT'));
        if (b_ma_phong != "") {
            var a_tso = lke_Fa_TSO(b_kieu);
            hts_dungchung.Fs_PHONG_LEVEL_DR_KN(form_Fs_nsd(), "3", b_ma_phong, a_tso[3], form_LIST_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}

// lấy cấp bậc theo chức danh
function ns_capbac_P_LIST(b_ctrId, b_kieu, b_vtri) {
    try {
        var b_ma_cty = lke_Fs_TRA($get(b_donviId));
        var b_ma_cdanh = C_NVL(GridX_Fas_layGtriA(b_grctId, 'CDANH'));
        if (b_ma_cdanh != "") {
            var a_tso = lke_Fa_TSO(b_kieu);
            sns_td.Fs_NHOM_CD_KH_NAM(form_Fs_nsd(), b_ma_cty, a_tso[3], form_LIST_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}

function ns_td_kh_dieuchuyenbonhiem_Import() {
    var b_tenf = '/App_form/ns/ma/file_Import.aspx';
    form_P_MO(b_tenf, window.dieuchuyenbonhieme + ',THAMSO', ['THAMSO', [window.dieuchuyenbonhieme, 'NS_TD_KH_NAM', null, "Import kế hoạch tuyển dụng năm"]], null);
    form_P_LOI('');
    return false;
}

function ns_td_dx_P_LAY_CANTUYEN(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        if (b_cot == "PHONG" || b_cot == "CDANH" || b_cot == "BAN" || b_cot == "CAPBAC") {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            var b_phong = C_NVL(GridX_Fas_layGtriA(b_grctId, 'PHONG')), b_cdanh = C_NVL(GridX_Fas_layGtriA(b_grctId, 'CDANH')), b_dieuchuyenbonhiem = $get(b_gocId).value;
            if (b_phong == "") b_phong = C_NVL(GridX_Fas_layGtriA(b_grctId, 'BAN'));
            if (b_phong != "" && b_cdanh != "" && b_dieuchuyenbonhiem != "") {
                sns_td.Fs_NS_TD_LAY_DINHBIEN(b_phong, b_cdanh, b_dieuchuyenbonhiem, ns_td_dx_P_LAY_DINHBIEN_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
    }
    catch (err) { form_P_LOI(err); }
    return false;
}

function ns_td_dx_P_LAY_DINHBIEN_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq != "") {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grctId);
        if (a_kq.length > 0) {
            GridX_datGtri(b_grctId, b_hang, ["sl_cantuyen"], a_kq[0], 'K');
        }
    }
    return false;
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
        b_ctyValue = a_tso[2];
        ns_td_kh_dieuchuyenbonhiem_P_LKE('K'); return false;
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

function ns_td_dchuyen_bnhiem_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_t = b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            //case "MA": b_maId = b_madxId; break;
            case "NAM_TK": b_maId = b_dieuchuyenbonhiemId; break;
            case "DONVI_TK": b_ma = form_Fs_TEN_GTRI(b_vungtkId, 'donvi_tk'); break;
            case "BAN_TK": b_ma = form_Fs_TEN_GTRI(b_vungtkId, 'ban_tk'); break;
            case "PHONG_TK": b_ma = form_Fs_TEN_GTRI(b_vungtkId, 'phong_tk'); break;
            case "CDANH_TK": b_ma = form_Fs_TEN_GTRI(b_vungtkId, 'cdanh_tk'); break;
            //case "BOPHAN_TK": b_ma = form_Fs_TEN_GTRI(b_vungId, 'bophan_ct'); break;
            //case "TONHOM_TK": b_ma = form_Fs_TEN_GTRI(b_vungId, 'tonhom_ct'); break;
            //case "KEHOACH_NAM": b_ma = b_kehoach_dieuchuyenbonhiemId; break;

        }
        if (b_maTen == "DONVI_TK" || b_maTen == "BAN_TK" || b_maTen == "PHONG_TK" || b_maTen == "NAM_TK") {
            var b_donvi = lke_Fs_TRA($get(b_donvi_tkId)), b_ban = lke_Fs_TRA($get(b_bantkId)), b_phong = lke_Fs_TRA($get(b_phongtkId)), b_nam = $get(b_namtkId).value;
            sns_td.Fs_NS_TD_KH_DCBN_BY_PHONG(form_Fs_nsd(), ns_td_kh_dieuchuyenbonhiem_P_TONG_DBIEN_KQ, b_donvi, P_LOI_CSDL, P_LOI_TGIAN);
        }
        if (b_maTen == "DONVI_TK") {
            var b_cty = form_Fs_TEN_GTRI(b_vungtkId, 'donvi_tk');
            var b_kq = "{";
            lke_P_DAT($get(form_Fs_TEN_ID(b_vungtkId, 'BAN_TK')), b_kq);
            lke_P_DAT($get(form_Fs_TEN_ID(b_vungtkId, 'PHONG_TK')), b_kq);
            hts_dungchung.Fs_PHONG_LEVEL_DR(2, b_cty, 'DT_BAN', 'ns_td_kh_dieuchuyenbonhiem', ns_td_dieuchuyenbonhiem_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        } else if (b_maTen == "BAN_TK") {
            var b_kq = "{";
            lke_P_DAT($get(form_Fs_TEN_ID(b_vungb_vungtkIdId, 'PHONG_TK')), b_kq);
            var b_ban = form_Fs_TEN_GTRI(b_vungtkId, 'BAN_TK');
            hts_dungchung.Fs_PHONG_LEVEL_DR(3, b_ban, 'DT_PHONG', 'ns_td_kh_dieuchuyenbonhiem', ns_td_dieuchuyenbonhiem_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            hts_dungchung.Fs_NS_CB_PHONG_CDANH('ns_td_kh_dieuchuyenbonhiem', b_ban);
        } else if (b_maTen == "PHONG_TK") {
            var b_kq = "{";
            lke_P_DAT($get(form_Fs_TEN_ID(b_vungtkId, 'cdanh_ct')), b_kq);
            var b_phongban = form_Fs_TEN_GTRI(b_vungtkId, 'PHONG_TK');
            if (b_phongban != '')
                hts_dungchung.Fs_NS_CB_PHONG_CDANH('ns_td_kh_dieuchuyenbonhiem', b_phongban, ns_td_dieuchuyenbonhiem_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            hts_dungchung.Fs_NS_CB_PHONG_CDANH('ns_td_kh_dieuchuyenbonhiem', b_phongban);
        } else if (b_maTen == "CDANH_TK" || b_maTen == "NAM_TK") {
            var b_cdanh = form_Fs_TEN_GTRI(b_vungtkId, 'cdanh_tk');
            var b_dieuchuyenbonhiem = form_Fs_TEN_GTRI(b_vungtkId, 'nam_tk')
            if (b_cdanh != '' && b_dieuchuyenbonhiem != '') {
                sns_td.Fs_HDNS_DBIEN_BY_CDANH(form_Fs_nsd(), b_dieuchuyenbonhiem, b_cdanh, ns_td_dieuchuyenbonhiem_P_NS_HIENTAI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
        } else if (b_maTen == "KEHOACH_NAM") {
            var b_ma_kh = lke_Fs_TRA($get(b_kehoach_dieuchuyenbonhiemId));
            if (b_ma_kh != '') {
                sns_td.Fs_TD_KH_NAM_BY_ID(form_Fs_nsd(), b_ma_kh, ns_td_dieuchuyenbonhiem_KEHOACH_NAM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        var b_ma = $get(b_maId);

    }
    catch (err) { form_P_LOI(err); }
}

function ns_td_dchuyen_bnhiem_P_KTRA_CT(b_maTen) {
    try {
        var b_maId = "";
        b_t = b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            //case "MA": b_maId = b_madxId; break;
            case "NAM_CT": b_maId = b_dieuchuyenbonhiemId; break;
            case "DONVI_CT": b_ma = form_Fs_TEN_GTRI(b_vungId, 'donvi_ct'); break;
            case "BAN_CT": b_ma = form_Fs_TEN_GTRI(b_vungId, 'ban_ct'); break;
            case "PHONG_CT": b_ma = form_Fs_TEN_GTRI(b_vungId, 'phong_ct'); break;
            case "CDANH_CT": b_ma = form_Fs_TEN_GTRI(b_vungId, 'cdanh_ct'); break;
            case "BOPHAN_CT": b_ma = form_Fs_TEN_GTRI(b_vungId, 'bophan_ct'); break;
            case "TONHOM_CT": b_ma = form_Fs_TEN_GTRI(b_vungId, 'tonhom_ct'); break;
            //case "KEHOACH_NAM": b_ma = b_kehoach_dieuchuyenbonhiemId; break;

        }
        if (b_maTen == "DONVI_CT" || b_maTen == "BAN_CT" || b_maTen == "PHONG_CT" || b_maTen == "NAM_CT") {
            var b_donvi = lke_Fs_TRA($get(b_donviId)), b_ban = lke_Fs_TRA($get(b_banId)), b_phong = lke_Fs_TRA($get(b_phongId)), b_nam = $get(b_namId).value;
            sns_td.Fs_NS_TD_KH_DCBN_BY_PHONG(form_Fs_nsd(), ns_td_kh_dieuchuyenbonhiem_P_TONG_DBIEN_KQ, b_donvi, P_LOI_CSDL, P_LOI_TGIAN);
        }
        if (b_maTen == "DONVI_CT") {
            var b_cty = form_Fs_TEN_GTRI(b_vungId, 'donvi_ct');
            var b_kq = "{";
            lke_P_DAT($get(form_Fs_TEN_ID(b_vungId, 'BAN_CT')), b_kq);
            lke_P_DAT($get(form_Fs_TEN_ID(b_vungId, 'PHONG_CT')), b_kq);
            hts_dungchung.Fs_PHONG_LEVEL_DR(2, b_cty, 'DT_BAN', 'ns_td_kh_dieuchuyenbonhiem', ns_td_dieuchuyenbonhiem_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        } else if (b_maTen == "BAN_CT") {
            var b_kq = "{";
            lke_P_DAT($get(form_Fs_TEN_ID(b_vungId, 'PHONG_CT')), b_kq);
            var b_ban = form_Fs_TEN_GTRI(b_vungId, 'BAN_CT');
            hts_dungchung.Fs_PHONG_LEVEL_DR(3, b_ban, 'DT_PHONG', 'ns_td_kh_dieuchuyenbonhiem', ns_td_dieuchuyenbonhiem_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            hts_dungchung.Fs_NS_CB_PHONG_CDANH('ns_td_kh_dieuchuyenbonhiem', b_ban);
        } else if (b_maTen == "PHONG_CT") {
            var b_kq = "{";
            lke_P_DAT($get(form_Fs_TEN_ID(b_vungId, 'cdanh_ct')), b_kq);
            var b_phongban = form_Fs_TEN_GTRI(b_vungId, 'PHONG_CT');
            if (b_phongban != '')
                hts_dungchung.Fs_NS_CB_PHONG_CDANH('ns_td_kh_dieuchuyenbonhiem', b_phongban, ns_td_dieuchuyenbonhiem_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            hts_dungchung.Fs_NS_CB_PHONG_CDANH('ns_td_kh_dieuchuyenbonhiem', b_phongban);
        } else if (b_maTen == "CDANH_CT" || b_maTen == "NAM_CT") {
            var b_cdanh = form_Fs_TEN_GTRI(b_vungId, 'cdanh_ct');
            var b_dieuchuyenbonhiem = form_Fs_TEN_GTRI(b_vungId, 'nam_ct')
            if (b_cdanh != '' && b_dieuchuyenbonhiem != '') {
                sns_td.Fs_HDNS_DBIEN_BY_CDANH(form_Fs_nsd(), b_dieuchuyenbonhiem, b_cdanh, ns_td_dieuchuyenbonhiem_P_NS_HIENTAI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
        } else if (b_maTen == "KEHOACH_NAM") {
            var b_ma_kh = lke_Fs_TRA($get(b_kehoach_dieuchuyenbonhiemId));
            if (b_ma_kh != '') {
                sns_td.Fs_TD_KH_NAM_BY_ID(form_Fs_nsd(), b_ma_kh, ns_td_dieuchuyenbonhiem_KEHOACH_NAM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        var b_ma = $get(b_maId);

    }
    catch (err) { form_P_LOI(err); }
}

function ns_td_dieuchuyenbonhiem_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
    }
}

function ns_td_dieuchuyenbonhiem_P_NS_HIENTAI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    $get(b_ns_hientaiId).value = a_kq[0];
}

function ns_td_kh_dieuchuyenbonhiem_P_TONG_DBIEN_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    $get(b_db_duocduyetId).value = CSO_SO(a_kq[0]);
}

// Phân trang bên phía Grid tìm kiếm 
function ns_ds_den_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId),
            a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_nam = $get(b_namtkId).value,
            b_phong = lke_Fs_TRA($get(b_phongtkId));
        sns_td.Fs_NS_TD_DCBN_LKE(form_Fs_nsd(), b_nam, b_ctyValue, a_tso, a_cot, ns_td_dieuchuyenbonhiem_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) {
        form_P_LOI(err);
    }
}

function ns_td_dieuchuyenbonhiem_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq); return;
    }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}

// lấy chức danh theo bộ phận hoặc phòng ban
function ns_cdanh_P_LIST(b_ctrId, b_kieu, b_vtri) {
    try {
        var b_congty = C_NVL(GridX_Fas_layGtriA(b_grctId, 'DONVI_CT')), b_ma_bophan = C_NVL(GridX_Fas_layGtriA(b_grctId, 'BOPHAN_CT'));
        if (b_ma_bophan == "") b_ma_bophan = C_NVL(GridX_Fas_layGtriA(b_grctId, 'PHONG_CT'));
        if (b_ma_bophan != '') {
            var a_tso = lke_Fa_TSO(b_kieu);
            hts_dungchung.Fs_NS_CB_PHONG_CDANH_KN(form_Fs_nsd(), b_congty, b_ma_bophan, a_tso[3], form_LIST_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}