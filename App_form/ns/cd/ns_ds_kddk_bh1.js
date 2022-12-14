
var NS_DS_KDDK_BH_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_ctrbeforId, b_aphongId, b_ctyValue, b_sothe_tkId, b_kyluongId, b_namId,
    b_thangkhai, b_tenId, b_tinhtrangId, NS_DS_KDDK_BH_choAct = 0, b_chon_allId, b_vungHi, b_akyId,
b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C';
function NS_DS_KDDK_BH_P_KD() {
    NS_DS_KDDK_BH_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_tenId = form_Fs_TEN_ID(b_vungId, 'ten');
    b_sothe_tkId = form_Fs_TEN_ID(b_vungId, 'so_the_tk'); b_kyluongId = form_Fs_TEN_ID(b_vungId, 'kyluong_tk'); b_namId = form_Fs_TEN_ID(b_vungId, 'nam_tk');
    b_slideId = b_grlkeId + '_slide'; b_chon_allId = form_Fs_VTEN_ID('UPa_hi', 'acheckall');
    b_akyId = form_Fs_TEN_ID('UPa_hi', 'aky');
    NS_DS_KDDK_BH_lkeCho = setInterval('NS_DS_KDDK_BH_P_LKE_CHO()', 200);
}
// Kiểm tra
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[0];
    }
    catch (err) { form_P_LOI(err); }
}
function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}
function NS_DS_KDDK_BH_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
            case "SO_THE": b_maId = b_sothe_tkId; break;
            case "THANG_BD": b_maId = b_gocId; break;
            case "HOTEN": b_maId = b_tenId; break;
            case "KYLUONG": b_maId = b_kyluongId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); NS_DS_KDDK_BH_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); NS_DS_KDDK_BH_P_CHUYEN_HANG(); }
            b_ten.focus();
        } else if (b_maTen == 'SO_THE') {
            NS_DS_KDDK_BH_P_LKE('K');
        } else if (b_maTen == 'KYLUONG') {
            $get(b_akyId).value = lke_Fs_TRA($get(b_kyluongId));
        }
    }
    catch (err) { form_P_LOI(err); }
}
function NS_DS_KDDK_BH_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_cd.Fs_NS_DS_KDDK_BH_MA(b_ma, b_TrangKt, a_cot, NS_DS_KDDK_BH_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function NS_DS_KDDK_BH_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); NS_DS_KDDK_BH_P_CHUYEN_HANG(); }
}
// Nhập
function NS_DS_KDDK_BH_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    $get(b_gocId).focus();
    return false;
}
function NS_DS_KDDK_BH_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        else {
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_dt_grid = GridX_Fdt_cotGtri(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            var b_ten = $get(b_tenId).value;
            var b_so_the = $get(b_sothe_tkId).value; var b_nam = lke_Fs_TRA($get(b_namId)), b_kyluong = lke_Fs_TRA($get(b_kyluongId));
            sns_cd.Fs_NS_DS_KDBHXH_NH(b_so_the, b_ten, b_nam, b_kyluong, b_TrangKt, a_tso, a_dt_ct, a_cot, b_dt_grid, NS_DS_KDDK_BH_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function NS_DS_KDDK_BH_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1;
        //slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[1]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        //$get(b_so_idHi).value = a_kq[4];
        form_P_LOI("loi:Ghi thành công!:loi");
    }
    return false;
}
// Xóa
function NS_DS_KDDK_BH_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) {
        alert("Bạn chưa chọn khai báo cần hủy");
        return false
    };
    var b_tinhtrang = form_Fs_TEN_GTRI(b_vungId, 'tinhtrang');
    if (b_tinhtrang == 1) {
        NS_DS_KDDK_BH_P_XOA_KQ("loi: Cán bộ đang ở tình trạng đã phê duyệt, bạn không thể hủy :loi");
        return false;
    }
    var retVal = confirm("Bạn chắc chắn muốn hủy ?");

    if (retVal == false) {
        form_P_LOI("");
        return false;
    }
    var b_thangbd = $get(b_gocId).value;
    var b_ten = $get(b_tenId).value;
    var b_phong = b_ctyValue;
    var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId), b_dt_grid = GridX_Fdt_cotGtri(b_grlkeId);
    sns_cd.Fs_NS_DS_KDDK_BH_XOA(b_phong,b_thangbd, b_ten, b_tinhtrang, b_dt_grid, a_tso, a_cot, NS_DS_KDDK_BH_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);

    return false;
}
function NS_DS_KDDK_BH_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) NS_DS_KDDK_BH_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); NS_DS_KDDK_BH_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Không phê duyệt thành công:loi");
    }
}
// Chuyển hàng
function NS_DS_KDDK_BH_GR_lke_RowChange() {
    if (NS_DS_KDDK_BH_choAct != 0) clearTimeout(NS_DS_KDDK_BH_choAct);
    NS_DS_KDDK_BH_choAct = setTimeout("NS_DS_KDDK_BH_P_CHUYEN_HANG()", 300);
    return false;
}
function NS_DS_KDDK_BH_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        if (b_ma == "") form_P_MOI(b_vungId, "XGL"); else form_P_GridX_TEXT(b_vungId, b_grlkeId);
    }
    catch (err) { form_P_LOI(err); }
}
// Liệt kê
function NS_DS_KDDK_BH_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (NS_DS_KDDK_BH_lkeCho != 0) clearTimeout(NS_DS_KDDK_BH_lkeCho);
        b_aphongId = form_Fs_TEN_ID('UPa_hi', 'aphong'),
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        form_F_GOC().P_MENUBf(window.name, 'M');
        vb_cctc_P_SL('', 'D', '0', ' ', ' ', 'T');
        b_ctyValue = "TATCA";
        NS_DS_KDDK_BH_P_LKE('K');
        NS_DS_KDDK_BH_CT_KYLUONG();
    }
}
function NS_DS_KDDK_BH_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_ten = $get(b_tenId).value; var b_so_the = $get(b_sothe_tkId).value; var b_nam = lke_Fs_TRA($get(b_namId)), b_kyluong = lke_Fs_TRA($get(b_kyluongId));
        sns_cd.Fs_NS_DS_KDBHXH_LKE(b_so_the, b_ten,b_nam,b_kyluong, a_tso, a_cot, NS_DS_KDDK_BH_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function NS_DS_KDDK_BH_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    $get(b_akyId).value = lke_Fs_TRA($get(b_kyluongId));
    b_fcho = 'X';
}

