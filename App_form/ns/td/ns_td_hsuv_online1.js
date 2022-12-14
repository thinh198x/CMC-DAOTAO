var ns_td_hsuv_online_lkeCho, b_cdanhId, b_cmtId, b_cmt,b_email ;
function ns_td_hsuv_online_P_KD() {
    b_vungId = form_Fs_VUNG_ID('UPa_ct');
    b_cdanhId = form_Fs_TEN_ID(b_vungId, 'cdanh'),
    b_vungId_tt = form_Fs_VUNG_ID('Upa_tt'), b_cmtId = form_Fs_TEN_ID(b_vungId_tt, 'cmt');
    b_vungId_td = form_Fs_VUNG_ID('Upa_td'); b_vungId_ttk = form_Fs_VUNG_ID('Upa_ttk');
    b_email = form_Fs_TEN_ID(b_vungId_tt, 'email');
    b_grgdId = form_Fs_VUNG_ID('GR_gd'), b_grhdctId = form_Fs_VUNG_ID('GR_hdct'), b_grtdId = form_Fs_VUNG_ID('GR_td');
   // ns_td_hsuv_online_lkeCho = setInterval('ns_td_hsuv_online_P_CHUYEN_HANG()', 200);
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (C_NVL(b_dtuong) == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        if (b_dtuong.indexOf("KQ") >= 0) {
            ns_td_hsuv_online_P_CHUYEN_HANG(a_tso[0]);
        }
    }
    catch (err) { form_P_LOI(err); }
}


function ns_td_hsuv_online_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "CDANH": b_maId = b_cdanhId; break;
            case "CMT": b_maId = b_cmtId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null) return;
        if (b_maTen == "CDANH") {
            ns_td_hsuv_online_P_CHUYEN_HANG();
        } else if (b_maTen == "CMT") {
            $get(b_cmtId).value = ($get(b_cmtId).value).validate_Ma();
            ns_td_hsuv_online_P_CHUYEN_HANG();
        }
        
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_hsuv_online_P_CHUYEN_HANG() { 
        var a_cot_gd = GridX_Fas_tenCot(b_grgdId);
        var a_cot_hdct = GridX_Fas_tenCot(b_grhdctId);
        var a_cot_td = GridX_Fas_tenCot(b_grtdId);
        var b_cdanh = $get(b_cdanhId).value;
        b_cmt = $get(b_cmtId).value;
        sns_td.Fs_NS_TD_CV_ONLINE_CT(b_cdanh,b_cmt, a_cot_gd, a_cot_hdct, a_cot_td, ns_td_hsuv_online_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false; 
}
function ns_td_hsuv_online_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    if (b_kq == "###") {
        form_P_MOI(b_vungId, "XGL");
        form_P_MOI(b_vungId_tt, "XGL");
        form_P_MOI(b_vungId_td, "XGL");
        form_P_MOI(b_vungId_ttk, "XGL");
    }
    $get(b_cmtId).value = b_cmt;
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    form_P_CH_TEXT(b_vungId_tt, a_kq[0]);
    form_P_CH_TEXT(b_vungId_td, a_kq[0]);
    form_P_CH_TEXT(b_vungId_ttk, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grgdId); else GridX_datBang(b_grgdId, a_kq[1]);
    if (a_kq[2] == "") GridX_datTrang(b_grhdctId); else GridX_datBang(b_grhdctId, a_kq[2]);
    if (a_kq[3] == "") GridX_datTrang(b_grtdId); else GridX_datBang(b_grtdId, a_kq[3]);
    return false;
}


function ns_td_hsuv_online_GR_Update(b_event) {
    var b_ctr = form_Fctr_event(b_event);
    if (C_NVL(b_ctr.value) != "") GridX_ThemHang(b_gridId);
    return false;
}
function ns_td_hsuv_online_LKE_CHO() {
     clearTimeout(ns_td_hsuv_online_lkeCho); ns_td_hsuv_online_P_CT();
}

