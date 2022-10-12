var ns_phucloi_tudong_lkeCho, ns_phucloi_tudong_lkecbCho, b_vungId, b_grctId, b_mt, b_phong_Id, b_ctyValue, b_ctrbeforId, b_so_the_Id, b_ho_ten_Id, b_ngayD_Id,
    b_ngayC_Id, b_ma_phong_Id, b_nsd;
function ns_phucloi_tudong_P_KD() {
    ns_phucloi_tudong_lkecbCho = setInterval('ns_phucloi_tudong_P_LKE_KTAO_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        if (b_dtuong.indexOf("DAYPHONG") >= 0) {
            var b_phong_tk = form_Fctr_TEN_DTUONG(b_vungId, 'dr_phongban');
            lke_P_DAT(b_phong_tk, a_tso[0] + "{" + a_tso[1]);
            $get(b_ma_phong_Id).value = a_tso[0];

            //$get(b_phongId).value = a_tso[0];
            //ns_phucloi_tudong_P_MOI();
            //ns_phucloi_tudong_P_LKE();
            //ns_phucloi_tudong_P_LKE_CB();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_phucloi_tudong_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "DR_PHONGBAN": b_maId = b_phong_tk_Id; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null) return;
        if (b_maTen == "DR_PHONGBAN") {
            $get(b_ma_phong_Id).value = lke_Fs_TRA(b_maId);
        }
    }
    catch (err) { form_P_LOI(err); }
}
 
function ns_phucloi_tudong_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grctId);
    GridX_datTrang(b_grctId);
} 
function ns_phucloi_tudong_IN() {
    __doPostBack('ctl00$ContentPlaceHolder1$Nhap2', '');
} 
function ns_phucloi_tudong_P_LKE_KTAO_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(ns_phucloi_tudong_lkecbCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grctId = form_Fs_VUNG_ID('GR_ct');
        b_phong_Id = form_Fs_TEN_ID(b_vungId, 'dr_phongban');
        b_so_the_Id = form_Fs_TEN_ID(b_vungId, 'so_the_tk');
        b_ho_ten_Id = form_Fs_TEN_ID(b_vungId, 'hoten_tk');
        b_ngayD_Id = form_Fs_TEN_ID(b_vungId, 'NGAY_D');
        b_ngayC_Id = form_Fs_TEN_ID(b_vungId, 'NGAY_C');
        b_ma_phong_Id = form_Fs_VTEN_ID('UPa_hi', 'ma_phong');
        b_slideId = $get(b_grctId).getAttribute('slideId');
        lke_P_DAT($get(b_phong_Id), 'TATCA' + '{' + 'Tất cả');
        b_nsd = form_Fs_nsd();

        slide_P_SOTRANG(b_slideId, 0);
        form_F_GOC().P_MENUBf(window.name, 'M');
        vb_cctc_P_SL('', 'D', '0', ' ', ' ', 'T');
        b_ctyValue = "TATCA";  
    }
}

function ns_phucloi_tudong_P_LKE(b_dk) {
    if (b_dk == 'C') slide_P_MOI(b_slideId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var b_phong = lke_Fs_TRA(b_phong_Id), b_so_the = $get(b_so_the_Id).value, b_hoTen = $get(b_ho_ten_Id).value,
        b_ngayD = $get(b_ngayD_Id).value, b_ngayC = $get(b_ngayC_Id).value;
    var a_cot_ct = GridX_Fas_tenCot(b_grctId), a_tso = slide_Faobj_TUDEN(b_slideId);
    sns_tt.Fs_NS_PHUCLOI_TU_DONG_LKE(b_nsd, b_phong, b_so_the, b_hoTen, b_ngayD, b_ngayC, a_cot_ct, a_tso, ns_phucloi_tudong_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;

}
function ns_phucloi_tudong_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grctId, a_kq[1]);
}
function ns_phucloi_tudong_TINH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }

        var b_phong = lke_Fs_TRA(b_phong_Id), b_so_the = $get(b_so_the_Id).value, b_hoTen = $get(b_ho_ten_Id).value,
            b_ngayD = $get(b_ngayD_Id).value, b_ngayC = $get(b_ngayC_Id).value;
        var a_cot = GridX_Fas_tenCot(b_grctId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_tt.Fs_NS_PHUCLOI_TU_DONG_TINH(b_nsd, b_ctyValue, b_so_the, b_hoTen, b_ngayD, b_ngayC, a_cot, a_tso, ns_phucloi_tudong_P_TINH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;

    }
    catch (err) { form_P_LOI(err); }
}
function ns_phucloi_tudong_P_TINH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grctId, a_kq[1]);
    form_P_LOI("loi:Tổng hợp dữ liệu thành công:loi"); return false;
}

