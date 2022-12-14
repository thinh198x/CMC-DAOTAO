var b_tmf, b_vungId, b_grlkeId, b_ltieudeId, b_ten_bcId, b_gchuId, b_lrepId, b_loaiId, b_chon_inId,
    b_ma_tkId, b_ma_tkduId;
function ns_export_P_KD(b_tm) {
    b_tmf = b_tm; b_vungId = form_Fs_VUNG_ID('UPa_ct');
    b_grlkeId = form_Fs_VUNG_ID('GR_lke');
    ns_export_P_KTRA('LOAI_SL');
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (C_NVL(b_dtuong) == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("MA_TKDU") >= 0) { $get(b_ma_tkduId).value = b_kq; $get(b_ma_tkduId).focus(); }
        else if (b_dtuong.indexOf("MA_TK") >= 0) { $get(b_ma_tkId).value = b_kq; $get(b_ma_tkId).focus(); }
    }
    catch (err) { form_P_LOI(err); }
}
// KTRA
function ns_export_P_KTRA(b_maTen) {
    try {
        b_maTen = b_maTen.toUpperCase();
        if (b_maTen == "TEN_BC") {
            var b_ten_bc = $get(b_ten_bcId);
            if (b_ten_bc.selectedIndex > -1) {
                $get(b_lrepId).innerHTML = "Report: " + b_ten_bc.value;
                ns_export_P_DatGchu(b_ten_bc[b_ten_bc.selectedIndex].innerHTML);
            }
        }
        else if (b_maTen == "LOAI_SL") {
            var a_cot = GridX_Fas_tenCot(b_grlkeId);
            //đường dẫn mở lên file báo cáo     "~/App_from/bc/ns/", "ns_export"
            sbc.Fs_GRID_BC("~/App_form/bc/ns/", "ns_export", "TATCA", a_cot, ns_export_P_GRID_BC_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else {

            //skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_export_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_export_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_DatGchu(b_gchuId, b_kq);
}
function ns_export_P_GRID_BC_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang(b_grlkeId, b_kq);
}
function ns_export_GR_lke_RowChange() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_ma_bc = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma_bc"), ""),
            b_rep = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "rep"), ""),
            b_ten = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten"), ""),
            b_ddan = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ddan"), "");
        form_Fctr_TEN_DTUONG('', 'ten_menu').value = b_ma_bc;
        form_Fctr_TEN_DTUONG('', 'ddan').value = b_ddan;
        form_Fctr_TEN_DTUONG('', 'ten_rp').value = b_rep;
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_export_TEN_BC_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    drop_P_LKE(b_ten_bcId, b_kq);
    var b_ten_bc = $get(b_ten_bcId);
    if (b_ten_bc.selectedIndex > -1) {
        $get(b_gchuId).innerHTML = b_ten_bc[b_ten_bc.selectedIndex].innerHTML;
        $get(b_lrepId).innerHTML = b_ten_bc.value;
    }
}
///An hiển các control trên Sửa ở đây
function ns_export_HIEN_AN(b_ma_bc) {
    try {
        form_P_MOI('', "X");
        form_Fctr_TEN_DTUONG(b_vungId, 'ma_tk').disabled = form_Fctr_TEN_DTUONG(b_vungId, 'ma_nt').disabled = true;
        form_Fctr_TEN_DTUONG(b_vungId, 'ma_nh').disabled = form_Fctr_TEN_DTUONG(b_vungId, 'nh_tk').disabled = true;
        form_Fctr_TEN_DTUONG(b_vungId, 'ma_tkdu').disabled = form_Fctr_TEN_DTUONG(b_vungId, 'nhom').disabled = true;
        form_Fctr_TEN_DTUONG(b_vungId, 'ma_qui').disabled = form_Fctr_TEN_DTUONG(b_vungId, 'tien_dc').disabled = true;
        form_Fctr_TEN_DTUONG(b_vungId, 'ma_dvi').disabled = form_Fctr_TEN_DTUONG(b_vungId, 'ma_lc').disabled = true;
        form_Fctr_TEN_DTUONG(b_vungId, 'luu').disabled = form_Fctr_TEN_DTUONG(b_vungId, 'in_malc').disabled = true;

        switch (b_ma_bc) {
            case "tt_squi_tm": //Sổ qũi tiền mặt
                form_Fctr_TEN_DTUONG(b_vungId, 'ma_tk').disabled = form_Fctr_TEN_DTUONG(b_vungId, 'ma_nt').disabled = false;
                form_Fctr_TEN_DTUONG(b_vungId, 'ma_nh').disabled = form_Fctr_TEN_DTUONG(b_vungId, 'nh_tk').disabled = false;
                form_Fctr_TEN_DTUONG(b_vungId, 'ma_dvi').disabled = false;
                form_Fctr_TEN_DTUONG(b_vungId, 'ma_nt').value = "VND";
                sbc.Fs_SE_DVI(ns_export_P_DVI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                break;
            case "tt_soct_nh_ngte":
            case "tt_soct_nh_nte": //Sổ chi tiết ngân hàng nội tệ
                if (b_ma_bc == "tt_soct_nh_ngte") {
                    form_Fctr_TEN_DTUONG(b_vungId, 'ma_tk').value = "112";
                    form_Fctr_TEN_DTUONG(b_vungId, 'ma_nt').value = "USD";
                }
                else if (b_ma_bc == "tt_soct_nh_nte") {
                    form_Fctr_TEN_DTUONG(b_vungId, 'ma_tk').value = "112";
                    form_Fctr_TEN_DTUONG(b_vungId, 'ma_nt').value = "VND";
                }
                form_Fctr_TEN_DTUONG(b_vungId, 'ma_tk').disabled = form_Fctr_TEN_DTUONG(b_vungId, 'ma_nt').disabled = false;
                form_Fctr_TEN_DTUONG(b_vungId, 'ma_nh').disabled = form_Fctr_TEN_DTUONG(b_vungId, 'nh_tk').disabled = false;
                form_Fctr_TEN_DTUONG(b_vungId, 'ma_tkdu').disabled = form_Fctr_TEN_DTUONG(b_vungId, 'nhom').disabled = false;
                break;
            case "tt_bc_sdu_ct_nh": //Báo cáo số dư chi tiết tại ngân hàng
                form_Fctr_TEN_DTUONG(b_vungId, 'ma_nh').disabled = form_Fctr_TEN_DTUONG(b_vungId, 'nh_tk').disabled = false;
                break;
            case "tt_bc_tc_nte": //Thu chi ngoại tệ
                break;
            case "tt_bcqui": //Báo cáo số dư theo mã quỹ
                form_Fctr_TEN_DTUONG(b_vungId, 'ma_qui').disabled = form_Fctr_TEN_DTUONG(b_vungId, 'tien_dc').disabled = false;
                form_Fctr_TEN_DTUONG(b_vungId, 'ma_nt').value = "VND";
                break;
            case "tt_lke_ct_lc_tt": //Liệt kê chức từ lưu chuyển tiền tệ
                form_Fctr_TEN_DTUONG(b_vungId, 'ma_dvi').disabled = form_Fctr_TEN_DTUONG(b_vungId, 'ma_lc').disabled = false;
                sbc.Fs_SE_DVI(ns_export_P_DVI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                break;
            case "tt_bcao_lc_tt": //Báo cáo lưu chuyển tiền tệ
                form_Fctr_TEN_DTUONG(b_vungId, 'ma_tk').disabled = form_Fctr_TEN_DTUONG(b_vungId, 'ma_dvi').disabled = false;
                form_Fctr_TEN_DTUONG(b_vungId, 'luu').disabled = form_Fctr_TEN_DTUONG(b_vungId, 'in_malc').disabled = false;
                form_Fctr_TEN_DTUONG(b_vungId, 'ma_tk').value = "11";
                sbc.Fs_SE_DVI(ns_export_P_DVI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                break;
        }
    }
    catch (err) { form_P_LOI(err); }
}
//sửa đây
function ns_export_P_XEM() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return; }
        var b_ma_bc = form_Fctr_TEN_DTUONG('', 'ten_menu').value,
            b_ddan = form_Fctr_TEN_DTUONG('', 'ddan').value,
            a_dt_ct = form_Faa_TEXT_ROW(b_vungId),
            b_ten_rp = form_Fctr_TEN_DTUONG('', 'ten_rp').value;
        if (b_ten_rp == "") { form_P_LOI('Chưa chọn đúng báo cáo'); return; }
        //modul bhxh "ns_export", "TT", 
        sbc.Fs_BKT_LUU_TSO("ns_export", "TT", b_ma_bc, b_ddan, b_ten_rp,'X', a_dt_ct, ns_export_P_XEM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
//Sửa đây
function ns_export_P_XEM_KQ(b_kq) {
    //?md=TT
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_kieu_in = "X";
    var b_excel = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "excel"), "");
    if (b_excel == "C" && b_kieu_in == "X") { form_P_MO(b_tmf + '/App_form/bc/ExcelView.aspx?md=TT', null, null, "C"); return false; }
    else { form_P_MO(b_tmf + '/App_form/bc/xem_bc.aspx?md=TT', null, null, "C"); return false;}
}
function ns_export_P_CHON_IN() {
    var b_chon_in = document.getElementById(b_chon_inId);
    var b_chon = b_chon_in.getElementsByTagName('input');
    for (var x = 0; x < b_chon.length; x++)
    { if (b_chon[x].checked) return b_chon[x].value; }

}
function ns_export_P_DVI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_Fctr_TEN_DTUONG(b_vungId, 'ma_dvi').value = b_kq;
}