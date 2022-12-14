var ns_kynang_cn_lkeCho, b_vungId, b_grlkeId, b_slideId, b_so_theId, b_so_idId, ns_kynang_cn_choAct = 0, b_ngaynId, b_ngayd;
function ns_kynang_cn_P_KD() {
    ns_kynang_cn_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grctId = form_Fs_VUNG_ID('GR_ct');
    b_slideId = b_grlkeId + '_slide';
    b_so_theId = form_Fs_TEN_ID(b_vungId, 'SO_THE');
    b_ngaynId = form_Fs_TEN_ID(b_vungId, 'ngayd');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_ngayd = form_Fs_TEN_ID(b_vungId, 'ngayd');
}
var b_cho_control = 0;
function P_cho(b_so_the, b_ten) {
    try {

        if (b_doi == 0) {
            $get(b_so_theId).value = b_so_the;
            $get(b_gchuId).innerHTML = b_ten;
            $get(b_so_theId).focus();
            ns_kynang_cn_P_CHUYEN_HANG();
            b_doi = 1;
            clearTimeout(b_cho_control);
        }
    }
    catch (err) {
        b_doi = 0;
    }
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        b_doi = 0;
        if (b_dtuong.indexOf("SO_THE") >= 0 || b_dtuong.indexOf("THAMSO") >= 0) {
            $get(b_so_theId).setAttribute("disabled", "disabled");
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "')", 200);
        }
        else if (b_dtuong.indexOf("MA") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang > -1) {
                GridX_datGtri(b_grctId, b_hang, "ma", b_kq);
                GridX_datGtri(b_grctId, b_hang, "ten", a_tso[1]);
                GridX_datA(b_grctId, b_hang, "kinhnghiem");
            }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_kynang_cn_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_mt = b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_so_theId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        else if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), "Mã cán bộ", b_ma.value, "ns_cb,so_the,ten", ns_kynang_cn_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_kynang_cn_P_CHUYEN_HANG();
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_kynang_cn_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grctId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        b_mt = b_cot;
        if (b_value != "") {
            if (b_cot == "MA") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Mã kỹ năng cá nhân", b_value, "ns_ma_kynang,ma,ten", ns_kynang_cn_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
                b_ctr.value = "";
            }
        }
        if (b_value != "") GridX_ThemHang(b_grctId);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_kynang_cn_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_mt == "MA") {
        var b_hang = GridX_Fi_timHangA(b_grctId);
        GridX_datGtri(b_grctId, b_hang, "ten", b_kq);
        GridX_datA(b_grctId, b_hang, "kinhnghiem");
    }
    if (b_mt == "SO_THE") {
        $get(b_gchuId).innerHTML = b_kq;
    }
}

function ns_kynang_cn_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_datTrang(b_grctId);
    $get(b_so_theId).focus();
    return false;
}
function ns_kynang_cn_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") {
            form_P_LOI(b_loi);
            return false;
        }
        var ktra = sosanh_withDateTimeNow($get(b_ngayd).value);
        if (ktra > 0) {
            form_P_LOI('loi:Ngày nhập không được hơn ngày hiện tại:loi');
            return false;
        }
        else {
            var b_ngayn = $get(b_ngaynId).value;

            var b_dt = form_Faa_TEXT_ROW(b_vungId),
                a_cot_ct = GridX_Fdt_cotGtri(b_grctId);
            sns_tt.Fs_NS_KYNANG_CN_NH(b_dt, a_cot_ct, ns_kynang_cn_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_kynang_cn_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        form_P_LOI('loi:Nhập thành công:loi');
        ns_kynang_cn_P_CHUYEN_HANG();
        $get(b_so_theId).focus();
    }
    return false;
}

function ns_kynang_cn_P_CHUYEN_HANG() {
    var b_so_the = $get(b_so_theId).value;
    if (b_so_the == null || b_so_the == "") { return false }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        sns_tt.Fs_NS_KYNANG_CN_CT(b_so_the, a_cot_ct, ns_kynang_cn_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function ns_kynang_cn_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]); slide_P_SOTRANG(b_grctId + "_slide");
    return false;
}

function ns_kynang_cn_P_XOA() {
    var b_so_the = $get(b_so_theId).value;
    if (b_so_the == null || b_so_the == "") ns_kynang_cn_P_MOI();
    else {
        var b_so_the = $get(b_so_theId).value;
        sns_tt.Fs_NS_KYNANG_CN_XOA(b_so_the, ns_kynang_cn_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_kynang_cn_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        ns_kynang_cn_P_CHUYEN_HANG();
        form_P_LOI('loi:Xóa thành công:loi');
        return false;
    }
}

function ns_kynang_cn_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_kynang_cn_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_kynang_cn_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function ns_kynang_cn_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}
function sosanh_withDateTimeNow(str) {
    var mdy_str = str.split('/');
    var mdy_str = mdy_str[2] + mdy_str[1] + mdy_str[0];
    var mdy_str = parseInt(mdy_str);
    var dateht = new Date();
    var m = "0" + (1 + dateht.getMonth());
    var y = parseInt("2" + dateht.getYear()) - 100;
    var d = "0" + dateht.getDate();
    var dmy = y + m + d;
    var dmy = parseInt(dmy);
    var kq = mdy_str - dmy;
    return kq;
}