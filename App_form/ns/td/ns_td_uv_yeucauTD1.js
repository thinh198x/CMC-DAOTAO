var ns_td_uv_yeucauTD_lkeCho, b_vungId, b_cho_control, b_nhapCho, b_ns_td_uv_yeucauTD_chuyenhang_cho, ns_td_uv_yeucauTD_choAct, b_grlkeId, b_slideId, b_ten_form, b_gocId,
    b_nc_cmtId, b_tenId, b_nsinhId, b_gchuId, b_so_idId, b_ten_tkId, b_dantocId, b_ma_yctkId, b_trangthai_uv_theoyc_tkId,
    b_tongiaoId, b_gioitinhId, b_noicapId, b_tt_honnhanId, b_qh_noisinhId, b_xp_noisinhId, b_tt_noisinhId, b_tt_tamtruId, b_qh_tamtruId, b_xp_tamtruId, b_tt_thuongtruId, b_qh_thuongtruId,
    b_xp_thuongtruId, b_trangthai_uv_theoycId, b_grtdhv, b_grtdnn, b_grcc, b_grqtct, b_grqhnt, b_grttk, b_dot_tk, b_sothe_tk, b_ten_tk, b_trangthai_uv_theoyc_tk, b_dot_ycId, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C',
    b_namId, b_ma_yeucauId, b_ten_cdanhId, b_ten_phongId;
function ns_td_uv_yeucauTD_P_KD() {
    b_cho_control = 0, b_ns_td_uv_yeucauTD_chuyenhang_cho = 0, ns_td_uv_yeucauTD_choAct = 0,
        ns_td_uv_yeucauTD_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_vungtkId = form_Fs_VUNG_ID('Upa_tk'),
        b_gocId = form_Fs_TEN_ID(b_vungId, 'so_the'); b_nc_cmtId = form_Fs_TEN_ID(b_vungId, 'noicap_cmt'), b_grtdhv = form_Fs_VUNG_ID('GR_td'), b_grtdnn = form_Fs_VUNG_ID('GR_tdnn'), b_grcc = form_Fs_VUNG_ID('GR_cc'),
            b_grqtct = form_Fs_VUNG_ID('GR_ct'), b_grqhnt = form_Fs_VUNG_ID('GR_nt'), b_grttk = form_Fs_VUNG_ID('GR_ttk'), b_tenId = form_Fs_TEN_ID(b_vungId, 'ten'), b_dantocId = form_Fs_TEN_ID(b_vungId, 'dantoc'),
            b_tt_noisinhId = form_Fs_TEN_ID(b_vungId, 'tt_noisinh'), b_qh_noisinhId = form_Fs_TEN_ID(b_vungId, 'qh_noisinh'), b_xp_noisinhId = form_Fs_TEN_ID(b_vungId, 'xp_noisinh'),
            b_tt_tamtruId = form_Fs_TEN_ID(b_vungId, 'tt_tamtru'), b_qh_tamtruId = form_Fs_TEN_ID(b_vungId, 'qh_tamtru'), b_xp_tamtruId = form_Fs_TEN_ID(b_vungId, 'xp_tamtru'),
            b_tongiaoId = form_Fs_TEN_ID(b_vungId, 'tongiao'), b_gioitinhId = form_Fs_TEN_ID(b_vungId, 'gioitinh'), b_noicapId = form_Fs_TEN_ID(b_vungId, 'noicap_cmt'),
            b_tt_honnhanId = form_Fs_TEN_ID(b_vungId, 'tt_honnhan'), b_tt_thuongtruId = form_Fs_TEN_ID(b_vungId, 'tt_thuongtru'), b_qh_thuongtruId = form_Fs_TEN_ID(b_vungId, 'qh_thuongtru'),
            b_xp_thuongtruId = form_Fs_TEN_ID(b_vungId, 'xp_thuongtru'), b_nsinhId = form_Fs_TEN_ID(b_vungId, 'ngaysinh'), b_trangthai_uv_theoycId = form_Fs_TEN_ID(b_vungId, 'trangthai_uv_theoyc'),
            b_namId = form_Fs_TEN_ID(b_vungId, 'nam'), b_ma_yeucauId = form_Fs_TEN_ID(b_vungId, 'mayeucau_td'), b_ten_cdanhId = form_Fs_TEN_ID(b_vungId, 'ten_cdanh'),
            b_ten_phongId = form_Fs_TEN_ID(b_vungId, 'ten_phong'),
            b_ma_yctkId = form_Fs_TEN_ID(b_vungtkId, 'ma_yc_tk'), b_trangthai_uv_theoyc_tkId = form_Fs_TEN_ID(b_vungtkId, 'trangthai_uv_theoyc_tk');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu'); b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_psId = form_Fs_VTEN_ID('UPa_hi', 'ps'), b_nvId = form_Fs_VTEN_ID('UPa_hi', 'nv');
    b_slideId = $get(b_grlkeId).getAttribute('slideId');
    b_no_anhId = form_Fs_TM() + "/images/no_image.png";
    b_loading_anhId = form_Fs_TM() + "/images/" + "loading_image.gif";
    ns_td_uv_yeucauTD_lkeCho = setInterval('ns_td_uv_yeucauTD_P_LKE_CHO()', 200);
    lke_P_DAT($get(b_trangthai_uv_theoycId), 'GYC' + '{' + 'Ứng viên đã gán vào yêu cầu');
}

