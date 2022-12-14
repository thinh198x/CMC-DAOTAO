
var ns_ds_thamgia_cmccare_lkeCho, b_vungId, b_grlkeId, b_slideId, b_ngaydID, b_ngaycID;
function ns_ds_thamgia_cmccare_P_KD() {
    ns_ds_thamgia_cmccare_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_ngaydID = form_Fs_TEN_ID(b_vungId, 'ngayd'), b_ngaycID = form_Fs_TEN_ID(b_vungId, 'ngayc');
    b_slideId = b_grlkeId + '_slide';
    ns_ds_thamgia_cmccare_lkeCho = setInterval('ns_ds_thamgia_cmccare_P_LKE_CHO()', 200);

}

function ns_ds_thamgia_cmccare_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "TINHTRANG": b_maId = b_tinhtrangId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == 'TINHTRANG') {
            ns_ds_thamgia_cmccare_P_LKE();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ds_thamgia_cmccare_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_cd.Fs_ns_ds_thamgia_cmccare_MA(b_ma, b_TrangKt, a_cot, ns_ds_thamgia_cmccare_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ds_thamgia_cmccare_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_ds_thamgia_cmccare_P_CHUYEN_HANG(); }
}

var ns_ds_thamgia_cmccare_choAct = 0;
function ns_ds_thamgia_cmccare_GR_lke_RowChange() {
    if (ns_ds_thamgia_cmccare_choAct != 0) clearTimeout(ns_ds_thamgia_cmccare_choAct);
    ns_ds_thamgia_cmccare_choAct = setTimeout("ns_ds_thamgia_cmccare_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_ds_thamgia_cmccare_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_ds_thamgia_cmccare_lkeCho); ns_ds_thamgia_cmccare_P_LKE(); }
}

function ns_ds_thamgia_cmccare_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_tso = slide_Faobj_TUDEN(b_slideId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_dt_grid = GridX_Fdt_cotGtri(b_grlkeId);
    var b_tungay = $get(b_ngaydID).value, b_denngay = $get(b_ngaycID).value;
    sns_cd.Fs_NS_DS_THAMGIA_CMCCARE_NH(b_tungay, b_denngay, b_dt_grid, a_tso, a_cot, ns_ds_thamgia_cmccare_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_ds_thamgia_cmccare_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    ns_ds_thamgia_cmccare_P_LKE();
    return false;
}
function ns_ds_thamgia_cmccare_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    $get(b_gocId).focus();
    return false;
}

function ns_ds_thamgia_cmccare_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) {
        alert("Bạn chưa chọn khai báo cần hủy");
        return false
    };
    var b_tinhtrang = $get(b_tinhtrangId).value;
    if (b_tinhtrang == 1) {
        ns_ds_thamgia_cmccare_P_XOA_KQ("loi: Cán bộ đang ở tình trạng đã phê duyệt, bạn không thể hủy :loi");
        return false;
    }
    var retVal = confirm("Bạn chắc chắn muốn hủy ?");

    if (retVal == false) {
        form_P_LOI("");
        return false;
    }
    var b_thangbd = $get(b_gocId).value;
    var b_ten = $get(b_tenId).value;
    var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId), b_dt_grid = GridX_Fdt_cotGtri(b_grlkeId);
    sns_cd.Fs_ns_ds_thamgia_cmccare_XOA(b_thangbd, b_ten, b_tinhtrang, b_dt_grid, a_tso, a_cot, ns_ds_thamgia_cmccare_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);

    return false;
}
function ns_ds_thamgia_cmccare_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_ds_thamgia_cmccare_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_ds_thamgia_cmccare_P_CHUYEN_HANG(); }
    }
}

function ns_ds_thamgia_cmccare_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        if (b_ma == "") form_P_MOI(b_vungId, "XGL"); else form_P_GridX_TEXT(b_vungId, b_grlkeId);
    }
    catch (err) { form_P_LOI(err); }
}

function ns_ds_thamgia_cmccare_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_tungay = $get(b_ngaydID).value, b_denngay = $get(b_ngaycID).value;
        sns_cd.Fs_NS_DS_THAMGIA_CMCCARE_LKE(b_tungay, b_denngay, a_tso, a_cot, ns_ds_thamgia_cmccare_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ds_thamgia_cmccare_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function form_dong() {
    location.reload(false);
}