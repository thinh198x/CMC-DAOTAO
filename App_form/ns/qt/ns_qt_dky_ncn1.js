var ns_qt_dky_ncn_lkeCho, b_vungId, b_grlkeId, b_slideId, b_so_theId, b_nsd, b_loai,
    b_sothe_thaytheId, b_nguoiduyetId, b_ngaydId, b_ngaycId, b_loiNhap = 0, ns_qt_dky_ncn_choAct = 0, c_thongtin_nghi_choActb_tungay_tkId, b_tungay_tkId, b_denngay_tkId, b_so_thetkId,
    b_tenId_tk, b_vungTkId, b_gio_bdId, b_macc_nghiId, b_gio_ktId, b_gchuId, b_ngaynghi, b_danghiId, b_nghiconId, b_moiId, b_ngaynghi, b_truphepnam;
function ns_qt_dky_ncn_P_KD(nsd) {
    b_nsd = nsd,
        ns_qt_dky_ncn_lkeCho = setTimeout('ns_qt_dky_ncn_P_LKE_CHO()', 500);
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
        }
        else
            if (b_dtuong.indexOf("SO_THE") >= 0) {
                $get(b_so_theId).value = a_tso[0];
                $get(b_gchuId).innerHTML = a_tso[1];
                ns_qt_dky_ncn_P_KTRA("SO_THE");
            }
            else
                if (b_dtuong.indexOf("KQ") >= 0) {
                    $get(b_so_theId).value = a_tso[0];
                    $get(b_ngayxnId).innerHTML = a_tso[1];
                    $get(b_ngaydId).innerHTML = a_tso[2];
                    ns_qt_dky_ncn_P_MA_KTRA();
                    return false;
                }
    }
    catch (err) { form_P_LOI(err); }
}
// kiểm tra
function ns_qt_dky_ncn_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SOTHE_THAYTHE": b_maId = b_sothe_thaytheId;
                break;
            case "NGAYD": b_maId = b_ngaydId;
                $get(b_ngaynghi).value = "";
                break;
            case "NGAYC": b_maId = b_ngaycId;
                $get(b_ngaynghi).value = "";
                break;
            case "SO_THE": b_maId = b_so_theId;
                break;
            case "NAMTRU": b_maId = b_namId;
                break;
            case "GIO_BD": b_maId = b_gio_bdId;
                break;
            case "GIO_KT": b_maId = b_gio_ktId;
                break;
            case "NGAY_NGHI": b_maId = b_ngaynghi;
                break;
            case "TRUPHEP": b_maId = b_truphepnam;
                break;
            case "MACC_NGHI": b_maId = b_macc_nghiId;
                $get(b_ngaynghi).value = "";
                break;
        }
        if (b_maTen == "NGAYD" || b_maTen == "NGAYC") {
            //tinh_ngay();
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "")
            return;
        else
            if (b_maTen == "SOTHE_THAYTHE") {
                skhac.Fs_MA_LOI(form_Fs_nsd(),
                    b_ma.getAttribute("ten"),
                    b_ma.value,
                    b_ma.getAttribute("ktra"),
                    ns_qt_dky_ncn_P_DatGchu,
                    P_LOI_CSDL,
                    P_LOI_TGIAN);
            }
            else
                if (b_maTen == "SO_THE") {
                    skhac.Fs_MA_LOI(form_Fs_nsd(),
                        b_ma.getAttribute("ten"),
                        b_ma.value,
                        b_ma.getAttribute("ktra"),
                        ns_qt_dky_ncn_P_DatGchu,
                        P_LOI_CSDL,
                        P_LOI_TGIAN);
                    ns_qt_dky_ncn_TTCB();
                    b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
                    if (b_hang < 1) {
                        GridX_thoiA(b_grlkeId);
                        ns_qt_dky_ncn_P_MOI();
                        ns_qt_dky_ncn_P_MA_KTRA();
                    }
                    else {
                        GridX_datA(b_grlkeId, b_hang);
                        ns_qt_dky_ncn_P_CHUYEN_HANG();
                    }
                }
                else
                    if (b_maTen == "NAMTRU") {
                        ns_qt_dky_ncn_phep();
                    }
                    else
                        if (b_maTen == "TRUPHEP") {
                            var truphep = $get(b_truphepnam).value;
                            var ngaynghi = $get(b_ngaynghi).value;
                            if (truphep > ngaynghi) {
                                form_P_LOI("Số ngày phép trừ không được lớn hơn ngày nghỉ.");
                            }
                        }
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_qt_dky_ncn_P_MA_KTRA() {
    try {
        var b_so_the = C_NVL($get(b_so_theId).value);
        if (b_so_the != "") {
            var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var a_cot = GridX_Fas_tenCot(b_grlkeId);
            var b_tungay = $get(b_tungay_tkId).value;
            var b_trangthai = form_Fs_TEN_GTRI(b_vungTkId, 'trangthai_tk');
            var b_denngay = $get(b_denngay_tkId).value;
            sns_qt.Fs_CC_DKY_NCN_MA(form_Fs_nsd(),
                b_so_id,
                b_so_the,
                b_tungay,
                b_denngay,
                b_trangthai,
                b_TrangKt,
                a_cot,
                ns_qt_dky_ncn_P_MA_KTRA_KQ,
                P_LOI_CSDL,
                P_LOI_TGIAN);
            return false;
        }
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_qt_dky_ncn_P_MA_KTRA_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) {
            form_P_LOI(b_kq);
            return;
        }
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1;
        var b_trang = CSO_SO(a_kq[1]);
        var b_soDong = CSO_SO(a_kq[2]);
        GridX_datBang(b_grlkeId, a_kq[3]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        if (b_hang < 1) {
            form_P_MOI(b_vungId, "X");
            //tinh_ngay();
        }
        else {
            GridX_datA(b_grlkeId, b_hang);
            ns_qt_dky_ncn_P_CHUYEN_HANG();
        }
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_qt_dky_ncn_P_DatGchu(b_kq) {
    try {

        if (Fb_LOI_KTRA(b_kq)) {
            form_P_LOI(b_kq);
            b_loiNhap = 1;
        }
        else {
            form_P_DatGchu(b_gchuId, b_kq);
            b_loiNhap = 0;
        }
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_qt_dky_ncn_P_MOI() {
    try {
        form_P_MOI(b_vungId, "GXL");
        GridX_thoiA(b_grlkeId);
        $get(b_so_theId).focus();
        ns_qt_dky_ncn_phep();
        return false;
    }
    catch (err) {
        form_P_LOI(err);
    }
}
//nhập
function ns_qt_dky_ncn_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") {
            form_P_LOI(b_loi);
            return false;
        }
        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
        var b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        var b_so_id = $get(b_so_Id).value;
        //var b_hang = GridX_Fi_timHangA(b_grlkeId);
        sns_qt.Fs_CC_DKY_NCN_NH(form_Fs_nsd(), b_so_id, b_TrangKt, a_dt_ct, a_cot_lke, ns_qt_dky_ncn_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);

        return false;
    }
    catch (err) {
        alert(err);
    }
}
function ns_qt_dky_ncn_P_NH_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq))
            form_P_LOI(b_kq);
        else {
            var a_kq = Fas_ChMang(b_kq, '#');
            var b_hang = CSO_SO(a_kq[0]) + 1;
            //slide_P_MOI(b_slideId, b_trang, b_soDong);
            GridX_datBang(b_grlkeId, a_kq[1]);
            if (b_hang >= 0)
                GridX_datA(b_grlkeId, b_hang);
            $get(b_so_theId).focus();
            form_P_LOI("loi:Nhập thành công!:loi");
        }
        return false;
    }
    catch (err) {
        form_P_LOI(err);
    }
}
// xóa
function ns_qt_dky_ncn_P_XOA() {
    try {

        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_the = $get(b_so_theId).value,
            b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));;
        if (b_hang < 1 || b_so_id == "") {
            form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi");
            ns_qt_dky_ncn_P_MOI();
            return false;
        }
        else {
            var a_cot = GridX_Fas_tenCot(b_grlkeId);
            a_tso = slide_Faobj_TUDEN(b_slideId);

            var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
            var b_so_the = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the"));
            sns_qt.Fs_CC_DKY_NCN_XOA(
                form_Fs_nsd(),
                b_so_id,
                b_so_the,
                a_tso,
                a_cot,
                ns_qt_dky_ncn_P_XOA_KQ,
                P_LOI_CSDL,
                P_LOI_TGIAN);

            return false;
        }
        return false;
    }
    catch (err) {
        alert(err.message);
    }
}
function ns_qt_dky_ncn_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq))
        form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'),
            b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1)
            b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang))
            ns_qt_dky_ncn_P_MOI();
        else {
            GridX_datA(b_grlkeId, b_hang);
            ns_qt_dky_ncn_P_CHUYEN_HANG();
        }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
    return false;
}
//hủy
function ns_qt_dky_ncn_P_HUY() {
    var r = confirm("Bạn có chắc chắn hủy không?");
    if (r == false)
        return false;
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_the = $get(b_so_theId).value,
        b_ngayd = $get(b_ngaydId).value;
    if (b_so_the == "") ns_qt_dky_ncn_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId),
            a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_tungay = $get(b_tungay_tkId).value,
            b_denngay = $get(b_denngay_tkId).value;
        sns_qt.Fs_CC_DKY_NCN_XOA(form_Fs_nsd(), b_tungay, b_denngay, b_so_the, b_ngayd, a_tso, a_cot, ns_qt_dky_ncn_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
// chuyển hàng
function ns_qt_dky_ncn_GR_lke_RowChange() {
    if (ns_qt_dky_ncn_choAct != 0)
        clearTimeout(ns_qt_dky_ncn_choAct);
    ns_qt_dky_ncn_choAct = setTimeout("ns_qt_dky_ncn_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_qt_dky_ncn_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_the = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the"),
        b_ngay_dky = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ngay_dky"));
    if (b_ngay_dky == "" || b_so_the == '') {
        form_P_MOI(b_vungId, "X");
    }
    else {
        sns_qt.Fs_CC_DKY_NCN_CT(form_Fs_nsd(), b_so_the, b_ngay_dky, ns_qt_dky_ncn_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        form_P_GridX_TEXT(b_vungId, b_grlkeId);
    }
    return false;
}
function ns_qt_dky_ncn_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        return;
    }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
// liệt kê
function ns_qt_dky_ncn_P_LKE_CHO() {
    try {
        if (document.readyState === 'complete') {
            b_vungTkId = form_Fs_VUNG_ID('UPa_tk');
            b_namId = form_Fs_TEN_ID(b_vungTkId, 'NAM_TK');
            b_ky_luongId = form_Fs_TEN_ID(b_vungTkId, 'KY_LUONG_TK');
            b_grlkeId = form_Fs_VUNG_ID('GR_lke');
            b_vungId = form_Fs_VUNG_ID('UPa_ct');
            b_so_Id = form_Fs_TEN_ID(b_vungId, 'so_id');
            b_so_theId = form_Fs_TEN_ID(b_vungId, 'SO_THE');
            b_ngaydId = form_Fs_TEN_ID(b_vungId, 'ngayd');
            b_ngaycId = form_Fs_TEN_ID(b_vungId, 'ngayc');
            b_giod_Id = form_Fs_TEN_ID(b_vungId, 'giod');
            b_gioc_Id = form_Fs_TEN_ID(b_vungId, 'gioc');
            b_gchuId = form_Fs_VTEN_ID('', 'gchu');
            b_moiId = form_Fs_VTEN_ID('', 'moi');
            b_slideId = b_grlkeId + '_slide';
            if (ns_qt_dky_ncn_lkeCho != 0)
                clearTimeout(ns_qt_dky_ncn_lkeCho);
            b_slideId = $get(b_grlkeId).getAttribute('slideId');
            ns_qt_dky_ncn_P_LKE('K');
            ns_qt_dky_ncn_P_CB();
        }
    }
    catch (err) {
        alert(err);
    }
}
function ns_qt_dky_ncn_P_LKE(b_dk) {
    try {
        var b_so_the = b_nsd;
        var b_nam = $get(b_namId).value;
        var b_ky_luong = $get(b_ky_luongId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId);
        var a_tso = slide_Faobj_TUDEN(b_slideId);

        sns_qt.Fs_CC_DKY_NCN_LKE(form_Fs_nsd(),
            b_so_the,
            b_nam,
            b_ky_luong,
            a_tso,
            a_cot,
            ns_qt_dky_ncn_P_LKE_KQ,
            P_LOI_CSDL,
            P_LOI_TGIAN);
        return false;
    }
    catch (err) {
        alert(err);
    }
}
function ns_qt_dky_ncn_P_LKE_KQ(b_kq) {
    try {

        if (Fb_LOI_KTRA(b_kq)) {
            form_P_LOI(b_kq);
            return;
        }
        else {
            var a_kq = Fas_ChMang(b_kq, '#');
            slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
            GridX_datBang(b_grlkeId, a_kq[1]);
            //if (lke_Fs_TRA($get(b_macc_nghiId)) != "")
            //    ns_qt_dky_ncn_SC();
            return false;
        }
    }
    catch (err) {
        alert(err);
    }
}
// thông tin năm/kỳ lương
function ns_qt_dky_ncn_P_NAM() {
    try {
        var b_nam = form_Fs_TEN_GTRI(b_vungTkId, 'NAM');
        hts_dungchung.Fs_NS_KYLUONG_BY_NAM_LKE(b_nam, ns_qt_dky_ncn_P_NAM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_qt_dky_ncn_P_NAM_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        ns_qt_dky_ncn_P_KTRA("KYLUONG");
    }
}
function ns_qt_dky_ncn_P_CB() {
    try {
        var b_so_the = b_nsd;
        hts_dungchung.Fs_THONGTIN_CANBO(b_so_the, ns_qt_dky_ncn_P_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_qt_dky_ncn_P_CB_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        return;
    }

    form_P_CH_TEXT(b_vungId, b_kq);
    $get(b_so_Id).value = '';
    return false;
}
function ns_qt_dky_ncn_ngayphep() {
    try {
        var b_so_the = $get(b_so_theId).value,
            b_ngayd = $get(b_ngaydId).value;
        sns_qt.Fs_CC_DKY_NCN_NGAY(form_Fs_nsd(), b_so_the, b_ngayd, ns_qt_dky_ncn_ngayphep_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_qt_dky_ncn_ngayphep_KQ(b_kq) {
    try {

        if (Fb_LOI_KTRA(b_kq)) {
            form_P_LOI(b_kq);
            return;
        }
        form_P_CH_TEXT(b_vungId, b_kq);
        return false;
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_qt_dky_ncn_phep() {
    try {
        var b_so_the = b_nsd;
        //b_nam = $get(b_namId).value;
        sns_qt.Fs_CC_DKY_NCN_NGAYPHEP(form_Fs_nsd(), b_so_the, '', ns_qt_dky_ncn_phep_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_qt_dky_ncn_phep_KQ(b_kq) {
    try {

        if (Fb_LOI_KTRA(b_kq)) {
            form_P_LOI(b_kq);
            return;
        }
        form_P_CH_TEXT(b_vungId, b_kq);
        return false;
    }
    catch (err) {
        form_P_LOI(err);
    }
}
// lấy thông tin cán bộ
function ns_qt_dky_ncn_TTCB() {
    try {
        var b_so_the = $get(b_so_theId).value;
        hts_dungchung.Fs_THONGTIN_CANBO(b_so_the, ns_qt_dky_ncn_TTCB_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_qt_dky_ncn_TTCB_kq(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        return;
    }
    if (b_kq == "") {
        form_P_LOI("loi:Nhân viên chưa được làm quyết định:loi");
        return
    }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
// so sánh ngày
function ns_qt_dky_ncn_KT_NGAY(tungay, denngay, loai, ten1, ten2) {
    if (denngay == "" || denngay == null) {
        return "";
    }
    if (loai == 1 && tungay > denngay) {
        return "loi: " + ten1 + " không được lớn hơn " + ten2 + " :loi";
    } else
        if (loai == 2 && tungay >= denngay) {
            return "loi: " + ten1 + " không được lớn hơn hoặc bằng " + ten2 + " :loi";
        }
    return "";
}
function ns_qt_dky_ncn_Date(str) {
    var mdy = str.split('/');
    return new Date(mdy[2] + "/" + mdy[1] + "/" + mdy[0]);
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
function form_dong() {
    location.reload(false);
}
function ns_qt_dky_ncn_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function ns_qt_dky_ncn_P_MAU() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'btn_excel_mau');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;

}

// Cập nhật trạng thái
function ns_qt_dky_ncn_P_Update() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_the = $get(b_so_theId).value,
            b_ngayd = $get(b_ngaydId).value;
        if (b_hang < 1 || b_so_the == "") {
            form_P_LOI("Bạn phải chọn một bản ghi để xóa");
            ns_qt_dky_ncn_P_MOI();
            return false;
        }
        else {
            b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "huydon"));
            if (b_trangthai == '1') {
                form_P_LOI('loi:Bản ghi ghi đã bị hủy, bạn không thể hủy đơn này:loi');
                return false;
            }

            var a_cot = GridX_Fas_tenCot(b_grlkeId),
                a_tso = slide_Faobj_TUDEN(b_slideId);
            var b_tungay = $get(b_tungay_tkId).value,
                b_denngay = $get(b_denngay_tkId).value,
                b_sothe = $get(b_so_thetkId).value,
                b_ten = $get(b_tenId_tk).value;
            sns_qt.Fs_CC_DKY_NCN_UP(form_Fs_nsd(), b_so_the, b_ngayd, "1", b_tungay, b_denngay, b_sothe, b_ten, "2", a_tso, a_cot, ns_qt_dky_ncn_Update_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_qt_dky_ncn_Update_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        form_P_LOI("loi:Hủy đơn thành công:loi");
    }
    return false;
}
//import từ file Excel
function ns_qt_dky_ncn_FILE_Import() {
    var b_tenf = '/App_form/ns/hdns/file_hdns.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "THONGTIN_NGHI_IMP", "THONGTIN_NGHI_IMP", "Import thông tin nghỉ"]], null);
    return false;
}
function ns_qt_dky_ncn_phep() {
    try {
        var b_so_the = b_nsd;
        //b_nam = $get(b_namId).value;
        sns_qt.Fs_NS_CC_THONGTIN_NGHI_NGAYPHEP(form_Fs_nsd(), b_so_the, '', ns_qt_dky_ncn_phep_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_qt_dky_ncn_phep_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        return;
    }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
function ns_qt_dky_ncn_P_GUI() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") {
            form_P_LOI(b_loi);
            return false;
        }
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) {
            form_P_LOI("loi:Chưa chọn đăng ký cần gửi:loi");
            return false;
        }
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "") {
            form_P_LOI("loi:Chưa chọn đăng ký cần gửi:loi");
            return false;
        }
        b_trang_thai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "trang_thai"));
        a_cot = GridX_Fas_tenCot(b_grlkeId);
        if (b_trang_thai == "0")
            sns_qt.Fs_CC_DKY_NCN_GUI(form_Fs_nsd(), b_so_id, ns_qt_dky_ncn_P_GUI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        else
            form_P_LOI("loi:Đăng ký đã được gửi hoặc phê duyệt:loi");
        return false;
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_qt_dky_ncn_P_GUI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        return;
    }
    else
        form_P_LOI("loi:Gửi phê duyệt thành công:loi");
    ns_qt_dky_ncn_P_LKE('K');
    return false;
}

function getDateNow(day) {
    var today = new Date();
    var numberOfDaysToAdd = day;
    today.setDate(today.getDate() + numberOfDaysToAdd);
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();
    if (dd < 10) {
        dd = '0' + dd;
    }
    if (mm < 10) {
        mm = '0' + mm;
    }
    var datenow = dd + '/' + mm + '/' + yyyy;
    return datenow;
}
function ktra_ngay(tungay, denngay, loai, ten1, ten2, songay) {
    if (denngay == "" || denngay == null) {
        return "";
    }
    if (loai == 1 && tungay < denngay) {
        return "loi:Bạn phải đăng ký trước " + songay + " ngày:loi";
    } else if (loai == 2 && tungay < denngay) {
        return "loi:Bạn phải đăng ký trước " + songay + ":loi";
    }
    return "";
}
function parseDate(str) {
    var mdy = str.split('/');
    return new Date(mdy[2], mdy[1], mdy[0]);
}