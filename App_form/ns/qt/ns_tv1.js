var ns_tv_lkeCho, b_vungId, b_vung_tk_Id, b_vung_ngk_Id1, b_vung_ngk_Id2, b_grlkeId, b_slideId, b_so_theId, b_nsd, b_loai, b_ten,
    b_sothe_thaytheId, b_nguoiduyetId, b_ngaydId, b_ngaycId, b_gio_bdId, b_gio_ktId, b_lydo_chitietId, b_lydo_khacId, b_gchuId, b_ngaynghiId,
    b_danghiId, b_trangthaiId, b_grctId, b_nghiconId, b_moiId, b_so_idId, b_gocId,b_namId,b_kyluongId,
    b_ml_khlId, b_ml_hlId, b_ml_rhlId, b_grtlId, b_grtbId, b_grtsId, b_gr_hs_Id, b_ql_khlId, b_nguoi_kyId, b_ten_nguoi_kyId, b_loainhId,
    b_ql_hlId, b_ql_rhlId, b_ngay_kyId, b_mt_khlId, b_mt_rhlId, b_mt_hlId, b_ch_khlId, b_ch_rhlId, b_ch_hlId, b_ql_lydo_khacId,
    b_ngayd_tkId, b_ngayc_tkId, b_phong_tkId, b_sothe_tkId, b_hoten_tkId, b_nsd, ns_tv_choAct = 0, b_ctyValue, b_ctrbeforId;
