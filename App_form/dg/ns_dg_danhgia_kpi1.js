var ns_dg_danhgia_kpi_P_KD_lkeCho, ns_dg_danhgia_kpi_P_KD_lkecbCho, b_vungId, b_grlkeId, b_grctId, b_mt, b_so_idId;
function ns_dg_danhgia_kpi_P_KD_P_KD() {
    ns_dg_danhgia_kpi_P_KD_lkeCho, ns_dg_danhgia_kpi_P_KD_lkecbCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct');
    b_thangId = form_Fs_TEN_ID(b_vungId, 'SO_THE'), b_phongId = form_Fs_TEN_ID(b_vungId, 'ngayqd');
    b_slideId = b_grlkeId + '_slide';
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    ns_dg_danhgia_kpi_P_KD_lkeCho = setInterval('ns_dg_danhgia_kpi_P_KD_P_LKE_CHO()', 200);
    ns_dg_danhgia_kpi_P_KD_lkecbCho = setInterval('ns_dg_danhgia_kpi_P_KD_P_LKE_CB_CHO()', 200);
}
function ns_dg_danhgia_kpi_P_KD_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "PHONG": b_maId = b_phongId; break;
            case "THANG": b_maId = b_thangId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null) return;
        if (b_maTen == "PHONG") {
            ns_dg_danhgia_kpi_P_KD_P_MOI();
            ns_dg_danhgia_kpi_P_KD_P_LKE();
            ns_dg_danhgia_kpi_P_KD_P_LKE_CB();
        }
        if (b_maTen == "THANG") {
            var b_thang = $get(b_thangId).value;
            if (b_thang != "") {
                var b_hang = GridX_Fi_timHangD(b_grlkeId, "thang", b_thang);
                if (b_hang > -1) {
                    GridX_datA(b_grlkeId, b_hang);
                    ns_dg_danhgia_kpi_P_KD_P_CHUYEN_HANG();
                }
                else {
                    ns_dg_danhgia_kpi_P_KD_P_LKE_CB();
                    GridX_thoiA(b_grlkeId);
                }
            }
            else $get(b_thangId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dg_danhgia_kpi_P_KD_P_LKE_CB() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grctId), b_phong = $get(b_phongId).value;
        sdg.Fs_NS_DG_DANHGIA_KPI_P_KD_LKE_CB(b_phong, a_cot, ns_dg_danhgia_kpi_P_KD_P_LKE_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dg_danhgia_kpi_P_KD_P_LKE_CB_KQ(b_kq) {
    if (b_kq == "") GridX_datTrang(b_grctId);
    else {
        GridX_datBang(b_grctId, b_kq);
    }
}
var ns_dg_danhgia_kpi_P_KD_choAct = 0;
function ns_dg_danhgia_kpi_P_KD_GR_lke_RowChange() {
    if (ns_dg_danhgia_kpi_P_KD_choAct != 0) clearTimeout(ns_dg_danhgia_kpi_P_KD_choAct);
    ns_dg_danhgia_kpi_P_KD_choAct = setTimeout("ns_dg_danhgia_kpi_P_KD_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_dg_danhgia_kpi_P_KD_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_dg_danhgia_kpi_P_KD_lkeCho); ns_dg_danhgia_kpi_P_KD_P_LKE(); }
}
function ns_dg_danhgia_kpi_P_KD_P_LKE_CB_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_dg_danhgia_kpi_P_KD_lkecbCho); ns_dg_danhgia_kpi_P_KD_P_LKE_CB(); }
}
function ns_dg_danhgia_kpi_P_KD_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    ns_dg_danhgia_kpi_P_KD_P_LKE_CB();
}
function ns_dg_danhgia_kpi_P_KD_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId);
        sdg.Fs_NS_DG_GIAO_KPI_CHO_CB_LKE(a_cot, ns_dg_danhgia_kpi_P_KD_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dg_danhgia_kpi_P_KD_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
var ns_dg_giao_kpi_choAct = 0;
function ns_dg_danhgia_kpi_GR_lke_RowChange() {
    if (ns_dg_giao_kpi_choAct != 0) clearTimeout(ns_dg_giao_kpi_choAct);
    ns_dg_giao_kpi_choAct = setTimeout("ns_dg_giao_kpi_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_dg_danhgia_kpi_P_KD_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_dt = form_Faa_TEXT_ROW(b_vungId),
                a_cot_ct = GridX_Fdt_cotGtri(b_grctId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
            sdg.Fs_NS_DG_DANHGIA_KPI_P_KD_NH(b_TrangKt, b_dt, a_cot_ct, a_cot_lke, ns_dg_danhgia_kpi_P_KD_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_dg_danhgia_kpi_P_KD_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_thangId).focus();
    }
    return false;
}
function ns_dg_giao_kpi_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")),
        a_cot = GridX_Fas_tenCot(b_grctId);

        if (b_so_id == "") { form_P_MOI(b_vungId, "XGL"); GridX_datTrang(b_grctId); }
        else sdg.Fs_NS_DG_GIAO_KPI_CHO_CB_CT(b_so_id, a_cot, Fs_MA_DONGIA_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
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
function ns_dg_danhgia_kpi_P_KD_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_thang = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "thang"));
    $get(b_thangId).value = b_thang;
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[0] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[0]);
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
}
function ns_dg_danhgia_kpi_P_KD_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_thang = GridX_Fas_layGtri(b_grlkeId, b_hang, "thang");
    if (b_thang == "") ns_dg_danhgia_kpi_P_KD_P_MOI();
    else {
        var b_phong = $get(b_phongId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_NS_DG_DANHGIA_KPI_P_KD_XOA(b_phong, b_thang, a_tso, a_cot, ns_dg_danhgia_kpi_P_KD_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_dg_danhgia_kpi_P_KD_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dg_danhgia_kpi_P_KD_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dg_danhgia_kpi_P_KD_P_CHUYEN_HANG(); }
    }
}


