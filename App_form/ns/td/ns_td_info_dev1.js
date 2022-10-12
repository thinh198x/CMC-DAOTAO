var ns_td_info_dev_lkeCho,
    b_vungId,
    b_vungtkId,
    b_grlkeId,
    b_slideId,
    b_donviId,
    b_donvi_tkId,
    b_lngId,
    ns_td_info_dev_choAct,
    b_choAct = 0,
    b_fdtuong, a_ftso,
    b_fcho = 'C',
    b_ctyId,
    b_ctyValue,
    b_ctrbeforId,
    b_bophanId,
    b_phongtkId,
    b_phongId,
    b_cdanhtkId,
    b_cdanhId,
    b_luongtkId,
    b_ngayhltkId,
    b_so_idId,
    b_ngayhlId;
function ns_td_info_dev_P_KD() {
    ns_td_info_dev_lkeCho,

        ns_td_info_dev_choAct = 0,
        b_vungId = form_Fs_VUNG_ID('UPa_ct'),
        b_vungtkId = form_Fs_VUNG_ID('Upa_tk'),
        b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_grctId = form_Fs_VUNG_ID('GR_ct'),
        b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'),
        b_donviId = form_Fs_TEN_ID(b_vungId, 'cong_ty_ct'),
        b_phongtkId = form_Fs_TEN_ID(b_vungtkId, 'phong_tk'),
        b_phongId = form_Fs_TEN_ID(b_vungId, 'phong_ct'),
        b_bophanId = form_Fs_TEN_ID(b_vungId, 'bophan_ct')
    b_cdanhtkId = form_Fs_TEN_ID(b_vungtkId, 'cdanh_tk'),
        b_cdanhId = form_Fs_TEN_ID(b_vungId, 'cdanh_ct'),
        b_slideId = b_grlkeId + '_slide';
    ns_td_info_dev_lkeCho = setInterval('ns_td_info_dev_P_LKE_CHO()', 200);
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
            ns_td_info_dev_P_LKE('M');
        }
    }
    catch (err) { form_P_LOI(err); }
}

function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}

// Nhập
function ns_td_info_dev_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_datTrang(b_grctId);
    GridX_thoiA(b_grlkeId);
    //$get(b_phongId).focus();
    $get(b_so_idId).value = "";
    return false;
}

function ns_td_info_dev_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var b_so_id = $get(b_so_idId).value;
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId),
        a_cot = GridX_Fdt_cotGtri(b_grctId),
        b_TrangKt = GridX_Fi_hangKt(b_grlkeId),
        a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
    b_phong_tk = lke_Fs_TRA($get(b_phongtkId));
    sns_td.Fs_NS_TD_INFO_DEV_NH(form_Fs_nsd(), b_so_id, b_phong_tk, '', b_TrangKt, a_dt_ct, a_cot, a_cot_lke, ns_td_info_dev_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}

function ns_td_info_dev_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) { GridX_datA(b_grlkeId, b_hang); ns_td_info_dev_P_CHUYEN_HANG(); };
        $get(b_gocId).focus();
        form_P_LOI('loi:Nhập thành công:loi');

    }
    return false;
}
// Xóa
function ns_td_info_dev_P_XOA() {

    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_hang < 1 || b_so_id == "") {
        form_P_LOI("loi:Chọn bản ghi để xóa.:loi");
        return false;
    }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId),
            a_tso = slide_Faobj_TUDEN(b_slideId);
        ns_td_info_dev_GR_lke_RowChange()
        var b_phong_tk = lke_Fs_TRA($get(b_phongtkId)),
            b_cdanh_tk = $get(b_cdanhtkId).value;
        sns_td.Fs_NS_TD_INFO_DEV_XOA(form_Fs_nsd(), b_so_id, b_phong_tk, b_cdanh_tk, a_tso, a_cot, ns_td_info_dev_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}

function ns_td_info_dev_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI("loi:Xóa thành công!:loi");
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) {
            b_hang = b_hang - 1;
        }
        else
            b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang))
            ns_td_info_dev_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_td_info_dev_P_CHUYEN_HANG(); }
    }
}

