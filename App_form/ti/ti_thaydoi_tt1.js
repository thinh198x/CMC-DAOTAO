var ti_thaydoi_tt_lkeCho;
function ti_thaydoi_tt_P_KD() {
    b_td_chengdId = form_Fs_VUNG_ID('id_chengd'); b_td_chenhdctId = form_Fs_VUNG_ID('id_chenhdct'); b_td_chentdId = form_Fs_VUNG_ID('id_chentd');
    b_vungId_tt = form_Fs_VUNG_ID('id_tt');
    b_so_theId = form_Fs_VTEN_ID('', 'SO_THE');
    b_statusId = form_Fs_VTEN_ID('', 'status');
    b_grgdId = form_Fs_VUNG_ID('GR_gd'), b_grhdctId = form_Fs_VUNG_ID('GR_hdct'), b_grtdId = form_Fs_VUNG_ID('GR_td');
    // b_vungId_tt 
    b_htksId = form_Fs_TEN_ID(b_vungId_tt, 'htks'), b_gtinhId = form_Fs_TEN_ID(b_vungId_tt, 'gtinh'), b_tenkhacId = form_Fs_TEN_ID(b_vungId_tt, 'tenkhac'),
    b_nsinhId = form_Fs_TEN_ID(b_vungId_tt, 'nsinh'), b_noisinhId = form_Fs_TEN_ID(b_vungId_tt, 'noisinh'), b_qquanId = form_Fs_TEN_ID(b_vungId_tt, 'qquan'),
    b_cmtId = form_Fs_TEN_ID(b_vungId_tt, 'cmt'), b_noioId = form_Fs_TEN_ID(b_vungId_tt, 'noio'), b_dtocId = form_Fs_TEN_ID(b_vungId_tt, 'dtoc'),
    b_tongiaoId = form_Fs_TEN_ID(b_vungId_tt, 'tongiao'), b_skhoeId = form_Fs_TEN_ID(b_vungId_tt, 'skhoe'),
    b_caoId = form_Fs_TEN_ID(b_vungId_tt, 'cao'), b_canId = form_Fs_TEN_ID(b_vungId_tt, 'can'), b_nhommauId = form_Fs_TEN_ID(b_vungId_tt, 'nhommau');
    ti_thaydoi_tt_lkeCho = setInterval('ti_thaydoi_tt_LKE_CHO()', 200);
}

function ti_thaydoi_tt_P_NPA(b_nv) {
    $get(b_td_chengdId).style.display = (b_nv == "gd") ? "" : "none";
    $get(b_td_chenhdctId).style.display = (b_nv == "hdct") ? "" : "none";
    $get(b_td_chentdId).style.display = (b_nv == "td") ? "" : "none";
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (C_NVL(b_dtuong) == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            var a_s = a_tso[0].split(',');
            if (a_s.length > 2) {
                b_ps = a_s[0]; b_nv = a_s[1]; form_Fctr_VTEN_DTUONG('', 'ten_form').innerHTML = "Thông tin thống kê " + a_s[2];
                ti_thaydoi_tt_P_CT();
            }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ti_thaydoi_tt_GR_Update(b_event) {
    var b_ctr = form_Fctr_event(b_event);
    if (C_NVL(b_ctr.value) != "") GridX_ThemHang(b_gridId);
    return false;
}
function ti_thaydoi_tt_LKE_CHO() {
     clearTimeout(ti_thaydoi_tt_lkeCho); ti_thaydoi_tt_P_CT();
}

function ti_thaydoi_tt_P_CT() {
    var b_so_the = $get(b_so_theId).value;
    sti_ch.Fs_NS_TI_THAYDOI_CT(b_so_the, ti_thaydoi_tt_P_CT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}

function ti_thaydoi_tt_P_CT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('$');
    if (a_kq[0] == '0') $get(b_statusId).innerHTML = "Hồ sơ đã được phê duyệt";
    if (a_kq[0] == '1') $get(b_statusId).innerHTML = "Hồ sơ chưa được phê duyệt";
    if (a_kq[0] == '2') $get(b_statusId).innerHTML = "Hồ sơ không được phê duyệt";
    form_P_CH_TEXT(b_vungId_tt, a_kq[1]);
    ti_thaydoi_tt_P_MAU(a_kq[2]);
    return false;
}
//["htks_mau"] + "#" + ["gtinh_mau"] + "#" + ["tenkhac_mau"] + "#" + ["nsinh_mau"] + "#" + ["noisinh_mau"]
//                + "#" + ["qquan_mau"] + "#" + ["cmt_mau"] + "#" + ["noio_mau"] + "#" + ["dtoc_mau"] + "#" + ["tongiao_mau"] + "#" + ["skhoe_mau"]
//                + "#" + ["cao_mau"] + "#" + ["can_mau"] + "#" + ["nhommau_mau"];

function ti_thaydoi_tt_P_MAU(b_kq)
{
    var a_kq = b_kq.split('#');
    $get(b_htksId).style.background=a_kq[0];
    $get(b_gtinhId).style.background=a_kq[1];
    $get(b_tenkhacId).style.background=a_kq[2];
    $get(b_nsinhId).style.background=a_kq[3];
    $get(b_noisinhId).style.background=a_kq[4];
    $get(b_qquanId).style.background=a_kq[5];
    $get(b_cmtId).style.background=a_kq[6];
    $get(b_noioId).style.background=a_kq[7];
    $get(b_dtocId).style.background=a_kq[8];
    $get(b_tongiaoId).style.background=a_kq[9];
    $get(b_skhoeId).style.background=a_kq[10];
    $get(b_caoId).style.background=a_kq[11];
    $get(b_canId).style.background=a_kq[12];
    $get(b_nhommauId).style.background = a_kq[13];
    return false;
}

function ti_thaydoi_tt_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId_tt);
            var b_so_the = $get(b_so_theId).value;
            sti_ch.Fs_NS_TI_THAYDOI_NH(b_so_the, a_dt_ct, ti_thaydoi_tt_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}

function ti_thaydoi_tt_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI('loi:Cập nhật dữ liệu thành công, vui lòng chờ phê duyệt:loi');
        ti_thaydoi_tt_P_CT();
        return false;
    }
}

