var ns_ls_ct_tct_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_hinhthucId, b_so_idId, b_gchuId, b_doi = 0, b_ngayqdID, b_soqdID, b_ngayd, b_ngayc, b_tien_lcbId, b_tenId,
    b_tien_tnsId, b_phantram_luongId, b_tien_tdgtId, b_tongluongId;
function ns_ls_ct_tct_P_KD(b_tm) {
    ns_ls_ct_tct_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_tmf = b_tm, b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE'); b_tenId = form_Fs_TEN_ID(b_vungId, 'TEN'); b_phongId = form_Fs_TEN_ID(b_vungId, 'phong');
    b_ngayqdID = form_Fs_TEN_ID(b_vungId, 'ngay_qd'); b_soqdID = form_Fs_TEN_ID(b_vungId, 'so_qd');
    b_tien_lcbId = form_Fs_TEN_ID(b_vungId, 'tien_lcb'); b_tien_tnsId = form_Fs_TEN_ID(b_vungId, 'tien_tns');
    b_phantram_luongId = form_Fs_TEN_ID(b_vungId, 'phantram_luong'); b_tien_tdgtId = form_Fs_TEN_ID(b_vungId, 'tien_tdgt');
    b_tongluongId = form_Fs_TEN_ID(b_vungId, 'tongluong');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_slideId = b_grlkeId + '_slide';
    b_ngayd = form_Fs_TEN_ID(b_vungId, 'NGAYD'); b_ngayc = form_Fs_TEN_ID(b_vungId, 'ngayc');
}

var b_cho_control = 0;
function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_gocId).value = b_so_the;
            $get(b_tenId).value = b_ten;$get(b_gchuId).innerHTML = b_ten;
            $get(b_phongId).value = b_phong;         
            $get(b_gocId).focus();
            ns_ls_ct_tct_P_LKE();
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
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
            if (a_tso[0] == 'FILE_HTOAN') {
                ns_ls_ct_tct_P_LKE();
            }
        }
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            $get(b_gocId).setAttribute("disabled", "disabled");
            $get(b_gocId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            ns_ls_ct_tct_P_LKE();
            $get(b_gocId).focus();
        }        
        else if (b_dtuong.indexOf("THAMSO") >= 0) {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ls_ct_tct_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; form_P_MOI("", "XGL"); break; 
            case "TIEN_LCB": b_maId = b_tien_lcbId; break;
            case "TIEN_TNS": b_maId = b_tien_tnsId; break;
            case "PHANTRAM_LUONG": b_maId = b_phantram_luongId; break;
            case "TIEN_TDGT": b_maId = b_tien_tdgtId; break;            
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_ls_ct_tct_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_ls_ct_tct_P_LKE();
        }
        else if (b_maTen == "TIEN_LCB") {
            var b_tong = CSO_SO($get(b_tien_lcbId).value) + CSO_SO($get(b_tien_tnsId).value)  + CSO_SO($get(b_tien_tdgtId).value);
            var b_pt = CSO_SO($get(b_phantram_luongId).value);
            if (b_pt!=0)b_pt=b_tong*b_pt/100;
            $get(b_tongluongId).value =SO_CSO(b_tong+b_pt);
        }
        else if (b_maTen == "TIEN_TNS") {
            var b_tong = CSO_SO($get(b_tien_lcbId).value) + CSO_SO($get(b_tien_tnsId).value) + CSO_SO($get(b_tien_tdgtId).value);
            var b_pt = CSO_SO($get(b_phantram_luongId).value);
            if (b_pt != 0) b_pt =b_tong * b_pt / 100;
            $get(b_tongluongId).value = SO_CSO(b_tong + b_pt);
            //$get(b_tongluongId).value = SO_CSO(CSO_SO($get(b_tien_lcbId).value) + CSO_SO($get(b_tien_tnsId).value) + CSO_SO($get(b_phantram_luongId).value) + CSO_SO($get(b_tien_tdgtId).value));
        }
        else if (b_maTen == "PHANTRAM_LUONG") {
            var b_tong = CSO_SO($get(b_tien_lcbId).value) + CSO_SO($get(b_tien_tnsId).value) + CSO_SO($get(b_tien_tdgtId).value);
            var b_pt = CSO_SO($get(b_phantram_luongId).value);
            if (b_pt != 0) b_pt =b_tong * b_pt / 100;
            $get(b_tongluongId).value = SO_CSO(b_tong + b_pt);
            //$get(b_tongluongId).value = SO_CSO(CSO_SO($get(b_tien_lcbId).value) + CSO_SO($get(b_tien_tnsId).value) + CSO_SO($get(b_phantram_luongId).value) + CSO_SO($get(b_tien_tdgtId).value));
        }
        else if (b_maTen == "TIEN_TDGT") {
            //$get(b_tongluongId).value = SO_CSO(CSO_SO($get(b_tien_lcbId).value) + CSO_SO($get(b_tien_tnsId).value) + CSO_SO($get(b_phantram_luongId).value) + CSO_SO($get(b_tien_tdgtId).value));
        }       
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ls_ct_tct_P_NGAYKETTHUC() {
    try {
        var b_ma_lqd = "KL";
        var b_ngaybd = $get(b_ngayqdID).value;
        sns_qt.Fs_NS_KHENTHUONG_SO_QD(b_ngaybd, b_ma_lqd, ns_ls_ct_tct_P_NGAYKETTHUC_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}

function ns_ls_ct_tct_P_NGAYKETTHUC_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        $get(b_soqdID).value = b_kq;
    }
}
function ns_ls_ct_tct_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else { form_P_DatGchu(b_gchuId, b_kq); $get(b_tenId).value = b_kq; }
}

