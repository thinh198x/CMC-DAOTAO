var b_lkeCho = 0, b_choAct = 0, b_vungId, b_grlkeId, b_slideId, b_gocId, b_ma_ctId, b_ten_ctId, b_capId, b_logoId, b_timId, b_gchuId, b_tmf, b_ma_dvi, b_hang_temp,
    b_no_anhId, b_imgId, b_taocon = 0, b_ten_cdanh_qlId, b_phong_qlId, b_choAct_fi = 0, b_cdanh_qlId, b_ten_qlId, b_choAct = 0, b_fdtuong,
    a_ftso, b_fcho = 'C', b_gtId;
function ht_madvi_KD(b_tmp, b_dvi, b_img) {
    b_tmf = b_tmp, b_ma_dvi = b_dvi;
    b_vungId = form_Fs_VUNG_ID('UPa_ct'); b_vungtkId = form_Fs_VUNG_ID('UPa_tk'); b_grlkeId = form_Fs_VUNG_ID('GR_lke'); b_slideId = b_grlkeId + '_slide';
    b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'); b_logoId = form_Fs_TEN_ID(b_vungId, 'logo'); b_timId = form_Fs_VTEN_ID('', 'tim_ten'); b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_ma_ctId = form_Fs_TEN_ID(b_vungId, 'ma_ct'); b_ten_ctId = form_Fs_TEN_ID(b_vungId, 'ten_ct'); b_capId = form_Fs_TEN_ID(b_vungId, 'cap'); b_ten_qlId = form_Fs_TEN_ID(b_vungId, 'ten_ql');
    b_ten_cdanh_qlId = form_Fs_TEN_ID(b_vungId, 'ten_cdanh_ql'), b_phong_qlId = form_Fs_TEN_ID(b_vungId, 'phong_ql'), b_cdanh_qlId = form_Fs_TEN_ID(b_vungId, 'cdanh_ql');
    b_no_anhId = form_Fs_TM() + "/images/no_image.png"; b_ngay_tlId = form_Fs_TEN_ID(b_vungId, 'ngay_tl'), b_ngay_gtId = form_Fs_TEN_ID(b_vungId, 'ngay_gt');
    b_gtId = form_Fs_TEN_ID(b_vungtkId, 'gt');
    b_imgId = document.getElementById(b_img);
    b_lkeCho = setInterval('ht_madvi_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (C_NVL(b_dtuong) == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("NHANG") >= 0) { form_Fctr_TEN_DTUONG(b_vungId, 'nhang').value = b_kq; form_Fctr_TEN_DTUONG(b_vungId, 'ma_tk').focus(); }
        else if (b_dtuong.indexOf("KVUC") >= 0) { form_Fctr_TEN_DTUONG(b_vungId, 'kvuc').value = b_kq; form_Fctr_TEN_DTUONG(b_vungId, 'ma_ct').focus(); }
        else if (b_dtuong.indexOf("TEN_CDANH_QL") >= 0) {
            b_dtuong = b_dtuong.toUpperCase();
            $get(b_phong_qlId).value = a_tso[0];
            $get(b_cdanh_qlId).value = a_tso[1];
            $get(b_ten_cdanh_qlId).value = a_tso[2];
            ht_madvi_P_TTQL($get(b_cdanh_qlId).value);
        }
        else if (b_dtuong.indexOf("TEN_QL") >= 0) {
            $get(b_ten_qlId).value = a_tso[0];
            $get(form_Fs_TEN_ID(b_vungId, 'ten_ten_ql')).value = a_tso[1];
            ns_thongtin_canbo(a_tso[0]);
        } else if (b_dtuong.indexOf("FLUU") >= 0) {
            ht_madvi_GR_lke_RowChange();
            return false;
        }
        else if (b_dtuong.indexOf("ANH_THE") >= 0) {
            layurl_cho();
            return false;
        }
    }
    catch (ex) { form_P_LOI(ex.message); }
}

