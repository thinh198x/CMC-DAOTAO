var ns_cc_kb_lthem_lkeCho, b_vungId, b_vungtkId, b_grlkeId, b_XuatEId, b_vungngayId, ns_cc_kb_lthem_choAct = 0, b_loi = 1, b_gionghibdId, b_gionghiktId, b_hinhthucId, b_slideId,
    b_gocId, b_sothe_tnId, b_tenId, b_tuoiId, b_sogio_ngayId, b_sogio_ngay_nbId, b_gioktId, b_so_idId, b_sogio_ttId, b_giobdId, b_gchuId, b_moiId, b_nsd, b_ten, b_ngaydkyId, b_loaidkyId,
    b_sothe_tkId,b_sotheId, b_hoten_tkId, b_ngayd_tk, b_ngayc_tk, b_phong_tkId, b_sogio_nbId, b_so_gio_ttId, b_sogio_demId, b_sogio_dem_nbId, b_ctyValue, b_ctrbeforId;
function ns_cc_kb_lthem_P_KD(b_xuatexcelId) {
    b_XuatEId = b_xuatexcelId;
    ns_cc_kb_lthem_lkeCho = setInterval('ns_cc_kb_lthem_P_LKE_CHO()', 200);
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
            ns_cc_kb_lthem_P_LKE('K');
            $get(b_gocId).focus();
            ns_cc_kb_lthem_P_CB();
        } else if (b_dtuong.indexOf("TAI_IMPORT") >= 0) {
            ns_cc_kb_lthem_P_LKE('K');
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_kb_lthem_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; form_P_MOI("", "XGL"); break;
            case "LOAI_DKY": b_maId = b_loaidkyId; break;
            case "NGAY_DKY": b_maId = b_ngaydkyId; break;
            case "GIO_BD": b_maId = b_giobdId; break;
            case "GIO_KT": b_maId = b_gioktId; break;
            case "NGHI_GCT": b_maId = b_gionghibdId; break;
            case "NGHI_GCD": b_maId = b_gionghiktId; break;
            case "SG_NGAY_NB": b_maId = b_sogio_ngay_nbId; break;
            case "SG_DEM_NB": b_maId = b_sogio_dem_nbId; break;
        }
        var b_ma = $get(b_maId);
        if ((b_ma == null || C_NVL(b_ma.value) == "") && !(b_maTen == "SG_NGAY_NB" || b_maTen == "SG_DEM_NB")) return;
        if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_cc_kb_lthem_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_cc_kb_lthem_P_CB();
            ns_cc_kb_lthem_P_LKE('K');
        } else if (b_maTen == "NGHI_GCT" || b_maTen == "NGHI_GCD") {
            tinh_thoigian();
        } else if (b_maTen == "NGAY_DKY") {
            ns_cc_kb_lthem_lthem_laydulieu();
            ns_cc_kb_lthem_hinhthuc();
            var dateNow = getDateNow();
            var ktraky = ktra_ngay(parseDate($get(b_ngaydkyId).value).getTime(), parseDate(dateNow).getTime(), 1, "Ngày đăng ký", "ngày hiện tại");
            if (ktraky.length > 0) {
                ns_cc_kb_lthem_NH_KQ(ktraky);
                return false;
            }
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

        } else if (b_maTen == "SG_NGAY_NB") {
            if (CSO_SO($get(b_sogio_ngayId).value,2) < CSO_SO($get(b_sogio_ngay_nbId).value,2)) {
                $get(b_sogio_ngay_nbId).value = '';
                form_P_LOI("loi:Số giờ làm thêm ngày chuyển nghỉ bù không được lớn hơn số giờ làm thêm ngày:loi");
                return false;
            }
            $get(b_sogio_ttId).value = CSO_SO($get(b_sogio_ngayId).value,2) - CSO_SO($get(b_sogio_ngay_nbId).value,2) + CSO_SO($get(b_sogio_demId).value,2) - CSO_SO($get(b_sogio_dem_nbId).value,2);
        }
        else if (b_maTen == "SG_DEM_NB") {
            if (CSO_SO($get(b_sogio_demId).value,2) < CSO_SO($get(b_sogio_dem_nbId).value,2)) {
                $get(b_sogio_dem_nbId).value = '';
                form_P_LOI("loi:Số giờ làm thêm đêm chuyển nghỉ bù không được lớn hơn số giờ làm thêm đêm:loi");
                return false;
            }
            $get(b_sogio_ttId).value = CSO_SO($get(b_sogio_ngayId).value,2) - CSO_SO($get(b_sogio_ngay_nbId).value,2) + CSO_SO($get(b_sogio_demId).value,2) - CSO_SO($get(b_sogio_dem_nbId).value,2);
        }
        //ns_cc_kb_lthem_P_CT();
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_kb_lthem_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}
// Nhập
function ns_cc_kb_lthem_P_MOI() {
    form_P_MOI(b_vungId, "GXLK");
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = "0";
    $get(b_gocId).focus();
    return false;
}
function ns_cc_kb_lthem_P_NH() {
    try {
        //var dateNow = getDateNow();
        //var ktraky = ktra_ngay(parseDate($get(b_ngaydkyId).value).getTime(), parseDate(dateNow).getTime(), 1, "Ngày đăng ký", "ngày hiện tại");
        //if (ktraky.length > 0) {
        //    ns_cc_dky_lthem_NH_KQ(ktraky);
        //    return false;
        //}
        //var b_sogio_lt = CSO_SO($get(b_sogioId).value), b_sogio_tt = CSO_SO($get(b_sogio_ttId).value);
        //if (b_sogio_tt > b_sogio_lt) {
        //    form_P_LOI("loi:Số giờ thanh toán không được lớn hơn số giờ làm thêm:loi"); return false;
        //}
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId); b_so_id = '0';
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 0) b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        var b_so_the = $get(b_sothe_tkId).value, b_hoten = $get(b_hoten_tkId).value; b_ngayd = $get(b_ngayd_tk).value, b_ngayc = $get(b_ngayc_tk).value, b_phong = b_ctyValue;
        stl_cc.Fs_NS_CC_KB_LTHEM_NH(form_Fs_nsd(), b_so_id, b_so_the, b_hoten, b_ngayd, b_ngayc, b_phong, b_TrangKt, a_dt_ct, a_cot_lke, ns_cc_kb_lthem_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { throw (err); }
}
function ns_cc_kb_lthem_NH_KQ(b_kq) {
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
function ns_cc_kb_lthem_P_XOA() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
        var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"),
            b_so_the = $get(b_gocId).value;
        if (b_so_id == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); ns_cc_kb_lthem_P_MOI(); return false; }
        else {
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_so_the = $get(b_sothe_tkId).value, b_hoten = $get(b_hoten_tkId).value; b_ngayd = $get(b_ngayd_tk).value, b_ngayc = $get(b_ngayc_tk).value, b_phong = b_ctyValue;
            stl_cc.Fs_NS_CC_KB_LTHEM_XOA(form_Fs_nsd(), b_so_id, b_so_the, b_hoten, b_ngayd, b_ngayc, b_phong, a_tso, a_cot, ns_cc_kb_lthem_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { throw (err); }
    return false;
}
function ns_cc_kb_lthem_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_cc_kb_lthem_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_cc_kb_lthem_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
        return false;

    }
}
// Chuyển hàng
function ns_cc_kb_lthem_GR_lke_RowChange() {
    if (ns_cc_kb_lthem_choAct != 0) clearTimeout(ns_cc_kb_lthem_choAct);
    ns_cc_kb_lthem_choAct = setTimeout("ns_cc_kb_lthem_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_cc_kb_lthem_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_the = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    var b_ngay_bd = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ngay_dky"));
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_the == "") form_P_MOI(b_vungId, "XGLK");
    else stl_cc.Fs_NS_CC_KB_LTHEM_CT(form_Fs_nsd(), b_so_id, b_ngay_bd, ns_cc_kb_lthem_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = b_so_id;
}
function ns_cc_kb_lthem_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
// Liệt kê
function ns_cc_kb_lthem_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        ns_cc_kb_lthem_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'),
        b_vungngayId = form_Fs_VUNG_ID('UPa_ngay'), b_vungtkId = form_Fs_VUNG_ID('UPa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
        b_sothe_tkId = form_Fs_TEN_ID(b_vungtkId, 'so_the_tk'), b_hoten_tkId = form_Fs_TEN_ID(b_vungtkId, 'ten_tk'), b_ngayd_tk = form_Fs_TEN_ID(b_vungtkId, 'ngayd_tk'),
        b_ngayc_tk = form_Fs_TEN_ID(b_vungtkId, 'ngayc_tk'), b_phong_tkId = form_Fs_TEN_ID(b_vungtkId, 'phong_tk'),
        b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE'); b_loaidkyId = form_Fs_TEN_ID(b_vungId, 'nghibu'); b_ngaydkyId = form_Fs_TEN_ID(b_vungId, 'ngay_dky');
        b_sogio_ttId = form_Fs_TEN_ID(b_vungId, 'so_gio_tt');
        b_gchuId = form_Fs_VTEN_ID('', 'gchu'); b_giobdId = form_Fs_TEN_ID(b_vungId, 'GIO_BD'); b_gioktId = form_Fs_TEN_ID(b_vungId, 'GIO_KT');
        b_sogio_ngayId = form_Fs_TEN_ID(b_vungId, 'so_gio_ngay'); b_sogio_demId = form_Fs_TEN_ID(b_vungId, 'so_gio_dem');
        b_sogio_ngay_nbId = form_Fs_TEN_ID(b_vungId, 'sg_ngay_nb'); b_sogio_dem_nbId = form_Fs_TEN_ID(b_vungId, 'sg_dem_nb');
        b_thangId = form_Fs_VTEN_ID('', 'thang'),
        b_gionghibdId = form_Fs_TEN_ID(b_vungId, 'NGHI_GCT'); b_gionghiktId = form_Fs_TEN_ID(b_vungId, 'NGHI_GCD');
        b_so_idId = form_Fs_VTEN_ID('', 'so_id'), b_hinhthucId = form_Fctr_TEN_DTUONG(b_vungId, 'hinhthuc');
        b_slideId = b_grlkeId + '_slide';
        b_sotheId = form_Fs_TEN_ID(b_vungId, 'so_the');
        if (ns_cc_kb_lthem_lkeCho != 0) clearTimeout(ns_cc_kb_lthem_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        lke_P_DAT($get(b_phong_tkId), 'TATCA' + '{' + 'Tất cả');
        form_F_GOC().P_MENUBf(window.name, 'M');
        vb_cctc_P_SL('', 'D', '0', ' ', ' ', 'T');
        b_ctyValue = "TATCA";
        ns_cc_kb_lthem_P_LKE('K');
    }
}
function ns_cc_kb_lthem_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_so_the = $get(b_sothe_tkId).value, b_hoten = $get(b_hoten_tkId).value; b_ngayd = $get(b_ngayd_tk).value, b_ngayc = $get(b_ngayc_tk).value, b_phong = b_ctyValue;
        stl_cc.Fs_NS_CC_KB_LTHEM_LKE(form_Fs_nsd(), b_so_the, b_hoten, b_ngayd, b_ngayc, b_phong, a_tso, a_cot, ns_cc_kb_lthem_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_kb_lthem_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#'); slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
}
// hàm bổ sung khác
function ns_cc_kb_lthem_P_CB() {
    try {
        var b_so_the = $get(b_gocId).value;
        hts_dungchung.Fs_THONGTIN_CANBO(b_so_the, ns_cc_kb_lthem_P_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_kb_lthem_P_CB_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
function ns_cc_kb_lthem_hinhthuc() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_ngaydkyId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var b_ngaykd = $get(b_ngaydkyId).value;
        stl_cc.Fs_LAY_HINHTHUC_LT(form_Fs_nsd(), b_ngaykd, ns_cc_kb_lthem_hinhthuc_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_kb_lthem_hinhthuc_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    list_P_DAT(b_hinhthucId, b_kq);
    return false;
}
function ns_cc_kb_lthem_lthem_laydulieu() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_ngaydkyId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var b_ngaykd = $get(b_ngaydkyId).value; var b_sothe = $get(b_sotheId).value;
        stl_cc.Fs_LAY_DULIEUKB_LT(form_Fs_nsd(), b_ngaykd, b_sothe, ns_cc_kb_lthem_laydulieu_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_kb_lthem_laydulieu_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}

function ns_cc_kb_lthem_P_CT() {
    var b_ngaydky = $get(b_ngaydkyId).value;
    var b_loaidky = $get(b_loaidkyId).value;
    if (b_ngaydky == "" || b_ngaydky == null || b_loaidky == "" || b_loaidky == null) { form_P_MOI("", "XGL"); return; }
    else stl_cc.Fs_NS_CC_KB_LTHEM_CT2(form_Fs_nsd(), b_ngaydky, b_loaidky, ns_cc_kb_lthem_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = b_so_id;
}
function ns_cc_kb_lthem_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function ns_cc_kb_lthem_P_MAU() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'btn_excel_mau');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;

}
function ns_cc_kb_lthem_FILE_Import() {
    var b_tenf = '/App_form/ns/ma/file_Import.aspx';
    form_P_MO(b_tenf, window.name + ',THAMSO', ['THAMSO', [window.name, 'KHAIBAO_LAMTHEM_IMP', null, "Import khai báo làm thêm"]], null);
    form_P_LOI('');
    return false;
}
function ns_cc_kb_lthem_P_NGAY(str) {
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
    var b_gNghibd = $get(b_gionghibdId).value,
        b_gNghikt = $get(b_gionghiktId).value;
    var b_gionghi_bd = b_gNghibd.substring(0, 2), b_phutNghi_bd = b_gNghibd.substring(3, 5);
    var b_gionghi_kt = b_gNghikt.substring(0, 2), b_phutNghi_kt = b_gNghikt.substring(3, 5);

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

        // tru di số giờ nghỉ giữa ca
        //1. trường hợp nghỉ trong khoảng làm đêm vs làm ngay
        if (b_gionghi_bd > 0 && b_gionghi_kt > 0) {
            //1. Giờ nghỉ phải nằm trong khoảng từ giờ đến giờ
            var gio_nghi_tu = parseFloat(b_gionghi_bd) * 60 + parseFloat(b_phutNghi_bd);
            var gio_nghi_den = parseFloat(b_gionghi_kt) * 60 + parseFloat(b_phutNghi_kt);
            var tugio = parseFloat(b_gio_bd) * 60 + parseFloat(b_phut_bd);
            var dengio = parseFloat(b_gio_kt) * 60 + parseFloat(b_phut_kt);
            if (tugio > dengio) {
                dengio = dengio + 24 * 60;
                if (gio_nghi_tu > gio_nghi_den) {
                    gio_nghi_den = gio_nghi_den + 24 * 60;
                }
                if (gio_nghi_tu < tugio) {
                    form_P_LOI("Giờ nghỉ từ không được nhỏ hơn từ giờ"); return false;
                } if (gio_nghi_den > dengio) {
                    form_P_LOI("Giờ nghỉ đến không được lớn hơn đến giờ"); return false;
                }
            } else {
                if (gio_nghi_tu < tugio) {
                    form_P_LOI("Giờ nghỉ từ không được nhỏ hơn từ giờ"); return false;
                } if (gio_nghi_den > dengio) {
                    form_P_LOI("Giờ nghỉ đến không được lớn hơn đến giờ"); return false;
                }
            }
            if (b_gio_bd < b_gio_kt && gio_nghi_den < gio_nghi_tu) {
                form_P_LOI("Nghỉ đến giờ không được nhỏ hơn nghỉ từ giờ"); return false;
            }
            //1. Nếu giờ nghỉ giữa ca nằm trong khoảng làm ngày
            if (parseFloat(b_gionghi_kt) <= 22 && parseFloat(b_gionghi_kt) >= 6 && parseFloat(b_phutNghi_kt) == 0) {
                b_gio_them_n = ((parseFloat(b_gionghi_kt) * 60 + parseFloat(b_phutNghi_kt)) - (parseFloat(b_gionghi_bd) * 60 + parseFloat(b_phutNghi_bd))) / 60;
                b_gio_them = b_gio_them - b_gio_them_n;
            }
            else if (b_gionghi_kt < b_gionghi_bd) {
                b_gio_dem_n = (((parseFloat(b_gionghi_kt) + 24) * 60 + parseFloat(b_phutNghi_kt)) - (parseFloat(b_gionghi_bd) * 60 + parseFloat(b_phutNghi_bd))) / 60;
            } else {
                b_gio_dem_n = ((parseFloat(b_gionghi_kt) * 60 + parseFloat(b_phutNghi_kt)) - (parseFloat(b_gionghi_bd) * 60 + parseFloat(b_phutNghi_bd))) / 60;
            }
            b_gio_dem = b_gio_dem - b_gio_dem_n;
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
        $get(b_sogio_ttId).value = (b_gio_them < 0 ? 0 : b_gio_them) - CSO_SO($get(b_sogio_ngay_nbId).value) + (b_gio_dem < 0 ? 0 : b_gio_dem) - CSO_SO($get(b_sogio_dem_nbId).value);
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
        ns_cc_kb_lthem_P_LKE('K');
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