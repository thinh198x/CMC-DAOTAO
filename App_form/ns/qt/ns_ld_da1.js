var ns_ld_da_lkeCho, b_vungId, b_grlkeId, b_slideId, b_vungtkId, b_gocId, b_so_idId, b_cho_control = 0, b_ten_tkId, b_ngay_tlId, b_ngaydId, b_ngaycId,
    ns_ld_da_choAct = 0, b_grctId, b_so_theId;
function ns_ld_da_P_KD() {
    b_grctId = form_Fs_VUNG_ID('GR_ct');
    ns_ld_da_lkeCho = setInterval('ns_ld_da_P_LKE_CHO()', 200);
}
function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_gocId).value = b_so_the;
            $get(b_gchuId).innerHTML = b_ten;
            $get(b_gocId).focus();
            ns_ld_da_P_LKE('K');
            b_doi = 1;
            clearTimeout(b_cho_control);
        }
    }
    catch (err) { b_doi = 0; }
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return; 
            ns_ld_da_TTCB(b_kq);
            //GridX_datGtri(b_grctId, b_hang, ["ho_ten"], [a_tso[1]], 'K');
            //GridX_datGtri(b_grctId, b_hang, ["phong"], [a_tso[3]], 'K');
            //GridX_datGtri(b_grctId, b_hang, ["cdanh"], [a_tso[6]], 'K');
        }
        else if (b_dtuong.indexOf("THAMSO") >= 0) {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ld_da_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_t = b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_so_theId; form_P_MOI("", "XGL"); break;
        }
        if (b_maTen == "SO_THE") {
            //skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_cc_thongtin_nghi_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_ld_da_TTCB();
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_ld_da_P_MOI(); ns_ld_da_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang);ns_ld_da_P_CHUYEN_HANG(); } 
        }
        b_chonId = b_maTen;
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;

    }
    catch (err) { form_P_LOI(err); }
}
function ns_ld_da_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
    }
    else { form_P_DatGchu(b_gchuId, b_kq); }
}
function ns_ld_da_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_datTrang(b_grctId);
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = "0"; 
    return false;
}
function ns_ld_da_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var ktra = ktra_ngay(parseDate($get(b_ngaydId).value).getTime(), parseDate($get(b_ngaycId).value).getTime(), 1, "Từ ngày", "đến ngày");
        if (ktra.length > 0) {
            ns_ld_da_P_NH_KQ(ktra);
            return false;
        }
        var b_dt = form_Faa_TEXT_ROW(b_vungId), b_dt_ct = GridX_Fdt_cotGtri(b_grctId);
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        var b_ten_da = $get(b_ten_tkId).value;
        sns_qt.Fs_NS_LD_DA_NH(form_Fs_nsd(), b_so_id, b_ten_da, b_TrangKt,b_dt, b_dt_ct, a_cot_lke, ns_ld_da_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { throw (err); }
}
function ns_ld_da_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang2(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_so_idId).focus();
        form_P_LOI("loi:Nhập thành công!:loi");
    }
    return false;
}
function ns_ld_da_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); ns_ld_da_P_MOI(); return false; }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_ten_da = $get(b_ten_tkId).value;
        sns_qt.Fs_NS_LD_DA_XOA(form_Fs_nsd(), b_so_id, b_ten_da, a_tso, a_cot, ns_ld_da_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_ld_da_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang2(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_ld_da_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_ld_da_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
    return false;

}
//Chuyển hàng
function ns_ld_da_GR_lke_RowChange() {
    if (ns_ld_da_choAct != 0) clearTimeout(ns_ld_da_choAct);
    ns_ld_da_choAct = setTimeout("ns_ld_da_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_ld_da_P_CHUYEN_HANG() {
    try{
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")), a_cot = GridX_Fas_tenCot(b_grlkeId), a_cot_ct = GridX_Fas_tenCot(b_grctId);
        if (b_so_id == "0" || b_so_id == "") { form_P_MOI(b_vungId, "XGL"); }
        else sns_qt.Fs_NS_LD_DA_CT(form_Fs_nsd(), b_so_id, a_cot_ct, ns_ld_da_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    } catch (err) { form_P_LOI(err); }
}
function ns_ld_da_P_CHUYEN_HANG_KQ(b_kq) { 
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] != "") {
        GridX_datBang2(b_grctId, a_kq[1]);     
    }
}
//Liệt kê
function ns_ld_da_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ns_ld_da_lkeCho != 0) clearTimeout(ns_ld_da_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
        b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_so_theId = form_Fs_TEN_ID(b_grctId, 'SO_THE'),
        b_vungtkId = form_Fs_VUNG_ID('UPa_tk'), b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'), b_ngaydId = form_Fs_TEN_ID(b_grctId, 'ngayd'),
        b_ngaycId = form_Fs_TEN_ID(b_grctId, 'ngayc'); b_ten_tkId = form_Fs_VTEN_ID(b_vungtkId, 'duan_tk');
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_ld_da_P_LKE('K');
    }
}
function ns_ld_da_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId), b_ten_da = $get(b_ten_tkId).value;
        sns_qt.Fs_NS_LD_DA_LKE(form_Fs_nsd(), b_ten_da, a_tso, a_cot, ns_ld_da_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_ld_da_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang2(b_grlkeId, a_kq[1]);
}
//
function ns_ld_da_TTCB(b_so_the) {
    try { 
        hts_dungchung.Fs_THONGTIN_CANBO_LUOI(b_so_the, ns_ld_da_TTCB_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ld_da_TTCB_kq(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var a_kq = Fas_ChMang(b_kq, '#');
    if (a_kq != "") {
        var b_hang = GridX_Fi_timHangA(b_grctId);
        GridX_datGtri(b_grctId, b_hang, "so_the", a_kq[1], 'K');
        GridX_datGtri(b_grctId, b_hang, "ho_ten", a_kq[2], 'K');
        GridX_datGtri(b_grctId, b_hang, "cdanh", a_kq[3], 'K');
        GridX_datGtri(b_grctId, b_hang, "phong", a_kq[4], 'K');
    }
    return false;
}
// them dong vao luoi
function ns_ld_da_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_ld_da_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_ld_da_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function ns_ld_da_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}
//Ki?m tra ngày tháng
function ns_ld_da_P_NGAY(str) {
    var mdy_str = str.split('/');
    var mdy_str = mdy_str[2] + mdy_str[1] + mdy_str[0];
    var mdy_str = parseInt(mdy_str);
    var dateht = new Date();
    var m = "0" + (1 + dateht.getMonth());
    var y = parseInt("2" + dateht.getYear()) - 100;
    var d = parseInt("0" + dateht.getDate());
    var dmy = y + m + d;
    var dmy = parseInt(dmy);
    var kq = mdy_str - dmy;
    if (kq > 0) {
        return 'loi:Ngày c?p không du?c l?n hon ngày hi?n t?i:loi';
    }
    return "";
}
function ktra_ngay(tungay, denngay, loai, ten1, ten2) {
    if (denngay == "" || denngay == null) {
        return "";
    }
    if (loai == 1 && tungay > denngay) {
        return "loi: " + ten1 + " không được lớn hơn " + ten2 + " :loi";
    } else if (loai == 2 && tungay >= denngay) {
        return "loi: " + ten1 + " không được lớn hơn hoặc bằng" + ten2 + " :loi";
    }
    return "";
}
function parseDate(str) {
    var mdy = str.split('/');
    return new Date(mdy[2], mdy[1], mdy[0]);
}
function getDateNow() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();
    if (dd < 10) {
        dd = '0' + dd;
    }
    if (mm < 10) {
        mm = '0' + mm;
    }
    var datenow = dd + '/' + mm + '/' + yyyy;
    return datenow;
}
function form_dong() {
    location.reload(false);
}