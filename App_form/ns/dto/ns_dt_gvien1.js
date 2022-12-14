var ns_dt_gvien_lkeCho, b_vungId, b_grlkeId, b_slideId, b_grctId, b_gchuId, b_so_idId, b_moiId, b_lvdaotao_text, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C';
function ns_dt_gvien_P_KD() {
    ns_dt_gvien_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
    b_lvdaotaoId = form_Fs_TEN_ID(b_vungId, 'LVDAOTAO'), b_tenId = form_Fs_TEN_ID(b_vungId, 'TEN'), b_phongId = form_Fs_TEN_ID(b_vungId, 'phong'),
    b_donviId = form_Fs_TEN_ID(b_vungId, 'donvi'), b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE'), b_lkeId = form_Fs_TEN_ID(b_vungId, 'lke'), b_hoatdongId = form_Fs_TEN_ID(b_vungId, 'hoatdong'), b_lvdaotao_text = form_Fs_VTEN_ID('GR_ct', 'wlvdaotao'),
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_moiId = form_Fs_VTEN_ID('', 'moi');
    b_slideId = b_grlkeId + '_slide';
    ns_dt_gvien_lkeCho = setInterval('ns_dt_gvien_P_LKE_CHO()', 200);
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            $get(b_gocId).value = b_kq;
            form_P_MOI("", "XL");
            ns_dt_gvien_P_TT(b_kq);
            $get(b_gchuId).innerHTML = a_tso[1];
        }
        else if (b_dtuong.indexOf("WLVDAOTAO") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grctId, b_hang, ["wlvdaotao"], [a_tso[0]], 'K');
            $get(b_gchuId).innerHTML = a_tso[1];
            GridX_datA(b_grctId, b_hang, "noidung");
        }
    }
    catch (err) { form_P_LOI(err); }
}
function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}

function ns_dt_gvien_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grctId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        if (b_value != "") {
            if (b_cot == "WLVDAOTAO") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Lĩnh vực đào tạo", b_value, "ns_ma_lvdaotao,ma,ten", ns_dt_gvien_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN)
                $get(b_lvdaotao_text).value = "", $get(b_lvdaotaoId).value = "";
            }
        }
        if (b_value != "") GridX_ThemHang(b_grctId);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_dt_gvien_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId;
                break;
            case "LVDAOTAO": b_maId = ""; break;
        }
        var b_ma = $get(b_maId);
        if (b_maTen == "LVDAOTAO") { //ns_dt_gvien_P_MOI();
            ns_dt_gvien_P_LKE('K');
        }
        if (b_ma == null || C_NVL(b_ma.value) == "") return;

        if (b_ma.value != "") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_dt_gvien_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
        }
        if (b_maTen == "SO_THE") {
            //
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "so_the", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_dt_gvien_P_MA_KTRA(); }
            if (b_hang > -1) {
                GridX_datA(b_grlkeId, b_hang);
                ns_dt_gvien_P_CHUYEN_HANG();
                $get(b_gocId).focus();
            }
            else {
                var b_lke = $get(b_lkeId).value;
                if (b_lke == "N") { ns_dt_gvien_P_TT(b_ma.value); }
                else return;
            }
        }
        else if (b_maTen == "WLVDAOTAO") {
            var b_hang = Grid_Fi_HangTrang(b_grctId);
            if (b_hang < 0) {
                Grid_ThemCuoi(b_grctId);
                b_hang = Grid_Fi_HangTrang(b_grctId);
            }
            Grid_DatActiveCell(b_grctId, b_hang, "noidung");
        }
        if (b_maTen == "LVDAOTAO") { ns_dt_gvien_P_MOI(); ns_dt_gvien_P_LKE('K'); }
        else if (b_maTen == "LKE") {
            ns_dt_gvien_P_MOI();
            ns_dt_gvien_P_LKE('K');
            ns_dt_gvien_P_DISABLED();
        }
        else skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_dt_gvien_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function ns_dt_gvien_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_lvdaotao = lke_Fs_TRA($get(b_lvdaotaoId)),
                b_so_id = $get(b_so_idId).value,
                b_lke = $get(b_lkeId).value;
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_dto.Fs_NS_DT_GVIEN_MA(b_so_id, b_lvdaotao, b_lke, b_ma, b_TrangKt, a_cot, ns_dt_gvien_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_gvien_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang >= 1) { GridX_datA(b_grlkeId, b_hang); ns_dt_gvien_P_CHUYEN_HANG(); }
}

