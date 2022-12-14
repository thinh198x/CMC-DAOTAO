var ns_qt_xin_nghiphep_ct_lkeCho, b_vungId, b_grlkeId, b_slideId, b_so_theId,b_nsd,b_loai,
    b_sothe_thaytheId,b_nguoiduyetId,b_ngaydId,b_ngaycId,b_gio_bdId,b_gio_ktId,b_gchuId,b_ngaynghiId ,b_danghiId,b_nghiconId, b_moiId;
function ns_qt_xin_nghiphep_ct_P_KD(nsd) {
    b_nsd = nsd,
    ns_qt_xin_nghiphep_ct_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_so_theId = form_Fs_TEN_ID(b_vungId, 'SO_THE');
    b_sothe_thaytheId = form_Fs_TEN_ID(b_vungId, 'sothe_thaythe');
    b_nguoiduyetId = form_Fs_TEN_ID(b_vungId, 'nguoiduyet');
    b_ngaydId = form_Fs_TEN_ID(b_vungId, 'ngayd');
    b_ngaycId = form_Fs_TEN_ID(b_vungId, 'ngayc');
    b_ngayxnId = form_Fs_TEN_ID(b_vungId, 'ngayxn');
    b_gio_bdId = form_Fs_TEN_ID(b_vungId, 'gio_bd');
    b_gio_ktId = form_Fs_TEN_ID(b_vungId, 'gio_kt');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_ngaynghiId = form_Fs_TEN_ID(b_vungId, 'ngaynghi');
    b_danghiId = form_Fs_TEN_ID(b_vungId, 'danghi');
    b_nghiconId = form_Fs_TEN_ID(b_vungId, 'nghicon');
    b_ykienId = form_Fs_TEN_ID(b_vungId, 'ykien');
    b_moiId = form_Fs_VTEN_ID('', 'moi');
    b_slideId = b_grlkeId + '_slide';
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
            $get(b_so_theId).value = a_tso[0];
            $get(b_gchuId).innerHTML = a_tso[1];
            ns_qt_xin_nghiphep_ct_CB();
        }
        else if (b_dtuong.indexOf("KQ") >= 0) {
            $get(b_so_theId).value = a_tso[0];
            $get(b_ngayxnId).value = a_tso[1];
            $get(b_ngaydId).value = a_tso[2];
            ns_qt_xin_nghiphep_ct_P_MA_KTRA();
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_qt_xin_nghiphep_ct_P_KTRA(b_maTen) {
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
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        else if (b_maTen == "SOTHE_THAYTHE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_qt_xin_nghiphep_ct_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_qt_xin_nghiphep_ct_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_qt_xin_nghiphep_ct_P_MOI();
            ns_qt_xin_nghiphep_ct_P_LKE_CHO();
        }
        else if (b_maTen == "NGAYC" || b_maTen == "GIO_BD" || b_maTen == "GIO_KT") {
            var b_kq = 0;
            tinh_ngay();
            return false;
        }
        else if (b_maTen == "NGAYD") {
            var b_ngayxn = $get(b_ngayxnId).value,
                b_ngayd = $get(b_ngaydId).value;
            var b_hang = GridX_Fi_timHangD(b_grlkeId, ["ngayxn","ngayd"], [b_ngayxn, b_ngayd]);
            if (b_hang < 1) {
                var b_kq = 0;
                GridX_thoiA(b_grlkeId);
                form_P_MOI(b_vungId, "X");
                tinh_ngay();
            }
            else { GridX_datA(b_grlkeId, b_hang); ns_qt_xin_nghiphep_ct_P_CHUYEN_HANG(); }
            return false;
        }
        else skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_qt_xin_nghiphep_ct_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function tinh_ngay()
{
    try {
        var b_ngayd = $get(b_ngaydId).value, b_ngayc = $get(b_ngaycId).value,
              b_gio_bd = $get(b_gio_bdId).value, b_gio_kt = $get(b_gio_ktId).value;
        if (b_ngayd != "" && b_ngayc != "") {
            b_ngayd = b_ngayd.substring(3, 5) + "/" + b_ngayd.substring(0, 2) + "/" + b_ngayd.substring(6, 10);
            b_ngayc = b_ngayc.substring(3, 5) + "/" + b_ngayc.substring(0, 2) + "/" + b_ngayc.substring(6, 10);
            var ngay = mydiff(b_ngayd, b_ngayc, "days");
            if (b_gio_bd == "NC") ngay = ngay - 0.5;
            if (b_gio_kt == "CN") ngay = ngay + 1;
            if (b_gio_kt == "ND") ngay = ngay + 0.5;
            $get(b_ngaynghiId).value = ngay;
        }
        if (b_ngayd != "" && b_ngayc == "") {
            var ngay = 1;
            if (b_gio_bd == "NC") ngay = ngay - 0.5;
            $get(b_ngaynghiId).value = ngay;
        }
    }
    catch (err) {form_P_LOI(err); }
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
function ns_qt_xin_nghiphep_ct_P_MA_KTRA() {
    try {
        var b_so_the = C_NVL($get(b_so_theId).value);
        if (b_so_the != "") {
            var b_ngayxn = $get(b_ngayxnId).value;
            var b_ngayd = $get(b_ngaydId).value;
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_qt.Fs_NS_QT_XIN_NGHIPHEP_MA(b_so_the, b_ngayxn, b_ngayd, b_TrangKt, a_cot, ns_qt_xin_nghiphep_ct_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_qt_xin_nghiphep_ct_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) { form_P_MOI(b_vungId, "X"); tinh_ngay(); }
    else { GridX_datA(b_grlkeId, b_hang); ns_qt_xin_nghiphep_ct_P_CHUYEN_HANG(); }
}

function ns_qt_xin_nghiphep_ct_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}

var ns_qt_xin_nghiphep_ct_choAct = 0;
function ns_qt_xin_nghiphep_ct_GR_lke_RowChange() {
    if (ns_qt_xin_nghiphep_ct_choAct != 0) clearTimeout(ns_qt_xin_nghiphep_ct_choAct);
    ns_qt_xin_nghiphep_ct_choAct = setTimeout("ns_qt_xin_nghiphep_ct_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_qt_xin_nghiphep_ct_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_qt_xin_nghiphep_ct_lkeCho); ns_qt_xin_nghiphep_ct_CB(); }
}

function ns_qt_xin_nghiphep_ct_CB() {
    try {
        var b_so_the = $get(b_so_theId).value;
        sns_qt.Fs_NS_QT_XIN_NGHIPHEP_CB(b_so_the,ns_qt_xin_nghiphep_ct_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_qt_xin_nghiphep_ct_CB_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    ns_qt_xin_nghiphep_ct_ngayphep();
    ns_qt_xin_nghiphep_ct_P_LKE();
    ns_qt_xin_nghiphep_ct_P_MA_KTRA();
    return false;
}

function ns_qt_xin_nghiphep_ct_ngayphep() {
    try {
        var b_so_the = $get(b_so_theId).value,
            b_ngayd = $get(b_ngaydId).value;
        sns_qt.Fs_NS_QT_XIN_NGHIPHEP_NGAY(b_so_the, b_ngayd, ns_qt_xin_nghiphep_ct_ngayphep_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_qt_xin_nghiphep_ct_ngayphep_KQ(b_kq)
{
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}

function ns_qt_xin_nghiphep_ct_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    var time = new Date();
    $get(b_ngayxnId).value = $get(b_ngaydId).value = time.format("dd/MM/yyyy");
    GridX_thoiA(b_grlkeId);
    $get(b_sothe_thaytheId).focus();
    return false;
}

function ns_qt_xin_nghiphep_ct_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_so_the = $get(b_so_theId).value;
        sns_qt.Fs_NS_QT_XIN_NGHIPHEP_LKE(b_so_the, a_tso, a_cot, ns_qt_xin_nghiphep_ct_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_qt_xin_nghiphep_ct_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    return false;
}

function ns_qt_xin_nghiphep_ct_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            sns_qt.Fs_NS_QT_XIN_NGHIPHEP_NH(b_TrangKt, a_dt_ct, a_cot_lke, ns_qt_xin_nghiphep_ct_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}

function ns_qt_xin_nghiphep_ct_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[1]) + 1, b_trang = CSO_SO(a_kq[2]), b_soDong = CSO_SO(a_kq[3]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[4]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_so_theId).focus(); $get(b_ykienId).value = '';
        sendMail(a_kq[0]);
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

function ns_qt_xin_nghiphep_ct_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_the = $get(b_so_theId).value,
        b_ngayxn = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ngayxn")),
    b_ngayd = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ngayd"));
    if (b_ngayxn == "") {form_P_MOI(b_vungId, "X");}
    else sns_qt.Fs_NS_QT_XIN_NGHIPHEP_CT(b_so_the, b_ngayxn,b_ngayd, ns_qt_xin_nghiphep_ct_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_qt_xin_nghiphep_ct_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
function ns_qt_xin_nghiphep_ct_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_the = $get(b_so_theId).value, b_ngayxn = $get(b_ngayxnId).value;
    if (b_so_the == "") ns_qt_xin_nghiphep_ct_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_qt.Fs_NS_QT_XIN_NGHIPHEP_XOA(b_so_the, b_ngayxn, a_tso, a_cot, ns_qt_xin_nghiphep_ct_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_qt_xin_nghiphep_ct_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_qt_xin_nghiphep_ct_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_qt_xin_nghiphep_ct_P_CHUYEN_HANG(); }
    }
    return false;
}
function ns_qt_xin_nghiphep_ct_P_CHON() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_check = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tinhtrang"));
    if (b_check == "Chưa phê duyệt") { alert('Không thể chọn đề xuất chưa được phê duyệt'); return; }
    if (b_check == "Không phê duyệt") { alert('Không thể chọn đề xuất Không được phê duyệt'); return; }
    else form_P_TRA_CHON('MA,TEN');
    return false;
}