function ns_td_uv_P_ANHIEN(b_item) {
    if (b_item == "NGUOITHAN_CO") {
        $get(form_Fs_TEN_ID(b_vungId, 'nguoithan_lvttd_ko')).value = "";
    } else if (b_item == "NGUOITHAN_KO") {
        $get(form_Fs_TEN_ID(b_vungId, 'nguoithan_lvttd_co')).value = "";
    } else if (b_item == "BANTHAN_CO") {
        $get(form_Fs_TEN_ID(b_vungId, 'banthan_lvttd_ko')).value = "";
    } else if (b_item == "BANTHAN_KO") {
        $get(form_Fs_TEN_ID(b_vungId, 'banthan_lvttd_co')).value = "";
    } else if (b_item == "UNGTUYEN_CO") {
        $get(form_Fs_TEN_ID(b_vungId, 'banthan_ut_ko')).value = "";
    } else if (b_item == "UNGTUYEN_KO") {
        $get(form_Fs_TEN_ID(b_vungId, 'banthan_ut_co')).value = "";
    }
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (typeof (b_dtuong) == "undefined") return false;
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[0];
        b_doi = 0;
        if (b_dtuong.indexOf("YEUCAU_TD") >= 0) {
            $get(b_yeucau_tdId).value = b_kq;
            $get(b_cdanhId).value = a_tso[1];
            $get(b_phongId).value = a_tso[2];
            $get(b_sl_cantuyenId).value = a_tso[3];
            $get(b_gchuId).innerHTML = b_kq;
        } else if (b_dtuong.indexOf("MA_YC") >= 0) {
            $get(b_yeucau_tkId).value = b_kq;
            $get(b_gchuId).innerHTML = b_kq;
        }
        else if (b_dtuong.indexOf("TEN_HINHTHUC_DT") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grtdhv);
            if (b_hang < 0) return;
            GridX_datGtri(b_grtdhv, b_hang, ["HINHTHUC_DT"], [a_tso[0]], 'K');
            GridX_datGtri(b_grtdhv, b_hang, ["TEN_HINHTHUC_DT"], [a_tso[1]], 'K');
            $get(b_gchuId).innerHTML = a_tso[0];
        }
        else if (b_dtuong.indexOf("TEN_TRINHDO_HOCVAN") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grtdhv);
            if (b_hang < 0) return;
            GridX_datGtri(b_grtdhv, b_hang, ["TRINHDO_HOCVAN"], [a_tso[0]], 'K');
            GridX_datGtri(b_grtdhv, b_hang, ["TEN_TRINHDO_HOCVAN"], [a_tso[1]], 'K');
            $get(b_gchuId).innerHTML = a_tso[0];
        }
        else if (b_dtuong.indexOf("TEN_CHUYENNGANH") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grtdhv);
            if (b_hang < 0) return;
            GridX_datGtri(b_grtdhv, b_hang, ["CHUYENNGANH"], [a_tso[0]], 'K');
            GridX_datGtri(b_grtdhv, b_hang, ["TEN_CHUYENNGANH"], [a_tso[1]], 'K');
            $get(b_gchuId).innerHTML = a_tso[0];
        }
        else if (b_dtuong.indexOf("TEN_TRINHDO") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grtdhv);
            if (b_hang < 0) return;
            GridX_datGtri(b_grtdhv, b_hang, ["TRINHDO"], [a_tso[0]], 'K');
            GridX_datGtri(b_grtdhv, b_hang, ["TEN_TRINHDO"], [a_tso[1]], 'K');
            $get(b_gchuId).innerHTML = a_tso[0];
        } else if (b_dtuong.indexOf("TEN_TENTRUONG") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grtdhv);
            if (b_hang < 0) return;
            GridX_datGtri(b_grtdhv, b_hang, ["TENTRUONG"], [a_tso[0]], 'K');
            GridX_datGtri(b_grtdhv, b_hang, ["TEN_TENTRUONG"], [a_tso[1]], 'K');
            $get(b_gchuId).innerHTML = a_tso[0];
        }
        else if (b_dtuong.indexOf("TEN_QUANHE") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grqhnt);
            if (b_hang < 0) return;
            GridX_datGtri(b_grqhnt, b_hang, ["QUANHE"], [a_tso[0]], 'K');
            GridX_datGtri(b_grqhnt, b_hang, ["TEN_QUANHE"], [a_tso[1]], 'K');
            $get(b_gchuId).innerHTML = a_tso[0];
        }
        else if (b_dtuong.indexOf("CHONKHO_UV") >= 0) {
            form_P_LOI("loi:Gán thành công!:loi");
            ns_td_uv_yeucauTD_P_LKE('K');
        }
        else if (b_dtuong.indexOf("CT") >= 0) {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "')", 200);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}
