var ns_biendong_bh_lkeCho, b_vungId, b_vungtkId, b_grlkeId, b_slideId, b_gocId, b_ngaytruy_thud, b_ngaytruy_thuc, b_ngaythoai_thud, b_ngaythoai_thuc, b_timId, b_so_idId,
    b_gchuId, b_phongId, b_ho_ten, b_loaibd, b_cho_control = 0, ns_biendong_bh_choAct = 0, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C', b_sothe_tkId, b_ten_tkId,
    b_phongtkId, b_thangd_tkId, b_thangc_tkId, b_tt_bhxhId, b_tt_bhytId, b_tt_bhtnId, b_ctrbeforId, b_ctyValue, b_aphongId, b_tht_bhxhId, b_tht_bhytId, b_tht_bhtnId;
function ns_biendong_bh_P_KD() {
    ns_biendong_bh_lkeCho = setInterval('ns_biendong_bh_P_LKE_CHO()', 200);
}
// Kiểm tra
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[0];
        b_doi = 0;
        if (b_dtuong.indexOf("SO_THE") >= 0 || b_dtuong.indexOf("THAMSO") >= 0) {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "','" + a_tso[6] + "')", 200);
        }
        else if (b_dtuong.indexOf("LOAI_BD") >= 0) {
            $get(b_loaibd).value = b_kq;
            $get(b_gchuId).innerhtml = a_tso[1];
            $get(b_loaibd).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}

