var ns_hdct_lkeCho, b_vungId, b_vungtkId, b_grlkeId, b_slideId, b_gocId, b_goctkId, b_tenId, b_ten_tkId, b_phong_tkId, b_nghi_viec_tkId, b_so_the_tkId, b_ten_tkId, b_phong_tkId,
    b_nghi_viec_tkId, b_gchuId, b_nguoiky_qdId, b_ngay_adId, b_ngay_ktId, b_moiId, b_doi = 0, b_fdtuong, a_ftso, b_fcho = 'C', b_phong_mId, b_hinhthucId, b_cdanh_mId, b_ten_phongId,
    b_ngaydId, b_ngaycId, b_ten_cdanhId, b_phong_Id, b_cdanh_Id, b_so_qdId, b_anttc1Id, b_anttc2Id, b_cho_control = 0, ns_hdct_choAct = 0, b_fileId, b_tenmanhinhId,
    b_loi = 0, b_nhapId, b_hangchon, b_chonId, b_chongt, b_moiId, b_xoaId, b_tthaiId, b_vungnhId, b_atluongId, b_atencdanhId, b_ntluongId, b_abluongId, b_ngay_kyQdId, b_ma_blId,
    b_ma_tlcId, b_ten_tlcId, b_ma_nlcId, b_ten_nlcId, b_ma_blcId, b_ten_blcId, b_luongcb_cId, b_thunhapthang_cId, b_thuong_ketqua_cId, b_pt_huongluong_cId,
    b_dongia_cId, b_tyle_hoahong_cId, b_tyle_hoahong_theophi_cId,
    b_ma_tlId, b_ma_nlId, b_ma_blId, b_luongcbId, b_thunhapthangId, b_thuong_ketquaId, b_pt_huongluongId, b_dongiaId, b_tyle_hoahongId, b_tyle_hoahong_theophiId,
    b_grlkePCId, b_trangthai, b_an_title_bonhiemId, b_an_title_miennhiemId, b_an_title_dieuchuyenId, b_an_title_tiepnhanId, b_an_ngayhl_bonhiemId, b_an_phong_cdanh_bonhiemId, b_an_cdanh_miennhiemId,
    b_an_title_luonghtId, b_an_thang_ngach_htId, b_an_bac_luong_htId, b_an_luongcb_htId, b_an_pt_huongluong_htId, b_an_tyle_hoahong_htId,
    b_an_title_luongtdId, b_an_thang_ngach_tdId, b_an_bac_luong_tdId, b_aphongId, b_atrangthaiId, b_an_luongcb_tdId, b_an_pt_huongluong_tdId, b_an_tyle_hoahong_tdId,
    b_loai_qd_tkId, b_chon_allId, a_so_idId, b_tungay_tkId, b_denngay_tkId, b_trangthai_tkId, b_an_mopdId, b_ma_nguoikyId, b_ten_cdanh_nguoikyId, b_alqdinhId,
    b_nsd, b_choAct = 0, b_ctyId, b_ctyValue, b_ctrbeforId;
// kiểm tra
function ns_hdct_P_KD(b_tm) {
    var a_kq = Fas_ChMang(b_tm, ',');
    b_nsd = a_kq[1]; b_tmf = a_kq[0];
    ns_hdct_lkeCho = setInterval('ns_hdct_P_LKE_CHO()', 200);
}
function checkquen_mopd(b_nsd) {
    if (b_nsd.indexOf("ADMIN") >= 0) {
        $get(b_an_mopdId).style.display = "";
    } else {
        $get(b_an_mopdId).style.display = "none";
    }
}

