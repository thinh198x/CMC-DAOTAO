var ns_dt_danhgia_kdt_lkeCho, b_vungId, b_gchuId, ns_dt_danhgia_kdt_choAct = 0, b_grlkeId, b_slideId, b_vungtkId, b_namId, b_so_idId, b_cho_control = 0, b_namId, b_thangId, b_khoa_hocId, b_lop_dtId, b_doi_tacId, b_ngay_hocId, b_STT_tk, b_nam_tkId, b_ngay_cId;
function ns_dt_danhgia_kdt_P_KD() {
    ns_dt_danhgia_kdt_lkeCho = setInterval('ns_dt_danhgia_kdt_P_LKE_CHO()', 200);
}
function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_namId).value = b_so_the;
            $get(b_gchuId).innerHTML = b_ten;
            $get(b_namId).focus();
            ns_dt_danhgia_kdt_P_LKE('K');
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
function ns_dt_danhgia_kdt_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_t = b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {            
            case "KHOA_DT": b_maId = b_khoa_hocId; break;
            case "NAM": b_maId = b_namId; break;
            case "LOP_DT": b_maId = b_lop_dtId; break;
        }
        b_chonId = b_maTen;
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "NAM") {
            var b_nam = form_Fs_TEN_GTRI(b_vungId, 'NAM');
            hts_dungchung.P_MA_KDT_NAM(window.name, b_nam);
            var b_kdt = form_Fs_TEN_GTRI(b_vungId, 'KHOA_DT');
            var b_nam = $get(b_namId).value;
            ns_dt_danhgia_P_LHOC();
        } else if (b_maTen == "KHOA_DT") {
            var b_kdt = form_Fs_TEN_GTRI(b_vungId, 'KHOA_DT');
            var b_nam = $get(b_namId).value;
            ns_dt_danhgia_P_LHOC();
        } else if (b_maTen == "LOP_DT") { 
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_ma_cdanh_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_ma_cdanh_P_CHUYEN_HANG(); }

            var b_kdt = form_Fs_TEN_GTRI(b_vungId, 'LOP_DT');            
            ns_dt_danhgia_P_LHOC_CT();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_danhgia_kdt_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
    }
    else { form_P_DatGchu(b_gchuId, b_kq); }
}
function ns_dt_danhgia_kdt_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_ncdanh = $get(b_ncdanhId).value;
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_dt.Fs_NNS_DT_DANHGIA_KDT_MA(form_Fs_nsd(), b_ma, b_TrangKt, a_cot, ns_dt_danhgia_kdt_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_danhgia_kdt_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_ma_cdanh_P_CHUYEN_HANG(); }
}
function ns_dt_danhgia_kdt_P_MOI() {
    form_P_MOI(b_vungId, "GX");
    GridX_thoiA(b_grlkeId);
    $get(b_namId).focus();
    return false;
}
function ns_dt_danhgia_kdt_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var b_ngayc = form_Fs_TEN_GTRI(b_vungId, 'ngay_c');
        //var b_ngayc = "01/31/2018";
        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        var b_nam = lke_Fs_TRA($get(b_nam_tkId));
        a_cot_ct = GridX_Fdt_cotGtri(b_grctId);
        sns_dt.Fs_NS_DT_DANHGIA_KDT_NH(form_Fs_nsd(), b_so_id, b_nam, b_ngayc,b_TrangKt, a_dt_ct, a_cot_lke, a_cot_ct, ns_dt_danhgia_kdt_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { throw (err); }
}
function ns_dt_danhgia_kdt_P_NH_KQ(b_kq) {
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
function ns_dt_danhgia_kdt_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1) { form_P_LOI("loi:Chọn bản ghi:loi"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") { form_P_LOI("loi:Chọn bản ghi:loi"); ns_dt_danhgia_kdt_P_MOI(); return false; }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId), a_cot_ct = GridX_Fas_tenCot(b_grctId);
        var b_nam = lke_Fs_TRA($get(b_nam_tkId));
        sns_dt.Fs_NS_DT_DANHGIA_KDT_XOA(form_Fs_nsd(), b_so_id, b_nam, a_tso, a_cot,a_cot_ct, ns_dt_danhgia_kdt_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_dt_danhgia_kdt_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dt_danhgia_kdt_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dt_danhgia_kdt_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
    return false;
}
//Chuy?n hàng
function ns_dt_danhgia_kdt_GR_lke_RowChange() {
    if (ns_dt_danhgia_kdt_choAct != 0) clearTimeout(ns_dt_danhgia_kdt_choAct);
    ns_dt_danhgia_kdt_choAct = setTimeout("ns_dt_danhgia_kdt_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_dt_danhgia_kdt_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var a_cot_ct = GridX_Fas_tenCot(b_grctId);
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "0" || b_so_id == "") { form_P_MOI(b_vungId, "XGL"); }
    else sns_dt.Fs_NS_DT_DANHGIA_KDT_CT(form_Fs_nsd(), b_so_id, a_cot_ct, ns_dt_danhgia_kdt_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function ns_dt_danhgia_kdt_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == '') return;
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    GridX_datBang(b_grctId, a_kq[1]);
    return false;
}
//Liêt kê
function ns_dt_danhgia_kdt_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ns_dt_danhgia_kdt_lkeCho != 0) clearTimeout(ns_dt_danhgia_kdt_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'),
        b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_grctId = form_Fs_VUNG_ID('GR_ct');
        b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
        b_vungtkId = form_Fs_VUNG_ID('UPa_tk'),
        b_namId = form_Fs_TEN_ID(b_vungId, 'nam'), b_thangId = form_Fs_TEN_ID(b_vungId, 'thang'),
        b_khoa_hocId = form_Fs_TEN_ID(b_vungId, 'KHOA_HOC'), b_lop_dtId = form_Fs_TEN_ID(b_vungId, 'lop_dt'),
        b_doi_tacId = form_Fs_TEN_ID(b_vungId, 'doi_tac'), b_ngay_hocId = form_Fs_TEN_ID(b_vungId, 'ngay_hoc'), b_ngay_cId = form_Fs_TEN_ID(b_vungId, 'ngay_c');
        b_nam_tkId = form_Fs_TEN_ID(b_vungtkId, 'nam_tk');
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_dt_danhgia_kdt_P_LKE('K');
    }
}
function ns_dt_danhgia_kdt_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var b_tam = form_Fs_nsd();
        var b_tam1= b_tam.split(',');
        var b_so_the = b_tam1[0];
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId), a_cot_ct = GridX_Fas_tenCot(b_grctId);
        var b_nam = lke_Fs_TRA($get(b_nam_tkId));
        sns_dt.Fs_NS_DT_DANHGIA_KDT_LKE(form_Fs_nsd(), b_nam, a_tso, a_cot,a_cot_ct, ns_dt_danhgia_kdt_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_dt_danhgia_kdt_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    GridX_datBang(b_grctId, a_kq[2]);
}
function ns_dt_danhgia_P_LHOC() {
    try {
        var b_khoa_dt = form_Fs_TEN_GTRI(b_vungId, 'KHOA_HOC'), b_nam = form_Fs_TEN_GTRI(b_vungId, 'NAM');
        if (b_nam != "" && b_khoa_dt != "")
            sns_dt.Fs_NS_DT_LOPHOC(form_Fs_nsd(), window.name, "DT_LDT", b_nam, b_khoa_dt, ns_dt_danhgia_P_LHOC_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_dt_danhgia_P_LHOC_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
}
function ns_dt_danhgia_P_LHOC_CT() {
    try {
        b_lop_dt = form_Fs_TEN_GTRI(b_vungId, 'LOP_DT');
        if (b_lop_dt != "")
            sns_dt.Fs_NS_DT_LOPHOC_CT(form_Fs_nsd(), b_lop_dt, ns_dt_danhgia_P_LHOC_CT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_dt_danhgia_P_LHOC_CT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else form_P_CH_TEXT(b_vungId, b_kq);
}
//Ki?m tra ngày tháng
function ns_dt_danhgia_kdt_P_NGAY(str) {
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
function ns_dt_danhgia_kdt_tinh(b_event) {
    var b_hang = GridX_Fi_timHangA(b_grctId); 
    var b_ctr = form_Fctr_event(b_event);
    var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();    
    if (b_value != "") {
        if (b_cot == "RTOT") {
            GridX_datGtri(b_grctId, b_hang, ["tot"], [""], 'K');
            GridX_datGtri(b_grctId, b_hang, ["kha"], [''], 'K');
            GridX_datGtri(b_grctId, b_hang, ["trungbinh"], [''], 'K');
            GridX_datGtri(b_grctId, b_hang, ["kem"], [''], 'K');
        } else if (b_cot == "TOT") {
            GridX_datGtri(b_grctId, b_hang, ["rtot"], [""], 'K'); 
            GridX_datGtri(b_grctId, b_hang, ["kha"], [''], 'K');
            GridX_datGtri(b_grctId, b_hang, ["trungbinh"], [''], 'K');
            GridX_datGtri(b_grctId, b_hang, ["kem"], [''], 'K');
        } else if (b_cot == "KHA") {
            GridX_datGtri(b_grctId, b_hang, ["rtot"], [""], 'K');
            GridX_datGtri(b_grctId, b_hang, ["tot"], [""], 'K'); 
            GridX_datGtri(b_grctId, b_hang, ["trungbinh"], [''], 'K');
            GridX_datGtri(b_grctId, b_hang, ["kem"], [''], 'K');
        } else if (b_cot == "TRUNGBINH") {
            GridX_datGtri(b_grctId, b_hang, ["rtot"], [""], 'K');
            GridX_datGtri(b_grctId, b_hang, ["tot"], [""], 'K');
            GridX_datGtri(b_grctId, b_hang, ["kha"], [''], 'K'); 
            GridX_datGtri(b_grctId, b_hang, ["kem"], [''], 'K');
        } else if (b_cot == "KEM") {
            GridX_datGtri(b_grctId, b_hang, ["rtot"], [""], 'K');
            GridX_datGtri(b_grctId, b_hang, ["tot"], [""], 'K');
            GridX_datGtri(b_grctId, b_hang, ["kha"], [''], 'K');
            GridX_datGtri(b_grctId, b_hang, ["trungbinh"], [''], 'K'); 
        }
    } 
    return false;
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