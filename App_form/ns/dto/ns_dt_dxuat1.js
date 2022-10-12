var ns_dt_dxuat_lkeCho, b_vungId, b_grlkeId, b_slideId,b_soth_gvId, b_gocId, b_dvtochucId, b_loai_dtanId, b_loaidtId, b_gvienId, b_lanId, b_kynangId, b_ykienId, b_gchuId, b_moiId,
    b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C';
function ns_dt_dxuat_P_KD() {
    ns_dt_dxuat_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'); b_dvtochucId = form_Fs_TEN_ID(b_vungId, 'dvtochuc'), b_loaidtId = form_Fs_TEN_ID(b_vungId, 'LOAIDT'),
    b_gvienId = form_Fs_TEN_ID(b_vungId, 'tengv'), b_lanId = form_Fs_TEN_ID(b_vungId, 'lan'), b_kynangId = form_Fs_TEN_ID(b_vungId, 'kynang'),
    b_ma_nhucauId = form_Fs_TEN_ID(b_vungId, 'ma_nhucau');
    b_ykienId = form_Fs_TEN_ID(b_vungId, 'ykien');
    b_soth_gvId = form_Fs_TEN_ID(b_vungId, 'so_the');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_moiId = form_Fs_VTEN_ID('', 'moi');
    b_loai_dtanId = form_Fs_VTEN_ID('UPa_hi', 'loaidtan')
    b_slideId = b_grlkeId + '_slide';
    ns_dt_dxuat_lkeCho = setInterval('ns_dt_dxuat_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("KYNANG") >= 0) {
            $get(b_kynangId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_lanId).focus();
        }
        else if (b_dtuong.indexOf("TENGV") >= 0) {
            $get(b_soth_gvId).value = b_kq;
            $get(b_gvienId).value = a_tso[1];
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_dvtochucId).focus();
        }
        else if (b_dtuong.indexOf("KQ") >= 0) {
            $get(b_loaidtId).value = a_tso[1];
            $get(b_gocId).value = a_tso[0];
            ns_dt_dxuat_P_LKE('K');
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", a_tso[0]);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_dt_dxuat_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_dt_dxuat_P_CHUYEN_HANG(); }
        } else if (b_dtuong.indexOf("MA_NHUCAU") >= 0) {
            $get(b_ma_nhucauId).value = a_tso[0];
            $get(b_gchuId).innerHTML = a_tso[1];
        }
    }
    catch (err) { form_P_LOI(err); }
}

function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}
function ns_dt_dxuat_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
            case "KEHOACH": b_maId = b_kynangId; break;
            case "PHONG": b_maId = b_loaidtId; break;
            case "TENGV": b_maId = b_gvienId; break;
            case "LOAIDT": b_maId = b_loaidtId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return false;
        else if (b_maTen == "MA") {
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_dt_dxuat_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_dt_dxuat_P_CHUYEN_HANG(); }
        }
        else if (b_maTen == "PHONG") { ns_dt_dxuat_P_MOI(); ns_dt_dxuat_P_LKE('K'); }
        else if (b_maTen == "LOAIDT") { ns_dt_dxuat_P_LKE('K'); $get(b_loai_dtanId).value = form_Fs_TEN_GTRI(b_vungId, 'loaidt'); }
        else skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_dt_dxuat_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_dxuat_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_loai_dt = form_Fs_TEN_GTRI(b_vungId, 'loaidt');
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_dto.Fs_NS_DT_DXUAT_MA(b_loai_dt, b_ma, b_TrangKt, a_cot, ns_dt_dxuat_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_dxuat_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_dt_dxuat_P_CHUYEN_HANG(); }
}

function ns_dt_dxuat_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        return false;
    } else form_P_DatGchu(b_gchuId, b_kq);
}

var ns_dt_dxuat_choAct = 0;
function ns_dt_dxuat_GR_lke_RowChange() {
    if (ns_dt_dxuat_choAct != 0) clearTimeout(ns_dt_dxuat_choAct);
    ns_dt_dxuat_choAct = setTimeout("ns_dt_dxuat_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_dt_dxuat_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (ns_dt_dxuat_lkeCho != 0) clearTimeout(ns_dt_dxuat_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_dt_dxuat_P_LKE('K');
    }
}

function ns_dt_dxuat_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_gocId).focus();
    return false;
}
function ns_dt_dxuat_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
        b_loaidt = form_Fs_TEN_GTRI(b_vungId, 'loaidt');
        sns_dto.Fs_NS_DT_DXUAT_LKE(b_loaidt, a_tso, a_cot, ns_dt_dxuat_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_dxuat_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}

function ns_dt_dxuat_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        //if (isNaN($get(b_lanId).value) == true) { form_P_LOI("Trường Lần đề xuất chỉ nhập số"); return false; }
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang < 1) b_hang = -1;
            var b_tinhtrang = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "trangthai")) == "" ? 0 : C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "trangthai"));
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);

            //var b_so_the = $get(b_gvienId).value;
            //var a = skhac.Fs_MA_LOI(form_Fs_nsd(), "Mã giảng viên", b_so_the, "ns_dt_gvien,so_the,ten", ns_dt_dxuat_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);

            sns_dto.Fs_NS_DT_DXUAT_NH(b_tinhtrang, b_TrangKt, a_dt_ct, a_cot_lke, ns_dt_dxuat_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}

function ns_dt_dxuat_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[1]) + 1, b_trang = CSO_SO(a_kq[2]), b_soDong = CSO_SO(a_kq[3]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[4]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus(); $get(b_ykienId).value = '';
       // sendMail(a_kq[0]);
        form_P_LOI("loi:Nhập thành công!:loi");
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
function sendMail_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); return false;
}

function ns_dt_dxuat_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma")),
        b_loaidt = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "loaidt")),
        b_lan = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "lan"));
    if (b_ma == "") ns_dt_dxuat_P_MOI();
    else sns_dto.Fs_NS_DT_DXUAT_CT(b_loaidt, b_ma, b_lan, ns_dt_dxuat_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function ns_dt_dxuat_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
function ns_dt_dxuat_P_XOA() {

    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) {
        form_P_LOI("loi:Chưa chọn đề xuất cần xóa:loi");
        return false;
    } else {
        var b_madx = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        if (b_madx == "") {
            form_P_LOI("loi:Chưa chọn đề xuất cần xóa:loi");
            return false;
        }
    }
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }
    var b_ma = $get(b_gocId).value, b_loaidt = form_Fs_TEN_GTRI(b_vungId, 'loaidt'), b_lan = $get(b_lanId).value;
    if (b_ma == "") ns_dt_dxuat_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);

        var tt = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "trangthai"));
        if (tt == "0")
            sns_dto.Fs_NS_DT_DXUAT_XOA(b_loaidt, b_ma, b_lan, a_tso, a_cot, ns_dt_dxuat_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        else form_P_LOI("loi:Đề xuất đã được phê duyệt hoặc không phê duyệt:loi");
    }
    return false;
}
function ns_dt_dxuat_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dt_dxuat_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dt_dxuat_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
    return false;
}
function ns_dt_dxuat_P_CHON() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_check = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tinhtrang"));

    if (b_check == "Không phê duyệt") { alert('Không thể chọn đề xuất Không được phê duyệt'); return; }
    else
        form_P_TRA_CHON('MA,TEN');
    return false;
}
//if (b_check == "Chờ phê duyệt") { alert('Không thể chọn đề xuất chưa được phê duyệt'); return; }

function form_dong() {
    location.reload(false);
}