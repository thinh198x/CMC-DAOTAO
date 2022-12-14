var dg_dm_tlap_dtuong_dgia_lkeCho, b_vungId, b_grlkeId, b_tm, dg_dm_tlap_dtuong_dgia_ds_lkeCho, b_gr_ct_qlctId, b_gr_ct_qlcdid, b_gr_ct_qlncid, b_ngay_xacnhanId, b_yeucau_td, b_slideId, b_grttId, b_nam, b_ma,
    b_ct_cdanh_ncId,b_ct_cdanh_ctId,b_ct_cdanh_cdId,
    b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C', dg_dm_tlap_dtuong_dgia_choAct = 0, b_datgrid;
function dg_dm_tlap_dtuong_dgia_P_KD() {
    dg_dm_tlap_dtuong_dgia_lkeCho, dg_dm_tlap_dtuong_dgia_ds_lkeCho,
    b_vungId = form_Fs_VUNG_ID('UPa_ct'),
    b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_gr_ct_qlctId = form_Fs_VUNG_ID('GR_ct_qlct'),
    b_gr_ct_qlcdid = form_Fs_VUNG_ID('GR_ct_qlcd');
    b_gr_ct_qlncid = form_Fs_VUNG_ID('GR_ct_qlnc');
    b_ct_cdanh_ncId = form_Fs_VUNG_ID('GR_ct_cdanh_qlnc');
    b_ct_cdanh_ctId = form_Fs_VUNG_ID('GR_ct_cdanh_qlct');
    b_ct_cdanh_cdId = form_Fs_VUNG_ID('GR_ct_cdanh_qlcd');
    b_ky_dgId = form_Fs_TEN_ID('', 'KY_DG'),
    b_namId = form_Fs_TEN_ID('', 'NAM'),
    b_namtk = form_Fs_TEN_ID('', 'n_chucdanh_tk'),
    b_matk = form_Fs_TEN_ID('', 'chucdanh_tk'),
    b_nhom_cdanhId = form_Fs_TEN_ID(b_vungId, 'nhom_cdanh'),
    b_ncdanhId = form_Fs_VTEN_ID('UPa_hi', 'Anncdanh'),
    b_cdanhId = form_Fs_VTEN_ID('UPa_hi', 'Ancdanh'),
    b_slideId = b_grlkeId + '_slide';
    dg_dm_tlap_dtuong_dgia_lkeCho = setInterval('dg_dm_tlap_dtuong_dgia_P_LKE_CHO()', 200);
}
//Kiểm tra
function dg_dm_tlap_dtuong_dgia_P_KTRA(b_maTen) {
    try {
        var b_maId = form_Fs_TEN_ID('', b_maTen);
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "NAM") {
            var b_nam = b_ma.value;
            sdg.Fdt_NS_DG_MA_KDG_NHL(window.name, b_nam, "DT_KY_DG", dg_dm_tlap_dtuong_dgia_P_KTRA_DR_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
        else if (b_maTen == "KY_DG") {
            var b_kdg = lke_Fs_TRA($get(b_ky_dgId));
            sdg.Fdt_NS_DG_MA_DTDG_NCDANH(window.name, b_kdg, "DT_NHOM_CDANH", dg_dm_tlap_dtuong_dgia_P_KTRA_DR_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        } else if (b_maTen == "SO_THE") {
            ns_thongtin_canbo(b_ma.value, "SO_THE");
            return;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function dg_dm_tlap_dtuong_dgia_P_KTRA_DR_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        drop_P_LKE(b_ky_dgId, b_kq);
    }
    return false;
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        var b_kq = a_tso[0];
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        b_doi = 0;
        if (b_dtuong.indexOf("MA_DX") >= 0) {
            $get(b_yeucau_td).value = b_kq;
            dg_dm_tlap_dtuong_dgia_P_LKE_DS();
        }
        else if (b_dtuong.indexOf("TEN_PHONGBAN") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grctId, b_hang, ["PHONGBAN"], [a_tso[0]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["TEN_PHONGBAN"], [a_tso[1]], 'K');
        } else if (b_dtuong.indexOf("SO_THE_CT") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_gr_ct_qlctId);
            if (b_hang < 0) return;
            if (a_tso[0] == 'CMC-2M') {
                for (var i = 1; i < a_tso.length; i++) {
                    GridX_datGtri(b_gr_ct_qlctId, b_hang, ["SO_THE_CT"], [a_tso[i][0]], 'K');
                    GridX_datGtri(b_gr_ct_qlctId, b_hang, ["ten_ct"], [a_tso[i][1]], 'K');
                    b_hang = b_hang + 1;
                }
            } else {
                for (var i = 1; i < a_tso.length; i++) {
                    GridX_datGtri(b_gr_ct_qlctId, b_hang, ["SO_THE_CT"], a_tso[0], 'K');
                    GridX_datGtri(b_gr_ct_qlctId, b_hang, ["ten_ct"], a_tso[1], 'K');
                }
            }
          
        } else if (b_dtuong.indexOf("SO_THE_CD") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_gr_ct_qlcdid);
            if (b_hang < 0) return;
            if (a_tso[0] == 'CMC-2M') {
                for (var i = 1; i < a_tso.length; i++) {
                    GridX_datGtri(b_gr_ct_qlcdid, b_hang, ["SO_THE_CD"], [a_tso[i][0]], 'K');
                    GridX_datGtri(b_gr_ct_qlcdid, b_hang, ["ten_cd"], [a_tso[i][1]], 'K');
                    b_hang = b_hang + 1;
                }
            } else {
                for (var i = 1; i < a_tso.length; i++) {
                    GridX_datGtri(b_gr_ct_qlcdid, b_hang, ["SO_THE_CD"], a_tso[0], 'K');
                    GridX_datGtri(b_gr_ct_qlcdid, b_hang, ["ten_cd"], a_tso[1], 'K');
                }
            }
        } else if (b_dtuong.indexOf("SO_THE_NC") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_gr_ct_qlncid);
            if (b_hang < 0) return;
            if (a_tso[0] == 'CMC-2M') {
                for (var i = 1; i < a_tso.length; i++) {
                    GridX_datGtri(b_gr_ct_qlncid, b_hang, ["SO_THE_NC"], [a_tso[i][0]], 'K');
                    GridX_datGtri(b_gr_ct_qlncid, b_hang, ["ten_nc"], [a_tso[i][1]], 'K');
                    b_hang = b_hang + 1;
                }
            } else {
                for (var i = 1; i < a_tso.length; i++) {
                    GridX_datGtri(b_gr_ct_qlncid, b_hang, ["SO_THE_NC"], a_tso[0], 'K');
                    GridX_datGtri(b_gr_ct_qlncid, b_hang, ["ten_nc"], a_tso[1], 'K');
                }
            }
        } else if (b_dtuong.indexOf("MA_CD_NC") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_ct_cdanh_ncId);
            if (b_hang < 0) return;
            if (a_tso[0] == 'CMC-2M') {
                for (var i = 1; i < a_tso.length; i++) {
                    GridX_datGtri(b_ct_cdanh_ncId, b_hang, ["MA_CD_NC"], [a_tso[i][0]], 'K');
                    GridX_datGtri(b_ct_cdanh_ncId, b_hang, ["ten_cd_nc"], [a_tso[i][1]], 'K');
                    b_hang = b_hang + 1;
                }
            } else {
                for (var i = 1; i < a_tso.length; i++) {
                    GridX_datGtri(b_ct_cdanh_ncId, b_hang, ["MA_CD_NC"], a_tso[0], 'K');
                    GridX_datGtri(b_ct_cdanh_ncId, b_hang, ["ten_cd_nc"], a_tso[1], 'K');
                }
            }
        }
        else if (b_dtuong.indexOf("MA_CD_CT") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_ct_cdanh_ctId);
            if (b_hang < 0) return;
            if (a_tso[0] == 'CMC-2M') {
                for (var i = 1; i < a_tso.length; i++) {
                    GridX_datGtri(b_ct_cdanh_ctId, b_hang, ["MA_CD_CT"], [a_tso[i][0]], 'K');
                    GridX_datGtri(b_ct_cdanh_ctId, b_hang, ["ten_cd_ct"], [a_tso[i][1]], 'K');
                    b_hang = b_hang + 1;
                }
            } else {
                for (var i = 1; i < a_tso.length; i++) {
                    GridX_datGtri(b_ct_cdanh_ctId, b_hang, ["MA_CD_CT"], a_tso[0], 'K');
                    GridX_datGtri(b_ct_cdanh_ctId, b_hang, ["ten_cd_ct"], a_tso[1], 'K');
                }
            }
        }
        else if (b_dtuong.indexOf("MA_CD_CD") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_ct_cdanh_cdId);
            if (b_hang < 0) return;
            if (a_tso[0] == 'CMC-2M') {
                for (var i = 1; i < a_tso.length; i++) {
                    GridX_datGtri(b_ct_cdanh_cdId, b_hang, ["MA_CD_cd"], [a_tso[i][0]], 'K');
                    GridX_datGtri(b_ct_cdanh_cdId, b_hang, ["ten_cd_cd"], [a_tso[i][1]], 'K');
                    b_hang = b_hang + 1;
                }
            } else {
                for (var i = 1; i < a_tso.length; i++) {
                    GridX_datGtri(b_ct_cdanh_cdId, b_hang, ["MA_CD_cd"], a_tso[0], 'K');
                    GridX_datGtri(b_ct_cdanh_cdId, b_hang, ["ten_cd_cd"], a_tso[1], 'K');
                }
            }
        }
        //ns_hdns_gan_cdanhdvi_P_LAY();
    }
    catch (err) { form_P_LOI(err); }
}
function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}
// Nhập
function dg_dm_tlap_dtuong_dgia_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_datTrang(b_gr_ct_qlctId);
    GridX_datTrang(b_gr_ct_qlcdid);
    GridX_datTrang(b_gr_ct_qlncid);
    GridX_thoiA(b_grlkeId);
    $get(b_nhom_cdanhId).value = "";
    return false;
}
function dg_dm_tlap_dtuong_dgia_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    else {
        var a_dt = form_Faa_TEXT_ROW(b_vungId);
        var b_dt_ct_ct = GridX_Fdt_cotGtri(b_gr_ct_qlctId);
        var b_dt_ct_cd = GridX_Fdt_cotGtri(b_gr_ct_qlcdid);
        var b_dt_ct_nc = GridX_Fdt_cotGtri(b_gr_ct_qlncid);

        //Lay chuc danh
        var b_dt_ct_cdanh_nc = GridX_Fdt_cotGtri(b_ct_cdanh_ncId);
        var b_dt_ct_cdanh_ct = GridX_Fdt_cotGtri(b_ct_cdanh_ctId);
        var b_dt_ct_cdanh_cd = GridX_Fdt_cotGtri(b_ct_cdanh_cdId);

        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_TrangKt = GridX_Fi_hangKt(b_grlkeId)
        if (b_hang < 1) { b_so_id = 0; }
        else {
            b_so_id = C_NVL(GridX_Fas_layGtriA(b_grlkeId, "so_id"));
        }
        sdg.Fs_DG_DM_TLAP_DTUONG_DGIA_NH(form_Fs_nsd(), b_so_id, b_TrangKt, a_dt, b_dt_ct_ct, b_dt_ct_cd, b_dt_ct_nc, b_dt_ct_cdanh_nc, b_dt_ct_cdanh_ct, b_dt_ct_cdanh_cd,a_cot_lke, dg_dm_tlap_dtuong_dgia_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
}
function dg_dm_tlap_dtuong_dgia_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_tso = Fas_ChMang(b_kq, '#');
        GridX_datBang(b_grlkeId, a_tso[3]);
        var b_hang = a_tso[0]
        if (b_hang >= 0) {
            GridX_datA(b_grlkeId, b_hang);
            dg_dm_tlap_dtuong_dgia_GR_lke_RowChange();
            form_P_LOI("loi:Ghi thành công:loi");
        }
    }
}
// Xóa
function dg_dm_tlap_dtuong_dgia_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (so_id > 0) {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_DG_DM_TLAP_DTUONG_DGIA_XOA(form_Fs_nsd(), so_id, a_tso, a_cot, dg_dm_tlap_dtuong_dgia_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function dg_dm_tlap_dtuong_dgia_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        dg_dm_tlap_dtuong_dgia_P_MOI();
        dg_dm_tlap_dtuong_dgia_P_LKE();
        //dg_dm_tlap_dtuong_dgia_P_LKE_DS();
    }
}

