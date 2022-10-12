var ns_pcap_lkeCho, b_vungId, b_grlkeId,b_vungtkId, b_slideId, b_gocId, b_hinhthucId, b_so_idId, b_gchuId, b_doi = 0, b_ngayd, b_ngayc,b_so_thetkId,b_loaihuong_tkId,
    b_tienId, b_tenId, b_maphucapId, b_loaihuongId, b_tien_tnsId, b_phantram_luongId, b_tien_tdgtId, b_tongluongId, b_cdanhId;
function ns_pcap_P_KD(b_tm) {
    ns_pcap_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_vungtkId = form_Fs_VUNG_ID('UPa_tk'),
    b_tmf = b_tm, b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE'); b_tenId = form_Fs_TEN_ID(b_vungId, 'TEN'); b_phongId = form_Fs_TEN_ID(b_vungId, 'phong');
    b_tienId = form_Fs_TEN_ID(b_vungId, 'tien'); b_maphucapId = form_Fs_TEN_ID(b_vungId, 'MA_PHUCAP'); b_loaihuongId = form_Fs_TEN_ID(b_vungId, 'loaihuong');
    b_cdanhId = form_Fs_TEN_ID(b_vungId, 'cdanh');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_so_thetkId = form_Fs_VTEN_ID(b_vungtkId, 'so_the_tk');
    b_loaihuong_tkId = form_Fs_VTEN_ID(b_vungtkId, 'loaihuong_tk');
    b_slideId = b_grlkeId + '_slide_ctrdivL';
    b_ngayd = form_Fs_TEN_ID(b_vungId, 'ngayd'); b_ngayc = form_Fs_TEN_ID(b_vungId, 'ngayc');
    ns_pcap_lkeCho = setInterval('ns_pcap_P_LKE_CHO()', 200);
}

var b_cho_control = 0;
function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_gocId).value = b_so_the;
            $get(b_tenId).value = b_ten;
            $get(b_phongId).value = b_phong;
            $get(b_gchuId).innerHTML = b_ten;
            $get(b_gocId).focus();
            ns_pcap_P_LKE();
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
            //$get(b_phongId).value = a_tso[6];
            tra_thong_tin(a_tso[0]);
            $get(b_gchuId).innerHTML = a_tso[1];
            //sns_sk.Fs_NS_TTB_PHONG(b_kq, ns_pcap_PHONG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            $get(b_gocId).focus();
        }
        else if (b_dtuong.indexOf("MA_PHUCAP") >= 0) {
            $get(b_maphucapId).value = a_tso[0];
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_tienId).value = a_tso[2];
            $get(b_loaihuongId).value = a_tso[3];

        }
        else if (b_dtuong.indexOf("THAMSO") >= 0) {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_pcap_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; form_P_MOI("", "XGL"); break;

        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_pcap_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            sns_sk.Fs_NS_TTB_PHONG(b_ma.value, ns_pcap_PHONG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            //ns_pcap_P_LKE();
        }
        else if (b_maTen == "TIEN_LCB") {
            $get(b_tongluongId).value = CSO_SO($get(b_tien_lcbId).value) + CSO_SO($get(b_tien_tnsId).value) + CSO_SO($get(b_phantram_luongId).value) + CSO_SO($get(b_tien_tdgtId).value);
        }
        else if (b_maTen == "TIEN_TNS") {
            $get(b_tongluongId).value = CSO_SO($get(b_tien_lcbId).value) + CSO_SO($get(b_tien_tnsId).value) + CSO_SO($get(b_phantram_luongId).value) + CSO_SO($get(b_tien_tdgtId).value);
        }
        else if (b_maTen == "PHANTRAM_LUONG") {
            $get(b_tongluongId).value = CSO_SO($get(b_tien_lcbId).value) + CSO_SO($get(b_tien_tnsId).value) + CSO_SO($get(b_phantram_luongId).value) + CSO_SO($get(b_tien_tdgtId).value);
        }
        else if (b_maTen == "TIEN_TDGT") {
            $get(b_tongluongId).value = CSO_SO($get(b_tien_lcbId).value) + CSO_SO($get(b_tien_tnsId).value) + CSO_SO($get(b_phantram_luongId).value) + CSO_SO($get(b_tien_tdgtId).value);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_pcap_PHONG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    ns_pcap_P_LKE();
}
function ns_pcap_P_NGAYKETTHUC() {
    try {
        var b_ma_lqd = "KL";
        var b_ngaybd = $get(b_ngayqdID).value;
        sns_qt.Fs_NS_KHENTHUONG_SO_QD(b_ngaybd, b_ma_lqd, ns_pcap_P_NGAYKETTHUC_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}

function ns_pcap_P_NGAYKETTHUC_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        $get(b_soqdID).value = b_kq;
    }
}
function ns_pcap_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else { form_P_DatGchu(b_gchuId, b_kq); $get(b_tenId).value = b_kq; }
}

