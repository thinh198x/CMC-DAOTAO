var ns_hdns_dbien_lkeCho, b_vungId, b_cho_control = 0, b_grlkeId, b_grctId, b_gocId, b_loi_id, b_mt, b_gchuId, b_thangId, b_doi = 0, b_phongId,
    ns_hdns_dbien_choAct = 0, ns_hdns_dbien_P_KD_choAct = 0, ns_hdns_dbien_P_KD2_choAct = 0, b_ctyId, b_ctyValue, b_ctrbeforId, b_phongban_ctId, b_nam_tkId, b_anNamId, b_phong_tkId;
function ns_hdns_dbien_P_KD() {
    ns_hdns_dbien_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vung_tkId = form_Fs_VUNG_ID('UPa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
        b_gocId = form_Fs_TEN_ID(b_vungId, 'nam'), b_nam_tkId = form_Fs_TEN_ID(b_vung_tkId, 'nam_tk'), b_phongId = form_Fs_TEN_ID(b_vungId, 'phong'), b_banId = form_Fs_TEN_ID(b_vungId, 'BAN'), b_donviId = form_Fs_TEN_ID(b_vungId, 'DONVI')
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'); b_slideId = b_grlkeId + '_slide'; b_phongban_ctId = form_Fs_TEN_ID(b_vungId, 'phongban_ct');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu'); b_anNamId = form_Fs_VTEN_ID('UPa_hi', 'an_Nam'); b_phong_tkId = form_Fs_VTEN_ID('UPa_hi', 'an_phong');

    ns_hdns_dbien_lkeCho = setInterval('ns_hdns_dbien_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "" || a_tso[0] == "FILE_HTOAN") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        b_doi = 0;
        if (b_dtuong.indexOf("BCDANH") >= 0) {
            b_doi = 1;
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grctId, b_hang, ["bcdanh"], [a_tso[0]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["heso"], [a_tso[1]], 'K');
        } else if (b_dtuong.indexOf("TEN_CDANH") >= 0) {
            b_doi = 0;
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grctId, b_hang, ["ten_cdanh"], [a_tso[1]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["cdanh"], [a_tso[0]], 'K');
            ns_hdns_dbien_P_LKE_TONGNHANSU();
        }
        else if (b_dtuong.indexOf("PHONG") >= 0) {
            $get(b_phongId).value = b_kq;
            $get(b_gchuId).value = a_tso[1];
            $get(b_phongId).focus();
            ns_hdns_dbien_P_LKE_TONGNHANSU();
        } else if (b_dtuong.indexOf("TAI_IMPORT") >= 0) {
            ns_hdns_dbien_P_LKE('K');
        }
    }
    catch (err) { form_P_LOI(err); }
}

