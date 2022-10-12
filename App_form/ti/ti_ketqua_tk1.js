var ti_ketqua_tk_lkeCho, b_grlkeId, b_tmf;
function ti_ketqua_tk_P_KD(b_tm) {
    b_tmf = b_tm; b_vungId = form_Fs_VUNG_ID('UPa_ct');
    ti_ketqua_tk_lkeCho, b_grlkeId = form_Fs_VUNG_ID('GR_lke');
    b_slideId = b_grlkeId + '_slide';
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        var b_an = a_tso[1];
        GridX_anCot(b_grlkeId, b_an, false);
        slide_P_SOTRANG(b_grlkeId + "_slide");
        P_NHAN_KQ(b_kq, b_an);
    }
    catch (err) { form_P_LOI(err); }
}
function P_NHAN_KQ(b_kq, b_an) {
    var a_kq = Fas_ChMang(b_kq, ';');
    for (var i = 0; i < a_kq.length; i++) {
        a_kq[i] = Fas_ChMang(a_kq[i], '|');
    }
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == "") GridX_datTrang(b_grlkeId);
    else {
        datBang(b_grlkeId, b_an, a_kq,i);
    } 
}
function datBang(gridId, b_cot, b_dt,b_length) {
    try {
        var a_cotG = GridX_Fas_tenCot(gridId), a_cot, a_dt;
        if (b_dt == null) {
            if (b_cot == "") { GridX_Moi(gridId); return; }
            else { a_cot = a_cotG; a_dt = Fdt_ChBang(b_cot); }
        }
        else { a_cot = b_cot; a_dt = b_dt; }
        for (var i = 0; i < b_length; i++) GridX_datGtri(gridId, i + 1, a_cot, a_dt[i]);
        if (Fi_vtri_mang(a_cotG, 'ccc') >= 0) GridX_laiMau(gridId);
    }
    catch (err) { form_P_LOI(err); }
}

function ti_ketqua_tk_P_FILES() {
    try {
        var b_ma = "ti_ketqua_tk";
        var b_ten = "Thêm mẫu excel cho kết quả tìm kiếm";
        var b_tenf = '<%= this.ResolveUrl("~/App_form/ti/ti_bc_files.aspx") %>';
        form_P_MO(b_tenf, null, ["MA", [b_ma, b_ten]]);
        return true;
    }
    catch (err) { form_P_LOI(err); }
}
function P_EXCEL() {
    var a_cot = GridX_Fdt_cotGtri(b_grlkeId);
    var b_ma_bc = "report",
        b_ddan = '~/Templates/ns/', a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
    var b_kieu_in = 'E', b_ten_rp = b_ma_bc;
    var a_dt = GridX_Fdt_cotGtri(b_grlkeId);
    if (b_ten_rp == "") { form_P_LOI('Chưa chọn đúng báo cáo'); return; }
    sti_ch.Fs_EXCEL("ns_ngbc", "TT", b_ma_bc, b_ddan, b_ten_rp, b_kieu_in, a_dt_ct, a_dt, P_EXCEL_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function P_EXCEL_KQ(b_kq) {
    //?md=TT
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_MO(b_tmf + '/App_form/bc/xexcel.aspx?md=TT', null, null, "C");
}