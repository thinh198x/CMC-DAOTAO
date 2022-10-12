
var hdns_mota_cv_lkeCho, hdns_mota_cv_choAct = 0, hdns_mota_cv_choAct = 0, b_cho_control = 0, b_vungId, b_grlkeId,
    b_grnvId, b_ma_cdId, b_slideId, b_loi_id, b_mt, b_so_idId, b_gchuId, b_thangId, b_doi = 0, b_ncdId, b_ncd2Id,
    b_bao_cao_choId, b_quan_he_trong_Id, b_ma_nguoi_st, b_ma_nguoi_pd, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C', b_mucdich_Id;
function hdns_mota_cv_P_KD() {
    hdns_mota_cv_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'),
        b_grnvId = form_Fs_VUNG_ID('GR_nv'),
        b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_ma_cdId = form_Fs_TEN_ID(b_vungId, 'cdanh');
    b_bao_cao_choId = form_Fs_TEN_ID(b_vungId, 'baocao');
    b_ma_nguoi_st = form_Fs_TEN_ID(b_vungId, 'ma_nguoi_st');
    b_ma_nguoi_pd = form_Fs_TEN_ID(b_vungId, 'ma_nguoi_pd');
    b_quan_he_trong_Id = form_Fs_TEN_ID(b_vungId, 'qh_bentrong');
    b_mucdich_Id = form_Fs_TEN_ID(b_vungId, 'mucdich');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'); b_slideId = $get(b_grlkeId).getAttribute('slideId');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    hdns_mota_cv_lkeCho = setInterval('hdns_mota_cv_P_LKE_CHO()', 200);
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
            if (a_tso[0] == 'FILE_HTOAN') {
                hdns_mota_cv_P_LKE('K');
            }
        }
        else {
            b_dtuong = b_dtuong.toUpperCase();
            b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
            if (b_fcho == 'X') P_KET_QUA_KQ();
            else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
            var b_kq = a_tso[0];
            b_doi = 0;
            if (b_dtuong.toUpperCase().endsWith("CDANH") > 0) {
                $get(b_ma_cdId).value = a_tso[0];
                $get(b_gchuId).innerHTML = a_tso[1];

                b_hang = GridX_Fi_timHangD(b_grlkeId, "CDANH", $get(b_ma_cdId).value);
                if (b_hang < 1) { GridX_thoiA(b_grlkeId); }
                else { GridX_datA(b_grlkeId, b_hang); hdns_mota_cv_P_CHUYEN_HANG(); }

            }
            else if (b_dtuong.toUpperCase().endsWith("MA_NGUOI_ST") > 0) {
                $get(b_ma_nguoi_st).value = a_tso[0];
                $get(b_gchuId).innerHTML = a_tso[1];
                $get(form_Fs_TEN_ID(b_vungId, 'ten_ma_nguoi_st')).value = a_tso[1];
            }
            else if (b_dtuong.toUpperCase().endsWith("MA_NGUOI_PD") > 0) {
                $get(b_ma_nguoi_pd).value = a_tso[0];
                $get(form_Fs_TEN_ID(b_vungId, 'ten_ma_nguoi_pd')).value = a_tso[1];
                $get(b_gchuId).innerHTML = a_tso[1];
            }
            else if (b_dtuong.toUpperCase().endsWith("BAOCAO") > 0) {
                $get(b_bao_cao_choId).value = a_tso[0];
                $get(form_Fs_TEN_ID(b_vungId, 'ten_baocao')).value = a_tso[1];
                $get(b_gchuId).innerHTML = a_tso[1];
            }
            else if (b_dtuong.toUpperCase().endsWith("QH_BENTRONG") > 0) {
                $get(b_quan_he_trong_Id).value = a_tso[0];
                $get(form_Fs_TEN_ID(b_vungId, 'ten_qh_bentrong')).value = a_tso[1];
                $get(b_gchuId).innerHTML = a_tso[1];
            } else if (b_dtuong == "TAI_IMPORT") {
                hdns_mota_cv_P_LKE('K');
            }
        }
    }
    catch (err) { form_P_LOI(err); }
}

function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}

function hdns_mota_cv_P_KTRA(b_maTen) {
    try {
        var b_maId = "", b_ma = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "CDANH": b_maId = b_ma_cdId; b_ma = form_Fs_TEN_GTRI(b_vungId, 'CDANH'); break;
            case "NHOM_CD": b_maId = b_ma_cdId; b_ma = form_Fs_TEN_GTRI(b_vungId, 'NHOM_CD'); break;

        }

        if (C_NVL(b_ma) == "") {
            GridX_thoiA(b_grlkeId);
            return;
        }
        if (b_maTen == "NHOM_CD") {
            $get(b_ma_cdId).value = "";
            sns_ma_ch.Fs_NS_HDNS_MA_CD_BYNNN(window.name, b_ma);
        }
        else if (b_maTen == "CDANH") {
            var b_nnn = form_Fs_TEN_GTRI(b_vungId, 'NHOM_CD');
            hdns_mota_cv_P_MA(b_nnn, b_ma);
        }
    }
    catch (err) { form_P_LOI(err); }
}

function hdns_mota_cv_P_MA(b_nnn, b_cdanh) {
    var a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_mota_cv.Fs_NS_HDNS_MOTA_CV_MA(form_Fs_nsd(), b_nnn, b_cdanh, b_TrangKt, a_cot, hdns_mota_cv_P_MA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}

function hdns_mota_cv_P_MA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang > 0) { GridX_datA(b_grlkeId, b_hang); hdns_mota_cv_GR_lke_RowChange(); } else { hdns_mota_cv_XOA_P_MOI("X"); };
        $get(b_mucdich_Id).focus();
    }
    return false;
}

