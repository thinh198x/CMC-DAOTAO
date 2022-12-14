var b_lkeCho, b_choAct = 0, b_vungId, b_grlkeId, b_slideId, b_gocId,b_maac;
function ns_hoachdinh_KD() {
    b_vungId = form_Fs_VUNG_ID('UPa_ct'); b_grlkeId = form_Fs_VUNG_ID('GR_lke'); b_slideId = b_grlkeId + '_slide';
    b_gocId = form_Fs_TEN_ID(b_vungId, 'MA');
    b_hiencoId = form_Fs_TEN_ID(b_vungId, 'hienco');
    b_lkeCho = setInterval('ns_hoachdinh_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("MA_CDANH") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            var b_qly = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
            var b_loai = GridX_Fas_layGtri(b_grlkeId, b_hang, "loai");
            ns_hoachdinh_cdanh_NH(b_qly, a_tso[0], a_tso[1]);
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_hoachdinh_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
            case "MA_CT": b_maId = form_Fs_TEN_ID(b_vungId, 'ma_ct'); break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        var b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
        if (b_maTen == "MA") {
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); form_P_MOI(b_vungId, "X"); }
            else { GridX_datA(b_grlkeId, b_hang, null, "K"); slide_P_vtri(b_slideId, b_hang); ns_hoachdinh_P_CHUYEN_HANG(); }
            form_Fctr_TEN_DTUONG(b_vungId, 'TEN').focus();
        }
        else if (b_hang < 0) form_P_LOI_DICH("Mã quản lý chưa đăng ký");
    }
    catch (ex) { form_P_LOI(ex.message); }
}

function ns_hoachdinh_P_MOI() {
    form_P_MOI(b_vungId, "GXL"); GridX_thoiA(b_grlkeId); $get(b_gocId).focus();
}
function ns_hoachdinh_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI_DICH(b_loi);
        else {
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_hd.Fs_MA_PH_NH(form_Fs_nsd(), a_dt_ct, a_cot, ns_hoachdinh_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_hoachdinh_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_ma = $get(b_gocId).value;
        GridX_datBang(b_grlkeId, b_kq);
        var b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma);
        if (b_hang > 0) { slide_P_vtri(b_slideId, b_hang); GridX_datA(b_grlkeId, b_hang, null, "K"); }
        $get(b_gocId).focus();
    }
}
function ns_hoachdinh_P_XOA() {
    try {
        var b_ma = C_NVL(GridX_Fas_layGtriA(b_grlkeId, "ma"));
        if (b_ma == "") ns_hoachdinh_P_MOI();
        else sns_hd.Fs_MA_PH_XOA(form_Fs_nsd(), b_ma, ns_hoachdinh_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_hoachdinh_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        GridX_boChon(b_grlkeId);
        if (b_hang > 1 && GridX_Fb_hangTrang(b_grlkeId, b_hang)) b_hang--;
        slide_P_vtri(b_slideId, b_hang);
        GridX_datA(b_grlkeId, b_hang, null, "K"); ns_hoachdinh_P_CHUYEN_HANG();
    }
}
function ns_hoachdinh_GR_lke_RowChange() {
    if (b_choAct != 0) clearTimeout(b_choAct);
    b_choAct = setTimeout("ns_hoachdinh_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_hoachdinh_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1 || GridX_Fb_hangTrang(b_grlkeId, b_hang)) form_P_MOI(b_vungId, "GXL");
    else {
        form_P_GridX_TEXT(b_vungId, b_grlkeId);
        var a = $get(b_hiencoId).value;
        $get(b_hiencoId).value = "15";
    }
}
function ns_hoachdinh_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(b_lkeCho); GridX_taoScroll(b_grlkeId); ns_hoachdinh_P_LKE(); }
}
function ns_hoachdinh_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId);
        sns_hd.Fs_NS_HD_LKE(form_Fs_nsd(), a_cot, ns_hoachdinh_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}

function ns_hoachdinh_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_iurlphong = form_Fs_TM() + "/images/phong.png";
        var b_iurlcdanh = form_Fs_TM() + "/images/cdanh.png";
        var b_iurldvi = form_Fs_TM() + "/images/dvi.png";
        var b_hang = GridX_Fi_hangSo(b_grlkeId);
        var a_row = $get(b_grlkeId).rows;
        var a_kq = Fas_ChMang(b_kq, '#');
        GridX_datBang(b_grlkeId, a_kq[1]);
        for (var i = 1; i <= a_kq[0]; i++) {
            var b_loai = GridX_Fas_layGtri(b_grlkeId, i, "loai");
            var a_cell = a_row[i].cells;
            var a_ctr = a_cell[1].getElementsByTagName('input');
            var a_ct = a_ctr[0];
            if (b_loai == "CD") a_ct.src = b_iurlcdanh;
            if (b_loai == "PH") a_ct.src = b_iurlphong;
            if (b_loai == "DV") a_ct.src = b_iurldvi;
        }
        slide_P_SOTRANG(b_slideId);
        ns_hoachdinh_cdanh_AC();
    }
}

function ns_hoachdinh_cdanh_CHON() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("loi:Phải chọn phòng ban muốn thêm chức danh:loi"); return false; }
    else {
        var b_loai = GridX_Fas_layGtri(b_grlkeId, b_hang, "loai");
        if (b_loai == "CD") { form_P_LOI('loi:Phải chọn phòng cần thêm chức danh:loi'); return false; }
    }
    b_tf = form_Fs_TM('f') + "/ns/ma/ns_ma_cdanh.aspx";
    form_P_MO(b_tf, null, ["KQ", []]);
    return false;
}

function ns_hoachdinh_cdanh_NH(a_qly, a_ma, a_ten) {
    try {
        sns_hd.Fs_NS_HD_NH(form_Fs_nsd(), a_qly, a_ma, a_ten, ns_hoachdinh_cdanh_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_hoachdinh_cdanh_NH_KQ(b_kq) {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
        b_maac = b_ma;
        ns_hoachdinh_P_LKE();
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_hoachdinh_cdanh_AC()
{
    var b_hangac = GridX_Fi_timHangD(b_grlkeId, "ma", b_maac);
    if (b_hangac < 1) { GridX_thoiA(b_grlkeId); form_P_MOI(b_vungId, "X"); }
    else { GridX_datA(b_grlkeId, b_hangac, null, "K"); slide_P_vtri(b_slideId, b_hangac); }
}

function ns_hoachdinh_cdanh_XOA() {
    try {
        var b_ma = C_NVL(GridX_Fas_layGtriA(b_grlkeId, "ma"));
        var b_ma_ct = C_NVL(GridX_Fas_layGtriA(b_grlkeId, "ma_ct"));
        b_maac = b_ma_ct;
        if (b_ma == "") ns_hoachdinh_P_MOI();
        else sns_hd.Fs_NS_HD_XOA(form_Fs_nsd(), b_ma, ns_hoachdinh_cdanh_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}

function ns_hoachdinh_cdanh_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        GridX_boChon(b_grlkeId);
        if (b_hang > 1 && GridX_Fb_hangTrang(b_grlkeId, b_hang));
        ns_hoachdinh_cdanh_AC();
        return false;
    }
}