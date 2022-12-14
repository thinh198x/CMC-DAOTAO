var ns_dt_ngv_ql_cchi_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_ghichuId, b_ma_cha_Id, b_ma_cha_Tk, b_hinhthuc_thi_tk, b_ma_con_Id, b_ten_dvi_cc, b_chiphi, b_thoihan_cchi, b_nsd, b_vungtkId;
function ns_dt_ngv_ql_cchi_P_KD() {
    //lấy ID ở các vùng 
    b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_vungtkId = form_Fs_VUNG_ID('Upa_tk'), b_vgchuId = form_Fs_VUNG_ID('UPa_gchu');
    //lấy ID theo tên truyền vào ở các vùng
    //b_kdtaoId = form_Fs_TEN_ID(b_vungId, 'KDTAO'),
    //b_md_utien_Id = form_Fs_TEN_ID(b_vungId, 'md_utien'),
    //b_nam_lst = form_Fs_TEN_ID(b_vungtkId, 'nam_lst'),
    //b_thang_lst = form_Fs_TEN_ID(b_vungtkId, 'thang_lst'),
    
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_nsd = form_Fs_nsd();
    b_slideId = b_grlkeId + '_slide';
    ns_dt_ngv_ql_cchi_lkeCho = setInterval('ns_dt_ngv_ql_cchi_P_LKE_CHO()', 200);
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        switch (b_dtuong) {
            case "CTL00_CONTENTPLACEHOLDER1_MA_NV":
                $get(b_kdtaoId).value = b_kq;
                sns_tt.Fs_NS_CB_CT(b_kq, ns_cb_P_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                //$get(b_gchuId).innerHTML = a_tso[1];
                break;
            case "CTL00_CONTENTPLACEHOLDER1_MD_UTIEN":
                $get(b_md_utien_Id).value = b_kq;
                $get(b_gchuId).innerHTML = a_tso[1];
                break;
        }

        //if (b_dtuong.indexOf("LV_CHA_TK") >= 0) {
        //    $get(b_ma_cha_Tk).value = b_kq;
        //    $get(b_ghichuId).innerHTML = a_tso[1];
        //    //$get(b_ten_dvi_cc).focus();
        //}
        //else if (b_dtuong.indexOf("LV_CHA") >= 0) {
        //    $get(b_ma_cha_Id).value = b_kq;
        //    $get(b_ghichuId).innerHTML = a_tso[1];
        //    $get(b_ma_con_Id).focus();
        //}
        //else if (b_dtuong.indexOf("LV_CON") >= 0) {
        //    $get(b_ma_con_Id).value = b_kq;
        //    $get(b_ghichuId).innerHTML = a_tso[1];
        //    $get(b_ten_dvi_cc).focus();
        //}

    }
    catch (err) { form_P_LOI(err); }
}
function ns_cb_P_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    //form_P_CH_TEXT(b_vungId, a_kq[0]);
    //khud_ttt_P_LKE(a_kq[2]);
    return false;
}
function ns_dt_ngv_ql_cchi_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return false;
        else if (b_maTen == "MA") {
            $get(b_gocId).value = b_ma.value.validate_Ma();
            var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_dt_ngv_ql_cchi_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_dt_ngv_ql_cchi_P_CHUYEN_HANG(); }
            b_ten.focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_dt_ngv_ql_cchi_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_dt.Fs_ns_dt_ngv_ql_cchi_MA(b_ma, b_TrangKt, a_cot, ns_dt_ngv_ql_cchi_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ngv_ql_cchi_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_dt_ngv_ql_cchi_P_CHUYEN_HANG(); }
}

function ns_dt_ngv_ql_cchi_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        return false;
    } else form_P_DatGchu(b_ghichuId, b_kq);
}

var ns_dt_ngv_ql_cchi_choAct = 0;
function ns_dt_ngv_ql_cchi_GR_lke_RowChange() {
    if (ns_dt_ngv_ql_cchi_choAct != 0) clearTimeout(ns_dt_ngv_ql_cchi_choAct);
    ns_dt_ngv_ql_cchi_choAct = setTimeout("ns_dt_ngv_ql_cchi_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_dt_ngv_ql_cchi_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_dt_ngv_ql_cchi_lkeCho); ns_dt_ngv_ql_cchi_P_LKE(); }
}

function ns_dt_ngv_ql_cchi_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    //$get(b_gocId).focus();
    return false;
}

function ns_dt_ngv_ql_cchi_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.Fs_ns_dt_ngv_ql_cchi_LKE(a_tso, a_cot, ns_dt_ngv_ql_cchi_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ngv_ql_cchi_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}

function ns_dt_ngv_ql_cchi_P_LKE_TK() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_nam = form_Fs_TEN_GTRI(b_vungtkId, 'thang_lst'),
        b_thang = form_Fs_TEN_GTRI(b_vungtkId, 'thang_lst');
        sns_dt.Fs_ns_dt_ngv_ql_cchi_LKE_TK(b_nam, b_thang, a_tso, a_cot, ns_dt_ngv_ql_cchi_P_LKE_TK_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ngv_ql_cchi_P_LKE_TK_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}

function ns_dt_ngv_ql_cchi_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang < 1) b_hang = -1;
            var a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            sns_dt.Fs_ns_dt_ngv_ql_cchi_NH(b_TrangKt, a_dt_ct, a_cot, ns_dt_ngv_ql_cchi_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}


function ns_dt_ngv_ql_cchi_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        //$get(b_gocId).focus();
    }
    return false;
}

function sendMail(b_tso) {
    var a_tso = Fas_ChMang(b_tso, ';');
    var b_toAddress = a_tso[0],
        b_subject = a_tso[1],
        b_body = a_tso[2];
    if (b_toAddress == "" || b_toAddress == null || b_toAddress == undefined) return false;
    else {
        sSmtpMail.SendMail(b_toAddress, b_subject, b_body, sendMail_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
}

function ns_dt_ngv_ql_cchi_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "soid"));
    if (b_ma == "") ns_dt_ngv_ql_cchi_P_MOI();
    else sns_dt.Fs_ns_dt_ngv_ql_cchi_CT(b_ma, ns_dt_ngv_ql_cchi_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function ns_dt_ngv_ql_cchi_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
function ns_dt_ngv_ql_cchi_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "soid");
    if (b_ma == "") ns_dt_ngv_ql_cchi_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.Fs_ns_dt_ngv_ql_cchi_XOA(b_ma, a_tso, a_cot, ns_dt_ngv_ql_cchi_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}

function ns_dt_ngv_ql_cchi_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dt_ngv_ql_cchi_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dt_ngv_ql_cchi_P_CHUYEN_HANG(); }
    }
    return false;
}
function ns_dt_ngv_ql_cchi_P_CHON() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_check = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tinhtrang"));
    form_P_TRA_CHON('MA,TEN');
    return false;
}

function ns_dt_ngv_ql_cchi_P_IN() {
    __doPostBack('ctl00$ContentPlaceHolder1$Nhap2', '');
}

function form_dong() {
    location.reload(false);
}