function P_cho(b_so_the) {
    try {
        if (b_doi == 0) {
            $get(b_gocId).value = b_so_the;
            $get(b_gocId).focus();
            b_doi = 1;
            clearTimeout(b_cho_control);
        }
    }
    catch (err) { b_doi = 0; }
}

function ns_td_uv_yeucauTD_P_KTRA_DR(b_maTen) {
    try {
        var b_ma = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "TT_NOISINH": b_ma = form_Fs_TEN_GTRI(b_vungId, 'tt_noisinh'); break;
            case "QH_NOISINH": b_ma = form_Fs_TEN_GTRI(b_vungId, 'qh_noisinh'); break;
            case "TT_THUONGTRU": b_ma = form_Fs_TEN_GTRI(b_vungId, 'tt_thuongtru'); break;
            case "QH_THUONGTRU": b_ma = form_Fs_TEN_GTRI(b_vungId, 'qh_thuongtru'); break;
            case "TT_TAMTRU": b_ma = form_Fs_TEN_GTRI(b_vungId, 'tt_tamtru'); break;
            case "QH_TAMTRU": b_ma = form_Fs_TEN_GTRI(b_vungId, 'qh_tamtru'); break;
        }

        if (b_maTen == "TT_NOISINH") {
            $get(b_qh_noisinhId).value = ''; $get(b_xp_noisinhId).value = '';
            var b_ktra = "ns_ma_qh,ma,ten,MA_TT," + b_ma;
            var b_ctr = form_Fctr_TEN_DTUONG(b_vungId, 'qh_noisinh')
            Attribute_P_DAT(b_ctr, 'ham_list', [b_ktra]);
        } else if (b_maTen == "QH_NOISINH") {
            $get(b_xp_noisinhId).value = '';
            var b_ktra = "ns_ma_xp,ma,ten,MA_QH," + b_ma;
            var b_ctr = form_Fctr_TEN_DTUONG(b_vungId, 'xp_noisinh')
            Attribute_P_DAT(b_ctr, 'ham_list', [b_ktra]);
        } else if (b_maTen == "TT_THUONGTRU") {
            $get(b_qh_thuongtruId).value = ''; $get(b_xp_thuongtruId).value = '';
            var b_ktra = "ns_ma_qh,ma,ten,MA_TT," + b_ma;
            var b_ctr = form_Fctr_TEN_DTUONG(b_vungId, 'qh_thuongtru')
            Attribute_P_DAT(b_ctr, 'ham_list', [b_ktra]);

        } else if (b_maTen == "QH_THUONGTRU") {
            $get(b_xp_thuongtruId).value = '';
            var b_ktra = "ns_ma_xp,ma,ten,MA_QH," + b_ma;
            var b_ctr = form_Fctr_TEN_DTUONG(b_vungId, 'xp_thuongtru')
            Attribute_P_DAT(b_ctr, 'ham_list', [b_ktra]);
        } else if (b_maTen == "TT_TAMTRU") {
            $get(b_qh_tamtruId).value = ''; $get(b_xp_tamtruId).value = '';
            var b_ktra = "ns_ma_qh,ma,ten,MA_TT," + b_ma;
            var b_ctr = form_Fctr_TEN_DTUONG(b_vungId, 'qh_tamtru')
            Attribute_P_DAT(b_ctr, 'ham_list', [b_ktra]);
        } else if (b_maTen == "QH_TAMTRU") {
            $get(b_xp_tamtruId).value = '';
            var b_ktra = "ns_ma_xp,ma,ten,MA_QH," + b_ma;
            var b_ctr = form_Fctr_TEN_DTUONG(b_vungId, 'xp_tamtru')
            Attribute_P_DAT(b_ctr, 'ham_list', [b_ktra]);
        }
    }
    catch (err) {
        form_P_LOI(err);
    }
}
// Kiểm tra
function ns_td_uv_yeucauTD_P_KTRA(b_maTen) {
    try {
        var b_dt_mayeucau = 'DT_MAYEUCAU_TD';
        var b_maId = "";
        b_mt = b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "NAM": b_maId = b_namId; break;
            case "MAYEUCAU_TD": b_maId = b_ma_yeucauId; break;
        }
        if (window.name == "ns_td_chuyen_uv_nv") {
            switch (b_maTen) {
                case "NAM": b_maId = form_Fs_TEN_ID(b_vungId, 'nam'); b_ma_yeucauId = form_Fs_TEN_ID(b_vungId, 'mayeucau_td'); break;
                case "NAMTK": b_maId = form_Fs_TEN_ID('', 'namtk'); b_ma_yeucauId = form_Fs_TEN_ID('', 'ma_yc_tk'); b_dt_mayeucau = 'DT_MA_YC_TK'; break;
            }
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        else if (b_maTen == "NAM" || b_maTen == "NAMTK") {
            var b_nam = $get(b_maId).value;
            sns_td.Fs_NS_TD_DEXUAT_LKE_BY_NAM(form_Fs_nsd(), window.name, b_dt_mayeucau, b_nam, ns_td_uv_yeucauTD_P_KTRA_DR_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        } else if (b_maTen == "MAYEUCAU_TD") {
            var b_nam = $get(form_Fs_TEN_ID(b_vungId, 'nam')).value, b_yeucau = lke_Fs_TRA($get(b_ma_yeucauId));
            sns_td.Fs_TD_DEXUAT_BYMA(form_Fs_nsd(), b_nam, b_yeucau, ns_td_uv_yeucauTD_P_THONGTIN_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_td_uv_yeucauTD_P_KTRA_DR_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (window.name == "ns_td_chuyen_uv_nv") {
        drop_P_LKE(b_ma_yeucauId, b_kq);
    }

}
function ns_td_uv_yeucauTD_P_THONGTIN_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');

    $get(b_ten_cdanhId).value = a_kq[0];
    $get(b_ten_phongId).value = a_kq[2];

}

function ns_td_uv_yeucauTD_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else if (b_mt == "SO_THE_GT") { $get(b_ten_gtId).value = b_kq; }
    else form_P_DatGchu(b_gchuId, b_kq);
}
function Fs_ns_td_uv_yeucauTD_HOI_KQ(b_kq) {
    var a_kq = b_kq.split('#');
    var b_phongId = $get(b_phongId_tkId).value;
    if (b_phongId != a_kq[1] && a_kq[1] != '') {
        $get(b_phongId_tkId).value = a_kq[1];
        b_ns_td_uv_yeucauTD_chuyenhang_cho = setInterval('ns_td_uv_yeucauTD_P_MA_KTRA()', 200);
    }
    else {
        GridX_thoiA(b_grlkeId);
        b_ns_td_uv_yeucauTD_chuyenhang_cho = setInterval('ns_td_uv_yeucauTD_P_MA_KTRA()', 200);
    }
}
function ns_td_uv_yeucauTD_P_MA_KTRA() {
    try {
        clearTimeout(b_ns_td_uv_yeucauTD_chuyenhang_cho);
        var b_so_the = C_NVL($get(b_gocId).value);
        if (b_so_the != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_phongId = $get(b_phongId_tkId).value;
            sns_tt.Fs_ns_td_uv_yeucauTD_MA(b_phongId, b_so_the, b_lke, b_TrangKt, a_cot, ns_td_uv_yeucauTD_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_uv_yeucauTD_P_MA_KTRA_KQ(b_kq) {
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
    else { GridX_datA(b_grlkeId, b_hang); ns_td_uv_yeucauTD_P_CHUYEN_HANG(); }
    return false;
}
// Nhập 
function ns_td_uv_yeucauTD_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId); GridX_datTrang(b_grtdhv); GridX_datTrang(b_grqtct); GridX_datTrang(b_grqhnt); GridX_datTrang(b_grcc);
    $get(b_dantocId).value = ""; $get(b_tongiaoId).value = ""; $get(b_gioitinhId).value = ""; $get(b_noicapId).value = ""; $get(b_tt_honnhanId).value = "";
    $get(b_so_idId).value = "0";
    lke_P_DAT($get(b_trangthai_uv_theoycId), 'GYC' + '{' + 'Ứng viên đã gán vào yêu cầu');
    var b_kytudau = "UV", b_tenbang = "NS_TD_UV_CV", b_tencot = "SO_THE";
    hts_dungchung.Fs_AutoGenCode(b_kytudau, b_tenbang, b_tencot, ns_td_uv_yeucauTD_P_MOI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_gocId).focus();
    return false;
}
function ns_td_uv_yeucauTD_P_MOI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        $get(b_gocId).value = b_kq;
    }
}
function ns_td_uv_yeucauTD_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        else {
            var b_so_id = $get(b_so_idId).value;
            var a_dt = form_Faa_TEXT_ROW(b_vungId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            a_dt_td = GridX_Fdt_cotGtri(b_grtdhv), a_dt_tdnn = GridX_Fdt_cotGtri(b_grtdnn), a_dt_cc = GridX_Fdt_cotGtri(b_grcc), a_dt_ct = GridX_Fdt_cotGtri(b_grqtct), a_dt_nt = GridX_Fdt_cotGtri(b_grqhnt), a_dt_ttk = GridX_Fdt_cotGtri(b_grttk)
            b_yeucau_tk = lke_Fs_TRA($get(b_ma_yctkId)), b_trangthai_uv_theoyc_tk = lke_Fs_TRA($get(b_trangthai_uv_theoyc_tkId));
            sns_td.Fs_NS_TD_GAN_UV_NH(form_Fs_nsd(), b_yeucau_tk, b_trangthai_uv_theoyc_tk, b_TrangKt, a_dt, a_dt_td, a_dt_tdnn, a_dt_cc, a_dt_ct, a_dt_nt, a_dt_ttk, a_cot_lke, ns_td_uv_yeucauTD_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_td_uv_yeucauTD_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI("loi:Nhập thành công:loi");
    }
}
// Xóa
function ns_td_uv_yeucauTD_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) {
        form_P_LOI("loi:Chưa chọn nhân viên cần xóa:loi");
        return false;
    }
    try {
        var b_so_the = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the"), b_ma_yc = GridX_Fas_layGtri(b_grlkeId, b_hang, "mayeucau_td");
        if (b_so_the == "") ns_td_uv_yeucauTD_P_MOI();
        else {
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
                b_yeucau_tk = lke_Fs_TRA($get(b_ma_yctkId)), b_trangthai_uv_theoyc_tk = lke_Fs_TRA($get(b_trangthai_uv_theoyc_tkId));
            sns_td.Fs_NS_TD_GAN_UV_XOA(form_Fs_nsd(), b_ma_yc, b_so_the, b_yeucau_tk, b_trangthai_uv_theoyc_tk, a_tso, a_cot, ns_td_uv_yeucauTD_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }

}
function ns_td_uv_yeucauTD_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI("loi:Xóa thành công!:loi");
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_td_uv_yeucauTD_P_MOI();
        else {
            GridX_datA(b_grlkeId, b_hang);
            ns_td_uv_yeucauTD_P_CHUYEN_HANG();
        }
    }
}
// chuyển hàng
function ns_td_uv_yeucauTD_GR_lke_RowChange() {
    if (ns_td_uv_yeucauTD_choAct != 0) clearTimeout(ns_td_uv_yeucauTD_choAct);
    ns_td_uv_yeucauTD_choAct = setTimeout("ns_td_uv_yeucauTD_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_td_uv_yeucauTD_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_the = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the"));
        b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_the == "") ns_td_uv_yeucauTD_P_MOI();
        else {

            var a_cot_td = GridX_Fas_tenCot(b_grtdhv), a_cot_tdnn = GridX_Fas_tenCot(b_grtdnn), a_cot_cc = GridX_Fas_tenCot(b_grcc), a_cot_ct = GridX_Fas_tenCot(b_grqtct), a_cot_nt = GridX_Fas_tenCot(b_grqhnt), a_cot_ttk = GridX_Fas_tenCot(b_grttk);
            sns_td.Fs_NS_TD_GAN_UV_CT(form_Fs_nsd(), b_so_the, a_cot_td, a_cot_tdnn, a_cot_cc, a_cot_ct, a_cot_nt, a_cot_ttk, ns_td_uv_yeucauTD_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);

        }
        $get(b_so_idId).value = b_so_id;
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_uv_yeucauTD_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grtdhv); else GridX_datBang(b_grtdhv, a_kq[1]);
    if (a_kq[2] == "") GridX_datTrang(b_grcc); else GridX_datBang(b_grcc, a_kq[2]);
    if (a_kq[3] == "") GridX_datTrang(b_grqtct); else GridX_datBang(b_grqtct, a_kq[3]);
    if (a_kq[4] == "") GridX_datTrang(b_grqhnt); else GridX_datBang(b_grqhnt, a_kq[4]);
    if (a_kq[5] == "") GridX_datTrang(b_grtdnn); else GridX_datBang(b_grtdnn, a_kq[5]);
    if (a_kq[6] == "") GridX_datTrang(b_grttk); else GridX_datBang(b_grttk, a_kq[6]);
    return false;
}
// Liệt kê
function ns_td_uv_yeucauTD_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (ns_td_uv_yeucauTD_lkeCho != 0) clearTimeout(ns_td_uv_yeucauTD_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_td_uv_yeucauTD_P_LKE('K');
    }
    if ($get(b_grlkeId) != null) { clearTimeout(ns_td_uv_yeucauTD_lkeCho); ns_td_uv_yeucauTD_P_LKE('K'); }
}
function ns_td_uv_yeucauTD_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId), b_yeucau_tk = lke_Fs_TRA($get(b_ma_yctkId)), b_trangthai_uv_theoyc_tk = lke_Fs_TRA($get(b_trangthai_uv_theoyc_tkId));
        sns_td.Fs_NS_TD_GAN_UV_LKE(form_Fs_nsd(), b_yeucau_tk, b_trangthai_uv_theoyc_tk, a_tso, a_cot, ns_td_uv_yeucauTD_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_uv_yeucauTD_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}