function ns_td_hsuv_online_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId_tt);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var b_cdanh_id = $get(b_cdanhId).value;
        if (b_cdanh_id == "") {
            form_P_LOI("loi:Chưa chọn chức danh ứng tuyển:loi"); return false;
        }
        if (ktra_email($get(b_email).value) == false) { form_P_LOI("Email không đúng định dạng"); return false }
        var a_cdanh = form_Faa_TEXT_ROW(b_vungId),
            a_dt = form_Faa_TEXT_ROW(b_vungId_tt),
            a_dt_td = form_Faa_TEXT_ROW(b_vungId_td),
            a_dt_ttk = form_Faa_TEXT_ROW(b_vungId_ttk);
        var b_dt_gd = GridX_Fdt_cotGtri(b_grgdId),
            b_dt_hdct = GridX_Fdt_cotGtri(b_grhdctId),
            b_dt_td = GridX_Fdt_cotGtri(b_grtdId);
        sns_td.Fs_NS_TD_CV_ONLINE_NH(a_cdanh, a_dt, a_dt_td, a_dt_ttk, b_dt_gd, b_dt_hdct, b_dt_td, ns_td_hsuv_online_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { throw (err); }
}
function ns_td_hsuv_online_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI('loi:Cảm ơn bạn đã ứng tuyển vào công ty chúng tôi. Chúng tôi sẽ liên hện với bạn trong thời gian sớm nhất!:loi');
        return false;
    }
}

function ns_td_hsuv_online_P_XOA() {
    var b_so_the = $get(b_cmtId).value;
    sti_ch.Fs_NS_TI_THAYDOI_XOA(b_so_the, ns_td_hsuv_online_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}

function ns_td_hsuv_online_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI('loi:Xóa dữ liệu cập nhập thành công!:loi');
        //ns_td_hsuv_online_P_CT();
        return false;
    }
}

function ns_td_hsuv_online_P_PD() {
    var b_so_the = $get(b_cmtId).value;
    sti_ch.Fs_NS_TI_THAYDOI_PD(b_so_the, ns_td_hsuv_online_P_PD_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}

function ns_td_hsuv_online_P_PD_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI('loi:Phê duyệt thành công!:loi');
        ns_td_hsuv_online_P_CT();
        return false;
    }
}

function ns_td_hsuv_online_P_KPD() {
    var b_so_the = $get(b_cmtId).value;
    sti_ch.Fs_NS_TI_THAYDOI_KPD(b_so_the, ns_td_hsuv_online_P_KPD_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}

function ns_td_hsuv_online_P_KPD_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI('loi:Không phê duyệt thành công!:loi');
        ns_td_hsuv_online_P_CT();
        return false;
    }
}

function ns_td_hsuv_online_HangLen(b_ktra) {
    if (b_ktra == 'GD') GridX_chuyenHang(b_grgdId, -1);
    if (b_ktra == 'HDCT') GridX_chuyenHang(b_grhdctId, -1);
    if (b_ktra == 'TD') GridX_chuyenHang(b_grtdId, -1);
    return false;
}
function ns_td_hsuv_online_HangXuong(b_ktra) {
    if (b_ktra == 'GD') GridX_chuyenHang(b_grgdId, 1);
    if (b_ktra == 'HDCT') GridX_chuyenHang(b_grhdctId, 1);
    if (b_ktra == 'TD') GridX_chuyenHang(b_grtdId, 1);
    return false;
}
function ns_td_hsuv_online_CatDong(b_dk,b_ktra) {
    if (b_ktra == 'GD') {
        if (GridX_Fi_timHangC(b_grgdId) < 1) {
            var b_ctr = eval(window.name + '_P_HTOAN');
            if (b_ctr != null) b_ctr('C');
        }
        else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grgdId);
    }
    if (b_ktra == 'HDCT') {
        if (GridX_Fi_timHangC(b_grhdctId) < 1) {
            var b_ctr = eval(window.name + '_P_HTOAN');
            if (b_ctr != null) b_ctr('C');
        }
        else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grhdctId);
    }
    if (b_ktra == 'TD') {
        if (GridX_Fi_timHangC(b_grtdId) < 1) {
            var b_ctr = eval(window.name + '_P_HTOAN');
            if (b_ctr != null) b_ctr('C');
        }
        else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grtdId);
    }
    return false;
}
function ns_td_hsuv_online_ChenDong(b_ktra) {
    if (b_ktra == 'GD') GridX_boChon(b_grgdId, 'C');
    if (b_ktra == 'HDCT') GridX_boChon(b_grhdctId, 'C');
    if (b_ktra == 'TD') GridX_boChon(b_grtdId, 'C');
    return false;
}

function khud_trdoi_FI_NH() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) {
            form_P_LOI('loi:Ấn nhập thông tin trước rồi Up ảnh:loi')
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

function form_dong() {
    location.reload(false);
}


