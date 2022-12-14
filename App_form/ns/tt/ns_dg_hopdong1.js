var ns_dg_hopdong_lkeCho, b_vungId, b_grlkeId, b_slideId, b_so_theId, b_nsd, b_loai,
    b_sothe_thaytheId, b_nguoiduyetId, b_ngaydId, b_ngaycId, b_loiNhap = 0, ns_dg_hopdong_choAct = 0, c_thongtin_nghi_choAct,
    b_so_the_tkId, b_ten_tkId, b_nam_tkId, b_aphongId, b_akyluongId, b_kyluongId, b_phong_tkId, b_vungTkId, b_gio_bdId, b_macc_nghiId, b_phep_conId, b_gio_ktId, b_gchuId,
    b_ngaynghi, b_danghiId, b_nghiconId, b_moiId, b_truphepnam, b_tt_phep, b_huydongId, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C', b_ctyValue, b_ctrbeforId;
function ns_dg_hopdong_P_KD() {
    ns_dg_hopdong_lkeCho = setTimeout('ns_dg_hopdong_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "" || a_tso[0] == "FILE_HTOAN")
            return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        $get(b_so_theId).value = a_tso[0];
        $get(b_ho_tenId).value = a_tso[1];
        $get(b_ten_cdanhId).value = a_tso[6];
        $get(b_ten_phongId).value = a_tso[3];
        ns_dg_hopdong_TTCB();
    }
    catch (err) {
        form_P_LOI(err);
    }
}
// kiểm tra
function ns_dg_hopdong_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_so_theId;
                ns_dg_hopdong_TTCB();
                break;
        }
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_dg_hopdong_P_MA_KTRA() {
    try {
        var b_so_the = C_NVL($get(b_so_theId).value);
        if (b_so_the != "") {
            var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_qt.Fs_NS_DG_HDLD_MA(form_Fs_nsd(),
                b_so_the,
                b_so_id,
                b_TrangKt,
                a_cot,
                ns_dg_hopdong_P_MA_KTRA_KQ,
                P_LOI_CSDL,
                P_LOI_TGIAN);
            return false;
        }
    }
    catch (err) {
        form_P_LOI(err);
    }
}

