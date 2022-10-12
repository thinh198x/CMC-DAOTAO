var ns_dt_tk_lkeCho, ns_dt_tk_gchuCho, b_vungId, b_vungtkId, b_grlke_cpId, b_ngay_dId, b_ngay_cId, b_thluongId, b_sl_hvien_ttId, b_tong_cpId, b_cp_hvId,
    b_ten_kdtId, b_lopId, b_gchuId, b_so_id = 0, b_so_id_kh, b_nsd;

function ns_dt_tk_P_KD() {
    b_vungId = form_Fs_VUNG_ID('UPa_ct'),
    b_grlke_cpId = form_Fs_VUNG_ID('GR_cpdt'),

    b_ngay_dId = form_Fs_TEN_ID(b_vungId, 'ngay_d'),
    b_ngay_cId = form_Fs_TEN_ID(b_vungId, 'ngay_c'),
    b_thluongId = form_Fs_TEN_ID(b_vungId, 'thluong'),
    b_sl_hvien_ttId = form_Fs_TEN_ID(b_vungId, 'sl_hvien_tt'),
    b_ten_kdtId = form_Fs_TEN_ID(b_vungId, 'ten_kdt'),
    b_lopId = form_Fs_TEN_ID(b_vungId, 'lop'),
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'),
    b_tong_cpId = form_Fs_VTEN_ID('UPa_total', 'tong_cp'),
    b_cp_hvId = form_Fs_VTEN_ID('UPa_total', 'cp_hv');
    b_gchuId = form_Fs_VTEN_ID('UPa_nhap', 'gchu');
    b_nsd = form_Fs_nsd();
    //ns_dt_tk_lkeCho = setInterval('ns_dt_tk_P_LKE_CHO()', 200);
}

// use
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        //var b_kq = a_tso[0];
        b_doi = 0;
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            b_so_id_kh = a_tso[1];
            // lay chi tiet thong tin trien khai
            ns_dt_tk_lkeCho = setInterval('ns_dt_tk_P_CT_CHO()', 200);
        }
        else if (b_dtuong.indexOf("TEN_CP") >= 0) {
            var b_hang1 = GridX_Fi_timHangA(b_grlke_cpId);
            if (b_hang1 < 0) return;
            var b_hang2 = GridX_Fi_timHangD(b_grlke_cpId, "ma_cp", a_tso[0]);
            if (b_hang2 > 0 && b_hang1 != b_hang2) {
                form_P_LOI("Đã có hạng mục chi phí này");
                return;
            }
            GridX_datGtri(b_grlke_cpId, b_hang1, ["ma_cp"], [a_tso[0]], 'K');
            GridX_datGtri(b_grlke_cpId, b_hang1, ["ten_cp"], [a_tso[1]], 'K');
        }
    }
    catch (err) { form_P_LOI(err); }
}


function ns_dt_tk_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        b_mt = b_maTen;
        switch (b_maTen) {
            case "NGAY_D": b_maId = b_ngay_dId; break;
            case "NGAY_C": b_maId = b_ngay_cId; break;            
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return true;

        if (b_maTen == "NGAY_D") {
           
            if (kiemTraNgayDau()) {
                if (kiemTraNgayDayVaNgayCuoi())
                    return kiemTraThoiLuong();
                else
                    return false;
            }
            else
                return false;           
        }
        else if (b_maTen == "NGAY_C") {
            if (kiemTraNgayDayVaNgayCuoi())
                return kiemTraThoiLuong();
            else
                return false;
        }        
        else
            return true;
    }
    catch (err) { form_P_LOI(err); return false; }
}
function kiemTraThoiLuong() {
    var b_thluong = CSO_SO($get(b_thluongId).value);
    if (b_thluong == 0) return true;
    var b_ngayD = b_ngayC = $get(b_ngay_dId).value, b_ngayC = $get(b_ngay_cId).value;
    if (b_ngayD != "" && b_ngayC != "") {
        if ((CNG_SO(b_ngayC) - CNG_SO(b_ngayD) + 1) * 24 < b_thluong) {
            form_P_LOI("Thời lượng đào tạo vượt quá số ngày đào tạo");
            return false;
        }
        return true;
    }
    else return true;
}
function kiemTraNgayDau() {
    var b_ngay = $get(b_ngay_dId).value;
    var b_ngayD = CNG_SO(b_ngay);
    if (b_ngayD == 0) return true;

    var b_namD = CSO_SO(b_ngay.substr(6, 4)), b_thangD = CSO_SO(b_ngay.substr(3, 2));
    var b_nam = CSO_SO(form_Fs_TEN_GTRI(b_vungId, 'nam')), b_thang = CSO_SO(form_Fs_TEN_GTRI(b_vungId, 'thang'));
    if (b_namD != b_nam) {
        form_P_LOI("Năm trong ngày bắt đầu khác năm kế hoạch đào tạo");
        return false;
    }
    if (b_thangD != b_thang) {
        form_P_LOI("Tháng trong ngày bắt đầu khác tháng kế hoạch đào tạo");
        return false;
    }
    return true;
}
function kiemTraNgayDayVaNgayCuoi() {
    var b_ngayD = $get(b_ngay_dId).value;
    var b_ngayC = $get(b_ngay_cId).value;
    if (b_ngayD != "" && b_ngayC != "") {
        if (CNG_SO(b_ngayC) < CNG_SO(b_ngayD)) {
            form_P_LOI("Ngày bắt đầu lớn hơn ngày kết thúc");
            return false;
        }
        else
            return true;
    }
    else return true;
}


