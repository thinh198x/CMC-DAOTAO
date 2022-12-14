var dg_ds_thuchien_dgia_lkeCho, b_vungId, b_grlkeId, b_grlctId, b_tm, dg_ds_thuchien_dgia_ds_lkeCho, b_gr_ct_qlctId, b_gr_ct_qlcdid, b_gr_ct_qlncid, b_ngay_xacnhanId,
    b_yeucau_td, b_slideId, b_grttId, b_nam, b_ma, b_ngay_thId, b_slide_ctId, b_so_idId,
    b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C', dg_ds_thuchien_dgia_choAct = 0, b_datgrid;
function dg_ds_thuchien_dgia_P_KD() {
    dg_ds_thuchien_dgia_lkeCho, dg_ds_thuchien_dgia_ds_lkeCho,
        b_vungId = form_Fs_VUNG_ID('UPa_ct'),
        b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_grlctId = form_Fs_VUNG_ID('GR_ct'),
        b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'),
        b_ky_dgId = form_Fs_TEN_ID(b_vungId, 'KY_DG'),
        b_ngay_thId = form_Fs_TEN_ID(b_vungId, 'ngayd'),
        b_namId = form_Fs_TEN_ID(b_vungId, 'NAM'),
        //b_nhom_cdanhId = form_Fs_TEN_ID(b_vungId, 'nhom_cdanh'),
        b_ncdanhId = form_Fs_VTEN_ID('UPa_hi', 'Anncdanh'),
        b_cdanhId = form_Fs_VTEN_ID('UPa_hi', 'Ancdanh'),
        b_slideId = b_grlkeId + '_slide';
        b_slide_ctId = b_grlctId + '_slide';
    dg_ds_thuchien_dgia_lkeCho = setInterval('dg_ds_thuchien_dgia_P_LKE_CHO()', 200);
}
//Kiểm tra
function dg_ds_thuchien_dgia_P_KTRA(b_maTen) {
    try {
        var b_maId = form_Fs_TEN_ID('', b_maTen);
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "NAM") {
            var b_nam = b_ma.value;
            sdg.Fdt_NS_DG_MA_KDG_NHL(window.name, b_nam, "DT_KY_DG", dg_ds_thuchien_dgia_P_KTRA_DR_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
        else if (b_maTen == "KY_DG") {
            var b_kdg = lke_Fs_TRA($get(b_ky_dgId));
            sdg.Fdt_NS_DG_MA_DTDG_NCDANH(window.name, b_kdg, "DT_NHOM_CDANH", dg_ds_thuchien_dgia_P_KTRA_DR_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        } else if (b_maTen == "SO_THE") {
            ns_thongtin_canbo(b_ma.value, "SO_THE");
            return;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function dg_ds_thuchien_dgia_P_KTRA_DR_KQ(b_kq) {
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
            dg_ds_thuchien_dgia_P_LKE_DS();
        }
        else if (b_dtuong.indexOf("TEN_PHONGBAN") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grctId, b_hang, ["PHONGBAN"], [a_tso[0]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["TEN_PHONGBAN"], [a_tso[1]], 'K');
        } else if (b_dtuong.indexOf("SO_THE_CT") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_gr_ct_qlctId);
            if (b_hang < 0) return;
            for (var i = 1; i < a_tso.length; i++) {
                GridX_datGtri(b_gr_ct_qlctId, b_hang, ["SO_THE_CT"], [a_tso[i][0]], 'K');
                GridX_datGtri(b_gr_ct_qlctId, b_hang, ["ten_ct"], [a_tso[i][1]], 'K');
                b_hang = b_hang + 1;
            }
        } else if (b_dtuong.indexOf("SO_THE_CD") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_gr_ct_qlcdid);
            if (b_hang < 0) return;
            for (var i = 1; i < a_tso.length; i++) {
                GridX_datGtri(b_gr_ct_qlcdid, b_hang, ["SO_THE_CD"], [a_tso[i][0]], 'K');
                GridX_datGtri(b_gr_ct_qlcdid, b_hang, ["ten_cd"], [a_tso[i][1]], 'K');
                b_hang = b_hang + 1;
            }
        } else if (b_dtuong.indexOf("SO_THE_NC") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_gr_ct_qlncid);
            if (b_hang < 0) return;
            for (var i = 1; i < a_tso.length; i++) {
                GridX_datGtri(b_gr_ct_qlncid, b_hang, ["SO_THE_NC"], [a_tso[i][0]], 'K');
                GridX_datGtri(b_gr_ct_qlncid, b_hang, ["ten_nc"], [a_tso[i][1]], 'K');
                b_hang = b_hang + 1;
            }
        } else if (b_dtuong.indexOf("MA_CD_NC") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_ct_cdanh_ncId);
            if (b_hang < 0) return;
            for (var i = 1; i < a_tso.length; i++) {
                GridX_datGtri(b_ct_cdanh_ncId, b_hang, ["MA_CD_NC"], [a_tso[i][0]], 'K');
                GridX_datGtri(b_ct_cdanh_ncId, b_hang, ["ten_cd_nc"], [a_tso[i][1]], 'K');
                b_hang = b_hang + 1;
            }
        }
        else if (b_dtuong.indexOf("MA_CD_CT") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_ct_cdanh_ctId);
            if (b_hang < 0) return;
            for (var i = 1; i < a_tso.length; i++) {
                GridX_datGtri(b_ct_cdanh_ctId, b_hang, ["MA_CD_CT"], [a_tso[i][0]], 'K');
                GridX_datGtri(b_ct_cdanh_ctId, b_hang, ["ten_cd_ct"], [a_tso[i][1]], 'K');
                b_hang = b_hang + 1;
            }
        }
        else if (b_dtuong.indexOf("MA_CD_CD") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_ct_cdanh_cdId);
            if (b_hang < 0) return;
            for (var i = 1; i < a_tso.length; i++) {
                GridX_datGtri(b_ct_cdanh_cdId, b_hang, ["MA_CD_cd"], [a_tso[i][0]], 'K');
                GridX_datGtri(b_ct_cdanh_cdId, b_hang, ["ten_cd_cd"], [a_tso[i][1]], 'K');
                b_hang = b_hang + 1;
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
function dg_ds_thuchien_dgia_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_datTrang(b_gr_ct_qlctId);
    GridX_datTrang(b_gr_ct_qlcdid);
    GridX_datTrang(b_gr_ct_qlncid);
    GridX_thoiA(b_grlkeId);
    $get(b_nhom_cdanhId).value = "";
    return false;
}
function dg_ds_thuchien_dgia_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    else {
        var a_dt = form_Faa_TEXT_ROW(b_vungId), a_cot_ct = GridX_Fdt_cotGtri(b_grlctId), a_tso = slide_Faobj_TUDEN(b_slideId);;
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId); var b_so_id = 0;
        if (b_hang > 0) b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        sdg.Fs_DG_DS_THUCHIEN_DGIA_NH(form_Fs_nsd(), b_so_id, b_TrangKt, a_dt, a_cot_ct, a_tso, a_cot_lke, dg_ds_thuchien_dgia_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
}
function dg_ds_thuchien_dgia_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = b_kq.split('#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        form_P_LOI("loi:Nhập thành công:loi");
    }
    b_fcho = 'X';
}
// Xóa
function dg_ds_thuchien_dgia_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (so_id > 0) {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_dg_ds_thuchien_dgia_XOA(form_Fs_nsd(), so_id, a_tso, a_cot, dg_ds_thuchien_dgia_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function dg_ds_thuchien_dgia_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        dg_ds_thuchien_dgia_P_MOI();
        dg_ds_thuchien_dgia_P_LKE();
        //dg_ds_thuchien_dgia_P_LKE_DS();
    }
}