// Kiểm tra
function ns_hdns_dbien_P_KTRA(b_maTen) {
    try {
        if (b_maTen == "NAM") {
            form_P_MOI(b_vungId, "XL");
            var b_phong = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "phong")), a_cot_ct = GridX_Fas_tenCot(b_grctId);
            sns_td.Fs_NS_HDNS_DBIEN_CT(form_Fs_nsd(), nam, b_phong, a_cot_ct, ns_tl_tl_ml_P_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_maTen == "PHONG") ns_tl_tl_ml_P_LKE();
    }
    catch (err) { form_P_LOI(err); }
}
// Nhập
function ns_hdns_dbien_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId); GridX_datTrang(b_grctId);
    $get(b_so_idId).value = "0"; $get(b_gocId).focus();
    return false;
}
function ns_hdns_dbien_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var b_dt = form_Faa_TEXT_ROW(b_vungId), a_tso = slide_Faobj_TUDEN(b_slideId),
            a_cot_ct = GridX_Fdt_cotGtri(b_grctId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId),
            b_dt_tk = form_Faa_TEXT_ROW(b_vung_tkId);
        sns_td.Fs_NS_HDNS_DBIEN_NH(form_Fs_nsd(), b_dt, a_cot_ct, b_ctyValue, a_cot_lke, a_tso, b_dt_tk, ns_hdns_dbien_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_dbien_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    form_P_LOI("loi:Nhập thành công:loi");
}
// Xóa
function ns_hdns_dbien_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_nam = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "nam"));
    b_donvi = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "donvi"));
    var b_dt_tk = form_Faa_TEXT_ROW(b_vung_tkId);
    if (b_nam == "" || b_donvi == "") ns_hdns_dbien_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_td.Fs_NS_HDNS_DBIEN_XOA(form_Fs_nsd(), b_nam, b_donvi, a_tso, a_cot, b_dt_tk, b_ctyValue, ns_hdns_dbien_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_hdns_dbien_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_hdns_dbien_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_hdns_dbien_P_CHUYEN_HANG(); }
    }
}
// Chuyển hàng
function ns_hdns_dbien_GR_lke_RowChange() {
    if (ns_hdns_dbien_choAct != 0) clearTimeout(ns_hdns_dbien_choAct);
    ns_hdns_dbien_choAct = setTimeout("ns_hdns_dbien_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_hdns_dbien_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")),
        b_nam = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "nam")), b_donvi = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "donvi"));

    if (b_nam == null || b_nam == "") { form_P_MOI("", "XGL"); GridX_datTrang(b_grctId); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        sns_td.Fs_NS_HDNS_DBIEN_CT(form_Fs_nsd(), b_nam, b_donvi, a_cot_ct, ns_hdns_dbien_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }

}
function ns_hdns_dbien_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    $get(b_so_idId).value = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
}
// Liệt kê
function ns_hdns_dbien_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ns_hdns_dbien_lkeCho != 0) clearTimeout(ns_hdns_dbien_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        form_F_GOC().P_MENUBf(window.name, 'M');
        vb_cctc_P_SL('', 'D', '0', ' ', ' ', 'T');
        b_ctyValue = "";
        ns_hdns_dbien_P_LKE('K');
    }
}
function ns_hdns_dbien_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId), b_dt_tk = form_Faa_TEXT_ROW(b_vung_tkId);
        sns_td.Fs_NS_HDNS_DBIEN_LKE(form_Fs_nsd(), b_dt_tk, b_ctyValue, a_tso, a_cot, ns_hdns_dbien_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_hdns_dbien_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}
function hsns_dinhbien_ns_tinh(b_event) {
    var tong = 0;
    var b_maId = "";
    var b_hang = GridX_Fi_timHangA(b_grctId);

    var b_ctr = form_Fctr_event(b_event);
    var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
    b_mt = b_cot;
    if (b_value != "") {
        if (b_cot == "CDANH") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), "Mã chức danh", b_value.toUpperCase(), "ns_ma_cdanh,ma,ten", hsns_dinhbien_ns_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }

    if (b_hang > 0) {
        var tong = CSO_SO(GridX_Fas_layGtri(b_grctId, b_hang, "sl_dbien")) + CSO_SO(GridX_Fas_layGtri(b_grctId, b_hang, "sl_dbien_ps"));
        GridX_datGtri(b_grctId, b_hang, ["tong_dbien"], [tong], 'K');

        var tong1 = CSO_SO(GridX_Fas_layGtri(b_grctId, b_hang, "tong_dbien")) - CSO_SO(GridX_Fas_layGtri(b_grctId, b_hang, "ns_hientai")) -
            CSO_SO(GridX_Fas_layGtri(b_grctId, b_hang, "sl_truyen_d")) - CSO_SO(GridX_Fas_layGtri(b_grctId, b_hang, "sl_nghiviec"));
        GridX_datGtri(b_grctId, b_hang, ["sl_ctruyen"], tong1, 'K');

        var tong2 = CSO_SO(GridX_Fas_layGtri(b_grctId, b_hang, "sl_ctruyen")) + CSO_SO(GridX_Fas_layGtri(b_grctId, b_hang, "sl_nghiviec")) - CSO_SO(GridX_Fas_layGtri(b_grctId, b_hang, "sl_truyen_d"));
        GridX_datGtri(b_grctId, b_hang, ["sl_truyen_cl"], tong2, 'K');
    }
    return false;
}
function ns_hdns_dbien_P_LKE_TONGNHANSU() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grctId);
        if (b_hang < 1) return;
        var b_nam = $get(b_gocId).value;
        if (b_nam != "") {
            var b_dvi = $get(b_donviId).value;
            var b_ban = $get(b_banId).value;
            var b_phong = $get(b_phongId).value;
            var b_cdanh = C_NVL(GridX_Fas_layGtri(b_grctId, b_hang, "cdanh"));
            sns_td.Fs_NS_CB_TONGNHANSU(b_dvi, b_nam, b_phong, b_cdanh, ns_hdns_dbien_P_LKE_TONGNHANSU_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;

    }
    catch (err) { form_P_LOI(err); }
}


