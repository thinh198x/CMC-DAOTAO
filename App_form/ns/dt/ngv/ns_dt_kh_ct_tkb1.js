var ns_dt_kh_ct_tkb_lkeCho, ns_dt_kh_ct_tkb_gchuCho, b_vungId, b_vungtkId, b_grlkeId, b_slideId, b_gchuId, b_dr_ngayId, b_doi_ngayId, b_ngayId, b_so_id_gvId,
    b_thluongId, b_gio_dId, b_gio_cId, b_so_id_kh, b_so_idId, b_gvienId, b_loai_gvId, b_tt_pd, b_taoNgayMoi = false, b_nsd, ns_dt_kh_ct_tkb_choAct = 0;
function ns_dt_kh_ct_tkb_P_KD() {
    b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtkId = form_Fs_VUNG_ID('UPa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
    b_slideId = b_grlkeId + '_slide';
    b_dr_ngayId = form_Fs_TEN_ID(b_vungtkId, 'dr_ngay');
    b_doi_ngayId = form_Fs_VTEN_ID('', 'doi_ngay');
    b_ngayId = form_Fs_TEN_ID(b_vungId, 'NGAY');
    b_so_id_gvId = form_Fs_TEN_ID(b_vungId, 'SO_ID_GV');
    b_gvienId = form_Fs_TEN_ID(b_vungId, 'gvien');
    b_loai_gvId = form_Fs_TEN_ID(b_vungId, 'loai_gv');
    b_thluongId = form_Fs_TEN_ID(b_vungId, 'thluong');
    b_gio_dId = form_Fs_TEN_ID(b_vungId, 'GIO_D');
    b_gio_cId = form_Fs_TEN_ID(b_vungId, 'GIO_C');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_gchuId = form_Fs_VTEN_ID('UPa_gchu', 'gchu');   
    b_nsd = form_Fs_nsd();
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
        }
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            b_so_id_kh = a_tso[1];
            var b_ttin_kdtId = form_Fs_VTEN_ID('', 'ttin_kdt');
            $get(b_ttin_kdtId).innerHTML = a_tso[2] + " - " + a_tso[3];

            b_tt_pd = a_tso[4];  
            var ttpd = "Chưa gửi phê duyệt";
            switch (b_tt_pd) {
                case 1:
                    ttpd = "Chờ phê duyệt";
                    break;
                case 2:
                    ttpd = "Được phê duyệt";
                    break;
                case 3:
                    ttpd = "Không phê duyệt";
                    break;
                default:
                    break;
            }
            ns_dt_kh_ct_tkb_P_DatGchu(false, ttpd);

            ns_dt_kh_ct_tkb_P_NGAY_LKE();
        }
        else if (b_dtuong.indexOf("GVIEN") >= 0) {
            $get(b_so_id_gvId).value = a_tso[0];
            $get(b_gvienId).value = a_tso[1];
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_kh_ct_tkb_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "NGAY": b_maId = b_ngayId; break;
            case "GVIEN": b_maId = b_gvienId; break;
            case "GIO_D": b_maId = b_gio_dId; break;
            case "GIO_C": b_maId = b_gio_cId; break;
            case "THLUONG": b_maId = b_thluongId; break;
            case "LOAI_GV": b_maId = b_loai_gvId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "NGAY") {
            var dr_ngay = form_Fctr_TEN_DTUONG(b_vungtkId, 'dr_ngay');
            var a_lke = Fas_ChMang(dr_ngay.getAttribute('traAn'));
            lke_P_DAT(dr_ngay, b_ma.value + '{' + b_ma.value);
            //var b_ngay = lke_Fs_TRA(form_Fs_TEN_ID(b_vungtkId, 'dr_ngay'));
            //lke_P_VTRI_KQ();
            //var b_index = lke_P_DAT(b_dr_ngayId, b_ma.value);// drop_P_LKE_DAT_GIATRI(b_dr_ngayId, b_ma.value); // tìm trong dr ngày có ko, có thì lấy ds TKB, ko có thì xóa grd
            //if (b_ngay == "") {
            //    GridX_datTrang(b_grlkeId);
            //    $get(b_dr_ngayId).value = null;
            //    //$get(b_so_idId).value = 0;
            //    var b_ngay = b_ma.value;
            //    ns_dt_kh_ct_tkb_P_MOI(false);
            //    $get(b_ngayId).value = b_ngay;
            //    b_taoNgayMoi = true;
            //}
            //else {
            //    b_taoNgayMoi = false;
            //    ns_dt_kh_ct_tkb_P_LKE();
            //}
            return true;
        }
        else if (b_maTen == "GVIEN") {
            // lấy thông tin giảng viên
            var b_loaigv = $get(b_loai_gvId).value;
            if (b_loaigv == "NB") ns_thongtin_canbo(C_NVL(b_ma.value));
            else alert("Lay gv ngoai");
            return true;
        }
        else if (b_maTen == "THLUONG") {
            var b_thluong = CSO_SO(b_ma.value);
            if (checkThoiLuong()) {
                return checkHour();
            }
            else
                return false;
        }
        else if (b_maTen == "GIO_D" || b_maTen == "GIO_C") {
            if (isTime(b_ma)) {
                if (checkTime())
                    return checkHour();
                else
                    return false;
            }
            else {
                form_P_LOI("loi:Dữ liệu thời gian không hợp lệ:loi");
                return false;
            }
        }
        else if (b_maTen == "LOAI_GV") {
            var b_f_tkhao, b_ktra;
            if (b_ma.value == "NB") {

                b_f_tkhao = "/App_form/ns/tt/ns_cb.aspx";
                b_ktra = "NS_CB,ma,ten";
            }
            else {
                b_f_tkhao = "/App_form/ns/dt/dm/ns_dt_ma_gv_ngoai.aspx";
                b_ktra = "";//"ns_dt_ma_gv_ngoai,ma,ten";
            }

            $get(b_gvienId).setAttribute("f_tkhao", b_f_tkhao);
            $get(b_gvienId).setAttribute("ktra", b_ktra);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_kh_ct_tkb_P_MOI(datNgay) {
    form_P_MOI(b_vungId, "XL");
    $get(b_so_idId).value = 0;
    // dien gtri ngay dr -> ngay nhap
    if (datNgay)
        $get(b_ngayId).value = $get(b_dr_ngayId).value;
    return false;
}
function ns_dt_kh_ct_tkb_P_NH() {
    if (b_tt_pd != 0) {
        form_P_LOI("loi:Không thao tác được do đã gửi phê duyệt:loi");
        return false;
    }
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        if (!checkThoiLuong() || !checkTime() || !checkHour())
            return false;

        var b_so_id = $get(b_so_idId).value;
        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        sns_dt.Fs_NS_DT_KH_CT_TKB_NH(b_nsd, b_so_id, b_so_id_kh, b_TrangKt, a_dt_ct, a_cot, ns_dt_kh_ct_tkb_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
    return false;
}
function ns_dt_kh_ct_tkb_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        ns_dt_kh_ct_tkb_P_DatGchu(true, "loi:Ghi thành công:loi");
    }
    return false;
}
function ns_dt_kh_ct_tkb_P_XOA() {
    if (b_tt_pd != 0) {
        form_P_LOI("loi:Không thao tác được do đã gửi phê duyệt:loi");
        return false;
    }
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_hang < 1 || b_loi.length > 0) {
            form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi");
            return false;
        }
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "") {
            form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi");
            ns_dt_kh_ct_tkb_P_MOI(true);
        }
        else {
            var b_ngay = CNG_SO($get(b_dr_ngayId).value);
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            sns_dt.Fs_NS_DT_KH_CT_TKB_XOA(b_nsd, b_so_id_kh, b_ngay, b_so_id, a_tso, a_cot, ns_dt_kh_ct_tkb_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
    return false;
}
function ns_dt_kh_ct_tkb_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
        var b_dong = CSO_SO(a_kq[2], 0);
        if (b_hang > b_dong) b_hang = b_dong;
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) {
            ns_dt_kh_ct_tkb_P_MOI(true);
            $get(b_dr_ngayId).value = null;
            ns_dt_kh_ct_tkb_P_NGAY_LKE();
        }
        else {
            GridX_datA(b_grlkeId, b_hang);
            ns_dt_kh_ct_tkb_P_CHUYEN_HANG();
        }
        ns_dt_kh_ct_tkb_P_DatGchu(true, "loi:Xóa thành công:loi");
    }
}
function ns_dt_kh_ct_tkb_GR_lke_RowChange() {
    if (ns_dt_kh_ct_tkb_choAct != 0) clearTimeout(ns_dt_kh_ct_tkb_choAct);
    ns_dt_kh_ct_tkb_choAct = setTimeout("ns_dt_kh_ct_tkb_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_dt_kh_ct_tkb_P_NGAY_LKE() {
    try {
        sns_dt.Fs_NS_DT_KH_CT_TKB_NGAY_LKE(b_nsd, b_so_id_kh, ns_dt_kh_ct_tkb_P_NGAY_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_kh_ct_tkb_P_NGAY_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    ns_dt_kh_ct_tkb_P_LKE();
}
function ns_dt_kh_ct_tkb_P_DR_CHANGE() {
    ns_dt_kh_ct_tkb_P_LKE();
}
function checkThoiLuong() {
    var b_thluong = C_NVL($get(b_thluongId).value);
    if (b_thluong == "") return true;

    b_thluong = CSO_SO(b_thluong);
    if (b_thluong == 0 || b_thluong > 24) {
        form_P_LOI("loi:Thời lượng đào tạo không hợp lệ (= 0 hoặc quá 24 giờ):loi");
        return false;
    }
    else
        return true;
}
function checkTime() {
    var b_gio_d = CSO_SO($get(b_gio_dId).value.replace(":", ""));
    var b_gio_c = CSO_SO($get(b_gio_cId).value.replace(":", ""));
    if (C_NVL($get(b_gio_dId).value) != "" && C_NVL($get(b_gio_cId).value) != "" && b_gio_c <= b_gio_d) {
        form_P_LOI("loi:Giờ kết thúc không được nhỏ hơn hoặc bằng giờ bắt đầu:loi");
        return false;
    }
    return true;
}
function checkHour() {
    var b_thluong = CSO_SO($get(b_thluongId).value);
    if (b_thluong == 0) return true;

    var b_gio_d = $get(b_gio_dId).value;
    var b_gio_c = $get(b_gio_cId).value;
    if (b_gio_d != "" && b_gio_c != "") {
        var a_gio_d = b_gio_d.split(":"), a_gio_c = b_gio_c.split(":");
        var b_gio_dN = CSO_SO(a_gio_d[0]) * 60 + CSO_SO(a_gio_d[1]);
        var b_gio_cN = CSO_SO(a_gio_c[0]) * 60 + CSO_SO(a_gio_c[1]);
        var b_minute = b_gio_cN - b_gio_dN;
        if (b_minute < b_thluong * 60) {
            form_P_LOI("loi:Thời lượng đào tạo vượt quá khung giờ đào tạo:loi");
            return false;
        }
        else
            return true;
    }
    else return true;
}
function drop_P_LKE_DAT_GIATRI(drId, gtri) {
    var b_dr = $get(drId);
    b_dr.selectedIndex = -1;
    var index = -1;
    for (var i = 0; i < b_dr.options.length; i++) {
        if (b_dr.options[i].value == gtri) {
            b_dr.selectedIndex = i;
            index = i;
            break;
        }
    }
    return index;
}
function ns_thongtin_canbo(b_so_the) {
    try {
        hts_dungchung.Fs_THONGTIN_CANBO_LUOI(b_so_the, ns_thongtin_canbo_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_thongtin_canbo_kq(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        return false;
    }
    var a_kq = Fas_ChMang(b_kq, '#');
    $get(b_so_id_gvId).value = a_kq[0];
    $get(b_gvienId).value = a_kq[2];   
    return false;
}
function ns_dt_kh_ct_tkb_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "") {
            ns_dt_kh_ct_tkb_P_MOI(true);
        }
        else {
            // lay chi tiet noi dung TKB
            $get(b_so_idId).value = b_so_id;
            sns_dt.Fs_NS_DT_KH_CT_TKB_CT(b_nsd, b_so_id, ns_dt_kh_ct_tkb_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_kh_ct_tkb_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
function ns_dt_kh_ct_tkb_P_LKE() {
    try {
        var b_ngay = lke_Fs_TRA(form_Fs_TEN_ID(b_vungtkId, 'dr_ngay'));
        if (b_ngay != null && b_ngay != '') {
            $get(b_ngayId).value = b_ngay;
            b_ngay = CNG_SO(b_ngay);
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            sns_dt.Fs_NS_DT_KH_CT_TKB_LKE(b_nsd, b_so_id_kh, b_ngay, a_tso, a_cot, ns_dt_kh_ct_tkb_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            ns_dt_kh_ct_tkb_P_MOI(true);
        }
        else {
            GridX_datTrang(b_grlkeId);
            ns_dt_kh_ct_tkb_P_MOI(false);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_kh_ct_tkb_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_dt_kh_ct_tkb_P_DOI_NGAY() {
    if (b_tt_pd != 0) {
        form_P_LOI("loi:Không thao tác được do đã gửi phê duyệt:loi");
        return false;
    }
    try {
        var b_ngay_c = $get(b_dr_ngayId).value;
        var b_ngay_m = C_NVL($get(b_doi_ngayId).value);
        if (b_ngay_c == "" || b_ngay_m == "") {
            form_P_LOI("loi:Chưa chọn ngày cũ hoặc ngày mới:loi");
            return;
        }
        var message = confirm("Hệ thống sẽ đổi toàn bộ TKB đã có từ ngày " + b_ngay_c + " sang ngày " + b_ngay_m + " ?");
        if (!message) { return false; }
        b_ngay_c = CNG_SO(b_ngay_c);
        b_ngay_m = CNG_SO(b_ngay_m);
        sns_dt.Fs_NS_DT_KH_CT_TKB_DOI(b_nsd, b_so_id_kh, b_ngay_c, b_ngay_m, ns_dt_kh_ct_tkb_P_DOI_NGAY_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
    return false;
}
function ns_dt_kh_ct_tkb_P_DOI_NGAY_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    drop_P_LKE(b_dr_ngayId, b_kq);
    $get(b_dr_ngayId).value = $get(b_doi_ngayId).value;
    $get(b_doi_ngayId).value = ""
    ns_dt_kh_ct_tkb_P_LKE();
    ns_dt_kh_ct_tkb_P_MOI(true);
}
function ns_dt_kh_ct_tkb_P_DatGchu(show, gchu) {
    form_P_DatGchu(b_gchuId, gchu);
    if (show) ns_dt_kh_ct_tkb_gchuCho = setInterval('ns_dt_kh_ct_tkb_P_DatGchu(false,".")', 2000);
    else if (ns_dt_kh_ct_tkb_gchuCho) clearTimeout(ns_dt_kh_ct_tkb_gchuCho);
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
    //data = data.substr(0, 2) + ':' + data.substr(2);
    return data;
}
function pad(s) { return (s < 10) ? '0' + s : s; }
function form_dong() {
    location.reload(false);
}