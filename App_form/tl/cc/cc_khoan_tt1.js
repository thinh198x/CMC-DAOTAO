var cc_khoan_tt_lkeCho, b_vungId, b_vungtkId, b_grlkeId, b_ngaydId, b_ngaycId, b_lhId, b_grspId, b_grdsId, b_gocId, b_phongId, b_ncdanhId, b_mt, b_gchuId, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C', b_hangId, b_ctyId, b_ctyValue, b_ctrbeforId;
function cc_khoan_tt_P_KD() {
    cc_khoan_tt_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtkId = form_Fs_VUNG_ID('UPa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
    b_ngaydId = form_Fs_TEN_ID(b_vungtkId, 'ngayd_tk'), b_ngaycId = form_Fs_TEN_ID(b_vungtkId, 'ngayc_tk'),
    b_phongId = form_Fs_TEN_ID(b_vungId, 'PHONG'), b_gocId = form_Fs_TEN_ID(b_vungId, 'NGAY'); b_tienId = form_Fs_TEN_ID(b_vungId, 'tien');
    b_maspId = form_Fs_TEN_ID(b_vungId, 'masp');
    b_lhId = form_Fs_TEN_ID(b_vungId, 'lh'),
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_slideId = $get(b_grlkeId).getAttribute('slideId');
    cc_khoan_tt_lkeCho = setInterval('cc_khoan_tt_P_LKE_CHO()', 200);
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
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_tienId).focus();
            //cc_khoan_tt_P_MOI();
            $get(b_maspId).value = b_kq;
        }
        else if (b_dtuong.indexOf("SO_THE") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang > -1) {
                b_hangId = b_hang;
                ns_thongtin_canbo(a_tso[0]);
            }
        }
        else if (b_dtuong.indexOf("DAYPHONG") >= 0) {
            $get(b_phongId).value = a_tso[0];
            cc_khoan_tt_P_LKE('K');
        }
    }
    catch (err) { form_P_LOI(err); }
}

