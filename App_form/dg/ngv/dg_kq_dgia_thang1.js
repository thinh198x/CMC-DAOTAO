var dg_kq_dgia_thang_lkeCho, b_vungId, b_so_theId, b_ten_Id, b_phong_Id, b_grlkeId, b_slideId, b_nsd, b_phong, b_ky_an, b_phong_anId,
    b_ky_dg_Id, b_nam_Id, b_phong_Id, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C';
function dg_kq_dgia_thang_P_KD() {
    b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
    b_ky_dg_Id = form_Fs_TEN_ID(b_vungId, 'KY_DG'), b_nam_Id = form_Fs_TEN_ID(b_vungId, 'nam'), b_phong_Id = form_Fs_TEN_ID(b_vungId, 'phongban');
    b_slideId = $get(b_grlkeId).getAttribute('slideId');
    b_ky_an = form_Fs_TEN_ID('UPa_hi', 'an_kydg'); b_phong_an = form_Fs_TEN_ID('UPa_hi', 'an_phong');
    b_nsd = form_Fs_nsd();
    dg_kq_dgia_thang_choAct = 0;
    dg_kq_dgia_thang_lkeCho = setInterval('dg_kq_dgia_thang_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("DAYPHONG") >= 0) {
            var b_phong_tk = form_Fctr_TEN_DTUONG(b_vungId, 'phong');
            lke_P_DAT(b_phong_tk, a_tso[0] + "{" + a_tso[1]);
        } else if (b_dtuong.indexOf("SO_THE") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang < 0) return;
            dgia_thang_P_TTCB(b_kq);
        } else if (b_dtuong.indexOf("TAI_IMPORT") >= 0) {
            dg_kq_dgia_thang_P_LKE();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}
function dg_kq_dgia_thang_P_KTRA(b_maTen) {
    try {
        if (b_maTen == "KY_DG") {
            $get(b_ky_an).value = lke_Fs_TRA($get(b_ky_dg_Id));
            dg_kq_dgia_thang_P_LKE('K');
        }
        if (b_maTen == "NAM") {
            var b_nam = lke_Fs_TRA(b_nam_Id);
            sdg.Fdt_NS_DG_MA_KDG_DG_NHL(window.name, b_nam, "DT_KY_DG", dgia_thang_P_KTRA_DR_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            dg_kq_dgia_thang_P_LKE('K');
        }
        if (b_maTen == "PHONG") {
            $get(b_phong_an).value = lke_Fs_TRA($get(b_phong_Id));
            dg_kq_dgia_thang_P_LKE('K');
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function dgia_thang_P_KTRA_DR_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        drop_P_LKE(b_ky_dg_Id, b_kq);
    }
    return false;
}
// Lấy thông tin cán bộ nhân viên
function dgia_thang_P_TTCB(b_so_the) {
    try {
        hts_dungchung.Fs_THONGTIN_CANBO_LUOI(b_so_the, dgia_thang_P_TTCB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function dgia_thang_P_TTCB_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 0) return;
    GridX_datGtri(b_grlkeId, b_hang, ["so_the"], a_kq[1], 'K');
    GridX_datGtri(b_grlkeId, b_hang, ["ho_ten"], a_kq[2], 'K');
    GridX_datGtri(b_grlkeId, b_hang, ["ten_cdanh"], a_kq[3], 'K');
    GridX_datGtri(b_grlkeId, b_hang, ["cdanh"], a_kq[10], 'K');
    GridX_datGtri(b_grlkeId, b_hang, ["phong"], a_kq[5], 'K');
    GridX_datGtri(b_grlkeId, b_hang, ["ten_phong"], a_kq[6], 'K');
    return false;
}
// Nhập
function dg_kq_dgia_thang_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var a_dt = form_Faa_TEXT_ROW(b_vungId), a_dt_ct = GridX_Fdt_cotGtri(b_grlkeId);
        var b_nam = lke_Fs_TRA(b_nam_Id), b_ky_dg = lke_Fs_TRA(b_ky_dg_Id), b_phong = lke_Fs_TRA(b_phong_Id);
        sdg.Fs_DG_KQ_DGIA_THANG_NH(form_Fs_nsd(), b_nam, b_ky_dg, b_phong, a_dt, a_dt_ct, a_tso, a_cot, dg_kq_dgia_thang_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
}
function dg_kq_dgia_thang_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        form_P_LOI("loi:Ghi thành công:loi");
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}
// Liệt Kê
function dg_kq_dgia_thang_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (dg_kq_dgia_thang_lkeCho != 0) clearTimeout(dg_kq_dgia_thang_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        dg_kq_dgia_thang_P_LKE('K');
    }
}
function dg_kq_dgia_thang_P_LKE(b_dk) {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_nam = lke_Fs_TRA(b_nam_Id), b_ky_dg = lke_Fs_TRA(b_ky_dg_Id), b_phong = lke_Fs_TRA(b_phong_Id);
        sdg.Fs_DG_KQ_DGIA_THANG_LKE(form_Fs_nsd(), b_nam, b_ky_dg, b_phong, a_tso, a_cot, dg_kq_dgia_thang_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);

        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function dg_kq_dgia_thang_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        anhien_controll();
    }
    b_fcho = 'X';
}
// Tổng hợp
function dg_kq_dgia_thang_P_TONGHOP() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    else {
        if (lke_Fs_TRA($get(b_ky_dg_Id)) == "") { form_P_LOI("loi:Phải nhập kỳ đánh giá:loi"); return false; }
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_nam = lke_Fs_TRA($get(b_nam_Id)), b_ky_dg = lke_Fs_TRA($get(b_ky_dg_Id)), b_phong = lke_Fs_TRA($get(b_phong_Id));
        sdg.Fs_DG_KQ_DGIA_THANG_TONGHOP(form_Fs_nsd(), b_nam, b_ky_dg, b_phong, a_tso, a_cot, dg_kq_dgia_thang_P_TONGHOP_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
}
function dg_kq_dgia_thang_P_TONGHOP_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        form_P_LOI("loi:Tổng hợp thành công!:loi")
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        anhien_controll();
    }
    b_fcho = 'X';
}
// Xác nhận
function dg_kq_dgia_thang_P_XACNHAN(b_dk) {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    else {
        var a_dt = form_Faa_TEXT_ROW(b_vungId);
        var b_dt = GridX_Fdt_cotGtri(b_grlkeId);
        sdg.Fs_DG_KQ_DGIA_THANG_XACNHAN(form_Fs_nsd(), a_dt, b_dt, b_dk, dg_kq_dgia_thang_P_XACNHAN_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
}
function dg_kq_dgia_thang_P_XACNHAN_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI("loi:Xác nhận thành công:loi");
        dg_kq_dgia_thang_P_LKE('TK')
    }
    return false;
}