function ns_td_thutuc_P_LKE_KQ_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang(b_grttId, b_kq);
}
// CHuyển hàng
function dg_ds_thuchien_dgia_GR_lke_RowChange() {
    if (dg_ds_thuchien_dgia_choAct != 0) clearTimeout(dg_ds_thuchien_dgia_choAct);
    dg_ds_thuchien_dgia_choAct = setTimeout("dg_ds_thuchien_dgia_P_CHUYEN_HANG()", 300);
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

function dg_ds_thuchien_dgia_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "0" || b_so_id == "") { form_P_MOI(b_vungId, "XGL"); GridX_datTrang(b_grlctId); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grlctId);
        sdg.Fs_DG_DS_THUCHIEN_DGIA_CT(form_Fs_nsd(), b_so_id, a_cot_ct, dg_ds_thuchien_dgia_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        $get(b_so_idId).value = b_so_id;
    }
    return false;
}
function dg_ds_thuchien_dgia_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        var a_kq = b_kq.split('#');
        form_P_MOI(b_vungId, "GXL"); $get(b_namId).value = "", $get(b_ky_dgId).value = "";
        drop_P_LKE(b_ky_dgId, a_kq[2]);
        form_P_CH_TEXT(b_vungId, a_kq[0]);
        if (a_kq[1] == "") GridX_datTrang(b_grlctId); else GridX_datBang(b_grlctId, a_kq[1]);
        return false;
    }
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

function dg_ds_thuchien_dgia_P_XEM() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    form_P_MO("ns_td_hsuv_online.aspx", null, ["KQ", [b_so_id]]);
    return false;
}
// Liệt kê
function dg_ds_thuchien_dgia_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (dg_ds_thuchien_dgia_lkeCho != 0) clearTimeout(dg_ds_thuchien_dgia_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        b_slide_ctId = $get(b_grlctId).getAttribute('slideId');
        dg_ds_thuchien_dgia_P_LKE('K');
    }

}
function dg_ds_thuchien_dgia_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_nam = lke_Fs_TRA($get(b_namId)), b_ky_dg = lke_Fs_TRA($get(b_ky_dgId));
        sdg.Fs_DG_DS_THUCHIEN_DGIA_LKE(form_Fs_nsd(), b_ky_dg, a_tso, a_cot, dg_ds_thuchien_dgia_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function dg_ds_thuchien_dgia_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
}

function dg_ds_thuchien_dgia_P_TH(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slide_ctId);
        var a_cot = GridX_Fas_tenCot(b_grlctId), a_tso = slide_Faobj_TUDEN(b_slide_ctId);
        var b_ngay_th = $get(b_ngay_thId).value, b_ky_dg = lke_Fs_TRA($get(b_ky_dgId));
        sdg.Fs_DG_DS_THUCHIEN_DGIA_TH(form_Fs_nsd(), b_ky_dg, b_ngay_th, a_tso, a_cot, dg_ds_thuchien_dgia_P_TH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function dg_ds_thuchien_dgia_P_TH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slide_ctId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlctId, a_kq[1]);
        dg_ds_thuchien_dgia_P_NH();
        //var a_cot = GridX_Fas_tenCot(b_grttId);
    }
}


function dg_ds_thuchien_dgia_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap1');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function form_dong() {
    location.reload(false);
}