function ns_dg_danhgia_kpi_P_KD_P_CHUYEN_TIEN() {
    try {
        var b_tenf = '<%= this.ResolveUrl("~/App_form/bc/tl_ngbc.aspx") %>',
            b_phong = $get(b_phongId).value,
            b_thang = $get(b_thangId).value,
            b_ten_phong = document.getElementById(b_phongId)[document.getElementById(b_phongId).selectedIndex].innerText;
        if (b_thang == null || b_thang == "") { alert("Chưa chọn chi tiết"); }
        else {
            var b_tso = b_phong + "#" + b_thang + "#" + b_ten_phong;
            form_P_MO(b_tenf, null, ["BL", [b_tso]], null);
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_dg_danhgia_kpi_P_KD_TINH() {
    try {
        var b_phong = $get(b_phongId).value,
        b_thang = $get(b_thangId).value;
        if (b_thang == null || b_thang == "") { alert("Phải nhập tháng tính lương"); }
        else {
            var a_cot = GridX_Fas_tenCot(b_grctId);
            sdg.Fs_NS_DG_DANHGIA_KPI_P_KD_TINH(b_phong, b_thang, a_cot, ns_dg_danhgia_kpi_P_KD_P_TINH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dg_danhgia_kpi_P_KD_P_TINH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == "") GridX_datTrang(b_grctId);
    else GridX_datBang(b_grctId, b_kq);
    return false;
}

function ns_dg_danhgia_kpi_P_KD_P_IN() {
    var a_cot = GridX_Fdt_cotGtri(b_grctId);
    var b_ma_bc = 'ns_ns_dg_danhgia_kpi_P_KD.xml',
        b_ddan = '~/Templates/ns/', a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
    var b_kieu_in = 'E', b_ten_rp = b_ma_bc;
    var a_dt = GridX_Fdt_cotGtri(b_grctId);
    if (b_ten_rp == "") { form_P_LOI('Chưa chọn đúng báo cáo'); return; }
    sti_ch.Fs_EXCEL_TIENLUONG("ns_ngbc", "TT", b_ma_bc, b_ddan, b_ten_rp, b_kieu_in, a_dt_ct, a_dt, P_EXCEL_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function P_EXCEL_KQ(b_kq) {
    //?md=TT
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_MO(form_Fs_TM() + '/App_form/bc/xexcel.aspx?md=TT', null, null, "C");
}
function form_dong() {
    location.reload(false);
}