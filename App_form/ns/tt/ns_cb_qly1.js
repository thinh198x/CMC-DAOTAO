var b_tmf, ns_cb_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_ma_dvi, b_choAct_fi = 0, b_check,
b_iurlId, b_dchiId, b_nc_cmtId, b_nhaId, b_nha_dchiId, b_nhomId, b_ngaydId, b_iurl, b_mt, b_klkId,
b_phongId, b_mastId, b_nhanId, b_tenId, b_sotkId, b_tenhoaId, b_nsinhId, b_gchuId, b_so_idId, b_tenphongId,
b_tt_hientai, b_qh_hientai, b_xp_hientai, b_tt_thuongtru, b_qh_thuongtru, b_xp_thuongtru, b_ql_tt, b_trangthaiId, b_grctnl;
function ns_cb_P_KD(b_tm, iurl_id, ma_dvi) {
    b_ma_dvi = ma_dvi;
    b_tmf = b_tm, ns_cb_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_vungtkId = form_Fs_VUNG_ID('Upa_tk'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE');
    b_nc_cmtId = form_Fs_TEN_ID(b_vungId, 'nc_cmt'), b_grctnl = form_Fs_VUNG_ID('GR_ct'),
    b_nhaId = form_Fs_TEN_ID(b_vungId, 'nha'), b_nha_dchiId = form_Fs_TEN_ID(b_vungId, 'nha_dchi'),
    b_nhomId = form_Fs_TEN_ID(b_vungId, 'nhom'), b_ngaydId = form_Fs_TEN_ID(b_vungId, 'ngayd'), b_phongId = form_Fs_TEN_ID(b_vungId, 'PHONG'),
    b_mastId = form_Fs_TEN_ID(b_vungId, 'mast'), b_nhanId = form_Fs_TEN_ID(b_vungId, 'nhan'),
    b_tenId = form_Fs_TEN_ID(b_vungId, 'TEN'), b_sotkId = form_Fs_TEN_ID(b_vungId, 'sotk'), b_tenhoaId = form_Fs_TEN_ID(b_vungId, 'TEN_HOA'),
    b_bcdId = form_Fs_TEN_ID(b_vungId, 'bac_cdanh'), b_cdanhId = form_Fs_TEN_ID(b_vungId, 'cdanh'), b_ncdId = form_Fs_TEN_ID(b_vungId, 'nhom_cd'),
    b_tt_hientai = form_Fs_TEN_ID(b_vungId, 'tt_hientai'), b_qh_hientai = form_Fs_TEN_ID(b_vungId, 'qh_hientai'), b_xp_hientai = form_Fs_TEN_ID(b_vungId, 'xp_hientai'),
    b_tt_thuongtru = form_Fs_TEN_ID(b_vungId, 'tt_thuongtru'), b_qh_thuongtru = form_Fs_TEN_ID(b_vungId, 'qh_thuongtru'), b_xp_thuongtru = form_Fs_TEN_ID(b_vungId, 'xp_thuongtru'),
    b_nsinhId = form_Fs_TEN_ID(b_vungId, 'nsinh'), b_dantoc = form_Fs_TEN_ID(b_vungId, 'dantoc'), b_tongiao = form_Fs_TEN_ID(b_vungId, 'tongiao');
    b_so_the_gtId = form_Fs_TEN_ID(b_vungId, 'ma_gt'); b_ten_gtId = form_Fs_TEN_ID(b_vungId, 'ten_gt');
    b_phong_tkId = form_Fs_TEN_ID(b_vungtkId, 'phong_tk');
    b_trangthaiId = form_Fs_TEN_ID(b_vungtkId, 'dr_trangthai');
    b_ma_nsdId = form_Fs_TEN_ID(b_vungId, 'ma_nsd');
    b_ql_tt = form_Fs_TEN_ID(b_vungId, 'quanly_tt');
    b_ten_tkId = form_Fs_TEN_ID(b_vungtkId, 'ten_tk');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'), b_tenphongId = form_Fs_VTEN_ID('UPa_hi', 'ten_phong');
    b_psId = form_Fs_VTEN_ID('UPa_hi', 'ps'), b_nvId = form_Fs_VTEN_ID('UPa_hi', 'nv');
    b_slideId = b_grlkeId + '_slide';
    b_no_anhId = form_Fs_TM() + "/images/no_image.png";
    b_loading_anhId = form_Fs_TM() + "/images/" + "loading_image.gif";
    b_iurlId = document.getElementById(iurl_id);
    ns_cb_lkeCho = setInterval('ns_cb_P_LKE_CHO()', 200);
    b_klkId = form_Fs_VTEN_ID('', 'klk');
}
function ns_cb_P_NPA(b_nv) {
    if (b_nv != "ch") {
        $get(b_ns_khId).style.display = "none";
        $get(b_ns_chId).style.display = "inline";
    }
    else {
        $get(b_td_khId).style.display = "inline";
        $get(b_td_chId).style.display = "none";
    }
}
function ns_cb_active_tab() {

}
function ns_cb_RemoveClassActive() {
    $get("ns_qhe").className = "";
    $get("ns_gd_hc").className = "";
    $get("ns_dthv").className = "";
    $get("ns_ls_qt_dt").className = "";
    $get("ns_kynang_cn").className = "";
    $get("ns_ths").className = "";
    $get("ns_hd").className = "";
    $get("ns_cp").className = "";
    $get("ns_hdct").className = "";
    $get("ns_biendong_bh").className = "";
    $get("ns_tv").className = "";
    $get("ns_ktkl_kt").className = "";
    $get("ns_ktkl_kl").className = "";
    $get("ns_ttb").className = "";
    $get("ns_cd_dsvm").className = "";
    $get("ns_qt_hoctap").className = "";
    $get("ns_ls_ct_tct").className = "";
    $get("ns_lsct").className = "";
}
function ns_cb_activemenu(b_id) {
    ns_cb_RemoveClassActive();
    $get(b_id).className = "active";
}
function form_dong() {
    location.reload(false);
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
        if (b_dtuong.indexOf("TTTHEM") >= 0) {
            P_KET_QUA2(b_dtuong, a_tso);
        }
        if (b_dtuong.indexOf("NC_CMT") >= 0) {
            $get(b_nc_cmtId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_dchiId).focus();
        }
        else if (b_dtuong.indexOf("NS_ANH") >= 0) {
            sns_tt.Fs_NS_CB_ANH(Fs_NS_CB_ANH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
        else if (b_dtuong.indexOf("ANH_THE") >= 0) {
            layurl_cho();
            return false;
        }
        else if (b_dtuong.indexOf("DANTOC") >= 0) {
            $get(b_dantoc).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
        }
        else if (b_dtuong.indexOf("TONGIAO") >= 0) {
            $get(b_tongiao).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
        }
        else if (b_dtuong.indexOf("NHA") >= 0) {
            $get(b_nhaId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_nha_dchiId).value = a_tso[2];
            $get(b_mastId).focus();
        }
        else if (b_dtuong.indexOf("NHOM_CD") >= 0) {
            $get(b_ncdId).value = b_kq;
            $get(b_gchuId).value = a_tso[1];
            $get(b_ncdId).focus();
        }
        else if (b_dtuong.indexOf("NHOM") >= 0) {
            $get(b_nhomId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_nhomId).focus();
        }
        else if (b_dtuong.indexOf("THOIVIEC") >= 0) {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "')", 200);
        }
        else if (b_dtuong.indexOf("THONGKE") >= 0) {
            b_cho_control = setInterval("P_cho2('" + a_tso[0] + "')", 200);
            return false;
        }
        else if (b_dtuong.indexOf("DAYPHONG") >= 0) {
            if (b_check == "phong") {
                $get(b_phongId).value = a_tso[0];
            }
            if (b_check == "phong_tk") {
                $get(b_phong_tkId).value = a_tso[0];
                $get(b_tenphongId).value = document.getElementById(b_phongId)[document.getElementById(b_phongId).selectedIndex].innerText;
                ns_cb_P_MOI(); ns_cb_P_LKE();
            }
        }
        else if (b_dtuong.indexOf("BAC_CDANH") >= 0) {
            $get(b_bcdId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_bcdId).focus();
        }
        else if (b_dtuong.indexOf("CDANH") >= 0) {
            $get(b_cdanhId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_cdanhId).focus();
        }

        else if (b_dtuong.indexOf("PHONG_TK") >= 0) {
            $get(b_phong_tkId).value = a_tso[0];
            $get(b_tenphongId).value = document.getElementById(b_phongId)[document.getElementById(b_phongId).selectedIndex].innerText;
            ns_cb_P_MOI(); ns_cb_P_LKE();
            return;
        }
        else if (b_dtuong.indexOf("PHONG") >= 0) {
            $get(b_phongId).value = a_tso[0];
            return;
        }
        else if (b_dtuong.indexOf("KLK") >= 0) {
            ns_cb_P_MOI();
            ns_cb_P_LKE();
        }

        else if (b_dtuong.indexOf("TT_HIENTAI") >= 0) {
            $get(b_tt_hientai).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_tt_hientai).focus();
        }
        else if (b_dtuong.indexOf("QH_HIENTAI") >= 0) {
            $get(b_qh_hientai).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_qh_hientai).focus();
        }
        else if (b_dtuong.indexOf("XP_HIENTAI") >= 0) {
            $get(b_xp_hientai).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_xp_hientai).focus();
        }
        else if (b_dtuong.indexOf("TT_THUONGTRU") >= 0) {
            $get(b_tt_thuongtru).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_tt_thuongtru).focus();
        }
        else if (b_dtuong.indexOf("QH_THUONGTRU") >= 0) {
            $get(b_qh_thuongtru).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_qh_thuongtru).focus();
        }
        else if (b_dtuong.indexOf("XP_THUONGTRU") >= 0) {
            $get(b_xp_thuongtru).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_xp_thuongtru).focus();
        }
        else if (b_dtuong.indexOf("CT") >= 0) {
            b_cho_control = setInterval("P_cho2('" + a_tso[0] + "')", 200);
        }
    }
    catch (err) { form_P_LOI(err); }
}
var b_cho_control = 0;
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

