var b_vungId, b_vung_gvId, b_vung_dgId, b_id_cutId, b_vung_tsId, b_so_idId, b_grlkeId, b_slideId, b_mode, b_gchuId, b_id_tsId, b_grdglkeId, b_slidetsId;
var b_doi = 0, b_cho_control = 0, b_tu_gioId, b_tu_phutId, b_vung_tcId, b_den_gioId, b_den_phutId, b_so_phutId, b_tmf, b_kqua_dgId, b_danh_giaId, b_btn_ct_id, b_huy_id, b_ts_id, b_danhgia_id, b_trao_doi_id;
function ns_ts_KD(b_frm) {
    b_tmf = b_frm;
    b_vungId = form_Fs_VUNG_ID('UPa_ct');
    b_vung_gvId = form_Fs_VUNG_ID('tab_pgiaoviec');
    b_vung_tcId = form_Fs_VUNG_ID('tab_ptc');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_id_cutId = form_Fs_VTEN_ID('UPa_hi', 'id_cut');
    b_id_tsId = form_Fs_VTEN_ID('UPa_hi', 'id_ts');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_grlkeId = form_Fs_VUNG_ID('GR_lke');
    b_slideId = b_grlkeId + '_slide';
    b_trao_doi_id = form_Fs_VTEN_ID('', 'trao_doi');
    b_ma_duanId = form_Fs_TEN_ID(b_vung_gvId, 'ma_du_an');
    b_hien_daihanId = form_Fs_VUNG_ID('hien_daihan');
    b_hien_nganhanId = form_Fs_VUNG_ID('hien_nganhan');
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        if (b_dtuong.indexOf('NG_NHAN') >= 0) {
            GridX_thoiA(b_grbookId);
            b_hang = GridX_Fi_themTra(b_grbookId, 'ng_nhan');
            GridX_datGtri(b_grbookId, b_hang, ['ng_nhan', 'ten'], [a_tso[2], a_tso[3]]);
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_ts_P_KTRA(b_maTen) {
    try {
        b_maTen = b_maTen.toUpperCase();
        if (b_maTen == "GIO") {
            if (C_NVL($get(b_tu_gioId).value, 0) * 1 >= 24 || C_NVL($get(b_den_gioId).value, 0) * 1 >= 24)
                form_P_LOI('loi:Giờ không quá 24:loi');
            if (C_NVL($get(b_tu_phutId).value, 0) * 1 >= 60 || C_NVL($get(b_den_phutId).value, 0) * 1 >= 60)
                form_P_LOI('loi:Phút không quá 60:loi');
            $get(b_so_phutId).value = -(C_NVL($get(b_tu_gioId).value, 0) * 60 + C_NVL($get(b_tu_phutId).value, 0) * 1 - C_NVL($get(b_den_gioId).value, 0) * 60 - C_NVL($get(b_den_phutId).value, 0) * 1);
        }
    } catch (err) { form_P_LOI(err); }
}

function ns_ts_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}

function ns_ts_gv_P_CT_MOI(b_dk) {
    form_P_MOI(b_vung_gvId, b_dk);
}

//giao việc với id_ct = id cấp trên của thằng đang focus

function ns_ts_gv_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vung_gvId);
    if (b_loi != "") form_P_LOI(b_loi);
    else {
        var a_dt = form_Faa_TEXT_ROW(b_vung_gvId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = 0; var b_id_ct = 0;
        a_dt[0].push('id_ct');
        //if (b_mode == 'GVC') {
        //    if (b_hang > 0) {
        //        b_so_id = '0';
        //        a_dt[1].push(C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id")));
        //    }
        //    else form_P_LOI('loi:Khong co viec cha:loi');
        //}
        if (b_mode == 'GV') {
            b_id_ct = b_hang < 1 ? 0 : C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id_ct"));
            if (b_id_ct === undefined)
                b_id_ct = 0;
        }
        if (b_mode == 'CT') {
            if (b_hang < 1) return;
            b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
            b_id_ct = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id_ct"));
        }
        if (b_mode == 'GVC') {
            if (b_hang < 1) return;
            b_so_id = '0';
            b_id_ct = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
        }
        a_dt[1].push(b_id_ct);
        sns_ts.Fs_NS_TS_GV_NH(form_Fs_nsd(), b_so_id, a_dt, ns_ts_gv_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}

function ns_ts_gv_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        $get(b_so_idId).value = a_kq[0];
        ns_ts_gv_P_LKE_ID(a_kq[0]); return false;
    }
}

