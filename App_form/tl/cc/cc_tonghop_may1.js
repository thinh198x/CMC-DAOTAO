var cc_tonghop_may_lkeCho, cc_tonghop_may_lkecbCho, b_vungId, b_grlkeId, b_grctId, b_mt, b_so_theId;
function cc_tonghop_may_P_KD() {
    cc_tonghop_may_lkeCho, cc_tonghop_may_lkecbCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct');
    b_kyluongId = form_Fs_TEN_ID(b_vungId, 'KYLUONG'), b_phongId = form_Fs_TEN_ID(b_vungId, 'PHONG'), b_so_theId = form_Fs_TEN_ID(b_vungId, 'SO_THE');;
    b_slideId = b_grlkeId + '_slide';
    cc_tonghop_may_lkecbCho = setInterval('cc_tonghop_may_P_LKE_KTAO_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        if (b_dtuong.indexOf("DAYPHONG") >= 0) {
            $get(b_phongId).value = a_tso[0];
            cc_tonghop_may_P_MOI();
            cc_tonghop_may_P_LKE();
            cc_tonghop_may_P_LKE_CB();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function cc_tonghop_may_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "PHONG": b_maId = b_phongId; break;
            case "SO_THE": b_maId = b_so_theId; break;
            case "KYLUONG": b_maId = b_kyluongId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null) return;
        if (b_maTen == "PHONG") {
            cc_tonghop_may_P_MOI();
            cc_tonghop_may_P_LKE_KHOITAO();
        } else if (b_maTen == "KYLUONG") { 
            cc_tonghop_may_P_LKE_KHOITAO();
        }
        if (b_maTen == "SO_THE") {
            cc_tonghop_may_P_MOI();
            cc_tonghop_may_P_LKE_KHOITAO();
        } else if (b_maTen == "SO_THE") {
            cc_tonghop_may_P_LKE_KHOITAO();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_danhsach_P_NAM() {
    try {
        var b_nam = form_Fs_TEN_GTRI(b_vungId, 'nam');
        stl_cc.Fs_DANHSACH_KYLUONG_LKE(b_nam, ns_danhsach_P_KYLUONG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_danhsach_P_KYLUONG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_kyluongId = form_Fs_TEN_ID(b_vungId, 'kyluong');
        drop_P_LKE(b_kyluongId, b_kq);
    }
    cc_tonghop_may_P_KTRA("KYLUONG");
}
var cc_tonghop_may_choAct = 0;
function cc_tonghop_may_GR_lke_RowChange() {
    if (cc_tonghop_may_choAct != 0) clearTimeout(cc_tonghop_may_choAct);
    cc_tonghop_may_choAct = setTimeout("cc_tonghop_may_P_CHUYEN_HANG()", 300);
    return false;
}
function cc_tonghop_may_P_LKE_CB_CHO() {
    if ($get(b_grctId) != null) { clearTimeout(cc_tonghop_may_lkecbCho); cc_tonghop_may_P_LKE_CB(); }
}
function cc_tonghop_may_P_LKE_CB()
{
    var b_phong = $get(b_phongId).value,
        b_kyluong = $get(b_kyluongId).value;
    var a_cot = GridX_Fas_tenCot(b_grlkeId);
    stl_cc.Fs_CC_TONGHOP_MAY_LKE(b_phong, b_kyluong,a_cot, cc_tonghop_may_P_LKE_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function cc_tonghop_may_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grctId);
    GridX_datTrang(b_grctId);
}
function cc_tonghop_may_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_dt = form_Faa_TEXT_ROW(b_vungId),
                a_cot_ct = GridX_Fdt_cotGtri(b_grctId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);            
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function cc_tonghop_may_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
    }
    return false;
}
function cc_tonghop_may_P_LKE_KTAO_CHO() {
    if ($get(b_grctId) != null) { clearTimeout(cc_tonghop_may_lkecbCho); cc_tonghop_may_P_LKE_KHOITAO(); }
}
function cc_tonghop_may_P_LKE_KHOITAO() {
    var b_kyluong = $get(b_kyluongId).value;
    if (b_kyluong != null && b_kyluong != "") {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId), b_phong = $get(b_phongId).value, b_so_the = $get(b_so_theId).value, a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_cc.Fs_CC_TONGHOP_MAY_LKE(b_phong, b_kyluong, b_so_the, a_cot_ct, a_tso,cc_tonghop_may_P_TINH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
}
function cc_tonghop_may_EXCEL() {
    __doPostBack('ctl00$ContentPlaceHolder1$Nhap2', '');//Xuất Excel
}

function cc_tonghop_may_P_CHUYEN_HANG() {
    var b_kyluong = $get(b_kyluongId).value;
    if (b_kyluong == null || b_kyluong == "") { form_P_MOI("", "XGL"); cc_tonghop_may_P_LKE_CB(); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId), b_phong = $get(b_phongId).value, b_so_the = $get(b_so_theId).value, a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_cc.Fs_CC_TONGHOP_MAY_CT(b_phong, b_kyluong, b_so_the, a_cot_ct, a_tso,cc_tonghop_may_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function cc_tonghop_may_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    GridX_dat_hangkt(b_grctId, a_kq[1]);
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[0] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[0]);
}
function cc_tonghop_may_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grctId);
    if (b_hang < 1) return false;
    var b_thang = GridX_Fas_layGtri(b_grctId, b_hang, "thang");
    if (b_thang == "") cc_tonghop_may_P_MOI();
    else {
        var b_phong = $get(b_phongId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_cc.Fs_CC_TONGHOP_MAY_XOA(b_phong, b_thang, a_tso, a_cot, cc_tonghop_may_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function cc_tonghop_may_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) cc_tonghop_may_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); cc_tonghop_may_P_CHUYEN_HANG(); }
    }
} 
function cc_tonghop_may_P_CHUYEN_TIEN() {
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
function cc_tonghop_may_TINH() {
    try {
        var b_phong = $get(b_phongId).value,
        b_kyluong = $get(b_kyluongId).value;
        if (b_kyluong == null || b_kyluong == "") { alert("Phải nhập tháng tính lương"); }
        else {
            var a_cot = GridX_Fas_tenCot(b_grctId), a_tso = slide_Faobj_TUDEN(b_slideId), b_so_the = $get(b_so_theId).value;
            stl_cc.Fs_CC_TONGHOP_MAY_TINH(b_phong, b_kyluong,b_so_the, a_cot, a_tso,cc_tonghop_may_P_TINH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function cc_tonghop_may_P_TINH_KQ(b_kq) { 
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));    
    if (a_kq[0] == "") GridX_datTrang(b_grctId);
    else GridX_datBang(b_grctId, a_kq[1]); 
    return false;
} 
function cc_tonghop_may_P_IN() {
    var a_cot = GridX_Fdt_cotGtri(b_grctId);
    var b_ma_bc = 'ns_cc_tonghop_may.xml',
        b_ddan = '~/Templates/ns/', a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
    var b_kieu_in = 'E', b_ten_rp = b_ma_bc;
    var a_dt = GridX_Fdt_cotGtri(b_grctId);
    if (b_ten_rp == "") { form_P_LOI('Chưa chọn đúng báo cáo'); return; }
    sti_ch.Fs_EXCEL_TIENLUONG("ns_ngbc", "TT", b_ma_bc, b_ddan, b_ten_rp, b_kieu_in, a_dt_ct, a_dt, P_EXCEL_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
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
function cc_tonghop_may_phong() {
    try {
        var b_tenf = form_Fs_TM() + '/App_form/ht/ht_maph.aspx';
        form_P_MO(b_tenf, null, ["cc_tonghop_may", [""]]);
        return false;
    }
    catch (err) { }
} 
function form_dong() {
    location.reload(false);
}