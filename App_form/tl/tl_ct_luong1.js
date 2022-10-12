
var tl_ct_luong_lkeCho, b_vungId, b_grlkeId, tl_ct_luong_dv_lkeCho, b_ttId,b_grctId, b_gocId, b_congthuc, b_ctId, b_mt, b_gchuId, b_nluongId, b_doi = 0, b_slideId, b_slide2Id;
function tl_ct_luong_P_KD() {
    tl_ct_luong_lkeCho,tl_ct_luong_dv_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'); b_slideId = b_grlkeId + '_slide'; b_slide2Id = b_grctId + '_slide';
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_nluongId = form_Fs_TEN_ID(b_vungId, 'NLUONG');  
    b_ctId = form_Fs_VTEN_ID('', 'ct');
    b_ttId = form_Fs_VTEN_ID('', 'tt');
    b_congthuc = "";
    tl_ct_luong_lkeCho = setInterval('tl_ct_luong_P_LKE_CHO()', 200);
    tl_ct_luong_dv_lkeCho = setInterval('tl_ct_luong_P_DV_LKE_CHO()', 200);
}

var b_cho_control = 0;
function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_gocId).value = b_so_the;
            $get(b_gchuId).innerHTML = b_ten;
            $get(b_gocId).focus();
            tl_ct_luong_P_LKE();
            b_doi = 1;
            clearTimeout(b_cho_control);
        }
    }
    catch (err) {
        b_doi = 0;
    }
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        b_doi = 0;
        if (b_dtuong.indexOf("SO_THE") >= 0 || b_dtuong.indexOf("THAMSO") >= 0) {
            $get(b_gocId).setAttribute("disabled", "disabled");
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function tl_ct_luong_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; form_P_MOI("", "XGL"); GridX_datTrang(b_grctId); break;
            case "NLUONG": b_maId = b_nluongId; break;
        }
        var b_ma = $get(b_maId);
        b_mt = b_maTen;
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), tl_ct_luong_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            tl_ct_luong_P_LKE();
        }
        else if (b_maTen == "NGAY") {
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ngayd", b_ma.value);
            if (b_hang < 0) { tl_ct_luong_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); tl_ct_luong_P_CHUYEN_HANG(); }
        } else if (b_maTen == "NLUONG") {
            tl_ct_luong_P_LKE();
            tl_ct_luong_P_DV_LKE();
        }
    }
    catch (err) { form_P_LOI(err); }
}

function tl_ct_luong_P_MA_KTRA() {
    try {
        //var b_ngay = C_NVL($get(b_ngayId).value);
        //if (b_ngay != "") {
        //    var b_so_the = $get(b_gocId).value;
        //    var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
        //    stl_ch.Fs_TL_CT_LUONG_MA(b_so_the, b_ngay, b_TrangKt, a_cot, tl_ct_luong_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        //}
    }
    catch (err) { form_P_LOI(err); }
}
function tl_ct_luong_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        form_P_MOI(b_vungId, "X"); GridX_datTrang(b_grctId);
        $get(b_gocId).focus(); $get(b_so_idId).value = "0";
    }
    else { GridX_datA(b_grlkeId, b_hang); tl_ct_luong_P_CHUYEN_HANG(); }
}
function tl_ct_luong_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    $get(b_gchuId).innerHTML = b_kq;
}

var tl_ct_luong_choAct = 0;
function tl_ct_luong_GR_lke_RowChange() {
    if (tl_ct_luong_choAct != 0) clearTimeout(tl_ct_luong_choAct);
    tl_ct_luong_choAct = setTimeout("tl_ct_luong_P_CHUYEN_HANG()", 300);
    return false;
}