function layurl_cho() {
    if (b_choAct_fi != 0) clearTimeout(b_choAct_fi);
    b_choAct_fi = setTimeout("layurl()", 300);
    return false;
}
function khud_trdoi_FI_CHUYEN() {
    try {
        var b_goc = C_NVL(GridX_Fas_layGtriA(b_grlkeId, "iurl"));
        //if (b_goc != "" && b_goc != null) b_iurlId.src = b_loading_anhId;
        //else b_iurlId.src = b_no_anhId;
        var b_i = b_goc.lastIndexOf('.');
        if (b_i > 0) {
            var b_s = b_goc.substr(b_i + 1);
            if (b_s != "" && "png,PNG,gif,GIF,BMP,bmp,jpg,JPG,JPEG,jpeg".indexOf(b_s) >= 0) sns_hs.Fs_FI_ANH_TRA(b_goc, khud_trdoi_FI_CHUYEN_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        } else b_iurlId.src = b_no_anhId;
        return false;
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function khud_trdoi_FI_CHUYEN_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else b_iurlId.src = b_kq + "?" + new Date().getTime();
}
function layurl() {
    try {
        b_iurlId.src = b_loading_anhId;
        var b_so_the = $get(b_gocId).value;
        sns_hs.Fs_FI_ANH_URL(layurl_kq, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function layurl_kq(b_kq) {
    try {
        if (b_kq == "File nhập phải nhỏ hơn 1 MB!") {
            form_P_LOI("File nhập phải nhỏ hơn 1 MB!");
        }
        else {
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            GridX_datGtri(b_grlkeId, b_hang, "iurl", b_kq);
        }
        khud_trdoi_FI_CHUYEN();
        return false;
    }
    catch (err) {
        form_P_LOI(err);
    }

}
function ns_thongtin_canbo(b_so_the) {
    try {
        hts_dungchung.Fs_THONGTIN_CANBO_LUOI(b_so_the, ns_thongtin_canbo_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_thongtin_canbo_kq(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var a_kq = Fas_ChMang(b_kq, '#');
    if (a_kq != "") {
        $get(b_ten_cdanh_qlId).value = a_kq[3];
    }
    return false;
}
function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}

function ht_madvi_P_KTRA(b_maTen) {
    try {
        var b_ma = form_Fctr_TEN_DTUONG(b_vungId, b_maTen);
        b_maTen = b_maTen.toUpperCase();
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
            b_ten.value = form_Fctr_TEN_DTUONG(b_vungId, 'TEN_GON').value = $get(b_timId).value = "";
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ma_goc", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ht_madvi_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ht_madvi_P_CHUYEN_HANG(); }
            b_ten.focus();
        }
        else if (b_maTen == "TEN") {
            var b_ten_gon = form_Fctr_TEN_DTUONG(b_vungId, 'TEN_GON');
            if (C_NVL(b_ten_gon.value) == "") b_ten_gon.value = b_ma.value;
        }
        else if (b_maTen.indexOf("NGAY") >= 0) {
            var b_loi = b_loi = Fs_NGAY_LOI(b_ma.value, b_ma.getAttribute("kieu_date"));
            if (b_loi != "") form_P_LOI(b_loi);
        }
        else skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ht_madvi_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ht_madvi_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}
function ht_madvi_P_MA_KTRA() {
    try {
        if (b_taocon == 1) { return false; }
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_hangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_gt = $get(b_gtId).value;
            sht_ma.Fs_MA_DVI_MA(form_Fs_nsd(), window.name, b_ma, b_gt, b_hangKt, a_cot, ht_madvi_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ht_madvi_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]), b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]); slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ht_madvi_P_CHUYEN_HANG(); }
}
// Nhap
function ht_madvi_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    $get(b_gocId).focus();
    return false;
}

function ht_madvi_P_MOI_CON() {
    form_P_MOI(b_vungId, "GXL");
    $get(b_ma_ctId).value = GridX_Fas_layGtriA(b_grlkeId, "MA");
    $get(b_ten_ctId).value = GridX_Fas_layGtriA(b_grlkeId, "TEN");
    return false;
}

function ht_madvi_P_MA() {
    try {
        var b_ma = $get(b_gocId).value, a_cot = GridX_Fas_tenCot(b_grlkeId), b_trangKT = GridX_Fi_hangKt(b_grlkeId);
        var b_gt = $get(b_gtId).value;
        sht_ma.Fs_MA_DVI_MA(form_Fs_nsd(), window.name, b_ma, b_gt, b_trangKT, a_cot, ht_madvi_P_MA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}

function ht_madvi_P_MA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]), b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        GridX_datBang(b_grlkeId, a_kq[3]); slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_luiCot(b_grlkeId, 'ten', 'cap'); $get(b_timId).value = '';
        if (b_hang > 0) GridX_datA(b_grlkeId, b_hang);
    }
}

function ht_madvi_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var ktra = ktra_ngay(parseDate($get(b_ngay_tlId).value).getTime(), parseDate($get(b_ngay_gtId).value).getTime(), 1, "Ngày thành lập", "ngày giải thể");
    if (ktra.length > 0) {
        ht_madvi_P_NH_KQ(ktra);
        return false;
    }
    var b_ma = $get(b_gocId).value;
    var b_ma_len = b_ma.length;
    if (b_ma_len > 9) { form_P_LOI("loi:Mã đơn vị không quá 9 ký tự:loi"); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_hangKt = GridX_Fi_hangKt(b_grlkeId);

    //var b_ma = C_NVL(GridX_Fas_layGtriA(b_grlkeId, 'ma'));
    //if (b_ma == '') 
    sht_ma.Fs_MA_DVI_NH(form_Fs_nsd(), a_dt_ct, a_cot, ht_madvi_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ht_madvi_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else { ht_madvi_P_MA(); $get(b_gocId).focus(); form_P_LOI("loi:Ghi thành công!:loi"); }
}
function ht_madvi_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }

    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }
    var b_ma = C_NVL(GridX_Fas_layGtriA(b_grlkeId, "ma"));
    if (b_ma == "") ht_madvi_P_MOI();
    else {
        var b_tim = C_NVL($get(b_timId).value), a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_gt = $get(b_gtId).value;
        sht_ma.Fs_MA_DVI_XOA(form_Fs_nsd(), b_ma, b_gt, b_tim, a_cot, a_tso, ht_madvi_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ht_madvi_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang == 1 && GridX_Fb_hangTrang(b_grlkeId, 2)) b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang) && b_hang > 1) b_hang--;
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ht_madvi_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ht_madvi_P_CHUYEN_HANG(); }
    }
}
function ht_madvi_GR_lke_RowChange() {
    if (b_choAct != 0) clearTimeout(b_choAct);
    b_choAct = setTimeout("ht_madvi_P_CHUYEN_HANG()", 300);
    return false;
}
function ht_madvi_P_CHUYEN_HANG() {
    try {
        b_taocon = 0;
        b_hang_temp = GridX_Fi_timHangA(b_grlkeId);
        var b_ma = C_NVL(GridX_Fas_layGtriA(b_grlkeId, 'ma'));
        if (b_ma == '') form_P_MOI(b_vungId, 'GXL');
        else sht_ma.Fs_MA_DVI_CT(form_Fs_nsd(), b_ma, ht_madvi_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}

function ht_madvi_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else if (b_kq == '') form_P_MOI(b_vungId, 'GXL');
    else form_P_CH_TEXT(b_vungId, b_kq);
    khud_trdoi_FI_CHUYEN();
    GridX_datA(b_grlkeId, b_hang_temp);
}


// Liệt kê
function ht_madvi_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (b_lkeCho != 0) clearTimeout(b_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ht_madvi_P_LKE('M');
    }
}