var ns_ls_ct_tct_choAct = 0;
function ns_ls_ct_tct_GR_lke_RowChange() {
    if (ns_ls_ct_tct_choAct != 0) clearTimeout(ns_ls_ct_tct_choAct);
    ns_ls_ct_tct_choAct = setTimeout("ns_ls_ct_tct_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_ls_ct_tct_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_ls_ct_tct_lkeCho); ns_ls_ct_tct_P_LKE(); }
}
function ns_ls_ct_tct_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = "0";
    $get(b_gocId).focus();
    return false;
}
function ns_ls_ct_tct_P_LKE() {
    try {        
        var b_phong = $get(b_phongId).value;
        sns_ls.Fs_TRA_TENPHONG(b_phong, ns_ls_ct_tct_P_TENPHONG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
       // sns_ls.Fs_NS_LS_CT_TCT_LKE(b_so_the, a_tso, a_cot, ns_ls_ct_tct_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ls_ct_tct_P_TENPHONG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        $get(b_phongId).value = b_kq;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_so_the = $get(b_gocId).value;
        sns_ls.Fs_NS_LS_CT_TCT_LKE(b_so_the, a_tso, a_cot, ns_ls_ct_tct_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function ns_ls_ct_tct_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}

function ns_ls_ct_tct_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") 
        {
            form_P_LOI(b_loi);
            return false;
        }
        var ktra = sosanh_Date($get(b_ngayd).value, $get(b_ngayc).value);
        if (ktra != "false" && ktra < 0) {
            form_P_LOI('loi:Ngày hết hiệu lực không được lớn hơn ngày hiệu lực:loi');
            return false;
        }
        else {
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var b_so_id = $get(b_so_idId).value;
            sns_ls.Fs_NS_LS_CT_TCT_NH(b_so_id, b_TrangKt, a_dt_ct, a_cot_lke, ns_ls_ct_tct_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}

function ns_ls_ct_tct_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        form_P_LOI('loi:Nhập thành công!:loi');
        $get(b_soqdID).focus();
    }
    return false;
}

function ns_ls_ct_tct_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "0") form_P_MOI(b_vungId, "XGL");
    else sns_ls.Fs_NS_LS_CT_TCT_CT(b_so_id, ns_ls_ct_tct_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = b_so_id;
}
function ns_ls_ct_tct_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == "") form_P_MOI(b_vungId, "XGL");
    else form_P_CH_TEXT(b_vungId, b_kq);
}
function ns_ls_ct_tct_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    //if (b_hang < 1) return;
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }

    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }

    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"),
        b_so_the = $get(b_gocId).value;
    if (b_so_id == "") ns_ls_ct_tct_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ls.Fs_NS_LS_CT_TCT_XOA(b_so_id, b_so_the, a_tso, a_cot, ns_ls_ct_tct_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_ls_ct_tct_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_ls_ct_tct_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_ls_ct_tct_P_CHUYEN_HANG(); }
    }
}
function nhap_file() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) {
        form_P_LOI('loi:Bạn phải chọn 1 bản ghi:loi')
        return false;
    }

    var b_tenf = b_tmf + '/ns/ma/file_Import_chung.aspx';
    var b_so_the = $get(b_gocId).value;
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "KTKL_KT", b_so_the, "Lưu File kỷ luật cá nhân"]], null);
    return false;
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
function form_dong() {
    location.reload(false);
}
function ns_ls_ct_tct_P_IN() {
    __doPostBack('ctl00$ContentPlaceHolder1$Nhap2', '');//Xuất Excel
}
function ns_ls_ct_tct_P_MAU() {
    __doPostBack('ctl00$ContentPlaceHolder1$btn_excel_mau', '');//Xuất file Excel mẫu

}
function ns_ls_ct_tct_FILE_Import() {//import từ file Excel
    var b_tenf = '/App_form/ns/hdns/file_hdns.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "CT_TCT_IMP", "CT_TCT_IMP", "Import lịch sử quá trình công tác trong công ty"]], null);
    form_P_LOI('');
    return false;
}