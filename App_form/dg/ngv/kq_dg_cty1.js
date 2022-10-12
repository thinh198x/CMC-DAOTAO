var kq_dg_cty_lkeCho, b_vungId, b_vungtkId, b_grlkeId, b_slideId, b_gocId, b_lngId, kq_dg_cty_choAct, b_namId, b_ky_dgId, b_grctId, b_ma_nsd, b_ky_dg,
b_choAct = 0, b_fcho = 'C', b_loai_dgId;
function kq_dg_cty_P_KD(b_nsd) {
    b_ma_nsd = b_nsd;
    kq_dg_cty_lkeCho, kq_dg_cty_choAct = 0,
    kq_dg_cty_lkeCho = setInterval('kq_dg_cty_P_LKE_CHO()', 200);
}
// Mới
function kq_dg_cty_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    form_P_MOI(b_grctId, "GXL");
    GridX_thoiA(b_grlkeId); GridX_datTrang(b_grctId);
    $get(b_so_idId).value = "0"; $get(b_so_idId).focus();
    return false;
}
//Nhập
function kq_dg_cty_P_NH() {
    try {

        var b_nam = form_Fs_TEN_GTRI(b_vungId, 'nam');
        if (b_nam == "") { form_P_LOI("loi:Phải chọn Năm:loi"); return false; }
        var b_ky_dg = form_Fs_TEN_GTRI(b_vungId, 'ky_dg');
        if (b_ky_dg == "") { form_P_LOI("loi:Phải chọn Kỳ đánh giá:loi"); return false; }
        var b_loi = form_Fs_TEXT_KTRA(b_vungId); var b_so_id = 0;
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt = form_Faa_TEXT_ROW(b_vungId), a_cot_ct = GridX_Fdt_cotGtri(b_grctId), a_tso = slide_Faobj_TUDEN(b_slideId);;
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang > 0) b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
            sdg.Fs_KQ_DG_CTY_NH(form_Fs_nsd(), b_so_id, b_TrangKt, a_dt, a_cot_ct, a_tso, a_cot_lke, kq_dg_cty_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function kq_dg_cty_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        if (b_kq == "") return false;
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
function kq_dg_cty_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI('loi:Bạn phải chọn một bản ghi để xóa :loi'); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    var b_nam = $get(b_namId).value;
    var b_ky_dg = C_NVL(lke_Fs_TRA($get(b_ky_dgId)));
    if (b_nam == "" || b_ky_dg == "") { form_P_LOI('loi:Chưa chọn bản ghi để xóa :loi'); return false; }
    //var b_tranthai_tk = lke_Fs_TRA($get(b_trangthai_tkId));
    var check = confirm("Bạn có chắc chắn xóa hay không");
    if (check == false) return false;
    if (b_so_id == "") kq_dg_cty_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_KQ_DG_CTY_XOA(form_Fs_nsd(), b_so_id, b_nam, b_ky_dg, a_tso, a_cot, kq_dg_cty_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function kq_dg_cty_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) kq_dg_cty_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); kq_dg_cty_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công:loi");
    }
}
// Chuyển hàng
function kq_dg_cty_GR_lke_RowChange() {
    if (kq_dg_cty_choAct != 0) clearTimeout(kq_dg_cty_choAct);
    kq_dg_cty_choAct = setTimeout("kq_dg_cty_P_CHUYEN_HANG()", 300);
    return false;
}
function kq_dg_cty_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "0" || b_so_id == "") { form_P_MOI(b_vungId, "XGL"); GridX_datTrang(b_grctId); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId); slide_P_MOI(b_slideIdct); a_tso = slide_Faobj_TUDEN(b_slideIdct);
        sdg.Fs_KQ_DG_CTY_CT(form_Fs_nsd(), b_so_id, a_tso, a_cot_ct, kq_dg_cty_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        $get(b_so_idId).value = b_so_id;
    }
    return false;
}
function kq_dg_cty_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        var a_kq = b_kq.split('#');
        form_P_MOI(b_vungId, "GXL");
        form_P_CH_TEXT(b_vungId, a_kq[0]);
        if (a_kq[1] == "") GridX_datTrang(b_grctId); else { slide_P_SOTRANG(b_slideIdct, CSO_SO(a_kq[2], 0)); GridX_datBang(b_grctId, a_kq[1]); }
        return false;
    }
}
// Liệt kê
function kq_dg_cty_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (kq_dg_cty_lkeCho != 0) clearTimeout(kq_dg_cty_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtkId = form_Fs_VUNG_ID('Upa_tk'),
        b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_grctId = form_Fs_VUNG_ID('GR_ct'),
        b_namId = form_Fs_TEN_ID(b_vungId, 'nam'),
        b_ky_dgId = form_Fs_TEN_ID(b_vungId, 'ky_dg'),
        b_ky_dgId_Upa_tk = form_Fs_TEN_ID(b_vungtkId, 'ky_dg1'),
        b_ky_dg = form_Fs_TEN_ID(b_vungId, 'KY_DG'), b_loai_dgId = form_Fs_TEN_ID(b_vungId, 'loai_dg'),
        b_so_idId = form_Fs_VTEN_ID('', 'so_id');
        b_slideId = b_grlkeId + '_slide';
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        b_slideIdct = $get(b_grctId).getAttribute('slideId');

        kq_dg_cty_P_LKE('K');
        kq_dg_cty_P_LKE_ct('CT')
        //kq_dg_cty_P_CB();
    }
}
function kq_dg_cty_P_LKE(b_dk) {
    try {
        if (b_dk == 'C' || b_dk == 'M1') slide_P_MOI(b_slideId);
        var b_ky_dg_tk = lke_Fs_TRA($get(b_ky_dgId_Upa_tk));
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_KQ_DG_CTY_LKE(form_Fs_nsd(), b_ky_dg_tk, a_tso, a_cot, kq_dg_cty_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function kq_dg_cty_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}
function kq_dg_cty_P_LKE_ct(b_dk) {
    try {
        if (b_dk == 'CT') slide_P_MOI(b_slideIdct);
        var a_cot_ct = GridX_Fas_tenCot(b_grctId), a_tso = slide_Faobj_TUDEN(b_slideIdct);
        b_kydg_gtri = C_NVL(lke_Fs_TRA($get(b_ky_dg)));
        if (b_dk == 'K') {
            b_kydg_display = $get(b_ky_dg).value
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            var b_kydg_grid = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten_ky_dg"));
            if (b_kydg_grid != b_kydg_display) {
                var b_hang1 = GridX_Fi_timHangD(b_grlkeId, "ten_ky_dg", b_kydg_display);
                if (b_hang1 > 0) GridX_datA(b_grlkeId, b_hang1);
                else {
                    if (b_hang != -1)
                        GridX_thoiA(b_grlkeId, b_hang);
                }
            }
        }
        sdg.Fs_KQ_DG_CTY_LKE_GRCT(form_Fs_nsd(), b_kydg_gtri, a_tso, a_cot_ct, kq_dg_cty_P_LKE_ct_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function kq_dg_cty_P_LKE_ct_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideIdct, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grctId, a_kq[1]);
    }
    b_fcho = 'X';
}
//Gửi
function kq_dg_cty_P_GUI() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) { form_P_LOI("loi:Chưa chọn bản ghi cần gửi:loi"); return false; }
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "") { form_P_LOI("loi:Chưa chọn bản ghi cần gửi:loi"); return false; }
        var b_so_Id = $get(b_so_idId).value, a_cot = GridX_Fas_tenCot(b_grlkeId);
        var b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "trangthai"));
        if (b_trangthai == "CG")
            sdg.Fs_KQ_DG_CTY_GUI(form_Fs_nsd(), b_so_Id, kq_dg_cty_GUI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        else
            form_P_LOI("loi:Đăng ký đã được gửi hoặc phê duyệt:loi");
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
//Xác nhận
function kq_dg_cty_P_XACNHAN_GUILAI(b_dk) {
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
                kq_dg_cty_P_NH();
            }
            else { form_P_LOI("loi:Chọn đúng trạng thái phê duyệt:loi"); return false; }
            sdg.Fs_KQ_DG_CTY_GUI(form_Fs_nsd(), b_so_Id, b_trangthai, kq_dg_cty_GUI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else
            form_P_LOI("loi:Đăng ký đã được gửi hoặc phê duyệt:loi");
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function kq_dg_cty_GUI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else form_P_LOI("loi:Gửi phê duyệt thành công:loi");
    kq_dg_cty_P_LKE('K');
    return false;
}

// lấy xếp loại đánh giá theo loại đánh giá
function ns_kq_dg_cty_P_LIST(b_ctrId, b_kieu, b_vtri) {
    try {
        var b_loai_dg = form_Fs_TEN_GTRI(b_vungId, 'loai_dg');
        if (b_loai_dg != '') {
            var a_tso = lke_Fa_TSO(b_kieu);
            sdg.Fs_NS_KQ_DG_CTY_DR_GRID(form_Fs_nsd(), b_loai_dg, a_tso[3], form_LIST_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}

//
function kq_dg_cty_P_CB() {
    try {
        var b_ma_nv = b_ma_nsd;
        sdg.Fs_THONGTIN_CANBO(b_ma_nv, kq_dg_cty_P_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function kq_dg_cty_P_CB_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
function kq_dg_cty_P_NAM(b_dk) {
    try {
        if (b_dk == 'N') var b_nam = lke_Fs_TRA($get(b_namId));
        if (b_dk == 'F') var b_nam = lke_Fs_TRA($get(b_namId_Upa_tk));
        var ktra = "DT_KY_DG";
        sdg.Fdt_NS_DG_MA_KDG_DG_NHL(window.name, b_nam, ktra, kq_dg_cty_P_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(err); }
}
function kq_dg_cty_P_KYDG(b_dk) {

}
function kq_dg_cty_P_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_kdgId = form_Fs_TEN_ID(b_vungId, 'ky_dg');
        drop_P_LKE(b_kdgId, b_kq);
    }
}
function form_dong() {
    location.reload(false);
}