// use
function ns_dt_tk_P_CT_CHO() {
    if ($get(b_grlke_cpId) != null) {
        clearTimeout(ns_dt_tk_lkeCho);
        ns_dt_tk_P_CT();
    }
}
// use
function ns_dt_tk_P_MOI() {
    form_P_MOI(b_vungId, "XL");
    GridX_datTrang(b_grlke_cpId);
    return false;
}
// use
function ns_dt_tk_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") {
            form_P_LOI(b_loi);
            return false;
        }
        if (!ns_dt_tk_P_KTRA("NGAY_D"))
            return false;
                
        var a_dt = form_Faa_TEXT_ROW(b_vungId);
        var a_cot_ct_cp = GridX_Fdt_cotGtri(b_grlke_cpId), a_cot_lke_cp = GridX_Fas_tenCot(b_grlke_cpId);
        sns_dt.Fs_NS_DT_TK_NH(b_nsd, b_so_id, b_so_id_kh, a_dt, a_cot_ct_cp, a_cot_lke_cp, ns_dt_tk_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);  
    }
    catch (err) { throw (err); }
    return false;
}

// use
function ns_dt_tk_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    else {
        if (b_so_id == 0)
            b_so_id = b_kq;
        ns_dt_tk_P_DatGchu(true, "Cập nhật thành công");
    }
    return false;
}
// use
function tinhTongChiPhi() {
    var b_tong_cp = GridX_Fn_Tong_KDK(b_grlke_cpId, "tong_hm");
    $get(b_tong_cpId).value = SO_CSO(b_tong_cp);
    var b_so_hv = $get(b_sl_hvien_ttId).value;
    var b_cp_hv = '';
    if (b_so_hv != '')
        b_cp_hv = Math.round(b_tong_cp / CSO_SO(b_so_hv));
    $get(b_cp_hvId).value = SO_CSO(b_cp_hv);
}

