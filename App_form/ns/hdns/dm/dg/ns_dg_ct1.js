var b_lkeCho, b_vungId, b_gr_truong_Id, b_gr_congthuc_Id, b_nam_id, b_ky_dg_Id, b_plnv_id, b_cnv_id, b_congthuc_id, b_nsd, b_so_id_Id, b_field1, ns_dg_ct_choAct = 0;
function ns_dg_ct_P_KD() {
    b_vungId = form_Fs_VUNG_ID('UPa_tk'), b_gr_truong_Id = form_Fs_VUNG_ID('GR_truong'), b_gr_congthuc_Id = form_Fs_VUNG_ID('GR_congthuc');
    b_nam_id = form_Fs_TEN_ID(b_vungId, 'NAM_DR');
    b_ky_dg_Id = form_Fs_TEN_ID(b_vungId, 'MA_KDG_DR');
    b_plnv_id = form_Fs_TEN_ID(b_vungId, 'MA_PLNV_DR');
    b_cnv_id = form_Fs_TEN_ID(b_vungId, 'ma_cap_nv_dr');
    b_congthuc_id = form_Fs_VTEN_ID("UPa_ct", 'CONGTHUC');
    b_so_id_Id = form_Fs_VTEN_ID("UPa_hi", 'so_id');
    b_nsd = form_Fs_nsd();
    b_lkeCho = setInterval('ns_dg_ct_P_LKE_CHO()', 200);
}
function ns_dg_ct_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "NAM": b_maId = b_nam_id; break;
            case "MA_KDG": b_maId = b_cnv_id; break;
            case "MA_PLNV": b_maId = b_plnv_id; break;
            case "MA_CAPNV": b_maId = b_cnv_id; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null) return;  
        switch (b_maTen) {
            case "MA_PLNV":
                // lấy danh mục cấp nhân viên
                $get(b_cnv_id).value = null;
                $get(b_congthuc_id).value = "";
                var b_plnv = C_NVL(form_Fs_TEN_GTRI(b_vungId, 'MA_PLNV_DR'));
                if (b_plnv == "") return;
                sns_ma_ch.Fs_NS_HDNS_MA_CAPNV_LKE_DR(b_nsd, "ns_dg_ct", "TC_DG_CT_CNV", b_plnv, "A", ns_dg_ct_P_CAPNV_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                break;
            case "NAM":
            case "MA_KDG":
            case "MA_CAPNV":
                $get(b_congthuc_id).value = "";
                $get(b_so_id_Id).value = 0;
                GridX_thoiA(b_gr_congthuc_Id);
                break;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dg_ct_P_CAPNV_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
}
function ns_dg_ct_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    $get(b_congthuc_id).value = '';
    $get(b_so_id_Id).value = 0;
    GridX_datTrang(b_gr_truong_Id, null, null, "chon");
    GridX_thoiA(b_gr_truong_Id);
    GridX_thoiA(b_gr_congthuc_Id);
    return false;
}
function ns_dg_ct_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var b_hang = GridX_Fi_timHangA(b_gr_congthuc_Id);
    if (b_hang < 1) { form_P_LOI("loi:Bạn phải chọn một công thức để lưu:loi"); return false; }
    var b_ma_ct = GridX_Fas_layGtri(b_gr_congthuc_Id, b_hang, "ma");
    if (b_ma_ct == "") { form_P_LOI("loi:Bạn phải chọn một công thức để lưu:loi"); return false; }
    var b_congthuc = C_NVL($get(b_congthuc_id).value);
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), b_so_id = CSO_SO($get(b_so_id_Id).value);    
    sdg.Fs_NS_DG_CT_NH(b_nsd, b_so_id, b_ma_ct, b_congthuc, b_field1, a_dt_ct, ns_dg_ct_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_dg_ct_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        if (b_kq.indexOf("KHONG_HOP_LE") >= 0)
            b_kq = "loi:Công thức không hợp lệ:loi";
        form_P_LOI(b_kq);
    }
    else {
        $get(b_so_id_Id).value = b_kq;
        form_P_LOI("loi:Ghi thành công!:loi");
    }
}
/*
function ns_dg_ct_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
    if (b_ma == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); ns_dg_ct_P_MOI(); }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_so_id = CSO_SO(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        sdg.Fs_NS_DG_TC_CNV_XOA(b_nsd, b_so_id, a_tso, a_cot, ns_dg_ct_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_dg_ct_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
        var b_dong = GridX_Fi_hangSo(b_grlkeId);
        if (b_hang > b_dong) b_hang = b_dong;
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dg_ct_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dg_ct_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công:loi");
    }
}
*/
function ns_dg_ct_GR_truong_RowChange() {    
    return false;
}
function ns_dg_ct_GR_truong_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        if (b_cot == 'CHON' && b_value != '') {
            var b_hang = GridX_Fi_timHangA(b_gr_truong_Id);
            GridX_datTrang(b_gr_truong_Id, null, null, "chon");
            GridX_datGtri(b_gr_truong_Id, b_hang, ["chon"], ["X"], 'K');
            var b_field_name = GridX_Fas_layGtri(b_gr_truong_Id, b_hang, "field_name");
            $get(b_congthuc_id).value = $get(b_congthuc_id).value + " " + b_field_name;
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_dg_ct_GR_congthuc_RowChange() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var b_hang = GridX_Fi_timHangA(b_gr_congthuc_Id);
        if (b_hang < 1) return;
        var b_ma_ct = GridX_Fas_layGtri(b_gr_congthuc_Id, b_hang, "ma");
        if (b_ma_ct == "") { ns_dg_ct_P_MOI(); }
        else {
            var b_nam = CSO_SO(form_Fs_TEN_GTRI(b_vungId, 'NAM_DR')), b_ma_kdg = C_NVL(form_Fs_TEN_GTRI(b_vungId, 'MA_KDG_DR')),
                b_ma_plnv = C_NVL(form_Fs_TEN_GTRI(b_vungId, 'MA_PLNV_DR')), b_ma_capnv = C_NVL(form_Fs_TEN_GTRI(b_vungId, 'ma_cap_nv_dr'));            
            sdg.Fs_NS_DG_CT_CT(b_nsd, b_nam, b_ma_kdg, b_ma_plnv, b_ma_capnv, b_ma_ct, ns_dg_ct_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dg_ct_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else if (b_kq == '') {
        form_P_MOI(b_vungId, "X");
        $get(b_congthuc_id).value = "";
        $get(b_so_id_Id).value = 0;
    }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        $get(b_so_id_Id).value = a_kq[0];
        $get(b_congthuc_id).value = a_kq[1];
    }
}
function ns_dg_ct_P_LKE_CHO() {    
    clearTimeout(b_lkeCho);
    ns_dg_ct_P_LKE();   
}
function ns_dg_ct_P_LKE() {
    try {        
        sdg.Fs_NS_DG_CT_FIELDNAME(b_nsd, ns_dg_ct_P_LKE_FIELDNAME_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        sdg.Fs_NS_DG_CT_CONGTHUC(b_nsd, ns_dg_ct_P_LKE_CONGTHUC_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dg_ct_P_LKE_FIELDNAME_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang(b_gr_truong_Id, b_kq);
    b_field1 = GridX_Fas_layGtri(b_gr_truong_Id, 1, "field_name");
}
function ns_dg_ct_P_LKE_CONGTHUC_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang(b_gr_congthuc_Id, b_kq);
}
function ns_dg_tieuChi_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var b_hang = GridX_Fi_timHangA(b_gr_tieuChi_Id);
    if (b_hang > 0) {
        GridX_dropCell(b_gr_tieuChi_Id, b_hang, 'ma_tc', b_kq);
    }
}
function ns_dg_ct_P_KT() {
    try {
        var b_congthuc = C_NVL($get(b_congthuc_id).value);
        if (b_congthuc == "") { form_P_LOI("loi:Bạn chưa nhập công thức:loi"); return false; }
        else {
            b_congthuc = b_congthuc + " + 1";// + b_field1;
            sdg.Fs_NS_DG_CT_KT(b_nsd, b_congthuc, ns_dg_ct_P_KT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dg_ct_P_KT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI("loi:Không hợp lệ:loi"); return false; }
    form_P_LOI("loi:Hợp lệ:loi");
    return false;
}
function ns_dg_ct_cong() {
    $get(b_congthuc_id).value = $get(b_congthuc_id).value + " + ";
    form_P_LOI('');
    return false;
}
function ns_dg_ct_tru() {
    $get(b_congthuc_id).value = $get(b_congthuc_id).value + " - ";
    form_P_LOI('');
    return false;
}
function ns_dg_ct_nhan(b_dk) {
    $get(b_congthuc_id).value = $get(b_congthuc_id).value + " * ";
    form_P_LOI('');
    return false;
}
function ns_dg_ct_chia() {
    $get(b_congthuc_id).value = $get(b_congthuc_id).value + " / ";
    form_P_LOI('');
    return false;
}
function form_dong() {
    location.reload(false);
}