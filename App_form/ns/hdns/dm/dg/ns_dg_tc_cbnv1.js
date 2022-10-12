var b_lkeCho, b_vungId, b_grlkeId, b_gr_tieuChi_Id, b_slide_lke_Id, b_slide_tc_Id, b_nam_id, b_ky_dg_Id, b_cbnv_id, b_gchu_id, b_so_the_id, b_nsd, ns_dg_tc_cbnv_choAct = 0;
function ns_dg_tc_cbnv_P_KD() {
    b_vungId = form_Fs_VUNG_ID('UPa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_gr_tieuChi_Id = form_Fs_VUNG_ID('GR_tc');
    b_nam_id = form_Fs_TEN_ID(b_vungId, 'NAM_DR');
    b_ky_dg_Id = form_Fs_TEN_ID(b_vungId, 'MA_KDG_DR');
    b_cbnv_id = form_Fs_TEN_ID(b_vungId, 'cbnv');
    b_gchu_id = form_Fs_TEN_ID(b_vungId, 'gchu');
    b_day = form_Fs_TEN_ID(b_vungId, 'day_nhomtc');
    b_so_the_id = form_Fs_VTEN_ID('UPa_hi', 'so_the');
    b_slide_lke_Id = $get(b_grlkeId).getAttribute('slideId'); slide_P_MOI(b_slide_lke_Id);
    b_slide_tc_Id = $get(b_gr_tieuChi_Id).getAttribute('slideId'); slide_P_MOI(b_slide_tc_Id);
    b_nsd = form_Fs_nsd();
    //b_lkeCho = setInterval('ns_dg_tc_cbnv_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        b_dtuong = b_dtuong.toUpperCase();
        if (b_dtuong.indexOf("MA") >= 0) {
            ns_dg_tc_cbnv_P_LAY();
        }
        else if (b_dtuong.indexOf("NHOM_TC") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_gr_tieuChi_Id);
            if (b_hang < 1) return;
            var b_ma_nhom_tc = a_tso[0], b_ten_nhom_tc = a_tso[1];
            var b_ma_nhom_tc_cu = GridX_Fas_layGtri(b_gr_tieuChi_Id, b_hang, "ma_nhom_tc");
            if (b_ma_nhom_tc_cu != b_ma_nhom_tc)
                GridX_datGtri(b_gr_tieuChi_Id, b_hang, ["ma_nhom_tc", "nhom_tc", "ma_tc", "tieu_chi"], [b_ma_nhom_tc, b_ten_nhom_tc, "", ""], 'K');
            else
                GridX_datGtri(b_gr_tieuChi_Id, b_hang, ["ma_nhom_tc", "nhom_tc"], [b_ma_nhom_tc, b_ten_nhom_tc], 'K');
            $get(b_day).value = b_ma_nhom_tc + "{" + b_ten_nhom_tc;
        }
        else if (b_dtuong.indexOf("TIEU_CHI") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_gr_tieuChi_Id);
            if (b_hang < 1) return;
            var b_ma_tieu_chi = a_tso[0], b_tieu_chi = a_tso[1], b_ma_nhom_tc = a_tso[2], b_ten_nhom_tc = a_tso[3];
            var b_hang_kt = GridX_Fi_timHangD(b_gr_tieuChi_Id, "ma_tc", b_ma_tieu_chi);
            if (b_hang_kt > 0) {
                form_P_LOI("loi:Trùng tiêu chí:loi");
                return;
            }
            var b_ma_nhom_tc_cu = GridX_Fas_layGtri(b_gr_tieuChi_Id, b_hang, "ma_nhom_tc");
            if (b_ma_nhom_tc_cu != b_ma_nhom_tc)
                GridX_datGtri(b_gr_tieuChi_Id, b_hang, ["ma_nhom_tc", "nhom_tc", "ma_tc", "tieu_chi"], [b_ma_nhom_tc, b_ten_nhom_tc, b_ma_tieu_chi, b_tieu_chi], 'K');
            else
                GridX_datGtri(b_gr_tieuChi_Id, b_hang, ["ma_tc", "tieu_chi"], [b_ma_tieu_chi, b_tieu_chi], 'K');
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dg_tc_cbnv_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "NAM": b_maId = b_nam_id; break;
            case "MA_KDG": b_maId = b_cnv_id; break;
            case "MA_PLNV": b_maId = b_plnv_id; break;
            case "MA_CAPNV": b_maId = b_cnv_id; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
       
        switch (b_maTen) {
            case "MA_PLNV":
                // lấy danh mục cấp nhân viên
                var b_plnv = C_NVL(form_Fs_TEN_GTRI(b_vungId, 'MA_PLNV'));
                if (b_plnv == "") return;
                sns_ma_ch.Fs_NS_HDNS_MA_CAPNV_LKE_ALL(b_nsd, "ns_dg_tc_cbnv", "TC_DG_CNV_KY_CNV", ns_dg_tc_cbnv_P_CAPNV_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                break;            
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dg_tc_cbnv_P_CAPNV_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
}
function ns_dg_tc_cbnv_P_MOI() {
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_gr_tieuChi_Id);
    //ns_dg_tc_cbnv_P_DEFAULT_LUYKE();
    return false;
}
function ns_dg_tc_cbnv_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("loi:Bạn chưa chọn cán bộ nhân viên:loi"); return false; }
    var b_nam = CSO_SO(form_Fs_TEN_GTRI(b_vungId, 'NAM_DR')),
        b_ma_kdg = form_Fs_TEN_GTRI(b_vungId, 'MA_KDG_DR'),
        b_so_the = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the"),
        b_ma_plnv = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma_plnv"),
        b_ma_capnv = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma_capnv");
    var a_cot_ct = GridX_Fdt_cotGtri(b_gr_tieuChi_Id);    
    sdg.Fs_NS_DG_TC_CBNV_NH(b_nsd, b_nam, b_ma_kdg, b_so_the, b_ma_plnv, b_ma_capnv, a_cot_ct, ns_dg_tc_cbnv_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_dg_tc_cbnv_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_tc_rieng = CSO_SO(a_kq[0]);
        var b_dong = CSO_SO(a_kq[1]);
        if (b_dong < 10) b_dong = 10;
        GridX_P_hangKt(b_gr_tieuChi_Id, b_dong);
        GridX_datBang(b_gr_tieuChi_Id, a_kq[2]);
        var b_gchu = "Tiêu chí theo PLNV";
        if (b_tc_rieng == 1) b_gchu = "Tiêu chí riêng của NV";
        form_P_DatGchu(b_gchu_id, b_gchu);
        form_P_LOI("loi:Ghi thành công!:loi");
    }
}
function ns_dg_tc_cbnv_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
    if (b_ma == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); ns_dg_tc_cbnv_P_MOI(); }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_so_id = CSO_SO(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        sdg.Fs_NS_DG_TC_CNV_XOA(b_nsd, b_so_id, a_tso, a_cot, ns_dg_tc_cbnv_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_dg_tc_cbnv_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
        var b_dong = GridX_Fi_hangSo(b_grlkeId);
        if (b_hang > b_dong) b_hang = b_dong;
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dg_tc_cbnv_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dg_tc_cbnv_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
}
function ns_dg_tc_cbnv_GR_lke_RowChange() {
    if (ns_dg_tc_cbnv_choAct != 0) clearTimeout(ns_dg_tc_cbnv_choAct);
    ns_dg_tc_cbnv_choAct = setTimeout("ns_dg_tc_cbnv_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_dg_tc_cbnv_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_nam = CSO_SO(form_Fs_TEN_GTRI(b_vungId, 'NAM_DR')),
            b_ma_kdg = form_Fs_TEN_GTRI(b_vungId, 'MA_KDG_DR'),
            b_so_the = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the"),
            b_ma_plnv = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma_plnv"),
            b_ma_capnv = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma_capnv");
        if (b_so_the == "") { ns_dg_tc_cbnv_P_MOI(); GridX_datA(b_grlkeId, b_hang); }
        else {
            var a_cot = GridX_Fas_tenCot(b_gr_tieuChi_Id);
            sdg.Fs_NS_DG_TC_CBNV_CT(b_nsd, b_nam, b_ma_kdg, b_so_the, b_ma_plnv, b_ma_capnv, a_cot, ns_dg_tc_cbnv_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dg_tc_cbnv_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else if (b_kq == '') ns_dg_tc_cbnv_P_MOI();
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_tc_rieng = CSO_SO(a_kq[0]);
        var b_dong = CSO_SO(a_kq[1]), b_hangKt = GridX_Fi_hangKt(b_gr_tieuChi_Id);
        if (b_dong < b_hangKt) b_dong = b_hangKt;
        //GridX_P_hangKt(b_gr_tieuChi_Id, b_dong);
        GridX_datBang(b_gr_tieuChi_Id, a_kq[2]);
        slide_P_SOTRANG(b_slide_tc_Id);
        var b_gchu = "Tiêu chí theo PLNV";
        if (b_tc_rieng == 1) b_gchu = "Tiêu chí riêng của NV";
        form_P_DatGchu(b_gchu_id, b_gchu);        
        //for (var i = 1; i <= b_dong; i++) {
        //    if (GridX_Fas_layGtri(b_gr_tieuChi_Id, i, "ma_nhom_tc") == "") {
        //        GridX_datGtri(b_gr_tieuChi_Id, i, ["luyke_kysau"], ['C'], 'K');
        //    }
        //}
    }
}
function ns_dg_tc_cbnv_GR_tc_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        if (b_cot == 'MA_NHOM_TC' && b_value != '') {
            sdg.Fs_NS_DG_MA_TCHI_LKE_ALL(b_nsd, b_value, ["ma", "ten"], ns_dg_tieuChi_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if ((b_cot == "TSO_NHOM" || b_cot == "TSO_TC") && b_value != '') {
            var b_trso = CSO_SO(b_value);
            if (b_trso == 0 || b_trso > 100) {
                if (b_cot == "TSO_NHOM")
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
        GridX_ThemHang(b_gr_tieuChi_Id);
        //slide_P_SOTRANG(b_grdsId + '_slide');
    }
}
function ns_dg_tc_cbnv_GR_lke_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        if (b_cot == 'CHON' && b_value != '') {
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            GridX_datTrang(b_grlkeId, null, null, "chon");
            GridX_datGtri(b_grlkeId, b_hang, ["chon"], ["X"], 'K');
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_dg_tc_cbnv_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) {
        clearTimeout(b_lkeCho);
        //ns_dg_tc_cbnv_P_LKE();
        //ns_dg_tc_cbnv_P_DEFAULT_LUYKE();
    }
}
function ns_dg_tc_cbnv_P_LKE() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var a_cot = GridX_Fas_tenCot(b_grlkeId);
        var b_phong = form_Fs_TEN_GTRI(b_vungId, 'phong_dr'),
            b_cbnv = C_NVL($get(b_cbnv_id).value),
            b_ky_dg = C_NVL($get(b_ky_dg_Id).value);
        //if (b_phong == "" && b_cbnv == "") {
        //    form_P_LOI("loi:Bạn cần chọn phòng ban hoặc nhập mã/tên CBNV để tìm kiếm:loi");
        //    return false;
        //}
        sdg.Fs_NS_DG_TC_CBNV_TIMNV(b_nsd, b_phong, b_cbnv, b_ky_dg, a_cot, ns_dg_tc_cbnv_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dg_tc_cbnv_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    //slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));    
    //var b_dong = CSO_SO(a_kq[0]);
    //if (b_dong < 12) b_dong = 12;
    //GridX_P_hangKt(b_grlkeId, b_dong);
    GridX_datBang(b_grlkeId, a_kq[1]);
    slide_P_SOTRANG(b_slide_lke_Id);
    if(CSO_SO(a_kq[0]) == 0)
        form_P_LOI("loi:Không tìm thấy cán bộ nhân viên:loi");
}
function ns_dg_ma_nhom_tieuChi_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_dropCot(b_gr_tieuChi_Id, 'ma_nhom_tc', b_kq);
}
function ns_dg_tieuChi_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var b_hang = GridX_Fi_timHangA(b_gr_tieuChi_Id);
    if (b_hang > 0) {
        //GridX_listCell(b_gr_tieuChi_Id, b_hang, 'ma_tc', "1,2,3,4,5", "1,2,3,4,5");
        //GridX_listCot(b_gr_tieuChi_Id, 'ma_tc', "A,B,C,D,E", "1,2,3,4,5");
        GridX_dropCell(b_gr_tieuChi_Id, b_hang, 'ma_tc', b_kq);
    }
}
function ns_dg_tc_cbnv_HangLen() {
    GridX_chuyenHang(b_gr_tieuChi_Id, -1);
    return false;
}
function ns_dg_tc_cbnv_HangXuong() {
    GridX_chuyenHang(b_gr_tieuChi_Id, 1);
    return false;
}
function ns_dg_tc_cbnv_CatDong() {
    GridX_boChon(b_gr_tieuChi_Id, 'C');
    return false;
}
function ns_dg_tc_cbnv_ChenDong(b_dk) { 
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
function ns_dg_tc_cbnv_P_EXCEL() {
    try{
        var b_so_the = GridX_Fdt_cotGtriD(b_grlkeId, "chon", "X", "so_the,MA_PLNV,MA_CAPNV");
        if (b_so_the[1] == null || b_so_the[1][0][0] == "") {
            form_P_LOI("loi:Bạn chưa chọn nhân viên:loi");
            return false;
        }
        var b_nam = CSO_SO(form_Fs_TEN_GTRI(b_vungId, 'NAM_DR')), b_ma_kdg = form_Fs_TEN_GTRI(b_vungId, 'MA_KDG_DR');
        $get(b_so_the_id).value = b_so_the[1][0][0] + String.fromCharCode(1) + b_so_the[1][0][1] + String.fromCharCode(1) + b_so_the[1][0][2] + String.fromCharCode(1) + b_nam + String.fromCharCode(1) + b_ma_kdg;
        __doPostBack('ctl00$ContentPlaceHolder1$excel', '');
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dg_tc_cbnv_P_DEFAULT_LUYKE() {
    var b_dong = GridX_Fi_hangSo(b_gr_tieuChi_Id);
    for (var i = 1; i <= b_dong; i++) {
        GridX_datGtri(b_gr_tieuChi_Id, i, ["luyke_kysau"], ['C'], 'K');
    }
}
function form_dong() {
    location.reload(false);
}