var ns_pcap_choAct = 0;
function ns_pcap_GR_lke_RowChange() {
    if (ns_pcap_choAct != 0) clearTimeout(ns_pcap_choAct);
    ns_pcap_choAct = setTimeout("ns_pcap_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_pcap_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_pcap_lkeCho); ns_pcap_P_LKE(); }
}
function ns_pcap_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = "0";
    $get(b_gocId).focus();
    return false;
}
function ns_pcap_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_so_the = $get(b_so_thetkId).value;
        var b_loai_huong = list_Fs_TRA($get(b_loaihuong_tkId));
        sns_ls.Fs_NS_PCAP_LKE(b_so_the,b_loai_huong, a_tso, a_cot, ns_pcap_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_pcap_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}

function ns_pcap_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") {
            form_P_LOI(b_loi);
            return false;
        }
        var ktra = sosanh_Date($get(b_ngayd).value, $get(b_ngayc).value);
        if (ktra != "false" && ktra < 0) {
            form_P_LOI('loi:Từ ngày không được lớn hơn đến ngày:loi');
            return false;
        }
        else {
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var b_so_id = $get(b_so_idId).value;
            sns_ls.Fs_NS_PCAP_NH(b_so_id, b_TrangKt, a_dt_ct, a_cot_lke, ns_pcap_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_pcap_NH_KQ(b_kq) {
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

function ns_pcap_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "0") form_P_MOI(b_vungId, "XGL");
    else sns_ls.Fs_NS_PCAP_CT(b_so_id, ns_pcap_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = b_so_id;
}
function ns_pcap_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == "") form_P_MOI(b_vungId, "XGL");
    else form_P_CH_TEXT(b_vungId, b_kq);
}
function ns_pcap_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    //if (b_hang < 1) return;
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }

    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }

    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"),
        b_so_the = $get(b_gocId).value;
    if (b_so_id == "") ns_pcap_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_loai_huong = list_Fs_TRA($get(b_loaihuong_tkId));
        sns_ls.Fs_NS_PCAP_XOA(b_so_id, b_so_the, b_loai_huong, a_tso, a_cot, ns_pcap_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_pcap_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_pcap_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_pcap_P_CHUYEN_HANG(); }
    }
}
function nhap_file() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || $get(b_so_idId).value == "") {
        form_P_LOI('loi:Bạn phải chọn 1 bản ghi:loi')
        return false;
    }

    var b_tenf = b_tmf + '/ns/ma/file_Import_chung.aspx';
    var b_so_the = $get(b_so_idId).value;
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "NS_PCAP", b_so_the, "Lưu File các khoản hỗ trợ"]], null);
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
function ns_pcap_P_IN() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_so_the = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the");
    if (b_so_the == "" || b_so_the == null) { form_P_LOI("Bạn phải chọn một bản ghi để in"); return false; }
    else {
        __doPostBack('ctl00$ContentPlaceHolder1$Xuat2', '');//Xuất quyết định
    }
} 
function tra_thong_tin(b_so_the) {
    try {
        sns_ls.Fs_NS_PCAP_TRA(b_so_the, tra_thong_tin_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function tra_thong_tin_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    $get(b_phongId).value = a_kq[0]; $get(b_cdanhId).value = a_kq[1];
}