function ns_td_thutuc_P_LKE_KQ_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang(b_grttId, b_kq);
}
// CHuyển hàng
function dg_dm_tlap_dtuong_dgia_GR_lke_RowChange() {
    if (dg_dm_tlap_dtuong_dgia_choAct != 0) clearTimeout(dg_dm_tlap_dtuong_dgia_choAct);
    dg_dm_tlap_dtuong_dgia_choAct = setTimeout("dg_dm_tlap_dtuong_dgia_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_td_thutuc_P_CHUYEN_HANG_LKE() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var a_ma_dx = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma_dx"));
    var a_cot = GridX_Fas_tenCot(b_grttId);
    if (a_ma_dx == "") sdg.FS_NS_TD_THUTUC_LKE_ALL(a_cot, ns_td_thutuc_P_LKE_KQ_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    else sdg.Fs_NS_TD_THUTUC_CT(a_ma_dx, a_cot, ns_td_thutuc_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_td_thutuc_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang(b_grttId, b_kq);
}

function dg_dm_tlap_dtuong_dgia_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var a_cot_ct_qlctId = GridX_Fas_tenCot(b_gr_ct_qlctId);
    var a_cot_ct_qlcdid = GridX_Fas_tenCot(b_gr_ct_qlcdid);
    var a_cot_ct_qlncid = GridX_Fas_tenCot(b_gr_ct_qlncid);
    var a_cot_cdanh_ncId = GridX_Fas_tenCot(b_ct_cdanh_ncId);
    var a_cot_cdanh_ctId = GridX_Fas_tenCot(b_ct_cdanh_ctId);
    var a_cot_cdanh_cdId = GridX_Fas_tenCot(b_ct_cdanh_cdId);
    var b_ma_dx = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_ma_dx == "") {
        dg_dm_tlap_dtuong_dgia_P_MOI();
    }
    else {
        sdg.Fs_DG_DM_TLAP_DTUONG_DGIA_CT(form_Fs_nsd(), b_ma_dx, a_cot_ct_qlctId, a_cot_ct_qlcdid, a_cot_ct_qlncid, a_cot_cdanh_ncId, a_cot_cdanh_ctId, a_cot_cdanh_cdId, dg_dm_tlap_dtuong_dgia_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function dg_dm_tlap_dtuong_dgia_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#')
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    GridX_datBang(b_gr_ct_qlctId, a_kq[4]);
    GridX_datBang(b_gr_ct_qlcdid, a_kq[5]);
    GridX_datBang(b_gr_ct_qlncid, a_kq[6]);
    GridX_datBang(b_ct_cdanh_ctId, a_kq[1]);
    GridX_datBang(b_ct_cdanh_cdId, a_kq[2]);
    GridX_datBang(b_ct_cdanh_ncId, a_kq[3]);
}
// Gửi mail
function sendMail(b_tso) {
    var a_tso = Fas_ChMang(b_tso, ';');
    var b_toAddress = a_tso[0],
        b_subject = a_tso[1],
        b_body = a_tso[2];
    if (b_toAddress == "" || b_toAddress == null || b_toAddress == undefined) return false;
    else {
        sSmtpMail.SendMail(b_toAddress, b_subject, b_body, sendMail_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
}
function sendMail_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); return false;
}

function dg_dm_tlap_dtuong_dgia_P_XEM() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    form_P_MO("ns_td_hsuv_online.aspx", null, ["KQ", [b_so_id]]);
    return false;
}
// Liệt kê
function dg_dm_tlap_dtuong_dgia_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (dg_dm_tlap_dtuong_dgia_lkeCho != 0) clearTimeout(dg_dm_tlap_dtuong_dgia_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        dg_dm_tlap_dtuong_dgia_P_LKE('K');
    }

}
function dg_dm_tlap_dtuong_dgia_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_nam = lke_Fs_TRA($get(b_namtk)), b_ma = lke_Fs_TRA($get(b_matk));
        sdg.Fs_DG_DM_TLAP_DTUONG_DGIA_LKE(form_Fs_nsd(), b_nam, b_ma, a_tso, a_cot, dg_dm_tlap_dtuong_dgia_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function dg_dm_tlap_dtuong_dgia_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        var a_cot = GridX_Fas_tenCot(b_grttId);
    }
}