function ht_madvi_P_LKE(b_dk) {
    try {
        if (b_dk == 'M') slide_P_MOI(b_slideId);
        else if (b_dk == 'T') {
            var b_dk = C_NVL(GridX_Fas_layGtriA(b_grlkeId, 'tc'));
            if (b_dk == 'C' || b_dk == '') return false;
        }
        var b_tim = C_NVL($get(b_timId).value), a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_ma = C_NVL(GridX_Fas_layGtriA(b_grlkeId, 'ma')), b_gt = $get(b_gtId).value;
        sht_ma.Fs_MA_DVI_LKE(form_Fs_nsd(), window.name, b_dk, b_ma, b_gt, a_cot, a_tso, ht_madvi_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ht_madvi_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_ma = C_NVL(GridX_Fas_layGtriA(b_grlkeId, 'ma'));
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        GridX_luiCot(b_grlkeId, 'ten', 'cap');
        if (b_ma != '') {
            var b_hang = GridX_Fi_timHangD(b_grlkeId, 'ma', b_ma);
            if (b_hang > 0) GridX_datA(b_grlkeId, b_hang);
        }
        if (a_kq[1] == '' && C_NVL($get(b_timId).value) != '') form_P_LOI_DICH('Không tìm thấy');
    }
    b_fcho = 'X';
}
function layurl_cho() {
    if (b_choAct_fi != 0) clearTimeout(b_choAct_fi);
    b_choAct_fi = setTimeout("layurl()", 500);
    return false;
}
function layurl() {
    try {
        sns_hs.Fs_FI_DB_ANH_URL(layurl_kq, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function layurl_kq(b_kq) {
    try {
        if (b_kq == "File nhập phải nhỏ hơn 1 MB!") {
            form_P_LOI("File nhập phải nhỏ hơn 1 MB!");
        }
        else {
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            GridX_datGtri(b_grlkeId, b_hang, "logo", b_kq);
        }
        //ht_madvi_GR_lke_RowChange();
        khud_trdoi_FI_CHUYEN();
        return false;
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function khud_trdoi_FI_CHUYEN() {
    try {
        var b_goc = C_NVL(GridX_Fas_layGtriA(b_grlkeId, "logo"));
        var b_i = b_goc.lastIndexOf('.');
        if (b_i > 0) {
            var b_s = b_goc.substr(b_i + 1);
            if (b_s != "" && "png,PNG,gif,GIF,BMP,bmp,jpg,JPG,JPEG,jpeg".indexOf(b_s) >= 0)
                sns_hs.Fs_FI_ANH_TRA(b_goc, khud_trdoi_FI_CHUYEN_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        } else b_imgId.src = b_no_anhId;
        return false;
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function khud_trdoi_FI_CHUYEN_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else b_imgId.src = b_kq + "?" + new Date().getTime();
}
function khud_trdoi_FI_NH() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) {
            form_P_LOI('loi:Chọn đơn vị:loi')
            return false;
        }
        var b_nd = "Logo", b_f = $get(b_gocId).value
        form_P_LOI("");
        b_t = "/" + b_f.substr(0, 4) + "/" + b_f.substr(4, 2) + "/" + b_f.substr(6, 2);
        form_P_MO(b_tmf + '/ns/tt/file_anh.aspx', window.name + ",FLUU", ["TSO", [b_t, b_f, null, 'LOGO', b_ma_dvi, b_nd, window.name]]);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
//
function ns_ht_madvi_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    if (b_ma == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sht_ma.Fs_MA_DVI_XOA(form_Fs_nsd(), b_ma, a_tso, a_cot, ns_ht_madvi_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_ht_madvi_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {

        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        ht_madvi_P_LKE('M');
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));// GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ht_madvi_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ht_madvi_P_CHUYEN_HANG(); }
        form_P_LOI("Xóa thành công!");
    }
}
function ht_madvi_P_TTQL(b_ma_cd) {
    try {
        hts_dungchung.Fs_THONGTIN_CANBO_CDANH(b_ma_cd, ht_madvi_P_TTQL_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ht_madvi_P_TTQL_KQ(b_kq) {
    if (b_kq == "") { form_P_LOI(b_kq); return false; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
//
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
function parseDate(str) {
    var mdy = str.split('/');
    return new Date(mdy[2], mdy[1], mdy[0]);
}
function form_dong() {
    location.reload(false);
}