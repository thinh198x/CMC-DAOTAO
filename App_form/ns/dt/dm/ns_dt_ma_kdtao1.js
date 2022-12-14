var ns_dt_ma_kdtao_lkeCho = 0, ns_dt_ma_kdtao_choAct = 0, b_vungId, b_grlkeId, b_vungTk, b_grcdId, b_namId, b_gocId,
    b_slideId, b_vungHi, b_so_idHi, b_nndId, b_nnd_dvId, b_motaId, b_gchuId, b_ncdanhId, b_nsd, b_grncdId, b_kdt_an,
    b_namTk, b_kdtTk, b_hinhthucId, b_trangthaiId, b_ndId, b_slidectId, b_slidecdId, b_grdvId, b_tluongId, b_ncdId, $b_ncd_Id;
function ns_dt_ma_kdtao_P_KD() {
    ns_dt_ma_kdtao_lkeCho = setInterval('ns_dt_ma_kdtao_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("DV") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grdvId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grdvId, b_hang, ["ma"], [a_tso[0]], 'K');
            GridX_datGtri(b_grdvId, b_hang, ["ten"], [a_tso[1]], 'K');
        }
        else if (b_dtuong.indexOf("NCD") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grncdId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grncdId, b_hang, ["ma"], [a_tso[0]], 'K');
            GridX_datGtri(b_grncdId, b_hang, ["ten"], [a_tso[1]], 'K');
        }
        else if (b_dtuong.indexOf("CD") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grcdId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grcdId, b_hang, ["ma"], [a_tso[0]], 'K');
            GridX_datGtri(b_grcdId, b_hang, ["ten"], [a_tso[1]], 'K');
        }
        ns_dt_ma_kdtao_P_LAY(); 
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ma_kdtao_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
            case "TLUONG": b_maId = b_tluongId; break;
            case "NAMTK": b_maId = b_namTk; break;
            case "NND": b_maId = b_nndId; break;
            case "NCD": b_maId = b_ncdId; break;
        }
        var b_ma = $get(b_maId);
        if (b_maTen == "MA") {
            $get(b_gocId).value = b_ma.value.validate_Ma();
        }
        else if (b_maTen == "NAMTK") {
            var b_nam = form_Fs_TEN_GTRI(b_vungTk, 'nam_tk');
            $get(b_kdtTk).value = "";
            sns_dt.Fs_NS_DT_MA_KDT_DR(window.name, CSO_SO(b_nam, 0), ns_dt_ma_kdtao_P_KDT_NAM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_maTen == "TLUONG") {
            if (!isTime(b_ma)) { form_P_LOI("loi:Thời lượng không đúng định dạng!:loi"); return false; }
            //var b_tluong = $get(b_tluongId).value;
            //if (b_tluong != "") ns_dt_ma_kdtao_GIO();
        }
        else if (b_maTen == "NND") {
            var b_nnd = form_Fs_TEN_GTRI(b_vungId, 'NND'), b_nam = form_Fs_TEN_GTRI(b_vungId, 'nam');
            $get(b_nnd_dvId).value = "";
            sns_dt.Fs_NS_DT_MA_NND_DV_DR(window.name, b_nnd, ns_dt_ma_kdtao_P_KDT_NND_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            if (b_nam == "") { form_P_LOI("loi:Nhập năm:loi"); return false; }
            var b_kytudau = b_nnd + b_nam.substr(2), b_tenbang = "NS_DT_MA_KDT", b_tencot = "MA";
            if (b_kytudau != "")
                hts_dungchung.Fs_AutoGenCode(b_kytudau, b_tenbang, b_tencot, s_dt_ma_kdtao_P_GENCODE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_maTen == "NND_DV") {
            var b_nam = form_Fs_TEN_GTRI(b_vungId, 'nam');
            if (b_nam == "") { form_P_LOI("loi:Nhập năm:loi"); return false; }
            var b_kytu = form_Fs_TEN_GTRI(b_vungId, 'NND') + form_Fs_TEN_GTRI(b_vungId, 'NND_DV') + b_nam.substr(2);
            var b_kytudau = b_kytu, b_tenbang = "NS_DT_MA_KDT", b_tencot = "MA";
            if (b_kytudau != "")
                hts_dungchung.Fs_AutoGenCode(b_kytudau, b_tenbang, b_tencot, s_dt_ma_kdtao_P_GENCODE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_maTen == "NCD") {
            var b_ma = $get(b_maId);
            $get(b_ncd_Id).value = lke_Fs_TRA($get(b_ncdId));
        }
    }
    catch (err) { form_P_LOI(err); }
}
function s_dt_ma_kdtao_P_GENCODE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        $get(b_gocId).value = b_kq;
    }
}
function ns_dt_ma_kdtao_P_MOI() {
    form_P_MOI(b_vungId, "GLX");
    GridX_thoiA(b_grlkeId);
    //GridX_datTrang(b_grncdId);
    GridX_datTrang(b_grcdId);
    GridX_datTrang(b_grdvId);
    $get(b_so_idHi).value = "";
    $get(b_hinhthucId).value = "";
    list_P_DAT(b_trangthaiId, 'A');
    $get(b_gocId).focus();
    return false;
}
function ns_dt_ma_kdtao_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt = form_Faa_TEXT_ROW(b_vungId), a_cot_cdanh = GridX_Fdt_cotGtri(b_grcdId),
                a_cot_dvi = GridX_Fdt_cotGtri(b_grdvId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var b_so_id = C_NVL(GridX_Fas_layGtriA(b_grlkeId, "so_id"));
            sns_dt.Fs_NS_DT_MA_KDTAO_NH(b_nsd, CSO_SO(b_so_id, 0), a_dt, b_TrangKt, a_cot_cdanh, a_cot_dvi, a_cot_lke, ns_dt_ma_kdtao_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_dt_ma_kdtao_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_so_idHi).value = a_kq[4];
        $get(b_namId).focus();
        form_P_LOI("loi:Ghi thành công!:loi");
    }
    return false;
}
function ns_dt_ma_kdtao_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 ) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "" || b_so_id == 0) ns_dt_ma_kdtao_P_MOI();
    else {
        var a_tk = form_Faa_TEXT_ROW(b_vungTk),b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.Fs_NS_DT_MA_KDTAO_XOA(a_tk, CSO_SO(b_so_id, 0),b_ma, a_tso, a_cot, ns_dt_ma_kdtao_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_dt_ma_kdtao_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (Fb_LOI_KTRA(b_kq)) {
        if (b_kq.indexOf("khoa dao tao") >= 0) {
            b_loi = "loi:Bản ghi đã được sử dụng ở chức năng khác, không được xóa!:loi";
        }
       // form_P_LOI(b_loi);
    }
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dt_ma_kdtao_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dt_ma_kdtao_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
    return false;
}
function ns_dt_ma_kdtao_GR_lke_RowChange() {
    if (ns_dt_ma_kdtao_choAct != 0) clearTimeout(ns_dt_ma_kdtao_choAct);
    ns_dt_ma_kdtao_choAct = setTimeout("ns_dt_ma_kdtao_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_dt_ma_kdtao_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "") {
        form_P_MOI(b_vungId, "GLX");
        //GridX_datTrang(b_grncdId);
        GridX_datTrang(b_grcdId);
        GridX_datTrang(b_grdvId);
        $get(b_so_idHi).value = "";
        $get(b_hinhthucId).value = "";
        list_P_DAT(b_trangthaiId, 'A');
        $get(b_gocId).focus();
    }
    else {
        var a_cot_cd = GridX_Fas_tenCot(b_grcdId), a_cot_dvi = GridX_Fas_tenCot(b_grdvId), b_nnd = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "nnd"));
        sns_dt.Fs_NS_DT_MA_KDTAO_CT(window.name, CSO_SO(b_so_id, 0), b_nnd, a_cot_cd, a_cot_dvi, ns_dt_ma_kdtao_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        $get(b_so_idHi).value = b_so_id;
    }
}
function ns_dt_ma_kdtao_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    //if (a_kq[1] == "") GridX_datTrang(b_grncdId);
    //else GridX_datBang(b_grncdId, a_kq[1]);
    if (a_kq[1] == "") GridX_datTrang(b_grcdId);
    else GridX_datBang(b_grcdId, a_kq[1]);
    if (a_kq[2] == "") GridX_datTrang(b_grdvId);
    else GridX_datBang(b_grdvId, a_kq[2]);
}
function ns_dt_ma_kdtao_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
        b_vungHi = form_Fs_VUNG_ID('UPa_hi'), b_grcdId = form_Fs_VUNG_ID('GR_cdanh');
        b_grncdId = form_Fs_VUNG_ID('GR_ncdanh'), b_grdvId = form_Fs_VUNG_ID('GR_dvi');
        b_vungTk = form_Fs_VUNG_ID('UPa_tk');
        b_namTk = form_Fs_TEN_ID(b_vungTk, 'nam_tk');
        b_kdtTk = form_Fs_TEN_ID(b_vungTk, 'kdt_tk');
        b_so_idHi = form_Fs_TEN_ID(b_vungHi, 'so_id');
        b_namId = form_Fs_TEN_ID(b_vungId, 'NAM');
        b_gocId = form_Fs_TEN_ID(b_vungId, 'MA');
        b_hinhthucId = form_Fs_TEN_ID(b_vungId, 'HTHUC');
        b_tluongId = form_Fs_TEN_ID(b_vungId, 'tluong');
        b_nndId = form_Fs_TEN_ID(b_vungId, 'NND');
        b_nnd_dvId = form_Fs_TEN_ID(b_vungId, 'nnd_dv');
        b_trangthaiId = form_Fctr_TEN_DTUONG(b_vungId, 'TRANGTHAI');
        b_motaId = form_Fs_TEN_ID(b_vungId, 'mota');
        b_ndId = form_Fs_TEN_ID(b_vungId, 'NDUNG');
        b_gchuId = form_Fs_VTEN_ID('', 'gchu');
        b_ncdId = form_Fs_TEN_ID(b_vungId, 'NCD')
        b_ncd_Id = form_Fs_TEN_ID(b_vungId, 'hincd'),
        b_kdt_an = form_Fs_TEN_ID(b_vungHi, 'kdt_an');
        b_nsd = form_Fs_nsd();
        b_slideId = $get(b_grlkeId).getAttribute('slideId'); slide_P_MOI(b_slideId);
        ns_dt_ma_kdtao_P_KTRA('NAMTK');
        clearTimeout(ns_dt_ma_kdtao_lkeCho); ns_dt_ma_kdtao_P_LKE();
    }
}
function ns_dt_ma_kdtao_P_LKE() {
    try {
        a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var a_tk = form_Faa_TEXT_ROW(b_vungTk);
        sns_dt.Fs_NS_DT_MA_KDTAO_LKE(a_tk, a_tso, a_cot, ns_dt_ma_kdtao_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ma_kdtao_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    return false;
}
function ns_dt_ma_kdtao_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_kdt_an).value = form_Fs_TEN_GTRI(b_vungTk, 'kdt_tk');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function form_dong() {
    location.reload(false);
}
function ns_dt_ma_kdtao_P_KDT_NAM_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
}
function ns_dt_ma_kdtao_P_KDT_NND_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
} 
function ns_dt_ma_kdtao_P_LAY() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grcdId);
        var b_so_id = 0, a_luoi;
        //slide_P_SOTRANG(b_slideId);
        var b_hang = GridX_Fi_timHangA(b_grcdId);
        a_luoi = GridX_Fdt_cotGtri(b_grcdId);
        sdg.Fs_LAY_TRACHON(form_Fs_nsd(), a_cot, a_luoi, ns_dt_ma_kdtao_P_LAY_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ma_kdtao_P_LAY_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#'); 
    GridX_datBang(b_grcdId, a_kq[1]); 
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

    //var rxHourPattern = /^(\d{1,2})(:)(\d{1,2})$/;
    //var dtArray = data.match(rxHourPattern); // is format OK?
    //if (dtArray == null) {
    //    rxHourPattern = /^(\d{1,2})$/;
    //   dtArray = data.match(rxHourPattern);
    //}
    //if (dtArray == null) {
    //   txtHour.value = "";
    //return false;
    //}
    //Checks for hh:mm format.
    //const hour = parseInt(dtArray[1], 10);
    //var minute = 0;

    //if (dtArray.length >= 4)
    //   minute = parseInt(dtArray[3], 10);
    var b_length = data.length;
    var hour = data.substr(0, b_length - 3);
    var minute = data.substr(b_length - 2);
    if (minute >= 60) {
        txtHour.value = "";
        return false;
    }
    txtHour.value = hour + ":" + minute;
    $get(b_tluongId).value = txtHour.value;
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
    else {

        data = data.substr(0, b_length - 2) + ':' + data.substr(b_length - 2);
    }
    return data;
}
function pad(s) { return (s < 10) ? '0' + s : s; }
function ns_dt_ma_kdtao_HangLen(b_dk) {
    var b_grct;
    if (b_dk == 1) b_grct = b_grcdId;
    if (b_dk == 2) b_grct = b_grdvId;
    GridX_chuyenHang(b_grct, -1); 
    return false;
}
function ns_dt_ma_kdtao_HangXuong(b_dk) {
    var b_grct;
    if (b_dk == 1) b_grct = b_grcdId;
    if (b_dk == 2) b_grct = b_grdvId;
    GridX_chuyenHang(b_grct, 1);
    return false;
}
function ns_dt_ma_kdtao_ChenDong(b_dk) {
    var b_grct, b_ktrahten;
    if (b_dk == 1) { b_grct = b_grcdId; b_ktrahten = C_NVL(GridX_Fas_layGtriA(b_grcdId, 'ma')); }
    if (b_dk == 2) { b_grct = b_grdvId; b_ktrahten = C_NVL(GridX_Fas_layGtriA(b_grdvId, 'ma')); }
    if (b_ktrahten == '') form_P_LOI("loi:Chọn dòng dữ liệu cần chèn thêm một hàng trước nó trên bảng:loi");
    else {
        GridX_chenHang(b_grct);
    }
    return false;
}
function ns_dt_ma_kdtao_CatDong(b_dk) {
    var b_grct;
    if (b_dk == 1) {
        b_grct = b_grcdId;
    }
    else if (b_dk == 2) {
        b_grct = b_grdvId;
    }
    else return false;
    GridX_boChon(b_grct, 'C');
    return false;
}