function hdns_mota_cv_GR_lke_RowChange() {
    if (hdns_mota_cv_choAct != 0) clearTimeout(hdns_mota_cv_choAct);
    hdns_mota_cv_choAct = setTimeout("hdns_mota_cv_P_CHUYEN_HANG()", 300);
    return false;
}

function hdns_mota_cv_P_LKE_CHO() {

    if (document.readyState == 'complete') {
        if (hdns_mota_cv_lkeCho != 0) clearTimeout(hdns_mota_cv_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        hdns_mota_cv_P_LKE('K');
    }
}

function hdns_mota_cv_P_MOI(b_ma) {
    $get(b_so_idId).value = 0;
    GridX_thoiA(b_grlkeId);
    hdns_mota_cv_XOA_P_MOI(b_ma);
    return false;
}
function hdns_mota_cv_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_mota_cv.Fs_NS_HDNS_MOTA_CV_LKE(form_Fs_nsd(), a_tso, a_cot, hdns_mota_cv_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function hdns_mota_cv_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    b_fcho = 'X';
}
function hdns_mota_cv_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var b_dt = form_Faa_TEXT_ROW(b_vungId),
            a_cot_nv = GridX_Fdt_cotGtri(b_grnvId), //, b_TrangKt = GridX_Fi_hangKt(b_grlkeId); //, a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
            b_so_id = CSO_SO($get(b_so_idId).value),
            a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);;
        sns_mota_cv.Fs_NS_HDNS_MOTA_CV_NH(form_Fs_nsd(), b_so_id, b_dt, a_cot_nv, b_TrangKt, a_cot, hdns_mota_cv_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function hdns_mota_cv_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        GridX_datBang(b_grlkeId, a_kq[3]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        if (b_hang > 0) { GridX_datA(b_grlkeId, b_hang); hdns_mota_cv_GR_lke_RowChange(); };
        form_P_LOI('loi:Nhập thành công:loi');
        $get(b_ma_cdId).focus();
    }
    return false;
}
function hdns_mota_cv_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_hang < 1) b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, 1, "so_id"));;
    //var b_nam = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "nam"));
    if (b_so_id == null || b_so_id == "") {
        form_P_MOI("", "XGL"); GridX_datTrang(b_grnvId);
        $get(b_so_idId).value = 0;
    }
    else {
        var a_cot_nv = GridX_Fas_tenCot(b_grnvId);
        sns_mota_cv.Fs_NS_HDNS_MOTA_CV_CT(form_Fs_nsd(), b_so_id, a_cot_nv, hdns_mota_cv_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function hdns_mota_cv_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grnvId); else GridX_datBang(b_grnvId, a_kq[1]);
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    $get(b_so_idId).value = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));

}
function hdns_mota_cv_P_XOA() {

    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) {
        form_P_LOI('loi:Bạn phải chọn một bản ghi để xóa:loi');
        return false;
    }

    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "") {
        hdns_mota_cv_XOA_P_MOI("XGL");
        form_P_LOI('loi:Bạn phải chọn một bản ghi để xóa:loi');
        return false;
    }
    else {
        var message = confirm("Bạn có chắc chắn xóa không?");
        if (message == false) {
            return false;
        }
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_mota_cv.Fs_NS_HDNS_MOTA_CV_XOA(form_Fs_nsd(), b_so_id, a_tso, a_cot, hdns_mota_cv_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}


function hdns_mota_cv_GR_lke_RowChange() {
    if (hdns_mota_cv_choAct != 0) clearTimeout(hdns_mota_cv_choAct);
    hdns_mota_cv_choAct = setTimeout("hdns_mota_cv_P_CHUYEN_HANG()", 300);
    return false;
}
function hdns_mota_cv_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) hdns_mota_cv_XOA_P_MOI("XGL");
        else { GridX_datA(b_grlkeId, b_hang); hdns_mota_cv_P_CHUYEN_HANG(); }
        //hdns_mota_cv_GR_lke_RowChange();
    }
}
function hdns_mota_cv_XOA_P_MOI(b_xoa) {
    form_P_MOI("", b_xoa); GridX_datTrang(b_grnvId);
    $get(b_so_idId).value = 0; $get(b_gchuId).innerHTML = '';
    return false;
}

function hdns_mota_cv_Export() {
    __doPostBack('ctl00$ContentPlaceHolder1$Nhap', '');
}

function hdns_mota_cv_Import() {
    var b_tenf = '/App_form/ns/ma/file_Import.aspx';
    form_P_MO(b_tenf, window.name + ',THAMSO', ['THAMSO', [window.name, 'hdns_mota_cv', null, "Import mô tả công việc"]], null);
    form_P_LOI('');
    return false;
}


function form_dong() {

    location.reload(false);
}

function hdns_mota_cv_HangLen() {
    GridX_chuyenHang(b_grnvId, -1);
    return false;
}
function hdns_mota_cv_HangXuong() {
    GridX_chuyenHang(b_grnvId, 1);
    return false;
}
function hdns_mota_cv_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grnvId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grnvId);
    return false;
}
function hdns_mota_cv_CatDong() {
    GridX_boChon(b_grnvId, 'C');
    return false;
}
