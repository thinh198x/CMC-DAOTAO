function ns_ts_dg_P_MOI() {
    form_P_MOI(b_vung_dgId, 'X'); GridX_thoiA(b_grdglkeId); return false;
}

function ns_ts_gv_P_DG_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vung_dgId);
    if (b_loi != "") form_P_LOI(b_loi);
    else {
        var a_dt = form_Faa_TEXT_ROW(b_vung_dgId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return false;
        else {
            var b_id_cv = O_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
            b_hang = GridX_Fi_timHangA(b_grdglkeId);
            var b_so_id = b_hang < 1 ? 0 : O_NVL(GridX_Fas_layGtri(b_grdglkeId, b_hang, "so_id"));
            if (b_so_id === undefined) b_so_id = 0;
            sns_ts.Fs_NS_TS_DG_NH(form_Fs_nsd(), b_id_cv, b_so_id, a_dt, ns_ts_gv_P_DG_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    return false;
}

function ns_ts_gv_P_DG_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        ns_ts_dg_P_LKE_ID(b_kq);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_id_cv = O_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
        ns_ts_gv_P_LKE_ID(b_id_cv);
    }
}
function ns_ts_dg_P_XOA() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grdglkeId); if (b_hang < 1) return false;
        var b_so_id = O_NVL(GridX_Fas_layGtri(b_grdglkeId, b_hang, "so_id"));
        if (b_so_id == "0") ns_ts_dg_P_MOI();
        else {
            var a_cot = GridX_Fas_tenCot(b_grdglkeId), a_tso = slide_Faobj_TUDEN(b_slidetsId);
            var b_dt = form_Faa_TEXT_ROW(b_vung_dgId); var b_id_cv = O_NVL($get(b_so_idId).value, "0");
            sns_ts.Fs_NS_TS_DG_XOA(form_Fs_nsd(), b_so_id, b_id_cv, b_dt, a_cot, a_tso, ns_ts_dg_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    } catch (err) {
        form_P_LOI(err);
    }
}

function ns_ts_dg_P_XOA_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grdglkeId);
        if (b_hang == 1 && GridX_Fb_hangTrang(b_grdglkeId, 2)) b_hang = GridX_Fi_hangSo(b_grdglkeId);
        slide_P_SOTRANG(b_slidetsId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grdglkeId, a_kq[1]);
        if (b_hang > 1 && GridX_Fb_hangTrang(b_grdglkeId, b_hang)) b_hang--;
        if (b_hang < 1 || GridX_Fb_hangTrang(b_grdglkeId, b_hang)) ns_ts_dg_P_MOI();
        else GridX_datA(b_grdglkeId, b_hang); ns_ts_dg_P_CT();
    } catch (err) { form_P_LOI(err); }
}

function ns_ts_dg_P_CT() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grdglkeId);
        if (b_hang < 1) return false;
        else {
            form_P_MOI(b_vung_dgId, 'X');
            var b_so_id = O_NVL(GridX_Fas_layGtri(b_grdglkeId, b_hang, "so_id"));
            if (C_NVL(b_so_id, "") == "") return false;
            sns_ts.Fs_NS_TS_DG_CT(form_Fs_nsd(), b_so_id, ns_ts_dg_P_CT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    } catch (err) { form_P_LOI(err); }
}

function ns_ts_dg_P_CT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else if (b_kq === "") ns_ts_gv_P_CT_MOI("XGL"); else { form_P_CH_TEXT(b_vung_dgId, b_kq); }
}

function ns_ts_dg_P_LKE() {
    try {
        var b_dt = form_Faa_TEXT_ROW(b_vung_dgId); var a_cot = GridX_Fas_tenCot(b_grdglkeId); var a_tso = slide_Faobj_TUDEN(b_slidetsId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_id_cv = O_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id")); var b_loai = ""; var b_path = "";
        sns_ts.Fs_NS_TS_DG_LKE(form_Fs_nsd(), b_id_cv, b_dt, a_cot, a_tso, ns_ts_dg_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    } catch (err) {
        form_P_LOI(err);
    }
}
function ns_ts_dg_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#'); slide_P_SOTRANG(b_slidetsId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grdglkeId, a_kq[1]);
    try {
        GridX_datA(b_grdglkeId, 1);
        ns_ts_dg_P_CT();
    }
    catch (err) { }

}

function ns_ts_dg_P_LKE_ID(b_so_id) {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_id_cv = O_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
        var a_cot = GridX_Fas_tenCot(b_grdglkeId), b_hangKt = GridX_Fi_hangKt(b_grdglkeId), b_dt = form_Faa_TEXT_ROW(b_vung_dgId);
        sns_ts.Fs_NS_TS_DG_ID(form_Fs_nsd(), b_so_id, b_id_cv, b_dt, b_hangKt, a_cot, ns_ts_dg_P_LKE_ID_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    } catch (err) { }
}

function ns_ts_dg_P_LKE_ID_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#'), b_hang = CSO_SO(a_kq[0]), b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grdglkeId, a_kq[3]); slide_P_MOI(b_slidetsId, b_trang, b_soDong);
    if (b_hang > 0) GridX_datA(b_grdglkeId, b_hang); form_Fctr_VTEN_DTUONG('', 'moi').focus();
}