// use
function ns_dt_tk_P_CT() {    
    var a_cot_lke_cp = GridX_Fas_tenCot(b_grlke_cpId);
    sns_dt.Fs_NS_DT_TK_CT(b_nsd, b_so_id_kh, a_cot_lke_cp, ns_dt_tk_P_CT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
// use
function ns_dt_tk_P_CT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    b_so_id = a_kq[0];
    form_P_CH_TEXT(b_vungId, a_kq[1]);
    GridX_datBang(b_grlke_cpId, a_kq[2]);
    tinhTongChiPhi();
}
// use
function ns_dt_tk_P_XOA() {
    try {
        if (b_so_id == 0) { form_P_LOI("Chưa có thông tin triển khai lớp đào tạo để xóa"); return false; }
        var message = confirm("Bạn có chắc chắn xóa không?");
        if (message == false) { return false; }
        var a_cot = GridX_Fas_tenCot(b_grlke_cpId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.Fs_NS_DT_TK_XOA(b_nsd, b_so_id, ns_dt_tk_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { throw (err); }
    return false;
}
// use
function ns_dt_tk_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        b_so_id = 0;
        ns_dt_tk_P_MOI();
        ns_dt_tk_P_DatGchu(true, "Xóa thành công");
    }
    return false;
}

// use
function ns_dt_tk_GR_Update(b_event) {
    try {
        var b_id = b_event.srcElement.id;
        if(b_id.indexOf("ten_cp") > 0) {
            var b_hang = GridX_Fi_timHangA(b_grlke_cpId);
            var b_ma_cp = C_NVL(GridX_Fas_layGtri(b_grlke_cpId, b_hang, "ten_cp"));
            if(b_ma_cp == "") return;

            var b_hang1 = GridX_Fi_timHangA(b_grlke_cpId);
            var b_hang2 = GridX_Fi_timHangD(b_grlke_cpId, "ma_cp", b_ma_cp);
            if (b_hang2 > 0 && b_hang1 != b_hang2) {
                form_P_LOI("Đã có hạng mục chi phí này");
                return;
            }

            sns_dt.Fs_THONGTIN_MA_CP_LUOI(b_ma_cp, ns_dt_tk_P_MA_CP_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_id.indexOf("dgia") > 0 || b_id.indexOf("sluong") > 0 || b_id.indexOf("thue") > 0) {
            var b_hang = GridX_Fi_timHangA(b_grlke_cpId);            
            var b_gdgia = C_NVL(GridX_Fas_layGtri(b_grlke_cpId, b_hang, "dgia"));
            var b_sluong = C_NVL(GridX_Fas_layGtri(b_grlke_cpId, b_hang, "sluong"));

            if (b_gdgia != "" && b_sluong != "") {
                var b_tong = CSO_SO(b_gdgia) * CSO_SO(b_sluong);
                GridX_datGtri(b_grlke_cpId, b_hang, ["tong"], SO_CSO(b_tong), 'K');

                var b_thue = C_NVL(GridX_Fas_layGtri(b_grlke_cpId, b_hang, "thue"));
                if (b_thue == '') b_thue = "0";

                var b_tong_hm = Math.round(b_tong + b_tong * CSO_SO(b_thue) / 100.0);
                GridX_datGtri(b_grlke_cpId, b_hang, ["tong_hm"], SO_CSO(b_tong_hm), 'K');
            }

            var tonghm = GridX_Fn_Tong_KDK(b_grlke_cpId, "tong_hm");
            $get(b_tong_cpId).value = SO_CSO(tonghm);
            var so_hv = CSO_SO(C_NVL($get(b_sl_hvien_ttId).value));
            if (so_hv != 0) {
                $get(b_cp_hvId).value = SO_CSO(Math.round(tonghm / so_hv));
            }
        }
    }
    catch (ex) { form_P_LOI(ex.message); }
}
// use
function ns_dt_tk_P_MA_CP_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if(b_kq == ""){
        form_P_LOI("Không tồn tại mã chi phí");
    }
    else {
        var b_hang = GridX_Fi_timHangA(b_grlke_cpId);
        if(b_hang < 0) return;
        var a_kq = Fas_ChMang(b_kq, '#');
        GridX_datGtri(b_grlke_cpId, b_hang, ["ma_cp"], [a_kq[0]], 'K');
        GridX_datGtri(b_grlke_cpId, b_hang, ["ten_cp"], [a_kq[1]], 'K');
    }
}

function ns_dt_tk_HangLen() {
    GridX_chuyenHang(b_grlke_cpId, -1);
    return false;
}
function ns_dt_tk_HangXuong() {
    GridX_chuyenHang(b_grlke_cpId, 1);

    return false;
}
function ns_dt_tk_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grlke_cpId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grlke_cpId);
    return false;
}
function ns_dt_tk_CatDong() {
    GridX_boChon(b_grlke_cpId, 'C');
    return false;
}

// use
function ns_dt_tk_P_CHON() {
    var b_hang = GridX_Fi_timHangA(b_grlke_cpId);
    if (b_hang < 1) return;
    form_P_TRA_CHON('MA,TEN');
    return false;
}


function ns_dt_tk_P_TT(b_nv) {    
    if (b_so_id == 0) {
        form_P_LOI('Bạn chưa lưu triển khai lớp đào tạo nào!');
        return;
    }

    var b_tenKdt = $get(b_ten_kdtId).value;
    var b_lop = $get(b_lopId).value;
    switch (b_nv) {
        case 'DD': // điểm danh
            form_P_MO('/App_form/ns/dt/ngv/ns_dt_tk_dd.aspx?so_id_tk=' + b_so_id, window.name, ["THAMSO", [window.name, b_so_id, b_tenKdt, b_lop]]);
            break;
        case 'TKB': // thời khóa biểu
            form_P_MO('/App_form/ns/dt/ngv/ns_dt_tk_tkb.aspx', window.name, ["THAMSO", [window.name, b_so_id, b_tenKdt, b_lop]]);
            break;
        default:
            break;
    }
    return false;
}
function ns_dt_tk_P_DatGchu(show, gchu) {
    form_P_DatGchu(b_gchuId, gchu);
    if (show) ns_dt_tk_gchuCho = setInterval('ns_dt_tk_P_DatGchu(false,".")', 2000);
    else clearTimeout(ns_dt_tk_gchuCho);
}

// use
function form_dong() {
    location.reload(false);
}