function ns_tv_P_KD() {
    ns_tv_lkeCho;
    b_vungId = form_Fs_VUNG_ID('UPa_ct');
    b_vung_tk_Id = form_Fs_VUNG_ID('UPa_tk');
    b_grctId = form_Fs_VUNG_ID('GR_ct');
    b_vung_ngk_Id1 = form_Fs_VUNG_ID('Pa_tt');
    b_vung_ngk_Id2 = form_Fs_VUNG_ID('UPa_ngk2');
    b_grlkeId = form_Fs_VUNG_ID('GR_lke');
    b_nguoi_kyId = form_Fs_TEN_ID(b_vung_ngk_Id1, 'NGUOI_KY');
    b_namId = form_Fs_TEN_ID(b_vung_ngk_Id1, 'NAM');
    b_kyluongId = form_Fs_TEN_ID(b_vung_ngk_Id1, 'ky_luong');
    b_ten_nguoi_kyId = form_Fs_TEN_ID(b_vung_ngk_Id2, 'ten_nguoi_ky');
    b_ngay_kyId = form_Fs_TEN_ID(b_vung_ngk_Id2, 'NGAY_KY');
    b_lydo_chitietId = form_Fs_TEN_ID(b_vung_ngk_Id2, 'lydo_nv');
    b_grtlId = form_Fs_VUNG_ID('GR_tl');
    b_grtbId = form_Fs_VUNG_ID('GR_tb');
    b_grtsId = form_Fs_VUNG_ID('GR_ts');
    b_gr_hs_Id = form_Fs_VUNG_ID('GR_hs');
    b_gr1_Id = form_Fs_VUNG_ID('GridX1');
    b_gr2_Id = form_Fs_VUNG_ID('GridX2');
    b_gr3_Id = form_Fs_VUNG_ID('GridX3');
    b_gr4_Id = form_Fs_VUNG_ID('GridX4');
    b_gr5_Id = form_Fs_VUNG_ID('GridX5');
    b_gr6_Id = form_Fs_VUNG_ID('GridX6');
    b_gr7_Id = form_Fs_VUNG_ID('GridX7');
    b_moiId = form_Fs_VTEN_ID('', 'moi');
    b_slideId = $get(b_grlkeId).getAttribute('slideId');
    b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE');
    b_ngayd_tkId = form_Fs_TEN_ID(b_vung_tk_Id, 'ngayd_tk');
    b_ngayc_tkId = form_Fs_TEN_ID(b_vung_tk_Id, 'ngayc_tk');
    b_phong_tkId = form_Fs_TEN_ID(b_vung_tk_Id, 'phong_tk');
    b_sothe_tkId = form_Fs_TEN_ID(b_vung_tk_Id, 'so_the_tk');
    b_hoten_tkId = form_Fs_TEN_ID(b_vung_tk_Id, 'hoten_tk');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_so_theId = form_Fs_VTEN_ID('UPa_hi', 'so_the');
    b_so_id_inId = form_Fs_VTEN_ID('UPa_hi', 'so_id_in');
    b_nsd = form_Fs_nsd();
    //lke_P_DAT($get(b_phong_tkId), 'TATCA' + '{' + 'Tất cả');
    ns_tv_lkeCho = setInterval('ns_tv_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "")
            return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("SOTHE_THAYTHE") >= 0) {
            $get(b_sothe_thaytheId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_nguoiduyetId).focus();
        }
        else
            if (b_dtuong.indexOf("NGUOIDUYET") >= 0) {
                $get(b_nguoiduyetId).value = b_kq;
                $get(b_gchuId).innerHTML = a_tso[1];
            }
            else
                if (b_dtuong.indexOf("SO_THE") >= 0) {
                    $get(b_so_theId).value = a_tso[0];
                    var b_hang = GridX_Fi_timHangD(b_grlkeId, "so_the", b_kq);
                    if (b_hang < 1) {
                        GridX_thoiA(b_grlkeId);
                        form_P_MOI(b_vungId, "XL");
                    }
                    else {
                        GridX_datA(b_grlkeId, b_hang);
                        ns_tv_P_CHUYEN_HANG();
                    }
                    ns_thongtin_canbo(a_tso[0]);
                } else
                    if (b_dtuong.indexOf("NGUOI_KY") >= 0) {
                        $get(b_nguoi_kyId).value = b_kq;
                        $get(b_ten_nguoi_kyId).value = a_tso[1];
                        ns_thongtin_canbo_ngky();
                    }
                    else
                        if (b_dtuong.indexOf("KQ") >= 0) {
                            $get(b_so_theId).value = a_tso[0];
                            $get(b_ngayxnId).innerHTML = a_tso[1];
                            $get(b_ngaydId).innerHTML = a_tso[2];
                            ns_tv_P_MA_KTRA();
                            return false;
                        } else
                            if (b_dtuong.indexOf("THAMSO_CB") >= 0) {
                                $get(b_so_theId).value = a_tso[0];
                                ns_thongtin_canbo();
                            }
                            else
                                if (b_dtuong.indexOf("DAYPHONG") >= 0) {
                                    var b_phong_tk = form_Fctr_TEN_DTUONG(b_vung_tk_Id, 'dr_phongban');
                                    lke_P_DAT(b_phong_tk, a_tso[0] + "{" + a_tso[1]);
                                }
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_tv_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SOTHE_THAYTHE": b_maId = b_sothe_thaytheId;
                break;
            case "NGUOIDUYET": b_maId = b_nguoiduyetId;
                break;
            case "NGAYD": b_maId = b_ngaydId;
                break;
            case "NGAYC": b_maId = b_ngaycId; break;
            case "GIO_BD": b_maId = b_gio_bdId;
                break;
            case "GIO_KT": b_maId = b_gio_ktId;
                break;
            case "SO_THE": b_maId = b_gocId;
                break;
            case "LYDO_KHAC": b_maId = b_lydo_khacId;
                break;
            case "NGUOI_KY": b_maId = b_nguoi_kyId;
                break;
            //case "TRANGTHAI": b_maId = b_trangthaiId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "")
            return;
        else
            if (b_maTen == "SOTHE_THAYTHE") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_tv_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
            else if (b_maTen == "SO_THE") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_tv_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
                ns_thongtin_canbo(b_ma.value);
                b_hang = GridX_Fi_timHangD(b_grlkeId, "so_the", b_ma.value);
                if (b_hang < 1) {
                    GridX_thoiA(b_grlkeId);
                    ns_tv_P_MOI();
                }
                else {
                    GridX_datA(b_grlkeId, b_hang);
                    ns_tv_P_CHUYEN_HANG();
                }
            }
            else
                if (b_maTen == "NGAYC" || b_maTen == "GIO_BD" || b_maTen == "GIO_KT") {
                    var b_kq = 0;
                    tinh_ngay();
                    return false;
                }
                else
                    if (b_maTen == "NGAYD") {
                        var b_ngayxn = $get(b_ngayxnId).value,
                            b_ngayd = $get(b_ngaydId).value;
                        var b_hang = GridX_Fi_timHangD(b_grlkeId, ["ngayxn", "ngayd"], [b_ngayxn, b_ngayd]);
                        if (b_hang < 1) {
                            var b_kq = 0;
                            GridX_thoiA(b_grlkeId);
                            form_P_MOI(b_vungId, "X");
                            tinh_ngay();
                        }
                        else {
                            GridX_datA(b_grlkeId, b_hang);
                            ns_tv_P_CHUYEN_HANG();
                        }
                        return false;
                    }
                    else
                        if (b_maTen == "TRANGTHAI") {
                            ns_tv_P_LKE('K');
                        }
                        else
                            if (b_maTen == "NGUOI_KY") {
                                ns_thongtin_canbo_ngky();
                            }
                            else skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"),
                                b_ma.value,
                                b_ma.getAttribute("ktra"),
                                ns_tv_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_thongtin_canbo(b_so_the) {
    try {
        hts_dungchung.Fs_THONGTIN_CANBO(b_so_the, ns_thongtin_canbo_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_thongtin_canbo_kq(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq); return;
    }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
function ns_thongtin_canbo_ngky() {
    try {
        var b_so_the = $get(b_nguoi_kyId).value;
        hts_dungchung.Fs_THONGTIN_CANBO(b_so_the, ns_thongtin_canbo_ngky_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_thongtin_canbo_ngky_kq(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    b_kq = b_kq.replace(",SO_THE,", ",NGUOI_KY,");
    b_kq = b_kq.replace(",HO_TEN,", ",TEN_NGUOI_KY,");
    b_kq = b_kq.replace(",TEN_CDANH,", ",TEN_CDANH_KY,");
    b_kq = b_kq.replace(",CDANH,", ",CDANH_KY,");
    form_P_CH_TEXT(b_vung_ngk_Id2, b_kq);
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
function ns_tv_P_MA_KTRA() {
    try {
        var b_so_the_tv = C_NVL($get(b_so_theId).value);
        if (b_so_the_tv != "") {
            var b_ngay_d = CNG_SO($get(b_ngayd_tkId).value);
            var b_ngay_c = CNG_SO($get(b_ngayc_tkId).value);
            var b_phong = lke_Fs_TRA(b_phong_tkId);
            var b_so_the = C_NVL($get(b_sothe_tkId).value);
            var b_ten = C_NVL($get(b_hoten_tkId).value);
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_qt.Fs_NS_THOIVIEC_MA(b_nsd, b_ngay_d, b_ngay_c, b_ctyValue, b_so_the, b_ten, b_so_the_tv, b_TrangKt, a_cot, ns_tv_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_tv_P_MA_KTRA_KQ(b_kq) {
    try {

        if (Fb_LOI_KTRA(b_kq)) {
            form_P_LOI(b_kq);
            return;
        }
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1,
            b_trang = CSO_SO(a_kq[1]),
            b_soDong = CSO_SO(a_kq[2]);
        GridX_datBang(b_grlkeId, a_kq[3]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        if (b_hang < 1) {
            form_P_MOI(b_vungId, "X");
            tinh_ngay();
        }
        else {
            GridX_datA(b_grlkeId, b_hang);
            ns_tv_P_CHUYEN_HANG();
        }
    }
    catch (ex) {
        alert(ex);
    }
}
function ns_tv_P_DatGchu(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq))
            form_P_LOI(b_kq);
        else
            form_P_DatGchu(b_gchuId, b_kq);
    }
    catch (ex) {
        alert(ex);
    }
}
function ns_tv_GR_lke_RowChange() {

    if (ns_tv_choAct != 0)
        clearTimeout(ns_tv_choAct);
    ns_tv_choAct = setTimeout("ns_tv_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_tv_P_LKE_CHO() {
    try {

        if (document.readyState === 'complete') {
            b_so_theId = form_Fs_TEN_ID(b_vungId, 'SO_THE')
            if (ns_tv_lkeCho != 0)
                clearTimeout(ns_tv_lkeCho);
            b_slideId = $get(b_grlkeId).getAttribute('slideId');
            form_F_GOC().P_MENUBf(window.name, 'M');
            vb_cctc_P_SL('', 'D', '0', ' ', ' ', 'T');
            b_ctyValue = "TATCA";
            ns_tv_P_LKE('K');
        }
    }
    catch (err) {
        alert(err);
    }
}
function ns_tv_P_LKE(b_dk) {
    try {
        if (b_dk == 'C')
            slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId);
        var a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_ngay_d = $get(b_ngayd_tkId).value;
        var b_ngay_c = $get(b_ngayc_tkId).value;
        var b_so_the = C_NVL($get(b_sothe_tkId).value);
        var b_ten = C_NVL($get(b_hoten_tkId).value);
        sns_qt.Fs_NS_THOIVIEC_LKE(b_nsd, b_ngay_d, b_ngay_c, b_ctyValue, b_so_the, b_ten, a_tso, a_cot, ns_tv_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_tv_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        return;
    }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    return false;
}
function ns_tv_CB() {
    try {
        var b_so_the = $get(b_so_theId).value;
        a_cot = GridX_Fas_tenCot(b_grlkeId),
            sns_qt.Fs_NS_THOIVIEC_MA(b_so_the, a_cot, ns_tv_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tv_CB_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    // ns_tv_P_LKE(); 
    return false;
}
function ns_tv_gui() {
    try {
        var b_so_the = $get(b_so_theId).value;
        a_cot = GridX_Fas_tenCot(b_grlkeId),
            sns_qt.Fs_NS_THOIVIEC_GUI(b_so_the, ns_tv_gui_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tv_gui_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else form_P_LOI("loi:Gửi duyệt thành công:loi");
    // $get(b_trangthaiId).value = "1";
    return false;
}
function ns_tv_ngayphep() {
    try {
        var b_so_the = $get(b_so_theId).value,
            b_ngayd = $get(b_ngaydId).value;
        sns_qt.Fs_NS_THOIVIEC_NGAY_NAGASE(b_so_the, b_ngayd, ns_tv_ngayphep_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tv_ngayphep_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        return;
    }
    var a_kq = Fas_ChMang(b_kq, '#');
    $get(b_danghiId).value = a_kq[0];
    $get(b_nghiconId).value = a_kq[1];
    return false;
}
function ns_tv_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    var time = new Date();
    $get(b_ngay_kyId).value = time.format("dd/MM/yyyy");
    $get(b_lydo_chitietId).value = "";
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grtlId);
    GridX_datTrang(b_grtsId);
    return false;
}
function ns_tv_P_NH(b_loai) {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") {
            form_P_LOI(b_loi);
            return false;
        }
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 0) {
            b_tinhtrang = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tinhtrang"));
            if (b_tinhtrang == '1') {
                form_P_LOI('loi:Bản ghi đang ở trạng thái phê duyệt, không thể chỉnh sửa:loi');
                return false;
            }
        }

        b_loainhId = b_loai;
        var a_cot = GridX_Fas_tenCot(b_grlkeId);
        var b_so_the = $get(b_so_theId).value;
        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);

        var b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        var a_gt1 = GridX_Fdt_cotGtri(b_gr1_Id);
        var a_gt2 = GridX_Fdt_cotGtri(b_gr2_Id);
        var a_gt3 = GridX_Fdt_cotGtri(b_gr3_Id);
        var a_gt4 = GridX_Fdt_cotGtri(b_gr4_Id);
        var a_gt5 = GridX_Fdt_cotGtri(b_gr5_Id);
        var a_gt6 = GridX_Fdt_cotGtri(b_gr6_Id);
        var a_gt7 = GridX_Fdt_cotGtri(b_gr7_Id);

        sns_qt.Fs_NS_THOIVIEC_NH(form_Fs_nsd(),
            b_so_the,
            b_TrangKt,
            a_dt_ct,
            a_gt1,
            a_gt2,
            a_gt3,
            a_gt4,
            a_gt5,
            a_gt6,
            a_gt7,
            a_cot,
            ns_tv_NH_KQ,
            P_LOI_CSDL,
            P_LOI_TGIAN);
        return false;
    }
    catch (err) {
        alert(err);
    }
}
function ns_tv_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq))
        form_P_LOI(b_kq);
    else {
        //var a_kq = Fas_ChMang(b_kq, '#');
        //var b_hang = CSO_SO(a_kq[0]) + 1;
        //var b_trang = CSO_SO(a_kq[1]);
        //var b_soDong = CSO_SO(a_kq[2]);
        //slide_P_MOI(b_slideId, b_trang, b_soDong);
        //GridX_datBang(b_grlkeId, a_kq[3]);
        //if (b_hang >= 0)
        //    GridX_datA(b_grlkeId, b_hang);
        //ns_tv_P_CHUYEN_HANG();
        form_P_LOI("loi:Nhập thành công!:loi");
        ns_tv_P_LKE('K');
    }
    return false;
}
function nhap_file() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1 || $get(b_so_idId).value == "") {
        form_P_LOI('loi:Bạn phải chọn 1 bản ghi:loi')
        return false;
    }
    var b_so_id = $get(b_so_idId).value;
    var b_tenf = '/App_form/ns/ma/file_Import_chung.aspx';
    form_P_MO(b_tenf,
        window.name,
        [
            "THAMSO",
            [window.name, b_so_id, "NS_TV", "Lưu file quyết định thôi việc"]
        ],
        "C"
    );
    form_P_LOI('');
    return false;

}


function sendMail(b_tso) {
    var a_tso = Fas_ChMang(b_tso, ';');
    var b_toAddress = a_tso[0];
    var b_subject = a_tso[1];
    var b_body = a_tso[2];
    if (b_toAddress == "" || b_toAddress == null || b_toAddress == undefined)
        return false;
    else {
        sSmtpMail.SendMail(b_toAddress, b_subject, b_body, sendMail_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
}
function sendMail_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq))
        form_P_LOI(b_kq);
    return false;
}
function ns_tv_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1)
        return false;
    var b_so_the = $get(b_so_theId).value = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the"));
    $get(b_so_id_inId).value = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_the == "") {
        ns_tv_P_MOI();
        GridX_datA(b_grlkeId, b_hang);
    } else {
        var a_cot_tl = GridX_Fas_tenCot(b_gr1_Id);
        var a_cot_tb = GridX_Fas_tenCot(b_grtbId);
        var a_cot_ts = GridX_Fas_tenCot(b_grtsId);
        var a_cot_hs = GridX_Fas_tenCot(b_gr_hs_Id);
        sns_qt.Fs_NS_THOIVIEC_CT(b_nsd, b_so_the, a_cot_tl, a_cot_tb, a_cot_ts, a_cot_hs, ns_tv_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        //$get(b_so_idId).value = b_so_id;
    }
    return false;
}
function ns_tv_P_CHUYEN_HANG_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) {
            form_P_LOI(b_kq);
            return;
        }
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_so_the = $get(b_so_theId).value;
        if (a_kq[0] != "0") {
            form_P_CH_TEXT(b_vungId, a_kq[0]);
            if (a_kq[1] != "")
                GridX_datBang(b_gr1_Id, a_kq[1]);
            else
                GridX_datTrang(b_gr1_Id);
            if (a_kq[2] != "")
                GridX_datBang(b_gr2_Id, a_kq[2]);
            else
                GridX_datTrang(b_gr2_Id);
            if (a_kq[3] != "")
                GridX_datBang(b_gr3_Id, a_kq[3]);
            else
                GridX_datTrang(b_gr3_Id);
            if (a_kq[4] != "")
                GridX_datBang(b_gr4_Id, a_kq[4]);
            else
                GridX_datTrang(b_gr4_Id);
            if (a_kq[5] != "")
                GridX_datBang(b_gr5_Id, a_kq[5]);
            else
                GridX_datTrang(b_gr5_Id);
            if (a_kq[6] != "")
                GridX_datBang(b_gr6_Id, a_kq[6]);
            else
                GridX_datTrang(b_gr6_Id);
            if (a_kq[7] != "")
                GridX_datBang(b_gr7_Id, a_kq[7]);
            else
                GridX_datTrang(b_gr7_Id);
            ns_thongtin_canbo(b_so_the);
            ns_thongtin_canbo_ngky();
        } else
            ns_tv_P_MOI();
        return false;
    }
    catch (ex) {
        alert(ex);
    }
}
function ns_tv_P_XOA() {
    try {

        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) {
            form_P_LOI("Bạn phải chọn một bản ghi để xóa");
            return false;
        }
        var b_so_the = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the"));
        if (b_so_the == "") {
            form_P_LOI("Bạn phải chọn một bản ghi để xóa");
            ns_tv_P_MOI();
        }
        else {
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang > 0) {
                b_tinhtrang = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tinhtrang"));
                if (b_tinhtrang == '1') {
                    form_P_LOI('loi:Bản ghi đang ở trạng thái phê duyệt, không thể xóa:loi');
                    return false;
                }
            }
            var a_cot = GridX_Fas_tenCot(b_grlkeId);
            var a_tso = slide_Faobj_TUDEN(b_slideId);
            var b_ngayd_tk = $get(b_ngayd_tkId).value;
            var b_ngayc_tk = $get(b_ngayc_tkId).value;
            var b_phong_tk = lke_Fs_TRA(b_phong_tkId);
            var b_sothe_tk = C_NVL($get(b_sothe_tkId).value);
            var b_ten_tk = C_NVL($get(b_hoten_tkId).value);
            sns_qt.Fs_NS_THOIVIEC_XOA(form_Fs_nsd(), b_so_the, b_ngayd_tk, b_ngayc_tk, b_ctyValue, b_sothe_tk, b_ten_tk, a_tso, a_cot, ns_tv_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (ex) {
        alert(ex);
    }
}
function ns_tv_P_XOA_KQ(b_kq) {
    try {

        if (Fb_LOI_KTRA(b_kq))
            form_P_LOI(b_kq);
        else {
            form_P_LOI("loi:Xóa thành công!:loi");
            var a_kq = Fas_ChMang(b_kq, '#');
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang > 1)
                b_hang--;
            else
                b_hang = GridX_Fi_hangSo(b_grlkeId);
            slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
            GridX_datBang(b_grlkeId, a_kq[1]);
            if (GridX_Fb_hangTrang(b_grlkeId, b_hang))
                ns_tv_P_MOI();
            else {
                GridX_datA(b_grlkeId, b_hang);
                ns_tv_P_CHUYEN_HANG();
            }
        }
        return false;
    }
    catch (ex) {
        alert(ex);
    }
}
function ns_tv_P_HUY() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1)
        return;
    var b_so_the = $get(b_so_theId).value;
    var b_ngayxn = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ngayxn"));
    var b_ngayd = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ngayd"));
    if (b_ngayxn == "") { form_P_MOI(b_vungId, "X"); }
    else sns_qt.Fs_NS_THOIVIEC_HUY(b_so_the, b_ngayxn, b_ngayd, ns_tv_P_HUY_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_tv_P_HUY_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        return;
    }
    else {
        ns_tv_P_LKE('K');
        form_P_LOI('loi:Hủy thành công:loi');
        return false;
    }
}
function ns_tv_P_CHON() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1)
        return;
    var b_check = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tinhtrang"));
    if (b_check == "Chưa phê duyệt") {
        alert('Không thể chọn đề xuất chưa được phê duyệt');
        return;
    }
    if (b_check == "Không phê duyệt") {
        alert('Không thể chọn đề xuất Không được phê duyệt');
        return;
    }
    else form_P_TRA_CHON('MA,TEN');
    return false;
}
function ns_tv_P_Phong() {
    try {
        var b_tenf = form_Fs_TM() + '/App_form/ht/ns_hs_cctc_quyen.aspx';
        form_P_MO(b_tenf, null, [window.name, [""]]);
        return false;
    }
    catch (err) { }
}
function ns_tv_P_XUATEXCEL() {
    __doPostBack('ctl00$ContentPlaceHolder1$Nhap2', '');//Xuất Excel
    return false;
}
function ns_tv_P_IN_QD() {
    var b_so_the = $get(b_so_theId).value;
    if (b_so_the == "") {
        form_P_LOI('loi:Vui lòng chọn nhân viên cần in quyết định:loi');
        return false;
    }
    __doPostBack('ctl00$ContentPlaceHolder1$Nhap3', '');//In quyết định chấm dứt
}
function ns_tv_P_IN_BB() {
    var b_so_the = $get(b_so_theId).value;
    if (b_so_the == "") {
        form_P_LOI('loi:Vui lòng chọn nhân viên cần in biên bản thanh lý:loi');
        return false;
    }
    __doPostBack('ctl00$ContentPlaceHolder1$Nhap4', '');//Xuất Excel
}
function vb_cctc_P_CLICK(b_event, b_id) {
    b_event.stopPropagation();
    var b_targetClassNam = b_event.target.className;
    if (b_targetClassNam == "ico_bptt") {
        var b_ctr = $get(b_id);
        var b_div = $get(b_id + '_Div');
        var a_tso = Attribute_Fas_LAY(b_ctr, 'loai,cap,dvi,ma,ma_ct');
        if (b_ctrbeforId != null)
            b_ctrbeforId.style.fontWeight = "100";
        b_ctr.style.fontWeight = "700";
        b_ctrbeforId = b_ctr;
        b_ctyValue = a_tso[3];
        ns_tv_P_LKE('K');
        return false;
    }
    else {
        var b_ctr = $get(b_id), b_div = $get(b_id + '_Div');
        var a_tso = Attribute_Fas_LAY(b_ctr, 'loai,cap,dvi,ma,ma_ct');
        if (a_tso[0] == 'A')
            return false;
        if (a_tso[0] != 'C') {
            if (b_div == null)
                vb_cctc_P_SL(b_id, a_tso[0], a_tso[1], a_tso[2], a_tso[3]);
            else {
                b_id = (C_NVL(b_div.style.display) == '') ? '' : b_id;
                vb_cctc_HIEN(a_tso[4], b_id);
            }
        }
    }
    return false;
}

function ns_tv_P_NAM() {
    try { 
        var b_nam = form_Fs_TEN_GTRI(b_vungId, 'NAM');
        hts_dungchung.Fs_NS_KYLUONG_CHUNG_LKE(form_Fs_nsd(), window.name, b_nam);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_tv_ngaypheduyet() {
    var b_ngaypheduyet = $get(form_Fs_TEN_ID(b_vung_ngk_Id1, 'NGAY_PD')).value;
    var a_string = b_ngaypheduyet.split("/");
    var b_thang = a_string[1];
    var b_nam = a_string[2];
    $get(b_namId).value = b_nam;
    $get(b_namId).setAttribute("textan", b_nam);
    $get(b_namId).setAttribute("traan", b_nam);
    hts_dungchung.Fdt_MA_KYLUONG_BY_NAM_THANG(b_nam, b_thang, ns_tv_ngaypheduyet_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_tv_ngaypheduyet_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_dt = b_kq.split(";");
    var a_value = a_dt[1].split("|");
    $get(b_kyluongId).value = a_value[1];
    $get(b_kyluongId).setAttribute("textan", a_value[1]);
    $get(b_kyluongId).setAttribute("traan",a_value[0]);
    return false;
}

function form_dong() {
    location.reload(false);
}