var tl_ct_luong2_choAct = 0;
function tl_ct_luong2_GR_lke_RowChange() {
    if (tl_ct_luong2_choAct != 0) clearTimeout(tl_ct_luong_choAct);
    tl_ct_luong2_choAct = setTimeout("tl_ct_luong2_P_CHUYEN_HANG()", 300);
    return false;
}
function tl_ct_luong2_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grctId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grctId, b_hang, "nam"));
        var b_congthuc = C_NVL(GridX_Fas_layGtri(b_grctId, b_hang, "congthuc"));
        var b_tt = C_NVL(GridX_Fas_layGtri(b_grctId, b_hang, "tt"));
        $get(b_ctId).value = b_congthuc;
        $get(b_ttId).value = b_tt;
        if (b_ma == "") form_P_MOI(b_vungId, "XGL"); else form_P_GridX_TEXT(b_vungId, b_grctId);
    }
    catch (err) { form_P_LOI(err); }
}
function tl_ct_luong_P_LKE_CHO() {
    if ($get(b_grctId) != null) { clearTimeout(tl_ct_luong_lkeCho); tl_ct_luong_P_LKE(); }
}
function tl_ct_luong_P_DV_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(tl_ct_luong_dv_lkeCho); tl_ct_luong_P_DV_LKE(); }
}

function tl_ct_luong_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    $get(b_so_idId).value = "0";
    $get(b_gocId).focus();
    return false;
}
function tl_ct_luong_P_LKE() {
    try {
        var a_nluong = $get(b_nluongId).value;
        var a_cot = GridX_Fas_tenCot(b_grctId), a_tso = slide_Faobj_TUDEN(b_slide2Id);
        stl_ch.Fs_TL_CT_LUONG_LKE(a_nluong,a_tso, a_cot, tl_ct_luong_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function tl_ct_luong_P_DV_LKE() {
    try {
        var a_nluong = $get(b_nluongId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_ch.Fs_TL_CT_LUONG_DV_LKE(a_nluong,a_tso, a_cot, tl_ct_luong_P_DV_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function tl_ct_luong_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slide2Id, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grctId, a_kq[1]);
}
function tl_ct_luong_P_DV_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function tl_ct_luong_P_KT() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_ct = $get(b_ctId).value;
            stl_ch.Fs_TL_CT_LUONG_KT(b_ct, tl_ct_luong_P_KT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function tl_ct_luong_P_KT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; } 
    return false;
}
function tl_ct_luong_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_hang = GridX_Fi_timHangA(b_grctId); 
            var b_mact = C_NVL(GridX_Fas_layGtri(b_grctId, b_hang, "macl"));
            var b_ct = $get(b_ctId).value;
            var b_tt = $get(b_ttId).value;
            
            stl_ch.Fs_TL_CT_LUONG_NH(b_mact, b_ct, b_tt,tl_ct_luong_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function tl_ct_luong_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    tl_ct_luong_P_LKE();
    return false;
}
function tl_ct_luong_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return; 
        var a_cot_ct = GridX_Fdt_cotGtri(b_grlkeId);
        var b_mact = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "macl"));
        var b_chon = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "chon"));
        var b_ct = $get(b_ctId).value;
        if (b_chon == 'X') {
            b_ct = b_ct + " NVL(" + b_mact + ",0)";
        } else
        {
            b_ct = b_ct.replace(" NVL(" + b_mact + ",0)", "");
        }
        $get(b_ctId).value = b_ct;
    }
    catch (err) { form_P_LOI("loi:Có lỗi xảy ra:loi"); }
}
function tl_ct_luong_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    $get(b_ctId).value = a_kq[1];
}
function tl_ct_luong_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") tl_ct_luong_P_MOI();
    else {
        var b_so_the = $get(b_gocId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_ch.Fs_TL_CT_LUONG_XOA(b_so_id, b_so_the, a_tso, a_cot, tl_ct_luong_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function tl_ct_luong_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) tl_ct_luong_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); tl_ct_luong_P_CHUYEN_HANG(); }
    }
}
function tl_ct_luong_cong() {
    $get(b_ctId).value = $get(b_ctId).value + " + ";
    form_P_LOI();
    return false;
}
function tl_ct_luong_tru() {
    $get(b_ctId).value = $get(b_ctId).value + " - ";
    form_P_LOI();
    return false;
}
function tl_ct_luong_nhan(b_dk) {
    $get(b_ctId).value = $get(b_ctId).value + " * ";
    form_P_LOI();
    return false;
}
function tl_ct_luong_chia() {
    $get(b_ctId).value = $get(b_ctId).value + " / ";
    form_P_LOI();
    return false;
}

function form_dong() {
    location.reload(false);
}