var ns_tl_nghiphep_lkeCho, ns_tl_nghiphep_lkecbCho, b_vungId, b_grlkeId, b_grctId, b_mt;
function ns_tl_nghiphep_P_KD() {
    ns_tl_nghiphep_lkeCho, ns_tl_nghiphep_lkecbCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct');
    b_namId = form_Fs_TEN_ID(b_vungId, 'NAM'), b_phongId = form_Fs_TEN_ID(b_vungId, 'PHONG');
    b_slideId = b_grlkeId + '_slide';
    b_lblloai1Id = form_Fs_VTEN_ID('', 'lblloai1');
    b_lblloai2Id = form_Fs_VTEN_ID('', 'lblloai2');
    b_lblloai3Id = form_Fs_VTEN_ID('', 'lblloai3');
    b_lblloai4Id = form_Fs_VTEN_ID('', 'lblloai4');
    b_lblloai5Id = form_Fs_VTEN_ID('', 'lblloai5');
    b_lblloai6Id = form_Fs_VTEN_ID('', 'lblloai6');
    b_lblloai7Id = form_Fs_VTEN_ID('', 'lblloai7');
    b_lblloai8Id = form_Fs_VTEN_ID('', 'lblloai8');
    b_lblloai9Id = form_Fs_VTEN_ID('', 'lblloai9');
    b_lblloai10Id = form_Fs_VTEN_ID('', 'lblloai10');
    b_lblloai11Id = form_Fs_VTEN_ID('', 'lblloai11');
    b_lblloai12Id = form_Fs_VTEN_ID('', 'lblloai12');
    ns_tl_nghiphep_lkeCho = setInterval('ns_tl_nghiphep_P_LKE_CHO()', 200);
    ns_tl_nghiphep_lkecbCho = setInterval('ns_tl_nghiphep_P_LKE_CB_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        if (b_dtuong.indexOf("DAYPHONG") >= 0) {
            $get(b_phongId).value = a_tso[0];
            ns_tl_nghiphep_P_LKE();
            ns_tl_nghiphep_P_MA_KTRA();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_nghiphep_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "PHONG": b_maId = b_phongId; break;
            case "NAM": b_maId = b_namId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null) return;
        if (b_maTen == "PHONG") {
            ns_tl_nghiphep_P_LKE();
            ns_tl_nghiphep_P_MA_KTRA();
        }
        if (b_maTen == "NAM") {
            var b_nam = $get(b_namId).value;
            if (b_nam != "") {
                var b_hang = GridX_Fi_timHangD(b_grlkeId, "nam", b_nam);
                if (b_hang > -1) {
                    GridX_datA(b_grlkeId, b_hang);
                    ns_tl_nghiphep_P_CHUYEN_HANG();
                }
                else {
                    GridX_thoiA(b_grlkeId);
                    ns_tl_nghiphep_P_MA_KTRA();
                }
            }
            else $get(b_thangId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_tl_nghiphep_P_MA_KTRA() {
    try {
        var b_nam = C_NVL($get(b_namId).value);
        if (b_nam != "") {
            var b_phong = $get(b_phongId).value;
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            stl_ch.Fs_NS_TL_NGHIPHEP_MA(b_phong, b_nam, b_TrangKt, a_cot, ns_tl_nghiphep_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_nghiphep_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        form_P_MOI(b_vungId, "X"); GridX_datTrang(b_grctId);
        ns_tl_nghiphep_P_LKE_CB();
    }
    else { GridX_datA(b_grlkeId, b_hang); ns_tl_nghiphep_P_CHUYEN_HANG(); }
    return false;
}

function ns_tl_nghiphep_P_LKE_CB() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grctId), b_phong = $get(b_phongId).value;
        stl_ch.Fs_NS_TL_NGHIPHEP_LKE_CB(b_phong, a_cot, ns_tl_nghiphep_P_LKE_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_tl_nghiphep_P_LKE_CB_KQ(b_kq) {
    if (b_kq == "") { GridX_datTrang(b_grctId); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        GridX_dat_hangkt(b_grctId, a_kq[1]);
        GridX_datBang(b_grctId, a_kq[0]);
        return;
    }
}


var ns_tl_nghiphep_choAct = 0;
function ns_tl_nghiphep_GR_lke_RowChange() {
    if (ns_tl_nghiphep_choAct != 0) clearTimeout(ns_tl_nghiphep_choAct);
    ns_tl_nghiphep_choAct = setTimeout("ns_tl_nghiphep_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_tl_nghiphep_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_tl_nghiphep_lkeCho); ns_tl_nghiphep_P_LKE(); }
}
function ns_tl_nghiphep_P_LKE_CB_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_tl_nghiphep_lkecbCho); ns_tl_nghiphep_P_MA_KTRA(); }
}
function ns_tl_nghiphep_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    ns_tl_nghiphep_P_LKE_CB();
}
function ns_tl_nghiphep_P_LKE() {
    try {
        var b_phong = $get(b_phongId).value, a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_ch.Fs_NS_TL_NGHIPHEP_LKE(b_phong, a_tso, a_cot, ns_tl_nghiphep_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_nghiphep_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}

function ns_tl_nghiphep_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_loai1 = $get(b_lblloai1Id).innerHTML,
                b_loai2 = $get(b_lblloai2Id).innerHTML,
                b_loai3 = $get(b_lblloai3Id).innerHTML,
                b_loai4 = $get(b_lblloai4Id).innerHTML,
                b_loai5 = $get(b_lblloai5Id).innerHTML,
                b_loai6 = $get(b_lblloai6Id).innerHTML,
                b_loai7 = $get(b_lblloai7Id).innerHTML,
                b_loai8 = $get(b_lblloai8Id).innerHTML,
                b_loai9 = $get(b_lblloai9Id).innerHTML,
                b_loai10 = $get(b_lblloai10Id).innerHTML,
                b_loai11 = $get(b_lblloai11Id).innerHTML,
                b_loai12 = $get(b_lblloai12Id).innerHTML;
            var b_dt = form_Faa_TEXT_ROW(b_vungId),
                a_cot_ct = GridX_Fdt_cotGtri(b_grctId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
            stl_ch.Fs_NS_TL_NGHIPHEP_NH(b_TrangKt, b_loai1, b_loai2, b_loai3, b_loai4, b_loai5, b_loai6, b_loai7, b_loai8, b_loai9, b_loai10, b_loai11, b_loai12, b_dt, a_cot_ct, a_cot_lke, ns_tl_nghiphep_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_tl_nghiphep_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        GridX_datBang(b_grlkeId, a_kq[3]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datA(b_grlkeId, b_hang);
    }
    return false;
}
function ns_tl_nghiphep_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_nam = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "nam"));
    if (b_nam == null || b_nam == "") { form_P_MOI("", "XGL"); ns_tl_nghiphep_P_LKE_CB(); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId), b_phong = $get(b_phongId).value;
        stl_ch.Fs_NS_TL_NGHIPHEP_CT(b_phong, b_nam, a_cot_ct, ns_tl_nghiphep_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_tl_nghiphep_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_nam = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "nam"));
    $get(b_namId).value = b_nam;
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    var a_title = a_kq[0].split(';'); a_title = a_title[1].split('|');
    $get(b_lblloai1Id).innerHTML = "Tháng " + a_title[3];
    $get(b_lblloai2Id).innerHTML = "Tháng " + a_title[4];
    $get(b_lblloai3Id).innerHTML = "Tháng " + a_title[5];
    $get(b_lblloai4Id).innerHTML = "Tháng " + a_title[6];
    $get(b_lblloai5Id).innerHTML = "Tháng " + a_title[7];
    $get(b_lblloai6Id).innerHTML = "Tháng " + a_title[8];
    $get(b_lblloai7Id).innerHTML = "Tháng " + a_title[9];
    $get(b_lblloai8Id).innerHTML = "Tháng " + a_title[10];
    $get(b_lblloai9Id).innerHTML = "Tháng " + a_title[11];
    $get(b_lblloai10Id).innerHTML = "Tháng " + a_title[12];
    $get(b_lblloai11Id).innerHTML = "Tháng " + a_title[13];
    $get(b_lblloai12Id).innerHTML = "Tháng " + a_title[14];
    if (a_kq[1] == "") GridX_datTrang(b_grctId); else {
        GridX_dat_hangkt(b_grctId, a_kq[2]);
        GridX_datBang(b_grctId, a_kq[1]);
    }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    return false;
}
function ns_tl_nghiphep_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_nam = GridX_Fas_layGtri(b_grlkeId, b_hang, "nam");
    if (b_nam == "") ns_tl_nghiphep_P_MOI();
    else {
        var b_phong = $get(b_phongId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_ch.Fs_NS_TL_NGHIPHEP_XOA(b_phong, b_nam, a_tso, a_cot, ns_tl_nghiphep_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_tl_nghiphep_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_tl_nghiphep_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_tl_nghiphep_P_CHUYEN_HANG(); }
    }
    return false;
}


function ns_tl_nghiphep_TINH() {
    try {
        var b_phong = $get(b_phongId).value,
        b_nam = $get(b_namId).value;
        if (b_nam == null || b_nam == "") { alert("Phải nhập năm tính nghỉ phép"); }
        else {
            var a_cot = GridX_Fas_tenCot(b_grctId);
            stl_ch.Fs_NS_TL_NGHIPHEP_TINH(b_phong, b_nam, a_cot, ns_tl_nghiphep_P_TINH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_nghiphep_P_TINH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_title = Fas_ChMang(a_kq[0], ';');
    //$get(b_lblloai1Id).innerHTML = "Tháng " + b_title[0];
    //$get(b_lblloai2Id).innerHTML = "Tháng " + b_title[1];
    //$get(b_lblloai3Id).innerHTML = "Tháng " + b_title[2];
    //$get(b_lblloai4Id).innerHTML = "Tháng " + b_title[3];
    //$get(b_lblloai5Id).innerHTML = "Tháng " + b_title[4];
    //$get(b_lblloai6Id).innerHTML = "Tháng " + b_title[5];
    //$get(b_lblloai7Id).innerHTML = "Tháng " + b_title[6];
    //$get(b_lblloai8Id).innerHTML = "Tháng " + b_title[7];
    //$get(b_lblloai9Id).innerHTML = "Tháng " + b_title[8];
    //$get(b_lblloai10Id).innerHTML = "Tháng " + b_title[9];
    //$get(b_lblloai11Id).innerHTML = "Tháng " + b_title[10];
    //$get(b_lblloai12Id).innerHTML = "Tháng " + b_title[11];
    if (a_kq[1] == "") GridX_datTrang(b_grctId);
    else GridX_datBang(b_grctId, a_kq[1]);
    form_P_LOI('loi:Tổng hợp dữ liệu thành công:loi')
    return false;
}

function ns_tl_nghiphep_P_IN() {
    var a_cot = GridX_Fdt_cotGtri(b_grctId);
    var b_ma_bc = 'ns_ns_tl_nghiphep.xml',
        b_ddan = '~/Templates/ns/', a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
    var b_kieu_in = 'E', b_ten_rp = b_ma_bc;
    var a_dt = GridX_Fdt_cotGtri(b_grctId);
    if (b_ten_rp == "") { form_P_LOI('Chưa chọn đúng báo cáo'); return; }
    sti_ch.Fs_EXCEL_TIENLUONG("ns_ngbc", "TT", b_ma_bc, b_ddan, b_ten_rp, b_kieu_in, a_dt_ct, a_dt, P_EXCEL_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function P_EXCEL_KQ(b_kq) {
    //?md=TT
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_MO(form_Fs_TM() + '/App_form/bc/xexcel.aspx?md=TT', null, null, "C");
}

function ns_tl_nghiphep_phong() {
    try {
        var b_tenf = form_Fs_TM() + '/App_form/ht/ht_maph.aspx';
        form_P_MO(b_tenf, null, ["ns_tl_nghiphep", [""]]);
        return false;
    }
    catch (err) { }
}


function GridX_dat_hangkt(b_gridx, sodong) {
    try {
        var b_grid = $get(b_gridx);
        b_grid.setAttribute('hangKt', '25');
        var b_hangkt = GridX_Fi_hangKt(b_gridx);
        if (sodong > b_hangkt) {
            b_grid.setAttribute('hangKt', sodong - b_hangkt + 26);
        }
        return false;
    } catch (err) { form_P_LOI(err); }
}
function form_dong() {
    location.reload(false);
}