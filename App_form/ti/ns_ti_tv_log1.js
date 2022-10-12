var b_tmf, ns_ti_tv_log_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_ma_dvi, b_choAct_fi = 0,
b_iurlId, b_dchiId, b_nc_cmtId, b_nhaId, b_nha_dchiId, b_nhomId, b_ngaydId, b_iurl, b_mt, b_klkId,
b_phongId, b_mastId, b_nhanId, b_tenId, b_sotkId, b_tenhoaId, b_nsinhId, b_gchuId, b_so_idId, b_tenphongId;
function ns_ti_tv_log_P_KD() {
    b_grlkeId = form_Fs_VUNG_ID('GR_lke');
    ns_ti_tv_log_lkeCho = setInterval('ns_ti_tv_log_P_LKE_CHO()', 200);
}
function ns_ti_tv_log_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_ti_tv_log_lkeCho); ns_ti_tv_log_P_LKE(); }
}

function ns_ti_tv_log_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId);
        sti_ch.Fs_TI_TV_LOG_LKE(a_cot, ns_ti_tv_log_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ti_tv_log_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    GridX_dat_hangkt(b_grlkeId, a_kq[1]);
    GridX_datBang(b_grlkeId, a_kq[0]);
    return false;
}
function GridX_dat_hangkt(b_gridx, sodong) {

    try {
        var b_grid = $get(b_gridx);
        b_grid.setAttribute('hangKt', '20');
        var b_hangkt = GridX_Fi_hangKt(b_gridx);
        if (sodong > b_hangkt) {
            b_grid.setAttribute('hangKt', sodong - b_hangkt + 21);
        }
        return false;
    } catch (err) { form_P_LOI(err); }
}

function form_dong() {
    location.reload(false);
}