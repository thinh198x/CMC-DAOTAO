var dg_ngv_ctcv_ht_lkeCho, b_vungId, b_vungtkId, b_grlkeId, b_slideId, b_gocId, b_lngId, dg_ngv_ctcv_ht_choAct, b_namId, b_ky_dgId, b_trangthaiId, b_grctId, b_ma_nsd
b_choAct = 0, b_fcho = 'C';
function dg_ngv_ctcv_ht_P_KD(b_nsd) {
    b_ma_nsd = b_nsd;
    dg_ngv_ctcv_ht_lkeCho, dg_ngv_ctcv_ht_choAct = 0,
    dg_ngv_ctcv_ht_lkeCho = setInterval('dg_ngv_ctcv_ht_P_LKE_CHO()', 200);
}
// Mới
function dg_ngv_ctcv_ht_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId); GridX_datTrang(b_grctId);
    $get(b_so_idId).value = "0"; $get(b_so_idId).focus();
    lke_P_DAT($get(b_trangthaiId), 'CG{Chưa gửi');
    return false;
}
//Nhập
function dg_ngv_ctcv_ht_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId); var b_so_id = 0;
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang > 0) {
                var b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "trangthai"));
                if (b_trangthai == '1') { form_P_LOI('loi:Bản ghi đã ở trạng thái phê duyệt, không thể chỉnh sửa:loi'); return false; }
                if (b_trangthai == '0') { form_P_LOI('loi:Bản ghi đã gửi phê duyệt, không thể chỉnh sửa:loi'); return false; }
            }
            var a_dt = form_Faa_TEXT_ROW(b_vungId), a_cot_ct = GridX_Fdt_cotGtri(b_grctId), a_tso = slide_Faobj_TUDEN(b_slideId);;
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang > 0) b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
            var b_trangthai_tk = lke_Fs_TRA($get(b_trangthai_tkId)), b_kydg_gtri = C_NVL(lke_Fs_TRA($get(b_ky_dg_tkId)));
            sdg.Fs_DG_NGV_CTCV_HT_NH(form_Fs_nsd(), b_so_id, b_trangthai_tk, b_kydg_gtri, b_TrangKt, a_dt, a_cot_ct, a_tso, a_cot_lke, dg_ngv_ctcv_ht_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function dg_ngv_ctcv_ht_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
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
function dg_ngv_ctcv_ht_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI('loi:Bạn phải chọn một bản ghi để xóa :loi'); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    var b_tranthai_tk = lke_Fs_TRA($get(b_trangthai_tkId));
    if (b_so_id == "") dg_ngv_ctcv_ht_P_MOI();
    else {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 0) {
            var b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "trangthai"));
            if (b_trangthai == '1') { form_P_LOI('loi:Bản ghi đã ở trạng thái phê duyệt, không thể xóa:loi'); return false; }
        }

        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_DG_NGV_CTCV_HT_XOA(form_Fs_nsd(), b_so_id, b_tranthai_tk, a_tso, a_cot, dg_ngv_ctcv_ht_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function dg_ngv_ctcv_ht_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) dg_ngv_ctcv_ht_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); dg_ngv_ctcv_ht_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công:loi");
    }
}
// Chuyển hàng
function dg_ngv_ctcv_ht_GR_lke_RowChange() {
    if (dg_ngv_ctcv_ht_choAct != 0) clearTimeout(dg_ngv_ctcv_ht_choAct);
    dg_ngv_ctcv_ht_choAct = setTimeout("dg_ngv_ctcv_ht_P_CHUYEN_HANG()", 300);
    return false;
}
function dg_ngv_ctcv_ht_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "0" || b_so_id == "") { form_P_MOI(b_vungId, "XGL"); GridX_datTrang(b_grctId); lke_P_DAT($get(b_trangthaiId), 'CG{Chưa gửi'); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        sdg.Fs_DG_NGV_CTCV_HT_CT(form_Fs_nsd(), b_so_id, a_cot_ct, dg_ngv_ctcv_ht_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        $get(b_so_idId).value = b_so_id;
    }
    return false;
}
function dg_ngv_ctcv_ht_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        var a_kq = b_kq.split('#');
        form_P_MOI(b_vungId, "GXL");
        form_P_CH_TEXT(b_vungId, a_kq[0]);
        if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
        return false;
    }
}
// Liệt kê
function dg_ngv_ctcv_ht_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (dg_ngv_ctcv_ht_lkeCho != 0) clearTimeout(dg_ngv_ctcv_ht_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtkId = form_Fs_VUNG_ID('Upa_tk'),
        b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_grctId = form_Fs_VUNG_ID('GR_ct'),
        b_namId = form_Fs_TEN_ID(b_vungId, 'nam'),
        b_ky_dgId = form_Fs_TEN_ID(b_vungId, 'ky_dg'),
        b_so_idId = form_Fs_VTEN_ID('', 'so_id');
        b_trangthaiId = form_Fs_TEN_ID(b_vungId, 'trangthai');
        b_trangthai_tkId = form_Fs_TEN_ID(b_vungtkId, 'trangthai_tk'), b_ky_dg_tkId = form_Fs_TEN_ID(b_vungtkId, 'ky_dg_tk'),
        b_slideId = b_grlkeId + '_slide';
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        dg_ngv_ctcv_ht_P_LKE('K');
        dg_ngv_ctcv_ht_P_CB();
        lke_P_DAT($get(b_trangthaiId), 'CG{Chưa gửi');
    }
}
function dg_ngv_ctcv_ht_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var b_trangthai_tk = lke_Fs_TRA($get(b_trangthai_tkId));
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        //son them
        b_kydg_gtri = C_NVL(lke_Fs_TRA($get(b_ky_dg_tkId)));
        if (b_dk == 'KDG') {
            b_kydg_display = $get(b_ky_dgId).value
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            //if(b_hang>0){
            var b_kydg_grid = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten_ky_dg"));
            if (b_kydg_grid != b_kydg_display) {
                var b_hang1 = GridX_Fi_timHangD(b_grlkeId, "ten_ky_dg", b_kydg_display);
                if (b_hang1 > 0) { GridX_datA(b_grlkeId, b_hang1); dg_ngv_ctcv_ht_P_CHUYEN_HANG(); return false; }
                else {
                    if (b_hang != -1) { GridX_thoiA(b_grlkeId, b_hang); GridX_datBang(b_grctId, ''); lke_P_DAT($get(b_trangthaiId), 'CG{Chưa gửi'); }
                    else {
                        lke_P_DAT($get(b_trangthaiId), 'CG{Chưa gửi');
                    }
                }
            }
            return false;
        }
        //Son
        sdg.Fs_DG_NGV_CTCV_HT_LKE(form_Fs_nsd(), b_trangthai_tk, b_kydg_gtri, a_tso, a_cot, dg_ngv_ctcv_ht_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function dg_ngv_ctcv_ht_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}