function checkanhien(b_kq, b_chuyenhang) {
    var b_hinhthuc;
    if (b_kq == undefined || b_kq == "") { b_hinhthuc = lke_Fs_TRA($get(b_hinhthucId)); }
    else b_hinhthuc = b_kq;
    if (b_hinhthuc == "QD000") { // Quyết định lương
        $get(b_an_title_bonhiemId).style.display = "none";
        $get(b_an_title_miennhiemId).style.display = "none";
        $get(b_an_title_dieuchuyenId).style.display = "none";
        $get(b_an_title_tiepnhanId).style.display = "none";
        $get(b_an_ngayhl_bonhiemId).style.display = "none";
        $get(b_an_phong_cdanh_bonhiemId).style.display = "none";
        $get(b_an_title_luonghtId).style.display = "none";
        $get(b_an_thang_ngach_htId).style.display = "none";
        $get(b_an_bac_luong_htId).style.display = "none";
        $get(b_an_luongcb_htId).style.display = "none";
        $get(b_an_pt_huongluong_htId).style.display = "none";
        $get(b_an_tyle_hoahong_htId).style.display = "none";
        $get(b_an_title_luongtdId).style.display = "";
        $get(b_an_thang_ngach_tdId).style.display = "";
        $get(b_an_bac_luong_tdId).style.display = "";
        $get(b_an_luongcb_tdId).style.display = "";
        $get(b_an_pt_huongluong_tdId).style.display = "";
        $get(b_an_tyle_hoahong_tdId).style.display = "";
    } else if (b_hinhthuc == "QD001") { // quyết định bổ nhiệm
        $get(b_an_title_bonhiemId).style.display = "";
        $get(b_an_title_miennhiemId).style.display = "none";
        $get(b_an_title_dieuchuyenId).style.display = "none";
        $get(b_an_title_tiepnhanId).style.display = "none";
        $get(b_an_ngayhl_bonhiemId).style.display = "";
        $get(b_an_phong_cdanh_bonhiemId).style.display = "";
        $get(b_an_cdanh_miennhiemId).style.display = "none";
        $get(b_an_title_luonghtId).style.display = "none";
        $get(b_an_thang_ngach_htId).style.display = "none";
        $get(b_an_bac_luong_htId).style.display = "none";
        $get(b_an_luongcb_htId).style.display = "none";
        $get(b_an_pt_huongluong_htId).style.display = "none";
        $get(b_an_tyle_hoahong_htId).style.display = "none";
        $get(b_an_title_luongtdId).style.display = "";
        $get(b_an_thang_ngach_tdId).style.display = "";
        $get(b_an_bac_luong_tdId).style.display = "";
        $get(b_an_luongcb_tdId).style.display = "";
        $get(b_an_pt_huongluong_tdId).style.display = "";
        $get(b_an_tyle_hoahong_tdId).style.display = "";
    } else if (b_hinhthuc == "QD002") { // quyết định điều chuyển
        $get(b_an_title_bonhiemId).style.display = "none";
        $get(b_an_title_miennhiemId).style.display = "none";
        $get(b_an_title_dieuchuyenId).style.display = "";
        $get(b_an_title_tiepnhanId).style.display = "none";
        $get(b_an_ngayhl_bonhiemId).style.display = "none";
        $get(b_an_phong_cdanh_bonhiemId).style.display = "";
        $get(b_an_cdanh_miennhiemId).style.display = "none";
        $get(b_an_title_luonghtId).style.display = "";
        $get(b_an_thang_ngach_htId).style.display = "";
        $get(b_an_bac_luong_htId).style.display = "";
        $get(b_an_luongcb_htId).style.display = "";
        $get(b_an_pt_huongluong_htId).style.display = "";
        $get(b_an_tyle_hoahong_htId).style.display = "";
        $get(b_an_title_luongtdId).style.display = "";
        $get(b_an_thang_ngach_tdId).style.display = "";
        $get(b_an_bac_luong_tdId).style.display = "";
        $get(b_an_luongcb_tdId).style.display = "";
        $get(b_an_pt_huongluong_tdId).style.display = "";
        $get(b_an_tyle_hoahong_tdId).style.display = "";
        if (b_chuyenhang != "1") ns_hdct_P_CB();
    } else if (b_hinhthuc == "QD003") { // quyết định điều chỉnh lương
        $get(b_an_title_bonhiemId).style.display = "none";
        $get(b_an_title_miennhiemId).style.display = "none";
        $get(b_an_title_dieuchuyenId).style.display = "none";
        $get(b_an_title_tiepnhanId).style.display = "none";
        $get(b_an_ngayhl_bonhiemId).style.display = "none";
        $get(b_an_phong_cdanh_bonhiemId).style.display = "none";
        $get(b_an_cdanh_miennhiemId).style.display = "none";
        $get(b_an_title_luonghtId).style.display = "";
        $get(b_an_thang_ngach_htId).style.display = "";
        $get(b_an_bac_luong_htId).style.display = "";
        $get(b_an_luongcb_htId).style.display = "";
        $get(b_an_pt_huongluong_htId).style.display = "";
        $get(b_an_tyle_hoahong_htId).style.display = "";
        $get(b_an_title_luongtdId).style.display = "";
        $get(b_an_thang_ngach_tdId).style.display = "";
        $get(b_an_bac_luong_tdId).style.display = "";
        $get(b_an_luongcb_tdId).style.display = "";
        $get(b_an_pt_huongluong_tdId).style.display = "";
        $get(b_an_tyle_hoahong_tdId).style.display = "";
        if (b_chuyenhang != "1") ns_hdct_P_CB();
    } else if (b_hinhthuc == "QD004") { // Quyết miễn nhiệm
        $get(b_an_title_bonhiemId).style.display = "none";
        $get(b_an_title_miennhiemId).style.display = "";
        $get(b_an_title_dieuchuyenId).style.display = "none";
        $get(b_an_title_tiepnhanId).style.display = "none";
        $get(b_an_ngayhl_bonhiemId).style.display = "none";
        $get(b_an_phong_cdanh_bonhiemId).style.display = "none";
        $get(b_an_cdanh_miennhiemId).style.display = "";
        $get(b_an_title_luonghtId).style.display = "none";
        $get(b_an_thang_ngach_htId).style.display = "none";
        $get(b_an_bac_luong_htId).style.display = "none";
        $get(b_an_luongcb_htId).style.display = "none";
        $get(b_an_pt_huongluong_htId).style.display = "none";
        $get(b_an_tyle_hoahong_htId).style.display = "none";
        $get(b_an_title_luongtdId).style.display = "none";
        $get(b_an_thang_ngach_tdId).style.display = "none";
        $get(b_an_bac_luong_tdId).style.display = "none";
        $get(b_an_luongcb_tdId).style.display = "none";
        $get(b_an_pt_huongluong_tdId).style.display = "none";
        $get(b_an_tyle_hoahong_tdId).style.display = "none";
    }
    else {
        $get(b_an_title_bonhiemId).style.display = "none";
        $get(b_an_title_miennhiemId).style.display = "none";
        $get(b_an_title_dieuchuyenId).style.display = "none";
        $get(b_an_title_tiepnhanId).style.display = "none";
        $get(b_an_ngayhl_bonhiemId).style.display = "none";
        $get(b_an_phong_cdanh_bonhiemId).style.display = "none";
        $get(b_an_cdanh_miennhiemId).style.display = "none";
        $get(b_an_title_luonghtId).style.display = "none";
        $get(b_an_thang_ngach_htId).style.display = "none";
        $get(b_an_bac_luong_htId).style.display = "none";
        $get(b_an_luongcb_htId).style.display = "none";
        $get(b_an_pt_huongluong_htId).style.display = "none";
        $get(b_an_tyle_hoahong_htId).style.display = "none";
        $get(b_an_title_luongtdId).style.display = "";
        $get(b_an_thang_ngach_tdId).style.display = "";
        $get(b_an_bac_luong_tdId).style.display = "";
        $get(b_an_luongcb_tdId).style.display = "";
        $get(b_an_pt_huongluong_tdId).style.display = "";
        $get(b_an_tyle_hoahong_tdId).style.display = "";
    }
    return false;
}

