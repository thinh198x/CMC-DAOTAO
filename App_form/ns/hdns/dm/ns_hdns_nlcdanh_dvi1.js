
var ns_hdns_nlcdanh_dvi_P_KD_lkeCho, b_vungId, b_grlkeId, b_grctId, b_gchuId, b_dvi_Id, ns_hdns_nlcdanh_dvi_P_KET_QUACho;
function ns_hdns_nlcdanh_dvi_P_KD() {
    ns_hdns_nlcdanh_dvi_P_KD_lkeCho, b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct');    
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'); b_slideId = b_grlkeId + '_slide';
    b_dvi_Id = form_Fs_VTEN_ID('UPa_hi', 'dvi');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    ns_hdns_nlcdanh_dvi_P_KD_lkeCho = setInterval('ns_hdns_nlcdanh_dvi_P_KD_P_LKE_CHO()', 200);
}

var b_cho_control = 0;
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("TEN_CDANH") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang > 0) {
                GridX_datGtri(b_grctId, b_hang, 'ma_phong', a_tso[0]);
                GridX_datGtri(b_grctId, b_hang, 'ten_cdanh', a_tso[1]);
                GridX_datGtri(b_grctId, b_hang, 'dvi', a_tso[2]);
            }
            //ns_hdns_nlcdanh_dvi_P_KD_P_CHUYEN_HANG();
        }
        if (b_dtuong.indexOf("NHOM_NL") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang > 0) {
                GridX_datGtri(b_grctId, b_hang, 'nhom_nl', a_tso[0]);
                GridX_datGtri(b_grctId, b_hang, 'tennl', a_tso[1]);
                GridX_datGtri(b_grctId, b_hang, 'mucnl', a_tso[2]);
                GridX_datGtri(b_grctId, b_hang, 'so_id_dg', a_tso[3]);
            }
            //ns_hdns_nlcdanh_dvi_P_KD_P_CHUYEN_HANG();
        }
        
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_nlcdanh_dvi_P_KD_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        form_P_MOI(b_vungId, "X"); GridX_datTrang(b_grctId);
        $get(b_gocId).focus(); $get(b_so_idId).value = "0";
    }
    else { GridX_datA(b_grlkeId, b_hang); ns_hdns_nlcdanh_dvi_P_KD_P_CHUYEN_HANG(); }
}
function ns_hdns_nlcdanh_dvi_tinh_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grctId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        var b_ktra = C_NVL(b_ctr.ktra), b_ten = C_NVL(b_ctr.ten);
        if (b_value != "") {
            if (b_cot == "CDANH") {

               skhac.Fs_MA_LOI(form_Fs_nsd(), "Nhóm chức danh", b_value, "ns_ma_ncdanh,ma,ten", ns_td_dexuat_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
            if (b_cot == "DONVI") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Chức danh", b_value, "ns_ma_cdanh,ma,ten", ns_td_dexuat_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }            
        }
        if (b_value != "") GridX_ThemHang(b_grctId);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_dexuat_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);

}

var ns_hdns_nlcdanh_dvi_choAct = 0;
function ns_hdns_nlcdanh_dvi_GR_lke_RowChange() {
    if (ns_hdns_nlcdanh_dvi_choAct != 0) clearTimeout(ns_hdns_nlcdanh_dvi_choAct);
    ns_hdns_nlcdanh_dvi_choAct = setTimeout("ns_hdns_nlcdanh_dvi_P_KD_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_hdns_nlcdanh_dvi_P_KD_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if ($get(b_grlkeId) != null) { clearTimeout(ns_hdns_nlcdanh_dvi_P_KD_lkeCho); GridX_taoScroll(b_grlkeId); ns_hdns_nlcdanh_dvi_P_KD_P_LKE(); }
    }
}
function ns_hdns_nlcdanh_dvi_P_KD_P_LKE() {
    try {
        var  a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
                sht_ma.Fs_MA_PH_LKE3(form_Fs_nsd(), "", a_cot, ns_hdns_nlcdanh_dvi_P_KD_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_hdns_nlcdanh_dvi_P_KD_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else { GridX_datBang(b_grlkeId, b_kq); slide_P_SOTRANG(b_slideId); ns_hdns_nlcdanh_dvi_P_KD_P_CHUYEN_HANG();}
}

function ns_hdns_nlcdanh_dvi_P_KD_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var a_cot_ct = GridX_Fdt_cotGtri(b_grctId);
        sns_hdns.Fs_NS_HDNS_NLCDANH_DVI_NH(a_cot_ct, Fs_ns_hdns_nlcdanh_dvi_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);      
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function Fs_ns_hdns_nlcdanh_dvi_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }    
}
function ns_hdns_nlcdanh_dvi_P_MOI() {
    GridX_datBang(b_grctId, '');
}
function ns_hdns_nlcdanh_dvi_P_KD_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId), b_madonvi;
    if (b_hang > 0) {
        $get(b_dvi_Id).value = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        b_madonvi = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        sns_hdns.Fs_NS_HDNS_NLCDANH_DVI_LKE(b_madonvi, ns_hdns_nlcdanh_dvi_P_KD_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    } else
        ns_hdns_nlcdanh_dvi_P_MOI();
    return false;
}
function ns_hdns_nlcdanh_dvi_P_KD_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }    
    GridX_datBang(b_grctId, b_kq);    
}
function ns_hdns_nlcdanh_dvi_P_XOA() {
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) {
        return false;
    }
    var b_hang = GridX_Fi_timHangA(b_grctId);
    if (b_hang < 1) { form_P_LOI("loi:Chọn đơn vị cần xóa:loi"); return false; }
    else
    {
        var b_donvi = C_NVL(GridX_Fas_layGtri(b_grctId, b_hang, "donvi")), b_ma = C_NVL(GridX_Fas_layGtri(b_grctId, b_hang, "ma"));
        sns_hdns.Fs_NS_HDNS_NLCDANH_DVI_XOA(b_donvi,b_ma, ns_hdns_nlcdanh_dvi_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;    
}


function ns_hdns_nlcdanh_dvi_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else  GridX_datBang(b_grctId, b_kq); 
}

