var b_tmf, b_cho_control = 0, ns_ths_lkeCho, b_vungId, b_so_theId, ns_ths_choAct = 0, b_grctId,
    b_tenId, b_slideIdct, b_vungttId, b_xoaId, b_moiId;
function ns_ths_P_KD(b_tm) {
    b_tmf = b_tm;
    ns_ths_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct');
    b_grctId = form_Fs_VUNG_ID('GR_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
    b_vungttId = form_Fs_VUNG_ID('UPa_tt');
    b_so_theId = form_Fs_TEN_ID(b_vungId, 'SO_THE');
    b_tenId = form_Fs_TEN_ID(b_vungId, 'ten'); b_xoaId = form_Fs_VTEN_ID('', 'xoa'); b_moiId = form_Fs_VTEN_ID('', 'moi')
    b_slideIdct = $get(b_grctId).getAttribute('slideId');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
}
function P_cho(b_so_the, b_ten) {
    try {
        if (b_doi == 0) {
            $get(b_so_theId).value = b_so_the;
            $get(b_tenId).value = b_ten;
            $get(b_so_theId).setAttribute("disabled", "disabled");
            ns_ths_P_CHUYEN_HANG();
            b_doi = 1;
            clearTimeout(b_cho_control);
        }
    }
    catch (err) {
        b_doi = 0;
    }
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        b_doi = 0;
        if (b_dtuong.indexOf("SO_THE") >= 0 || b_dtuong.indexOf("THAMSO") >= 0) {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "')", 200);
        }
        else if (b_dtuong.indexOf("FILEIMP") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            GridX_datGtri(b_grctId, b_hang, ["duong_dan"], b_kq);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ths_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_so_theId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        else if (b_maTen == "SO_THE") {
            ns_ths_P_CHUYEN_HANG();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ths_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    // GridX_thoiA(b_grlkeId);
    GridX_thayGtriT(b_grctId, 'chon', "");
    $get(b_so_theId).focus();
    return false;
}
function ns_ths_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") {
            form_P_LOI(b_loi);
            return false;
        }
        //var ktra = sosanh_withDateTimeNow($get(b_ngay_d).value);
        //if (ktra > 0) {
        //    form_P_LOI('loi:Ngày nhập không được lớn hơn ngày hiện tại:loi');
        //    return false;
        //}
        else {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            var b_so_id = C_NVL(GridX_Fas_layGtri(b_grctId, b_hang, "so_id"));
            //var b_dg_dan = $get(b_duong_dan_Id).value;
            var b_dt = form_Faa_TEXT_ROW(b_vungId);
            var a_cot_ct = GridX_Fdt_cotGtri(b_grctId), a_cot_lke = GridX_Fdt_cotGtri(b_grlkeId);
            sns_tt.Fs_NS_THS_NH(b_dt, a_cot_ct, a_cot_lke, ns_ths_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ths_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        form_P_LOI('loi:Ghi thành công:loi');
        ns_ths_P_CHUYEN_HANG();
    }
    return false;
}
function ns_ths_P_XOA() {
    var b_so_the = $get(b_so_theId).value;
    if (b_so_the == null || b_so_the == "") ns_ths_P_MOI();
    else {
        var b_so_the = $get(b_so_theId).value;
        sns_tt.Fs_NS_THS_XOA(b_so_the, ns_ths_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_ths_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        ns_ths_P_CHUYEN_HANG();
        form_P_LOI('loi:Xóa thành công:loi');
        return false;
    }
}
function ns_ths_GR_ct_RowChange() {
    try {
        var today = new Date(), dd = today.getDate(), mm = today.getMonth() + 1;
        var yyyy = today.getFullYear();
        if (dd < 10) {
            dd = '0' + dd;
        }
        if (mm < 10) {
            mm = '0' + mm;
        }
        var b_today = dd + '/' + mm + '/' + yyyy;
        var b_hang = GridX_Fi_timHangA(b_grctId);
        //var b_ngay_p = GridX_Fas_layGtriA(b_grctId, "ngay_p");
        var b_chon = GridX_Fas_layGtriA(b_grctId, "chon");
        //if (b_ngay_p == "") {
        // GridX_datGtri(b_grctId, b_hang, ["ngay_p"], b_today, 'K');
        // }
        return false;
    } catch (err) { form_P_LOI(err); }
}
function ns_ths_P_CHUYEN_HANG() {
    var b_so_the = $get(b_so_theId).value;
    if (b_so_the == null || b_so_the == "") { return false }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideIdct);
        sns_tt.Fs_NS_THS_CT(b_so_the, a_cot_ct, a_cot_lke, a_tso, ns_ths_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function ns_ths_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungttId, a_kq[0]);
    slide_P_SOTRANG(b_slideIdct, CSO_SO(a_kq[3], 0))
    GridX_datBang2(b_grctId, a_kq[1]);
    if (a_kq[2] == "") GridX_datTrang(b_grlkeId); else GridX_datBang2(b_grlkeId, a_kq[2]);
    return false;
}
function ns_ths_CHON() {
    var j = 0;
    var b_ktra = GridX_Fdt_cotGtri(b_grctId, ["chon", "ma"]);
    var b_gt = b_ktra[1];
    for (var i = 0; i < b_gt.length; i++) {
        if (b_gt[i][0] == "X") { j++; }
    }
    if (j == 0) {
        for (var i = 0; i < b_gt.length; i++) {
            if (b_gt[i][1] != "") {
                GridX_datGtri(b_grctId, i + 1, ["chon"], ["X"]);
            }
        }
    }
    else {
        for (var i = 0; i < b_gt.length; i++) {
            GridX_datGtri(b_grctId, i + 1, ["chon"], [""]);
        }
    }
}
function ns_ths_HOANTHANH() {
    var j = 0;
    var b_ktra = GridX_Fdt_cotGtri(b_grlkeId, ["hthanh", "ma"]);
    var b_gt = b_ktra[1];
    for (var i = 0; i < b_gt.length; i++) {
        if (b_gt[i][0] == "X") { j++; }
    }
    if (j == 0) {
        for (var i = 0; i < b_gt.length; i++) {
            if (b_gt[i][1] != "") {
                GridX_datGtri(b_grlkeId, i + 1, ["hthanh"], ["X"]);
            }
        }
    }
    else {
        for (var i = 0; i < b_gt.length; i++) {
            GridX_datGtri(b_grlkeId, i + 1, ["hthanh"], [""]);
        }
    }
}
function nhap_file() {
    var b_hang = GridX_Fi_timHangA(b_grctId);
    if (b_hang < 1) form_P_LOI('loi:Chọn hồ sơ cần lưu đường dẫn:loi');
    else {
        var b_tenf = b_tmf + '/ns/tt/file_ths.aspx';
        var b_so_the = $get(b_so_theId).value;
        form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "THS", b_so_the, "Lưu túi hồ sơ"]], null);
    }
    return false;
}
function sosanh_withDateTimeNow(str) {
    var mdy_str = str.split('/');
    var mdy_str = mdy_str[2] + mdy_str[1] + mdy_str[0];
    var mdy_str = parseInt(mdy_str);
    var dateht = new Date();
    var m = "0" + (1 + dateht.getMonth());
    var y = parseInt("2" + dateht.getYear()) - 100;
    var d = "0" + dateht.getDate();
    var dmy = y + m + d;
    var dmy = parseInt(dmy);
    var kq = mdy_str - dmy;
    return kq;
}
function ns_ths_P_NPA(b_nv) {
    if (b_nv == "0") {
        //$get(b_xoaId).style.display = "none";
        //$get(b_moiId).style.display = "none";
    }
    else {
        //$get(b_xoaId).style.display = "none";
        //$get(b_moiId).style.display = "";
    }
}
function ns_ths_FI_NH() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grctId);
        if (b_hang < 1 || C_NVL(GridX_Fas_layGtriA(b_grctId, "ma")) == "") {
            form_P_LOI('loi:Vui lòng chọn loại hồ sơ:loi')
            return false;
        }
        var b_tenf = '/App_form/ns/hs/file_hs.aspx';
        form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "NS_THS_IMP" + C_NVL(GridX_Fas_layGtriA(b_grctId, "ma")), "NS_THS_IMP" + C_NVL(GridX_Fas_layGtriA(b_grctId, "ma")), "Lưu file hồ sơ"]], null);
        form_P_LOI('');
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}

