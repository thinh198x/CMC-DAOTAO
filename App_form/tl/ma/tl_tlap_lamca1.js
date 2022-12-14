var b_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_maconglvId, b_gio_bd_Id, b_gio_kt_Id, b_giora_giuaca_Id, b_giovao_giuaca_Id, b_nsd, tl_tlap_lamca_choAct = 0;
function tl_tlap_lamca_P_KD() {

    b_lkeCho = setInterval('tl_tlap_lamca_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        var b_hso = a_tso[1];
        b_doi = 0;
        if (b_dtuong.indexOf("MA_CONG") > 0) {
            $get(b_maconglvId).value = b_kq;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function tl_tlap_lamca_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
            case "MA_CONG": b_maId = b_maconglvId; break;
            case "GIO_BD": b_maId = b_gio_bd_Id; break;
            case "GIO_KT": b_maId = b_gio_kt_Id; break;
            case "GIORA_GIUACA": b_maId = b_giora_giuaca_Id; break;
            case "GIOVAO_GIUACA": b_maId = b_giovao_giuaca_Id; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return true;
        if (b_maTen == "MA") {
            var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); tl_tlap_lamca_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); tl_tlap_lamca_P_CHUYEN_HANG(); }
            //b_ten.focus();
            return false;
        }
        else if (b_maTen == "MA_CONG") {
            $get(b_maconglvId).value = b_ma.value;
            return false;
        }
        else if (b_maTen == "GIO_BD") {
            if (!isTime(b_ma)) {
                form_P_LOI("loi:Thời gian bắt đầu ca không đúng định dạng!:loi");
                return false;
            }
            else
                return true;
        }
        else if (b_maTen == "GIO_KT") {
            if (!isTime(b_ma)) {
                form_P_LOI("loi:Thời gian kết thúc ca không đúng định dạng!:loi");
                return false;
            }
            else
                return true;
        }
        else if (b_maTen == "GIORA_GIUACA") {
            if (!isTime(b_ma)) {
                form_P_LOI("loi:Nghỉ giữa ca từ giờ không đúng định dạng!:loi");
                return false;
            }
            else
                return true;
        }
        else if (b_maTen == "GIOVAO_GIUACA") {
            if (!isTime(b_ma)) {
                form_P_LOI("loi:Nghỉ giữa ca đến giờ không đúng định dạng!:loi");
                return false;
            }
            else
                return true;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function tl_tlap_lamca_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            stl_ma.Fs_TL_TLAP_LAMCA_MA(b_nsd, b_ma, b_TrangKt, a_cot, tl_tlap_lamca_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function tl_tlap_lamca_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); tl_tlap_lamca_P_CHUYEN_HANG(); }
}
function tl_tlap_lamca_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_gocId).focus();
    var b_tt = "nghi_7_cn,TRANGTHAI;1|A";
    form_P_CH_TEXT(b_vungId, b_tt);
    return false;
}
function tl_tlap_lamca_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    if (!checkTime()) return false;
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    stl_ma.Fs_TL_TLAP_LAMCA_NH(b_nsd, b_TrangKt, a_dt_ct, a_cot, tl_tlap_lamca_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function tl_tlap_lamca_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI("loi:Ghi thành công!:loi");
    }
    return false;
}
function tl_tlap_lamca_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    if (b_ma == "") {
        form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi");
        tl_tlap_lamca_P_MOI();
    }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_ma.Fs_TL_TLAP_LAMCA_XOA(b_nsd, b_ma, a_tso, a_cot, tl_tlap_lamca_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function tl_tlap_lamca_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
        var b_dong = GridX_Fi_hangSo(b_grlkeId);
        if (b_hang > b_dong) b_hang = b_dong;
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) tl_tlap_lamca_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); tl_tlap_lamca_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
}
function tl_tlap_lamca_GR_lke_RowChange() {
    if (tl_tlap_lamca_choAct != 0) clearTimeout(tl_tlap_lamca_choAct);
    tl_tlap_lamca_choAct = setTimeout("tl_tlap_lamca_P_CHUYEN_HANG()", 300);
    return false;
}
function tl_tlap_lamca_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        if (b_ma == "") {
            form_P_MOI(b_vungId, "XGL");
            var b_tt = "nghi_7_cn,TRANGTHAI;1|A";
            form_P_CH_TEXT(b_vungId, b_tt);
        } else {
            stl_ma.Fs_TL_TLAP_LAMCA_CT(b_nsd, b_ma, tl_tlap_lamca_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function tl_tlap_lamca_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
function tl_tlap_lamca_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        b_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
        b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'), b_maconglvId = form_Fs_TEN_ID(b_vungId, 'MA_CONG');
        b_gio_bd_Id = form_Fs_TEN_ID(b_vungId, 'GIO_BD');
        b_gio_kt_Id = form_Fs_TEN_ID(b_vungId, 'GIO_KT');
        b_giora_giuaca_Id = form_Fs_TEN_ID(b_vungId, 'giora_giuaca');
        b_giovao_giuaca_Id = form_Fs_TEN_ID(b_vungId, 'giovao_giuaca');
        b_slideId = $get(b_grlkeId).getAttribute('slideId'); slide_P_MOI(b_slideId);
        b_nsd = form_Fs_nsd();
        clearTimeout(b_lkeCho); tl_tlap_lamca_P_LKE();
    }
}
function tl_tlap_lamca_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_ma.Fs_TL_TLAP_LAMCA_LKE(b_nsd, a_tso, a_cot, tl_tlap_lamca_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function tl_tlap_lamca_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function form_dong() {
    location.reload(false);
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
function checkTime() {
    if (!tl_tlap_lamca_P_KTRA("GIO_BD") || !tl_tlap_lamca_P_KTRA('GIO_KT') || !tl_tlap_lamca_P_KTRA('giora_giuaca') || !tl_tlap_lamca_P_KTRA('giovao_giuaca')) {
        return false;
    }

    var b_gio_d = CSO_SO($get(b_gio_bd_Id).value.replace(":", ""));
    var b_gio_c = CSO_SO($get(b_gio_kt_Id).value.replace(":", ""));
    var b_gio_n_d = CSO_SO($get(b_giora_giuaca_Id).value.replace(":", ""));
    var b_gio_n_c = CSO_SO($get(b_giovao_giuaca_Id).value.replace(":", ""));

    //if (b_gio_c <= b_gio_d) {
    //    form_P_LOI("loi:Thời gian kết thúc ca không được nhỏ hơn hoặc bằng Thời gian bắt đầu ca:loi");
    //    return false;
    //}
    //if (C_NVL($get(b_giovao_giuaca_Id).value) != "" && b_gio_n_c <= b_gio_n_d) {
    //    form_P_LOI("loi:Nghỉ giữa ca đến giờ không được nhỏ hơn hoặc bằng Nghỉ giữa ca từ giờ:loi");
    //    return false;
    //}
    //if (C_NVL($get(b_giora_giuaca_Id).value) != "" && (b_gio_n_d <= b_gio_d || b_gio_n_d >= b_gio_c)) {
    //    form_P_LOI("loi:Nghỉ giữa ca từ giờ phải nằm trong khoảng thời gian làm việc của ca:loi");
    //    return false;
    //}
    //if (C_NVL($get(b_giovao_giuaca_Id).value) != "" && (b_gio_n_c <= b_gio_d || b_gio_n_c >= b_gio_c)) {
    //    form_P_LOI("loi:Nghỉ giữa ca đến giờ phải nằm trong khoảng thời gian làm việc của ca:loi");
    //    return false;
    //}
    return true;
}
function pad(s) { return (s < 10) ? '0' + s : s; }