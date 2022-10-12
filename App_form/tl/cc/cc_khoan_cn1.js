var cc_khoan_cn_lkeCho, b_vungId, b_vungtkId, b_grlkeId, b_ngaydId, b_ngaycId, b_sothe_tkId, b_gocId, b_mt, b_gchuId, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C';
function cc_khoan_cn_P_KD() {
    cc_khoan_cn_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtkId = form_Fs_VUNG_ID('UPa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
    b_ngaydId = form_Fs_TEN_ID(b_vungtkId, 'ngayd_tk'), b_ngaycId = form_Fs_TEN_ID(b_vungtkId, 'ngayc_tk'), b_sothe_tkId = form_Fs_TEN_ID(b_vungtkId, 'so_the_tk'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE'), b_ngayId = form_Fs_TEN_ID(b_vungId, 'NGAY'); b_tienId = form_Fs_TEN_ID(b_vungId, 'tien');
    b_maspId = form_Fs_TEN_ID(b_vungId, 'masp');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_so_idId = form_Fs_VTEN_ID('UPa_hidden', 'so_id'); b_slideId = $get(b_grlkeId).getAttribute('slideId');
    cc_khoan_cn_lkeCho = setInterval('cc_khoan_cn_P_LKE_CHO()', 200);
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
            $get(b_gchuId).innerHTML = a_tso[1];
            cc_khoan_cn_P_LKE('K');
            $get(b_ngayId).focus();
        }
        else if (b_dtuong.indexOf("MASP") >= 0) {
            $get(b_maspId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_tienId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}

function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}

function cc_khoan_cn_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; form_P_MOI("", "XGL"); break;
            case "NGAY": b_maId = b_ngayId; break;
            case "NGAYD": b_maId = b_ngaydId; break;
            case "NGAYC": b_maId = b_ngaycId; break;
            case "MASP": b_maId = b_maspId; break;
        }
        b_mt = b_maTen;
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), cc_khoan_cn_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_maTen == "NGAYD") {
            cc_khoan_cn_P_LKE('K');
        }
        else if (b_maTen == "NGAYC") {
            cc_khoan_cn_P_LKE('K');
        }
        else if (b_maTen == "MASP") {
            var b_ngay = $get(b_ngayId).value;
            if (b_ngay == "") {
                skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), cc_khoan_cn_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
            else cc_khoan_cn_P_MA_KTRA();
        }
        else if (b_maTen == "NGAY") {
            var b_masp = $get(b_maspId).value;
            if (b_masp == "") {
                alert("phải nhập mã sản phẩm/công việc trước");
                return;
            }
            var b_hang = GridX_Fi_timHangD(b_grlkeId, ["masp", "ngay"], [b_masp, b_ma.value]);
            if (b_hang < 0) { cc_khoan_cn_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); cc_khoan_cn_P_CHUYEN_HANG(); }
        }
    }
    catch (err) { form_P_LOI(err); }
}

function cc_khoan_cn_P_MA_KTRA() {
    try {
        var b_ngay = C_NVL($get(b_ngayId).value);
        if (b_ngay != "") {
            var b_ngayd = $get(b_ngaydId).value, b_ngayc = $get(b_ngaycId).value,
                b_so_the = $get(b_sothe_tkId).value, b_masp = $get(b_maspId).value;
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            stl_cc.Fs_CC_KHOAN_CN_MA(b_so_the, b_masp, b_ngayd, b_ngayc, b_ngay, b_TrangKt, a_cot, cc_khoan_cn_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function cc_khoan_cn_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        form_P_MOI(b_vungId, "X");
        $get(b_tienId).focus();
        $get(b_so_idId).value = "0";
    }
    else { GridX_datA(b_grlkeId, b_hang); cc_khoan_cn_P_CHUYEN_HANG(); }
}

function cc_khoan_cn_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_mt == "MASP") {
        $get(b_gchuId).innerHTML = b_kq;
        $get(b_ngayId).focus();
    }
    else if (b_mt == "SO_THE") {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        $get(b_gchuId).innerHTML = b_kq;
        cc_khoan_cn_P_LKE('K');
        form_P_MOI(b_vungId, "GX");
    }
}

var cc_khoan_cn_choAct = 0;
function cc_khoan_cn_GR_lke_RowChange() {
    if (cc_khoan_cn_choAct != 0) clearTimeout(cc_khoan_cn_choAct);
    cc_khoan_cn_choAct = setTimeout("cc_khoan_cn_P_CHUYEN_HANG()", 300);
    return false;
}

function cc_khoan_cn_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (cc_khoan_cn_lkeCho != 0) clearTimeout(cc_khoan_cn_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        cc_khoan_cn_P_LKE('K');
    }
}

function cc_khoan_cn_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = "0";
    $get(b_maspId).focus();
    return false;
}
function cc_khoan_cn_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var b_ngayd = $get(b_ngaydId).value, b_ngayc = $get(b_ngaycId).value, b_so_the = $get(b_sothe_tkId).value,
            a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_cc.Fs_CC_KHOAN_CN_LKE(b_so_the, b_ngayd, b_ngayc, a_tso, a_cot, cc_khoan_cn_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function cc_khoan_cn_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    b_fcho = 'X';
}
function cc_khoan_cn_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_so_the = $get(b_sothe_tkId).value, b_ngayd = $get(b_ngaydId).value, b_ngayc = $get(b_ngaycId).value;
            var b_so_id = $get(b_so_idId).value, b_dt = form_Faa_TEXT_ROW(b_vungId),
                b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
            stl_cc.Fs_CC_KHOAN_CN_NH(b_so_id, b_so_the, b_ngayd, b_ngayc, b_TrangKt, b_dt, a_cot_lke, cc_khoan_cn_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function cc_khoan_cn_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        form_P_LOI("loi:Nhập thành công!:loi");
        $get(b_gocId).focus();
    }
    return false;
}
function cc_khoan_cn_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == null || b_so_id == "") { form_P_MOI(b_vungId, "XGL"); }
    else {
        stl_cc.Fs_CC_KHOAN_CN_CT(b_so_id, cc_khoan_cn_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function cc_khoan_cn_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    $get(b_so_idId).value = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
}
function cc_khoan_cn_P_XOA() {
    var r = confirm("Bạn có chắc chắn xóa không?");
    if (r == false) {
        return false;
    }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") cc_khoan_cn_P_MOI();
    else {
        var b_so_the = $get(b_sothe_tkId).value, b_ngayd = $get(b_ngaydId).value, b_ngayc = $get(b_ngaycId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_cc.Fs_CC_KHOAN_CN_XOA(b_so_id, b_so_the, b_ngayd, b_ngayc, a_tso, a_cot, cc_khoan_cn_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function cc_khoan_cn_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) cc_khoan_cn_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); cc_khoan_cn_P_CHUYEN_HANG(); }
    }
}

function form_dong() {
    location.reload(false);
}