function ns_dt_gvien_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);

}

var ns_dt_gvien_choAct = 0;
function ns_dt_gvien_GR_lke_RowChange() {
    if (ns_dt_gvien_choAct != 0) clearTimeout(ns_dt_gvien_choAct);
    ns_dt_gvien_choAct = setTimeout("ns_dt_gvien_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_dt_gvien_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (ns_dt_gvien_lkeCho != 0) clearTimeout(ns_dt_gvien_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_dt_gvien_P_LKE('K');
    }
    if ($get(b_grlkeId) != null) { clearTimeout(ns_dt_gvien_lkeCho); ns_dt_gvien_P_LKE('K'); }
}

function ns_dt_gvien_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    $get(b_gocId).focus();
    $get(b_lvdaotaoId).value = "";
    $get(b_so_idId).value = 0;
    return false;
}
function ns_dt_gvien_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
        b_lvdaotao = lke_Fs_TRA($get(b_lvdaotaoId)),
        b_lke = $get(b_lkeId).value;
        sns_dto.Fs_NS_DT_GVIEN_LKE(b_lvdaotao, b_lke, a_tso, a_cot, ns_dt_gvien_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_gvien_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
    }
    //b_fcho = 'X';
}

function ns_dt_gvien_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var b_so_id = $get(b_so_idId).value, b_dt = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fdt_cotGtri(b_grctId),
            b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
        sns_dto.Fs_NS_DT_GVIEN_NH(b_so_id, b_TrangKt, b_dt, a_cot, a_cot_lke, ns_dt_gvien_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_gvien_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        ns_dt_gvien_P_MOI();
        form_P_LOI("Ghi thành công!");
        ns_dt_gvien_P_LKE();
    }
    return false;
}

function ns_dt_gvien_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")),
        a_cot = GridX_Fas_tenCot(b_grctId);
    if (b_so_id == "0") form_P_MOI(b_vungId, "XGL");
    else sns_dto.Fs_NS_DT_GVIEN_CT(b_so_id, a_cot, ns_dt_gvien_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = b_so_id;
    //form_P_LOI("loi:Nhập thành công:loi");
}
function ns_dt_gvien_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") { form_P_MOI(b_vungId, "XGL"); GridX_datTrang(b_grctId); }
    else GridX_datBang(b_grctId, a_kq[1]);
}
function ns_dt_gvien_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    var b_lvdaotao = lke_Fs_TRA($get(b_lvdaotaoId)), b_lke = $get(b_lkeId).value;
    if (b_so_id == "") ns_dt_gvien_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dto.Fs_NS_DT_GVIEN_XOA(b_lvdaotao, b_so_id, b_lke, a_tso, a_cot, ns_dt_gvien_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_dt_gvien_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI("loi:Xóa thành công:loi");
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        GridX_boChon(b_grlkeId, 'C');
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dt_gvien_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dt_gvien_P_CHUYEN_HANG(); }
    }
    return false;
}
function ns_dt_gvien_P_TT(b_ma) {
    sns_dto.Fs_NS_DT_GVIEN_TT(b_ma, ns_dt_gvien_P_TT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function ns_dt_gvien_P_TT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    //$get(b_hoatdongId).focus();
}
function ns_dt_gvien_P_DISABLED() {
    var b_lke = $get(b_lkeId).value;
    if (b_lke != "B") {
        $get(b_tenId).setAttribute("disabled", "disabled");
        $get(b_donviId).setAttribute("disabled", "disabled");
        $get(b_phongId).setAttribute("disabled", "disabled");
        $get(b_gocId).focus();
    }
    else {
        $get(b_tenId).removeAttribute("disabled");
        $get(b_donviId).removeAttribute("disabled");
        $get(b_phongId).removeAttribute("disabled");
        $get(b_gocId).focus();
    }
}

function ns_dt_gvien_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_dt_gvien_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_dt_gvien_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function ns_dt_gvien_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}
function form_dong() {
    location.reload(false);
}