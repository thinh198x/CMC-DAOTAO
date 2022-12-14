var ns_td_kq_td_lkeCho, b_vungId, b_vung_tkId, b_grlkeId, b_xuatfilemau, ns_td_kq_td_ds_lkeCho, ns_td_kq_td_choAct, b_grctId, b_slideId, b_namId, b_ma_ycId, b_ten_cdanhId, b_ten_phongId, b_gchuId,
    b_nam_tkId, b_ma_yctkId, b_ketquachung_Id, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C';
function ns_td_kq_td_P_KD() {
    ns_td_kq_td_choAct = 0,
    ns_td_kq_td_lkeCho = setInterval('ns_td_kq_td_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[0];
        b_doi = 0;
        if (b_dtuong.indexOf("MA_YC_TK") >= 0) {
            $get(b_ma_yctkId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
        } else if (b_dtuong.indexOf("CDANH_TK") >= 0) {
            $get(b_cdanh_tkId).value = a_tso[0];
            $get(b_cdanh_tkId).focus();
        } else if (b_dtuong.indexOf("MA_YC") >= 0) {
            $get(b_ma_ycId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            ns_td_kq_td_P_LKE_DS();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}
// Kiểm tra
function ns_td_kq_td_P_KTRA(b_maTen) {
    var b_maId = "";
    b_maTen = b_maTen.toUpperCase();
    switch (b_maTen) {
        case "NAM": b_maId = b_namId; break;
        case "NAM_TK": b_maId = b_nam_tkId; break;
        case "MAYEUCAU_TD": b_maId = b_ma_ycId; break;
    }
    if (b_maTen == "NAM") {
        var b_nam = $get(b_namId).value;
        sns_td.Fs_NS_TD_DEXUAT_LKE_BY_NAM(form_Fs_nsd(), window.name, 'DT_MAYEUCAU_TD', b_nam, ns_td_kq_td_P_KTRA_DR_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    } else if (b_maTen == "NAM_TK") {
        var b_nam = $get(b_nam_tkId).value;
        sns_td.Fs_NS_TD_DEXUAT_LKE_BY_NAM(form_Fs_nsd(), window.name, 'DT_MAYEUCAU_TK_TD', b_nam, ns_td_kq_td_P_KTRA_DR_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    } else if (b_maTen == "MAYEUCAU_TD") {
        var b_nam = $get(b_namId).value, b_yeucau = lke_Fs_TRA($get(b_ma_ycId));
        sns_td.Fs_TD_DEXUAT_BYMA(form_Fs_nsd(), b_nam, b_yeucau, ns_td_kq_td_P_THONGTIN_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        ns_td_kq_td_P_LKE_DS();
    }
}
function ns_td_kq_td_P_KTRA_DR_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
}
function ns_td_kq_td_P_THONGTIN_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    $get(b_ten_cdanhId).value = a_kq[0];
    $get(b_ten_phongId).value = a_kq[1];
}

// Nhập
function ns_td_kq_td_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_datTrang(b_grctId);
    $get(b_ketquachung_Id).value = "";
    return false;
}
function ns_td_kq_td_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        else {
            var a_dt = form_Faa_TEXT_ROW(b_vungId);
            var b_dt_ct = GridX_Fdt_cotGtri(b_grctId);
            var a_tso = slide_Faobj_TUDEN(b_slideId), a_cot = GridX_Fas_tenCot(b_grlkeId),
            b_nam = $get(b_nam_tkId).value, b_ma_yc = $get(b_ma_yctkId).value, b_so_id = $get(b_so_idId).value;
            sns_td.Fs_ns_td_kq_td_NH(form_Fs_nsd(), b_so_id, b_nam, b_ma_yc, a_dt, b_dt_ct, a_tso, a_cot, ns_td_kq_td_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
    } catch (err) { form_P_LOI(err); }

}
function ns_td_kq_td_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
        form_P_LOI("loi:Nhập thành công:loi");
    }
    return false;
}
// xóa
function ns_td_kq_td_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) {
        form_P_LOI("loi:Chưa chọn bản ghi cần xóa:loi");
        return false;
    };
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") ns_td_kq_td_P_LKE();
    else {
        var a_tso = slide_Faobj_TUDEN(b_slideId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_nam = $get(b_nam_tkId).value, b_ma_yc = $get(b_ma_yctkId).value;
        sns_td.Fs_ns_td_kq_td_XOA(form_Fs_nsd(), b_so_id, b_nam, b_ma_yc, a_tso, a_cot, ns_td_kq_td_P_XOA_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_td_kq_td_P_XOA_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI("loi:Xóa thành công!:loi");
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_td_kq_td_P_MOI();
        ns_td_kq_td_P_LKE();
        ns_td_kq_td_P_LKE_DS();
    }
}
// Chuyển hàng
function ns_td_kq_td_GR_lke_RowChange() {
    if (ns_td_kq_td_choAct != 0) clearTimeout(ns_td_kq_td_choAct);
    ns_td_kq_td_choAct = setTimeout("ns_td_kq_td_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_td_kq_td_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == null || b_so_id == "") { form_P_MOI("", "XGL"); GridX_datTrang(b_grctId); $get(b_ketquachung_Id).value = ""; }
        else {
            var a_cot_ct = GridX_Fas_tenCot(b_grctId);
            sns_td.Fs_ns_td_kq_td_CT(form_Fs_nsd(), b_so_id, a_cot_ct, ns_td_kq_td_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    } catch (err) { form_P_LOI(err); }

}
function ns_td_kq_td_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    GridX_datBang(b_grctId, a_kq[1]);
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    $get(b_so_idId).value = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
}
// Liệt kê
function ns_td_kq_td_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        b_vung_tkId = form_Fs_VUNG_ID('Upa_tk'), b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_grctId = form_Fs_VUNG_ID('GR_ct'), b_namId = form_Fs_TEN_ID(b_vungId, 'nam'), b_ma_ycId = form_Fs_TEN_ID(b_vungId, 'mayeucau_td'),
        b_ten_cdanhId = form_Fs_TEN_ID(b_vungId, 'ten_cdanh'), b_ten_phongId = form_Fs_TEN_ID(b_vungId, 'ten_phong'),
        b_nam_tkId = form_Fs_TEN_ID(b_vung_tkId, 'nam_tk'), b_ma_yctkId = form_Fs_TEN_ID(b_vung_tkId, 'ma_dx_tk'), b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'),
        b_ketquachung_Id = form_Fs_TEN_ID(b_grctId, 'ketqua_chung');        
        b_gchuId = form_Fs_VTEN_ID('', 'gchu');
        if (ns_td_kq_td_lkeCho != 0) clearTimeout(ns_td_kq_td_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_td_kq_td_P_LKE('K');
    }
}
function ns_td_kq_td_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_tso = slide_Faobj_TUDEN(b_slideId), a_cot = GridX_Fas_tenCot(b_grlkeId),
        b_nam = $get(b_nam_tkId).value, b_ma_yc = $get(b_ma_yctkId).value;
        sns_td.Fs_ns_td_kq_td_LKE(form_Fs_nsd(), b_nam, b_ma_yc, a_tso, a_cot, ns_td_kq_td_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_kq_td_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}
// Liệt kê danh sách khi chọn mã yêu cầu
function ns_td_kq_td_P_LKE_DS() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grctId), b_ma_yc = $get(b_ma_ycId).value;
        sns_td.Fs_ns_td_kq_td_DS(form_Fs_nsd(), b_ma_yc, a_cot, ns_td_kq_td_P_LKE_DS_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_kq_td_P_LKE_DS_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    GridX_datBang(b_grctId, a_kq[1]);
}
// Phê duyệt
function ns_td_kq_td_P_PHEDUYET() {
    try {
        var b_dt_ct = GridX_Fdt_cotGtri(b_grlkeId);
        sns_td.Fs_NS_TD_CV_ONLINE_PHEDUYET(form_Fs_nsd(), b_dt_ct, ns_td_kq_td_P_PHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    } catch (err) { form_P_LOI(err); }

}
function ns_td_kq_td_P_PHEDUYET_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_LOI("loi:Hoàn thành xếp phỏng vấn!:loi");
    return false;
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
function ns_td_kq_td_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    form_P_LOI('');
    return false;
}
function sendMail_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); return false;
}

// // them dong vao luoi
function ns_td_kq_td_P_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_td_kq_td_P_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_td_kq_td_P_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function ns_td_kq_td_P_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}

function form_dong() {
    location.reload(false);
}