function dg_kq_dgia_thang_HangLen() {
    GridX_chuyenHang(b_grlkeId, -1);
    return false;
}
function dg_kq_dgia_thang_HangXuong() {
    GridX_chuyenHang(b_grlkeId, 1);
    return false;
}
function dg_kq_dgia_thang_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grlkeId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grlkeId);
    return false;
}
function dg_kq_dgia_thang_CatDong() {
    GridX_boChon(b_grlkeId, 'C');
    return false;
}

function anhien_controll() {
    var length = GridX_Fi_hangSo(b_grlkeId)
    for (var i1 = 0; i1 < length; i1++) {
        var a_cell = $get(b_grlkeId).rows[i1 + 1].cells, a_ctr, b_icot = 0, b_cot = '';
        for (var i = 1; i < a_cell.length - 1; i++) {
            a_ctr = a_cell[i].getElementsByTagName('input');
            if (a_ctr == null || a_ctr.length < 1) a_ctr = a_cell[i].getElementsByTagName('select');
            if (a_ctr.length > 0) {
                a_ctr[0].disabled = false;
                if (C_NVL(GridX_Fas_layGtri(b_grlkeId, i1 + 1, 'dl_cttns')) == 'X') {
                    if (i > 1) a_ctr[0].disabled = true;
                    if (C_NVL(GridX_Fas_layGtri(b_grlkeId, i1 + 1, 'xacnhan')) == 'X')
                        if (i == 1) a_ctr[0].disabled = true;
                }
                if (C_NVL(GridX_Fas_layGtri(b_grlkeId, i1 + 1, 'xacnhan')) == 'X' && C_NVL(GridX_Fas_layGtri(b_grlkeId, i1 + 1, 'dl_cttns')) != 'X')
                    a_ctr[0].disabled = true;
            }
        }
    }
}
function dg_kq_dgia_DS_CHUA_DG() {
    var b_nam = lke_Fs_TRA(b_nam_Id), b_ky_dg = lke_Fs_TRA(b_ky_dg_Id);
    if (b_nam == "") { form_P_LOI("loi:Phải nhập năm đánh giá:loi"); return false; }
    if (b_ky_dg == "") { form_P_LOI("loi:Phải nhập kỳ đánh giá:loi"); return false; }

    var b_btn_excel = form_Fs_VTEN_ID('', 'ds_cdg');
    $get(b_btn_excel).click(); form_chay = 0;
    form_P_LOI('');
    return false;
}
function dg_kq_dgia_LAY_FILE_MAU() {
    var b_nam = lke_Fs_TRA(b_nam_Id), b_ky_dg = lke_Fs_TRA(b_ky_dg_Id);
    if (b_nam == "") { form_P_LOI("loi:Phải nhập năm đánh giá:loi"); return false; }
    if (b_ky_dg == "") { form_P_LOI("loi:Phải nhập kỳ đánh giá:loi"); return false; }

    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    form_P_LOI('');
    return false;
}
function dg_kq_dgia_thang_P_Excel() {//import từ file Excel
    var b_nam = lke_Fs_TRA(b_nam_Id), b_ky_dg = lke_Fs_TRA(b_ky_dg_Id);
    if (b_nam == "" || b_ky_dg == "") {
        form_P_LOI("loi:Phải nhập năm và kỳ đánh giá:loi"); return false;
    }
    var b_tenf = '/App_form/ns/ma/file_Import.aspx';
    form_P_MO(b_tenf, window.name + ',THAMSO', ['THAMSO', [window.name, 'DG_KQ_DGIA_THANG', null, "Import đánh giá công việc tháng"]], null);
    form_P_LOI('');
    return false;
}
function form_dong() {
    location.reload(false);
}
