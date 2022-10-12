var cc_sp_cn_lkeCho, b_vungId, b_vungtkId, b_grlkeId, b_ngaydI, b_ngaycId, b_sothe_tkId, b_ngayId, b_grctId, b_grdsId, b_gocId, b_ncdanhId, b_mt, b_gchuId, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C';
function cc_sp_cn_P_KD() {
    cc_sp_cn_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtkId = form_Fs_VUNG_ID('UPa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
    b_ngaydId = form_Fs_TEN_ID(b_vungtkId, 'ngayd_tk'), b_ngaycId = form_Fs_TEN_ID(b_vungtkId, 'ngayc_tk'), b_sothe_tkId = form_Fs_TEN_ID(b_vungtkId, 'so_the_tk'), b_ngayId = form_Fs_TEN_ID(b_vungId, 'NGAY'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE'); b_noteId = form_Fs_TEN_ID(b_vungId, 'note'); b_caId = form_Fs_TEN_ID(b_vungId, 'ca');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'); b_slideId = b_grlkeId + '_slide';
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    cc_sp_cn_lkeCho = setInterval('cc_sp_cn_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("MASP") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang > -1) {
                GridX_datGtri(b_grctId, b_hang, "masp", b_kq);
                GridX_datGtri(b_grctId, b_hang, "donvi", a_tso[2]);
                $get(b_gchuId).innerHTML = a_tso[1];
                GridX_datA(b_grctId, b_hang, "chatluong");
            }
        }
        else if (b_dtuong.indexOf("SO_THE") >= 0) {
            $get(b_gocId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            cc_sp_cn_P_LKE('K');
            $get(b_gocId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}
function cc_sp_cn_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; form_P_MOI("", "XGL"); GridX_datTrang(b_grctId); break;
            case "NGAYD": b_maId = b_ngaydId; break;
            case "NGAYC": b_maId = b_ngaycId; break;
            case "NGAY": b_maId = b_ngayId; break;
        }
        var b_ma = $get(b_maId);
        b_mt = b_maTen;
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), cc_sp_cn_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            cc_sp_cn_P_LKE('K');
        }
        else if (b_maTen == "NGAYD") {
            cc_sp_cn_P_LKE('K');
        }
        else if (b_maTen == "NGAYC") {
            cc_sp_cn_P_LKE('K');
        }
        else if (b_maTen == "NGAY") {
            cc_sp_cn_P_MA_KTRA();
        }
        else if (b_maTen == "CHATLUONG") {
            var b_masp = GridX_Fas_layGtriA(b_grctId, "masp");
            var b_hang = GridX_Fi_timHangA(b_grctId);
            var b_check = cc_sp_cn_checkmasp(b_masp, b_kq, b_grctId, b_hang);
            if (b_check == "") {
                GridX_datA(b_grctId, b_hang, "soluong");
            }
            else {
                GridX_datGtri(b_grctId, b_hang, "chatluong", "");
                GridX_datA(b_grctId, b_hang, "chatluong");
                alert(b_check);
            }
        }
    }
    catch (err) { form_P_LOI(err); }
}

