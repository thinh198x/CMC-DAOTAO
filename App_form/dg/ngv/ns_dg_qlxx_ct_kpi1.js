var ns_dg_qlxx_ct_kpi_lkeCho, b_vungId, b_vungtkId, b_grlkeId, b_slideId, b_gocId, b_lngId, ns_dg_qlxx_ct_kpi_choAct, b_namId, b_ky_dgId, b_grctId, b_grctId1,
    b_ma_nsd, b_ma, b_ten_nsd, b_choAct = 0, b_fcho = 'C';
function ns_dg_qlxx_ct_kpi_P_KD(b_nsd) {
    b_ma_nsd = b_nsd;
    ns_dg_qlxx_ct_kpi_lkeCho, ns_dg_qlxx_ct_kpi_choAct = 0,
    ns_dg_qlxx_ct_kpi_lkeCho = setInterval('ns_dg_qlxx_ct_kpi_P_LKE_CHO()', 200);
}
// Mới
function ns_dg_qlxx_ct_kpi_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    form_P_MOI(b_grctId, "GXL");
    GridX_thoiA(b_grlkeId); GridX_datTrang(b_grctId);
    $get(b_so_idId).value = "0"; $get(b_so_idId).focus();
    return false;
}
//Nhập
function ns_dg_qlxx_ct_kpi_P_NH(b_dk) {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId); var b_so_id = 0;
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt = form_Faa_TEXT_ROW(b_vungId), a_cot_ct = GridX_Fdt_cotGtri(b_grctId), a_cot_ct1 = GridX_Fdt_cotGtri(b_grctId1), a_tso = slide_Faobj_TUDEN(b_slideId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang > 0) b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
            var b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "trangthai"));
            if (b_dk == 'DC') {
                if (b_trangthai != "1") { form_P_LOI("loi:Chỉ được điều chỉnh bản ghi đã phê duyệt:loi"); return false; }
                else
                    sdg.Fs_NS_DG_QLXX_CT_KPI_NH(form_Fs_nsd(), b_so_id, b_TrangKt, a_dt, a_cot_ct, a_tso, a_cot_lke, a_cot_ct1, ns_dg_qlxx_ct_kpi_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
            else {
                if (b_trangthai == "CG" || b_trangthai == "1" || b_trangthai == "2") { form_P_LOI("loi:Bản ghi đã được gửi đi hoặc đã xem xét,không phê duyệt:loi"); return false; }
                sdg.Fs_NS_DG_QLXX_CT_KPI_NH(form_Fs_nsd(), b_so_id, b_TrangKt, a_dt, a_cot_ct, a_tso, a_cot_lke, a_cot_ct1, ns_dg_qlxx_ct_kpi_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        return false;
    }
    catch (err) { throw (err); }
}
var b_kq_gui = 1;
function ns_dg_qlxx_ct_kpi_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        GridX_datGtriA(b_grlkeId, 'ten_trangthai', 'Chưa gửi');
        if (b_kq == "") { b_kq_gui = 0; form_P_LOI("loi:Nhập thành công:loi"); return false; }
        var a_kq = b_kq.split('#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        form_P_LOI("loi:Nhập thành công:loi"); b_kq_gui = 0;
    }
    b_fcho = 'X';
}
// Xóa
function ns_dg_qlxx_ct_kpi_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI('loi:Bạn phải chọn một bản ghi để xóa :loi'); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    var b_trangthai_tk = lke_Fs_TRA($get(b_trangthai_tkId));
    if (b_so_id == "") ns_dg_qlxx_ct_kpi_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_NS_DG_QLXX_CT_KPI_XOA(form_Fs_nsd(), b_so_id, b_trangthai_tk, a_tso, a_cot, ns_dg_qlxx_ct_kpi_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_dg_qlxx_ct_kpi_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dg_qlxx_ct_kpi_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dg_qlxx_ct_kpi_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công:loi");
    }
}
// Chuyển hàng
function ns_dg_qlxx_ct_kpi_GR_lke_RowChange() {
    if (ns_dg_qlxx_ct_kpi_choAct != 0) clearTimeout(ns_dg_qlxx_ct_kpi_choAct);
    ns_dg_qlxx_ct_kpi_choAct = setTimeout("ns_dg_qlxx_ct_kpi_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_dg_qlxx_ct_kpi_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "0" || b_so_id == "") { form_P_MOI(b_vungId, "XGL"); GridX_datTrang(b_grctId); GridX_datTrang(b_grctId1); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        var a_cot_ct1 = GridX_Fas_tenCot(b_grctId1);
        var b_kydg = C_NVL(GridX_Fas_layGtriA(b_grlkeId, 'ky_dg'));
        var b_nam = C_NVL(GridX_Fas_layGtriA(b_grlkeId, 'nam'));
        sdg.Fs_NS_DG_QLXX_CT_KPI_CT(form_Fs_nsd(), b_so_id, b_ma_nsd, b_nam, b_kydg, a_cot_ct, a_cot_ct1, ns_dg_qlxx_ct_kpi_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        $get(b_so_idId).value = b_so_id;
    }
    return false;
}
function ns_dg_qlxx_ct_kpi_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        var a_kq = b_kq.split('#');
        form_P_MOI(b_vungId, "GXL");
        form_P_CH_TEXT(b_vungId, a_kq[0]);
        if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
        if (a_kq[3] == "") GridX_datTrang(b_grctId1); else GridX_datBang(b_grctId1, a_kq[3]);
        return false;
    }
}
// Liệt kê
function ns_dg_qlxx_ct_kpi_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ns_dg_qlxx_ct_kpi_lkeCho != 0) clearTimeout(ns_dg_qlxx_ct_kpi_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtkId = form_Fs_VUNG_ID('Upa_tk'),
        b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_grctId = form_Fs_VUNG_ID('GR_ct'),
        b_grctId1 = form_Fs_VUNG_ID('GR_ct1'),
        b_namId = form_Fs_TEN_ID(b_vungId, 'nam'),
        b_ky_dgId = form_Fs_TEN_ID(b_vungId, 'ky_dg'),
        b_ma = form_Fs_TEN_ID(b_vungId, 'MA'),
        b_ten_nsd = form_Fs_TEN_ID(b_vungId, 'TEN'),
        //b_namId_Upa_tk = form_Fs_TEN_ID(b_vungtkId, 'nam1'),
        b_ky_dgId_Upa_tk = form_Fs_TEN_ID(b_vungtkId, 'ky_dg1'),
        b_so_idId = form_Fs_VTEN_ID('', 'so_id');
        b_trangthai_tkId = form_Fs_TEN_ID(b_vungtkId, 'trangthai_tk'),
        b_slideId = b_grlkeId + '_slide';
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_dg_qlxx_ct_kpi_P_CB();
        ns_dg_qlxx_ct_kpi_P_LKE('K');
    }
}
function ns_dg_qlxx_ct_kpi_P_LKE(b_dk) {
    try {
        if (b_dk == 'C' || b_dk == 'M') slide_P_MOI(b_slideId);
        var b_trangthai_tk = lke_Fs_TRA($get(b_trangthai_tkId));
        //var b_nam_tk = lke_Fs_TRA($get(b_namId_Upa_tk));
        var b_nam_tk = "";
        b_nam_tk = CSO_SO(b_nam_tk, 0);
        var b_ky_dg_tk = lke_Fs_TRA($get(b_ky_dgId_Upa_tk));
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_NS_DG_QLXX_CT_KPI_LKE(form_Fs_nsd(), b_trangthai_tk, b_ky_dg_tk, a_tso, a_cot, ns_dg_qlxx_ct_kpi_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);

        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dg_qlxx_ct_kpi_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}
//Gửi
function ns_dg_qlxx_ct_kpi_P_GUI() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) { form_P_LOI("loi:Chưa chọn bản ghi cần gửi:loi"); return false; }
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "") { form_P_LOI("loi:Chưa chọn bản ghi cần gửi:loi"); return false; }
        var b_so_Id = $get(b_so_idId).value, a_cot = GridX_Fas_tenCot(b_grlkeId);
        var b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "trangthai"));
        if (b_trangthai == "CG")
            sdg.Fs_NS_DG_QLXX_CT_KPI_GUI(form_Fs_nsd(), b_so_Id, ns_dg_qlxx_ct_kpi_GUI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        else
            form_P_LOI("loi:Đăng ký đã được gửi hoặc phê duyệt:loi");
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
//Xác nhận
function ns_dg_qlxx_ct_kpi_P_XACNHAN_GUILAI(b_dk) {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) { form_P_LOI("loi:Chưa chọn bản ghi cần gửi:loi"); return false; }
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "") { form_P_LOI("loi:Chưa chọn bản ghi cần gửi:loi"); return false; }

        if (b_dk == "XN" || b_dk == "TC") {
            var b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "trangthai"));
            if (b_trangthai == 0) {
                if (b_dk == "XN") b_trangthai = 1; else b_trangthai = 2;
                //ns_dg_qlxx_ct_kpi_P_NH();
            } else { form_P_LOI("loi:Chọn đúng trạng thái phê duyệt:loi"); return false; }
            var b_so_Id = $get(b_so_idId).value, a_cot = GridX_Fas_tenCot(b_grlkeId);
            sdg.Fs_NS_DG_QLXX_CT_KPI_GUI(form_Fs_nsd(), b_so_Id, b_trangthai, ns_dg_qlxx_ct_kpi_GUI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else
            form_P_LOI("loi:Đăng ký đã được gửi hoặc phê duyệt:loi");
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dg_qlxx_ct_kpi_GUI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        if (b_kq_gui == 0) { b_kq_gui = 1; ns_dg_qlxx_ct_kpi_P_LKE('K'); }
        else
        {
            form_P_LOI("loi:Xác nhận/từ chối phê duyệt thành công:loi");
            ns_dg_qlxx_ct_kpi_P_LKE('K');
        }
    }

    return false;
}

