
var ns_dt_ketquadt_lkeCho, b_vungId, b_grlkeId, b_slideId, b_grctId, b_gchuId, b_so_idId, _moiId;
function ns_dt_ketquadt_P_KD() {
    ns_dt_ketquadt_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_grctId = form_Fs_VUNG_ID('GR_ct');
    b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'); b_so_qdId = form_Fs_TEN_ID(b_vungId, 'so_qd');
    b_ngayqdId = form_Fs_TEN_ID(b_vungId, 'ngay_qd');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_moiId = form_Fs_VTEN_ID('', 'moi');
    b_slideId = b_grlkeId + '_slide';
    ns_dt_ketquadt_lkeCho = setInterval('ns_dt_ketquadt_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("MA") >= 0) {
            $get(b_gocId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            ns_dt_ketquadt_P_LKECB();
            $get(b_so_qdId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ketquadt_P_LKECB() {
    try {
        var b_ma = $get(b_gocId).value;
        var a_cot = GridX_Fas_tenCot(b_grctId);
        sns_dt.Fs_NS_DT_KETQUADT_LKECB(b_ma, a_cot, ns_dt_ketquadt_P_LKECB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function ns_dt_ketquadt_P_LKECB_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang(b_grctId, b_kq);
}

function ns_dt_ketquadt_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; form_P_MOI("", "XL"); break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_dt_ketquadt_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_dt_ketquadt_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_dt_ketquadt_P_CHUYEN_HANG(); }
        }
        else skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_dt_ketquadt_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function ns_dt_ketquadt_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_dt.Fs_NS_DT_KETQUADT_MA(b_ma, b_TrangKt, a_cot, ns_dt_ketquadt_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ketquadt_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_dt_ketquadt_P_CHUYEN_HANG(); }
}
function ns_dt_ketquadt_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}
function ns_dt_ketquadt_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}
function ns_dt_ketquadt_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grctId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        if (b_value != "") {
            if (b_cot == "SO_THE") {
                sns_tt.Fs_NS_CB_HOI(b_value, ns_dt_ketquadt_P_CB_HOI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
            
        } 
        if (b_value != "") {
            GridX_ThemHang(b_grctId);
            if (b_cot == "KETQUA") {
                var so_the = GridX_Fas_layGtri(b_grctId, b_hang, "so_the");
                if (so_the == "") { 
                    GridX_datGtri(b_grctId, b_hang, "ketqua", "");
                    return false;
                }
            }
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_dt_ketquadt_P_CB_HOI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var b_hang = GridX_Fi_timHangA(b_grctId);
    var a_kq = Fas_ChMang(b_kq, '#');
    GridX_datGtri(b_grctId, b_hang, ["so_the"], [a_kq[0]], 'K');
    GridX_datGtri(b_grctId, b_hang, ["phong"], [a_kq[1]], 'K');
    GridX_datGtri(b_grctId, b_hang, ["ten"], [a_kq[2]], 'K');
}

var ns_dt_ketquadt_choAct = 0;
function ns_dt_ketquadt_GR_lke_RowChange() {
    if (ns_dt_ketquadt_choAct != 0) clearTimeout(ns_dt_ketquadt_choAct);
    ns_dt_ketquadt_choAct = setTimeout("ns_dt_ketquadt_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_dt_ketquadt_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_dt_ketquadt_lkeCho); ns_dt_ketquadt_P_LKE(); }
}

function ns_dt_ketquadt_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    $get(b_so_idId).value = "0";
    return false;
}
// lke
function ns_dt_ketquadt_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.Fs_NS_DT_KETQUADT_LKE(a_tso, a_cot, ns_dt_ketquadt_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function ns_dt_ketquadt_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
//Nhap

function ns_dt_ketquadt_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_dt = form_Faa_TEXT_ROW(b_vungId),
                b_so_id = $get(b_so_idId).value, b_dt_ct = GridX_Fdt_cotGtri(b_grctId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var tt = ns_dt_ketqua_hoi();
            if (!tt) { 
                return false;
            }
                
            sns_dt.Fs_NS_DT_KETQUADT_NH(b_TrangKt, b_so_id, b_dt, b_dt_ct, a_cot_lke, ns_dt_ketquadt_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_dt_ketqua_hoi()
{
    var b_vitri = GridX_Fi_timHangT(b_grctId);
    for (var i = 1; i < b_vitri; i++) {
        var b_so_the = GridX_Fas_layGtri(b_grctId, i, "so_the");
        if (b_so_the != "") {
            var kq = GridX_Fas_layGtri(b_grctId, i, "ketqua");
            if (kq == "") {
                form_P_LOI("loi:Chưa nhập kết quả cho cán bộ " + b_so_the + " :loi");
                return false;
            } 
        }
    }
    return true;
}
function ns_dt_ketquadt_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        $get(b_so_idId).value = b_so_id;
        $get(b_gocId).focus();
    }
    return false;
}
function ns_dt_ketquadt_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")),
        a_cot = GridX_Fas_tenCot(b_grctId);
    if (b_so_id == "0") form_P_MOI(b_vungId, "XGL");
    else sns_dt.Fs_NS_DT_KETQUADT_CT(b_so_id, a_cot, ns_dt_ketquadt_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = b_so_id;
}
function ns_dt_ketquadt_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId);
    else GridX_datBang(b_grctId, a_kq[1]);
}
function ns_dt_ketquadt_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang == -1) return false;
    if (b_hang < 1) return;
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") ns_dt_ketquadt_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.Fs_NS_DT_KETQUADT_XOA(b_so_id, a_tso, a_cot, ns_dt_ketquadt_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_dt_ketquadt_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dt_ketquadt_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dt_ketquadt_P_CHUYEN_HANG(); }
    }
}
function form_dong() {
    location.reload(false);
}