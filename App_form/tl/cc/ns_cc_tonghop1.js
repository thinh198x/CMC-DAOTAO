var ns_cc_tonghop_lkeCho, ns_cc_tonghop_lkecbCho, b_vungId, b_grlkeId, b_grctId, b_mt;
function ns_cc_tonghop_P_KD(b_tm) {
    b_tmf = b_tm, ns_cc_tonghop_lkeCho, ns_cc_tonghop_lkecbCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct');
    b_grmaId = form_Fs_VUNG_ID('Gr_ma');
    b_kyluongId = form_Fs_TEN_ID(b_vungId, 'KYLUONG'), b_phongId = form_Fs_TEN_ID(b_vungId, 'PHONG');
    b_slideId = b_grlkeId + '_slide';
    ns_cc_tonghop_lkeCho = setInterval('ns_cc_tonghop_P_LKE_CHO()', 200);
    ns_cc_tonghop_lkecbCho = setInterval('ns_cc_tonghop_P_LKE_COT_CHO()', 200); 
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
            stl_cc.Fs_FILE(window.name, a_cot, ns_cc_tonghop_P_EXCEL_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
        else if (b_dtuong.indexOf("DAYPHONG") >= 0) {
            $get(b_phongId).value = a_tso[0];
            ns_cc_tonghop_P_MOI();
            ns_cc_tonghop_P_LKE();
            ns_cc_tonghop_P_LKE_CB();
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_cc_tonghop_P_EXCEL_KQ(b_kq) {
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


function ns_cc_tonghop_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "PHONG": b_maId = b_phongId; break;
            case "KYLUONG": b_maId = b_kyluongId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null) return;
        if (b_maTen == "PHONG") {
            ns_cc_tonghop_P_MOI();
            ns_cc_tonghop_P_LKE(); 
        } else if (b_maTen == "KYLUONG") {
            var b_kyluong = $get(b_kyluongId).value;
            ns_cc_tonghop_P_CHUYEN_HANG();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_danhsach_P_NAM() {
    try {
        var b_nam = form_Fs_TEN_GTRI(b_vungId, 'nam');
        stl_cc.Fs_DANHSACH_KYLUONG_LKE(b_nam, ns_danhsach_P_KYLUONG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_danhsach_P_KYLUONG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_kyluongId = form_Fs_TEN_ID(b_vungId, 'kyluong');
        drop_P_LKE(b_kyluongId, b_kq);
    }
    cc_cn_ct_P_KTRA("KYLUONG");
}
function ns_cc_tonghop_P_LKE_COT() {
    try {
        var a_cot_ma = GridX_Fas_tenCot(b_grmaId);
        stl_cc.Fs_NS_CC_TONGHOP_LKE_COT(a_cot_ma, ns_cc_tonghop_P_LKE_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_tonghop_P_LKE_CB_KQ(b_kq) {
    if (b_kq == "") GridX_datTrang(b_grctId);
    else {
        var a_kq = b_kq.split('#');
        for (var i = 0; i < a_kq.length; i++) {
            $get("ctl00_ContentPlaceHolder1_Label" + (i + 7)).innerHTML = a_kq[i];
        }
        for (var i = a_kq.length ; i < 21; i++) {
            $get("td" + (i + 6)).style.display = "none";
        }
        for (var i = a_kq.length ; i < 27; i++) { 
            GridX_anCot(b_grctId, "CONG_" + (i), "none");
        }
        Attribute_P_DAT($get(b_grctId),"WIDTH","1600px");
        return false;
    }
}
function hideColumn(col_num) {
    rows = document.getElementById("ctl00_ContentPlaceHolder1_GR_ct").rows;
    for (i = 0; i < rows.length; i++) {
        rows[i].cells[col_num].style.display = "none";
    }
}
var ns_cc_tonghop_choAct = 0;
function ns_cc_tonghop_GR_lke_RowChange() {
    if (ns_cc_tonghop_choAct != 0) clearTimeout(ns_cc_tonghop_choAct);
    ns_cc_tonghop_choAct = setTimeout("ns_cc_tonghop_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_cc_tonghop_P_LKE_CHO() {
    if ($get(b_grctId) != null) { clearTimeout(ns_cc_tonghop_lkeCho); ns_cc_tonghop_P_LKE(); }
}
function ns_cc_tonghop_P_LKE_COT_CHO() {
    if ($get(b_grctId) != null) { clearTimeout(ns_cc_tonghop_lkecbCho); ns_cc_tonghop_P_LKE_COT(); }
}
function ns_cc_tonghop_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_datTrang(b_grctId);
    //ns_cc_tonghop_P_LKE_CB();
}
function ns_cc_tonghop_P_LKE() {
    try {
        var b_phong = $get(b_phongId).value, a_cot = GridX_Fas_tenCot(b_grctId);
        ns_cc_tonghop_P_CHUYEN_HANG();
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_tonghop_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    return false;
}

function ns_cc_tonghop_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_dt = form_Faa_TEXT_ROW(b_vungId),
                a_cot_ma = GridX_Fdt_cotGtri(b_grmaId),
                a_cot_ct = GridX_Fdt_cotGtri(b_grctId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
            stl_cc.Fs_NS_CC_TONGHOP_NH(b_TrangKt, b_dt, a_cot_ma, a_cot_ct, a_cot_lke, ns_cc_tonghop_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_tonghop_P_MO() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_phong = $get(b_phongId).value, b_kyluong = $get(b_kyluongId).value;
            stl_cc.Fs_NS_CC_TONGHOP_MO(b_phong, b_kyluong, ns_cc_tonghop_P_DONGMO_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            $get("tdMo").style.display = "none";
            $get("tdKhoa").style.display = "";
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_tonghop_P_DONG() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else { 
            var b_phong = $get(b_phongId).value, b_kyluong = $get(b_kyluongId).value;            
            stl_cc.Fs_NS_CC_TONGHOP_DONG(b_phong, b_kyluong, ns_cc_tonghop_P_DONGMO_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            $get("tdMo").style.display = "";
            $get("tdKhoa").style.display = "none";
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_tonghop_P_DONGMO_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; } 
    return false;
}
function ns_cc_tonghop_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
    }
    return false;
}
function ns_cc_tonghop_P_CHUYEN_HANG() {

    var b_kyluong = $get(b_kyluongId).value;
    if (b_kyluong == null || b_kyluong == "") { form_P_MOI("", "XGL"); ns_cc_tonghop_P_LKE_CB(); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId), b_phong = $get(b_phongId).value, a_cot_ma = GridX_Fas_tenCot(b_grmaId);
        stl_cc.Fs_NS_CC_TONGHOP_CT(b_phong, b_kyluong, a_cot_ct, a_cot_ma, ns_cc_tonghop_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
}
function ns_cc_tonghop_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var a_kq = b_kq.split('#');
    GridX_dat_hangkt(b_grctId, a_kq[2]); 
    if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);

    if (a_kq[3] == "1") {
        $get("tdKhoa").style.display = "none";
        $get("tdMo").style.display = "";
    } else{
        $get("tdMo").style.display = "none";
        $get("tdKhoa").style.display = "";
    }
    return false;
}
function ns_cc_tonghop_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_kyluong = $get(b_kyluongId).value;
    if (b_kyluong == "") ns_cc_tonghop_P_MOI();
    else {
        var b_phong = $get(b_phongId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_cc.Fs_NS_CC_TONGHOP_XOA(b_phong, b_kyluong, a_tso, a_cot, ns_cc_tonghop_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_cc_tonghop_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_cc_tonghop_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_cc_tonghop_P_CHUYEN_HANG(); }
    }
}

function ns_cc_tonghop_TINH() {
    try {
        var b_phong = $get(b_phongId).value,
        b_kyluong = $get(b_kyluongId).value;
        if (b_kyluong == null || b_kyluong == "") { alert("Phải nhập tháng tính lương"); }
        else {
            var a_cot_ct = GridX_Fdt_cotGtri(b_grmaId);
            var a_cot = GridX_Fas_tenCot(b_grctId);
            stl_cc.Fs_NS_CC_TONGHOP_TINH(b_phong, b_kyluong, a_cot_ct, a_cot, ns_cc_tonghop_P_TINH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_tonghop_P_TINH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    GridX_dat_hangkt(b_grctId, a_kq[1]);
    if (a_kq[0] == "") GridX_datTrang(b_grctId);
    else GridX_datBang(b_grctId, a_kq[0]);
    form_P_LOI('loi:Tổng hợp dữ liệu thành công:loi');
    return false;
}

function ns_cc_tonghop_P_IN() {
    //var a_cot = GridX_Fdt_cotGtri(b_grctId);
    //var b_ma_bc = 'ns_ns_cc_tonghop.xml',
    //    b_ddan = '~/Templates/ns/', a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
    //var b_kieu_in = 'E', b_ten_rp = b_ma_bc;
    //var a_dt = GridX_Fdt_cotGtri(b_grctId);
    //if (b_ten_rp == "") { form_P_LOI('Chưa chọn đúng báo cáo'); return; }
    //sti_ch.Fs_EXCEL_TIENLUONG("ns_ngbc", "TT", b_ma_bc, b_ddan, b_ten_rp, b_kieu_in, a_dt_ct, a_dt, P_EXCEL_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    //return false;
    __doPostBack('ctl00$ContentPlaceHolder1$Nhap2', '');
}
function ns_cc_tonghop_P_PHEDUYET() {
    if (window.confirm("Phê duyệt thành công, Hệ thống sẽ tự động gửi bảng công cho tất cả các cán bộ nhân viên?")) {
         
    }
    form_P_LOI('');
    return false;
}
function P_EXCEL_KQ(b_kq) {
    //?md=TT
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_MO(form_Fs_TM() + '/App_form/bc/xexcel.aspx?md=TT', null, null, "C");
}

function ns_cc_tonghop_P_FILES() {
    var b_tenf = b_tmf + "/khud/khud_Excel.aspx";
    form_P_MO(b_tenf, window.name + ",FILE_CC", null);
    return false;
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

function ns_cc_tonghop_phong() {
    try {
        var b_tenf = form_Fs_TM() + '/App_form/ht/ht_maph.aspx';
        form_P_MO(b_tenf, null, ["ns_cc_tonghop", [""]]);
        return false;
    }
    catch (err) { }
}

function ns_cc_tonghop_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_cc_tonghop_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_cc_tonghop_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function ns_cc_tonghop_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}

function form_dong() {
    location.reload(false);
}