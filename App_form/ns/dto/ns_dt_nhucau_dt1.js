var ns_dt_nhucau_dt_choAct = 0, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C',b_trangthaiId
var ns_dt_nhucau_dt_lkeCho, b_vungId, b_grlkeId, b_loaidt, b_grctId, b_grdsId, b_gocId, b_ncdanhId, b_mt, b_gchuId, b_loaidtId;
function ns_dt_nhucau_dt_P_KD() {
    ns_dt_nhucau_dt_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
    b_loaidt = form_Fs_TEN_ID(b_vungId, 'loaidt'), b_trangthaiId = form_Fs_TEN_ID(b_vungId, 'tt');
    b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'); b_tenId = form_Fs_TEN_ID(b_vungId, 'TEN');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'); b_slideId = b_grlkeId + '_slide'; b_Id_cdanhId = form_Fs_VTEN_ID('UPa_hi', 'id_cdanh'); b_cdanhId = form_Fs_VTEN_ID(b_vungId, 'cdanh');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu'); b_loaidtId = form_Fs_TEN_ID(b_vungId, 'LOAIDT');
    ns_dt_nhucau_dt_lkeCho = setInterval('ns_dt_nhucau_dt_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[1];
        if (b_dtuong.indexOf("TEN_HINHTHUC") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            GridX_datGtri(b_grctId, b_hang, "MA_HINHTHUC", a_tso[0]);
            GridX_datGtri(b_grctId, b_hang, "TEN_HINHTHUC", b_kq);
        }
        if (b_dtuong.indexOf("CDANH") >= 0) {
            $get(b_cdanhId).value = a_tso[0];
        }
        else if (b_dtuong.indexOf("THAMSO") >= 0) {
            var b_kq = a_tso[0]

            $get(b_loaidt).setAttribute("disabled", "disabled");
            $get(b_loaidt).value = b_kq;
            ns_dt_nhucau_dt_P_LKE('K'); form_P_MOI(b_vungId, "GX");
        }
        else if (b_dtuong.indexOf("THAMSO") >= 0) {
            var b_kq = a_tso[0];
            lke_Fs_TRA($get(b_ncdId)) = b_kq;
            ns_dt_nhucau_dt_P_LKE('K');
        }
    }
    catch (err) { form_P_LOI(err); }
}

