var ns_hd_pl_lkeCho, b_vungId, b_grlkeId, b_grctId, b_vungtkId, b_slideId, b_slideIdct, b_gocId, b_gchuId, b_so_idId, b_moiId, b_doi = 0, b_ten_cb, b_so_hdId, b_hddauId, b_thangluongId, b_ngachId, b_bacId, b_so_qdId,
    b_tien_lcbId, b_tien_tdgtId, b_tienbhId, b_tien_tnsId, b_phantram_luongId, b_ten_cbId, b_ngaydId, b_ngaycId, b_lhdId, b_ngaykId, b_tienId, b_sothe_tkId, b_ten_tkId, b_phong_tkId,
    b_nghi_viec_tkId, b_ma_nguoikyId, b_cho_control = 0, ns_hd_pl_choAct = 0, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C', b_luonghtId, b_tratheoId, b_ngayd_hdct, b_chonId, b_check = 0,
    b_ten_cdanhnkId, b_kt_loai, b_alhdId, b_ten_ttr = "Chờ phê duyệt", b_ttr = "CPD";
function ns_hd_pl_P_KD(b_tm) {
    b_tmf = b_tm;
    ns_hd_pl_lkeCho = setInterval('ns_hd_pl_P_LKE_CHO()', 200);
}
// Kiểm tra
function ns_hd_pl_P_NPA(b_nv) {
    //if (b_nv == "X") {
    //    $get("lblChon").style.display = "none";
    //    $get(b_so_qdId).style.display = "none";
    //    document.getElementById(b_so_qdId).disabled = true;
    //    document.getElementById(b_thangluongId).disabled = false;
    //    document.getElementById(b_ngachId).disabled = false;
    //    document.getElementById(b_bacId).disabled = false;
    //    document.getElementById(b_tien_lcbId).disabled = false;
    //    document.getElementById(b_tien_tdgtId).disabled = false;
    //    document.getElementById(b_tienbhId).disabled = false;
    //    document.getElementById(b_tien_tnsId).disabled = false;
    //    document.getElementById(b_phantram_luongId).disabled = false;
    //    document.getElementById(b_tienId).disabled = false;
    //}
    //else {
    //    $get("lblChon").style.display = "";
    //    $get(b_so_qdId).style.display = "";
    //    document.getElementById(b_so_qdId).disabled = false;
    //    document.getElementById(b_thangluongId).disabled = true;
    //    document.getElementById(b_ngachId).disabled = true;
    //    document.getElementById(b_bacId).disabled = true;
    //    document.getElementById(b_tien_lcbId).disabled = true;
    //    document.getElementById(b_tien_tdgtId).disabled = true;
    //    document.getElementById(b_tienbhId).disabled = true;
    //    document.getElementById(b_tien_tnsId).disabled = true;
    //    document.getElementById(b_phantram_luongId).disabled = true;
    //    document.getElementById(b_tienId).disabled = true;
    //}
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[0];
        var b_hso = a_tso[1];
        b_doi = 0;
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            lke_P_DAT($get(b_so_hdId), b_kq + '{' + b_kq);
            $get(b_sothe_tkId).value = b_hso;
            Attribute_P_DAT(form_Fctr_TEN_DTUONG(b_vungId, 'so_hd'), "disabled", "disabled");
            Attribute_P_DAT(form_Fctr_TEN_DTUONG(b_vungtkId, 'so_the_tk'), "disabled", "disabled");
            Attribute_P_DAT(form_Fctr_TEN_DTUONG(b_vungtkId, 'ten_tk'), "disabled", "disabled");
            ns_hd_pl_P_LKE_CHO();
            b_check = 1;

        } else if (b_dtuong.indexOf("SO_THE") >= 0) {
            ns_thongtin_canbo(a_tso[0], "SO_THE");
        } else if (b_dtuong.indexOf("MA_NGUOIKY") >= 0) {
            ns_thongtin_canbo(a_tso[0], "MA_NGUOIKY");
        } else if (b_dtuong.indexOf("SO_QD") >= 0) {
            ns_hd_pl_thongtin_qd(a_tso[1], "SO_THE");
        }
        else if (b_dtuong.indexOf("CVU") >= 0) {
            $get(b_cvuId).value = b_kq;
            $get(b_hspcId).value = a_tso[2];
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_lngId).focus();
        }
        else if (b_dtuong.indexOf("NCD") >= 0) {
            $get(b_ncdId).value = b_kq;
            $get(b_gchuId).value = b_hso;
            $get(b_cdanhId).focus();
        }
        else if (b_dtuong.indexOf("CDANH") >= 0) {
            $get(b_cdanhId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_bcdId).focus();
        }
        else if (b_dtuong.indexOf("BCD") >= 0) {
            $get(b_bcdId).value = b_kq;
            $get(b_hscdId).value = b_hso;
            $get(b_hscdId).focus();
        }
        else if (b_dtuong.indexOf("MA_NTE") >= 0) {
            $get(b_ma_nteId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_ma_nteId).focus();
        } else if (b_dtuong.indexOf("MA_PC") >= 0) {
            b_doi = 0;
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            var b_count = a_tso
            if (a_tso[0] == "CMC-2M") {
                for (var i = 1; i < a_tso.length; i++) {
                    GridX_datGtri(b_grctId, b_hang, ["ma_pc"], [a_tso[i][0]], 'K');
                    GridX_datGtri(b_grctId, b_hang, ["ten"], [a_tso[i][1]], 'K');
                    GridX_datGtri(b_grctId, b_hang, ["sotien"], [a_tso[i][2]], 'K');
                    b_hang = b_hang + 1;
                }
                slide_P_SOTRANG(b_slideIdct, CSO_SO(b_hang, 0));
            } else {
                GridX_datGtri(b_grctId, b_hang, ["ma_pc"], [a_tso[0]], 'K');
                GridX_datGtri(b_grctId, b_hang, ["ten"], [a_tso[1]], 'K');
                GridX_datGtri(b_grctId, b_hang, ["sotien"], [a_tso[2]], 'K');
            }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
    if (C_NVL(b_dtuong) != '') {
        if (b_dtuong == 'THAMSO') {
            var b_s = (a_tso[0] == 'K') ? 'M' : 'B';
            //list_P_IdDAT(b_klkId, b_s);
        }
        else form_NhanKq(b_dtuong, a_tso[0]);
    }
}
function ns_hd_pl_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; form_P_MOI("", "XGL"); break;
            case "MA_NGUOIKY": b_maId = b_ma_nguoikyId; break;
            case "CVU": b_maId = b_cvuId; break;
            case "LNG": b_maId = b_lngId; break;
            case "MA_NTE": b_maId = b_ma_nteId; break;
            case "MA_TL": b_maId = b_thangluongId; break;
            case "MA_NL": b_maId = b_ngachId; break;
            case "MA_BL": b_maId = b_bacId; break;
            case "SO_QD": b_maId = b_so_qdId; break;
        }
        b_chonId = b_maTen;
        var b_ma = $get(b_maId);
        if (b_maTen == "HDDAU") {
            var b_hhdau = $get(b_hddauId).value;
            ns_hd_pl_P_NPA(b_hhdau);
        }
        if (b_ma == null || C_NVL(b_ma.value) == "") return;

        if (b_maTen == "SO_THE") {
            //ns_hd_pl_P_LKE();
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_hd_pl_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_thongtin_canbo($get(b_maId).value, b_maTen);
        } else if (b_maTen == "MA_NGUOIKY") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_hd_pl_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_thongtin_canbo($get(b_maId).value, b_maTen);
        } else if (b_maTen == "MA_TL") {
            var b_ma_tl = lke_Fs_TRA($get(b_thangluongId));
            $get(b_ngachId).value = ""; $get(b_bacId).value = ""; $get(b_tien_lcbId).value = ""; $get(b_luonghtId).value = "";
            sns_ma_ch.Fs_NS_MA_TL_NL(window.name, b_ma_tl);
        } else if (b_maTen == "MA_NL") {
            var b_ma_tl = lke_Fs_TRA($get(b_thangluongId)), b_ma_nl = lke_Fs_TRA($get(b_ngachId));
            $get(b_bacId).value = ""; $get(b_tien_lcbId).value = ""; $get(b_luonghtId).value = "";
            sns_ma_ch.Fs_NS_HDNS_MA_BL_BYTLNL(window.name, b_ma_tl, b_ma_nl);
        } else if (b_maTen == "MA_BL") {
            var b_ma_bl = lke_Fs_TRA($get(b_bacId));
            $get(b_tien_lcbId).value = ""; $get(b_luonghtId).value = "";
            sns_ma_ch.Fs_NS_HDNS_MA_BL_BYID(form_Fs_nsd(), window.name, b_ma_bl, ns_hd_pl_ma_bl_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        } else if (b_maTen = "SO_QD") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_hd_pl_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_hd_thongtin_qd_byma(b_ma.value);
        }

    }
    catch (err) { form_P_LOI(err); }
}

