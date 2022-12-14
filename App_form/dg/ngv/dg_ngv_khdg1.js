var dg_ngv_khdg_lkeCho, b_vungId, b_vungtkId, b_grlkeId, b_slideId, b_gocId, b_lngId, dg_ngv_khdg_choAct, b_nhom_cdanhId, b_cdanhId, b_nam_tkId,
    b_namId, b_ngay_adId, b_ky_dg_tkId, b_cdanh_tkId, b_ky_dgId, b_sttId, b_ngay_d_Id,
    b_ma_cauhoiId, b_nd_cauhoiId, b_tongdiem5, b_tongdiem4, b_tongdiem3, b_tongdiem2, b_tongdiem1,
b_choAct = 0, b_fcho = 'C';
function dg_ngv_khdg_P_KD() {
    dg_ngv_khdg_lkeCho = setInterval('dg_ngv_khdg_P_LKE_CHO()', 200);
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "" || a_tso[0] == "FILE_HTOAN") return;
        b_dtuong = b_dtuong.toUpperCase();
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        b_doi = 0;
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            ns_thongtin_canbo(a_tso[0], "SO_THE");
        } 
    }
    catch (err) { form_P_LOI(err); }
}
function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
    if (C_NVL(b_dtuong) != '') {
        if (b_dtuong == 'THAMSO') {
            var b_s = (a_tso[0] == 'K') ? 'M' : 'B';
        }
        else form_NhanKq(b_dtuong, a_tso[0]);
    }
}
function dg_ngv_khdg_P_KTRA(b_maTen) {
    try {
        var b_maId = form_Fs_TEN_ID('', b_maTen);
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "NAM") {
            var b_nam = b_ma.value;
            sdg.Fdt_NS_DG_MA_KDG_NHL(window.name, b_nam, "DT_KY_DG", dg_dm_tlap_dtuong_dgia_P_KTRA_DR_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
        else if (b_maTen == "KY_DG") {
            var b_kdg = lke_Fs_TRA($get(b_ky_dgId));
            sdg.Fdt_NS_DG_MA_DTDG_NCDANH(window.name, b_kdg, "DT_NHOM_CDANH", dg_dm_tlap_dtuong_dgia_P_KTRA_DR_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        } else if (b_maTen == "SO_THE") {
            ns_thongtin_canbo(b_ma.value, "SO_THE");
            return;
        }
    }
    catch (err) { form_P_LOI(err); }
}

//Nhập
function dg_ngv_khdg_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId); var b_so_id = 0;
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt = form_Faa_TEXT_ROW(b_vungId), a_cot_ct = GridX_Fdt_cotGtri(b_grctId), a_tso = slide_Faobj_TUDEN(b_slideId);;
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang > 0) b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
            sdg.Fs_DG_NGV_KHDG_NH(form_Fs_nsd(), b_so_id, b_TrangKt, a_dt, a_cot_ct, a_tso, a_cot_lke, dg_ngv_khdg_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function dg_ngv_khdg_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = b_kq.split('#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        form_P_LOI("loi:Nhập thành công:loi");
    }
    b_fcho = 'X';
}
// Xóa
function dg_ngv_khdg_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa :loi"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    var b_nam_tk = lke_Fs_TRA($get(b_nam_tkId));
    var b_ky_dg_tk = lke_Fs_TRA($get(b_ky_dg_tkId));
    var b_hoten_tk = $get(b_hoten_tkId).value;
    if (b_so_id == "") dg_ngv_khdg_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_DG_NGV_KHDG_XOA(form_Fs_nsd(), b_so_id, b_nam_tk, b_ky_dg_tk, b_hoten_tk, a_tso, a_cot, dg_ngv_khdg_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function dg_ngv_khdg_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        GridX_datA(b_grlkeId, b_hang); dg_ngv_khdg_P_CHUYEN_HANG();
        form_P_LOI("loi:Xóa thành công:loi");
    }
}
// Chuyển hàng
function dg_ngv_khdg_GR_lke_RowChange() {
    if (dg_ngv_khdg_choAct != 0) clearTimeout(dg_ngv_khdg_choAct);
    dg_ngv_khdg_choAct = setTimeout("dg_ngv_khdg_P_CHUYEN_HANG()", 300);
    return false;
}
function dg_ngv_khdg_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "0" || b_so_id == "") { form_P_MOI(b_vungId, "XGL"); GridX_datTrang(b_grctId); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        sdg.Fs_DG_NGV_KHDG_CT(form_Fs_nsd(), b_so_id, a_cot_ct, dg_ngv_khdg_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        $get(b_so_idId).value = b_so_id;
    }
    return false;
}
function dg_ngv_khdg_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        var a_kq = b_kq.split('#');
        form_P_MOI(b_vungId, "GXL");
        // drop_P_LKE(b_ky_dgId, a_kq[2]);
        form_P_CH_TEXT(b_vungId, a_kq[0]);
        if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
        return false;
    }
}
// Liệt kê
function dg_ngv_khdg_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (dg_ngv_khdg_lkeCho != 0) clearTimeout(dg_ngv_khdg_lkeCho);
        dg_ngv_khdg_lkeCho, dg_ngv_khdg_choAct = 0, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtkId = form_Fs_VUNG_ID('Upa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_grctId = form_Fs_VUNG_ID('GR_ct'),
        b_nam_tkId = form_Fs_TEN_ID(b_vungtkId, 'nam_tk'),
        b_ky_dg_tkId = form_Fs_TEN_ID(b_vungtkId, 'ky_dg_tk'),
         b_hoten_tkId = form_Fs_TEN_ID(b_vungtkId, 'hoten_tk'),
        b_namId = form_Fs_TEN_ID(b_vungId, 'nam'),
        //b_cdanhId = form_Fs_TEN_ID(b_vungId, 'CDANH'),
        b_ky_dgId = form_Fs_TEN_ID(b_vungId, 'ky_dg'),
        //b_hoten_Id = form_Fs_TEN_ID(b_vungId, 'hoten'),
            b_ngay_c_Id = form_Fs_TEN_ID(b_vungId, 'ngay_c'),
            b_ngay_d_Id = form_Fs_TEN_ID(b_vungId, 'ngay_d'),
        b_makh_Id = form_Fs_TEN_ID(b_vungId, 'ma_kh'),
        b_tongdiem5 = form_Fs_TEN_ID(b_vungId, 'tong_diem5'),
         b_tongdiem4 = form_Fs_TEN_ID(b_vungId, 'tong_diem4'),
         b_tongdiem3 = form_Fs_TEN_ID(b_vungId, 'tong_diem3'),
         b_tongdiem2 = form_Fs_TEN_ID(b_vungId, 'tong_diem2'),
         b_tongdiem1 = form_Fs_TEN_ID(b_vungId, 'tong_diem1'),
        b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        dg_ngv_khdg_P_LKE('K');
    }
}
function dg_ngv_khdg_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var b_nam_tk = lke_Fs_TRA($get(b_nam_tkId));
        var b_ky_dg_tk = lke_Fs_TRA($get(b_ky_dg_tkId));
        var b_hoten_tk = $get(b_hoten_tkId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_DG_NGV_KHDG_LKE(form_Fs_nsd(), b_nam_tk, b_ky_dg_tk, b_hoten_tk, a_tso, a_cot, dg_ngv_khdg_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function dg_ngv_khdg_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}
function dg_ngv_khdg_P_NAM() {
    try {
        var b_nam = lke_Fs_TRA($get(b_namId));
        var ktra = "DT_KY_DG";
        sdg.Fdt_NS_DG_MA_KDG_NHL(window.name, b_nam, ktra, dg_ngv_khdg_P_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(err); }
}
function dg_ngv_khdg_P_NAM_TK() {
    try {
        var ktra = "DT_KY_DG_TK";
        var b_nam_tk = form_Fs_TEN_GTRI(b_vungtkId, 'nam_tk');
        sdg.Fdt_NS_DG_MA_KDG_NHL(window.name, b_nam_tk, ktra, dg_ngv_khdg_P_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(err); }
}
//lấy thông tin cán bộ theo chức danh
function dg_ngv_khdg_P_CDANH() {
    try {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        var b_ky_dg = lke_Fs_TRA($get(b_ky_dgId));
        var b_cdanh = lke_Fs_TRA(b_cdanhId);
        var ktra = "DT_HOTEN";
        sdg.Fdt_DG_NGV_TTCB(window.name, "", b_ky_dg, b_cdanh, ktra, dg_ngv_khdg_P_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        sdg.Fs_DG_NGV_DS_CAUHOI_LKE(form_Fs_nsd(), b_ky_dg, b_cdanh, a_cot_ct, dg_ngv_khdg_P_LKE_DS_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
// lấy thông tin cán bộ + bộ câu hỏi theo kỳ đánh giá
function dg_ngv_khdg_P_KY_DG() {
    try {

        //var ktra = "DT_HOTEN";
        //sdg.Fdt_DG_NGV_KHDG_TTCB(window.name, b_ky_dg, ktra, dg_ngv_khdg_P_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        $get(b_cdanhId).value = "";
        var b_ky_dg = lke_Fs_TRA($get(b_ky_dgId));
        var ktra = "DT_CDANH";
        sdg.Fdt_DG_NGV_CDANH(window.name, "", b_ky_dg, ktra, dg_ngv_khdg_P_KQ, P_LOI_CSDL, P_LOI_TGIAN);

    }
    catch (err) { form_P_LOI(err); }
}
function dg_ngv_khdg_P_LKE_DS_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        var a_kq = b_kq.split('#');
        form_P_MOI(b_vungId, "XL");
        form_P_CH_TEXT(b_vungId, a_kq[0]);
        if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
        return false;
    }
}
function dg_ngv_khdg_P_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_kdgId = form_Fs_TEN_ID(b_vungId, 'ky_dg');
        drop_P_LKE(b_kdgId, b_kq);
    }
}

//Lấy từ ngày đến ngày đánh giá
function dg_ngv_khdg_P_laynam() {
    try {
        var b_ky_dg = lke_Fs_TRA($get(b_ky_dgId));
        stl_cc.Fs_CC_LAY_NAM(form_Fs_nsd(), b_ky_dg, dg_ngv_khdg_P_laynam_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function dg_ngv_khdg_P_laynam_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '|');
    $get(b_ngay_d_Id).value = a_kq[11];
    $get(b_ngay_c_Id).value = a_kq[12];
    //form_P_CH_TEXT(b_vungId, b_kq);

    return false;
}
//Lấy chức danh theo nhân viên
//function dg_ngv_khdg_P_HOTEN() {
//    try {
//        var b_manv = lke_Fs_TRA($get(b_hoten_Id)); 
//        sdg.Fdt_DG_NGV_KHDG_CDANH(b_manv, dg_ngv_khdg_P_HOTEN_KQ, P_LOI_CSDL, P_LOI_TGIAN);
//    } catch (err) { form_P_LOI(err); }
//}

// lấy thông tin cán bộ nhân viên
function ns_thongtin_canbo(b_so_the, b_loai) {
    try {
        if (b_so_the == null) b_so_the = $get(b_gocId).value;
        var b_listcotcu = "", b_listcotmoi = "";
        if (b_loai == "SO_THE") { b_kt_loai = "SO_THE"; b_listcotcu = "SO_THE,HO_TEN,CDANH,TEN_CDANH,PHONG,TEN_PHONG,TEN_VITRI,VITRI", b_listcotmoi = "SO_THE,HO_TEN,CDANH,TEN_CDANH,PHONG,TEN_PHONG,TEN_VITRI,VITRI" }
        else if (b_loai == "MA_NGUOIKY") { b_kt_loai = "MA_NGUOIKY"; b_listcotcu = "SO_THE,TEN_CDANH", b_listcotmoi = "MA_NGUOIKY,TEN_CDANH_NGUOIKY" }
        else { b_kt_loai = ""; b_listcotcu = "SO_THE,HO_TEN,TEN_CDANH,TEN_PHONG", b_listcotmoi = "SO_THE,HO_TEN,TEN_CDANH,TEN_PHONG" }
        hts_dungchung.Fs_THONGTIN_CANBO_HD(b_so_the, b_listcotcu, b_listcotmoi, ns_thongtin_canbo_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_thongtin_canbo_kq(b_kq) {
    if (b_kq == "") {
        if (b_kt_loai == "SO_THE" || b_kt_loai == "") {
            form_P_MOI(b_vungId, "GXL"); $get(b_gocId).focus(); form_P_LOI(b_kq); return false;
        } else if (b_kt_loai == "MA_NGUOIKY") {
            $get(b_ma_nguoikyId).value = ""; $get(b_ten_cdanhnkId).value = "";
        }
    }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
function dg_ngv_khdg_P_HOTEN_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = b_kq.split('#');
        lke_P_DAT($get(b_cdanhId), a_kq[0] + '{' + a_kq[1]);
    }
}
function dg_ngv_khdg_P_MA_KH() {
    try {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        var b_cdanh = lke_Fs_TRA(b_cdanhId);
        var b_manv = lke_Fs_TRA($get(b_hoten_Id));
        var b_makh = $get(b_makh_Id).value;
        var b_ky_dg = lke_Fs_TRA($get(b_ky_dgId));
        sdg.Fs_DG_NGV_KHDG_DIEM_LKE(form_Fs_nsd(), b_manv, b_makh, b_ky_dg, b_cdanh, a_cot_ct, dg_ngv_khdg_P_MA_KH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function dg_ngv_khdg_P_MA_KH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        //  var a_kq = b_kq.split('#'); 
        form_P_CH_TEXT(b_vungId, b_kq);
        if (b_kq == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, b_kq);
        return false;
    }
}
var tong_diem5 = 0, tong_diem4 = 0, tong_diem3 = 0, tong_diem2 = 0, tong_diem1 = 0;
function tinhtong(b_event) {
    GridX_sott(b_grctId, 'stt');
    var b_hang = GridX_Fi_timHangA(b_grctId);
    var b_ctr = form_Fctr_event(b_event);
    var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
    if (b_value != "") {
        if (b_cot == "DIEM5") {
            GridX_datGtri(b_grctId, b_hang, ["diem4"], [""], 'K');
            GridX_datGtri(b_grctId, b_hang, ["diem3"], [''], 'K');
            GridX_datGtri(b_grctId, b_hang, ["diem2"], [''], 'K');
            GridX_datGtri(b_grctId, b_hang, ["diem1"], [''], 'K');
        } else if (b_cot == "DIEM4") {
            GridX_datGtri(b_grctId, b_hang, ["diem5"], [""], 'K');
            GridX_datGtri(b_grctId, b_hang, ["diem3"], [''], 'K');
            GridX_datGtri(b_grctId, b_hang, ["diem2"], [''], 'K');
            GridX_datGtri(b_grctId, b_hang, ["diem1"], [''], 'K');
        } else if (b_cot == "DIEM3") {
            GridX_datGtri(b_grctId, b_hang, ["diem5"], [""], 'K');
            GridX_datGtri(b_grctId, b_hang, ["diem4"], [""], 'K');
            GridX_datGtri(b_grctId, b_hang, ["diem2"], [''], 'K');
            GridX_datGtri(b_grctId, b_hang, ["diem1"], [''], 'K');
        } else if (b_cot == "DIEM2") {
            GridX_datGtri(b_grctId, b_hang, ["diem5"], [""], 'K');
            GridX_datGtri(b_grctId, b_hang, ["diem4"], [""], 'K');
            GridX_datGtri(b_grctId, b_hang, ["diem3"], [''], 'K');
            GridX_datGtri(b_grctId, b_hang, ["diem1"], [''], 'K');
        } else if (b_cot == "DIEM1") {
            GridX_datGtri(b_grctId, b_hang, ["diem5"], [""], 'K');
            GridX_datGtri(b_grctId, b_hang, ["diem4"], [""], 'K');
            GridX_datGtri(b_grctId, b_hang, ["diem3"], [''], 'K');
            GridX_datGtri(b_grctId, b_hang, ["diem2"], [''], 'K');
        }
    }

    a_cot_ct = GridX_Fdt_cotGtri(b_grctId);
    var x;
    var tong = 0
    for (var i = 0; i < 10; i++) {
        var x = a_cot_ct[1][i][4];
        if (x == "X") {
            tong_diem5 = tong_diem5 + 1;
        }
        var x = a_cot_ct[1][i][5];
        if (x == "X") {
            tong_diem4 = tong_diem4 + 1;
        }
        var x = a_cot_ct[1][i][6];
        if (x == "X") {
            tong_diem3 = tong_diem3 + 1;
        }
        var x = a_cot_ct[1][i][7];
        if (x == "X") {
            tong_diem2 = tong_diem2 + 1;
        }
        var x = a_cot_ct[1][i][8];
        if (x == "X") {
            tong_diem1 = tong_diem1 + 1;
        }
    }
    $get(b_tongdiem5).value = tong_diem5;
    $get(b_tongdiem4).value = tong_diem4;
    $get(b_tongdiem3).value = tong_diem3;
    $get(b_tongdiem2).value = tong_diem2;
    $get(b_tongdiem1).value = tong_diem1;
    tong_diem5 = 0; tong_diem4 = 0; tong_diem3 = 0; tong_diem2 = 0; tong_diem1 = 0;
    return false;
}
function form_dong() {
    location.reload(false);
}