var ns_hd_lkeCho, b_vungId, b_grlkeId, b_grctId, b_vungtkId, b_slideId, b_slideIdct, b_gocId, b_gchuId, b_so_idId, b_alhdId, b_moiId, b_doi = 0, b_ten_cb, b_so_hdId, b_hddauId, b_thangluongId, b_ngachId, b_bacId, b_so_qdId,
    b_tien_lcbId, b_tien_tdgtId, b_tienbhId, b_tien_tnsId, b_phantram_luongId, b_ten_cbId, b_ngaydId, b_ngaycId, b_lhdId, b_ngaykId, b_tienId, b_dongiaId, b_goctkId, b_ten_tkId, b_phong_tkId, b_vungnhId,
    b_nghi_viec_tkId, b_ma_nguoikyId, b_cho_control = 0, ns_hd_choAct = 0, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C', b_luonghtId, b_tratheoId, b_trangthai, b_ngay_tlId, b_chonId,
    b_ten_cdanhnkId, b_kt_loai, b_lblChonId, b_cdanh_Id, b_nsd, b_an_mopdId, b_lhd_Idtk, b_ngayd_Idtk, b_chon_allId, b_ctyValue, b_ngayc_Idtk, b_ctrbeforId, a_so_idId, b_alhd_tk, b_aphongId, b_atrangthaiId;
function ns_hd_P_KD(b_tm) {
    var a_kq = Fas_ChMang(b_tm, ',');
    b_nsd = a_kq[1];
    ns_hd_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
        b_vungtkId = form_Fs_VUNG_ID('UPa_tk'), b_tmf = a_kq[0], b_vungnhId = form_Fs_VUNG_ID('UPa_nhap');
    b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE'), b_so_hdId = form_Fs_TEN_ID(b_vungId, 'so_hd'), b_ten_cbId = form_Fs_TEN_ID(b_vungId, 'ho_ten'),
        b_hddauId = form_Fs_TEN_ID(b_vungId, 'hddau'), b_so_qdId = form_Fs_TEN_ID(b_vungId, 'so_qd'), b_ma_nguoikyId = form_Fs_TEN_ID(b_vungId, 'ma_nguoiky'),
        b_lhdId = form_Fs_TEN_ID(b_vungId, 'LHD'), b_ngaydId = form_Fs_TEN_ID(b_vungId, 'NGAYD'), b_ngaycId = form_Fs_TEN_ID(b_vungId, 'ngayc'),
        b_lhd_Idtk = form_Fs_TEN_ID(b_vungtkId, 'lhd_tk'), b_ngayd_Idtk = form_Fs_TEN_ID(b_vungtkId, 'ngayd_tk'),
        b_ngayc_Idtk = form_Fs_TEN_ID(b_vungtkId, 'ngayc_tk'), b_trangthai_Idtk = form_Fs_TEN_ID(b_vungtkId, 'trangthai_tk'), b_atrangthaiId = form_Fs_VTEN_ID('UPa_hi', 'atrangthai_tk'),
        b_ngaykId = form_Fs_TEN_ID(b_vungId, 'ngay_ky'), b_thangluongId = form_Fs_TEN_ID(b_vungId, 'ma_tl'), b_ngachId = form_Fs_TEN_ID(b_vungId, 'ma_nl'), a_so_idId = form_Fs_VTEN_ID('UPa_hi', 'a_so_id'),
        b_bacId = form_Fs_TEN_ID(b_vungId, 'ma_bl'), b_tien_lcbId = form_Fs_TEN_ID(b_vungId, 'luongcb'), b_tien_tdgtId = form_Fs_TEN_ID(b_vungId, 'tien_tdgt'),
        b_tienbhId = form_Fs_TEN_ID(b_vungId, 'tienbh'), b_tien_tnsId = form_Fs_TEN_ID(b_vungId, 'tien_tns'), b_phantram_luongId = form_Fs_TEN_ID(b_vungId, 'phantram_luong'),
        b_tratheoId = form_Fs_TEN_ID(b_vungId, 'tratheo'), b_aphongId = form_Fs_VTEN_ID('UPa_hi', 'aphong_tk'), b_ngay_tlId = form_Fs_TEN_ID(b_vungId, 'ngay_tl'), b_ten_cdanhnkId = form_Fs_TEN_ID(b_vungId, 'ten_cdanh_nguoiky'),
        b_tienId = form_Fs_TEN_ID(b_vungId, 'luong'), b_dongiaId = form_Fs_TEN_ID(b_vungId, 'dongia'), b_goctkId = form_Fs_TEN_ID(b_vungtkId, 'so_the_tk'), b_ten_tkId = form_Fs_TEN_ID(b_vungtkId, 'ten_tk'), b_alhd_tk = form_Fs_VTEN_ID('UPa_hi', 'alhd_tk'),
        b_phong_tkId = form_Fs_TEN_ID(b_vungtkId, 'phong_tk'), b_nghi_viec_tkId = form_Fs_TEN_ID(b_vungtkId, 'nghi_viec_tk'), b_luonghtId = form_Fs_TEN_ID(b_vungId, 'luonght');
    b_atluongId = form_Fs_VTEN_ID('UPa_hi', 'atluong'), b_ntluongId = form_Fs_VTEN_ID('UPa_hi', 'anluong'), b_abluongId = form_Fs_VTEN_ID('UPa_hi', 'abluong'),
        b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'), b_alhdId = form_Fs_VTEN_ID('UPa_hi', 'alhd'), b_lblChonId = form_Fs_VUNG_ID('lblChonSqd'), b_chon_allId = form_Fs_VTEN_ID('UPa_hi', 'acheckall'),
        b_gchuId = form_Fs_VTEN_ID('', 'gchu'), b_cdanh_Id = form_Fs_TEN_ID(b_vungId, 'CDANH'); b_an_mopdId = form_Fs_VUNG_ID('an_mopd');
    b_moiId = form_Fs_VTEN_ID('', 'moi');
    b_slideId = b_grlkeId + '_slide', b_slideIdct = $get(b_grctId).getAttribute('slideId');
    //lke_P_DAT($get(b_phong_tkId), 'TATCA' + '{' + 'Tất cả');
    lke_P_DAT($get(b_lhd_Idtk), 'TATCA' + '{' + 'Tất cả');
    var b_tratheo = form_Fctr_TEN_DTUONG(b_vungId, 'tratheo');
    list_P_DAT(b_tratheo, 'TH');
    ns_hd_lkeCho = setInterval('ns_hd_P_LKE_CHO()', 200);
    $get(b_so_qdId).style.display = "none"; $get(b_lblChonId).style.display = "none";
    ns_hd_P_NPA($get(b_hddauId).value);
    checkquen_mopd(b_nsd);
}
function checkquen_mopd(b_nsd) {
    if (b_nsd.indexOf("ADMIN") >= 0) {
        $get(b_an_mopdId).style.display = "";
    } else {
        $get(b_an_mopdId).style.display = "none";
    }
}

