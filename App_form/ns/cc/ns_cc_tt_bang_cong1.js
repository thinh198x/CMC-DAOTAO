var ns_cc_tt_bang_cong_lkeCho, ns_cc_tt_bang_cong_lkecotCho, b_vungId, b_vungtkId, b_vungNhapId, b_nsd, b_aphongId, b_phongId, b_kyluongId,
    b_akyluongId, b_so_theId, ns_cc_th_choAct, b_grlkeId, b_grtmpId, b_slideId, b_mt, b_so_the;
function ns_cc_tt_bang_cong_P_KD(nsd, ten) {
    b_nsd = nsd;
    ns_cc_tt_bang_cong_lkecotCho = setInterval('ns_cc_tt_bang_cong_P_LKE_COT_CHO()', 200); 
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
            stl_cc.Fs_FILE(window.name, a_cot, ns_cc_th_P_EXCEL_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
        else if (b_dtuong.indexOf("DAYPHONG") >= 0) {
            $get(b_phongId).value = a_tso[0]; 
            ns_cc_tt_bang_cong_P_LKE();
            ns_cc_tt_bang_cong_P_LKE_CB();
        }
        $get(b_so_theId).value = b_nsd;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_th_P_EXCEL_KQ(b_kq) {
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
function ns_cc_tt_bang_cong_P_KTRA(b_maTen) {
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
            ns_cc_tt_bang_cong_P_LKE();
        }else if (b_maTen == "PHONG") {
            ns_cc_tt_bang_cong_P_LKE();
        } else if (b_maTen == "KYLUONG") {
            $get(b_aphongId).value = lke_Fs_TRA($get(b_phongId));
            $get(b_akyluongId).value = lke_Fs_TRA($get(b_kyluongId));
            ns_cc_tt_bang_cong_P_LKE();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_tt_bang_cong_P_LKE_COT_CHO() {
    if (document.readyState === 'complete') {
        ns_cc_tt_bang_cong_lkeCho, ns_cc_tt_bang_cong_lkecotCho, ns_cc_th_choAct = 0, b_vungId = form_Fs_VUNG_ID('UPa_ct'),        
        b_grmaId = form_Fs_VUNG_ID('Gr_ma'); b_grtmpId = form_Fs_VUNG_ID('GR_lke'); b_so_theId = form_Fs_TEN_ID(b_vungId, 'so_the');
        b_kyluongId = form_Fs_TEN_ID(b_vungId, 'KYLUONG'), b_phongId = form_Fs_TEN_ID(b_vungId, 'PHONG');
        b_vungNhapId = form_Fs_VUNG_ID('UPa_nhap');
        b_aphongId = form_Fs_TEN_ID('UPa_hi', 'aphong'), b_akyluongId = form_Fs_TEN_ID('UPa_hi', 'akyluong');
        $get(b_so_theId).value = b_nsd;
        lke_P_DAT($get(b_phongId), 'TATCA' + '{' + 'Tất cả');
        clearTimeout(ns_cc_tt_bang_cong_lkecotCho); ns_cc_tt_bang_cong_P_LKE_COT();
        var b_namht = (new Date()).getFullYear();
        form_P_CH_TEXT(b_vungId, 'NAM#' + b_namht);
        ns_cc_tt_bang_cong_P_NAM();
    }
}
function ns_cc_tt_bang_cong_P_LKE_COT() {
    try {
        sns_cc.Fs_NS_CC_TT_BANG_CONG_LKE_COT(form_Fs_nsd(), ns_cc_tt_bang_cong_P_LKE_COT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_tt_bang_cong_P_LKE_COT_KQ(b_kq) {
    if (b_kq != "") {
        var a_kq = list_Fas_CH(b_kq);
        var a_cot = Fas_ChMang(a_kq[1], ','), a_ten = Fas_ChMang(a_kq[0], ','), a_cotan = [], b_hangkt = GridX_Fi_hangKt(b_grtmpId);
        b_grlkeId = ns_khud_TAO(a_cot, a_ten, a_cotan, b_hangkt); clearTimeout(ns_cc_tt_bang_cong_lkeCho);
        b_slideId = $get(b_grtmpId).getAttribute('slideId');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    }
}
function ns_cc_tt_bang_cong_P_NAM() {
    try {
        var b_nam = CSO_SO(form_Fs_TEN_GTRI(b_vungId, 'NAM'));
        var form_name = window.name;
        sns_cc.Fs_NS_CC_TT_BANG_LUONG_KYLUONG_LKE(form_Fs_nsd(), b_nam, ns_cc_tt_bang_cong_P_NAM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_cc_tt_bang_cong_P_NAM_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        ns_cc_tt_bang_cong_P_KTRA("KYLUONG");
    }
} 

function ns_cc_tt_bang_cong_P_LKE() {
    if (document.readyState === 'complete') {
        b_slideId = $get(b_grtmpId).getAttribute('slideId'); 
    }
    var b_kyluong = lke_Fs_TRA($get(b_kyluongId));
    if (b_kyluong == null || b_kyluong == "") { form_P_MOI("", "XGL"); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grlkeId), b_phong = lke_Fs_TRA($get(b_phongId)), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_so_the = $get(b_so_theId).value;
        stl_cc.Fs_NS_CC_TH_LKE(form_Fs_nsd(), b_phong, b_kyluong, b_so_the,a_tso, a_cot_ct, ns_cc_tt_bang_cong_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
}
function ns_cc_tt_bang_cong_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[1], 0));
        if (a_kq[0] == "") GridX_datTrang(b_grlkeId);
        else GridX_datBang(b_grlkeId, a_kq[0]);
        return false;
    }
    //var a_kq = b_kq.split('#');
    //if (a_kq[0] == "") GridX_datTrang(b_grlkeId); else GridX_datBang(b_grlkeId, a_kq[0]);

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
function ns_cc_tt_bang_cong_TINH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var b_phong = b_phong = form_Fs_TEN_GTRI(b_vungId, 'PHONG'), b_kyluong = form_Fs_TEN_GTRI(b_vungId, 'KYLUONG');
        if (b_kyluong == null || b_kyluong == "") { form_P_LOI("loi:Phải chọn tháng tính lương:loi"); }
        else {
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId), b_so_the = $get(b_so_theId).value;
            stl_cc.Fs_ns_cc_tt_bang_cong_TINH(form_Fs_nsd(), b_phong, b_kyluong, b_so_the,a_tso, a_cot, ns_cc_tt_bang_cong_P_TINH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_tt_bang_cong_P_TINH_KQ(b_kq) {

    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        a_kq = Fas_ChMang(b_kq, '#');
        GridX_datBang(b_grlkeId, a_kq[1]);
        slide_P_MOI(b_slideId, 1, CSO_SO(a_kq[0]));        
        form_P_LOI('loi:Tổng hợp dữ liệu thành công:loi');
    }
    return false;
}
function ns_cc_th_P_IN() {
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
function ns_cc_th_P_FILES() {
    var b_tenf = b_tmf + "/khud/khud_Excel.aspx";
    form_P_MO(b_tenf, window.name + ",FILE_CC", null);
    return false;
}
function ns_cc_th_P_BC() {
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