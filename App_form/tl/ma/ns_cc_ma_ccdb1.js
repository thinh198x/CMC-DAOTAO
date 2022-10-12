var ns_cc_ma_ccdb_lkeCho, b_vungId,ns_test_choAct=0, b_grlkeId,ns_cc_ma_ccdb_choAct=0, b_slideId, b_vungtkId, b_ncbId, b_so_idId,b_cho_control = 0,b_ncbId,b_cdanhId,b_ngay_hlId;
function ns_cc_ma_ccdb_P_KD() {        
    ns_cc_ma_ccdb_lkeCho = setInterval('ns_cc_ma_ccdb_P_LKE_CHO()', 200);
}
function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) { 
            $get(b_gchuId).innerHTML = b_ten;
            $get(b_ncbId).focus();
            ns_cc_ma_ccdb_P_LKE('K');
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
        if (b_dtuong.indexOf("THAMSO") >= 0) { 
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);           
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_ma_ccdb_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_t = b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_ncbId; form_P_MOI("", "XGL"); break;            
        }
        b_chonId = b_maTen;
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;

    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_ma_ccdb_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq); 
    }
    else { form_P_DatGchu(b_gchuId, b_kq); }
}
function ns_cc_ma_ccdb_P_MOI() {
    form_P_MOI(b_vungId, "GXLK");
    GridX_thoiA(b_grlkeId);    
    //$get(b_ncbId).focus();
    return false;
}
function ns_cc_ma_ccdb_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
         
        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")); 
        stl_ma.Fs_NS_CC_MA_CCDB_NH(form_Fs_nsd(), b_so_id, b_TrangKt, a_dt_ct, a_cot_lke, ns_cc_ma_ccdb_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { throw (err); }
}
function ns_cc_ma_ccdb_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
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
function ns_cc_ma_ccdb_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");        
    if (b_so_id == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); ns_cc_ma_ccdb_P_MOI(); return false; }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId); 
        stl_ma.Fs_NS_CC_MA_CCDB_XOA(form_Fs_nsd(), b_so_id,  a_tso, a_cot, ns_cc_ma_ccdb_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_cc_ma_ccdb_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_cc_ma_ccdb_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_cc_ma_ccdb_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
    return false;
}
//Chuy?n hàng
function ns_cc_ma_ccdb_GR_lke_RowChange() {
    if (ns_cc_ma_ccdb_choAct != 0) clearTimeout(ns_cc_ma_ccdb_choAct);
    ns_cc_ma_ccdb_choAct = setTimeout("ns_cc_ma_ccdb_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_cc_ma_ccdb_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return; 
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "0" || b_so_id == "") {form_P_MOI(b_vungId, "XGL"); }
    else stl_ma.Fs_NS_CC_MA_CCDB_CT(form_Fs_nsd(), b_so_id,ns_cc_ma_ccdb_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);    
}
function ns_cc_ma_ccdb_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false; 
}
//Li?t kê
function ns_cc_ma_ccdb_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ns_cc_ma_ccdb_lkeCho != 0) clearTimeout(ns_cc_ma_ccdb_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), 
        b_grlkeId = form_Fs_VUNG_ID('GR_lke'), 
        b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'); 
        //b_ncbId = form_Fs_TEN_ID(b_vungId, 'ncb'),
        b_cdanhId = form_Fs_TEN_ID(b_vungId, 'cdanh'),
        b_ngay_hlId = form_Fs_TEN_ID(b_vungId, 'ngay_hl');
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_cc_ma_ccdb_P_LKE('K');
    }
}
function ns_cc_ma_ccdb_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);  
        stl_ma.Fs_NS_CC_MA_CCDB_LKE(form_Fs_nsd(), a_tso, a_cot, ns_cc_ma_ccdb_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_cc_ma_ccdb_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}  
//Ki?m tra ngày tháng
function ns_cc_ma_ccdb_P_NGAY(str) {
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
        return 'loi:Ngày h:loi';
    }
    return "";
}
function ktra_ngay(tungay, denngay, loai, ten1, ten2) {
    if (denngay == "" || denngay == null) {
        return "";
    }
    if (loai == 1 && tungay > denngay) {
        return "loi: " + ten1 + " không du?c l?n hon " + ten2 + " :loi";
    } else if (loai == 2 && tungay >= denngay) {
        return "loi: " + ten1 + " không du?c l?n hon ho?c b?ng " + ten2 + " :loi";
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