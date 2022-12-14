var b_tmf, ns_danhsach_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_ma_dvi, b_choAct_fi = 0,
b_iurlId, b_dchiId, b_nc_cmtId, b_nhaId, b_nha_dchiId, b_nhomId, b_ngaydId, b_iurl, b_mt, b_klkId,
b_phongId, b_mastId, b_nhanId, b_tenId, b_sotkId, b_tenhoaId, b_nsinhId, b_gchuId, b_so_idId, b_tenphongId;
function ns_danhsach_P_KD() {
    ns_danhsach_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_vungtkId = form_Fs_VUNG_ID('Upa_tk'),
    b_grccId = form_Fs_VUNG_ID('GR_cc'); b_grdaId = form_Fs_VUNG_ID('GR_da')
    b_phong_tkId = form_Fs_TEN_ID(b_vungtkId, 'phong_tk');
    b_ten_tkId = form_Fs_TEN_ID(b_vungtkId, 'ten_tk');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_slideId = b_grlkeId + '_slide';
    b_grctId = form_Fs_VUNG_ID('GR_ct');
    ns_danhsach_lkeCho = setInterval('ns_danhsach_P_LKE_CHO()', 200);
    b_klkId = form_Fs_VTEN_ID('', 'klk');
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        b_doi = 0;
        if (b_dtuong.indexOf("NC_CMT") >= 0) {
            $get(b_nc_cmtId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_dchiId).focus();
        }
        else if (b_dtuong.indexOf("NS_ANH") >= 0) {
            sns_tt.Fs_ns_danhsach_ANH(Fs_ns_danhsach_ANH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
        else if (b_dtuong.indexOf("NHA") >= 0) {
            $get(b_nhaId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_nha_dchiId).value = a_tso[2];
            $get(b_mastId).focus();
        }
        else if (b_dtuong.indexOf("NHOM") >= 0) {
            $get(b_nhomId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_ngaydId).focus();
        }
        else if (b_dtuong.indexOf("THOIVIEC") >= 0) {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "')", 200);
        }
        else if (b_dtuong.indexOf("THONGKE") >= 0) {
            b_cho_control = setInterval("P_cho2('" + a_tso[0] + "')", 200);
            return false;
        }
        else if (b_dtuong.indexOf("MA") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang > -1) {
                GridX_datGtri(b_grctId, b_hang, "ma", b_kq);
                GridX_datGtri(b_grctId, b_hang, "ten", a_tso[1]);
            }
        }
        else if (b_dtuong.indexOf("CC") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grccId);
            if (b_hang > -1) {
                GridX_datGtri(b_grccId, b_hang, "cc", a_tso[0]);
                GridX_datGtri(b_grccId, b_hang, "ten", a_tso[1]);
            }
        }
        else if (b_dtuong.indexOf("DA") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grdaId);
            if (b_hang > -1) {
                GridX_datGtri(b_grdaId, b_hang, "da", a_tso[0]);
                GridX_datGtri(b_grdaId, b_hang, "ten_da", a_tso[1]);
            }
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_danhsach_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_mt = b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "PHONG_TK": b_maId = b_phong_tkId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "PHONG_TK") {
            ns_danhsach_P_LKE();
        }
    }
    catch (err) { form_P_LOI(err); }
}


function ns_danhsach_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_danhsach_lkeCho); ns_danhsach_TIMKIEM(); }
}

function ns_danhsach_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    return false;
}
function ns_danhsach_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_phong = $get(b_phong_tkId).value;
        var b_lke = ($get(b_klkId).innerHTML == "Hoạt động") ? "0" : "1";
        sns_tt.Fs_NS_CB_LKE(b_phong, b_lke, a_tso, a_cot, ns_danhsach_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_danhsach_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    return false;
}

function ns_danhsach_TIMKIEM() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var a_dt_ct = form_Faa_TEXT_ROW(b_vungtkId);
        var a = $get(b_klkId).innerHTML;
        var b_lke = ($get(b_klkId).innerHTML == "Hoạt động") ? "0" : "1";
        sns_tt.Fs_NS_CB_DANHSACH(a_dt_ct, b_lke, a_tso, a_cot, ns_danhsach_TIMKIEM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_danhsach_TIMKIEM_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    ns_danhsach_P_MOI();
    return false;
}

function ns_danhsach_TIM() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt_cn = form_Faa_TEXT_ROW(b_vungtkId);
            var b_lke = ($get(b_klkId).innerHTML == "Hoạt động") ? "0" : "1";
            var b_dt = form_Faa_TEXT_ROW(b_vungId),
                a_cot_ct = GridX_Fdt_cotGtri(b_grctId),
                a_cot_cc = GridX_Fdt_cotGtri(b_grccId);
            var a_cot_kq = GridX_Fas_tenCot(b_grlkeId);
            sns_tt.Fs_NS_DANHSACH_TIM(b_lke, a_dt_cn, a_cot_kq, a_cot_ct, a_cot_cc, ns_danhsach_TIM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_danhsach_TIM_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    GridX_dat_hangkt(b_grlkeId, a_kq[1]);
    if (a_kq[0] == "") GridX_datTrang(b_grlkeId); else GridX_datBang(b_grlkeId, a_kq[0]);
    return false;
}