function Fs_NS_CB_ANH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    try {
        if (b_kq == "") return false;
        // xoa cache
        b_iurlId.src = form_Fs_TM() + "/Anh/" + b_kq + "?" + new Date().getTime();
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_cb_P_KTRA(b_maTen) {
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
            $get(b_tenphongId).value = document.getElementById(b_phongId)[document.getElementById(b_phongId).selectedIndex].innerText;
            ns_cb_P_MOI(); ns_cb_P_LKE();
        }
        else if (b_maTen == "TEN") {
            sns_tt.Fs_TEN_HOA(b_ma.value, ns_cb_TEN_HOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            $get(b_tenId).value = ten_hoa(b_ma.value);
            var b_ma_nsd = $get(b_ma_nsdId).value;
            if (b_ma_nsd == "") {
                $get(b_ma_nsdId).value = $get(b_gocId).value;
            }
        }
        else if (b_maTen == "NC_CMT") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_cb_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN); $get(b_dchiId).focus();
        }
        else if (b_maTen == "CDANH") {
            var b_ma = $get(b_cdanhId).value;
            var b_ncd = $get(b_ncdId).value;
            if (b_ncd == "") { alert("Phải nhập nhóm chức danh công việc"); return; $get(b_ncdId).focus(); }
        }
        else if (b_maTen == "BCD") {
            var b_ncd = $get(b_ncdId).value, b_cdanh = $get(b_cdanhId).value, b_ma = $get(b_bcdId).value;
            if (b_ncd == "") { alert("Phải nhập nhóm chức danh công việc"); $get(b_bcdId).value = ""; $get(b_ncdId).focus(); return; }
            if (b_cdanh == "") { alert("Phải nhập chức danh công việc"); $get(b_bcdId).value = ""; $get(b_ncdId).focus(); return; }
            sns_ma_ch.Fs_NS_MA_BACCDANH_HOI(b_ncd, b_cdanh, b_ma, Fs_NS_CB_HOI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_maTen == "NHAN") {
            ns_cb_hien_tkhoan();
            $get(b_sotkId).focus();
            if (b_ma.value == "M") {
                ns_cb_an_tkhoan();
                $get(b_mastId).focus();
            }
        }
        else if (b_maTen == "NHA") { skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_cb_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN); $get(b_mastId).focus(); }
        else if (b_maTen == "NHOM") { skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_cb_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN); $get(b_ngaydId).focus(); }
        else if (b_maTen == "SO_THE") {
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "so_the", b_ma.value);
            if (b_hang < 1) {

                sns_tt.Fs_NS_CB_HOI(b_ma.value, Fs_NS_CB_HOI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
            else { GridX_datA(b_grlkeId, b_hang); ns_cb_P_CHUYEN_HANG(); }
        }
        else if (b_maTen == "SO_THE_GT") { skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_cb_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN); }
    }
    catch (err) { form_P_LOI(err); }
}
var ns_cb_chuyenhang_cho = 0;
function Fs_NS_CB_HOI_KQ(b_kq) {
    var a_kq = b_kq.split('#');
    var b_phong = $get(b_phong_tkId).value;
    if (b_phong != a_kq[1] && a_kq[1] != '') {
        $get(b_phong_tkId).value = a_kq[1];
        ns_cb_chuyenhang_cho = setInterval('ns_cb_P_MA_KTRA()', 200);
    }
    else {
        GridX_thoiA(b_grlkeId);
        ns_cb_chuyenhang_cho = setInterval('ns_cb_P_MA_KTRA()', 200);

    }
}
function KiemTra_QL() {
    var ql = $get(b_ql_tt).value;
    if (ql != "") {

        skhac.Fs_MA_LOI(form_Fs_nsd(), "Mã quản lý", ql, "ns_cb,so_the,ten", KiemTra_QL_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function KiemTra_QL_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    $get(b_gchuId).innerHTML = b_kq;
}
function ns_cb_P_MA_KTRA() {
    try {
        clearTimeout(ns_cb_chuyenhang_cho);
        var b_so_the = C_NVL($get(b_gocId).value);
        if (b_so_the != "") {
            var b_lke = ($get(b_klkId).innerHTML == "Hoạt động") ? "0" : "1";
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_phong = $get(b_phong_tkId).value;
            sns_tt.Fs_NS_CB_MA(b_phong, b_so_the, b_lke, b_TrangKt, a_cot, ns_cb_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_cb_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        form_P_MOI(b_vungId, "X");
        b_iurlId.src = b_no_anhId;
        khud_ttt_P_LKE();
    }
    else { GridX_datA(b_grlkeId, b_hang); ns_cb_P_CHUYEN_HANG(); }
    return false;
}

function ns_cb_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else if (b_mt == "SO_THE_GT") { $get(b_ten_gtId).value = b_kq; }
    else form_P_DatGchu(b_gchuId, b_kq);
}

function ns_cb_TEN_HOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    $get(b_tenhoaId).value = b_kq;
    $get(b_nsinhId).focus();
}

var ns_cb_choAct = 0;
function ns_cb_GR_lke_RowChange() {
    if (ns_cb_choAct != 0) clearTimeout(ns_cb_choAct);
    ns_cb_choAct = setTimeout("ns_cb_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_cb_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_cb_lkeCho); ns_cb_P_LKE(); }
}

function ns_cb_P_NH() {
    try {
        //var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        //if (b_loi != "") { alert(b_loi); return true; }
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        else {
            var b_lke = ($get(b_klkId).innerHTML == "Hoạt động") ? "0" : "1";
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var b_dt_ttt = khud_ttt_P_LAY_NH();
            if (b_dt_ttt != "") {
                if (Fb_LOI_KTRA(b_dt_ttt)) { form_P_LOI(b_dt_ttt); return false; }
            }
            var b_so_id = $get(b_so_idId).value;
            var b_phongtk = $get(b_phong_tkId).value, a_cot_nl = GridX_Fdt_cotGtri(b_grctnl);
            sns_tt.Fs_NS_CB_NH(b_phongtk, b_TrangKt, b_lke, a_dt_ct, b_dt_ttt, a_cot_nl, a_cot_lke, ns_cb_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}

function ns_cb_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        //$get(b_phong_tkId).value = $get(b_phongId).value;
        $get(b_gocId).focus();
        form_P_LOI("loi:Nhập thành công:loi");
    }
}
function ns_cb_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    b_iurlId.src = b_no_anhId;
    $get(b_so_idId).value = "0";
    $get(b_gocId).focus();
    return false;
}
function ns_cb_P_XOA() {
    var r = confirm("Bạn có chắc chắn xóa không?");
    if (r == false) {
        return false;
    }
    var b_lke = $get(b_trangthaiId).value;
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) {
        form_P_LOI("loi:Chưa chọn nhân viên cần xóa:loi");
        return false;
    }
    var b_so_the = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the");
    if (b_so_the == "") ns_cb_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId), b_phong = $get(b_phong_tkId).value;
        sns_tt.Fs_NS_CB_XOA(b_so_the, b_phong, b_lke, a_tso, a_cot, ns_cb_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_cb_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_cb_P_MOI();
        else {
            GridX_datA(b_grlkeId, b_hang);
            ns_cb_P_CHUYEN_HANG();
        }
    }
}
function ns_cb_P_ANH() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 0) {
            var b_tenf = b_tmf + '/ns/tt/ns_anh.aspx';
            var b_so_the = $get(b_gocId).value;
            form_P_MO(b_tenf, window.name + ",NS_ANH", ["NS_ANH", [b_so_the]], null);
            return false;
        }
        else {
            form_P_LOI('loi:Chọn cán bộ muốn thêm ảnh:loi');
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_cb_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    b_iurlId.src = b_loading_anhId;
    var b_so_the = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the"));
    b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_the == "") form_P_MOI(b_vungId, "XGL");
    else sns_tt.Fs_NS_CB_CT(b_so_the, ns_cb_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    //else form_P_GridX_TEXT(b_vungId, b_grlkeId);
    khud_trdoi_FI_CHUYEN();
    $get(b_so_idId).value = b_so_id;
    return false;
}
function ns_cb_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    khud_ttt_P_LKE(a_kq[2]);
    return false;
}

