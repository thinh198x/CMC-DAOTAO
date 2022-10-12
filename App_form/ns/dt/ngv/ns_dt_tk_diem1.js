var ns_dt_tk_diem_lkeCho, b_vungId, b_grlkeId, b_grlke_cpId, b_slideId, b_DR_namId, b_DR_thangId, b_DR_kdtId, b_DR_lopId, b_gchuId, b_so_id_kh, b_so_id_tk = 0,
    b_so_mon_maxId, b_so_monId, b_ten_monId, a_ma_mon, b_so_mon_max, ns_dt_tk_diem_gchuCho, b_nsd;

function ns_dt_tk_diem_P_KD() {
    b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_kq'), b_slideId = b_grlkeId + '_slide',
    b_DR_namId = form_Fs_TEN_ID(b_vungId, 'DR_nam'),
    b_DR_thangId = form_Fs_TEN_ID(b_vungId, 'DR_thang'),
    b_DR_kdtId = form_Fs_TEN_ID(b_vungId, 'DR_kdt'),
    b_DR_lopId = form_Fs_TEN_ID(b_vungId, 'DR_lop'),
    b_so_mon_maxId = form_Fs_VTEN_ID('UPa_hi', 'so_mon_max'),
    b_so_monId = form_Fs_VTEN_ID('UPa_hi', 'so_mon'),
    b_ten_monId = form_Fs_VTEN_ID('UPa_hi', 'ten_mon');
    b_gchuId = form_Fs_VTEN_ID('UPa_nhap', 'gchu');

    b_so_mon_max = parseInt($get(b_so_mon_maxId).value);
    b_nsd = form_Fs_nsd();
    ns_dt_tk_diem_P_KQDT_DM();
    //ns_dt_tk_diem_lkeCho = setInterval('ns_dt_kh_ct_P_LKE_CHO()', 200);
}

function ns_dt_kh_ct_P_KTRA(b_maTen) {
    try {
        b_maTen = b_maTen.toUpperCase();
        if (b_maTen == "DR_NAM") {
            // xoa dr_thang
        }
        else if (b_maTen == "DR_THANG") {
            // lay danh sach khoa dao tao
            ns_dt_tk_diem_P_DKT_LKE();
        }
        else if (b_maTen == "DR_KDT") {
            // lay danh sach lop
            ns_dt_tk_diem_P_LOP_LKE();
        }
        else if (b_maTen == "DR_LOP") {
            // lay thong tin lop
            ns_dt_tk_diem_P_LOP_CT();
            // lay danh sach diem
            ns_dt_tk_diem_P_LKE();
        }
    }
    catch (err) { form_P_LOI(err); }
}

