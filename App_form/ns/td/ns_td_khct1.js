var b_tmf, ns_td_khct_lkeCho, b_vungId, b_grlkeId, b_slideId,b_gchuId, b_so_idId,  b_trangthai_tk, b_phongycId,
 b_trangthaiId, b_grntk, b_ten_form, b_ma_ycId, b_co_gapId, b_cdanhId, b_namId, b_thangId, b_phongId, b_co_kh_namId, b_so_ngay_dxId, b_theo_kh_namId,
 b_duanId, b_tuoi_tuId, b_tuoi_denId, b_xuatExcelId, b_thangAntkId, b_phongAntkId, b_sl_cantuyenId, b_canbo_pv1, b_canbo_pv2, b_canbo_pv3, b_cdanh_cb1,
 b_vungctttId, b_cdanh_cb2, b_cdanh_cb3, b_sl_dexuat_tuyenId, b_luong_tuId, b_luong_denId, b_vungtkId, b_grmtId, b_grpaId, b_ma_yctkId, b_cdanhtkId,
 b_phongtkId, b_thangtkId, b_namtkId, ns_td_khct_chuyenhang_cho, ns_td_khct_choAct;
function ns_td_khct_P_KD(b_xuatExcel) {
    b_xuatExcelId = b_xuatExcel;
    ns_td_khct_lkeCho, ns_td_khct_chuyenhang_cho = 0, ns_td_khct_choAct = 0,b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtkId = form_Fs_VUNG_ID('UPa_tk'), 
    b_grlkeId = form_Fs_VUNG_ID('GR_lke'),b_grmtId = form_Fs_VUNG_ID('GR_mt'), b_grpaId = form_Fs_VUNG_ID('GR_pa'), b_vungtkId = form_Fs_VUNG_ID('Upa_tk'),
    b_namtkId = form_Fs_TEN_ID(b_vungtkId, 'nam_tk'), b_thangtkId = form_Fs_TEN_ID(b_vungtkId, 'thang_tk'), b_phongtkId = form_Fs_TEN_ID(b_vungtkId, 'phong_tk'),
    b_cdanhtkId = form_Fs_TEN_ID(b_vungtkId, 'cdanh_tk'), b_ma_yctkId = form_Fs_TEN_ID(b_vungtkId, 'ma_yc_tk'), b_vungctttId = form_Fs_VUNG_ID('UPa_cttt'),
    b_cdanhId = form_Fs_TEN_ID(b_vungId, 'cdanh'), b_namId = form_Fs_TEN_ID(b_vungId, 'nam'), b_thangId = form_Fs_TEN_ID(b_vungId, 'thang'),
    b_phongycId = form_Fs_TEN_ID(b_vungId, 'phong_yc'), b_phongId = form_Fs_TEN_ID(b_vungId, 'phong');
    b_co_gapId = form_Fs_TEN_ID(b_vungId, 'co_gap'), b_co_kh_namId = form_Fs_TEN_ID(b_vungId, 'co_kehoach_nam'), b_so_ngay_dxId = form_Fs_TEN_ID(b_vungId, 'so_ngay_dx'),
    b_theo_kh_namId = form_Fs_TEN_ID(b_vungId, 'theo_kehoach'), b_duanId = form_Fs_TEN_ID(b_vungId, 'du_an'), b_tuoi_tuId = form_Fs_TEN_ID(b_vungId, 'tuoi_tu'),
    b_tuoi_denId = form_Fs_TEN_ID(b_vungId, 'tuoi_den'), b_luong_tuId = form_Fs_TEN_ID(b_vungId, 'luong_tu'), b_luong_denId = form_Fs_TEN_ID(b_vungId, 'luong_den'),
    b_canbo_pv1 = form_Fs_TEN_ID(b_vungId, 'canbo_pv1'), b_canbo_pv2 = form_Fs_TEN_ID(b_vungId, 'canbo_pv2'), b_canbo_pv3 = form_Fs_TEN_ID(b_vungId, 'canbo_pv3'),
    b_cdanh_cb1 = form_Fs_TEN_ID(b_vungId, 'cdanh_cb1'), b_cdanh_cb2 = form_Fs_TEN_ID(b_vungId, 'cdanh_cb2'), b_cdanh_cb3 = form_Fs_TEN_ID(b_vungId, 'cdanh_cb3'),
    b_sl_cantuyenId = form_Fs_TEN_ID(b_vungId, 'sl_cantuyen'), b_sl_dexuat_tuyenId = form_Fs_TEN_ID(b_vungId, 'sl_dexuat_td'),
    b_ma_ycId = form_Fs_TEN_ID(b_vungId, 'ma'); b_gchuId = form_Fs_VTEN_ID('', 'gchu'); b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_thangAntkId = form_Fs_VTEN_ID('UPa_hi', 'thangtk'); b_phongAntkId = form_Fs_VTEN_ID('UPa_hi', 'phongtk');
    b_psId = form_Fs_VTEN_ID('UPa_hi', 'ps'), b_nvId = form_Fs_VTEN_ID('UPa_hi', 'nv');
    b_slideId = b_grlkeId + '_slide';
    ns_td_khct_lkeCho = setInterval('ns_td_khct_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (typeof (b_dtuong) == "undefined") return false;
        if (b_dtuong == null || b_dtuong == "") return;
        b_ten_form = a_tso[0];
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        b_doi = 0;
        if (b_dtuong.indexOf("PHONG_YC") >= 0) {
            $get(b_phongycId).value = b_kq;
            $get(b_gchuId).value = a_tso[1];
        } else if (b_dtuong.indexOf("PHONG") >= 0) {
            $get(b_phongId).value = b_kq;
            $get(b_gchuId).value = a_tso[1];
            Fs_ns_td_khct_P_DINHBIEN();
            Fs_ns_td_khct_P_LAN();
        } else if (b_dtuong.indexOf("CDANH") >= 0) {
            $get(b_cdanhId).value = b_kq;
            $get(b_gchuId).value = a_tso[1];
            Fs_ns_td_khct_P_DINHBIEN();
            Fs_ns_td_khct_P_LAN();
            Fs_ns_td_khct_P_VONGTHI();
        } else if (b_dtuong.indexOf("CANBO_PV1") >= 0) {
            $get(b_canbo_pv1).value = b_kq;
            $get(b_cdanh_cb1).value = a_tso[6];
            $get(b_gchuId).value = a_tso[1];
        } else if (b_dtuong.indexOf("CANBO_PV2") >= 0) {
            $get(b_canbo_pv2).value = b_kq;
            $get(b_cdanh_cb2).value = a_tso[6];
            $get(b_gchuId).value = a_tso[1];
        } else if (b_dtuong.indexOf("CANBO_PV3") >= 0) {
            $get(b_canbo_pv3).value = b_kq;
            $get(b_cdanh_cb3).value = a_tso[6];
            $get(b_gchuId).value = a_tso[1];
        } else if (b_dtuong.indexOf("DU_AN") >= 0) {
            $get(b_duanId).value = b_kq;
            $get(b_gchuId).value = a_tso[1];
        } else if (b_dtuong.indexOf("THEO_KEHOACH") >= 0) {
            $get(b_theo_kh_namId).value = b_kq;
            $get(b_gchuId).value = a_tso[1];
        } else if (b_dtuong.indexOf("TEN_PA") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grpaId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grpaId, b_hang, ["sott"], [1], 'K');
            GridX_datGtri(b_grpaId, b_hang, ["ma_pa"], [a_tso[0]], 'K');
            GridX_datGtri(b_grpaId, b_hang, ["ten_pa"], [a_tso[1]], 'K');
            GridX_chenHang(b_grpaId, 1, 1);
            $get(b_gchuId).value = a_tso[1];
        }
        else if (b_dtuong.indexOf("THAMSO") >= 0) { b_ma_ycId = a_tso[1]; }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_khct_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_mt = b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_ma_ycId; break;
            case "CDANH": b_maId = b_cdanhId; break;
            case "CO_GAP": b_maId = b_co_gapId; break;
            case "CO_KEHOACH_NAM": b_maId = b_co_kh_namId; break;
        }
        var b_ma = $get(b_maId);
        if (b_maTen != "CO_GAP" && b_maTen != "CO_KEHOACH_NAM")
            if (b_ma == null || C_NVL(b_ma.value) == "") return;
            else skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_td_khct_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
        if (b_maTen == "CDANH") {
            Fs_ns_td_khct_P_DINHBIEN();
            Fs_ns_td_khct_P_LAN();
            Fs_ns_td_khct_P_VONGTHI();
        } else if (b_maTen == "MA") {
            ns_td_khct_P_MA_KTRA();
        }
        else if (b_maTen == "CO_GAP") {
            if ($get(b_co_gapId).value == "X") $get(b_so_ngay_dxId).removeAttribute("disabled");
            else {
                $get(b_so_ngay_dxId).value = ""; Attribute_P_DAT(b_so_ngay_dxId, "disabled", "disabled");
            }
        } else if (b_maTen == "CO_KEHOACH_NAM") {
            if ($get(b_co_kh_namId).value == "X") {
                $get(b_theo_kh_namId).removeAttribute("disabled");
            } else {
                $get(b_theo_kh_namId).value = ""; Attribute_P_DAT(b_theo_kh_namId, "disabled", "disabled");
            }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_khct_P_MA_KTRA() {
    try {
        clearTimeout(ns_td_khct_chuyenhang_cho);
        var b_ma = C_NVL($get(b_ma_ycId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId), a_cot_mt = GridX_Fas_tenCot(b_grmtId), a_cot_pa = GridX_Fas_tenCot(b_grpaId);
            sns_td.Fs_NS_TD_KHCT_MA(form_Fs_nsd(), b_ma, b_TrangKt, a_cot, a_cot_mt, a_cot_pa, ns_td_khct_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_khct_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_td_khct_P_CHUYEN_HANG(); }
    return false;
}
function ns_td_khct_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    return false;
}
function ns_td_khct_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else if (b_mt == "SO_THE_GT") { $get(b_ten_gtId).value = b_kq; }
    else form_P_DatGchu(b_gchuId, b_kq);
}
function ns_td_khct_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        else {
            var b_so_id = $get(b_so_idId).value;
            var a_dt = form_Faa_TEXT_ROW(b_vungId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var a_gt_mt = GridX_Fdt_cotGtri(b_grmtId), a_cot_mt = GridX_Fas_tenCot(b_grmtId);
            var a_gt_pa = GridX_Fdt_cotGtri(b_grpaId), a_cot_pa = GridX_Fas_tenCot(b_grpaId);
            sns_td.Fs_NS_TD_KHCT_NH(form_Fs_nsd(), b_so_id, b_TrangKt, a_dt, a_gt_mt, a_cot_mt, a_gt_pa, a_cot_pa, a_cot_lke, ns_td_khct_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_td_khct_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        form_P_LOI("loi:Nhập thành công:loi");
    }
}
function ns_td_khct_P_XOA() {
    var r = confirm("Bạn có chắc chắn xóa không?");
    if (r == false) {
        return false;
    }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) {
        form_P_LOI("loi:Chưa chọn nhân viên cần xóa:loi");
        return false;
    }
    var b_so_the = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the");
    if (b_so_the == "") ns_td_khct_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"), b_nam = $get(b_namtkId).value, b_thang = lke_Fs_TRA($get(b_mucluongtu_tk)),
            b_phong = lke_Fs_TRA($get(b_phongtkId)), b_cdanh = $get(b_cdanhtkId).value, b_ma = $get(b_ma_yctkId).value, a_cot_mt = GridX_Fas_tenCot(b_grmtId), a_cot_pa = GridX_Fas_tenCot(b_grpaId);
        sns_td.Fs_NS_TD_KHCT_XOA(form_Fs_nsd(), b_so_id, b_nam, b_thang, b_phong, b_cdanh, b_ma, a_tso, a_cot, a_cot_mt, a_cot_pa, ns_td_khct_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_td_khct_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_td_khct_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_td_khct_P_CHUYEN_HANG(); }
    }
}
function ns_td_khct_GR_lke_RowChange() {
    if (ns_td_khct_choAct != 0) clearTimeout(ns_td_khct_choAct);
    ns_td_khct_choAct = setTimeout("ns_td_khct_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_td_khct_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "") ns_td_khct_P_MOI();
    else {
        var a_cot_mt = GridX_Fas_tenCot(b_grmtId), a_cot_pa = GridX_Fas_tenCot(b_grpaId), a_cot = GridX_Fas_tenCot(b_grlkeId);
        sns_td.Fs_NS_TD_KHCT_CT(form_Fs_nsd(), b_so_id, a_cot, a_cot_mt, a_cot_pa, ns_td_khct_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    $get(b_so_idId).value = b_so_id;
    return false;
}
function ns_td_khct_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] != "") GridX_datBang(b_grmtId, a_kq[1]);
    if (a_kq[2] != "") GridX_datBang(b_grpaId, a_kq[2]);
    var b_co_kh_nam = $get(b_co_kh_namId).value;
    if (b_co_kh_nam == "X") $get(b_theo_kh_namId).removeAttribute("disabled");
    var b_co_gap = $get(b_co_gapId).value;
    if (b_co_gap == "X") $get(b_so_ngay_dxId).removeAttribute("disabled");
    return false;
}
function ns_td_khct_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_td_khct_lkeCho); ns_td_khct_P_LKE('M'); }
}
function ns_td_khct_P_LKE(b_dk) {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId), a_cot_mt = GridX_Fas_tenCot(b_grmtId), a_cot_pa = GridX_Fas_tenCot(b_grpaId),
             b_nam = $get(b_namtkId).value, b_thang = lke_Fs_TRA($get(b_thangtkId)), b_phong = lke_Fs_TRA($get(b_phongtkId)),
             b_cdanh = $get(b_cdanhtkId).value, b_mayc = $get(b_ma_yctkId).value;
        sns_td.Fs_NS_TD_KHCT_LKE(form_Fs_nsd(), b_nam, b_thang, b_phong, b_cdanh, b_mayc, a_tso, a_cot, a_cot_mt, a_cot_pa, ns_td_khct_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_khct_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    if (a_kq[1] != "") GridX_datBang(b_grlkeId, a_kq[1]);
    else GridX_datTrang(b_grlkeId);
    if (a_kq[2] != "") GridX_datBang(b_grmtId, a_kq[2]);
    else GridX_datTrang(b_grmtId);
    var b_co_kh_nam = $get(b_co_kh_namId).value;
    if (b_co_kh_nam == "X") {
        $get(b_so_ngay_dxId).removeAttribute("disabled");
    }
    var b_co_gap = $get(b_co_gapId).value;
    if (b_co_gap == "X") {
        $get(b_so_ngay_dxId).removeAttribute("disabled");
    }
    return false;
}
function ns_td_khct_P_PHEDUYET(b_trangthai) {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId), a_cot_mt = GridX_Fas_tenCot(b_grmtId), a_cot_pa = GridX_Fas_tenCot(b_grpaId),
           b_nam = $get(b_namtkId).value, b_thang = lke_Fs_TRA($get(b_thangtkId)), b_phong = lke_Fs_TRA($get(b_phongtkId)),
           b_cdanh = $get(b_cdanhtkId).value, b_mayc = $get(b_ma_yctkId).value;
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        sns_td.Fs_NS_TD_KHCT_PD(form_Fs_nsd(), b_so_id, b_trangthai, b_nam, b_thang, b_phong, b_cdanh, b_mayc, a_tso, a_cot, a_cot_mt, a_cot_pa, ns_td_khct_P_PHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { throw (err); }
}
function ns_td_khct_P_PHEDUYET_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    if (a_kq[1] != "") GridX_datBang(b_grlkeId, a_kq[1]);
    else GridX_datTrang(b_grlkeId);
    if (a_kq[2] != "") GridX_datBang(b_grmtId, a_kq[2]);
    else GridX_datTrang(b_grmtId);
    var b_co_kh_nam = $get(b_co_kh_namId).value;
    if (b_co_kh_nam == "X")  $get(b_so_ngay_dxId).removeAttribute("disabled");    
    var b_co_gap = $get(b_co_gapId).value;
    if (b_co_gap == "X") $get(b_so_ngay_dxId).removeAttribute("disabled"); 
    form_P_LOI("Phê duyệt thành công");
    return false;
}
function ns_td_khct_lke_Update(b_event) {
    var b_ctr = form_Fctr_event(b_event);
    var b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
    if ('DK_CHON'.indexOf(b_cot) >= 0) {
        var b_so_id = C_NVL(GridX_Fas_layGtriA(b_grlkeId, 'so_id')), b_chon = C_NVL(GridX_Fas_layGtriA(b_grlkeId, 'chon'));
        sns_td.Fs_NS_TD_KHCT_CHON(form_Fs_nsd(), window.name, b_so_id, b_chon, ns_td_khct_P_Grid_CHON_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_td_khct_P_DINHBIEN() {
    try {
        var b_nam = $get(b_namId).value, b_thang = $get(b_thangId).value, b_phong = $get(b_phongId).value, b_cdanh = $get(b_cdanhId).value;
        sns_td.Fs_HDNS_DINHBIEN_NS_THANG(form_Fs_nsd(), b_nam, b_thang, b_phong, b_cdanh, ns_td_khct_P_DINHBIEN_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_khct_P_DINHBIEN_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq != "") $get(b_sl_cantuyenId).value = b_kq;
     
    $get(b_sl_cantuyenId).focus();
}
function ns_td_khct_P_VONGTHI() {
    try {
        var b_cdanh = $get(b_cdanhId).value;
        sns_td.Fs_NS_TD_KHCT_VONGTHI(form_Fs_nsd(), b_cdanh, ns_td_khct_P_VONGTHI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_khct_P_VONGTHI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq != "")  form_P_CH_TEXT(b_vungId, b_kq);    
    $get(b_ma_ycId).focus();
}
function ns_td_khct_P_LAN() {
    try {
        var b_nam = $get(b_namId).value, b_phong = $get(b_phongId).value, b_cdanh = $get(b_cdanhId).value;
        sns_td.Fs_NS_TD_KHCT_LAN(form_Fs_nsd(), b_nam, b_phong, b_cdanh, ns_td_khct_P_LAN_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_khct_P_LAN_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq != "") {
        var b_ma = $get(b_ma_ycId).value;
        if (b_ma == "") $get(b_ma_ycId).value = b_kq;
    }
    $get(b_ma_ycId).focus();
} 
function ns_td_khct_P_EXCEL() {
    $get(b_thangAntkId).value = lke_Fs_TRA($get(b_thangtkId)); $get(b_phongAntkId).value = lke_Fs_TRA($get(b_phongtkId));
    __doPostBack(b_xuatExcelId, '');
} 
function form_dong() {
    location.reload(false);
}