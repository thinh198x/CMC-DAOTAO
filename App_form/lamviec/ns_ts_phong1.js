var b_vungId, b_vung_gvId, b_vung_dgId, b_id_cutId, b_vung_tsId, b_so_idId, b_grlkeId, b_slideId, b_mode, b_gchuId, b_id_tsId, b_grtslkeId, b_slidetsId;
var b_doi = 0, b_cho_control = 0, ns_ts_phong_lkeCho, b_tu_gioId, b_tu_phutId, b_den_gioId, b_den_phutId, b_so_phutId;
function ns_ts_phong_KD() {
    b_vungId = form_Fs_VUNG_ID('UPa_ct');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_id_cutId = form_Fs_VTEN_ID('UPa_hi', 'id_cut');
    b_id_tsId = form_Fs_VTEN_ID('UPa_hi', 'id_ts');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_grlkeId = form_Fs_VUNG_ID('GR_lke');
    b_slideId = b_grlkeId + '_slide';
    ns_ts_phong_lkeCho = setInterval('ns_ts_phong_P_LKE_CHO()', 200);
}

function P_KET_QUA(b_dtuong, a_tso) {
    try { } catch (err) { form_P_LOI(err); }
}
function ns_ts_phong_P_IN() {
    var a_cot = GridX_Fdt_cotGtri(b_grlkeId);
    var b_ma_bc = 'ns_ts_dutruPhong.xml',
        b_ddan = '~/Templates/ns/', a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
    var b_kieu_in = 'E', b_ten_rp = b_ma_bc;
    var a_dt = GridX_Fdt_cotGtri(b_grlkeId);
    if (b_ten_rp == "") { form_P_LOI('Chưa chọn đúng báo cáo'); return; }
    sns_tt.Fs_EXCEL("ns_ngbc", "TT", b_ma_bc, b_ddan, b_ten_rp, b_kieu_in, a_dt_ct, a_dt, P_EXCEL_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function P_EXCEL_KQ(b_kq) {
    //?md=TT
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_MO(form_Fs_TM() + '/App_form/bc/xexcel.aspx?md=TT', null, null, "C");
}
function ns_ts_phong_P_KTRA(b_maTen) {
    try {
        b_maTen = b_maTen.toUpperCase();
        if (b_maTen == "GIO") {
            if (O_NVL($get(b_tu_gioId).value, 0) * 1 >= 24 || O_NVL($get(b_den_gioId).value, 0) * 1 >= 24)
                form_P_LOI('loi:Giờ không quá 24:loi');
            if (O_NVL($get(b_tu_phutId).value, 0) * 1 >= 60 || O_NVL($get(b_den_phutId).value, 0) * 1 >= 60)
                form_P_LOI('loi:Phút không quá 60:loi');
            $get(b_so_phutId).value = -(O_NVL($get(b_tu_gioId).value, 0) * 60 + O_NVL($get(b_tu_phutId).value, 0) * 1 - O_NVL($get(b_den_gioId).value, 0) * 60 - O_NVL($get(b_den_phutId).value, 0) * 1);
        }
    } catch (err) { form_P_LOI(err); }
}

function ns_ts_phong_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}
function ns_ts_phong_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_ts_phong_lkeCho); ns_ts_phong_P_LKE(); }
}
function ns_ts_phong_P_LKE() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_dt = form_Faa_TEXT_ROW(b_vungId); var a_cot = GridX_Fas_tenCot(b_grlkeId); var a_tso = slide_Faobj_TUDEN(b_slideId);
            sns_ts.Fs_NS_TS_PHONG_KHOI2_LKE(form_Fs_nsd(), b_dt, a_cot, a_tso, ns_ts_phong_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    } catch (err) {
        form_P_LOI(err);
    }
}

function ns_ts_phong_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#'); slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    $get("ctl00_ContentPlaceHolder1_tong").innerHTML = a_kq[2];
}

