
var ht_ma_tusinh_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_hopdongId, b_timId, b_quyetdinhId;
function ht_ma_tusinh_P_KD() {
    ht_ma_tusinh_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), 
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_sotheId = form_Fs_VTEN_ID(b_vungId, 'SOTHE');
    b_hopdongId = form_Fs_VTEN_ID(b_vungId, 'hopdong');
    b_quyetdinhId = form_Fs_VTEN_ID(b_vungId, 'quyetdinh');
    ht_ma_tusinh_lkeCho = setInterval('ht_ma_tusinh_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("MA1NGAY") >= 0) {
            $get(b_ma1ngayId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_manuangayId).focus();
        }
        else if (b_dtuong.indexOf("MANUANGAY") >= 0) {
            $get(b_manuangayId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ht_ma_tusinh_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SOTHE": b_maId = b_sotheId; break;
            case "HOPDONG": b_maId = b_hopdongId; break;
            case "QUYETDINH": b_maId = b_quyetdinhId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return false;
        if (b_maTen == 'SOTHE') {
            var b_loai = $get(b_sotheId).value;
            if (b_loai == "TS") {
                $get("trTuSinhSothe").style.display = "";
                $get("trTuSinhSothe2").style.display = "";
            } else if (b_loai == "NT") {
                $get("trTuSinhSothe").style.display = "none";
                $get("trTuSinhSothe2").style.display = "none";
            }else
            {
                $get("trTuSinhSothe").style.display = "";
                $get("trTuSinhSothe2").style.display = "";
            }
        } else if (b_maTen == 'HOPDONG') {
            var b_loai = $get(b_hopdongId).value;
            if (b_loai == "TS") {
                $get("trTuSinhhopdong").style.display = "";
                $get("trTuSinhhopdong2").style.display = "";
            } else if (b_loai == "NT") {
                $get("trTuSinhhopdong").style.display = "none";
                $get("trTuSinhhopdong2").style.display = "none";
            }
        }
        else if (b_maTen == 'QUYETDINH') {
            var b_loai = $get(b_quyetdinhId).value;
            if (b_loai == "TS") {
                $get("trTuSinhquyetdinh").style.display = "";
                $get("trTuSinhquyetdinh2").style.display = "";
            } else if (b_loai == "NT") {
                $get("trTuSinhquyetdinh").style.display = "none";
                $get("trTuSinhquyetdinh2").style.display = "none";
            }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ht_ma_tusinh_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}

function ht_ma_tusinh_P_LKE_CHO() {
    clearTimeout(ht_ma_tusinh_lkeCho); ht_ma_tusinh_P_CHUYEN_HANG(); 
}


function ht_ma_tusinh_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
    stl_ma.Fs_HT_MA_TUSINH_NH(a_dt_ct, ht_ma_tusinh_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ht_ma_tusinh_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI("loi:Nhập thành công:loi");
    }
    return false;
}


function ht_ma_tusinh_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    $get(b_gocId).focus();
}

function ht_ma_tusinh_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    if (b_ma == "") ht_ma_tusinh_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_ma.Fs_HT_MA_TUSINH_XOA(b_ma, a_tso, a_cot, ht_ma_tusinh_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ht_ma_tusinh_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ht_ma_tusinh_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ht_ma_tusinh_P_CHUYEN_HANG(); }
    }
}

function ht_ma_tusinh_P_CHUYEN_HANG() {
    try {
        stl_ma.Fs_HT_MA_TUSINH_MA("1",ht_ma_tusinh_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ht_ma_tusinh_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    form_P_CH_TEXT(b_vungId, b_kq);

    var hdId = $get(b_hopdongId).value;
    if (hdId == "TS") {
        $get("trTuSinhhopdong").style.display = "";
        $get("trTuSinhhopdong2").style.display = "";
    } else {
        $get("trTuSinhhopdong").style.display = "none";
        $get("trTuSinhhopdong2").style.display = "none";
    }
    var hdId = $get(b_quyetdinhId).value;
    if (hdId == "TS") {
        $get("trTuSinhquyetdinh").style.display = "";
        $get("trTuSinhquyetdinh2").style.display = "";
    } else {
        $get("trTuSinhquyetdinh").style.display = "none";
        $get("trTuSinhquyetdinh2").style.display = "none";
    }
    var sotheId = $get(b_sotheId).value;
    if (sotheId == "TS" || sotheId == "TS_NT") {
        $get("trTuSinhSothe").style.display = "";
        $get("trTuSinhSothe2").style.display = "";
    } else {
        $get("trTuSinhSothe").style.display = "none";
        $get("trTuSinhSothe2").style.display = "none";
    }
}
function form_dong() {
    location.reload(false);
}