function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}
function ns_dt_nhucau_dt_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; form_P_MOI("", "XGL"); GridX_datTrang(b_grctId); break;
            case "LOAIDT": b_maId = b_loaidt; form_P_MOI("", "XGL"); GridX_datTrang(b_grctId); break;
        }
        var b_ma = $get(b_maId);
        b_mt = b_maTen;
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA" || b_maTen == "LOAIDT") {
            // skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_dt_nhucau_dt_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN); //$get(b_dchiId).focus();
            ns_dt_nhucau_dt_P_MA_KTRA();
        }
    }
    catch (err) { form_P_LOI(err); }
}
// Kiểm tra
function ns_dt_nhucau_dt_P_MA_KTRA() {
    try {
        //var b_ma = $get(b_gocId).value,b_loai = $get(b_loaidt).value;
        //var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
        //sns_dto.Fs_NS_DT_NHUCAU_DT_MA(b_loai,b_ma, b_TrangKt, a_cot, ns_dt_nhucau_dt_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        ns_dt_nhucau_dt_P_LKE('K');
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_nhucau_dt_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        form_P_MOI(b_vungId, "X"); GridX_datTrang(b_grctId);
        $get(b_so_idId).value = "0";
    }
    else { GridX_datA(b_grlkeId, b_hang); ns_dt_nhucau_dt_P_CHUYEN_HANG(); }
}
// Nhập 
function ns_dt_nhucau_dt_P_NH() {
    try {

        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_so_id = $get(b_so_idId).value, b_dt = form_Faa_TEXT_ROW(b_vungId),
                a_cot_ct = GridX_Fdt_cotGtri(b_grctId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
            sns_dto.Fs_NS_DT_NHUCAU_DT_NH(b_so_id, b_TrangKt, b_dt, a_cot_ct, a_cot_lke, ns_dt_nhucau_dt_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_nhucau_dt_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI("loi:Nhập thành công:loi");
    }
    return false;
}
// Làm mới 
function ns_dt_nhucau_dt_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    $get(b_so_idId).value = "0";
    $get(b_gocId).value = '';
    $get(b_trangthaiId).value = "";
    $get(b_loaidtId).value = "";
    $get(b_gocId).focus();
    return false;
}
// Xóa
function ns_dt_nhucau_dt_P_XOA() {
    var r = confirm("Bạn có chắc chắn xóa không?");
    if (r == false) {
        return false;
    }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") ns_dt_nhucau_dt_P_MOI();
    else {
        var b_ma = $get(b_gocId).value, b_loai = form_Fs_TEN_GTRI(b_vungId, 'loaidt');
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dto.Fs_NS_DT_NHUCAU_DT_XOA(b_so_id, b_loai, b_ma, a_tso, a_cot, ns_dt_nhucau_dt_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_dt_nhucau_dt_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dt_nhucau_dt_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dt_nhucau_dt_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công:loi");
    }
}
// Chuyển hàng
function ns_dt_nhucau_dt_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == null || b_so_id == "") { form_P_MOI("", "XGL"); GridX_datTrang(b_grctId); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        sns_dto.Fs_NS_DT_NHUCAU_DT_CT(b_so_id, a_cot_ct, ns_dt_nhucau_dt_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function ns_dt_nhucau_dt_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    $get(b_so_idId).value = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
}
// Liệt kê
function ns_dt_nhucau_dt_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (ns_dt_nhucau_dt_lkeCho != 0) clearTimeout(ns_dt_nhucau_dt_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_dt_nhucau_dt_P_LKE('K');
    }
}
function ns_dt_nhucau_dt_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var b_ma = $get(b_gocId).value, b_loai = form_Fs_TEN_GTRI(b_vungId, 'loaidt'),
            a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dto.Fs_NS_DT_NHUCAU_DT_LKE(b_loai, b_ma, a_tso, a_cot, ns_dt_nhucau_dt_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_nhucau_dt_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        GridX_datA(b_grlkeId, 1);
    }
    b_fcho = 'X';
}
function ns_dt_nhucau_dt_sp_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grctId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        b_mt = b_cot;
        if (b_value != "") {
            if (b_cot == "MASP") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Mã nhu cầu", b_value, "ns_MA_HINHTHUC_dt,ma,ten", ns_dt_nhucau_dt_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        if (b_value != "") GridX_ThemHang(b_grctId);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_nhucau_dt_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
}
function ns_dt_nhucau_dt_checkmasp(b_masp, b_chatluong, b_gridId, b_hang) {
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
//
function ns_dt_nhucau_dt_GR_lke_RowChange() {
    if (ns_dt_nhucau_dt_choAct != 0) clearTimeout(ns_dt_nhucau_dt_choAct);
    ns_dt_nhucau_dt_choAct = setTimeout("ns_dt_nhucau_dt_P_CHUYEN_HANG()", 300);
    return false;
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
function form_P_TRA_CHON_GRID(b_ten) {
    try {
        var a_kq = form_P_TRA_GTRI_GRID(b_ten);
        form_P_DONG(window.name, a_kq);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function form_P_TRA_HOI_CHON(b_ten) {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) {
            form_P_LOI("loi:Bạn chưa chọn dữ liệu:loi"); return false;
        }
        form_P_TRA_CHON(b_ten);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
// Cắt chèn dòng
function form_P_TRA_GTRI_GRID(b_ten) {
    try {
        var a_ten = b_ten.split(','), a_kq = [];
        for (var i = 0; i < a_ten.length; i++) {
            var a_grid = a_ten[i].split(':');
            var b_gridId = form_Fs_VUNG_ID(a_grid[0]);
            var b_hang = GridX_Fi_timHangA(b_gridId);
            a_kq[i] = GridX_Fas_layGtri(b_gridId, b_hang, a_grid[1]);
        }
        return a_kq;
    }
    catch (err) { return null; }
}
function ns_dt_nhucau_dt_sp_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_dt_nhucau_dt_sp_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_dt_nhucau_dt_sp_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function ns_dt_nhucau_dt_sp_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}
function form_dong() {
    location.reload(false);
}
