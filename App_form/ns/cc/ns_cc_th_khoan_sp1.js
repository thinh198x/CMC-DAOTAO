var ns_cc_th_khoan_sp_lkeCho, b_vungId, b_vungNhapId, b_phongId, b_kyluongId, b_aphongId, b_akyluongId, b_so_theId, ns_cc_th_khoan_sp_choAct, b_moId, b_dongId, b_grtmpId, b_slideId, b_mt, b_ctyId, b_ctyValue, b_ctrbeforId;
function ns_cc_th_khoan_sp_P_KD() {
    ns_cc_th_khoan_sp_lkeCho = setInterval('ns_cc_th_khoan_sp_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("MA01_") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grmaId);
            if (b_hang > -1) { GridX_datGtri(b_grmaId, b_hang, "MA01", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
        }
        else if (b_dtuong.indexOf("MA2_") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grmaId);
            if (b_hang > -1) { GridX_datGtri(b_grmaId, b_hang, "MA2", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
        }
        else if (b_dtuong.indexOf("MA3_") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grmaId);
            if (b_hang > -1) { GridX_datGtri(b_grmaId, b_hang, "MA3", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
        }
        else if (b_dtuong.indexOf("MA4_") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grmaId);
            if (b_hang > -1) { GridX_datGtri(b_grmaId, b_hang, "MA4", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
        }
        else if (b_dtuong.indexOf("MA5_") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grmaId);
            if (b_hang > -1) { GridX_datGtri(b_grmaId, b_hang, "MA5", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
        }
        else if (b_dtuong.indexOf("MA6_") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grmaId);
            if (b_hang > -1) { GridX_datGtri(b_grmaId, b_hang, "MA6", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
        }
        else if (b_dtuong.indexOf("MA7_") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grmaId);
            if (b_hang > -1) { GridX_datGtri(b_grmaId, b_hang, "MA7", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
        }
        else if (b_dtuong.indexOf("MA8_") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grmaId);
            if (b_hang > -1) { GridX_datGtri(b_grmaId, b_hang, "MA8", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
        }
        else if (b_dtuong.indexOf("MA9_") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grmaId);
            if (b_hang > -1) { GridX_datGtri(b_grmaId, b_hang, "MA9", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
        }
        else if (b_dtuong.indexOf("MA10") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grmaId);
            if (b_hang > -1) { GridX_datGtri(b_grmaId, b_hang, "MA10", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
        }
        else if (b_dtuong.indexOf("MA11") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grmaId);
            if (b_hang > -1) { GridX_datGtri(b_grmaId, b_hang, "MA11", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
        }
        else if (b_dtuong.indexOf("MA12") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grmaId);
            if (b_hang > -1) { GridX_datGtri(b_grmaId, b_hang, "MA12", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
        }
        else if (b_dtuong.indexOf("MA13") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grmaId);
            if (b_hang > -1) { GridX_datGtri(b_grmaId, b_hang, "MA13", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
        }
        else if (b_dtuong.indexOf("MA14") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grmaId);
            if (b_hang > -1) { GridX_datGtri(b_grmaId, b_hang, "MA14", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
        }
        else if (b_dtuong.indexOf("MA15") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grmaId);
            if (b_hang > -1) { GridX_datGtri(b_grmaId, b_hang, "MA15", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
        }
        else if (b_dtuong.indexOf("MA16") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grmaId);
            if (b_hang > -1) { GridX_datGtri(b_grmaId, b_hang, "MA16", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
        }
        else if (b_dtuong.indexOf("MA17") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grmaId);
            if (b_hang > -1) { GridX_datGtri(b_grmaId, b_hang, "MA17", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
        }
        else if (b_dtuong.indexOf("MA18") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grmaId);
            if (b_hang > -1) { GridX_datGtri(b_grmaId, b_hang, "MA18", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
        }
        else if (b_dtuong.indexOf("MA19") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grmaId);
            if (b_hang > -1) { GridX_datGtri(b_grmaId, b_hang, "MA19", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
        }
        else if (b_dtuong.indexOf("MA20") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grmaId);
            if (b_hang > -1) { GridX_datGtri(b_grmaId, b_hang, "MA20", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
        }
        else if (b_dtuong.indexOf("MA21") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grmaId);
            if (b_hang > -1) { GridX_datGtri(b_grmaId, b_hang, "MA21", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
        }
        else if (b_dtuong.indexOf("MA22") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grmaId);
            if (b_hang > -1) { GridX_datGtri(b_grmaId, b_hang, "MA22", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
        }
        else if (b_dtuong.indexOf("MA23") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grmaId);
            if (b_hang > -1) { GridX_datGtri(b_grmaId, b_hang, "MA23", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
        }
        else if (b_dtuong.indexOf("MA24") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grmaId);
            if (b_hang > -1) { GridX_datGtri(b_grmaId, b_hang, "MA24", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
        }
        else if (b_dtuong.indexOf("MA25") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grmaId);
            if (b_hang > -1) { GridX_datGtri(b_grmaId, b_hang, "MA25", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
        }
        else if (b_dtuong.indexOf("FILE_CC") >= 0) {
            var a_cot = GridX_Fas_tenCot(b_grctId);
            stl_cc.Fs_FILE(window.name, a_cot, ns_cc_th_khoan_sp_P_EXCEL_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
        else if (b_dtuong.indexOf("DAYPHONG") >= 0) {
            $get(b_phongId).value = a_tso[0];
            ns_cc_th_khoan_sp_P_LKE();
            ns_cc_th_khoan_sp_P_LKE_CB();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_th_khoan_sp_P_EXCEL_KQ(b_kq) {
    try {
        var a_kq = b_kq.split('#');
        if (a_kq[0] == "") return;
        else {
            GridX_dat_hangkt(b_grctId, a_kq[1]);
            GridX_datBang(b_grctId, b_kq);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_th_khoan_sp_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_so_theId; break;
            case "PHONG": b_maId = b_phongId; break;
            case "KYLUONG": b_maId = b_kyluongId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null) return;
        if (b_maTen == "SO_THE") {
            ns_cc_th_khoan_sp_P_LKE();
        } else if (b_maTen == "PHONG") {
            $get(b_aphongId).value = b_ctyValue;
            $get(b_akyluongId).value = lke_Fs_TRA($get(b_kyluongId));
            ns_cc_th_khoan_sp_P_LKE();
        } else if (b_maTen == "KYLUONG") {
            $get(b_aphongId).value = b_ctyValue;
            $get(b_akyluongId).value = lke_Fs_TRA($get(b_kyluongId));
            ns_cc_th_khoan_sp_P_LKE();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_th_khoan_sp_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        ns_cc_th_khoan_sp_lkeCho, ns_cc_th_khoan_sp_choAct = 0, b_vungId = form_Fs_VUNG_ID('UPa_ct'),
        b_grmaId = form_Fs_VUNG_ID('Gr_ma'); b_grtmpId = form_Fs_VUNG_ID('GR_lke'); b_so_theId = form_Fs_TEN_ID(b_vungId, 'so_the');
        b_kyluongId = form_Fs_TEN_ID(b_vungId, 'KYLUONG'), b_phongId = form_Fs_TEN_ID(b_vungId, 'PHONG');
        b_vungNhapId = form_Fs_VUNG_ID('UPa_nhap'), b_moId = form_Fs_TEN_ID(b_vungNhapId, 'tdMo'), b_dongId = form_Fs_TEN_ID(b_vungNhapId, 'tdKhoa');
        b_aphongId = form_Fs_TEN_ID('UPa_hi', 'aphong'), b_akyluongId = form_Fs_TEN_ID('UPa_hi', 'akyluong');
        lke_P_DAT($get(b_phongId), 'TATCA' + '{' + 'Tất cả');
        form_F_GOC().P_MENUBf(window.name, 'M');
        vb_cctc_P_SL('', 'D', '0', ' ', ' ', 'T'); //  vb_cctc_P_SL('', 'A', '0', ' ', ' ', 'T'); -- Chỉ hiện đơn vị
        b_ctyValue = "TATCA";
        clearTimeout(ns_cc_th_khoan_sp_lkeCho); ns_cc_th_khoan_sp_P_LKE_KYLUONG();
    }
}
function ns_cc_th_khoan_sp_P_LKE_KYLUONG() {
    try {
        var b_form = "ns_cc_th_khoan_sp", b_nam = "DT_NAM", b_thang = "DT_KY";
        hts_dungchung.Fs_NS_CC_KY(form_Fs_nsd(), b_form, b_nam, b_thang, ns_cc_th_khoan_sp_P_LKE_KYLUONG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_th_khoan_sp_P_LKE_KYLUONG_KQ(b_kq) {
    if (b_kq != "") {
        form_P_CH_TEXT(b_vungId, b_kq);
    }
    ns_cc_th_khoan_sp_P_KTRA("KYLUONG");
}
function ns_cc_th_khoan_sp_P_NAM() {
    try {
        var b_nam = form_Fs_TEN_GTRI(b_vungId, 'NAM');
        stl_cc.Fs_NS_CC_TH_KHOAN_SP_KYLUONG_LKE(form_Fs_nsd(), b_nam, ns_cc_th_khoan_sp_P_NAM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_cc_th_khoan_sp_P_NAM_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        ns_cc_th_khoan_sp_P_KTRA("KYLUONG");
    }
}
function ns_cc_th_khoan_sp_P_MO() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_phong = form_Fs_TEN_GTRI(b_vungId, 'PHONG'), b_kyluong = form_Fs_TEN_GTRI(b_vungId, 'KYLUONG');
            stl_cc.Fs_NS_CC_TH_KHOAN_SP_MO(form_Fs_nsd(), b_ctyValue, b_kyluong, ns_cc_th_khoan_sp_P_DONGMO_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            $get(b_moId).style.display = "none";
            $get(b_dongId).style.display = "";
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_th_khoan_sp_P_DONG() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_phong = form_Fs_TEN_GTRI(b_vungId, 'PHONG'), b_kyluong = form_Fs_TEN_GTRI(b_vungId, 'KYLUONG');
            stl_cc.Fs_NS_CC_TH_KHOAN_SP_DONG(form_Fs_nsd(), b_ctyValue, b_kyluong, ns_cc_th_khoan_sp_P_DONGMO_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            $get(b_moId).style.display = "";
            $get(b_dongId).style.display = "none";
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_th_khoan_sp_P_DONGMO_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    return false;
}
function ns_cc_th_khoan_sp_P_LKE() {
    if (document.readyState === 'complete') {
        b_slideId = $get(b_grtmpId).getAttribute('slideId');
    }
    var b_kyluong = lke_Fs_TRA($get(b_kyluongId));
    if (b_kyluong == null || b_kyluong == "") { form_P_MOI("", "XGL"); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grtmpId), b_phong = lke_Fs_TRA($get(b_phongId)), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_so_the = $get(b_so_theId).value;
        stl_cc.Fs_NS_CC_TH_KHOAN_SP_LKE(form_Fs_nsd(), b_ctyValue, b_kyluong, b_so_the, a_tso, a_cot_ct, ns_cc_th_khoan_sp_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
}
function ns_cc_th_khoan_sp_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[1], 0));
        if (a_kq[0] == "") GridX_datTrang(b_grtmpId);
        else GridX_datBang(b_grtmpId, a_kq[0]);
        return false;
    }
    //var a_kq = b_kq.split('#');
    //if (a_kq[0] == "") GridX_datTrang(b_grtmpId); else GridX_datBang(b_grtmpId, a_kq[0]);

    //if (a_kq[2] == "1") {
    //    $get("tdKhoa").style.display = "none";
    //    $get("tdMo").style.display = "";
    //} else {
    //    $get("tdMo").style.display = "none";
    //    $get("tdKhoa").style.display = "";
    //}
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[1], 0));
    return false;
}
function ns_cc_th_khoan_sp_TINH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var b_phong = b_phong = form_Fs_TEN_GTRI(b_vungId, 'PHONG'), b_kyluong = form_Fs_TEN_GTRI(b_vungId, 'KYLUONG');
        if (b_kyluong == null || b_kyluong == "") { form_P_LOI("loi:Phải chọn tháng tính lương:loi"); }
        else {
            var a_cot = GridX_Fas_tenCot(b_grtmpId), a_tso = slide_Faobj_TUDEN(b_slideId), b_so_the = $get(b_so_theId).value;
            stl_cc.Fs_NS_CC_TH_KHOAN_SP_TINH(form_Fs_nsd(), b_ctyValue, b_kyluong, b_so_the, a_tso, a_cot, ns_cc_th_khoan_sp_P_TINH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_th_khoan_sp_P_TINH_KQ(b_kq) {

    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        if (b_kq == "") {
            form_P_LOI('loi:Tổng hợp dữ liệu thành công:loi');
            return false;
        } else {
            a_kq = Fas_ChMang(b_kq, '#');
            GridX_datBang(b_grtmpId, a_kq[1]);
            slide_P_MOI(b_slideId, 1, CSO_SO(a_kq[0]));
            form_P_LOI('loi:Tổng hợp dữ liệu thành công:loi');
        }
    }
    return false;
}
function ns_cc_th_khoan_sp_P_IN() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") form_P_LOI(b_loi);
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function P_EXCEL_KQ(b_kq) {
    //?md=TT
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_MO(form_Fs_TM() + '/App_form/bc/xexcel.aspx?md=TT', null, null, "C");
}
function ns_cc_th_khoan_sp_P_FILES() {
    var b_tenf = b_tmf + "/khud/khud_Excel.aspx";
    form_P_MO(b_tenf, window.name + ",FILE_CC", null);
    return false;
}
function ns_cc_th_khoan_sp_P_BC() {
    __doPostBack('ctl00$ContentPlaceHolder1$Nhap1', '');
}
function GridX_dat_hangkt(b_gridx, sodong) {
    try {
        var b_grid = $get(b_gridx);
        b_grid.setAttribute('hangKt', '19');
        var b_hangkt = GridX_Fi_hangKt(b_gridx);
        if (sodong > b_hangkt) {
            b_grid.setAttribute('hangKt', sodong - b_hangkt + 20);
        }
        return false;
    } catch (err) { form_P_LOI(err); }
}
function form_dong() {
    location.reload(false);
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
        b_ctyValue = a_tso[3]; //  b_ctyValue = a_tso[2]; -- Chỉ hiện đơn vị
        ns_cc_th_khoan_sp_P_LKE('K'); return false;
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