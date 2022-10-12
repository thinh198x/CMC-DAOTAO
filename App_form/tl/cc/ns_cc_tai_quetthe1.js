var ns_cc_tai_quetthe_lkeCho, ns_cc_tai_quetthe_lkecbCho, b_vungId, b_grlkeId, b_grctId, b_mt,b_nsd,b_ten,b_so_the,b_ngayd,b_ngayc;
function ns_cc_tai_quetthe_P_KD(nsd, ten) {
    b_nsd = nsd, b_ten = ten;
    ns_cc_tai_quetthe_lkeCho, ns_cc_tai_quetthe_lkecbCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grctId = form_Fs_VUNG_ID('GR_ct');
    b_may_ccId = form_Fs_TEN_ID(b_vungId, 'MAY_CC');b_ngayd = form_Fs_TEN_ID(b_vungId, 'ngayd'); b_ngayc = form_Fs_TEN_ID(b_vungId, 'ngayc');    
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            $get(b_may_ccId).value = b_nsd; 
            $get(b_gchuId).innerHTML = a_tso[1];
            ns_cc_tai_quetthe_P_LKE();
            $get(b_gocId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_tai_quetthe_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MAY_CC": b_maId = b_may_ccId; break; 
        }
        var b_ma = $get(b_maId);
        if (b_ma == null) return;
        if (b_maTen == "MAY_CC") {
            ns_cc_tai_quetthe_P_MOI();             
        } 
    }
    catch (err) { form_P_LOI(err); }
}
var ns_cc_tai_quetthe_choAct = 0;
function ns_cc_tai_quetthe_GR_lke_RowChange() {
    if (ns_cc_tai_quetthe_choAct != 0) clearTimeout(ns_cc_tai_quetthe_choAct);
    ns_cc_tai_quetthe_choAct = setTimeout("ns_cc_tai_quetthe_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_cc_tai_quetthe_P_LKE_CHO() {
    $get(b_may_ccId).value = b_nsd;
    if ($get(b_grctId) != null) { clearTimeout(ns_cc_tai_quetthe_lkeCho); ns_cc_tai_quetthe_P_LKE(); }
}
function ns_cc_tai_quetthe_P_MOI() {
    form_P_MOI(b_vungId, "GXL"); 
    GridX_datTrang(b_grctId); 
}
function ns_cc_tai_quetthe_P_LKE() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var b_may_cc = $get(b_may_ccId).value, a_cot = GridX_Fas_tenCot(b_grctId);
        var b_ngaybd = $get(b_ngayd).value, b_ngaykt = $get(b_ngayc).value;
        stl_cc.Fs_CC_TAI_QUET_THE_LKE(a_cot, b_may_cc, b_ngaybd, b_ngaykt, ns_cc_tai_quetthe_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_tai_quetthe_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang(b_grctId, b_kq);
}
function ns_cc_tai_quetthe_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_dt = form_Faa_TEXT_ROW(b_vungId),
                a_cot_ct = GridX_Fdt_cotGtri(b_grctId), b_TrangKt = GridX_Fi_hangKt(b_grctId), a_cot_lke = GridX_Fas_tenCot(b_grctId);
            stl_cc.Fs_CC_QUET_THE_NH(b_TrangKt, b_dt, a_cot_ct, a_cot_lke, ns_cc_tai_quetthe_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_cc_tai_quetthe_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);        
    }
    return false;
}
function ns_cc_tai_quetthe_P_CHUYEN_HANG() {
    
}
function ns_cc_tai_quetthe_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    GridX_dat_hangkt(b_grctId, a_kq[1]);
    if (a_kq[0] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[0]);
}

function GridX_dat_hangkt(b_gridx, sodong) {
    try {
        var b_grid = $get(b_gridx);
        b_grid.setAttribute('hangKt', '23');
        var b_hangkt = GridX_Fi_hangKt(b_gridx);
        if (sodong > b_hangkt) {
            b_grid.setAttribute('hangKt', sodong - b_hangkt + 24);
        }
        return false;
    } catch (err) { form_P_LOI(err); }
}
function ns_cc_tai_quetthe_P_XOA() {     
}
function ns_cc_tai_quetthe_P_XOA_KQ(b_kq) {     
} 
function ns_cc_tai_quetthe_P_CHUYEN_TIEN() {
    try {
        var b_tenf = '<%= this.ResolveUrl("~/App_form/bc/tl_ngbc.aspx") %>',
            b_phong = $get(b_phongId).value,
            b_thang = $get(b_thangId).value,
            b_ten_phong = document.getElementById(b_phongId)[document.getElementById(b_phongId).selectedIndex].innerText;
        if (b_thang == null || b_thang == "") { alert("Chưa chọn chi tiết"); }
        else {
            var b_tso = b_phong + "#" + b_thang + "#" + b_ten_phong;
            form_P_MO(b_tenf, null, ["BL", [b_tso]], null);
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_cc_tai_quetthe_TINH() {
    try {
        var b_phong = $get(b_phongId).value,
        b_thang = $get(b_thangId).value;
        if (b_thang == null || b_thang == "") { alert("Phải nhập tháng tính lương"); }
        else {
            var a_cot = GridX_Fas_tenCot(b_grctId);
            stl_cc.Fs_CC_QUET_THE_TINH(b_phong, b_thang, a_cot, ns_cc_tai_quetthe_P_TINH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_tai_quetthe_P_TINH_KQ(b_kq) {
    
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    GridX_dat_hangkt(b_grctId, a_kq[1]);
    if (a_kq[0] == "") GridX_datTrang(b_grctId);
    else GridX_datBang(b_grctId, a_kq[0]);
    return false;
}

function ns_cc_tai_quetthe_P_IN() {
    var a_cot = GridX_Fdt_cotGtri(b_grctId);
    var b_ma_bc = 'ns_ns_cc_tai_quetthe.xml',
        b_ddan = '~/Templates/ns/', a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
    var b_kieu_in = 'E', b_ten_rp = b_ma_bc;
    var a_dt = GridX_Fdt_cotGtri(b_grctId);
    if (b_ten_rp == "") { form_P_LOI('Chưa chọn đúng báo cáo'); return; }
    sns_tt.Fs_EXCEL("ns_ngbc", "TT", b_ma_bc, b_ddan, b_ten_rp, b_kieu_in, a_dt_ct, a_dt, P_EXCEL_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function P_EXCEL_KQ(b_kq) {
    //?md=TT
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
function ns_cc_tai_quetthe_phong() {
    try {
        var b_tenf = form_Fs_TM() + '/App_form/ht/ht_maph.aspx';
        form_P_MO(b_tenf, null, ["ns_cc_tai_quetthe", [""]]);
        return false;
    }
    catch (err) { }
}