var b_tmf, ns_cc_giaitrinh_pd_lkeCho, ns_cc_giaitrinh_pd_chuyenhangCho, b_vungId, b_grlkeId, b_slideId, b_so_theId, b_so_idId, ns_cc_giaitrinh_pd_choAct = 0, b_nsd, b_ten;
function ns_cc_giaitrinh_pd_P_KD(nsd) {
    b_nsd = nsd;
    ns_cc_giaitrinh_pd_lkeCho,
    ns_cc_giaitrinh_pd_chuyenhangCho,
    b_vungId = form_Fs_VUNG_ID('UPa_ct'),
    b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
    b_grkqId = form_Fs_VUNG_ID('GR_kq'),
    b_slideId = b_grlkeId + '_slide';
    b_tinhtrangId = form_Fs_TEN_ID(b_vungId, 'tinhtrang');
    b_thangId = form_Fs_TEN_ID(b_vungId, 'thang');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    ns_cc_giaitrinh_pd_lkeCho = setInterval('ns_cc_giaitrinh_pd_P_LKE_CHO()', 200);
    //ns_cc_giaitrinh_pd_chuyenhangCho = setInterval('ns_cc_giaitrinh_pd_P_CHUYENHANG_CHO()', 200);
}
var b_cho_control = 0;
function P_cho(b_so_the, b_ten) {
    try {
        if (b_doi == 0) {
            $get(b_so_theId).value = b_so_the;
            $get(b_gchuId).innerHTML = b_ten;
            $get(b_so_theId).focus();
            //ns_cc_giaitrinh_pd_P_CHUYEN_HANG();
            b_doi = 1;
            clearTimeout(b_cho_control);
        }
    }
    catch (err) {
        b_doi = 0;
    }
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        b_doi = 0;
        if (b_dtuong.indexOf("SO_THE") >= 0 || b_dtuong.indexOf("THAMSO") >= 0) {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "')", 200);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_giaitrinh_pd_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_so_theId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        else if (b_maTen == "SO_THE") {
            ns_cc_giaitrinh_pd_P_CHUYEN_HANG();
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_cc_giaitrinh_pd_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_cc_giaitrinh_pd_lkeCho); ns_cc_giaitrinh_pd_P_LKE(); }
}

function ns_cc_giaitrinh_pd_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_thang = $get(b_thangId).value;
        var b_tinhtrang = $get(b_tinhtrangId).value;
        stl_cc.Fs_NS_CHAMCONG_GIAITRINH_PD_LKE(b_tinhtrang, b_thang, a_tso, a_cot, ns_cc_giaitrinh_pd_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_giaitrinh_pd_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    return false;
}

function ns_cc_giaitrinh_pd_P_CHUYENHANG_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_cc_giaitrinh_pd_chuyenhangCho); ns_cc_giaitrinh_pd_P_CHUYEN_HANG(); }
}
function ns_cc_giaitrinh_pd_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    GridX_datTrang(b_grkqId);
    $get(b_so_theId).focus();
    return false;
}
function ns_cc_giaitrinh_pd_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_dt = form_Faa_TEXT_ROW(b_vungId),
                a_cot_ct = GridX_Fdt_cotGtri(b_grctId), a_cot_kq = GridX_Fdt_cotGtri(b_grkqId);
            stl_cc.Fs_NS_CHAMCONG_GIAITRINH_NH(b_dt, a_cot_ct, a_cot_kq, ns_cc_giaitrinh_pd_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_cc_giaitrinh_pd_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        form_P_LOI('loi:Nhập thành công!:loi');
        ns_cc_giaitrinh_pd_P_CHUYEN_HANG();
        $get(b_so_theId).focus();
    }
    return false;
}