function ns_dg_hopdong_P_MA_KTRA_KQ(b_kq) {
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
            tinh_ngay();
        }
        else {
            GridX_datA(b_grlkeId, b_hang);
            ns_dg_hopdong_P_CHUYEN_HANG();
        }
    }
    catch (err) {
        alert(err);
    }
}
function ns_dg_hopdong_P_MA_PHEP_KTRA() {
    try {
        var b_so_the = $get(b_so_theId).value;
        var b_ngayd = $get(b_ngaydId).value;
        sns_qt.Fs_NS_DG_HDLD_KTRA(form_Fs_nsd(), b_so_the, b_ngayd, ns_dg_hopdong_P_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_dg_hopdong_P_KTRA_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) {
            form_P_LOI(b_kq);
        }
        // chỗ này con thiếu, phải công thêm số phép nó nhập trên lưới với b_kq, nếu >3 thì mới hỏi

    }
    catch (err) {
        alert(err);
    }
}
function ns_dg_hopdong_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        b_loiNhap = 1;
    }
    else {
        form_P_DatGchu(b_gchuId, b_kq);
        b_loiNhap = 0;
    }
}
function ns_dg_hopdong_P_MOI() {
    try {
        form_P_MOI(b_vungId, "GXL");
        GridX_thoiA(b_grlkeId);
        $get(b_so_theId).focus();
        return false;
    }
    catch (err) {
        alert(err);
    }
}
//nhập
function ns_dg_hopdong_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") {
            form_P_LOI(b_loi);
            return false;
        }

        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
        var b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));

        sns_qt.Fs_NS_DG_HDLD_NH(
            form_Fs_nsd(),
            b_so_id,
            b_TrangKt,
            a_dt_ct,
            a_cot_lke,
            ns_dg_hopdong_P_NH_KQ,
            P_LOI_CSDL,
            P_LOI_TGIAN
        );
        return false;
    }
    catch (err) {
        alert(err);
    }
}
function ns_dg_hopdong_P_NH_KQ(b_kq) {
    try {

        if (Fb_LOI_KTRA(b_kq))
            form_P_LOI(b_kq);
        else {
            var a_kq = Fas_ChMang(b_kq, '#');
            var b_hang = CSO_SO(a_kq[0]) + 1;
            var b_trang = CSO_SO(a_kq[1]);
            var b_soDong = CSO_SO(a_kq[2]);
            slide_P_MOI(b_slideId, b_trang, b_soDong);
            GridX_datBang(b_grlkeId, a_kq[3]);
            if (b_hang >= 0)
                GridX_datA(b_grlkeId, b_hang);
            $get(b_so_theId).focus();
            form_P_LOI("loi:Nhập thành công!:loi");
        }
        return false;
    }
    catch (err) {
        alert(err);
    }
}
// xóa
function ns_dg_hopdong_P_XOA() {
    try {

        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        //var b_so_the = $get(b_so_theId).value;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));;
        if (b_hang < 1 || b_so_id == "") {
            form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi");
            ns_dg_hopdong_P_MOI();
            return false;
        }
        else {
            var a_cot = GridX_Fas_tenCot(b_grlkeId);
            var a_tso = slide_Faobj_TUDEN(b_slideId);
            var b_so_the_tk = $get(b_so_the_tkId).value;
            var b_ten_tk = $get(b_ten_tkId).value;

            var b_phong_tk = b_ctyValue;
            sns_qt.Fs_NS_DG_HDLD_XOA(
                form_Fs_nsd(),
                b_so_the_tk,
                b_ten_tk,               
                b_phong_tk,
                b_so_id,
                a_tso,
                a_cot,
                ns_dg_hopdong_P_XOA_KQ,
                P_LOI_CSDL,
                P_LOI_TGIAN
            );
        }
        return false;
    }
    catch (err) {
        alert(err);
    }
}
function ns_dg_hopdong_P_XOA_KQ(b_kq) {
    try {

        if (Fb_LOI_KTRA(b_kq))
            form_P_LOI(b_kq);
        else {
            var a_kq = Fas_ChMang(b_kq, '#'),
                b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang > 1)
                b_hang--;
            else
                b_hang = GridX_Fi_hangSo(b_grlkeId);
            slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
            GridX_datBang(b_grlkeId, a_kq[1]);
            if (GridX_Fb_hangTrang(b_grlkeId, b_hang))
                ns_dg_hopdong_P_MOI();
            else {
                GridX_datA(b_grlkeId, b_hang);
                ns_dg_hopdong_P_CHUYEN_HANG();
            }
            form_P_LOI("loi:Xóa thành công!:loi");
        }
        return false;
    }
    catch (err) {
        alert(err);
    }
}
//hủy
function ns_dg_hopdong_P_HUY() {
    var r = confirm("Bạn có chắc chắn hủy không?");
    if (r == false)
        return false;
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_the = $get(b_so_theId).value;
    var b_ngayd = $get(b_ngaydId).value;
    if (b_so_the == "")
        ns_dg_hopdong_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId);
        var a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_so_the_tk = $get(b_so_the_tkId).value;
        var b_ten_tk = $get(b_ten_tkId).value;
        var b_nam_tk = lke_Fs_TRA($get(b_nam_tkId));
        var b_kyluong = lke_Fs_TRA($get(b_kyluongId));
        var b_phong_tk = b_ctyValue;
        sns_qt.Fs_NS_DG_HDLD_XOA(
            form_Fs_nsd(),
            b_so_the_tk,
            b_ten_tk,
            b_nam_tk,
            b_kyluong,
            b_phong_tk,
            a_tso,
            a_cot,
            ns_dg_hopdong_P_XOA_KQ,
            P_LOI_CSDL,
            P_LOI_TGIAN
        );
    }
    return false;
}
// chuyển hàng
function ns_dg_hopdong_GR_lke_RowChange() {
    if (ns_dg_hopdong_choAct != 0)
        clearTimeout(ns_dg_hopdong_choAct);
    ns_dg_hopdong_choAct = setTimeout("ns_dg_hopdong_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_dg_hopdong_P_CHUYEN_HANG() {
    try {

        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1)
            return;
        var b_so_the = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the");

        sns_qt.Fs_NS_DG_HDLD_CT(
            form_Fs_nsd(),
            b_so_the,
            ns_dg_hopdong_P_CHUYEN_HANG_KQ,
            P_LOI_CSDL,
            P_LOI_TGIAN
        );
        //form_P_GridX_TEXT(b_vungId, b_grlkeId);
        return false;
    }
    catch (err) {
        alert(err);
    }
}
function ns_dg_hopdong_P_CHUYEN_HANG_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) {
            form_P_LOI(b_kq);
            return;
        }
        form_P_CH_TEXT(b_vungId, b_kq);
        return false;
    }
    catch (err) {
        alert(err);
    }
}
// liệt kê
function ns_dg_hopdong_P_LKE_CHO() {
    try {

        if (document.readyState === 'complete') {
            b_tt_phep = 0;
            b_vungId = form_Fs_VUNG_ID('UPa_ct');
            b_vungTkId = form_Fs_VUNG_ID('UPa_tk');
            b_grlkeId = form_Fs_VUNG_ID('GR_lke');
            b_so_theId = form_Fs_TEN_ID(b_vungId, 'SO_THE');
            b_ho_tenId = form_Fs_TEN_ID(b_vungId, 'ho_ten');
            b_ten_cdanhId = form_Fs_TEN_ID(b_vungId, 'ten_cdanh');
            b_ten_phongId = form_Fs_TEN_ID(b_vungId, 'ten_phong');
            b_ngaydId = form_Fs_TEN_ID(b_vungId, 'ngay_hl');
            b_ngaycId = form_Fs_TEN_ID(b_vungId, 'ngay_hhl');
            b_gio_bdId = form_Fs_TEN_ID(b_vungId, 'gio_bd');
            b_so_the_tkId = form_Fs_TEN_ID(b_vungTkId, 'so_the_tk');
            b_ten_tkId = form_Fs_TEN_ID(b_vungTkId, 'ten_tk');
            b_phong_tkId = form_Fs_TEN_ID(b_vungTkId, 'phong_tk');
            b_gchuId = form_Fs_VTEN_ID('', 'gchu');
            b_moiId = form_Fs_VTEN_ID('', 'moi');
            b_aphongId = form_Fs_VTEN_ID('UPa_hi', 'aphong');
            b_slideId = b_grlkeId + '_slide';
            lke_P_DAT($get(b_phong_tkId), 'TATCA' + '{' + 'Tất cả');
            form_F_GOC().P_MENUBf(window.name, 'M');
            vb_cctc_P_SL('', 'D', '0', ' ', ' ', 'T');
            b_ctyValue = "TATCA";
            ns_dg_hopdong_P_LKE('K');
            if (ns_dg_hopdong_lkeCho != 0)
                clearTimeout(ns_dg_hopdong_lkeCho);
            b_slideId = $get(b_grlkeId).getAttribute('slideId');
        }
    }
    catch (ex) {
        alert(ex);
    }
}

