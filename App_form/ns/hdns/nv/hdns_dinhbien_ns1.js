
var hdns_dinhbien_ns_P_KD_lkeCho, b_vungId, b_grlkeId, b_grctId, b_gocId, b_loi_id, b_mt, b_gchuId, b_donviId, b_chucdanhId, b_nchucdanhId, b_doi = 0, b_ncdId, b_ncd2Id, b_day;
function hdns_dinhbien_ns_P_KD() {
    hdns_dinhbien_ns_P_KD_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'nam'), b_donviId = form_Fs_TEN_ID(b_vungId, 'donvi'), b_chucdanhId = form_Fs_TEN_ID(b_vungId, 'chucdanh'),
    b_ncdId = form_Fs_TEN_ID(b_vungId, 'hincd'), b_nchucdanhId = form_Fs_TEN_ID(b_grctId, 'NCDANH'),
    b_ncd2Id = form_Fs_TEN_ID(b_vungId, 'hincd2');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'); b_slideId = b_grlkeId + '_slide';
    b_gchuId = form_Fs_VTEN_ID('', 'gchu'); b_day = form_Fs_VTEN_ID('UPa_ct', 'day');
    hdns_dinhbien_ns_P_KD_lkeCho = setInterval('hdns_dinhbien_ns_P_KD_P_LKE_CHO()', 200);
}

var b_cho_control = 0;
function P_cho(b_nam, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_gocId).value = b_nam;
            $get(b_gchuId).innerHTML = b_ten;
            $get(b_gocId).focus();
            hdns_dinhbien_ns_P_KD_P_LKE();
            b_doi = 1;
            clearTimeout(b_cho_control);
        } else if (b_doi == 1) {
        }
    }
    catch (err) {
        b_doi = 0;
    }
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
            if (a_tso[0] == 'FILE_HTOAN') {
                hdns_dinhbien_ns_P_KD_P_CHUYEN_HANG();
            }
        }
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        b_doi = 0;
        if (b_dtuong.indexOf("SO_THE") >= 0 || b_dtuong.indexOf("THAMSO") >= 0) {
            $get(b_gocId).setAttribute("disabled", "disabled");
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
        }
        else if (b_dtuong.indexOf("NCDANH") >= 0) {
            b_doi = 0;
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            $get(b_gchuId).innerHTML = a_tso[1];
            GridX_datGtri(b_grctId, b_hang, ["ncdanh"], [a_tso[0]], 'K');
            hdns_dinhbien_ns_P_LKE_TONGNHANSU();
            $get(b_ncdId).value = a_tso[0];
        }
        else if (b_dtuong.indexOf("PHONG") >= 0) {
            b_doi = 1;
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            $get(b_gchuId).innerHTML = a_tso[1];
            GridX_datGtri(b_grctId, b_hang, ["phong"], [a_tso[0]], 'K');
            hdns_dinhbien_ns_P_LKE_TONGNHANSU();
            $get(b_nchucdanhId).focus();
        }
        else if (b_dtuong.indexOf("DONVI") >= 0) {
            $get(b_donviId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];            
            $get(b_chucdanhId).focus();
        }
        else if (b_dtuong.indexOf("CHUCDANH") >= 0) {
            $get(b_chucdanhId).value = b_kq;           
            $get(b_gchuId).innerHTML = a_tso[1];            
            $get(b_chucdanhId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}

function hdns_dinhbien_ns_P_KD_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "DONVI": b_maId = b_donviId;  break;//form_P_MOI("", "XGL"); GridX_datTrang(b_grctId);
            case "CHUCDANH": b_maId = b_chucdanhId; break;
            case "NCDANH": break;
            case "PHONG": break;
        }
        var b_ma = $get(b_maId);
        b_mt = b_maTen;
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "DONVI") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), hdns_dinhbien_ns_P_KD_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            $get(b_chucdanhId).focus();
            //$get(b_donviId).value = b_kq;
            //hdns_dinhbien_ns_P_LKE_TONGNHANSU();
            //hdns_dinhbien_ns_P_KD_P_LKE();
        }
        else if (b_maTen == "CHUCDANH") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), hdns_dinhbien_ns_P_KD_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            $get(b_chucdanhId).focus();
        }
        else if (b_maTen == "NCDANH") {

        }
        else if (b_maTen == "PHONG") {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            $get(b_gchuId).innerHTML = a_tso[1];
            //GridX_datGtri(b_grctId, b_hang, ["ten_phong"], [a_tso[1]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["phong"], [a_tso[0]], 'K');
            hdns_dinhbien_ns_P_LKE_TONGNHANSU();
            $get(b_nchucdanhId).focus();
        }
        else if (b_maTen == "NGAY") {
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ngayd", b_ma.value);
            if (b_hang < 0) { hdns_dinhbien_ns_P_KD_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); hdns_dinhbien_ns_P_KD_P_CHUYEN_HANG(); }
        }
    }
    catch (err) { form_P_LOI(err); }
}

