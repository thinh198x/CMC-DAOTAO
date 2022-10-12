var ns_dt_ts_them_gchuCho, b_vungtkId, b_grlke_ts_Id, b_grlke_nv_Id, b_so_id_kh, b_ngay_ht, b_nsd;

function ns_dt_ts_them_P_KD(b_so_the_cb) {
    b_vungtkId = form_Fs_VUNG_ID('Upa_tk'),
    b_grlke_ts_Id = form_Fs_VUNG_ID('GR_dx'), b_grlke_nv_Id = form_Fs_VUNG_ID('GR_nv')   
    b_gchuId = form_Fs_VTEN_ID('UPa_gchu', 'gchu');
    b_ngay_ht = new Date();
    b_nsd = form_Fs_nsd();
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
        }
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            b_so_id_kh = a_tso[1];
            var b_lop_id = form_Fs_TEN_ID(b_vungtkId, 'ttin_lop');
            $get(b_lop_id).innerHTML = a_tso[2];
        }        
    }
    catch (err) { form_P_LOI(err); }
}
// lấy danh sách nhân viên thuộc 1 phòng
function ns_dt_ts_them_P_DR_CHANGE() {
    try {
        var b_ma_dvi = form_Fs_TEN_GTRI(b_vungtkId, 'dvi_lke');
        if (b_ma_dvi == '') return false;

        var a_cot = GridX_Fas_tenCot(b_grlke_nv_Id);
        sns_dt.Fs_NS_DT_TS_NV_DVI_LKE(b_nsd, b_so_id_kh, b_ma_dvi, a_cot, ns_dt_ts_them_P_DR_CHANGE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ts_them_P_DR_CHANGE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_dong = CSO_SO(a_kq[1]);
    GridX_P_hangKt(b_grlke_nv_Id, b_dong < 10 ? 10 : b_dong);
    GridX_datBang(b_grlke_nv_Id, a_kq[0]);
}
/*
// lấy danh sách nhân viên vừa thêm
function ns_dt_ts_them_P_THEM_LKE() {
    try {
        var b_ma_dvi = form_Fs_TEN_GTRI(b_vungtkId, 'dvi_lke');
        if (b_ma_dvi == '') return false;

        var a_cot = GridX_Fas_tenCot(b_grlke_ts_Id);
        sns_dt.Fs_NS_DT_TS_THEM_LKE(b_so_id_kh, b_ngay_ht, a_cot, ns_dt_ts_them_P_THEM_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ts_them_P_THEM_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    GridX_P_hangKt(b_grlke_ts_Id, a_kq[1]);
    GridX_datBang(b_grlke_ts_Id, a_kq[0]);
}*/
// thêm danh sách tuyển sinh
function ns_dt_ts_them_P_THEMTS() {
    try {
        var b_ma_dvi = form_Fs_TEN_GTRI(b_vungtkId, 'dvi_lke');
        if (b_ma_dvi == '') return false;
        var a_dt = GridX_Fdt_cotGtri(b_grlke_nv_Id), a_cot_lke_nv = GridX_Fas_tenCot(b_grlke_nv_Id), a_cot_lke_ts = GridX_Fas_tenCot(b_grlke_ts_Id);
        sns_dt.Fs_NS_DT_TS_THEM_NH(b_nsd, b_so_id_kh, a_dt, b_ma_dvi, b_ngay_ht, a_cot_lke_nv, a_cot_lke_ts, ns_dt_ts_them_P_THEMXOATS_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ts_them_P_THEMXOATS_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    // nv
    var b_dong = CSO_SO(a_kq[1]);
    GridX_P_hangKt(b_grlke_nv_Id, b_dong < 10 ? 10 : b_dong);
    GridX_datBang(b_grlke_nv_Id, a_kq[0]);
    // ts
    b_dong = CSO_SO(a_kq[3]);
    GridX_P_hangKt(b_grlke_ts_Id, b_dong < 10 ? 10 : b_dong);
    GridX_datBang(b_grlke_ts_Id, a_kq[2]);
}
// xóa danh sách tuyển sinh
function ns_dt_ts_them_P_XOATS() {
    try {
        var b_ma_dvi = form_Fs_TEN_GTRI(b_vungtkId, 'dvi_lke');
        if (b_ma_dvi == '') return false;
        var a_dt = GridX_Fdt_cotGtri(b_grlke_ts_Id), a_cot_lke_nv = GridX_Fas_tenCot(b_grlke_nv_Id), a_cot_lke_ts = GridX_Fas_tenCot(b_grlke_ts_Id);
        sns_dt.Fs_NS_DT_TS_THEM_XOA(b_nsd, b_so_id_kh, a_dt, b_ma_dvi, b_ngay_ht, a_cot_lke_nv, a_cot_lke_ts, ns_dt_ts_them_P_THEMXOATS_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_dt_ts_them_P_DatGchu(show, gchu) {
    form_P_DatGchu(b_gchuId, gchu);
    if (show) ns_dt_ts_them_gchuCho = setInterval('ns_dt_ts_them_P_DatGchu(false,".")', 2000);
    else if (ns_dt_ts_them_gchuCho) clearTimeout(ns_dt_ts_them_gchuCho);
}