var file_import_chung_lkeCho, b_vungId, b_formId, file_import_chung_choAct = 0, file_import_chung_huyCho, b_cho_control = 0,
    b_tra_luuId, b_ten_files, b_vuId, b_so_theId, b_iurlId, b_ma_dviId, b_ngay_nhId, b_doi = 0, b_grlke_kqId, b_ngaynhapId, b_ten_mhId,
    b_ten_formId;
function file_import_chung_P_KD(b_ma_dvi) {
    b_ma_dviId = b_ma_dvi;
    b_vuId = form_Fs_VUNG_ID('UPa_hi'); b_ten_formId = form_Fs_VTEN_ID('UPa_hi', 'ten_form');
    file_import_chung_lkeCho = setInterval('file_import_chung_P_LKE_CHO()', 200);
}
function P_cho(b_ten_form, b_nv, b_ten_kq, b_tenmanhinh) {
    try {
        if (b_doi == 0) {
            $get(b_ten_formId).value = b_ten_form;
            $get(b_nvId).value = b_nv;
            $get(b_ten_kqId).value = b_ten_kq;
            $get(b_ten_mhId).value = b_tenmanhinh;
            $get(b_tenmanhinhId).innerHTML = b_tenmanhinh;
            file_import_chung_P_LKE();
            b_doi = 1;
            clearTimeout(b_cho_control);
            return false;
        }
    }
    catch (err) { b_doi = 0; }
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return true;
        b_dtuong = b_dtuong.toUpperCase();
        b_doi = 0;
        b_formId = a_tso[0];
        if (b_dtuong.indexOf("THAMSO") >= 0 && a_tso[1] != "NS_LHD" && a_tso[1] != "NS_LQD") {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "','" + a_tso[3] + "')", 200);
        } else if (b_dtuong.indexOf("THAMSO") >= 0 && (a_tso[1] == "NS_LHD" || a_tso[1] == "NS_LQD")) {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[5] + "','" + a_tso[2] + "','" + a_tso[3] + "')", 200);
        }
        if (a_tso.length > 3) {
            form_Fctr_TEN_DTUONG(b_vuId, 'tmuc').value = a_tso[4];
            form_Fctr_TEN_DTUONG(b_vuId, 'tra_luu').value = a_tso[5];
            form_Fctr_TEN_DTUONG(b_vuId, 'loai').value = a_tso[6];
            form_Fctr_TEN_DTUONG(b_vuId, 'ten_lhd').value = a_tso[7];
        }
        if (a_tso[1] == "NS_LHD" || a_tso[1] == "NS_LQD") {
            $get(b_ngaynhapId).style.display = "";
        } else {
            $get(b_ngaynhapId).style.display = "none";
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function file_import_chung_P_MOI() {
    form_P_MOI(b_vungId, "XGL");
    $get(b_tenId).innerHTML = "";
    $get(b_so_idId).value = 0;
}
function file_import_chung_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") {
        form_P_LOI(b_loi);
        return false;
    }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_so_id = 0;
    if (b_hang >= 0)
        b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    else {
        var fu1 = document.getElementById("ctl00_ContentPlaceHolder1_chon_file");
        if (fu1.files.length == 0) {
            form_P_LOI('loi:Bạn chưa chọn file upload :loi');
            return false;
        }
        else {
            var allowed_extensions = new Array("jpg", "png", "gif", "doc", "docx", "xls", "xlsx", "pdf", "rar", "zip");
            if (b_formId == "ns_dthv" || b_formId == "ns_dtcc") {
                allowed_extensions = new Array("jpg", "png", "gif", "pdf", "docx", "doc", "xls", "xlsx");
            }


            var b_kq = 0;
            var fileName = fu1.value;
            var file_extension = fileName.split('.').pop().toLowerCase();
            for (var i = 0; i < allowed_extensions.length; i++) {
                if (allowed_extensions[i] == file_extension) {
                    b_kq = b_kq + 1;
                }
            }
            if (b_kq == 0) {
                form_P_LOI('loi:File không đúng định dạng!:loi');
                b_kq = 0;
                return false;
            }
        }
        var file_size = fu1.files[0].size;
        if (file_size >= 2100000) {
            form_P_LOI('loi:File vượt quá dung lượng cho phép (2M)!:loi');
            return false;
        }


        //else if (fu1.value.substring(fu1.value.length - 4, fu1.value.length) == ".exe") {
        //    form_P_LOI('loi:Nhập file không đúng định dạng!:loi');
        //    return false;
        //}
    }
    __doPostBack('ctl00$ContentPlaceHolder1$Nhap2', '');
    form_P_LOI('');
    file_import_chung_huyCho = setInterval('file_import_chung_P_HUY_CHO()', 5000);

    GridX_anCot(b_grlkeId, "ten"); GridX_anCot(b_grlkeId, "so_id");
    return false;
}
function file_import_chung_P_XOA() {
    var message = confirm("Có xóa không?");
    if (message == false) { return false; }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"),
        b_forms = $get(b_ten_formId).value,
        b_nv = $get(b_nvId).value,
        b_ten_kq = $get(b_ten_kqId).value,
        a_tso = slide_Faobj_TUDEN(b_slideId);
    if (b_so_id == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId);
        sns_ma_ch.Fs_FILE_LUU_XOA(b_so_id, b_forms, b_nv, b_ten_kq, a_tso, a_cot, file_import_chung_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function file_import_chung_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var a_kq = b_kq.split('#');
    var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang > 1) b_hang--;
    else b_hang = GridX_Fi_hangSo(b_grlkeId);
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) file_import_chung_P_MOI();
    else { GridX_datA(b_grlkeId, b_hang); file_import_chung_P_CHUYEN_HANG(); }
    form_P_LOI("loi:Xóa thành công!:loi");
    return false;
}
function file_import_chung_GR_lke_RowChange() {
    if (file_import_chung_choAct != 0) clearTimeout(file_import_chung_choAct);
    file_import_chung_choAct = setTimeout("file_import_chung_P_CHUYEN_HANG()", 300);
    return false;
}
function file_import_chung_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ten_file = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten_file")),
            b_url = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "url")),
            b_ten = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten")),
            b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")),
            b_ngay_nh = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ngay"));

        if (b_so_id == "") {
            file_import_chung_P_MOI();
        } else {
            $get(b_ten_fileId).value = b_ten_file;
            $get(b_so_idId).value = b_so_id;
            $get(b_urlId).value = b_url;
            $get(b_tenId).innerHTML = b_ten;
            $get(b_ten_files).value = b_ten;
            $get(b_ngay_nhId).value = b_ngay_nh;
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function file_import_chung_P_HUY_CHO() {
    if (file_import_chung_huyCho != 0) clearTimeout(file_import_chung_huyCho);
    form_P_LOI('');
    location.reload(true);
    return;
}
function file_import_chung_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        file_import_chung_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
        b_vuId = form_Fs_VUNG_ID('UPa_hi');
        b_ten_formId = form_Fs_VTEN_ID('UPa_hi', 'ten_form');
        b_nvId = form_Fs_VTEN_ID('UPa_hi', 'nv');
        b_ten_mhId = form_Fs_VTEN_ID('', 'ten_mh');
        b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
        b_ten_kqId = form_Fs_VTEN_ID('UPa_hi', 'ten_kq');
        b_ngaynhapId = form_Fs_VUNG_ID('trNgayNhap');
        b_ten_fileId = form_Fs_TEN_ID(b_vungId, 'ten_file');
        b_urlId = form_Fs_TEN_ID('UPa_hi', 'url');
        b_tra_luuId = form_Fs_TEN_ID('UPa_hi', 'tra_luu');
        b_ten_files = form_Fs_TEN_ID('UPa_hi', 'ten_files');
        b_ngay_nhId = form_Fs_TEN_ID(b_vungId, 'ngay');
        b_tenId = form_Fs_TEN_ID(b_vungId, 'ten');
        b_tenmanhinhId = form_Fs_VTEN_ID('', 'tenForm');
        if (file_import_chung_lkeCho != 0) clearTimeout(file_import_chung_lkeCho);
        file_import_chung_lkeCho = 0;
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        file_import_chung_P_LKE('K');
    }
}
function file_import_chung_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId),
            b_ten_form = $get(b_ten_formId).value, b_nv = $get(b_nvId).value,
            b_ten_kq = $get(b_ten_kqId).value,
            a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_FILE_LUU_LKE(b_ten_form, b_nv, b_ten_kq, a_tso, a_cot, file_import_chung_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function file_import_chung_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
    }
    form_P_LOI('');
    return false;
}
function file_import_chung_Download() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_ten_file = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten_file")),
        b_url = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "url")),
        b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_hang < 1 || b_so_id == "") { form_P_LOI("loi:Chưa chọn file muốn tải:loi"); return false; }
    var b_href = window.location.href.toString();
    var b_path = window.location.pathname.toString();
    var file_download = $get(b_ten_formId).value;
    var b_host = b_href.substring(0, b_href.length - b_path.length);

    if (file_download == "ns_ma_lhd") {
        b_url = b_host + form_Fs_TM() + "/Templates/Bieu_mau_dong" + b_url;
    } else if (file_download == "ns_ma_htctac") {
        b_url = b_host + form_Fs_TM() + "/Templates/Bieu_mau_dong_quyet_dinh" + b_url;
    } else if (file_download == "ns_ma_email_sn") {
        b_url = b_host + form_Fs_TM() + "/file_import/" + b_ma_dviId + b_url;
    } else
        b_url = b_host + form_Fs_TM() + "/file_import/" + b_url;
    window.open(b_url, null, null, null);
    return false;
}
function form_dong() {
    location.reload(false);
}