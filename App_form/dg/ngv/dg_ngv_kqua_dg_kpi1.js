var dg_ngv_kqua_dg_kpi_lkeCho, b_vungId, b_vungtkId, b_grlkeId, b_slideId, b_gocId, b_donviId, b_donvi_tkId, b_nam_tkId, b_lngId, dg_ngv_kqua_dg_kpi_choAct, b_nhom_cdanhId, b_cdanhId, b_capbacId
b_choAct = 0, b_fcho = 'C', b_checkMessage = "";
function dg_ngv_kqua_dg_kpi_P_KD() {
    dg_ngv_kqua_dg_kpi_lkeCho = setInterval('dg_ngv_kqua_dg_kpi_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("DAYPHONG") >= 0) {
            var b_phong_tk = form_Fctr_TEN_DTUONG(b_vungId, 'phong');
            lke_P_DAT(b_phong_tk, a_tso[0] + "{" + a_tso[1]);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function dg_ngv_kqua_dg_kpi_P_KTRA(b_maTen) {
    try {
        if (b_maTen == "KY_DG") {
            $get(b_an_ky_dgId).value = lke_Fs_TRA($get(b_ky_dgId));
            dg_ngv_kqua_dg_kpi_P_LKE();
        } else if (b_maTen == "PHONG") {
            $get(b_an_phongId).value = lke_Fs_TRA($get(b_phongId));
            dg_ngv_kqua_dg_kpi_P_LKE();
        }
    }
    catch (err) {
        form_P_LOI(err);
    }
}
// Xác nhận 
function dg_ngv_kqua_dg_kpi_P_XACNHAN(b_dk) {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }

        var b_nam = lke_Fs_TRA(b_namId), b_ky_dg = lke_Fs_TRA(b_ky_dgId), b_phong = lke_Fs_TRA(b_phongId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var a_dt = form_Faa_TEXT_ROW(b_vungId), a_dt_ct = GridX_Fdt_cotGtri(b_grlkeId);
        sdg.Fs_NS_XACNHAN_KPI_NV_NH(form_Fs_nsd(), b_dk, b_nam, b_ky_dg, b_phong, a_dt, a_dt_ct, a_tso, a_cot, dg_ngv_kqua_dg_kpi_P_XACNHAN_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        b_checkMessage = b_dk;
        return false;
    } catch (err) { form_P_LOI(err); }
}
function dg_ngv_kqua_dg_kpi_P_XACNHAN_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    else {
        if (b_checkMessage == "XN") form_P_LOI("loi:Xác nhận thành công!:loi");
        else form_P_LOI("loi:Ghi nhận thành công!:loi");
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
    }
    return false;
}
// Chuyển hàng 
function dg_ngv_kqua_dg_kpi_GR_lke_RowChange() {
    if (dg_ngv_kqua_dg_kpi_choAct != 0) clearTimeout(dg_ngv_kqua_dg_kpi_choAct);
    dg_ngv_kqua_dg_kpi_choAct = setTimeout("dg_ngv_kqua_dg_kpi_P_CHUYEN_HANG()", 300);
    return false;
}
function dg_ngv_kqua_dg_kpi_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    var b_kydg = lke_Fs_TRA($get(b_ky_dgId));
    if (b_so_id == "0" || b_so_id == "") { form_P_MOI(b_vungId, "XL"); GridX_datTrang(b_grctId); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        sdg.Fs_dg_ngv_kqua_dg_kpi_CT(form_Fs_nsd(), b_so_id, b_kydg, a_cot_ct, dg_ngv_kqua_dg_kpi_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function dg_ngv_kqua_dg_kpi_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        var a_kq = b_kq.split('#');
        form_P_MOI(b_vungId, "XL");
        // drop_P_LKE(b_ky_dgId, a_kq[2]);
        form_P_CH_TEXT(b_vungId, a_kq[0]);
        if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
        return false;
    }
}
// Liệt kê
function dg_ngv_kqua_dg_kpi_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (dg_ngv_kqua_dg_kpi_lkeCho != 0) clearTimeout(dg_ngv_kqua_dg_kpi_lkeCho);
        dg_ngv_kqua_dg_kpi_lkeCho, dg_ngv_kqua_dg_kpi_choAct = 0,
        b_vungId = form_Fs_VUNG_ID('UPa_ct'),
        b_vungtkId = form_Fs_VUNG_ID('Upa_tk'),
        b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_grctId = form_Fs_VUNG_ID('GR_ct'),
        b_ky_dgId = form_Fs_TEN_ID(b_vungId, 'ky_dg'),
        b_phongId = form_Fs_TEN_ID(b_vungId, 'phong'),
        b_namId = form_Fs_TEN_ID(b_vungId, 'nam'),
        b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
        b_an_ky_dgId = form_Fs_VTEN_ID('UPa_hi', 'an_ky_dg');
        b_an_nam_Id = form_Fs_VTEN_ID('UPa_hi', 'an_nam');
        b_an_phongId = form_Fs_VTEN_ID('UPa_hi', 'an_phong');
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        dg_ngv_kqua_dg_kpi_P_LKE();
    }
}

function dg_ngv_kqua_dg_kpi_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_nam = lke_Fs_TRA(b_namId), b_ky_dg = lke_Fs_TRA(b_ky_dgId), b_phong = lke_Fs_TRA(b_phongId);
        sdg.Fs_DG_NGV_KQUA_DG_KPI_LKE(form_Fs_nsd(), a_tso, a_cot, b_nam, b_ky_dg, b_phong, dg_ngv_kqua_dg_kpi_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function dg_ngv_kqua_dg_kpi_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
    }
}

function dg_ngv_kqua_dg_kpi_P_NAM(b_dk) {
    try {
        if (b_dk == 'N') var b_nam = lke_Fs_TRA($get(b_namId));
        else var b_nam = "";
        $get(b_an_nam_Id).value = b_nam;
        var ktra = "DT_KY_DG";
        sdg.Fdt_NS_DG_MA_KDG_DG_NHL(window.name, b_nam, ktra, dg_ngv_kqua_dg_kpi_P_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(err); }
}

function dg_ngv_kqua_dg_kpi_P_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_kdgId = form_Fs_TEN_ID(b_vungId, 'ky_dg');
        drop_P_LKE(b_kdgId, b_kq);
    }
    dg_ngv_kqua_dg_kpi_P_LKE();
}
function checkEmpty() {
    $get(b_an_nam_Id).value = lke_Fs_TRA($get(b_namId));
    $get(b_an_ky_dgId).value = lke_Fs_TRA($get(b_ky_dgId));
    $get(b_an_phongId).value = lke_Fs_TRA($get(b_phongId));

    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    form_P_LOI('');
    return false;
}
function dg_ngv_kqua_dg_kpi_P_Phong() {
    try {
        var b_tenf = form_Fs_TM() + '/App_form/ht/ns_hs_cctc_quyen.aspx';
        form_P_MO(b_tenf, null, [window.name, [""]]);
        return false;
    }
    catch (err) { }
}
function form_dong() {
    location.reload(false);
}