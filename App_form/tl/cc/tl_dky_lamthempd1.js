       var tl_dky_lamthempd_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timId;
function tl_dky_lamthempd_P_KD() {
    tl_dky_lamthempd_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_gocId = form_Fs_TEN_ID(b_vungId, 'tinhtrang');
    b_thangId = form_Fs_TEN_ID(b_vungId, 'thang');
    b_slideId = b_grlkeId + '_slide';
    tl_dky_lamthempd_lkeCho = setInterval('tl_dky_lamthempd_P_LKE_CHO()', 200);

}
function tl_dky_lamthempd_P_KTRA(b_maTen) {
    var b_maId = "";
    b_maTen = b_maTen.toUpperCase();
    switch (b_maTen) {
        case "TINHTRANG": b_maId = b_gocId; break;
    }
    if (b_maTen == "TINHTRANG") { tl_dky_lamthempd_P_LKE(); }
}

function tl_dky_lamthempd_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(tl_dky_lamthempd_lkeCho); tl_dky_lamthempd_P_LKE(); }
}
function tl_dky_lamthempd_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            a_tinhtrang = $get(b_gocId).value, a_thang = $get(b_thangId).value;
        stl_cc.Fs_NS_TL_LAMTHEMPD_LKE(a_tinhtrang,a_thang, a_tso, a_cot, tl_dky_lamthempd_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function tl_dky_lamthempd_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}

function tl_dky_lamthempd_P_PHEDUYET() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId); 
    var b_dt_ct = GridX_Fdt_cotGtri(b_grlkeId);
    var b_tinhtrang = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tinhtrang")) == "" ? 0 : C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tinhtrang"));
    stl_cc.Fs_NS_TL_LAMTHEMPD_PHEDUYET(b_tinhtrang,b_dt_ct, tl_dky_lamthempd_P_PHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function tl_dky_lamthempd_P_PHEDUYET_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_LOI("loi:Phê duyệt thành công:loi");
    GridX_datTrang(b_grlkeId);
    tl_dky_lamthempd_P_LKE();
}
function tl_dky_lamthempd_P_KOPHEDUYET() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId); 
    var b_dt_ct = GridX_Fdt_cotGtri(b_grlkeId);
    stl_cc.Fs_NS_TL_LAMTHEMPD_KOPHEDUYET(b_dt_ct, tl_dky_lamthempd_P_KOPHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function tl_dky_lamthempd_P_KOPHEDUYET_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_LOI("loi:Không phê duyệt thành công:loi");
    GridX_datTrang(b_grlkeId);
    tl_dky_lamthempd_P_LKE();
}

function tl_dky_lamthempd_CHON() {
    var j = 0;
    var b_ktra = GridX_Fdt_cotGtri(b_grlkeId, ["chon", "so_id"]);
    var b_gt = b_ktra[1];
    for (var i = 0; i < b_gt.length; i++) {
        if (b_gt[i][0] == "X") { j++; }
    }
    if (j == 0) {
        for (var i = 0; i < b_gt.length; i++) {
            if (b_gt[i][1] != "") {
                GridX_datGtri(b_grlkeId, i + 1, ["chon"], ["X"]);
            }
        }
    }
    else {
        for (var i = 0; i < b_gt.length; i++) {
            GridX_datGtri(b_grlkeId, i + 1, ["chon"], [""]);
        }
    }
}
function form_dong() {
    location.reload(false);
}