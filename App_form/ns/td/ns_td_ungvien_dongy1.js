var b_tmf, ns_td_ungvien_dongy_lkeCho, ns_td_ungvien_dongy_chuyenhang_cho, ns_td_ungvien_dongy_choAct, b_cho_control, b_vungId, b_grlkeId, b_slideId, b_gocId, b_gchuId, b_phongycId, b_makId, b_vungtkId, b_ma_yctkId, b_cdanhtkId,
    b_phongtkId, b_thangtkId, b_namtkId, b_xuatexcelId, b_thangluongId, b_nhomluongId, b_bacluongId, b_luongId, b_trangthaitkId, b_ngaydtkId, b_ngayctkId;
function ns_td_ungvien_dongy_P_KD(b_xuatexcel) {
    b_xuatexcelId = b_xuatexcel;
    ns_td_ungvien_dongy_lkeCho, ns_td_ungvien_dongy_choAct = 0, ns_td_ungvien_dongy_chuyenhang_cho = 0, b_cho_control = 0, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_vungtkId = form_Fs_VUNG_ID('Upa_tk'),
    b_namtkId = form_Fs_TEN_ID(b_vungtkId, 'nam_tk'), b_cdanhtkId = form_Fs_TEN_ID(b_vungtkId, 'cdanh_tk'),
    b_ngaydtkId = form_Fs_TEN_ID(b_vungtkId, 'ngayd_tk'), b_ngayctkId = form_Fs_TEN_ID(b_vungtkId, 'ngayc_tk'), b_ma_yctkId = form_Fs_TEN_ID(b_vungtkId, 'MA_YC_TK'),
    b_gchuId = form_Fs_VTEN_ID('', 'gchu'), b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_psId = form_Fs_VTEN_ID('UPa_hi', 'ps'), b_nvId = form_Fs_VTEN_ID('UPa_hi', 'nv'); b_slideId = b_grlkeId + '_slide';
    ns_td_ungvien_dongy_lkeCho = setInterval('ns_td_ungvien_dongy_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (typeof (b_dtuong) == "undefined") {
            return false;
        }
        if (b_dtuong == null || b_dtuong == "") return;
        b_ten_form = a_tso[0];
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        b_doi = 0;
        if (b_dtuong.indexOf("TLUONG") >= 0) {
            $get(b_thangluongId).value = b_kq;
            $get(b_gchuId).value = a_tso[1];
        } else if (b_dtuong.indexOf("NLUONG") >= 0) {
            $get(b_nhomluongId).value = b_kq;
            $get(b_gchuId).value = a_tso[1];
        } else if (b_dtuong.indexOf("BLUONG") >= 0) {
            $get(b_bacluongId).value = b_kq;
            $get(b_luongId).value = b_kq[2];
            $get(b_gchuId).value = a_tso[1];
        } else if (b_dtuong.indexOf("CDANH_TK") >= 0) {
            $get(b_cdanhtkId).value = b_kq;
            $get(b_gchuId).value = a_tso[1];
        } else if (b_dtuong.indexOf("MA_YC_TK") >= 0) {
            $get(b_ma_yctkId).value = b_kq;
            $get(b_gchuId).value = a_tso[1];
        }
        else if (b_dtuong.indexOf("THAMSO") >= 0) b_ma_ycId = a_tso[1];
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_ungvien_dongy_P_KTRA(b_maTen) {
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
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            ns_td_ungvien_dongy_P_MA_KTRA();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_ungvien_dongy_P_MA_KTRA() {
    try {
        clearTimeout(ns_td_ungvien_dongy_chuyenhang_cho);
        var b_ma = C_NVL($get(b_ma_ycId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_td.Fs_NS_TD_UNGVIEN_DONGY_MA(form_Fs_nsd(), b_ma, b_TrangKt, a_cot, ns_td_ungvien_dongy_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_ungvien_dongy_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        form_P_MOI(b_vungId, "X");
    }
    else { GridX_datA(b_grlkeId, b_hang); ns_td_ungvien_dongy_P_CHUYEN_HANG(); }
    return false;
}
function ns_td_ungvien_dongy_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    return false;
}
function ns_td_ungvien_dongy_GR_lke_RowChange() {
    if (ns_td_ungvien_dongy_choAct != 0) clearTimeout(ns_td_ungvien_dongy_choAct);
    ns_td_ungvien_dongy_choAct = setTimeout("ns_td_ungvien_dongy_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_td_ungvien_dongy_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_the = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the"));
        if (b_so_the == "") ns_td_ungvien_dongy_P_MOI();
        else {
            var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
            $get(b_makId).value = b_ma;
            var a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_td.Fs_NS_TD_UNGVIEN_DONGY_CT(form_Fs_nsd(), b_so_the, a_cot, ns_td_ungvien_dongy_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_ungvien_dongy_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    if (a_kq[0] != "") form_P_CH_TEXT(b_vungId, a_kq[0]);
    return false;
}
function ns_td_ungvien_dongy_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        else {
            var a_dt = form_Faa_TEXT_ROW(b_vungId), b_ma = $get(b_makId).value, b_nam = $get(b_namtkId).value, b_thang = $get(b_thangtkId).value, b_phong = $get(b_phongtkId).value, b_cdanh = $get(b_cdanhtkId).value, b_tt = $get(b_trangthaitkId).value;
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            sns_td.Fs_NS_TD_UNGVIEN_DONGY_NH(form_Fs_nsd(), b_ma, b_nam, b_thang, b_phong, b_cdanh, b_tt, b_TrangKt, a_dt, a_cot_lke, ns_td_ungvien_dongy_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_td_ungvien_dongy_P_NH_KQ(b_kq) {
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
function ns_td_ungvien_dongy_P_XOA() {
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
    if (b_so_the == "") ns_td_ungvien_dongy_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
             b_nam = $get(b_namtkId).value, b_thang = $get(b_thangtkId).value, b_phong = $get(b_phongtkId).value,
             b_cdanh = $get(b_cdanhtkId).value, b_mayc = $get(b_ma_yctkId).value;
        sns_td.Fs_NS_TD_UNGVIEN_DONGY_XOA(form_Fs_nsd(), b_so_the, b_nam, b_thang, b_phong, b_cdanh, b_mayc, a_tso, a_cot, ns_td_ungvien_dongy_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_td_ungvien_dongy_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_td_ungvien_dongy_P_MOI();
        else {
            GridX_datA(b_grlkeId, b_hang);
            ns_td_ungvien_dongy_P_CHUYEN_HANG();
        }
    }
}
function ns_td_ungvien_dongy_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_td_ungvien_dongy_lkeCho); ns_td_ungvien_dongy_P_LKE('M'); }
}
function ns_td_ungvien_dongy_P_LKE(b_dk) {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
             b_nam = $get(b_namtkId).value, b_cdanh = $get(b_cdanhtkId).value,
             b_mayc = $get(b_ma_yctkId).value, b_tungay = $get(b_ngaydtkId).value, b_denngay = $get(b_ngayctkId).value;
        sns_td.Fs_NS_TD_UNGVIEN_DONGY_LKE(form_Fs_nsd(), b_nam, b_mayc, b_cdanh, b_tungay, b_denngay, a_tso, a_cot, ns_td_ungvien_dongy_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_ungvien_dongy_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    if (a_kq[1] != "") GridX_datBang(b_grlkeId, a_kq[1]);
    else GridX_datTrang(b_grlkeId);
    return false;
}
function ns_td_ungvien_dongy_P_EXCEL() {
    __doPostBack(b_xuatexcelId, '');
}
function form_dong() {
    location.reload(false);
}