function ns_hd_pl_ma_bl_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    $get(b_tien_lcbId).value = SO_CSO(a_kq[0]);
    ns_hd_pl_tinh_thuongkq();
}
function ns_hd_pl_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        if (b_chonId == "SO_THE") { $get(b_gocId).value = ""; $get(b_gocId).focus(); }
        if (b_chonId == "MA_NGUOIKY") { $get(b_ma_nguoikyId).value = ""; $get(b_ten_cdanhnkId).value = ""; $get(b_ma_nguoikyId).focus(); }
        if (b_chonId == "SO_QD") {
            $get(b_so_qdId).value = ""; $get(b_thangluongId).value = ""; $get(b_ngachId).value = ""; $get(b_bacId).value = "";
            $get(b_tienId).value = ""; $get(b_tien_lcbId).value = ""; $get(b_luonghtId).value = ""; $get(b_so_qdId).focus();
        }
        if (b_chonId == "MA_TL") {
            $get(b_thangluongId).focus();
            $get(b_thangluongId).value = ""; $get(b_ngachId).value = ""; $get(b_bacId).value = "";
            $get(b_tienId).value = ""; $get(b_tien_lcbId).value = ""; $get(b_luonghtId).value = "";
        }
        if (b_chonId == "MA_NL") {
            $get(b_ngachId).focus();
            $get(b_ngachId).value = ""; $get(b_bacId).value = "";
            $get(b_tienId).value = ""; $get(b_tien_lcbId).value = ""; $get(b_luonghtId).value = "";
        }
        if (b_chonId == "MA_BL") {
            $get(b_bacId).focus();
            $get(b_bacId).value = "";
            $get(b_tienId).value = ""; $get(b_tien_lcbId).value = ""; $get(b_luonghtId).value = "";
        }

    } else form_P_DatGchu(b_gchuId, b_kq);
}
// Nhập
function ns_hd_pl_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = "0"; $get(b_phantram_luongId).value = "100";
    $get(b_gocId).focus();
    $get(b_lhdId).value = "";
    $get(b_so_hdId).value = "";
    $get(b_hddauId).value = "";
    var b_tratheo = form_Fctr_TEN_DTUONG(b_vungId, 'tratheo');
    list_P_DAT(b_tratheo, 'TH');
    return false;
}
function ns_hd_pl_P_NH(b_thaotac) {
    try {
        var ktra = ktra_ngay(parseDate($get(b_ngaydId).value).getTime(), parseDate($get(b_ngaycId).value).getTime(), 1, "Từ ngày", "Đến ngày");
        if (ktra.length > 0) {
            ns_hd_pl_P_NH_KQ(ktra);
            return false;
        }
        var dateNow = getDateNow();
        var ktraky = ktra_ngay(parseDate($get(b_ngaykId).value).getTime(), parseDate(dateNow).getTime(), 1, "Ngày ký", "ngày hiện tại");
        if (ktraky.length > 0) {
            ns_hd_pl_P_NH_KQ(ktraky);
            return false;
        }
        var b_ktra_ngaykt = ktra_ngaykt(parseDate($get(b_ngaycId).value).getTime());
        if (b_ktra_ngaykt.length > 0) {
            ns_hd_pl_P_NH_KQ(b_ktra_ngaykt);
            return false;
        }
        if (CSO_SO($get(b_tienId).value) < CSO_SO($get(b_tien_lcbId).value)) {
            form_P_LOI("loi:Tổng lương không được nhỏ hơn lương cơ bản:loi");
            return false;
        }

        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 0) {
            b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ttr"));
            if (b_trangthai == 'PD') { form_P_LOI('loi:Bản ghi đang ở trạng thái phê duyệt, không thể chỉnh sửa:loi'); return false; }
            if (b_trangthai == 'KPD') { form_P_LOI('loi:Bản ghi đang ở trạng thái không phê duyệt, không thể chỉnh sửa:loi'); return false; }
        }

        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt = form_Faa_TEXT_ROW(b_vungId), b_so_id = $get(b_so_idId).value;
            var a_dt_ct = GridX_Fdt_cotGtri(b_grctId);
            if (b_thaotac == "P") {
                b_ten_ttr = "Phê duyệt"; b_ttr = "PD";
                sns_qt.Fs_NS_HD_PL_PD(b_so_id, a_dt, a_dt_ct, ns_hd_pl_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            } else {
                sns_qt.Fs_NS_HD_PL_NH(b_so_id, a_dt, a_dt_ct, ns_hd_pl_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }


        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_hd_pl_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        $get(b_so_idId).value = b_kq;
        var b_hang = GridX_Fi_timHangD(b_grlkeId, "so_id", b_kq);
        if (b_hang < 0) {
            b_hang = GridX_Fi_timHangT(b_grlkeId);
            if (b_hang < 0) {
                GridX_ThemHang(b_grlkeId);
                b_hang = GridX_Fi_timHangT(b_grlkeId);
            }
        }
        var b_lhd = lke_Fs_TRA($get(b_lhdId)), b_ten_lhd = $get(b_lhdId).value,
            b_ngayd = $get(b_ngaydId).value,
            b_ngayc = $get(b_ngaycId).value,
            b_ten_cb = $get(b_ten_cbId).value,
            b_sothe = $get(form_Fs_TEN_ID(b_vungId, 'so_the')).value,
            b_ten_trangthai = b_ten_ttr,
            b_ma_trangthai = b_ttr;
        GridX_datGtri(b_grlkeId, b_hang, ["so_id", "lhd", "ten_lhd", "ngayd", "ngayc", "so_the", "ten", "ten_ttr", "ttr"], [b_kq, b_lhd, b_ten_lhd, b_ngayd, b_ngayc, b_sothe, b_ten_cb, b_ten_trangthai, b_ma_trangthai]);
        GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI("loi:Nhập thành công!:loi");
    }
    return false;
}
// Xóa
function ns_hd_pl_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_hang < 1 || b_so_id == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    else {
        b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ttr"));
        if (b_trangthai == 'PD') { form_P_LOI('loi:Bản ghi đang ở trạng thái phê duyệt, không thể xóa:loi'); return false; }
        //if (b_trangthai == 'KPD') { form_P_LOI('loi:Bản ghi đang ở trạng thái không phê duyệt, không thể xóa:loi'); return false; }

        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_so_the = $get(b_sothe_tkId).value, b_ten = $get(b_ten_tkId).value, b_phong = lke_Fs_TRA($get(b_phong_tkId)), b_nghi_viec = $get(b_nghi_viec_tkId).value;
        if (b_check == "1") { var b_so_hd = $get(b_so_hdId).value; }
        else var b_so_hd = "";
        sns_qt.Fs_NS_HD_PL_XOA(window.name, b_so_id, b_so_the, b_ten, b_phong, b_nghi_viec, b_so_hd, a_cot, a_tso, ns_hd_pl_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_hd_pl_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_hd_pl_P_MOI();
        else {
            GridX_datA(b_grlkeId, b_hang); ns_hd_pl_P_CHUYEN_HANG();
        }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
}
// Chuyển hàng
function ns_hd_pl_GR_lke_RowChange() {
    if (ns_hd_pl_choAct != 0) clearTimeout(ns_hd_pl_choAct);
    ns_hd_pl_choAct = setTimeout("ns_hd_pl_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_hd_pl_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    var a_cot_ct = GridX_Fas_tenCot(b_grctId);
    if (b_so_id == "0" || b_so_id == "") {
        form_P_MOI(b_vungId, "XGL"); GridX_datTrang(b_grctId); slide_P_SOTRANG(b_slideIdct, 0);
    }
    else
        sns_qt.Fs_NS_HD_QL_CT(window.name, b_so_id, a_cot_ct, ns_hd_pl_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = b_so_id;
}
function ns_hd_pl_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[1]);
    ns_hd_pl_P_KTRA('HDDAU');
    ns_thongtin_canbo($get(b_gocId).value, "SO_THE");
    ns_thongtin_canbo($get(b_ma_nguoikyId).value, "MA_NGUOIKY");
    if (a_kq[3] == "") GridX_datTrang(b_grctId); else { slide_P_SOTRANG(b_slideIdct, CSO_SO(a_kq[2], 0)); GridX_datBang(b_grctId, a_kq[3]); }
    // đẩy loại hợp đồng vào biến ẩn để phụ vụ chức năng in hợp đồng
    $get(b_alhdId).value = lke_Fs_TRA($get(b_lhdId));
}
// Liệt kê
function ns_hd_pl_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ns_hd_pl_lkeCho != 0) clearTimeout(ns_hd_pl_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'), b_vungtkId = form_Fs_VUNG_ID('UPa_tk'),
            b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE'), b_so_hdId = form_Fs_TEN_ID(b_vungId, 'so_hd'), b_ten_cbId = form_Fs_TEN_ID(b_vungId, 'ho_ten'),
            b_hddauId = form_Fs_TEN_ID(b_vungId, 'hddau'), b_so_qdId = form_Fs_TEN_ID(b_vungId, 'so_qd'), b_ma_nguoikyId = form_Fs_TEN_ID(b_vungId, 'ma_nguoiky'),
            b_lhdId = form_Fs_TEN_ID(b_vungId, 'LHD'), b_ngaydId = form_Fs_TEN_ID(b_vungId, 'ngayd'), b_ngaycId = form_Fs_TEN_ID(b_vungId, 'ngayc'),
            b_ngaykId = form_Fs_TEN_ID(b_vungId, 'ngay_ky'), b_thangluongId = form_Fs_TEN_ID(b_vungId, 'ma_tl'), b_ngachId = form_Fs_TEN_ID(b_vungId, 'ma_nl'),
            b_bacId = form_Fs_TEN_ID(b_vungId, 'ma_bl'), b_tien_lcbId = form_Fs_TEN_ID(b_vungId, 'tien_lcb'), b_tien_tdgtId = form_Fs_TEN_ID(b_vungId, 'tien_tdgt'),
            b_tienbhId = form_Fs_TEN_ID(b_vungId, 'tienbh'), b_tien_tnsId = form_Fs_TEN_ID(b_vungId, 'tien_tns'), b_phantram_luongId = form_Fs_TEN_ID(b_vungId, 'phantram_luong'),
            b_tratheoId = form_Fs_TEN_ID(b_vungId, 'tratheo'), b_ten_cdanhnkId = form_Fs_TEN_ID(b_vungId, 'ten_cdanh_nguoiky'),
            b_tienId = form_Fs_TEN_ID(b_vungId, 'tien'), b_sothe_tkId = form_Fs_TEN_ID(b_vungtkId, 'so_the_tk'), b_ten_tkId = form_Fs_TEN_ID(b_vungtkId, 'ten_tk'),
            b_phong_tkId = form_Fs_TEN_ID(b_vungtkId, 'phong_tk'), b_nghi_viec_tkId = form_Fs_TEN_ID(b_vungtkId, 'nghi_viec_tk'), b_luonghtId = form_Fs_TEN_ID(b_vungId, 'luonght');
        b_atluongId = form_Fs_VTEN_ID('UPa_hi', 'atluong'), b_ntluongId = form_Fs_VTEN_ID('UPa_hi', 'anluong'), b_abluongId = form_Fs_VTEN_ID('UPa_hi', 'abluong'),
            b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'); b_alhdId = form_Fs_VTEN_ID('UPa_hi', 'alhd');
        b_gchuId = form_Fs_VTEN_ID('', 'gchu');
        b_moiId = form_Fs_VTEN_ID('', 'moi');
        b_slideId = b_grlkeId + '_slide', b_slideIdct = $get(b_grctId).getAttribute('slideId');
        lke_P_DAT($get(b_phong_tkId), 'TATCA' + '{' + 'Tất cả');
        var b_tratheo = form_Fctr_TEN_DTUONG(b_vungId, 'tratheo');
        list_P_DAT(b_tratheo, 'TH');
        $get(b_so_qdId).style.display = "none"; $get("lblChon").style.display = "none";
        ns_hd_pl_P_NPA($get(b_hddauId).value);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_hd_pl_P_LKE('K');
    }
}
function ns_hd_pl_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_so_the = $get(b_sothe_tkId).value, b_ten = $get(b_ten_tkId).value, b_phong = lke_Fs_TRA($get(b_phong_tkId)), b_nghi_viec = $get(b_nghi_viec_tkId).value,
            b_so_hd = $get(b_so_hdId).value;
        sns_qt.Fs_NS_HD_PL_LKE(window.name, b_so_the, b_ten, b_phong, b_nghi_viec, b_so_hd, a_cot, a_tso, ns_hd_pl_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hd_pl_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        GridX_datTrang(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if ($get(b_so_hdId).value == "") return false;
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        sns_qt.Fs_NS_HD_CT_BY_SOHD(window.name, $get(b_so_hdId).value, a_cot_ct, ns_hd_pl_P_CHUYEN_HANG_CT_SOHD_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    b_fcho = 'X';
}
function ns_hd_pl_P_CHUYEN_HANG_CT_SOHD_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == "") return;
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    ns_thongtin_canbo($get(b_gocId).value, "SO_THE");
    ns_thongtin_canbo($get(b_ma_nguoikyId).value, "MA_NGUOIKY");
    ns_hd_pl_P_KTRA('HDDAU');
    if (a_kq[2] == "") GridX_datTrang(b_grctId); else { slide_P_SOTRANG(b_slideIdct, CSO_SO(a_kq[1], 0)); GridX_datBang(b_grctId, a_kq[2]); }
    b_ngayd_hdct = $get(b_ngaydId).value;
}