function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
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
        GridX_datGtri(b_grctId, b_hangId, "so_the", a_kq[1]);
        GridX_datGtri(b_grctId, b_hangId, "ten", a_kq[2]);
        GridX_datGtri(b_grctId, b_hangId, "cdanh", a_kq[3]);
        GridX_datGtri(b_grctId, b_hangId, "phong", a_kq[4]);
    }
    return false;
}
function cc_khoan_tt_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "PHONG": b_maId = b_phongId; GridX_datTrang(b_grctId); break;
            case "NGAY": b_maId = b_gocId; break;
            case "NGAYD": b_maId = b_ngaydId; break;
            case "NGAYC": b_maId = b_ngaycId; break;
            case "MASP": b_maId = b_maspId; break;
        }
        b_mt = b_maTen;
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "PHONG") {
            cc_khoan_tt_P_LKE_CB();
            cc_khoan_tt_P_LKE('K');
        }
        else if (b_maTen == "NGAYD") {
            cc_khoan_tt_P_LKE('K');
        }
        else if (b_maTen == "NGAYC") {
            cc_khoan_tt_P_LKE('K');
        }
        else if (b_maTen == "MASP") {
            var b_ngay = $get(b_gocId).value;
            if (b_ngay == "") {
                skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), cc_khoan_tt_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
            else {
                cc_khoan_tt_P_MA_KTRA();
                skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), cc_khoan_tt_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        else if (b_maTen == "NGAY") {
            var b_masp = $get(b_maspId).value;
            if (b_masp == "") {
                alert("phải nhập mã sản phẩm/công việc trước");
                return;
            }
            var b_hang = GridX_Fi_timHangD(b_grlkeId, ["masp", "ngay"], [b_masp, b_ma.value]);
            if (b_hang < 0) { cc_khoan_tt_P_MA_KTRA();}
            else { GridX_datA(b_grlkeId, b_hang); cc_khoan_tt_P_CHUYEN_HANG(); }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function cc_khoan_tt_P_LKE_CB() {
    try {
        var b_lk = $get(b_lhId).value;
        if (b_lk == "C") {
            var b_phong = lke_Fs_TRA(b_phongId), a_cot = GridX_Fas_tenCot(b_grctId);
            stl_cc.Fs_CC_SP_TT_LKE_CB(form_Fs_nsd(), b_phong, a_cot, cc_khoan_tt_P_LKE_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        } else
        {
            GridX_datBang(b_grctId,"");
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function cc_khoan_tt_P_LKE_CB_KQ(b_kq) {
    if (b_kq == "") { GridX_datTrang(b_grctId); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#'); 
        GridX_datBang(b_grctId, a_kq[0]);
        return;
    }
}

function cc_khoan_tt_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grctId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        b_mt = b_cot;
        if (b_value != "") {
            if (b_cot == "SO_THE") {
                skhac.Fs_MA_LOI(form_Fs_nsd(),"Mã cán bộ", b_value, "ns_cb,so_the,ten", cc_khoan_tt_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        if (b_value != "") GridX_ThemHang(b_grctId);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function cc_khoan_tt_P_MA_KTRA() {
    try {
        var b_ngay = C_NVL($get(b_gocId).value);
        if (b_ngay != "") {
            var b_ngayd = $get(b_ngaydId).value, b_ngayc = $get(b_ngaycId).value,
                b_phong = lke_Fs_TRA(b_phongId), b_masp = $get(b_maspId).value;
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            stl_cc.Fs_CC_KHOAN_TT_MA(b_ctyValue, b_masp, b_ngayd, b_ngayc, b_ngay, b_TrangKt, a_cot, cc_khoan_tt_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function cc_khoan_tt_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        form_P_MOI(b_vungId, "X");
        $get(b_tienId).focus();
        GridX_datTrang(b_grctId);
        $get(b_so_idId).value = "0";
    }
    else { GridX_datA(b_grlkeId, b_hang); cc_khoan_tt_P_CHUYEN_HANG(); }
}

function cc_khoan_tt_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_mt == "MASP") {
        $get(b_gchuId).innerHTML = b_kq;
        $get(b_gocId).focus();
    }
    else if (b_mt == "SO_THE") {
        var b_hang = GridX_Fi_timHangA(b_grctId);
        GridX_datGtri(b_grctId, b_hang, "ten", b_kq);
        GridX_datA(b_grctId, b_hang, "congviec");
    }
}

var cc_khoan_tt_choAct = 0;
function cc_khoan_tt_GR_lke_RowChange() {
    if (cc_khoan_tt_choAct != 0) clearTimeout(cc_khoan_tt_choAct);
    cc_khoan_tt_choAct = setTimeout("cc_khoan_tt_P_CHUYEN_HANG()", 300);
    return false;
}

function cc_khoan_tt_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (cc_khoan_tt_lkeCho != 0) clearTimeout(cc_khoan_tt_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        form_F_GOC().P_MENUBf(window.name, 'M');
        vb_cctc_P_SL('', 'D', '0', ' ', ' ', 'T'); //  vb_cctc_P_SL('', 'A', '0', ' ', ' ', 'T'); -- Chỉ hiện đơn vị
        b_ctyValue = "TATCA";
        cc_khoan_tt_P_LKE('K');
    }
}

function cc_khoan_tt_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    $get(b_so_idId).value = "0";
    $get(b_maspId).focus();
    var b_lk = $get(b_lhId).value;
    if (b_lk == "C") {
        var b_phong = lke_Fs_TRA(b_phongId), a_cot = GridX_Fas_tenCot(b_grctId);
        stl_cc.Fs_CC_CN_CT_LKE_CB(b_phong, a_cot, cc_khoan_tt_P_LKE_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    } else {
        GridX_datBang(b_grctId,"");
    }
    return false;
}
function cc_khoan_tt_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var b_ngayd = $get(b_ngaydId).value, b_ngayc = $get(b_ngaycId).value, b_phong = lke_Fs_TRA(b_phongId),
            a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_cc.Fs_CC_KHOAN_TT_LKE(b_ctyValue, b_ngayd, b_ngayc, a_tso, a_cot, cc_khoan_tt_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function cc_khoan_tt_P_LKE_KQ(b_kq) {
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
function cc_khoan_tt_P_NH() {
    try {
        var ktra = ktra_ngay(parseDate($get(b_ngaydId).value).getTime(), parseDate($get(b_ngaycId).value).getTime(), 1, "Từ ngày", "Đến ngày");
        if (ktra.length > 0) {
            cc_khoan_tt_P_NH_KQ(ktra);
            return false;
        }
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_phong = lke_Fs_TRA(b_phongId), b_ngayd = $get(b_ngaydId).value, b_ngayc = $get(b_ngaycId).value;
            var b_so_id = $get(b_so_idId).value, b_dt = form_Faa_TEXT_ROW(b_vungId),
                a_cot_ct = GridX_Fdt_cotGtri(b_grctId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
            stl_cc.Fs_CC_KHOAN_TT_NH(b_so_id, b_ctyValue, b_ngayd, b_ngayc, b_TrangKt, b_dt, a_cot_ct, a_cot_lke, cc_khoan_tt_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function cc_khoan_tt_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI("loi:Nhập thành công!:loi");
    }
    return false;
}
function cc_khoan_tt_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == null || b_so_id == "") {
        form_P_MOI("", "XGL"); GridX_datTrang(b_grctId);
        cc_khoan_tt_P_MOI();
    }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        stl_cc.Fs_CC_KHOAN_TT_CT(b_so_id, a_cot_ct, cc_khoan_tt_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function cc_khoan_tt_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    $get(b_so_idId).value = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
}
function cc_khoan_tt_P_XOA() {
    var r = confirm("Bạn có chắc chắn xóa không?");
    if (r == false) {
        return false;
    }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") cc_khoan_tt_P_MOI();
    else {
        var b_phong = lke_Fs_TRA(b_phongId), b_ngayd = $get(b_ngaydId).value, b_ngayc = $get(b_ngaycId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_cc.Fs_CC_KHOAN_TT_XOA(b_so_id, b_ctyValue, b_ngayd, b_ngayc, a_tso, a_cot, cc_khoan_tt_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function cc_khoan_tt_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) cc_khoan_tt_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); cc_khoan_tt_P_CHUYEN_HANG(); }
    }
}
function cc_khoan_tt_HangLen() {
    GridX_chuyenHang(b_grdsId, -1);
    return false;
}
function cc_khoan_tt_HangXuong() {
    GridX_chuyenHang(b_grdsId, 1);
    return false;
}
function cc_khoan_tt_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grdsId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grdsId);
    return false;
}
function cc_khoan_tt_CatDong() {
    GridX_boChon(b_grdsId, 'C');
    return false;
}

function cc_khoan_tt_phong() {
    try {
        var b_tenf = form_Fs_TM() + '/App_form/ht/ht_maph.aspx';
        form_P_MO(b_tenf, null, ["cc_khoan_tt", [""]]);
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
        b_ctyValue = a_tso[3]; //  b_ctyValue = a_tso[2]; -- Chỉ hiện đơn vị
        cc_khoan_tt_P_LKE('K'); return false;
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