function ns_td_uv_yeucauTD_td_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grtdhv);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        var b_ktra = C_NVL(b_ctr.ktra), b_ten = C_NVL(b_ctr.ten);
        if (b_value != "") {
            if (b_cot == "TEN_HINHTHUC_DT") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Hình thức đào tạo", b_value, "ns_ma_htdt,ma,ten", ns_td_uv_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
                b_ctr.value = "";
            }
            if (b_cot == "TEN_CHUYENNGANH") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Chuyên ngành", b_value, "ns_ma_cndt,ma,ten", ns_td_uv_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
                b_ctr.value = "";
            }
            if (b_cot == "TEN_TRINHDO") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Trình độ", b_value, "ns_ma_bc,ma,ten", ns_td_uv_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
                b_ctr.value = "";
            }
        }
        if (b_value != "") GridX_ThemHang(b_grtdhv);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_uv_yeucauTD_nt_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grqhnt);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        var b_ktra = C_NVL(b_ctr.ktra), b_ten = C_NVL(b_ctr.ten);
        if (b_value != "") {
            if (b_cot == "TEN_QUANHE") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Quan hệ", b_value, "ns_ma_lqh,ma,ten", ns_td_uv_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
                b_ctr.value = "";
            }

        }
        if (b_value != "") GridX_ThemHang(b_grqhnt);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
