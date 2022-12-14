var b_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timId, b_choAct = 0, b_tt = '', b_hang;
var b_kytudau = "CCHN";
var b_tenbang = "NS_MA_CCHN";
var b_tencot = "MA";

function ns_tl_cchn_P_KD() {
    b_lkeCho = setTimeout('ns_tl_cchn_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "" || b_dtuong == 'MENU')
            return;
        b_ten_form = b_dtuong;
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            b_tt = b_kq;
            ns_tl_cchn_P_LKE();
        }
        else if (b_dtuong.indexOf("MA_CCC") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            if (a_tso[0] == "CMC-2M") {
                for (var i = 1; i < a_tso.length; i++) {
                    GridX_datGtri(b_grctId, b_hang, ["MA_CCC"], [a_tso[i][0]], 'K');
                    GridX_datGtri(b_grctId, b_hang, ["TEN_CCC"], [a_tso[i][1]], 'K');
                    b_hang = b_hang + 1;
                }
                slide_P_SOTRANG(b_slideIdcn, CSO_SO(b_hang, 0));
            } else {
                GridX_datGtri(b_grctId, b_hang, ["MA_CCC"], [a_tso[0]], 'K');
                GridX_datGtri(b_grctId, b_hang, ["TEN_CCC"], [a_tso[1]], 'K');
            }
            GridX_datA(b_grctId, b_hang + 1, "MA_CCC");
        }

    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_tl_cchn_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId;
                break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "")
            return;
        if (b_maTen == "MA") {
            $get(b_gocId).value = ($get(b_gocId).value).validate_Ma();
            var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) {
                GridX_thoiA(b_grlkeId);
                ns_tl_cchn_P_MA_KTRA();
            }
            else {
                GridX_datA(b_grlkeId, b_hang);
                ns_tl_cchn_P_CHUYEN_HANG();
            }
            b_ten.focus();
        }
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_tl_cchn_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_ma_ch.Fs_NS_MA_CCHN_MA(b_ma, b_TrangKt, a_cot, ns_tl_cchn_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_tl_cchn_P_MA_KTRA_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) {
            form_P_LOI(b_kq);
            return;
        }
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1;
        var b_trang = CSO_SO(a_kq[1]);
        var b_soDong = CSO_SO(a_kq[2]);
        GridX_datBang(b_grlkeId, a_kq[3]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        if (b_hang < 1) form_P_MOI(b_vungId, "X");
        else {
            GridX_datA(b_grlkeId, b_hang);
            ns_tl_cchn_P_CHUYEN_HANG();
        }
    }
    catch (err) {
        form_P_LOI(err);
    }
}

function ns_tl_cchn_P_MOI() {
    GridX_thoiA(b_grlkeId);
    form_P_MOI(b_vungId, "GXL");
    GridX_datTrang(b_grctId);
    return false;
}
function ns_tl_cchn_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") {
            form_P_LOI(b_loi);
            return false;
        }
        var a_dt = form_Faa_TEXT_ROW(b_vungId);
        var a_dt_ct = GridX_Fdt_cotGtri(b_grctId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId);
        var b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        sns_ma_ch.Fs_NS_TL_CCHN_NH(b_TrangKt, a_dt, a_dt_ct, a_cot, ns_tl_cchn_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_tl_cchn_P_NH_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq))
            form_P_LOI(b_kq);
        else {
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            form_P_LOI("loi:Ghi thành công!:loi");
            var a_kq = Fas_ChMang(b_kq, '#');
            var b_hang = CSO_SO(a_kq[0]) + 1;
            var b_trang = CSO_SO(a_kq[1]);
            var b_soDong = CSO_SO(a_kq[2]);
            slide_P_MOI(b_slideId, b_trang, b_soDong);
            GridX_datBang(b_grlkeId, a_kq[3]);
            if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
            $get(b_gocId).focus();
        }
        return false;
    }
    catch (err) {
        form_P_LOI(err);
    }
}

