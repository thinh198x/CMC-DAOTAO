       var ns_dt_danhsach_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timId;
function ns_dt_danhsach_P_KD() {
    ns_dt_danhsach_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_gocId = form_Fs_TEN_ID(b_vungId, 'tinhtrang');
    b_slideId = b_grlkeId + '_slide';
    ns_dt_danhsach_lkeCho = setInterval('ns_dt_danhsach_P_LKE_CHO()', 200);

}
function ns_dt_danhsach_P_KTRA(b_maTen) {
    var b_maId = "";
    b_maTen = b_maTen.toUpperCase();
    switch (b_maTen) {
        case "TINHTRANG": b_maId = b_gocId; break;
    }
    if (b_maTen == "TINHTRANG") { ns_dt_danhsach_P_LKE(); }
}

function ns_dt_danhsach_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_dt_danhsach_lkeCho); ns_dt_danhsach_P_LKE(); }
}
function ns_dt_danhsach_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            a_tinhtrang = $get(b_gocId).value;
        sns_dt.Fs_NS_DT_DANHSACH_LKE(a_tinhtrang, a_tso, a_cot, ns_dt_danhsach_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_danhsach_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    return false;
}

function ns_dt_danhsach_P_PHEDUYET() { 
    a_tinhtrang = $get(b_gocId).value; 
    if (a_tinhtrang == 1) {
        return false;
    }
    var b_dt_ct = GridX_Fdt_cotGtri(b_grlkeId);
    sns_dt.Fs_NS_DT_DANHSACH_PHEDUYET(b_dt_ct, ns_dt_danhsach_P_PHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_dt_danhsach_P_PHEDUYET_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_LOI("loi:Phê duyệt thành công!:loi");
    GridX_datTrang(b_grlkeId);
    ns_dt_danhsach_P_LKE();
    //sendMail(b_kq);
    return false;
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

function ns_dt_danhsach_P_KOPHEDUYET() {
     
    var b_dt_ct = GridX_Fdt_cotGtri(b_grlkeId);
    sns_dt.Fs_NS_DT_DANHSACH_KOPHEDUYET(b_dt_ct, ns_dt_danhsach_P_KOPHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_dt_danhsach_P_KOPHEDUYET_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        return false;
    }
    form_P_LOI("loi:Không phê duyệt thành công!:loi");
    GridX_datTrang(b_grlkeId);
    ns_dt_danhsach_P_LKE();
    return false;
}

function ns_dt_danhsach_P_CHOPHEDUYET() { 
    var b_dt_ct = GridX_Fdt_cotGtri(b_grlkeId);
    sns_dt.Fs_NS_DT_DANHSACH_CHOPHEDUYET(b_dt_ct, ns_dt_danhsach_P_CHOPHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}

function ns_dt_danhsach_P_CHOPHEDUYET_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        form_P_LOI("loi:Chuyển về chờ phê duyệt thành công!:loi");
        GridX_datTrang(b_grlkeId);
        ns_dt_danhsach_P_LKE();
        return false;
    } catch (err) { form_P_LOI(err); }
}

function ns_dt_danhsach_P_XEM() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return false;
    var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma")),
        b_phong = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "phong")),
        b_lan = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "lan"));
    form_P_MO("ns_dt_dxuat.aspx", null, ["KQ", [b_ma, b_phong, b_lan]]);
    return false;
}
function ns_dt_danhsach_CHON() {
    var j = 0;
    var b_ktra = GridX_Fdt_cotGtri(b_grlkeId, ["chon", "ma"]);
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
    return false;
}
function form_dong() {
    location.reload(false);
}