var ns_qt_debat_lkeCho, b_vungId, b_grlkeId, b_grspId, b_grdsId, b_gocId, b_ncdanhId, b_mt, b_gchuId, b_ncdId;
function ns_qt_debat_P_KD() {
    ns_qt_debat_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
    b_ncdId = form_Fs_TEN_ID(b_vungId, 'hincd');
    b_gocId = form_Fs_TEN_ID(b_vungId, 'NGAY_LAP'); b_slideId = b_grlkeId + '_slide'; 
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    ns_qt_debat_lkeCho = setInterval('ns_qt_debat_P_LKE_CHO()', 200);
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
       if (b_dtuong.indexOf("SO_THE") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang > -1) {
                GridX_datGtri(b_grctId, b_hang, "so_the", b_kq);
                GridX_datGtri(b_grctId, b_hang, "ten", a_tso[1]);
                GridX_datGtri(b_grctId, b_hang, "phong", a_tso[2]);
            }
       }
       else if (b_dtuong.indexOf("CVU") >= 0) {
           var b_hang = GridX_Fi_timHangA(b_grctId);
           if (b_hang > -1) {
               GridX_datGtri(b_grctId, b_hang, "cvu", b_kq);
               GridX_datGtri(b_grctId, b_hang, "ten_cvu", a_tso[1]);
               GridX_datGtri(b_grctId, b_hang, "hspc", a_tso[2]); 
           }
       }
       else if (b_dtuong.indexOf("TEN_CDANH") >= 0) {
           var b_hang = GridX_Fi_timHangA(b_grctId);
           if (b_hang > -1) {
               GridX_datGtri(b_grctId, b_hang, "cdanh", b_kq);
               GridX_datGtri(b_grctId, b_hang, "ten_cdanh", a_tso[1]);
           }
       }
       else if (b_dtuong.indexOf("BAC") >= 0) {
           var b_hang = GridX_Fi_timHangA(b_grctId);
           if (b_hang > -1) {
               GridX_datGtri(b_grctId, b_hang, "bac", b_kq);
               GridX_datGtri(b_grctId, b_hang, "hso", a_tso[1]);
           }
       }
       else if (b_dtuong.indexOf("NCD") >= 0) {
           var b_hang = GridX_Fi_timHangA(b_grctId);
           if (b_hang > -1) {
               GridX_datGtri(b_grctId, b_hang, "ncd", b_kq);
               GridX_datGtri(b_grctId, b_hang, "ten_ncd", a_tso[1]);
               $get(b_ncdId).value = b_kq;
           }
       } 
    }
    catch (err) { form_P_LOI(err); }
}

function ns_qt_debat_P_KTRA(b_maTen) {
    try {        
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) { 
            case "NGAY_LAP": b_maId = b_gocId; break;
        } 
        if (b_maTen == "NGAY_LAP") ns_qt_debat_GR_lke_RowChange();
    }
    catch (err) { form_P_LOI(err); }
}
function ns_qt_debat_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grctId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        b_mt = b_cot;
        if (b_value != "") {
            if (b_cot == "SO_THE") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Mã cán bộ", b_value, "ns_cb,so_the,ten", ns_qt_debat_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        if (b_value != "") GridX_ThemHang(b_grctId);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_qt_debat_P_MA_KTRA() {
    try {
        var b_ngay_lap = C_NVL($get(b_gocId).value);
        if (b_ngay_lap != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_qt.Fs_NS_QT_DEBAT_MA(b_ngay_lap, b_TrangKt, a_cot, ns_qt_debat_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_qt_debat_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        form_P_MOI(b_vungId, "X");
        $get(b_tienId).focus();
        GridX_datTrang(b_grctId); 
    }
    else { GridX_datA(b_grlkeId, b_hang); ns_qt_debat_P_CHUYEN_HANG(); }
}

function ns_qt_debat_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_mt == "SO_THE") {
        var b_hang = GridX_Fi_timHangA(b_grctId);
        GridX_datGtri(b_grctId, b_hang, "ten", b_kq); 
    }
}

var ns_qt_debat_choAct = 0;
function ns_qt_debat_GR_lke_RowChange() {
    if (ns_qt_debat_choAct != 0) clearTimeout(ns_qt_debat_choAct);
    ns_qt_debat_choAct = setTimeout("ns_qt_debat_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_qt_debat_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_qt_debat_lkeCho); ns_qt_debat_P_LKE(); }
}

function ns_qt_debat_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    return false;
}
function ns_qt_debat_P_LKE() {
    try {
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_qt.Fs_NS_QT_DEBAT_LKE(a_tso, a_cot, ns_qt_debat_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_qt_debat_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]); 
}
function ns_qt_debat_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_dt = form_Faa_TEXT_ROW(b_vungId),
                a_cot_ct = GridX_Fdt_cotGtri(b_grctId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
                a_tso = slide_Faobj_TUDEN(b_slideId);
                sns_qt.Fs_NS_QT_DEBAT_NH(b_TrangKt, a_tso, b_dt, a_cot_lke, a_cot_ct, ns_qt_debat_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_qt_debat_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[0]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[1]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
    }
    return false;
}
function ns_qt_debat_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_ngay_lap = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ngay_lap"));
    if (b_ngay_lap == null || b_ngay_lap == "") { form_P_MOI("", "XGL"); GridX_datTrang(b_grctId); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        $get(b_gocId).value = b_ngay_lap;
        sns_qt.Fs_NS_QT_DEBAT_CT(b_ngay_lap, a_cot_ct, ns_qt_debat_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function ns_qt_debat_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[0]);
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
}
function ns_qt_debat_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") ns_qt_debat_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_qt.Fs_NS_QT_DEBAT_XOA(a_tso, a_cot, b_so_id, ns_qt_debat_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_qt_debat_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_qt_debat_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_qt_debat_P_CHUYEN_HANG(); }
        ns_qt_debat_P_MOI();
    }
}
function ns_qt_debat_HangLen() {
    GridX_chuyenHang(b_grdsId, -1);
    return false;
}
function ns_qt_debat_HangXuong() {
    GridX_chuyenHang(b_grdsId, 1);
    return false;
}
function ns_qt_debat_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grdsId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grdsId);
    return false;
}
function ns_qt_debat_CatDong() {
    GridX_boChon(b_grdsId, 'C');
    return false;
}

function ns_qt_debat_phong() {
    try {
        var b_tenf = form_Fs_TM() + '/App_form/ht/ht_maph.aspx';
        form_P_MO(b_tenf, null, ["ns_qt_debat", [""]]);
        return false;
    }
    catch (err) { }
}
function p_hamten()
{
    form_P_LOI('loi:o day:loi');
}

function form_dong() {
    location.reload(false);
}