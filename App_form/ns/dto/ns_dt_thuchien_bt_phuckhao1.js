
var ns_dt_thuchien_bt_phuckhao1_lkeCho, b_giay, b_noidung_pkId,ns_dt_thuchien_bt_phuckhao1_p_lkeCho, b_tongthoigian, b_vungId, b_nsd, b_so_idId, b_thoigianId, b_hoanthanhId, b_baitiId, b_loai_chId, b_CausoId, b_grlkeId, b_slideId, b_gocId, b_timIdb_nhomId, b_nhomId, b_gocIdId, b_cmtnd, b_TENId, b_gchuId, b_khoadtId, b_gchu;
function ns_dt_thuchien_bt_phuckhao_P_KD(nsd) {
    b_nsd = nsd;
    ns_dt_thuchien_bt_phuckhao1_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE'), b_gchu = form_Fs_VTEN_ID('', 'GCHU'), b_hoanthanhId = form_Fs_TEN_ID(b_vungId, 'hoanthanh'), b_diemId = form_Fs_TEN_ID(b_vungId, 'DIEM'),
    b_baitiId = form_Fs_VTEN_ID('', 'BAITHI'), b_thoigianId = form_Fs_VTEN_ID('', 'thoigian'), b_CausoId = form_Fs_TEN_ID(b_vungId, 'cauhoi_so'), b_loai_chId = form_Fs_TEN_ID(b_vungId, 'loai_ch'), b_so_idId = form_Fs_TEN_ID(b_vungId, 'so_id'),
    b_slideId = b_grlkeId + '_slide'; b_noidung_pkId = form_Fs_TEN_ID(b_vungId, 'noidung_phuckhao');
    b_tongthoigian = 0;b_giay = 10;
    ns_thongtin_canbo(); 
}
var b_cho_control = 0;
function P_cho(b_ma_nhom, b_ten, b_cmtnd) {
    try {
        if (b_doi == 0) {
            $get(b_gchu).value = b_ten;
            $get(b_gocId).value = b_ma_nhom;
        }
    }
    catch (err) { b_doi = 0;}
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        b_doi = 0;
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            $get(b_gchu).value = a_tso[1];
            $get(b_gocId).value = a_tso[0];
        } else if (b_dtuong.indexOf("THAMSO") >= 0) {
            $get(b_baitiId).value = b_kq;
            ns_dt_thuchien_bt_phuckhao1_P_MA_KTRA();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function startTime() {
    if (b_giay == 0 && b_tongthoigian>0) {
        b_tongthoigian = b_tongthoigian - 1;
        b_giay = 60;
    }
    if (b_giay == 0 && b_tongthoigian == 0) {
        var t = clearTimeout(startTime, 1000);
        $get("ctl00_ContentPlaceHolder1_trNoidung").style.display = "none";
        $get("ctl00_ContentPlaceHolder1_trCauHoi").style.display = "none";
        $get("trtraloi").style.display = "none";
        $get("trphantrang").style.display = "none";
        $get("btnclose").style.display = "block";
        $get("btnquaylai").style.display = "none";
        $get("btntieptheo").style.display = "none";
        $get("btnnopbai").style.display = "none";
        form_Fctr_TENVUNG("trHoanThanh").className = "";
        form_Fctr_TENVUNG("trHoanThanh2").className = "";
        form_Fctr_TENVUNG("trDapan").className = "";
        form_Fctr_TENVUNG("trDapan2").className = "";
        ns_dt_thuchien_bt_phuckhao1_P_KETQUA();
    }
    b_giay = b_giay - 1;
    if(b_giay >=0 && b_tongthoigian >=0){
        document.getElementById('ctl00_ContentPlaceHolder1_thoigian').innerHTML = b_tongthoigian + ":" + b_giay;
    }
    if (b_giay >= 0 && b_tongthoigian >= 0) { var t = setTimeout(startTime, 1000);}
}
function checkTime(i) {
    if (i < 10) { i = "0" + i }; 
    return i;
}
function ns_dt_thuchien_bt_phuckhao_P_LKE_CHO() {
    clearTimeout(ns_dt_thuchien_bt_phuckhao1_p_lkeCho); ns_dt_thuchien_bt_phuckhao_P_CHUYEN_HANG();
}
function ns_dt_thuchien_bt_phuckhao_P_CHUYEN_HANG() {
    ns_dt_thuchien_bt_phuckhao1_P_KETQUA();
}
function ns_dt_thuchien_bt_phuckhao1_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; form_P_MOI("", "XGL"); break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;

        if (b_maTen == "MA") {
            var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_dt_thuchien_bt_phuckhao1_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_dt_thuchien_bt_phuckhao1_P_CHUYEN_HANG(); }
            b_ten.focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_thongtin_canbo() {
    try {
        var b_so_theId = $get(b_gocId).value;
        hts_dungchung.Fs_THONGTIN_CANBO(b_so_theId, ns_thongtin_canbo_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_thongtin_canbo_kq(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
function ns_dt_thuchien_bt_phuckhao1_P_MA_KTRA() {
    try {
        var b_ma = $get(b_baitiId).value;
        var b_causo = $get(b_CausoId).value;
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_dto.Fs_NS_DT_THUCHIEN_BT_MA(b_ma, b_causo, b_TrangKt, a_cot, ns_dt_thuchien_bt_phuckhao1_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_thuchien_bt_phuckhao1_P_KETQUA() {
    try {
        var b_ma = $get(b_baitiId).value; 
        if (b_ma != "") {            
            sns_dto.Fs_NS_DT_PHUCKHAO(b_ma, ns_dt_thuchien_bt_phuckhao1_P_KETQUA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_thuchien_bt_phuckhao1_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    ns_dt_thuchien_bt_phuckhao1_P_KETQUA();
}
function ns_dt_thuchien_bt_phuckhao1_P_KETQUA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    $get(b_noidung_pkId).value = a_kq[0];
    
}
function ns_dt_thuchien_bt_phuckhao1_P_TRALOI() {
    try {
        var a_cot_ct = GridX_Fas_tenCot(b_grlkeId);
        var b_ma = $get(b_baitiId).value;
        var b_causo = $get(b_CausoId).value;
        sns_dto.Fs_NS_DT_THUCHIEN_BT_CT(b_ma, b_causo, a_cot_ct, ns_dt_thuchien_bt_phuckhao1_P_TRALOI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_thuchien_bt_phuckhao1_P_TRALOI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    if (a_kq[0] == "") GridX_datTrang(b_grlkeId); else GridX_datBang(b_grlkeId, a_kq[0]);
}
var ns_dt_thuchien_bt_phuckhao1_choAct = 0;
function ns_dt_thuchien_bt_phuckhao1_GR_lke_RowChange() {
    if (ns_dt_thuchien_bt_phuckhao1_choAct != 0) clearTimeout(ns_dt_thuchien_bt_phuckhao1_choAct);
    ns_dt_thuchien_bt_phuckhao1_choAct = setTimeout("ns_dt_thuchien_bt_phuckhao1_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_dt_thuchien_bt_phuckhao1_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_dt_thuchien_bt_phuckhao1_lkeCho); ns_dt_thuchien_bt_phuckhao1_P_LKE(); }
}

function ns_dt_thuchien_bt_phuckhao1_P_NH() {
    try {
        var b_ma = $get(b_baitiId).value;
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var b_so_id = $get(b_so_idId).value;
        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), a_cot_ct = GridX_Fdt_cotGtri(b_grlkeId);
        sns_dto.Fs_NS_DT_THUCHIEN_BT_NH(b_ma,b_so_id, a_dt_ct, a_cot_ct, a_cot, ns_dt_thuchien_bt_phuckhao1_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_thuchien_bt_phuckhao1_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else { 
    }
    return false;
}
function ns_dt_thuchien_bt_phuckhao1_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    $get(b_gocId).focus();
    return false;
}
function ns_dt_thuchien_bt_phuckhao1_P_SEND() {
    try {
        var b_ma = $get(b_baitiId).value, b_noidung = $get(b_noidung_pkId).value;         
        sns_dto.Fs_NS_DT_THUCHIEN_BT_PHUCKHAO(b_ma,b_noidung, ns_dt_thuchien_bt_phuckhao1_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_thuchien_bt_phuckhao1_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI("loi:Bạn đã phúc khảo bài thi thành công:loi");
    }
    return false;
}
function ns_dt_thuchien_bt_phuckhao1_P_TIEPTHEO_QUAYLAI() {
    ns_dt_thuchien_bt_phuckhao1_P_NH();
    ns_dt_thuchien_bt_phuckhao1_P_MA_KTRA();
    var loai_cauhoi = $get(b_loai_chId).value;
    if (loai_cauhoi == 1) {
        $get("tdlbl").style.display = "none";
        $get("bt_grid").style.display = "block";
        $get("bt_noidung").style.display = "none";
    } else {
        $get("bt_grid").style.display = "none";
        $get("tdlbl").style.display = "block";
        $get("bt_noidung").style.display = "block";
    }
} 
function ns_dt_thuchien_bt_phuckhao1_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    if (b_ma == "") ns_dt_thuchien_bt_phuckhao1_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        return false;
        //sns_dto.Fs_NS_DT_THUCHIEN_BT_XOA(b_ma, a_tso, a_cot, ns_dt_thuchien_bt_phuckhao1_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_dt_thuchien_bt_phuckhao1_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dt_thuchien_bt_phuckhao1_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dt_thuchien_bt_phuckhao1_P_CHUYEN_HANG(); }
    }
}

function ns_dt_thuchien_bt_phuckhao1_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        //var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        //if (b_ma == "") form_P_MOI(b_vungId, "XGL"); else form_P_GridX_TEXT(b_vungId, b_grlkeId);
    }
    catch (err) { form_P_LOI(err); }
}

function ns_dt_thuchien_bt_phuckhao1_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var a_cmtnd = "", a_so_the = $get(b_gocId).value;
        sns_dto.Fs_NS_DT_THUCHIEN_BT_LKE(a_tso, a_cot, a_cmtnd, a_so_the, ns_dt_thuchien_bt_phuckhao1_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_dt_thuchien_bt_phuckhao1_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);

}

function form_thoat() {
    location.reload(false);
}