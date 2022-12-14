var ns_tl_khoan_phaithu_lkeCho, b_vungId, b_grlkeId, b_vungtkId, b_slideId, b_gocId, b_hinhthucId, b_so_idId, b_gchuId, b_doi = 0,
    b_so_thetkId, b_ten_tkId, b_nam_tkId, b_kyluong_tkId, b_tenId, b_ten_phongId, b_ten_cdanhId, b_phongId, b_cdanhId, b_ngaytaoId;
function ns_tl_khoan_phaithu_P_KD(b_tm) {
    ns_tl_khoan_phaithu_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_vungtkId = form_Fs_VUNG_ID('UPa_tk');
    b_namId = form_Fs_TEN_ID(b_vungId, 'NAM'), b_kyluongId = form_Fs_TEN_ID(b_vungId, 'KYLUONG_ID');
    b_tmf = b_tm, b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE'); b_tenId = form_Fs_TEN_ID(b_vungId, 'TEN'); b_ten_phongId = form_Fs_TEN_ID(b_vungId, 'ten_phong');
    b_ten_cdanhId = form_Fs_TEN_ID(b_vungId, 'ten_cdanh'); b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_phongId = form_Fs_TEN_ID(b_vungId, 'phong'), b_cdanhId = form_Fs_TEN_ID(b_vungId, 'cdanh');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu'), b_ngaytaoId = form_Fs_TEN_ID(b_vungId, 'ngaytao');
    b_so_thetkId = form_Fs_VTEN_ID(b_vungtkId, 'so_the_tk'), b_ten_tkId = form_Fs_VTEN_ID(b_vungtkId, 'ten_tk');
    b_nam_tkId = form_Fs_VTEN_ID(b_vungtkId, 'nam_tk'), b_kyluong_tkId = form_Fs_VTEN_ID(b_vungtkId, 'kyluong_tk');
    b_slideId = b_grlkeId + '_slide_ctrdivL';
    var today = new Date();
    lke_P_DAT($get(b_namId), today.getFullYear() + '{' + today.getFullYear());
    ns_tl_khoan_phaithu_P_NAM("NAM");
    ns_tl_khoan_phaithu_lkeCho = setInterval('ns_tl_khoan_phaithu_P_LKE_CHO()', 200);
}

var b_cho_control = 0;
function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_gocId).value = b_so_the;
            $get(b_tenId).value = b_ten;
            $get(b_ten_phongId).value = b_phong;
            $get(b_gchuId).innerHTML = b_ten;
            $get(b_gocId).focus();
            ns_tl_khoan_phaithu_P_LKE();
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
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            $get(b_gocId).value = a_tso[0];
            $get(b_tenId).value = a_tso[1];
            tra_thong_tin(a_tso[0]);
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_gocId).focus();
        }
        else if (b_dtuong.indexOf("THAMSO") >= 0) {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
        } else if (b_dtuong.indexOf("TAI_IMPORT") >= 0) {
            ns_tl_khoan_phaithu_P_LKE('M');
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_khoan_phaithu_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; form_P_MOI("", "X"); break;

        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_tl_khoan_phaithu_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            tra_thong_tin(b_ma.value);
        }

    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_khoan_phaithu_PHONG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    ns_tl_khoan_phaithu_P_LKE();
}

function ns_tl_khoan_phaithu_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else { form_P_DatGchu(b_gchuId, b_kq); $get(b_tenId).value = b_kq; }
}

var ns_tl_khoan_phaithu_choAct = 0;
function ns_tl_khoan_phaithu_GR_lke_RowChange() {
    if (ns_tl_khoan_phaithu_choAct != 0) clearTimeout(ns_tl_khoan_phaithu_choAct);
    ns_tl_khoan_phaithu_choAct = setTimeout("ns_tl_khoan_phaithu_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_tl_khoan_phaithu_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "0") { form_P_MOI(b_vungId, "XGL"); $get(b_ngaytaoId).value = getDateNow(); }
    else stl_ma.Fs_NS_TL_KHOAN_PHAITHU_CT(b_so_id, ns_tl_khoan_phaithu_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = b_so_id;
}
function ns_tl_khoan_phaithu_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == "") form_P_MOI(b_vungId, "XGL");
    else form_P_CH_TEXT(b_vungId, b_kq);
}

