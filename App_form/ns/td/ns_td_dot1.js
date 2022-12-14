var ns_td_dot_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gchuId, b_so_idId, b_moiId;
function ns_td_dot_P_KD() {
    ns_td_dot_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'); b_grvgId = form_Fs_VUNG_ID('GR_vg'); b_grycId = form_Fs_VUNG_ID('GR_yc');
    b_grlkeId = form_Fs_VUNG_ID('GR_lke');
    b_namId = form_Fs_TEN_ID(b_vungId, 'nam'), b_ngaydId = form_Fs_TEN_ID(b_vungId, 'ngayd');
    b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'); b_tendotId = form_Fs_TEN_ID(b_vungId, 'tendot');
    b_diemId = form_Fs_TEN_ID(b_vungId, 'diem');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_slideId = b_grlkeId + '_slide';
}
function ns_td_dot_P_NPA(b_nv) {
    if (b_nv == "vg") {
        var b_hang = GridX_Fi_timHangA(b_grycId);
        if (b_hang > 0) { GridX_datA(b_grvgId, b_hang); GridX_datA(b_grvgId, b_hang, "vong1"); }
        var b_gtri = GridX_Fdt_layGtri(b_grycId);
        var b_sott, b_nhom_cdanh, b_ma_dxuat,b_cdanh;
        for (var i = 1; i <= b_gtri.length; i++) {
            b_sott = GridX_Fas_layGtri(b_grycId, i, "sott");
            b_ma_dxuat = GridX_Fas_layGtri(b_grycId, i, "ma_dxuat");
            b_nhom_cdanh = GridX_Fas_layGtri(b_grycId, i, "ten_ncdanh");
            b_cdanh = GridX_Fas_layGtri(b_grycId, i, "ten_cdanh")
            GridX_datGtri(b_grvgId, i, ["sott", "ma_dxuat", "ten_ncdanh", "ten_cdanh"], [b_sott, b_ma_dxuat, b_nhom_cdanh, b_cdanh]);
            return false;
        }
    }
    if (b_nv == "yc") {
        var b_hang = GridX_Fi_timHangA(b_grvgId);
        if (b_hang > 0) { GridX_datA(b_grycId, b_hang); GridX_datA(b_grycId, b_hang, "soluong") }
        return false;
    }
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("MA_DXUAT") >= 0) {
            if (b_kq == "lưới") {
                var b_hang = GridX_Fi_timHangA(b_grycId);
                if (b_hang < 0) return;
                var b_nhom_cdanh = a_tso[2], b_cdanh = a_tso[3];
                sns_td.Fs_NS_TD_DOT_HOI_CDANH(b_nhom_cdanh, b_cdanh, ns_td_dot_P_HOI_CDANH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                GridX_datGtri(b_grycId, b_hang, ["ma_dxuat", "nhom_cdanh", "cdanh", "loai", "soluong", "noi_lv"],
                    [a_tso[1], a_tso[2], a_tso[3], a_tso[4], a_tso[5], a_tso[6]], 'K');
                GridX_datGtri(b_grvgId, b_hang, ["ma_dxuat"],[a_tso[1]], 'K');
                return false;
            }
            else {
                var b_sott = '0';
                var b_hang = GridX_Fi_timHangA(b_grycId);
                if (b_hang > 0) { GridX_datGtri(b_grycId, b_hang, "sott","");}
                var b_hangtrang = GridX_Fi_timHangT(b_grycId);
                if (b_hangtrang > 1) { b_sott = GridX_Fas_layGtri(b_grycId, b_hangtrang - 1, "sott"); }
                var a_cot = GridX_Fas_tenCot(b_grycId);
                sns_td.Fs_NS_TD_DOT_HOI_DXUAT(b_kq,a_tso[1],b_sott, a_cot, ns_td_dot_P_HOI_DXUAT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                return false;
            }
        }
        else if (b_dtuong.indexOf("NHOM_CDANH") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grycId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grycId, b_hang, ["nhom_cdanh"], [a_tso[0]], 'K');
            $get(b_gchuId).innerHTML = a_tso[1];
            GridX_datA(b_grycId, b_hang, "cdanh");
        }
        else if (b_dtuong.indexOf("CDANH") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grycId);
            if (b_hang < 0) return;
            var b_nhom_cdanh = GridX_Fas_layGtri(b_grycId, b_hang, "nhom_cdanh")
            if (b_nhom_cdanh != a_tso[2]) {
                alert("Vị trí công việc không thuộc nhóm chức danh đã chọn");
            }
            else {
                GridX_datGtri(b_grycId, b_hang, ["cdanh"], b_kq, 'K');
                $get(b_gchuId).innerHTML = a_tso[1];
                GridX_datA(b_grycId, b_hang, "soluong");
            }
        }
        else if (b_dtuong.indexOf("BANGCAP") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grvgId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grvgId, b_hang, ["bangcap"], [a_tso[0]], 'K');
            $get(b_gchuId).innerHTML = a_tso[1];
            GridX_datA(b_grvgId, b_hang, "chuyenmon");
        }
        else if (b_dtuong.indexOf("CHUYENMON") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grvgId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grvgId, b_hang, ["chuyenmon"], [a_tso[0]], 'K');
            $get(b_gchuId).innerHTML = a_tso[1];
            GridX_datA(b_grvgId, b_hang, "ngoaingu");
        }
        else if (b_dtuong.indexOf("NGOAINGU") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grvgId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grvgId, b_hang, ["ngoaingu"], [a_tso[0]], 'K');
            $get(b_gchuId).innerHTML = a_tso[1];
            GridX_datA(b_grvgId, b_hang, "uutien");
        }
        else if (b_dtuong.indexOf("MA_KH") >= 0) {
            $get(b_ma_khId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_gocId).focus();
        }
        else if (b_dtuong.indexOf("KQ") >= 0) {
            $get(b_phongId).value = a_tso[0];
            $get(b_gocId).value = a_tso[1];
            $get(b_lanId).value = a_tso[2];
            ns_td_dot_P_LKE();
            var b_hang = GridX_Fi_timHangD(b_grlkeId, ["ma", "lan"], [a_tso[1], a_tso[2]]);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_td_dot_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_td_dot_P_CHUYEN_HANG(); }
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_td_dot_P_HOI_CDANH_KQ(b_kq) {
    var b_hang = GridX_Fi_timHangA(b_grycId);
    if (b_hang < 0) return;
    var a_kq = Fas_ChMang(b_kq, ';'); var kq = Fas_ChMang(a_kq[1], '|');
    GridX_datGtri(b_grycId, b_hang, ["ten_ncdanh", "ten_cdanh"], [kq[0], kq[1]], 'K');
    GridX_datGtri(b_grvgId, b_hang, ["ten_ncdanh", "ten_cdanh"], [kq[0], kq[1]], 'K');
    return false;
}
function ns_td_dot_P_HOI_DXUAT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == "") return;
    else {
        b_hang = GridX_Fi_timHangT(b_grycId);
        GridX_chenBang(b_grycId, b_hang, b_kq);
        return false;
    }
}
function ns_td_dot_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "NAM": b_maId = b_phongId; form_P_MOI("", "XL"); break;
            case "MA": b_maId = b_gocId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            var b_nam = $get(b_namId).value;
            if (b_nam != "") {
                var b_hang = GridX_Fi_timHangD(b_grlkeId,"ma",b_ma.value);
                if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_td_dot_P_MA_KTRA(); }
                else { GridX_datA(b_grlkeId, b_hang); ns_td_dot_P_CHUYEN_HANG(); }
            }
        }
        else if (b_maTen == "NAM") ns_td_dot_P_LKE();
        else skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_td_dot_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_td_dot_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_nam = $get(b_namId).value;
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_td.Fs_NS_TD_DOT_MA(b_nam, b_ma, b_TrangKt, a_cot, ns_td_dot_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_td_dot_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_td_dot_P_CHUYEN_HANG(); }
    return false;
}