// danh sách khóa đào tạo được triển khai
function ns_dt_tk_diem_P_DKT_LKE() {
    var nam = form_Fs_TEN_GTRI(b_vungId, 'DR_nam'), thang = form_Fs_TEN_GTRI(b_vungId, 'DR_thang');
    sns_dt.Fs_NS_DT_TK_LKE_KDT(b_nsd, nam, thang, "ns_dt_tk_diem", ns_dt_tk_diem_P_DKT_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function ns_dt_tk_diem_P_DKT_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
}
// danh sach lop thuoc 1 khoa dao tao
function ns_dt_tk_diem_P_LOP_LKE() {
    var b_nam = form_Fs_TEN_GTRI(b_vungId, 'DR_nam'), b_thang = form_Fs_TEN_GTRI(b_vungId, 'DR_thang'),
        b_ma_kdt = form_Fs_TEN_GTRI(b_vungId, 'DR_kdt');
    sns_dt.Fs_NS_DT_TK_LKE_LOP(b_nsd, b_nam, b_thang, b_ma_kdt, "ns_dt_tk_diem", ns_dt_tk_diem_P_LOP_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function ns_dt_tk_diem_P_LOP_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
}
// lay thong tin lop
function ns_dt_tk_diem_P_LOP_CT() {
    b_so_id_kh = form_Fs_TEN_GTRI(b_vungId, 'DR_lop');
    sns_dt.Fs_NS_DT_TK_LOP_CT(b_nsd, b_so_id_kh, ns_dt_tk_diem_P_LOP_CT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function ns_dt_tk_diem_P_LOP_CT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
// lay danh sach diem
// use
function ns_dt_tk_diem_P_LKE() {
    try {
        b_so_id_kh = form_Fs_TEN_GTRI(b_vungId, 'DR_lop');
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.Fs_NS_DT_TK_DIEM_LKE(b_nsd, b_so_id_kh, b_so_mon_max, a_tso, a_cot, ns_dt_tk_diem_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
// use
function ns_dt_tk_diem_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    b_so_id_tk = a_kq[1];
    GridX_datBang(b_grlkeId, a_kq[2]);
    a_ma_mon = a_kq[3].split(String.fromCharCode(1));
    var a_ten_mon = a_kq[4].split(String.fromCharCode(1));
    $get(b_so_monId).value = a_ten_mon.length;
    $get(b_ten_monId).value = a_kq[4];
    // ẩn hiện cột điểm
    var b_dat;
    for (var i = 0; i < a_ma_mon.length; i++) {
        GridX_anCot(b_grlkeId, "ngay_thi_" + i + ",diem_" + i + ",tr_so_" + i, "");
        GridX_titCot(b_grlkeId, "diem_" + i, a_ten_mon[i]);
    }
    for (var i = a_ma_mon.length; i <= b_so_mon_max; i++) {
        b_dat = "none";
        GridX_anCot(b_grlkeId, "ngay_thi_" + i + ",diem_" + i + ",tr_so_" + i, b_dat);
    }
}
// use: danh mục kết quả điểm
function ns_dt_tk_diem_P_KQDT_DM() {
    try {
        sns_ma_ch.Fs_NS_MA_CHUNG_LKE_DR("KQDTNB", ns_dt_tk_diem_P_KQDT_DM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
// use
function ns_dt_tk_diem_P_KQDT_DM_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }

    var a_kq = Fas_ChMang(b_kq, '#');
    GridX_listCot(b_grlkeId, "kq", a_kq[1], a_kq[0]);// b_lke = mảng text, b_tra = mảng value    
}
// use
function ns_dt_tk_diem_P_NH() {
    try {
        if (b_so_id_tk == 0) {
            form_P_LOI("Bạn chưa chọn lớp để nhập điểm");
            return false;
        }
        var a_dt_ct = GridX_Fdt_cotGtri(b_grlkeId);
        sns_dt.Fs_NS_DT_TK_DIEM_NH(b_nsd, b_so_id_kh, b_so_id_tk, a_ma_mon, a_dt_ct, ns_dt_tk_diem_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { throw (err); }
    return false;
}

// use
function ns_dt_tk_diem_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    else ns_dt_diem_P_DatGchu(true, "Cập nhật thành công!");
    return false;
}


// use
function ns_dt_tk_diem_P_XOA() {
    try {
        if (b_so_id_tk == 0) { form_P_LOI("Chưa có thông tin triển khai lớp đào tạo để xóa"); return false; }
        sns_dt.Fs_NS_DT_TK_DIEM_XOA(b_nsd, b_so_id_tk, ns_dt_tk_diem_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { throw (err); }
    return false;
}
// use
function ns_dt_tk_diem_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        ns_dt_tk_diem_P_MOI();
    }
    return false;
}
// tính điểm trung bình
function ns_dt_tk_diem_GR_Update(b_event) {
    try {
        var b_hang = b_event.srcElement.parentNode.parentNode.rowIndex;
        var b_so_the = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the");
        if (b_so_the == "") {
            GridX_datTrang(b_grlkeId, b_hang);
            return;
        }
        var b_id = b_event.srcElement.id;
        if (b_id.indexOf("diem_") < 0) return;
        var b_tong_diem = 0, b_tong_tr_so = 0, b_tr_so;
        for (var i = 0; i < a_ma_mon.length; i++) {
            b_tr_so =  CSO_SO(GridX_Fas_layGtri(b_grlkeId, b_hang, 'tr_so_' + i));
            b_tong_diem += CSO_SO(GridX_Fas_layGtri(b_grlkeId, b_hang, 'diem_' + i)) * b_tr_so;
            b_tong_tr_so += b_tr_so;
        }
        
        var b_dtb = Math.round((b_tong_diem * 100) / b_tong_tr_so) / 100;// Math.round(b_tong_diem / b_tong_tr_so, 1);
        GridX_datGtri(b_grlkeId, b_hang, ["dtb"], b_dtb, 'K');
    }
    catch (ex) { form_P_LOI(ex.message); }
}

// use
function ns_dt_tk_diem_P_MOI() {
    b_so_id_tk = 0;
    form_P_MOI(b_grlkeId, "XL");
    //Số hàng đã nhập của grid
    //gridId(string): Id lưới
    var b_hang = GridX_Fi_hangSo(b_grlkeId);
    var b_cot = b_so_id_tkb.length + 9;
    //GridX_datTrang(b_grlkeId,6);
    GridX_thayGtriT(b_grlkeId, "", "");
    //for (var i = 0; i < b_hang; i++) {
    //    GridX_datTrang(b_grlkeId, 2, i);
    //}

    //GridX_datTrang(b_grlke_cpId);
    return false;
}

function ns_dt_diem_P_DatGchu(show, gchu) {    
    form_P_DatGchu(b_gchuId, gchu);
    if (show) ns_dt_tk_diem_gchuCho = setInterval('ns_dt_diem_P_DatGchu(false,".")', 2000);
    else clearTimeout(ns_dt_tk_diem_gchuCho);
}

//use
function ns_dt_tk_diem_P_IMPORT() {
    if (b_so_id_tk == 0) {
        form_P_LOI("Bạn chưa chọn lớp để nhập điểm");
        return false;
    }

    var b_tenf = '/App_form/ns/dt/ngv/file_dt.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "DIEM_IMP", "DIEM_IMP", "Nhập điểm từ file excel", b_so_id_tk, b_so_id_kh, $get(b_so_monId).value]], null);
    return false;
}