function ns_hdns_dbien_P_LKE_TONGNHANSU_PHONG() {
    try {
        var b_nam = $get(b_gocId).value;
        if (b_nam != "") {
            a_cot = GridX_Fas_tenCot(b_grctId), a_cot = GridX_Fas_tenCot(b_grctId), b_dt_tk = form_Faa_TEXT_ROW(b_vungId);
            sns_td.Fs_NS_CB_TONGNHANSU_PHONG(b_dt_tk, a_cot, ns_hdns_dbien_P_LKE_TONGNHANSU_PHONG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;

    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_dbien_P_LKE_TONGNHANSU_PHONG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        GridX_datBang(b_grctId, b_kq);
    }
}

function ns_hdns_dbien_P_LKE_TONGNHANSU_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#')
    var b_hang = GridX_Fi_timHangA(b_grctId);
    if (b_hang < 0) return;
    GridX_datGtri(b_grctId, b_hang, ["ten_cdanh"], [a_kq[0]], 'K');
    GridX_datGtri(b_grctId, b_hang, ["cdanh"], [a_kq[1]], 'K');
    GridX_datGtri(b_grctId, b_hang, ["ns_hientai"], [a_kq[2]], 'K');
    var tong = CSO_SO(GridX_Fas_layGtri(b_grctId, b_hang, "sl_dbien")) + CSO_SO(GridX_Fas_layGtri(b_grctId, b_hang, "sl_dbien_ps")) + CSO_SO(a_kq[0]);
    GridX_datGtri(b_grctId, b_hang, ["tong_dbien"], [tong], 'K');
}
function ns_hdns_dbien_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_hdns_dbien_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_hdns_dbien_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function ns_hdns_dbien_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}
function ns_hdns_dbien_P_LSU() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("loi:Bạn chưa chọn phòng ban:loi"); return false; }
    var b_phong = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "donvi")), b_nam = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "nam"));
    var b_tenf = '/App_form/ns/hdns/ns_hdns_lsdbien.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "", "", "Lịch sử định biên", b_nam, b_phong]], "C");
}

function form_dong() {
    location.reload(false);
}

function ns_hdns_dbien_P_KTRA_DR(b_maTen) {
    try {
        var b_ma = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "DONVI": b_ma = form_Fs_TEN_GTRI(b_vungId, 'donvi'); break;
            case "BAN": b_ma = form_Fs_TEN_GTRI(b_vungId, 'ban'); break;
            case "CDANH": b_ma = form_Fs_TEN_GTRI(b_vungId, 'cdanh'); break;
            case "PHONG": b_ma = form_Fs_TEN_GTRI(b_vungId, 'phong'); break;
            /*case "MA": b_ma = $get(b_gocId).value; break;*/
        }
        if (b_maTen == "DONVI") {
            var b_phongban = form_Fs_TEN_GTRI(b_vungId, 'DONVI');
            hts_dungchung.Fdt_CHUOI_CCTC(b_phongban, ns_hdns_dbien_P_CCTC_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            ns_hdns_dbien_P_LKE_TONGNHANSU_PHONG();
        } else if (b_maTen == "BAN") {
            var b_kq = "{";
            lke_P_DAT($get(form_Fs_TEN_ID('', 'phong')), b_kq);
            var b_ban = form_Fs_TEN_GTRI(b_vungId, 'ban');
            hts_dungchung.Fs_PHONG_LEVEL_DR(3, b_ban, 'DT_PHONG', 'ns_hdns_dbien', ns_hdns_dbien_P_KTRA_DR_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_maTen == "TK_DONVI") {
            ns_hdns_dbien_P_LKE();
        }

        else if (b_maTen == "CDANH") {
            var b_kq = "{";
            lke_P_DAT($get(form_Fs_TEN_ID('', 'bac_cdanh')), b_kq);
            var b_cdanh = form_Fs_TEN_GTRI(b_vungId, 'cdanh');
            if (b_cdanh != '')
                hts_dungchung.Fs_NHOM_CD(b_cdanh, 'DT_BCDANH', 'ns_hdns_dbien', ns_hdns_dbien_P_CDANH_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_hdns_dbien_P_CCTC_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq))
            form_P_LOI(b_kq);
        else {
            $get(b_phongban_ctId).value = b_kq;
        }
    }
    catch (err) {
        alert(err);
    }
}
function ns_hdns_dbien_P_KTRA_DR_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        ns_hdns_dbien_P_LKE_TONGNHANSU_PHONG();
    }
}