function ns_phucloi_tudong_P_IN() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    else {
        var b_btn_excel = form_Fs_VTEN_ID('', 'excel_an'); $get(b_btn_excel).click(); form_chay = 0; return false;
    }

    //var a_cot = GridX_Fdt_cotGtri(b_grctId);
    //var b_ma_bc = 'ns_ns_phucloi_tudong.xml',
    //    b_ddan = '~/Templates/ns/', a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
    //var b_kieu_in = 'E', b_ten_rp = b_ma_bc;
    //var a_dt = GridX_Fdt_cotGtri(b_grctId);
    //if (b_ten_rp == "") { form_P_LOI('Chưa chọn đúng báo cáo'); return; }
    ////sti_ch.Fs_EXCEL_TIENLUONG("ns_ngbc", "TT", b_ma_bc, b_ddan, b_ten_rp, b_kieu_in, a_dt_ct, a_dt, P_EXCEL_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    //return false;
}
function P_EXCEL_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_MO(form_Fs_TM() + '/App_form/bc/xexcel.aspx?md=TT', null, null, "C");
}

function GridX_dat_hangkt(b_gridx, sodong) {
    try {
        var b_grid = $get(b_gridx);
        b_grid.setAttribute('hangKt', '21');
        var b_hangkt = GridX_Fi_hangKt(b_gridx);
        if (sodong > b_hangkt) {
            b_grid.setAttribute('hangKt', sodong - b_hangkt + 22);
        }
        return false;
    } catch (err) { form_P_LOI(err); }
}
function ns_phucloi_tudong_phong() {
    try {
        var b_tenf = form_Fs_TM() + '/App_form/ht/ns_hs_cctc_quyen.aspx';
        form_P_MO(b_tenf, null, [window.name, [""]]);
        return false;
    }
    catch (err) { }
}
function vb_cctc_P_CLICK(b_event, b_id) {
    b_event.stopPropagation();
    var b_targetClassNam = b_event.target.className;
    if (b_targetClassNam == "ico_bptt") { 
        var b_ctr = $get(b_id), b_div = $get(b_id + '_Div');
        var a_tso = Attribute_Fas_LAY(b_ctr, 'loai,cap,dvi,ma,ma_ct');
        if (b_ctrbeforId != null) b_ctrbeforId.style.fontWeight = "100";
        b_ctr.style.fontWeight = "700";
        b_ctrbeforId = b_ctr;
        b_ctyValue = a_tso[3];
        //ns_phucloi_tudong_P_LKE('K');
        return false;
    }
    else {
        var b_ctr = $get(b_id), b_div = $get(b_id + '_Div');
        var a_tso = Attribute_Fas_LAY(b_ctr, 'loai,cap,dvi,ma,ma_ct');
        if (a_tso[0] == 'A') return false;
        if (a_tso[0] != 'C') {
            if (b_div == null) vb_cctc_P_SL(b_id, a_tso[0], a_tso[1], a_tso[2], a_tso[3]);
            else {
                b_id = (C_NVL(b_div.style.display) == '') ? '' : b_id;
                vb_cctc_HIEN(a_tso[4], b_id);
            }
        }
    }
    return false;
}
function form_dong() {
    location.reload(false);
}