function ns_cb_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
             b_sothe = $get(b_gocId).value;
        //var b_lke = $get(b_trangthaiId).value;
        sns_tt.Fs_NS_CB_QLY_LKE(a_tso, a_cot, ns_cb_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cb_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    b_iurlId.src = b_no_anhId;
    return false;
}
function ns_cb_P_qly() {
    try {
        sns_tt.Fdt_NS_CB_QLY_PHONG(ns_cb_P_qly_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cb_P_qly_KQ(b_kq) {
    if (b_kq == "KO") return;
    $get(b_phong_tkId).value = b_kq;
    ns_cb_P_LKE();
    return false;
}
function checkSothe() {
    var b_sothe = $get(b_gocId).value;
    if (b_sothe == "") {
        form_P_LOI('loi:Chưa chọn cán bộ:loi');
        return false;
    }
}
function ns_cb_hien_tkhoan() {
    $get(b_sotkId).removeAttribute("disabled");
    $get(b_nhaId).removeAttribute("disabled");
    $get(b_nha_dchiId).removeAttribute("disabled");
}
function ns_cb_an_tkhoan() {
    $get(b_sotkId).setAttribute("disabled", "disabled");
    $get(b_nhaId).setAttribute("disabled", "disabled");
    $get(b_nha_dchiId).setAttribute("disabled", "disabled");
}
function from_THEM_TT() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) {
            form_P_LOI('loi:Chọn cán bộ trước:loi');
        }
    }
    catch (err) { form_P_LOI(err); }
}
function from_MA_TT() {
    try {
        var b_tenf = b_tmf + '/khud/ns_khud_ttt.aspx';
        form_P_MO(b_tenf, window.name, ["THAMSO", ["NS,TT,Lý lịch cán bộ"]], null);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cb_P_IMPORT() {
    var b_tenf = b_tmf + '/khud/khud_Excel_Import.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", ["NS_CB"]], null);
    return false;
}
function ns_cb_TIMKIEM() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var a_dt_ct = form_Faa_TEXT_ROW(b_vungtkId);
        var a = $get(b_klkId).innerHTML;
        var b_lke = $get(b_trangthaiId).value;
        sns_tt.Fs_NS_CB_TIMKIEM(a_dt_ct, b_lke, a_tso, a_cot, ns_cb_TIMKIEM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cb_TIMKIEM_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    ns_cb_P_MOI();
    return false;
}

function nhap_file() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) {
        form_P_LOI('loi:Chọn cán bộ trước:loi')
        return false;
    }
    var b_tenf = '/App_form/ns/ma/file_Import_chung.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "NS_CB", "Import_Vaora", "Lưu sơ yếu lý lịch"]], null);
    form_P_LOI('');
    return false;
}
function ten_hoa(b_input) {
    newVal = '';
    b_input = b_input.split(' ');
    for (var c = 0; c < b_input.length; c++) {
        newVal += b_input[c].substring(0, 1).toUpperCase()
                + b_input[c].substring(1, b_input[c].length) + ' ';
    }
    return newVal;
}

