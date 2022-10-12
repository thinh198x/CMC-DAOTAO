var ns_cb_dgia_kpi_nv_lkeCho, b_vungId, b_vungtkId, b_grlkeId, b_slideId, b_gocId, b_lngId, ns_cb_dgia_kpi_nv_choAct, b_namId, b_ky_dgId, b_grctId,
    b_ma_nsd, b_ketqua_xlId, b_namId_tk,b_hesoId, b_ky_dgId_tk, b_trangthaiId_tk, b_choAct = 0, b_fcho = 'C', b_check_message = "", b_diem_tb_qlId, b_diem_tb_nl_ql, b_ketqua_cb_dgiaId, b_ketqua_tnId, b_diem_tb_nl_qlId, b_xeploaiId;
function ns_cb_dgia_kpi_nv_P_KD(b_nsd) {
    b_ma_nsd = b_nsd;
    ns_cb_dgia_kpi_nv_lkeCho, ns_cb_dgia_kpi_nv_choAct = 0,
    ns_cb_dgia_kpi_nv_lkeCho = setInterval('ns_cb_dgia_kpi_nv_P_LKE_CHO()', 200);
}
//Nhập 
function ns_cb_dgia_kpi_nv_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    form_P_MOI(b_grctId, "GXL");
    GridX_thoiA(b_grlkeId); GridX_datTrang(b_grctId);
    $get(b_so_idId).value = "0"; $get(b_so_idId).focus();
    return false;
}
function ns_cb_dgia_kpi_nv_P_NH(b_dk) {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId); var b_so_id = 0;
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang > 0) {
                b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "trangthai"));
                if (b_trangthai == '1') { form_P_LOI('loi:Bản ghi đã qua xem xét, không thể chỉnh sửa:loi'); return false; }
            }
            var a_dt = form_Faa_TEXT_ROW(b_vungId), a_cot_ct = GridX_Fdt_cotGtri(b_grctId), a_cot_cv_ct = GridX_Fdt_cotGtri(b_grnlctId), a_tso = slide_Faobj_TUDEN(b_slideId);
            if (b_dk == 'XN') { a_dt[1][13] = '1'; b_check_message = "XN" }
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            if (b_hang > 0) b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
            sdg.Fs_NS_CB_DGIA_KPI_NV_NH(form_Fs_nsd(), b_so_id, b_TrangKt, a_dt, a_cot_ct, a_cot_cv_ct, a_tso, a_cot_lke, ns_cb_dgia_kpi_nv_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_cb_dgia_kpi_nv_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        if (b_kq == "") return false;
        var a_kq = b_kq.split('#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        if (b_check_message == "XN") form_P_LOI("loi:Xác nhận thành công:loi");
        else form_P_LOI("loi:Nhập thành công:loi");
    }
    b_fcho = 'X';
}
// Xóa
function ns_cb_dgia_kpi_nv_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI('loi:Bạn phải chọn một bản ghi để xóa :loi'); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    var b_tranthai_tk = lke_Fs_TRA($get(b_trangthai_tkId));
    if (b_so_id == "") ns_cb_dgia_kpi_nv_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_NS_CB_DGIA_KPI_NV_XOA(form_Fs_nsd(), b_so_id, b_tranthai_tk, a_tso, a_cot, ns_cb_dgia_kpi_nv_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_cb_dgia_kpi_nv_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_cb_dgia_kpi_nv_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_cb_dgia_kpi_nv_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công:loi");
    }
}
// Chuyển hàng
function ns_cb_dgia_kpi_nv_GR_lke_RowChange() {
    if (ns_cb_dgia_kpi_nv_choAct != 0) clearTimeout(ns_cb_dgia_kpi_nv_choAct);
    ns_cb_dgia_kpi_nv_choAct = setTimeout("ns_cb_dgia_kpi_nv_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_cb_dgia_kpi_nv_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "0" || b_so_id == "") { form_P_MOI(b_vungId, "XGL"); GridX_datTrang(b_grctId); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId); a_cot_nl_ct = GridX_Fas_tenCot(b_grnlctId);
        sdg.Fs_NS_CB_DGIA_KPI_NV_CT(form_Fs_nsd(), b_so_id, a_cot_ct, a_cot_nl_ct, ns_cb_dgia_kpi_nv_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_cb_dgia_kpi_nv_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        var a_kq = b_kq.split('#');
        form_P_MOI(b_vungId, "GXL");
        form_P_CH_TEXT(b_vungId, a_kq[0]);
        if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
        if (a_kq[2] == "") GridX_datTrang(b_grnlctId); else GridX_datBang(b_grnlctId, a_kq[2]);
        //ns_cb_dgia_kpi_nv_P_KY_DG('K');
        return false;
    }
}
// Liệt kê
function ns_cb_dgia_kpi_nv_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ns_cb_dgia_kpi_nv_lkeCho != 0) clearTimeout(ns_cb_dgia_kpi_nv_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtkId = form_Fs_VUNG_ID('Upa_tk'),
        b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_grctId = form_Fs_VUNG_ID('GR_ct'),
        b_grnlctId = form_Fs_VUNG_ID('GR_nl_ct'),
        b_namId = form_Fs_TEN_ID(b_vungId, 'nam'),
        b_ky_dgId = form_Fs_TEN_ID(b_vungId, 'ky_dg'),
        b_diem_tbId = form_Fs_TEN_ID(b_vungId, 'diem_tb_kpi'),
        b_diem_tb_qlId = form_Fs_TEN_ID(b_vungId, 'diem_tb_kpi_ql'),
        b_diem_tb_nl_qlId = form_Fs_TEN_ID(b_vungId, 'DIEM_TB_NL_QL'),
        b_xeploaiId = form_Fs_TEN_ID(b_vungId, 'xeploai'),
        //b_hesoId = form_Fs_TEN_ID(b_vungId, 'heso'),
        b_namId_Upa_tk = form_Fs_TEN_ID(b_vungtkId, 'nam1'),
        b_so_idId = form_Fs_VTEN_ID('', 'so_id'); 
        b_namId_tk = form_Fs_VTEN_ID('', 'nam_tk_an');
        b_ky_dgId_tk = form_Fs_VTEN_ID('', 'ky_dg_tk_an');
        b_trangthaiId_tk = form_Fs_VTEN_ID('', 'trangthai_tk_an');
        b_trangthai_tkId = form_Fs_TEN_ID(b_vungtkId, 'trangthai_tk'),
        b_ky_dg_tkId = form_Fs_TEN_ID(b_vungtkId, 'ky_dg_tk'), b_ketqua_xlId = form_Fs_TEN_ID('', 'ketqua_xl'),
        b_ketqua_cb_dgiaId = form_Fs_TEN_ID(b_vungId, 'ketqua_cb_dgia'), b_ketqua_tnId = form_Fs_TEN_ID(b_vungId, 'ketqua_tn'),
        b_slideId = b_grlkeId + '_slide';
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_cb_dgia_kpi_nv_P_LKE('K');
        ns_cb_dgia_kpi_nv_P_CB();
    }
}
function ns_cb_dgia_kpi_nv_P_LKE(b_dk) {
    try {
        if (b_dk == 'C' || b_dk == 'M') slide_P_MOI(b_slideId);
        var b_trangthai_tk = lke_Fs_TRA($get(b_trangthai_tkId));
        var b_nam_tk = lke_Fs_TRA($get(b_namId_Upa_tk));
        var b_ky_dg_tk = lke_Fs_TRA($get(b_ky_dg_tkId));
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_NS_CB_DGIA_KPI_NV_LKE(form_Fs_nsd(), b_nam_tk, b_trangthai_tk, b_ky_dg_tk, a_tso, a_cot, ns_cb_dgia_kpi_nv_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);

        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cb_dgia_kpi_nv_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}
//Gửi
function ns_cb_dgia_kpi_nv_P_GUI() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) { form_P_LOI("loi:Chưa chọn bản ghi cần gửi:loi"); return false; }
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "") { form_P_LOI("loi:Chưa chọn bản ghi cần gửi:loi"); return false; }
        var b_so_Id = $get(b_so_idId).value, a_cot = GridX_Fas_tenCot(b_grlkeId);
        var b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "trangthai"));
        if (b_trangthai == "CG")
            sdg.Fs_NS_CB_DGIA_KPI_NV_GUI(form_Fs_nsd(), b_so_Id, ns_cb_dgia_kpi_nv_GUI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        else
            form_P_LOI("loi:Đăng ký đã được gửi hoặc phê duyệt:loi");
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
//Xác nhận
function ns_cb_dgia_kpi_nv_P_XACNHAN_GUILAI(b_dk) {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) { form_P_LOI("loi:Chưa chọn bản ghi cần gửi:loi"); return false; }
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "") { form_P_LOI("loi:Chưa chọn bản ghi cần gửi:loi"); return false; }
        var b_so_Id = $get(b_so_idId).value, a_cot = GridX_Fas_tenCot(b_grlkeId);
        var b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "trangthai"));
        if (b_dk == "XN" || b_dk == "TC") {
            if (b_trangthai == 0) {
                if (b_dk == "XN") b_trangthai = 1;
                else b_trangthai = 2;
                ns_cb_dgia_kpi_nv_P_NH();
            }
            else { form_P_LOI("loi:Chọn đúng trạng thái phê duyệt:loi"); return false; }
            sdg.Fs_NS_CB_DGIA_KPI_NV_GUI(form_Fs_nsd(), b_so_Id, b_trangthai, ns_cb_dgia_kpi_nv_GUI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else
            form_P_LOI("loi:Đăng ký đã được gửi hoặc phê duyệt:loi");
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cb_dgia_kpi_nv_GUI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else form_P_LOI("loi:Gửi phê duyệt thành công:loi");
    ns_cb_dgia_kpi_nv_P_LKE('K');
    return false;
}

//
function ns_cb_dgia_kpi_nv_P_CB() {
    try {
        var b_ma_nv = b_ma_nsd;
        sdg.Fs_THONGTIN_CANBO111(b_ma_nv, ns_cb_dgia_kpi_nv_P_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cb_dgia_kpi_nv_P_CB_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
function ns_cb_dgia_kpi_nv_P_NAM(b_dk) {
    try {
        if (b_dk == 'N') var b_nam = lke_Fs_TRA($get(b_namId));
        else var b_nam = "";
        var ktra = "DT_KY_DG";
        sdg.Fdt_NS_DG_MA_KDG_DG_NHL(window.name, b_nam, ktra, ns_cb_dgia_kpi_nv_P_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(err); }
}
function ns_cb_dgia_kpi_nv_P_KY_DG(b_dk) {
    try {
        if (b_dk == 'K') var b_kydg = lke_Fs_TRA($get(b_ky_dgId));
        else var b_kydg = "";
        var ktra = "DT_DOT_DG";
        sdg.Fdt_NS_DG_MA_DDG_DG_NHL(window.name, b_kydg, ktra, ns_cb_dgia_kpi_nv_P_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        var b_nam_lke = lke_Fs_TRA($get(b_namId));
        var a_cot_ct = GridX_Fas_tenCot(b_grctId), a_cot_nl_ct = GridX_Fas_tenCot(b_grnlctId);
        sdg.Fs_NS_CB_DGIA_KPI_NV_CT_LKE(form_Fs_nsd(), b_nam_lke, b_kydg, a_cot_ct, a_cot_nl_ct, ns_cb_dgia_kpi_nv_P_KQ2, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(err); }
}
function ns_cb_dgia_kpi_nv_P_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_kdgId = form_Fs_TEN_ID(b_vungId, 'ky_dg');
        drop_P_LKE(b_kdgId, b_kq);
    }
}

function ns_cb_dgia_kpi_nv_P_KQ2(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = b_kq.split('#');
        if (a_kq[0] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[0]);
        if (a_kq[1] == "") GridX_datTrang(b_grnlctId); else GridX_datBang(b_grnlctId, a_kq[1]);
    }
}
function ns_cb_dgia_kpi_nv_cac_chitieu_CHECK(b_cell) {
    GridX_datGtriA(b_grctId, ['cac_chitieu_kd', 'cac_chitieu_ct', 'cac_chitieu_d', 'cac_chitieu_t', 'cac_chitieu_x'], [' ', ' ', ' ', ' ', ' ']);
    var b_hang = GridX_Fi_timHangA(b_grctId);
    var b_ctieu = GridX_Fas_layGtri(b_grctId, b_hang, b_cot);
    if (b_ctieu != '') {
        GridX_datGtriA(b_grctId, b_cot, b_ctieu);
        GridX_datGtriA(b_grctId, 'cac_chitieu', b_ctieu);
    } else { GridX_datGtriA(b_grctId, 'cac_chitieu', ''); }
    return false;
}

function tinhtong_P_KTRA(b_maTen) {
    try {
        var b_dat = Fas_ChMang(b_maTen, '=');
        var ktra = Fas_ChMang(b_dat[0], ',');
        if (ktra.length > 1) {
            if (b_dat.length > 1) {
                var b_datgtri = tinhtong(b_dat[0]);
                GridX_datGtriA(b_grctId, b_dat[1], SO_CSO((b_datgtri / 100).toFixed(2),2));
            }
        }
        diemtb_KPI();
    }
    catch (err) { form_P_LOI(err); }
}
function diemtb_KPI() {
    var b_kq_nv_tong = 0, b_kq_ql_tong = 0
    a_cot_ct = GridX_Fdt_cotGtri(b_grctId);
    for (var i = 0; i < 10; i++) {
        var b_kq_nv = a_cot_ct[1][i][9], b_kq_ql = a_cot_ct[1][i][11];
        if (CSO_SO(b_kq_nv, 2) > 0) {
            b_kq_nv_tong += CSO_SO(b_kq_nv, 2);
        }
        if (CSO_SO(b_kq_ql, 2) > 0) {
            b_kq_ql_tong += CSO_SO(b_kq_ql, 2);
        }
    }
    // tính điểm quản lý đánh giá mức độ hoàn thành công việc
    $get(b_diem_tb_qlId).value = b_kq_ql_tong.toFixed(2);

    // tính điểm cbql đánh giá và kết quả thống nhất
    $get(b_ketqua_cb_dgiaId).value = SO_CSO((((CSO_SO($get(b_diem_tb_qlId).value,2) * 80) / 100) + ((CSO_SO($get(b_diem_tb_nl_qlId).value,2) * 20) / 100)).toFixed(2),2);
    $get(b_ketqua_tnId).value = $get(b_ketqua_cb_dgiaId).value;

    //Lay he so va xep loai.
    sdg.Fs_CB_DGIA_KPI_LAY_HESO_XEPLOAI(form_Fs_nsd(), $get(b_ketqua_cb_dgiaId).value, cb_dgia_kpi_P_LAY_HESO_XEPLOAI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function tinhtong(b_kq) {
    var arr = Fas_ChMang(b_kq, ',');
    var kq = 1;
    var b_hang_t = GridX_Fi_timHangA(b_grctId);
    for (var i = 0; i < arr.length; i++) {
        var b_giatri = C_NVL(GridX_Fas_layGtri(b_grctId, b_hang_t, '' + arr[i] + ''));
        kq *= CSO_SO(b_giatri,2);
    }
    return kq;
}

function tinhtong_nl_ct_P_KTRA(b_maTen) {
    try {
        var b_dat = Fas_ChMang(b_maTen, '=');
        var ktra = Fas_ChMang(b_dat[0], ',');
        if (ktra.length > 1) {
            if (b_dat.length > 1) {
                var b_datgtri = tinhtong_nl_ct(b_dat[0]);
                GridX_datGtriA(b_grnlctId, b_dat[1], SO_CSO((b_datgtri / 100).toFixed(2),2));
            }
        }
        diemtb_NL();
    }
    catch (err) { form_P_LOI(err); }
}
function tinhtong_nl_ct(b_kq) {
    var arr = Fas_ChMang(b_kq, ',');
    var kq = 1;
    var b_hang_t = GridX_Fi_timHangA(b_grnlctId);
    for (var i = 0; i < arr.length; i++) {
        var b_giatri = C_NVL(GridX_Fas_layGtri(b_grnlctId, b_hang_t, '' + arr[i] + ''));
        kq *= CSO_SO(b_giatri, 2);
    }
    return kq;
}
function diemtb_NL() {
    var b_kq_nv_tong = 0, b_kq_ql_tong = 0;
    a_cot_ct = GridX_Fdt_cotGtri(b_grnlctId);
    for (var i = 0; i < 10; i++) {
        var b_kq_nv = a_cot_ct[1][i][4], b_kq_ql = a_cot_ct[1][i][6];
        if (CSO_SO(b_kq_nv, 2) > 0) {
            b_kq_nv_tong += CSO_SO(b_kq_nv,2);
        }
        if (CSO_SO(b_kq_ql, 2) > 0) {
            b_kq_ql_tong += CSO_SO(b_kq_ql, 2);
        }
    }
    // tính tổng điểm quản lý đánh giá năng lực nhân viên
    $get(b_diem_tb_nl_qlId).value = b_kq_ql_tong.toFixed(2);

    // tính điểm cbql đánh giá và kết quả thống nhaats
    $get(b_ketqua_cb_dgiaId).value = SO_CSO((((CSO_SO($get(b_diem_tb_qlId).value,2) * 80) / 100) + ((CSO_SO($get(b_diem_tb_nl_qlId).value,2) * 20) / 100)).toFixed(2),2);
    $get(b_ketqua_tnId).value = $get(b_ketqua_cb_dgiaId).value;

    //Lay he so va xep loai.
    sdg.Fs_CB_DGIA_KPI_LAY_HESO_XEPLOAI(form_Fs_nsd(), $get(b_ketqua_cb_dgiaId).value, cb_dgia_kpi_P_LAY_HESO_XEPLOAI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function cb_dgia_kpi_P_LAY_HESO_XEPLOAI_KQ(b_kq) {
    var a_kq = Fas_ChMang(b_kq, '#');
    $get(b_xeploaiId).value = a_kq[1];
    //$get(b_hesoId).value = a_kq[0];
}
//Xuất excel
function ns_cb_dgia_kpi_nv_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_namId_tk).value = lke_Fs_TRA($get(b_namId_Upa_tk));
    $get(b_ky_dgId_tk).value = lke_Fs_TRA($get(b_ky_dg_tkId));
    $get(b_trangthaiId_tk).value = lke_Fs_TRA($get(b_trangthai_tkId));
    $get(b_btn_excel).click(); form_chay = 0;
    form_P_LOI('');
    return false;
}
function ns_cb_dgia_kpi_nv_P_PRINT() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap4');
    var b_hang = GridX_Fi_timHangA(b_grlkeId); 
    if (b_hang < 1) { form_P_LOI('loi:Bạn phải chọn một bản ghi:loi'); return false; }
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")); 
    $get(b_so_idId).value = b_so_id; 
    $get(b_btn_excel).click(); form_chay = 0;
    form_P_LOI('');
    return false;
}
function form_dong() {
    location.reload(false);
}