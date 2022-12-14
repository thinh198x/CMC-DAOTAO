var tl_tlap_dongia_tts_lkeCho, b_vungId, b_grlkeId, b_giatriId, b_slideId, b_gocId, b_lngId;
function tl_tlap_dongia_tts_P_KD() {
    try {

        tl_tlap_dongia_tts_lkeCho;
        b_vungId = form_Fs_VUNG_ID('UPa_ct');
        b_grlkeId = form_Fs_VUNG_ID('GR_lke');
        b_gocId = form_Fs_TEN_ID(b_vungId, 'NGAY');
        b_giatriId = form_Fs_TEN_ID(b_vungId, 'giatri');
        b_slideId = b_grlkeId + '_slide';
        tl_tlap_dongia_tts_lkeCho = setTimeout('tl_tlap_dongia_tts_P_LKE_CHO()', 200);
    }
    catch (err) {
        alert(err);
    }
}
function tl_tlap_dongia_tts_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "NGAY": b_maId = b_gocId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "")
            return;
        if (b_maTen == "NGAY") {
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ngay", b_ma.value);
            if (b_hang < 1) {
                GridX_thoiA(b_grlkeId);
                tl_tlap_dongia_tts_P_MA_KTRA();
            }
            else {
                GridX_datA(b_grlkeId, b_hang);
                tl_tlap_dongia_tts_P_CHUYEN_HANG();
            }
        }
    }
    catch (err) {
        alert(err);
    }
}

function tl_tlap_dongia_tts_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var a_cot = GridX_Fas_tenCot(b_grlkeId);
            stl_ma.Fs_TL_TLAP_DONGIA_TTS_MA(b_ma, b_TrangKt, a_cot, tl_tlap_dongia_tts_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) {
        alert(err);
    }
}
function tl_tlap_dongia_tts_P_MA_KTRA_KQ(b_kq) {
    try {

        if (Fb_LOI_KTRA(b_kq)) {
            alert(b_kq);
            return;
        }
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1,
            b_trang = CSO_SO(a_kq[1]),
            b_soDong = CSO_SO(a_kq[2]);
        GridX_datBang(b_grlkeId, a_kq[3]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        if (b_hang < 1)
            form_P_MOI(b_vungId, "X");
        else {
            GridX_datA(b_grlkeId, b_hang);
            tl_tlap_dongia_tts_P_CHUYEN_HANG();
        }
    }
    catch (err) {
        alert(err);
    }
}
var tl_tlap_dongia_tts_choAct = 0;
function tl_tlap_dongia_tts_GR_lke_RowChange() {
    try {

        if (tl_tlap_dongia_tts_choAct != 0)
            clearTimeout(tl_tlap_dongia_tts_choAct);
        tl_tlap_dongia_tts_choAct = setTimeout("tl_tlap_dongia_tts_P_CHUYEN_HANG()", 300);
        return false;
    }
    catch (err) {
        alert(err);
    }
}
function tl_tlap_dongia_tts_P_LKE_CHO() {
    try {

        if (document.readyState === 'complete') {
            if (tl_tlap_dongia_tts_lkeCho != 0)
                clearTimeout(tl_tlap_dongia_tts_lkeCho);
            b_slideId = $get(b_grlkeId).getAttribute('slideId');
            tl_tlap_dongia_tts_P_LKE('K');
        }
    }
    catch (err) {
        alert(err);
    }
}
function tl_tlap_dongia_tts_P_LKE(b_dk) {
    try {
        if (b_dk == 'C')
            slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId);
        var a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_ma.Fs_TL_TLAP_DONGIA_TTS_LKE(a_cot, a_tso, tl_tlap_dongia_tts_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) {
        alert(err);
    }
}
function tl_tlap_dongia_tts_P_LKE_KQ(b_kq) {
    try {

        if (Fb_LOI_KTRA(b_kq)) {
            alert(b_kq);
            return;
        }
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
    }
    catch (err) {
        alert(err);
    }
}
function tl_tlap_dongia_tts_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_gocId).focus();
    return false;
}
function tl_tlap_dongia_tts_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1)
            return;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "") {
            form_P_MOI(b_vungId, "XGL");
        }
        else stl_ma.Fs_TL_TLAP_DONGIA_TTS_CT(b_so_id, tl_tlap_dongia_tts_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) {
        alert(err);
    }
}

function tl_tlap_dongia_tts_P_CHUYEN_HANG_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) {
            alert(b_kq);
            return;
        }
        form_P_CH_TEXT(b_vungId, b_kq);
    }
    catch (err) {
        alert(err);
    }
}

function tl_tlap_dongia_tts_P_NH() {
    try {

        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") {
            alert(b_loi);
            return false;
        }
        var b_giatri = $get(b_giatriId).value;
        if (CSO_SO(b_giatri) < 0) {
            {
                alert("Giá trị không được nhỏ hơn 0");
                return false;
            }
        }
        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
        var b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
        stl_ma.Fs_TL_TLAP_DONGIA_TTS_NH(b_TrangKt, a_dt_ct, a_cot_lke, tl_tlap_dongia_tts_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) {
        alert(err);
    }
}

function tl_tlap_dongia_tts_P_NH_KQ(b_kq) {
    try {

        if (Fb_LOI_KTRA(b_kq))
            alert(b_kq);
        else {
            var a_kq = Fas_ChMang(b_kq, '#');
            var b_hang = CSO_SO(a_kq[0]) + 1;
            var b_trang = CSO_SO(a_kq[1]);
            var b_soDong = CSO_SO(a_kq[2]);
            slide_P_MOI(b_slideId, b_trang, b_soDong);
            GridX_datBang(b_grlkeId, a_kq[3]);
            if (b_hang >= 0)
                GridX_datA(b_grlkeId, b_hang);
            $get(b_gocId).focus();
            alert("Nhập thành công!");
        }
        return false;
    }
    catch (err) {
        alert(err);
    }
}
function tl_tlap_dongia_tts_P_XOA() {
    try {

        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) {
            alert("Bạn phải chọn một bản ghi để xóa");
            return false;
        }
        var b_ngay = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
        if (b_ngay == "") {
            alert("Bạn phải chọn một bản ghi để xóa");
            tl_tlap_dongia_tts_P_MOI();
            return false;
        }
        else {
            var a_cot = GridX_Fas_tenCot(b_grlkeId);
            var a_tso = slide_Faobj_TUDEN(b_slideId);
            stl_ma.Fs_TL_TLAP_DONGIA_TTS_XOA(b_ngay, a_tso, a_cot, tl_tlap_dongia_tts_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) {
        alert(err);
    }
}
function tl_tlap_dongia_tts_P_XOA_KQ(b_kq) {
    try {

        if (Fb_LOI_KTRA(b_kq))
            alert(b_kq);
        else {
            var a_kq = Fas_ChMang(b_kq, '#');
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang > 1)
                b_hang--;
            else
                b_hang = GridX_Fi_hangSo(b_grlkeId);
            slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
            GridX_datBang(b_grlkeId, a_kq[1]);
            if (GridX_Fb_hangTrang(b_grlkeId, b_hang))
                tl_tlap_dongia_tts_P_MOI();
            else {
                GridX_datA(b_grlkeId, b_hang);
                tl_tlap_dongia_tts_P_CHUYEN_HANG();
            }
            alert("Xóa thành công!");
            return false;
        }
    }
    catch (err) {
        alert(err);
    }
}
function form_dong() {
    location.reload(false);
}