function ns_cc_giaitrinh_pd_GR_lke_RowChange() {
    if (ns_cc_giaitrinh_pd_choAct != 0) clearTimeout(ns_cc_giaitrinh_pd_choAct);
    ns_cc_giaitrinh_pd_choAct = setTimeout("ns_cc_giaitrinh_pd_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_cc_giaitrinh_pd_P_CHUYEN_HANG() {
    var b_thang = $get(b_thangId).value;
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    else var b_so_the = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the"));
    if (b_so_the == null || b_so_the == "") {
        GridX_datTrang(b_grctId);
        GridX_datTrang(b_grkqId);
        return false;
    }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        var a_cot_kq = GridX_Fas_tenCot(b_grkqId);
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
        stl_cc.Fs_NS_CHAMCONG_GIAITRINH_CT(b_so_the, b_thang, a_cot_ct, a_cot_kq, ns_cc_giaitrinh_pd_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function ns_cc_giaitrinh_pd_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    //form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[0] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[0]); slide_P_SOTRANG(b_grctId + "_slide");
    if (a_kq[1] == "") GridX_datTrang(b_grkqId); else GridX_datBang(b_grkqId, a_kq[1]); slide_P_SOTRANG(b_grlkeId + "_slide");
    return false;
}

function ns_cc_giaitrinh_pd_P_XOA() {
    var b_so_the = $get(b_so_theId).value;
    if (b_so_the == null || b_so_the == "") ns_cc_giaitrinh_pd_P_MOI();
    else {
        var b_so_the = $get(b_so_theId).value;
        sns_tt.Fs_ns_cc_giaitrinh_pd_XOA(b_so_the, ns_cc_giaitrinh_pd_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_cc_giaitrinh_pd_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        ns_cc_giaitrinh_pd_P_CHUYEN_HANG();
        form_P_LOI('loi:Xóa thành công!:loi');
        return false;
    }
}


function ns_cc_giaitrinh_pd_CHON() {
    var j = 0;
    var b_ktra = GridX_Fdt_cotGtri(b_grctId, ["pheduyet", "ngay_cc"]);
    var b_gt = b_ktra[1];
    for (var i = 0; i < b_gt.length; i++) {
        if (b_gt[i][0] == "X") { j++; }
    }
    if (j == 0) {
        for (var i = 0; i < b_gt.length; i++) {
            if (b_gt[i][1] != "") {
                GridX_datGtri(b_grctId, i + 1, ["pheduyet"], ["X"]);
            }
        }
    }
    else {
        for (var i = 0; i < b_gt.length; i++) {
            GridX_datGtri(b_grctId, i + 1, ["pheduyet"], [""]);
        }
    }
}

function ns_cc_giaitrinh_pd_CHON2() {
    var j = 0;
    var b_ktra = GridX_Fdt_cotGtri(b_grkqId, ["pheduyet", "ngay_ot"]);
    var b_gt = b_ktra[1];
    for (var i = 0; i < b_gt.length; i++) {
        if (b_gt[i][0] == "X") { j++; }
    }
    if (j == 0) {
        for (var i = 0; i < b_gt.length; i++) {
            if (b_gt[i][1] != "") {
                GridX_datGtri(b_grkqId, i + 1, ["pheduyet"], ["X"]);
            }
        }
    }
    else {
        for (var i = 0; i < b_gt.length; i++) {
            GridX_datGtri(b_grkqId, i + 1, ["pheduyet"], [""]);
        }
    }
}

function ns_cc_giaitrinh_pd_HangLen() {
    GridX_chuyenHang(b_grlkeId, -1);
    return false;
}
function ns_cc_giaitrinh_pd_HangXuong() {
    GridX_chuyenHang(b_grlkeId, 1);
    return false;
}
function ns_cc_giaitrinh_pd_chenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grlkeId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grlkeId);
    return false;
}
function ns_cc_giaitrinh_pd_CatDong() {
    GridX_boChon(b_grlkeId, 'C');
    return false;
}

function nhap_file() {
    var b_tenf = b_tmf + '/ns/ma/file_luu.aspx';
    var b_so_the = $get(b_so_theId).value;
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "THS", b_so_the, "Lưu túi hồ sơ"]], null);
    return false;
}

function ns_cc_giaitrinh_pd_P_PHEDUYET() {
    var b_thang = $get(b_thangId).value;
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    else var b_so_the = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the"));
    if (b_so_the == null || b_so_the == "") return false;
    var b_dt_ct = GridX_Fdt_cotGtri(b_grctId),
        b_dt_kq = GridX_Fdt_cotGtri(b_grkqId);
    stl_cc.Fs_NS_CHAMCONG_GIAITRINH_PHEDUYET(b_so_the, b_thang, '1', b_dt_ct, b_dt_kq, ns_cc_giaitrinh_pd_P_PHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_cc_giaitrinh_pd_P_PHEDUYET_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_LOI("loi:Phê duyệt thành công!:loi");
    GridX_datTrang(b_grlkeId);
    GridX_datTrang(b_grkqId);
    GridX_datTrang(b_grctId);
    ns_cc_giaitrinh_pd_P_LKE();
   // sendMail(b_kq);
    return false;
}

function ns_cc_giaitrinh_pd_P_KOPHEDUYET() {
    var b_thang = $get(b_thangId).value;
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    else var b_so_the = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the"));
    if (b_so_the == null || b_so_the == "") return false;
    var b_dt_ct = GridX_Fdt_cotGtri(b_grctId),
        b_dt_kq = GridX_Fdt_cotGtri(b_grkqId);
    stl_cc.Fs_NS_CHAMCONG_GIAITRINH_PHEDUYET(b_so_the, b_thang, '2', b_dt_ct, b_dt_kq, ns_cc_giaitrinh_pd_P_KOPHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_cc_giaitrinh_pd_P_KOPHEDUYET_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_LOI("loi:Không phê duyệt thành công!:loi");
    GridX_datTrang(b_grlkeId);
    GridX_datTrang(b_grkqId);
    GridX_datTrang(b_grctId);
    ns_cc_giaitrinh_pd_P_LKE();
    return false;
}