function ns_ts_gv_P_XOA() {
    try {
        if (confirm("Bạn có chắc chắn muốn xóa?") == true) {
            var b_hang = GridX_Fi_timHangA(b_grlkeId); if (b_hang < 1) return false;
            var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
            if (b_so_id == "0") ns_ts_P_MOI();
            else {
                var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId), b_dt = form_Faa_TEXT_ROW(b_vungId)
                    , b_path = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "path"));
                sns_ts.Fs_NS_TS_GV_XOA(form_Fs_nsd(), b_so_id, b_path, b_dt, a_cot, a_tso, ns_ts_gv_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        form_P_LOI('');
        return false;
    } catch (err) {
        form_P_LOI(err);
    }
}

function ns_ts_gv_P_XOA_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang == 1 && GridX_Fb_hangTrang(b_grlkeId, 2)) b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
        if (b_hang > 1 && GridX_Fb_hangTrang(b_grlkeId, b_hang)) b_hang--;
        if (b_hang < 1 || GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_ts_P_MOI();
        else {
            GridX_datA(b_grlkeId, b_hang); ns_ts_gv_P_CT();
            $get(b_so_idId).value = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
            $get(b_id_cutId).value = 0;
            form_P_DatGchu(b_gchuId, 'Di chuyển thành công!');
        }
        doimau();
    } catch (err) { form_P_LOI(err); }
}

function ns_ts_GR_lke_RowChange(b_event) {
    try {
        try {
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            ns_ts_BOOKNS_CT();
        }
        catch (err) { }
    } catch (err) { form_P_LOI(err); }
}

function ns_ts_gv_P_CT() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
        if (b_so_id != "") sns_ts.Fs_NS_TS_GV_CT(form_Fs_nsd(), b_so_id, ns_ts_gv_P_CT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        else { form_P_LOI(''); return false; }
    } catch (err) { form_P_LOI(err); }
}

function ns_ts_gv_P_ENABLE() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
        var b_hien = '';
        if (b_so_id == "") b_hien = 'none';
        $get(b_btn_ct_id).style.display = b_hien;
        $get(b_huy_id).style.display = b_hien;
        $get(b_ts_id).style.display = b_hien;
        $get(b_danhgia_id).style.display = b_hien;
        $get(b_trao_doi_id).style.display = b_hien;
    } catch (err) { form_P_LOI(err); }
}



function ns_ts_gv_P_CT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else if (b_kq === "") ns_ts_gv_P_CT_MOI("XGL"); else {
        form_P_CH_TEXT(b_vung_gvId, b_kq);
        ns_ts_dg_P_LKE();
        form_P_CH_TEXT(b_vung_tcId, b_kq);
        doimau();
    }
}

function ns_ts_BOOKNS_CT() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id != "") sns_ts.Fs_NS_TS_BOOKNS_CT(form_Fs_nsd(), b_so_id, ns_ts_BOOKNS_CT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        else { form_P_LOI(''); return false; }
    } catch (err) { form_P_LOI(err); }
}

function ns_ts_BOOKNS_CT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vung_gvId, b_kq);
    ns_ts_timkiem_anhien();
    return false;
}

