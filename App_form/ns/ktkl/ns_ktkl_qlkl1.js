var ns_ktkl_qlkl_lkeCho = 0, ns_ktkl_qlkl_choAct = 0, b_vungId, b_grlkeId, b_vungtkId, b_slideId, b_slidectId, b_gchuId,
    b_grctId, b_vungHi, b_so_idId, b_nguoikyId, b_ngay_bhId, b_dtuongId, b_an_canhanId, b_an_canhan1Id, b_an_taptheId,
    b_an_truluongId, b_ngay_hlId, b_ngay_hhlId, b_trangthaiId, b_truluongId, b_cdanhnkId, b_so_theId, b_tenId, b_cdanhId,
    b_dviId, b_cap_ktkld, b_dtuongTk, b_tthaiTk, b_sotheTk, b_tenTk, b_phongTk, b_nvTk, b_ten_dviId, b_tencdanhId, b_so_idHi, b_namId,
    b_ten_cdanhnkId, b_dtHi, b_tungayHi, b_denngayHi, b_phongHi, b_tthaiHi, b_hinhthucId, b_sotienId, b_andtklId, b_ctyValue, b_ctrbeforId;
function ns_ktkl_qlkl_P_KD() {
    try {
        ns_ktkl_qlkl_lkeCho = setInterval('ns_ktkl_qlkl_P_LKE_CHO()', 200);
    }
    catch (err) { return; }
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("TEN_NGUOIKY") >= 0) {
            $get(b_nguoikyId).value = a_tso[0];
            $get(b_ten_nguoikyId).value = a_tso[1];
            $get(b_cdanhnkId).value = a_tso[6];
            tra_thong_tin_nk(a_tso[0]);
            $get(b_ngay_bhId).focus();
        }
        else if (b_dtuong.indexOf("CTL00_CONTENTPLACEHOLDER1_GR_CT_CTL02_SO_THENV") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grctId, b_hang, "so_thenv", b_kq);
            GridX_datGtri(b_grctId, b_hang, ["tennv"], [a_tso[1]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["cdanhnv"], [a_tso[6]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["dvinv"], [a_tso[2]], 'K');
            tra_thong_tin(b_kq);
            GridX_datA(b_grctId, b_hang + 1, "so_thenv");
        }
        else if (b_dtuong.indexOf("SO_THE") >= 0) {
            $get(b_so_theId).value = a_tso[0];
            $get(b_tenId).value = a_tso[1];
            $get(b_cdanhId).value = a_tso[6];
            $get(b_dviId).value = a_tso[2];
            tra_thong_tin(a_tso[0]);
            $get(b_cap_ktkld).focus();
        }
        else if (b_dtuong.indexOf("DTUONG") >= 0) {
            $get(b_dtuongId).value = a_tso[0];
            $get(b_cap_ktkld).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ktkl_qlkl_P_KTRA(b_maTen) {
    var b_maId = "";
    b_maTen = b_maTen.toUpperCase();
    switch (b_maTen) {
        case "HINHTHUC": b_maId = b_hinhthucId; break;
    }
    var b_ma = $get(b_maId);
    if (b_ma == null || C_NVL(b_ma.value) == "") return;
    if (b_maTen == "HINHTHUC") {
        var b_hinhthuc = lke_Fs_TRA(b_hinhthucId);
        sns_ktkl.Fs_NS_HTKL_TRA(b_hinhthuc, ns_htkl_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function ns_ktkl_qlkl_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}
function ns_ktkl_qlkl_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    $get(b_so_idHi).value = "0";
    $get(b_ngay_hlId).focus();
    ///$get(b_gchuId).innerHTML = "";
    //list_P_DAT(b_trangthaiId, 'CPD');
    return false;
}
function ns_ktkl_qlkl_P_NH() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_trangthai = GridX_Fas_layGtri(b_grlkeId, b_hang, "trangthai");
        if (b_trangthai == "PD") { form_P_LOI("loi:Bản ghi đã được phê duyệt. Thao tác không thành công:loi"); return false; }
        var ktra = ktra_ngay(parseDate($get(b_ngay_hlId).value).getTime(), parseDate($get(b_ngay_hhlId).value).getTime(), 1, "Ngày hiệu lực", "Ngày hết hiệu lực");
        if (ktra.length > 0) { ns_ktkl_qlkl_NH_KQ(ktra); return false; }
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt_tk = form_Faa_TEXT_ROW(b_vungId);
            var a_dt = form_Faa_TEXT_ROW(b_vungId), b_so_id = $get(b_so_idHi).value;
            var b_hang = GridX_Fi_timHangA(b_grlkeId), a_cot_ct = GridX_Fdt_cotGtri(b_grctId);
            if (b_hang < 1) b_hang = -1;
            var a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            sns_ktkl.Fs_NS_KTKL_QLKL_NH(form_Fs_nsd(), b_so_id, a_dt_tk, a_dt, a_cot_ct, a_cot, b_TrangKt, ns_ktkl_qlkl_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_ktkl_qlkl_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_so_idHi).value = a_kq[4];
        $get(b_ngay_hlId).focus();
        form_P_LOI("loi:Ghi thành công!:loi");
    }
    return false;
}
function ns_ktkl_qlkl_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_trangthai = GridX_Fas_layGtri(b_grlkeId, b_hang, "trangthai");
    if (b_trangthai == "PD") { form_P_LOI("loi:Bản ghi đã được phê duyệt. Thao tác không thành công:loi"); return false; }
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") ns_ktkl_qlkl_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var a_dt_tk = form_Faa_TEXT_ROW(b_vungtkId);
        sns_ktkl.Fs_NS_KTKL_QLKL_XOA(form_Fs_nsd(), b_ctyValue, a_dt_tk, b_so_id, a_cot, a_tso, ns_ktkl_qlkl_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_ktkl_qlkl_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) {
            ns_ktkl_qlkl_P_MOI();
        }
        else {
            GridX_datA(b_grlkeId, b_hang); ns_ktkl_qlkl_P_CHUYEN_HANG();
        }
        form_P_LOI("loi:Xóa thành công!:loi"); return false;
    }
}
function ns_ktkl_qlkl_GR_lke_RowChange() {
    if (ns_ktkl_qlkl_choAct != 0) clearTimeout(ns_ktkl_qlkl_choAct);
    ns_ktkl_qlkl_choAct = setTimeout("ns_ktkl_qlkl_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_ktkl_qlkl_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    var b_dtuong = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "dtuong"));
    if (b_so_id == "0" || b_so_id == "") { ns_ktkl_qlkl_P_MOI(); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        sns_ktkl.Fs_NS_KTKL_QLKL_CT(form_Fs_nsd(), window.name, b_so_id, a_cot_ct, ns_ktkl_qlkl_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        $get(b_so_idHi).value = b_so_id;
    }
    return false;
}
function ns_ktkl_qlkl_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_dtuong = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "dtuong"));
    var b_tvluong = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tvluong"));
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    GridX_datBang(b_grctId, a_kq[1]);
    if (b_dtuong == "CN") {
        checkanhien(b_dtuong);
        checkanhien(b_tvluong);
    } else if (b_dtuong == "TT") {
        checkanhien(b_dtuong);
        slide_P_SOTRANG(b_slidectId);
    }
    $get(b_andtklId).value = b_dtuong;
}
function ns_ktkl_qlkl_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
        b_vungtkId = form_Fs_VUNG_ID('UPa_tk'), b_grctId = form_Fs_VUNG_ID('GR_ct');
        b_vungHi = form_Fs_VUNG_ID('UPa_hi');
        b_an_canhanId = form_Fs_VUNG_ID('an_canhan'); b_an_canhan1Id = form_Fs_VUNG_ID('an_canhan1'); b_an_taptheId = form_Fs_VUNG_ID('an_tapthe');
        b_an_truluongId = form_Fs_VUNG_ID('an_truluong');
        b_so_idHi = form_Fs_TEN_ID(b_vungHi, 'so_id');
        b_truluongId = form_Fs_TEN_ID(b_vungId, 'tvluong');
        b_dtuongId = form_Fs_TEN_ID(b_vungId, 'dtuong');
        b_ngay_hlId = form_Fs_TEN_ID(b_vungId, 'NGAY_HL');
        b_ngay_hhlId = form_Fs_TEN_ID(b_vungId, 'ngay_hhl');
        b_ngay_bhId = form_Fs_TEN_ID(b_vungId, 'ngayky');
        b_so_theId = form_Fs_TEN_ID(b_vungId, 'SO_THE');
        b_tenId = form_Fs_TEN_ID(b_vungId, 'ten');
        b_trangthaiId = form_Fctr_TEN_DTUONG(b_vungId, 'trangthai');
        b_cdanhId = form_Fs_TEN_ID(b_vungId, 'cdanh');
        b_tencdanhId = form_Fs_TEN_ID(b_vungId, 'ten_cdanh');
        b_dviId = form_Fs_TEN_ID(b_vungId, 'dvi');
        b_ten_dviId = form_Fs_TEN_ID(b_vungId, 'ten_dvi');
        b_cap_ktkld = form_Fs_TEN_ID(b_vungId, 'CAP_KTKL');
        b_cdanhnkId = form_Fs_TEN_ID(b_vungId, 'cdanhnk');
        b_ten_cdanhnkId = form_Fs_TEN_ID(b_vungId, 'ten_cdanhnk');
        b_nguoikyId = form_Fs_TEN_ID(b_vungId, 'nguoiky');
        b_ten_nguoikyId = form_Fs_TEN_ID(b_vungId, 'ten_nguoiky');
        b_namId = form_Fs_TEN_ID(b_vungId, 'nam');
        b_dtuongTk = form_Fs_TEN_ID(b_vungtkId, 'dtkl_tk');
        b_sotheTk = form_Fs_TEN_ID(b_vungtkId, 'so_the_tk');
        b_tenTk = form_Fs_TEN_ID(b_vungtkId, 'ten_tk');
        b_phongTk = form_Fs_TEN_ID(b_vungtkId, 'phong_tk');
        b_nvTk = form_Fs_TEN_ID(b_vungtkId, 'nghi_viec_tk');
        b_tthaiTk = form_Fs_TEN_ID(b_vungtkId, 'trangthai_tk');
        b_gchuId = form_Fs_VTEN_ID('', 'gchu');
        b_dtHi = form_Fs_TEN_ID(b_vungHi, 'dtkl_Hi');
        b_tungayHi = form_Fs_TEN_ID(b_vungHi, 'tungay_Hi');
        b_dengayHi = form_Fs_TEN_ID(b_vungHi, 'denngay_Hi');
        b_tthaiHi = form_Fs_TEN_ID(b_vungHi, 'tthai_Hi');
        b_phongHi = form_Fs_TEN_ID(b_vungHi, 'phong_Hi');
        b_hinhthucId = form_Fs_TEN_ID(b_vungId, 'HINHTHUC');
        b_sotienId = form_Fs_TEN_ID(b_vungId, 'sotien');
        b_andtklId = form_Fs_VTEN_ID('UPa_hi', 'andtkl'),
            b_slideId = $get(b_grlkeId).getAttribute('slideId'); slide_P_MOI(b_slideId);
        b_slidectId = $get(b_grctId).getAttribute('slideId'); slide_P_MOI(b_slidectId);
        form_F_GOC().P_MENUBf(window.name, 'M');
        vb_cctc_P_SL('', 'D', '0', ' ', ' ', 'T');
        b_ctyValue = "TATCA";
        checkanhien();
        //ns_danhsach_P_KYLUONG();
        clearTimeout(ns_ktkl_qlkl_lkeCho);
        ns_ktkl_qlkl_P_LKE();
    }
}
function ns_ktkl_qlkl_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var a_dt_tk = form_Faa_TEXT_ROW(b_vungtkId); var b_phong_tk = lke_Fs_TRA($get(b_phongTk));
        sns_ktkl.Fs_NS_KTKL_QLKL_LKE(form_Fs_nsd(), b_ctyValue, a_dt_tk, a_cot, a_tso, ns_ktkl_qlkl_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ktkl_qlkl_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    //$get(b_dtHi).value = $get(b_dtuongTk).value;
    //$get(b_tthaiHi).value = $get(b_tthaiTk).value;
    //$get(b_phongHi).value = $get(b_phongTk).value;
}
function ns_ktkl_qlkl_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'in_excel');
    $get(b_btn_excel).click();
    var b_btn_word = form_Fs_VTEN_ID('', 'in_word');
    $get(b_btn_word).click(); form_chay = 0;
    return false;
}
function checkanhien(b_kq) {
    var b_dtuong, b_congluong;
    if (b_kq == undefined || b_kq == "") {
        b_dtuong = form_Fs_TEN_GTRI(b_vungId, 'dtuong')
        b_congluong = $get(b_truluongId).value;
    }
    else b_dtuong = b_kq;
    if (b_dtuong == "CN") {
        $get(b_an_canhanId).style.display = "";
        $get(b_an_canhan1Id).style.display = "";
        $get(b_an_taptheId).style.display = "none";
    } else if (b_dtuong == "TT") {
        $get(b_an_canhanId).style.display = "none";
        $get(b_an_taptheId).style.display = "";
        $get(b_an_canhan1Id).style.display = "none";
    }
    if ($get(b_truluongId).value == "X") {
        $get(b_an_truluongId).style.display = "";
    }
    else {
        $get(b_an_truluongId).style.display = "none";
    }
    return false;
}
function ns_ktkl_qlkl_HangLen(mode) {
    var b_grct;
    if (mode == 1) b_grct = b_grctId;
    else return false;
    GridX_chuyenHang(b_grct, -1);
    return false;
}
function ns_ktkl_qlkl_HangXuong(mode) {
    var b_grct;
    if (mode == 1) b_grct = b_grctId;
    else return false;
    GridX_chuyenHang(b_grct, 1);
    return false;
}
function ns_ktkl_qlkl_CatDong(mode) {
    var b_grct;
    if (mode == 1) b_grct = b_grctId;
    else return false;
    GridX_boChon(b_grct, 'C');
    return false;
}
function ns_ktkl_qlkl_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function tra_thong_tin(b_so_the) {
    try {
        sns_ktkl.Fs_NS_KTKL_QLKL_TRA(b_so_the, tra_thong_tin_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function tra_thong_tin_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    $get(b_ten_dviId).value = a_kq[0]; $get(b_tencdanhId).value = a_kq[1];
    var b_hang = GridX_Fi_timHangA(b_grctId);
    if (b_hang < 0) return;
    GridX_datGtri(b_grctId, b_hang, ["ten_dvinv"], a_kq[0], 'K');
    GridX_datGtri(b_grctId, b_hang, ["ten_cdanhnv"], a_kq[1], 'K');
}
function tra_thong_tin_nk(b_so_the) {
    try {
        sns_ktkl.Fs_NS_KTKL_QLKL_TRA(b_so_the, tra_thong_tin_nk_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function tra_thong_tin_nk_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    $get(b_ten_cdanhnkId).value = a_kq[1];
}
function ns_danhsach_P_KYLUONG() {
    try {
        var b_nam = lke_Fs_TRA(b_namId);
        sns_ktkl.Fs_NS_KTKL_QLKL_KYLUONG_LKE(window.name, CSO_SO(b_nam, 0), ns_danhsach_P_KYLUONG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_danhsach_P_KYLUONG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
}
function ns_cb_phong(check) {
    try {
        b_check = check;
        var b_tenf = form_Fs_TM() + '/App_form/ht/ht_maph.aspx';
        form_P_MO(b_tenf, null, ["ns_cb", [""]]);
        return false;
    }
    catch (err) { }
}
function ns_htkl_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    $get(b_sotienId).value = b_kq;
}
function nhap_file() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1 || $get(b_so_idHi).value == "") {
        form_P_LOI('loi:Bạn phải chọn 1 bản ghi:loi')
        return false;
    }
    var b_so_id = $get(b_so_idHi).value;
    var b_tenf = '/App_form/ns/ma/file_Import_chung.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, b_so_id, "NS_KTKL_QLKL", "Lưu file quyết định kỷ luật"]], null);
    form_P_LOI('');
    return false;

}
function parseDate(str) {
    var mdy = str.split('/');
    return new Date(mdy[2], mdy[1], mdy[0]);
}
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
        ns_ktkl_qlkl_P_LKE();
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