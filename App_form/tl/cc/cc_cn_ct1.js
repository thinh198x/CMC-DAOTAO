var cc_cn_ct_lkecbCho, cc_cn_ct_lkektaoCho, b_tt_luu, cc_cn_ct_choAct = 0, b_aphongId, b_tt = 0, b_akyluongId, b_vungId, b_grngayId, b_loi_id,
    b_grccId, b_sothe_tkId, b_phongId, b_ma_mdinhId, b_vungId2, b_kieuId, b_gocId, b_mt, b_gchuId, b_slideId, b_namId, b_ctyValue, b_ctrbeforId;
function cc_cn_ct_P_KD(b_tm) {
    b_tmf = b_tm; cc_cn_ct_lkektaoCho; cc_cn_ct_lkecbCho;
    cc_cn_ct_lkektaoCho = setInterval('cc_cn_ct_P_LKE_KTAO_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong === undefined && a_tso == "FILE_HTOAN") {
            cc_cn_ct_P_LKE_KHOITAO();
        }
        else {
            if (b_dtuong == null || b_dtuong == "") return;
            b_dtuong = b_dtuong.toUpperCase();
            var b_kq = a_tso[0];
            var gtri_cu;
            if (b_dtuong.indexOf("N1_") >= 0) {
                var b_hang = GridX_Fi_timHangA(b_grccId);
                if (b_hang > -1) { GridX_datGtri(b_grccId, b_hang, "n1", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
            }
            else if (b_dtuong.indexOf("N2_") >= 0) {
                var b_hang = GridX_Fi_timHangA(b_grccId);
                if (b_hang > -1) { GridX_datGtri(b_grccId, b_hang, "n2", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
            }
            else if (b_dtuong.indexOf("N3_") >= 0) {
                var b_hang = GridX_Fi_timHangA(b_grccId);
                if (b_hang > -1) { GridX_datGtri(b_grccId, b_hang, "n3", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
            }
            else if (b_dtuong.indexOf("N4_") >= 0) {
                var b_hang = GridX_Fi_timHangA(b_grccId);
                if (b_hang > -1) { GridX_datGtri(b_grccId, b_hang, "n4", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
            }
            else if (b_dtuong.indexOf("N5_") >= 0) {
                var b_hang = GridX_Fi_timHangA(b_grccId);
                if (b_hang > -1) { GridX_datGtri(b_grccId, b_hang, "n5", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
            }
            else if (b_dtuong.indexOf("N6_") >= 0) {
                var b_hang = GridX_Fi_timHangA(b_grccId);
                if (b_hang > -1) { GridX_datGtri(b_grccId, b_hang, "n6", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
            }
            else if (b_dtuong.indexOf("N7_") >= 0) {
                var b_hang = GridX_Fi_timHangA(b_grccId);
                if (b_hang > -1) { GridX_datGtri(b_grccId, b_hang, "n7", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
            }
            else if (b_dtuong.indexOf("N8_") >= 0) {
                var b_hang = GridX_Fi_timHangA(b_grccId);
                if (b_hang > -1) { GridX_datGtri(b_grccId, b_hang, "n8", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
            }
            else if (b_dtuong.indexOf("N9_") >= 0) {
                var b_hang = GridX_Fi_timHangA(b_grccId);
                if (b_hang > -1) { GridX_datGtri(b_grccId, b_hang, "n9", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
            }
            else if (b_dtuong.indexOf("N10") >= 0) {
                var b_hang = GridX_Fi_timHangA(b_grccId);
                if (b_hang > -1) { GridX_datGtri(b_grccId, b_hang, "n10", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
            }
            else if (b_dtuong.indexOf("N11") >= 0) {
                var b_hang = GridX_Fi_timHangA(b_grccId);
                if (b_hang > -1) { GridX_datGtri(b_grccId, b_hang, "n11", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
            }
            else if (b_dtuong.indexOf("N12") >= 0) {
                var b_hang = GridX_Fi_timHangA(b_grccId);
                if (b_hang > -1) { GridX_datGtri(b_grccId, b_hang, "n12", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
            }
            else if (b_dtuong.indexOf("N13") >= 0) {
                var b_hang = GridX_Fi_timHangA(b_grccId);
                if (b_hang > -1) { GridX_datGtri(b_grccId, b_hang, "n13", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
            }
            else if (b_dtuong.indexOf("N14") >= 0) {
                var b_hang = GridX_Fi_timHangA(b_grccId);
                if (b_hang > -1) { GridX_datGtri(b_grccId, b_hang, "n14", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
            }
            else if (b_dtuong.indexOf("N15") >= 0) {
                var b_hang = GridX_Fi_timHangA(b_grccId);
                if (b_hang > -1) { GridX_datGtri(b_grccId, b_hang, "n15", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
            }
            else if (b_dtuong.indexOf("N16") >= 0) {
                var b_hang = GridX_Fi_timHangA(b_grccId);
                if (b_hang > -1) { GridX_datGtri(b_grccId, b_hang, "n16", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
            }
            else if (b_dtuong.indexOf("N17") >= 0) {
                var b_hang = GridX_Fi_timHangA(b_grccId);
                if (b_hang > -1) { GridX_datGtri(b_grccId, b_hang, "n17", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
            }
            else if (b_dtuong.indexOf("N18") >= 0) {
                var b_hang = GridX_Fi_timHangA(b_grccId);
                if (b_hang > -1) { GridX_datGtri(b_grccId, b_hang, "n18", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
            }
            else if (b_dtuong.indexOf("N19") >= 0) {
                var b_hang = GridX_Fi_timHangA(b_grccId);
                if (b_hang > -1) { GridX_datGtri(b_grccId, b_hang, "n19", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
            }
            else if (b_dtuong.indexOf("N20") >= 0) {
                var b_hang = GridX_Fi_timHangA(b_grccId);
                if (b_hang > -1) { GridX_datGtri(b_grccId, b_hang, "n20", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
            }
            else if (b_dtuong.indexOf("N21") >= 0) {
                var b_hang = GridX_Fi_timHangA(b_grccId);
                if (b_hang > -1) { GridX_datGtri(b_grccId, b_hang, "n21", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
            }
            else if (b_dtuong.indexOf("N22") >= 0) {
                var b_hang = GridX_Fi_timHangA(b_grccId);
                if (b_hang > -1) { GridX_datGtri(b_grccId, b_hang, "n22", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
            }
            else if (b_dtuong.indexOf("N23") >= 0) {
                var b_hang = GridX_Fi_timHangA(b_grccId);
                if (b_hang > -1) { GridX_datGtri(b_grccId, b_hang, "n23", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
            }
            else if (b_dtuong.indexOf("N24") >= 0) {
                var b_hang = GridX_Fi_timHangA(b_grccId);
                if (b_hang > -1) { GridX_datGtri(b_grccId, b_hang, "n24", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
            }
            else if (b_dtuong.indexOf("N25") >= 0) {
                var b_hang = GridX_Fi_timHangA(b_grccId);
                if (b_hang > -1) { GridX_datGtri(b_grccId, b_hang, "n25", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
            }
            else if (b_dtuong.indexOf("N26") >= 0) {
                var b_hang = GridX_Fi_timHangA(b_grccId);
                if (b_hang > -1) { GridX_datGtri(b_grccId, b_hang, "n26", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
            }
            else if (b_dtuong.indexOf("N27") >= 0) {
                var b_hang = GridX_Fi_timHangA(b_grccId);
                if (b_hang > -1) { GridX_datGtri(b_grccId, b_hang, "n27", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
            }
            else if (b_dtuong.indexOf("N28") >= 0) {
                var b_hang = GridX_Fi_timHangA(b_grccId);
                if (b_hang > -1) { GridX_datGtri(b_grccId, b_hang, "n28", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
            }
            else if (b_dtuong.indexOf("N29") >= 0) {
                var b_hang = GridX_Fi_timHangA(b_grccId);
                if (b_hang > -1) { GridX_datGtri(b_grccId, b_hang, "n29", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
            }
            else if (b_dtuong.indexOf("N30") >= 0) {
                var b_hang = GridX_Fi_timHangA(b_grccId);
                if (b_hang > -1) { GridX_datGtri(b_grccId, b_hang, "n30", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
            }
            else if (b_dtuong.indexOf("N31") >= 0) {
                var b_hang = GridX_Fi_timHangA(b_grccId);
                if (b_hang > -1) { GridX_datGtri(b_grccId, b_hang, "n31", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
            }
            else if (b_dtuong.indexOf("MA_MDINH") >= 0) {
                $get(b_ma_mdinhId).value = b_kq; $get(b_gchuId).innerHTML = a_tso[1];
            }
            else if (b_dtuong.indexOf("FILE_CC") >= 0) {
                var a_cot = GridX_Fas_tenCot(b_grccId);
                stl_cc.Fs_FILE(form_Fs_nsd(), window.name, a_cot, cc_cn_ct_P_EXCEL_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                return false;
            }
            else if (b_dtuong.indexOf("DAYPHONG") >= 0) {
                lke_Fs_TRA($get(b_phongId)) = a_tso[0];
                cc_cn_ct_P_MOI();
                var b_thang = lke_Fs_TRA($get(b_thangccId));
                cc_cn_ct_P_LKE_CT(b_thang);
            } else if (b_dtuong.indexOf("TAI_IMPORT") >= 0) {
                cc_cn_ct_P_KTRA("KYLUONG");
            }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function cc_cn_ct_P_EXCEL_KQ(b_kq) {
    try {
        if (b_kq == "") return;
        else {
            var a_kq = b_kq.split('#');
            GridX_datBang(b_grccId, a_kq[0]);
            GridX_dat_hangkt(b_grccId, a_kq[1]);
            cc_cn_ct_doimau();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function cc_cn_ct_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grccId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        b_mt = b_cot;
        if (b_value != "") {
            if (b_cot == "N1" || b_cot == "N2" || b_cot == "N3" || b_cot == "N4" || b_cot == "N5" || b_cot == "N6" || b_cot == "N7" || b_cot == "N8" || b_cot == "N9" ||
        b_cot == "N10" || b_cot == "N11" || b_cot == "N12" || b_cot == "N13" || b_cot == "N14" || b_cot == "N15" || b_cot == "N16" || b_cot == "N17" || b_cot == "N18" || b_cot == "N19" ||
        b_cot == "N20" || b_cot == "N21" || b_cot == "N22" || b_cot == "N23" || b_cot == "N24" || b_cot == "N25" || b_cot == "N26" || b_cot == "N27" || b_cot == "N28" || b_cot == "N29" ||
        b_cot == "N30" || b_cot == "N31") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Mã chấm công", b_value, "ns_cc_ma_cc,ma,ten", cc_cn_ct_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        if (b_value != "") GridX_ThemHang(b_grccId);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function cc_cn_ct_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        b_mt = b_maTen;
        switch (b_maTen) {
            case "PHONG": b_maId = b_phongId; break;
            case "KYLUONG": b_maId = b_thangccId; break;
            case "MA_MDINH": b_maId = b_ma_mdinhId; break;
        }
        var b_ma = $get(b_maId),
            b_ma_value = C_NVL(b_ma.value);
        if (b_ma == null || b_ma_value == "") return;
        if (b_maTen == "PHONG") {
            cc_cn_ct_P_MOI();
            var b_thang = lke_Fs_TRA($get(b_thangccId)), b_ngayd = $get(b_ngaydId).value;
            $get(b_aphongId).value = lke_Fs_TRA($get(b_phongId));
            if (b_thang != "") cc_cn_ct_P_LKE_CT(b_thang);
            if (b_ngayd != "") cc_cn_ct_ngay_by_kyluong();
        }
        else if (b_maTen == "KYLUONG") {
            cc_cn_ct_P_MOI();
            var b_thang = lke_Fs_TRA($get(b_thangccId));
            $get(b_aphongId).value = lke_Fs_TRA($get(b_phongId));
            $get(b_akyluongId).value = lke_Fs_TRA($get(b_thangccId));
            cc_cn_ct_P_LKE_CT(b_thang);
            cc_cn_ct_ngay_by_kyluong();
        }
        else if (b_maTen == "MA_MDINH") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), cc_cn_ct_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}

function cc_cn_ct_ngay_by_kyluong() {
    var b_thang = lke_Fs_TRA($get(b_thangccId)),
                b_ngayd = $get(b_ngaydId).value,
                b_phong = lke_Fs_TRA($get(b_phongId)),
                a_cot = GridX_Fas_tenCot(b_grngayId);
    var b_i = b_thang.indexOf("/");
    if (b_i < 0) { b_thang = b_thang.substring(0, 2) + "/" + b_thang.substring(2); }
    var b_so_id = lke_Fs_TRA($get(b_thangccId));
    stl_cc.Fs_CC_CN_CT_TEM_NGAY_LKE(form_Fs_nsd(), 2, b_so_id, b_ngayd, b_phong, a_cot, cc_cn_ct_NGAY_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function cc_cn_ct_NGAY_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    $get(b_t7Id).value = a_kq[2];
    $get(b_cnId).value = a_kq[3];
    form_P_CH_TEXT(b_vungId2, a_kq[4]);
    if (a_kq[1] == "") GridX_datTrang(b_gridId);
    else GridX_datBang(b_grngayId, a_kq[1]);
    cc_cn_ct_doimau();
    return false;
}
function cc_cn_ct_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; } else {
    }
    $get(b_gchuId).innerHTML = b_kq;
}
function cc_cn_ct_P_LKE_CB_CHO() {
    if ($get(b_grccId) != null) { clearTimeout(cc_cn_ct_lkecbCho); cc_cn_ct_P_LKE_CB(); }
}
function cc_cn_ct_P_LKE_KTAO_CHO() {
    if (document.readyState === 'complete') {
        b_vungId = form_Fs_VUNG_ID('UPa_ct'); b_vungId2 = form_Fs_VUNG_ID('UPa_nhap'); b_grngayId = form_Fs_VUNG_ID('GR_ngay');
        b_grccId = form_Fs_VUNG_ID('GR_lke'); b_aphongId = form_Fs_TEN_ID('UPa_hi', 'aphong'), b_akyluongId = form_Fs_TEN_ID('UPa_hi', 'akyluong');
        b_phongId = form_Fs_TEN_ID(b_vungId, 'PHONG');
        b_sothe_tkId = form_Fs_TEN_ID(b_vungId, 'so_the_tk');
        b_thangccId = form_Fs_TEN_ID(b_vungId, 'KYLUONG'); b_ngaydId = form_Fs_TEN_ID(b_vungId, 'ngayd'); b_namId = form_Fs_TEN_ID(b_vungId, 'nam'); b_ngaylamId = form_Fs_TEN_ID(b_vungId, 'ngaylam');
        b_t7Id = form_Fs_VTEN_ID('UPa_hi', 't7'); b_cnId = form_Fs_VTEN_ID('UPa_hi', 'cn'); b_thumucId = form_Fs_VTEN_ID('UPa_hi', 'thumuc');
        b_ma_mdinhId = form_Fs_VTEN_ID('', 'MA_MDINH'), b_kieuId = form_Fs_VTEN_ID('', 'kieu');
        b_gchuId = form_Fs_VTEN_ID('', 'gchu');
        b_tu_ngayId = form_Fs_VTEN_ID('', 'tu_ngay'), b_toi_ngayId = form_Fs_VTEN_ID('', 'toi_ngay');
        lke_P_DAT($get(b_phongId), 'TATCA' + '{' + 'Tất cả');
        if (cc_cn_ct_lkektaoCho != 0) clearTimeout(cc_cn_ct_lkektaoCho);
        b_slideId = $get(b_grccId).getAttribute('slideId');
        form_F_GOC().P_MENUBf(window.name, 'M');
        vb_cctc_P_SL('', 'D', '0', ' ', ' ', 'T');
        b_ctyValue = "TATCA";
        cc_cn_ct_P_CT_KYLUONG();
    }
}
function cc_cn_ct_P_CT_KYLUONG() {
    try {
        var b_form = "cc_cn_ct", b_nam = "DT_NAM_TK", b_thang = "DT_KY";
        hts_dungchung.Fs_NS_CC_KY(form_Fs_nsd(), b_form, b_nam, b_thang, cc_cn_ct_P_CT_KYLUONG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function cc_cn_ct_P_CT_KYLUONG_KQ(b_kq) {
    if (b_kq != "") {
        form_P_CH_TEXT(b_vungId, b_kq);
    }
    cc_cn_ct_P_KTRA("KYLUONG");
}
function cc_cn_ct_P_LKE_KHOITAO() {
    var b_phong = lke_Fs_TRA($get(b_phongId)), b_thang = lke_Fs_TRA($get(b_thangccId)), b_ngaydId = $get(b_grngayId).value;
    if (b_thang != null && b_thang != "") {
        //var a_cot_cc = GridX_Fas_tenCot(b_grccId), a_tso = slide_Faobj_TUDEN(b_slideId);
        //stl_cc.Fs_CC_CN_CT_CT(form_Fs_nsd(), b_phong, b_thang, a_cot_cc, a_tso, cc_cn_ct_P_LKE_CT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        //cc_cn_ct_P_KTRA("KYLUONG");
        //return false;
        cc_cn_ct_P_LKE_CT(b_thang);
    } else slide_P_SOTRANG(b_slideId, 0, 0);
}
function cc_cn_ct_P_LKE_CB() {
    try {
        var b_sothe = $get(b_sothe_tkId).value;
        var b_phong = lke_Fs_TRA($get(b_phongId)), a_cot = GridX_Fas_tenCot(b_grccId);
        stl_cc.Fs_CC_CN_CT_LKE_CB(form_Fs_nsd(), b_phong,b_sothe, a_cot, cc_cn_ct_P_LKE_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function cc_cn_ct_P_LKE_CB_KQ(b_kq) {
    if (b_kq == "") { GridX_datTrang(b_grccId); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        GridX_dat_hangkt(b_grccId, a_kq[1]);
        GridX_datBang(b_grccId, a_kq[0]);
        slide_P_SOTRANG(b_slideId, a_kq[5], 0);
        return;
    }
}
function cc_cn_ct_P_MOI() {
    try {
        form_P_MOI(b_vungId, "XL");
        var b_ngay = "Thứ|||||||||||||||||||||||||||||||;Ngày|||||||||||||||||||||||||||||||";
        var b_vitri = GridX_Fi_timHangT(b_grccId);
        for (var i = 1; i < b_vitri; i++) {
            for (var j = 1; j <= 31; j++) {
                var b_cot = "n" + j;
                GridX_datGtri(b_grccId, i, b_cot, "");
            }
        }
        return false;
    }
    catch (err) { throw (err); }
}
function cc_cn_ct_P_MOI_XOA() {
    try {
        form_P_MOI(b_vungId, "XL");
        var b_ngay = "Thứ|||||||||||||||||||||||||||||||;Ngày|||||||||||||||||||||||||||||||";
        var b_vitri = GridX_Fi_timHangT(b_grccId);
        for (var i = 1; i < b_vitri; i++) {
            for (var j = 1; j <= 31; j++) {
                var b_cot = "n" + j;
                GridX_datGtri(b_grccId, i, b_cot, "");
            }
        }
        return false;
    }
    catch (err) { throw (err); }
}
function cc_cn_ct_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { alert(b_loi); return false; }
        if (b_loi_id == "1") {
            form_P_LOI("loi:Mã chấm công chưa được đăng ký:loi");
            return false;
        }
        var b_t7 = $get(b_t7Id).value, b_cn = $get(b_cnId).value;
        var a_dt = form_Faa_TEXT_ROW(b_vungId),
            a_dt_ngay = GridX_Fdt_cotGtri(b_grngayId),
            a_dt_cc = GridX_Fdt_cotGtri(b_grccId);

        stl_cc.Fs_CC_CN_CT_NH(form_Fs_nsd(), a_dt, a_dt_cc, b_t7, b_cn, cc_cn_ct_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { throw (err); }
}
function tl_phanca_kiemtra() {
    var b_vitri = GridX_Fi_timHangT(b_grccId);
    for (var i = 1; i < b_vitri; i++) {
        for (var j = 1; j <= 31; j++) {
            var b_cot = "n" + j;
            b_gtri_cu = GridX_Fas_layGtri(b_grccId, i, b_cot);
            if (b_gtri_cu != "") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Mã chấm công", b_gtri_cu.toUpperCase(), "ns_cc_ma_cc,ma,ten", cc_cn_ct_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
    }
    return b_tt_luu;
}
function cc_cn_ct_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        //cc_cn_ct_P_LKE_KHOITAO();
        return false;
    }
    else { alert("Đã nhập thành công!"); }
}
function cc_cn_ct_P_LKE_CT(b_thang) {
    var b_phong = lke_Fs_TRA($get(b_phongId)); var b_sothe = $get(b_sothe_tkId).value;
    if (b_thang != null && b_thang != "") {
        var a_cot_cc = GridX_Fas_tenCot(b_grccId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_cc.Fs_CC_CN_CT_CT(form_Fs_nsd(), b_phong,b_sothe, b_thang, a_cot_cc, a_tso, cc_cn_ct_P_LKE_CT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    } else slide_P_SOTRANG(b_slideId, 0, 0);
}
function cc_cn_ct_P_LKE_CT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    if (b_kq == '####0') {
        var b_ngay = "Thứ|||||||||||||||||||||||||||||||;Ngày|||||||||||||||||||||||||||||||";
        cc_cn_ct_P_LKE_CB();
        cc_cn_ct_doimau();
    }
    else {
        var a_kq = b_kq.split('#');
        if (a_kq[1] == "") return;
        else {
            GridX_datBang(b_grccId, a_kq[1]);
            slide_P_SOTRANG(b_slideId, a_kq[5], 0);
        }
    }
    cc_cn_ct_mau();
}
function cc_cn_ct_P_XOA() {
    try {
        var b_phong = lke_Fs_TRA($get(b_phongId)), b_thang = lke_Fs_TRA($get(b_thangccId)), b_ngay = $get(b_ngaydId).value;
        var b_sothe = $get(b_sothe_tkId).value;
        stl_cc.Fs_CC_CN_CT_XOA(form_Fs_nsd(), b_phong,b_sothe, b_thang, b_ngay, cc_cn_ct_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return true;
    }
    catch (err) { throw (err); }
}
function cc_cn_ct_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    alert("Đã xóa thành công!");
    cc_cn_ct_P_MOI_XOA();
}
function cc_cn_ct_P_NAM() {
    try {
        var b_nam = form_Fs_TEN_GTRI(b_vungId, 'nam');
        form_P_MOI(b_vungId, "G");
        stl_cc.Fs_CC_CN_CT_KYLUONG_LKE(form_Fs_nsd(), b_nam, cc_cn_ct_P_NAM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function cc_cn_ct_P_NAM_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else { cc_cn_ct_P_KTRA("KYLUONG"); }
}
function cc_ma_cc_P_MACDINH(b_kq) {
    var b_kieu = $get(b_kieuId).value;
    var b_check_kq = "";
    var b_vitri = GridX_Fi_timHangT(b_grccId);
    var b_tu_ngay = $get(b_tu_ngayId).value, b_toi_ngay = $get(b_toi_ngayId).value;
    var a_cot = GridX_Fas_tenCot(b_grccId), b_gtricheck = $get(b_ma_mdinhId).value;
    if (b_gtricheck == "") {
        form_P_LOI("loi:Chưa chọn ca mặc định:loi"); return false;
    }
    if (b_toi_ngay > 31) {
        form_P_LOI("loi:Tới ngày không được lớn hơn 31:loi"); return false;
    }
    if (b_tu_ngay == "" || b_toi_ngay == "") {
        form_P_LOI("loi:Chưa nhập từ ngày hoặc tới ngày:loi"); return false;
    }
    if (CSO_SO(b_tu_ngay) > CSO_SO(b_toi_ngay)) {
        form_P_LOI("loi:Từ ngày không được lớn hơn đến ngày:loi"); return false;
    }
    var b_hang = GridX_Fi_timHangA(b_grccId);
    var b_so_the = GridX_Fas_layGtri(b_grccId, b_hang, "so_the");
    if (b_so_the == '') {
        form_P_LOI("loi:Bạn chưa chọn hàng xếp kiểu công:loi"); return false;
    }
    if (b_kieu == "T") {
        for (var i = 1; i < b_vitri; i++) {
            for (var j = 1; j <= 31; j++) {
                var b_gtri_cu = "";
                var b_cot = "n" + j;
                var b_gtri = GridX_Fas_layGtri(b_grngayId, 1, b_cot);
                var b_ngay = GridX_Fas_layGtri(b_grngayId, 2, b_cot);
                if (b_ngay >= b_tu_ngay && b_ngay <= b_toi_ngay && b_gtri != null && b_gtri != "" && b_gtri != "CN") {
                    b_gtri_cu = GridX_Fas_layGtri(b_grccId, i, b_cot);
                    if (C_NVL(b_gtri_cu) != "") continue;
                    else b_check_kq = b_gtricheck;
                    GridX_datGtri(b_grccId, i, b_cot, b_check_kq)
                }
            }
        }
    }

    else if (b_kieu == "C") {
        var b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        var b_vitri = GridX_Fi_timHangT(b_grccId);
        if (b_cot > 0) {
            for (var i = 1; i < b_vitri; i++) {
                var b_gtri_cu = "";
                b_gtri_cu = GridX_Fas_layGtri(b_grccId, i, b_cot);
                if (C_NVL(b_gtri_cu) != "") continue;
                else b_check_kq = b_gtricheck;
                GridX_datGtri(b_grccId, i, b_cot, b_check_kq)
            }
        }
    }
    else {
        var b_hang = GridX_Fi_timHangA(b_grccId);
        if (b_hang > 0) {
            for (var j = 1; j <= 31; j++) {
                var b_gtri_cu = "";
                var b_cot = "n" + j;
                var b_ngay = GridX_Fas_layGtri(b_grngayId, 2, b_cot);
                var b_gtri = GridX_Fas_layGtri(b_grngayId, 1, b_cot);
                if (b_ngay >= b_tu_ngay && b_ngay <= b_toi_ngay && b_gtri != null && b_gtri != "" && b_gtri != "CN") {
                    b_gtri_cu = GridX_Fas_layGtri(b_grccId, b_hang, b_cot);
                    if (C_NVL(b_gtri_cu) != "") continue;
                    else b_check_kq = b_gtricheck;
                    GridX_datGtri(b_grccId, b_hang, b_cot, b_check_kq)
                }
            }
        }
        else return;
    }
    return "";
}
function cc_cn_ct_doimau() {
    var b_hangngay = GridX_Fi_hangSo(b_grngayId), b_hangcc = GridX_Fi_hangSo(b_grccId);
    for (var j = 1; j <= 31; j++) {
        var b_cot = "n" + j;
        var b_gtri = GridX_Fas_layGtri(b_grngayId, 1, b_cot);
        switch (b_gtri) {
            case 'CN':
                {// doi mau tren luoi ngay thang
                    for (var i = 1; i <= b_hangngay; i++) {
                        GridX_P_MauCell(b_grngayId, i, j + 1, "#F62217", "#000000");
                    }
                    break;
                }
            case 'T.7':
                {// doi mau tren luoi ngay thang
                    for (var i = 1; i <= b_hangngay; i++) {
                        GridX_P_MauCell(b_grngayId, i, j + 1, "#FFE87C", "#000000");
                    }
                    break;
                }
            default:
                {// doi mau tren luoi ngay thang
                    for (var i = 1; i <= b_hangngay; i++) {
                        GridX_P_MauCell(b_grngayId, i, j + 1, "#FFFFFF", "#000000");
                    }
                    // doi mau luoi cham cong
                    for (var i = 1; i <= b_hangcc; i++) {
                        GridX_P_MauCell(b_grccId, i, j + 2, "#FFFFFF", "#000000");
                        var b_ctr = GridX_Fctr_TimCtr(b_grccId, i, b_cot);
                        b_ctr.style.backgroundColor = "#FFFFFF";
                    }
                    break;
                }
        }
    }
}

function cc_cn_ct_mau() {
    var b_hangngay = GridX_Fi_hangSo(b_grngayId), b_hangcc = GridX_Fi_hangSo(b_grccId);
    for (var j = 1; j <= 31; j++) {
        var b_cot = "d" + j;
        for (var i = 1; i <= b_hangcc; i++) {
            var b_gtri = GridX_Fas_layGtri(b_grccId, i, b_cot);
            if (b_gtri == '1')
                GridX_P_MauCell(b_grccId, i, j + 1, "#F62217", "#000000");
        }
    }
}
function GridX_P_MauCell(gridId, b_hang, b_cot, b_nen, b_chu) {
    try {
        var a_cell = $get(gridId).rows[b_hang].cells;
        var b_row = $get(gridId).rows[b_hang], b_cellId = "";
        if (C_NVL(b_nen) != "") a_cell[b_cot].style.backgroundColor = b_nen;
        if (C_NVL(b_chu) != "") a_cell[b_cot].style.color = b_chu;
    }
    catch (ex) { }
}
function cc_cn_ct_P_FILES() {
    var b_tenf = '/App_form/ns/ma/file_Import_chung.aspx';
    //form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "CC_CN_CT", "BangCongTay", "Attach file bảng công"]], null);
    form_P_MO(b_tenf, window.name + ',THAMSO', ['THAMSO', [window.name, 'NS_HDNS_MA_VTCDANH', null, "Import mã chức danh"]], null);
    form_P_LOI('');
    return false;
}
function GridX_Fctr_TimCtr(gridId, b_hang, b_cot) {
    try {
        var a_cot = GridX_Fas_tenCot(gridId);
        var b_icot = Fi_vtri_mang(a_cot, b_cot) + 1;
        var b_cell = $get(gridId).rows[b_hang].cells[b_icot], b_kq = null
        var a_ctr = b_cell.getElementsByTagName('input');
        if (a_ctr.length > 0) b_kq = a_ctr[0];
        else {
            a_ctr = b_cell.getElementsByTagName('select');
            if (a_ctr.length > 0) b_kq = a_ctr[0];
            else {
                a_ctr = b_cell.getElementsByTagName('span');
                if (a_ctr.length > 0) b_kq = a_ctr[0];
            }
        }
        return b_kq;
    }
    catch (err) { return null; }
}
function cc_cn_ct_GR_lke_RowChange() {
    if (cc_cn_ct_choAct != 0) clearTimeout(cc_cn_ct_choAct);
    cc_cn_ct_choAct = setTimeout("cc_cn_ct_doimau()", 300);
    return false;
}
function cc_cn_ct_phong() {
    try {
        var b_tenf = form_Fs_TM() + '/App_form/ht/ht_maph.aspx';
        form_P_MO(b_tenf, null, ["cc_cn_ct", [""]]);
        return false;
    }
    catch (err) { }
}
function GridX_dat_hangkt(b_gridx, sodong) {
    try {
        var b_grid = $get(b_gridx);
        b_grid.setAttribute('hangKt', '20');
        var b_hangkt = GridX_Fi_hangKt(b_gridx);
        if (sodong > b_hangkt) {
            b_grid.setAttribute('hangKt', sodong - b_hangkt + 21);
        }
        return false;
    } catch (err) { form_P_LOI(err); }
}
function cc_cn_ct_P_TIMKIEM() {
    var b_tim = $get(b_timId).value;
}
function form_dong() {
    location.reload(false);
}
function cc_cn_ct_P_EXPORT() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var b_btn_excel = form_Fs_VTEN_ID('', 'btn_excel_mau');
    $get(b_btn_excel).click(); form_chay = 0;
}
function cc_cn_ct_P_IN() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
}
function cc_cn_ct_P_IMPORT() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var b_thang = lke_Fs_TRA($get(b_thangccId));
    var b_phong = lke_Fs_TRA($get(b_phongId));
    var b_tenf = '/App_form/ns/ma/file_Import.aspx';
    form_P_MO(b_tenf, window.name + ',THAMSO', ['THAMSO', [window.name, 'CC_CN_CT', null, "Import xử lý dữ liệu chấm công", b_thang, b_phong]], null); 
    form_P_LOI('');
    return false;
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
        cc_cn_ct_P_MOI();
        var b_thang = lke_Fs_TRA($get(b_thangccId)), b_ngayd = $get(b_ngaydId).value;
        $get(b_aphongId).value = b_ctyValue;
        if (b_thang != "") cc_cn_ct_P_LKE_CT(b_thang);
        if (b_ngayd != "") cc_cn_ct_ngay_by_kyluong();
        return false;
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