function cc_sp_cn_P_MA_KTRA() {
    try {
        var b_ngay = C_NVL($get(b_ngayId).value);
        if (b_ngay != "") {
            var b_ngayd = $get(b_ngaydId).value, b_ngayc = $get(b_ngaycId).value, b_so_the = $get(b_sothe_tkId).value, b_ca = $get(b_caId).value;
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            stl_cc.Fs_CC_SP_CN_MA(b_so_the, b_ngayd, b_ngayc, b_ngay, b_ca, b_TrangKt, a_cot, cc_sp_cn_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function cc_sp_cn_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        form_P_MOI(b_vungId, "X"); GridX_datTrang(b_grctId);
        $get(b_caId).focus(); $get(b_so_idId).value = "0";
    }
    else { GridX_datA(b_grlkeId, b_hang); cc_sp_cn_P_CHUYEN_HANG(); }
}

function cc_sp_cn_sp_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grctId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        b_mt = b_cot;
        if (b_value != "") {
            if (b_cot == "MASP") {
                skhac.Fs_MA_LOI(form_Fs_nsd(),"Mã sản phẩm", b_value, "ns_tl_ma_spham,ma,donvi", cc_sp_cn_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        if (b_value != "") GridX_ThemHang(b_grctId);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function cc_sp_cn_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_mt == "MASP") {
        var b_hang = GridX_Fi_timHangA(b_grctId);
        GridX_datGtri(b_grctId, b_hang, "donvi", b_kq);
        GridX_datA(b_grctId, b_hang, "chatluong");
    }
    else if (b_mt == "SO_THE") {
        $get(b_gchuId).innerHTML = b_kq;
        GridX_datA(b_grctId, 0, "masp");
    }
}
function cc_sp_cn_checkmasp(b_masp, b_chatluong, b_gridId, b_hang) {
    var b_hienthi = "";
    var a_dt = GridX_Fdt_layGtri(b_gridId, "masp"),
        a_dt_loai = GridX_Fdt_layGtri(b_gridId, "chatluong");
    a_dt[b_hang - 1] = ""; a_dt_loai[b_hang - 1] = "";
    if (a_dt != null) {
        for (var i = 0; i < a_dt.length; i++) {
            if (b_masp == a_dt[i] && b_chatluong == a_dt_loai[i]) { b_hienthi = "Trùng mã sản phẩm và chất lượng"; }
        }
    }
    return b_hienthi;
}

var cc_sp_cn_choAct = 0;
function cc_sp_cn_GR_lke_RowChange() {
    if (cc_sp_cn_choAct != 0) clearTimeout(cc_sp_cn_choAct);
    cc_sp_cn_choAct = setTimeout("cc_sp_cn_P_CHUYEN_HANG()", 300);
    return false;
}

function cc_sp_cn_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (cc_sp_cn_lkeCho != 0) clearTimeout(cc_sp_cn_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        cc_sp_cn_P_LKE('K');
    }
}

function cc_sp_cn_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    $get(b_so_idId).value = "0";
    $get(b_gocId).focus();
    return false;
}
function cc_sp_cn_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var b_ngayd = $get(b_ngaydId).value, b_ngayc = $get(b_ngaycId).value, b_so_the = $get(b_sothe_tkId).value,
            a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_cc.Fs_CC_SP_CN_LKE(b_so_the, b_ngayd, b_ngayc, a_tso, a_cot, cc_sp_cn_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function cc_sp_cn_P_LKE_KQ(b_kq) {
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
function cc_sp_cn_P_NH() {
    try {
        var ktra = ktra_ngay(parseDate($get(b_ngaydId).value).getTime(), parseDate($get(b_ngaycId).value).getTime(), 1, "Từ ngày", "Đến ngày");
        if (ktra.length > 0) {
            cc_sp_cn_P_NH_KQ(ktra);
            return false;
        }
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_so_the = $get(b_sothe_tkId).value, b_ngayd = $get(b_ngaydId).value, b_ngayc = $get(b_ngaycId).value;
            var b_so_id = $get(b_so_idId).value, b_dt = form_Faa_TEXT_ROW(b_vungId),
                a_cot_ct = GridX_Fdt_cotGtri(b_grctId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
            stl_cc.Fs_CC_SP_CN_NH(b_so_id, b_so_the, b_ngayd, b_ngayc, b_TrangKt, b_dt, a_cot_ct, a_cot_lke, cc_sp_cn_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function cc_sp_cn_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) { GridX_datA(b_grlkeId, b_hang); cc_sp_cn_P_CHUYEN_HANG(); };
        $get(b_gocId).focus();
        form_P_LOI("loi:Nhập thành công!:loi");  
    }
    return false;
}
function cc_sp_cn_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == null || b_so_id == "") { form_P_MOI("", "XGL"); GridX_datTrang(b_grctId); }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId);
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        stl_cc.Fs_CC_SP_CN_CT(b_so_id, a_cot, a_cot_ct, cc_sp_cn_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function cc_sp_cn_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    $get(b_so_idId).value = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
}
function cc_sp_cn_P_XOA() {
    var r = confirm("Bạn có chắc chắn xóa không?");
    if (r == false) {
        return false;
    }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") cc_sp_cn_P_MOI();
    else {
        var b_so_the = $get(b_sothe_tkId).value, b_ngayd = $get(b_ngaydId).value, b_ngayc = $get(b_ngaycId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_cc.Fs_CC_SP_CN_XOA(b_so_id, b_so_the, b_ngayd, b_ngayc, a_tso, a_cot, cc_sp_cn_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function cc_sp_cn_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) cc_sp_cn_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); cc_sp_cn_P_CHUYEN_HANG(); }
    }
}
function cc_sp_cn_sp_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function cc_sp_cn_sp_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function cc_sp_cn_sp_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function cc_sp_cn_sp_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}


function form_dong() {
    location.reload(false);
}
