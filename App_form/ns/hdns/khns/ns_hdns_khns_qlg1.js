var b_lkeCho, b_choAct, b_vungId, b_grlkeId, b_grctId, b_slideId, b_slide_ct_Id, b_nam_lke_Id, b_nam_Id, b_phong_Id, b_thang_d_Id, b_thang_c_Id, b_phong_an_Id, b_ngay_an_Id, b_so_id_Id, b_nsd;
function ns_hdns_khns_qlg_P_KD() {
    b_lkeCho = setInterval('ns_hdns_khns_qlg_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("CDANH") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 1) return;
            var b_ma_cdanh = a_tso[0], b_ten_cdanh = a_tso[1], b_ma_plnv = a_tso[6], b_ten_plnv = a_tso[7];
            GridX_datGtri(b_grctId, b_hang, ["cdanh", "ten_cdanh", "loai_nv", "ten_plnv"], [b_ma_cdanh, b_ten_cdanh, b_ma_plnv, b_ten_plnv], 'K');
        }
        else if (b_dtuong.indexOf("TEN_PLNV") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 1) return;
            var b_ma_loai_nv = a_tso[0], b_ten_loai_nv = a_tso[1];
            GridX_datGtri(b_grctId, b_hang, ["loai_nv", "ten_plnv"], [b_ma_loai_nv, b_ten_loai_nv], 'K');
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_khns_qlg_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "NAM": b_maId = b_nam_Id; break;
            case "PHONG": b_maId = b_phong_Id; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return true;
        switch (b_maTen) {
            case "NAM": // lay thong tin nam tai chinh
                ns_hdns_khns_qlg_P_NAM_TC();
                var b_nam = lke_Fs_TRA(b_nam_Id), b_phong = lke_Fs_TRA(b_phong_Id);
                if (b_nam == "" || b_phong == "") return;
                var b_hang = GridX_Fi_timHangD(b_grlkeId, ["nam", "phong"], [b_nam, b_phong]);
                if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_hdns_khns_qlg_P_MA_KTRA(); }
                else { GridX_datA(b_grlkeId, b_hang); ns_hdns_khns_qlg_P_CHUYEN_HANG(); }
                break;
            case "PHONG":                
                var b_nam = lke_Fs_TRA(b_nam_Id), b_phong = lke_Fs_TRA(b_phong_Id);
                $get(b_phong_an_Id).value = b_phong;
                if (b_nam == "" || b_phong == "") return;
                var b_hang = GridX_Fi_timHangD(b_grlkeId, ["nam", "phong"], [b_nam, b_phong]);
                if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_hdns_khns_qlg_P_MA_KTRA(); }
                else { GridX_datA(b_grlkeId, b_hang); ns_hdns_khns_qlg_P_CHUYEN_HANG(); }
                break;                
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_khns_qlg_P_MA_KTRA() {
    try {
        var b_nam = lke_Fs_TRA(b_nam_Id), b_phong = lke_Fs_TRA(b_phong_Id);
        var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
        sns_hdns.Fs_NS_HDNS_KHNS_QLG_MA(b_nsd, b_nam, b_phong, b_TrangKt, a_cot, ns_hdns_khns_qlg_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_khns_qlg_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        //form_P_MOI(b_vungId, "X");
        GridX_datTrang(b_grctId);
        slide_P_SOTRANG(b_slide_ct_Id);
        var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
        var b_phong = lke_Fs_TRA(b_phong_Id), b_ngay_d = CNG_SO('01/' + $get(b_thang_d_Id).value), b_ngay_c = CNG_SO($get(b_ngay_an_Id).value);
        sns_hdns.Fs_NS_HDNS_KHNS_QLG_NEW(b_nsd, b_phong, b_ngay_d, b_ngay_c, a_cot, ns_hdns_khns_qlg_P_NEW_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    else {
        GridX_datA(b_grlkeId, b_hang);
        ns_hdns_khns_qlg_P_CHUYEN_HANG();
    }
}
function ns_hdns_khns_qlg_P_NEW_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang(b_grctId, b_kq);
    slide_P_SOTRANG(b_slide_ct_Id);
}
function ns_hdns_khns_qlg_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    slide_P_SOTRANG(b_slide_ct_Id);
    $get(b_phong_an_Id).value = '';
    $get(b_ngay_an_Id).value = '';
    return false;
}
function ns_hdns_khns_qlg_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt = form_Faa_TEXT_ROW(b_vungId), a_cot_ct = GridX_Fdt_cotGtri(b_grctId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);    
    sns_hdns.Fs_NS_HDNS_KHNS_QLG_NH(b_nsd, b_TrangKt, a_dt, a_cot_ct, a_cot, ns_hdns_khns_qlg_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_hdns_khns_qlg_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        form_P_LOI('loi:Ghi thành công!:loi');
        if (b_hang > 0) { GridX_datA(b_grlkeId, b_hang); ns_hdns_khns_qlg_P_CHUYEN_HANG(); }
    }
    return false;
}
function ns_hdns_khns_qlg_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa!:loi"); return false; }
    var b_dtg_ctru = GridX_Fas_layGtri(b_grlkeId, b_hang, "doituong_cutru"), b_ngay_d = GridX_Fas_layGtri(b_grlkeId, b_hang, "ngay_d");
    if (b_dtg_ctru == "") ns_hdns_khns_qlg_P_MOI();
    else {
        var b_index = b_dtg_ctru.indexOf("{"); b_dtg_ctru = b_dtg_ctru.substr(0, b_index);
        b_ngay_d = CNG_SO(b_ngay_d);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_NS_HDNS_KHNS_QLG_XOA(b_nsd, b_dtg_ctru, b_ngay_d, a_tso, a_cot, ns_hdns_khns_qlg_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_hdns_khns_qlg_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId), b_dong = CSO_SO(a_kq[0], 0);
        slide_P_SOTRANG(b_slideId, b_dong);
        GridX_datBang(b_grlkeId, a_kq[1]);
        if (b_hang > b_dong) b_hang = b_dong;
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_hdns_khns_qlg_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_hdns_khns_qlg_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
}
function ns_hdns_khns_qlg_GR_lke_RowChange() {
    if (b_choAct != 0) clearTimeout(b_choAct);
    b_choAct = setTimeout("ns_hdns_khns_qlg_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_hdns_khns_qlg_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
        if (b_so_id == "") {
            //form_P_MOI(b_vungId, "XGL");
            ns_hdns_khns_qlg_P_MOI();
            GridX_datA(b_grlkeId, b_hang);
        }
        else {
            form_P_GridX_TEXT(b_vungId, b_grlkeId);
            $get(b_ngay_an_Id).value = "31/" + $get(b_thang_c_Id).value;
            var a_cot = GridX_Fas_tenCot(b_grctId);
            var b_phong = lke_Fs_TRA(b_phong_Id), b_ngay_d = CNG_SO('01/' + $get(b_thang_d_Id).value), b_ngay_c = CNG_SO($get(b_ngay_an_Id).value);
            $get(b_phong_an_Id).value = b_phong;            
            sns_hdns.Fs_NS_HDNS_KHNS_QLG_CT(b_nsd, b_so_id, b_phong, b_ngay_d, b_ngay_c, a_cot, ns_hdns_khns_qlg_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        $get(b_so_id_Id).value = b_so_id;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_khns_qlg_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    //form_P_CH_TEXT(b_vungId, a_kq[0]);
    GridX_datBang(b_grctId, a_kq[1]);
    slide_P_SOTRANG(b_slide_ct_Id);
}
function ns_hdns_khns_qlg_GR_ct_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        var b_hang = GridX_Fi_timHangA(b_grctId);
        if (b_cot == 'THU_NHAP' || b_cot == 'LUONG_CB') {
            // tinh thuong danh gia thang hien tai
            var b_thuNhap = GridX_Fas_layGtri(b_grctId, b_hang, "THU_NHAP"), b_luongCb = GridX_Fas_layGtri(b_grctId, b_hang, "LUONG_CB");
            if (b_thuNhap != "" && b_luongCb != "") {                
                b_thuNhap = CSO_SO(b_thuNhap);
                b_luongCb = CSO_SO(b_luongCb);

                if (b_luongCb > b_thuNhap) {
                    form_P_LOI("loi:Lương cơ bản hiện tại không được lớn hơn Thu nhập tháng hiện tại:loi");
                    b_ctr.value = '';
                }              
            }
            tinhThuongDanhGiaThangHienTai(b_hang);
            if (b_cot == 'LUONG_CB') {
                tinhChiPhiCongDoan(b_hang);
                tinhKeHoachBaoHiem(b_hang);                
            }
            if (b_cot == 'THU_NHAP') {
                tinhTongQuyThuNhapThang(b_hang);
                tinhTongQuyThuongNangXuat(b_hang);
            }
            tinhTongThuNhapDuKien(b_hang);
        }
        else if (b_cot == 'THU_NHAP_KH' || b_cot == 'LUONG_CB_KH') {
            // tinh thuong danh gia thang ke hoach            
            var b_thuNhap = GridX_Fas_layGtri(b_grctId, b_hang, "THU_NHAP_KH"), b_luongCb = GridX_Fas_layGtri(b_grctId, b_hang, "LUONG_CB_KH");
            if (b_thuNhap != "" && b_luongCb != "") {                
                b_thuNhap = CSO_SO(b_thuNhap);
                b_luongCb = CSO_SO(b_luongCb);

                if (b_luongCb > b_thuNhap) {
                    form_P_LOI("loi:Lương cơ bản kế hoạch không được lớn hơn Thu nhập tháng kế hoạch:loi");
                    b_ctr.value = '';
                }               
            }
            tinhThuongDanhGiaThangKeHoach(b_hang);
            if (b_cot == 'LUONG_CB_KH') {
                tinhChiPhiCongDoan(b_hang);
                tinhKeHoachBaoHiem(b_hang);                
            }
            if (b_cot == 'THU_NHAP_KH') {
                tinhTongQuyThuNhapThang(b_hang);
                tinhTongQuyThuongNangXuat(b_hang);                
            }
            tinhTongThuNhapDuKien(b_hang);
        }
        else if (b_cot == 'NGAY_D_NAM' || b_cot == 'NGAY_C_NAM' || b_cot == 'NGAY_TD') {
            // tinh Số tháng làm việc dự kiến
            GridX_datGtri(b_grctId, b_hang, ["thang_lv_dk"], [""], 'K');
            var b_ngayD = GridX_Fas_layGtri(b_grctId, b_hang, "NGAY_D_NAM"), b_ngayC = GridX_Fas_layGtri(b_grctId, b_hang, "NGAY_C_NAM"), b_ngayTD = GridX_Fas_layGtri(b_grctId, b_hang, "NGAY_TD");
            var b_dauNamTaiChinh = '01/' + $get(b_thang_d_Id).value, b_cuoiNamTaiChinh = $get(b_ngay_an_Id).value;
            var b_soThangLamViecDuKien = '', b_ngay_null = 30000101;
            b_ngayD = CNG_SO(b_ngayD);
            b_ngayC = CNG_SO(b_ngayC);
            if ((b_cot == 'NGAY_D_NAM' || b_cot == 'NGAY_C_NAM') && b_ngayD != b_ngay_null && b_ngayC != b_ngay_null) {
                if (b_ngayD > b_ngayC) {
                    form_P_LOI("loi:Thời gian bắt đầu làm việc trong năm không được lớn hơn Thời gian kết thúc làm việc trong năm:loi");
                    b_ctr.value = '';
                }                
            }

            if (b_cot == 'NGAY_TD' && b_ngayTD != "") {
                b_ngayTD = CNG_SO(b_ngayTD);
                if (b_ngayTD < b_ngayD) {
                    form_P_LOI("loi:Thời gian thay đổi thu nhập tháng không được nhỏ hơn Thời gian bắt đầu làm việc trong năm:loi");
                    b_ctr.value = '';
                }
                if (b_ngayTD > b_ngayC) {
                    form_P_LOI("loi:Thời gian thay đổi thu nhập tháng không được lớn hơn Thời gian kết thúc làm việc trong năm:loi");
                    b_ctr.value = '';
                }
            }
           
            tinhSoThangLamViecDuKien(b_hang);
            tinhSoThangThuNhapHienTai(b_hang);
            tinhSoThangThuNhapThayDoi(b_hang);
            tinhChiPhiCongDoan(b_hang);
            tinhTongQuyThuNhapThang(b_hang);
            tinhKeHoachBaoHiem(b_hang);
            tinhTongPhuCap(b_hang);
            tinhTongQuyThuongNangXuat(b_hang);
            tinhTongThuNhapDuKien(b_hang);
        }        
        else if ((b_cot == "TYLE_LC" || b_cot == "TYLE_TNX" || b_cot == "TYLE_DL" || b_cot == "TYLE_PT") && b_value != '') {
            var b_trso = CSO_SO(b_value);
            if (b_trso > 100) {
                if (b_cot == "TYLE_LC")
                    form_P_LOI("loi:Tỷ lệ lương cứng không được lớn hơn 100:loi");
                else if (b_cot == "TYLE_TNX")
                    form_P_LOI("loi:Tỷ lệ thưởng năng suất không được lớn hơn 100:loi");
                else if (b_cot == "TYLE_DL")
                    form_P_LOI("loi:Tỷ lệ độc lập không được lớn hơn 100:loi");
                else
                    form_P_LOI("loi:Tỷ lệ phụ thuộc không được lớn hơn 100:loi");
                b_ctr.value = '';

                //var b_hang = GridX_Fi_timHangA(b_gr_tieuChi_Id);
                //GridX_datGtri(b_gr_tieuChi_Id, b_hang, b_cot, "", "K");
            }
            if (b_cot == "TYLE_LC" || b_cot == "TYLE_TNX") {
                tinhTongQuyThuongNangXuat(b_hang);
                tinhTongThuNhapDuKien(b_hang);
            }
        }
        else if ((b_cot == "PHUCAP1" || b_cot == "PHUCAP2" || b_cot == "PHUCAP3" || b_cot == "TYLE_PT") && b_value != '') {
            tinhTongPhuCap(b_hang);
            tinhTongThuNhapDuKien(b_hang);
        }
        else if (b_cot == 'TONG_CHI_PL') {
            tinhTongThuNhapDuKien(b_hang);
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function tinhThuongDanhGiaThangHienTai(b_hang) {
    // = Thu nhập tháng – Lương cơ bản
    var b_thuNhapThang = GridX_Fas_layGtri(b_grctId, b_hang, "thu_nhap");
    var b_luongCoBan = GridX_Fas_layGtri(b_grctId, b_hang, "luong_cb");
    var b_thuongDanhGiaThangHienTai = '';
    if (b_thuNhapThang != '' && b_luongCoBan != '')
        b_thuongDanhGiaThangHienTai = b_thuNhapThang - b_luongCoBan;
    GridX_datGtri(b_grctId, b_hang, ["thuong"], [b_thuongDanhGiaThangHienTai], 'K');
}
function tinhThuongDanhGiaThangKeHoach(b_hang) {
    // = Thu nhập tháng kế hoạch – Lương cơ bản kế hoạch
    var b_thuNhapThangKeHoach = GridX_Fas_layGtri(b_grctId, b_hang, "thu_nhap_kh");
    var b_luongCoBanKeHoach = GridX_Fas_layGtri(b_grctId, b_hang, "luong_cb_kh");
    var b_thuongDanhGiaThangKeHoach = '';
    if (b_thuNhapThangKeHoach != '' && b_luongCoBanKeHoach != '')
        b_thuongDanhGiaThangKeHoach = b_thuNhapThangKeHoach - b_luongCoBanKeHoach;
    GridX_datGtri(b_grctId, b_hang, ["thuong_kh"], [b_thuongDanhGiaThangKeHoach], 'K');
}
function tinhSoThangLamViecDuKien(b_hang) {
    // = Thời gian kết thúc làm việc trong năm - Thời gian bắt đầu làm việc trong năm
    var b_ngayD = GridX_Fas_layGtri(b_grctId, b_hang, "NGAY_D_NAM"), b_ngayC = GridX_Fas_layGtri(b_grctId, b_hang, "NGAY_C_NAM");
    var b_soThangLamViecDuKien = '';
    if (b_ngayD != "" && b_ngayC != "") {
        b_ngayD = CNG_NG(b_ngayD);
        b_ngayC = CNG_NG(b_ngayC);
        b_soThangLamViecDuKien = Days360(b_ngayD, b_ngayC) / 30;
    }       
    GridX_datGtri(b_grctId, b_hang, ["thang_lv_dk"], [b_soThangLamViecDuKien], 'K');
}
function tinhSoThangThuNhapHienTai(b_hang) {
    // = Days360(Thời gian bắt đầu làm việc trong năm, Thời gian thay đổi thu nhập tháng, 1) / 30
    var b_ngayBatDauLamViecTrongNam = GridX_Fas_layGtri(b_grctId, b_hang, "NGAY_D_NAM");
    var b_ngayThayDoiThuNhapThang = GridX_Fas_layGtri(b_grctId, b_hang, "NGAY_TD");
    var b_soThangThuNhapHienTai = '';
    if (b_ngayBatDauLamViecTrongNam != '' && b_ngayThayDoiThuNhapThang != '') {
        b_ngayBatDauLamViecTrongNam = CNG_NG(b_ngayBatDauLamViecTrongNam);
        b_ngayThayDoiThuNhapThang = CNG_NG(b_ngayThayDoiThuNhapThang);
        b_soThangThuNhapHienTai = Days360(b_ngayBatDauLamViecTrongNam, b_ngayThayDoiThuNhapThang) / 30;
    }
    GridX_datGtri(b_grctId, b_hang, ["thang_tn"], [b_soThangThuNhapHienTai], 'K');
}
function tinhSoThangThuNhapThayDoi(b_hang) {
    // = Số tháng làm việc dự kiến – Số tháng thu nhập hiện tại
    var b_soThangLamViecDuKien = GridX_Fas_layGtri(b_grctId, b_hang, "thang_lv_dk");
    var b_soThangThuNhapHienTai = GridX_Fas_layGtri(b_grctId, b_hang, "thang_tn");
    var b_soThangThuNhapThayDoi = '';
    if(b_soThangLamViecDuKien != '' && b_soThangThuNhapHienTai != '')
        b_soThangThuNhapThayDoi = CSO_SO(b_soThangLamViecDuKien) - CSO_SO(b_soThangThuNhapHienTai);
    GridX_datGtri(b_grctId, b_hang, ["thang_tn_td"], [b_soThangThuNhapThayDoi], 'K');
}
function tinhKeHoachBaoHiem(b_hang) {
    // (Lương cơ bản hiện tại * Số tháng thu nhập hiện tại + Lương cơ bản kế hoạch * Số tháng thu nhập thay đổi)* tỷ lệ % BHXH, BHYT, BHTN của Người SDLĐ khai báo ở DM bảo hiểm
    var b_luongCoBanHienTai = GridX_Fas_layGtri(b_grctId, b_hang, "LUONG_CB");
    var b_soThangThuNhapHienTai = GridX_Fas_layGtri(b_grctId, b_hang, "thang_tn");
    var b_luongCoBanKeHoach = GridX_Fas_layGtri(b_grctId, b_hang, "LUONG_CB_KH");
    var b_soThangThuNhapThayDoi = GridX_Fas_layGtri(b_grctId, b_hang, "thang_tn_td");
    var b_tyLeBaoHiem = 10;
    var b_keHoachBaoHiem = '';
    if (b_luongCoBanHienTai != '' && b_soThangThuNhapHienTai != '' && b_luongCoBanKeHoach != '' && b_soThangThuNhapThayDoi != '')
        b_keHoachBaoHiem = (b_luongCoBanHienTai * b_soThangThuNhapHienTai + b_luongCoBanKeHoach * b_soThangThuNhapThayDoi) * b_tyLeBaoHiem / 100;
    GridX_datGtri(b_grctId, b_hang, ["kh_bh"], [b_keHoachBaoHiem], 'K');
}
function tinhChiPhiCongDoan(b_hang) {
    // (Lương cơ bản hiện tại * Số tháng thu nhập hiện tại + Lương cơ bản kế hoạch * Số tháng thu nhập thay đổi)* tỷ lệ % CĐ phí của Người SDLĐ khai báo ở DM bảo hiểm
    var b_luongCoBanHienTai = GridX_Fas_layGtri(b_grctId, b_hang, "LUONG_CB");
    var b_soThangThuNhapHienTai = GridX_Fas_layGtri(b_grctId, b_hang, "thang_tn");
    var b_luongCoBanKeHoach = GridX_Fas_layGtri(b_grctId, b_hang, "LUONG_CB_KH");
    var b_soThangThuNhapThayDoi = GridX_Fas_layGtri(b_grctId, b_hang, "thang_tn_td");
    var b_tyLeChiPhiCongDoan = 10;
    var b_kinhPhiCongDoan = '';
    if (b_luongCoBanHienTai != '' && b_soThangThuNhapHienTai != '' && b_luongCoBanKeHoach != '' && b_soThangThuNhapThayDoi != '')
        b_kinhPhiCongDoan = (b_luongCoBanHienTai * b_soThangThuNhapHienTai + b_luongCoBanKeHoach * b_soThangThuNhapThayDoi) * b_tyLeChiPhiCongDoan / 100;    
    GridX_datGtri(b_grctId, b_hang, ["phi_cd"], [b_kinhPhiCongDoan], 'K');
}
function tinhTongQuyThuNhapThang(b_hang) {
    // Thu nhập tháng hiện tại * Số tháng thu nhập hiện tại + Thu nhập tháng kế hoạch * Số tháng thu nhập thay đổi
    var b_thuNhapThangHienTai = GridX_Fas_layGtri(b_grctId, b_hang, "THU_NHAP");
    var b_soThangThuNhapHienTai = GridX_Fas_layGtri(b_grctId, b_hang, "thang_tn");
    var b_thuNhapThangKeHoach = GridX_Fas_layGtri(b_grctId, b_hang, "THU_NHAP_KH");
    var b_soThangThuNhapThayDoi = GridX_Fas_layGtri(b_grctId, b_hang, "thang_tn_td");
    var b_tongQuyThuNhapThang = '';
    if (b_thuNhapThangHienTai != '' && b_soThangThuNhapHienTai != '' && b_thuNhapThangKeHoach != '' && b_soThangThuNhapThayDoi != '')
        b_tongQuyThuNhapThang = CSO_SO(b_thuNhapThangHienTai) * CSO_SO(b_soThangThuNhapHienTai) + CSO_SO(b_thuNhapThangKeHoach) * CSO_SO(b_soThangThuNhapThayDoi);
    GridX_datGtri(b_grctId, b_hang, ["tongquy_tnt"], [b_tongQuyThuNhapThang], 'K');
}
function tinhTongPhuCap(b_hang) {
    // Số tháng làm việc dự kiến* (Kế hoạch phụ cấp 1 + Phụ cấp 2 + Phụ cấp 3) 
    var b_soThangLamViecDuKien = GridX_Fas_layGtri(b_grctId, b_hang, "thang_lv_dk");
    var b_phuCap1 = CSO_SO(GridX_Fas_layGtri(b_grctId, b_hang, "phucap1")), b_phuCap2 = CSO_SO(GridX_Fas_layGtri(b_grctId, b_hang, "phucap2")),
        b_phuCap3 = CSO_SO(GridX_Fas_layGtri(b_grctId, b_hang, "phucap3"));
    GridX_datGtri(b_grctId, b_hang, ["tong_pc"], [b_soThangLamViecDuKien * (b_phuCap1 + b_phuCap2 + b_phuCap3)], 'K');
}
function tinhTongQuyThuongNangXuat(b_hang) {
    // (Thu nhập tháng hiện tại * Số tháng hiện tại + Thu nhập tháng kế hoạch * Số tháng thu nhập thay đổi)* (Tỷ lệ thưởng năng suất/Tỷ lệ lương cứng)
    var b_thuNhapThangHienTai = GridX_Fas_layGtri(b_grctId, b_hang, "THU_NHAP");
    var b_soThangThuNhapHienTai = GridX_Fas_layGtri(b_grctId, b_hang, "thang_tn");
    var b_thuNhapThangKeHoach = GridX_Fas_layGtri(b_grctId, b_hang, "THU_NHAP_KH");
    var b_soThangThuNhapThayDoi = GridX_Fas_layGtri(b_grctId, b_hang, "thang_tn_td");
    var b_tyLeThuongNangXuat = GridX_Fas_layGtri(b_grctId, b_hang, "tyle_tnx");
    var b_tyLeLuongCung = GridX_Fas_layGtri(b_grctId, b_hang, "tyle_lc");
    var b_tongQuyThuongNangXuat = '';
    if (b_thuNhapThangHienTai != '' && b_soThangThuNhapHienTai != '' && b_thuNhapThangKeHoach != '' && b_soThangThuNhapThayDoi != '' && b_tyLeThuongNangXuat != '' && b_tyLeLuongCung != '')
        b_tongQuyThuongNangXuat = (CSO_SO(b_thuNhapThangHienTai) * CSO_SO(b_soThangThuNhapHienTai) + CSO_SO(b_thuNhapThangKeHoach) * CSO_SO(b_soThangThuNhapThayDoi)) * (CSO_SO(b_tyLeThuongNangXuat) / CSO_SO(b_tyLeLuongCung));
    GridX_datGtri(b_grctId, b_hang, ["tong_thuong_nx"], [b_tongQuyThuongNangXuat], 'K');
}
function tinhTongThuNhapDuKien(b_hang) {
    // Kế hoạch BHXH, BHYT, BHYN + Kinh phí công đoàn + Tổng quỹ Thu nhập tháng + Tổng phụ cấp + Tổng quỹ Thưởng Năng suất + Tổng chi phúc lợi
    var b_keHoachBaoHiem = GridX_Fas_layGtri(b_grctId, b_hang, "kh_bh");
    var b_kinhPhiCongDoan = GridX_Fas_layGtri(b_grctId, b_hang, "phi_cd");
    var b_tongQuyThuNhapThang = GridX_Fas_layGtri(b_grctId, b_hang, "tongquy_tnt");
    var b_tongPhuCap = GridX_Fas_layGtri(b_grctId, b_hang, "tong_pc");
    var b_tongQuyThuongNangXuat = GridX_Fas_layGtri(b_grctId, b_hang, "tong_thuong_nx");
    var b_tongChiPhucLoi = GridX_Fas_layGtri(b_grctId, b_hang, "TONG_CHI_PL");
    var b_tongThuNhapDuKien = CSO_SO(b_keHoachBaoHiem) + CSO_SO(b_kinhPhiCongDoan) + CSO_SO(b_tongQuyThuNhapThang) + CSO_SO(b_tongPhuCap)
            + CSO_SO(b_tongQuyThuongNangXuat) + CSO_SO(b_tongChiPhucLoi);
    GridX_datGtri(b_grctId, b_hang, ["tong_tn_dk"], [b_tongThuNhapDuKien], 'K');
}
function ns_hdns_khns_qlg_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(b_lkeCho);

        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct');
        b_nam_lke_Id = form_Fs_VTEN_ID('', 'nam_lke'),
        b_nam_Id = form_Fs_TEN_ID(b_vungId, 'NAM'),
        b_phong_Id = form_Fs_TEN_ID(b_vungId, 'PHONG'),
        b_thang_d_Id = form_Fs_TEN_ID(b_vungId, 'thang_d'),
        b_thang_c_Id = form_Fs_TEN_ID(b_vungId, 'thang_c');
        b_slideId = $get(b_grlkeId).getAttribute('slideId'); slide_P_MOI(b_slideId);
        b_slide_ct_Id = $get(b_grctId).getAttribute('slideId'); slide_P_MOI(b_slide_ct_Id);
        b_phong_an_Id = form_Fs_VTEN_ID('', 'phong_an');
        b_ngay_an_Id = form_Fs_VTEN_ID('', 'ngay_an');
        b_so_id_Id = form_Fs_VTEN_ID('', 'so_id');
        b_nsd = form_Fs_nsd();

        //GridX_taoScroll(b_grlkeId);
        //ns_hdns_khns_qlg_P_LKE();
    }
}
function ns_hdns_khns_qlg_P_LKE() {
    try {
        var b_nam = CSO_SO(lke_Fs_TRA(b_nam_lke_Id));
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_NS_HDNS_KHNS_QLG_LKE(b_nsd, b_nam, a_tso, a_cot, ns_hdns_khns_qlg_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_khns_qlg_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_hdns_khns_qlg_P_EXCEL() {
    var b_nam = CSO_SO(lke_Fs_TRA(b_nam_lke_Id));
    if (b_nam == 0) { form_P_LOI("loi:Bạn chưa chọn năm:loi"); return false; }
    var b_btn_excel = form_Fs_VTEN_ID('', 'excel_an'); $get(b_btn_excel).click(); form_chay = 0; return false;
}
function ns_hdns_khns_qlg_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_hdns_khns_qlg_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_hdns_khns_qlg_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function ns_hdns_khns_qlg_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}
function ns_hdns_khns_qlg_P_NAM_TC() {
    var b_nam = lke_Fs_TRA(b_nam_Id);
    $get(b_thang_d_Id).value = "04/" + b_nam;
    $get(b_thang_c_Id).value = "03/" + (CSO_SO(b_nam) + 1);
    $get(b_ngay_an_Id).value = "31/" + $get(b_thang_c_Id).value;
    return false;
}
function ns_hdns_khns_qlg_FILE_Import() {//import từ file Excel
    var b_tenf = '/App_form/ns/ma/file_import_hdns.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "NS_HDNS_KHNS_QLG", "NS_HDNS_KHNS_QLG", "Import kế hoạch quỹ lương"]], null);
    form_P_LOI('');
    return false;
}
function ns_hdns_khns_qlg_P_LSU() {
    var b_tenf = '/App_form/ns/hdns/khns/ns_hdns_khns_qlg_ls.aspx';
    var b_nam = lke_Fs_TRA(b_nam_Id), b_phong = lke_Fs_TRA(b_phong_Id), b_ten_phong = $get(b_phong_Id).value;
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, b_nam, b_phong, b_ten_phong]], null);
    form_P_LOI('');
    return false;
}
function form_dong() {
    location.reload(false);
}


function Days360(sd, fd, m) {
    var d1 = new Date(sd);
    var d2 = new Date(fd);
    var d1_1 = d1;
    var d2_1 = d2;
    var method = m || false;
    var d1_y = d1.getFullYear();
    var d2_y = d2.getFullYear();
    var dy = 0;
    var d1_m = d1.getMonth();
    var d2_m = d2.getMonth();
    var dm = 0;
    var d1_d = d1.getDate();
    var d2_d = d2.getDate();
    var dd = 0;
    if (method) {
        // euro
        if (d1_d == 31) d1_d = 30;
        if (d2_d == 31) d2_d = 30;
    } else {
        // american NASD
        if (d1_d == 31) d1_d = 30;
        if (d2_d == 31) {
            if (d1_d < 30) {
                if (d2_m == 11) {
                    d2_y = d2_y + 1;
                    d2_m = 0;
                    d2_d = 1;
                } else {
                    d2_m = d2_m + 1;
                    d2_d = 1;
                }
            } else {
                d2_d = 30;
            }
        }
    }
    dy = d2_y - d1_y;
    dm = d2_m - d1_m;
    dd = d2_d - d1_d;
    return parseFloat(dy * 360 + dm * 30 + dd);
}