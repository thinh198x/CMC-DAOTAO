
var ns_qhe_tt_lkeCho, b_vungId, b_grlkeId, b_slideId,b_ttDinhkem = 0, b_gocId, b_sothe_tnId, b_tenId, b_tuoiId, b_so_idId, b_gchuId, b_moiId, b_phuthuocId, b_doi = 0, b_ngaydId, b_ngay_gtId, b_tencbId, b_so_the_an_Id;
function ns_qhe_tt_P_KD() {
    ns_qhe_tt_lkeCho = setInterval('ns_qhe_tt_P_CHO()', 200);

}
function ns_qhe_tt_P_CHO() {
    if (document.readyState === 'complete') {
        clearInterval(ns_qhe_tt_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE'),
        b_tenId = form_Fs_TEN_ID(b_vungId, 'ten'), b_tuoiId = form_Fs_TEN_ID(b_vungId, ''), b_phuthuocId = form_Fs_TEN_ID(b_vungId, 'phuthuoc'),
        b_ngay_gtId = form_Fs_TEN_ID(b_vungId, 'ngayc'), b_ngaydId = form_Fs_TEN_ID(b_vungId, 'ngayd'), b_tencbId = form_Fs_TEN_ID(b_vungId, 'tencb');
        b_tinhthanhId = form_Fs_TEN_ID(b_vungId, 'tinhthanh'), b_quanhuyenId = form_Fs_TEN_ID(b_vungId, 'quanhuyen'), b_phuongxaId = form_Fs_TEN_ID(b_vungId, 'phuongxa');
        b_so_the_an_Id = form_Fs_TEN_ID(b_vungId, 'ASOTHE');
        b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
        b_gchuId = form_Fs_VTEN_ID('', 'gchu');
        b_moiId = form_Fs_VTEN_ID('', 'moi');
        b_slideId = b_grlkeId + '_slide_ctrdivL';
        slide_P_MOI(b_slideId);
    }
}
var b_cho_control = 0;
function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_gocId).value = b_so_the;
            $get(b_gchuId).innerHTML = b_ten;
            $get(b_tencbId).value = b_ten;
            ns_qhe_tt_P_LKE();
            b_doi = 1;
            clearTimeout(b_cho_control);
            $get(b_tenId).focus();
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
        if (b_dtuong.indexOf("SO_THE") >= 0 || b_dtuong.indexOf("THAMSO") >= 0) {
            //$get(b_gocId).setAttribute("disabled", "disabled");
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
        }
        else if (b_dtuong.indexOf("SOTHE_TNHAN") >= 0) {
            $get(b_sothe_tnId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_tenId).value = a_tso[1];
            $get(b_sothe_tnId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_qhe_tt_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; form_P_MOI("", "XGL"); break;
            case "SOTHE_TNHAN": b_maId = b_sothe_tnId; form_P_MOI("", "XGL"); break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_qhe_tt_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_qhe_tt_P_LKE();
        }
        else if (b_maTen == "SOTHE_TNHAN")
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_qhe_tt_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_qhe_tt_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else { form_P_DatGchu(b_gchuId, b_kq); $get(b_tencbId).value = b_kq; }
}

var ns_qhe_tt_choAct = 0;
function ns_qhe_tt_GR_lke_RowChange() {
    if (ns_qhe_tt_choAct != 0) clearTimeout(ns_qhe_tt_choAct);
    ns_qhe_tt_choAct = setTimeout("ns_qhe_tt_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_qhe_tt_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_qhe_tt_lkeCho); ns_qhe_tt_P_LKE(); }
}

function ns_qhe_tt_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = "0";
    $get(b_gocId).focus();
    return false;
}

function ns_qhe_tt_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_so_the = $get(b_gocId).value;
        sns_tt.Fs_NS_QHE_TT_LKE(b_so_the, a_tso, a_cot, ns_qhe_tt_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function ns_qhe_tt_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}

function ns_qhe_tt_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var ktra = sosanh_Date($get(b_ngaydId).value, $get(b_ngay_gtId).value);
        if (ktra != "false" && ktra < 0) form_P_LOI('loi:Từ ngày không được lớn hơn đến ngày:loi');
        else {
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang > 0) {
                b_tt = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tthai"));
                if (b_tt == 'G') { form_P_LOI('loi:Không thể sửa bản ghi đã ở trạng thái đã gửi:loi'); return false; }
                if (b_tt == '1') { form_P_LOI('loi:Không thể sửa bản ghi đã ở trạng thái phê duyệt:loi'); return false; }
            }
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var b_so_id = $get(b_so_idId).value; 
            sns_tt.Fs_NS_QHE_TT_NH(b_so_id, b_TrangKt, a_dt_ct, a_cot_lke, ns_qhe_tt_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}

function ns_qhe_tt_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI("loi:Nhập thành công:loi");
    }
    return false;
}

function ns_qhe_tt_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "") form_P_MOI(b_vungId, "XGL");
    else sns_tt.Fs_NS_QHE_TT_CT(b_so_id, ns_qhe_tt_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = b_so_id;
}