function ns_ts_BOOKNS_XACNHAN(b_xacnhan) {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id != "") sns_ts.Fs_NS_TS_BOOKNS_XACNHAN(form_Fs_nsd(), b_so_id, b_xacnhan, ns_ts_BOOKNS_XACNHAN_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        else { form_P_LOI(''); return false; }
    } catch (err) { form_P_LOI(err); }
}

function ns_ts_BOOKNS_XACNHAN_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    ns_ts_bookns_P_LKE();
    return false;
}


function ns_ts_bookns_P_LKE(b_dk) {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_dt = form_Faa_TEXT_ROW(b_vungId); var a_cot = GridX_Fas_tenCot(b_grlkeId); var a_tso = slide_Faobj_TUDEN(b_slideId);
        }
        sns_ts.Fs_NS_TS_BOOKNS_LKE(form_Fs_nsd(), b_dt, a_cot, ns_ts_bookns_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    } catch (err) {
        form_P_LOI(err);
    }
}
function ns_ts_bookns_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { GridX_datTrang(b_grlkeId); form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#'); GridX_datBang(b_grlkeId, a_kq[0]); doimau();
}

function ns_ts_gv_P_LKE_ID(b_so_id) {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), b_hangKt = GridX_Fi_hangKt(b_grlkeId); var b_dt = form_Faa_TEXT_ROW(b_vungId);
        sns_ts.Fs_NS_TS_GV_LKE_ID(form_Fs_nsd(), b_so_id, b_dt, b_hangKt, a_cot, ns_ts_gv_P_LKE_ID_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    } catch (err) { form_P_LOI(err); }
}

function ns_ts_gv_P_LKE_ID_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]), b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]); GridX_datBang(b_grlkeId, a_kq[3]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        if (b_hang > 0) { GridX_datA(b_grlkeId, b_hang); $get(b_so_idId).value = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id")); }
        doimau();
    } catch (err) { form_P_LOI(err); }
}

function ns_ts_gv_P_MO_DG(b_mo) {
    if (b_mo) { $get(b_vung_dgId).style.display = ''; ns_ts_dg_P_LKE(); }
    else { $get(b_vung_dgId).style.display = 'none'; }
    form_P_LOI(''); return false;
}

function ns_ts_gv_P_MO_TC(b_mo) {
    if (b_mo) {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
        if (b_id != "") $get(b_vung_tcId).style.display = '';
    }
    else $get(b_vung_tcId).style.display = 'none';
    form_P_LOI(''); return false;
}

function ns_ts_gv_P_MO_BOOK(b_mo) {
    if (b_mo) {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
        if (b_id != "") $get(b_vung_bookId).style.display = '';
    }
    else $get(b_vung_bookId).style.display = 'none';
    form_P_LOI(''); return false;
}

function ns_ts_gv_P_MO_GV(b_mo, b_dk) {
    if (b_mo) {
        $get(b_vung_gvId).style.display = '';
    }
    else $get(b_vung_gvId).style.display = 'none';
    form_P_LOI(''); return false;
}
function ns_ts_gv_P_MO_TS(b_mo) {
    var b_hang = GridX_Fi_timHangA(b_grlkeId); if (b_hang < 1) return false;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
    if (b_so_id != "0") form_P_MO("ns_ts_nh.aspx", null, ["SO_ID", [b_so_id]], "");
    form_P_LOI('');
    return false;
}

function ns_ts_gv_P_DC() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId); if (b_hang < 1) return false;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
        if (b_so_id == "0") ns_ts_P_MOI();
        else {
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId), b_dt = form_Faa_TEXT_ROW(b_vungId), b_path = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "path"));
            sns_ts.Fs_NS_TS_GV_DC(form_Fs_nsd(), $get(b_id_cutId).value, b_so_id, b_path, b_dt, a_cot, a_tso, ns_ts_gv_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    } catch (err) {
        form_P_LOI(err);
    }
}