// Kiểm tra
function ns_hd_P_NPA(b_nv) {
    if (b_nv == "X") {
        $get(b_lblChonId).style.display = "none";
        $get(b_so_qdId).style.display = "none";
        document.getElementById(b_so_qdId).disabled = true;
        document.getElementById(b_thangluongId).disabled = false;
        document.getElementById(b_ngachId).disabled = false;
        document.getElementById(b_bacId).disabled = false;
        document.getElementById(b_tien_lcbId).disabled = false;
        document.getElementById(b_tien_tdgtId).disabled = false;
        document.getElementById(b_tienbhId).disabled = false;
        document.getElementById(b_tien_tnsId).disabled = false;
        document.getElementById(b_phantram_luongId).disabled = false;
        document.getElementById(b_tienId).disabled = false;
    }
    else {
        //$get(b_lblChonId).style.display = "";
        //$get(b_so_qdId).style.display = "";
        //document.getElementById(b_so_qdId).disabled = false;
        //document.getElementById(b_thangluongId).disabled = true;
        //document.getElementById(b_ngachId).disabled = true;
        //document.getElementById(b_bacId).disabled = true;
        //document.getElementById(b_tien_lcbId).disabled = true;
        //document.getElementById(b_tien_tdgtId).disabled = true;
        //document.getElementById(b_tienbhId).disabled = true;
        //document.getElementById(b_tien_tnsId).disabled = true;
        //document.getElementById(b_phantram_luongId).disabled = true;
        //document.getElementById(b_tienId).disabled = true;

        // Không dùng chức năng chọn từu quyết định
        $get(b_lblChonId).style.display = "none";
        $get(b_so_qdId).style.display = "none";
        document.getElementById(b_so_qdId).disabled = true;
        document.getElementById(b_thangluongId).disabled = false;
        document.getElementById(b_ngachId).disabled = false;
        document.getElementById(b_bacId).disabled = false;
        document.getElementById(b_tien_lcbId).disabled = false;
        document.getElementById(b_tien_tdgtId).disabled = false;
        document.getElementById(b_tienbhId).disabled = false;
        document.getElementById(b_tien_tnsId).disabled = false;
        document.getElementById(b_phantram_luongId).disabled = false;
        document.getElementById(b_tienId).disabled = false;
    }
}
function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_goctkId).value = b_so_the;
            $get(b_gchuId).innerHTML = b_ten;
            $get(b_gocId).focus();
            ns_hd_P_LKE('K');
            b_doi = 1;
            clearTimeout(b_cho_control);
            b_ten_cb = b_ten;
        }
    }
    catch (err) { b_doi = 0; }
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "" || a_tso[0] == "FILE_HTOAN") return;
        b_dtuong = b_dtuong.toUpperCase();
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[0];
        var b_hso = a_tso[1];
        b_doi = 0;
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
            ns_thongtin_canbo(a_tso[0], "SO_THE");
            ns_hd_P_NGAYKETTHUC();
            document.getElementById(b_goctkId).disabled = true;
            document.getElementById(b_ten_tkId).disabled = true;
            document.getElementById(b_phong_tkId).disabled = true;
            document.getElementById(b_nghi_viec_tkId).disabled = true;
            $get(b_ma_nguoikyId).setAttribute("placeholder", "Nhấn dấu cách");
        } else if (b_dtuong.indexOf("SO_THE") >= 0) {
            ns_thongtin_canbo(a_tso[0], "SO_THE");
        } else if (b_dtuong.indexOf("MA_NGUOIKY") >= 0) {
            ns_thongtin_canbo(a_tso[0], "MA_NGUOIKY");
        } else if (b_dtuong.indexOf("SO_QD") >= 0) {
            ns_hd_thongtin_qd(a_tso[1]);
        } else if (b_dtuong.indexOf("MA_NTE") >= 0) {
            $get(b_ma_nteId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_ma_nteId).focus();
        } else if (b_dtuong.indexOf("MA_TL") >= 0) {
            $get(b_thangluongId).value = ""; $get(b_ngachId).value = ""; $get(b_bacId).value = "";
            $get(b_tienId).value = ""; $get(b_tien_lcbId).value = ""; $get(b_luonghtId).value = "";

            $get(b_thangluongId).value = b_kq;
            $get(b_atluongId).value = a_tso[1];
            $get(b_gchuId).innerHTML = a_tso[1];
        }
        else if (b_dtuong.indexOf("MA_NL") >= 0) {
            $get(b_ngachId).value = ""; $get(b_bacId).value = "";
            $get(b_tienId).value = ""; $get(b_tien_lcbId).value = ""; $get(b_luonghtId).value = "";

            $get(b_ngachId).value = b_kq;
            $get(b_ntluongId).value = a_tso[1];
            $get(b_gchuId).innerHTML = a_tso[1];
        }
        else if (b_dtuong.indexOf("MA_BL") >= 0) {
            $get(b_bacId).value = "";
            $get(b_tienId).value = ""; $get(b_tien_lcbId).value = ""; $get(b_luonghtId).value = "";

            $get(b_bacId).value = b_kq;
            $get(b_tienId).value = a_tso[1];
            $get(b_tien_lcbId).value = a_tso[2];
            $get(b_luonghtId).value = a_tso[3];
        }
        else if (b_dtuong.indexOf("NS_HD_TL") >= 0) {
            ns_hd_P_LKE('K');
        }
        else if (b_dtuong.indexOf("CHITIET_HD") >= 0) {
            // b_cho_control = setInterval("P_cho2('" + a_tso[0] + "')", 200);
            ns_hd_P_CHITIET_HD(a_tso[0]);
            return false;
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
                GridX_datGtri(b_grctId, b_hang, ["sotien"], [a_tso[i][2]], 'K');
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
function ns_hd_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; form_P_MOI("", "XL"); break;
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
            //$get(b_thangluongId).value = ""; $get(b_ngachId).value = ""; $get(b_bacId).value = "";
            //$get(b_tien_lcbId).value = ""; $get(b_tienId).value = ""; $get(b_luonghtId).value = "";
            ns_hd_P_NPA(b_hhdau);
        }
        if (b_ma == null || C_NVL(b_ma.value) == "") return;

        if (b_maTen == "SO_THE") {
            //ns_hd_P_LKE(); 
            ns_thongtin_canbo($get(b_maId).value, b_maTen);
            ns_hd_P_CHITIET_HD($get(b_maId).value);
        } else if (b_maTen == "MA_NGUOIKY") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_hd_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
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
            sns_ma_ch.Fs_NS_HDNS_MA_BL_BYID(form_Fs_nsd(), window.name, b_ma_bl, ns_hd_ma_bl_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        } else if (b_maTen = "SO_QD") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_hd_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_hd_thongtin_qd_byma(b_ma.value);
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_hd_ma_bl_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    $get(b_tien_lcbId).value = SO_CSO(a_kq[0]);
    ns_hd_tinh_thuongkq();
}
function ns_hd_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        if (b_chonId == "SO_THE") { $get(b_gocId).value = ""; $get(b_gocId).focus(); }
        else if (b_chonId == "MA_NGUOIKY") { $get(b_ma_nguoikyId).value = ""; $get(b_ten_cdanhnkId).value = ""; $get(b_ma_nguoikyId).focus(); }
        else if (b_chonId == "SO_QD") {
            $get(b_so_qdId).value = ""; $get(b_thangluongId).value = ""; $get(b_ngachId).value = ""; $get(b_bacId).value = "";
            $get(b_tienId).value = ""; $get(b_tien_lcbId).value = ""; $get(b_luonghtId).value = ""; $get(b_so_qdId).focus();
        }
        else if (b_chonId == "MA_TL") {
            $get(b_thangluongId).focus();
            $get(b_thangluongId).value = ""; $get(b_ngachId).value = ""; $get(b_bacId).value = "";
            $get(b_tienId).value = ""; $get(b_tien_lcbId).value = ""; $get(b_luonghtId).value = "";
        }
        else if (b_chonId == "MA_NL") {
            $get(b_ngachId).focus();
            $get(b_ngachId).value = ""; $get(b_bacId).value = "";
            $get(b_tienId).value = ""; $get(b_tien_lcbId).value = ""; $get(b_luonghtId).value = "";
        }
        else if (b_chonId == "MA_BL") {
            $get(b_bacId).focus();
            $get(b_bacId).value = "";
            $get(b_tienId).value = ""; $get(b_tien_lcbId).value = ""; $get(b_luonghtId).value = "";
        }
    } else form_P_DatGchu(b_gchuId, b_kq);
}
// Mở chờ phê duyệt
function ns_hd_P_PHEDUYET(b_kq) {

    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
        b_so_the_tk = $get(b_goctkId).value, b_ten_tk = $get(b_ten_tkId).value, b_phong_tk = lke_Fs_TRA($get(b_phong_tkId)), b_nghi_viec_tk = $get(b_nghi_viec_tkId).value, b_lhd = lke_Fs_TRA($get(b_lhd_Idtk)), b_ngayd = $get(b_ngayd_Idtk).value, b_ngayc = $get(b_ngayc_Idtk).value,
        b_trangthai = form_Fs_TEN_GTRI(b_vungtkId, 'trangthai_tk'),
        b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")), b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ttr")), b_so_the = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the"));

    if (b_hang < 1 || b_so_id == "") { form_P_LOI("loi:Chọn 1 bản ghi để mở phê duyệt:loi"); return false; }
    if (b_trangthai == "CPD") { form_P_LOI("loi:Bản ghi đang ở trạng thái chờ phê duyệt:loi"); return false; }
    var message = confirm("Bạn có chắc chắn muốn mở phê duyệt?");
    if (message == false) { return false; }
    sns_qt.Fs_NS_HD_MO_CHOPD(form_Fs_nsd(), b_so_id, b_so_the, b_lhd, b_ngayd, b_ngayc, b_trangthai, b_so_the_tk, b_ten_tk, b_ctyValue, b_nghi_viec_tk, a_cot, a_tso, ns_hd_P_PHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_hd_P_PHEDUYET_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    form_P_LOI("loi:Mở phê duyệt thành công:loi");
    return false;
}

