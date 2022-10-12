var file_import_lkeCho, b_vungId, b_ten_mhId, b_so_theId, b_iurlId, b_doi = 0, b_grlke_kqId, b_thamso1, b_thamso2, b_thamso3, b_thamso4, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C';
function file_import_P_KD() {
    file_import_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
    b_ten_formId = form_Fs_VTEN_ID('UPa_hi', 'ten_form');
    b_nvId = form_Fs_VTEN_ID('UPa_hi', 'nv');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_ten_kqId = form_Fs_VTEN_ID('UPa_hi', 'ten_kq');
    b_ten_fileId = form_Fs_TEN_ID(b_vungId, 'ten_file');
    b_ten_mhId = form_Fs_VTEN_ID('', 'ten_mh');
    b_urlId = form_Fs_TEN_ID('UPa_hi', 'url');
    b_tenId = form_Fs_TEN_ID(b_vungId, 'ten');
    b_tenmanhinhId = form_Fs_VTEN_ID('', 'tenForm');
    b_slideId = $get(b_grlkeId).getAttribute('slideId');

    b_thamso1 = form_Fs_TEN_ID('UPa_hi', 'thamso1_cc');
    b_thamso2 = form_Fs_TEN_ID('UPa_hi', 'thamso2_cc');
    b_thamso3 = form_Fs_TEN_ID('UPa_hi', 'thamso3_cc');
    b_thamso4 = form_Fs_TEN_ID('UPa_hi', 'thamso4_cc');

    //file_import_lkeCho = setTimeout('file_import_P_LKE_CHO()', 200);

}
// ket qua
var b_cho_control = 0;
function P_cho(b_ten_form, b_nv, b_ten_kq, b_tenmanhinh) {
    try {
        if (b_doi == 0) {
            $get(b_ten_formId).value = b_ten_form;
            $get(b_nvId).value = b_nv;
            $get(b_ten_kqId).value = b_ten_kq;
            $get(b_ten_mhId).value = b_tenmanhinh;
            $get(b_tenmanhinhId).innerHTML = b_tenmanhinh;
            file_import_P_LKE();
            b_doi = 1;
            clearTimeout(b_cho_control);
            return false;
        }
    } catch (err) { b_doi = 0; }
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "")
            return false;
        else {
            b_dtuong = b_dtuong.toUpperCase();
            b_fdtuong = b_dtuong;
            a_ftso = Farr_copy(a_tso);
            if (b_fcho == 'X')
                P_KET_QUA_KQ();
            else
                b_choAct = setTimeout('P_KET_QUA_KQ()', 500);
            var b_kq = a_tso[0];
            b_doi = 0;
            if (a_tso[0].toString() == "cc_cn_ct") {
                $get(b_thamso1).value = a_tso[4];
                $get(b_thamso2).value = a_tso[5];
                $get(b_thamso3).value = a_tso[6];
                $get(b_thamso4).value = a_tso[7];
            }
            if (b_dtuong.indexOf("THAMSO") >= 0) {
                b_cho_control = setTimeout("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "','" + a_tso[3] + "')", 200);
            }
            if (a_tso[0].toString() == "tl_phanca" || a_tso[0].toString() == "cc_cn_ct") {
                $get(b_thamso1).value = a_tso[4];
                $get(b_thamso2).value = a_tso[5];
            }
            if (a_tso[0].toString() == "tl_ems_imp") {
                $get(b_thamso1).value = a_tso[4];
                $get(b_thamso2).value = a_tso[5];
            }
            if (a_tso[0].toString() == "ns_dt_hvien_tgian") {
                $get(b_thamso1).value = a_tso[4];
            }
            if (a_tso[0].toString() == "ns_dsach_thieu_plenh") {
                $get(b_thamso1).value = a_tso[4];
                $get(b_thamso2).value = a_tso[5];
            }
        }

    }
    catch (err) {
        form_P_LOI(err);
    }
}

function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase();
    a_tso = Farr_copy(a_ftso);
    b_kq = a_tso[0];
    clearInterval(b_choAct);
}

function file_import_P_CHON() {
    try {
        var b_iurl = $get(b_iurlId).value;
        form_P_DAY(window.name, "file_luu", "file_luu", b_iurl);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function file_import_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (file_import_lkeCho != 0) clearTimeout(file_import_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        file_import_P_LKE('K');
    }
}

function file_import_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId),
            b_ten_form = $get(b_ten_formId).value, b_nv = $get(b_nvId).value,
            b_ten_kq = $get(b_ten_kqId).value,
            a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_FILE_LUU_LKE(b_ten_form, b_nv, b_ten_kq, a_tso, a_cot, file_import_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function file_import_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    b_fcho = 'X';
    return false;
}

var file_import_choAct = 0;
function file_import_GR_lke_RowChange() {
    if (file_import_choAct != 0) clearTimeout(file_import_choAct);
    file_import_choAct = setTimeout("file_import_P_CHUYEN_HANG()", 300);
    return false;
}

