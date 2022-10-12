var ns_dt_kh_ct_lkeCho, ns_dt_kh_ct_gchuCho, b_vungId, b_vungtkId, b_grlkeId, b_grlke_cpId, b_slideId, b_gocId, b_nam_tkId, b_thang_tkId, b_hthuctkId, b_trthai_lopId, b_trthai_pdId, b_namId, b_thangId, b_kh_namId,
    b_ma_kdtId, b_ten_kdtId, b_lopId, b_sl_hvienId, b_tong_cpId, b_cp_hvId, b_gchuId, b_ngay_dId, b_ngay_cId, b_thluongId, b_grlke_gvId,
    b_nhap_id, b_xoa_id, b_guipd_id, b_tt_pd = 0, b_nsd, ns_dt_kh_ct_choAct = 0, b_cho_control = 0, b_doi = 0, b_nhucau_Id, b_nhom_ndId, b_doitacId,
    b_ddiemId;
function ns_dt_kh_ct_P_KD() {
    ns_dt_kh_ct_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtkId = form_Fs_VUNG_ID('UPa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_grlke_cpId = form_Fs_VUNG_ID('GR_cpdt'), b_grlke_gvId = form_Fs_VUNG_ID('GR_gvdt'),
    b_nam_tkId = form_Fs_TEN_ID(b_vungtkId, 'nam_tk'), b_thang_tkId = form_Fs_TEN_ID(b_vungtkId, 'thangtk'), b_hthuctkId = form_Fs_TEN_ID(b_vungtkId, 'hthuc_tk'),
    b_hinhthucId = form_Fs_TEN_ID(b_vungId, 'hinhthuc'),
    b_namId = form_Fs_TEN_ID(b_vungId, 'nam'), b_thangId = form_Fs_TEN_ID(b_vungId, 'thang'), b_nhom_ndId = form_Fs_TEN_ID(b_vungId, 'nhom_nd'),
    b_kh_namId = form_Fs_TEN_ID(b_vungId, 'kh_nam'), b_ngay_dId = form_Fs_TEN_ID(b_vungId, 'ngay_d'), b_ngay_cId = form_Fs_TEN_ID(b_vungId, 'ngay_c'),
    b_thluongId = form_Fs_TEN_ID(b_vungId, 'thluong'), b_nhucau_Id = form_Fs_TEN_ID(b_vungId, 'ma_kdt_nhucau'), b_ma_kdtId = form_Fs_TEN_ID(b_vungId, 'ma_kdt'),
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'), b_lopId = form_Fs_TEN_ID(b_vungId, 'ma_lop'), b_sl_hvienId = form_Fs_TEN_ID(b_vungId, 'sl_hvien'),
    b_tong_cpId = form_Fs_TEN_ID(b_vungId, 'tong_cp'), b_cp_hvId = form_Fs_TEN_ID(b_vungId, 'cp_hvien'), b_doitacId = form_Fs_TEN_ID(b_vungId, 'doitac'),
    b_ddiemId = form_Fs_TEN_ID(b_vungId, 'ddiem'),
    b_slideId = b_grlkeId + '_slide',
    b_gchuId = form_Fs_VTEN_ID('UPa_gchu', 'gchu'),
    b_nhap_id = form_Fs_VTEN_ID('UPa_nhap', 'nhap'),
    b_xoa_id = form_Fs_VTEN_ID('UPa_nhap', 'xoa'),
    b_guipd_id = form_Fs_VTEN_ID('UPa_nhap', 'guipd');
    b_nsd = form_Fs_nsd();
    ns_dt_kh_ct_lkeCho = setInterval('ns_dt_kh_ct_P_LKE_CHO()', 200);
    ns_dt_kh_ct_P_NPA();
}
// Kiểm tra
function P_cho(b_so_the, b_ten, b_phong) {
    try {

        if (b_doi == 0) {
            $get(b_gocId).value = b_so_the;
            $get(b_hotencanboId).innerHTML = b_ten;
            $get(b_thangdId).focus();
            ns_dt_kh_ct_P_LKE();
            b_doi = 1;
            clearTimeout(b_cho_control);
        }
    }
    catch (err) {
        b_doi = 0;
    }
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        b_doi = 0;
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            $get(b_gocId).setAttribute("disabled", "disabled");
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
        } else if (b_dtuong.indexOf("TEN_CP") >= 0) {
            var b_hang1 = GridX_Fi_timHangA(b_grlke_cpId);
            if (b_hang1 < 0) return;
            var b_hang2 = GridX_Fi_timHangD(b_grlke_cpId, "ma_cp", a_tso[0]);
            if (b_hang2 > 0 && b_hang1 != b_hang2) {
                form_P_LOI("Đã có hạng mục chi phí này");
                return;
            }
            GridX_datGtri(b_grlke_cpId, b_hang1, ["ma_cp"], [a_tso[0]], 'K');
            GridX_datGtri(b_grlke_cpId, b_hang1, ["ten_cp"], [a_tso[1]], 'K');
        } else if (b_dtuong.indexOf("MA_GV") >= 0) {
            b_doi = 0;
            var b_hang = GridX_Fi_timHangA(b_grlke_gvId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grlke_gvId, b_hang, ["loai_gv"], "Nội bộ", 'K');
            GridX_datGtri(b_grlke_gvId, b_hang, ["ma_gv"], [a_tso[0]], 'K');
            GridX_datGtri(b_grlke_gvId, b_hang, ["ten_gv"], [a_tso[1]], 'K');
            GridX_datGtri(b_grlke_gvId, b_hang, ["knghiem"], [a_tso[2]], 'K');
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_kh_ct_kdt_P_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        if (b_kq != '') form_P_CH_TEXT(b_vungId, b_kq); // thông tin KDT
    }
}
function ns_dt_kh_ct_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        b_mt = b_maTen;
        switch (b_maTen) {
            case "MA_KDT": b_maId = b_ma_kdtId; break;
            case "KDT_NHUCAU": b_maId = b_nhucau_Id; break;
            case "NGAY_D": b_maId = b_ngay_dId; break;
            case "NGAY_C": b_maId = b_ngay_cId; break;
            case "DT_NAM": b_maId = b_namId; break;
            case "DT_THANG": b_maId = b_thangId; break;
            case "THLUONG": b_maId = b_thluongId; break;
            case "LKE_KDT": b_maId = b_kh_namId; break;
        }
        var b_ma = $get(b_maId);

        if (b_maTen == "NAM" || b_maTen == "THANG" || b_maTen == "NHOM_ND" || b_maTen == "YEUCAU") {
            var b_nam = form_Fs_TEN_GTRI(b_vungId, 'NAM'), b_thang = lke_Fs_TRA($get(b_thangId)), b_nhom_nd = lke_Fs_TRA($get(b_nhom_ndId)), b_kh_nam = $get(b_kh_namId).value;
            if (b_kh_nam == "X") {
                $get(b_nhucau_Id).value = "";
                hts_dungchung.Fs_NS_MA_KDT_KH_NAM(window.name, "DT_NHUCAU", b_nam, b_thang);
            } else {
                $get(b_ma_kdtId).value = "";
                hts_dungchung.P_MA_KDT_NAM(window.name, b_nam, b_nhom_nd);
            }
        }
        if (b_ma == null || C_NVL(b_ma.value) == "") return true;
        else if (b_maTen == "MA_KDT") {
            var b_ma_kdt = lke_Fs_TRA($get(b_ma_kdtId));
            ns_dt_kh_ct_KDT(b_ma_kdt);
        } else if (b_maTen == "KDT_NHUCAU") {
            var b_nam = form_Fs_TEN_GTRI(b_vungId, 'NAM'), b_thang = lke_Fs_TRA($get(b_thangId)), b_ma_kdt_nhucau = lke_Fs_TRA($get(b_nhucau_Id));
            ns_dt_kh_NAM_CT(b_nam, b_thang, b_ma_kdt_nhucau);
        }
            //else if (b_maTen == "NGAY_D") {
            //    if (kiemTraNgayDau()) {
            //        if (kiemTraNgayDayVaNgayCuoi())
            //            return kiemTraThoiLuong();
            //        else
            //            return false;
            //    }
            //    else
            //        return false;
            //} else if (b_maTen == "NGAY_C") {
            //    if (kiemTraNgayDayVaNgayCuoi())
            //        return kiemTraThoiLuong();
            //    else
            //        return false;
            //}
        else if (b_maTen == "DT_NAM") {
            // kiem tra ngay thang
            var b_ngayD = CNG_SO(b_ma.value);
            if (b_ngayD == 0) return true;
            var b_namD = CSO_SO(b_ma.value.substr(6, 4));
            var b_nam = CSO_SO(form_Fs_TEN_GTRI(b_vungId, 'nam'));
            if (b_namD != b_nam) {
                form_P_LOI("Năm trong ngày bắt đầu khác năm kế hoạch đào tạo");
                return false;
            }
            else
                return true;
        } else if (b_maTen == "DT_THANG") {
            // kiem tra ngay thang
            var b_ngayD = CNG_SO(b_ma.value);
            if (b_ngayD == 0) return true;
            var b_thangD = CSO_SO(b_ma.value.substr(3, 2));
            var b_thang = CSO_SO(form_Fs_TEN_GTRI(b_vungId, 'thang'));
            if (b_thangD != b_thang) {
                form_P_LOI("Tháng trong ngày bắt đầu khác tháng kế hoạch đào tạo");
                return false;
            }
            else
                return true;
        }
        else if (b_maTen == "THLUONG") {
            // kiem tra thoi luong dao tao
            //return kiemTraThoiLuong();
            if (!isTime(b_ma)) { form_P_LOI("loi:Thời lượng không đúng định dạng!:loi"); return false; }
        }
    }
    catch (err) { form_P_LOI(err); return false; }
}
function ns_dt_kh_ct_kdt_lke_P_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
}
function ns_dt_kh_ct_P_DatGchu(show, b_kq) {
    if (Fb_LOI_KTRA(b_kq))
        form_P_LOI(b_kq);
    else {
        form_P_DatGchu(b_gchuId, b_kq);
        if (show) ns_dt_kh_ct_gchuCho = setInterval('ns_dt_kh_ct_P_DatGchu(false,".")', 2000);
        else clearTimeout(ns_dt_kh_ct_gchuCho);
    }
}
function ns_dt_kh_ct_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_dt.Fs_NS_DT_KH_CT_MA(b_ma, b_TrangKt, a_cot, ns_dt_kh_ct_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_kh_ct_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_dt_kh_ct_P_CHUYEN_HANG(); }
}
// Nhập
function ns_dt_kh_ct_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grlke_gvId);
    GridX_datTrang(b_grlke_cpId);
    $get(b_so_idId).value = 0;
    $get(b_hinhthucId).value = "";
    b_tt_pd = 0;
    ns_dt_kh_ct_P_NPA();
    return false;
}
function ns_dt_kh_ct_P_NH() {
    var b_so_id = $get(b_so_idId).value;
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") {
            form_P_LOI(b_loi);
            return false;
        }
        var ktra = ktra_ngay(parseDate($get(b_ngay_dId).value).getTime(), parseDate($get(b_ngay_cId).value).getTime(), 1, "Ngày bắt đầu", "ngày kết thúc");
        if (ktra.length > 0) {
            ns_dt_kh_ct_NH_KQ(ktra);
            return false;
        }

        var a_dt = form_Faa_TEXT_ROW(b_vungId);
        var a_cot_ct_cp = GridX_Fdt_cotGtri(b_grlke_cpId), a_cot_lke_cp = GridX_Fas_tenCot(b_grlke_cpId);
        var a_cot_ct_gv = GridX_Fdt_cotGtri(b_grlke_gvId), a_cot_lke_gv = GridX_Fas_tenCot(b_grlke_gvId);
        var nam = $get(b_namId).value, thang = lke_Fs_TRA($get(b_thang_tkId)), b_hinhthuc = form_Fs_TEN_GTRI(b_vungtkId, 'hthuc_tk');//$get(b_thangId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        sns_dt.Fs_NS_DT_KH_CT_NH(b_nsd, b_so_id, nam, thang, b_hinhthuc, a_dt, a_cot_ct_cp, a_cot_ct_gv, a_cot_lke_cp, b_TrangKt, a_cot, ns_dt_kh_ct_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { throw (err); }
    return false;
}
function ns_dt_kh_ct_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        form_P_LOI("loi:Ghi thành công!:loi");
    }
    return false;
}
// Xóa
function ns_dt_kh_ct_P_XOA() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_hang < 1) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
        var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
        if (b_so_id == "") ns_dt_kh_ct_P_MOI();
        else {
            var nam = form_Fs_TEN_GTRI(b_vungId, 'nam_tk'), thang = lke_Fs_TRA($get(b_thang_tkId)),
            b_hinhthuc = form_Fs_TEN_GTRI(b_vungtkId, 'hthuc_tk');
            if (nam == "") nam = 0;
            if (thang == "") thang = 0;
            if (b_hinhthuc == "") b_hinhthuc = "";

            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            sns_dt.Fs_NS_DT_KH_CT_XOA(b_nsd, b_so_id, a_tso, a_cot, nam, thang, b_hinhthuc, ns_dt_kh_ct_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
    return false;
}
function ns_dt_kh_ct_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
        var b_dong = GridX_Fi_hangSo(b_grlkeId);
        if (b_hang > b_dong) b_hang = b_dong;
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dt_kh_ct_P_MOI();
        else {
            GridX_datA(b_grlkeId, b_hang);
            ns_dt_kh_ct_P_CHUYEN_HANG();
        }
        form_P_LOI("loi:Xóa thành công:loi");//ns_dt_kh_ct_P_DatGchu(true, "Xóa thành công!");
    }
    return false;
}
// Chuyển hàng
function ns_dt_kh_ct_GR_lke_RowChange() {
    if (ns_dt_kh_ct_choAct != 0) clearTimeout(ns_dt_kh_ct_choAct);
    ns_dt_kh_ct_choAct = setTimeout("ns_dt_kh_ct_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_dt_kh_ct_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "") ns_dt_kh_ct_P_MOI();
        else {
            $get(b_so_idId).value = b_so_id;
            var a_cot_lke_cp = GridX_Fas_tenCot(b_grlke_cpId), b_cot_lke_gv = GridX_Fas_tenCot(b_grlke_gvId);
            sns_dt.Fs_NS_DT_KH_CT_CT(b_so_id, a_cot_lke_cp, b_cot_lke_gv, ns_dt_kh_ct_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_kh_ct_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    GridX_datBang(b_grlke_cpId, a_kq[1]);
    GridX_datBang(b_grlke_gvId, a_kq[2]);
    ns_dt_kh_ct_P_NPA();
    //tinhTongChiPhi();
    // b_tt_pd = CSO_SO(a_kq[2]);
}
function ns_dt_kh_ct_GR_Update(b_event) {
    try {
        var b_id = b_event.srcElement.id;
        if (b_id.indexOf("dgia") > 0 || b_id.indexOf("sluong") > 0 || b_id.indexOf("thue") > 0) {
            var b_hang = GridX_Fi_timHangA(b_grlke_cpId);
            var b_dgia = C_NVL(GridX_Fas_layGtri(b_grlke_cpId, b_hang, "dgia"));
            var b_sluong = C_NVL(GridX_Fas_layGtri(b_grlke_cpId, b_hang, "sluong"));
            if (b_dgia != "" && b_sluong != "") {
                var b_tong = CSO_SO(b_dgia) * CSO_SO(b_sluong);
                GridX_datGtri(b_grlke_cpId, b_hang, ["tong"], SO_CSO(b_tong), 'K');
                var b_thue = C_NVL(GridX_Fas_layGtri(b_grlke_cpId, b_hang, "thue"));
                if (b_thue == '') b_thue = "0";
                var b_tong_hm = Math.round(b_tong + b_tong * CSO_SO(b_thue) / 100.0);
                GridX_datGtri(b_grlke_cpId, b_hang, ["tong_hm"], SO_CSO(b_tong_hm), 'K');
            }
            var tonghm = GridX_Fn_Tong_KDK(b_grlke_cpId, "tong_hm");
            $get(b_tong_cpId).value = SO_CSO(tonghm);
            var so_hv = CSO_SO(C_NVL($get(b_sl_hvienId).value));
            if (so_hv != 0) {
                $get(b_cp_hvId).value = SO_CSO(Math.round(tonghm / so_hv));
            }
        }
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_dt_kh_cp_GR_Update(b_event) {
    try {
        var tonghm = GridX_Fn_Tong_KDK(b_grlke_cpId, "stien");
        $get(b_tong_cpId).value = SO_CSO(tonghm);
        var so_hv = CSO_SO(C_NVL($get(b_sl_hvienId).value));
        if (so_hv != 0) {
            $get(b_cp_hvId).value = SO_CSO(Math.round(tonghm / so_hv));
        }

    }
    catch (ex) { form_P_LOI(ex.message); }
}
// Liệt kê
function ns_dt_kh_ct_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ns_dt_kh_ct_lkeCho != 0) clearTimeout(ns_dt_kh_ct_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_dt_kh_ct_P_LKE();
    }
}
function ns_dt_kh_ct_P_LKE() {
    try {
        var nam = form_Fs_TEN_GTRI(b_vungtkId, 'nam_tk'), thang = lke_Fs_TRA($get(b_thang_tkId)),
            b_hinhthuc = form_Fs_TEN_GTRI(b_vungtkId, 'hthuc_tk');
        if (nam == "") nam = 0;
        if (thang == "") thang = 0;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.Fs_NS_DT_KH_CT_LKE(b_nsd, a_tso, a_cot, nam, thang, b_hinhthuc, ns_dt_kh_ct_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
    return false;
}
function ns_dt_kh_ct_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
// Phê duyệt
function ns_dt_kh_ct_P_PD() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 0) {
            form_P_LOI("Bạn phải chọn một bản ghi để gửi phê duyệt");
            return false;
        }
        var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
        if (b_so_id == "") {
            form_P_LOI("Bạn phải chọn một bản ghi để gửi phê duyệt");
        }
        else {
            if (b_tt_pd != 0)
                form_P_LOI("Không thao tác được do đã gửi phê duyệt");
            else
                sns_ctt.Fs_NS_DT_KH_CT_NH_PD(b_nsd, b_so_id, 1, ns_dt_kh_ct_P_PD_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (ex) { form_P_LOI(ex.message); }
    return false;
}
function ns_dt_kh_ct_P_PD_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        ns_dt_kh_ct_P_DatGchu(true, "Gửi phê duyệt thành công!");
    }
    return false;
}
// Next hàng giảng viên
function ns_dt_kh_gv_HangLen() {
    GridX_chuyenHang(b_grlke_gvId, -1);
    return false;
}
function ns_dt_kh_gv_HangXuong() {
    GridX_chuyenHang(b_grlke_gvId, 1);

    return false;
}
function ns_dt_kh_gv_ChenDong(b_dk) {
    if (C_NVL(b_dk) == 'C') {
        var b_dong = GridX_Fi_hangKt(b_grlke_gvId);
        GridX_P_hangKt(b_grlke_gvId, b_dong + 1);
        GridX_chenHang(b_grlke_gvId);
    }
    return false;
}
function ns_dt_kh_gv_CatDong() {
    GridX_boChon(b_grlke_gvId, 'C');
    return false;
}
// Next hàng chi phí
function ns_dt_kh_cp_HangLen() {
    GridX_chuyenHang(b_grlke_cpId, -1);
    return false;
}
function ns_dt_kh_cp_HangXuong() {
    GridX_chuyenHang(b_grlke_cpId, 1);

    return false;
}
function ns_dt_kh_cp_ChenDong(b_dk) {
    if (C_NVL(b_dk) == 'C') {
        var b_dong = GridX_Fi_hangKt(b_grlke_cpId);
        GridX_P_hangKt(b_grlke_cpId, b_dong + 1);
        GridX_chenHang(b_grlke_cpId);
    }
    return false;
}
function ns_dt_kh_cp_CatDong() {
    GridX_boChon(b_grlke_cpId, 'C');
    return false;
}

function ns_dt_kh_ct_P_CHON() {
    var b_hang = GridX_Fi_timHangA(b_grlke_cpId);
    if (b_hang < 1) return;
    form_P_TRA_CHON('MA,TEN');
    return false;
}
function ns_dt_kh_ct_P_TT(b_nv) {
    var b_so_id = $get(b_so_idId).value;
    if (b_so_id == '' || b_so_id == '0') {
        form_P_LOI('Bạn chưa chọn kế hoạch đào tạo nào!');
        return false;
    }

    var b_tenKdt = $get(b_ten_kdtId).value;
    var b_lop = $get(b_lopId).value;
    switch (b_nv) {
        case 'MON': // môn thi
            form_P_MO('/App_form/ns/dt/ngv/ns_dt_kh_ct_mon.aspx', window.name, ["THAMSO", [window.name, b_so_id, b_tenKdt, b_lop, b_tt_pd]]);
            break;
        case 'TKB': // thời khóa biểu
            form_P_MO('/App_form/ns/dt/ngv/ns_dt_kh_ct_tkb.aspx', window.name, ["THAMSO", [window.name, b_so_id, b_tenKdt, b_lop, b_tt_pd]]);
            break;
        default:
            break;
    }
    return false;
}
function ns_dt_kh_ct_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function tinhTongChiPhi() {
    var b_tong_cp = GridX_Fn_Tong_KDK(b_grlke_cpId, "tong_hm");
    $get(b_tong_cpId).value = SO_CSO(b_tong_cp);
    var b_so_hv = $get(b_sl_hvienId).value;
    var b_cp_hv = '';
    if (b_so_hv != '')
        b_cp_hv = Math.round(b_tong_cp / CSO_SO(b_so_hv));
    $get(b_cp_hvId).value = SO_CSO(b_cp_hv);
}
function kiemTraThoiLuong() {
    var b_thluong = CSO_SO($get(b_thluongId).value);
    if (b_thluong == 0) return;
    var b_ngayD = b_ngayC = $get(b_ngay_dId).value, b_ngayC = $get(b_ngay_cId).value;
    if (b_ngayD != "" && b_ngayC != "") {
        if ((CNG_SO(b_ngayC) - CNG_SO(b_ngayD) + 1) * 24 < b_thluong) {
            form_P_LOI("Thời lượng đào tạo vượt quá số ngày đào tạo");
            return false;
        }
        return true;
    }
    else return true;
}
function kiemTraNgayDau() {
    var b_ngay = $get(b_ngay_dId).value;
    var b_ngayD = CNG_SO(b_ngay);
    if (b_ngayD == 0) return true;

    var b_namD = CSO_SO(b_ngay.substr(6, 4)), b_thangD = CSO_SO(b_ngay.substr(3, 2));
    var b_nam = CSO_SO(form_Fs_TEN_GTRI(b_vungId, 'nam')), b_thang = CSO_SO(form_Fs_TEN_GTRI(b_vungId, 'thang'));
    if (b_namD != b_nam) {
        form_P_LOI("Năm trong ngày bắt đầu khác năm kế hoạch đào tạo");
        return false;
    }
    if (b_thangD != b_thang) {
        form_P_LOI("Tháng trong ngày bắt đầu khác tháng kế hoạch đào tạo");
        return false;
    }
    return true;
}
function kiemTraNgayDayVaNgayCuoi() {
    var b_ngayD = $get(b_ngay_dId).value;
    var b_ngayC = $get(b_ngay_cId).value;
    if (b_ngayD != "" && b_ngayC != "") {
        if (CNG_SO(b_ngayC) < CNG_SO(b_ngayD)) {
            form_P_LOI("Ngày bắt đầu lớn hơn ngày kết thúc");
            return false;
        }
        else
            return true;
    }
    else return true;
}
//
function ns_dt_hinhthuc_P_LIST(b_ctrId, b_kieu, b_vtri) {
    try {
        var b_nam = C_NVL(GridX_Fas_layGtriA(b_grctId, 'NAM'));
        if (b_nam == "") b_nam = C_NVL(GridX_Fas_layGtriA(b_grctId, 'PHONG'));
        if (b_nam != '') {
            var a_tso = lke_Fa_TSO(b_kieu);
            hts_dungchung.Fs_NS_DT_KDT_NAM(form_Fs_nsd(), b_nam, a_tso[3], form_LIST_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_dt_kh_ct_P_NPA() {
    var b_nv = $get(b_kh_namId).value;
    if (b_nv == "X") {
        $get(b_nhucau_Id).style.display = '';
        $get(b_ma_kdtId).style.display = 'none';
        document.getElementById(b_nhom_ndId).disabled = true;
    } else {
        $get(b_nhucau_Id).style.display = 'none';
        $get(b_ma_kdtId).style.display = '';
        document.getElementById(b_nhom_ndId).disabled = false;
    }
}
// chọn khóa đào tạo không theo yêu cầu
function ns_dt_kh_ct_KDT(b_kdt) {
    try {
        sns_dt.Fs_NS_DT_KHDT_NAM_KDT(b_kdt, ns_dt_kh_ct_KDT_KDT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_kh_ct_KDT_KDT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var b_drop = form_Fctr_TEN_DTUONG(b_vungId, 'hinhthuc');
    var a_kq = Fas_ChMang(b_kq, '#');
    list_P_DAT(b_drop, a_kq[0]);
    $get(b_thluongId).value = a_kq[1];
    $get(b_lopId).value = a_kq[2];
}
//chọn khóa đào tạo theo yêu cầu
function ns_dt_kh_NAM_CT(b_nam, b_thang, b_kdt_nhucau) {
    try {
        sns_dt.Fs_NS_KH_NAM_CT(b_nam, b_thang, b_kdt_nhucau, ns_dt_kh_NAM_CT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_kh_NAM_CT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');

    var b_drop = form_Fctr_TEN_DTUONG(b_vungId, 'hinhthuc');
    list_P_DAT(b_drop, a_kq[0]);
    $get(b_ddiemId).value = a_kq[1];
    $get(b_sl_hvienId).value = a_kq[2];
    $get(b_thluongId).value = a_kq[3];
    $get(b_lopId).value = a_kq[4];
    lke_P_DAT($get(b_nhom_ndId), a_kq[5]);

}
// Liệt kê danh sách giảng viên theo đối tác
function ns_dt_kh_ct_P_LKE_GVIEN() {
    try {
        var b_ma_doitac = lke_Fs_TRA($get(b_doitacId));
        var a_cot = GridX_Fas_tenCot(b_grlke_gvId);
        sns_dt.Fs_NS_DT_KH_CT_LKE_GVIEN(b_ma_doitac, a_cot, ns_dt_kh_ct_P_LKE_GVIEN_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
    return false;
}
function ns_dt_kh_ct_P_LKE_GVIEN_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    GridX_datBang(b_grlke_gvId, a_kq[0]);
}
// validate ngày
function ktra_ngay(tungay, denngay, loai, ten1, ten2) {
    if (denngay == "" || denngay == null) {
        return "";
    }
    if (loai == 1 && tungay > denngay) {
        return "loi: " + ten1 + " không được lớn hơn " + ten2 + " :loi";
    } else if (loai == 2 && tungay >= denngay) {
        return "loi: " + ten1 + " không được lớn hơn hoặc bằng " + ten2 + " :loi";
    }
    return "";
}
function parseDate(str) {
    var mdy = str.split('/');
    return new Date(mdy[2], mdy[1], mdy[0]);
}
function addDays(date, days) {
    date = date.substring(6, 10) + "-" + date.substring(3, 5) + "-" + date.substring(0, 2);
    var result = new Date(date);
    result.setMonth(result.getMonth() + Number(days));
    result.setDate(result.getDate() - Number(1));
    var kq = NG_CNG(result);
    return kq;
}
// validate time
function isTime(txtHour) {
    var data = C_NVL(txtHour.value);
    if (data == "") return true;

    if (data.indexOf(":") < 0) {
        data = formatTime(data);
        if (data != '')
            txtHour.value = data;
        else {
            txtHour.value = "";
            return false;
        }
    }

    var b_length = data.length;
    var hour = data.substr(0, b_length - 3);
    var minute = data.substr(b_length - 2);
    if (minute >= 60) {
        txtHour.value = "";
        return false;
    }
    txtHour.value = hour + ":" + minute;
    $get(b_tluongId).value = txtHour.value;
    return true;
}
function formatTime(data) {
    if (data.indexOf(":") >= 0) return data;

    var b_length = data.length;
    if (b_length < 4) {
        if (b_length == 0)
            data = "00:00";
        else if (b_length == 1)
            data = "0" + data + ":00";
        else if (b_length == 2)
            data = data + ":00";
        else if (b_length == 3)
            data = data.substr(0, 2) + ":0" + data.substr(2);
    }
    else {

        data = data.substr(0, b_length - 2) + ':' + data.substr(b_length - 2);
    }
    return data;
}
function form_dong() {
    location.reload(false);
}
