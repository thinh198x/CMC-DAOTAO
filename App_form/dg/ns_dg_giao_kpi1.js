var ns_dg_giao_kpi_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_grctId, b_chatluongId, b_so_idId, b_gchuId;
function ns_dg_giao_kpi_P_KD() {
    ns_dg_giao_kpi_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_grctId = form_Fs_VUNG_ID('GR_ct');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_slideId = b_grlkeId + '_slide';
    ns_dg_giao_kpi_lkeCho = setInterval('ns_dg_giao_kpi_P_LKE_CHO()', 200);
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("MASP") >= 0) {
            $get(b_gocId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_gocId).focus();
        }
        else if (b_dtuong.indexOf("CHATLUONG") >= 0) {
            var b_masp = $get(b_gocId).value;
            if (b_masp == "") { alert('Phải nhập mã sản phẩm trước'); return; }
            $get(b_chatluongId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_chatluongId).focus();
            ns_dg_giao_kpi_P_LKE();
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_dg_giao_kpi_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MASP": b_maId = b_gocId; form_P_MOI("", "XGL"); GridX_datTrang(b_grctId); break;
            case "CHATLUONG": b_maId = b_chatluongId; break;
            //case "NGAY": b_maId = b_ngayId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MASP") {
            skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_dg_giao_kpi_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_maTen == "CHATLUONG") {
            skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_dg_giao_kpi_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_dg_giao_kpi_P_LKE();
        }
        //else if (b_maTen == "NGAY") {
        //    var b_hang = GridX_Fi_timHangD(b_grlkeId, "ngay", b_ma.value);
        //    if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_dg_giao_kpi_P_MA_KTRA(); }
        //    else { GridX_datA(b_grlkeId, b_hang); ns_dg_giao_kpi_P_CHUYEN_HANG(); }
        //}
    }
    catch (err) { form_P_LOI(err); }
}

function ns_dg_giao_kpi_P_MA_KTRA() {
    try {
        var b_masp = C_NVL($get(b_gocId).value);
        if (b_masp != "") {
            var b_chatluong = $get(b_chatluongId).value, b_ngay = $get(b_ngayId).value;
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            //stl_ma.Fs_ns_dg_giao_kpi_MA(b_masp, b_chatluong, b_ngay, b_TrangKt, a_cot, ns_dg_giao_kpi_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dg_giao_kpi_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) { form_P_MOI(b_vungId, "X"); GridX_datTrang(b_grctId); }
    else { GridX_datA(b_grlkeId, b_hang); ns_dg_giao_kpi_P_CHUYEN_HANG(); }
}

function ns_dg_giao_kpi_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    $get(b_gchuId).innerHTML = b_kq;
    form_P_MOI(b_vungId, "GX");
}
var ns_dg_giao_kpi_choAct = 0;
function ns_dg_giao_kpi_GR_lke_RowChange() {
    if (ns_dg_giao_kpi_choAct != 0) clearTimeout(ns_dg_giao_kpi_choAct);
    ns_dg_giao_kpi_choAct = setTimeout("ns_dg_giao_kpi_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_dg_giao_kpi_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_dg_giao_kpi_lkeCho); ns_dg_giao_kpi_P_LKE(); }
}
function ns_dg_giao_kpi_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    $get(b_so_idId).value = "";
    $get(b_gocId).focus();
}

function ns_dg_giao_kpi_P_LKE() {
    try {
        //var b_masp = $get(b_gocId).value, b_chatluong = $get(b_chatluongId).value, 
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_NS_DG_GIAO_KPI_LKE(a_tso, a_cot, ns_dg_giao_kpi_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function ns_dg_giao_kpi_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_dg_giao_kpi_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")),
        a_cot = GridX_Fas_tenCot(b_grctId);
        $get(b_so_idId).value = b_so_id;
        if (b_so_id == "") { form_P_MOI(b_vungId, "XGL"); GridX_datTrang(b_grctId); }
        else sdg.Fs_NS_DG_GIAO_KPI_CT(b_so_id, a_cot, Fs_MA_DONGIA_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function Fs_MA_DONGIA_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId);
    else GridX_datBang(b_grctId, a_kq[1]);
}
function ns_dg_giao_kpi_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var b_so_id = $get(b_so_idId).value;
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fdt_cotGtri(b_grctId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
    //stl_ma.Fs_ns_dg_giao_kpi_NH(b_so_id, b_TrangKt, a_dt_ct, a_cot, a_cot_lke, ns_dg_giao_kpi_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_dg_giao_kpi_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = b_kq.split('#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
    }
    return false;
}
function ns_dg_giao_kpi_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") ns_dg_giao_kpi_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        //stl_ma.Fs_ns_dg_giao_kpi_XOA(b_so_id, a_tso, a_cot, ns_dg_giao_kpi_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_dg_giao_kpi_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dg_giao_kpi_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dg_giao_kpi_P_CHUYEN_HANG(); }
    }
}

function ns_dg_giao_kpi_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_dg_giao_kpi_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_dg_giao_kpi_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function ns_dg_giao_kpi_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}
function form_dong() {
    location.reload(false);
}