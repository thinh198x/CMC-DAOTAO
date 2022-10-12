var ns_ttb_lkeCho, b_vungId, b_vung_tk_Id, b_grlkeId, b_slideId, b_gocId, b_tenId, b_cdanh_Id, b_phong_Id, b_gchuId, b_so_idId, b_moiId, b_doi = 0, b_t, b_nhomId, b_tienId, b_tien_an_Id, b_tentbId,
    b_cb_giaoId, b_ma_cb_giaoId, b_phong_giao_Id, b_ngaycapId, b_ngaythuId, b_soluongId, b_phong_tk_Id, b_so_the_tk_Id, b_hoten_tk_Id, b_nsd, b_cho_control = 0, b_kd = true, ns_ttb_choAct = 0;
function ns_ttb_P_KD() {
    b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vung_tk_Id = form_Fs_VUNG_ID('UPa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE'), b_tenId = form_Fs_TEN_ID(b_vungId, 'TEN'); b_cdanh_Id = form_Fs_TEN_ID(b_vungId, 'cdanh'); b_phong_Id = form_Fs_TEN_ID(b_vungId, 'phong'); b_matsId = form_Fs_TEN_ID(b_vungId, 'mats'); b_nhomId = form_Fs_TEN_ID(b_vungId, 'NHOM_TS');
    b_soluongId = form_Fs_TEN_ID(b_vungId, 'SLUONG'); b_tienId = form_Fs_TEN_ID(b_vungId, 'tien'); b_tien_an_Id = form_Fs_TEN_ID(b_vungId, 'tien_an'); b_tentbId = form_Fs_TEN_ID(b_vungId, 'tentb');
    b_cb_giaoId = form_Fs_TEN_ID(b_vungId, 'cb_giao'); b_ma_cb_giaoId = form_Fs_TEN_ID(b_vungId, 'ma_cb_giao'); b_phong_giao_Id = form_Fs_TEN_ID(b_vungId, 'phong_giao');
    b_ngaycapId = form_Fs_TEN_ID(b_vungId, 'NGAYCAP'),b_ngaythuId=  form_Fs_TEN_ID(b_vungId,'ngaythu');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_moiId = form_Fs_VTEN_ID('', 'moi');
    b_tt_Id = form_Fctr_TEN_DTUONG(b_vungId, 'tt');
    b_phong_tk_Id = form_Fs_TEN_ID(b_vung_tk_Id, 'dr_phongban');
    b_so_the_tk_Id = form_Fs_TEN_ID(b_vung_tk_Id, 'so_the_tk');
    b_hoten_tk_Id = form_Fs_TEN_ID(b_vung_tk_Id, 'hoten_tk');
    b_slideId = $get(b_grlkeId).getAttribute('slideId');
    b_nsd = form_Fs_nsd();
    ns_ttb_lkeCho = setInterval('ns_ttb_P_LKE_CHO()', 200);
}
function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_gocId).value = b_so_the;
            $get(b_gchuId).innerHTML = b_ten;
            $get(b_gocId).focus();
            ns_ttb_P_LKE();
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
            $get(b_gocId).value = b_kq;
            $get(b_tenId).value = a_tso[1];
            $get(b_cdanh_Id).value = a_tso[6];
            $get(b_phong_Id).value = a_tso[3];
            //$get(b_gchuId).innerHTML = a_tso[1];
            //ns_ttb_P_LKE();
            //sns_sk.Fs_NS_TTB_PHONG(b_kq, ns_ttb_PHONG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_dtuong.indexOf("MA_CB_GIAO") >= 0) {
            $get(b_ma_cb_giaoId).value = b_kq;
            $get(b_cb_giaoId).value = a_tso[1];
            $get(b_phong_giao_Id).value = a_tso[3];
            //ns_ttb_P_LKE();
            //sns_sk.Fs_NS_TTB_PHONG(b_kq, ns_ttb_PHONG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_dtuong.indexOf("MATS") >= 0 || b_dtuong.indexOf("NHOM_TS") >= 0) {
            $get(b_matsId).value = a_tso[1];
            $get(b_nhomId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[2]; $get(b_tentbId).value = a_tso[2];
            $get(b_tienId).value = a_tso[3];
            $get(b_tentbId).focus();
        }
        else if (b_dtuong.indexOf("THAMSO") >= 0) {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
        }
        else if (b_dtuong.indexOf("DAYPHONG") >= 0) {
            var b_phong_tk = form_Fctr_TEN_DTUONG(b_vung_tk_Id, 'dr_phongban');
            lke_P_DAT(b_phong_tk, a_tso[0]+ "{" + a_tso[1]);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ttb_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_t = b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; break;
            case "MATS": b_maId = b_matsId; break;
            case "MA_CB_GIAO": b_maId = b_cb_giaoId; break;
            case "SLUONG": b_maId = b_soluongId; break;
            case "NHOM_TS": b_maId = b_nhomId; break;
            case "NGAYCAP": b_maId = b_ngaycapId; break;
            case "NGAYTHU": b_maId = b_ngaythuId; break;
        }

        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "NHOM_TS") {
            var b_nhom = lke_Fs_TRA(b_maId);
            sns_ma_ch.Fs_NS_MA_TAISAN_DR_NHOM(b_nsd, b_nhom, "ns_ttb", "NS_TTB_MATS", ns_ttb_P_TAISAN_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_maTen == "MATS") {
            var b_ma_ts = lke_Fs_TRA(b_maId);
            sns_ma_ch.Fs_NS_MA_TAISAN_TIEN(b_nsd, b_ma_ts, ns_ttb_P_TS_TIEN_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_maTen == "SO_THE") {
            //skhac.Fs_MA_LOI(b_nsd, b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_ttb_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            sns_sk.Fs_NS_TTB_PHONG(b_ma.value, ns_ttb_PHONG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_maTen == "MA_CB_GIAO") {
            //skhac.Fs_MA_LOI(b_nsd, b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_ttb_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            sns_sk.Fs_NS_TTB_PHONG_CB_GIAO(b_ma.value, ns_ttb_PHONG_CB_GIAO_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if(b_maTen=="SLUONG")
        {
            var b_soluong = $get(b_soluongId).value, b_tien = $get(b_tien_an_Id).value;
            $get(b_tienId).value = SO_CSO(CSO_SO(b_soluong) * CSO_SO(b_tien));
        }
        else if (b_maTen == "NGAYCAP" || b_maTen == "NGAYTHU") {
            sosanh_Date($get(b_ngaycapId).value, $get(b_ngaythuId).value);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ttb_P_TAISAN_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }    
}
function ns_ttb_P_TS_TIEN_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    $get(b_tienId).value = b_kq;
    $get(b_tien_an_Id).value = b_kq;    
}
function ns_ttb_PHONG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == "") {
        form_P_LOI("loi:Chưa đăng ký mã nhân viên:loi");
        $get(b_gocId).value = ""; $get(b_tenId).value = ""; $get(b_cdanh_Id).value = ""; $get(b_phong_Id).value = "";
    }
    else form_P_CH_TEXT(b_vungId, b_kq);
}
function ns_ttb_PHONG_CB_GIAO_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == "") {
        form_P_LOI("loi:Chưa đăng ký mã nhân viên:loi");
        $get(b_cb_giaoId).value = ""; $get(b_ma_cb_giaoId).value = ""; $get(b_phong_giao_Id).value = "";
    }
    else form_P_CH_TEXT(b_vungId, b_kq);
}
function ns_ttb_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        if (b_t == 'SO_THE') {
            form_P_DatGchu(b_gchuId, b_kq); $get(b_tenId).value = b_kq;
        }
       // else { $get(b_tentbId).value = b_kq; $get(b_tentbId).focus(); }
    }
}
function ns_ttb_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    list_P_DAT(b_tt_Id, 'A');
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = "0";
    $get(b_gocId).focus();
    return false;
}
function ns_ttb_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var ktra = sosanh_Date($get(b_ngaycapId).value, $get(b_ngaythuId).value);
        if (!ktra) form_P_LOI('loi:Ngày cấp phát không được lớn hơn Ngày thu hồi:loi');
        else {
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
            var b_phong = lke_Fs_TRA(b_phong_tk_Id), b_so_the = C_NVL($get(b_so_the_tk_Id).value), b_ten = C_NVL($get(b_hoten_tk_Id).value);
            sns_sk.Fs_NS_TTB_NH(b_nsd, b_phong, b_so_the, b_ten, b_so_id, b_TrangKt, a_dt_ct, a_cot_lke, ns_ttb_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_ttb_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI("loi:Ghi thành công:loi");
    }
    return false;
}
function ns_ttb_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); ns_ttb_P_MOI(); }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_phong = lke_Fs_TRA(b_phong_tk_Id), b_so_the = C_NVL($get(b_so_the_tk_Id).value), b_ten = C_NVL($get(b_hoten_tk_Id).value);
        sns_sk.Fs_NS_TTB_XOA(b_nsd, b_so_id, b_phong, b_so_the, b_ten, a_tso, a_cot, ns_ttb_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_ttb_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_ttb_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_ttb_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công:loi");
    }
}
function ns_ttb_GR_lke_RowChange() {
    if (ns_ttb_choAct != 0) clearTimeout(ns_ttb_choAct);
    ns_ttb_choAct = setTimeout("ns_ttb_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_ttb_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "0" || b_so_id == "") form_P_MOI(b_vungId, "XGL");
    else sns_sk.Fs_NS_TTB_CT(b_so_id, ns_ttb_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = b_so_id;
}
function ns_ttb_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
function ns_ttb_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_ttb_lkeCho); ns_ttb_P_LKE(); }
}
function ns_ttb_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_phong = lke_Fs_TRA(b_phong_tk_Id), b_so_the = C_NVL($get(b_so_the_tk_Id).value), b_ten = C_NVL($get(b_hoten_tk_Id).value);
        sns_sk.Fs_NS_TTB_LKE(b_nsd, b_phong, b_so_the, b_ten, a_tso, a_cot, ns_ttb_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ttb_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    $get(b_gocId).focus();
    if (b_kd) 
        b_kd = false;
    else if (CSO_SO(a_kq[0]) == 0)
        form_P_LOI('loi:Không tìm thấy kết quả nào thỏa mãn với điều kiện tìm kiếm:loi');
}
function nhap_file() {
    //var b_hang = GridX_Fi_timHangA(b_grlkeId);
    //if (b_hang < 1) {
    //if ($get(b_gocId).value == "") {
    //    form_P_LOI('loi:Chọn cán bộ trước:loi')
    //    return false;
    //}
    var b_tenf = '/App_form/ns/ma/file_Import_chung.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "NS_QLCPTS", "Nhansu_qlcapphattaisan", "Import dữ liệu -Cấp phát tài sản"]], null);
    form_P_LOI('');
    return false;
}
function sosanh_Date(str1, str2) {
    var kq;
    if (str1 == "" || str2 == "")
        kq = true;
    else {
        var b_ngayD = CNG_SO(str1), b_ngayC = CNG_SO(str2);        
        kq = b_ngayD <= b_ngayC;
    }
    return kq;
}
function ns_ttb_P_Phong() {
    try {       
        var b_tenf = form_Fs_TM() + '/App_form/ht/ns_hs_cctc_quyen.aspx';
        form_P_MO(b_tenf, null, [window.name, [""]]);
        return false;
    }
    catch (err) { }
}
function form_dong() {
    location.reload(false);
}
function ns_ttb_P_IN() {
    __doPostBack('ctl00$ContentPlaceHolder1$Nhap2', '');//Xuất Excel
}