// Chuyển hàng
function ns_td_info_dev_GR_lke_RowChange() {
    if (ns_td_info_dev_choAct != 0)
        clearTimeout(ns_td_info_dev_choAct);
    ns_td_info_dev_choAct = setTimeout("ns_td_info_dev_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_td_info_dev_P_CHUYEN_HANG() {
    try {
        form_P_MOI(b_vungId, "GXL");
        GridX_datTrang(b_grctId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1)
            return;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")),
            a_cot = GridX_Fas_tenCot(b_grctId);
        if (b_so_id == "") {
            form_P_MOI(b_vungId, "XGL"); GridX_datTrang(b_grctId);
        }
        else
            sns_td.Fs_NS_TD_INFO_DEV_CT(form_Fs_nsd(), b_so_id, a_cot, ns_td_info_dev_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        $get(b_so_idId).value = b_so_id;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_td_info_dev_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        return;
    }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        form_P_CH_TEXT(b_vungId, a_kq[1]);
        var a_kq = Fas_ChMang(b_kq, '#');
        form_P_CH_TEXT(b_vungId, a_kq[0]);
        if (a_kq[1] == "") GridX_datTrang(b_grctId); else { GridX_datBang(b_grctId, a_kq[1]); 

        //form_P_LOI("loi:Xóa thành công!:loi");
        //var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        //if (b_hang > 1) b_hang--;
        //else b_hang = GridX_Fi_hangSo(b_grlkeId);
        //slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        //GridX_datBang(b_grlkeId, a_kq[1]);
        //if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_td_info_dev_P_MOI();
        //else {
        //    GridX_datA(b_grlkeId, b_hang); ns_td_info_dev_P_CHUYEN_HANG();
        }

    }
}

function ns_td_info_dev_Update(b_event) {
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

function ns_td_info_dev_P_DatGchu(b_kq) {
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
function ns_td_info_dev_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (ns_td_info_dev_lkeCho != 0) clearTimeout(ns_td_info_dev_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        form_F_GOC().P_MENUBf(window.name, 'M');
        ns_td_info_dev_P_LKE('K');
    }
}

function ns_td_info_dev_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_phongtk = lke_Fs_TRA($get(b_phongtkId)), b_cdanhtk = $get(b_cdanhtkId).value;
        sns_td.Fs_NS_TD_INFO_DEV_LKE(form_Fs_nsd(), b_phongtk, b_cdanhtk, a_tso, a_cot, ns_td_info_dev_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }


    catch (err) { form_P_LOI(err); }
}

function ns_td_info_dev_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang2(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}

// Lấy dữ liệu theo phòng ban
function ns_td_info_dev_P_BY_PHONG() {
    try {
        var b_nam = $get(b_gocId).value, b_congty = lke_Fs_TRA($get(b_donviId)), a_cot = GridX_Fas_tenCot(b_grctId);
        if (b_nam == "" || b_congty == "") { GridX_datTrang(b_grctId); }
        else sns_td.Fs_NS_TD_INFO_DEV_BY_PHONG(form_Fs_nsd(), b_nam, b_congty, a_cot, ns_td_info_dev_P_BY_PHONG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function ns_td_info_dev_P_BY_PHONG_KQ(b_kq) {
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
        var b_ma_cty = lke_Fs_TRA($get(b_donviId).value);
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
        var b_ma_phong = C_NVL(GridX_Fas_layGtriA(b_grctId, 'BOPHAN_CT'));
        if (b_ma_phong != "") {
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
        var b_ma_cty = lke_Fs_TRA($get(b_donviId));
        var b_ma_bophan = C_NVL(GridX_Fas_layGtriA(b_grctId, 'PHONG_CT'));
        if (b_ma_bophan == "") b_ma_bophan = C_NVL(GridX_Fas_layGtriA(b_grctId, 'BOPHAN_CT'));
        if (b_ma_bophan != "") {
            var a_tso = lke_Fa_TSO(b_kieu);
            hts_dungchung.Fs_NS_CB_PHONG_CDANH_KN(form_Fs_nsd(), b_ma_cty, b_ma_bophan, a_tso[3], form_LIST_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}

// lấy cấp bậc theo chức danh
function ns_capbac_P_LIST(b_ctrId, b_kieu, b_vtri) {
    try {
        var b_ma_cty = lke_Fs_TRA($get(b_donviId));
        var b_ma_cdanh = C_NVL(GridX_Fas_layGtriA(b_grctId, 'CDANH_CT'));
        if (b_ma_cdanh != "") {
            var a_tso = lke_Fa_TSO(b_kieu);
            sns_td.Fs_NHOM_CD_INFO_DEV(form_Fs_nsd(), b_ma_cty, a_tso[3], form_LIST_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}

function ns_td_info_dev_Import() {
    var b_tenf = '/App_form/ns/ma/file_Import.aspx';
    form_P_MO(b_tenf, window.name + ',THAMSO', ['THAMSO', [window.name, 'NS_TD_INFO_DEV', null, "Import Thông tin phòng ban - ứng viên"]], null);
    form_P_LOI('');
    return false;
}

function ns_td_dx_P_LAY_CANTUYEN(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        if (b_cot == "PHONG_CT" || b_cot == "CDANH_CT") {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            var b_phong = C_NVL(GridX_Fas_layGtriA(b_grctId, 'PHONG_CT')), b_cdanh = C_NVL(GridX_Fas_layGtriA(b_grctId, 'CDANH_CT')), b_nam = $get(b_gocId).value;
            if (b_phong == "") b_phong = C_NVL(GridX_Fas_layGtriA(b_grctId, 'BOPHAN_CT'));
            if (b_phong != "" && b_cdanh != "" && b_nam != "") {
                sns_td.Fs_NS_TD_LAY_DINHBIEN(b_phong, b_cdanh, b_nam, ns_td_dx_P_LAY_DINHBIEN_KQ, P_LOI_CSDL, P_LOI_TGIAN);
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
        ns_td_info_dev_P_LKE('K'); return false;
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

function ns_td_info_dev_P_KTRA_CT(b_maTen) {
    try {
        var b_maId = "";
        b_t = b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "DONVI_CT": b_ma = form_Fs_TEN_GTRI(b_vungId, 'cong_ty_ct'); break;
            case "BAN_CT": b_ma = form_Fs_TEN_GTRI(b_vungId, 'bo_phan_ct'); break;
            case "CDANH_CT": b_ma = form_Fs_TEN_GTRI(b_vungId, 'cdanh_ct'); break;
        }
        if (b_maTen == "DONVI_CT") {
            var b_cty = form_Fs_TEN_GTRI(b_vungId, 'cong_ty_ct');
            var b_kq = "{";
            lke_P_DAT($get(form_Fs_TEN_ID('', 'bophan_ct')), b_kq);
            lke_P_DAT($get(form_Fs_TEN_ID('', 'PHONG_CT')), b_kq);
            hts_dungchung.Fdt_MA_PHONG_LKE_BY_MADVI(b_cty, 'ns_td_info_dev', 'DT_PHONG_CT');
        } else if (b_maTen == "PHONG_CT") {
            var b_kq = "{";
            lke_P_DAT($get(form_Fs_TEN_ID('', 'cdanh_ct')), b_kq);
            var b_donvi = form_Fs_TEN_GTRI(b_vungId, 'DONVI');
            var b_phongban = form_Fs_TEN_GTRI(b_vungId, 'PHONG_CT');
            hts_dungchung.Fs_NS_CB_PHONG_CDANH('ns_td_info_dev', b_phongId);
            hts_dungchung.Fdt_MA_PHONG_CHITIET(window.name, "DT_BOPHAN_CT", b_donvi, b_phongban, ns_cb_P_PHONG_CHITIET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_maTen == "CDANH_CT") {
            var b_kq = "{";
            lke_P_DAT($get(form_Fs_TEN_ID('', 'cdanh_ct')), b_kq);
            var b_cdanh = form_Fs_TEN_GTRI(b_vungId, 'cdanh_ct');
            if (b_cdanh != '')
                hts_dungchung.Fs_NHOM_CD(b_cdanh, 'DT_CDANH_CT', 'ns_td_info_dev', ns_cb_P_CDANH_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }

    }
    catch (err) { form_P_LOI(err); }
}

function ns_td_info_dev_KTRA_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
        else {
            var a_kq = Fas_ChMang(b_kq, '#');
            $get(b_phongId).value = a_kq[0];
            lke_P_DAT($get(b_khoiId), a_kq[1] + '{' + a_kq[2]);
            $get(b_ql_tt).value = a_kq[3];
            $get(b_ten_ql_tt).value = a_kq[4];

        }
    }
    catch (err) {
        alert(err);
    }
}

function ns_td_info_dev_P_NS_HIENTAI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    $get(b_ns_hientaiId).value = a_kq[0];
}

function ns_td_kh_info_dev_P_TONG_DBIEN_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    $get(b_db_duocduyetId).value = CSO_SO(a_kq[0]);
}

function ns_cb_P_PHONG_CHITIET_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq))
            form_P_LOI(b_kq);
        else {
            var a_kq = Fas_ChMang(b_kq, '#');
            $get(b_phongban_ctId).value = a_kq[0];
            lke_P_DAT($get(b_khoiId), a_kq[1] + '{' + a_kq[2]);
            $get(b_ql_tt).value = a_kq[3];
            $get(b_ten_ql_tt).value = a_kq[4];

        }
    }
    catch (err) {
        alert(err);
    }
}

function ns_cb_P_PBO_CHITIET_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq))
            form_P_LOI(b_kq);
        else {
            var a_kq = Fas_ChMang(b_kq, '#');
            $get(b_phongban_ctId).value = a_kq[0];
            lke_P_DAT($get(b_phanboId), a_kq[1] + '{' + a_kq[2]);
        }
    }
    catch (err) {
        alert(err);
    }
}

function ns_cb_P_CDANH_KTRA_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq))
            form_P_LOI(b_kq);
        else {
            var a_kq = Fas_ChMang(b_kq, '#');
            $get(b_ncdanhId).value = a_kq[0];
        }
    }
    catch (err) {
        alert(err);
    }
}