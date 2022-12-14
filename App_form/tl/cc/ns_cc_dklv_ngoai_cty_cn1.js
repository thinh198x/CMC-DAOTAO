var ns_cc_dklv_ngoai_cty_cn_lkeCho, b_vungId, b_nsd, b_grlkeId, b_slideId, b_so_theId, b_nsd, b_ngay_dkId, ns_cc_dklv_ngoai_cty_cn_choAct = 0, c_thongtin_nghi_choAct,
    b_vungTkId, b_nam_tkId, b_kyluong_tkId, b_tt_tkId, b_gio_bdId, b_gchuId, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C', b_ctrbeforId,
    b_aNam_tkId, b_akyluong_tkId, b_att_tkId, b_aSotheId;
function ns_cc_dklv_ngoai_cty_cn_P_KD(nsd) {
    b_nsd = nsd;
    ns_cc_dklv_ngoai_cty_cn_lkeCho = setInterval('ns_cc_dklv_ngoai_cty_cn_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "" || a_tso[0] == "FILE_HTOAN") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            $get(b_so_theId).value = a_tso[0];
            $get(b_gchuId).innerHTML = a_tso[1];
            ns_cc_dklv_ngoai_cty_cn_P_KTRA("SO_THE");
        } else if (b_dtuong.indexOf("TAI_IMPORT") >= 0) {
            ns_cc_dklv_ngoai_cty_cn_P_LKE('K');
        }
    }
    catch (err) { form_P_LOI(err); }
}
// kiểm tra
function ns_cc_dklv_ngoai_cty_cn_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_so_theId; break;
            case "GIO_BD": b_maId = b_gio_bdId; break;
            case "GIO_KT": b_maId = b_gio_ktId; break;

        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        else if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_cc_dklv_ngoai_cty_cn_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_cc_dklv_ngoai_cty_cn_TTCB();
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_cc_dklv_ngoai_cty_cn_P_MOI(); ns_cc_dklv_ngoai_cty_cn_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_cc_dklv_ngoai_cty_cn_P_CHUYEN_HANG(); }

        } else if (b_maTen == "GIO_BD" || b_maTen == "GIO_KT") {
            if (b_maTen == "GIO_BD") {
                if (!isTime(b_ma)) {
                    form_P_LOI("loi:Thời gian từ không đúng định dạng!:loi");
                    return false;
                }
            } else if (b_maTen == "GIO_KT") {
                if (!isTime(b_ma)) {
                    form_P_LOI("loi:Thời gian đến không đúng định dạng!:loi");
                    return false;
                }
            }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_dklv_ngoai_cty_cn_P_MA_KTRA() {
    try {
        var b_so_the = C_NVL($get(b_so_theId).value);
        if (b_so_the != "") {
            var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_qt.Fs_NS_CC_DKLV_NGOAI_CTY_CN_MA(form_Fs_nsd(), b_so_the, b_so_id, b_TrangKt, a_cot, ns_cc_dklv_ngoai_cty_cn_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_cc_dklv_ngoai_cty_cn_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) { form_P_MOI(b_vungId, "X"); tinh_ngay(); }
    else { GridX_datA(b_grlkeId, b_hang); ns_cc_dklv_ngoai_cty_cn_P_CHUYEN_HANG(); }
}
function ns_cc_dklv_ngoai_cty_cn_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        b_loiNhap = 1;
    }
    else { form_P_DatGchu(b_gchuId, b_kq); b_loiNhap = 0; }
}
function ns_cc_dklv_ngoai_cty_cn_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_so_theId).focus();
    return false;
}
//nhập
function ns_cc_dklv_ngoai_cty_cn_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }

        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 0) {
            var b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tt"));
            if (b_trangthai == 'PD') { form_P_LOI('loi:Bản ghi đang ở trạng thái phê duyệt, không thể chỉnh sửa:loi'); return false; }
        }

        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        var b_nam_tk = lke_Fs_TRA($get(b_nam_tkId)), b_kyluong_tk = lke_Fs_TRA($get(b_kyluong_tkId)), b_tt_tk = form_Fs_TEN_GTRI(b_vungTkId, 'tt_tk'),
            b_so_the = b_nsd;
        sns_qt.Fs_NS_CC_DKLV_NGOAI_CTY_CN_NH(form_Fs_nsd(), b_nam_tk, b_kyluong_tk, b_tt_tk, b_so_the, b_so_id, b_TrangKt, a_dt_ct, a_cot_lke, ns_cc_dklv_ngoai_cty_cn_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { throw (err); }
}
function ns_cc_dklv_ngoai_cty_cn_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_so_theId).focus();
        form_P_LOI("loi:Nhập thành công!:loi");
    }
    return false;
}
// xóa
function ns_cc_dklv_ngoai_cty_cn_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_so_the = $get(b_so_theId).value, b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_hang < 1 || b_so_id == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); ns_cc_dklv_ngoai_cty_cn_P_MOI(); return false; }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_nam_tk = lke_Fs_TRA($get(b_nam_tkId)), b_kyluong_tk = lke_Fs_TRA($get(b_kyluong_tkId)), b_tt_tk = form_Fs_TEN_GTRI(b_vungTkId, 'tt_tk'),
            b_so_the = b_nsd;
        var b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tt"));
        if (b_trangthai == "CG")
            sns_qt.Fs_NS_CC_DKLV_NGOAI_CTY_CN_XOA(form_Fs_nsd(), b_nam_tk, b_kyluong_tk, b_tt_tk, b_so_id, b_so_the, a_tso, a_cot, ns_cc_dklv_ngoai_cty_cn_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        else
            form_P_LOI("loi:Đăng ký đã được gửi hoặc phê duyệt không thể xóa:loi");
    }
    return false;
}
function ns_cc_dklv_ngoai_cty_cn_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_cc_dklv_ngoai_cty_cn_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_cc_dklv_ngoai_cty_cn_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
    return false;
}
// chuyển hàng
function ns_cc_dklv_ngoai_cty_cn_GR_lke_RowChange() {
    if (ns_cc_dklv_ngoai_cty_cn_choAct != 0) clearTimeout(ns_cc_dklv_ngoai_cty_cn_choAct);
    ns_cc_dklv_ngoai_cty_cn_choAct = setTimeout("ns_cc_dklv_ngoai_cty_cn_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_cc_dklv_ngoai_cty_cn_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_the = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the"),
        b_ngay_dk = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ngay_dk"));
    if (b_ngay_dk == "") { form_P_MOI(b_vungId, "X"); }
    else {
        sns_qt.Fs_NS_CC_DKLV_NGOAI_CTY_CN_CT(form_Fs_nsd(), b_so_the, b_ngay_dk, ns_cc_dklv_ngoai_cty_cn_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        form_P_GridX_TEXT(b_vungId, b_grlkeId);
    }
    return false;
}
function ns_cc_dklv_ngoai_cty_cn_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
// liệt kê
function ns_cc_dklv_ngoai_cty_cn_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        b_tt_phep = 0;
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungTkId = form_Fs_VUNG_ID('UPa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
        b_so_theId = form_Fs_TEN_ID(b_vungId, 'SO_THE');
        b_ngay_dkId = form_Fs_TEN_ID(b_vungId, 'ngay_dk'), b_gio_bdId = form_Fs_TEN_ID(b_vungId, 'gio_bd'), b_gio_ktId = form_Fs_TEN_ID(b_vungId, 'gio_kt');
        b_nam_tkId = form_Fs_TEN_ID(b_vungTkId, 'nam_tk'), b_kyluong_tkId = form_Fs_TEN_ID(b_vungTkId, 'kyluong_tk'), b_tt_tkId = form_Fs_TEN_ID(b_vungTkId, 'tt_tk');

        b_gchuId = form_Fs_VTEN_ID('', 'gchu'), b_aNam_tkId = form_Fs_TEN_ID('UPa_hi', 'aNam_tk'), b_akyluong_tkId = form_Fs_TEN_ID('UPa_hi', 'akyluong_tk');
        b_att_tkId = form_Fs_VTEN_ID('UPa_hi', 'att_tk'), b_aSotheId = form_Fs_VTEN_ID('UPa_hi', 'aSothe');;

        b_slideId = b_grlkeId + '_slide';
        if (ns_cc_dklv_ngoai_cty_cn_lkeCho != 0) clearTimeout(ns_cc_dklv_ngoai_cty_cn_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');

        ns_cc_dklv_ngoai_cty_cn_P_LKE('K');
        ns_cc_dklv_ngoai_cty_cn_TTCB();
    }
}
function ns_cc_dklv_ngoai_cty_cn_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);

        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_nam_tk = form_Fs_TEN_GTRI(b_vungTkId, 'NAM_TK'), b_kyluong_tk = lke_Fs_TRA($get(b_kyluong_tkId)), b_tt_tk = form_Fs_TEN_GTRI(b_vungTkId, 'tt_tk'), b_sothe = b_nsd;
        sns_qt.Fs_NS_CC_DKLV_NGOAI_CTY_CN_LKE(form_Fs_nsd(), b_nam_tk, b_kyluong_tk, b_tt_tk, b_sothe, a_tso, a_cot, ns_cc_dklv_ngoai_cty_cn_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_dklv_ngoai_cty_cn_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
        return false;
    }
    b_fcho = 'X';
}
// thông tin năm/kỳ lương
function ns_cc_dklv_ngoai_cty_cn_P_NAM() {
    try {
        var b_nam = form_Fs_TEN_GTRI(b_vungTkId, 'NAM_TK');
        if (b_nam != "")
            stl_cc.Fs_NS_KYLUONG_CHUNG2_LKE(form_Fs_nsd(), window.name, b_nam, ns_cc_dklv_ngoai_cty_cn_P_NAM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_cc_dklv_ngoai_cty_cn_P_NAM_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
}

// lấy thông tin cán bộ
function ns_cc_dklv_ngoai_cty_cn_TTCB() {
    try {
        var b_so_the = b_nsd;
        hts_dungchung.Fs_THONGTIN_CANBO(b_so_the, ns_cc_dklv_ngoai_cty_cn_TTCB_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_dklv_ngoai_cty_cn_TTCB_kq(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == "") { form_P_LOI("loi:Nhân viên chưa được làm quyết định:loi"); return }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}

function ns_cc_dklv_ngoai_cty_cn_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_aNam_tkId).value = form_Fs_TEN_GTRI(b_vungTkId, 'NAM_TK');
    $get(b_akyluong_tkId).value = lke_Fs_TRA($get(b_kyluong_tkId));
    $get(b_att_tkId).value = form_Fs_TEN_GTRI(b_vungTkId, 'TT_TK');
    $get(b_aSotheId).value = b_nsd;
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function ns_cc_dklv_ngoai_cty_cn_P_MAU() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'btn_excel_mau');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;

}
function ns_cc_dklv_ngoai_cty_cn_FILE_Import() {
    var b_tenf = '/App_form/ns/ma/file_Import.aspx';
    form_P_MO(b_tenf, window.name + ',THAMSO', ['THAMSO', [window.name, 'THONGTIN_NGHI_IMP', null, "Import thông tin nghỉ"]], null);
    form_P_LOI('');
    return false;
}


function ns_cc_dklv_ngoai_cty_cn_P_GUI() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) { form_P_LOI("loi:Chưa chọn đăng ký cần gửi:loi"); return false; }
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "") { form_P_LOI("loi:Chưa chọn đăng ký cần gửi:loi"); return false; }
        a_cot = GridX_Fas_tenCot(b_grlkeId);
        var b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tt"));
        if (b_trangthai == "CG" || b_trangthai == "KPD")
            sns_qt.Fs_NS_CC_DKLV_NGOAI_CTY_CN_GUI(form_Fs_nsd(), b_so_id, ns_cc_dklv_ngoai_cty_cn_P_GUI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        else
            form_P_LOI("loi:Đăng ký đã được gửi hoặc đã được phê duyệt:loi");
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_dklv_ngoai_cty_cn_P_GUI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else form_P_LOI("loi:Gửi phê duyệt thành công:loi");
    ns_cc_dklv_ngoai_cty_cn_P_LKE('K');
    return false;
}

