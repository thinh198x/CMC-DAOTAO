var b_lkeCho, b_vungId, b_grlkeId, b_slideId, b_tenId, b_phongId, b_cdanhId, b_gocId, b_timId,
    ns_cc_ma_ghcp_choAct = 0;

// kiểm tra
function ns_cc_ma_ghcp_P_KD() {
    b_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct');
    b_grlkeId = form_Fs_VUNG_ID('GR_lke');
    b_grctId = form_Fs_VUNG_ID('GR_ct');
    b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE');
    b_tenId = form_Fs_TEN_ID(b_vungId, 'TEN');
    b_sotheTkId = form_Fs_TEN_ID('', 'SO_THE_TK');
    b_tenTkId = form_Fs_TEN_ID('', 'TEN_NV_TK');
    b_phongId = form_Fs_TEN_ID(b_vungId, 'TEN_PHONG');
    b_cdanhId = form_Fs_TEN_ID(b_vungId, 'TEN_CDANH');
    b_slideId = b_grlkeId + '_slide';
    b_nsd = form_Fs_nsd();
    b_lkeCho = setInterval('ns_cc_ma_ghcp_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("MAPC") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang > -1) {
                GridX_datGtri(b_grctId, b_hang, "mapc", b_kq);
                GridX_datGtri(b_grctId, b_hang, "tenpc", a_tso[1]);
                GridX_datA(b_grctId, b_hang, "hso");
            }
        } else if (b_dtuong.indexOf("SO_THE") >= 0) {
            $get(b_gocId).value = a_tso[0];
            tra_thong_tin(a_tso[0]);
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_gocId).focus();

        }
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_cc_ma_ghcp_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "SO_THE") {
            tra_thong_tin(b_ma.value);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_ma_ghcp_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            stl_ma.Fs_CC_MA_GHCP_MA(b_nsd, b_ma, b_TrangKt, a_cot, ns_cc_ma_ghcp_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_ma_ghcp_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        form_P_MOI(b_vungId, "X");
        $get(b_conggioId).value = '1'
        $get(b_conggio2Id).value = '1';
    }
    else { GridX_datA(b_grlkeId, b_hang); ns_cc_ma_ghcp_P_CHUYEN_HANG(); }
}
// Nhập
function ns_cc_ma_ghcp_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    return false;
}
function ns_cc_ma_ghcp_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var a_dt = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        var b_so_the = $get(b_sotheTkId).value;
        var b_ten_nv = $get(b_tenTkId).value;
        stl_ma.Fs_CC_MA_GHCP_NH(b_nsd, b_so_the, b_ten_nv, b_TrangKt, a_dt, a_cot, ns_cc_ma_ghcp_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    } catch (err) { form_P_LOI(err); }
}
function ns_cc_ma_ghcp_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI("loi:Nhập thành công!:loi");
    }
    return false;
}
// Xóa
function ns_cc_ma_ghcp_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_so_the = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the");

    var b_so_the_tk = $get(b_sotheTkId).value;
    var b_ten_nv_tk = $get(b_tenTkId).value;

    if (b_so_the == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); ns_cc_ma_ghcp_P_MOI(); }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_ma.Fs_CC_MA_GHCP_XOA(b_nsd, b_so_the, b_so_the_tk, b_ten_nv_tk, a_tso, a_cot, ns_cc_ma_ghcp_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_cc_ma_ghcp_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_cc_ma_ghcp_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_cc_ma_ghcp_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
}
// CHuyển hàng
function ns_cc_ma_ghcp_GR_lke_RowChange() {
    if (ns_cc_ma_ghcp_choAct != 0) clearTimeout(ns_cc_ma_ghcp_choAct);
    ns_cc_ma_ghcp_choAct = setTimeout("ns_cc_ma_ghcp_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_cc_ma_ghcp_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_the = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the"));
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        if (b_so_the == "") {
            form_P_MOI(b_vungId, "XGL");
            GridX_datTrang(b_grctId);
            //$get(b_conggioId).value = '1';
            //$get(b_conggio2Id).value = '1';
        }
        else stl_ma.Fs_CC_MA_GHCP_CT(b_nsd, b_so_the, a_cot_ct, ns_cc_ma_ghcp_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_ma_ghcp_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    if (a_kq[0] == "") { form_P_MOI("", "X"); return; }
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    var b_hang = GridX_Fi_timHangA(b_grlkeId);

}
// Liệt kê
function ns_cc_ma_ghcp_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (b_lkeCho != 0) clearTimeout(b_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_cc_ma_ghcp_P_LKE('K');
    }
}
function ns_cc_ma_ghcp_P_LKE(b_dk) {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId);
        var a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_so_the = $get(b_sotheTkId).value;
        var b_ten_nv = $get(b_tenTkId).value;
        stl_ma.Fs_CC_MA_GHCP_LKE(b_nsd, b_so_the, b_ten_nv, a_tso, a_cot, ns_cc_ma_ghcp_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_cc_ma_ghcp_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
// Check mã nhân viên
function tra_thong_tin(b_so_the) {
    try {
        sns_ls.Fs_NS_PCAP_TRA(b_so_the, tra_thong_tin_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function tra_thong_tin_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    $get(b_phongId).value = a_kq[0]; $get(b_cdanhId).value = a_kq[1]; $get(b_tenId).value = a_kq[2];
}
function form_dong() {
    location.reload(false);
}