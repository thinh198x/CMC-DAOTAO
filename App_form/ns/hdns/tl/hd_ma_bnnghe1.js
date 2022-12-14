var hd_ma_bnnghe_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_ma_nnnghe_Id, b_ma_nnnghe_Ten, b_cap_bac, b_tenId, b_gchuId, v, b_luudayId = 'A'
function hd_ma_bnnghe_P_KD() {
    hd_ma_bnnghe_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'MA_NNGIEP'), b_ma_nnnghe_Id = form_Fs_TEN_ID(b_vungId, 'MA_NNNGHE'),
    b_cap_bac = form_Fs_TEN_ID(b_vungId, 'CAP_BAC'), b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_slideId = b_grlkeId + '_slide';
    hd_ma_bnnghe_lkeCho = setInterval('hd_ma_bnnghe_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
            if (a_tso[0] == 'FILE_HTOAN') {
                hd_ma_bnnghe_P_LKE();
            }
        }
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("MA_NNNGHE") >= 0) {
            $get(b_ma_nnnghe_Id).value = b_kq;
            hd_ma_bnnghe_P_LKE(); form_P_MOI(b_vungId, "LX");
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_gocId).focus();
        }
        else if (b_dtuong.indexOf("MA_NNGIEP") >= 0) {
            $get(b_gocId).value = b_kq;
            hd_ma_bnnghe_P_LKE_MA_NNGIEP(); form_P_MOI(b_vungId, "GX");
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_cap_bac).focus();
        }
        else if (b_dtuong.indexOf("THAMSO") >= 0) {
            $get(b_ma_nnnghe_Id).value = a_tso[0];
            $get(b_ma_nnnghe_Id).focus();
            hd_ma_bnnghe_P_LKE();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function hd_ma_bnnghe_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA_NNNGHE": b_maId = b_ma_nnnghe_Id; break;
            case "MA_NNGIEP": b_maId = b_gocId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA_NNNGHE") {
            $get(b_ma_nnnghe_Id).value = ($get(b_ma_nnnghe_Id).value).validate_Ma();
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), hd_ma_bnnghe_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            hd_ma_bnnghe_P_LKE();
            // hd_ma_bnnghe_P_LKE_MA_NNGIEP();          
        }
        else if (b_maTen == "MA_NNGIEP") {
            $get(b_gocId).value = ($get(b_gocId).value).validate_Ma();
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ma_nngiep", b_ma.value);
            if (b_hang < 1) {
                GridX_thoiA(b_grlkeId); hd_ma_bnnghe_P_MA_KTRA();
            }
            else { GridX_datA(b_grlkeId, b_hang); hd_ma_bnnghe_P_CHUYEN_HANG(); }
            // hd_ma_bnnghe_P_LKE();            
        }
        //else if (b_maTen == "CAP_BAC")
        //{
        //    var b_tt = form_Fctr_TEN_DTUONG(b_vungId, 'tt');
        //    b_hang = GridX_Fi_timHangD(b_grlkeId, "cap_bac", b_ma.value);
        //    if (b_hang < 1) {
        //        GridX_thoiA(b_grlkeId); hd_ma_bnnghe_P_MA_KTRA(); 
        //    }
        //    else { GridX_datA(b_grlkeId, b_hang); hd_ma_bnnghe_P_CHUYEN_HANG(); }
        //    b_tt.focus();
        //}
    }
    catch (err) { form_P_LOI(err); }
}
function hd_ma_bnnghe_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_mannghe = $get(b_ma_nnnghe_Id).value, b_ma_nngiep = $get(b_gocId).value;
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_hdns.Fs_HD_MA_BNNGHE_MA_CAP_BAC(b_mannghe, b_ma_nngiep, b_TrangKt, a_cot, hd_ma_bnnghe_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function hd_ma_bnnghe_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    //GridX_datBang(b_grlkeId, a_kq[3]);
    // slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) { form_P_MOI(b_vungId, "X"); return false; }
    else { GridX_datA(b_grlkeId, b_hang); hd_ma_bnnghe_P_CHUYEN_HANG(); }
}
function hd_ma_bnnghe_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    $get(b_gchuId).innerHTML = b_kq;
    form_P_MOI(b_vungId, "GX");
    $get(b_gocId).focus();
}
var hd_ma_bnnghe_choAct = 0;
function hd_ma_bnnghe_GR_lke_RowChange() {
    if (hd_ma_bnnghe_choAct != 0) clearTimeout(hd_ma_bnnghe_choAct);
    hd_ma_bnnghe_choAct = setTimeout("hd_ma_bnnghe_P_CHUYEN_HANG()", 300);
    return false;
}
function hd_ma_bnnghe_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(hd_ma_bnnghe_lkeCho); hd_ma_bnnghe_P_LKE(); }
}
function hd_ma_bnnghe_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    var b_nnnghiep = $get(b_ma_nnnghe_Id).value;
    if (b_nnnghiep == null || b_nnnghiep == "") { form_P_LOI("Chưa chọn Ngạch nghề nghiệp!"); return false; }
    sns_hdns.Fs_HD_MA_BNNGHE_NH(b_TrangKt, a_dt_ct, a_cot, hd_ma_bnnghe_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function hd_ma_bnnghe_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI("Nhập dữ liệu thành công!");
    }
    return false;
}
function hd_ma_bnnghe_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_gocId).focus();
    return false;
}
function hd_ma_bnnghe_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == 0) { hd_ma_bnnghe_P_MOI(); form_P_LOI("Bạn phải chọn một bản ghi để xóa"); }
    else {
        var message = confirm("Bạn có chắc chắn xóa không?");
        if (message == false) { return false; } else {
            var b_mannghe = $get(b_ma_nnnghe_Id).value, b_ma_nngiep = $get(b_gocId).value, b_capbac = $get(b_cap_bac).value, a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            sns_hdns.Fs_HD_MA_BNNGHE_XOA(b_mannghe, b_ma_nngiep, b_capbac, a_tso, a_cot, hd_ma_bnnghe_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        } 
    }
    return false;
}
function hd_ma_bnnghe_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) hd_ma_bnnghe_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); hd_ma_bnnghe_P_CHUYEN_HANG(); }
        form_P_LOI("Xóa dữ liệu thành công!");
    }
}
function hd_ma_bnnghe_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return false;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == 0) { form_P_MOI(b_vungId, "XGL"); return false; }
        else form_P_GridX_TEXT(b_vungId, b_grlkeId);
    }
    catch (err) { form_P_LOI(err); }
}
function hd_ma_bnnghe_P_LKE() {
    try {
        var b_mannghe = $get(b_ma_nnnghe_Id).value, a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_day = b_luudayId;
        sns_hdns.Fs_HD_MA_BNNGHE_LKE(b_mannghe,b_day, a_tso, a_cot, hd_ma_bnnghe_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function hd_ma_bnnghe_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function hd_ma_bnnghe_P_LKE_MA_NNGIEP() {
    try {
        var b_ma_nnghe = $get(b_ma_nnnghe_Id).value, b_ma_nngiep = $get(b_gocId).value, a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_HD_MA_BNNGHE_MA_NNGIEP_LKE(b_ma_nnghe, b_ma_nngiep, a_tso, a_cot, hd_ma_bnnghe_P_LKE_MA_NNGIEP_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function hd_ma_bnnghe_P_LKE_MA_NNGIEP_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function hd_ma_bnnghe_P_IN() {
    __doPostBack('ctl00$ContentPlaceHolder1$Nhap2', '');
}
function form_dong() {
    location.reload(false);
}
function hd_ma_bnnghe_P_MAU() {
    __doPostBack('ctl00$ContentPlaceHolder1$btn_excel_mau', '');//Xuất file Excel mẫu

}
function hd_ma_bnnghe_FILE_Import() {//import từ file Excel
    var b_tenf = '/App_form/ns/hdns/file_hdns.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "BAC_NNGHE_IMP", "BAC_NNGHE_IMP", "Import bậc ngành nghề"]], null);
    form_P_LOI('');
    return false;
}