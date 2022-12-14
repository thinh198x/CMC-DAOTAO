var ns_ktkl_ktc_lkeCho, b_vungId, b_grlkeId, b_slideId, b_soqdId, b_hinhthucId, b_so_idId, b_gchuId, b_doi = 0, b_ngayqd;
function ns_ktkl_ktc_P_KD(b_tm) {
    ns_ktkl_ktc_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
    b_tmf = b_tm, b_hinhthucId = form_Fs_TEN_ID(b_vungId, 'hinhthuc'); b_soqdId = form_Fs_TEN_ID(b_vungId, 'soqd');
    b_cap_ktklId = form_Fs_TEN_ID(b_vungId, 'cap_ktkl'); b_noi_ktklId = form_Fs_TEN_ID(b_vungId, 'noi_ktkl');
    b_ngayqdid = form_Fs_TEN_ID(b_vungId, 'ngayqd'); 
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_so_idId = form_Fs_VTEN_ID('', 'so_id');
    ns_ktkl_ktc_lkeCho = setInterval('ns_ktkl_ktc_P_LKE_CHO()', 200);
    b_slideId = b_grlkeId + '_slide';
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("HINHTHUC") >= 0) {
            $get(b_hinhthucId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_hinhthucId).focus();
        }
        else if (b_dtuong.indexOf("CAP_KTKL") >= 0) {
            $get(b_cap_ktklId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_cap_ktklId).focus();
        }
        else if (b_dtuong.indexOf("NOI_KTKL") >= 0) {
            $get(b_noi_ktklId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_noi_ktklId).focus();
        }
        else if (b_dtuong.indexOf("THAMSO") >= 0) {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
        }
        else if (b_dtuong.indexOf("SO_THE") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grctId, b_hang, ["so_the"], [a_tso[0]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["ten"], [a_tso[1]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["phong"], [a_tso[2]], 'K');
            GridX_datA(b_grctId, b_hang, "mucthuong");
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ktkl_ktc_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SOQD": b_maId = b_soqdId; form_P_MOI("", "XGL"); GridX_datTrang(b_grctId); break;
            case "HINHTHUC": b_maId = b_hinhthucId; break;
            case "CAP_KTKL": b_maId = b_cap_ktklId; break;
            case "NOI_KTKL": b_maId = b_noi_ktklId; break;
            case "NOI_KTKL": b_maId = b_noi_ktklId; break;
            case "NGAYQD": b_maId = b_ngayqdid; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_ktkl_ktc_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_ktkl_ktc_P_LKE();
        }
        if (b_maTen == "SOQD") {
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "soqd", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_ktkl_ktc_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_ktkl_ktc_P_CHUYEN_HANG(); }
        }
        else if (b_maTen == "HINHTHUC") {
            skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_ktkl_ktc_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_maTen == "CAP_KTKL") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_ktkl_kl_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_maTen == "NOI_KTKL") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_ktkl_kl_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
        } else if (b_maTen == "NGAYQD") {
            ns_ktkl_ktc_P_NGAYKETTHUC();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ktkl_ktc_P_NGAYKETTHUC() {
    try {
        var b_ma_lqd = "KT";
        var b_ngaybd = $get(b_ngayqdid).value;
        sns_qt.Fs_NS_KHENTHUONG_SO_QD(b_ngaybd, b_ma_lqd, ns_ktkl_ktc_P_NGAYKETTHUC_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}

function ns_ktkl_ktc_P_NGAYKETTHUC_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        $get(b_soqdId).value = b_kq;

    }
}
function ns_ktkl_ktc_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_soqdId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_ktkl.Fs_NS_KTKL_KTC_MA( b_ma, b_TrangKt, a_cot, ns_ktkl_ktc_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ktkl_ktc_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_ktkl_ktc_P_CHUYEN_HANG(); }
}

function ns_ktkl_ktc_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grctId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        if (b_value != "") {
            if (b_cot == "SO_THE") {
                sns_tt.Fs_NS_CB_HOI(b_value, ns_ktkl_ktc_P_CB_HOI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_ktkl_ktc_P_CB_HOI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var b_hang = GridX_Fi_timHangA(b_grctId);
    var a_kq = Fas_ChMang(b_kq, '#');
    GridX_datGtri(b_grctId, b_hang, ["so_the"], [a_kq[0]], 'K');
    GridX_datGtri(b_grctId, b_hang, ["phong"], [a_kq[1]], 'K');
    GridX_datGtri(b_grctId, b_hang, ["ten"], [a_kq[2]], 'K');
    GridX_datA(b_grctId, b_hang, "mucthuong");
    GridX_ThemHang(b_grctId);
}

function ns_ktkl_ktc_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}

var ns_ktkl_ktc_choAct = 0;
function ns_ktkl_ktc_GR_lke_RowChange() {
    if (ns_ktkl_ktc_choAct != 0) clearTimeout(ns_ktkl_ktc_choAct);
    ns_ktkl_ktc_choAct = setTimeout("ns_ktkl_ktc_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_ktkl_ktc_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_ktkl_ktc_lkeCho); ns_ktkl_ktc_P_LKE(); }
}
function ns_ktkl_ktc_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    $get(b_so_idId).value = "0";
    $get(b_soqdId).focus();
    return false;
}

function ns_ktkl_ktc_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ktkl.Fs_NS_KTKL_KTC_LKE(a_tso, a_cot, ns_ktkl_ktc_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ktkl_ktc_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}

function ns_ktkl_ktc_P_NH() {

    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else { 
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
            var a_cot_ct = GridX_Fdt_cotGtri(b_grctId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            sns_ktkl.Fs_NS_KTKL_KTC_NH(b_TrangKt, a_dt_ct,a_cot_ct, a_cot_lke, ns_ktkl_ktc_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}

function ns_ktkl_ktc_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_soqdId).focus();
        form_P_LOI("loi:Nhập thành công:loi");
    }
    return false;
}

function ns_ktkl_ktc_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_soqd = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "soqd"));
    if (b_soqd == "0") form_P_MOI(b_vungId, "XGL");
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        sns_ktkl.Fs_NS_KTKL_KTC_CT(b_soqd, a_cot_ct, ns_ktkl_ktc_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_ktkl_ktc_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
    return false;
}

function ns_ktkl_ktc_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }

    var b_soqd = GridX_Fas_layGtri(b_grlkeId, b_hang, "soqd"),
        b_ngayqd = GridX_Fas_layGtri(b_grlkeId, b_hang, "ngayqd");
    if (b_soqd == "") ns_ktkl_ktc_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ktkl.Fs_NS_KTKL_KTC_XOA(b_soqd, b_ngayqd, a_tso, a_cot, ns_ktkl_ktc_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_ktkl_ktc_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_ktkl_ktc_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_ktkl_ktc_P_CHUYEN_HANG(); }
    }
}
function nhap_file() {
    var b_tenf = b_tmf + '/ns/ma/file_luu.aspx';
    var b_so_the = $get(b_soqdId).value;
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "KTKL_KTC", b_so_the, "Lưu File khen thưởng đơn vị"]], null);
    return false;
}
function form_dong() {
    location.reload(false);
}