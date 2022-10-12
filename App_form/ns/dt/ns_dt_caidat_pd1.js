var b_lkeCho, b_choAct = 0, b_vungId, b_grlkeId, b_slideId, b_hangId, b_chonId, b_loitt = 0, b_grctId, b_gchuId, b_so_idId, b_moiId, a_ftso, b_dviId, b_fcho = 'C';
function ns_dt_caidat_pd_P_KD() {
    b_lkeCho = setInterval('ns_dt_caidat_pd_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    if (C_NVL(b_dtuong) != '') {
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grctId, b_hang, ["so_the"], [a_tso[0]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["ten"], [a_tso[1]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["phong"], [a_tso[2]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["ten_phong"], [a_tso[3]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["email"], [a_tso[10]], 'K');
        }
    }
}
function P_KET_QUA_KQ() {
    try {
        if (b_choAct != 0) clearInterval(b_choAct);
        var b_dtuong = b_fdtuong.toUpperCase(), a_tso = Farr_copy(a_ftso), b_kq = a_tso[0];
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grctId, b_hang, ["so_the"], [a_tso[0]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["ten"], [a_tso[1]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["phong"], [a_tso[2]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["ten_phong"], [a_tso[3]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["email"], [a_tso[10]], 'K');
        }
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_dt_caidat_pd_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_t = b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; form_P_MOI("", "XGL"); break;
        }
        b_chonId = b_maTen;
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        else if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_dt_caidat_pd_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_dt_caidat_pd_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_datTrang(b_grctId);
    $get(b_so_idId).value = "0";
    $get(b_loaiId).focus();
    return false;
}
function ns_dt_caidat_pd_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_dt = form_Faa_TEXT_ROW(b_vungId), b_dt_ct = GridX_Fdt_cotGtri(b_grctId);
            var b_loai = $get(b_loaiId).value
            sns_dt.Fs_NS_DT_CAIDAT_PD_NH(b_dt, b_loai, b_dt_ct, ns_dt_caidat_pd_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_dt_caidat_pd_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        form_P_LOI('loi:Nhập thành công!:loi');
        ns_dt_caidat_pd_P_CHUYEN_HANG();
        $get(b_loaiId).focus();
    }
    return false;
}
function ns_dt_caidat_pd_P_CHUYEN_HANG() {
    var b_loai = $get(b_loaiId).value;

    var b_dvi = lke_Fs_TRA($get(b_dviId));
    var a_cot = GridX_Fas_tenCot(b_grctId);
    var b_loaichon = $get(b_loaiId).value;
    if (b_loaichon != "DXN") {
        GridX_anCot(b_grctId, "so_ngay", "none"); Attribute_P_DAT($get(b_grctId), "WIDTH", "820px");
    } else {
        GridX_anCot(b_grctId, "so_ngay", ""); Attribute_P_DAT($get(b_grctId), "WIDTH", "1100px");
    }
    sns_dt.Fs_NS_DT_CAIDAT_PD_CT(b_loai, b_dvi, a_cot, ns_dt_caidat_pd_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_dt_caidat_pd_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId);
    else GridX_datBang(b_grctId, a_kq[1]);
}
function ns_dt_caidat_pd_P_XOA() {
    var b_loai = $get(b_loaiId).value, b_hang = GridX_Fi_timHangA(b_grctId), b_loi = form_Fs_TEXT_KTRA(b_vungId);
    var so_the = GridX_Fas_layGtri(b_grctId, b_hang, "so_the");
    var b_so_id = $get(b_so_idId).value;
    if (b_hang < 1) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    if (so_the == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    else {
        sns_dt.Fs_NS_DT_CAIDAT_PD_XOA(so_the, b_loai, ns_dt_caidat_pd_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
}
function ns_dt_caidat_pd_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        ns_dt_caidat_pd_P_CHUYEN_HANG();
        form_P_LOI('loi:Xóa thành công!:loi');
        return false;
    }
}
function ns_dt_caidat_pd_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        b_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grctId = form_Fs_VUNG_ID('GR_ct');
        b_loaiId = form_Fs_TEN_ID(b_vungId, 'loai');
        b_dviId = form_Fs_TEN_ID(b_vungId, 'dvi');
        b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
        b_gchuId = form_Fs_VTEN_ID('', 'gchu');
        b_moiId = form_Fs_VTEN_ID('', 'moi');
        if (b_lkeCho != 0) clearTimeout(b_lkeCho);
        ns_dt_caidat_pd_P_CHUYEN_HANG();
    }
}
function ns_dt_caidat_pd_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_dt_caidat_pd_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_dt_caidat_pd_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function ns_dt_caidat_pd_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}
function ns_dt_caidat_pd_P_CHON() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_check = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tinhtrang"));
    if (b_check == "Chưa phê duyệt") { form_P_LOI('loi:Không thể chọn khóa đào tạo chưa phê duyệt:loi'); return; }
    else form_P_TRA_CHON('MA,TEN');
}
function ns_dt_caidat_pd_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
    }
    else { form_P_DatGchu(b_gchuId, b_kq); }
}
function ns_dt_caidat_pd_Update(b_event) {
    try {
        b_loitt = 0;
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grctId); b_hangId = b_hang;
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        if (b_value != "") {
            if (b_cot == "SO_THE") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Mã nhân viên", b_value, "ns_cb,so_the,ten", ns_dt_caidat_pd_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
                sns_tt.Fs_NS_CB_HOI(b_value, ns_dt_caidat_pd_P_CB_HOI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_caidat_pd_P_CB_HOI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var b_hang = GridX_Fi_timHangA(b_grctId);
    var a_kq = Fas_ChMang(b_kq, '#');
    GridX_datGtri(b_grctId, b_hangId, ["so_the"], [a_kq[0]], 'K');
    GridX_datGtri(b_grctId, b_hangId, ["phong"], [a_kq[1]], 'K');
    GridX_datGtri(b_grctId, b_hangId, ["ten"], [a_kq[2]], 'K');
    GridX_datGtri(b_grctId, b_hangId, ["email"], [a_kq[3]], 'K');
    // GridX_datGtri(b_grctId, b_hang-1, ["so_ngay"], [a_kq[3]], 'K');
    GridX_ThemHang(b_grctId);
}
function form_dong() {
    location.reload(false);
}