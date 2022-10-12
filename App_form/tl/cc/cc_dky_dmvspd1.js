var cc_dky_dmvspd_lkeCho, b_vungId, b_phong_tkId, b_loai_dkyId, b_grlkeId, b_slideId, b_sothe_tkId, b_vungTKId, b_gocId, b_timId, b_denngayId, b_tungayId;
function cc_dky_dmvspd_P_KD() {
    cc_dky_dmvspd_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungTKId = form_Fs_VUNG_ID('UPa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_gocId = form_Fs_TEN_ID(b_vungId, 'tinhtrang');
    b_slideId = b_grlkeId + '_slide';
    b_noidungId = form_Fs_VTEN_ID('', 'noidung'),
        b_phong_tkId = form_Fs_TEN_ID(b_vungTKId, 'PHONG'), b_tungayId = form_Fs_TEN_ID(b_vungTKId, 'ngayd'),
        b_denngayId = form_Fs_TEN_ID(b_vungTKId, 'ngayc'), b_sothe_tkId = form_Fs_TEN_ID(b_vungTKId, 'so_the_tk');
    b_loai_dkyId = form_Fs_TEN_ID(b_vungTKId, 'loai_dky_tk')
    lke_P_DAT($get(b_phong_tkId), 'TATCA' + '{' + 'Tất cả');
    cc_dky_dmvspd_lkeCho = setInterval('cc_dky_dmvspd_P_LKE_CHO()', 200);

}
function cc_dky_dmvspd_P_KTRA(b_maTen) {
    var b_maId = "";
    b_maTen = b_maTen.toUpperCase();
    switch (b_maTen) {
        case "TINHTRANG": b_maId = b_gocId; break; m
    }
    if (b_maTen == "TINHTRANG") { cc_dky_dmvspd_P_LKE(); }
}

function cc_dky_dmvspd_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (cc_dky_dmvspd_lkeCho != 0) clearTimeout(cc_dky_dmvspd_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        cc_dky_dmvspd_P_LKE();
    }
}
function cc_dky_dmvspd_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_ngayd = $get(b_tungayId).value, b_ngayc = $get(b_denngayId).value,
            b_phongId = lke_Fs_TRA($get(b_phong_tkId));
        var a_tinhtrang = form_Fs_TEN_GTRI(b_vungTKId, 'tinhtrang'),
            b_so_the = $get(b_sothe_tkId).value, b_loai_dkyId = form_Fs_TEN_GTRI(b_vungTKId, 'loai_dky_tk');
        stl_cc.Fs_CC_DKY_DMVSPD_LKE(b_phongId, a_tinhtrang, b_loai_dkyId, b_so_the, b_ngayd, b_ngayc, a_tso, a_cot, cc_dky_dmvspd_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;

    }
    catch (err) { form_P_LOI(err); }
}
function cc_dky_dmvspd_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    if (b_kq == "#") return;
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    return false;
}

function cc_dky_dmvspd_P_PHEDUYET(b_kq) {
    var a_tinhtrang = form_Fs_TEN_GTRI(b_vungTKId, 'tinhtrang');
    if (a_tinhtrang == '0') {
        var message = confirm("Bạn có chắc chắn Phê duyệt?");
        if (message == false) { return false; }
        var b_dt_ct = GridX_Fdt_cotGtri(b_grlkeId), b_ngayd = $get(b_tungayId).value, b_ngayc = $get(b_denngayId).value, b_phongId = lke_Fs_TRA($get(b_phong_tkId));
        stl_cc.Fs_CC_DKY_DMVSPD_PHEDUYET(b_phongId, a_tinhtrang, b_ngayd, b_ngayc, b_dt_ct, cc_dky_dmvspd_P_PHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    } else {
        form_P_LOI("loi:Chỉ được phê duyệt bản ghi đang chờ phê duyệt:loi");
        return false;
    }
}

function cc_dky_dmvspd_P_PHEDUYET_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_LOI("loi:Phê duyệt thành công:loi");
    GridX_datTrang(b_grlkeId);
    cc_dky_dmvspd_P_LKE();
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

function cc_dky_dmvspd_P_KOPHEDUYET() {
    var a_tinhtrang = form_Fs_TEN_GTRI(b_vungTKId, 'tinhtrang');
    if (a_tinhtrang == '0') {
        var message = confirm("Bạn có chắc chắn Không phê duyệt?");
        if (message == false) { return false; }
        var b_dt_ct = GridX_Fdt_cotGtri(b_grlkeId), b_ngayd = $get(b_tungayId).value, b_ngayc = $get(b_denngayId).value, b_phongId = lke_Fs_TRA($get(b_phong_tkId));
        stl_cc.Fs_CC_DKY_DMVSPD_KOPHEDUYET(b_phongId, a_tinhtrang, b_ngayd, b_ngayc, b_dt_ct, cc_dky_dmvspd_P_KOPHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    } else {
        form_P_LOI("loi:Chỉ được không phê duyệt bản ghi đang chờ phê duyệt:loi");
        return false;
    }
}
function cc_dky_dmvspd_P_KOPHEDUYET_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_LOI("loi:Không phê duyệt thành công:loi");
    GridX_datTrang(b_grlkeId);
    cc_dky_dmvspd_P_LKE();
    return false;
}

function cc_dky_dmvspd_P_XEM() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_the = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the")),
        b_ngayxn = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ngayxn")),
        b_ngayd = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ngayd"));
    form_P_MO("ns_qt_xin_nghiphep_ct.aspx", null, ["KQ", [b_so_the, b_ngayxn, b_ngayd]]);
    return false;
}

function cc_dky_dmvspd_CHON() {
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

var cc_dky_dmvspd_choAct = 0;
function cc_dky_dmvspd_GR_lke_RowChange() {
    if (cc_dky_dmvspd_choAct != 0) clearTimeout(cc_dky_dmvspd_choAct);
    cc_dky_dmvspd_choAct = setTimeout("cc_dky_dmvspd_P_CHUYEN_HANG()", 300);
    return false;
}
function cc_dky_dmvspd_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_the = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the")),
        b_ngayxn = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ngayxn")),
        b_ngayd = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ngayd"));
    stl_cc.Fs_CC_DKY_DMVSPD_CT(b_so_the, b_ngayxn, b_ngayd, cc_dky_dmvspd_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    GridX_datA(b_grlkeId, b_hang);
}
function cc_dky_dmvspd_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    $get(b_noidungId).value = b_kq;
}
function form_dong() {
    location.reload(false);
}