function khud_trdoi_FI_NH() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) {
            form_P_LOI('loi:Chọn cán bộ trước:loi')
            return false;
        }
        var b_nd = "Ảnh thẻ", b_f = $get(b_gocId).value
        form_P_LOI("");
        b_t = "/" + b_f.substr(0, 4) + "/" + b_f.substr(4, 2) + "/" + b_f.substr(6, 2);
        form_P_MO(b_tmf + '/ns/tt/file_anh.aspx', window.name + ",FLUU", ["TSO", [b_t, b_f, null, 'ID', b_ma_dvi, b_nd]]);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function khud_trdoi_GR_fi_RowChange() {
    if (b_choAct_fi != 0) clearTimeout(b_choAct_fi);
    b_choAct_fi = setTimeout("khud_trdoi_FI_CHUYEN()", 300);
    return false;
}

function ns_cb_nl_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grctId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        var b_ktra = C_NVL(b_ctr.ktra), b_ten = C_NVL(b_ctr.ten);
        if (b_value != "") {
            if (b_cot == "NHOM_NL_TEN") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Nhóm năng lực", b_value, "dg_dm_nhom_nl,ma,ten", ns_cb_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
            if (b_cot == "NANGLUC_TEN") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Năng lực", b_value, "dg_dm_nl,ma,ten", ns_cb_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        if (b_value != "") GridX_ThemHang(b_grctId);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}



function layurl_cho() {
    if (b_choAct_fi != 0) clearTimeout(b_choAct_fi);
    b_choAct_fi = setTimeout("layurl()", 300);
    return false;
}

function khud_trdoi_FI_CHUYEN() {
    try {
        var b_goc = C_NVL(GridX_Fas_layGtriA(b_grlkeId, "iurl"));
        //if (b_goc != "" && b_goc != null) b_iurlId.src = b_loading_anhId;
        //else b_iurlId.src = b_no_anhId;
        var b_i = b_goc.lastIndexOf('.');
        if (b_i > 0) {
            var b_s = b_goc.substr(b_i + 1);
            if (b_s != "" && "png,PNG,gif,GIF,BMP,bmp,jpg,JPG,JPEG,jpeg".indexOf(b_s) >= 0) sns_tt.Fs_FI_ANH_TRA(b_goc, khud_trdoi_FI_CHUYEN_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        } else b_iurlId.src = b_no_anhId;
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function khud_trdoi_FI_CHUYEN_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else b_iurlId.src = b_kq + "?" + new Date().getTime();
}

function layurl() {
    try {
        b_iurlId.src = b_loading_anhId;
        var b_so_the = $get(b_gocId).value;
        sns_tt.Fs_FI_ANH_URL(layurl_kq, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function layurl_kq(b_kq) {
    try {
        if (b_kq == "File nhập phải nhỏ hơn 1 MB!") {
            form_P_LOI("File nhập phải nhỏ hơn 1 MB!");
        }
        else {
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            GridX_datGtri(b_grlkeId, b_hang, "iurl", b_kq);
        }
        khud_trdoi_FI_CHUYEN();
        return false;
    }
    catch (err) { form_P_LOI(err); }

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
function ns_cb_cmt() {
    try {
        var b_tenf = form_Fs_TM() + '/App_form/ns/ma/ns_ma_tt.aspx';
        form_P_MO(b_tenf, null, ["ns_cb", [""]]);
        return false;
    }
    catch (err) { }
}

function test() {
    form_P_LOI("loi:Test thử:loi");
}

// quân huyện hiện tại
function ns_danhsach_P_QHHT() {
    try {
        var b_ma_tt = form_Fs_TEN_GTRI(b_vungId, 'tt_hientai');
        sns_tt.Fs_NS_MA_QH_LKE(b_ma_tt, ns_danhsach_P_QHHT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}

function ns_danhsach_P_QHHT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_ma_qh = form_Fs_TEN_ID(b_vungId, 'qh_hientai');
        drop_P_LKE(b_ma_qh, b_kq);
    }
}
// quân huyện thường trú
function ns_danhsach_P_QHTT() {
    try {
        var b_ma_tt = form_Fs_TEN_GTRI(b_vungId, 'tt_thuongtru');
        sns_tt.Fs_NS_MA_QH_LKE(b_ma_tt, ns_danhsach_P_QHTT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}

function ns_danhsach_P_QHTT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_ma_qh = form_Fs_TEN_ID(b_vungId, 'qh_thuongtru');
        drop_P_LKE(b_ma_qh, b_kq);
    }
}
// xã phường hiện tại
function ns_danhsach_P_XPHT() {
    try {
        var b_ma_qh = form_Fs_TEN_GTRI(b_vungId, 'qh_hientai');
        sns_tt.Fs_NS_MA_XP_LKE(b_ma_qh, ns_danhsach_P_XPHT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}

function ns_danhsach_P_XPHT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_ma_xp = form_Fs_TEN_ID(b_vungId, 'xp_hientai');
        drop_P_LKE(b_ma_xp, b_kq);
    }
}
// xã phường thường trú
function ns_danhsach_P_XPTT() {
    try {
        var b_ma_qh = form_Fs_TEN_GTRI(b_vungId, 'qh_thuongtru');
        sns_tt.Fs_NS_MA_XP_LKE(b_ma_qh, ns_danhsach_P_XPTT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}

function ns_danhsach_P_XPTT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_ma_xp = form_Fs_TEN_ID(b_vungId, 'xp_thuongtru');
        drop_P_LKE(b_ma_xp, b_kq);
    }
}