// Chọn ứng viên gán vào yêu cầu tuyển dụng
function ns_td_uv_yeucauTD_chonkho() {
    var b_tenf = '/App_form/ns/td/ns_td_uv.aspx';
    if (lke_Fs_TRA($get(b_ma_yeucauId)) == "") { form_P_LOI('Chưa chọn mã yêu cầu tuyển dụng'); return false; }
    var b_thamso = lke_Fs_TRA($get(b_ma_yeucauId)) + "#" + lke_Fs_TRA($get(b_ma_yctkId)) + "#" + lke_Fs_TRA($get(b_trangthai_uv_theoyc_tkId));
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, b_thamso, "ns_td_uv_yeucauTD", "ns_td_uv_yeucauTD", "Chọn ứng viên từ kho"]], null);
    return false;
}
function ns_td_uv_yeucauTD_chonnoibo() {
    var b_tenf = '/App_form/ns/tt/ns_cb.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "ns_td_uv_yeucauTD", "ns_td_uv_yeucauTD", "Chọn ứng viên nội bộ"]], null);
    return false;
}
function ns_td_uv_yeucauTD_nl_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grctId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        var b_ktra = C_NVL(b_ctr.ktra), b_ten = C_NVL(b_ctr.ten);
        if (b_value != "") {
            if (b_cot == "NHOM_NL_TEN") skhac.Fs_MA_LOI(form_Fs_nsd(), "Nhóm năng lực", b_value, "dg_dm_nhom_nl,ma,ten", ns_td_uv_yeucauTD_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            if (b_cot == "NANGLUC_TEN") skhac.Fs_MA_LOI(form_Fs_nsd(), "Năng lực", b_value, "dg_dm_nl,ma,ten", ns_td_uv_yeucauTD_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
        }
        if (b_value != "") GridX_ThemHang(b_grctId);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_uv_yeucauTD_cmt() {
    try {
        var b_tenf = form_Fs_TM() + '/App_form/ns/ma/ns_ma_tt.aspx';
        form_P_MO(b_tenf, null, ["ns_td_uv_yeucauTD", [""]]);
        return false;
    }
    catch (err) { }
}
function ns_td_uv_yeucauTD_P_IMPORT() {
    var b_tenf = b_tmf + '/khud/khud_Excel_Import.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", ["ns_td_uv_yeucauTD"]], null);
    return false;
}
function nhap_file() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) {
        form_P_LOI('loi:Chọn cán bộ trước:loi')
        return false;
    }
    var b_tenf = '/App_form/ns/ma/file_Import_chung.aspx';
    var b_so_the = $get(b_gocId).value;
    form_P_MO(b_tenf, "ns_td_uv", ["THAMSO", ["ns_td_uv", b_so_the, "NS_TD_UV", "Lưu sơ yếu lý lịch"]], null);
    form_P_LOI('');
    return false;
}
function form_dong() {
    location.reload(false);
}