function ns_td_dot_Update_yc(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grycId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        var b_ktra = C_NVL(b_ctr.ktra), b_ten = C_NVL(b_ctr.ten);
        if (b_value != "") {
            if (b_cot == "MA_DXUAT") {
                
            }
        }
        if (b_value != "") GridX_ThemHang(b_grycId);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_td_dot_Update_vg(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grvgId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        var b_ktra = C_NVL(b_ctr.ktra), b_ten = C_NVL(b_ctr.ten);
        if (b_value != "") {
            if (b_cot == "VONG1" || b_cot == "VONG2" || b_cot == "VONG3" || b_cot == "VONG4" || b_cot == "VONG5"
                || b_cot == "VONG6" || b_cot == "VONG7" || b_cot == "VONG8" || b_cot == "VONG9" || b_cot == "VONG10") {
                skhac.Fs_MA_LOI(form_Fs_nsd(),b_ten, b_value, b_ktra, ns_td_dot_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        if (b_value != "") GridX_ThemHang(b_grycId);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_td_dot_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        if (a_kq.length > 1) { $get(b_cdanhId).value = a_kq[1]; $get(b_ma_cdanhId).value = a_kq[0]; }
        else form_P_DatGchu(b_gchuId, b_kq);
        return false;
    }
}
var ns_td_dot_choAct = 0;
function ns_td_dot_GR_lke_RowChange() {
    if (ns_td_dot_choAct != 0) clearTimeout(ns_td_dot_choAct);
    ns_td_dot_choAct = setTimeout("ns_td_dot_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_td_dot_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_td_dot_lkeCho); ns_td_dot_P_LKE(); }
}

function ns_td_dot_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grycId);
    GridX_datTrang(b_grvgId);
    $get(b_so_idId).value = "0";
    $get(b_phongId).focus();
    return false;
}
function ns_td_dot_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),b_nam = $get(b_namId).value;
        sns_td.Fs_NS_TD_DOT_LKE(b_nam, a_tso, a_cot, ns_td_dot_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_dot_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_td_dot_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_dt = form_Faa_TEXT_ROW(b_vungId), b_so_id = $get(b_so_idId).value, b_dt_yc = GridX_Fdt_cotGtri(b_grycId), b_dt_vg = GridX_Fdt_cotGtri(b_grvgId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            sns_td.Fs_NS_TD_DOT_NH(b_TrangKt, b_so_id, b_dt, b_dt_yc, b_dt_vg, a_cot_lke, ns_td_dot_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}

function ns_td_dot_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_phongId).focus(); $get(b_ykienId).value = '';
    }
    return false;
}
function ns_td_dot_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")),
        a_cot_yc = GridX_Fas_tenCot(b_grycId),
        a_cot_vg = GridX_Fas_tenCot(b_grvgId);
    if (b_so_id == "") ns_td_dot_P_MOI();
    else sns_td.Fs_NS_TD_DOT_CT(b_so_id, a_cot_yc, a_cot_vg, ns_td_dot_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    GridX_datA(b_grlkeId, b_hang);
    $get(b_so_idId).value = b_so_id;
}
function ns_td_dot_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grycId);
    else GridX_datBang(b_grycId, a_kq[1]);
    if (a_kq[2] == "") GridX_datTrang(b_grvgId);
    else GridX_datBang(b_grvgId, a_kq[2]);
}
function ns_td_dot_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") ns_td_dot_P_MOI();
    else {
        var b_phong = $get(b_phongId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_td.Fs_NS_TD_DOT_XOA(b_so_id, b_phong, a_tso, a_cot, ns_td_dot_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_td_dot_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_td_dot_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_td_dot_P_CHUYEN_HANG(); }
        return false;
    }
}
function ns_td_dot_HangLen() {
    var b_hang = GridX_Fi_timHangA(b_grycId);
    if (b_hang < 0) b_hang = GridX_Fi_timHangA(b_grvgId);
    if (b_hang > 0) {
        GridX_datA(b_grycId, b_hang);
        GridX_datA(b_grvgId, b_hang);
        GridX_chuyenHang(b_grvgId, -1);
        GridX_chuyenHang(b_grycId, -1);
    }
    return false;
}
function ns_td_dot_HangXuong() {
    var b_hang = GridX_Fi_timHangA(b_grycId);
    if (b_hang < 0) b_hang = GridX_Fi_timHangA(b_grvgId);
    if (b_hang > 0) {
        GridX_datA(b_grycId, b_hang);
        GridX_datA(b_grvgId, b_hang);
        GridX_chuyenHang(b_grvgId, 1);
        GridX_chuyenHang(b_grycId, 1);
    }
    return false;
}
function ns_td_dot_ChenDong(b_dk) {
    var b_hang = GridX_Fi_timHangA(b_grycId);
    if (b_hang < 0) b_hang = GridX_Fi_timHangA(b_grvgId);
    if (b_hang > 0) {
        GridX_datA(b_grycId, b_hang);
        GridX_datA(b_grvgId, b_hang);
        if (GridX_Fi_timHangC(b_grycId) < 1 || GridX_Fi_timHangC(b_grvgId) < 1) {
            var b_ctr = eval(window.name + '_P_HTOAN');
            if (b_ctr != null) b_ctr('C');
        }
        else if (C_NVL(b_dk) == 'C') { GridX_chenHang(b_grycId); GridX_chenHang(b_grvgId); }
    }
    return false;
}
function ns_td_dot_CatDong() {
    var b_hang = GridX_Fi_timHangA(b_grycId);
    if (b_hang < 0) b_hang = GridX_Fi_timHangA(b_grvgId);
    if (b_hang > 0) {
        GridX_datA(b_grycId, b_hang);
        GridX_datA(b_grvgId, b_hang);
        GridX_boChon(b_grycId, 'C');
        GridX_boChon(b_grvgId, 'C');
    }
    return false;
}

