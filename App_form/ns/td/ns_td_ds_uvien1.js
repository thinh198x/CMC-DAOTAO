var ns_td_ds_uvien_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timId, b_noidungId, b_ncdanhId;
function ns_td_ds_uvien_P_KD() {
    ns_td_ds_uvien_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_grctId = form_Fs_VUNG_ID('GR_ct'), b_vungttId = form_Fs_VUNG_ID('UPa_tt'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'cdanh');
    b_ncdanhId = form_Fs_TEN_ID(b_vungId, 'ncdanh');
    b_vongId = form_Fs_TEN_ID(b_vungttId, 'vong');
    b_slideId = b_grlkeId + '_slide';
    b_noidungId = form_Fs_VTEN_ID('', 'noidung');
  ns_td_ds_uvien_lkeCho = setInterval('ns_td_ds_uvien_P_LKE_CHO()', 200);

}
function ns_td_ds_uvien_P_KTRA(b_maTen) {
    var b_maId = "";
    b_maTen = b_maTen.toUpperCase();
    switch (b_maTen) {
        case "CDANH": b_maId = b_gocId; break;
        case "NCDANH": b_maId = b_ncdanhId; break;
    }
    if (b_maTen == "CDANH") { ns_td_ds_uvien_P_LKE(); }
    else if (b_maTen == "NCDANH") { ns_td_ds_uvien_P_CDANH(); }
}
function ns_td_ds_uvien_P_CDANH() {
    try {
        var b_ncdanh = $get(b_ncdanhId).value;
        sns_td.Fs_CDANH_CV(b_ncdanh, ns_td_ds_uvien_P_CDANH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_td_ds_uvien_P_CDANH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_cdanhId = form_Fs_TEN_ID(b_vungId, 'cdanh');
        drop_P_LKE(b_cdanhId, b_kq);

        ns_td_ds_uvien_P_KTRA("CDANH");
    } 
}
function ns_td_ds_uvien_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_td_ds_uvien_lkeCho); ns_td_ds_uvien_P_LKE(); }
}
function ns_td_ds_uvien_P_LKE() {
    try {
        ns_td_ds_uvien_P_MOI();
        var a_cot = GridX_Fas_tenCot(b_grlkeId),
            a_ncdanh = $get(b_ncdanhId).value,
            a_cdanh = $get(b_gocId).value;
        sns_td.Fs_NS_TD_DS_UVIEN_LKE(a_cdanh,a_cot, ns_td_ds_uvien_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_ds_uvien_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang(b_grlkeId, b_kq);
}

function ns_td_ds_uvien_P_PHEDUYET() {
    var b_dt_ct = GridX_Fdt_cotGtri(b_grlkeId);
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("loi:Chưa chọn ứng viên cần tuyển:loi"); return false; }
    var b_hang_ct = GridX_Fi_timHangA(b_grctId);
    if (b_hang_ct < 1) { form_P_LOI("loi:Ứng viên chưa thi tuyển:loi"); return false; }
     
    var b_chon = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "chon"));
    if (b_chon == "") { form_P_LOI("loi:Chưa chọn ứng viên cần tuyển:loi"); return false; }
     
    sns_td.Fs_NS_TD_DS_TUYENDUNG(b_dt_ct, ns_td_ds_uvien_P_PHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_td_ds_uvien_P_PHEDUYET_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    ns_td_ds_uvien_P_LKE();
    form_P_LOI("loi:Offer thành công:loi");
    return false;
}
function ns_td_ds_uvien_P_XEM() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    form_P_MO("ns_td_hsuv_online.aspx", null, ["KQ", [b_so_id]]);
    return false;
}
function ns_td_dxuat_CHON() {
    var j = 0;
    var b_ktra = GridX_Fdt_cotGtri(b_grlkeId, ["chon", "so_id"]);
    var b_gt = b_ktra[1];
    for (var i = 0; i < b_gt.length; i++) {
        if (b_gt[i][0] == "X") { j++; }
    }
    if (j == 0) {
        for (var i = 0; i < b_gt.length; i++) {
            if (b_gt[i][1] != "") {
                GridX_datGtri(b_grlkeId, i + 1, ["chon"], ["X"]);
            }
        }
    }
    else {
        for (var i = 0; i < b_gt.length; i++) {
            GridX_datGtri(b_grlkeId, i + 1, ["chon"], [""]);
        }
    }
}
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


