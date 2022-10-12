var b_tmf, ns_cb_chon_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_ten_cdanhId, b_ten_nnnId, b_cdanhId, b_ncdanhId,
    b_bcdanhId, b_ten_levelcdanhId, b_ten_dviId, b_ma_dvi, b_choAct_fi = 0, b_check, b_iurlId, b_dchiId, b_nc_cmtId,
    b_nhaId, b_nha_dchiId, b_nhomId, b_ngaydId, b_iurl, b_mt, b_klkId, b_phongban_Id, b_mastId, b_nhanId, b_tenId, b_sotkId, b_banId,
    b_tenhoaId, b_nsinhId, b_gchuId, b_so_idId, b_tenphongId, b_tt_noisinh, b_qh_noisinhId, b_xp_noisinh, b_tt_thuongtru, b_qh_thuongtru, b_la_cty_chinhId,
    b_xp_thuongtru, b_ql_tt, b_trangthaiId, b_grctnl, b_so_the_tkId, b_ten_tkId, b_cho_control = 0, b_save = 0, ns_cb_chon_chuyenhang_cho = 0, ns_cb_chon_choAct = 0;
function ns_cb_chon_P_KD(b_tm, iurl_id, ma_dvi) {
    b_ma_dvi = ma_dvi;
    b_tmf = b_tm, ns_cb_chon_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_vungtkId = form_Fs_VUNG_ID('Upa_tk'),
        b_phong_tkId = form_Fs_TEN_ID(b_vungtkId, 'phong_tk');
    b_so_the_tkId = form_Fs_TEN_ID(b_vungtkId, 'so_the_tk');
    b_ten_tkId = form_Fs_TEN_ID(b_vungtkId, 'ten_tk');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'),
        b_psId = form_Fs_VTEN_ID('UPa_hi', 'ps'), b_nvId = form_Fs_VTEN_ID('UPa_hi', 'nv');
    b_slideId = $get(b_grlkeId).getAttribute('slideId');
    b_no_anhId = form_Fs_TM() + "/images/no_image.png";
    b_loading_anhId = form_Fs_TM() + "/images/" + "loading_image.gif";
    b_iurlId = document.getElementById(iurl_id);
    lke_P_DAT($get(b_phong_tkId), 'TATCA' + '{' + 'Tất cả');
    ns_cb_chon_lkeCho = setInterval('ns_cb_chon_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (typeof (b_dtuong) == "undefined") {
            return false;
        }
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        b_doi = 0;
        if (b_dtuong.indexOf("CT") >= 0) {
            b_cho_control = setInterval("P_cho2('" + a_tso[0] + "')", 200);
        }
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_cb_chon_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_mt = b_maTen = b_maTen.toUpperCase();

        switch (b_maTen) {
            case "PHONG_TK": b_maId = b_phong_tkId; break;
            case "SO_THE": b_maId = b_gocId; break;
            case "TEN": b_maId = b_tenId; break;
            case "NC_CMT": b_maId = b_nc_cmtId; break;
            case "NHAN": b_maId = b_nhanId; break;
            case "NHA": b_maId = b_nhaId; break;
            case "NHOM": b_maId = b_nhomId; break;
            case "SO_THE_GT": b_maId = b_so_the_gtId; break;
            case "NCD": b_maId = b_ncdId; break;
            case "CDANH": b_maId = b_cdanhId; break;
            case "BCD": b_maId = b_bcdId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "PHONG_TK") {
            $get(b_tenphongId).value = document.getElementById(b_phongban_Id)[document.getElementById(b_phongban_Id).selectedIndex].innerText;
            ns_cb_chon_P_MOI(); ns_cb_chon_P_LKE();
        }
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_cb_chon_P_MA_KTRA() {
    try {
        clearTimeout(ns_cb_chon_chuyenhang_cho);
        var b_so_the = C_NVL($get(b_gocId).value);
        if (b_so_the != "") {
            var b_lke = ($get(b_klkId).innerHTML == "Hoạt động") ? "0" : "1";
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_phong = $get(b_phong_tkId).value;
            sns_tt.Fs_NS_CB_MA(b_phong, b_so_the, b_lke, b_TrangKt, a_cot, ns_cb_chon_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_cb_chon_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq); return;
    }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        form_P_MOI(b_vungId, "X");
        b_iurlId.src = b_no_anhId;
        khud_ttt_P_LKE();
    }
    else {
        GridX_datA(b_grlkeId, b_hang); ns_cb_chon_P_CHUYEN_HANG();
    }
    return false;
}
function ns_cb_chon_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    khud_ttt_P_MOI();
    GridX_thoiA(b_grlkeId);
    b_iurlId.src = b_no_anhId;
    $get(b_so_idId).value = "0";
    $get(b_gocId).focus(); $get(b_la_cty_chinhId).value = "X";
    var b_drop = form_Fctr_TEN_DTUONG(b_vungId, 'dt_cutru');
    list_P_DAT(b_drop, 'CT');
    return false;
}

