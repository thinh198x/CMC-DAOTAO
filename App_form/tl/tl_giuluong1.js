var tl_giuluong_lkeCho, b_vungId, b_vungtk, b_cho_control = 0, b_grlkeId, b_slideId, b_ten_nv_tk, b_kyluong_tk, b_gocId, b_tongtienId, b_phong_tk, b_ten_nv_nv, b_namId,
    b_kyluongId, b_timId, b_aphongId, b_tienluongId, b_akyluongId, b_tiengiuId, b_ctrbeforId, b_ctyValue, tl_giuluong_choAct = 0, b_vungHi, b_so_idId;
function tl_giuluong_P_KD() { 
    tl_giuluong_lkeCho = setInterval('tl_giuluong_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        var b_hso = a_tso[1];
        b_doi = 0;
        if (b_dtuong.indexOf("SO_THE") >= 0 || b_dtuong.indexOf("THAMSO") >= 0) {
            $get(b_gocId).value = b_kq;
            tl_giuluong_P_CB();
        } else if (b_dtuong.indexOf("LOAI_BD") >= 0) {
            $get(b_loaibd).value = b_kq;
            $get(b_gchuId).innerhtml = b_hso;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function P_cho(b_so_the, b_ten, b_phong, b_chucdanh) {
    try {
        if (b_doi == 0) {
            $get(b_gocId).value = b_so_the;
            $get(b_tenNV).value = b_ten;
            $get(b_phongban).value = b_phong;
            $get(b_cdanh).value = b_chucdanh;
            tl_giuluong_load_luong();
            $get(b_gocId).focus(); 
            tl_giuluong_P_LKE();
            b_doi = 1;
            clearTimeout(b_cho_control);
        }
    }
    catch (err) {
        b_doi = 0;
    }
}
function tl_giuluong_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; break;
            case "NAM": b_maId = b_namId; form_P_MOI("", "T"); break; 
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "SO_THE") {
            tl_giuluong_P_CB();
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_biendong_bh_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            var b_ten_nv = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
            b_hang = GridX_Fi_timHangD(b_grlkeId, "SO_THE", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); tl_giuluong_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); tl_giuluong_P_CHUYEN_HANG(); }
        } else if (b_maTen == "NAM") {
            var b_nam = form_Fs_TEN_GTRI(b_vungId, 'NAM'); form_P_MOI("", "N");
            hts_dungchung.Fs_NS_KT_NAM(window.name, b_nam);
            $get(b_aphongId).value = lke_Fs_TRA($get(b_phong_tk));
            $get(b_akyluongId).value = lke_Fs_TRA($get(b_kyluong_tk));
        } else if (b_maTen == "KYLUONG") {
            $get(b_aphongId).value = lke_Fs_TRA($get(b_phong_tk));
            $get(b_akyluongId).value = lke_Fs_TRA($get(b_kyluong_tk));
        }
    }
    catch (err) { form_P_LOI(err); }
}
function tl_giuluong_P_MOI() {
    form_P_MOI(b_vungId, "GXNM");
    $get(b_so_idId).value = "0";
    $get(b_gocId).focus();
    GridX_thoiA(b_grlkeId);
    return false;
}
function tl_giuluong_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            var a_phong = b_ctyValue, a_kyluong = lke_Fs_TRA($get(b_kyluong_tk));
            stl_ch.Fs_NS_TL_GIULUONG_MA(form_Fs_nsd(), b_ma, a_phong, a_kyluong,b_TrangKt, a_cot, tl_giuluong_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function tl_giuluong_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); tl_giuluong_P_CHUYEN_HANG(); }
} 
function tl_giuluong_GR_lke_RowChange() {
    if (tl_giuluong_choAct != 0) clearTimeout(tl_giuluong_choAct);
    tl_giuluong_choAct = setTimeout("tl_giuluong_P_CHUYEN_HANG()", 300);
    return false;
}
function tl_giuluong_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "") form_P_MOI(b_vungId, "XGLMN");
    else stl_ch.Fs_NS_TL_GIULUONG_CT(form_Fs_nsd(), window.name, b_so_id, tl_giuluong_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = b_so_id;
}
function tl_giuluong_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
function tl_giuluong_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtk = form_Fs_VUNG_ID('UPa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_vungHi = form_Fs_VUNG_ID('UPa_hi'),
        b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE'), b_phong_tk = form_Fs_TEN_ID(b_vungtk, 'phong_tk'), b_ten_nv_tk = form_Fs_TEN_ID(b_vungtk, 'ten_tk'), b_kyluong_tk = form_Fs_TEN_ID(b_vungtk, 'kyluong_tk'),
        b_tenNV = form_Fs_TEN_ID(b_vungId, 'HO_TEN'), b_cdanh = form_Fs_TEN_ID(b_vungId, 'TEN_CDANH'), b_phongban = form_Fs_TEN_ID(b_vungId, 'TEN_PHONG'),
        b_tongtienId = form_Fs_TEN_ID(b_vungId, 'tong_tien'), b_kyluongId = form_Fs_TEN_ID(b_vungId, 'KYLUONG'); b_namId = form_Fs_TEN_ID(b_vungId, 'NAM');
        b_tienluongId = form_Fs_TEN_ID(b_vungId, 'tien_luong'); b_so_idId = form_Fs_TEN_ID(b_vungHi, 'so_id');
        b_tiengiuId = form_Fs_TEN_ID(b_vungId, 'tien_giu');
        b_namId = form_Fs_TEN_ID(b_vungId, 'NAM'); b_aphongId = form_Fs_TEN_ID('UPa_hi', 'aphong'),
        b_akyluongId = form_Fs_TEN_ID('UPa_hi', 'akyluong');
        lke_P_DAT($get(b_phong_tk), 'TATCA' + '{' + 'Tất cả');
        if (tl_giuluong_lkeCho != 0) clearTimeout(tl_giuluong_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        form_F_GOC().P_MENUBf(window.name, 'M');
        vb_cctc_P_SL('', 'D', '0', ' ', ' ', 'T');
        b_ctyValue = "TATCA";
        tl_giuluong_CT_KYLUONG();
    }
}
function tl_giuluong_CT_KYLUONG() {
    try {
        var b_form = "tl_giuluong", b_nam = "DT_NAM", b_thang = "DT_KYLUONG_TK";
        hts_dungchung.Fs_NS_CC_KY(form_Fs_nsd(), b_form, b_nam, b_thang, tl_giuluong_CT_KYLUONG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function tl_giuluong_CT_KYLUONG_KQ(b_kq) {
    if (b_kq != "") {
        form_P_CH_TEXT(b_vungtk, b_kq);
    }
    tl_giuluong_P_LKE();
}
function tl_giuluong_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var a_phong  = b_ctyValue, a_ten = $get(b_ten_nv_tk).value, a_kyluong = lke_Fs_TRA($get(b_kyluong_tk));
        stl_ch.Fs_NS_TL_GIULUONG_LKE(form_Fs_nsd(), a_phong, a_ten, a_kyluong, a_tso, a_cot, tl_giuluong_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function tl_giuluong_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function tl_giuluong_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    var b_hang = GridX_Fi_timHangA(b_grlkeId), b_so_id = '0';
    if (b_hang > 0) b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    var a_phong = b_ctyValue, a_kyluong = lke_Fs_TRA($get(b_kyluong_tk));

    var tienluong = CSO_SO($get(b_tienluongId).value),tien_giu = CSO_SO($get(b_tiengiuId).value);
    if (tienluong < tien_giu) { form_P_LOI("loi:Số tiền lương không được nhỏ hơn tiền giữ:loi"); return false; }
    stl_ch.Fs_NS_TL_GIULUONG_NH(form_Fs_nsd(), b_so_id, a_phong, a_kyluong,b_TrangKt, a_dt_ct, a_cot, tl_giuluong_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function tl_giuluong_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);                
        form_P_LOI('loi:Nhập thành công!:loi');
        $get(b_gocId).focus();
    }
    return false;
}
function tl_giuluong_P_XOA() { 
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var a_so_the = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (a_so_the == "") { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); tl_giuluong_P_MOI(); return false; }
    else {
        var a_phong = b_ctyValue, a_ten = $get(b_ten_nv_tk).value, a_kyluong =lke_Fs_TRA($get(b_kyluong_tk));
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_ch.Fs_NS_TL_GIULUONG_XOA(form_Fs_nsd(), a_so_the, a_phong, a_ten, a_kyluong, a_tso, a_cot, tl_giuluong_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function tl_giuluong_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) tl_giuluong_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); tl_giuluong_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
        return false;
    }
}
function tl_giuluong_load_luong() {
    try {
        var a_so_the = C_NVL($get(b_gocId).value), a_kyluong = lke_Fs_TRA($get(b_kyluongId));
        if (a_so_the != "") {
            stl_ch.Fs_GET_LUONG_BY_SOTHE(form_Fs_nsd(), a_so_the, a_kyluong, tl_giuluong_load_luong_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function tl_giuluong_load_luong_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    $get(b_tienluongId).value = b_kq;
    $get(b_tiengiuId).value = b_kq;
    return false;
}
 
function tl_giuluong_P_NAM() {
    try {
        var b_nam = form_Fs_TEN_GTRI(b_vungtk, 'NAM_TK');
        hts_dungchung.Fs_NS_KT_NAM_TK(window.name, b_nam);
    }
    catch (ex) { form_P_LOI(ex.message); }
} 
function tl_giuluong_P_CB() {
    try {
        var b_so_the = $get(b_gocId).value;
        hts_dungchung.Fs_THONGTIN_CANBO(b_so_the, tl_giuluong_P_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function tl_giuluong_P_CB_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);    
    $get(b_tongtienId).value = b_kq;
    return false;
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
        if (b_ctyValue != "") tl_giuluong_P_LKE();
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