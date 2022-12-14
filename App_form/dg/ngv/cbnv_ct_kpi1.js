var cbnv_ct_kpi_lkeCho, b_vungId, b_vungtkId, b_grlkeId, b_slideId, b_gocId, b_lngId, cbnv_ct_kpi_choAct, b_namId, b_ky_dgId, b_grctId, b_grctId1,
    b_ma_nsd, b_ma, b_ten_nsd, b_choAct = 0, b_fcho = 'C';
function cbnv_ct_kpi_P_KD(b_nsd) {
    b_ma_nsd = b_nsd;
    cbnv_ct_kpi_lkeCho, cbnv_ct_kpi_choAct = 0,
    cbnv_ct_kpi_lkeCho = setInterval('cbnv_ct_kpi_P_LKE_CHO()', 200);
}
// Kiểm tra
function cbnv_ct_kpi_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_mt = b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "KY_DG": b_maId = b_ky_dgId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        else if (b_maTen == "KY_DG") {
            var b_nam = lke_Fs_TRA($get(b_namId)), b_ky_dg = lke_Fs_TRA($get(b_ky_dgId)), b_ky_dg_tk = lke_Fs_TRA($get(b_ky_dg_tkId)), b_trangthai_tk = lke_Fs_TRA($get(b_trangthai_tkId)),
            b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
            sdg.Fs_NS_DG_CBNV_KPI_CT_BY_MA(form_Fs_nsd(), b_nam, b_ky_dg, b_ma_nsd, b_ky_dg_tk, b_trangthai_tk, b_TrangKt, a_cot_lke, ns_dg_cbnv_kpi_ct_by_ma_P_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dg_cbnv_kpi_ct_by_ma_P_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else if (b_kq == "") {
        form_P_MOI(b_vungId, "XL"); var b_drop = form_Fctr_TEN_DTUONG(b_vungId, 'trangthai'); list_P_DAT(b_drop, 'CG');
        GridX_datTrang(b_grctId); GridX_datTrang(b_grctId1);
        GridX_thoiA(b_grlkeId);
        $get(b_so_idId).value = "0"; $get(b_so_idId).focus();
        ns_dg_cbnv_kpi_BY_TLAP();
        return false;
    } else {
        var b_drop = form_Fctr_TEN_DTUONG(b_vungId, 'trangthai');
        list_P_DAT(b_drop, 'CG');
        var a_kq = b_kq.split('#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) { GridX_datA(b_grlkeId, b_hang); cbnv_ct_kpi_P_CHUYEN_HANG(); }
        else form_P_MOI(b_vungId, "X");
    }
    b_fcho = 'X';
}
function ns_dg_cbnv_kpi_BY_TLAP() {
    var a_cot_ct = GridX_Fas_tenCot(b_grctId), a_cot_nl = GridX_Fas_tenCot(b_grctId1);
    var b_nam = lke_Fs_TRA($get(b_namId)), b_ky_dg = lke_Fs_TRA($get(b_ky_dgId));
    sdg.Fs_NS_DG_CBNV_KPI_BY_TLAP(form_Fs_nsd(), b_nam, b_ky_dg, b_ma_nsd, a_cot_ct, a_cot_nl, ns_dg_cbnv_kpi_BY_TLAP_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_dg_cbnv_kpi_BY_TLAP_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = b_kq.split('#');
        if (a_kq[0] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[0]);
        if (a_kq[1] == "") GridX_datTrang(b_grctId1); else GridX_datBang(b_grctId1, a_kq[1]);
        return false;
    }
}

// Mới
function cbnv_ct_kpi_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_datTrang(b_grctId); GridX_datTrang(b_grctId1);
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = "0"; $get(b_so_idId).focus();
    var b_drop = form_Fctr_TEN_DTUONG(b_vungId, 'trangthai');
    list_P_DAT(b_drop, 'CG');
    return false;
}
//Nhập
function cbnv_ct_kpi_P_NH(b_dk) {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId); var b_so_id = 0;
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt = form_Faa_TEXT_ROW(b_vungId), a_cot_ct = GridX_Fdt_cotGtri(b_grctId), a_cot_ct1 = GridX_Fdt_cotGtri(b_grctId1), a_tso = slide_Faobj_TUDEN(b_slideId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var b_hang = GridX_Fi_timHangA(b_grlkeId), b_ky_dg_tk = lke_Fs_TRA($get(b_ky_dg_tkId)), b_trangthai_tk = lke_Fs_TRA($get(b_trangthai_tkId));
            if (b_hang > 0) b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
            var b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "trangthai"));
            if (b_dk == 'DC') {
                if (b_trangthai != "1") { form_P_LOI("loi:Chỉ được điều chỉnh bản ghi đã phê duyệt:loi"); return false; }
                else
                    sdg.Fs_CBNV_CT_KPI_NH(form_Fs_nsd(), b_so_id, b_TrangKt, a_dt, a_cot_ct, a_tso, a_cot_lke, a_cot_ct1, cbnv_ct_kpi_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            } else {
                if (b_trangthai == "0" || b_trangthai == "1") { form_P_LOI("loi:Bản ghi đã gửi phê duyệt hoặc đã phê duyệt, không thể chỉnh sửa:loi"); return false; }
                sdg.Fs_CBNV_CT_KPI_NH(form_Fs_nsd(), b_so_id, b_ky_dg_tk, b_trangthai_tk, b_ma_nsd, b_TrangKt, a_dt, a_cot_ct, a_tso, a_cot_lke, a_cot_ct1, cbnv_ct_kpi_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        return false;
    }
    catch (err) { throw (err); }
}
function cbnv_ct_kpi_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        GridX_datGtriA(b_grlkeId, 'ten_trangthai', 'Chưa gửi');
        GridX_datGtriA(b_grlkeId, 'trangthai', 'CG');
        if (b_kq == "") { form_P_LOI("loi:Nhập thành công:loi"); return false; }
        var a_kq = b_kq.split('#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        form_P_LOI("loi:Nhập thành công:loi");
    }
    b_fcho = 'X';
}
// Xóa
function cbnv_ct_kpi_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI('loi:Bạn phải chọn một bản ghi để xóa :loi'); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    var b_trangthai_tk = lke_Fs_TRA($get(b_trangthai_tkId));
    var b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "trangthai"));

    if (b_so_id == "") cbnv_ct_kpi_P_MOI();
    else {
        if (b_trangthai == "0" || b_trangthai == "1") { form_P_LOI("loi:Bản ghi đã gửi phê duyệt hoặc đã phê duyệt, không thể xóa:loi"); return false; }
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_CBNV_CT_KPI_XOA(form_Fs_nsd(), b_so_id, b_ma_nsd, b_trangthai_tk, a_tso, a_cot, cbnv_ct_kpi_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function cbnv_ct_kpi_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) cbnv_ct_kpi_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); cbnv_ct_kpi_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công:loi");
    }
}
// Chuyển hàng
function cbnv_ct_kpi_GR_lke_RowChange() {
    if (cbnv_ct_kpi_choAct != 0) clearTimeout(cbnv_ct_kpi_choAct);
    cbnv_ct_kpi_choAct = setTimeout("cbnv_ct_kpi_P_CHUYEN_HANG()", 300);
    return false;
}
var b_manv, b_tennv;
function cbnv_ct_kpi_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "0" || b_so_id == "") { cbnv_ct_kpi_P_MOI(); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        var a_cot_ct1 = GridX_Fas_tenCot(b_grctId1);
        b_manv = $get(b_ma).value; b_tennv = $get(b_ten_nsd).value;
        var b_kydg = C_NVL(GridX_Fas_layGtriA(b_grlkeId, 'ky_dg'));
        var b_nam = C_NVL(GridX_Fas_layGtriA(b_grlkeId, 'nam'));
        sdg.Fs_CBNV_CT_KPI_CT(form_Fs_nsd(), b_so_id, b_ma_nsd, b_nam, b_kydg, a_cot_ct, a_cot_ct1, cbnv_ct_kpi_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        $get(b_so_idId).value = b_so_id;
    }
    return false;
}
function cbnv_ct_kpi_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        var a_kq = b_kq.split('#');
        form_P_MOI(b_vungId, "GXL");
        form_P_CH_TEXT(b_vungId, a_kq[0]);
        if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
        if (a_kq[3] == "") GridX_datTrang(b_grctId1); else GridX_datBang(b_grctId1, a_kq[3]);
        $get(b_ma).value = b_manv;
        $get(b_ten_nsd).value = b_tennv;
        b_manv = ""; b_tennv = "";
        return false;
    }
}
// Liệt kê
function cbnv_ct_kpi_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (cbnv_ct_kpi_lkeCho != 0) clearTimeout(cbnv_ct_kpi_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtkId = form_Fs_VUNG_ID('Upa_tk'),
        b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_grctId = form_Fs_VUNG_ID('GR_ct'),
        b_grctId1 = form_Fs_VUNG_ID('GR_ct1'),
        b_namId = form_Fs_TEN_ID(b_vungId, 'nam'),
        b_ky_dgId = form_Fs_TEN_ID(b_vungId, 'ky_dg'),
        b_ma = form_Fs_TEN_ID(b_vungId, 'MA'),
        b_ten_nsd = form_Fs_TEN_ID(b_vungId, 'TEN'), b_trangthaiId = form_Fs_TEN_ID(b_vungId, 'trangthai'),
        b_ky_dg_tkId = form_Fs_TEN_ID(b_vungtkId, 'ky_dg1'),
        b_so_idId = form_Fs_VTEN_ID('', 'so_id');
        b_trangthai_tkId = form_Fs_TEN_ID(b_vungtkId, 'trangthai_tk'),
        b_slideId = b_grlkeId + '_slide';
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        cbnv_ct_kpi_P_CB();
        cbnv_ct_kpi_P_LKE('K');
    }
}
function cbnv_ct_kpi_P_LKE(b_dk) {
    try {
        if (b_dk == 'C' || b_dk == 'M') slide_P_MOI(b_slideId);
        var b_trangthai_tk = lke_Fs_TRA($get(b_trangthai_tkId));
        //var b_nam_tk = lke_Fs_TRA($get(b_namId_Upa_tk));
        var b_nam_tk = "";
        b_nam_tk = CSO_SO(b_nam_tk, 0);
        var b_ky_dg_tk = lke_Fs_TRA($get(b_ky_dg_tkId));
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_CBNV_CT_KPI_LKE(form_Fs_nsd(), b_ma_nsd, b_trangthai_tk, b_ky_dg_tk, a_tso, a_cot, cbnv_ct_kpi_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);

        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function cbnv_ct_kpi_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}
//Gửi
function cbnv_ct_kpi_P_GUI() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) { form_P_LOI("loi:Chưa chọn bản ghi cần gửi:loi"); return false; }
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "") { form_P_LOI("loi:Chưa chọn bản ghi cần gửi:loi"); return false; }
        var b_so_Id = $get(b_so_idId).value, a_cot = GridX_Fas_tenCot(b_grlkeId);
        var b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "trangthai"));
        if (b_trangthai == "CG" || b_trangthai == "2")
            sdg.Fs_CBNV_CT_KPI_GUI(form_Fs_nsd(), b_so_Id, cbnv_ct_kpi_GUI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        else
            form_P_LOI("loi:Đăng ký đã được gửi hoặc phê duyệt:loi");
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function cbnv_ct_kpi_GUI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else form_P_LOI("loi:Gửi phê duyệt thành công:loi");
    cbnv_ct_kpi_P_LKE('K');
    return false;
}
//
function cbnv_ct_kpi_P_CB() {
    try {
        var b_ma_nv = b_ma_nsd;
        sdg.Fs_THONGTIN_CANBO111(b_ma_nv, cbnv_ct_kpi_P_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function cbnv_ct_kpi_P_CB_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
function cbnv_ct_kpi_P_NAM(b_dk) {
    try {
        if (b_dk == 'N') var b_nam = lke_Fs_TRA($get(b_namId));
            //if (b_dk == 'F') var b_nam = lke_Fs_TRA($get(b_namId_Upa_tk));
        else var b_nam = "";
        var ktra = "DT_KY_DG";
        sdg.Fdt_NS_DG_MA_KDG_DG_NHL(window.name, b_nam, ktra, cbnv_ct_kpi_P_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(err); }
}
function cbnv_ct_kpi_P_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_kdgId = form_Fs_TEN_ID(b_vungId, 'ky_dg');
        drop_P_LKE(b_kdgId, b_kq);
    }
}
function tieuchi_P_LIST(b_ctrId, b_kieu, b_vtri) {
    try {
        var ktra = " ";
        var b_nhom_tc = C_NVL(GridX_Fas_layGtriA(b_grctId, 'NHOM_TC'));
        if (b_nhom_tc != "") {
            var a_tso = lke_Fa_TSO(b_kieu);
            sdg.Fs_TIEUCHI(form_Fs_nsd(), b_nhom_tc, a_tso[3], window.name, ktra, form_LIST_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
var b_hang1;
function thaydoiRow() {
    try {
        b_hang1 = GridX_Fi_timHangA(b_grctId);
        var b_tieuchi = C_NVL(GridX_Fas_layGtriA(b_grctId, 'TIEUCHI'));
        var b_nhom_tc = C_NVL(GridX_Fas_layGtriA(b_grctId, 'NHOM_TC'));
        if (b_tieuchi != "" || b_nhom_tc != "") {
            GridX_datGtri(b_grctId, b_hang1, 'stt', b_hang1);
            //GridX_datGtri(b_grctId1, b_hang1, 'stt', b_hang1);
        }
        //if (b_tieuchi != "" && b_nhom_tc != "") {
        //    sdg.Fs_MOTA(form_Fs_nsd(), b_tieuchi, b_nhom_tc, thaydoiRow_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        //}
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function thaydoiRow1() {
    try {
        b_hang1 = GridX_Fi_timHangA(b_grctId1);
        var b_mota = C_NVL(GridX_Fas_layGtriA(b_grctId1, 'mota'));
        if (b_mota != "") {
            GridX_datGtri(b_grctId1, b_hang1, 'stt', b_hang1);
            //GridX_datGtri(b_grctId1, b_hang1, 'stt', b_hang1);
        }
        //if (b_tieuchi != "" && b_nhom_tc != "") {
        //    sdg.Fs_MOTA(form_Fs_nsd(), b_tieuchi, b_nhom_tc, thaydoiRow_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        //}
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function thaydoiRow_KQ(b_kq) {
    GridX_datGtri(b_grctId1, b_hang1, 'mota', b_kq);
    b_hang1 = -1;
}
function cbnv_ct_kpi_HangLen(b_dk) {
    var b_grct;
    if (b_dk == 1) b_grct = b_grctId;
    if (b_dk == 2) b_grct = b_grctId1;
    GridX_chuyenHang(b_grct, -1);
    return false;
}
function cbnv_ct_kpi_HangXuong(b_dk) {
    var b_grct;
    if (b_dk == 1) b_grct = b_grctId;
    if (b_dk == 2) b_grct = b_grctId1;
    GridX_chuyenHang(b_grct, 1);
    return false;
}
function cbnv_ct_kpi_ChenDong(b_dk) {
    var b_grct, b_ktrahten;
    if (b_dk == 'C') { b_grct = b_grctId; b_ktrahten = C_NVL(GridX_Fas_layGtriA(b_grctId, 'NHOM_TC')); }
    if (b_dk == 2) { b_grct = b_grctId1; b_ktrahten = C_NVL(GridX_Fas_layGtriA(b_grctId1, 'mota')); }
    if (b_ktrahten == '') form_P_LOI("loi:Chọn dòng dữ liệu cần chèn thêm một hàng trước nó trên bảng:loi");
    else {
        GridX_chenHang(b_grct);
    }
    return false;
}
function cbnv_ct_kpi_CatDong(b_dk) {
    var b_grct;
    if (b_dk == 1) {
        b_grct = b_grctId;
    }
    else if (b_dk == 2) {
        b_grct = b_grctId1;
    }
    else return false;
    GridX_boChon(b_grct, 'C');
    return false;
}
function form_dong() {
    location.reload(false);
}