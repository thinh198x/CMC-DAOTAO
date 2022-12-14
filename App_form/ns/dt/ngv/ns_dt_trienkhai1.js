var ns_dt_trienkhai_lkeCho, b_vungId, b_grlkeId, b_ngaydId, b_ngaycId, b_vungTkId, ns_dt_trienkhai_choAct = 0, b_slideId, b_gocId, b_sothe_tnId,
     b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C',
    b_tenId, b_tuoiId, b_so_idId, b_gchuId, b_moiId, b_nsd, b_ten, b_phong_tkId, b_kdtId, b_kyluongTKId, b_ngaydkyId, b_giodId, b_namId, b_namTKId, b_giocId, b_sophutId;
function ns_dt_trienkhai_P_KD(nsd) {
    b_nsd = nsd;
    ns_dt_trienkhai_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungTkId = form_Fs_VUNG_ID('UPa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
    b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE'); b_ngaydkyId = form_Fs_TEN_ID(b_vungId, 'ngay_gt');
    b_so_theId = form_Fs_TEN_ID(b_vungId, 'so_the');
    b_giodId = form_Fs_TEN_ID(b_vungId, 'giod'); b_giocId = form_Fs_TEN_ID(b_vungId, 'gioc');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu2'); b_namId = form_Fs_TEN_ID(b_vungId, 'nam'); b_namTKId = form_Fs_TEN_ID(b_vungTkId, 'nam_tk');
    b_so_idId = form_Fs_VTEN_ID('', 'so_id'); b_phong_tkId = form_Fs_TEN_ID(b_vungTkId, 'PHONG');
    b_kyluongTKId = form_Fs_TEN_ID(b_vungTkId, 'KYLUONG_TK');
    b_slideId = b_grlkeId + '_slide';
    lke_P_DAT($get(b_phong_tkId), 'TATCA' + '{' + 'Tất cả');
    ns_dt_trienkhai_lkeCho = setInterval('ns_dt_trienkhai_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "" || a_tso[0] == "FILE_HTOAN") return;
        b_dtuong = b_dtuong.toUpperCase();
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            $get(b_gocId).value = b_kq;
            ns_dt_trienkhai_P_CB();
            $get(b_gchuId).innerHTML = a_tso[1];
            ns_dt_trienkhai_P_LKE('K');
            $get(b_gocId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}
function ns_dt_trienkhai_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; form_P_MOI("", "XGL"); break;
            case "LOAI_DKY": b_maId = b_loaidkyId; break;
            case "NGAY_DKY": b_maId = b_ngaydkyId; break;
            case "GIOD": b_maId = b_giodId; break;
            case "GIOC": b_maId = b_giocId; break;
            case "NAM": b_maId = b_namId; form_P_MOI("", "T"); break;
            case "NAM_TK": b_maId = b_namTKId; form_P_MOI("", "T"); break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_dt_trienkhai_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_dt_trienkhai_P_CB();
            ns_dt_trienkhai_P_LKE('K');
        }
        else if (b_maTen == "GIOD" || b_maTen == "GIOC") {
            if (b_maTen == "GIOD") {
                if (!isTime(b_ma)) {
                    form_P_LOI("loi:Giờ vào không đúng định dạng!:loi");
                    return false;
                }
            } else if (b_maTen == "GIOC") {
                if (!isTime(b_ma)) {
                    form_P_LOI("loi:Giờ ra không đúng định dạng!:loi");
                    return false;
                }
            }
            var b_giobd = $get(b_giodId).value, b_giokt = $get(b_giocId).value;
        }
        else if (b_maTen == "NAM") {
            var b_nam = form_Fs_TEN_GTRI(b_vungId, 'NAM'); form_P_MOI("", "N");
            hts_dungchung.Fs_NS_KT_NAM(window.name, b_nam);
        }
        else if (b_maTen == "NAM_TK") {
            var b_nam = form_Fs_TEN_GTRI(b_vungTkId, 'NAM_TK'); form_P_MOI("", "N");
            hts_dungchung.Fs_NS_KT_NAM_TK(window.name, b_nam);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_trienkhai_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}
// Nhập
function ns_dt_trienkhai_P_MOI() {
    form_P_MOI(b_vungId, "GXLMN");
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = "0";
    $get(b_giodId).value = "";
    $get(b_giocId).value = "";
    $get(b_gocId).focus();
    return false;
}
function ns_dt_trienkhai_P_NH() {
    var b_dt_ct = GridX_Fdt_cotGtri(b_grlkeId);
    sns_dt.Fs_NS_DT_TRIENKHAI_NH(b_dt_ct, ns_dt_trienkhai_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_dt_trienkhai_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_LOI("loi:triển khai thành công:loi");
    GridX_datTrang(b_grlkeId);
    ns_dt_trienkhai_P_LKE('K');
    return false;
}
// Xóa
function ns_dt_trienkhai_P_XOA() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
        var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"),
            b_so_the = $get(b_gocId).value;
        if (b_so_id == "") { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); ns_dt_trienkhai_P_MOI(); return false; }
        else {
            var b_trangthai = form_Fs_TEN_GTRI(b_vungTkId, 'trangthai_tk');
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            var b_kyluong = form_Fs_TEN_GTRI(b_vungTkId, 'KYLUONG_TK');
            var b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tt"));
            if (b_trangthai == "")
                sns_dt.Fs_NS_GT_CC_XOA(form_Fs_nsd(), b_so_id, b_so_the, b_kyluong, "", a_tso, a_cot, ns_dt_trienkhai_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            else
                form_P_LOI("loi:Đăng ký đã được gửi hoặc phê duyệt:loi");
        }
    }
    catch (err) { throw (err); }
    return false;
}
function ns_dt_trienkhai_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dt_trienkhai_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dt_trienkhai_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
    return false;
}
// CHuyển hàng
function ns_dt_trienkhai_GR_lke_RowChange() {
    if (ns_dt_trienkhai_choAct != 0) clearTimeout(ns_dt_trienkhai_choAct);
    ns_dt_trienkhai_choAct = setTimeout("ns_dt_trienkhai_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_dt_trienkhai_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "") form_P_MOI(b_vungId, "XGLMN");
    //else sns_dt.Fs_NS_GT_CC_CT(form_Fs_nsd(), window.name, b_so_id, ns_dt_trienkhai_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = b_so_id;
}
function ns_dt_trienkhai_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    return false;
}
// Liệt kê
function ns_dt_trienkhai_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        $get(b_gocId).value = b_nsd;
        if (ns_dt_trienkhai_lkeCho != 0) clearTimeout(ns_dt_trienkhai_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_dt_trienkhai_P_LKE();
        ns_dt_trienkhai_P_CB();
    }
}
function ns_dt_trienkhai_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.Fs_NS_DT_TRIENKHAI_LKE(form_Fs_nsd(), a_tso, a_cot, ns_dt_trienkhai_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_trienkhai_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    b_fcho = 'X';
}
function ns_dt_trienkhai_P_CB() {
    try {
        var b_so_the = $get(b_so_theId).value;
        hts_dungchung.Fs_THONGTIN_CANBO(b_so_the, ns_dt_trienkhai_P_CB_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_trienkhai_P_CB_kq(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == "") { form_P_LOI("loi:Nhân viên chưa được làm quyết đinh.:loi"); $get(b_gocId).value = ""; return false; }
    form_P_CH_TEXT(b_vungId, b_kq);
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
function ns_dt_trienkhai_P_CT() {
    var b_ngaydky = $get(b_ngaydkyId).value;
    var b_loaidky = $get(b_loaidkyId).value;
    if (b_ngaydky == "" || b_ngaydky == null || b_loaidky == "" || b_loaidky == null) { form_P_MOI("", "XGL"); return; }
    else sns_dt.Fs_NS_GT_CC_CT2(form_Fs_nsd(), b_ngaydky, b_loaidky, ns_dt_trienkhai_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = b_so_id;
}
function ns_dt_trienkhai_GIO() {
    try {
        var b_giobd = $get(b_giodId).value, b_giokt = $get(b_giocId).value;
        sns_dt.Fs_KIEMTRA_PHUT(b_giobd, b_giokt, ns_dt_trienkhai_GIO_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_trienkhai_GIO_kq(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    if (b_kq != "") $get(b_sophutId).value = b_kq;
}
function ns_dt_trienkhai_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function ns_dt_trienkhai_P_MAU() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'btn_excel_mau');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function ns_dt_trienkhai_FILE_Import() {
    var b_tenf = '/App_form/ns/ma/file_Import.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "DKY_DMVS_IMP", "DKY_DMVS_IMP", "Import đăng ký đi muộn về sớm"]], null);
    form_P_LOI('');
    return false;
}
function ns_dt_trienkhai_kdt_P() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("loi:Bạn chưa chọn năm:loi"); return false; }
    var b_kdt = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "kdt")), b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "trangthai")),
        b_lop_hoc = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma_lop"));
    var b_so_id = $get(b_so_idId).value;
    var b_tenf = '/App_form/ns/dt/ngv/ns_dt_trienkhai_kdt.aspx';
    form_P_MO(b_tenf, window.name + ',THAMSO', ['THAMSO', [window.name, "Triển khai khóa đào tạo", b_so_id, b_kdt, b_lop_hoc, b_trangthai]], null);
    form_P_LOI('');
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
function ns_dt_trienkhai_P_GUI() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) { form_P_LOI("loi:Chưa chọn đăng ký cần gửi:loi"); return false; }
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "") { form_P_LOI("loi:Chưa chọn đăng ký cần gửi:loi"); return false; }
        var b_so_the = $get(b_so_theId).value, a_cot = GridX_Fas_tenCot(b_grlkeId)
        var b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tt"));
        if (b_trangthai == "CG")
            sns_dt.Fs_NS_GT_CC_GUI(form_Fs_nsd(), b_so_id, ns_dt_trienkhai_GUI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        else
            form_P_LOI("loi:Đăng ký đã được gửi hoặc phê duyệt:loi");
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_trienkhai_GUI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else form_P_LOI("loi:Gửi phê duyệt thành công:loi");
    ns_dt_trienkhai_P_LKE('K');
    return false;
}