function ns_ts_gv_P_BACK() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId); if (b_hang < 1) return false;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
        if (b_so_id == "0") ns_ts_P_MOI();
        else {
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            var b_dt = form_Faa_TEXT_ROW(b_vungId); var b_path = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "path"));
            sns_ts.Fs_NS_TS_GV_BACK(form_Fs_nsd(), b_so_id, b_path, b_dt, a_cot, a_tso, ns_ts_gv_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    } catch (err) {
        form_P_LOI(err);
    }
}
function ns_ts_gv_P_NEXT() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId); if (b_hang < 2) return false;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang - 1, "id"));
        var b_id_cut = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
        if (b_so_id == "0") ns_ts_P_MOI();
        else {
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId), b_dt = form_Faa_TEXT_ROW(b_vungId), b_path = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "path"));
            sns_ts.Fs_NS_TS_GV_DC(form_Fs_nsd(), b_id_cut, b_so_id, b_path, b_dt, a_cot, a_tso, ns_ts_gv_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    } catch (err) {
        form_P_LOI(err);
    }
}

function ns_ts_gv_CatDong() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return false;
    var b_so_id_cut = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
    if (b_so_id_cut === undefined) form_P_LOI('loi:Chưa chọn dòng cut:loi');;
    $get(b_id_cutId).value = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
    form_P_DatGchu(b_gchuId, 'Di chuyển: ' + C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "nd")));
    return false;
}

function ns_ts_gv_TT_P_NH(b_dk) {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return false;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
    if (b_so_id != "") sns_ts.Fs_NS_TS_TT_NH(form_Fs_nsd(), b_so_id, b_dk, ns_ts_gv_TT_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}

function ns_ts_gv_TT_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        ns_ts_gv_P_LKE_ID($get(b_so_idId).value);
    };
    return false;
}

function ns_ts_gv_P_TC_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vung_tcId);
    if (b_loi != "") form_P_LOI(b_loi);
    else {
        var a_dt = form_Faa_TEXT_ROW(b_vung_tcId); var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return false;
        else {
            var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
            sns_ts.Fs_NS_TS_GV_TC(form_Fs_nsd(), b_so_id, a_dt, ns_ts_gv_P_TC_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    return false;
}

function ns_ts_gv_P_TC_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        ns_ts_gv_P_MO_TC(false);
        ns_ts_gv_P_LKE_ID($get(b_so_idId).value);
        //ns_ts_gv_P_LKE();
    }
}

function doimau() {

    var so_hang = GridX_Fi_timHangS(b_grlkeId);
    var b_ngay_con, b_ttrang;
    for (var i = 1; i <= so_hang; i++) {
        b_ngay_con = GridX_Fas_layGtri(b_grlkeId, i, "ngay_con");
        b_ttrang = GridX_Fas_layGtri(b_grlkeId, i, "ma_ttrang");
        if (CSO_SO(b_ngay_con) <= 3 && (b_ttrang == 'DN' || b_ttrang == 'CDG')) GridX_P_MauCell(b_grlkeId, i, '', "#FFE87C", "#000000")
        else GridX_P_MauCell(b_grlkeId, i, '', "#FFFFFF", "#000000");
    }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    GridX_P_MauCell(b_grlkeId, b_hang, '', "lightcyan", "#000000")
    return false;
}

function GridX_P_MauCell(gridId, b_hang, b_cot, b_nen, b_chu) {
    try {
        var a_cell = $get(gridId).rows[b_hang].cells;
        var a_cot = (b_cot == "") ? GridX_Fas_tenCot(gridId) : b_cot.split(',');
        var b_row = $get(gridId).rows[b_hang],
            b_cellId = "";
        for (var i = 1; i <= a_cot.length; i++) {
            //b_cellId = b_row.getCellFromKey(a_cot[i]).Id;
            //var b_cell = $get(b_cellId);
            if (C_NVL(b_nen) != "") a_cell[i].style.backgroundColor = b_nen;
            if (C_NVL(b_chu) != "") a_cell[i].style.color = b_chu;
        }
    } catch (ex) { }
}