// START: Trả giá trị chọn trên lưới //       
// Tra gia tri chon cho form goi
function form_P_TRA_CHON_GRID(b_ten) {
    try {
        var a_kq = form_P_TRA_GTRI_GRID(b_ten);
        form_P_DONG(window.name, a_kq);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
// Tra mang gia tri theo ten
function form_P_TRA_GTRI_GRID(b_ten) {
    try {
        var a_ten = b_ten.split(','), a_kq = [];
        for (var i = 0; i < a_ten.length; i++) {
            var a_grid = a_ten[i].split(':');
            var b_gridId = form_Fs_VUNG_ID(a_grid[0]);
            var b_hang = GridX_Fi_timHangA(b_gridId);
            a_kq[i] = GridX_Fas_layGtri(b_gridId, b_hang, a_grid[1]);
        }
        return a_kq;
    }
    catch (err) { return null; }
}
// END: Trả giá trị chọn trên lưới // 
function ns_danhsach_mo(b_kq) {
    if (b_kq == 'C') {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 0) {
            var b_so_the = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the");
            form_P_MO("ns_cb.aspx", null, ["CT", [b_so_the]]);
        }
    }
    else form_P_MO("ns_cb.aspx", null, ["MOI", null]);
    return false;
}

function ns_kynang_cn_P_TIM() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_dt = form_Faa_TEXT_ROW(b_vungId),
                a_cot_ct = GridX_Fdt_cotGtri(b_grctId);
            var a_cot_kq = GridX_Fas_tenCot(b_grlkeId);
            sns_tt.Fs_NS_KYNANG_CN_TIM(a_cot_kq, a_cot_ct, ns_kynang_cn_P_TIM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_kynang_cn_P_TIM_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    GridX_dat_hangkt(b_grlkeId, a_kq[1]);
    if (a_kq[0] == "") GridX_datTrang(b_grlkeId); else GridX_datBang(b_grlkeId, a_kq[0]);
    return false;
}


function GridX_dat_hangkt(b_gridx, sodong) {
    try {
        var b_grid = $get(b_gridx);
        b_grid.setAttribute('hangKt', '17');
        var b_hangkt = GridX_Fi_hangKt(b_gridx);
        if (sodong > b_hangkt) {
            b_grid.setAttribute('hangKt', sodong - b_hangkt + 18);
        }
        return false;
    } catch (err) { form_P_LOI(err); }
}

function ns_danhsach_P_IN() {
    var a_cot = GridX_Fdt_cotGtri(b_grlkeId);
    //var b_ma_bc = 'ns_tl_bluong.xml',
    var b_ma_bc = 'ns_danhsach.xml',
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
        sbc.Fs_BKT_LUU_TSO("ns_export", "TT", b_ma_bc, b_ddan, b_ten_rp, 'X', a_dt_ct, ns_export_P_XEM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
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
    else { form_P_MO(b_tmf + '/App_form/bc/xem_bc.aspx?md=TT', null, null, "C"); return false; }
}

function ns_danhsach_P_NCDANH() {
    try {
        b_ncdanh = form_Fs_TEN_GTRI(b_vungId, 'ncdanh');
        sns_ma_ch.Fs_NS_MA_CDANH_LKE_DR(b_ncdanh, ns_danhsach_P_NCDANH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_danhsach_P_NCDANH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        b_cdanhId = form_Fs_TEN_ID(b_vungId, 'cdanh');
        drop_P_LKE(b_cdanhId, b_kq);
    }
}
function ns_danhsach_ct_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_danhsach_ct_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_danhsach_ct_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function ns_danhsach_ct_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}

function ns_danhsach_cc_HangLen() {
    GridX_chuyenHang(b_grccId, -1);
    return false;
}
function ns_danhsach_cc_HangXuong() {
    GridX_chuyenHang(b_grccId, 1);
    return false;
}
function ns_danhsach_cc_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grccId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grccId);
    return false;
}
function ns_danhsach_cc_CatDong() {
    GridX_boChon(b_grccId, 'C');
    return false;
}
function ns_menu_tbao_ct_P_CB() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) {
        form_P_LOI('loi:Chưa chọn cán bộ:loi');
        return false;
    }
    try {
        var b_so_the = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the");
        var b_tenf = form_Fs_TM('f') + '/ns/tt/ns_cb.aspx';
        form_P_MO(b_tenf, null, ["THONGKE", [b_so_the]], "");
        form_P_LOI();
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function form_dong() {
    location.reload(false);
}
