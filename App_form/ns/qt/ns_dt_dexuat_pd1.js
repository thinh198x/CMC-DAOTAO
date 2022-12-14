var ns_dt_dexuat_pd_lkeCho, b_vungId, b_thang_tkId, b_grlkeId, b_slideId, b_gocId, b_timId, b_denngayId, b_tungayId;
function ns_dt_dexuat_pd_P_KD() {
    ns_dt_dexuat_pd_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungTKId = form_Fs_VUNG_ID('UPa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_gocId = form_Fs_TEN_ID(b_vungId, 'tinhtrang');
    b_slideId = b_grlkeId + '_slide';
    b_noidungId = form_Fs_VTEN_ID('', 'noidung'),
        b_thang_tkId = form_Fs_TEN_ID(b_vungTKId, 'thang'),
        ns_dt_dexuat_pd_lkeCho = setInterval('ns_dt_dexuat_pd_P_LKE_CHO()', 200);

}
function ns_dt_dexuat_pd_P_KTRA(b_maTen) {
    var b_maId = "";
    b_maTen = b_maTen.toUpperCase();
    switch (b_maTen) {
        case "TINHTRANG": b_maId = b_gocId; break;
    }
    if (b_maTen == "TINHTRANG") { ns_dt_dexuat_pd_P_LKE(); }
}

function ns_dt_dexuat_pd_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ns_dt_dexuat_pd_lkeCho != 0) clearTimeout(ns_dt_dexuat_pd_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_dt_dexuat_pd_P_LKE();
    }
}
function ns_dt_dexuat_pd_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_thangId = form_Fs_TEN_GTRI(b_vungId, 'thang');
        a_tinhtrang = form_Fs_TEN_GTRI(b_vungId, 'tinhtrang');
        sns_dt.Fs_NS_DT_DEXUAT_PD_LKE(b_thangId, a_tinhtrang, "", "", a_tso, a_cot, ns_dt_dexuat_pd_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_dexuat_pd_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    if (b_kq == "#") return;
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    return false;
}

function ns_dt_dexuat_pd_P_PHEDUYET(b_kq) {
    var a_tinhtrang = form_Fs_TEN_GTRI(b_vungId, 'tinhtrang');
    if (a_tinhtrang == '0') {
        var message = confirm("Bạn có chắc chắn Phê duyệt?");
        if (message == false) { return false; }
        var b_dt_ct = GridX_Fdt_cotGtri(b_grlkeId), b_thangId = form_Fs_TEN_GTRI(b_vungId, 'thang');
        sns_dt.Fs_NS_DT_DEXUAT_PD_PHEDUYET(b_thangId, a_tinhtrang, "", "", b_dt_ct, ns_dt_dexuat_pd_P_PHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    else {
        form_P_LOI("loi:Chỉ được phê duyệt bản ghi đang chờ phê duyệt:loi");
        return false;
    }
    return false;
}

function ns_dt_dexuat_pd_P_PHEDUYET_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_LOI("loi:Phê duyệt thành công:loi");
    GridX_datTrang(b_grlkeId);
    ns_dt_dexuat_pd_P_LKE();
    return false;
}

function sendMailM(b_kq) {
    try {
        var a_kq = Fas_ChMang(b_kq, ';');
        for (var i = 0; i < a_kq.length; i++) {
            a_kq[i] = Fas_ChMang(a_kq[i], "|");
        }
        var b_sendmail = Array();
        b_sendmail[0] = "ten,email,subject,body";
        b_sendmail[0] = Fas_ChMang(b_sendmail[0], ",");
        b_sendmail[1] = a_kq;
        //sSmtpMail.SendMailM(b_kq, sendMail_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function sendMail_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); return false;
}

function ns_dt_dexuat_pd_P_KOPHEDUYET() {
    var a_tinhtrang = form_Fs_TEN_GTRI(b_vungId, 'tinhtrang')
    if (a_tinhtrang == '0') {
        var message = confirm("Bạn có chắc chắn Không phê duyệt?");
        if (message == false) { return false; }
        var b_dt_ct = GridX_Fdt_cotGtri(b_grlkeId),
            b_thangId = form_Fs_TEN_GTRI(b_vungId, 'thang');
        sns_dt.Fs_NS_DT_DEXUAT_PD_KOPHEDUYET(b_thangId, a_tinhtrang, "", "", b_dt_ct, ns_dt_dexuat_pd_P_KOPHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    else {
        form_P_LOI("loi:Chỉ được không phê duyệt bản ghi đang chờ phê duyệt:loi");
        return false;
    }
    return false;
}
function ns_dt_dexuat_pd_P_KOPHEDUYET_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_LOI("loi:Không phê duyệt thành công:loi");
    GridX_datTrang(b_grlkeId);
    ns_dt_dexuat_pd_P_LKE();
    return false;
}

function ns_dt_dexuat_pd_P_XEM() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_the = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the")),
        b_ngayxn = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ngayxn")),
        b_ngayd = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ngayd"));
    form_P_MO("ns_qt_xin_nghiphep_ct.aspx", null, ["KQ", [b_so_the, b_ngayxn, b_ngayd]]);
    return false;
}

function ns_dt_dexuat_pd_CHON() {
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

var ns_dt_dexuat_pd_choAct = 0;
function ns_dt_dexuat_pd_GR_lke_RowChange() {
    if (ns_dt_dexuat_pd_choAct != 0) clearTimeout(ns_dt_dexuat_pd_choAct);
    ns_dt_dexuat_pd_choAct = setTimeout("ns_dt_dexuat_pd_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_dt_dexuat_pd_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_the = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the")),
        b_ngayxn = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ngayxn")),
        b_ngayd = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ngayd"));
    sns_dt.Fs_NS_DT_DEXUAT_PD_CT(b_so_the, b_ngayxn, b_ngayd, ns_dt_dexuat_pd_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    GridX_datA(b_grlkeId, b_hang);
}
function ns_dt_dexuat_pd_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    $get(b_noidungId).value = b_kq;
}
function form_dong() {
    location.reload(false);
}