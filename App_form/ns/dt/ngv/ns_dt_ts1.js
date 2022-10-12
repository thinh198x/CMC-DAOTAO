var ns_dt_ts_lkeCho, ns_dt_ts_gchuCho, b_vungtkId, b_grlkeId, b_slideId, b_lop_lstId, b_formName = 'ns_dt_ts', b_gchuId, b_nv, b_nsd;

function ns_dt_ts_P_KD() {
    ns_dt_ts_lkeCho, b_vungtkId = form_Fs_VUNG_ID('UPa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_hv'),
    b_nam_Id = form_Fs_TEN_ID(b_vungtkId, 'nam_lst'),
    b_lop_lstId = form_Fs_TEN_ID(b_vungtkId, 'lop_lst'),
    //b_thang_Id = form_Fs_TEN_ID(b_vungtkId, 'thang_lst'),
    //b_kdt_lstId = form_Fs_TEN_ID(b_vungtkId, 'kdt_lst'),
    //b_lop_lstId = form_Fs_TEN_ID(b_vungtkId, 'lop_lst'),

    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'),
    b_slideId = b_grlkeId + '_slide',
    b_gchuId = form_Fs_VTEN_ID('UPa_gchu', 'gchu');

    b_nv = 'LKE';
    b_nsd = form_Fs_nsd();
    ns_dt_ts_P_KLTS_DM();
    //P_cho('nam');
}

function P_cho(nv) {
    ns_dt_ts_lkeCho = setInterval('ns_dt_ts_P_LKE_CHO("' + nv + '")', 200);
}

function ns_dt_ts_P_LKE_CHO(nv) {
    nv = nv.toUpperCase();
    switch (nv) {
        case 'NAM':
            clearTimeout(ns_dt_ts_lkeCho);
            ns_dt_ts_P_LKE_KDT();
            break;
        case 'THANG':
            clearTimeout(ns_dt_ts_lkeCho);
            ns_dt_ts_P_LKE_KDT();
            break;
        case 'KDT':
            clearTimeout(ns_dt_ts_lkeCho);
            ns_dt_ts_P_LKE_LOP();
            break;
        case 'LOP':
            clearTimeout(ns_dt_ts_lkeCho);
            ns_dt_ts_P_LKE_HOCVIEN();
            break;
        case 'SLIDE':
            clearTimeout(ns_dt_ts_lkeCho);
            if (b_nv = 'TONGHOP')
                ns_dt_ts_P_TONGHOP();
            break;
        default:
            return;
    }
}