function ns_dg_hopdong_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId);
        var a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_so_the_tk = $get(b_so_the_tkId).value;
        var b_ten_tk = $get(b_ten_tkId).value;
        var b_phong_tk = lke_Fs_TRA($get(b_phong_tkId));
        sns_qt.Fs_NS_DG_HDLD_LKE(
            form_Fs_nsd(),
            b_so_the_tk,
            b_ten_tk,
            b_phong_tk,
            a_tso,
            a_cot,
            ns_dg_hopdong_P_LKE_KQ,
            P_LOI_CSDL,
            P_LOI_TGIAN
        );
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_dg_hopdong_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        return;
    }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
        if (lke_Fs_TRA($get(b_macc_nghiId)) != "")
            ns_dg_hopdong_SC();
        return false;
    }
    b_fcho = 'X';
}


// Lấy kiểu nghỉ sáng chiều
function ns_dg_hopdong_SC() {
    try {
        var b_kieunghi = lke_Fs_TRA($get(b_macc_nghiId));
        sns_qt.Fs_NS_DG_HDLD_SC(form_Fs_nsd(), b_kieunghi, ns_dg_hopdong_SC_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_dg_hopdong_SC_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        return;
    }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
// lấy thông tin ngày nghỉ
function ns_dg_hopdong_ngayphep() {
    try {
        var b_so_the = $get(b_so_theId).value;
        var b_ngayd = $get(b_ngaydId).value;
        sns_qt.Fs_NS_DG_HDLD_NGAY(form_Fs_nsd(), b_so_the, b_ngayd, ns_dg_hopdong_ngayphep_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_dg_hopdong_ngayphep_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        return;
    }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
function ns_dg_hopdong_phep_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        return;
    }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
// lấy thông tin cán bộ
function ns_dg_hopdong_TTCB() {
    try {
        var b_so_the = $get(b_so_theId).value;
        sns_qt.Fs_NS_DG_HDLD_HOPDONG(form_Fs_nsd(), b_so_the, ns_dg_hopdong_TTCB_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_dg_hopdong_TTCB_kq(b_kq) {
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
function ns_dg_hopdong_KT_NGAY(tungay, denngay, loai, ten1, ten2) {
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
function ns_dg_hopdong_Date(str) {
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
        case "months": return ((date2.getFullYear() * 12 + date2.getMonth()) - (date1.getFullYear() * 12 + date1.getMonth()));
        case "weeks": return Math.floor(timediff / week);
        case "days": return Math.floor(timediff / day);
        case "hours": return Math.floor(timediff / hour);
        case "minutes": return Math.floor(timediff / minute);
        case "seconds": return Math.floor(timediff / second);
        default: return undefined;
    }
}

function ns_dg_hopdong_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click();
    form_chay = 0;
    return false;
}
function ns_dg_hopdong_P_MAU() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'btn_excel_mau');
    $get(b_btn_excel).click();
    form_chay = 0;
    return false;

}
function ns_dg_hopdong_FILE_Import() {
    var b_tenf = '/App_form/ns/ma/file_Import.aspx';
    form_P_MO(
        b_tenf,
        window.name + ',THAMSO',
        ['THAMSO',
            [
                window.name,
                'THONGTIN_IMP',
                null,
                "Import thông tin nghỉ"
            ]
        ],
        null
    );
    form_P_LOI('');
    return false;
}

// Cập nhật trạng thái
function ns_dg_hopdong_P_Update() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        var b_ngayd = $get(b_ngaydId).value;
        if (b_hang < 1 || b_so_id == "") {
            form_P_LOI("Bạn phải chọn một bản ghi để hủy");
            ns_dg_hopdong_P_MOI();
            return false;
        }
        else {
            b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "huydon"));
            if (b_trangthai == '1') {
                form_P_LOI('loi:Bản ghi ghi đã bị hủy, bạn không thể hủy đơn này:loi');
                return false;
            }
            var a_cot = GridX_Fas_tenCot(b_grlkeId);
            var a_tso = slide_Faobj_TUDEN(b_slideId);
            var b_so_the_tk = $get(b_so_the_tkId).value;
            var b_ten_tk = $get(b_ten_tkId).value;
            var b_nam_tk = lke_Fs_TRA($get(b_nam_tkId));
            var b_kyluong = lke_Fs_TRA($get(b_kyluongId));
            var b_phong_tk = b_ctyValue;
            sns_qt.Fs_NS_DG_HDLD_UP(
                form_Fs_nsd(),
                b_so_id,
                b_so_the_tk,
                b_ten_tk,
                b_nam_tk,
                b_kyluong,
                b_phong_tk,
                "1",
                a_tso,
                a_cot,
                ns_dg_hopdong_Update_KQ,
                P_LOI_CSDL,
                P_LOI_TGIAN
            );
        }
        return false;
    }
    catch (err) {
        alert(err);
    }
}
function ns_dg_hopdong_Update_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        return;
    }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
        form_P_LOI("loi:Hủy đơn thành công:loi");
    }
    return false;
}
function ns_dg_hopdong_P_NAM() {
    try {
        var b_nam = form_Fs_TEN_GTRI(b_vungTkId, 'NAM');
        if (b_nam != "")
            stl_cc.Fs_NS_KYLUONG_CHUNG2_LKE(form_Fs_nsd(), window.name, b_nam, ns_dg_hopdong_P_NAM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) {
        form_P_LOI(ex.message);
    }
}
function ns_dg_hopdong_P_NAM_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq))
        form_P_LOI(b_kq);
    else {
        ns_dg_hopdong_P_KTRA("KYLUONG");
    }
}
// tinh ngày
function tinh_ngay() {
    try {
        var b_ma_nghi = lke_Fs_TRA($get(b_macc_nghiId));
        sns_qt.Fs_NS_DG_HDLD_LOAI(form_Fs_nsd(), b_ma_nghi, tinh_ngay_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function tinh_ngay_KQ(b_kq) {
    try {
        var b_ngayd = $get(b_ngaydId).value;
        var b_ngayc = $get(b_ngaycId).value;
        if (b_ngayd != "" && b_ngayc != "") {
            var b_gio_bd = $get(b_gio_bdId).value;
            var b_gio_kt = $get(b_gio_ktId).value;
            b_ngayd = b_ngayd.substring(3, 5) + "/" + b_ngayd.substring(0, 2) + "/" + b_ngayd.substring(6, 10);
            b_ngayc = b_ngayc.substring(3, 5) + "/" + b_ngayc.substring(0, 2) + "/" + b_ngayc.substring(6, 10);
            var ngay = mydiff(b_ngayd, b_ngayc, "days");
            if (b_gio_bd == "2HD")
                ngay = ngay - 0.75;
            if (b_gio_bd == "NC")
                ngay = ngay - 0.5;
            if (b_gio_kt == "CN")
                ngay = ngay + 1;
            if (b_gio_kt == "ND")
                ngay = ngay + 0.5;
            if (b_gio_kt == "2HC")
                ngay = ngay + 0.25;
        } else
            if (b_ngayd != "" && b_ngayc == "") {
                $get(b_ngaynghi).value = 1;
                return false;
            }

        if (ngay == undefined) {
            $get(b_ngaynghi).value = "";
            return false;
        }
        if (b_kq == "1") {
            $get(b_ngaynghi).value = ngay;
        } else
            if (b_kq == "0.5") {
                $get(b_ngaynghi).value = parseFloat(ngay / 2).toFixed(1);
            }
        $get(b_truphepnam).value = $get(b_ngaynghi).value
    }
    catch (err) {
        form_P_LOI(err);
    }
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
        ns_dg_hopdong_P_LKE('K');
        $get(b_aphongId).value = b_ctyValue;
        $get(b_akyluongId).value = lke_Fs_TRA($get(b_kyluongId));
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
function form_dong() {
    location.reload(false);
}