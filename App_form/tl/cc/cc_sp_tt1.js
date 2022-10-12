var cc_sp_tt_lkeCho, b_vungId, b_vungtkId, b_grlkeId, b_ngaydId, b_ngaycId, b_phongId, b_grspId, b_grdsId, b_gocId, b_ncdanhId, b_mt, b_gchuId, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C', b_hangId, b_caId, b_ctyId, b_ctyValue, b_ctrbeforId;
function cc_sp_tt_P_KD() {
    cc_sp_tt_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtkId = form_Fs_VUNG_ID('UPa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grspId = form_Fs_VUNG_ID('GR_sp'),
    b_grdsId = form_Fs_VUNG_ID('GR_ds'), b_ngaydId = form_Fs_TEN_ID(b_vungtkId, 'ngayd_tk'), b_ngaycId = form_Fs_TEN_ID(b_vungtkId, 'ngayc_tk'),
    b_phongId = form_Fs_TEN_ID(b_vungId, 'PHONG'), b_gocId = form_Fs_TEN_ID(b_vungId, 'NGAY'); b_noteId = form_Fs_TEN_ID(b_vungId, 'note');
    b_caId = form_Fs_TEN_ID(b_vungId, 'ca');
    b_td_chenspId = form_Fs_VUNG_ID('id_chensp'); b_td_chendsId = form_Fs_VUNG_ID('id_chends');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'); b_slideId = b_grlkeId + '_slide';
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_lhId = form_Fs_TEN_ID(b_vungId, 'lh'),
    cc_sp_tt_lkeCho = setInterval('cc_sp_tt_P_LKE_CHO()', 200);
}

function cc_sp_tt_P_NPA(b_nv) {
    $get(b_td_chenspId).style.display = (b_nv == "sp") ? "" : "none";
    $get(b_td_chendsId).style.display = (b_nv == "ds") ? "" : "none";
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("TEN_SP") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grspId);
            if (b_hang > -1) {
                GridX_datGtri(b_grspId, b_hang, "masp", b_kq);
                GridX_datGtri(b_grspId, b_hang, "ten_sp", a_tso[1]);
                GridX_datGtri(b_grspId, b_hang, "donvi", a_tso[2]);
                $get(b_gchuId).innerHTML = a_tso[1];
                GridX_datA(b_grspId, b_hang, "chatluong");
            }
        }
        else if (b_dtuong.indexOf("SO_THE") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grdsId);
            if (b_hang > -1) {
                b_hangId = b_hang;
                ns_thongtin_canbo(a_tso[0]);
            }
        }
        else if (b_dtuong.indexOf("DAYPHONG") >= 0) {
            lke_Fs_TRA(b_phongId) = a_tso[0];
            cc_sp_tt_P_LKE();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_thongtin_canbo(b_so_the) {
    try {
        hts_dungchung.Fs_THONGTIN_CANBO_LUOI(b_so_the, ns_thongtin_canbo_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_thongtin_canbo_kq(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var a_kq = Fas_ChMang(b_kq, '#');
    if (a_kq != "") {
        GridX_datGtri(b_grdsId, b_hangId, "so_the", a_kq[1]);
        GridX_datGtri(b_grdsId, b_hangId, "ten", a_kq[2]);
        GridX_datGtri(b_grdsId, b_hangId, "cdanh", a_kq[3]);
        GridX_datGtri(b_grdsId, b_hangId, "phong", a_kq[4]);
    }
    return false;
}
function cc_sp_tt_P_TIM_DG(b_sanpham, b_chatluong, b_ngay) {
    try {
        stl_cc.Fs_CC_SP_TT_TIM_DONGIA(b_sanpham, b_chatluong, b_ngay, cc_sp_tt_P_TIM_DG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function cc_sp_tt_P_TIM_DG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var a_kq = Fas_ChMang(b_kq, '#');
    if (a_kq != "") {
        GridX_datGtri(b_grdsId, b_hangId, "SO_THE", a_kq[1], 'K');
        GridX_datGtri(b_grdsId, b_hangId, "TEN", a_kq[2], 'K');
        GridX_datGtri(b_grdsId, b_hangId, "CDANH", a_kq[3], 'K');
        GridX_datGtri(b_grdsId, b_hangId, "PHONG", a_kq[4], 'K');
    }
    return false;
}
function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}
function cc_sp_tt_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "PHONG": b_maId = b_phongId; GridX_datTrang(b_grdsId); break;
            case "NGAY": b_maId = b_gocId; break;
            case "NGAYD": b_maId = b_ngaydId; break;
            case "NGAYC": b_maId = b_ngaycId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "PHONG") {
            cc_sp_tt_P_LKE_CB();
            cc_sp_tt_P_LKE('K');
        }
        else if (b_maTen == "NGAYD") {
            cc_sp_tt_P_LKE('K');
        }
        else if (b_maTen == "NGAYC") {
            cc_sp_tt_P_LKE('K');
        }
        else if (b_maTen == "NGAY") {
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ngay", b_ma.value);
            if (b_hang < 0) { cc_sp_tt_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); cc_sp_tt_P_CHUYEN_HANG(); }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function cc_sp_tt_sp_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grspId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        b_mt = b_cot;
        if (b_value != "") {
            if (b_cot == "MASP") {
                skhac.Fs_MA_LOI(form_Fs_nsd(),"Mã sản phẩm", b_value, "ns_tl_ma_spham,ma,donvi", cc_sp_tt_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        if (b_value != "") GridX_ThemHang(b_grspId);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function cc_sp_tt_ds_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grdsId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        b_mt = b_cot;
        if (b_value != "") {
            if (b_cot == "SO_THE") {
                skhac.Fs_MA_LOI(form_Fs_nsd(),"Mã cán bộ", b_value, "ns_cb,so_the,ten", cc_sp_tt_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        if (b_value != "") GridX_ThemHang(b_grdsId);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function cc_sp_tt_P_MA_KTRA() {
    try {
        var b_ngay = C_NVL($get(b_gocId).value);
        if (b_ngay != "") {
            var b_ngayd = $get(b_ngaydId).value, b_ngayc = $get(b_ngaycId).value, b_phong = lke_Fs_TRA(b_phongId); b_ca = $get(b_caId).value;
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            stl_cc.Fs_CC_SP_TT_MA(b_ctyValue, b_ngayd, b_ngayc, b_ngay, b_ca, b_TrangKt, a_cot, cc_sp_tt_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function cc_sp_tt_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        form_P_MOI(b_vungId, "X"); GridX_datTrang(b_grspId); GridX_datTrang(b_grdsId);
        $get(b_noteId).focus(); $get(b_so_idId).value = "0";
    }
    else { GridX_datA(b_grlkeId, b_hang); cc_sp_tt_P_CHUYEN_HANG(); }
}

function cc_sp_tt_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_mt == "MASP") {
        var b_hang = GridX_Fi_timHangA(b_grspId);
        GridX_datGtri(b_grspId, b_hang, "donvi", b_kq);
        GridX_datA(b_grspId, b_hang, "chatluong");
    }
    else if (b_mt == "SO_THE") {
        var b_hang = GridX_Fi_timHangA(b_grdsId);
        GridX_datGtri(b_grdsId, b_hang, "ten", b_kq);
        GridX_datA(b_grdsId, b_hang, "congviec");
    }
}
function cc_sp_tt_checkmasp(b_masp, b_chatluong, b_gridId, b_hang) {
    var b_hienthi = "";
    var a_dt = GridX_Fdt_layGtri(b_gridId, "masp"),
        a_dt_loai = GridX_Fdt_layGtri(b_gridId, "chatluong");
    a_dt[b_hang - 1] = ""; a_dt_loai[b_hang - 1] = "";
    if (a_dt != null) {
        for (var i = 0; i < a_dt.length; i++) {
            if (b_masp == a_dt[i] && b_chatluong == a_dt_loai[i]) { b_hienthi = "Trùng mã sản phẩm và chất lượng";  }
        }
    }
    return b_hienthi;
}

var cc_sp_tt_choAct = 0;
function cc_sp_tt_GR_lke_RowChange() {
    if (cc_sp_tt_choAct != 0) clearTimeout(cc_sp_tt_choAct);
    cc_sp_tt_choAct = setTimeout("cc_sp_tt_P_CHUYEN_HANG()", 300);
    return false;
}

function cc_sp_tt_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (cc_sp_tt_lkeCho != 0) clearTimeout(cc_sp_tt_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        form_F_GOC().P_MENUBf(window.name, 'M');
        vb_cctc_P_SL('', 'D', '0', ' ', ' ', 'T');
        b_ctyValue = "TATCA";
        cc_sp_tt_P_LKE('K');
    }
}

function cc_sp_tt_P_MOI() {
    cc_sp_tt_P_LKE_CB();
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grspId);
    GridX_datTrang(b_grdsId);
    $get(b_so_idId).value = "0";
    $get(b_gocId).focus();
    return false;
}

function cc_sp_tt_P_LKE_CB() {
    try {
        var b_lk = $get(b_lhId).value;
        if (b_lk == "C") {
            var b_phong = lke_Fs_TRA(b_phongId), a_cot = GridX_Fas_tenCot(b_grdsId);
            stl_cc.Fs_CC_SP_TT_LKE_CB(form_Fs_nsd(), b_phong, a_cot, cc_sp_tt_P_LKE_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function cc_sp_tt_P_LKE_CB_KQ(b_kq) {
    if (b_kq == "") { GridX_datTrang(b_grdsId); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        //GridX_dat_hangkt(b_grdsId, a_kq[1]);
        GridX_datBang(b_grdsId, a_kq[0]);
        return;
    }
}

function cc_sp_tt_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var b_ngayd = $get(b_ngaydId).value, b_ngayc = $get(b_ngaycId).value, b_phong = lke_Fs_TRA(b_phongId),
            a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_cc.Fs_CC_SP_TT_LKE(b_ctyValue, b_ngayd, b_ngayc, a_tso, a_cot, cc_sp_tt_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function cc_sp_tt_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    b_fcho = 'X';
}
function ktra_ngay(tungay, denngay, loai, ten1, ten2) {
    if (denngay == "" || denngay == null) {
        return "";
    }
    if (loai == 1 && tungay > denngay) {
        return "loi: " + ten1 + " không được lớn hơn " + ten2 + " :loi";
    } else if (loai == 2 && tungay >= denngay) {
        return "loi: " + ten1 + " không được lớn hơn hoặc bằng " + ten2 + " :loi";
    }
    return "";
}
function parseDate(str) {
    var mdy = str.split('/');
    return new Date(mdy[2], mdy[1], mdy[0]);
}
function cc_sp_tt_P_NH() {
    try {
        var ktra = ktra_ngay(parseDate($get(b_ngaydId).value).getTime(), parseDate($get(b_ngaycId).value).getTime(), 1, "Từ ngày", "Đến ngày");
        if (ktra.length > 0) {
            cc_sp_tt_P_NH_KQ(ktra);
            return false;
        }
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_phong = lke_Fs_TRA(b_phongId), b_ngayd = $get(b_ngaydId).value, b_ngayc = $get(b_ngaycId).value;
            var b_so_id = $get(b_so_idId).value, b_dt = form_Faa_TEXT_ROW(b_vungId),
                a_cot_sp = GridX_Fdt_cotGtri(b_grspId), a_cot_ds = GridX_Fdt_cotGtri(b_grdsId),
                b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
            stl_cc.Fs_CC_SP_TT_NH(b_so_id, b_ctyValue, b_ngayd, b_ngayc, b_TrangKt, b_dt, a_cot_sp, a_cot_ds, a_cot_lke, cc_sp_tt_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function cc_sp_tt_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI('loi:Nhập thành công:loi');
    }
    return false;
}
function cc_sp_tt_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == null || b_so_id == "") { form_P_MOI("", "XGL"); GridX_datTrang(b_grspId); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grspId), a_cot_ds = GridX_Fas_tenCot(b_grdsId);
        stl_cc.Fs_CC_SP_TT_CT(b_so_id, a_cot_ct, a_cot_ds, cc_sp_tt_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function cc_sp_tt_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grspId); else GridX_datBang(b_grspId, a_kq[1]);
    if (a_kq[2] == "") GridX_datTrang(b_grdsId); else GridX_datBang(b_grdsId, a_kq[2]);
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    $get(b_so_idId).value = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
}
function cc_sp_tt_P_XOA() {
    var r = confirm("Bạn có chắc chắn xóa không?");
    if (r == false) {
        return false;
    }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") cc_sp_tt_P_MOI();
    else {
        var b_phong = lke_Fs_TRA(b_phongId), b_ngayd = $get(b_ngaydId).value, b_ngayc = $get(b_ngaycId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_cc.Fs_CC_SP_TT_XOA(b_so_id, b_ctyValue, b_ngayd, b_ngayc, a_tso, a_cot, cc_sp_tt_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function cc_sp_tt_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) cc_sp_tt_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); cc_sp_tt_P_CHUYEN_HANG(); }
    }
}
function cc_sp_tt_sp_HangLen() {
    GridX_chuyenHang(b_grspId, -1);
    return false;
}
function cc_sp_tt_sp_HangXuong() {
    GridX_chuyenHang(b_grspId, 1);
    return false;
}
function cc_sp_tt_sp_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grspId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grspId);
    return false;
}
function cc_sp_tt_sp_CatDong() {
    GridX_boChon(b_grspId, 'C');
    return false;
}
function cc_sp_tt_ds_HangLen() {
    GridX_chuyenHang(b_grdsId, -1);
    return false;
}
function cc_sp_tt_ds_HangXuong() {
    GridX_chuyenHang(b_grdsId, 1);
    return false;
}
function cc_sp_tt_ds_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grdsId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grdsId);
    return false;
}
function cc_sp_tt_ds_CatDong() {
    GridX_boChon(b_grdsId, 'C');
    return false;
}

function cc_sp_tt_phong() {
    try {
        var b_tenf = form_Fs_TM() + '/App_form/ht/ht_maph.aspx';
        form_P_MO(b_tenf, null, ["cc_sp_tt", [""]]);
        return false;
    }
    catch (err) { }
}

function form_dong() {
    location.reload(false);
}

function vb_cctc_P_CLICK(b_event, b_id) {
    b_event.stopPropagation();
    var b_targetClassNam = b_event.target.className;
    if (b_targetClassNam == "ico_bptt") {
        var b_ctr = $get(b_id), b_div = $get(b_id + '_Div');
        var a_tso = Attribute_Fas_LAY(b_ctr, 'loai,cap,dvi,ma,ma_ct');
        if (b_ctrbeforId != null) b_ctrbeforId.style.fontWeight = "100";
        b_ctr.style.fontWeight = "700";
        b_ctrbeforId = b_ctr;
        b_ctyValue = a_tso[3];
        cc_sp_tt_P_LKE('K'); return false;
    }
    else {
        var b_ctr = $get(b_id), b_div = $get(b_id + '_Div');
        var a_tso = Attribute_Fas_LAY(b_ctr, 'loai,cap,dvi,ma,ma_ct');
        if (a_tso[0] == 'A') return false;
        if (a_tso[0] != 'C') {
            if (b_div == null) vb_cctc_P_SL(b_id, a_tso[0], a_tso[1], a_tso[2], a_tso[3]);
            else {
                b_id = (C_NVL(b_div.style.display) == '') ? '' : b_id;
                vb_cctc_HIEN(a_tso[4], b_id);
            }
        }
    }
    return false;
}