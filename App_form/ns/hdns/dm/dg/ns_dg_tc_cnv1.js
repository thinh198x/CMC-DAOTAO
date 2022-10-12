var b_lkeCho, b_vungId, b_grlkeId, b_gr_tieuChi_Id, b_slideId, b_slide_ct_Id, b_nam_id, b_ky_dg_Id, b_plnv_id, b_cnv_id, b_ngay_apdung_Id, b_nsd, ns_dg_tc_cnv_choAct = 0;
function ns_dg_tc_cnv_P_KD() {
    b_lkeCho = setInterval('ns_dg_tc_cnv_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        b_dtuong = b_dtuong.toUpperCase();
        if (b_dtuong.indexOf("MA") >= 0) {
            ns_dg_tc_cnv_P_LAY();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dg_tc_cnv_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "NAM": b_maId = b_nam_id; break;
            case "MA_KDG": b_maId = b_cnv_id; break;
            case "MA_PLNV": b_maId = b_plnv_id; break;
            case "MA_CAPNV": b_maId = b_cnv_id; break;
            case "NGAY_ADUNG": b_maId = b_ngay_apdung_Id; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || (b_maTen != "MA_CAPNV" && C_NVL(b_ma.value) == "")) return;               
        switch (b_maTen) {
            case "MA_PLNV":
                // lấy danh mục cấp nhân viên
                $get(b_cnv_id).value = null;
                var b_plnv = C_NVL(form_Fs_TEN_GTRI(b_vungId, 'MA_PLNV'));
                form_P_MOI(b_vungId, "X");
                GridX_datTrang(b_gr_tieuChi_Id); slide_P_SOTRANG(b_slide_ct_Id);
                sns_ma_ch.Fs_NS_HDNS_MA_CAPNV_LKE_DR(b_nsd, "ns_dg_tc_cnv", "TC_DG_CNV_KY_CNV", b_plnv, "A", ns_dg_tc_cnv_P_CAPNV_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                break;
            case "NAM":                
            case "MA_KDG":               
            case "MA_CAPNV":
            case "NGAY_ADUNG":
                var b_nam = C_NVL(form_Fs_TEN_GTRI(b_vungId, 'NAM')), b_kdg = C_NVL(form_Fs_TEN_GTRI(b_vungId, 'MA_KDG')),
                    b_plnv = C_NVL(form_Fs_TEN_GTRI(b_vungId, 'MA_PLNV')), b_cnv = C_NVL(form_Fs_TEN_GTRI(b_vungId, 'ma_capnv')), b_ngay_adung = $get(b_ngay_apdung_Id).value;
                if (b_nam == "" || b_kdg == "" || b_plnv == "" || b_ngay_adung == "") return;
                // tìm trên lưới
                var b_hang = GridX_Fi_timHangD(b_grlkeId, ["nam", "ma_kdg", "ma_plnv", "ma_capnv", "ngay_adung"], [b_nam, b_kdg, b_plnv, b_cnv, b_ngay_adung]);
                if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_dg_tc_cnv_P_MA_KTRA(); }
                else { GridX_datA(b_grlkeId, b_hang); ns_dg_tc_cnv_P_CHUYEN_HANG(); }
                $get(b_ngay_apdung_Id).focus();
                break;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dg_tc_cnv_P_CAPNV_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
}
function ns_dg_tc_cnv_P_MA_KTRA() {
    try {        
        var b_nam = C_NVL(form_Fs_TEN_GTRI(b_vungId, 'NAM')), b_kdg = C_NVL(form_Fs_TEN_GTRI(b_vungId, 'MA_KDG')),
                b_plnv = C_NVL(form_Fs_TEN_GTRI(b_vungId, 'MA_PLNV')), b_cnv = C_NVL(form_Fs_TEN_GTRI(b_vungId, 'ma_capnv')), b_ngay_adung = CNG_SO($get(b_ngay_apdung_Id).value);
        var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
        sdg.Fs_NS_DG_TC_CNV_MA(b_nsd, b_nam, b_kdg, b_plnv, b_cnv, b_ngay_adung, b_TrangKt, a_cot, ns_dg_tc_cnv_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dg_tc_cnv_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        //form_P_MOI(b_vungId, "X");
        GridX_datTrang(b_gr_tieuChi_Id);
        slide_P_SOTRANG(b_slide_ct_Id);
    }
    else {
        GridX_datA(b_grlkeId, b_hang);
        ns_dg_tc_cnv_P_CHUYEN_HANG();
    }
}
function ns_dg_tc_cnv_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_gr_tieuChi_Id);
    slide_P_SOTRANG(b_slide_ct_Id);
    //ns_dg_tc_cnv_P_DEFAULT_LUYKE();
    return false;
}
function ns_dg_tc_cnv_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }    
    var a_cot_ct = GridX_Fdt_cotGtri(b_gr_tieuChi_Id);
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
    var b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sdg.Fs_NS_DG_TC_CNV_NH(b_nsd, b_TrangKt, a_dt_ct, a_cot_ct, a_cot_lke, ns_dg_tc_cnv_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_dg_tc_cnv_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) { GridX_datA(b_grlkeId, b_hang); ns_dg_tc_cnv_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Ghi thành công!:loi");
    }
}
function ns_dg_tc_cnv_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); ns_dg_tc_cnv_P_MOI(); }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        b_so_id = CSO_SO(b_so_id);
        sdg.Fs_NS_DG_TC_CNV_XOA(b_nsd, b_so_id, a_tso, a_cot, ns_dg_tc_cnv_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_dg_tc_cnv_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
        var b_dong = GridX_Fi_hangSo(b_grlkeId);
        if (b_hang > b_dong) b_hang = b_dong;
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dg_tc_cnv_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dg_tc_cnv_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
}
function ns_dg_tc_cnv_GR_lke_RowChange() {
    if (ns_dg_tc_cnv_choAct != 0) clearTimeout(ns_dg_tc_cnv_choAct);
    ns_dg_tc_cnv_choAct = setTimeout("ns_dg_tc_cnv_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_dg_tc_cnv_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "") { ns_dg_tc_cnv_P_MOI(); GridX_datA(b_grlkeId, b_hang); }
        else {
            var b_so_id = CSO_SO(b_so_id);
            var a_cot = GridX_Fas_tenCot(b_gr_tieuChi_Id);
            sdg.Fs_NS_DG_TC_CNV_CT(b_nsd, b_so_id, a_cot, ns_dg_tc_cnv_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dg_tc_cnv_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else if (b_kq == '') ns_dg_tc_cnv_P_MOI();
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        form_P_CH_TEXT(b_vungId, a_kq[0]);
        var b_dong = CSO_SO(a_kq[2]);
        if (b_dong < 8) b_dong = 8;
        GridX_P_hangKt(b_gr_tieuChi_Id, b_dong);
        var a_index_ma_nhom = Fas_ChMang(a_kq[3], ','), a_ma_tc_nhom = Fas_ChMang(a_kq[4], String.fromCharCode(1));
        for (var i = 0; i < a_index_ma_nhom.length; i++) {
            var b_dm_tc = a_ma_tc_nhom[a_index_ma_nhom[i]];
            GridX_dropCell(b_gr_tieuChi_Id, i + 1, 'ma_tc', b_dm_tc);            
        }        
        GridX_datBang(b_gr_tieuChi_Id, a_kq[1]);
        slide_P_SOTRANG(b_slide_ct_Id);
        //for (var i = 1; i <= b_dong; i++) {
        //    if (GridX_Fas_layGtri(b_gr_tieuChi_Id, i, "ma_nhom_tc") == "") {
        //        GridX_datGtri(b_gr_tieuChi_Id, i, ["luyke_kysau"], ['C'], 'K');
        //    }
        //}
    }
}
function ns_dg_tc_cnv_GR_tc_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        if (b_cot == 'MA_NHOM_TC' && b_value != '') {
            sdg.Fs_NS_DG_MA_TCHI_LKE_ALL(b_nsd, b_value, ["ma", "ten"], ns_dg_tieuChi_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_cot == 'MA_TC' && b_value != '') {
            var b_hangD = GridX_Fi_timHangD(b_gr_tieuChi_Id, "MA_TC", b_value);
            var b_hangC = GridX_Fi_timHangX(b_gr_tieuChi_Id, ["MA_TC"], [b_value], "==");
            var b_hangA = GridX_Fi_timHangA(b_gr_tieuChi_Id);
            if (b_hangD != b_hangA || b_hangC != b_hangA) {
                form_P_LOI("loi:Trùng tiêu chí:loi");
                b_ctr.value = null;
            }
        }
        else if ((b_cot == "TSO_NHOM" || b_cot == "TSO_TC") && b_value != '')
        {
            var b_trso = CSO_SO(b_value);
            if (b_trso == 0 || b_trso > 100)
            {
                if(b_cot == "TSO_NHOM")
                    form_P_LOI("loi:Trọng số nhóm tiêu chí phải lớn hơn 0 và nhỏ hơn hoặc bằng 100:loi");
                else
                    form_P_LOI("loi:Trọng số tiêu chí phải lớn hơn 0 và nhỏ hơn hoặc bằng 100:loi");
                //var b_hang = GridX_Fi_timHangA(b_gr_tieuChi_Id);
                //GridX_datGtri(b_gr_tieuChi_Id, b_hang, b_cot, "", "K");
            }
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function pcchs_hs_GR_ds_Update_KQ(b_kq) {
    var b_hang = GridX_Fi_timHangA(b_gr_tieuChi_Id);
    if (b_hang > 0) {
        GridX_dropCell(b_gr_tieuChi_Id, b_hang, 'ma_tc', b_kq);
        //GridX_ThemHang(b_gr_tieuChi_Id);
        //slide_P_SOTRANG(b_grdsId + '_slide');
    }
}
function ns_dg_tc_cnv_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(b_lkeCho);
        b_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_gr_tieuChi_Id = form_Fs_VUNG_ID('GR_tc');
        b_nam_id = form_Fs_TEN_ID(b_vungId, 'NAM');
        b_ky_dg_Id = form_Fs_TEN_ID(b_vungId, 'MA_KDG');
        b_plnv_id = form_Fs_TEN_ID(b_vungId, 'MA_PLNV');
        b_cnv_id = form_Fs_TEN_ID(b_vungId, 'ma_capnv');
        b_ngay_apdung_Id = form_Fs_TEN_ID(b_vungId, 'NGAY_ADUNG');
        b_slideId = $get(b_grlkeId).getAttribute('slideId'); slide_P_MOI(b_slideId);
        b_slide_ct_Id = $get(b_gr_tieuChi_Id).getAttribute('slideId'); slide_P_MOI(b_slide_ct_Id);
        b_nsd = form_Fs_nsd();
        ns_dg_tc_cnv_P_LKE();
        ns_dg_tc_cnv_nhom_tieuChi_P_LKE();
    }
}
function ns_dg_tc_cnv_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_NS_DG_TC_CNV_LKE(b_nsd, a_tso, a_cot, ns_dg_tc_cnv_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);              
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dg_tc_cnv_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_dg_tc_cnv_nhom_tieuChi_P_LKE() {
    //var b_plnv = C_NVL(form_Fs_TEN_GTRI(b_vungId, 'MA_PLNV'));
    //sns_ma_ch.Fs_NS_HDNS_MA_CAPNV_LKE_DR(b_nsd, "ns_dg_tc_cnv", "TC_DG_CNV_KY_CNV", b_plnv, "A", ns_dg_tc_cnv_P_CAPNV_KQ, P_LOI_CSDL, P_LOI_TGIAN);  
    sdg.Fs_NS_DG_MA_NHOM_TCHI_LKE_ALL(b_nsd, ["ma", "ten"], ns_dg_ma_nhom_tieuChi_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function ns_dg_ma_nhom_tieuChi_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_dropCot(b_gr_tieuChi_Id, 'ma_nhom_tc', b_kq);
}
function ns_dg_tieuChi_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var b_hang = GridX_Fi_timHangA(b_gr_tieuChi_Id);
    if (b_hang > 0) {
        GridX_dropCell(b_gr_tieuChi_Id, b_hang, 'ma_tc', b_kq);
    }
}
function ns_dg_tc_cnv_HangLen() {    
    GridX_chuyenHang(b_gr_tieuChi_Id, -1);
    return false;
}
function ns_dg_tc_cnv_HangXuong() {    
    GridX_chuyenHang(b_gr_tieuChi_Id, 1);
    return false;
}
function ns_dg_tc_cnv_CatDong() {    
    GridX_boChon(b_gr_tieuChi_Id, 'C');
    return false;
}
function ns_dg_tc_cnv_ChenDong(b_dk) {
    if (C_NVL(b_dk) == 'C') {
        var b_hang = GridX_Fi_timHangA(b_gr_tieuChi_Id);
        var b_dong = GridX_Fi_hangKt(b_gr_tieuChi_Id);
        GridX_P_hangKt(b_gr_tieuChi_Id, b_dong + 1);
        GridX_chenHang(b_gr_tieuChi_Id);
        if (b_hang <= 0) b_hang = b_dong + 1;
        GridX_datGtri(b_gr_tieuChi_Id, b_hang, ["luyke_kysau"], ['C'], 'K');
    }
    return false;
}
function ns_dg_tc_cnv_P_DEFAULT_LUYKE() {
    var b_dong = GridX_Fi_hangSo(b_gr_tieuChi_Id);
    for (var i = 1; i <= b_dong; i++) {
        GridX_datGtri(b_gr_tieuChi_Id, i, ["luyke_kysau"], ['C'], 'K');
    }
}
function form_dong() {
    location.reload(false);
}