function vb_cctc_P_CLICK(b_event, b_id) {
    b_event.stopPropagation();
    var b_targetClassNam = b_event.target.className;
    if (b_targetClassNam == "ico_bptt") {
        var b_ctr = $get(b_id), b_div = $get(b_id + '_Div');
        var a_tso = Attribute_Fas_LAY(b_ctr, 'loai,cap,dvi,ma,ma_ct');
        if (b_ctrbeforId != null) b_ctrbeforId.style.fontWeight = "100";
        $get(b_aphongId).value = b_ctyValue;
        b_ctr.style.fontWeight = "700";
        b_ctrbeforId = b_ctr;
        b_ctyValue = a_tso[3];
        // load lại dữ liệu 
        $get(b_aphongId).value = b_ctyValue;
        if (b_ctyValue != "") NS_DS_KDDK_BH_P_LKE('K');
        return false;
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
function form_dong() {
    location.reload(false);
}

function CheckAll(oCheckbox) {
    var b_count = GridX_Fi_timHangT(b_grlkeId);
    if (oCheckbox.checked == true) {
        $get(b_chon_allId).value = 'TATCA';
        for (i = 1; i < b_count; i++) {
            var b_so_the = C_NVL(GridX_Fas_layGtri(b_grlkeId, i, "so_the"));
            if (b_so_the != "") GridX_datGtri(b_grlkeId, i, ["chon"], ['X'], 'K');
        }
    } else {
        for (i = 1; i < b_count; i++) {
            GridX_datGtri(b_grlkeId, i, ["chon"], [''], 'K');
        }
    }
}
function NS_DS_KDDK_BH_P_NAM() {
    try {
        var b_nam = form_Fs_TEN_GTRI(b_vungId, 'nam_tk');
        if (b_nam != "")
            stl_cc.Fs_NS_KYLUONG_CHUNG2_LKE(form_Fs_nsd(), window.name, b_nam, NS_DS_KDDK_BH_P_NAM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function NS_DS_KDDK_BH_P_NAM_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        NS_DS_KDDK_BH_P_KTRA("KYLUONG");
    }
}
function NS_DS_KDDK_BH_CT_KYLUONG() {
    try {
        var b_form = "ns_ds_kddk_bh", b_nam = "DT_NAM", b_thang = "DT_KY";
        hts_dungchung.Fs_NS_CC_KY(form_Fs_nsd(), b_form, b_nam, b_thang, NS_DS_KDDK_BH_CT_KYLUONG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function NS_DS_KDDK_BH_CT_KYLUONG_KQ(b_kq) {
    if (b_kq != "") {
        form_P_CH_TEXT(b_vungTkId, b_kq);
    }
    //ns_cc_thongtin_nghi_P_LKE('K');
}