function ns_ts_TRDOI() {
    var b_nsd = form_Fs_nsd();
    var b_hang = GridX_Fi_timHangA(b_grlkeId); if (b_hang < 1) return false;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    form_P_MO(b_tmf + '/khud/khud_trdoi.aspx', null, ['TSO', ['', b_so_id]]);
    return false;
}


function ns_ts_gv_P_DG_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vung_tsId);
    if (b_loi != "") form_P_LOI(b_loi);
    else {
        var a_dt = form_Faa_TEXT_ROW(b_vung_tsId); var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return false;
        else {
            var b_hang2 = GridX_Fi_timHangA(b_grdglkeId);
            if (b_hang2 < 1) {
                var b_so_id = 0;
            }
            else { var b_so_id = C_NVL(GridX_Fas_layGtri(b_grdglkeId, b_hang2, "so_id")); }
            var b_so_id_cv = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
            sns_ts.Fs_NS_TS_DG_NH(form_Fs_nsd(), b_so_id_cv, b_so_id, a_dt, ns_ts_gv_P_DG_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    return false;
}

function ns_ts_gv_P_BOOK_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang < 1) return false;
            else {
                var b_so_id_cv = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
                var b_dt_ct = GridX_Fdt_cotGtri(b_grbookId);
                sns_ts.Fs_NS_TS_BOOK_NH(b_so_id_cv, b_dt_ct, ns_ts_gv_P_BOOK_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_ts_gv_P_BOOK_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI("loi:Nhập thành công!:loi");
    }
}


function ns_ts_gv_P_DG_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        ns_ts_dg_P_LKE();
        ns_ts_gv_P_LKE();
    }
}
//function ns_ts_gv_P_DG_LKE() {
//	try {
//		var a_cot = GridX_Fas_tenCot(b_grdglkeId);
//		var b_hang = GridX_Fi_timHangA(b_grlkeId);
//		if (b_hang < 1) return false;
//		var b_so_id_cv = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
//		sns_ts.Fs_NS_TS_DG_LKE(form_Fs_nsd(), b_so_id_cv, a_cot, ns_ts_gv_P_DG_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
//		return false;
//	}
//	catch (err) { form_P_LOI(err); }
//}
//function ns_ts_gv_P_DG_LKE_KQ(b_kq) {
//	if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
//	GridX_datBang(b_grdglkeId, b_kq);
//	return false;
//}


function ns_ts_gv_P_DG_CT() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grdglkeId);
        if (b_hang < 1) return false;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grdglkeId, b_hang, "so_id"));
        if (b_so_id != "")
            sns_ts.Fs_NS_TS_DG_CT(form_Fs_nsd(), b_so_id, ns_ts_gv_P_DG_CT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        else form_P_MOI(b_vung_dgId, 'X');
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ts_gv_P_DG_CT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vung_tsId, b_kq);
    return false;
}

function ns_ts_timkiem_anhien() {
    var b_ma_duan = $get(b_ma_duanId).value;
    if (b_ma_duan == "NH") {
        $get(b_hien_daihanId).style.display = "none";
        $get(b_hien_nganhanId).style.display = "table-row";
    }
    else {
        $get(b_hien_daihanId).style.display = "table-row";
        $get(b_hien_nganhanId).style.display = "none";
    }
}

function ns_bookns_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vung_gvId);
    if (b_loi != "") form_P_LOI(b_loi);
    else {
        var a_dt = form_Faa_TEXT_ROW(b_vung_gvId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        sns_ts.Fs_NS_TS_BOOKNS_NH(form_Fs_nsd(), b_so_id, a_dt, ns_bookns_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    return false;
}

function ns_bookns_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI("loi:nhập thành công:loi"); return false;
    }
}

function form_dong() {
    location.reload(false);
}