// danh sách khóa đào tạo theo kế hoạch chi tiết đã được phê duyệt
function ns_dt_ts_P_LKE_KDT() {
    try {
        var b_nam = form_Fs_TEN_GTRI(b_vungtkId, 'nam_lst'), b_thang = form_Fs_TEN_GTRI(b_vungtkId, 'thang_lst');
        if (b_nam == "") {
            //b_nam = (new Date()).getFullYear();
            //form_NhanKq(b_nam_Id, b_nam, 'K');
            form_P_LOI('Bạn chưa chọn năm');
            return;
        }
        else b_nam = CSO_SO(b_nam);
        if (b_thang == "") b_thang = 0;
        sns_dt.Fs_NS_DT_KH_CT_LKE_DR(b_nsd, b_nam, CSO_SO(b_thang), 1, b_formName, ns_dt_ts_P_LKE_KDT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ts_P_LKE_KDT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
}
// danh sách lớp thuộc KĐT
function ns_dt_ts_P_LKE_LOP() {
    try {
        var b_ma_kdt = form_Fs_TEN_GTRI(b_vungtkId, 'kdt_lst'), b_nam = form_Fs_TEN_GTRI(b_vungtkId, 'nam_lst'), b_thang = form_Fs_TEN_GTRI(b_vungtkId, 'thang_lst');
        if (b_ma_kdt == '') {
            form_P_LOI('Bạn chưa chọn khóa đào tạo nào');
            return;
        }
        if (b_nam == "") {
            form_P_LOI('Bạn chưa chọn năm');
            return;
            //b_nam = (new Date()).getFullYear();
        }
        else b_nam = CSO_SO(b_nam);
        if (b_thang == "") {
            form_P_LOI('Bạn chưa chọn tháng');
            return;
        }

        sns_dt.Fs_NS_DT_KH_CT_LOP_LKE_DR(b_nsd, b_ma_kdt, b_nam, CSO_SO(b_thang), 1, b_formName, ns_dt_ts_P_LKE_LOP_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ts_P_LKE_LOP_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
}
// thông tin chi tiết lớp đào tạo
function ns_dt_ts_P_LKE_HOCVIEN() {
    try {
        b_nv = 'LKE';
        var b_so_id_kh = form_Fs_TEN_GTRI(b_vungtkId, 'lop_lst');
        var a_cot = GridX_Fas_tenCot(b_grlkeId);//, a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.Fs_NS_DT_TS_LKE(b_nsd, b_so_id_kh, a_cot, ns_dt_ts_P_LKE_HOCVIEN_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
    return false;
}
function ns_dt_ts_P_LKE_HOCVIEN_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');

    form_P_CH_TEXT(b_vungtkId, a_kq[0]);
    var b_dong = CSO_SO(a_kq[1]);
    if (b_dong < 12) b_dong = 12;
    GridX_P_hangKt(b_grlkeId, b_dong);
    GridX_datBang(b_grlkeId, a_kq[2]);
}
// tổng hợp danh sách tuyển sinh
function ns_dt_ts_P_TONGHOP() {
    try {
        var b_so_id_kh = form_Fs_TEN_GTRI(b_vungtkId, 'lop_lst'), b_ma_kdt = form_Fs_TEN_GTRI(b_vungtkId, 'kdt_lst'),
             b_nam = form_Fs_TEN_GTRI(b_vungtkId, 'nam_lst'), b_thang = form_Fs_TEN_GTRI(b_vungtkId, 'thang_lst');
        if (b_ma_kdt == '') {
            form_P_LOI('Bạn chưa chọn khóa đào tạo nào');
            return false;
        }
        if (b_so_id_kh == '') {
            form_P_LOI('Bạn chưa chọn lớp đào tạo nào');
            return false;
        }
        if (b_nam == "") {
            form_P_LOI('Bạn chưa chọn năm');
            return false;
            //b_nam = (new Date()).getFullYear();
        }
        else b_nam = CSO_SO(b_nam);
        if (b_thang == "") {
            form_P_LOI('Bạn chưa chọn tháng');
            return false;
        }
        b_nv = 'TONGHOP';
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.Fs_NS_DT_TS_TONGHOP(b_nsd, b_so_id_kh, b_ma_kdt, b_nam, b_thang, a_tso, a_cot, ns_dt_ts_P_TONGHOP_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
    return false;
}

function ns_dt_ts_P_TONGHOP_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    GridX_P_hangKt(b_grlkeId, 12);
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
// danh mục kết luận tuyển sinh: danh mục dùng chung, mã nhóm = 'NS_DT_KLTS'
function ns_dt_ts_P_KLTS_DM() {
    try {
        sns_ma_ch.Fs_NS_MA_CHUNG_LKE_DR("NS_DT_KLTS", ns_dt_ts_P_KLTS_DM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ts_P_KLTS_DM_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    GridX_listCot(b_grlkeId, "kluan", a_kq[1], a_kq[0]);// b_lke = mảng text, b_tra = mảng value    
}
// thêm học viên ngoài: ko lấy từ đề xuất
function ns_dt_ts_P_THEM() {
    var b_so_id_kh = form_Fs_TEN_GTRI(b_vungtkId, 'lop_lst'), b_lop = $get(b_lop_lstId).value;
    form_P_MO('/App_form/ns/dt/ngv/ns_dt_ts_them.aspx', window.name, ["THAMSO", [window.name, b_so_id_kh, b_lop]]);
    return false;
}
// lưu kết luận tuyển sinh
function ns_dt_ts_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_grlkeId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }

        var b_so_id_kh = form_Fs_TEN_GTRI(b_vungtkId, 'lop_lst'), b_ma_kdt = form_Fs_TEN_GTRI(b_vungtkId, 'kdt_lst'),
                 b_nam = form_Fs_TEN_GTRI(b_vungtkId, 'nam_lst'), b_thang = form_Fs_TEN_GTRI(b_vungtkId, 'thang_lst');
        if (b_ma_kdt == '') {
            form_P_LOI('Bạn chưa chọn khóa đào tạo nào');
            return false;
        }
        if (b_so_id_kh == '') {
            form_P_LOI('Bạn chưa chọn lớp đào tạo nào');
            return false;
        }
        if (b_nam == "") {
            form_P_LOI('Bạn chưa chọn năm');
            return false;
            //b_nam = (new Date()).getFullYear();
        }
        else b_nam = CSO_SO(b_nam);
        if (b_thang == "") {
            form_P_LOI('Bạn chưa chọn tháng');
            return false;
        }

        var a_cot_ct = GridX_Fdt_cotGtri(b_grlkeId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.Fs_NS_DT_TS_NH(b_nsd, b_so_id_kh, a_cot_ct, b_ma_kdt, b_nam, b_thang, a_tso, a_cot_lke, b_nv, ns_dt_ts_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
    return false;
}
function ns_dt_ts_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        if (b_nv == 'TONGHOP')
            ns_dt_ts_P_TONGHOP_KQ(b_kq);
        else
            ns_dt_ts_P_LKE_HOCVIEN_KQ(b_kq);
        ns_dt_ts_P_DatGchu(true, "Cập nhật thành công!");
    }
    return false;
}
// xoa danh sach chon tren grid
function ns_dt_ts_P_XOA() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_grlkeId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }

        var b_so_id_kh = form_Fs_TEN_GTRI(b_vungtkId, 'lop_lst'), b_ma_kdt = form_Fs_TEN_GTRI(b_vungtkId, 'kdt_lst'),
                 b_nam = form_Fs_TEN_GTRI(b_vungtkId, 'nam_lst'), b_thang = form_Fs_TEN_GTRI(b_vungtkId, 'thang_lst');
        if (b_ma_kdt == '') {
            form_P_LOI('Bạn chưa chọn khóa đào tạo nào');
            return false;
        }
        if (b_so_id_kh == '') {
            form_P_LOI('Bạn chưa chọn lớp đào tạo nào');
            return false;
        }
        else b_so_id_kh = CSO_SO(b_so_id_kh);
        if (b_nam == "") {
            form_P_LOI('Bạn chưa chọn năm');
            return false;
            //b_nam = (new Date()).getFullYear();
        }
        else b_nam = CSO_SO(b_nam);
        if (b_thang == "") {
            form_P_LOI('Bạn chưa chọn tháng');
            return false;
        }
        else b_thang = CSO_SO(b_thang);

        var a_cot_ct = GridX_Fdt_cotGtri(b_grlkeId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.Fs_NS_DT_TS_XOA(b_nsd, b_so_id_kh, a_cot_ct, b_ma_kdt, b_nam, b_thang, a_tso, a_cot_lke, b_nv, ns_dt_ts_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) {
        form_P_LOI(err);
    }
    return false;
}
function ns_dt_ts_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        if (b_nv == 'TONGHOP')
            ns_dt_ts_P_TONGHOP_KQ(b_kq);
        else
            ns_dt_ts_P_LKE_HOCVIEN_KQ(b_kq);
        ns_dt_ts_P_DatGchu(true, "Xóa thành công!");
    }
    return false;
}
// import danh sách học viên ngoài
function ns_dt_ts_P_IMPORT() {
    var b_so_id_kh = form_Fs_TEN_GTRI(b_vungtkId, 'lop_lst');
    if (b_so_id_kh == '') {
        form_P_LOI('Bạn chưa chọn lớp đào tạo nào');
        return false;
    }

    var b_tenf = '/App_form/ns/dt/ngv/file_dt.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "TUYEN_SINH_IMP", "TUYEN_SINH_IMP", "Import danh sách tuyển sinh ngoài", b_so_id_kh]], null);
    form_P_LOI('');
    return false;
}
// gửi email đến học viên
function ns_dt_ts_P_EMAIL() {
    return false;
}
// xuất excel danh sách học viên
function ns_dt_ts_P_EXCEL() {
    return false;
}

function ns_dt_ts_P_DatGchu(show, gchu) {
    form_P_DatGchu(b_gchuId, gchu);
    if (show) ns_dt_ts_gchuCho = setInterval('ns_dt_ts_P_DatGchu(false,".")', 2000);
    else if (ns_dt_ts_gchuCho) clearTimeout(ns_dt_ts_gchuCho);
}