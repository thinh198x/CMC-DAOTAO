var tl_bluong_cn_lkeCho, tl_bluong_cn_lkecbCho, b_vungId, b_grlkeId, b_grctId, b_mt, b_nsd, b_ten, b_kyluongId, b_lienheId, b_thacmacId, b_dtuongId;
function tl_bluong_cn_P_KD(nsd, ten) {
    b_nsd = nsd, b_ten = ten;
    tl_bluong_cn_lkeCho, tl_bluong_cn_lkecbCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_ct'), b_grctId = form_Fs_VUNG_ID('GR_ct');
    b_so_theId = form_Fs_TEN_ID(b_vungId, 'SO_THE');
    b_kyluongId = form_Fs_TEN_ID(b_vungId, 'KYLUONG'); b_lienheId = form_Fs_VTEN_ID('', 'lbllienhe'); b_thacmacId = form_Fs_VTEN_ID('', 'lblthacmac');
    b_dtuongId = form_Fs_VTEN_ID(b_vungId, 'CO_LANHDAO'); 
    tl_bluong_cn_TTCB(b_nsd);
    tl_bluong_cn_lkeCho = setInterval('tl_bluong_cn_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            $get(b_so_theId).value = b_nsd;
            //$get(b_gocId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            tl_bluong_cn_P_LKE();
            $get(b_gocId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function tl_bluong_cn_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "KYLUONG": b_maId = b_kyluongId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null) return;
    }
    catch (err) { form_P_LOI(err); }
}

var tl_bluong_cn_choAct = 0;
function tl_bluong_cn_GR_lke_RowChange() {
    if (tl_bluong_cn_choAct != 0) clearTimeout(tl_bluong_cn_choAct);
    tl_bluong_cn_choAct = setTimeout("tl_bluong_cn_P_CHUYEN_HANG()", 300);
    return false;
}

function tl_bluong_cn_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);

}
// lấy dữ liệu
function tl_bluong_cn_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        $get(b_so_theId).value = b_nsd;
        clearTimeout(tl_bluong_cn_lkeCho); tl_bluong_cn_P_LKE();
    }
}
function tl_bluong_cn_P_LKE() {
    try {
        var b_so_the = $get(b_so_theId).value, a_cot = GridX_Fas_tenCot(b_grlkeId);
        var b_kyluong = form_Fs_TEN_GTRI(b_vungId, 'KYLUONG'), b_dtuong = $get(b_dtuongId).value;
        tl_bluong_cn_load_tt_P_LKE();
        stl_ch.Fs_TL_BLUONG_CN_LKE(b_so_the, b_kyluong, b_dtuong, a_cot, tl_bluong_cn_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function tl_bluong_cn_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        GridX_datBang(b_grlkeId, b_kq);

    }
}

function tl_bluong_cn_load_tt_P_LKE() {
    try {
        var b_kyluong = form_Fs_TEN_GTRI(b_vungId, 'KYLUONG');
        stl_ch.Fs_TTLH_BLUONG_CN_LKE(b_kyluong, tl_bluong_cn_load_tt_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);

    }
    catch (err) { form_P_LOI(err); }
}
function tl_bluong_cn_load_tt_P_LKE_KQ(b_kq) {
    if (b_kq != "") {
        var a_kq = b_kq.split('#');
        $get(b_thacmacId).innerHTML = a_kq[0];
        $get(b_lienheId).innerHTML = "Anh/chị có thắc mắc về lương tháng " + a_kq[1] + " vui lòng phản hồi lại BP DVNS để được giải đáp trước ngày " + a_kq[2] + ".";
    }
}

function tl_bluong_cn_P_NAM() {
    try {
        form_P_MOI(b_vungId, "N");
        var b_nam = form_Fs_TEN_GTRI(b_vungId, 'NAM');
        hts_dungchung.Fs_NS_KYLUONG_CHUNG_LKE(form_Fs_nsd(), window.name, b_nam);
    }
    catch (ex) { form_P_LOI(ex.message); }
}

function tl_bluong_cn_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_thang = GridX_Fas_layGtri(b_grlkeId, b_hang, "thangcc");
    if (b_thang == "") tl_bluong_cn_P_MOI();
    else {
        var b_phong = $get(b_phongId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_ch.Fs_tl_bluong_cn_VN_XOA(b_phong, b_thang, a_tso, a_cot, tl_bluong_cn_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function tl_bluong_cn_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) tl_bluong_cn_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); tl_bluong_cn_P_CHUYEN_HANG(); }
    }
}

function tl_bluong_cn_P_CHUYEN_TIEN() {
    try {
        var b_tenf = '<%= this.ResolveUrl("~/App_form/bc/tl_ngbc.aspx") %>',
            b_phong = $get(b_phongId).value,
            b_thang = $get(b_thangId).value,
            b_ten_phong = document.getElementById(b_phongId)[document.getElementById(b_phongId).selectedIndex].innerText;
        if (b_thang == null || b_thang == "") { alert("Chưa chọn chi tiết"); }
        else {
            var b_tso = b_phong + "#" + b_thang + "#" + b_ten_phong;
            form_P_MO(b_tenf, null, ["BL", [b_tso]], "C");
        }
    }
    catch (err) { form_P_LOI(err); }
}

function tl_bluong_cn_P_IN() {
    var a_cot = GridX_Fdt_cotGtri(b_grctId);
    var b_ma_bc = 'ns_tl_bluong_cn.xml',
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

// lấy thông tin cán bộ
function tl_bluong_cn_TTCB(b_so_the) {
    try {
        hts_dungchung.Fs_THONGTIN_CANBO(b_so_the, tl_bluong_cn_TTCB_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function tl_bluong_cn_TTCB_kq(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}

function form_dong() {
    location.reload(false);
}