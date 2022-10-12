var ns_caidat_qly_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_so_idId, b_tenId, ns_caidat_qly_choAct = 0, b_magoc, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C';
function ns_caidat_qly_P_KD() {
    ns_caidat_qly_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct');
    b_slideId = b_grlkeId + '_slide';
    b_gocId = form_Fs_TEN_ID(b_vungId, 'MA');
    b_tenId = form_Fs_TEN_ID(b_vungId, 'ten');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    ns_caidat_qly_lkeCho = setInterval('ns_caidat_qly_P_LKE_CHO()', 200);
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[0];
        b_doi = 0;
        if (b_dtuong.indexOf("MA") >= 0) {
            $get(b_gocId).value = a_tso[0];
            $get(b_tenId).value = a_tso[1];
            GridX_datA(b_grctId, 1, "phong");
        } else if (b_dtuong.indexOf("PHONG") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            var b_count = a_tso
            if (a_tso[0] == "CMC-2M") {
                for (var i = 1; i < a_tso.length; i++) {
                    GridX_datGtri(b_grctId, b_hang, ["PHONG"], [a_tso[i][0]], 'K');
                    b_hang = b_hang + 1;
                }
            } else {
                GridX_datGtri(b_grctId, b_hang, ["PHONG"], [a_tso[0]], 'K');
            }
        }
        if (b_dtuong.indexOf("CDANH") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang > -1) { GridX_datGtri(b_grctId, b_hang, "CDANH", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}
function ns_caidat_qly_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
        }
        var b_ma = b_magoc = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        else if (b_maTen == "MA") {
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) {
                var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
                sns_tt.Fs_NS_CAIDAT_QLY_MA(b_ma.value, b_TrangKt, a_cot, ns_caidat_qly_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
            else { GridX_datA(b_grlkeId, b_hang); ns_caidat_qly_P_CHUYEN_HANG(); }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_caidat_qly_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        form_P_MOI(b_vungId, "X"); GridX_datTrang(b_grctId);
        skhac.Fs_MA_LOI(form_Fs_nsd(), b_magoc.getAttribute("ten"), b_magoc.value, b_magoc.getAttribute("ktra"), ns_caidat_qly_P_DatGchu2, P_LOI_CSDL, P_LOI_TGIAN);
    }
    else { GridX_datA(b_grlkeId, b_hang); ns_caidat_qly_P_CHUYEN_HANG(); }
}

function ns_caidat_qly_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grctId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        if (b_value != "") {
            if (b_cot == "PHONG") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Phòng ban", b_value, "ht_ma_phong,ma,ten", ns_caidat_qly_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
            if (b_cot == "CDANH") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Chức danh", b_value, "ns_ma_cdanh,ma,ten", ns_caidat_qly_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_caidat_qly_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    $get(b_gchuId).innerHTML = b_kq;
}

function ns_caidat_qly_P_DatGchu2(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    $get(b_tenId).value = b_kq;
    GridX_datA(b_grctId, 1, "phong");
}

var ns_caidat_qly_choAct = 0;
function ns_caidat_qly_GR_lke_RowChange() {
    if (ns_caidat_qly_choAct != 0) clearTimeout(ns_caidat_qly_choAct);
    ns_caidat_qly_choAct = setTimeout("ns_caidat_qly_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_caidat_qly_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (ns_caidat_qly_lkeCho != 0) clearTimeout(ns_caidat_qly_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_caidat_qly_P_LKE('K');
    }
}
function ns_caidat_qly_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_tt.Fs_NS_CAIDAT_QLY_LKE(a_cot, a_tso, ns_caidat_qly_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_caidat_qly_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
    return false;
}

function ns_caidat_qly_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    $get(b_gocId).focus();
    return false;
}
function ns_caidat_qly_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_dt = form_Faa_TEXT_ROW(b_vungId), a_cot_ct = GridX_Fdt_cotGtri(b_grctId),
                a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            sns_tt.Fs_NS_CAIDAT_QLY_NH(b_TrangKt, b_dt, a_cot_ct, a_cot_lke, ns_caidat_qly_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_caidat_qly_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
    }

}
function ns_caidat_qly_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
    if (b_ma == null || b_ma == "") {
        form_P_MOI(b_vungId, "GXL");
        GridX_datTrang(b_grctId);
    }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        sns_tt.Fs_NS_CAIDAT_QLY_CT(b_ma, a_cot_ct, ns_caidat_qly_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function ns_caidat_qly_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
    var b_ten = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten"));
    $get(b_gocId).value = b_ma; $get(b_tenId).value = b_ten;
    if (b_kq == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, b_kq);
    return false;
}

function ns_caidat_qly_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }

    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }
    var b_ma = $get(b_gocId).value;
    if (b_ma == null || b_ma == "") ns_caidat_qly_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_tt.Fs_NS_CAIDAT_QLY_XOA(b_ma, a_tso, a_cot, ns_caidat_qly_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_caidat_qly_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_caidat_qly_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_caidat_qly_P_CHUYEN_HANG(); }
    }
}

function ns_caidat_qly_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_caidat_qly_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_caidat_qly_chenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function ns_caidat_qly_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}
function form_dong() {
    location.reload(false);
}