function ns_hdns_nlcdanh_dvi_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_hdns_nlcdanh_dvi_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_hdns_nlcdanh_dvi_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function ns_hdns_nlcdanh_dvi_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}
function ns_hdns_nlcdanh_dvi_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); b_loi_id = 1; return; } else {
        b_loi_id = 0;
    }
    $get(b_gchuId).innerHTML = b_kq;
}
function ns_hdns_nlcdanh_dvi_tinh(b_event) {
        var b_hang = GridX_Fi_timHangA(b_grctId);
    var b_ctr = form_Fctr_event(b_event);
    var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();    
    if (b_value != "") {
        if (b_cot == "DONVI") skhac.Fs_MA_LOI(form_Fs_nsd(), "Mã đơn vị", b_value.toUpperCase(), "ht_ma_phong,ma,ten", ns_hdns_nlcdanh_dvi_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
        if (b_cot == "CDANH") skhac.Fs_MA_LOI(form_Fs_nsd(), "Mã chức danh", b_value.toUpperCase(), "ns_ma_cdanh,ma,ten", ns_hdns_nlcdanh_dvi_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
    }
    if (b_hang > 0) {
        var b_tenchucdanh = C_NVL(GridX_Fas_layGtri(b_grctId, b_hang, "donvi")) + '.' + C_NVL(GridX_Fas_layGtri(b_grctId, b_hang, "cdanh"));
        GridX_datGtri(b_grctId, b_hang, ["ma"],b_tenchucdanh, 'K');
    }
    return false;
}
function nvl(value1, value2) {
    if (value1 == null || value1 == "")
        return value2;
    return value1;
}
// START: Trả giá trị chọn trên lưới //       
// Tra gia tri chon cho form goi
function form_P_TRA_CHON_GRID(b_ten) {
    try {
        var a_kq = form_P_TRA_GTRI_GRID(b_ten);
        form_P_DONG(window.name, a_kq);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
// Tra mang gia tri theo ten
function form_P_TRA_GTRI_GRID(b_ten) {
    try {
        var a_ten = b_ten.split(','), a_kq = [];
        for (var i = 0; i < a_ten.length; i++) {
            var a_grid = a_ten[i].split(':');
            var b_gridId = form_Fs_VUNG_ID(a_grid[0]);
            var b_hang = GridX_Fi_timHangA(b_gridId);
            a_kq[i] = GridX_Fas_layGtri(b_gridId, b_hang, a_grid[1]);
        }
        return a_kq;
    }
    catch (err) { return null; }
}
// END: Trả giá trị chọn trên lưới //  
function form_dong() {
    location.reload(false);
}
function ns_hdns_nlcdanh_dvi_P_IN() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId),b_dvi;
    if (b_hang < 1) b_dvi = '';
    else b_dvi= C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
    sns_hdns.Fs_NS_HDNS_NLCDANH_DVI_XUATEXCEL(b_dvi, ns_hdns_nlcdanh_dvi_P_IN_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
    //__doPostBack('ctl00$ContentPlaceHolder1$Nhap2', '');//Xuất Excel
}
function ns_hdns_nlcdanh_dvi_P_IN_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);   
}
function form_dong() {
    location.reload(false);
}
function ns_hdns_nlcdanh_dvi_P_MAU() {
    __doPostBack('ctl00$ContentPlaceHolder1$btn_excel_mau', '');//Xuất file Excel mẫu

}
function ns_hdns_nlcdanh_dvi_FILE_Import() {//import từ file Excel
    var b_tenf = '/App_form/ns/hdns/file_hdns.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "CDANH_DVI_IMP", "CDANH_DVI_IMP", "Import chức danh đơn vị"]], null);
    form_P_LOI('');
    return false;
}