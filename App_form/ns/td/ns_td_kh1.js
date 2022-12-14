var ns_td_kh_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gchuId, b_so_idId, b_moiId;
function ns_td_kh_P_KD() {
     ns_td_kh_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'); b_grctId = form_Fs_VUNG_ID('GR_ct'); b_grlkeId = form_Fs_VUNG_ID('GR_lke');
     b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'), b_ngayId = form_Fs_TEN_ID(b_vungId, 'ngay'), b_ykienId = form_Fs_TEN_ID(b_vungId, 'ykien'),
     b_ngaydkId = form_Fs_TEN_ID(b_vungId, 'ngaydk'),b_tenId = form_Fs_TEN_ID(b_vungId, 'ten'),b_kinhphiId = form_Fs_TEN_ID(b_vungId, 'kinhphi');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_slideId = b_grlkeId + '_slide';
    ns_td_kh_lkeCho = setInterval('ns_td_kh_P_LKE_CHO()', 200);
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("NHOM_CDANH") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grctId, b_hang, ["nhom_cdanh"], [a_tso[0]], 'K');
            $get(b_gchuId).innerHTML = a_tso[1];
            GridX_datA(b_grctId, b_hang, "cdanh");
        }
        else if (b_dtuong.indexOf("CDANH") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            var b_nhom_cdanh = GridX_Fas_layGtri(b_grctId, b_hang, "nhom_cdanh")
            if (b_nhom_cdanh != a_tso[2]) {
                alert("Vị trí công việc không thuộc nhóm chức danh đã chọn");
            }
            else {
                GridX_datGtri(b_grctId, b_hang, ["cdanh"], b_kq, 'K');
                $get(b_gchuId).innerHTML = a_tso[1];
                GridX_datA(b_grctId, b_hang, "phong");
            }
        }
        else if (b_dtuong.indexOf("PHONG") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grctId, b_hang, ["phong"], [a_tso[0]], 'K');
            $get(b_gchuId).innerHTML = a_tso[1];
            GridX_datA(b_grctId, b_hang, "soluong");
        }
        else if (b_dtuong.indexOf("KQ") >= 0) {
            $get(b_phongId).value = a_tso[0];
            $get(b_ngayId).value = a_tso[1];
            ns_td_kh_P_LKE();
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ngay", a_tso[1]);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_td_kh_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_td_kh_P_CHUYEN_HANG(); }
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_td_kh_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; form_P_MOI("", "XL"); break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_td_kh_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_td_kh_P_CHUYEN_HANG(); }
        }
        else skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_td_kh_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function ns_td_kh_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_td.Fs_NS_TD_KH_MA(b_ma, b_TrangKt, a_cot, ns_td_kh_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_kh_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_td_kh_P_CHUYEN_HANG(); }
}

function ns_td_kh_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grctId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        var b_ktra = C_NVL(b_ctr.ktra), b_ten = C_NVL(b_ctr.ten);
        if (b_value != "") {
            if (b_cot == "NHOM_CDANH") {
                skhac.Fs_MA_LOI(form_Fs_nsd(),b_ten, b_value, b_ktra, ns_td_kh_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
            if (b_cot == "CDANH") {
                skhac.Fs_MA_LOI(form_Fs_nsd(),b_ten, b_value, b_ktra, ns_td_kh_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
            if (b_cot == "PHONG") {
                skhac.Fs_MA_LOI(form_Fs_nsd(),b_ten, b_value, b_ktra, ns_td_kh_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        if (b_value != "") GridX_ThemHang(b_grctId);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_td_kh_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        if (a_kq.length > 1) { $get(b_cdanhId).value = a_kq[1]; $get(b_ma_cdanhId).value = a_kq[0]; }
        else form_P_DatGchu(b_gchuId, b_kq);
    }
}
var ns_td_kh_choAct = 0;
function ns_td_kh_GR_lke_RowChange() {
    if (ns_td_kh_choAct != 0) clearTimeout(ns_td_kh_choAct);
    ns_td_kh_choAct = setTimeout("ns_td_kh_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_td_kh_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_td_kh_lkeCho); ns_td_kh_P_LKE(); }
}

function ns_td_kh_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    $get(b_so_idId).value = "0";
    $get(b_gocId).focus();
    return false;
}
function ns_td_kh_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_td.Fs_NS_TD_KH_LKE(a_tso, a_cot, ns_td_kh_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_kh_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    $get(b_gocId).focus();
}
function ns_td_kh_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_dt = form_Faa_TEXT_ROW(b_vungId),b_so_id = $get(b_so_idId).value, b_dt_ct = GridX_Fdt_cotGtri(b_grctId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            sns_td.Fs_NS_TD_KH_NH(b_TrangKt, b_so_id, b_dt, b_dt_ct, a_cot_lke, ns_td_kh_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}

function ns_td_kh_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_ngayId).focus(); $get(b_ykienId).value = '';
        $get(b_so_idId).value = a_kq[4];
    }
    return false;
}
function ns_td_kh_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")),
        a_cot = GridX_Fas_tenCot(b_grctId);
    if (b_so_id == "") ns_td_kh_P_MOI();
    else sns_td.Fs_NS_TD_KH_CT(b_so_id, a_cot, ns_td_kh_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    GridX_datA(b_grlkeId, b_hang);
    $get(b_so_idId).value = b_so_id;
}
function ns_td_kh_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId);
    else GridX_datBang(b_grctId, a_kq[1]);
}
function ns_td_kh_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") ns_td_kh_P_MOI();
    else {
        var b_ma = $get(b_gocId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_td.Fs_NS_TD_KH_XOA(b_so_id,b_ma, a_tso, a_cot, ns_td_kh_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_td_kh_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_td_kh_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_td_kh_P_CHUYEN_HANG(); }
    }
}
function ns_td_kh_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_td_kh_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_td_kh_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function ns_td_kh_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}