function CheckAll(oCheckbox) {
    var b_count = GridX_Fi_timHangT(b_grctId);
    if (oCheckbox.checked == true) {
        for (b_i = 1; b_i < b_count; b_i++) {
            var b_ten_bc = C_NVL(GridX_Fas_layGtri(b_grctId, b_i, "TEN"));
            if (b_ten_bc != "") GridX_datGtri(b_grctId, b_i, ["CHON"], ['X'], 'K');
        }
    } else {
        for (b_i = 1; b_i < b_count; b_i++) {
            GridX_datGtri(b_grctId, b_i, ["CHON"], [''], 'K');
        }
    }
}
function form_dong() {
    location.reload(false);
}
function ns_ths_CatDong() {
    GridX_boChon(b_grlkeId, 'C');
    return false;
}
function ns_ths_HangLen() {
    GridX_chuyenHang(b_grlkeId, -1);
    return false;
}
function ns_ths_HangXuong() {
    GridX_chuyenHang(b_grlkeId, 1);
    return false;
}
function ns_ths_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grlkeId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grlkeId);
    return false;
}
function ns_ths_P_FILE() {
    var b_sothe = $get(b_so_theId).value;
    if (b_sothe =="") {
        form_P_LOI('loi:Chọn cán bộ trước:loi')
        return false;
    }
    var b_tenf = '/App_form/ns/ma/file_Import_chung.aspx';
   
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, b_sothe, "NS_HDCT", "File đính kèm quản lý quyết định"]], null);
    form_P_LOI('');
    return false;
}