function ns_hd_pl_hoi_NGH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == "") { alert("Chưa đăng ký mã ngạch trong nhóm ngạch này!"); $get(b_ngachId).value = ""; $get(b_ngachId).focus(); }
    else {
        var a_kq = b_kq.split("#");
        $get(b_gchuId).innerHTML = a_kq[1];
    }
}
function ns_hd_pl_hoi_NGBAC_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq != "") {
        $get(b_hsoId).value = b_kq; $get(b_hsoId).focus();
    }
}
function ns_hd_pl_hoi_CDANH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == "") { alert("Chưa đăng ký mã chức danh trong nhóm chức danh này!"); $get(b_cdanhId).value = ""; $get(b_cdanhId).focus(); }
    else {
        var a_kq = b_kq.split("#");
        $get(b_gchuId).innerHTML = a_kq[1];
    }
    return false;
}
function ns_hd_pl_hoi_BCD_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq != "") {
        $get(b_hscdId).value = b_kq; $get(b_hscdId).focus();
    }
}
function ns_hd_pl_hoi_cvu_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        return;
    }
    if (b_kq != "") {
        var a_kq = b_kq.split("#");
        $get(b_hspcId).value = a_kq[0]; $get(b_gchuId).innerHTML = a_kq[1];
        $get(b_lngId).focus();
    }
}
function ns_hd_pl_CHECK_TONTAI_KQ(b_kq) {
    if (b_kq > 0) {
        form_P_LOI("loi:Tồn tại hợp đồng có cùng thời gian hiệu lực:loi");
        return false;
    } else {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), b_so_id = $get(b_so_idId).value;
            sns_qt.Fs_ns_hd_pl_NH(b_so_id, a_dt_ct, ns_hd_pl_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
}
function ns_hd_pl_P_NGAYKETTHUC() {
    try {
        var b_ma_lhd = form_Fs_TEN_GTRI(b_vungId, 'lhd');
        var b_ngayhd = $get(b_ngaydId).value;
        // lay du lieu bieu mau chi phi len theo ngay hieu luc
        stl_ma.Fs_NS_TL_TLAP_TYLE_HOAHONG_DR(window.name, "DT_CHIPHI", b_ngayhd);
        sns_ma_ch.Fs_NS_MA_LHD_SOTHANG(b_ngayhd, b_ma_lhd, ns_hd_pl_P_NGAYKETTHUC_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_hd_pl_P_NGAYKETTHUC_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = b_kq.split("#");
        if (a_kq[1] != "") {
            $get(b_so_hdId).value = a_kq[1];
        }
        if ($get(b_ngaydId).value == "" || a_kq[0] == 0) return false;
        else {
            var b_ngayd = $get(b_ngaydId).value;
            $get(b_ngaycId).value = addDays(b_ngayd, a_kq[0]);
        }
    }
}
function ns_hd_pl_thongtin_qd(b_so_id) {
    try {
        sns_qt.Fs_THONGTIN_QD(b_so_id, ns_hd_pl_thongtin_qd_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hd_pl_thongtin_qd_kq(b_kq) {
    if (b_kq == "") { form_P_MOI(b_vungId, "GXL"); $get(b_gocId).focus(); form_P_LOI(b_kq); return false; }
    form_P_CH_TEXT(b_vungId, b_kq);
    ns_hd_pl_P_KTRA('HDDAU');
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
function ns_hd_pl_thongtin_qd_byma(b_ma) {
    try {
        sns_qt.Fs_THONGTIN_QD_BYMA(b_ma, ns_hd_thongtin_qd_byma_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hd_pl_thongtin_qd_byma_kq(b_kq) {
    if (b_kq == "") { $get(b_gocId).focus(); form_P_LOI(b_kq); return false; }
    form_P_CH_TEXT(b_vungId, b_kq);
    ns_hd_pl_P_NPA('HDDAU');
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
function ns_thongtin_canbo(b_so_the, b_loai) {
    try {
        var b_listcotcu = "", b_listcotmoi = "";
        if (b_loai == "SO_THE") { b_kt_loai = "SO_THE"; b_listcotcu = "SO_THE,HO_TEN,CDANH,TEN_CDANH,PHONG,TEN_PHONG,TEN_VITRI,VITRI", b_listcotmoi = "SO_THE,HO_TEN,CDANH,TEN_CDANH,PHONG,TEN_PHONG,TEN_VITRI,VITRI" }
        else if (b_loai == "MA_NGUOIKY") { b_kt_loai = "MA_NGUOIKY"; b_listcotcu = "SO_THE,TEN_CDANH", b_listcotmoi = "MA_NGUOIKY,TEN_CDANH_NGUOIKY" }
        else { b_kt_loai = ""; b_listcotcu = "SO_THE,HO_TEN,TEN_CDANH,TEN_PHONG", b_listcotmoi = "SO_THE,HO_TEN,TEN_CDANH,TEN_PHONG" }
        hts_dungchung.Fs_THONGTIN_CANBO_HD(b_so_the, b_listcotcu, b_listcotmoi, ns_thongtin_canbo_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_thongtin_canbo_kq(b_kq) {
    if (b_kq == "") {
        if (b_kt_loai == "SO_THE" || b_kt_loai == "") {
            form_P_MOI(b_vungId, "GXL"); $get(b_gocId).focus(); form_P_LOI(b_kq); return false;
        } else if (b_kt_loai == "MA_NGUOIKY") {
            $get(b_ma_nguoikyId).value = ""; $get(b_ten_cdanhnkId).value = "";
        }

    }
    form_P_CH_TEXT(b_vungId, b_kq);

    // lay du lieu bieu mau chi phi len theo ngay hieu luc
    var b_ngayhd = $get(b_ngaydId).value;
    stl_ma.Fs_NS_TL_TLAP_TYLE_HOAHONG_DR(window.name, "DT_CHIPHI", b_ngayhd);
    return false;
}
function ns_hd_pl_tinh_thuongkq() {
    if (CSO_SO($get(b_tienId).value) >= CSO_SO($get(b_tien_lcbId).value)) {
        $get(b_luonghtId).value = SO_CSO(CSO_SO($get(b_tienId).value) - CSO_SO($get(b_tien_lcbId).value));
    }
    else $get(b_luonghtId).value = 0;
}
function ktra_ngaykt(denngay) {
    if (b_ngayd_hdct == "" || b_ngayd_hdct == null || denngay == "" || denngay == null) {
        return "";
    }
    else {
        var b_ngaykt_pl = addDays(b_ngayd_hdct, 36);
        if (denngay > parseDate(b_ngaykt_pl).getTime()) {
            return "loi:Ngày kết thúc phụ lục hợp đồng vượt quá 36 tháng so với ngày hiệu lực của hợp đồng chính:loi";
        }
    }
    return "";
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
function ktra_ngay(tungay, denngay, loai, ten1, ten2) {
    if (denngay == "" || denngay == null) {
        return "";
    }
    if (loai == 1 && tungay > denngay) {
        return "loi: " + ten1 + " không được lớn hơn " + ten2 + " :loi";
    } else if (loai == 2 && tungay >= denngay) {
        return "loi: " + ten1 + " không được lớn hơn hoặc bằng " + ten2 + " :loi";
    }
    return "";
}
function parseDate(str) {
    var mdy = str.split('/');
    return new Date(mdy[2], mdy[1], mdy[0]);
}
function addDays(date, days) {
    date = date.substring(6, 10) + "-" + date.substring(3, 5) + "-" + date.substring(0, 2);
    var result = new Date(date);
    result.setMonth(result.getMonth() + Number(days));
    result.setDate(result.getDate() - Number(1));
    var kq = NG_CNG(result);
    return kq;
}
function form_dong() {
    location.reload(false);
}
