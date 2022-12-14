
var ns_dt_dsdaotao_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timId, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C';
function ns_dt_dsdaotao_P_KD() {
    ns_dt_dsdaotao_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_gocId = form_Fs_TEN_ID(b_vungId, 'tinhtrang');
    b_slideId = b_grlkeId + '_slide';
    ns_dt_dsdaotao_lkeCho = setInterval('ns_dt_dsdaotao_P_LKE_CHO()', 200);

}
function ns_dt_dsdaotao_P_KTRA(b_maTen) {
    var b_maId = "";
    b_maTen = b_maTen.toUpperCase();
    switch (b_maTen) {
        case "TINHTRANG": b_maId = b_gocId; break;
    }
    if (b_maTen == "TINHTRANG") { ns_dt_dsdaotao_P_LKE(); }
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[0];
    }
    catch (err) { form_P_LOI(err); }
}
function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}
function ns_dt_dsdaotao_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (ns_dt_dsdaotao_lkeCho != 0) clearTimeout(ns_dt_dsdaotao_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_dt_dsdaotao_P_LKE('K');
    }
}
function ns_dt_dsdaotao_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            a_tinhtrang = $get(b_gocId).value;
        sns_dto.Fs_NS_DT_DSDAOTAO_LKE(a_tinhtrang, a_tso, a_cot, ns_dt_dsdaotao_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_dsdaotao_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}

function ns_dt_dsdaotao_P_PHEDUYET() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("loi:Vui lòng chọn bản ghi:loi"); return false; }
    else
    {
        var b_ten = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"), b_chon = GridX_Fas_layGtri(b_grlkeId, b_hang, "chon");
        if (b_chon == "") {
            form_P_LOI("loi:Vui lòng chọn bản ghi:loi");
            return false;
        }
        if (b_ten == "") {
            return false;
        }
    }
    var b_dt_ct = GridX_Fdt_cotGtri(b_grlkeId);
    sns_dto.Fs_NS_DT_DSDAOTAO_PHEDUYET(b_dt_ct, ns_dt_dsdaotao_P_PHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_dt_dsdaotao_P_PHEDUYET_KQ(b_kq) {
    GridX_datTrang(b_grlkeId);
    ns_dt_dsdaotao_P_LKE();
    return false;
}

function ns_dt_dsdaotao_P_HUYPHEDUYET() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("loi:Vui lòng chọn bản ghi:loi"); return false; }
    else
    {
        var b_ten = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"), b_chon = GridX_Fas_layGtri(b_grlkeId, b_hang, "chon");
        if (b_chon == "") {
            form_P_LOI("loi:Vui lòng chọn bản ghi:loi");
            return false;
        }
        if (b_ten == "") {
            return false;
        }
    }
    var b_dt_ct = GridX_Fdt_cotGtri(b_grlkeId);
    sns_dto.Fs_NS_DT_DSDAOTAO_HUYPHEDUYET(b_dt_ct, ns_dt_dsdaotao_P_HUYPHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_dt_dsdaotao_P_HUYPHEDUYET_KQ(b_kq) {
    GridX_datTrang(b_grlkeId);
    ns_dt_dsdaotao_P_LKE();
    return false;
}

function ns_dt_dsdaotao_P_KOPHEDUYET() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("loi:Vui lòng chọn bản ghi:loi"); return false; }
    else
    {
        var b_ten = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"), b_chon = GridX_Fas_layGtri(b_grlkeId, b_hang, "chon");
        if (b_chon == "") {
            form_P_LOI("loi:Vui lòng chọn bản ghi:loi");
            return false;
        }
        if (b_ten == "") {
            return false;
        }
    }
    var b_dt_ct = GridX_Fdt_cotGtri(b_grlkeId);
    sns_dto.Fs_NS_DT_DSDAOTAO_KOPHEDUYET(b_dt_ct, ns_dt_dsdaotao_P_KOPHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_dt_dsdaotao_P_KOPHEDUYET_KQ(b_kq) {
    GridX_datTrang(b_grlkeId);
    ns_dt_dsdaotao_P_LKE();
    return false;
}

function ns_dt_dsdaotao_P_XEM() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return false;
    var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
    form_P_MO("ns_dt_kdt.aspx", null, ["KQ", [b_ma]]);
    return false;
}
function ns_dt_dsdaotao_CHON() {
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
    return false;
}
function form_dong() {
    location.reload(false);
}