//
function ns_dg_qlxx_ct_kpi_P_CB() {
    try {
        var b_ma_nv = b_ma_nsd;
        sdg.Fs_THONGTIN_CANBO111(b_ma_nv, ns_dg_qlxx_ct_kpi_P_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dg_qlxx_ct_kpi_P_CB_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
function ns_dg_qlxx_ct_kpi_P_NAM(b_dk) {
    try {
        if (b_dk == 'N') var b_nam = lke_Fs_TRA($get(b_namId));
            //if (b_dk == 'F') var b_nam = lke_Fs_TRA($get(b_namId_Upa_tk));
        else var b_nam = "";
        var ktra = "DT_KY_DG";
        sdg.Fdt_NS_DG_MA_KDG_DG_NHL(window.name, b_nam, ktra, ns_dg_qlxx_ct_kpi_P_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(err); }
}
function ns_dg_qlxx_ct_kpi_P_KQ(b_kq) {
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
    b_hang1 = GridX_Fi_timHangA(b_grctId1);
    var b_mota = C_NVL(GridX_Fas_layGtriA(b_grctId1, 'mota'));
    if (b_mota != "") {
        GridX_datGtri(b_grctId1, b_hang1, 'stt', b_hang1);
        //GridX_datGtri(b_grctId1, b_hang1, 'stt', b_hang1);
    }
    return false;
}
function thaydoiRow_KQ(b_kq) {
    GridX_datGtri(b_grctId1, b_hang1, 'mota', b_kq);
    b_hang1 = -1;
}
function ns_dg_qlxx_ct_kpi_HangLen(b_dk) {
    var b_grct;
    if (b_dk == 1) b_grct = b_grctId;
    if (b_dk == 2) b_grct = b_grctId1;
    GridX_chuyenHang(b_grct, -1);
    return false;
}
function ns_dg_qlxx_ct_kpi_HangXuong(b_dk) {
    var b_grct;
    if (b_dk == 1) b_grct = b_grctId;
    if (b_dk == 2) b_grct = b_grctId1;
    GridX_chuyenHang(b_grct, 1);
    return false;
}
function ns_dg_qlxx_ct_kpi_ChenDong(b_dk) {
    var b_grct, b_ktrahten;
    if (b_dk == 'C') { b_grct = b_grctId; b_ktrahten = C_NVL(GridX_Fas_layGtriA(b_grctId, 'NHOM_TC')); }
    if (b_dk == 2) { b_grct = b_grctId1; b_ktrahten = C_NVL(GridX_Fas_layGtriA(b_grctId1, 'mota')); }
    if (b_ktrahten == '') form_P_LOI("loi:Chọn dòng dữ liệu cần chèn thêm một hàng trước nó trên bảng:loi");
    else {
        GridX_chenHang(b_grct);
    }
    return false;
}
function ns_dg_qlxx_ct_kpi_CatDong(b_dk) {
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