var ns_tl_vipham_lkeCho, b_vungId, b_gchuId, ns_tl_vipham_choAct = 0, b_grlkeId, b_slideId, b_vungtkId, b_so_theId, b_so_idId, b_cho_control = 0,
    b_so_theId, b_tenId, b_cdanhId,b_sothe_tkId, b_phongId, b_goc, b_loai_vpId, b_lan_vpId, b_tienId, b_akyluongId, b_ctrbeforId, b_ctyValue, b_aphongId, b_co_tinhluongId, b_namTKId, b_kyluongTKId, b_namId, b_kyluongId, b_so_the_tkId, b_ten_tkId;
function ns_tl_vipham_P_KD() {
    ns_tl_vipham_lkeCho = setInterval('ns_tl_vipham_P_LKE_CHO()', 200);
}
function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_so_theId).value = b_so_the;
            $get(b_gchuId).innerHTML = b_ten;
            $get(b_so_theId).focus();
            ns_tl_vipham_P_LKE('K');
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
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            $get(b_so_theId).value = b_kq;    
            ns_tl_vipham_P_CB();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_vipham_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_t = b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_so_theId; form_P_MOI("", "XGL"); break;
            case "NAM_TK": b_maId = b_namTKId; form_P_MOI("", "T"); break;
            case "KYLUONG_TK": b_maId = b_kyluongTKId;break;
        }
        b_chonId = b_maTen;
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_tl_vipham_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_tl_vipham_P_CB();
            return;
        } else if (b_maTen == "NAM_TK") { 
            $get(b_akyluongId).value = lke_Fs_TRA($get(b_kyluongTKId));
            var b_nam = form_Fs_TEN_GTRI(b_vungtkId, 'NAM_TK'); form_P_MOI("", "N");
            hts_dungchung.Fs_NS_KT_NAM_TK(window.name, b_nam);
        } else if (b_maTen == "KYLUONG_TK") {
            $get(b_akyluongId).value = lke_Fs_TRA($get(b_kyluongTKId)); 
        } 
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_vipham_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
    }
    else { form_P_DatGchu(b_gchuId, b_kq); }
}
function ns_tl_vipham_P_MOI() {
    form_P_MOI(b_vungId, "GXLK");
    $get(b_kyluongId).value = "";
    $get(b_namId).value = "";
    GridX_thoiA(b_grlkeId);
    $get(b_so_theId).focus();
    return false;
}
function ns_tl_vipham_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }

        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")); 
        var b_kyluong = form_Fs_TEN_GTRI(b_vungtkId, 'KYLUONG_TK');
        var b_phong = b_ctyValue;
        stl_ch.Fs_NS_TL_VIPHAM_NH(form_Fs_nsd(), b_so_id,b_phong, "",b_kyluong, b_TrangKt, a_dt_ct, a_cot_lke, ns_tl_vipham_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { throw (err); }
}
function ns_tl_vipham_P_NH_KQ(b_kq) {
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
function ns_tl_vipham_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1) { form_P_LOI("loi:Bản phải chọn bản ghi để xóa:loi"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") { form_P_LOI("loi:Bản phải chọn bản ghi để xóa:loi"); ns_tl_vipham_P_MOI(); return false; }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);        
        var b_kyluong = form_Fs_TEN_GTRI(b_vungtkId, 'KYLUONG_TK');
        var b_phong = b_ctyValue;
        stl_ch.Fs_NS_TL_VIPHAM_XOA(form_Fs_nsd(), b_so_id, b_phong,"", b_kyluong, a_tso, a_cot, ns_tl_vipham_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_tl_vipham_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_tl_vipham_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_tl_vipham_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
    return false;
}
//Chuy?n hàng
function ns_tl_vipham_GR_lke_RowChange() {
    if (ns_tl_vipham_choAct != 0) clearTimeout(ns_tl_vipham_choAct);
    ns_tl_vipham_choAct = setTimeout("ns_tl_vipham_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_tl_vipham_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;

    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "0" || b_so_id == "") { form_P_MOI(b_vungId, "XGL"); }
    else stl_ch.Fs_NS_TL_VIPHAM_CT(form_Fs_nsd(), b_so_id, ns_tl_vipham_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function ns_tl_vipham_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
//Li?t kê
function ns_tl_vipham_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ns_tl_vipham_lkeCho != 0) clearTimeout(ns_tl_vipham_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'),
        b_grlkeId = form_Fs_VUNG_ID('GR_lke'), 
        b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
        b_vungtkId = form_Fs_VUNG_ID('UPa_tk'),
        b_so_theId = form_Fs_TEN_ID(b_vungId, 'so_the'), b_tenId = form_Fs_TEN_ID(b_vungId, 'ten'), b_cdanhId = form_Fs_TEN_ID(b_vungId, 'cdanh'), b_phongId = form_Fs_TEN_ID(b_vungId, 'phong'),
        b_loai_vpId = form_Fs_TEN_ID(b_vungId, 'loai_vp'), b_lan_vpId = form_Fs_TEN_ID(b_vungId, 'lan_vp'),
        b_tienId = form_Fs_TEN_ID(b_vungId, 'tien'), b_co_tinhluongId = form_Fs_TEN_ID(b_vungId, 'co_tinhluong'),
        b_kyluongTKId = form_Fs_TEN_ID(b_vungtkId, 'KYLUONG_TK'),
        b_namTKId = form_Fs_TEN_ID(b_vungtkId, 'nam_tk'), b_aphongId = form_Fs_TEN_ID('UPa_hi', 'aphong'),
        b_akyluongId = form_Fs_TEN_ID('UPa_hi', 'akyluong'),
        b_namId = form_Fs_TEN_ID(b_vungId, 'nam'), b_kyluongId = form_Fs_TEN_ID(b_vungId, 'kyluong'); 
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        b_sothe_tkId = form_Fs_TEN_ID(b_vungtkId, 'so_the_tk');
        form_F_GOC().P_MENUBf(window.name, 'M');
        vb_cctc_P_SL('', 'D', '0', ' ', ' ', 'T');
        b_ctyValue = "TATCA";
        ns_tl_vipham_P_LKE('K');
        //ns_tl_vipham_CT_KYLUONG('K');
    }
}
function ns_tl_vipham_CT_KYLUONG() {
    try {
        var b_form = "ns_tl_vipham", b_nam = "DT_NAM_TK", b_thang = "DT_KYLUONG_TK";        
        hts_dungchung.Fs_NS_CC_KY(form_Fs_nsd(), b_form, b_nam, b_thang, ns_tl_vipham_CT_KYLUONG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_vipham_CT_KYLUONG_KQ(b_kq) {
    if (b_kq != "") {
        form_P_CH_TEXT(b_vungtkId, b_kq);
    }
    ns_tl_vipham_P_LKE('K');
}
function ns_tl_vipham_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId); 
        var b_kyluong = form_Fs_TEN_GTRI(b_vungtkId, 'KYLUONG_TK');
        var b_phong = b_ctyValue; var b_sothe = $get(b_sothe_tkId).value; var b_nam = form_Fs_TEN_GTRI(b_vungtkId, 'NAM_TK');
        stl_ch.Fs_NS_TL_VIPHAM_LKE(form_Fs_nsd(), b_phong,b_nam, b_kyluong,b_sothe, a_tso, a_cot, ns_tl_vipham_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_tl_vipham_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_tl_vipham_P_CB() {
    try {
        var b_so_the = $get(b_so_theId).value;
        hts_dungchung.Fs_THONGTIN_CANBO_TEN(b_so_the, ns_tl_vipham_P_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_vipham_P_NAM() {
    try {
        var b_nam = form_Fs_TEN_GTRI(b_vungId, 'NAM');
        hts_dungchung.Fs_NS_KT_NAM(window.name, b_nam);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_tl_vipham_P_CB_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq); 
    return false;
}
//Ki?m tra ngày tháng
function ns_tl_vipham_P_NGAY(str) {
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
        if (b_ctyValue != "") ns_tl_vipham_P_LKE('K');
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