function file_import_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ten_file = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten_file")),
            b_url = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "url")),
            b_ten = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten")),
            b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));

        if (b_so_id == "") {
            file_import_P_MOI();
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
function file_import_P_MOI() {
    form_P_MOI(b_vungId, "XGL");
    $get(b_tenId).innerHTML = "";
    $get(b_so_idId).value = 0;
}

function dowload_file() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("loi:Chưa chọn file muốn tải:loi"); return false; }
    var b_ten_file = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten_file")),
        b_url = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "url")),
        b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    var b_href = window.location.href.toString();
    var b_path = window.location.pathname.toString();
    var b_host = b_href.substring(0, b_href.length - b_path.length);
    b_url = b_host + form_Fs_TM() + "/file_luu/" + b_url;
    window.open(b_url, null, null, null);
    return false;
}
function file_import_P_NH() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'nhap2');
    $get(b_btn_excel).click(); form_chay = 0; form_P_LOI('');
    return false;
}
function file_import_P_XOA() {
    var r = confirm("Bạn có chắc chắn xóa không?");
    if (r == false) {
        return false;
    }
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
        sns_ma_ch.Fs_FILE_LUU_XOA(b_so_id, b_forms, b_nv, b_ten_kq, a_tso, a_cot, file_import_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function file_import_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var a_kq = b_kq.split('#');
    if (a_kq[0] == "0")
        GridX_datBang(b_grlkeId, "");
    else
        GridX_datBang(b_grlkeId, b_kq);
    file_import_P_MOI();
    return false;
}

function file_import_P_LKE2(b_grlkeId2, b_ten_form, b_nv, b_ten_kq) {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId2);
        b_grlke_kqId = b_grlkeId2;
        sns_ma_ch.Fs_FILE_LUU_LKE(b_ten_form, b_nv, b_ten_kq, a_cot, file_import_P_LKE_KQ2, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function file_import_P_LKE_KQ2(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang(b_grlke_kqId, b_kq);
    return false;
}

function form_dong() {
    var b_ten_form = $get(b_ten_formId).value;
    if (b_ten_form == "ns_cp_nvien") {
        form_P_DAY(window.name, 'ns_cp_nvien', 'TAI_IMPORT', ['CB', 1, 1]);
    } else if (b_ten_form == "tl_phanca") {
        form_P_DAY(window.name, 'tl_phanca', 'TAI_IMPORT', ['CB', 1, 1]);
    } else if (b_ten_form == "cc_cn_ct") {
        form_P_DAY(window.name, 'cc_cn_ct', 'TAI_IMPORT', ['CB', 1, 1]);
    } else if (b_ten_form == "ns_cc_thongtin_nghi") {
        form_P_DAY(window.name, 'ns_cc_thongtin_nghi', 'TAI_IMPORT', ['CB', 1, 1]);
    } else if (b_ten_form == "ns_tl_khoan_phaithu") {
        form_P_DAY(window.name, 'ns_tl_khoan_phaithu', 'TAI_IMPORT', ['CB', 1, 1]);
    } else if (b_ten_form == "cc_dky_dmvs") {
        form_P_DAY(window.name, 'cc_dky_dmvs', 'TAI_IMPORT', ['CB', 1, 1]);
    } else if (b_ten_form == "ns_cc_dky_lthem") {
        form_P_DAY(window.name, 'ns_cc_dky_lthem', 'TAI_IMPORT', ['CB', 1, 1]);
    } else if (b_ten_form == "ns_cc_kb_lthem") {
        form_P_DAY(window.name, 'ns_cc_kb_lthem', 'TAI_IMPORT', ['CB', 1, 1]);
    } else if (b_ten_form == "ns_tl_qtthue") {
        form_P_DAY(window.name, 'ns_tl_qtthue', 'TAI_IMPORT', ['CB', 1, 1]);
    } else if (b_ten_form == "ns_td_uv") {
        form_P_DAY(window.name, 'ns_td_uv', 'TAI_IMPORT', ['CB', 1, 1]);
    } else if (b_ten_form == "ns_hdns_dbien") {
        form_P_DAY(window.name, 'ns_hdns_dbien', 'TAI_IMPORT', ['CB', 1, 1]);
    } else if (b_ten_form == "ns_td_kh_nam") {
        form_P_DAY(window.name, 'ns_td_kh_nam', 'TAI_IMPORT', ['CB', 1, 1]);
    } else if (b_ten_form == "dg_dm_mdg") {
        form_P_DAY(window.name, 'dg_dm_mdg', 'TAI_IMPORT', ['CB', 1, 1]);
    } else if (b_ten_form == "ns_qhe") {
        var b_tenf = '/App_form/ns/tt/ns_qhe.aspx';
        form_P_MO(b_tenf, window.name + ',TAI_IMPORT', ['TAI_IMPORT', [window.name, 'ns_qhe', null, "Quan hệ nhân thân"]], null);
    } else if (b_ten_form == "hdns_mota_cv") {
        form_P_DAY(window.name, 'hdns_mota_cv', 'TAI_IMPORT', ['CB', 1, 1]);
    } else if (b_ten_form == "ns_hdns_vtcdanh") {
        var b_tenf = '/App_form/ns/hdns/dm/cdanh/ns_hdns_vtcdanh.aspx';
        form_P_MO(b_tenf, window.name + ',TAI_IMPORT', ['TAI_IMPORT', [window.name, 'ns_hdns_vtcdanh', null, "Gán vị trí chức danh"]], null);
    } else if (b_ten_form == "ns_dt_hvien_tgian") {
        form_P_DAY(window.name, 'ns_dt_hvien_tgian', 'TAI_IMPORT', ['CB', 1, 1]);
    } else if (b_ten_form == "dg_kq_dgia_thang") {
        form_P_DAY(window.name, 'dg_kq_dgia_thang', 'TAI_IMPORT', ['CB', 1, 1]);
    } else if (b_ten_form == "dg_dm_tieuchi") {
        form_P_DAY(window.name, 'dg_dm_tieuchi', 'TAI_IMPORT', ['CB', 1, 1]);
    } else if (b_ten_form == "ns_hdns_pban_longbai3") {
        form_P_DAY(window.name, 'ns_hdns_pban_longbai3', 'TAI_IMPORT', ['CB', 1, 1]);
    } else {
        form_P_DAY(window.name, b_ten_form, 'TAI_IMPORT', ['CB', 1, 1]);
    } 
}