function ns_cb_chon_GR_lke_RowChange() {
    if (ns_cb_chon_choAct != 0) clearTimeout(ns_cb_chon_choAct);
    ns_cb_chon_choAct = setTimeout("ns_cb_chon_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_cb_chon_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    b_iurlId.src = b_loading_anhId;
    var b_so_the = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the"));
    b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    form_P_MOI(b_vungId, "XGL");
    if (b_so_the == "") form_P_MOI(b_vungId, "XGL");
    else sns_tt.Fs_NS_CB_CHON_CT(b_so_the, ns_cb_chon_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    khud_trdoi_FI_CHUYEN();
    $get(b_so_idId).value = b_so_id;
    return false;
}
function ns_cb_chon_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq); return;
    }
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    khud_ttt_P_LKE(a_kq[2]);
    if (b_save == 1) {
        var b_tenf = '/App_form/ns/qt/ns_hd.aspx';
        var b_so_the = $get(b_gocId).value, b_ten = $get(b_tenId).value;
        var b_phong = lke_Fs_TRA($get(b_phongban_Id));
        if (b_phong == "" || b_phong == null) b_phong = lke_Fs_TRA($get(b_banId));
        form_P_MO(b_tenf, window.name, ["THAMSO_CB", [b_so_the, b_ten, b_phong, "NS_HD", "Quản lý hợp đồng"]], null);
        form_P_LOI('');
    }
    b_save = 0;
    return false;
}
function ns_cb_chon_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) {
        clearTimeout(ns_cb_chon_lkeCho); ns_cb_chon_P_LKE();
    }
}
function ns_cb_chon_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId), b_phong = form_Fs_TEN_GTRI(b_vungtkId, 'phong_tk'),
            b_trangthai = form_Fs_TEN_GTRI(b_vungtkId, 'trangthai_tk'), b_so_the = $get(b_so_the_tkId).value, b_ten = $get(b_ten_tkId).value;
        sns_tt.Fs_NS_CB_CHON_LKE(b_phong, b_trangthai, b_so_the, b_ten, a_tso, a_cot, ns_cb_chon_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_cb_chon_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq); return;
    }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    return false;
}
function ns_cb_chon_P_NPA(b_nv) {
    if (b_nv != "ch") {
        $get(b_ns_khId).style.display = "none";
        $get(b_ns_chId).style.display = "inline";
    }
    else {
        $get(b_td_khId).style.display = "inline";
        $get(b_td_chId).style.display = "none";
    }
}

function form_P_TRA_CHON_GRID(b_ten) {
    try {

        var b_grid = $get(b_grlkeId);
        var b_tbo = b_grid.getElementsByTagName('tbody')[0];
        var b_c = b_tbo.rows.length - 1;
        var b_chon = '';
        var b_kq = [], a_kq = [];
        b_kq[0] = "CMC-1M";
        var f = 1;
        b_r = b_tbo.rows[1].cloneNode(true);
        for (var i = b_c; i > 0; i--) {
            b_chon = GridX_Fb_hangChon(b_grlkeId, i);
            if (b_chon == true) {
                b_kq[f] = form_P_TRA_GTRI_GRID(b_ten, i);
                f++;
            }
        }
        var b_l = b_kq.length;
        if (b_l == 2) {
            a_kq = b_kq[1];
            form_P_DONG("ns_cb_chon", a_kq);
        }
        else {
            b_kq[0] = "CMC-2M";
            form_P_DONG("ns_cb_chon", b_kq);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
// Tra mang gia tri theo ten
function form_P_TRA_GTRI_GRID(b_ten, b_hang) {
    try {
        var a_ten = b_ten.split(','), a_kq = [];
        for (var i = 0; i < a_ten.length; i++) {
            var a_grid = a_ten[i].split(':');
            var b_gridId = form_Fs_VUNG_ID(a_grid[0]);
            a_kq[i] = GridX_Fas_layGtri(b_gridId, b_hang, a_grid[1]);
        }
        return a_kq;
    }
    catch (err) { return null; }
}

function P_cho(b_so_the) {
    try {
        if (b_doi == 0) {
            sns_tt.Fs_NS_CB_HOI(b_so_the, Fs_NS_CB_HOI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            $get(b_klkId).innerHTML = "Thôi việc";
            $get(b_gocId).value = b_so_the;
            $get(b_gocId).focus();
            b_doi = 1;
            clearTimeout(b_cho_control);
        }
    }
    catch (err) {
        b_doi = 0;
    }
}
function P_cho2(b_so_the) {
    try {
        if (b_doi == 0) {
            sns_tt.Fs_NS_CB_HOI(b_so_the, Fs_NS_CB_HOI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            $get(b_gocId).value = b_so_the;
            $get(b_gocId).focus();
            b_doi = 1;
            clearTimeout(b_cho_control);
        }
    }
    catch (err) {
        b_doi = 0;
    }
    return false;
}
function form_dong() {
    form_P_DONG("ns_cb_chon");
}