function P_cho(b_so_the, b_ten, b_phong, b_chucdanh) {
    try {
        if (b_doi == 0) {
            $get(b_gocId).value = b_so_the;
            $get(b_ho_ten).value = b_ten;
            $get(b_phongId).value = b_phong;
            $get(b_cdanh).value = b_chucdanh;
            $get(b_gchuId).innerhtml = b_ten;
            $get(b_gocId).focus();
            ns_thongtin_canbo("SO_THE");
            ns_biendong_bh_P_LKE();
            b_doi = 1;
            clearTimeout(b_cho_control);
        }
    }
    catch (err) {
        b_doi = 0;
    }
}
function ns_biendong_bh_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; break;
            case "NGAY_TRUYTHU_D": b_maId = b_ngaytruy_thud; break;
            case "NGAY_THOAITHU_D": b_maId = b_ngaythoai_thud; break;
        }
        var b_ma = $get(b_maId);

        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_biendong_bh_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_thongtin_canbo("SO_THE");
        } else if (b_maTen == "NGAY_TRUYTHU_D") {
            if ($get(b_ngaytruy_thuc).value == "" || C_NVL(b_ma.value) == "") {
                $get(b_tt_bhxhId).value = 0;
                $get(b_tt_bhytId).value = 0;
                $get(b_tt_bhtnId).value = 0;
                return false;
            }
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            var a_cot = GridX_Fas_tenCot(b_grlkeId)
            sns_cd.Fs_NS_BIENDONG_BH_CHECKTHU(a_dt_ct, a_cot, 1, ns_biendong_bh_P_TRUYTHU_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_maTen == "NGAY_THOAITHU_D") {
            if ($get(b_ngaythoai_thuc).value == "" || C_NVL(b_ma.value) == "") {
                $get(b_tht_bhxhId).value = 0;
                $get(b_tht_bhytId).value = 0;
                $get(b_tht_bhtnId).value = 0;
                return false;
            }
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            var a_cot = GridX_Fas_tenCot(b_grlkeId)
            sns_cd.Fs_NS_BIENDONG_BH_CHECKTHU(a_dt_ct, a_cot, 2, ns_biendong_bh_P_THOAITHU_KQ, P_LOI_CSDL, P_LOI_TGIAN);

        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_biendong_bh_P_TRUYTHU_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    $get(b_tt_bhxhId).value = SO_CSO(a_kq[0]);
    $get(b_tt_bhytId).value = SO_CSO(a_kq[1]);
    $get(b_tt_bhtnId).value = SO_CSO(a_kq[2]);
}
function ns_biendong_bh_P_THOAITHU_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    $get(b_tht_bhxhId).value = SO_CSO(a_kq[0]);
    $get(b_tht_bhytId).value = SO_CSO(a_kq[1]);
    $get(b_tht_bhtnId).value = SO_CSO(a_kq[2]);
}
function ns_biendong_bh_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}
function ns_biendong_bh_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_cd.Fs_NS_BIENDONG_BH_MA(b_ma, b_TrangKt, a_cot, ns_biendong_bh_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_biendong_bh_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_biendong_bh_P_CHUYEN_HANG(); }
}
// Nhập
function ns_biendong_bh_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = "0";
    $get(b_gocId).focus();
    return false;
}
function ns_biendong_bh_P_NH() {
    var ktra_truythu = ktra_ngay(parseDate($get(b_ngaytruy_thud).value).getTime(), parseDate($get(b_ngaytruy_thuc).value).getTime(), 1, "Truy thu từ ngày", "Truy thu đến ngày");
    var ktra_thoaithu = ktra_ngay(parseDate($get(b_ngaythoai_thud).value).getTime(), parseDate($get(b_ngaythoai_thuc).value).getTime(), 1, "Thoái thu từ ngày", "Thoái thu đến ngày");
    if (ktra_truythu.length > 0) {
        ns_biendong_bh_P_NH_KQ(ktra_truythu);
        return false;
    } else if (ktra_thoaithu.length > 0) {
        ns_biendong_bh_P_NH_KQ(ktra_thoaithu);
        return false;
    }
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    var b_hang = GridX_Fi_timHangA(b_grlkeId), b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")), a_tso = slide_Faobj_TUDEN(b_slideId);
    var b_sothe = $get(b_sothe_tkId).value, b_hoten = $get(b_ten_tkId).value, b_phong = b_ctyValue, b_thangd = $get(b_thangd_tkId).value
    b_thangc = $get(b_thangc_tkId).value;
    sns_cd.Fs_NS_BIENDONG_BH_NH(b_so_id, b_sothe, b_hoten, b_phong, b_thangd, b_thangc, a_dt_ct, b_TrangKt, a_cot, a_tso, ns_biendong_bh_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_biendong_bh_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        form_P_LOI("loi:Nhập thành công!:loi");
    }
    return false;
}
// Xóa
function ns_biendong_bh_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_hang < 1 || b_so_id == "") { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var b_loai = lke_Fs_TRA($get(b_loaibd));
    if (b_loai == "1") { form_P_LOI("Không được xóa bản ghi biến động tăng mới"); return false; }

    var a_tso = slide_Faobj_TUDEN(b_slideId), a_cot = GridX_Fas_tenCot(b_grlkeId);
    var b_sothe = $get(b_sothe_tkId).value, b_hoten = $get(b_ten_tkId).value, b_phong = b_ctyValue, b_thangd = $get(b_thangd_tkId).value
    b_thangc = $get(b_thangc_tkId).value;
    sns_cd.Fs_NS_BIENDONG_BH_XOA(b_so_id, b_sothe, b_hoten, b_phong, b_thangd, b_thangc, a_tso, a_cot, ns_biendong_bh_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_biendong_bh_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_biendong_bh_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_biendong_bh_P_CHUYEN_HANG(); }
    }
}
// Chuyển hàng
function ns_biendong_bh_GR_lke_RowChange() {
    if (ns_biendong_bh_choAct != 0) clearTimeout(ns_biendong_bh_choAct);
    ns_biendong_bh_choAct = setTimeout("ns_biendong_bh_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_biendong_bh_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "") form_P_MOI(b_vungId, "XGL");
        else sns_cd.Fs_NS_BIENDONG_BH_CT(b_so_id, ns_biendong_bh_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_biendong_bh_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
// Liệt kê
function ns_biendong_bh_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (ns_biendong_bh_lkeCho != 0) clearTimeout(ns_biendong_bh_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtkId = form_Fs_VUNG_ID('UPa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
            b_sothe_tkId = form_Fs_TEN_ID(b_vungtkId, 'so_the_tk'), b_ten_tkId = form_Fs_TEN_ID(b_vungtkId, 'ten_tk'), b_phongtkId = form_Fs_TEN_ID(b_vungtkId, 'phong_tk'),
            b_thangd_tkId = form_Fs_TEN_ID(b_vungtkId, 'thangd_tk'), b_thangc_tkId = form_Fs_TEN_ID(b_vungtkId, 'thangc_tk');
        b_gocId = form_Fs_TEN_ID(b_vungId, 'so_the');
        b_ngaytruy_thud = form_Fs_TEN_ID(b_vungId, 'ngay_truythu_d'), b_ngaytruy_thuc = form_Fs_TEN_ID(b_vungId, 'ngay_truythu_c');
        b_ngaythoai_thud = form_Fs_TEN_ID(b_vungId, 'ngay_thoaithu_d'), b_ngaythoai_thuc = form_Fs_TEN_ID(b_vungId, 'ngay_thoaithu_c');
        b_tt_bhxhId = form_Fs_TEN_ID(b_vungId, 'tt_bhxh'), b_tt_bhytId = form_Fs_TEN_ID(b_vungId, 'tt_bhyt'), b_tt_bhtnId = form_Fs_TEN_ID(b_vungId, 'tt_bhtn'),
            b_tht_bhxhId = form_Fs_TEN_ID(b_vungId, 'tht_bhxh'), b_tht_bhytId = form_Fs_TEN_ID(b_vungId, 'tht_bhyt'), b_tht_bhtnId = form_Fs_TEN_ID(b_vungId, 'tht_bhtn'),
            b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'); b_aphongId = form_Fs_VTEN_ID('UPa_hi', 'aphong'),
                b_phongId = form_Fs_TEN_ID(b_vungId, 'PHONG');
        b_gchuId = form_Fs_VTEN_ID('', 'gchu1');
        b_ho_ten = form_Fs_VTEN_ID(b_vungId, 'ho_ten');
        b_loaibd = form_Fs_VTEN_ID(b_vungId, 'loai_bd');
        b_cdanh = form_Fs_TEN_ID(b_vungId, 'cdanh');
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        form_F_GOC().P_MENUBf(window.name, 'M');
        vb_cctc_P_SL('', 'D', '0', ' ', ' ', 'T');
        b_ctyValue = "TATCA";
        ns_biendong_bh_P_LKE('K');
    }
}
function ns_biendong_bh_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        if (b_dk == 'TK') {
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            var b_sothe = $get(b_sothe_tkId).value, b_hoten = $get(b_ten_tkId).value, b_phong = lke_Fs_TRA($get(b_phongtkId)), b_thangd = $get(b_thangd_tkId).value
            b_thangc = $get(b_thangc_tkId).value;
            sns_cd.Fs_NS_BIENDONG_BH_LKE(b_sothe, b_hoten, b_phong, b_thangd, b_thangc, a_tso, a_cot, ns_biendong_bh_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else {
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            var b_sothe = $get(b_sothe_tkId).value, b_hoten = $get(b_ten_tkId).value, b_phong = b_ctyValue, b_thangd = $get(b_thangd_tkId).value
            b_thangc = $get(b_thangc_tkId).value;
            sns_cd.Fs_NS_BIENDONG_BH_LKE(b_sothe, b_hoten, b_phong, b_thangd, b_thangc, a_tso, a_cot, ns_biendong_bh_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_biendong_bh_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}

function ns_thongtin_canbo(b_loai) {
    try {
        var b_listcotcu = "", b_listcotmoi = "";
        if (b_loai == "SO_THE") { b_kt_loai = "SO_THE"; b_listcotcu = "SO_THE,HO_TEN,CDANH,TEN_CDANH,PHONG,TEN_PHONG,TEN_VITRI,BAC_CDANH,HESO_CD,VITRI", b_listcotmoi = "SO_THE,HO_TEN,CDANH,TEN_CDANH,PHONG,TEN_PHONG,TEN_VITRI,BAC_CDANH,HESO_CD,VITRI" }
        else { b_kt_loai = ""; b_listcotcu = "SO_THE,HO_TEN,TEN_CDANH,TEN_PHONG", b_listcotmoi = "SO_THE,HO_TEN,TEN_CDANH,TEN_PHONG" }
        var b_so_the = $get(b_gocId).value;
        hts_dungchung.Fs_THONGTIN_CANBO_HD(b_so_the, b_listcotcu, b_listcotmoi, ns_thongtin_canbo_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_thongtin_canbo_kq(b_kq) {
    if (b_kq == "") {
        if (b_kt_loai == "SO_THE" || b_kt_loai == "") {
            form_P_MOI(b_vungId, "GXL"); $get(b_gocId).focus(); form_P_LOI(b_kq); return false;
        }
    }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}


//function ns_thongtin_canbo() {
//    try {
//       
//        hts_dungchung.Fs_THONGTIN_CANBO( b_so_the, ns_thongtin_canbo_kq, P_LOI_CSDL, P_LOI_TGIAN);
//        return false;
//    }
//    catch (err) { form_P_LOI(err); }
//}
//function ns_thongtin_canbo_kq(b_kq) {
//    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
//    form_P_CH_TEXT(b_vungId, b_kq);
//    return false;
//}

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

function vb_cctc_P_CLICK(b_event, b_id) {
    b_event.stopPropagation();
    var b_targetClassNam = b_event.target.className;
    if (b_targetClassNam == "ico_bptt") {
        var b_ctr = $get(b_id), b_div = $get(b_id + '_Div');
        var a_tso = Attribute_Fas_LAY(b_ctr, 'loai,cap,dvi,ma,ma_ct');
        if (b_ctrbeforId != null) b_ctrbeforId.style.fontWeight = "100";
        $get(b_aphongId).value = b_ctyValue;
        b_ctr.style.fontWeight = "700";
        b_ctrbeforId = b_ctr;
        b_ctyValue = a_tso[3];
        // load lại dữ liệu 
        $get(b_aphongId).value = b_ctyValue;
        if (b_ctyValue != "") ns_biendong_bh_P_LKE('K');
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