function ns_hdns_dbien_P_FI_NH() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) { form_P_LOI("loi:Bạn chưa chọn định biên phòng ban muốn gán file:loi"); return false; }
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        var b_t = b_so_id.toString(), b_f = b_so_id;
        b_t = '/' + b_t.substr(0, 4) + '/' + b_t.substr(4, 2) + '/' + b_t.substr(6, 2);
        var b_tmf = form_Fs_TM('f');
        var b_ten = 'File lưu';
        form_P_MO(b_tmf + '/khud/khud_luuf.aspx', window.name + ',FLUU', ['TSO', [b_t, b_f, null, 'ID', '', b_ten]]);
        form_P_LOI('');
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_hdns_dbien_Import() {
    var b_tenf = '/App_form/ns/ma/file_Import.aspx';
    form_P_MO(b_tenf, window.name + ',THAMSO', ['THAMSO', [window.name, 'NS_HDNS_DINHBIEN', null, "Import định biên"]], null);
    form_P_LOI('');
    return false;
}

function ns_hdns_dbien_P_FI_LAY() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) { form_P_LOI("loi:Bạn chưa chọn định biên phòng ban muốn lấy file:loi"); return false; }
        //var b_bt = O_NVL(GridX_Fas_layGtriA(b_grlkeId, 'bt'), '0');
        var b_goc = C_NVL(GridX_Fas_layGtriA(b_grlkeId, 'goc'), '');
        var b_so_id = C_NVL(GridX_Fas_layGtriA(b_grlkeId, 'so_id'), '');
        var b_tmf = form_Fs_TM('f');
        if (b_so_id != 0 && b_goc != '') {
            var b_t = b_so_id.toString();
            var b_f = b_so_id;
            b_goc = b_goc.replace('.', '!'); b_goc = b_goc.replace('/', '|'); b_t = '!' + b_t.substr(0, 4) + '!' + b_t.substr(4, 2) + '!' + b_t.substr(6, 2);
            //b_t += ',' + b_f + ',' + b_goc;
            b_t += ',' + b_f + ',' + b_goc;
            form_P_MO(b_tmf + '/khud/khud_layf.aspx?tso=' + b_goc, null, null, 'C');
        }
        else {
            form_P_LOI("loi:Không có file đính kèm:loi"); return false;
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function vb_cctc_P_CLICK(b_event, b_id) {
    b_event.stopPropagation();
    var b_targetClassNam = b_event.target.className;
    if (b_targetClassNam == "ico_bptt") {
        var b_ctr = $get(b_id), b_div = $get(b_id + '_Div');
        var a_tso = Attribute_Fas_LAY(b_ctr, 'loai,cap,dvi,ma,ma_ct');
        if (b_ctrbeforId != null) b_ctrbeforId.style.fontWeight = "100";
        b_ctr.style.fontWeight = "700";
        b_ctrbeforId = b_ctr;
        b_ctyValue = a_tso[3];
        ns_hdns_dbien_P_LKE('K'); return false;
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

// lấy chức danh theo bộ phận hoặc phòng ban
function ns_cdanh_P_LIST(b_ctrId, b_kieu, b_vtri) {
    try {
        var b_phongban = form_Fs_TEN_GTRI(b_vungId, 'DONVI');
        if (b_phongban != "") {
            var a_tso = lke_Fa_TSO(b_kieu);
            hts_dungchung.Fs_NS_CB_PHONG_CDANH_KN(form_Fs_nsd(), "", b_phongban, a_tso[3], form_LIST_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}

// In 
function ns_hdns_dbien_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_anNamId).value = $get(b_nam_tkId).value;
    $get(b_phong_tkId).value = b_ctyValue;
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}