function ns_tl_cchn_P_XOA() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_hang < 1 || b_loi.length > 0) {
            form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi");
            return false;
        }
        var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma_cchn"), b_ngay_hl = GridX_Fas_layGtri(b_grlkeId, b_hang, "ngay_hl");
        if (b_ma == "") {
            ns_tl_cchn_P_MOI(); form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi");
            return false;
        }
        else {
            var message = confirm("Bạn có chắc chắn xóa không?");
            if (message == false)
                return false;
            var a_cot = GridX_Fas_tenCot(b_grlkeId);
            var a_tso = slide_Faobj_TUDEN(b_slideId);
            sns_ma_ch.Fs_NS_TL_CCHN_XOA(b_ma, b_ngay_hl, a_tso, a_cot, ns_tl_cchn_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_tl_cchn_P_XOA_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq))
            form_P_LOI(b_kq);
        else {
            form_P_LOI("loi:Xóa thành công!:loi");
            var a_kq = Fas_ChMang(b_kq, '#');
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang > 1)
                b_hang--;
            else
                b_hang = GridX_Fi_hangSo(b_grlkeId);
            slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
            GridX_datBang(b_grlkeId, a_kq[1]);
        }
    }
    catch (err) {
        form_P_LOI(err);
    }
    return false;
}

function ns_tl_cchn_GR_lke_RowChange() {
    try {
        if (b_choAct != 0)
            clearTimeout(b_choAct);
        b_choAct = setTimeout("ns_tl_cchn_P_CHUYEN_HANG()", 300);
        return false;
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_tl_cchn_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma_cchn"));
        if (b_ma == "") {
            form_P_MOI(b_vungId, "XGL");
            GridX_datTrang(b_grctId);
            var b_drop = form_Fctr_TEN_DTUONG(b_vungId, 'tt');
            list_P_DAT(b_drop, 'A');
            //hts_dungchung.Fs_AutoGenCode(b_kytudau, b_tenbang, b_tencot, ns_tl_cchn_P_GENCODE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else {
            var a_cot = GridX_Fas_tenCot(b_grctId);
            sns_ma_ch.Fs_NS_TL_CCHN_CT(b_ma, a_cot, ns_tl_cchn_P_CT, P_LOI_CSDL, P_LOI_TGIAN)
        }
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_tl_cchn_P_CT(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) {
            form_P_LOI(b_kq);
            return;
        }
        var a_kq = Fas_ChMang(b_kq, '#')
        form_P_CH_TEXT(b_vungId, a_kq[0]);
        GridX_datBang(b_grctId, a_kq[1]);

        //form_P_GridX_TEXT(b_vungId, b_grlkeId);

    }
    catch (err) {
        form_P_LOI(err);
    }
}

function ns_tl_cchn_P_LKE_CHO() {
    try {
        if (document.readyState === 'complete') {
            clearTimeout(b_lkeCho);
            b_vungId = form_Fs_VUNG_ID('UPa_ct');
            b_grlkeId = form_Fs_VUNG_ID('GR_lke');
            b_grctId = form_Fs_VUNG_ID('GR_ct');
            b_ma_cchn = form_Fs_TEN_ID(b_vungId, 'MA_CCHN');
            b_slideId = $get(b_grlkeId).getAttribute('slideId');
            slide_P_MOI(b_slideId);
            ns_tl_cchn_P_LKE();
        }
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_tl_cchn_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId);
        var a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_NS_TL_CCHN_LKE(a_tso, a_cot, b_tt, ns_tl_cchn_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_tl_cchn_P_LKE_KQ(b_kq) {
    try {

        if (Fb_LOI_KTRA(b_kq)) {
            form_P_LOI(b_kq);
            return;
        }
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
    }
    catch (err) {
        form_P_LOI(err);
    }
}

function ns_tl_cchn_P_IN() {
    try {

        var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
        $get(b_btn_excel).click();
        form_chay = 0;
        return false;
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function form_dong() {
    location.reload(false);
}
function ns_tl_cchn_P_GENCODE_KQ(b_kq) {
    try {

        if (Fb_LOI_KTRA(b_kq))
            form_P_LOI(b_kq);
        else {
            $get(b_gocId).value = b_kq;
        }
    }
    catch (err) {
        form_P_LOI(err);
    }
}

function ns_tl_cchn_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_tl_cchn_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_tl_cchn_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function ns_tl_cchn_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}

function ns_tl_cchn_click(event) {
    var a = setTimeout(ns_tl_cchn_wait, 1000);
}
function ns_tl_cchn_wait() {
    b_hang = GridX_Fi_timHangA(b_grctId);
    alert(b_hang);
}