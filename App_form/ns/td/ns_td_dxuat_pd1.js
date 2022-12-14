var ns_td_dxuat_pd_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timId, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C';
function ns_td_dxuat_pd_P_KD() {
    ns_td_dxuat_pd_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_gocId = form_Fs_TEN_ID(b_vungId, 'tinhtrang');
    b_slideId = b_grlkeId + '_slide';
    b_noidungId = form_Fs_VTEN_ID('', 'noidung');
    ns_td_dxuat_pd_lkeCho = setInterval('ns_td_dxuat_pd_P_LKE_CHO()', 200);

}
function ns_td_dxuat_pd_P_KTRA(b_maTen) {
    var b_maId = "";
    b_maTen = b_maTen.toUpperCase();
    switch (b_maTen) {
        case "TINHTRANG": b_maId = b_gocId; break;
    }
    if (b_maTen == "TINHTRANG") { ns_td_dxuat_pd_P_LKE(); }
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[0];
    }
    catch (err) { form_P_LOI(err); }
}
function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}

function ns_td_dxuat_pd_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (ns_td_dxuat_pd_lkeCho != 0) clearTimeout(ns_td_dxuat_pd_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_td_dxuat_pd_P_LKE('K');
    }
}

function ns_td_dxuat_pd_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            a_tinhtrang = $get(b_gocId).value;
        sns_td.Fs_NS_TD_DEXUAT_PD_LKE(a_tinhtrang, a_tso, a_cot, ns_td_dxuat_pd_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_dxuat_pd_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}

function ns_td_dxuat_pd_P_PHEDUYET() {
    var b_trangthai = $get(b_gocId).value;
    if (b_trangthai != '0') { form_P_LOI('loi:Không thể chỉnh sửa bản ghi này:loi'); return false; }
    var b_dt_ct = GridX_Fdt_cotGtri(b_grlkeId);
    sns_td.Fs_NS_TD_DEXUAT_PD_PHEDUYET(b_dt_ct, ns_td_dxuat_pd_P_PHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_td_dxuat_pd_P_PHEDUYET_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_LOI("loi:Phê duyệt thành công!:loi");
    GridX_datTrang(b_grlkeId);
    ns_td_dxuat_pd_P_LKE();
    //sendMail(b_kq);
    return false;
}

function ns_td_dxuat_pd_P_KOPHEDUYET() {
    var b_trangthai = $get(b_gocId).value;
    if (b_trangthai != '0') { form_P_LOI('loi:Không thể chỉnh sửa bản ghi này:loi'); return false; }
    var b_dt_ct = GridX_Fdt_cotGtri(b_grlkeId);
    sns_td.Fs_NS_TD_DEXUAT_PD_KOPHEDUYET(b_dt_ct, ns_td_dxuat_pd_P_KOPHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_td_dxuat_pd_P_KOPHEDUYET_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_LOI("loi:Không phê duyệt thành công!:loi");
    GridX_datTrang(b_grlkeId);
    ns_td_dxuat_pd_P_LKE();
    return false;
}

function ns_td_dxuat_pd_P_XEM() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_phong = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "phong")),
        b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma")),
        b_lan = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "lan"));
    form_P_MO("ns_td_dexuat.aspx", null, ["KQ", [b_phong, b_ma, b_lan]]);
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

var ns_td_dexuat_pd_choAct = 0;
function ns_td_dexuat_pd_GR_lke_RowChange() {
    if (ns_td_dexuat_pd_choAct != 0) clearTimeout(ns_td_dexuat_pd_choAct);
    ns_td_dexuat_pd_choAct = setTimeout("ns_td_dexuat_pd_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_td_dexuat_pd_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    sns_td.Fs_NS_TD_DEXUAT_PD_CT(b_so_id, ns_td_dexuat_pd_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    GridX_datA(b_grlkeId, b_hang);
}
function ns_td_dexuat_pd_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    $get(b_noidungId).value = b_kq;
}

function form_dong() {
    location.reload(false);
}