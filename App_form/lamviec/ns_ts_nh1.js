var b_vungId, b_so_idId, b_grlkeId, b_slideId, b_mode, b_gchuId, b_vungtkId;
var b_doi = 0, b_cho_control = 0, b_tu_gioId, b_tu_phutId, b_den_gioId, b_den_phutId, b_so_phutId, b_cvId;

function ns_ts_nh_KD() {
    b_vungId = form_Fs_VUNG_ID('UPa_ct');
    b_vungtkId = form_Fs_VUNG_ID('Upa_tk');
    b_cvId = form_Fs_VTEN_ID(b_vungId, 'cv');
    b_tu_gioId = form_Fs_VTEN_ID(b_vungId, 'tu_gio');
    b_tu_phutId = form_Fs_VTEN_ID(b_vungId, 'tu_phut');
    b_den_gioId = form_Fs_VTEN_ID(b_vungId, 'den_gio');
    b_den_phutId = form_Fs_VTEN_ID(b_vungId, 'den_phut');
    b_so_phutId = form_Fs_VTEN_ID(b_vungId, 'so_phut');
    b_xongId = form_Fs_VTEN_ID(b_vungId, 'phan_tram_xong');
    b_phantramId = form_Fs_VTEN_ID(b_vungId, 'PHAN_TRAM');
    b_grlkeId = form_Fs_VUNG_ID('GR_lke');
    b_slideId = b_grlkeId + '_slide';
    b_doi = 0;
    b_cho_control = setInterval("P_cho(0)", 200);
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (C_NVL(b_dtuong) != "") {
            if (b_dtuong.toUpperCase().indexOf("SO_ID") >= 0) {
                b_doi = 0;
                clearTimeout(b_cho_control);
                b_cho_control = setInterval("P_cho('" + a_tso[0] + "')", 200);
            }
        }
    } catch (err) {
        form_P_LOI(err);
    }
}
function P_cho(b_id) {
    try {
        if (b_doi == 0) {
            if (b_id > 0) drop_set_selected($get(b_cvId), b_id);
            ns_ts_nh_P_LKE();
            b_doi = 1;
            clearTimeout(b_cho_control);
        }
    } catch (err) {
        clog(err);
        b_doi = 0;
    }
}
function ns_ts_nh_P_KTRA(b_maTen) {
    try {
        b_maTen = b_maTen.toUpperCase();
        if (b_maTen == "GIO") {
            if (O_NVL($get(b_tu_gioId).value, 0) * 1 >= 24 || O_NVL($get(b_den_gioId).value, 0) * 1 >= 24)
                form_P_LOI('loi:Giờ không quá 24:loi');
            if (O_NVL($get(b_tu_phutId).value, 0) * 1 >= 60 || O_NVL($get(b_den_phutId).value, 0) * 1 >= 60)
                form_P_LOI('loi:Phút không quá 60:loi');
            $get(b_so_phutId).value = -(O_NVL($get(b_tu_gioId).value, 0) * 60 + O_NVL($get(b_tu_phutId).value, 0) * 1 - O_NVL($get(b_den_gioId).value, 0) * 60 - O_NVL($get(b_den_phutId).value, 0) * 1);
        }
    } catch (err) { form_P_LOI(err); }
}

function ns_ts_nh_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}


function ns_ts_nh_P_MOI() {
    form_P_MOI(b_vungId, 'X'); GridX_thoiA(b_grlkeId); return false;
}

function ns_ts_nh_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_dt = form_Faa_TEXT_ROW(b_vungId);
            var b_id_cv = $get(b_cvId).value;
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            var b_phantram = $get(b_phantramId).value;
            var b_xong = $get(b_xongId).value;
            var b_tyle = parseInt(b_phantram) + parseInt(b_xong);
            if (b_tyle > 100) {
                form_P_LOI("loi:Tổng hoàn thành đã vượt quá 100%:loi"); return false;
            }
            var b_so_id = b_hang > 0 ? CSO_SO(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")) : 0;
            sns_ts.Fs_NS_TS_NH(b_id_cv, b_so_id, b_dt, ns_ts_nh_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    } catch (err) {
        form_P_LOI(err);
        dumpError(err);
    }
}

