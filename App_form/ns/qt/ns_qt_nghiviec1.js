var ns_qt_nghiviec_lkeCho, b_vungId, b_grctId, b_slideId, b_so_theId, b_nsd, b_loai, b_ten,
    b_sothe_thaytheId, b_nguoiduyetId, b_ngaydId, b_ngaycId, b_gio_bdId, b_gio_ktId,b_lydo_chitietId,b_lydo_khacId, b_gchuId, b_ngaynghiId, b_danghiId,b_tinhtrangId, b_grctId, b_nghiconId, b_moiId,
    b_ml_khlId, b_ml_hlId, b_ml_rhlId, b_ql_khlId, b_ql_hlId, b_ql_rhlId, b_mt_khlId, b_mt_rhlId, b_mt_hlId, b_ch_khlId, b_ch_rhlId, b_ch_hlId;
function ns_qt_nghiviec_P_KD(nsd, ten) {
    b_nsd = nsd, b_ten = ten;
    ns_qt_nghiviec_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_so_theId = form_Fs_TEN_ID(b_vungId, 'SO_THE'), b_grctId = form_Fs_VUNG_ID('GR_ct');
    b_lydo_chitietId = form_Fs_TEN_ID(b_vungId, 'lydo_chitiet'), b_lydo_khacId = form_Fs_TEN_ID(b_vungId, 'lydo_khac'), b_ml_khlId = form_Fs_TEN_ID(b_vungId, 'ml_khl'),
    b_ml_hlId = form_Fs_TEN_ID(b_vungId, 'ml_hl'), b_ml_rhlId = form_Fs_TEN_ID(b_vungId, 'ml_rhl'), b_ql_khlId = form_Fs_TEN_ID(b_vungId, 'ql_khl'), b_ql_hlId = form_Fs_TEN_ID(b_vungId, 'ql_hl'),
    b_ql_rhlId = form_Fs_TEN_ID(b_vungId, 'ql_rhl'), b_mt_khlId = form_Fs_TEN_ID(b_vungId, 'mt_khl'), b_mt_hlId = form_Fs_TEN_ID(b_vungId, 'mt_hl'), b_mt_rhlId = form_Fs_TEN_ID(b_vungId, 'mt_rhl'),
    b_ch_khlId = form_Fs_TEN_ID(b_vungId, 'ch_khl'), b_ch_hlId = form_Fs_TEN_ID(b_vungId, 'ch_hl'), b_ch_rhlId = form_Fs_TEN_ID(b_vungId, 'ch_rhl'),b_tinhtrangId = form_Fs_TEN_ID(b_vungId, 'tinhtrang');
    b_moiId = form_Fs_VTEN_ID('', 'moi');
    b_slideId = b_grctId + '_slide';
    ns_qt_nghiviec_P_LKE_CHO();
    ns_thongtin_canbo();
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("SOTHE_THAYTHE") >= 0) {
            $get(b_sothe_thaytheId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_nguoiduyetId).focus();
        }
        else if (b_dtuong.indexOf("NGUOIDUYET") >= 0) {
            $get(b_nguoiduyetId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
        }
        else if (b_dtuong.indexOf("SO_THE") >= 0) {
            $get(b_so_theId).value = b_nsd;
            ns_qt_nghiviec_CB();
        }
        else if (b_dtuong.indexOf("KQ") >= 0) {
            $get(b_so_theId).value = a_tso[0];
            $get(b_ngayxnId).innerHTML = a_tso[1];
            $get(b_ngaydId).innerHTML = a_tso[2];
            ns_qt_nghiviec_P_MA_KTRA();
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_qt_nghiviec_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SOTHE_THAYTHE": b_maId = b_sothe_thaytheId; break;
            case "NGUOIDUYET": b_maId = b_nguoiduyetId; break;
            case "NGAYD": b_maId = b_ngaydId; break;
            case "NGAYC": b_maId = b_ngaycId; break;
            case "GIO_BD": b_maId = b_gio_bdId; break;
            case "GIO_KT": b_maId = b_gio_ktId; break;
            case "SO_THE": b_maId = b_so_theId; break;
            case "LYDO_KHAC": b_maId = b_lydo_khacId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        else if (b_maTen == "SOTHE_THAYTHE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_qt_nghiviec_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_qt_nghiviec_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_qt_nghiviec_P_MOI();
            ns_qt_nghiviec_P_LKE_CHO();
        }
        else if (b_maTen == "NGAYC" || b_maTen == "GIO_BD" || b_maTen == "GIO_KT") {
            var b_kq = 0;
            tinh_ngay();
            return false;
        }
        else if (b_maTen == "NGAYD") {
            var b_ngayxn = $get(b_ngayxnId).value,
                b_ngayd = $get(b_ngaydId).value;
            var b_hang = GridX_Fi_timHangD(b_grctId, ["ngayxn", "ngayd"], [b_ngayxn, b_ngayd]);
            if (b_hang < 1) {
                var b_kq = 0;
                GridX_thoiA(b_grctId);
                form_P_MOI(b_vungId, "X");
                tinh_ngay();
            }
            else { GridX_datA(b_grctId, b_hang); ns_qt_nghiviec_P_CHUYEN_HANG(); }
            return false;
        } else if (b_maTen == "LYDO_KHAC" && b_ma.value=="X") {
            $get(b_lydo_chitietId).removeAttribute('disabled');
        }else if (b_maTen == "LYDO_KHAC" && b_ma.value=="") {
            $get(b_lydo_chitietId).setAttribute('disabled',true);
        }
        else skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_qt_nghiviec_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);        
    }
    catch (err) { form_P_LOI(err); }
}

