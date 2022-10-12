var ns_dt_hoctap_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_hotencanboId, b_thangdId, b_thangcId, b_nam_tnId, b_truongId, b_ma_htdtId, b_ma_cndtId, b_ma_ketqua_dtId, b_so_hieu_bangId, b_ngay_hieu_lucId, b_noteId, b_moiId, b_moi = 0, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C';
function ns_dt_hoctap_P_KD() {
    ns_dt_hoctap_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE'),
    b_hotencanboId = form_Fs_TEN_ID(b_vungId, 'hotencanbo'),
    b_thangdId = form_Fs_TEN_ID(b_vungId, 'THANGD'),
    b_thangcId = form_Fs_TEN_ID(b_vungId, 'thangc'),
    b_nam_tnId = form_Fs_TEN_ID(b_vungId, 'NAM_TN'),
    b_truongId = form_Fs_TEN_ID(b_vungId, 'TRUONG'),
    b_ma_htdtId = form_Fs_TEN_ID(b_vungId, 'ma_htdt'),
    b_ma_cndtId = form_Fs_TEN_ID(b_vungId, 'ma_cndt'),
    b_ma_ketqua_dtId = form_Fs_TEN_ID(b_vungId, 'ma_ketqua_dt'),
    b_so_hieu_bangId = form_Fs_TEN_ID(b_vungId, 'so_hieu_bang'),
    b_ngay_hieu_lucId = form_Fs_TEN_ID(b_vungId, 'ngay_hieu_luc'),
    b_noteId = form_Fs_TEN_ID(b_vungId, 'note');

    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_slideId = $get(b_grlkeId).getAttribute('slideId');
   
}
var b_cho_control = 0, b_doi = 0;
function P_cho(b_so_the, b_ten, b_phong) {
    try {

        if (b_doi == 0) {
            $get(b_gocId).value = b_so_the;
            $get(b_hotencanboId).innerHTML = b_ten;
            $get(b_thangdId).focus();
            ns_dt_hoctap_P_LKE();
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
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[0];
        b_doi = 0;
        if (b_dtuong.indexOf("SO_THE") >= 0 || b_dtuong.indexOf("THAMSO") >= 0) {
            $get(b_gocId).setAttribute("disabled", "disabled");
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
        }
        else if (b_dtuong.indexOf("MA_HTDT") >= 0) {
            $get(b_ma_htdtId).value = a_tso[0];
        }
        else if (b_dtuong.indexOf("MA_CNDT") >= 0) {
            $get(b_ma_cndtId).value = a_tso[0];
        }
    }
    catch (err) { form_P_LOI(err); }
}

function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}
function ns_dt_hoctap_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        b_mt = b_maTen;
        switch (b_maTen) {            
            case "MA_HTDT": b_maId = b_ma_htdtId; break;
            case "MA_CNDT": b_maId = b_ma_cndtId; break;            
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;

        skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_dt_hoctap_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);

        /*
        if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_dt_hoctap_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_dt_hoctap_P_LKE();
        }
        if (b_maTen == "TEN_CCHI" || b_maTen == "CNGANH" || b_maTen == "NHOM_CNGANH" || b_maTen == "XEPLOAI") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_dt_hoctap_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_dt_hoctap_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
        */
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_hoctap_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq))
        form_P_LOI(b_kq);
    else
        form_P_DatGchu(b_gchuId, b_kq);
}

var ns_dt_hoctap_choAct = 0;
function ns_dt_hoctap_GR_lke_RowChange() {
    if (ns_dt_hoctap_choAct != 0) clearTimeout(ns_dt_hoctap_choAct);
    ns_dt_hoctap_choAct = setTimeout("ns_dt_hoctap_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_dt_hoctap_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (ns_dt_hoctap_lkeCho != 0) clearTimeout(ns_dt_hoctap_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_dt_hoctap_P_LKE('K');
    }
}

function ns_dt_hoctap_P_MOI() {
    form_P_MOI(b_vungId, "XL");
    $get(b_ma_htdtId).value = "";
    $get(b_ma_cndtId).value = "";
    $get(b_ma_ketqua_dtId).value = "";
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = "0";
    $get(b_gocId).focus();
    return false;
}

function ns_dt_hoctap_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_so_the = $get(b_gocId).value;
        sns_tt.Fs_NS_DT_QT_HOCTAP_LKE(b_so_the, a_tso, a_cot, ns_dt_hoctap_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_hoctap_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    b_fcho = 'X';
}

