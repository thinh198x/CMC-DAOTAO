var ns_td_pd_cdanh_td_ql_lkeCho, b_vungId, b_phong_tkId, b_grlkeId, b_namId, b_slideId, b_sothe_tkId, b_kycongId, b_tinhtrangId, b_timId, b_namId, b_ma_dxId, b_an_sotheId;
function ns_td_pd_cdanh_td_ql_P_KD() {
    ns_td_pd_cdanh_td_ql_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungTKId = form_Fs_VUNG_ID('UPa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
    b_namId = form_Fs_TEN_ID(b_vungTKId, 'nam_tk'); b_ma_dxId = form_Fs_TEN_ID(b_vungTKId, 'ma_dx_tk'); b_tinhtrangId = form_Fs_TEN_ID(b_vungId, 'tinhtrang');
    b_sothe_tkId = form_Fs_TEN_ID(b_vungTKId, 'so_the_tk'); b_an_sotheId = form_Fs_VTEN_ID('UPa_hi', 'an_sothe');
    b_slideId = b_grlkeId + '_slide';
    b_noidungId = form_Fs_VTEN_ID('', 'mota'); b_phong_tkId = form_Fs_TEN_ID(b_vungTKId, 'PHONG');
    lke_P_DAT($get(b_phong_tkId), 'TATCA' + '{' + 'Tất cả');
    ns_td_pd_cdanh_td_ql_lkeCho = setInterval('ns_td_pd_cdanh_td_ql_P_LKE_CHO()', 200);

}
function ns_td_pd_cdanh_td_ql_P_KTRA(b_maTen) {
    var b_maId = "";
    b_maTen = b_maTen.toUpperCase();
    switch (b_maTen) {
        case "TINHTRANG": b_maId = b_tinhtrangId; break;
        case "NAM_TK": b_maId = b_namId; break;
    }
    if (b_maTen == "TINHTRANG") { ns_td_pd_cdanh_td_ql_P_LKE(); }
    else if (b_maTen == "NAM_TK") {
        var b_nam = form_Fs_TEN_GTRI(b_vungTKId, 'NAM_TK');
        sns_td.Fs_NS_TD_DEXUAT_LKE_BY_NAM(form_Fs_nsd(), window.name, 'DT_MAYEUCAU_TK_TD', b_nam, ns_td_pd_cdanh_td_ql_P_KTRA_DR_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function ns_td_pd_cdanh_td_ql_P_KTRA_DR_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
}
function ns_td_pd_cdanh_td_ql_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ns_td_pd_cdanh_td_ql_lkeCho != 0) clearTimeout(ns_td_pd_cdanh_td_ql_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_td_pd_cdanh_td_ql_P_LKE();
    }
}
function ns_td_pd_cdanh_td_ql_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_nam = $get(b_namId).value, b_ma_dx = $get(b_ma_dxId).value, b_tinhtrang = list_Fs_TRA($get(b_tinhtrangId)), b_so_the = $get(b_sothe_tkId).value;
        sns_td.Fs_NS_TD_PD_CDANH_TD_QL_LKE(b_nam, b_ma_dx, b_tinhtrang, b_so_the, a_tso, a_cot, ns_td_pd_cdanh_td_ql_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_pd_cdanh_td_ql_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    if (b_kq == "#") return;
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    return false;
}

function ns_td_pd_cdanh_td_ql_P_PHEDUYET(b_kq) {
    var a_tinhtrang = list_Fs_TRA($get(b_tinhtrangId));
    if (a_tinhtrang == 'CPD') {
        var message = confirm("Bạn có chắc chắn Phê duyệt?");
        if (message == false) { return false; }
        var b_dt_ct = GridX_Fdt_cotGtri(b_grlkeId);
        sns_td.Fs_NS_TD_PD_CDANH_TD_QL_PHEDUYET(b_dt_ct, ns_td_pd_cdanh_td_ql_P_PHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    } else {
        form_P_LOI("loi:Chỉ được phê duyệt bản ghi đang chờ phê duyệt:loi");
        return false;
    }
}

function ns_td_pd_cdanh_td_ql_P_PHEDUYET_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_LOI("loi:Phê duyệt thành công:loi");
    GridX_datTrang(b_grlkeId);
    ns_td_pd_cdanh_td_ql_P_LKE();
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

function ns_td_pd_cdanh_td_ql_P_KOPHEDUYET() {
    var a_tinhtrang = list_Fs_TRA($get(b_tinhtrangId));
    if (a_tinhtrang == 'CPD') {
        var message = confirm("Bạn có chắc chắn Không phê duyệt?");
        if (message == false) { return false; }
        var a_dt_ct = GridX_Fdt_cotGtri(b_grlkeId);
        sns_td.Fs_NS_TD_PD_CDANH_TD_QL_KOPHEDUYET(a_dt_ct, ns_td_pd_cdanh_td_ql_P_KOPHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    } else {
        form_P_LOI("loi:Chỉ được không phê duyệt bản ghi đang chờ phê duyệt:loi");
        return false;
    }
}
function ns_td_pd_cdanh_td_ql_P_KOPHEDUYET_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_LOI("loi:Không phê duyệt thành công:loi");
    GridX_datTrang(b_grlkeId);
    ns_td_pd_cdanh_td_ql_P_LKE();
    return false;
}

function ns_td_pd_cdanh_td_ql_P_XEM() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_the = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the")),
        b_ngayxn = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ngayxn")),
        b_ngayd = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ngayd"));
    form_P_MO("ns_qt_xin_nghiphep_ct.aspx", null, ["KQ", [b_so_the, b_ngayxn, b_ngayd]]);
    return false;
}

function ns_td_pd_cdanh_td_ql_CHON() {
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

var ns_td_pd_cdanh_td_ql_choAct = 0;
 
function ns_td_pd_cdanh_td_ql_P_MO_FILE(b_event, b_mo) {
    if (b_mo) {
        // tìm row sinh ra sự kiện
        var b_row = GridX_Fr_E(b_event);
        var b_hang_at = CSO_SO(b_row.getAttribute('hang'));
        // đặt active vào hàng đó
        GridX_datA(b_grlkeId, b_hang_at);
        // lấy số id thời điểm click
        var b_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang_at, "so_id"));
        var b_so_the = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang_at, "so_the"));
        $get(b_an_sotheId).value = b_so_the;
        if (b_so_the == "") { return false; }
        var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
        $get(b_btn_excel).click();
    }
    return false;
}

function form_dong() {
    location.reload(false);
}