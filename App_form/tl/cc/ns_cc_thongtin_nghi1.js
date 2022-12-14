var ns_cc_thongtin_nghi_lkeCho, b_vungId, b_grlkeId, b_slideId, b_so_theId, b_nsd, b_loai,
    b_sothe_thaytheId, b_nguoiduyetId, b_ngaydId, b_ngaycId, b_loiNhap = 0, ns_cc_thongtin_nghi_choAct = 0, c_thongtin_nghi_choAct,
    b_so_the_tkId, b_ten_tkId, b_nam_tkId, b_aphongId, b_akyluongId, b_kyluongId, b_phong_tkId, b_vungTkId, b_gio_bdId, b_macc_nghiId, b_phep_conId, b_gio_ktId, b_gchuId,
    b_ngaynghi, b_danghiId, b_nghiconId, b_moiId, b_truphepnam, b_tt_phep, b_huydongId, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C', b_ctyValue, b_ctrbeforId, b_phongId;
function ns_cc_thongtin_nghi_P_KD() {
    ns_cc_thongtin_nghi_lkeCho = setInterval('ns_cc_thongtin_nghi_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "" || a_tso[0] == "FILE_HTOAN") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            $get(b_so_theId).value = a_tso[0];
            $get(b_gchuId).innerHTML = a_tso[1];
            ns_cc_thongtin_nghi_P_KTRA("SO_THE");
        }
        else if (b_dtuong.indexOf("KQ") >= 0) {
            $get(b_so_theId).value = a_tso[0];
            $get(b_ngayxnId).innerHTML = a_tso[1];
            $get(b_ngaydId).innerHTML = a_tso[2];
            ns_cc_thongtin_nghi_P_MA_KTRA();
            return false;
        } else if (b_dtuong.indexOf("TAI_IMPORT") >= 0) {
            ns_cc_thongtin_nghi_P_LKE('K');
        }
    }
    catch (err) { form_P_LOI(err); }
}
// kiểm tra
function ns_cc_thongtin_nghi_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "NGAYD": b_maId = b_ngaydId; $get(b_ngaynghi).value = ""; break;
            case "NGAYC": b_maId = b_ngaycId; $get(b_ngaynghi).value = ""; break;
            case "SO_THE": b_maId = b_so_theId; break;
            case "NAMTRU": b_maId = b_namId; break;
            case "GIO_BD": b_maId = b_gio_bdId; break;
            case "GIO_KT": b_maId = b_gio_ktId; break;
            case "NGAY_NGHI": b_maId = b_ngaynghi; break;
            case "TRUPHEP": b_maId = b_truphepnam; break;
            case "KYLUONG": b_maId = b_kyluongId; break;
            case "PHONG_TK": b_maId = b_phong_tkId; break;
            case "MACC_NGHI": b_maId = b_macc_nghiId; $get(b_ngaynghi).value = ""; break;
        }
        if (b_maTen == "NGAYD" || b_maTen == "NGAYC") {
            tinh_ngay();
            //ns_cc_thongtin_nghi_P_MA_PHEP_KTRA();
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        else if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_cc_thongtin_nghi_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_cc_thongtin_nghi_phep();
            ns_cc_thongtin_nghi_TTCB();
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_cc_thongtin_nghi_P_MOI(); ns_cc_thongtin_nghi_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_cc_thongtin_nghi_P_CHUYEN_HANG(); }

        }
        else if (b_maTen == "NAMTRU") {
            ns_cc_thongtin_nghi_phep();
        }
        else if (b_maTen == "NGAY_NGHI") {
            $get(b_truphepnam).value = $get(b_ngaynghi).value
            tinh_ngay();
        }
        else if (b_maTen == "MACC_NGHI") {
            // ns_cc_thongtin_nghi_P_MA_PHEP_KTRA();
            ns_cc_thongtin_nghi_SC(); tinh_ngay();
        }
        else if (b_maTen == "TRUPHEP") {
            var truphep = $get(b_truphepnam).value, ngaynghi = $get(b_ngaynghi).value
            if (truphep > ngaynghi) {
                form_P_LOI("Số ngày phép trừ không được lớn hơn ngày nghỉ.");
            }
        }
        else if (b_maTen == "KYLUONG") {
            $get(b_aphongId).value = b_ctyValue;
            $get(b_akyluongId).value = lke_Fs_TRA($get(b_kyluongId));
            //ns_cc_thongtin_nghi_P_LKE('C');
        } else if (b_maTen == "PHONG_TK") {
            $get(b_aphongId).value = b_ctyValue;
            $get(b_akyluongId).value = lke_Fs_TRA($get(b_kyluongId));
        }
        //else skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_cc_thongtin_nghi_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_thongtin_nghi_P_MA_KTRA() {
    try {
        var b_so_the = C_NVL($get(b_so_theId).value);
        if (b_so_the != "") {
            var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_qt.Fs_NS_CC_THONGTIN_NGHI_MA(form_Fs_nsd(), b_so_the, b_so_id, b_TrangKt, a_cot, ns_cc_thongtin_nghi_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_cc_thongtin_nghi_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) { form_P_MOI(b_vungId, "X"); tinh_ngay(); }
    else { GridX_datA(b_grlkeId, b_hang); ns_cc_thongtin_nghi_P_CHUYEN_HANG(); }
}
function ns_cc_thongtin_nghi_P_MA_PHEP_KTRA() {
    try {
        var b_so_the = $get(b_so_theId).value, b_ngayd = $get(b_ngaydId).value;
        sns_qt.Fs_NS_CC_THONGTIN_NGHI_KTRA(form_Fs_nsd(), b_so_the, b_ngayd, ns_cc_thongtin_nghi_P_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_thongtin_nghi_P_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
    }
    // chỗ này con thiếu, phải công thêm số phép nó nhập trên lưới với b_kq, nếu >3 thì mới hỏi
    var nganghi = 0, ngaynghi = 0;
    var b_loainghi = lke_Fs_TRA($get(b_macc_nghiId));
    var b_loainghi_t = b_loainghi.split("/");
    var b_loainghi_s = b_loainghi_t[0];
    var b_loainghi_c = "";
    if (b_loainghi_t.length > 0) {
        b_loainghi_c = b_loainghi_t[1];
    }
    if (b_loainghi == "P" || (b_loainghi_s == "P" || b_loainghi_c == "P")) {
        ngaynghi = CSO_SO($get(b_ngaynghi).value);
    }
    ngaynghi = CSO_SO(b_kq) + ngaynghi;
    if (ngaynghi > 3) {
        b_tt_phep = 1;
    } else b_tt_phep = 0;
    return false;
}
function ns_cc_thongtin_nghi_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        b_loiNhap = 1;
    }
    else { form_P_DatGchu(b_gchuId, b_kq); b_loiNhap = 0; }
}
function ns_cc_thongtin_nghi_P_MOI() {
    $get(b_kyluongId).value = "";
    $get(b_namId).value = "";
    form_P_MOI(b_vungId, "GXL"); $get(b_macc_nghiId).value = ""; $get(b_huydongId).value = "0";
    GridX_thoiA(b_grlkeId);
    $get(b_so_theId).focus();
    return false;
}
//nhập
function ns_cc_thongtin_nghi_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var ktra = ns_cc_thongtin_nghi_KT_NGAY(ns_cc_thongtin_nghi_Date($get(b_ngaydId).value).getTime(), ns_cc_thongtin_nghi_Date($get(b_ngaycId).value).getTime(), 1, "Từ ngày", "Đến ngày");
        if (ktra.length > 0) {
            ns_cc_thongtin_nghi_P_NH_KQ(ktra);
            return false;
        }
        var b_nnghi = 0;
        var b_loainghi = lke_Fs_TRA($get(b_macc_nghiId));
        var b_loainghi_t = b_loainghi.split("/");
        var b_loainghi_s = b_loainghi_t[0];
        var b_loainghi_c = "";
        if (b_loainghi_t.length > 0) {
            b_loainghi_c = b_loainghi_t[1];
        }
        var phepcon = CSO_SO($get(b_phep_conId).value);
        b_nnghi = CSO_SO($get(b_ngaynghi).value);
        if (b_nnghi - phepcon > 3 && b_loainghi == "P" || (b_nnghi - phepcon > 3 && (b_loainghi_s == "P" || b_loainghi_c == "P"))) {
            var r = confirm("Số ngày nghỉ phép vượt quá 3 ngày so với số phép hiện tại, bạn có đồng ý lưu?");
            if (r == false) {
                form_P_LOI('');
                return false;
            }
        }
        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        var b_so_the_tk = $get(b_so_the_tkId).value, b_ten_tk = $get(b_ten_tkId).value, b_nam_tk = lke_Fs_TRA($get(b_nam_tkId)), b_kyluong = lke_Fs_TRA($get(b_kyluongId)), b_phong_tk = b_ctyValue;
        sns_qt.Fs_NS_CC_THONGTIN_NGHI_NH(form_Fs_nsd(), b_so_the_tk, b_ten_tk, b_nam_tk, b_kyluong, b_phong_tk, "1", b_so_id, b_TrangKt, a_dt_ct, a_cot_lke, ns_cc_thongtin_nghi_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { throw (err); }
}
function ns_cc_thongtin_nghi_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_so_theId).focus();
        form_P_LOI("loi:Nhập thành công!:loi");
    }
    return false;
}
// xóa
function ns_cc_thongtin_nghi_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_so_the = $get(b_so_theId).value, b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));;
    if (b_hang < 1 || b_so_id == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); ns_cc_thongtin_nghi_P_MOI(); return false; }
    else {
        var b_dtuong_nh = GridX_Fas_layGtri(b_grlkeId, b_hang, "dtuong_nh");
        if (b_dtuong_nh == "CN") { form_P_LOI("loi:Bạn không thể xóa các bản ghi do cá nhân đăng ký:loi"); ns_cc_thongtin_nghi_P_MOI(); return false; }
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_so_the_tk = $get(b_so_the_tkId).value, b_ten_tk = $get(b_ten_tkId).value, b_nam_tk = lke_Fs_TRA($get(b_nam_tkId)), b_kyluong = lke_Fs_TRA($get(b_kyluongId)), b_phong_tk = b_ctyValue;
        sns_qt.Fs_NS_CC_THONGTIN_NGHI_XOA(form_Fs_nsd(), b_so_the_tk, b_ten_tk, b_nam_tk, b_kyluong, b_phong_tk, b_so_id, a_tso, a_cot, ns_cc_thongtin_nghi_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_cc_thongtin_nghi_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_cc_thongtin_nghi_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_cc_thongtin_nghi_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
    return false;
}
//hủy
function ns_cc_thongtin_nghi_P_HUY() {
    var r = confirm("Bạn có chắc chắn hủy không?");
    if (r == false) return false;
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_the = $get(b_so_theId).value, b_ngayd = $get(b_ngaydId).value;
    if (b_so_the == "") ns_cc_thongtin_nghi_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_so_the_tk = $get(b_so_the_tkId).value, b_ten_tk = $get(b_ten_tkId).value, b_nam_tk = lke_Fs_TRA($get(b_nam_tkId)), b_kyluong = lke_Fs_TRA($get(b_kyluongId)), b_phong_tk = b_ctyValue;
        sns_qt.Fs_NS_CC_THONGTIN_NGHI_XOA(form_Fs_nsd(), b_so_the_tk, b_ten_tk, b_nam_tk, b_kyluong, b_phong_tk, a_tso, a_cot, ns_cc_thongtin_nghi_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
// chuyển hàng
function ns_cc_thongtin_nghi_GR_lke_RowChange() {
    if (ns_cc_thongtin_nghi_choAct != 0) clearTimeout(ns_cc_thongtin_nghi_choAct);
    ns_cc_thongtin_nghi_choAct = setTimeout("ns_cc_thongtin_nghi_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_cc_thongtin_nghi_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_the = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the"),
        b_ngayd = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ngayd"));
    if (b_ngayd == "") { form_P_MOI(b_vungId, "X"); }
    else sns_qt.Fs_NS_CC_THONGTIN_NGHI_CT(form_Fs_nsd(), b_so_the, b_ngayd, ns_cc_thongtin_nghi_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    form_P_GridX_TEXT(b_vungId, b_grlkeId);
    return false;
}
function ns_cc_thongtin_nghi_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
// liệt kê
function ns_cc_thongtin_nghi_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        b_tt_phep = 0;
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungTkId = form_Fs_VUNG_ID('UPa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
        b_so_theId = form_Fs_TEN_ID(b_vungId, 'SO_THE'); b_sothe_thaytheId = form_Fs_TEN_ID(b_vungId, 'sothe_thaythe');
        b_ngaydId = form_Fs_TEN_ID(b_vungId, 'ngayd'); b_ngaycId = form_Fs_TEN_ID(b_vungId, 'ngayc');
        b_namId = form_Fs_TEN_ID(b_vungId, 'namtru'); b_gio_bdId = form_Fs_TEN_ID(b_vungId, 'gio_bd');
        b_macc_nghiId = form_Fs_TEN_ID(b_vungId, 'macc_nghi'); b_gio_ktId = form_Fs_TEN_ID(b_vungId, 'gio_kt');
        b_ngaynghi = form_Fs_TEN_ID(b_vungId, 'ngaynghi'); b_truphepnam = form_Fs_TEN_ID(b_vungId, 'truphep'), b_phongId = form_Fs_TEN_ID(b_vungId, 'phong');
        b_so_the_tkId = form_Fs_TEN_ID(b_vungTkId, 'so_the_tk'), b_ten_tkId = form_Fs_TEN_ID(b_vungTkId, 'ten_tk');
        b_nam_tkId = form_Fs_TEN_ID(b_vungTkId, 'nam'), b_kyluongId = form_Fs_TEN_ID(b_vungTkId, 'kyluong');
        b_phong_tkId = form_Fs_TEN_ID(b_vungTkId, 'phong_tk'); b_huydongId = form_Fs_TEN_ID(b_vungId, 'huydon');
        b_gchuId = form_Fs_VTEN_ID('', 'gchu'), b_moiId = form_Fs_VTEN_ID('', 'moi'); b_phep_conId = form_Fs_TEN_ID(b_vungId, 'phepcon');
        b_aphongId = form_Fs_VTEN_ID('UPa_hi', 'aphong'), b_akyluongId = form_Fs_TEN_ID('UPa_hi', 'akyluong');
        b_slideId = b_grlkeId + '_slide';
        lke_P_DAT($get(b_phong_tkId), 'TATCA' + '{' + 'Tất cả');
        form_F_GOC().P_MENUBf(window.name, 'M');
        vb_cctc_P_SL('', 'D', '0', ' ', ' ', 'T');
        b_ctyValue = "TATCA";

        if (document.readyState == 'complete') {
            if (ns_cc_thongtin_nghi_lkeCho != 0) clearTimeout(ns_cc_thongtin_nghi_lkeCho);
            b_slideId = $get(b_grlkeId).getAttribute('slideId');
            ns_cc_thongtin_nghi_CT_KYLUONG();
            ns_cc_thongtin_nghi_P_LKE('K');
        }
    }
}
function ns_cc_thongtin_nghi_CT_KYLUONG() {
    try {
        var b_form = "ns_cc_thongtin_nghi", b_nam = "DT_NAM", b_thang = "DT_KY";
        hts_dungchung.Fs_NS_CC_KY(form_Fs_nsd(), b_form, b_nam, b_thang, ns_cc_thongtin_nghi_CT_KYLUONG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_thongtin_nghi_CT_KYLUONG_KQ(b_kq) {
    if (b_kq != "") {
        form_P_CH_TEXT(b_vungTkId, b_kq);
    }
    //ns_cc_thongtin_nghi_P_LKE('K');
}
function ns_cc_thongtin_nghi_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var time = new Date();
        var b_year = time.getFullYear();
        $get(b_namId).value = b_year;
        if (b_dk == 'K') {
            var b_so_the = $get(b_so_theId).value;
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            var b_so_the_tk = $get(b_so_the_tkId).value, b_ten_tk = $get(b_ten_tkId).value,
                //b_nam_tk = lke_Fs_TRA($get(b_nam_tkId)),

                b_nam_tk = form_Fs_TEN_GTRI(b_vungTkId, 'NAM'), b_kyluong = form_Fs_TEN_GTRI(b_vungTkId, 'KYLUONG'),
                //b_kyluong = lke_Fs_TRA($get(b_kyluongId)),
                b_phong_tk = lke_Fs_TRA($get(b_phong_tkId));
            sns_qt.Fs_NS_CC_THONGTIN_NGHI_LKE(form_Fs_nsd(), b_so_the_tk, b_ten_tk, b_nam_tk, b_kyluong, b_phong_tk, a_tso, a_cot, ns_cc_thongtin_nghi_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
        else {
            var b_so_the = $get(b_so_theId).value;
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            var b_so_the_tk = $get(b_so_the_tkId).value, b_ten_tk = $get(b_ten_tkId).value,
                b_nam_tk = lke_Fs_TRA($get(b_nam_tkId)),
                //b_nam_tk = form_Fs_TEN_GTRI(b_vungTkId, 'NAM'), b_kyluong = form_Fs_TEN_GTRI(b_vungTkId, 'KYLUONG'),
                b_kyluong = lke_Fs_TRA($get(b_kyluongId)),
                b_phong_tk = b_ctyValue;
            sns_qt.Fs_NS_CC_THONGTIN_NGHI_LKE(form_Fs_nsd(), b_so_the_tk, b_ten_tk, b_nam_tk, b_kyluong, b_phong_tk, a_tso, a_cot, ns_cc_thongtin_nghi_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }

    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_thongtin_nghi_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#'); slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (lke_Fs_TRA($get(b_macc_nghiId)) != "") ns_cc_thongtin_nghi_SC();
        return false;
    }
    b_fcho = 'X';
}

// Lấy kiểu nghỉ sáng chiều
function ns_cc_thongtin_nghi_SC() {
    try {
        var b_kieunghi = lke_Fs_TRA($get(b_macc_nghiId));
        sns_qt.Fs_NS_CC_THONGTIN_NGHI_SC(form_Fs_nsd(), b_kieunghi, ns_cc_thongtin_nghi_SC_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_thongtin_nghi_SC_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
// lấy thông tin ngày nghỉ
function ns_cc_thongtin_nghi_ngayphep() {
    try {
        var b_so_the = $get(b_so_theId).value,
            b_ngayd = $get(b_ngaydId).value;
        sns_qt.Fs_NS_CC_THONGTIN_NGHI_NGAY(form_Fs_nsd(), b_so_the, b_ngayd, ns_cc_thongtin_nghi_ngayphep_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_thongtin_nghi_ngayphep_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
function ns_cc_thongtin_nghi_phep() {
    try {
        var b_so_the = $get(b_so_theId).value,
            b_nam = $get(b_namId).value;
        sns_qt.Fs_NS_CC_THONGTIN_NGHI_NGAYPHEP(form_Fs_nsd(), b_so_the, b_nam, ns_cc_thongtin_nghi_phep_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_thongtin_nghi_phep_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
// lấy thông tin cán bộ
function ns_cc_thongtin_nghi_TTCB() {
    try {
        var b_so_the = $get(b_so_theId).value;
        hts_dungchung.Fs_THONGTIN_CANBO(b_so_the, ns_cc_thongtin_nghi_TTCB_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_thongtin_nghi_TTCB_kq(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == "") { form_P_LOI("loi:Nhân viên chưa được làm quyết định:loi"); return }
    form_P_CH_TEXT(b_vungId, b_kq);
    ns_cc_thongtin_nghi_P_DT_TT();
    return false;
}

// thông tin nhân viên thay thế
function ns_cc_thongtin_nghi_P_DT_TT() {
    try {
        var b_so_the = $get(b_so_theId).value, b_phong = $get(b_phongId).value, b_ktra = "DT_SOTHE_THAYTHE";
        hts_dungchung.Fs_NS_KT_SO_THE_THE_PHONG(window.name, b_so_the, b_phong, b_ktra);
    }
    catch (ex) { form_P_LOI(ex.message); }
}

// so sánh ngày
function ns_cc_thongtin_nghi_KT_NGAY(tungay, denngay, loai, ten1, ten2) {
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
function ns_cc_thongtin_nghi_Date(str) {
    var mdy = str.split('/');
    return new Date(mdy[2] + "/" + mdy[1] + "/" + mdy[0]);
}
function mydiff(date1, date2, interval) {
    var second = 1000, minute = second * 60, hour = minute * 60, day = hour * 24, week = day * 7;
    date1 = new Date(date1);
    date2 = new Date(date2);
    var timediff = date2 - date1;
    if (isNaN(timediff)) return NaN;
    switch (interval) {
        case "years": return date2.getFullYear() - date1.getFullYear();
        case "months": return (
            (date2.getFullYear() * 12 + date2.getMonth())
            -
            (date1.getFullYear() * 12 + date1.getMonth())
        );
        case "weeks": return Math.floor(timediff / week);
        case "days": return Math.floor(timediff / day);
        case "hours": return Math.floor(timediff / hour);
        case "minutes": return Math.floor(timediff / minute);
        case "seconds": return Math.floor(timediff / second);
        default: return undefined;
    }
}

function ns_cc_thongtin_nghi_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function ns_cc_thongtin_nghi_P_MAU() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'btn_excel_mau');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;

}
function ns_cc_thongtin_nghi_FILE_Import() {
    var b_tenf = '/App_form/ns/ma/file_Import.aspx';
    form_P_MO(b_tenf, window.name + ',THAMSO', ['THAMSO', [window.name, 'THONGTIN_NGHI_IMP', null, "Import thông tin nghỉ"]], null);
    form_P_LOI('');
    return false;
}

// Cập nhật trạng thái
function ns_cc_thongtin_nghi_P_Update() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")), b_ngayd = $get(b_ngaydId).value;
        if (b_hang < 1 || b_so_id == "") { form_P_LOI("Bạn phải chọn một bản ghi để hủy"); ns_cc_thongtin_nghi_P_MOI(); return false; }
        else {
            b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "huydon"));
            if (b_trangthai == '1') { form_P_LOI('loi:Bản ghi ghi đã bị hủy, bạn không thể hủy đơn này:loi'); return false; }

            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            var b_so_the_tk = $get(b_so_the_tkId).value, b_ten_tk = $get(b_ten_tkId).value, b_nam_tk = lke_Fs_TRA($get(b_nam_tkId)), b_kyluong = lke_Fs_TRA($get(b_kyluongId)), b_phong_tk = b_ctyValue;

            sns_qt.Fs_NS_CC_THONGTIN_NGHI_UP(form_Fs_nsd(), b_so_id, b_so_the_tk, b_ten_tk, b_nam_tk, b_kyluong, b_phong_tk, "1", a_tso, a_cot, ns_cc_thongtin_nghi_Update_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_cc_thongtin_nghi_Update_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        form_P_LOI("loi:Hủy đơn thành công:loi");
    }
    return false;
}
function ns_cc_thongtin_nghi_P_NAM() {
    try {
        var b_nam = form_Fs_TEN_GTRI(b_vungTkId, 'NAM');
        if (b_nam != "")
            stl_cc.Fs_NS_KYLUONG_CHUNG2_LKE(form_Fs_nsd(), window.name, b_nam, ns_cc_thongtin_nghi_P_NAM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_cc_thongtin_nghi_P_NAM_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        ns_cc_thongtin_nghi_P_KTRA("KYLUONG");
    }
}
// tinh ngày
function tinh_ngay() {
    try {
        var b_ma_nghi = lke_Fs_TRA($get(b_macc_nghiId));
        var b_ngayd = $get(b_ngaydId).value, b_ngayc = $get(b_ngaycId).value;
        if (b_ngayd != "" && b_ngayc != "")
            sns_qt.Fs_NS_CC_THONGTIN_NGHI_LOAI(form_Fs_nsd(), b_ma_nghi, b_ngayd, b_ngayc, tinh_ngay_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        else if ((b_ngayd != "" && b_ngayc == "") || (b_ngayd == "" && b_ngayc != ""))
            $get(b_ngaynghi).value = 1;
    }
    catch (err) { form_P_LOI(err); }
}
function tinh_ngay_KQ(b_kq) {
    try {
        var b_ngayd = $get(b_ngaydId).value, b_ngayc = $get(b_ngaycId).value;
        var a_kq = Fas_ChMang(b_kq, '#')
        if (b_ngayd != "" && b_ngayc != "") {
            var ngay = a_kq[1];
        } else if (b_ngayd != "" && b_ngayc == "") {
            $get(b_ngaynghi).value = 1; return false;
        }
        if (ngay == undefined) { $get(b_ngaynghi).value = ""; return false; }
        if (a_kq[0] == "1") {
            $get(b_ngaynghi).value = ngay;
        } else if (a_kq[0] == "0.5") {
            $get(b_ngaynghi).value = parseFloat(ngay / 2).toFixed(1);
        }
        $get(b_truphepnam).value = $get(b_ngaynghi).value
    } catch (err) { form_P_LOI(err); }
}

function vb_cctc_P_CLICK(b_event, b_id) {
    b_event.stopPropagation();
    var b_targetClassNam = b_event.target.className;
    if (b_targetClassNam == "ico_bptt") {
        var b_ctr = $get(b_id), b_div = $get(b_id + '_Div');
        var a_tso = Attribute_Fas_LAY(b_ctr, 'loai,cap,dvi,ma,ma_ct');
        if (b_ctrbeforId != null) b_ctrbeforId.style.fontWeight = "100";
        b_ctr.style.fontWeight = "700";
        b_ctrbeforId = b_ctr;
        b_ctyValue = a_tso[3];
        ns_cc_thongtin_nghi_P_LKE('K');
        $get(b_aphongId).value = b_ctyValue;
        $get(b_akyluongId).value = lke_Fs_TRA($get(b_kyluongId));
        return false;
    }
    else {
        var b_ctr = $get(b_id), b_div = $get(b_id + '_Div');
        var a_tso = Attribute_Fas_LAY(b_ctr, 'loai,cap,dvi,ma,ma_ct');
        if (a_tso[0] == 'A') return false;
        if (a_tso[0] != 'C') {
            if (b_div == null) vb_cctc_P_SL(b_id, a_tso[0], a_tso[1], a_tso[2], a_tso[3]);
            else {
                b_id = (C_NVL(b_div.style.display) == '') ? '' : b_id;
                vb_cctc_HIEN(a_tso[4], b_id);
            }
        }
    }
    return false;
}
function form_dong() {
    location.reload(false);
}