// Nhập
function ns_hd_P_MOI() {
    form_P_MOI(b_vungId, "GXLK");
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = "0"; $get(b_phantram_luongId).value = "100";
    $get(b_gocId).focus();
    $get(b_lhdId).value = "";
    $get(b_hddauId).value = "";
    var b_tratheo = form_Fctr_TEN_DTUONG(b_vungId, 'tratheo');
    list_P_DAT(b_tratheo, 'TH');
    return false;
}
function ns_hd_P_NH(b_thaotac) {
    try {
        var ktra = ktra_ngay(parseDate($get(b_ngaydId).value).getTime(), parseDate($get(b_ngaycId).value).getTime(), 1, "Từ ngày", "đến ngày");
        if (ktra.length > 0) {
            ns_hd_P_NH_KQ(ktra);
            return false;
        }
        var dateNow = getDateNow();
        var ktraky = ktra_ngay(parseDate($get(b_ngaykId).value).getTime(), parseDate(dateNow).getTime(), 1, "Ngày ký", "ngày hiện tại");
        if (ktraky.length > 0) {
            ns_hd_P_NH_KQ(ktraky);
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
            // ns_ma_khungluong_check(); 
            var a_dt = form_Faa_TEXT_ROW(b_vungId), b_so_id = $get(b_so_idId).value, b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var b_so_the = $get(b_goctkId).value, b_ten = $get(b_ten_tkId).value, b_lhd = lke_Fs_TRA($get(b_lhd_Idtk)), b_ngayd = $get(b_ngayd_Idtk).value, b_ngayc = $get(b_ngayc_Idtk).value, b_trangthai_tk = form_Fs_TEN_GTRI(b_vungtkId, 'trangthai_tk');
            b_phong = lke_Fs_TRA($get(b_phong_tkId)), b_nghi_viec = $get(b_nghi_viec_tkId).value, a_tso = slide_Faobj_TUDEN(b_slideId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            var a_dt_ct = GridX_Fdt_cotGtri(b_grctId);
            if (b_thaotac == "P") {
                sns_qt.Fs_NS_HD_PD(b_so_id, a_dt, a_dt_ct, b_lhd, b_ngayd, b_ngayc, b_trangthai_tk, b_so_the, b_ten, b_ctyValue, b_nghi_viec, b_TrangKt, a_cot, ns_hd_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            } else {
                sns_qt.Fs_NS_HD_NH(b_so_id, a_dt, a_dt_ct, b_lhd, b_ngayd, b_ngayc, b_trangthai_tk, b_so_the, b_ten, b_ctyValue, b_nghi_viec, b_TrangKt, a_cot, ns_hd_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }

        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_hd_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
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

// Xóa
function ns_hd_P_XOA() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_hang < 1 || b_so_id == "") { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    else {
        b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ttr"));
        if (b_trangthai == 'PD') { form_P_LOI('loi:Bản ghi đang ở trạng thái phê duyệt, không thể xóa:loi'); return false; }
        //if (b_trangthai == 'KPD') { form_P_LOI('loi:Bản ghi đang ở trạng thái không phê duyệt, không thể xóa:loi'); return false; }

        var b_so_the = $get(b_goctkId).value, b_ten = $get(b_ten_tkId).value, b_lhd = lke_Fs_TRA($get(b_lhd_Idtk)), b_ngayd = $get(b_ngayd_Idtk).value, b_ngayc = $get(b_ngayc_Idtk).value, b_trangthai_tk = form_Fs_TEN_GTRI(b_vungtkId, 'trangthai_tk'),
            b_phong = lke_Fs_TRA($get(b_phong_tkId)), b_nghi_viec = $get(b_nghi_viec_tkId).value, a_tso = slide_Faobj_TUDEN(b_slideId), a_cot = GridX_Fas_tenCot(b_grlkeId);
        sns_qt.Fs_NS_HD_XOA(b_so_id, b_lhd, b_ngayd, b_ngayc, b_trangthai_tk, b_so_the, b_ten, b_ctyValue, b_nghi_viec, a_cot, a_tso, ns_hd_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_hd_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_hd_P_MOI();
        else {
            GridX_datA(b_grlkeId, b_hang); ns_hd_P_CHUYEN_HANG();
        }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
}
// Chuyển hàng
function ns_hd_GR_lke_RowChange() {
    if (ns_hd_choAct != 0) clearTimeout(ns_hd_choAct);
    ns_hd_choAct = setTimeout("ns_hd_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_hd_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")); var a_cot_pc = GridX_Fas_tenCot(b_grctId);
    if (b_so_id == "0" || b_so_id == "") {
        form_P_MOI("", "XGL");
        GridX_datTrang(b_grctId); slide_P_SOTRANG(b_slideIdct, 0);
    }
    else sns_qt.Fs_NS_HD_CT(window.name, form_Fs_nsd(), b_so_id, a_cot_pc, ns_hd_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = b_so_id;
}
function ns_hd_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[1]);
    if (a_kq[3] == "") GridX_datTrang(b_grctId); else { slide_P_SOTRANG(b_slideIdct, CSO_SO(a_kq[2], 0)); GridX_datBang(b_grctId, a_kq[3]); }
    ns_hd_P_KTRA('HDDAU');
    //ns_thongtin_canbo($get(b_gocId).value, "SO_THE");
    ns_thongtin_canbo($get(b_ma_nguoikyId).value, "MA_NGUOIKY");
    // đẩy loại hợp đồng vào biến ẩn để phụ vụ chức năng in hợp đồng
    $get(b_alhdId).value = lke_Fs_TRA($get(b_lhdId));
}
// Liệt kê
function ns_hd_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ns_hd_lkeCho != 0) clearTimeout(ns_hd_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        form_F_GOC().P_MENUBf(window.name, 'M');
        vb_cctc_P_SL('', 'D', '0', ' ', ' ', 'T');
        b_ctyValue = "TATCA";
        ns_hd_P_LKE('K');
    }
}
function ns_hd_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), b_so_the = $get(b_gocId).value;
        var b_so_the = $get(b_goctkId).value, b_ten = $get(b_ten_tkId).value, b_lhd = lke_Fs_TRA($get(b_lhd_Idtk)), b_ngayd = $get(b_ngayd_Idtk).value, b_ngayc = $get(b_ngayc_Idtk).value, b_trangthai = form_Fs_TEN_GTRI(b_vungtkId, 'trangthai_tk'),
            b_phong = lke_Fs_TRA($get(b_phong_tkId)), b_nghi_viec = $get(b_nghi_viec_tkId).value, a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_qt.Fs_NS_HD_LKE(b_lhd, b_ngayd, b_ngayc, b_trangthai, b_so_the, b_ten, b_ctyValue, b_nghi_viec, a_cot, a_tso, ns_hd_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hd_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}

function ns_hd_hoi_NGH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == "") { alert("Chưa đăng ký mã ngạch trong nhóm ngạch này!"); $get(b_ngachId).value = ""; $get(b_ngachId).focus(); }
    else {
        var a_kq = b_kq.split("#");
        $get(b_gchuId).innerHTML = a_kq[1];
    }
}
function ns_hd_hoi_NGBAC_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq != "") {
        $get(b_hsoId).value = b_kq; $get(b_hsoId).focus();
    }
}
function ns_hd_hoi_CDANH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == "") { alert("Chưa đăng ký mã chức danh trong nhóm chức danh này!"); $get(b_cdanhId).value = ""; $get(b_cdanhId).focus(); }
    else {
        var a_kq = b_kq.split("#");
        $get(b_gchuId).innerHTML = a_kq[1];
    }
    return false;
}
function ns_hd_hoi_BCD_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq != "") {
        $get(b_hscdId).value = b_kq; $get(b_hscdId).focus();
    }
}
function ns_hd_hoi_cvu_KQ(b_kq) {
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
function ns_hd_P_BIEUMAU() {
    var a_so_id = "";
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_lhd = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "lhd"));

    $get(b_alhdId).value = b_lhd;

    var b_btn_excel = form_Fs_VTEN_ID('', 'msword');
    $get(b_btn_excel).click(); form_chay = 0;
    form_P_LOI('');
    return false;
}
function ns_hd_P_TL() {
    try {
        var b_tenf = b_tmf + '/ns/qt/ns_hd_tl.aspx';
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = $get(b_so_idId).value;
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_so_id == "" || b_hang < 1) {
            form_P_LOI("loi:Bạn phải chọn 1 hợp đồng để thanh lý:loi");
            return false;
        } else {
            b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ttr"));
            if (b_trangthai == 'CPD') { form_P_LOI('loi:Bản ghi đang ở trạng thái chờ phê duyệt, không thể thanh lý:loi'); return false; }
            if (b_trangthai == 'KPD') { form_P_LOI('loi:Bản ghi đang ở trạng thái không phê duyệt, không thể thanh lý:loi'); return false; }

            var ten_cb = GridX_Fas_layGtri(b_grlkeId, b_hang, "ten");
            var so_the = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the");
            var ngay_tl = GridX_Fas_layGtri(b_grlkeId, b_hang, "ngay_tl");
            var ngayd = $get(b_ngaydId).value, ngayc = $get(b_ngaycId).value;
            form_P_MO(b_tenf, window.name, ["THAMSO", ["NS,TL,Thanh lý hợp đồng," + b_so_id + "," + so_the + "," + ten_cb + "," + ngayd + "," + ngayc + "," + ngay_tl + ""]], null);
            return false;
        }

    }
    catch (err) { form_P_LOI(err); }
}
function ns_hd_P_PL() {
    try {
        var b_tenf = b_tmf + '/ns/qt/ns_hd_pl.aspx';
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = $get(b_so_idId).value;
        if (b_so_id == "" || b_hang < 1) {
            form_P_LOI("loi:Bạn phải chọn 1 hợp đồng để làm phụ lục:loi");
            return false;
        } else {
            b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ttr"));
            if (b_trangthai == 'KPD') { form_P_LOI('loi:Bản ghi đang ở trạng thái không phê duyệt, không thể làm phụ lục:loi'); return false; }

            var b_so_hdId = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_hd"), b_so_the = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the"), b_ten = GridX_Fas_layGtri(b_grlkeId, b_hang, "ten");
            form_P_MO(b_tenf, "ns_hd_pl", ["THAMSO", [b_so_hdId, b_so_the, b_ten]], "K");
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hd_CHECK_TONTAI_KQ(b_kq) {
    if (b_kq > 0) {
        form_P_LOI("loi:Tồn tại hợp đồng có cùng thời gian hiệu lực:loi");
        return false;
    } else {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), b_so_id = $get(b_so_idId).value;
            sns_qt.Fs_NS_HD_NH(b_so_id, a_dt_ct, ns_hd_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
}
function ns_hd_P_NGAYKETTHUC() {
    try {
        var b_ma_lhd = form_Fs_TEN_GTRI(b_vungId, 'lhd');
        var b_ngayhd = $get(b_ngaydId).value;
        ns_hd_P_DONGIA();
        // lay du lieu bieu mau chi phi len theo ngay hieu luc
        stl_ma.Fs_NS_TL_TLAP_TYLE_HOAHONG_DR(window.name, "DT_CHIPHI", b_ngayhd);
        var b_so_the = form_Fs_TEN_GTRI(b_vungId, 'so_the'); b_so_id = $get(b_so_idId).value;
        sns_ma_ch.Fs_NS_MA_LHD_SOTHANG(b_ngayhd, b_ma_lhd, b_so_the, b_so_id, ns_hd_P_NGAYKETTHUC_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_hd_P_NGAYKETTHUC_KQ(b_kq) {
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

function ns_hd_P_DONGIA() {
    try {
        var b_ngayhd = $get(b_ngaydId).value;
        var b_so_the = $get(b_gocId).value;
        sns_qt.Fs_NS_THONGTIN_DONGIA(b_so_the, b_ngayhd, ns_hd_P_DONGIA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_hd_P_DONGIA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        $get(b_dongiaId).value = b_kq;
    }
}


function nhap_file() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1 || $get(b_gocId).value == "") {
        form_P_LOI('loi:Bạn phải chọn 1 bản ghi:loi')
        return false;
    }
    var b_so_the = $get(b_gocId).value;
    var b_tenf = '/App_form/ns/ma/file_Import_chung.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, b_so_the, "NS_HD", "Import dữ liệu - Hợp đồng"]], null);
    form_P_LOI('');
    return false;

}

function ns_hd_Export() {
    __doPostBack('ctl00$ContentPlaceHolder1$xuatfilemau', '');
}
function ns_hd_Import() {
    var b_tenf = '/App_form/ns/ma/file_Import.aspx';
    form_P_MO(b_tenf, window.name + ',THAMSO', ['THAMSO', [window.name, 'NS_HD', null, "Import thông tin hợp đồng"]], null);
    form_P_LOI('');
    return false;
}
// Chuyển hàng lên xuống trên grid
function ns_hd_P_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_hd_P_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_hd_P_chenDong(b_dk) {
    var b_hang = GridX_Fi_timHangA(b_grctId);
    if (b_hang < 1) return;
    GridX_chenHang(b_grctId, b_hang, 1);
    return false;
}
function ns_hd_P_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}

function ns_hd_thongtin_qd(b_so_id) {
    try {
        sns_qt.Fs_THONGTIN_QD(b_so_id, ns_hd_thongtin_qd_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hd_thongtin_qd_kq(b_kq) {
    if (b_kq == "") { $get(b_gocId).focus(); form_P_LOI(b_kq); return false; }
    form_P_CH_TEXT(b_vungId, b_kq);
    ns_hd_P_KTRA('HDDAU');
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
function ns_hd_thongtin_qd_byma(b_ma) {
    try {
        sns_qt.Fs_THONGTIN_QD_BYMA(b_ma, ns_hd_thongtin_qd_byma_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hd_thongtin_qd_byma_kq(b_kq) {
    if (b_kq == "") { $get(b_gocId).focus(); form_P_LOI(b_kq); return false; }
    form_P_CH_TEXT(b_vungId, b_kq);
    ns_hd_P_KTRA('HDDAU');
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}

function ns_thongtin_canbo(b_so_the, b_loai) {
    try {
        if (b_so_the == "") return false;
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


    var b_phong = form_Fs_TEN_GTRI(b_vungId, 'phong');
    hts_dungchung.Fs_NS_CB_PHONG_CDANH('ns_hd', b_phong);

    // lay du lieu bieu mau chi phi len theo ngay hieu luc
    var b_ngayhd = $get(b_ngaydId).value;
    stl_ma.Fs_NS_TL_TLAP_TYLE_HOAHONG_DR(window.name, "DT_CHIPHI", b_ngayhd);

    return false;
}
function ns_hd_tinh_thuongkq() {
    if (CSO_SO($get(b_tienId).value) >= CSO_SO($get(b_tien_lcbId).value)) {
        $get(b_luonghtId).value = SO_CSO(CSO_SO($get(b_tienId).value) - CSO_SO($get(b_tien_lcbId).value));
    }
    else $get(b_luonghtId).value = 0;
}
function ns_hd_P_IN() {
    $get(b_alhd_tk).value = lke_Fs_TRA($get(b_lhd_Idtk));
    $get(b_aphongId).value = b_ctyValue;
    $get(b_atrangthaiId).value = form_Fs_TEN_GTRI(b_vungtkId, 'trangthai_tk');
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap3');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
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

// Kiểm tra xem thu nhập tháng có nằm trong khu lương theo chức danh hay không.
function ns_ma_khungluong_check() {
    try {
        var b_ngayd = $get(b_ngaydId).value, b_cdanh = $get(b_cdanh_Id).value, b_tongthunhap = $get(b_tienId).value;
        sns_ma_ch.Fs_NS_MA_KHUNGLUONG_CHECK(form_Fs_nsd(), b_ngayd, b_cdanh, b_tongthunhap, ns_ma_khungluong_check_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_khungluong_check_KQ(b_kq) {
    if (CSO_SO(b_kq) == 0) {
        form_P_LOI("loi:Thu nhập tháng không nằm trong khung lương theo chức danh:loi");
    }
}

function ns_hd_P_CHITIET_HD(b_kq) {
    var b_ma_nv = b_kq;
    sns_qt.Fs_NS_CHITIET_HD_CT(window.name, form_Fs_nsd(), b_ma_nv, ns_hd_P_CHITIET_HD_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_hd_P_CHITIET_HD_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    ns_hd_P_KTRA('HDDAU');
    //ns_thongtin_canbo($get(b_gocId).value, "SO_THE");
    ns_thongtin_canbo($get(b_ma_nguoikyId).value, "MA_NGUOIKY");
    // đẩy loại hợp đồng vào biến ẩn để phụ vụ chức năng in hợp đồng
    $get(b_alhdId).value = lke_Fs_TRA($get(b_lhdId));
    return false;
}

function CheckAll(oCheckbox) {
    if (oCheckbox.checked == true) {
        $get(b_chon_allId).value = 'TATCA';
        for (i = 1; i < 16; i++) {
            var b_so_the = C_NVL(GridX_Fas_layGtri(b_grlkeId, i, "so_the"));
            if (b_so_the != "") GridX_datGtri(b_grlkeId, i, ["chon"], ['X'], 'K');
        }
    } else {
        for (i = 1; i < 16; i++) {
            GridX_datGtri(b_grlkeId, i, ["chon"], [''], 'K');
        }
    }
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
        ns_hd_P_LKE('K'); return false;
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