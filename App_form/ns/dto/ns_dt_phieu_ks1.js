var ns_dt_phieu_ks_lkeCho, b_vungId, b_nsd, b_dotId, b_grlkeId, b_vungsId, b_grctId, b_grdsId, b_gocId, b_ncdanhId, b_mt, b_gchuId,
     b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C',b_ma_nhucauId;
function ns_dt_phieu_ks_P_KD(nsd) {
    b_nsd = nsd;
    ns_dt_phieu_ks_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
    b_vungsId = form_Fs_VUNG_ID('UPa_tk'),
    b_ngayguiId = form_Fs_TEN_ID(b_vungId, 'ngay_gui'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE'); b_tenId = form_Fs_TEN_ID(b_vungId, 'ho_ten'); b_LkeId = form_Fs_TEN_ID(b_vungsId, 'lke');
    b_tennhucauId = form_Fs_TEN_ID(b_vungId, 'ten_nhucau');
    b_dotId = form_Fs_TEN_ID(b_vungId, 'dot');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'); b_slideId = b_grlkeId + '_slide';
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    ns_dt_phieu_ks_lkeCho = setInterval('ns_dt_phieu_ks_P_LKE_CHO()', 200);

}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[1];
        if (b_dtuong.indexOf("TEN_NHUCAU") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            GridX_datGtri(b_grctId, b_hang, "MA_NHUCAU", a_tso[0]);
            GridX_datGtri(b_grctId, b_hang, "TEN_NHUCAU", b_kq);
        } else if (b_dtuong.indexOf("TEN_HINHTHUC") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            GridX_datGtri(b_grctId, b_hang, "hinhthuc", a_tso[0]);
            GridX_datGtri(b_grctId, b_hang, "ten_hinhthuc", b_kq);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}
function ns_dt_phieu_ks_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "DOT": b_maId = b_gocId; form_P_MOI("", "XGL"); GridX_datTrang(b_grctId); break;
            case "LKE": b_maId = b_gocId; form_P_MOI("", "XGL"); GridX_datTrang(b_grctId); break;
        }
        var b_ma = $get(b_maId);
        b_mt = b_maTen;
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "DOT") { ns_dt_phieu_ks_P_MA_KTRA(); }
        if (b_maTen == "LKE") { ns_dt_phieu_ks_P_LKE_CHO(); }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_thongtin_canbo() {
    try {
        var b_so_the = $get(b_gocId).value;
        hts_dungchung.Fs_THONGTIN_CANBO(b_so_the, ns_thongtin_canbo_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_thongtin_canbo_kq(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
function ns_dt_phieu_ks_P_MA_KTRA() {
    try {
        var b_ma = $get(b_dotId).value, b_lke = $get(b_LkeId).value;
        var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
        sns_dto.Fs_NS_DT_PHIEU_KS_MA(b_ma, b_lke, b_TrangKt, a_cot, ns_dt_phieu_ks_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_phieu_ks_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang2(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        form_P_MOI(b_vungId, "X"); GridX_datTrang(b_grctId);
        $get(b_so_idId).value = "0";
    }
    else { GridX_datA(b_grlkeId, b_hang); ns_dt_phieu_ks_P_CHUYEN_HANG(); }
}
function ns_dt_phieu_ks_sp_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grctId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        b_mt = b_cot;
        if (b_value != "") {
            if (b_cot == "MASP") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Mã nhu cầu", b_value, "ns_ma_nhucau_dt,ma,ten", ns_dt_phieu_ks_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        if (b_value != "") GridX_ThemHang(b_grctId);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_dt_phieu_ks_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
}
function ns_dt_phieu_ks_checkmasp(b_masp, b_chatluong, b_gridId, b_hang) {
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

var ns_dt_phieu_ks_choAct = 0;
function ns_dt_phieu_ks_GR_lke_RowChange() {
    ns_thongtin_canbo();
    if (ns_dt_phieu_ks_choAct != 0) clearTimeout(ns_dt_phieu_ks_choAct);
    ns_dt_phieu_ks_choAct = setTimeout("ns_dt_phieu_ks_P_CHUYEN_HANG()", 300);
    //return false;
}

function ns_dt_phieu_ks_P_LKE_CHO() {
    if (ns_dt_phieu_ks_lkeCho != 0) clearTimeout(ns_dt_phieu_ks_lkeCho);
    b_slideId = $get(b_grlkeId).getAttribute('slideId');
    ns_dt_phieu_ks_P_LKE('K');  
}

function ns_dt_phieu_ks_P_MOI() {
    form_P_MOI(b_vungId, "X");
    for (var b_hang = 0; b_hang < 10; b_hang++) {
        GridX_datGtri(b_grctId, b_hang, ["hinhthuc"], "", 'K');
        GridX_datGtri(b_grctId, b_hang, ["ten_hinhthuc"], "", 'K');
        GridX_datGtri(b_grctId, b_hang, ["NTHOI_DIEM_TG"], "", 'K');
        GridX_datGtri(b_grctId, b_hang, ["ghichu"], "", 'K');
    }
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = "0";
    $get(b_gocId).focus();
    return false;
}
function ns_dt_phieu_ks_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        ns_thongtin_canbo();
        var b_ma = $get(b_dotId).value, b_lke =$get(b_LkeId).value;
        a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dto.Fs_NS_DT_PHIEU_KS_LKE(b_ma, b_lke, a_tso, a_cot, ns_dt_phieu_ks_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_phieu_ks_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    if (a_kq[0] != "") {
        GridX_datBang2(b_grlkeId, a_kq[1]);
        //GridX_datA(b_grlkeId, 1);
        //ns_dt_phieu_ks_GR_lke_RowChange();
    }
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
function ns_dt_phieu_ks_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_dt = form_Faa_TEXT_ROW(b_vungId), b_ma = C_NVL(lke_Fs_TRA($get(b_dotId))), b_lke = $get(b_LkeId).value;
            a_cot_ct = GridX_Fdt_cotGtri(b_grctId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            var b_hang = GridX_Fi_timHangA(b_grlkeId), b_so_id = 0;
            if (b_hang > 0) b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
            sns_dto.Fs_NS_DT_PHIEU_KS_NH(b_so_id, b_ma, b_lke, b_TrangKt, b_dt, a_cot_ct, a_cot_lke, a_tso, ns_dt_phieu_ks_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_dt_phieu_ks_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        if (a_kq[0] != "") {
            GridX_datBang2(b_grlkeId, a_kq[1]);
            GridX_datA(b_grlkeId, 1);
            ns_dt_phieu_ks_GR_lke_RowChange();
        }
        $get(b_gocId).focus();
        form_P_LOI("loi:Nhập thành công:loi");
    }
    return false;
}
function ns_dt_phieu_ks_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == null || b_so_id == "") { form_P_MOI("", "XGL"); GridX_datTrang(b_grctId); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        sns_dto.Fs_NS_DT_PHIEU_KS_CT(b_so_id, a_cot_ct, ns_dt_phieu_ks_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function ns_dt_phieu_ks_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId); else {
        GridX_datBang2(b_grctId, a_kq[1]);
        setInterval(myTimer, 1000);
    }
    if (a_kq[2] != "") $get(b_ngayguiId).value = a_kq[2];
    
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    $get(b_so_idId).value = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
}
function myTimer() {
    $("input[placeholder='dd/MM/yyyy']").datepicker({
        dateFormat: 'dd/mm/yy'
    });
}
function ns_dt_phieu_ks_P_XOA() {
    var r = confirm("Bạn có chắc chắn xóa không?");
    if (r == false) {
        return false;
    }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") ns_dt_phieu_ks_P_MOI();
    else {
        var b_ma = b_ma = C_NVL(lke_Fs_TRA($get(b_dotId))), b_tt = $get(b_LkeId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        if (b_tt == 2) { form_P_LOI("loi:Phiếu khảo sát đã kết thúc, Bạn không thể xóa:loi"); return false; }
        sns_dto.Fs_NS_DT_PHIEU_KS_XOA(b_so_id, b_ma, b_tt, a_tso, a_cot, ns_dt_phieu_ks_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_dt_phieu_ks_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang2(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dt_phieu_ks_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dt_phieu_ks_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
}
function ns_dt_phieu_ks_sp_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_dt_phieu_ks_sp_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_dt_phieu_ks_sp_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function ns_dt_phieu_ks_sp_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}


function form_dong() {
    location.reload(false);
}