function hdns_dinhbien_ns_P_KD_P_MA_KTRA() {
    try {
        //var b_ngay = C_NVL($get(b_ngayId).value);
        //if (b_ngay != "") {
        //    var b_nam = $get(b_gocId).value;
        //    var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
        //    sns_td.Fs_HDNS_DINHBIEN_NS_MA(b_nam, b_ngay, b_TrangKt, a_cot, hdns_dinhbien_ns_P_KD_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        //}
    }
    catch (err) { form_P_LOI(err); }
}

function hdns_dinhbien_ns_P_LKE_TONGNHANSU() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grctId);
        if (b_hang < 1) return;
        //var b_nam = $get(b_gocId).value;
        var b_nam = C_NVL(GridX_Fas_layGtri(b_grctId, b_hang, "nam"));
        if (b_nam != "") {
            var b_phong = C_NVL(GridX_Fas_layGtri(b_grctId, b_hang, "phong"));
            var b_cdanh = C_NVL(GridX_Fas_layGtri(b_grctId, b_hang, "ncdanh"));
            sns_td.Fs_NS_CB_TONGNHANSU(b_nam, b_phong, b_cdanh, hdns_dinhbien_ns_P_LKE_TONGNHANSU_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;

    }
    catch (err) { form_P_LOI(err); }
}
function hdns_dinhbien_ns_P_LKE_TONGNHANSU_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var b_hang = GridX_Fi_timHangA(b_grctId);
    if (b_hang < 0) return;
    GridX_datGtri(b_grctId, b_hang, ["ns_hientai"], [b_kq], 'K');
}


function hdns_dinhbien_ns_P_KD_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    $get(b_gchuId).innerHTML = b_kq;
}

function hdns_dinhbien_ns_P_KD_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(hdns_dinhbien_ns_P_KD_lkeCho); GridX_taoScroll(b_grlkeId); hdns_dinhbien_ns_P_KD_P_LKE(); }
}


