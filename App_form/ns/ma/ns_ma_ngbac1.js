    var ns_ma_ngbac_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_lngId;
function ns_ma_ngbac_P_KD() {
    ns_ma_ngbac_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),b_grctId = form_Fs_VUNG_ID('GR_ct'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'NGAYD'); b_lngId = form_Fs_TEN_ID(b_vungId, 'LNG'); b_ngachId = form_Fs_TEN_ID(b_vungId, 'NGACH');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_slideId = b_grlkeId + '_slide';
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("LNG") >= 0) {
            $get(b_lngId).value = b_kq;
            form_P_MOI(b_vungId, "GX");
            $get(b_gchuId).innerHTML = a_tso[1]; 
            $get(b_ngachId).focus();               
        }
        else if (b_dtuong.indexOf("NGACH") >= 0){
            $get(b_ngachId).value = b_kq;
            ns_ma_ngbac_P_LKE();form_P_MOI(b_vungId, "GX");
            $get(b_gchuId).innerHTML = a_tso[1]; 
            $get(b_gocId).focus();   
        }
        else if (b_dtuong.indexOf("THAMSO") >= 0) {
            $get(b_lngId).value = a_tso[0];
            $get(b_ngachId).value = a_tso[0];
            ns_ma_ngbac_P_LKE(); form_P_MOI(b_vungId, "GX");
            $get(b_gchuId).innerHTML = "chay vao day roi";
            $get(b_gocId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_ma_ngbac_P_KTRA(b_maTen) {    
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "NGAYD": b_maId = b_gocId; break;
            case "LNG": b_maId = b_lngId; break;
            case "NGACH": b_maId = b_ngachId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen=="LNG")
        {
            skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_ma_ngbac_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            $get(b_ngachId).focus();
        }
        if (b_maTen == "NGACH")
        {
            skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_ma_ngbac_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_ma_ngbac_P_LKE();$get(b_gocId).focus();
        }
        if (b_maTen == "NGAYD") {
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ngayd", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_ma_ngbac_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_ma_ngbac_P_CHUYEN_HANG(); }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_ngbac_P_MA_KTRA() {
    try {
        var b_ngayd = C_NVL($get(b_gocId).value);
        if (b_ngayd != "") {
            var b_lng = $get(b_lngId).value, b_ngach =$get(b_ngachId).value;
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId),a_cot_ct = GridX_Fas_tenCot(b_grctId);
            sns_ma_ch.Fs_NS_MA_NGBAC_MA(b_lng,b_ngach,b_ngayd, b_TrangKt, a_cot,a_cot_ct, ns_ma_ngbac_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_ngbac_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);GridX_datBang(b_grctId, a_kq[4]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_ma_ngbac_P_CHUYEN_HANG(); }
}

function ns_ma_ngbac_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    $get(b_gchuId).innerHTML = b_kq;
    form_P_MOI(b_vungId, "GX");
}
var ns_ma_ngbac_choAct = 0;
function ns_ma_ngbac_GR_lke_RowChange() {
    if (ns_ma_ngbac_choAct != 0) clearTimeout(ns_ma_ngbac_choAct);
    ns_ma_ngbac_choAct = setTimeout("ns_ma_ngbac_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_ma_ngbac_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_ma_ngbac_lkeCho); ns_ma_ngbac_P_LKE(); }
}
function ns_ma_ngbac_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_datTrang(b_grctId);
    $get(b_gocId).focus();
    $get(b_so_idId).value = '0';
    return false;
}

function ns_ma_ngbac_P_LKE() {
    try {
        var b_lng = $get(b_lngId).value,b_ngach = $get(b_ngachId).value,a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_NS_MA_NGBAC_LKE(b_lng,b_ngach,a_tso, a_cot, ns_ma_ngbac_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function ns_ma_ngbac_P_LKE_KQ(b_kq) {
    ns_ma_ngbac_P_MOI();
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_ma_ngbac_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")),
        a_cot = GridX_Fas_tenCot(b_grctId);
        if (b_so_id == "") { form_P_MOI(b_vungId, "XGL"); GridX_datTrang(b_grctId); }
        else sns_ma_ch.Fs_NS_MA_NGBAC_CT(b_so_id, a_cot, Fs_MA_NGBAC_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        $get(b_so_idId).value= b_so_id;
    }
    catch (err) { form_P_LOI(err); }
}
function Fs_MA_NGBAC_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId);
    else GridX_datBang(b_grctId, a_kq[1]);
}
function ns_ma_ngbac_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var b_so_id = $get(b_so_idId).value;
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fdt_cotGtri(b_grctId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
    sns_ma_ch.Fs_NS_MA_NGBAC_NH(b_so_id,b_TrangKt, a_dt_ct, a_cot,a_cot_lke,ns_ma_ngbac_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_ma_ngbac_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);GridX_datBang(b_grctId, a_kq[4]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
    }
    return false;
}
function ns_ma_ngbac_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }

    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") ns_ma_ngbac_P_MOI();
    else {
        var b_lng = $get(b_lngId).value, b_ngach = $get(b_ngachId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_NS_MA_NGBAC_XOA(b_lng,b_ngach,b_so_id, a_tso, a_cot, ns_ma_ngbac_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_ma_ngbac_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId); 
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_ma_ngbac_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_ma_ngbac_P_CHUYEN_HANG(); }
    }
}

function ns_ma_ngbac_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_ma_ngbac_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_ma_ngbac_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function ns_ma_ngbac_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}

// START: Trả giá trị chọn trên lưới //       
// Tra gia tri chon cho form goi
function form_P_TRA_CHON_GRID(b_ten) {
    try {
        var a_kq = form_P_TRA_GTRI_GRID(b_ten);
        form_P_DONG(window.name, a_kq);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
// Tra mang gia tri theo ten
function form_P_TRA_GTRI_GRID(b_ten) {
    try {
        var a_ten = b_ten.split(','), a_kq = [];
        for (var i = 0; i < a_ten.length; i++) {
            var a_grid = a_ten[i].split(':');
            var b_gridId = form_Fs_VUNG_ID(a_grid[0]);
            var b_hang = GridX_Fi_timHangA(b_gridId);
            a_kq[i] = GridX_Fas_layGtri(b_gridId, b_hang, a_grid[1]);
        }
        return a_kq;
    }
    catch (err) { return null; }
}
function form_dong() {
    location.reload(false);
}

// END: Trả giá trị chọn trên lưới //