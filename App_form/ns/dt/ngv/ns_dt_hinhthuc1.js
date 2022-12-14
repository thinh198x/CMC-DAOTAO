var ns_dt_hinhthuc_lkeCho, b_vungId, b_gchuId, ns_dt_hinhthuc_choAct = 0, b_grctId,b_grlkeId, b_slideId, b_vungtkId, b_so_idId,
    b_cho_control = 0, b_namId, b_tenId, b_cdanhId, b_phongId, b_ngay_gdId, b_thoi_gian_gdId, b_tu_gioId, b_den_gioId, b_noidungId,
    b_MA_HV_tk, b_nam_tkId;
function ns_dt_hinhthuc_P_KD() {
    ns_dt_hinhthuc_lkeCho = setInterval('ns_dt_hinhthuc_P_LKE_CHO()', 200);
}
function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_namId).value = b_so_the;
            $get(b_gchuId).innerHTML = b_ten;
            $get(b_namId).focus();
            ns_dt_hinhthuc_P_LKE('K');
            b_doi = 1;
            clearTimeout(b_cho_control);
        }
    }
    catch (err) { b_doi = 0; }
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
        }
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            $get(b_tenId).value = b_kq; 
            ns_dt_hinhthuc_P_CB();
        }
        else if (b_dtuong.indexOf("MA_HV") >= 0) { 
            ns_dt_hinhthuc_TTCB(b_kq);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_hinhthuc_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_t = b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_tenId; form_P_MOI("", "XGL"); break;
            case "TU_GIO": b_maId = b_tu_gioId; break;
            case "DEN_GIO": b_maId = b_den_gioId; break;
            case "THOI_GIAN_GD": b_maId = b_thoi_gian_gdId; break;
        }
        b_chonId = b_maTen;
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        else if (b_maTen == "SO_THE") {
            ns_dt_hinhthuc_P_CB();
        }
        else if (b_maTen == "TU_GIO") {
            if (!isTime(b_ma)) {
                form_P_LOI("loi:Từ giờ không đúng định dạng!:loi");
                return false;
            } 
        }
        else if (b_maTen == "DEN_GIO") {
            if (!isTime(b_ma)) {
                form_P_LOI("loi:Đến giờ không đúng định dạng!:loi"); 
                return false;
            }
        }
        else if (b_maTen == "THOI_GIAN_GD") {
            var b_thoigian=CSO_SO($get(b_thoi_gian_gdId).value);
            if(b_thoigian>8)
            {
                $get(b_thoi_gian_gdId).value = '';
                form_P_LOI("loi:Thời hạn đào tạo không quá 8h!:loi");
                return false;
            }
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_dt_hinhthuc_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
    }
    else { form_P_DatGchu(b_gchuId, b_kq); }
}
function ns_dt_hinhthuc_P_MOI() {
    form_P_MOI(b_vungId, "GXLK");
    GridX_thoiA(b_grlkeId);
    GridX_datBang(b_grctId, "");
    $get(b_namId).focus();
    return false;
}
function ns_dt_hinhthuc_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }

        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        var b_nam = $get(b_nam_tkId).value;
        a_cot_ct = GridX_Fdt_cotGtri(b_grctId);
        var b_thoigian = CSO_SO($get(b_thoi_gian_gdId).value);
        if (b_thoigian > 8) {
            $get(b_thoi_gian_gdId).value = '';
            form_P_LOI("loi:Thời hạn đào tạo không quá 8h!:loi");
            return false;
        }
        sns_dt.Fs_NS_DT_HINHTHUC_NH(form_Fs_nsd(), b_so_id, b_nam, b_TrangKt, a_dt_ct, a_cot_lke, a_cot_ct, ns_dt_hinhthuc_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { throw (err); }
}
function ns_dt_hinhthuc_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        form_P_LOI("loi:Nhập thành công!:loi");
    }
    return false;
}
function ns_dt_hinhthuc_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1) { form_P_LOI("loi:Chọn bản ghi:loi"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    var b_ma_hv = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma_hv");
    if (b_so_id == "") { form_P_LOI("loi:Chọn bản ghi:loi"); ns_dt_hinhthuc_P_MOI(); return false; }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_nam = $get(b_nam_tkId).value;
        sns_dt.Fs_NS_DT_HINHTHUC_XOA(form_Fs_nsd(), b_so_id, b_nam,b_ma_hv, a_tso, a_cot, ns_dt_hinhthuc_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_dt_hinhthuc_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dt_hinhthuc_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dt_hinhthuc_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
    return false;
}
//Chuy?n hàng
function ns_dt_hinhthuc_GR_lke_RowChange() {
    if (ns_dt_hinhthuc_choAct != 0) clearTimeout(ns_dt_hinhthuc_choAct);
    ns_dt_hinhthuc_choAct = setTimeout("ns_dt_hinhthuc_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_dt_hinhthuc_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var a_cot_ct = GridX_Fas_tenCot(b_grctId);
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "0" || b_so_id == "") { form_P_MOI(b_vungId, "XGL"); }
    else sns_dt.Fs_NS_DT_HINHTHUC_CT(form_Fs_nsd(), b_so_id, a_cot_ct, ns_dt_hinhthuc_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function ns_dt_hinhthuc_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == '') return;
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    GridX_datBang(b_grctId, a_kq[1]);
    return false;
}
//Li?t kê
function ns_dt_hinhthuc_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ns_dt_hinhthuc_lkeCho != 0) clearTimeout(ns_dt_hinhthuc_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'),
        b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_grctId = form_Fs_VUNG_ID('GR_ct');
        b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
        b_vungtkId = form_Fs_VUNG_ID('UPa_tk'),
        b_namId = form_Fs_TEN_ID(b_vungId, 'nam'),
        b_tenId = form_Fs_TEN_ID(b_vungId, 'so_the'),
        b_cdanhId = form_Fs_TEN_ID(b_vungId, 'cdanh'),
        b_phongId = form_Fs_TEN_ID(b_vungId, 'ten_phong'),
        b_ngay_gdId = form_Fs_TEN_ID(b_vungId, 'ngay_gd'),
        b_thoi_gian_gdId = form_Fs_TEN_ID(b_vungId, 'thoi_gian_gd'),
        b_tu_gioId = form_Fs_TEN_ID(b_vungId, 'tu_gio'), b_den_gioId = form_Fs_TEN_ID(b_vungId, 'den_gio'),
        b_noidungId = form_Fs_TEN_ID(b_vungId, 'noidung');
        b_nam_tkId = form_Fs_TEN_ID(b_vungtkId, 'nam_tk');
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_dt_hinhthuc_P_LKE('K');
    }
}
function ns_dt_hinhthuc_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_nam = $get(b_nam_tkId).value;
        sns_dt.Fs_NS_DT_HINHTHUC_LKE(form_Fs_nsd(), b_nam, a_tso, a_cot, ns_dt_hinhthuc_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
// hàm bổ sung khác
function ns_dt_hinhthuc_P_CB() {
    try {
        var b_so_the = $get(b_tenId).value;
        hts_dungchung.Fs_THONGTIN_CANBO(b_so_the, ns_dt_hinhthuc_P_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_hinhthuc_P_CB_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
function ns_dt_hinhthuc_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
//
function ns_dt_hinhthuc_TTCB(b_so_the) {
    try {
        hts_dungchung.Fs_THONGTIN_CANBO_LUOI(b_so_the, ns_dt_hinhthuc_TTCB_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_hinhthuc_TTCB_kq(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var a_kq = Fas_ChMang(b_kq, '#');
    if (a_kq != "") {
        var b_hang = GridX_Fi_timHangA(b_grctId),b_thoi_gian_hoc=$get(b_thoi_gian_gdId).value;
        GridX_datGtri(b_grctId, b_hang, "ma_hv", a_kq[1], 'K');
        GridX_datGtri(b_grctId, b_hang, "ten_hv", a_kq[2], 'K');
        GridX_datGtri(b_grctId, b_hang, "ten_donvi", a_kq[4], 'K');
        GridX_datGtri(b_grctId, b_hang, "donvi", a_kq[5], 'K');
        GridX_datGtri(b_grctId, b_hang, "thoi_gian_hoc", b_thoi_gian_hoc, 'K');
        //ns_dt_hinhthuc_ChenDong('C');

    }
    return false;
}
function ns_dt_hinhthuc_ChenDong(b_dk) {
    if (C_NVL(b_dk) == 'C') {
        var b_dong = GridX_Fi_hangKt(b_grctId);
        //GridX_P_hangKt(b_grctId, b_dong + 1);
        GridX_chenHang(b_grctId);
    }
    return false;
}
//
function ns_dt_hinhthuc_P_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grctId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        var b_ktra = C_NVL(b_ctr.ktra), b_ten = C_NVL(b_ctr.ten);
        if (b_value != "") GridX_ThemHang(b_grctId);
        if (b_value != "") {
            if (b_cot == "MA_HV") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Mã cán bộ", b_value, "ns_cb,so_the,ten", ns_dt_hinhthuc_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        if (b_value != "") GridX_ThemHang(b_grctId);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_hinhthuc_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        var b_hang = GridX_Fi_timHangA(b_grctId);
        form_P_LOI(b_kq);
        GridX_datGtri(b_grctId, b_hang, "ma_hv","", 'K'); 
        return false;
    }
    $get(b_gchuId).innerHTML = b_kq;
    return false;
}
//Ki?m tra ngày tháng
function ns_dt_hinhthuc_P_NGAY(str) {
    var mdy_str = str.split('/');
    var mdy_str = mdy_str[2] + mdy_str[1] + mdy_str[0];
    var mdy_str = parseInt(mdy_str);
    var dateht = new Date();
    var m = "0" + (1 + dateht.getMonth());
    var y = parseInt("2" + dateht.getYear()) - 100;
    var d = parseInt("0" + dateht.getDate());
    var dmy = y + m + d;
    var dmy = parseInt(dmy);
    var kq = mdy_str - dmy;
    if (kq > 0) {
        return 'loi:Ngày c?p không du?c l?n hon ngày hi?n t?i:loi';
    }
    return "";
}
//function ns_dt_hinhthuc_P_Update() {
//    try {
//        return false;
//        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grlkePCId);
//        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
//        var b_ktra = C_NVL(b_ctr.ktra), b_ten = C_NVL(b_ctr.ten); 
//        if (b_value != "") GridX_ThemHang(b_grctId);
//        return false;
//    }
//    catch (err) { form_P_LOI(err); }
//}
function ns_dt_hinhthuc_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
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
function ns_dt_hinhthuc_HangLen(mode) {
    var b_grct;
    if (mode == 1) b_grct = b_grctId;
    if (mode == 2) b_grct = b_grlvchaId;
    GridX_chuyenHang(b_grct, -1);
    return false;
}
function ns_dt_hinhthuc_HangXuong(mode) {
    var b_grct;
    if (mode == 1) b_grct = b_grctId;
    if (mode == 2) b_grct = b_grlvchaId;
    GridX_chuyenHang(b_grct, 1);
    return false;
}
function ns_dt_hinhthuc_CatDong(mode) {
    var b_grct;
    if (mode == 1) {
        b_grct = b_grctId;
    }
    else if (mode == 2) {
        b_grct = b_grlvchaId;
    }
    else return false;
    GridX_boChon(b_grct, 'C');
    return false;
}
function ns_dt_hinhthuc_ChenDong(b_dk) {
    var b_ktrahten = C_NVL(GridX_Fas_layGtriA(b_grctId, 'ma_hv'));
    if (b_ktrahten == '') form_P_LOI("loi:Chọn dòng dữ liệu cần chèn thêm một hàng trước nó trên bảng Thông tin người liên hệ:loi");
    else {
        GridX_chenHang(b_grctId);
    }
    return false;
}
function pad(s) { return (s < 10) ? '0' + s : s; }
function ktra_ngay(tungay, denngay, loai, ten1, ten2) {
    if (denngay == "" || denngay == null) {
        return "";
    }
    if (loai == 1 && tungay > denngay) {
        return "loi: " + ten1 + " không du?c l?n hon " + ten2 + " :loi";
    } else if (loai == 2 && tungay >= denngay) {
        return "loi: " + ten1 + " không du?c l?n hon ho?c b?ng " + ten2 + " :loi";
    }
    return "";
}
function parseDate(str) {
    var mdy = str.split('/');
    return new Date(mdy[2], mdy[1], mdy[0]);
}
function getDateNow() {
    var today = new Date();
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
function form_dong() {
    location.reload(false);
}