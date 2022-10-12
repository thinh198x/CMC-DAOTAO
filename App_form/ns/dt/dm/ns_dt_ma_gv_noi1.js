var ns_dt_ma_gv_noi_lkeCho = 0, ns_dt_ma_gv_noi_choAct = 0, b_vungId, b_grlkeId, b_slideId, b_gchuId, b_gocId, b_tenId, b_cdanhId, b_dviId,
    b_ngsinhId, b_ngv_ctyId, b_dthoaiId, b_loai_gvienId, b_cap_gvienId, b_knghiemId, b_email_ctyId, b_email_cnhanId, b_trangthaiId, b_lv_chaId,
    b_kdtaoId, b_tt_tkId, b_cap_gvien_tkId, b_loai_gvien_tkId, b_vungtk, b_tt_anId, b_lgv_anId, b_cgv_anId;
function ns_dt_ma_gv_noi_P_KD() {
    ns_dt_ma_gv_noi_lkeCho = setInterval('ns_dt_ma_gv_noi_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
            if (a_tso[0] == 'FILE_HTOAN') {
            }
        }
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            ns_thongtin_canbo(a_tso[0], 'SO_THE');
            var b_ma = a_tso[0];
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "so_the", b_ma);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_dt_ma_gv_noi_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_dt_ma_gv_noi_P_CHUYEN_HANG(); }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ma_gv_noi_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_dt_ma_gv_noi_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_thongtin_canbo($get(b_gocId).value, 'SO_THE');
            $get(b_gocId).value = b_ma.value.validate_Ma();
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "so_the", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_dt_ma_gv_noi_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_dt_ma_gv_noi_P_CHUYEN_HANG(); }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ma_gv_noi_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}
function ns_dt_ma_gv_noi_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            var a_tk = form_Faa_TEXT_ROW(b_vungtk);
            sns_dt.Fs_NS_DT_MA_GV_NOI_MA(a_tk,b_ma, b_TrangKt, a_cot, ns_dt_ma_gv_noi_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ma_gv_noi_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_dt_ma_gv_noi_P_CHUYEN_HANG(); }
}
function ns_dt_ma_gv_noi_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}
function ns_dt_ma_gv_noi_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_gocId).focus();
    return false;
}
function ns_dt_ma_gv_noi_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            if (ktra_ktdb(C_NVL(form_Fs_TEN_GTRI(b_vungId, 'TEN')))) { form_P_LOI("loi:Đối tượng không được chứa ký tự đặc biệt:loi"); return false; }
            var b_hang = GridX_Fi_timHangA(b_grlkeId); if (b_hang < 1) b_hang = -1;
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var b_ma = $get(b_gocId).value;
            var a_tk = form_Faa_TEXT_ROW(b_vungtk);
            sns_dt.Fs_NS_DT_MA_GV_NOI_NH(a_tk,b_ma, b_TrangKt, a_dt_ct, a_cot_lke, ns_dt_ma_gv_noi_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_dt_ma_gv_noi_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI("Ghi thành công!");
    }
    return false;
}
function ns_dt_ma_gv_noi_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the"));
    if (b_ma == "") ns_dt_ma_gv_noi_P_MOI();
    else {
        var a_tk = form_Faa_TEXT_ROW(b_vungtk);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.Fs_NS_DT_MA_GV_NOI_XOA(a_tk,b_ma, a_tso, a_cot, ns_dt_ma_gv_noi_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_dt_ma_gv_noi_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dt_ma_gv_noi_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dt_ma_gv_noi_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi"); 
    }
}
function ns_dt_ma_gv_noi_GR_lke_RowChange() {
    if (ns_dt_ma_gv_noi_choAct != 0) clearTimeout(ns_dt_ma_gv_noi_choAct);
    ns_dt_ma_gv_noi_choAct = setTimeout("ns_dt_ma_gv_noi_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_dt_ma_gv_noi_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the"));
    if (b_ma == "") form_P_MOI(b_vungId, "GLX");
    else {
        ns_thongtin_canbo(b_ma, 'SO_THE');
        sns_dt.Fs_NS_DT_MA_GV_NOI_CT(window.name,b_ma, ns_dt_ma_gv_noi_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function ns_dt_ma_gv_noi_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    var b_so_the =$get(b_gocId).value;
    ns_thongtin_canbo(b_so_the, 'SO_THE');
}
function ns_dt_ma_gv_noi_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_vungtk = form_Fs_VUNG_ID('Upa_tk');
        b_gchuId = form_Fs_VTEN_ID('', 'gchu');
        b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE');
        b_tenId = form_Fs_TEN_ID(b_vungId, 'HO_TEN');  
        b_kdtaoId = form_Fs_TEN_ID(b_vungId, 'kdtao');
        b_knghiemId = form_Fs_TEN_ID(b_vungId, 'knghiem');
        b_tt_tkId = form_Fs_TEN_ID(b_vungtk, 'tt_tk'); 
        b_tt_anId = form_Fs_TEN_ID(b_vungtk, 'tt_an');
        b_lgv_anId = form_Fs_TEN_ID(b_vungtk, 'lgv_an');
        b_cgv_anId = form_Fs_TEN_ID(b_vungtk, 'cgv_an');
        b_slideId = $get(b_grlkeId).getAttribute('slideId'); slide_P_MOI(b_slideId);
        clearTimeout(ns_dt_ma_gv_noi_lkeCho); ns_dt_ma_gv_noi_P_LKE();
    }
}
function ns_dt_ma_gv_noi_P_LKE() {
    try {
        //$get(b_tt_anId).value = list_Fs_IdTRA(b_tt_tkId);
        //$get(b_cgv_anId).value = list_Fs_IdTRA(b_cap_gvien_tkId);
        //$get(b_lgv_anId).value = list_Fs_IdTRA(b_loai_gvien_tkId);
        //var a_tk = form_Faa_TEXT_ROW(b_vungtk);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.Fs_NS_DT_MA_GV_NOI_LKE( a_tso, a_cot, ns_dt_ma_gv_noi_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ma_gv_noi_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_dt_ma_gv_noi_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function form_dong() {
    location.reload(false);
}
function ns_dt_ma_gv_noi_FI_NH() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1 || C_NVL(GridX_Fas_layGtriA(b_grlkeId, "so_the")) == "") {
            form_P_LOI('loi:Chọn giảng viên:loi')
            return false;
        }
        var b_tenf = '/App_form/ns/hs/file_hs.aspx';
        form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "NS_DT_MA_GV_NOI_IMP" + C_NVL(GridX_Fas_layGtriA(b_grlkeId, "so_the")), "NS_DT_MA_GV_NOI_IMP" + C_NVL(GridX_Fas_layGtriA(b_grlkeId, "so_the")), "Lưu file thông tin"]], null);
        form_P_LOI('');
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_thongtin_canbo(b_so_the, b_loai) {
    try {
        var b_listcotcu = "", b_listcotmoi = "";
        if (b_loai == "SO_THE") { b_listcotcu = "SO_THE,HO_TEN,TEN_CDANH,TEN_PHONG,EMAIL,EMAIL_CTY,NSINH,NGAY_VAO,NGAY_CT,DTDD,TEN_TTR", b_listcotmoi = "SO_THE,HO_TEN,TEN_CDANH,TEN_PHONG,EMAIL,EMAIL_CTY,NSINH,NGAY_VAO,NGAY_CT,DTHOAI,TEN_TTR" }
        hts_dungchung.Fs_THONGTIN_CANBO_HD(b_so_the, b_listcotcu, b_listcotmoi, ns_thongtin_canbo_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_thongtin_canbo_kq(b_kq) {
    if (b_kq == "") { form_P_LOI(b_kq); return false; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}