function dg_dm_tlap_dtuong_dgia_P_NHOM_CDANH(b_tenctr, b_kieu) {
    try {
        b_nhom_cdanhId = form_Fs_TEN_ID('', b_tenctr)
        var b_nam = lke_Fs_TRA($get(b_namId)), b_ky_dg = lke_Fs_TRA($get(b_ky_dgId)), b_nhom_cdanh = lke_Fs_TRA($get(b_nhom_cdanhId));
        var b_ktra = "DT_CDANH";
        if (b_tenctr == "N_CHUCDANH_TK") b_ktra = "DT_CHUCDANH_TK";
        if (b_nhom_cdanh != '') {
            var a_tso = lke_Fa_TSO(b_kieu);
            sdg.Fs_CDANH_TLAP_DTDG_DR(form_Fs_nsd(), b_nam, b_ky_dg, b_nhom_cdanh, window.name, b_ktra, form_LIST_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
        var b_cdanh = lke_Fs_TRA($get(b_matk));
        $get(b_ncdanhId).value = b_nhom_cdanh;
        $get(b_cdanhId).value = b_cdanh;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function dg_dm_tlap_dtuong_dgia_P_CDANH(b_tenctr, b_kieu) {
    try {
        var b_cdanh = lke_Fs_TRA($get(b_matk));
        var b_nhom_cdanh = lke_Fs_TRA($get(b_nhom_cdanhId));
        $get(b_ncdanhId).value = b_nhom_cdanh;
        $get(b_cdanhId).value = b_cdanh;
    }
    catch (ex) { form_P_LOI(ex.message); }
}

function dg_dm_tlap_dtuong_dgia_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap1');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function form_dong() {
    location.reload(false);
}
//-------------------Lấy 
function ns_hdns_gan_cdanhdvi_P_LAY() {
    try {
        var a_cot, b_ma = form_Fs_TEN_GTRI(b_vungId, 'PHONG');
        var b_so_id = 0, a_luoi;
        //slide_P_SOTRANG(b_slideId);
        var b_hang = GridX_Fi_timHangA(b_gr_ct_qlctId);
        if (b_hang > 0) {
            b_datgrid = 'QLCT';
            a_cot = GridX_Fas_tenCot(b_gr_ct_qlctId);
            a_luoi = GridX_Fdt_cotGtri(b_gr_ct_qlctId);
        }
        b_hang = GridX_Fi_timHangA(b_gr_ct_qlcdid);
        if (b_hang > 0) {
            b_datgrid = 'QLCD';
            a_cot = GridX_Fas_tenCot(b_gr_ct_qlcdid);
            a_luoi = GridX_Fdt_cotGtri(b_gr_ct_qlcdid);
        }
        b_hang = GridX_Fi_timHangA(b_gr_ct_qlncid);
        if (b_hang > 0) {
            b_datgrid = 'QLNC';
            a_cot = GridX_Fas_tenCot(b_gr_ct_qlncid);
            a_luoi = GridX_Fdt_cotGtri(b_gr_ct_qlncid);
        }
        sdg.Fs_LAY_TRACHON(form_Fs_nsd(), a_cot, a_luoi, ns_hdns_gan_cdanhdvi_P_LAY_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_gan_cdanhdvi_P_LAY_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    b_datgrid = b_datgrid.toUpperCase();
    switch (b_datgrid) {
        case "QLCT": GridX_datBang(b_gr_ct_qlctId, a_kq[1]); break;
        case "QLCD": GridX_datBang(b_gr_ct_qlcdid, a_kq[1]); break;
        case "QLNC": GridX_datBang(b_gr_ct_qlncid, a_kq[1]); break;
    }

    //slide_P_SOTRANG(b_slidectId);
}

function qlct_thoiA() {
    GridX_thoiA(b_gr_ct_qlcdid);
    GridX_thoiA(b_gr_ct_qlncid);
}

function qlcd_thoiA() {
    GridX_thoiA(b_gr_ct_qlncid);
    GridX_thoiA(b_gr_ct_qlctId);
}

function qlnc_thoiA() {
    GridX_thoiA(b_gr_ct_qlctId);
    GridX_thoiA(b_gr_ct_qlcdid);
}

// lấy chức danh cán bộ quản lý cấp trên trực tiếp
function ns_cdanh_qlct_P_LIST(b_ctrId, b_kieu, b_vtri) {
    try {
        var b_congty = C_NVL(GridX_Fas_layGtriA(b_gr_ct_qlctId, 'cty_qlct'));
        if (b_congty != '') {
            var a_tso = lke_Fa_TSO(b_kieu);
            hts_dungchung.Fs_NS_MA_CDANH_BY_CTY(form_Fs_nsd(), b_congty, a_tso[3], form_LIST_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
// lấy chức danh CB cấp dưới trực tiếp
function ns_cdanh_qlcd_P_LIST(b_ctrId, b_kieu, b_vtri) {
    try {
        var b_congty = C_NVL(GridX_Fas_layGtriA(b_gr_ct_qlcdid, 'cty_qlcd'));
        if (b_congty != '') {
            var a_tso = lke_Fa_TSO(b_kieu);
            hts_dungchung.Fs_NS_MA_CDANH_BY_CTY(form_Fs_nsd(), b_congty, a_tso[3], form_LIST_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
// lấy chức danh cán bộ quản lý cấp trên trực tiếp
function ns_cdanh_qlcn_P_LIST(b_ctrId, b_kieu, b_vtri) {
    try {
        var b_congty = C_NVL(GridX_Fas_layGtriA(b_gr_ct_qlncid, 'cty_nc'));
        if (b_congty != '') {
            var a_tso = lke_Fa_TSO(b_kieu);
            hts_dungchung.Fs_NS_MA_CDANH_BY_CTY(form_Fs_nsd(), b_congty, a_tso[3], form_LIST_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}