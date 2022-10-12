
var cc_dulieu_vaora_lkeCho, cc_dulieu_vaora_choAct = 0, b_phong_tkId, b_dimuonId, b_aphongId, b_ve_somId, b_cangayId, b_slideId, b_vungId,
    b_grlkeId, b_grctId, b_ho_tenId, b_mt, b_nsd, b_ten, b_so_the, b_ngayd, b_ngayc, b_ctyValue, b_ctrbeforId;
function cc_dulieu_vaora_P_KD() {
    cc_dulieu_vaora_lkeCho = setInterval('cc_dulieu_vaora_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "" || a_tso[0] == "FILE_HTOAN") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kd = a_tso[0];
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            $get(b_so_theId).value = b_kd;
            $get(b_gchuId).innerHTML = a_tso[1];
            cc_dulieu_vaora_P_LKE('K');
            $get(b_gocId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function cc_dulieu_vaora_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "PHONG": b_maId = b_phongId; break;
            case "THANG": b_maId = b_thangId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null) return;
        if (b_maTen == "PHONG") {
            $get(b_aphongId).value = lke_Fs_TRA($get(b_phongId));
            cc_dulieu_vaora_P_MOI();
            cc_dulieu_vaora_P_LKE('K');
        }
    }
    catch (err) { form_P_LOI(err); }
}
function cc_dulieu_vaora_GR_lke_RowChange() {
    if (cc_dulieu_vaora_choAct != 0) clearTimeout(cc_dulieu_vaora_choAct);
    cc_dulieu_vaora_choAct = setTimeout("cc_dulieu_vaora_P_CHUYEN_HANG()", 300);
    return false;
}
function cc_dulieu_vaora_P_CHUYEN_HANG() {

}
function cc_dulieu_vaora_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    GridX_dat_hangkt(b_grctId, a_kq[1]);
    if (a_kq[0] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[0]);
}
function cc_dulieu_vaora_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        cc_dulieu_vaora_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grctId = form_Fs_VUNG_ID('GR_lke');
        b_so_theId = form_Fs_TEN_ID(b_vungId, 'SO_THE'), b_ho_tenId = form_Fs_TEN_ID(b_vungId, 'HO_TEN');
        b_ngayd = form_Fs_TEN_ID(b_vungId, 'ngayd'), b_ngayc = form_Fs_TEN_ID(b_vungId, 'ngayc');
        b_phong_tkId = form_Fs_TEN_ID(b_vungId, 'phong_tk');
        b_dimuonId = form_Fs_TEN_ID(b_vungId, 'di_muon'), b_ve_somId = form_Fs_TEN_ID(b_vungId, 've_som'),
        b_cangayId = form_Fs_TEN_ID(b_vungId, 'nghi_cn'); b_aphongId = form_Fs_VTEN_ID('UPa_hi', 'aphong');
        if (cc_dulieu_vaora_lkeCho != 0) clearTimeout(cc_dulieu_vaora_lkeCho);
        b_slideId = $get(b_grctId).getAttribute('slideId');
        form_F_GOC().P_MENUBf(window.name, 'M');
        vb_cctc_P_SL('', 'D', '0', ' ', ' ', 'T');
        b_ctyValue = "TATCA";
        cc_dulieu_vaora_P_LKE('K');
    }
}
function cc_dulieu_vaora_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var b_so_the = $get(b_so_theId).value, a_cot = GridX_Fas_tenCot(b_grctId), b_ho_ten = $get(b_ho_tenId).value;
        var b_ngaybd = $get(b_ngayd).value, b_ngaykt = $get(b_ngayc).value;
        var b_TrangKt = GridX_Fi_hangKt(b_grctId), b_phong = b_ctyValue
        a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_dimuon = $get(b_dimuonId).value, b_ve_som = $get(b_ve_somId).value, b_cangay = $get(b_cangayId).value;
        stl_cc.Fs_CC_VANTAY_LKE(form_Fs_nsd(), a_cot, b_phong, b_so_the, b_ho_ten, b_ngaybd, b_ngaykt, b_dimuon, b_ve_som, b_cangay, b_TrangKt, a_tso, cc_dulieu_vaora_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function cc_dulieu_vaora_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == "") {
        form_P_LOI('');
        return false;
    }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grctId, a_kq[1]);
}
function GridX_dat_hangkt(b_gridx, sodong) {
    try {
        var b_grid = $get(b_gridx);
        b_grid.setAttribute('hangKt', '23');
        var b_hangkt = GridX_Fi_hangKt(b_gridx);
        if (sodong > b_hangkt) {
            b_grid.setAttribute('hangKt', sodong - b_hangkt + 24);
        }
        return false;
    } catch (err) { form_P_LOI(err); }
}
function cc_dulieu_vaora_MAU() {
    var b_url = "Import_Vaora";
    var b_href = window.location.href.toString();
    var b_path = window.location.pathname.toString();
    var b_host = b_href.substring(0, b_href.length - b_path.length);
    b_url = b_host + form_Fs_TM() + "/Templates/importmau/" + b_url + ".xls";
    window.open(b_url, null, null, null);
    form_P_LOI('');
    return false;
}
function cc_dulieu_vaora_Import() {
    var b_tenf = '/App_form/ns/ma/file_Import.aspx';
    form_P_MO(b_tenf, window.name + ',THAMSO', ['THAMSO', [window.name, 'Import_Vaora', null, "Import dữ liệu vào ra"]], null);
    form_P_LOI('');
    return false;
}
function cc_dulieu_vaora_EXPORT() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function cc_dulieu_vaora_EMAIL() {
    form_P_LOI('');
    return false;
}
function P_EXCEL_KQ(b_kq) {
    //?md=TT
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_MO(form_Fs_TM() + '/App_form/bc/xexcel.aspx?md=TT', null, null, "C");
}
function cc_dulieu_vaora_phong() {
    try {
        var b_tenf = form_Fs_TM() + '/App_form/ht/ht_maph.aspx';
        form_P_MO(b_tenf, null, ["cc_dulieu_vaora", [""]]);
        return false;
    }
    catch (err) { }
}

function vb_cctc_P_CLICK(b_event, b_id) {
    b_event.stopPropagation();
    var b_targetClassNam = b_event.target.className;
    if (b_targetClassNam == "ico_bptt") {
        var b_ctr = $get(b_id), b_div = $get(b_id + '_Div');
        var a_tso = Attribute_Fas_LAY(b_ctr, 'loai,cap,dvi,ma,ma_ct');
        if (b_ctrbeforId != null) b_ctrbeforId.style.fontWeight = "100";
        b_ctr.style.fontWeight = "700";
        b_ctrbeforId = b_ctr;
        b_ctyValue = a_tso[3];
        cc_dulieu_vaora_P_LKE('K');
        return false;
    }
    else {
        var b_ctr = $get(b_id), b_div = $get(b_id + '_Div');
        var a_tso = Attribute_Fas_LAY(b_ctr, 'loai,cap,dvi,ma,ma_ct');
        if (a_tso[0] == 'A') return false;
        if (a_tso[0] != 'C') {
            if (b_div == null) vb_cctc_P_SL(b_id, a_tso[0], a_tso[1], a_tso[2], a_tso[3]);
            else {
                b_id = (C_NVL(b_div.style.display) == '') ? '' : b_id;
                vb_cctc_HIEN(a_tso[4], b_id);
            }
        }
    }
    return false;
}

function form_dong() {
    location.reload(false);
}