function ns_tl_khoan_phaithu_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_tl_khoan_phaithu_lkeCho); ns_tl_khoan_phaithu_P_LKE(); }
}
function ns_tl_khoan_phaithu_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_so_the = $get(b_so_thetkId).value, b_ten_tk = $get(b_ten_tkId).value,
            b_nam = lke_Fs_TRA($get(b_nam_tkId)), b_kyluong_tk = lke_Fs_TRA($get(b_kyluong_tkId));
        stl_ma.Fs_NS_TL_KHOAN_PHAITHU_LKE(b_so_the, b_ten_tk, b_nam, b_kyluong_tk, a_tso, a_cot, ns_tl_khoan_phaithu_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_khoan_phaithu_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}

function ns_tl_khoan_phaithu_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = "0";
    $get(b_gocId).focus(); 
    var today = new Date();
    lke_P_DAT($get(b_namId), today.getFullYear() + '{' + today.getFullYear());
    ns_tl_khoan_phaithu_P_NAM("NAM");
    return false;
}
function ns_tl_khoan_phaithu_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") {
            form_P_LOI(b_loi);
            return false;
        }

        else {
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var b_so_id = $get(b_so_idId).value, b_so_the = $get(b_so_thetkId).value, b_ten_tk = $get(b_ten_tkId).value,
                b_nam_tk = lke_Fs_TRA($get(b_nam_tkId)), b_kyluong_tk = lke_Fs_TRA($get(b_kyluong_tkId));
            stl_ma.Fs_NS_TL_KHOAN_PHAITHU_NH(b_so_id, b_so_the, b_ten_tk, b_nam_tk, b_kyluong_tk, b_TrangKt, a_dt_ct, a_cot_lke, ns_tl_khoan_phaithu_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_tl_khoan_phaithu_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        form_P_LOI('loi:Nhập thành công!:loi');
        $get(b_gocId).focus();
    }
    return false;
}

function ns_tl_khoan_phaithu_P_NAM(b_dk) {
    try {
        if (b_dk == "NAM_TK") {
            var b_nam = form_Fs_TEN_GTRI(b_vungtkId, 'NAM_TK'); 
            if (b_nam != "")
                hts_dungchung.Fs_NS_KYLUONG_LKE_BYNAM(form_Fs_nsd(), window.name, "DT_KYLUONG_TK", b_nam);
        } else {
            var b_nam = form_Fs_TEN_GTRI(b_vungId, 'NAM');
            if (b_nam != "")
                hts_dungchung.Fs_NS_KYLUONG_LKE_BYNAM(form_Fs_nsd(), window.name, "DT_KY", b_nam);
        }
    }
    catch (ex) { form_P_LOI(ex.message); }
} 
 
function ns_tl_khoan_phaithu_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    //if (b_hang < 1) return;
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }

    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }

    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");

    if (b_so_id == "") ns_tl_khoan_phaithu_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_so_the = $get(b_so_thetkId).value, b_ten_tk = $get(b_ten_tkId).value,
            b_nam_tk = lke_Fs_TRA($get(b_nam_tkId)), b_kyluong_tk = lke_Fs_TRA($get(b_kyluong_tkId));
        stl_ma.Fs_NS_TL_KHOAN_PHAITHU_XOA(b_so_id, b_so_the, b_ten_tk, b_nam_tk, b_kyluong_tk, a_tso, a_cot, ns_tl_khoan_phaithu_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_tl_khoan_phaithu_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_tl_khoan_phaithu_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_tl_khoan_phaithu_P_CHUYEN_HANG(); }
    }
}
  
function ns_tl_khoan_phaithu_P_IN() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_so_the = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the");
    if (b_so_the == "" || b_so_the == null) { form_P_LOI("Bạn phải chọn một bản ghi để in"); return false; }
    else {
        __doPostBack('ctl00$ContentPlaceHolder1$Xuat2', '');//Xuất quyết định
    }
}

function tra_thong_tin(b_so_the) {
    try {
        stl_ma.Fs_NS_TL_KHOAN_PHAITHU_TRA(b_so_the, tra_thong_tin_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function tra_thong_tin_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    $get(b_ten_phongId).value = a_kq[0]; $get(b_ten_cdanhId).value = a_kq[1];
    $get(b_phongId).value = a_kq[2]; $get(b_cdanhId).value = a_kq[3];
}


//IMPORT EXCEL
function ns_tl_khoan_phaithu_P_MAU() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'btn_excel_mau');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;

}
function ns_tl_khoan_phaithu_FILE_Import() {
    var b_tenf = '/App_form/ns/ma/file_Import.aspx';
    form_P_MO(b_tenf, window.name + ',THAMSO', ['THAMSO', [window.name, 'KHOAN_PHAITHU_IMP', null, "Import thông tin khoản thu"]], null);
    form_P_LOI('');
    return false;
}
 
function form_dong() {
    location.reload(false);
}