function ns_ts_nh_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else { ns_ts_nh_P_LKE_ID(b_kq); }
}

function ns_ts_nh_P_XOA() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
        var message = confirm("Bạn có chắc chắn xóa không?");
        if (message == false) { return false; }
        var b_hang = GridX_Fi_timHangA(b_grlkeId); if (b_hang < 1) return false;
        var b_so_id = O_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "0") ns_ts_nh_P_MOI();
        else {
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            var b_dt = form_Faa_TEXT_ROW(b_vungtkId); var b_id_cv = $get(b_cvId).value;
            sns_ts.Fs_NS_TS_XOA(form_Fs_nsd(), b_so_id, b_id_cv, b_dt, a_cot, a_tso, ns_ts_nh_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    } catch (err) {
        form_P_LOI(err);
    }
}

function ns_ts_nh_P_XOA_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang == 1 && GridX_Fb_hangTrang(b_grlkeId, 2)) b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
        if (b_hang > 1 && GridX_Fb_hangTrang(b_grlkeId, b_hang)) b_hang--;
        if (b_hang < 1 || GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_ts_nh_P_MOI();
        else GridX_datA(b_grlkeId, b_hang); ns_ts_nh_P_CT();
    } catch (err) { form_P_LOI(err); }
}

function ns_ts_nh_P_CT() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return false;
        else {
            form_P_MOI(b_vungId, 'X');
            var b_so_id = O_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
            if (C_NVL(b_so_id, "") == "") return false;
            sns_ts.Fs_NS_TS_CT(form_Fs_nsd(), b_so_id, ns_ts_nh_P_CT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    } catch (err) { form_P_LOI(err); }
}

function ns_ts_nh_P_CT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else if (b_kq === "") ns_ts_nh_gv_P_CT_MOI("XGL"); else { form_P_CH_TEXT(b_vungId, b_kq); ns_ts_nh_P_LKE_HT();}
}

function ns_ts_nh_P_LKE_HT() {
    var b_id_cv = $get(b_cvId).value;
    sns_ts.Fs_NS_TS_LKE_HT(form_Fs_nsd(), b_id_cv, ns_ts_nh_P_LKE_HT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_ts_nh_P_LKE_HT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    $get(b_xongId).value = b_kq;
    return false;
}


function ns_ts_nh_P_LKE() {
    var b_dt = form_Faa_TEXT_ROW(b_vungtkId);
    var a_cot = GridX_Fas_tenCot(b_grlkeId);
    var a_tso = slide_Faobj_TUDEN(b_slideId);
    var b_id_cv = $get(b_cvId).value;
    sns_ts.Fs_NS_TS_LKE(form_Fs_nsd(), b_id_cv, b_dt, a_cot, a_tso, ns_ts_nh_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_ts_nh_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }

    var a_kq = Fas_ChMang(b_kq, '#'); slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    ns_ts_nh_P_LKE_HT();
    return false;
}

function ns_ts_nh_P_LKE_ID(b_so_id) {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), b_hangKt = GridX_Fi_hangKt(b_grlkeId), b_dt = form_Faa_TEXT_ROW(b_vungtkId);
        sns_ts.Fs_NS_TS_ID(form_Fs_nsd(), b_so_id, $get(b_cvId).value, b_dt, b_hangKt, a_cot, ns_ts_nh_P_LKE_ID_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    } catch (err) { }
}

function ns_ts_nh_P_LKE_ID_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#'), b_hang = CSO_SO(a_kq[0]), b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]); slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang > 0) GridX_datA(b_grlkeId, b_hang); form_Fctr_VTEN_DTUONG('', 'moi').focus();
}
function form_dong() {
    location.reload(false);
}