function ti_thaydoi_tt_P_XOA() {
    var b_so_the = $get(b_so_theId).value;
    sti_ch.Fs_NS_TI_THAYDOI_XOA(b_so_the, ti_thaydoi_tt_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}

function ti_thaydoi_tt_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI('loi:Xóa dữ liệu cập nhập thành công!:loi');
        ti_thaydoi_tt_P_CT();
        return false;
    }
}

function ti_thaydoi_tt_P_PD() {
    var b_so_the = $get(b_so_theId).value;
    sti_ch.Fs_NS_TI_THAYDOI_PD(b_so_the, ti_thaydoi_tt_P_PD_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}

function ti_thaydoi_tt_P_PD_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI('loi:Phê duyệt thành công!:loi');
        ti_thaydoi_tt_P_CT();
        return false;
    }
}

function ti_thaydoi_tt_P_KPD() {
    var b_so_the = $get(b_so_theId).value;
    sti_ch.Fs_NS_TI_THAYDOI_KPD(b_so_the, ti_thaydoi_tt_P_KPD_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}

function ti_thaydoi_tt_P_KPD_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI('loi:Không phê duyệt thành công!:loi');
        ti_thaydoi_tt_P_CT();
        return false;
    }
}

function ti_thaydoi_tt_HangLen(b_ktra) {
    if (b_ktra == 'GD') GridX_chuyenHang(b_grgdId, -1);
    if (b_ktra == 'HDCT') GridX_chuyenHang(b_grhdctId, -1);
    if (b_ktra == 'TD') GridX_chuyenHang(b_grtdId, -1);
    return false;
}
function ti_thaydoi_tt_HangXuong(b_ktra) {
    if (b_ktra == 'GD') GridX_chuyenHang(b_grgdId, 1);
    if (b_ktra == 'HDCT') GridX_chuyenHang(b_grhdctId, 1);
    if (b_ktra == 'TD') GridX_chuyenHang(b_grtdId, 1);
    return false;
}
function ti_thaydoi_tt_CatDong(b_dk,b_ktra) {
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
function ti_thaydoi_tt_ChenDong(b_ktra) {
    if (b_ktra == 'GD') GridX_boChon(b_grgdId, 'C');
    if (b_ktra == 'HDCT') GridX_boChon(b_grhdctId, 'C');
    if (b_ktra == 'TD') GridX_boChon(b_grtdId, 'C');
    return false;
}




