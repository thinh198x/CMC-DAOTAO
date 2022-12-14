var ns_ma_phucloi_lkeCho, b_vungId, b_grlkeId, b_slideId, b_ma_nnnghe, b_gocId, b_so_idId, b_tenId, b_sotien_id, b_tutuoiId, b_gchuId, b_dentuoiId, b_tungayId,
    b_moiId, b_grhdId, b_denngayId, b_ngay_apDung_Id, b_grgtId, b_grgtIdb_doi = 0, b_nsd, ns_ma_phucloi_choAct = 0, b_cho_control = 0, b_ma_lvcdanh, b_ma_cdanh;
function ns_ma_phucloi_P_KD() {
    ns_ma_phucloi_lkeCho = setInterval('ns_ma_phucloi_P_LKE_CHO()', 200);
}
function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_gocId).value = b_so_the;
            $get(b_gchuId).innerHTML = b_ten;
            $get(b_gocId).focus();
            ns_ma_phucloi_P_LKE();
            b_doi = 1;
            clearTimeout(b_cho_control);
        }
    }
    catch (err) {
        b_doi = 0;
    }
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        b_doi = 0;
        switch (b_dtuong) {
            case 'CTL00_CONTENTPLACEHOLDER1_MA_NNNGHE':
                if (b_dtuong.indexOf("MA_NNNGHE") >= 0) {
                    $get(b_ma_nnnghe).value = a_tso[0];
                    //ns_ma_cdanh_P_LKE();
                    //form_P_MOI(b_vungId, "GX");
                    $get(b_gchuId).innerHTML = a_tso[1];
                }
                break;
            case 'CTL00_CONTENTPLACEHOLDER1_MA':
                if (b_dtuong.indexOf("MA") >= 0) {
                    $get(b_gocId).setAttribute("disabled", "disabled");
                    b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
                }
                break;
            case 'CTL00_CONTENTPLACEHOLDER1_THAMSO':
                if (b_dtuong.indexOf("THAMSO") >= 0) {
                    $get(b_gocId).setAttribute("disabled", "disabled");
                    b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
                }
                break;
            case 'CTL00_CONTENTPLACEHOLDER1_MA_BNNGHE':
                if (b_dtuong.indexOf("MA_BNNGHE") >= 0) {
                    $get(b_ma_bnnghe).value = a_tso[0];
                    $get(b_gchuId).innerHTML = a_tso[1];
                }
                break;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_phucloi_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
            case "MA_NNNGHE": b_maId = b_gocId; break;
            case "TUTUOI": b_maId = b_tutuoiId; break;
            case "DENTUOI": b_maId = b_dentuoiId; break;
            case "CBTUTUOI": b_maId = b_cbtutuoiId; break;
            case "CBDENTUOI": b_maId = b_cbdentuoiId; break;
            case "NGAY_D": b_maId = b_tungayId; break;
            case "NGAY_C": b_maId = b_denngayId; break;
            case "SOTIEN": b_maId = b_sotien_id; break;
            case "NG_APDUNG": b_maId = b_ngay_apDung_Id; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return true;

        switch (b_maTen) {
            case "MA": b_maId = b_gocId;
                form_P_MOI("", "XGL");
                var b_ma = $get(b_maId);
                if (b_ma == null || C_NVL(b_ma.value) == "") return;
                $get(b_gocId).value = ($get(b_gocId).value).validate_Ma();
                var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
                b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
                if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_ma_dt_P_MA_KTRA(); }
                else { GridX_datA(b_grlkeId, b_hang); ns_ma_phucloi_P_CHUYEN_HANG(); }
                b_ten.focus();
                break;
            case "MA_NNNGHE":
                // lấy danh mục bậc nghề nghiệp theo ngạch
                var b_nnnghiep = form_Fs_TEN_GTRI(b_vungId, 'MA_NNNGHE');
                sns_hdns.Fs_NS_HDNS_MA_CBNN_DROP_MA_TT(b_nsd, b_nnnghiep, "A", "ns_ma_phucloi", "DT_MA_BNNGHE", hd_ma_bnnghe_all_P_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                break;
            case "SOTIEN":
                if (C_NVL(b_ma.value.replace(",", "")).length > 20) {
                    form_P_LOI("loi:Số tiền vượt quá độ dài cho phép:loi");
                    b_ma.value = "";
                    return false;
                }
                break;
            case "TUTUOI":
                if (C_NVL($get(b_cbdentuoiId).value) == "") return true;
                var b_tuTuoi = CSO_SO($get(b_tutuoiId).value), b_denTuoi = CSO_SO($get(b_dentuoiId).value);
                if (b_tuTuoi > b_denTuoi) {
                    $get(b_tutuoiId).focus();
                    form_P_LOI("loi:Tuổi con từ không được lớn hơn tuổi con đến:loi");
                    return false;
                }
                break;
            case "DENTUOI":
                if (C_NVL($get(b_tutuoiId).value) == "") return true;
                var b_tuTuoi = CSO_SO($get(b_tutuoiId).value), b_denTuoi = CSO_SO($get(b_dentuoiId).value);
                if (b_tuTuoi > b_denTuoi) {
                    $get(b_dentuoiId).focus();
                    form_P_LOI("loi:Tuổi con từ không được lớn hơn tuổi con đến:loi");
                    return false;
                }
                break;
            case "CBTUTUOI":
                if (C_NVL($get(b_cbdentuoiId).value) == "") return true;
                var b_tuTuoi = CSO_SO($get(b_cbtutuoiId).value), b_denTuoi = CSO_SO($get(b_cbdentuoiId).value);
                if (b_tuTuoi > b_denTuoi) {
                    $get(b_cbtutuoiId).focus();
                    form_P_LOI("loi:Tuổi CB từ không được lớn hơn tuổi CB đến:loi");
                    return false;
                }
                else
                    return true;
                break;
            case "CBDENTUOI":
                if (C_NVL($get(b_tutuoiId).value) == "") return true;
                var b_tuTuoi = CSO_SO($get(b_tutuoiId).value), b_denTuoi = CSO_SO($get(b_dentuoiId).value);
                if (b_tuTuoi > b_denTuoi) {
                    $get(b_dentuoiId).focus();
                    form_P_LOI("loi:Tuổi CB từ không được lớn hơn tuổi CB đến:loi");
                    return false;
                }
                else
                    return true;
                break;
            case "NGAY_D":
                if (C_NVL($get(b_denngayId).value) == "") return true;
                var b_ngayD = CNG_SO($get(b_tungayId).value), b_ngayC = CNG_SO($get(b_denngayId).value);
                if (b_ngayD > b_ngayC) {
                    $get(b_tungayId).focus();
                    form_P_LOI("loi:Ngày hiệu lực không được lớn hơn ngày hết hiệu lực:loi");
                    return false;
                }
                else
                    return true;
                break;
            case "NGAY_C":
                if (C_NVL($get(b_tungayId).value) == "") return true;
                var b_ngayD = CNG_SO($get(b_tungayId).value), b_ngayC = CNG_SO($get(b_denngayId).value);
                if (b_ngayD > b_ngayC) {
                    $get(b_denngayId).focus();
                    form_P_LOI("loi:Ngày hiệu lực không được lớn hơn ngày hết hiệu lực:loi");
                    return false;
                }
                else
                    return true;
                break;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function hd_ma_bnnghe_all_P_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    $get(b_ma_bnnghe).value = null;
}
function ns_ma_phucloi_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}
function ns_ma_phucloi_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    var b_kytudau = "PL", b_tenbang = "NS_MA_PHUCLOI", b_tencot = "MA";
    hts_dungchung.Fs_AutoGenCode(b_kytudau, b_tenbang, b_tencot, ns_ma_phucloi_P_GENCODE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = "0"; ns_ma_P_HOPDONG(); ns_ma_P_GT();
    GridX_datTrang(b_grhdId, null, null, "chon");
    GridX_datTrang(b_grgtId, null, null, "chon");
    $get(b_gocId).focus();
    return false;
}
function ns_ma_phucloi_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        else {
            if (!ns_ma_phucloi_P_KTRA("NGAY_D")) return false;
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId),
                a_cot_hd = GridX_Fdt_cotGtri(b_grhdId),
                a_cot_gt = GridX_Fdt_cotGtri(b_grgtId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var b_so_id = $get(b_so_idId).value;
            sns_ma_ch.Fs_NS_MA_PHUCLOI_NH(b_nsd, b_so_id, b_TrangKt, a_dt_ct, a_cot_hd, a_cot_gt, a_cot_lke, ns_ma_phucloi_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_ma_phucloi_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        ns_ma_phucloi_P_CHUYEN_HANG();
        form_P_LOI("loi:Ghi thành công!:loi");
    }
    return false;
}
function ns_ma_phucloi_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa!:loi"); return false; }
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa!:loi"); ns_ma_phucloi_P_MOI(); }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_NS_MA_PHUCLOI_XOA(b_nsd, b_so_id, a_tso, a_cot, ns_ma_phucloi_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_ma_phucloi_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
        var b_dong = GridX_Fi_hangSo(b_grlkeId);
        if (b_hang > b_dong) b_hang = b_dong;
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_ma_phucloi_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_ma_phucloi_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
}
function ns_ma_phucloi_GR_lke_RowChange() {
    if (ns_ma_phucloi_choAct != 0) clearTimeout(ns_ma_phucloi_choAct);
    ns_ma_phucloi_choAct = setTimeout("ns_ma_phucloi_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_ma_phucloi_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "") { ns_ma_phucloi_P_MOI(); GridX_datA(b_grlkeId, b_hang); }
    else {
        var a_cot_gt = GridX_Fas_tenCot(b_grgtId),
           a_cot_lhd = GridX_Fas_tenCot(b_grhdId);
        sns_ma_ch.Fs_NS_MA_PHUCLOI_CT(b_nsd, b_so_id, a_cot_lhd, a_cot_gt, ns_ma_phucloi_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    $get(b_so_idId).value = b_so_id;
}
function ns_ma_phucloi_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    //form_P_CH_TEXT(b_vungId, b_kq);
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grgtId); else GridX_datBang(b_grgtId, a_kq[1]);
    if (a_kq[2] == "") GridX_datTrang(b_grhdId); else GridX_datBang(b_grhdId, a_kq[2]);
}
function ns_ma_phucloi_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
       b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'),
       b_ma_lvcdanh = form_Fs_TEN_ID(b_vungId, 'MA_LVCDANH'),
       b_ma_cdanh = form_Fs_TEN_ID(b_vungId, 'MA_CDANH'),
       b_tenId = form_Fs_TEN_ID(b_vungId, 'ten'),
       b_sotien_id = form_Fs_TEN_ID(b_vungId, 'SOTIEN'),
       b_tutuoiId = form_Fs_TEN_ID(b_vungId, 'tutuoi'),
       b_dentuoiId = form_Fs_TEN_ID(b_vungId, 'dentuoi'),
       b_cbdentuoiId = form_Fs_TEN_ID(b_vungId, 'cbdentuoi'),
       b_cbtutuoiId = form_Fs_TEN_ID(b_vungId, 'cbtutuoi'),
       b_tungayId = form_Fs_TEN_ID(b_vungId, 'ngay_d'), b_denngayId = form_Fs_TEN_ID(b_vungId, 'ngay_c'),
        //b_ngay_apDung_Id = form_Fs_TEN_ID(b_vungId, 'NG_APDUNG'),
       b_grhdId = form_Fs_VUNG_ID('GR_hd'), b_grgtId = form_Fs_VUNG_ID('GR_gt');
        b_gchuId = form_Fs_VTEN_ID('', 'gchu');
        b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
        b_moiId = form_Fs_VTEN_ID('', 'moi');
        b_slideId = $get(b_grlkeId).getAttribute('slideId'); slide_P_MOI(b_slideId);
        if (ns_ma_phucloi_lkeCho != 0) clearTimeout(ns_ma_phucloi_lkeCho);
        b_nsd = form_Fs_nsd();
        ns_ma_phucloi_P_LKE();
    }
}
function ns_ma_phucloi_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_NS_MA_PHUCLOI_LKE(b_nsd, a_tso, a_cot, ns_ma_phucloi_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        ns_ma_P_HOPDONG();
        ns_ma_P_GT();
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_phucloi_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_ma_phucloi_P_GENCODE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        $get(b_gocId).value = b_kq;
    }
}
function ns_ma_P_HOPDONG() {
    var a_cot = GridX_Fas_tenCot(b_grhdId);
    sns_ma_ch.Fs_NS_MA_DAT_LHD(a_cot, ns_ma_P_HOPDONG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function ns_ma_P_HOPDONG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    if (a_kq[0] == "")
        GridX_datTrang(b_grhdId);
    else
        GridX_datBang(b_grhdId, a_kq[0]);
    return false;
}
function ns_ma_phucloi_Gr_gt_RowChange() {
    GridX_datTrang(b_grgtId, null, null, "chon");
    b_hang = GridX_Fi_timHangA(b_grgtId);
    GridX_datGtri(b_grgtId, b_hang, ["chon"], ["X"]);
    return false;
}
function ns_ma_P_GT() {
    var a_cot = GridX_Fas_tenCot(b_grgtId);
    sns_ma_ch.Fs_NS_MA_DAT_GT(a_cot, ns_ma_P_GT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function ns_ma_P_GT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == "") { GridX_datTrang(b_grgtId); GridX_datBang(b_grgtId, b_kq); } else GridX_datBang(b_grgtId, b_kq);
    return false;
}
function ns_phucloi_hd_CHON() {
    var j = 0;
    var b_ktra = GridX_Fdt_cotGtri(b_grhdId, ["chon", "ma"]);
    var b_gt = b_ktra[1];
    for (var i = 0; i < b_gt.length; i++) {
        if (b_gt[i][0] == "X") { j++; }
    }
    if (j == 0) {
        for (var i = 0; i < b_gt.length; i++) {
            if (b_gt[i][1] != "") {
                GridX_datGtri(b_grhdId, i + 1, ["chon"], ["X"]);
            }
        }
    }
    else {
        for (var i = 0; i < b_gt.length; i++) {
            GridX_datGtri(b_grhdId, i + 1, ["chon"], [""]);
        }
    }
}
function ns_phucloi_hd_HangLen() {
    GridX_chuyenHang(b_grhdId, -1);
    return false;
}
function ns_phucloi_hd_HangXuong() {
    GridX_chuyenHang(b_grhdId, 1);
    return false;
}
function ns_phucloi_hd_chenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grhdId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grhdId);
    return false;
}
function ns_phucloi_hd_CatDong() {
    GridX_boChon(b_grhdId, 'C');
    return false;
}
function ns_phucloi_gt_CHON() {
    var j = 0;
    var b_ktra = GridX_Fdt_cotGtri(b_grgtId, ["chon", "ten"]);
    var b_gt = b_ktra[1];
    for (var i = 0; i < b_gt.length; i++) {
        if (b_gt[i][0] == "X") { j++; }
    }
    if (j == 0) {
        for (var i = 0; i < b_gt.length; i++) {
            if (b_gt[i][1] != "") {
                GridX_datGtri(b_grgtId, i + 1, ["chon"], ["X"]);
            }
        }
    }
    else {
        for (var i = 0; i < b_gt.length; i++) {
            GridX_datGtri(b_grgtId, i + 1, ["chon"], [""]);
        }
    }
}
function ns_phucloi_gt_HangLen() {
    GridX_chuyenHang(b_grgtId, -1);
    return false;
}
function ns_phucloi_gt_HangXuong() {
    GridX_chuyenHang(b_grgtId, 1);
    return false;
}
function ns_phucloi_gt_chenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grgtId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grgtId);
    return false;
}
function ns_phucloi_gt_CatDong() {
    GridX_boChon(b_grgtId, 'C');
    return false;
}
function ns_ma_phucloi_P_EXCEL() {
    __doPostBack('ctl00$ContentPlaceHolder1$Nhap2', '');//Xuất Excel
}
function form_dong() {
    location.reload(false);
}