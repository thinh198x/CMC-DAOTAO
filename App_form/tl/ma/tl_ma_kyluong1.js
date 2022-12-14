var b_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_namId, b_thangId, b_timId, b_ngay_bd_Id, b_ngay_kt_id, b_so_idId, b_nsd, b_choAct = 0;
function tl_ma_kyluong_P_KD() {
    b_lkeCho = setInterval('tl_ma_kyluong_P_LKE_CHO()', 200);
}
function tl_ma_kyluong_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            //case "MA": b_maId = b_gocId; break;
            case "THANG": b_maId = b_namId; break;
            case "NGAY_BD": b_maId = b_ngay_bd_Id; break;
            case "NGAY_KT": b_maId = b_ngay_kt_id; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        switch (b_maTen) {
            case "THANG":
                var b_nam = CSO_SO($get(b_namId).value, 0), b_thang = CSO_SO(form_Fs_TEN_GTRI(b_vungId, 'THANG'), 0);
                var b_hang = GridX_Fi_timHangM(b_grlkeId, ["NAM", "THANG"], [b_nam, b_thang]);
                if (b_hang < 1) { GridX_thoiA(b_grlkeId); tl_ma_kyluong_P_MA_KTRA(); }
                else { GridX_datA(b_grlkeId, b_hang); tl_ma_kyluong_P_CHUYEN_HANG(); }
                break;
            case "NGAY_BD":
                if (C_NVL($get(b_ngay_kt_id).value) == "") return true;
                var b_ngayD = CNG_SO($get(b_ngay_bd_Id).value), b_ngayC = CNG_SO($get(b_ngay_kt_id).value);
                if (b_ngayD > b_ngayC) {
                    form_P_LOI("loi:Ngày bắt đầu không được lớn hơn ngày kết thúc:loi");
                    return false;
                }
                else
                    return true;
                break;
            case "NGAY_KT":
                if (C_NVL($get(b_ngay_bd_Id).value) == "") return true;
                var b_ngayD = CNG_SO($get(b_ngay_bd_Id).value), b_ngayC = CNG_SO($get(b_ngay_kt_id).value);
                if (b_ngayD > b_ngayC) {
                    form_P_LOI("loi:Ngày kết thúc không được nhỏ hơn ngày bắt đầu:loi");
                    return false;
                }
                else
                    return true;
                break;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function tl_ma_kyluong_P_MA_KTRA() {
    try {
        var b_nam = CSO_SO($get(b_namId).value, 0), b_thang = CSO_SO(form_Fs_TEN_GTRI(b_vungId, 'THANG'), 0);
        if (b_nam != 0 || b_thang != 0) {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            stl_ma.Fs_TL_MA_KYLUONG_NAMTHANG(b_nsd, b_nam, b_thang, b_TrangKt, a_cot, tl_ma_kyluong_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function tl_ma_kyluong_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); tl_ma_kyluong_P_CHUYEN_HANG(); }
}
function tl_ma_kyluong_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = 0;
    return false;
}
function tl_ma_kyluong_P_NH() {
    var b_nam = $get(b_namId).value;
    if (b_nam.length < 4) { form_P_LOI("loi:Năm không đúng định dạng:loi"); return false; }
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    if (!tl_ma_kyluong_P_KTRA('NGAY_BD') || !tl_ma_kyluong_P_KTRA('NGAY_KT'))
        return false;
    var b_so_id = CSO_SO($get(b_so_idId).value);
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    stl_ma.Fs_TL_MA_KYLUONG_NH(b_nsd, b_so_id, b_TrangKt, a_dt_ct, a_cot, tl_ma_kyluong_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function tl_ma_kyluong_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        $get(b_so_idId).value = a_kq[4];
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        form_P_LOI("loi:Ghi thành công!:loi");
    }
}
function tl_ma_kyluong_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");

    if (b_hang < 1 || b_so_id == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); tl_ma_kyluong_P_MOI(); }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_ma.Fs_TL_MA_KYLUONG_XOA(b_nsd, b_so_id, a_tso, a_cot, tl_ma_kyluong_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function tl_ma_kyluong_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
        var b_dong = GridX_Fi_hangSo(b_grlkeId);
        if (b_hang > b_dong) b_hang = b_dong;
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) tl_ma_kyluong_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); tl_ma_kyluong_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
}
function tl_ma_kyluong_GR_lke_RowChange() {
    if (b_choAct != 0) clearTimeout(b_choAct);
    b_choAct = setTimeout("tl_ma_kyluong_P_CHUYEN_HANG()", 300);
    return false;
}
function tl_ma_kyluong_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "") { tl_ma_kyluong_P_MOI(); }
        else {
            $get(b_so_idId).value = b_so_id;
            form_P_GridX_TEXT(b_vungId, b_grlkeId);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function tl_ma_kyluong_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
function tl_ma_kyluong_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(b_lkeCho);
        b_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_namId = form_Fs_TEN_ID(b_vungId, 'NAM');
        b_thangId = form_Fs_TEN_ID(b_vungId, 'THANG'), b_ngay_bd_Id = form_Fs_TEN_ID(b_vungId, 'NGAY_BD'), b_ngay_kt_id = form_Fs_TEN_ID(b_vungId, 'NGAY_KT');
        b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'); b_slideId = $get(b_grlkeId).getAttribute('slideId'); slide_P_MOI(b_slideId);
        b_nsd = form_Fs_nsd();
        tl_ma_kyluong_P_LKE();
    }
}
function tl_ma_kyluong_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_ma.Fs_TL_MA_KYLUONG_LKE(b_nsd, a_tso, a_cot, tl_ma_kyluong_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function tl_ma_kyluong_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function form_dong() {
    location.reload(false);
}