//Gửi
function dg_ngv_ctcv_ht_P_GUI() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) { form_P_LOI("loi:Chưa chọn bản ghi cần gửi:loi"); return false; }
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "") { form_P_LOI("loi:Chưa chọn bản ghi cần gửi:loi"); return false; }
        var b_so_Id = $get(b_so_idId).value, a_cot = GridX_Fas_tenCot(b_grlkeId);
        var b_trangthaiId = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "trangthai"));
        if (b_trangthaiId == "CG" || b_trangthaiId == "2")
            sdg.Fs_DG_NGV_CTCV_HT_GUI(form_Fs_nsd(), b_so_Id, dg_ngv_ctcv_ht_GUI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        else
            form_P_LOI("loi:Đăng ký đã được gửi hoặc phê duyệt:loi");
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function dg_ngv_ctcv_ht_GUI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else form_P_LOI("loi:Gửi phê duyệt thành công:loi");
    dg_ngv_ctcv_ht_P_LKE('K');
    return false;
}
function dg_ngv_ctcv_ht_STT(b_event) {
    GridX_sott(b_grctId, 'stt');
    return false;
}
function dg_ngv_ctcv_ht_P_CB() {
    try {
        var b_ma_nv = b_ma_nsd;
        sdg.Fs_THONGTIN_CANBO111(b_ma_nv, dg_ngv_ctcv_ht_P_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function dg_ngv_ctcv_ht_P_CB_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
function dg_ngv_ctcv_ht_P_NAM() {
    try {
        var b_nam = lke_Fs_TRA($get(b_namId));
        var ktra = "DT_KY_DG";
        sdg.Fdt_NS_DG_MA_KDG_DG_NHL(window.name, b_nam, ktra, dg_ngv_ctcv_ht_P_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(err); }
}
function dg_ngv_ctcv_ht_P_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_kdgId = form_Fs_TEN_ID(b_vungId, 'ky_dg');
        drop_P_LKE(b_kdgId, b_kq);
    }
}
function form_dong() {
    location.reload(false);
}