function hdns_dinhbien_ns_P_KD_P_LKE() {
    try {
        var b_nam = $get(b_gocId).value, a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sht_ma.Fs_MA_PH_LKE3(form_Fs_nsd(), "", a_cot, hdns_dinhbien_ns_P_KD_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function hdns_dinhbien_ns_P_KD_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else { GridX_datBang(b_grlkeId, b_kq); slide_P_SOTRANG(b_slideId); hdns_dinhbien_ns_P_KD_P_CHUYEN_HANG(); }
}
function hdns_dinhbien_ns_P_THEM() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) { form_P_LOI("loi:chọn đơn vị cần thêm:loi"); return false; }
        else
        {
            var ngay_dk = new Date();
            var b_nam= ngay_dk.getFullYear();
            var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
            var b_ten = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten"));
            var b_hang_ct = GridX_Fi_timHangT(b_grctId);
            if (b_hang_ct < 0) { GridX_ThemHang(b_grctId); b_hang_ct = GridX_Fi_timHangT(b_grctId); }
            else GridX_chenHang(b_grctId, b_hang_ct);
            GridX_datGtri(b_grctId, b_hang_ct, ["phong"], b_ma, 'K');
            GridX_datGtri(b_grctId, b_hang_ct, ["nam"], b_nam, 'K');
           // GridX_datGtri(b_grctId, b_hang_ct, ["NCDANH"], b_ten, 'K');
            GridX_datA(b_grctId, b_hang_ct);
            hdns_dinhbien_ns_P_LKE_TONGNHANSU();
        }
        //var b_nam = C_NVL(GridX_Fas_layGtri(b_grctId, b_hang, "nam"));
       // if (b_nam != "") {
           
            sns_td.Fs_NS_CB_TONGNHANSU(b_nam, b_phong, b_cdanh, hdns_dinhbien_ns_P_LKE_TONGNHANSU_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        //}
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function hdns_dinhbien_ns_P_KD_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var b_nam = $get(b_gocId).value, b_dt = form_Faa_TEXT_ROW(b_vungId),
            a_cot_ct = GridX_Fdt_cotGtri(b_grctId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
        sns_td.Fs_HDNS_DINHBIEN_NS_NH(b_nam, b_TrangKt, a_cot_ct, a_cot_lke, hdns_dinhbien_ns_P_KD_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function hdns_dinhbien_ns_P_KD_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else { form_P_LOI("loi:Nhập thành công:loi"); hdns_dinhbien_ns_P_CHUYEN_HANG(); }
}
function hdns_dinhbien_ns_P_TIM() {
    try {
        hdns_dinhbien_ns_P_CHUYEN_HANG();
    }
    catch (err) { form_P_LOI(err); }
}
function hdns_dinhbien_ns_P_TIM_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
}
function hdns_dinhbien_ns_P_KD_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId), b_madonvi;
    if (b_hang < 1) b_madonvi = '';
    else b_madonvi = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
    $get(b_donviId).value = b_madonvi;
    sns_td.Fs_HDNS_DINHBIEN_NS_LKE('', b_madonvi, '', hdns_dinhbien_ns_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function hdns_dinhbien_ns_P_CHUYEN_HANG() {
    var b_cdanh, b_madonvi, b_nam;
    b_nam = $get(b_gocId).value;
    b_cdanh = $get(b_chucdanhId).value, b_madonvi = $get(b_donviId).value;    
    sns_td.Fs_HDNS_DINHBIEN_NS_LKE(b_nam, b_madonvi, b_cdanh, hdns_dinhbien_ns_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}

function an_hien(b_thang_t) {
    var ngay_dk = NG_CNG(new Date());
    var b_thang = ngay_dk.substr(3, 2);
    if (b_thang_t < b_thang)
        return false;
    else
        return true;
}

function hdns_dinhbien_ns_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang(b_grctId, b_kq);
    var ngay_dk = NG_CNG(new Date());
    var b_thang = ngay_dk.substr(3, 2);
    var a_kq = b_kq.split(';');   
}

function hdns_dinhbien_ns_P_KD_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    $get(b_so_idId).value = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
}
var hdns_dinhbien_ns_choAct = 0;
function hdns_dinhbien_ns_GR_lke_RowChange() {
    if (hdns_dinhbien_ns_choAct != 0) clearTimeout(hdns_dinhbien_ns_choAct);
    hdns_dinhbien_ns_choAct = setTimeout("hdns_dinhbien_ns_P_KD_P_CHUYEN_HANG()", 300);
    return false;
}
function hdns_dinhbien_ns_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function hdns_dinhbien_ns_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function hdns_dinhbien_ns_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function hdns_dinhbien_ns_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}
function hsns_dinhbien_ns_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); b_loi_id = 1; return; } else {
        b_loi_id = 0;
    }
    $get(b_gchuId).innerHTML = b_kq;
}
function hsns_dinhbien_ns_tinh(b_event) {
    var tong = 0;
    var b_maId = "";
    var b_hang = GridX_Fi_timHangA(b_grctId);

    var b_ctr = form_Fctr_event(b_event);
    var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
    b_mt = b_cot;
    if (b_value != "") {
        if (b_cot == "PHONG") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), "Mã đơn vị", b_value.toUpperCase(), "ht_ma_phong,ma,ten", hsns_dinhbien_ns_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            hdns_dinhbien_ns_P_LKE_TONGNHANSU();
        }
        if (b_cot == "NCDANH") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), "Mã nhóm chức danh", b_value.toUpperCase(), "ns_ma_ncdanh,ma,ten", hsns_dinhbien_ns_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
        }
        if (b_cot == "CDANH") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), "Mã chức danh", b_value.toUpperCase(), "ns_ma_cdanh,ma,ten", hsns_dinhbien_ns_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            hdns_dinhbien_ns_P_LKE_TONGNHANSU();
        }
    }
    if (b_hang > 0) {
        var tong = parseInt(nvl(GridX_Fas_layGtri(b_grctId, b_hang, "db_t1"), 0)) + parseInt(nvl(GridX_Fas_layGtri(b_grctId, b_hang, "db_t2"), 0)) + parseInt(nvl(GridX_Fas_layGtri(b_grctId, b_hang, "db_t3"), 0));
        var tong1 = parseInt(nvl(GridX_Fas_layGtri(b_grctId, b_hang, "db_t4"), 0)) + parseInt(nvl(GridX_Fas_layGtri(b_grctId, b_hang, "db_t5"), 0)) + parseInt(nvl(GridX_Fas_layGtri(b_grctId, b_hang, "db_t6"), 0));
        var tong2 = parseInt(nvl(GridX_Fas_layGtri(b_grctId, b_hang, "db_t7"), 0)) + parseInt(nvl(GridX_Fas_layGtri(b_grctId, b_hang, "db_t8"), 0)) + parseInt(nvl(GridX_Fas_layGtri(b_grctId, b_hang, "db_t9"), 0));
        var tong3 = parseInt(nvl(GridX_Fas_layGtri(b_grctId, b_hang, "db_t10"), 0)) + parseInt(nvl(GridX_Fas_layGtri(b_grctId, b_hang, "db_t11"), 0)) + parseInt(nvl(GridX_Fas_layGtri(b_grctId, b_hang, "db_t12"), 0));
        var b_max = parseInt(nvl(GridX_Fas_layGtri(b_grctId, b_hang, "db_t1"), 0));
        for (var i = 2; i < 13; i++) {
            if (b_max < parseInt(nvl(GridX_Fas_layGtri(b_grctId, b_hang, "db_t" + i), 0))) b_max = GridX_Fas_layGtri(b_grctId, b_hang, "db_t" + i);
        }
        tong = tong1 + tong2 + tong + tong3;
        GridX_datGtri(b_grctId, b_hang, ["db_tb"], tong / 12, 'K');
        GridX_datGtri(b_grctId, b_hang, ["db_cn"], GridX_Fas_layGtri(b_grctId, b_hang, "db_t3"), 'K');
        GridX_datGtri(b_grctId, b_hang, ["db_caon"], b_max, 'K');
    }
    return false;
}
function hsns_dinhbien_ns_day() {
    var b_hang = GridX_Fi_timHangA(b_grctId);
    $get(b_day).value = nvl(GridX_Fas_layGtri(b_grctId, b_hang, "phong"), 0);
}
function nvl(value1, value2) {
    if (value1 == null || value1 == "")
        return value2;
    return value1;
}
function form_dong() {
    location.reload(false);
}
function hdns_dinhbien_ns_P_IN() {
    __doPostBack('ctl00$ContentPlaceHolder1$Nhap2', '');//Xuất Excel
}
function hdns_dinhbien_ns_P_MAU() {
    __doPostBack('ctl00$ContentPlaceHolder1$btn_excel_mau', '');//Xuất file Excel mẫu

}
function hdns_dinhbien_ns_FILE_Import() {//import từ file Excel
    var b_tenf = '/App_form/ns/hdns/file_hdns.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "DINHBIEN_NS_IMP", "DINHBIEN_NS_IMP", "Import Định biên nhân sự"]], null);
    form_P_LOI('');
    return false;
}