var ns_td_ds_choAct = 0;
function ns_td_ds_GR_lke_RowChange() {
    if (ns_td_ds_choAct != 0) clearTimeout(ns_td_ds_choAct);
    ns_td_ds_choAct = setTimeout("ns_td_ds_P_CHUYEN_HANG_LKE()", 300);
    return false;
}
//yen
function ns_td_ds_P_CHUYEN_HANG_LKE() {
    ns_td_ds_uvien_P_MOI();
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var a_cot = GridX_Fas_tenCot(b_grctId);
    //b_iurlId.src = b_loading_anhId;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "") $get(b_noidungId).value = "";
    else sns_td.Fs_NS_TD_LKE_CT(b_so_id, a_cot, ns_td_ds_P_CHUYEN_HANG_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}

function ns_td_ds_P_CHUYEN_HANG_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    $get(b_noidungId).value = a_kq[0];
    GridX_datBang(b_grctId, a_kq[1]);
    return false;
}

function ns_td_ds_uvien_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "") { form_P_LOI("loi:Chọn ứng viên muốn thêm thông tin:loi"); return false; }
        var b_loi = form_Fs_TEXT_KTRA(b_vungttId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungttId);
            var a_cot_lke = GridX_Fas_tenCot(b_grctId);
            sns_td.Fs_NS_TD_DS_UVIEN_NH(b_so_id,a_dt_ct, a_cot_lke, ns_td_ds_uvien_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_td_ds_uvien_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        GridX_datBang(b_grctId, b_kq);
        var b_vong = $get(b_vongId).value;
        var b_hang = GridX_Fi_timHangD(b_grctId, "vong", b_vong);
        if (b_hang >= 0) GridX_datA(b_grctId, b_hang);
    }
}

function ns_td_ds_uvien_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    form_P_MOI(b_vungttId, "GXL");
    GridX_thoiA(b_grctId);
    GridX_datTrang(b_grctId);
    $get(b_noidungId).value = "";
    return false;
}


var ns_td_ds_ct_choAct = 0;
function ns_td_ds_ct_GR_lke_RowChange() {
    if (ns_td_ds_ct_choAct != 0) clearTimeout(ns_td_ds_ct_choAct);
    ns_td_ds_ct_choAct = setTimeout("ns_td_ds_P_CHUYEN_HANG_CT()", 300);
    return false;
}
//yen
function ns_td_ds_P_CHUYEN_HANG_CT() {
    form_P_MOI(b_vungttId, "GXL");
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_hang_ct = GridX_Fi_timHangA(b_grctId);
    if (b_hang_ct < 1) return;
    //b_iurlId.src = b_loading_anhId;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "") return;
    var b_vong = C_NVL(GridX_Fas_layGtri(b_grctId, b_hang_ct, "vong"));
    if (b_vong == "") return;
    sns_td.Fs_NS_TD_DS_UVIEN_NH_LKE_CT(b_so_id, b_vong, ns_td_ds_P_CHUYEN_HANG_CT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}

function ns_td_ds_P_CHUYEN_HANG_CT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungttId, b_kq);
    return false;
}


function ns_td_ds_uvien_P_XOA() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) { form_P_LOI("loi:Chưa chọn ứng viên cần xóa:loi"); return false; }
        var b_hang_ct = GridX_Fi_timHangA(b_grctId);
        if (b_hang_ct < 1) { form_P_LOI("loi:Chưa chọn ngày thi/Vòng thi hoặc ứng viên chưa thi tuyển:loi"); return false;}
        //b_iurlId.src = b_loading_anhId;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        var b_chon = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "chon"));
        if (b_chon == "") {form_P_LOI("loi:Chưa chọn ứng viên cần xóa:loi"); return false;}
        if (b_so_id == "") return;
        var b_vong = C_NVL(GridX_Fas_layGtri(b_grctId, b_hang_ct, "vong"));
        if (b_vong == "") return;
        var a_cot_lke = GridX_Fas_tenCot(b_grctId);
        sns_td.Fs_NS_TD_DS_UVIEN_NH_LKE_XOA(b_so_id, b_vong, a_cot_lke, ns_td_ds_uvien_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI("loi:Chưa chọn ngày thi/Vòng thi hoặc ứng viên chưa thi tuyển:loi"); return false; }
}

function ns_td_ds_uvien_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        GridX_datBang(b_grctId, b_kq);
    }
}
function form_dong() {
    location.reload(false);
}