function ns_qt_nghiviec2_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) { 
            case "LYDO_KHAC": b_maId = b_lydo_khacId; break;
            case "ML_KHL": b_maId = b_ml_khlId; break;
            case "ML_HL": b_maId = b_ml_hlId; break;
            case "ML_RHL": b_maId = b_ml_rhlId; break;
            case "QL_KHL": b_maId = b_ql_khlId; break;
            case "QL_HL": b_maId = b_ql_hlId; break;
            case "QL_RHL": b_maId = b_ql_rhlId; break;
            case "MT_KHL": b_maId = b_mt_khlId; break;
            case "MT_HL": b_maId = b_mt_hlId; break;
            case "MT_RHL": b_maId = b_mt_rhlId; break;
            case "CH_KHL": b_maId = b_ch_khlId; break;
            case "CH_HL": b_maId = b_ch_hlId; break;
            case "CH_RHL": b_maId = b_ch_rhlId; break;
        }
        var b_ma = $get(b_maId);
        if (b_maTen == "LYDO_KHAC" && b_ma.value == "X") {
            $get(b_lydo_chitietId).removeAttribute('disabled');
        } else if (b_maTen == "LYDO_KHAC" && b_ma.value == "") {
            $get(b_lydo_chitietId).setAttribute('disabled', true);
            $get(b_lydo_chitietId).value = "";
        } else if (b_maTen == "ML_KHL") {
            $get(b_ml_hlId).value = "";
            $get(b_ml_rhlId).value = "";
        } else if (b_maTen == "ML_HL") {
            $get(b_ml_khlId).value = "";
            $get(b_ml_rhlId).value = "";
        } else if (b_maTen == "ML_RHL") {
            $get(b_ml_khlId).value = "";
            $get(b_ml_hlId).value = "";
        } else if (b_maTen == "QL_KHL") {
            $get(b_ql_hlId).value = "";
            $get(b_ql_rhlId).value = "";
        } else if (b_maTen == "QL_HL") {
            $get(b_ql_khlId).value = "";
            $get(b_ql_rhlId).value = "";
        } else if (b_maTen == "QL_RHL") {
            $get(b_ql_khlId).value = "";
            $get(b_ql_hlId).value = "";
        } else if (b_maTen == "MT_KHL") {
            $get(b_mt_hlId).value = "";
            $get(b_mt_rhlId).value = "";
        } else if (b_maTen == "MT_HL") {
            $get(b_mt_khlId).value = "";
            $get(b_mt_rhlId).value = "";
        } else if (b_maTen == "MT_RHL") {
            $get(b_mt_khlId).value = "";
            $get(b_mt_hlId).value = "";
        } else if (b_maTen == "CH_KHL") {
            $get(b_ch_hlId).value = "";
            $get(b_ch_rhlId).value = "";
        } else if (b_maTen == "CH_HL") {
            $get(b_ch_khlId).value = "";
            $get(b_ch_rhlId).value = "";
        } else if (b_maTen == "CH_RHL") {
            $get(b_ch_khlId).value = "";
            $get(b_ch_hlId).value = "";
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_thongtin_canbo() {
    try {
        var b_so_the = $get(b_so_theId).value;
        hts_dungchung.Fs_THONGTIN_CANBO(b_so_the, ns_thongtin_canbo_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_thongtin_canbo_kq(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
function tinh_ngay() {
    try {
        var b_ngayd = $get(b_ngaydId).value, b_ngayc = $get(b_ngaycId).value,
              b_gio_bd = $get(b_gio_bdId).value, b_gio_kt = $get(b_gio_ktId).value;
        var ngaythu7cn = 0;
        if (b_ngayd != "" && b_ngayc != "") {
            b_ngayd = b_ngayd.substring(3, 5) + "/" + b_ngayd.substring(0, 2) + "/" + b_ngayd.substring(6, 10);
            b_ngayc = b_ngayc.substring(3, 5) + "/" + b_ngayc.substring(0, 2) + "/" + b_ngayc.substring(6, 10);
            var ngay = mydiff(b_ngayd, b_ngayc, "days");
            if (b_gio_bd == "75H") ngay = ngay - 0.25;
            if (b_gio_bd == "2HD") ngay = ngay - 0.75;
            if (b_gio_bd == "NC") ngay = ngay - 0.5;
            if (b_gio_kt == "CN") ngay = ngay + 1;
            if (b_gio_kt == "ND") ngay = ngay + 0.5;
            if (b_gio_kt == "2HC") ngay = ngay + 0.25;
            if (b_gio_kt == "75D") ngay = ngay + 0.75;
            ngaythu7cn = tinh_thu7cn(b_ngayd, b_ngayc, ngay);
            ngay = ngay - ngaythu7cn;
            if (ngay < 0) ngay = 0;
            $get(b_ngaynghiId).value = ngay;
        }
        if (b_ngayd != "" && b_ngayc == "") {
            var ngay = 1;
            if (b_gio_bd == "NC") ngay = ngay - 0.5;
            if (b_gio_bd == "2HD") ngay = 0.25;
            if (b_gio_bd == "75H") ngay = 0.75;
            $get(b_ngaynghiId).value = ngay;
        }
    }
    catch (err) { form_P_LOI(err); }
}



function mydiff(date1, date2, interval) {
    var second = 1000, minute = second * 60, hour = minute * 60, day = hour * 24, week = day * 7;
    date1 = new Date(date1);
    date2 = new Date(date2);
    var timediff = date2 - date1;
    if (isNaN(timediff)) return NaN;
    switch (interval) {
        case "years": return date2.getFullYear() - date1.getFullYear();
        case "months": return (
            (date2.getFullYear() * 12 + date2.getMonth())
            -
            (date1.getFullYear() * 12 + date1.getMonth())
        );
        case "weeks": return Math.floor(timediff / week);
        case "days": return Math.floor(timediff / day);
        case "hours": return Math.floor(timediff / hour);
        case "minutes": return Math.floor(timediff / minute);
        case "seconds": return Math.floor(timediff / second);
        default: return undefined;
    }
}

function ktra_ngay() {
    var b_ngayd = $get(b_ngaydId).value,
        b_ngayc = $get(b_ngaycId).value;
    var b_thangd = b_ngayd.substring(3, 5),
        b_thangc = b_ngayc.substring(3, 5);
    if (b_thangd < '04' && b_thangc >= '04') { return "loi:Leave Application until Mar 31 only:loi" }
    else return "";
}

function tinh_thu7cn(b_ngayd, b_ngayc, b_days) {
    try {
        var b_ngayd_d = b_ngayd.substring(3, 5),
            b_thangd_d = b_ngayd.substring(0, 2),
            b_namd_d = b_ngayd.substring(6, 10);
        var b_ngay = 0;
        var b_ngaytinh = '';
        var ngaythu7cn = 0;
        var b_thu = "";
        var b_ktra = "";
        for (var i = 0; i < b_days; i++) {
            b_ngay = Math.floor(b_ngayd_d) + i;
            b_ngaytinh = b_thangd_d + '/' + b_ngay + '/' + b_namd_d;
            b_ktra = new Date(b_ngaytinh).toString();
            b_thu = b_ktra.substring(0, 3);
            if (b_thu == 'Sun' || b_thu == 'Sat') ngaythu7cn = ngaythu7cn + 1;
        }
        return ngaythu7cn;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_qt_nghiviec_P_MA_KTRA() {
    try {
        var b_so_the = C_NVL($get(b_so_theId).value);
        if (b_so_the != "") {
            var b_ngayxn = $get(b_ngayxnId).value;
            var b_ngayd = $get(b_ngaydId).value;
            var b_TrangKt = GridX_Fi_hangKt(b_grctId), a_cot = GridX_Fas_tenCot(b_grctId);
            sns_qt.Fs_NS_QT_NGHIVIEC_MA(b_so_the, b_ngayxn, b_ngayd, b_TrangKt, a_cot, ns_qt_nghiviec_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_qt_nghiviec_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grctId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) { form_P_MOI(b_vungId, "X"); tinh_ngay(); }
    else { GridX_datA(b_grctId, b_hang); ns_qt_nghiviec_P_CHUYEN_HANG(); }
}

function ns_qt_nghiviec_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}


var ns_qt_nghiviec_choAct = 0;
function ns_qt_nghiviec_GR_lke_RowChange() {
    if (ns_qt_nghiviec_choAct != 0) clearTimeout(ns_qt_nghiviec_choAct);
    ns_qt_nghiviec_choAct = setTimeout("ns_qt_nghiviec_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_qt_nghiviec_P_LKE_CHO() {
    $get(b_so_theId).value = b_nsd; ns_qt_nghiviec_CB();
}

function ns_qt_nghiviec_CB() {
    try {
        var b_so_the = $get(b_so_theId).value;
        var a_cot = GridX_Fas_tenCot(b_grctId);
        sns_qt.Fs_NS_QT_NGHIVIEC_MA(b_so_the, a_cot, ns_qt_nghiviec_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_qt_nghiviec_CB_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    if (a_kq[0] != "0") { form_P_CH_TEXT(b_vungId, a_kq[1]); }
    if (a_kq[2] != "") GridX_datBang(b_grctId, a_kq[2]); else GridX_datTrang(b_grctId);
    // ns_qt_nghiviec_P_LKE(); 
    return false;
}
function ns_qt_nghiviec_gui() {
    try {
        var b_so_the = $get(b_so_theId).value;
        a_cot = GridX_Fas_tenCot(b_grctId),
        sns_qt.Fs_NS_QT_NGHIVIEC_GUI(b_so_the, ns_qt_nghiviec_gui_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_qt_nghiviec_gui_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else form_P_LOI("loi:Gửi duyệt thành công:loi");
    $get(b_tinhtrangId).value = "1";
    return false;
}
function ns_qt_nghiviec_ngayphep() {
    try {
        var b_so_the = $get(b_so_theId).value,
            b_ngayd = $get(b_ngaydId).value;
        sns_qt.Fs_NS_QT_NGHIVIEC_NGAY_NAGASE(b_so_the, b_ngayd, ns_qt_nghiviec_ngayphep_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_qt_nghiviec_ngayphep_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    $get(b_danghiId).value = a_kq[0];
    $get(b_nghiconId).value = a_kq[1];
    return false;
}

function ns_qt_nghiviec_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    var time = new Date();
    $get(b_ngayxnId).value = $get(b_ngaydId).value = time.format("dd/MM/yyyy");
    GridX_thoiA(b_grctId);
    $get(b_sothe_thaytheId).focus();
    return false;
}

function ns_qt_nghiviec_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grctId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_so_the = $get(b_so_theId).value;
        sns_qt.Fs_NS_QT_NGHIVIEC_LKE(b_so_the, a_tso, a_cot, ns_qt_nghiviec_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_qt_nghiviec_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grctId, a_kq[1]);
    return false;
}

function ns_qt_nghiviec_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        var b_tt = $get(b_tinhtrangId).value;
        if (b_tt != "0") {
            form_P_LOI("loi:Đơn xin nghỉ đã được gửi hoặc phê duyệt:loi"); return false; 
        }
        var a_cot = GridX_Fas_tenCot(b_grctId);
        var b_so_the = $get(b_so_theId).value;
        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId),a_gt_ts = GridX_Fdt_cotGtri(b_grctId);
        sns_qt.Fs_NS_QT_NGHIVIEC_NH(b_so_the, a_cot, a_dt_ct, a_gt_ts,ns_qt_nghiviec_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { throw (err); }
}

function ns_qt_nghiviec_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI("loi:Cập nhật thành công:loi"); return false;
        //sendMail(a_kq[0]);
    }
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

function ns_qt_nghiviec_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grctId);
    if (b_hang < 1) return;
    var b_so_the = $get(b_so_theId).value,
        b_ngayxn = C_NVL(GridX_Fas_layGtri(b_grctId, b_hang, "ngayxn")),
    b_ngayd = C_NVL(GridX_Fas_layGtri(b_grctId, b_hang, "ngayd"));
    if (b_ngayxn == "") { form_P_MOI(b_vungId, "X"); }
    else sns_qt.Fs_NS_QT_NGHIVIEC_CT(b_so_the, b_ngayxn, b_ngayd, ns_qt_nghiviec_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_qt_nghiviec_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
function ns_qt_nghiviec_P_XOA() {     
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; } 
    var b_so_the = $get(b_so_theId).value, b_ngayxn = $get(b_ngayxnId).value, b_ngayd = $get(b_ngaydId).value;
    if (b_so_the == "") ns_qt_nghiviec_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grctId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_qt.Fs_NS_QT_NGHIVIEC_XOA(b_so_the, b_ngayxn, b_ngayd, a_tso, a_cot, ns_qt_nghiviec_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_qt_nghiviec_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grctId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grctId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grctId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grctId, b_hang)) ns_qt_nghiviec_P_MOI();
        else { GridX_datA(b_grctId, b_hang); ns_qt_nghiviec_P_CHUYEN_HANG(); }
    }
    return false;
}
function ns_qt_nghiviec_P_HUY() {
    var b_hang = GridX_Fi_timHangA(b_grctId);
    if (b_hang < 1) return;
    var b_so_the = $get(b_so_theId).value,
        b_ngayxn = C_NVL(GridX_Fas_layGtri(b_grctId, b_hang, "ngayxn")),
    b_ngayd = C_NVL(GridX_Fas_layGtri(b_grctId, b_hang, "ngayd"));
    if (b_ngayxn == "") { form_P_MOI(b_vungId, "X"); }
    else sns_qt.Fs_NS_QT_NGHIVIEC_HUY(b_so_the, b_ngayxn, b_ngayd, ns_qt_nghiviec_P_HUY_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_qt_nghiviec_P_HUY_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        ns_qt_nghiviec_P_LKE();
        form_P_LOI('loi:Hủy thành công:loi');
        return false;
    }
}
function ns_qt_nghiviec_P_CHON() {
    var b_hang = GridX_Fi_timHangA(b_grctId);
    if (b_hang < 1) return;
    var b_check = C_NVL(GridX_Fas_layGtri(b_grctId, b_hang, "tinhtrang"));
    if (b_check == "Chưa phê duyệt") { alert('Không thể chọn đề xuất chưa được phê duyệt'); return; }
    if (b_check == "Không phê duyệt") { alert('Không thể chọn đề xuất Không được phê duyệt'); return; }
    else form_P_TRA_CHON('MA,TEN');
    return false;
}
function form_dong() {
    location.reload(false);
}