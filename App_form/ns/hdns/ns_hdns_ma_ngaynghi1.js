var ns_hdns_ma_ngaynghi_lkeCho = 0, ns_hdns_ma_ngaynghi_choAct = 0, b_vungId, b_grlkeId, b_slideId, b_gchuId, b_tenId, b_ngaynghiId,
    b_trangthaiId, b_vungHi, b_tthaiHi, b_soidHi, b_luuday = "", b_namId, b_maId, b_tungayId, b_denngayId, b_so_ngayId;
function ns_hdns_ma_ngaynghi_P_KD() {
    ns_hdns_ma_ngaynghi_lkeCho = setInterval('ns_hdns_ma_ngaynghi_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
        }
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            b_luuday = b_kq;
            form_P_MOI(b_vungId, "GLX");
            ns_hdns_ma_ngaynghi_P_LKE();
            $get(b_namId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_ngaynghi_P_KTRA(b_maTen) {
    try {
        var b_ma_Id = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "NAM": b_ma_Id = b_namId; break;
            case "MA": b_ma_Id = b_maId; break;
            case "TUNGAY": b_ma_Id = b_tungayId; break;
            case "DENNGAY": b_ma_Id = b_denngayId; break;
        }
        var b_ma = $get(b_ma_Id);
        if (b_maTen == "MA") {
            $get(b_maId).value = ($get(b_maId).value).validate_Ma();
            var b_nam = $get(b_namId).value;
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) {
                GridX_thoiA(b_grlkeId);
                ns_hdns_ma_ngaynghi_P_MA_KTRA();
            }
            else { GridX_datA(b_grlkeId, b_hang); ns_hdns_ma_ngaynghi_P_CHUYEN_HANG(); }
        }
        else if (b_maTen == "NAM") {
            form_P_MOI(b_vungId, "GLX");
            ns_hdns_ma_ngaynghi_P_LKE();
        }
        else if (b_maTen == "TUNGAY" || b_maTen == "DENNGAY") {
            tinh_ngay();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_ngaynghi_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_maId).value);
        var b_nam = C_NVL($get(b_namId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_hdns.Fs_NS_HDNS_MA_NGAYNGHI_MA(b_ma, b_luuday, b_TrangKt, a_cot, ns_hdns_ma_ngaynghi_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_ngaynghi_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "LX");
    else { GridX_datA(b_grlkeId, b_hang); ns_hdns_ma_ngaynghi_P_CHUYEN_HANG(); }
}
function ns_hdns_ma_ngaynghi_P_MOI() {
    form_P_MOI(b_vungId, "KGXL");
    ns_hdns_ma_ngaynghi_P_LKE();
    $get(b_soidHi).value = "";
    $get(b_tthaiHi).value = "";
    $get(b_trangthaiId).value = "Áp dụng";
    $get(b_namId).focus();
    return false;
}
function ns_hdns_ma_ngaynghi_P_NH() {
    var ktra = ktra_ngay(parseDate($get(b_tungayId).value).getTime(), parseDate($get(b_denngayId).value).getTime(), 1, "Từ ngày", "Đến ngày");
    if (ktra.length > 0) { ns_hdns_ma_ngaynghi_P_NH_KQ(ktra); return false; }
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var b_ngaynghi = $get(b_tungayId).value;
    if ($get(b_namId).value != b_ngaynghi.substring(b_ngaynghi.length - 4)) {
        b_loi = "loi:Nhập năm không đúng:loi";
        form_P_LOI(b_loi); return false;
    }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    var b_so_id = $get(b_soidHi).value;
    sns_hdns.Fs_NS_HDNS_MA_NGAYNGHI_NH(form_Fs_nsd(), b_TrangKt, a_dt_ct, b_so_id, b_luuday, a_cot, ns_hdns_ma_ngaynghi_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_hdns_ma_ngaynghi_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        $get(b_soidHi).value = a_kq[4];
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_namId).focus();
        form_P_LOI("loi:Ghi thành công!:loi");
    }
    return false;
}
function ns_hdns_ma_ngaynghi_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") ns_hdns_ma_ngaynghi_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_NS_HDNS_MA_NGAYNGHI_XOA(b_so_id, a_tso, a_cot, ns_hdns_ma_ngaynghi_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_hdns_ma_ngaynghi_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) {
            if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) {
                ns_hdns_ma_ngaynghi_P_MOI();
            }
            else {
                GridX_datA(b_grlkeId, b_hang); ns_hdns_ma_ngaynghi_P_CHUYEN_HANG();
            }
        }
        else { ns_hdns_ma_ngaynghi_P_CHUYEN_HANG(); GridX_datA(b_grlkeId, b_hang); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
}
function ns_hdns_ma_ngaynghi_GR_lke_RowChange() {
    if (ns_hdns_ma_ngaynghi_choAct != 0) clearTimeout(ns_hdns_ma_ngaynghi_choAct);
    ns_hdns_ma_ngaynghi_choAct = setTimeout("ns_hdns_ma_ngaynghi_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_hdns_ma_ngaynghi_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "") {
            form_P_MOI(b_vungId, "KGLX");
            $get(b_soidHi).value = "";
            $get(b_tthaiHi).value = "";
            $get(b_trangthaiId).value = "Áp dụng";
        }
        else {
            $get(b_soidHi).value = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
            sns_hdns.Fs_NS_HDNS_MA_NGAYNGHI_CT(b_so_id, ns_hdns_ma_ngaynghi_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_ngaynghi_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
function ns_hdns_ma_ngaynghi_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        ns_hdns_ma_ngaynghi_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_vungHi = form_Fs_VUNG_ID('UPa_hi');
        b_namId = form_Fs_TEN_ID(b_vungId, 'NAM');
        b_maId = form_Fs_TEN_ID(b_vungId, 'MA');
        b_tenId = form_Fs_TEN_ID(b_vungId, 'TEN');
        b_tungayId = form_Fs_TEN_ID(b_vungId, 'TUNGAY');
        b_denngayId = form_Fs_TEN_ID(b_vungId, 'DENNGAY');
        b_trangthaiId = form_Fs_TEN_ID(b_vungId, 'TRANGTHAI');
        b_tthaiHi = form_Fs_TEN_ID(b_vungHi, 'tthai'); b_so_ngayId = form_Fs_TEN_ID(b_vungId, 'so_ngay');
        b_soidHi = form_Fs_TEN_ID(b_vungHi, 'so_id');
        b_gchuId = form_Fs_VTEN_ID('', 'gchu');
        b_slideId = $get(b_grlkeId).getAttribute('slideId'); slide_P_MOI(b_slideId);
        clearTimeout(ns_hdns_ma_ngaynghi_lkeCho); ns_hdns_ma_ngaynghi_P_LKE();
    }
}
function ns_hdns_ma_ngaynghi_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_NS_HDNS_MA_NGAYNGHI_LKE(b_luuday, a_tso, a_cot, ns_hdns_ma_ngaynghi_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_ngaynghi_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_hdns_ma_ngaynghi_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function form_dong() {
    location.reload(false);
}
function parseDate(str) {
    var mdy = str.split('/');
    return new Date(mdy[2], mdy[1], mdy[0]);
}
function ktra_ngay(tungay, denngay, loai, ten1, ten2) {
    if (denngay == "" || denngay == null) {
        return "";
    }
    if (loai == 1 && tungay > denngay) {
        return "loi: " + ten1 + " không được lớn hơn " + ten2 + " :loi";
    } else if (loai == 2 && tungay >= denngay) {
        return "loi: " + ten1 + " không được lớn hơn hoặc bằng " + ten2 + " :loi";
    }
    return "";
}

function tinh_ngay() {
    try {
        var b_ngayd = $get(b_tungayId).value, b_ngayc = $get(b_denngayId).value;
        if (b_ngayd != "" && b_ngayc != "") {
            b_ngayd = b_ngayd.substring(3, 5) + "/" + b_ngayd.substring(0, 2) + "/" + b_ngayd.substring(6, 10);
            b_ngayc = b_ngayc.substring(3, 5) + "/" + b_ngayc.substring(0, 2) + "/" + b_ngayc.substring(6, 10);
            var ngay = mydiff(b_ngayd, b_ngayc, "days") + 1;
            $get(b_so_ngayId).value = ngay;
        }
    } catch (err) { form_P_LOI(err); }
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