function isTime(txtHour) {
    var data = C_NVL(txtHour.value);
    if (data == "") return true;

    if (data.indexOf(":") < 0) {
        data = formatTime(data);
        if (data != '')
            txtHour.value = data;
        else {
            txtHour.value = "";
            return false;
        }
    }

    var rxHourPattern = /^(\d{1,2})(:)(\d{1,2})$/;
    var dtArray = data.match(rxHourPattern); // is format OK?
    if (dtArray == null) {
        rxHourPattern = /^(\d{1,2})$/;
        dtArray = data.match(rxHourPattern);
    }
    if (dtArray == null) {
        txtHour.value = "";
        return false;
    }
    //Checks for hh:mm format.
    const hour = parseInt(dtArray[1], 10);
    var minute = 0;
    if (dtArray.length >= 4)
        minute = parseInt(dtArray[3], 10);
    if (hour < 0 || hour >= 24 || minute < 0 || minute >= 60) {
        txtHour.value = "";
        return false;
    }
    txtHour.value = pad(hour) + ":" + pad(minute);
    return true;
}
function formatTime(data) {
    if (data.indexOf(":") >= 0) return data;

    var b_length = data.length;
    if (b_length < 4) {
        if (b_length == 0)
            data = "00:00";
        else if (b_length == 1)
            data = "0" + data + ":00";
        else if (b_length == 2)
            data = data + ":00";
        else if (b_length == 3)
            data = data.substr(0, 2) + ":0" + data.substr(2);
    }
    else data = data.substr(0, 2) + ':' + data.substr(2);
    return data;
}
function pad(s) { return (s < 10) ? '0' + s : s; }

function form_dong() {
    location.reload(false);
}