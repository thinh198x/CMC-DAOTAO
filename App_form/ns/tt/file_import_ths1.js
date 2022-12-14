var file_import_ths_lkeCho, b_vungId, b_ten_files, b_vuId, b_so_theId, b_iurlId, b_doi = 0, b_grlke_kqId, b_dg_danId, b_ten_fileId;
function file_import_ths_P_KD(b_chon) {

    file_import_ths_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
    b_vuId = form_Fs_VUNG_ID('UPa_hi');
    b_ten_formId = form_Fs_VTEN_ID('UPa_hi', 'ten_form');
    b_nvId = form_Fs_VTEN_ID('UPa_hi', 'nv');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_ten_kqId = form_Fs_VTEN_ID('UPa_hi', 'ten_kq');
    b_ten_fileId = form_Fs_TEN_ID(b_vungId, 'TEN_FILE');
    b_urlId = form_Fs_TEN_ID('UPa_hi', 'url');
    b_ten_files = form_Fs_TEN_ID('UPa_hi', 'ten_files');
    b_tenId = form_Fs_TEN_ID(b_vungId, 'ten');
    b_tenmanhinhId = form_Fs_VTEN_ID('', 'tenmanhinh');
    b_slideId = b_grlkeId + '_slide';
    file_import_ths_lkeCho = setInterval('file_import_ths_P_LKE_CHO()', 200);

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
            file_import_ths_P_LKE();
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
        if (b_dtuong == null || b_dtuong == "") return true;
        b_dtuong = b_dtuong.toUpperCase();
        b_doi = 0;
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "','" + a_tso[3] + "')", 200);
            
        }
        if (a_tso.length > 3) {
            form_Fctr_TEN_DTUONG(b_vuId, 'tmuc').value = a_tso[4];
            form_Fctr_TEN_DTUONG(b_vuId, 'tra_luu').value = a_tso[5];
            form_Fctr_TEN_DTUONG(b_vuId, 'loai').value = a_tso[6];
            form_Fctr_TEN_DTUONG(b_vuId, 'ten_lhd').value = a_tso[7]; 
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function file_import_ths_P_CHON() {
    try {
        var b_iurl = $get(b_iurlId).value;
        form_P_DAY(window.name, "file_luu", "file_luu", b_iurl);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function file_import_ths_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(file_import_ths_lkeCho); file_import_ths_P_LKE(); }
}

function file_import_ths_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId),
            b_ten_form = $get(b_ten_formId).value, b_nv = $get(b_nvId).value,
            b_ten_kq = $get(b_ten_kqId).value,
        a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_FILE_LUU_LKE(b_ten_form, b_nv, b_ten_kq, a_tso, a_cot, file_import_ths_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function file_import_ths_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    return false;
}

var file_import_ths_choAct = 0;
function file_import_ths_GR_lke_RowChange() {
    if (file_import_ths_choAct != 0) clearTimeout(file_import_ths_choAct);
    file_import_ths_choAct = setTimeout("file_import_ths_P_CHUYEN_HANG()", 300);
    return false;
}

function file_import_ths_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ten_file = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten_file")),
            b_url = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "url")),
            b_ten = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten")),
            b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));

        if (b_so_id == "") {
            file_import_ths_P_MOI();
        } else {
            $get(b_ten_fileId).value = b_ten_file;
            $get(b_so_idId).value = b_so_id;
            $get(b_urlId).value = b_url;
            $get(b_tenId).innerHTML = b_ten;
            $get(b_ten_files).value = b_ten;
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function file_import_ths_P_MOI() {
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
    var file_download = $get(b_ten_formId).value;
    var b_host = b_href.substring(0, b_href.length - b_path.length);
    
    if (file_download == "ns_ma_lhd") {
        b_url = b_host + form_Fs_TM() + "/Templates/" + b_url;
    } else
        b_url = b_host + form_Fs_TM() + "/file_import/" + b_url;
    window.open(b_url, null, null, null);
    return false;
}

function file_import_ths_P_NH() {
    __doPostBack('ctl00$ContentPlaceHolder1$Nhap2', '');
}
function file_import_ths_P_CN()
{
    var b_dan = $get(b_ten_fileId).value;
    var b_dgdan = $get(b_ten_files).innerHTML;
}
function file_import_ths_P_XOA() {
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
        sns_ma_ch.Fs_FILE_LUU_XOA(b_so_id, b_forms, b_nv, b_ten_kq, a_tso, a_cot, file_import_ths_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}

function file_import_ths_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var a_kq = b_kq.split('#');
    if (a_kq[0] == "0")
        GridX_datBang(b_grlkeId, "");
    else
        GridX_datBang(b_grlkeId, b_kq);
    file_import_ths_P_MOI();
    return false;
}

function file_import_ths_P_LKE2(b_grlkeId2, b_ten_form, b_nv, b_ten_kq) {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId2);
        b_grlke_kqId = b_grlkeId2;
        sns_ma_ch.Fs_FILE_LUU_LKE(b_ten_form, b_nv, b_ten_kq, a_cot, file_import_ths_P_LKE_KQ2, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function file_import_ths_P_LKE_KQ2(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang(b_grlke_kqId, b_kq);
    return false;
}
function form_P_TRA_CHON_D() {
    try {
        //var a_kq = $get(b_ten_fileId).value;
        var a_kq = [];
        a_kq[0] = 'a'; a_kq[1] = '3';
       // form_P_DONG(window.name, a_kq);
      //  window.close();
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function form_P_DONG_P(b_ten, a_tso) {
    try {
        b_date = new Date();
        if (b_date > CNG_NG('01/06/2018')) return;
        if (window.P_DONG) window.P_DONG();
        var b_goc = form_F_GOC();
        if (b_ten == 'login' || b_goc == null) return;
        var b_damo = b_goc.damo;
        if (C_NVL(b_damo) == '') return;
        var a_damo = Fas_ChMang(b_damo), b_kq = '';
        if (b_ten != b_goc.name) {
            var b_fcu = b_goc[b_ten], b_tra = '';
            if (b_fcu != null) {
                b_kq = C_NVL(form_Fs_VTEN_GTRI('', 'tra_dong')); b_tra = b_fcu.damo;
                if (C_NVL(form_Fs_VTEN_GTRI('', "tra_luu")) == '') {
                    b_fcu.close(); b_goc[b_ten] = null;;
                }
            }
            b_damo = '';
            for (var i = 0; i < a_damo.length; i++) {
                if (a_damo[i] != b_ten) b_damo = kytu_Fs_them(b_damo, a_damo[i]);
            }
            b_goc.damo = b_damo;
            var a_xl = [];
            if (a_tso != null) { for (var i = 0; i < a_tso.length; i++) a_xl[i] = a_tso[i]; }
            else if (b_kq != '') a_xl[0] = b_kq;
            if (a_xl != null && a_xl.length > 0 && C_NVL(b_tra) != '') {
                var a_s = Fas_ChMang(b_tra, ',');
                if (Fb_MA_MA(b_damo, a_s[0])) {
                    var b_f = b_goc[a_s[0]];
                    if (b_f.P_KET_QUA) { b_f.focus(); b_f.P_KET_QUA(a_s[1], a_xl); }
                }
            }
        }
        else {
            for (var i = 0; i < a_damo.length; i++) {
                b_goc[a_damo[i]].close(); b_goc[a_damo[i]] = null;
            }
        }
    }
    catch (ex) { }
}