function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_gocId).value = b_so_the;
            $get(b_tenId).value = b_ten;
            $get(b_gocId).focus();
            ns_hdct_P_LKE('K');


            b_doi = 1;
            clearTimeout(b_cho_control);
        }
    }
    catch (err) { b_doi = 0; }
}
function P_cho2(b_so_the, b_ten, b_phong, b_tenmanhinh) {
    try {
        if (b_doi == 0) {
            $get(b_tenId).value = b_ten;
            $get(b_goctkId).value = b_so_the;
            $get(b_gocId).value = b_so_the;
            $get(b_gocId).focus();
            $get(b_tenmanhinhId).innerHTML = 'Quá trình công tác tại công ty';

            ns_hdct_P_LKE('K');
            b_doi = 1;
            clearTimeout(b_cho_control);
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
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
            ns_thongtin_canbo(a_tso[0], "SO_THE");

        } else if (b_dtuong.indexOf("THAMSO") >= 0) {
            document.getElementById(b_gocId).disabled = true;
            document.getElementById(b_goctkId).disabled = true;
            document.getElementById(b_ten_tkId).disabled = true;
            document.getElementById(b_phong_tkId).disabled = true;
            document.getElementById(b_nghi_viec_tkId).disabled = true;
            ns_thongtin_canbo(a_tso[0], "SO_THE");
            b_cho_control = setInterval("P_cho2('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
        } else if (b_dtuong.indexOf("MA_NGUOIKY") >= 0) {
            ns_thongtin_nguoiky(a_tso[0], "MA_NGUOIKY");
        } else if (b_dtuong.indexOf("MA_PC") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grlkePCId);
            if (b_hang < 0) return;
            var b_count = a_tso
            if (a_tso[0] == "CMC-2M") {
                for (var i = 1; i < a_tso.length; i++) {
                    GridX_datGtri(b_grlkePCId, b_hang, ["ma_pc"], [a_tso[i][0]], 'K');
                    GridX_datGtri(b_grlkePCId, b_hang, ["ten"], [a_tso[i][1]], 'K');
                    GridX_datGtri(b_grlkePCId, b_hang, ["sotien"], [a_tso[i][2]], 'K');
                    b_hang = b_hang + 1;
                }
                slide_P_SOTRANG(b_slideIdct, CSO_SO(b_hang, 0));
            } else {
                GridX_datGtri(b_grlkePCId, b_hang, ["ma_pc"], [a_tso[0]], 'K');
                GridX_datGtri(b_grlkePCId, b_hang, ["ten"], [a_tso[1]], 'K');
                GridX_datGtri(b_grlkePCId, b_hang, ["sotien"], [a_tso[2]], 'K');
            }
        } else if (b_dtuong.indexOf("PHONG") >= 0) {
            $get(b_phong_mId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
        } else if (b_dtuong.indexOf("PHONG_TK") >= 0) {
            lke_P_DAT($get(b_phong_tkId), a_tso[0] + '{' + a_tso[1]);
        } else if (b_dtuong.indexOf("CDANH") >= 0) {
            $get(b_cdanh_mId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_atencdanhId).value = a_tso[1];
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
        }
        else form_NhanKq(b_dtuong, a_tso[0]);
    }
}
function ns_hdct_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; form_P_MOI("", "XGLTV"); break;
            case "MA_NGUOIKY": b_maId = b_ma_nguoikyId; break;
            case "PHONG": b_maId = b_phong_mId; form_P_MOI("", "T"); break;
            case "NGAYD": b_maId = b_ngaydId; break;
            case "NCD": b_maId = b_ncdId; break;
            case "CDANH": b_maId = b_cdanh_mId; form_P_MOI(b_vungId, "V"); break;
            case "BCD": b_maId = b_bcdId; break;
            case "MA_TL": b_maId = b_ma_tlId; break;
            case "MA_NL": b_maId = b_ma_nlId; break;
            case "MA_BL": b_maId = b_ma_blId; break;
            case "NGAY_KT": break;
        }
        b_chonId = b_maTen;
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return false;

        if (b_maTen == "SO_THE") {
            ns_thongtin_canbo(b_ma.value, "SO_THE");
            return;
        } else if (b_maTen == "MA_TL") {
            var b_ma_tl = lke_Fs_TRA($get(b_ma_tlId));
            $get(b_ma_nlId).value = ""; $get(b_ma_blId).value = ""; $get(b_luongcbId).value = ""; $get(b_thuong_ketquaId).value = "";
            sns_ma_ch.Fs_NS_MA_TL_NL(window.name, b_ma_tl);
        } else if (b_maTen == "MA_NL") {
            var b_ma_tl = lke_Fs_TRA($get(b_ma_tlId)), b_ma_nl = lke_Fs_TRA($get(b_ma_nlId));
            $get(b_ma_blId).value = ""; $get(b_luongcbId).value = ""; $get(b_thuong_ketquaId).value = "";
            sns_ma_ch.Fs_NS_HDNS_MA_BL_BYTLNL(window.name, b_ma_tl, b_ma_nl);
        } else if (b_maTen == "MA_BL") {
            var b_ma_bl = lke_Fs_TRA($get(b_ma_blId));
            $get(b_luongcbId).value = ""; $get(b_thuong_ketquaId).value = "";
            sns_ma_ch.Fs_NS_HDNS_MA_BL_BYID(form_Fs_nsd(), window.name, b_ma_bl, ns_ns_hdns_ma_bl_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_maTen == 'NGAY_KT') {
            var b_ngay_ad = $get(b_ngay_adId).value, b_ngay_kt = $get(b_ngay_ktId).value;
            if (b_ngay_ad > b_ngay_kt) { form_P_LOI("loi:Ngày kết thúc phải lớn hơn ngày bắt đầu:loi"); return; }
        }
        else if (b_maTen == "NGAYD") {
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ngayd", b_ma.value);
            if (b_hang > -1) {
                GridX_datA(b_grlkeId, b_hang);
                ns_hdct_P_CHUYEN_HANG();
                $get(b_gocId).focus();
                var b_soqd = $get(b_so_qd).value;
                if (b_soqd == "") ns_hdct_P_NGAYKETTHUC();
            }
            else {
                GridX_thoiA(b_grlkeId);
                var b_so_the = $get(b_gocId).value;
                if (b_so_the != "" && b_so_the != null && b_so_the != undefined) {
                    ns_hdct_P_CB();
                    ns_hdct_P_NGAYKETTHUC();
                }
            }
            return;
        } else if (b_maTen == "PHONG") {
            var b_kq = "{";
            lke_P_DAT($get(form_Fs_TEN_ID('', 'cdanh_m')), b_kq);
            var b_phong = form_Fs_TEN_GTRI(b_vungId, 'phong_m');
            hts_dungchung.Fs_NS_CB_PHONG_CDANH('ns_hdct', b_phong);
        } else if (b_maTen == "MA_NGUOIKY") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_hdct_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_thongtin_nguoiky($get(b_maId).value, b_maTen);
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_ns_hdns_ma_bl_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    $get(b_luongcbId).value = SO_CSO(a_kq[0]);
    ns_hdct_tinh_thuongkq();
}
function ns_hdct_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        if (b_chonId == "SO_THE") { $get(b_gocId).value = ""; $get(b_gocId).focus(); }
        else if (b_chonId == "CDANH") { $get(b_cdanh_mId).value = ""; $get(b_cdanh_mId).focus(); }
        else if (b_chonId == "MA_BL") { $get(b_ma_blId).value = ""; $get(b_ma_blId).focus(); }
        else if (b_chonId == "MA_NL") { $get(b_ma_nlId).value = ""; $get(b_ma_nlId).focus(); }
        else if (b_chonId == "MA_TL") { $get(b_ma_tlId).value = ""; $get(b_ma_tlId).focus(); }
        GridX_datGtri(b_grlkePCId, b_hangchon, ["MA_PC"], [""], 'K');
        b_loi = 1;
    }
    else form_P_DatGchu(b_gchuId, b_kq);
    if (b_chonId == 'MA_PC' && b_loi == 0) ns_hdct_P_TT_PC(b_chongt);
}
// Mở chờ phê duyệt
function ns_hdct_P_PHEDUYET(b_kq) {

    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
        b_so_the = $get(b_goctkId).value, b_ten = $get(b_ten_tkId).value, b_phong = lke_Fs_TRA($get(b_phong_tkId)), b_nghi_viec = $get(b_nghi_viec_tkId).value,
        b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")), b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tt")), b_loaiqd = lke_Fs_TRA($get(b_loai_qd_tkId)), b_tungay = $get(b_tungay_tkId).value, b_denngay = $get(b_denngay_tkId).value,
        b_trangthai = form_Fs_TEN_GTRI(b_vungtkId, 'trangthai_tk');

    if (b_hang < 1 || b_so_id == "") { form_P_LOI("loi:Chọn 1 bản ghi để mở phê duyệt:loi"); return false; }
    if (b_trangthai == "CPD") { form_P_LOI("loi:Bản ghi đang ở trạng thái chờ phê duyệt:loi"); return false; }
    var message = confirm("Bạn có chắc chắn muốn mở phê duyệt?");
    if (message == false) { return false; }

    sns_qt.Fs_NS_HDCT_MO_CHOPD(form_Fs_nsd(), b_so_id, b_so_the, b_ten, b_ctyValue, b_nghi_viec, b_loaiqd, b_tungay, b_denngay, b_trangthai, a_cot, a_tso, ns_hdct_P_PHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_hdct_P_PHEDUYET_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#'); slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 0) {
            GridX_datA(b_grlkeId, 1); ns_hdct_GR_lke_RowChange();
        }
    }
    form_P_LOI("loi:Mở phê duyệt thành công:loi");
    return false;
}
// Nhập 
function ns_hdct_P_MOI() {
    form_P_MOI(b_vungId, "GXLKTV");
    GridX_datBang(b_grlkePCId, "");
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = "0"; $get(b_pt_huongluongId).value = "100";
    var b_drop = form_Fctr_TEN_DTUONG(b_vungId, 'tt');
    list_P_DAT(b_drop, 'CPD');
    $get(b_gocId).focus();
    checkanhien();
    return false;
}
function ns_hdct_P_NH(b_thaotac) {
    try {
        var ktra = ktra_ngay(parseDate($get(b_ngaydId).value).getTime(), parseDate($get(b_ngaycId).value).getTime(), 1, "Từ ngày", "đến ngày");
        if (ktra.length > 0) {
            ns_hdct_P_NH_KQ(ktra);
            return false;
        }
        var dateNow = getDateNow();
        var ktraky = ktra_ngay(parseDate($get(b_ngay_kyQdId).value).getTime(), parseDate(dateNow).getTime(), 1, "Ngày ký QĐ", "ngày hiện tại");
        if (ktraky.length > 0) {
            ns_hdct_P_NH_KQ(ktraky);
            return false;
        }
        if (CSO_SO($get(b_luongcbId).value) < 0 || CSO_SO($get(b_thunhapthangId).value < 0)) {
            form_P_LOI('loi:Lương cơ bản, thu nhập tháng không được nhỏ hơn 0:loi'); return false;
        }
        if (CSO_SO($get(b_thunhapthangId).value) < CSO_SO($get(b_luongcbId).value)) {
            form_P_LOI("loi:Thu nhập tháng không được nhỏ hơn lương cơ bản:loi");
            return false;
        }
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 0) {
            b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tt"));
            if (b_trangthai == 'PD') { form_P_LOI('loi:Bản ghi đang ở trạng thái phê duyệt, không thể chỉnh sửa:loi'); return false; }
            if (b_trangthai == 'KPD') { form_P_LOI('loi:Bản ghi đang ở trạng thái không phê duyệt, không thể chỉnh sửa:loi'); return false; }
        }

        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_cot = GridX_Fas_tenCot(b_grlkeId), b_so_the = $get(b_goctkId).value, b_ten = $get(b_ten_tkId).value, b_so_id = '0',
                b_phong = lke_Fs_TRA($get(b_phong_tkId)), b_nghi_viec = $get(b_nghi_viec_tkId).value, b_TrangKt = GridX_Fi_hangKt(b_grlkeId),
                b_loaiqd = lke_Fs_TRA($get(b_loai_qd_tkId)), b_tungay = $get(b_tungay_tkId).value, b_denngay = $get(b_denngay_tkId).value,
                b_trangthai = form_Fs_TEN_GTRI(b_vungtkId, 'trangthai_tk');
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot_pc = GridX_Fdt_cotGtri(b_grlkePCId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang > 0) b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
            if (b_thaotac == "P") {
                sns_qt.Fs_NS_HDCT_PD(form_Fs_nsd(), b_so_the, b_ten, b_ctyValue, b_nghi_viec, b_loaiqd, b_tungay, b_denngay, b_trangthai, b_so_id, b_TrangKt, a_dt_ct, a_cot_pc, a_cot_lke, ns_hdct_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            } else {
                sns_qt.Fs_NS_HDCT_NH(form_Fs_nsd(), b_so_the, b_ten, b_ctyValue, b_nghi_viec, b_loaiqd, b_tungay, b_denngay, b_trangthai, b_so_id, b_TrangKt, a_dt_ct, a_cot_pc, a_cot_lke, ns_hdct_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_hdct_P_NH_KQ(b_kq) {
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

function ns_hdct_P_CAT_PC() {
    try {



        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 0) {
            b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tt"));
            if (b_trangthai == 'CPD') { form_P_LOI('loi:Bản ghi đang ở trạng thái chờ phê duyệt, không thể chỉnh sửa:loi'); return false; }
            if (b_trangthai == 'KPD') { form_P_LOI('loi:Bản ghi đang ở trạng thái không phê duyệt, không thể chỉnh sửa:loi'); return false; }
        }

        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_so_the = $get(b_goctkId).value, b_ten = $get(b_ten_tkId).value, b_so_id = '0',
                b_nghi_viec = $get(b_nghi_viec_tkId).value, b_TrangKt = GridX_Fi_hangKt(b_grlkeId),
                b_loaiqd = lke_Fs_TRA($get(b_loai_qd_tkId)), b_tungay = $get(b_tungay_tkId).value, b_denngay = $get(b_denngay_tkId).value,
                b_trangthai = form_Fs_TEN_GTRI(b_vungtkId, 'trangthai_tk');
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot_pc = GridX_Fdt_cotGtri(b_grlkePCId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang > 0) b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
            sns_qt.Fs_NS_HDCT_CAT_PC(form_Fs_nsd(), b_so_the, b_ten, b_ctyValue, b_nghi_viec, b_loaiqd, b_tungay, b_denngay, b_trangthai, b_so_id, b_TrangKt, a_dt_ct, a_cot_pc, a_cot_lke, ns_hdct_P_CAT_PC_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_hdct_P_CAT_PC_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        form_P_LOI("loi:Cắt phụ cấp thành công!:loi");
    }
    return false;
}
// Xóa
function ns_hdct_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId), b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1) { form_P_LOI('Bạn phải chọn một bản ghi để xóa'); return false; }
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, 'so_id')),
        a_cot = GridX_Fas_tenCot(b_grlkeId), b_so_the = $get(b_goctkId).value, b_ten = $get(b_ten_tkId).value,
        b_phong = lke_Fs_TRA($get(b_phong_tkId)), b_nghi_viec = $get(b_nghi_viec_tkId).value, a_tso = slide_Faobj_TUDEN(b_slideId),
        b_loaiqd = lke_Fs_TRA($get(b_loai_qd_tkId)), b_tungay = $get(b_tungay_tkId).value, b_denngay = $get(b_denngay_tkId).value,
        b_trangthai = form_Fs_TEN_GTRI(b_vungtkId, 'trangthai_tk');
    if (b_so_id == "") { form_P_LOI('Bạn phải chọn một bản ghi để xóa'); return false; }
    var b_tt = form_Fs_TEN_GTRI(b_vungId, 'tt');
    if (b_tt == 'PD' || b_tt == 'KPD') { form_P_LOI('loi:Bản ghi đang ở trạng thái phê duyệt/Không phê duyệt, bạn không thể xóa:loi'); return false; }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId),
            a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_qt.Fs_NS_HDCT_XOA(form_Fs_nsd(), b_so_id, b_so_the, b_ten, b_ctyValue, b_nghi_viec, b_loaiqd, b_tungay, b_denngay, b_trangthai, a_cot, a_tso, ns_hdct_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_hdct_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_hdct_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_hdct_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
    return false;
}
// Chuyển hàng
function ns_hdct_GR_lke_RowChange() {
    if (ns_hdct_choAct != 0) clearTimeout(ns_hdct_choAct);
    ns_hdct_choAct = setTimeout("ns_hdct_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_hdct_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    var b_hinhthuc = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "hinhthuc"));
    var a_cot_pc = GridX_Fas_tenCot(b_grlkePCId);
    if (b_so_id == "0" || b_so_id == "") ns_hdct_P_MOI();
    else sns_qt.Fs_NS_HDCT_CT(window.name, form_Fs_nsd(), b_so_id, a_cot_pc, ns_hdct_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = b_so_id;
    return false;
}
function ns_hdct_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == '') return;
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[1]);
    GridX_datBang(b_grlkePCId, a_kq[2]);
    b_trangthai = form_Fs_TEN_GTRI(b_vungId, 'tt');
    // đẩy loại quyết đinh vào biến ẩn để phụ vụ chức năng in quyết định
    $get(b_alqdinhId).value = lke_Fs_TRA($get(b_hinhthucId));
    checkanhien("", "1");
    return false;
}
// Liệt kê
function ns_hdct_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ns_hdct_lkeCho != 0) clearTimeout(ns_hdct_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtkId = form_Fs_VUNG_ID('UPa_tk'), b_vungnhId = form_Fs_VUNG_ID('UPa_nhap');
        b_goctkId = form_Fs_TEN_ID(b_vungtkId, 'so_the_tk'), b_ten_tkId = form_Fs_TEN_ID(b_vungtkId, 'ten_tk'), b_phong_tkId = form_Fs_TEN_ID(b_vungtkId, 'phong_tk');
        b_nghi_viec_tkId = form_Fs_TEN_ID(b_vungtkId, 'nghi_viec_tk'), b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
        b_grlkePCId = form_Fs_VUNG_ID('GR_ct'), b_tenId = form_Fs_TEN_ID(b_vungId, 'HO_TEN'), b_hinhthucId = form_Fs_TEN_ID(b_vungId, 'HINHTHUC');
        b_so_qdId = form_Fs_TEN_ID(b_vungId, 'SO_QD'), b_ten_cdanhId = form_Fs_TEN_ID(b_vungId, 'TEN_CDANH'), b_ten_phongId = form_Fs_TEN_ID(b_vungId, 'ten_phong');
        b_phong_Id = form_Fs_TEN_ID(b_vungId, 'PHONG'), b_cdanh_Id = form_Fs_TEN_ID(b_vungId, 'CDANH'), b_ma_nguoikyId = form_Fs_TEN_ID(b_vungId, 'ma_nguoiky');
        b_phong_mId = form_Fs_TEN_ID(b_vungId, 'PHONG_M'), b_cdanh_mId = form_Fs_TEN_ID(b_vungId, 'CDANH_M'); b_ten_cdanh_nguoikyId = form_Fs_TEN_ID(b_vungId, 'ten_cdanh_nguoiky');
        b_ngay_kyQdId = form_Fs_TEN_ID(b_vungId, 'ngay_qd'), b_ngaydId = form_Fs_TEN_ID(b_vungId, 'NGAYD'), b_ngaycId = form_Fs_TEN_ID(b_vungId, 'NGAYC');
        b_ma_tlId = form_Fs_TEN_ID(b_vungId, 'MA_TL'), b_ma_nlId = form_Fs_TEN_ID(b_vungId, 'MA_NL'), b_ma_blId = form_Fs_TEN_ID(b_vungId, 'MA_BL');
        b_luongcbId = form_Fs_TEN_ID(b_vungId, 'luongcb'), b_thunhapthangId = form_Fs_TEN_ID(b_vungId, 'thunhapthang');
        b_thuong_ketquaId = form_Fs_TEN_ID(b_vungId, 'thuong_ketqua'), b_pt_huongluongId = form_Fs_TEN_ID(b_vungId, 'pt_huongluong');
        b_dongiaId = form_Fs_TEN_ID(b_vungId, 'dongia'), b_tyle_hoahongId = form_Fs_TEN_ID(b_vungId, 'tyle_hoahong'), b_tyle_hoahong_theophiId = form_Fs_TEN_ID(b_vungId, 'tyle_hoahong_theophi');
        b_ma_tlcId = form_Fs_TEN_ID(b_vungId, 'ma_tl_c'), b_ten_tlcId = form_Fs_TEN_ID(b_vungId, 'ten_tl_c');
        b_ma_nlcId = form_Fs_TEN_ID(b_vungId, 'ma_nl_c'), b_ten_nlcId = form_Fs_TEN_ID(b_vungId, 'ten_nl_c');
        b_ma_blcId = form_Fs_TEN_ID(b_vungId, 'ma_bl_c'), b_ten_blcId = form_Fs_TEN_ID(b_vungId, 'ten_bl_c');
        b_luongcb_cId = form_Fs_TEN_ID(b_vungId, 'luongcb_c'), b_thunhapthang_cId = form_Fs_TEN_ID(b_vungId, 'thunhapthang_c');
        b_thuong_ketqua_cId = form_Fs_TEN_ID(b_vungId, 'thuong_ketqua_c'), b_pt_huongluong_cId = form_Fs_TEN_ID(b_vungId, 'pt_huongluong_c');
        b_dongia_cId = form_Fs_TEN_ID(b_vungId, 'dongia_c'), b_tyle_hoahong_cId = form_Fs_TEN_ID(b_vungId, 'tyle_hoahong_c'), b_tyle_hoahong_theophi_cId = form_Fs_TEN_ID(b_vungId, 'tyle_hoahong_theophi_c');

        b_atluongId = form_Fs_VTEN_ID('UPa_hi', 'atluong'), b_ntluongId = form_Fs_VTEN_ID('UPa_hi', 'anluong');
        b_abluongId = form_Fs_VTEN_ID('UPa_hi', 'abluong'), b_kthuocId = form_Fs_VTEN_ID('UPa_hi', 'kthuoc'), b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
        b_tenmanhinhId = form_Fs_VTEN_ID('', 'Luu1');
        b_fileId = form_Fs_VTEN_ID(b_vungnhId, 'excel'), b_tthaiId = form_Fs_TEN_ID(b_vungId, 'TT'), b_alqdinhId = form_Fs_VTEN_ID('UPa_hi', 'alqdinh');
        b_an_title_bonhiemId = form_Fs_VUNG_ID('an_title_bonhiem'), b_an_title_miennhiemId = form_Fs_VUNG_ID('an_title_miennhiem'), b_an_title_dieuchuyenId = form_Fs_VUNG_ID('an_title_dieuchuyen'), b_an_title_tiepnhanId = form_Fs_VUNG_ID('an_title_tiepnhan'),
            b_an_ngayhl_bonhiemId = form_Fs_VUNG_ID('an_ngayhl_bonhiem'), b_an_phong_cdanh_bonhiemId = form_Fs_VUNG_ID('an_phong_cdanh_bonhiem'), b_an_cdanh_miennhiemId = form_Fs_VUNG_ID('an_cdanh_miennhiem'),
            b_an_title_luonghtId = form_Fs_VUNG_ID('an_title_luonght'),
            b_an_thang_ngach_htId = form_Fs_VUNG_ID('an_thang_ngach_ht'), b_an_bac_luong_htId = form_Fs_VUNG_ID('an_bac_luong_ht'),
            b_an_luongcb_htId = form_Fs_VUNG_ID('an_luongcb_ht'), b_an_pt_huongluong_htId = form_Fs_VUNG_ID('an_pt_huongluong_ht'), b_an_tyle_hoahong_htId = form_Fs_VUNG_ID('an_tyle_hoahong_ht'),
            b_an_title_luongtdId = form_Fs_VUNG_ID('an_title_luongtd'), b_an_thang_ngach_tdId = form_Fs_VUNG_ID('an_thang_ngach_td'),
            b_an_bac_luong_tdId = form_Fs_VUNG_ID('an_bac_luong_td'), b_an_luongcb_tdId = form_Fs_VUNG_ID('an_luongcb_td'),
            b_an_pt_huongluong_tdId = form_Fs_VUNG_ID('an_pt_huongluong_td'), b_an_tyle_hoahong_tdId = form_Fs_VUNG_ID('an_tyle_hoahong_td'),
            b_an_mopdId = form_Fs_VUNG_ID('an_mopd'), b_loai_qd_tkId = form_Fs_TEN_ID(b_vungtkId, 'hinhthuc_tk'), b_tungay_tkId = form_Fs_TEN_ID(b_vungtkId, 'ngayd_tk'), b_denngay_tkId = form_Fs_TEN_ID(b_vungtkId, 'ngayc_tk');
        b_trangthai_tkId = form_Fs_TEN_ID(b_vungtkId, 'trangthai_tk'), a_so_idId = form_Fs_VTEN_ID('UPa_hi', 'a_so_id'), b_aphongId = form_Fs_VTEN_ID('UPa_hi', 'aphong_tk'), b_atrangthaiId = form_Fs_VTEN_ID('UPa_hi', 'atrangthai');
        b_atencdanhId = form_Fs_VTEN_ID('UPa_hi', 'atcdanh');
        b_gchuId = form_Fs_VTEN_ID('UPa_gchu', 'gchu');
        b_chon_allId = form_Fs_VTEN_ID('UPa_hi', 'acheckall'),
            lke_P_DAT($get(b_phong_tkId), 'TATCA' + '{' + 'Tất cả');
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        checkanhien(); checkquen_mopd(b_nsd);
        form_F_GOC().P_MENUBf(window.name, 'M');
        vb_cctc_P_SL('', 'D', '0', ' ', ' ', 'T');
        b_ctyValue = "TATCA";
        ns_hdct_P_LKE('K');
    }
}
function ns_hdct_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_so_the = $get(b_goctkId).value, b_ten = $get(b_ten_tkId).value,
            b_phong = lke_Fs_TRA($get(b_phong_tkId)), b_nghi_viec = $get(b_nghi_viec_tkId).value,
            b_loaiqd = lke_Fs_TRA($get(b_loai_qd_tkId)), b_tungay = $get(b_tungay_tkId).value, b_denngay = $get(b_denngay_tkId).value,
            b_trangthai = form_Fs_TEN_GTRI(b_vungtkId, 'trangthai_tk');
        sns_qt.Fs_NS_HDCT_LKE(form_Fs_nsd(), b_so_the, b_ten, b_ctyValue, b_nghi_viec, b_loaiqd, b_tungay, b_denngay, b_trangthai, a_cot, a_tso, ns_hdct_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdct_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#'); slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 0) {
            GridX_datA(b_grlkeId, 1); ns_hdct_GR_lke_RowChange();
        }
    }
    b_fcho = 'X';
}
// thông tin quyết định 
function ns_hdct_P_CB() {
    try {
        b_so_the = $get(b_gocId).value;
        b_ngayd = $get(b_ngaydId).value;
        sns_qt.Fs_NS_HDCT_CB(form_Fs_nsd(), b_so_the, b_ngayd, ns_hdct_P_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdct_P_CB_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#'), b_hinhthuc = lke_Fs_TRA($get(b_hinhthucId));
    if (a_kq == "") return;
    //else if (b_hinhthuc == "QD001") { // quyết định bổ nhiệm lấy dữ liệu lương hiện tại vào các controll lương cần thay đổi
    //    lke_P_DAT($get(b_ma_tlId), a_kq[0] + '{' + a_kq[7]); // đẩy dữ liệu vào controll bảng lương 
    //    var b_ma_tl = lke_Fs_TRA($get(b_ma_tlId)); sns_ma_ch.Fs_NS_MA_TL_NL(window.name, b_ma_tl); // load dữ liệu nhóm lương theo bảng lương
    //    lke_P_DAT($get(b_ma_nlId), a_kq[1] + '{' + a_kq[8]); // đẩy dữ liệu vào control nhóm lương
    //    var b_ma_nl = lke_Fs_TRA($get(b_ma_nlId)); sns_ma_ch.Fs_NS_HDNS_MA_BL_BYTLNL(window.name, b_ma_tl, b_ma_nl); // load dữ liệu bậc lương theo bảng lương và nhóm lương
    //    lke_P_DAT($get(b_ma_blId), a_kq[2] + '{' + a_kq[9]); // đẩy dữ liệu vào control bậc lương
    //    $get(b_luongcbId).value = a_kq[3];
    //    $get(b_thunhapthangId).value = a_kq[4];
    //    $get(b_thuong_ketquaId).value = a_kq[5];
    //    $get(b_an_pt_huongluong_tdId).value = a_kq[6];
    //}
    else if (b_hinhthuc == "QD004" || b_hinhthuc == "QD001") { // quyết định điều chuyển lấy dữ liệu vào cả controll hiện tại và thay đổi
        // làm mới các control thang bảng lương thay đổi
        $get(b_ma_tlId).value = ""; $get(b_ma_nlId).value = ""; $get(b_ma_blId).value = "";
        $get(b_luongcbId).value = ""; $get(b_thunhapthangId).value = ""; $get(b_thuong_ketquaId).value = ""; $get(b_pt_huongluongId).value = "";
        $get(b_dongiaId).value = ""; $get(b_tyle_hoahongId).value = ""; $get(b_tyle_hoahong_theophiId).value = "";
        // đẩy dữ liệu vào các controll thang bảng lương hiện tại
        $get(b_ma_tlcId).value = a_kq[0];
        $get(b_ma_nlcId).value = a_kq[1];
        $get(b_ma_blcId).value = a_kq[2];
        $get(b_luongcb_cId).value = a_kq[3];
        $get(b_thunhapthang_cId).value = a_kq[4];
        $get(b_thuong_ketqua_cId).value = a_kq[5];
        $get(b_pt_huongluong_cId).value = a_kq[6];
        $get(b_ten_tlcId).value = a_kq[7];
        $get(b_ten_nlcId).value = a_kq[8];
        $get(b_ten_blcId).value = a_kq[9];
        $get(b_dongia_cId).value = a_kq[11];
        $get(b_tyle_hoahong_cId).value = a_kq[12];
        $get(b_tyle_hoahong_theophi_cId).value = a_kq[13];

        lke_P_DAT($get(b_ma_tlId), a_kq[0] + '{' + a_kq[7]); // đẩy dữ liệu vào controll bảng lương 
        var b_ma_tl = lke_Fs_TRA($get(b_ma_tlId)); sns_ma_ch.Fs_NS_MA_TL_NL(window.name, b_ma_tl); // load dữ liệu nhóm lương theo bảng lương
        lke_P_DAT($get(b_ma_nlId), a_kq[1] + '{' + a_kq[8]); // đẩy dữ liệu vào control nhóm lương
        var b_ma_nl = lke_Fs_TRA($get(b_ma_nlId)); sns_ma_ch.Fs_NS_HDNS_MA_BL_BYTLNL(window.name, b_ma_tl, b_ma_nl); // load dữ liệu bậc lương theo bảng lương và nhóm lương
        lke_P_DAT($get(b_ma_blId), a_kq[2] + '{' + a_kq[9]); // đẩy dữ liệu vào control bậc lương
        $get(b_luongcbId).value = a_kq[3];
        $get(b_thunhapthangId).value = a_kq[4];
        $get(b_thuong_ketquaId).value = a_kq[5];
        $get(b_pt_huongluongId).value = a_kq[6];
        $get(b_dongiaId).value = a_kq[11];
        $get(b_tyle_hoahongId).value = a_kq[12];
        $get(b_tyle_hoahong_theophiId).value = a_kq[13];

    } else { // còn lại lấy dữ liệu vào con troll lương cũ
        // làm mới các control thang bảng lương thay đổi
        $get(b_ma_tlId).value = ""; $get(b_ma_nlId).value = ""; $get(b_ma_blId).value = "";
        $get(b_luongcbId).value = ""; $get(b_thunhapthangId).value = ""; $get(b_thuong_ketquaId).value = ""; $get(b_pt_huongluongId).value = "";
        $get(b_dongiaId).value = ""; $get(b_tyle_hoahongId).value = ""; $get(b_tyle_hoahong_theophiId).value = "";
        // đẩy dữ liệu vào các controll thang bảng lương hiện tại
        $get(b_ma_tlcId).value = a_kq[0];
        $get(b_ma_nlcId).value = a_kq[1];
        $get(b_ma_blcId).value = a_kq[2];
        $get(b_luongcb_cId).value = a_kq[3];
        $get(b_thunhapthang_cId).value = a_kq[4];
        $get(b_thuong_ketqua_cId).value = a_kq[5];
        $get(b_pt_huongluong_cId).value = a_kq[6];
        $get(b_ten_tlcId).value = a_kq[7];
        $get(b_ten_nlcId).value = a_kq[8];
        $get(b_ten_blcId).value = a_kq[9];
        $get(b_dongia_cId).value = a_kq[11];
        $get(b_tyle_hoahong_cId).value = a_kq[12];
        $get(b_tyle_hoahong_theophi_cId).value = a_kq[13];
    }

    return false;
}
function ns_hdct_P_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grlkePCId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        var b_ktra = C_NVL(b_ctr.ktra), b_ten = C_NVL(b_ctr.ten);
        if (b_value != "") {
            b_chonId = b_cot;
            b_hangchon = b_hang;
            if (b_cot == "MA_PC") {
                b_chongt = b_value;
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Mã phụ cấp", b_value, "ns_ma_phucap,ma,ten", ns_hdct_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
            else if (b_cot == "NGAY_KT" || b_cot == "NGAY_AD") {
                var b_hang = GridX_Fi_timHangA(b_grlkePCId);
                if (b_hang < 0) return;
                var b_ngay_ad = C_NVL(GridX_Fas_layGtri(b_grlkePCId, b_hang, "ngay_ad"));
                var b_ngay_kt = C_NVL(GridX_Fas_layGtri(b_grlkePCId, b_hang, "ngay_kt"));
                var ktra = ktra_ngay(parseDate(b_ngay_ad).getTime(), parseDate(b_ngay_kt).getTime(), 1, "Ngày áp dụng", "Ngày kết thúc");
                if (ktra.length > 0) {
                    ns_hdct_P_NH_KQ(ktra);
                    return false;
                }
            }
        }
        if (b_value != "") GridX_ThemHang(b_grctId);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
// thông tin phụ cấp
function ns_hdct_P_TT_PC(b_value) {
    try {
        hts_dungchung.Fs_NS_MA_TT_PC(b_value, ns_hdct_P_TT_PC_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdct_P_TT_PC_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == "") return;
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = GridX_Fi_timHangA(b_grlkePCId);
    if (b_hang < 0) return;
    GridX_datGtri(b_grlkePCId, b_hang, ["ma_pc"], [a_kq[0]], 'K');
    GridX_datGtri(b_grlkePCId, b_hang, ["ten"], [a_kq[1]], 'K');
    GridX_datGtri(b_grlkePCId, b_hang, ["sotien"], [a_kq[2]], 'K');
    return false;
}
function ns_hdct_P_SOQD() {
    try {
        var b_ma_lqd = lke_Fs_TRA($get(b_hinhthucId));
        var b_ngayhd = $get(b_ngaydId).value;
        ns_hdct_P_DONGIA();
        // lay du lieu bieu mau chi phi len theo ngay hieu luc 
        stl_ma.Fs_NS_TL_TLAP_TYLE_HOAHONG_DR(window.name, "DT_CHIPHI", b_ngayhd);
        sns_qt.Fs_NS_HDCT_SO_QD(form_Fs_nsd(), b_ngayhd, b_ma_lqd, ns_hdct_P_SOQD_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_hdct_P_SOQD_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq))
        form_P_LOI(b_kq);
    else $get(b_so_qdId).value = b_kq;
}
// lay don gia
function ns_hdct_P_DONGIA() {
    try {
        var b_ngayhd = $get(b_ngaydId).value;
        var b_so_the = $get(b_gocId).value;
        sns_qt.Fs_NS_THONGTIN_DONGIA(b_so_the, b_ngayhd, ns_hdct_P_DONGIA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_hdct_P_DONGIA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        $get(b_dongiaId).value = b_kq;
    }
}
function ns_tv_P_FILE() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) {
        form_P_LOI('loi:Chọn cán bộ trước:loi')
        return false;
    }
    var b_tenf = '/App_form/ns/ma/file_Import_chung.aspx';
    var b_so_the = $get(b_gocId).value;
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, b_so_the, "NS_HDCT", "File đính kèm quản lý quyết định"]], null);
    form_P_LOI('');
    return false;
}
// Chuyển hàng lên xuống trên grid
function ns_hdct_P_HangLen() {
    GridX_chuyenHang(b_grlkePCId, -1);
    return false;
}
function ns_hdct_P_HangXuong() {
    GridX_chuyenHang(b_grlkePCId, 1);
    return false;
}
function ns_hdct_P_chenDong(b_dk) {
    var b_hang = GridX_Fi_timHangA(b_grlkePCId);
    if (b_hang < 1) return;
    GridX_chenHang(b_grlkePCId, b_hang, 1);
    return false;
}
function ns_hdct_P_CatDong() {
    GridX_boChon(b_grlkePCId, 'C');
    return false;
}
function ns_hdct_phong(check) {
    try {
        b_check = check;
        var b_tenf = form_Fs_TM() + '/App_form/ht/ht_maph.aspx';
        form_P_MO(b_tenf, null, ["ns_cb", [""]]);
        return false;
    }
    catch (err) { }
}
function ns_hdct_tinh_thuongkq() {
    if (CSO_SO($get(b_thunhapthangId).value) >= CSO_SO($get(b_luongcbId).value)) {
        $get(b_thuong_ketquaId).value = SO_CSO(CSO_SO($get(b_thunhapthangId).value) - CSO_SO($get(b_luongcbId).value));
    }
    else $get(b_thuong_ketquaId).value = 0;
}
function form_P_CHON(b_chon) {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 0) {
            var b_tthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tt"));
            if (b_tthai != 'PD') { form_P_LOI("loi:Quyết định chưa được phê duyệt hoặc không phê duyệt. Không được chọn:loi"); return false; }
        }
        form_P_TRA_CHON(b_chon);
    }
    catch (err) { form_P_LOI(err); }
}
// lấy thông tin cán bộ nhân viên
function ns_thongtin_canbo(b_so_the, b_loai) {
    try {
        if (b_so_the == null) b_so_the = $get(b_gocId).value;
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
// Thông tin người ký
function ns_thongtin_nguoiky(b_so_the, b_loai) {
    try {
        var b_listcotcu = "", b_listcotmoi = "";
        if (b_loai == "MA_NGUOIKY") { b_kt_loai = "MA_NGUOIKY"; b_listcotcu = "SO_THE,TEN_CDANH", b_listcotmoi = "MA_NGUOIKY,TEN_CDANH_NGUOIKY" }
        else { b_kt_loai = ""; b_listcotcu = "SO_THE,HO_TEN,TEN_CDANH,TEN_PHONG", b_listcotmoi = "SO_THE,HO_TEN,TEN_CDANH,TEN_PHONG" }
        hts_dungchung.Fs_THONGTIN_CANBO_HD(b_so_the, b_listcotcu, b_listcotmoi, ns_thongtin_nguoiky_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_thongtin_nguoiky_kq(b_kq) {
    if (b_kq == "") {
        if (b_kt_loai == "MA_NGUOIKY") {
            $get(b_ma_nguoikyId).value = ""; $get(b_ten_cdanhnkId).value = "";
        }

    }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
// so sánh ngày 
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
// In 
function ns_hdct_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_phong_tkId).value = b_ctyValue;
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}

function ns_hdct_P_BIEUMAU() {
    var a_so_id = "";
    for (i = 1; i < 20; i++) {
        var b_so_the = C_NVL(GridX_Fas_layGtri(b_grlkeId, i, "so_the"));
        var b_chon = C_NVL(GridX_Fas_layGtri(b_grlkeId, i, "chon"));
        if (b_so_the != "" && b_chon == "X")
            a_so_id = a_so_id + "," + C_NVL(GridX_Fas_layGtri(b_grlkeId, i, "so_id"));
    }
    if (a_so_id == "") { form_P_LOI("loi:Bạn chưa chọn dữ liệu cần in:loi"); return; }
    $get(a_so_idId).value = a_so_id;
    $get(b_aphongId).value = b_ctyValue;
    $get(b_atrangthaiId).value = lke_Fs_TRA($get(b_trangthai_tkId));
    var b_btn_excel = form_Fs_VTEN_ID('', 'msword');
    $get(b_btn_excel).click(); form_chay = 0;
    form_P_LOI('');
    return false;
}
function ns_hdct_Export() {
    __doPostBack('ctl00$ContentPlaceHolder1$xuatfilemau', '');
}
function ns_hdct_Import() {
    var b_tenf = '/App_form/ns/ma/file_Import.aspx';
    form_P_MO(b_tenf, window.name + ',THAMSO', ['THAMSO', [window.name, 'NS_HDCT', null, "Import tờ trình quyết định"]], null);
    form_P_LOI('');
    return false;
}

// Kiểm tra xem thu nhập tháng có nằm trong khu lương theo chức danh hay không.
function ns_ma_khungluong_check() {
    try {
        var b_ngayd = $get(b_ngaydId).value, b_cdanh = $get(b_cdanh_Id).value, b_tongthunhap = $get(b_thunhapthangId).value;
        sns_ma_ch.Fs_NS_MA_KHUNGLUONG_CHECK(form_Fs_nsd(), b_ngayd, b_cdanh, b_tongthunhap, ns_ma_khungluong_check_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_khungluong_check_KQ(b_kq) {
    if (CSO_SO(b_kq) == 0) {
        form_P_LOI("loi:Thu nhập tháng không nằm trong khung lương theo chức danh:loi");
    }
}
function CheckAll(oCheckbox) {
    var b_sohang = GridX_Fi_hangKt(b_grlkeId)
    if (oCheckbox.checked == true) {
        $get(b_chon_allId).value = 'TATCA';

        for (i = 1; i <= b_sohang; i++) {
            var b_so_the = C_NVL(GridX_Fas_layGtri(b_grlkeId, i, "so_the"));
            if (b_so_the != "") GridX_datGtri(b_grlkeId, i, ["chon"], ['X'], 'K');
        }
    } else {
        for (i = 1; i <= b_sohang; i++) {
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
        ns_hdct_P_LKE('K'); return false;
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