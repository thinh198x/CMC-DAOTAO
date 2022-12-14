var ns_cc_dky_lthem_lkeCho, b_vungId, b_vungtkId, b_grlkeId, b_XuatEId, b_vungngayId, ns_cc_dky_lthem_choAct = 0, b_loi = 1, b_gionghibdId, b_gionghiktId, b_hinhthucId, b_slideId,
    b_gocId, b_tuoiId, b_sogio_ngayId, b_sogio_ngay_nbId, b_so_the_tkId, b_ten_tkId, b_phong_tkId, b_vungTkId, b_sogio_demId, b_sogio_dem_nbId, b_gioktId, b_sogio_ttId, b_so_idId,
    b_giobdId, b_gchuId, b_moiId, b_nsd, b_ten, b_ngaydkyId, b_loaidkyId, b_sothe_tkId, b_hoten_tkId, b_ngayd_tk, b_ngayc_tk, b_phong_tkId, b_sogio_nbId, b_ctyId, b_ctyValue, b_ctrbeforId,
    b_cdanhId, b_lthem_theoluatId, b_hsoId, b_sogio_nghigiuacaId;
function ns_cc_dky_lthem_P_KD(b_xuatexcelId) {
    b_XuatEId = b_xuatexcelId;
    ns_cc_dky_lthem_lkeCho = setInterval('ns_cc_dky_lthem_P_LKE_CHO()', 200);
}
// Kiểm tra
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "" || a_tso[0] == "FILE_HTOAN") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            $get(b_gocId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            ns_cc_dky_lthem_P_LKE('K');
            $get(b_gocId).focus();
            ns_cc_dky_lthem_P_CB();
        } else if (b_dtuong.indexOf("TAI_IMPORT") >= 0) {
            ns_cc_dky_lthem_P_LKE('K');
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_dky_lthem_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; form_P_MOI("", "XGL"); break;
            case "LOAI_DKY": b_maId = b_loaidkyId; break;
            case "NGAY_BD": b_maId = b_ngaydkyId; break;
            case "GIO_BD": b_maId = b_giobdId; break;
            case "GIO_KT": b_maId = b_gioktId; break;
            case "SOGIO_NGHIGIUACA": b_maId = b_sogio_nghigiuacaId; break;
            case "SG_NGAY_NB": b_maId = b_sogio_ngay_nbId; break;
            case "SG_DEM_NB": b_maId = b_sogio_dem_nbId; break;
        }
        var b_ma = $get(b_maId);
        if ((b_ma == null || C_NVL(b_ma.value) == "") && !(b_maTen == "SG_NGAY_NB" || b_maTen == "SG_DEM_NB")) return;
        if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_cc_dky_lthem_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_cc_dky_lthem_P_CB();
            ns_cc_dky_lthem_P_LKE('K');
        } else if (b_maTen == "NGHI_GCT" || b_maTen == "NGHI_GCD") {
            tinh_thoigian();
        } else if (b_maTen == "NGAY_BD") {
            //ns_cc_dky_lthem_laydulieu();
            ns_cc_dky_lthem_hinhthuc();
            var ktraky = ktra_ngay(parseDate($get(b_ngaybdId).value).getTime(), parseDate($get(b_ngayktId).value).getTime(), 1, "Ngày bắt đầu", "ngày kết thúc");
            if (ktraky.length > 0) {
                $get(b_ngaybdId).value = "";
                form_P_LOI(ktraky);
                return false;
            }
            tinh_thoigian();
        }
        else if (b_maTen == "GIO_BD") {
            if (!isTime(b_ma)) {
                form_P_LOI("loi:Từ giờ không đúng định dạng!:loi");
                return false;
            }
            else { tinh_thoigian(); return true; }
        }
        else if (b_maTen == "GIO_KT") {
            if (!isTime(b_ma)) {
                form_P_LOI("loi:Đến giờ không đúng định dạng!:loi");
                return false;
            }
            else { tinh_thoigian(); return true; }

        } else if (b_maTen == "SOGIO_NGHIGIUACA") {
            tinh_thoigian(); return true;
        } else if (b_maTen == "KYLUONG_TK") {
            ns_cc_dky_lthem_P_LKE('K');
        } else if (b_maTen == "SG_NGAY_NB") {
            if (CSO_SO($get(b_sogio_ngayId).value, 2) < CSO_SO($get(b_sogio_ngay_nbId).value, 2)) {
                $get(b_sogio_ngay_nbId).value = '';
                form_P_LOI("loi:Số giờ làm thêm ngày chuyển nghỉ bù không được lớn hơn số giờ làm thêm ngày:loi");
                return false;
            }
            $get(b_sogio_ttId).value = CSO_SO($get(b_sogio_ngayId).value, 2) - CSO_SO($get(b_sogio_ngay_nbId).value, 2) + CSO_SO($get(b_sogio_demId).value, 2) - CSO_SO($get(b_sogio_dem_nbId).value, 2);
        }
        else if (b_maTen == "SG_DEM_NB") {
            if (CSO_SO($get(b_sogio_demId).value, 2) < CSO_SO($get(b_sogio_dem_nbId).value, 2)) {
                $get(b_sogio_dem_nbId).value = '';
                form_P_LOI("loi:Số giờ làm thêm đêm chuyển nghỉ bù không được lớn hơn số giờ làm thêm đêm:loi");
                return false;
            }
            $get(b_sogio_ttId).value = CSO_SO($get(b_sogio_ngayId).value, 2) - CSO_SO($get(b_sogio_ngay_nbId).value, 2) + CSO_SO($get(b_sogio_demId).value, 2) - CSO_SO($get(b_sogio_dem_nbId).value, 2);
        }
        //ns_cc_dky_lthem_P_CT();
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_dky_lthem_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}
// Nhập
function ns_cc_dky_lthem_P_MOI() {
    form_P_MOI(b_vungId, "GXLK");
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = "0";
    $get(b_gocId).focus();
    ns_cc_dky_lthem_check_cdanh("M");
    return false;
}
function ns_cc_dky_lthem_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId); b_so_id = '0';
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 0) b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        var b_so_the = $get(b_sothe_tkId).value, b_hoten = $get(b_hoten_tkId).value; b_ngayd = $get(b_ngayd_tk).value, b_ngayc = $get(b_ngayc_tk).value, b_phong = b_ctyValue;
        stl_cc.Fs_NS_CC_DKY_LTHEM_NH(form_Fs_nsd(), b_so_id, b_so_the, b_hoten, b_ngayd, b_ngayc, b_phong, b_TrangKt, a_dt_ct, a_cot_lke, ns_cc_dky_lthem_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { throw (err); }
}
function ns_cc_dky_lthem_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[1]) + 1, b_trang = CSO_SO(a_kq[2]), b_soDong = CSO_SO(a_kq[3]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[4]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI('loi:Nhập thành công!:loi')
    }
    return false;
}
// Xóa
function ns_cc_dky_lthem_P_XOA() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
        var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"),
            b_so_the = $get(b_gocId).value;
        if (b_so_id == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); ns_cc_dky_lthem_P_MOI(); return false; }
        else {
            var b_dtuong_nh = GridX_Fas_layGtri(b_grlkeId, b_hang, "dtuong_nh");
            if (b_dtuong_nh == 'Cá nhân') {
                form_P_LOI("loi:Không thể xóa bản ghi của cá nhân đăng ký:loi"); ns_cc_dky_lthem_P_MOI(); return false;
            }
            else {
                var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
                var b_so_the = $get(b_sothe_tkId).value, b_hoten = $get(b_hoten_tkId).value; b_ngayd = $get(b_ngayd_tk).value, b_ngayc = $get(b_ngayc_tk).value, b_phong = b_ctyValue;
                stl_cc.Fs_NS_CC_DKY_LTHEM_XOA(form_Fs_nsd(), b_so_id, b_so_the, b_hoten, b_ngayd, b_ngayc, b_phong, a_tso, a_cot, ns_cc_dky_lthem_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);

            }
        }
    }
    catch (err) { throw (err); }
    return false;
}
function ns_cc_dky_lthem_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_cc_dky_lthem_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_cc_dky_lthem_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
        return false;

    }
}
// Chuyển hàng
function ns_cc_dky_lthem_GR_lke_RowChange() {
    if (ns_cc_dky_lthem_choAct != 0) clearTimeout(ns_cc_dky_lthem_choAct);
    ns_cc_dky_lthem_choAct = setTimeout("ns_cc_dky_lthem_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_cc_dky_lthem_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_the = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    var b_ngay_bd = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "NGAY_BD"));
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_the == "") form_P_MOI(b_vungId, "XGLK");
    else stl_cc.Fs_NS_CC_DKY_LTHEM_CT(form_Fs_nsd(), b_so_id, b_ngay_bd, ns_cc_dky_lthem_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = b_so_id;
}
function ns_cc_dky_lthem_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    ns_cc_dky_lthem_check_cdanh("CT");
}
// Liệt kê
function ns_cc_dky_lthem_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        ns_cc_dky_lthem_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungTkId = form_Fs_VUNG_ID('UPa_tk');
        b_vungngayId = form_Fs_VUNG_ID('UPa_ngay'), b_vungtkId = form_Fs_VUNG_ID('UPa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
        b_sothe_tkId = form_Fs_TEN_ID(b_vungtkId, 'so_the_tk'), b_hoten_tkId = form_Fs_TEN_ID(b_vungtkId, 'ten_tk'), b_ngayd_tk = form_Fs_TEN_ID(b_vungtkId, 'ngayd_tk');
        b_ngayc_tk = form_Fs_TEN_ID(b_vungtkId, 'ngayc_tk'), b_phong_tkId = form_Fs_TEN_ID(b_vungtkId, 'phong_tk');
        b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE'); b_ngaydkyId = form_Fs_TEN_ID(b_vungId, 'NGAY_BD');
        b_gchuId = form_Fs_VTEN_ID('', 'gchu'); b_giobdId = form_Fs_TEN_ID(b_vungId, 'GIO_BD'); b_gioktId = form_Fs_TEN_ID(b_vungId, 'GIO_KT');
        b_sogio_ngayId = form_Fs_TEN_ID(b_vungId, 'so_gio_ngay'); b_sogio_demId = form_Fs_TEN_ID(b_vungId, 'so_gio_dem');
        b_sogio_ngay_nbId = form_Fs_TEN_ID(b_vungId, 'sg_ngay_nb'); b_sogio_dem_nbId = form_Fs_TEN_ID(b_vungId, 'sg_dem_nb');
        b_sogio_ttId = form_Fs_TEN_ID(b_vungId, 'so_gio_tt'), b_cdanhId = form_Fs_TEN_ID(b_vungId, 'cdanh');
        b_lthem_theoluatId = form_Fs_TEN_ID(b_vungId, 'lthem_theoluat');
        b_so_the_tkId = form_Fs_TEN_ID(b_vungTkId, 'so_the_tk'), b_ten_tkId = form_Fs_TEN_ID(b_vungTkId, 'ten_tk');
        b_hsoId = form_Fs_TEN_ID(b_vungId, 'hso'), b_sogio_nghigiuacaId = form_Fs_TEN_ID(b_vungId, 'sogio_nghigiuaca');
        b_so_idId = form_Fs_VTEN_ID('', 'so_id'), b_hinhthucId = form_Fctr_TEN_DTUONG(b_vungId, 'hinhthuc');
        b_slideId = b_grlkeId + '_slide';
        if (ns_cc_dky_lthem_lkeCho != 0) clearTimeout(ns_cc_dky_lthem_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        lke_P_DAT($get(b_phong_tkId), 'TATCA' + '{' + 'Tất cả');
        form_F_GOC().P_MENUBf(window.name, 'M');
        vb_cctc_P_SL('', 'D', '0', ' ', ' ', 'T');
        b_ctyValue = "TATCA";
        ns_cc_dky_lthem_P_LKE('K');
    }
}
function ns_cc_dky_lthem_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_so_the = $get(b_gocId).value, b_thang = "";
        b_so_the = $get(b_sothe_tkId).value, b_hoten = $get(b_hoten_tkId).value; b_ngayd = $get(b_ngayd_tk).value, b_ngayc = $get(b_ngayc_tk).value, b_phong = b_ctyValue;
        stl_cc.Fs_NS_CC_DKY_LTHEM_LKE(form_Fs_nsd(), b_so_the, b_hoten, b_ngayd, b_ngayc, b_phong, a_tso, a_cot, ns_cc_dky_lthem_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_dky_lthem_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#'); slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
}
// lay thong tin cán bộ
function ns_cc_dky_lthem_P_CB() {
    try {
        var b_so_the = $get(b_gocId).value;
        hts_dungchung.Fs_THONGTIN_CANBO(b_so_the, ns_cc_dky_lthem_P_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_dky_lthem_P_CB_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    ns_cc_dky_lthem_check_cdanh("M");
    return false;
}
// lấy hình thức
function ns_cc_dky_lthem_hinhthuc() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_ngaydkyId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var b_ngaykd = $get(b_ngaydkyId).value;
        stl_cc.Fs_LAY_HINHTHUC_LT(form_Fs_nsd(), b_ngaykd, ns_cc_dky_lthem_hinhthuc_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_dky_lthem_hinhthuc_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    list_P_DAT(b_hinhthucId, b_kq);
    return false;
}

// Kiểm tra chức danh 
function ns_cc_dky_lthem_check_cdanh(b_dk) {
    try {
        var b_cdanh = $get(b_cdanhId).value;
        if (b_cdanh == "") return false;
        else if (b_cdanh == "CD.035") { // truong hop la lai xe
            if (b_dk != "CT") {
                var b_drop = form_Fctr_TEN_DTUONG(b_vungId, 'lthem_theoluat');
                list_P_DAT(b_drop, 'K');
            }
            document.getElementById(b_lthem_theoluatId).disabled = false;
            $get(b_hsoId).value = "LX";
        }
        else if (b_cdanh == "CD123" || b_cdanh == "CD124") { // truong hop la IT
            if (b_dk != "CT") {
                var b_drop = form_Fctr_TEN_DTUONG(b_vungId, 'lthem_theoluat');
                list_P_DAT(b_drop, 'C');
            }
            document.getElementById(b_lthem_theoluatId).disabled = false;
            $get(b_hsoId).value = "IT";
        }
        else {
            if (b_dk != "CT") {
                var b_drop = form_Fctr_TEN_DTUONG(b_vungId, 'lthem_theoluat');
                list_P_DAT(b_drop, 'C');
            }
            document.getElementById(b_lthem_theoluatId).disabled = true;
            $get(b_hsoId).value = "BT";
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
// lấy dữ liệu cũ
function ns_cc_dky_lthem_laydulieu() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_ngaydkyId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var b_ngaykd = $get(b_ngaydkyId).value; var b_sothe = $get(b_gocId).value;
        //stl_cc.Fs_LAY_DULIEUDKY_LT(form_Fs_nsd(), b_ngaykd, b_sothe, ns_cc_dky_lthem_laydulieu_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_dky_lthem_laydulieu_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}

function ns_cc_dky_lthem_P_CT() {
    var b_ngaydky = $get(b_ngaydkyId).value;
    var b_loaidky = $get(b_loaidkyId).value;
    if (b_ngaydky == "" || b_ngaydky == null || b_loaidky == "" || b_loaidky == null) { form_P_MOI("", "XGL"); return; }
    else stl_cc.Fs_NS_CC_DKY_LTHEM_CT2(form_Fs_nsd(), b_ngaydky, b_loaidky, ns_cc_dky_lthem_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = b_so_id;
}
function ns_cc_dky_lthem_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function ns_cc_dky_lthem_P_MAU() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'btn_excel_mau');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;

}
function ns_cc_dky_lthem_FILE_Import() {
    form_P_DONG('file_import');
    var b_tenf = '/App_form/ns/ma/file_Import.aspx';
    form_P_MO(b_tenf, window.name + ',THAMSO', ['THAMSO', [window.name, 'KHAIBAO_LAMTHEM_IMP', null, "Import khai báo làm thêm"]], null);
    form_P_LOI('');
    return false;
}
function ns_cc_dky_lthem_P_NGAY(str) {
    var mdy_str = str.split('/');
    var mdy_str = mdy_str[2] + mdy_str[1] + mdy_str[0];
    var mdy_str = parseInt(mdy_str);
    var dateht = new Date();
    var m = "0" + (1 + dateht.getMonth());
    var y = parseInt("2" + dateht.getYear()) - 100;
    var d = parseInt("0" + dateht.getDate());
    var dmy = y + m + d;
    var dmy = parseInt(dmy);
    var kq = mdy_str - dmy;
    if (kq > 0) {
        return 'loi:Ngày làm thêm không được lớn hơn ngày hiện tại:loi';
    }
    return "";
}
function cc_kiemtra_gio() {
    try {
        var b_giobd = $get(b_giobdId).value, b_giokt = $get(b_gioktId).value;
        stl_cc.Fs_KIEMTRA_GIO(form_Fs_nsd(), b_giobd, b_giokt, cc_kiemtra_gio_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function cc_kiemtra_gio_kq(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    $get(b_sogioId).value = b_kq;
    return false;
}
function tinh_thoigian() {
    var b_gbd = $get(b_giobdId).value,
        b_gkt = $get(b_gioktId).value;
    var b_gio_bd = b_gbd.substring(0, 2), b_phut_bd = b_gbd.substring(3, 5);
    var b_gio_kt = b_gkt.substring(0, 2), b_phut_kt = b_gkt.substring(3, 5);


    var b_gio_them = 0, b_gio_dem = 0;
    var b_phut_dau = 0, b_phut_cuoi = 0;

    var b_gio_them_n = 0, b_gio_dem_n = 0;
    var b_hinhthuc = form_Fctr_TEN_DTUONG(b_vungId, 'hinhthuc').value;
    if (b_gio_bd >= 0 && b_gio_kt >= 0) {
        stl_cc.Fs_GIO_DANGKY_HOI(b_gbd, b_gkt, tl_gio_dangky_P_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        // lấy giờ làm  
        if (b_gio_bd <= b_gio_kt) {
            if (b_gio_kt >= 22) {
                if (b_gio_bd < 6) {
                    b_gio_dem = ((parseFloat(b_gio_kt) - 22) * 60 + parseFloat(b_phut_kt)) / 60;
                    b_gio_dem = b_gio_dem + (6 * 60 - (parseFloat(b_gio_bd)) * 60 + parseFloat(b_phut_bd)) / 60;
                    b_gio_them = ((22 * 60) - (6 * 60)) / 60;
                } else {
                    b_gio_dem = ((parseFloat(b_gio_kt) - 22) * 60 + parseFloat(b_phut_kt)) / 60;
                    b_gio_them = ((22 * 60) - (parseFloat(b_gio_bd) * 60 + parseFloat(b_phut_bd))) / 60;
                }
            }
            else if (b_gio_bd < 6 && b_gio_kt < 6) {
                b_gio_dem = ((parseFloat(b_gio_kt) * 60 + parseFloat(b_phut_kt)) - (parseFloat(b_gio_bd) * 60 + parseFloat(b_phut_bd))) / 60;
                b_gio_them = ((parseFloat(b_gio_kt) * 60 + parseFloat(b_phut_kt)) - (parseFloat(b_gio_bd) * 60 + parseFloat(b_phut_bd))) / 60 - b_gio_dem;
            }
            else if (b_gio_bd < 6 && b_gio_kt >= 6) {
                b_gio_dem = 6 - (parseFloat(b_gio_bd) * 60 + parseFloat(b_phut_bd)) / 60;
                b_gio_them = ((parseFloat(b_gio_kt) * 60 + parseFloat(b_phut_kt)) - (parseFloat(b_gio_bd) * 60 + parseFloat(b_phut_bd))) / 60 - b_gio_dem;
            } else if (b_gio_bd >= 6) {
                b_gio_dem = 0;
                b_gio_them = ((parseFloat(b_gio_kt) * 60 + parseFloat(b_phut_kt)) - (parseFloat(b_gio_bd) * 60 + parseFloat(b_phut_bd))) / 60;
            }
        } else {
            b_gio_them = (((parseFloat(b_gio_kt) + 24) * 60 + parseFloat(b_phut_kt)) - (parseFloat(b_gio_bd) * 60 + parseFloat(b_phut_bd))) / 60;
            if (b_gio_bd >= 22 && b_gio_kt <= 6) {
                b_gio_dem = ((24 - parseFloat(b_gio_bd)) * 60 - (parseFloat(b_phut_bd))) / 60;
                b_gio_dem = b_gio_dem + ((parseFloat(b_gio_kt)) * 60 + parseFloat(b_phut_kt)) / 60;
                b_gio_them = 0;
            } else if (b_gio_bd >= 22 && b_gio_kt > 6) {
                b_gio_dem = ((24 - parseFloat(b_gio_bd)) * 60 + (parseFloat(b_phut_kt))) / 60;
                b_gio_dem = b_gio_dem + ((parseFloat(b_gio_kt)) * 60 + parseFloat(b_phut_kt)) / 60;
                b_gio_them = ((parseFloat(b_gio_kt) - 6) * 60 + parseFloat(b_phut_kt)) / 60;
            }
            else if (b_gio_bd < 22 && b_gio_kt <= 6) {
                b_gio_them = ((22 * 60) - (parseFloat(b_gio_bd) * 60 + parseFloat(b_phut_bd))) / 60;
                b_gio_dem = ((24 - 22) * 60) / 60;
                b_gio_dem = b_gio_dem + ((parseFloat(b_gio_kt)) * 60 + parseFloat(b_phut_kt)) / 60;
            } else if (b_gio_bd < 22 && b_gio_kt > 6) {
                b_gio_them = ((22 * 60) - (parseFloat(b_gio_bd) * 60 + parseFloat(b_phut_bd))) / 60;
                b_gio_them = b_gio_them + ((parseFloat(b_gio_kt) - 6) * 60 + parseFloat(b_phut_kt)) / 60;
                b_gio_dem = ((24 - 22) * 60) / 60;
                b_gio_dem = b_gio_dem + ((6) * 60 + parseFloat(0)) / 60;
            }
        }


        var b_them_g = 0, b_them_p = 0, b_dem_g = 0, b_dem_p = 0;
        b_them_g = Math.floor(b_gio_them);
        b_them_p = parseFloat(b_gio_them) - parseFloat(b_them_g).toFixed(2);
        //if (b_them_p < 0.25) b_them_p = 0;
        //if (b_them_p < 0.5 && b_them_p >= 0.25) b_them_p = 0.25;
        //if (b_them_p < 0.75 && b_them_p >= 0.5) b_them_p = 0.5;
        //if (b_them_p < 1 && b_them_p >= 0.75) b_them_p = 0.75;
        b_gio_them = parseFloat(b_them_g) + parseFloat(b_them_p.toFixed(2));

        b_dem_g = Math.floor(b_gio_dem);
        b_dem_p = parseFloat(b_gio_dem) - parseFloat(b_dem_g.toFixed(2));
        //if (b_dem_p < 0.25) b_dem_p = 0;
        //if (b_dem_p < 0.5 && b_dem_p >= 0.25) b_dem_p = 0.25;
        //if (b_dem_p < 0.75 && b_dem_p >= 0.5) b_dem_p = 0.5;
        //if (b_dem_p < 1 && b_dem_p >= 0.75) b_dem_p = 0.75;
        b_gio_dem = parseFloat(b_dem_g) + parseFloat(b_dem_p.toFixed(2));
        if (isNaN(b_gio_them) || isNaN(b_gio_dem)) return;
        $get(b_sogio_ngayId).value = (b_gio_them < 0 ? 0 : b_gio_them);
        $get(b_sogio_demId).value = (b_gio_dem < 0 ? 0 : b_gio_dem);
        if (CSO_SO($get(b_sogio_ngay_nbId).value) > (b_gio_them < 0 ? 0 : b_gio_them)) {
            $get(b_sogio_ngay_nbId).value = '';
        }
        if (CSO_SO($get(b_sogio_dem_nbId).value) > (b_gio_dem < 0 ? 0 : b_gio_dem)) {
            $get(b_sogio_dem_nbId).value = '';
        }
        var b_so_gio_cuoi; 
        var b_so_gio = (b_gio_them < 0 ? 0 : b_gio_them) - CSO_SO($get(b_sogio_ngay_nbId).value) + (b_gio_dem < 0 ? 0 : b_gio_dem) - CSO_SO($get(b_sogio_dem_nbId).value);

        if (b_so_gio >= 7) {
            b_so_gio_cuoi = b_so_gio - 1;
            $get(b_sogio_nghigiuacaId).value = 1;
        } else {
            b_so_gio_cuoi = b_so_gio;
            $get(b_sogio_nghigiuacaId).value = 0;
        } 
        $get(b_sogio_ttId).value = b_so_gio_cuoi;
    }
}
function tl_gio_dangky_P_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { b_loi = 0; form_P_LOI(b_kq); return false; }
}
function sendMail(b_tso) {
    var a_tso = Fas_ChMang(b_tso, ';');
    var b_toAddress = a_tso[0],
        b_subject = a_tso[1],
        b_body = a_tso[2];
    if (b_toAddress == "" || b_toAddress == null || b_toAddress == undefined) return false;
    else {
        sSmtpMail.SendMail(b_toAddress, b_subject, b_body, sendMail_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
}
function sendMail_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); return false;
}
function ns_cc_dky_lthem_P_NAM() {
    try {
        var b_nam = form_Fs_TEN_GTRI(b_vungTkId, 'NAM_TK');
        if (b_nam != "")
            stl_cc.Fs_NS_KYLUONG_CHUNG2_LKE(form_Fs_nsd(), window.name, b_nam, ns_cc_dky_lthem_P_NAM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_cc_dky_lthem_P_NAM_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        ns_cc_dky_lthem_P_KTRA("KYLUONG_TK");
    }
}
function ktra_ngay(tungay, denngay, loai, ten1, ten2) {
    if (denngay == "" || denngay == null) {
        return "";
    }
    if (loai == 1 && tungay > denngay) {
        return "loi: " + ten1 + " không được lớn hơn " + ten2 + " :loi";
    } else if (loai == 2 && tungay >= denngay) {
        return "loi: " + ten1 + " không được lớn hơn hoặc bằng " + ten2 + " :loi";
    }
    return "";
}
function parseDate(str) {
    var mdy = str.split('/');
    return new Date(mdy[2], mdy[1], mdy[0]);
}
function isTime(txtHour) {
    var data = C_NVL(txtHour.value);
    if (data == "") return true;

    if (data.indexOf(":") < 0) {
        data = formatTime(data);
        if (data != '')
            txtHour.value = data;
        else {
            txtHour.value = "";
            return false;
        }
    }

    var rxHourPattern = /^(\d{1,2})(:)(\d{1,2})$/;
    var dtArray = data.match(rxHourPattern); // is format OK?
    if (dtArray == null) {
        rxHourPattern = /^(\d{1,2})$/;
        dtArray = data.match(rxHourPattern);
    }
    if (dtArray == null) {
        txtHour.value = "";
        return false;
    }
    //Checks for hh:mm format.
    const hour = parseInt(dtArray[1], 10);
    var minute = 0;
    if (dtArray.length >= 4)
        minute = parseInt(dtArray[3], 10);
    if (hour < 0 || hour >= 24 || minute < 0 || minute >= 60) {
        txtHour.value = "";
        return false;
    }
    txtHour.value = pad(hour) + ":" + pad(minute);
    return true;
}
function ktra_ngay(tungay, denngay, loai, ten1, ten2) {
    if (denngay == "" || denngay == null) {
        return "";
    }
    if (loai == 1 && tungay > denngay) {
        return "loi: " + ten1 + " không được lớn hơn " + ten2 + " :loi";
    } else if (loai == 2 && tungay >= denngay) {
        return "loi: " + ten1 + " không được lớn hơn hoặc bằng " + ten2 + " :loi";
    }
    return "";
}
function parseDate(str) {
    var mdy = str.split('/');
    return new Date(mdy[2], mdy[1], mdy[0]);
}
function getDateNow() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();
    if (dd < 10) {
        dd = '0' + dd;
    }
    if (mm < 10) {
        mm = '0' + mm;
    }
    var datenow = dd + '/' + mm + '/' + yyyy;
    return datenow;
}
function formatTime(data) {
    if (data.indexOf(":") >= 0) return data;

    var b_length = data.length;
    if (b_length < 4) {
        if (b_length == 0)
            data = "00:00";
        else if (b_length == 1)
            data = "0" + data + ":00";
        else if (b_length == 2)
            data = data + ":00";
        else if (b_length == 3)
            data = data.substr(0, 2) + ":0" + data.substr(2);
    }
    else data = data.substr(0, 2) + ':' + data.substr(2);
    return data;
}
function pad(s) { return (s < 10) ? '0' + s : s; }

function vb_cctc_P_CLICK(b_event, b_id) {
    b_event.stopPropagation();
    var b_targetClassNam = b_event.target.className;
    if (b_targetClassNam == "ico_bptt") {
        var b_ctr = $get(b_id), b_div = $get(b_id + '_Div');
        var a_tso = Attribute_Fas_LAY(b_ctr, 'loai,cap,dvi,ma,ma_ct');
        if (b_ctrbeforId != null) b_ctrbeforId.style.fontWeight = "100";
        b_ctr.style.fontWeight = "700";
        b_ctrbeforId = b_ctr;
        b_ctyValue = a_tso[3];
        ns_cc_dky_lthem_P_LKE('K');
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