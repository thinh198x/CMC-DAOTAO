
var ns_dt_tinhdiem_thi_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timIdb_nhomId, b_nhomId, b_so_theId, b_kythiId, b_so_the, b_TENId,
    b_gchuId, b_ngay_chamId, b_khoadtId, b_gchu, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C';
function ns_dt_tinhdiem_thi_P_KD() {
    ns_dt_tinhdiem_thi_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_kythiId = form_Fs_TEN_ID(b_vungId, 'KYTHI'),b_ngay_chamId = form_Fs_TEN_ID(b_vungId, 'ngay_cham'), b_gchu = form_Fs_VTEN_ID('', 'GCHU'),
    b_slideId = b_grlkeId + '_slide';
    ns_dt_tinhdiem_thi_lkeCho = setInterval('ns_dt_tinhdiem_thi_P_LKE_CHO()', 200);

}
var b_cho_control = 0;
function P_cho(b_ma_nhom, b_ten, b_kythiId) {
    try {
        if (b_doi == 0) {
            $get(b_gchu).value = b_ten;
            $get(b_so_the).value = b_ma_nhom;
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
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[0];
        b_doi = 0;
        if (b_dtuong.indexOf("KYTHI") >=0) {
            //$get(b_gchu).value = a_tso[1];
            $get(b_kythiId).value = a_tso[0];
            ns_dt_tinhdiem_thi_P_LKE();
        } else if (b_dtuong.indexOf("TAI") >= 0) {
            ns_dt_tinhdiem_thi_P_LKE();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}
function ns_dt_tinhdiem_thi_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_so_the; form_P_MOI("", "XGL"); break;
            case "KYTHI": b_maId = b_kythiId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        
        if (b_maTen == "MA") {
            var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_dt_tinhdiem_thi_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_dt_tinhdiem_thi_P_CHUYEN_HANG(); }
            b_ten.focus();
        } else if (b_maTen == "KYTHI") {
            ns_dt_tinhdiem_thi_P_LKE();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_tinhdiem_thi_P_MA_KTRA() {
    try {
        var b_ma = "";
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_dto.Fs_NS_DT_TINHDIEM_THI_MA(b_ma, b_TrangKt, a_cot, ns_dt_tinhdiem_thi_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_tinhdiem_thi_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_dt_tinhdiem_thi_P_CHUYEN_HANG(); }
}

var ns_dt_tinhdiem_thi_choAct = 0;
function ns_dt_tinhdiem_thi_GR_lke_RowChange() {
    if (ns_dt_tinhdiem_thi_choAct != 0) clearTimeout(ns_dt_tinhdiem_thi_choAct);
    ns_dt_tinhdiem_thi_choAct = setTimeout("ns_dt_tinhdiem_thi_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_dt_tinhdiem_thi_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (ns_dt_tinhdiem_thi_lkeCho != 0) clearTimeout(ns_dt_tinhdiem_thi_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_dt_tinhdiem_thi_P_LKE('K');
    } 
}

function ns_dt_tinhdiem_thi_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_cot = GridX_Fas_tenCot(b_grlkeId), a_dt_ct = GridX_Fdt_cotGtri(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId), b_ma_kt = $get(b_kythiId).value,
        b_ngay_cham = $get(b_ngay_chamId).value;
    sns_dto.Fs_NS_DT_TINHDIEM_NH(b_ma_kt, b_ngay_cham,b_TrangKt, a_dt_ct, a_tso, a_cot, ns_dt_tinhdiem_thi_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_dt_tinhdiem_thi_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
        form_P_LOI("loi:Nhập thành công:loi");
    }
    return false;
}
function ns_dt_tinhdiem_thi_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    $get(b_gocId).focus();
    return false;
}
function ns_dt_tinhdiem_thi_P_CHAMDIEM() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) {
        form_P_LOI("loi:Bạn chưa chọn cán bộ cần chấm điểm:loi");
        return false;
    };
    var b_so_the = GridX_Fas_layGtri(b_grlkeId, b_hang, "SO_THE");
    if (b_so_the == "") {
        form_P_LOI("loi:Bạn chưa chọn cán bộ cần chấm điểm:loi");
        return false;
    }
    var b_ten = GridX_Fas_layGtri(b_grlkeId, b_hang, "ho_ten");
    var b_ch = GridX_Fas_layGtri(b_grlkeId, b_hang, "sc_tuluan");
    if (b_ch == "" || b_ch=="0") {
        form_P_LOI("loi:Đề thi không có câu hỏi tự luận:loi");
        return false;
    }
    var b_ma_dt = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma_dt");
    var b_tenf = '/App_form/ns/dt/ns_dt_chamdiem_tl.aspx';
    var b_ma_kythi = $get(b_kythiId).value;
    form_P_MO(b_tenf, window.name, ["THAMSO_BAITHI", [b_ma_kythi, b_so_the, b_ma_dt, b_ten]], null);
    return false; 
}
function ns_dt_tinhdiem_thi_P_EXPORT() { 
    var b_kythi = $get(b_kythiId).value;
    if (b_kythi == "") {
        form_P_LOI("Bạn chưa chọn kỳ thi"); return false;
    }
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function ns_dt_tinhdiem_thi_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    if (b_ma == "") ns_dt_tinhdiem_thi_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        return false;        
    }
    return false;
}
function ns_dt_tinhdiem_thi_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId); 
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dt_tinhdiem_thi_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dt_tinhdiem_thi_P_CHUYEN_HANG(); }
    }
}
function ns_dt_tinhdiem_thi_P_XEMLAI() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) {
        form_P_LOI("loi:Bạn chưa chọn cán bộ cần chấm điểm:loi");
        return false;
    };
    var b_so_the = GridX_Fas_layGtri(b_grlkeId, b_hang, "SO_THE");
    if (b_so_the == "") {
        form_P_LOI("loi:Bạn chưa chọn cán bộ cần chấm điểm:loi");
        return false;
    }
    var b_kythi = $get(b_kythiId).value;
    
    if (b_kythi == "") {
        form_P_LOI("loi:Bạn chưa chọn kỳ thi:loi");
        return false;
    }      
    var b_tenf = '/App_form/ns/dt/ns_dt_thuchien_bt_xemlai.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO_BAITHI", [b_kythi, b_so_the, "0"]], null);
    return false;
}
function ns_dt_tinhdiem_thi_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));       
    }
    catch (err) { form_P_LOI(err); }
}

function ns_dt_tinhdiem_thi_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var a_kythi = $get(b_kythiId).value;
        if (a_kythi == "") return false;
        sns_dto.Fs_NS_DT_TINHDIEM_THI_LKE(a_kythi,a_tso, a_cot, ns_dt_tinhdiem_thi_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
} 
function ns_dt_tinhdiem_thi_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}
function form_dong() {
    location.reload(false);
}