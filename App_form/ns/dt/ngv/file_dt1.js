var file_dt_lkeCho, b_vungId, b_so_theId, b_iurlId, b_doi = 0, b_grlke_kqId, b_thamso1, b_thamso2, b_thamso3, b_thamso4;
function file_dt_P_KD() {
    file_dt_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
    b_ten_formId = form_Fs_VTEN_ID('UPa_hi', 'ten_form');
    b_nvId = form_Fs_VTEN_ID('UPa_hi', 'nv');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_ten_kqId = form_Fs_VTEN_ID('UPa_hi', 'ten_kq');
    b_ten_fileId = form_Fs_TEN_ID(b_vungId, 'ten_file');
    b_urlId = form_Fs_TEN_ID('UPa_hi', 'url');
    b_tenId = form_Fs_TEN_ID(b_vungId, 'ten');
    b_tenmanhinhId = form_Fs_VTEN_ID('', 'tenmanhinh');
    b_slideId = b_grlkeId + '_slide';

    b_thamso1 = form_Fs_TEN_ID('UPa_hi', 'thamso1_cc');
    b_thamso2 = form_Fs_TEN_ID('UPa_hi', 'thamso2_cc');
    b_thamso3 = form_Fs_TEN_ID('UPa_hi', 'thamso3_cc');
    b_thamso4 = form_Fs_TEN_ID('UPa_hi', 'thamso4_cc');

    file_dt_lkeCho = setInterval('file_dt_P_LKE_CHO()', 200);

}
// ket qua
var b_cho_control = 0;
function P_cho(b_ten_form, b_nv, b_ten_kq, b_tenmanhinh) {
    try {
        if (b_doi == 0) {
            $get(b_ten_formId).value = b_ten_form;
            $get(b_nvId).value = b_nv;
            $get(b_ten_kqId).value = b_ten_kq;
            $get(b_tenmanhinhId).innerHTML = b_tenmanhinh;
            file_dt_P_LKE();
            b_doi = 1;
            clearTimeout(b_cho_control);
            return false;
        }
    }
    catch (err) {
        b_doi = 0;
    }
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return false;
        b_dtuong = b_dtuong.toUpperCase();
        b_doi = 0;
        if (b_dtuong != null) {

            if (a_tso[0].toString() == "ns_dt_ts") { // import tuyển sinh
                $get(b_thamso1).value = a_tso[4]; // so_id_kh
                //$get(b_thamso2).value = a_tso[5];
                //$get(b_thamso3).value = a_tso[6];
                //$get(b_thamso4).value = a_tso[7];
            }
            else if (a_tso[0].toString() == "ns_dt_tk_diem") { // import điểm
                $get(b_thamso1).value = a_tso[4]; // b_so_id_tk
                $get(b_thamso2).value = a_tso[5]; // b_so_id_kh
                $get(b_thamso3).value = a_tso[6]; // so mon
            }
        }
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "','" + a_tso[3] + "')", 200);
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}

function file_dt_P_CHON() {
    try {
        var b_iurl = $get(b_iurlId).value;
        form_P_DAY(window.name, "file_luu", "file_luu", b_iurl);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function file_dt_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(file_dt_lkeCho); file_dt_P_LKE(); }
}

function file_dt_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId),
            b_ten_form = $get(b_ten_formId).value, b_nv = $get(b_nvId).value,
            b_ten_kq = $get(b_ten_kqId).value,
        a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_FILE_LUU_LKE(b_ten_form, b_nv, b_ten_kq, a_tso, a_cot, file_dt_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function file_dt_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    return false;
}

var file_dt_choAct = 0;
function file_dt_GR_lke_RowChange() {
    if (file_dt_choAct != 0) clearTimeout(file_dt_choAct);
    file_dt_choAct = setTimeout("file_dt_P_CHUYEN_HANG()", 300);
    return false;
}

function file_dt_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ten_file = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten_file")),
            b_url = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "url")),
            b_ten = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten")),
            b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));

        if (b_so_id == "") {
            file_dt_P_MOI();
        } else {
            $get(b_ten_fileId).value = b_ten_file;
            $get(b_so_idId).value = b_so_id;
            $get(b_urlId).value = b_url;
            $get(b_tenId).innerHTML = b_ten;
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function file_dt_P_MOI() {
    form_P_MOI(b_vungId, "XGL");
    $get(b_tenId).innerHTML = "";
    $get(b_so_idId).value = 0;
}

function download_file() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("loi:Chưa chọn file muốn tải:loi"); return false; }
    var b_ten_file = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten_file")),
        b_url = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "url")),
        b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    var b_href = window.location.href.toString();
    var b_path = window.location.pathname.toString();
    var b_host = b_href.substring(0, b_href.length - b_path.length);
    var b_url_file = b_host + form_Fs_TM() + "/File_luu/" + b_url;
    window.open(b_url_file, null, null, null);
    return false;
}

//function ns_cdanh_kn_P_Excel() {
//    __doPostBack('ctl00$ContentPlaceHolder1$Nhap2', '');
//}
function file_dt_P_NH() {
    __doPostBack('ctl00$ContentPlaceHolder1$Nhap2', '');
    return false;
}
function file_dt_P_XOA() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) { form_P_LOI("loi:Bạn chưa chọn bản ghi cần xóa:loi"); return false; }
        var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"),
            b_forms = $get(b_ten_formId).value,
            b_nv = $get(b_nvId).value,
            b_ten_kq = $get(b_ten_kqId).value,
        a_tso = slide_Faobj_TUDEN(b_slideId);
        if (b_so_id == "") { form_P_LOI("loi:Bạn chưa chọn bản ghi cần xóa:loi"); return false; }
        else {
            var a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_ma_ch.Fs_FILE_LUU_XOA(b_so_id, b_forms, b_nv, b_ten_kq, a_tso, a_cot, file_dt_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
    return false;
}
function file_dt_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var a_kq = b_kq.split('#');
    if (a_kq[0] == "0")
        GridX_datBang(b_grlkeId, "");
    else
        GridX_datBang(b_grlkeId, b_kq);
    file_dt_P_MOI();
    return false;
}

function file_dt_P_LKE2(b_grlkeId2, b_ten_form, b_nv, b_ten_kq) {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId2);
        b_grlke_kqId = b_grlkeId2;
        sns_ma_ch.Fs_FILE_LUU_LKE(b_ten_form, b_nv, b_ten_kq, a_cot, file_dt_P_LKE_KQ2, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function file_dt_P_LKE_KQ2(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang(b_grlke_kqId, b_kq);
    return false;
}