function ns_qhe_tt_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
function ns_qhe_tt_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"), b_tt = GridX_Fas_layGtri(b_grlkeId, b_hang, "tthai"),
        b_so_the = $get(b_gocId).value;
    if (b_so_id == "") ns_qhe_tt_P_MOI();
    else {
        if (b_tt == "0") {
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            sns_tt.Fs_NS_QHE_TT_XOA(b_so_id, b_so_the, a_tso, a_cot, ns_qhe_tt_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        } else {
            form_P_LOI("loi:Không thể xóa bản ghi đã ở trạng thái đã gửi hoặc phê duyệt:loi"); return false;
        }
    }
    return false;
}
function ns_qhe_tt_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_qhe_tt_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_qhe_tt_P_CHUYEN_HANG(); }
    }
}
function sosanh_Date(str1, str2) {
    var kq;
    if (str1 == "" || str2 == "")
        kq = false;
    else {
        var mdy_str1 = str1.split('/');
        var mdy_str1 = mdy_str1[2] + mdy_str1[1] + mdy_str1[0];
        var mdy_str1 = parseInt(mdy_str1);
        var mdy_str2 = str2.split('/');
        var mdy_str2 = mdy_str2[2] + mdy_str2[1] + mdy_str2[0];
        var mdy_str2 = parseInt(mdy_str2);
        kq = mdy_str2 - mdy_str1;
    }
    return kq;
}
function ns_qhe_tt_P_EXCEL() {
    var b_so_the = $get(b_gocId).value;
    $get(b_so_the_an_Id).value = b_so_the;
    if (b_so_the_an_Id != "") {
        var b_btn_excel = form_Fs_VTEN_ID('', 'XuatExcel'); $get(b_btn_excel).click(); form_chay = 0; return false;
    }
    else { form_P_LOI("loi:Bạn phải chọn cán bộ:loi"); return false; }
}
function ns_qhe_tt_P_EXCEL_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
}
function ns_qhe_tt_P_MAU() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'FileMau'); $get(b_btn_excel).click(); form_chay = 0; return false;
}
function ns_qhe_tt_FILE_IMPORT() {//import từ file Excel
    var b_tenf = '/App_form/ns/ma/file_import_hdns.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "ns_qhe_tt", "ns_qhe_tt", "Quan hệ nhân thân"]], null);
    form_P_LOI('');
    return false;
}
function ns_qhe_tt_P_GUI() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("Bạn phải chọn một bản ghi để gửi"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"), b_tt = GridX_Fas_layGtri(b_grlkeId, b_hang, "tthai"),
        b_so_the = $get(b_gocId).value;
    if (b_so_id == "") ns_qhe_tt_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_tt.Fs_NS_QHE_TT_GUI(b_so_id, b_so_the, a_tso, a_cot, ns_qhe_tt_P_GUI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_qhe_tt_P_GUI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_qhe_tt_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_qhe_tt_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Gửi phê duyệt thành công:loi");
    }
}
function nhap_file() {   
    b_ttDinhkem = 1;
    var b_tenf = '/App_form/ns/ma/file_Import_chung.aspx';
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "") {
        b_so_id = "NS_QH";
    }
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, b_so_id, "Quanhe_nhanthan", "Import dữ liệu -Quan hệ nhân thân"]], null);
    form_P_LOI('');
    return false;
}
function form_dong() {
    location.reload(false);
}
function ns_qhe_tt_P_KTRA_DR(b_maTen) {
    try {
        var b_ma = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "TINHTHANH": b_ma = form_Fs_TEN_GTRI(b_vungId, 'tinhthanh'); break;
            case "QUANHUYEN": b_ma = form_Fs_TEN_GTRI(b_vungId, 'quanhuyen'); break;
            case "PHUONGXA": b_ma = form_Fs_TEN_GTRI(b_vungId, 'phuongxa'); break;
        }

        if (b_maTen == "TINHTHANH") {
            //sns_tt.Fs_NS_QHE_TT_QH_XEM(b_ma, 'DT_THQH', ns_qhe_tt_P_KTRA_DR_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            $get(b_quanhuyenId).value = '';
            var b_ktra = "ns_ma_qh,ma,ten,MA_TT," + b_ma;
            var b_ctr = form_Fctr_TEN_DTUONG(b_vungId, 'quanhuyen')
            Attribute_P_DAT(b_ctr, 'ham_list', [b_ktra]);
        } else if (b_maTen == "QUANHUYEN") {
            //sns_tt.Fs_NS_QHE_TT_XP_XEM(b_ma, 'DT_THXP', ns_qhe_tt_P_KTRA_DR_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            $get(b_phuongxaId).value = '';
            var b_ktra = "ns_ma_xp,ma,ten,MA_QH," + b_ma;
            var b_ctr = form_Fctr_TEN_DTUONG(b_vungId, 'phuongxa')
            Attribute_P_DAT(b_ctr, 'ham_list', [b_ktra]);
        }
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_qhe_tt_P_KTRA_DR_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        //ns_hdns_ma_vtcdanh_P_LKE();
    }
}