function ns_dt_hoctap_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") {
            form_P_LOI(b_loi);
            return false;
        }
        /*var ktra = sosanh_withDateTimeNow($get(b_ngaycap).value);
        if (ktra > 0) {
            form_P_LOI('loi:Ngày cấp bằng hoặc nhỏ hơn ngày hiện tại:loi');
            return false;
        }
        var ktra = sosanh_Date($get(b_ngayd).value, $get(b_ngayc).value);
        if (ktra != "false" && ktra < 0) {
            form_P_LOI('loi:Từ ngày không được lớn hơn đến ngày:loi');
            return false;
        }*/
        if(kiemTraThang()) {
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var b_so_id = $get(b_so_idId).value;
            sns_tt.Fs_NS_DT_QT_HOCTAP_NH(b_so_id, b_TrangKt, a_dt_ct, a_cot_lke, ns_dt_hoctap_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}

function ns_dt_hoctap_NH_KQ(b_kq) {
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

function ns_dt_hoctap_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "") form_P_MOI(b_vungId, "XGL");
    else sns_tt.Fs_NS_DT_QT_HOCTAP_CT(b_so_id, ns_dt_hoctap_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = b_so_id;
}
function ns_dt_hoctap_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
function ns_dt_hoctap_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) {
        form_P_LOI("Bạn phải chọn một bản ghi để xóa");
        return false;
    }

    var message = confirm("Bạn có chắc chắn xóa không?");
    if (!message) {
        return false;
    }
    
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"),
        b_so_the = $get(b_gocId).value;
    if (b_so_id == "") ns_dt_hoctap_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_tt.Fs_NS_DT_QT_HOCTAP_XOA(b_so_id, b_so_the, a_tso, a_cot, ns_dt_hoctap_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_dt_hoctap_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dt_hoctap_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dt_hoctap_P_CHUYEN_HANG(); }
    }
}
function nhap_file() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) {
        form_P_LOI('loi:Bạn phải chọn 1 bản ghi:loi')
        return false;
    }
    var b_tenf = form_Fs_TM('f') + '/ns/ma/file_Import_chung.aspx';

    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "FILE_QT_HOCTAP", b_so_id, "Lưu văn bằng chứng chỉ quá trình học tập"]], null);
    return false;
}
function sosanh_withDateTimeNow(str) {
    var mdy_str = str.split('/');
    var mdy_str = mdy_str[2] + mdy_str[1] + mdy_str[0];
    var mdy_str = parseInt(mdy_str);
    var dateht = new Date();
    var m = "0" + (1 + dateht.getMonth());
    var y = parseInt("2" + dateht.getYear()) - 100;
    var d = "0" + dateht.getDate();
    var dmy = y + m + d;
    var dmy = parseInt(dmy);
    var kq = mdy_str - dmy;
    return kq;
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
function kiemTraThang() {
    try{
        var thangD = C_NVL($get(b_thangdId).value);
        if(!kiemTraThangNam(thangD)) {
            form_P_LOI('loi:"Từ tháng" không hợp lệ:loi')
            return false;
        }
        var thangC = C_NVL($get(b_thangcId).value);
        if(thangC != '' && !kiemTraThangNam(thangC)){
            form_P_LOI('loi:"Đến tháng" không hợp lệ:loi')
            return false;
        }

        var b_nam_tn = parseInt($get(b_nam_tnId).value);
        var a_my_str1 = thangD.split('/');
        var b_validMonth = true;
        if (thangC != "") {            
            var my_str1 = a_my_str1[1] + pad(parseInt(a_my_str1[0]));
            var a_my_str2 = thangC.split('/');
            var my_str2 = a_my_str2[1] + pad(parseInt(a_my_str2[0]));
            if(parseInt(my_str1) > parseInt(my_str2)) {
                form_P_LOI('loi:"Đến tháng" không được nhỏ hơn "Từ tháng":loi')
                b_validMonth = false;
            }

            if (b_nam_tn < parseInt(a_my_str2[1])) {
                form_P_LOI('loi:Năm tốt nghiệp không được nhỏ hơn năm "Đến tháng":loi')
                b_validMonth = false;
            }
        }
        else {
            if (b_nam_tn < parseInt(a_my_str1[1])) {
                form_P_LOI('loi:Năm tốt nghiệp không được nhỏ hơn năm "Từ tháng":loi')
                b_validMonth = false;
            }
        }

        return b_validMonth;
    }
    catch(err) {
        return false;
    }
}
function kiemTraThangNam(b_value) {
    var b_valid = true;
    var my_str = b_value.split('/');
    if(my_str.length != 2)
        b_valid = false;
    else {
        var month = parseInt(my_str[0]), year = parseInt(my_str[1]);
        if (month <= 0 || month > 12 || year <= 0)
            b_valid = false;
    }
    return b_valid;
}
function pad(s) { return (s < 10) ? '0' + s : s; }