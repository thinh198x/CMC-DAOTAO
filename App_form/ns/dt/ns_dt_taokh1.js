var ns_dt_taokh_lkeCho, b_vungId, b_grlkeId, b_slideId, b_grctId,b_gchuId, b_moiId;
function ns_dt_taokh_P_KD() {
    ns_dt_taokh_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_nhomcnId = form_Fs_TEN_ID(b_vungId, 'nhomcn'), b_chuyennganhId = form_Fs_TEN_ID(b_vungId, 'CHUYENNGANH'), b_noidtId = form_Fs_TEN_ID(b_vungId, 'noidt'),
    b_ngaytrinhId = form_Fs_TEN_ID(b_vungId, 'ngaytrinh'), b_tenId = form_Fs_TEN_ID(b_vungId, 'ten'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'), b_noteId = form_Fs_TEN_ID(b_vungId, 'note'),
    b_ngaydId = form_Fs_TEN_ID(b_vungId, 'NGAYD'), b_soluongId = form_Fs_TEN_ID(b_vungId, 'soluong'),
    b_ngaycId = form_Fs_TEN_ID(b_vungId, 'NGAYC'), b_cap_dtId = form_Fs_TEN_ID(b_vungId, 'cap_dt'), b_hinhthucId = form_Fs_TEN_ID(b_vungId, 'hinhthuc'),
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_moiId = form_Fs_VTEN_ID('', 'moi');
    b_slideId = b_grlkeId + '_slide';
    ns_dt_taokh_lkeCho = setInterval('ns_dt_taokh_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("NHOMCN") >= 0) {
            $get(b_nhomcnId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_chuyennganhId).focus();
        }
        else if (b_dtuong.indexOf("CHUYENNGANH") >= 0) {
            $get(b_chuyennganhId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
        }
        else if (b_dtuong.indexOf("CAP_DT") >= 0) {
            $get(b_cap_dtId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_hinhthucId).focus();
        }
        else if (b_dtuong.indexOf("HINHTHUC") >= 0) {
            $get(b_hinhthucId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_noteId).focus();
        }
        else if (b_dtuong.indexOf("KQ") >= 0) {
            $get(b_gocId).value = a_tso[0];
            var b_tso = a_tso[0];
            ns_dt_taokh_P_LKE();
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_tso);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_dt_taokh_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_dt_taokh_P_CHUYEN_HANG(); }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_taokh_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; form_P_MOI("", "XGL"); break;
            case "NHOMCN": b_maId = b_nhomcnId; break;
            case "CHUYENNGANH": b_maId = b_chuyennganhId; break;
            case "CAP_DT": b_maId = b_cap_dtId; break;
            case "HINHTHUC": b_maId = b_hinhthucId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_dt_taokh_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_dt_taokh_P_CHUYEN_HANG(); }
        }
        else skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_dt_taokh_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function ns_dt_taokh_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_dt.Fs_NS_DT_TAOKH_MA(b_ma, b_TrangKt, a_cot, ns_dt_taokh_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_taokh_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_dt_taokh_P_CHUYEN_HANG(); }
}
function ns_dt_taokh_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}
function ns_dt_taokh_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}

var ns_dt_taokh_choAct = 0;
function ns_dt_taokh_GR_lke_RowChange() {
    if (ns_dt_taokh_choAct != 0) clearTimeout(ns_dt_taokh_choAct);
    ns_dt_taokh_choAct = setTimeout("ns_dt_taokh_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_dt_taokh_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_dt_taokh_lkeCho); ns_dt_taokh_P_LKE(); }
}

function ns_dt_taokh_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_gocId).focus();
    return false;
}
// lke
function ns_dt_taokh_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.Fs_NS_DT_TAOKH_LKE(a_tso, a_cot, ns_dt_taokh_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function ns_dt_taokh_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
//Nhap

function ns_dt_taokh_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_dt = form_Faa_TEXT_ROW(b_vungId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var b_ma = $get(b_gocId).value;
            sns_dt.Fs_NS_DT_TAOKH_NH(b_ma, b_TrangKt, b_dt, a_cot_lke, ns_dt_taokh_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}

function ns_dt_taokh_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
    }
    return false;
}
function ns_dt_taokh_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    if (b_ma == "") form_P_MOI(b_vungId, "XGL");
    else sns_dt.Fs_NS_DT_TAOKH_CT(b_ma, ns_dt_taokh_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function ns_dt_taokh_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
}
function ns_dt_taokh_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }

    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    if (b_ma == "") ns_dt_taokh_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.Fs_NS_DT_TAOKH_XOA(b_ma, a_tso, a_cot, ns_dt_taokh_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_dt_taokh_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dt_taokh_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dt_taokh_P_CHUYEN_HANG(); }
    }
}

function ns_dt_taokh_P_DANGKY() {
    var b_ma = $get(b_gocId).value;
    sns_dt.Fs_NS_DT_DANGKYKH_NH(b_ma, ns_dt_taokh_P_DANGKY_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_dt_taokh_P_DANGKY_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else { alert("Đã đăng ký thành công!"); }
    ns_dt_taokh_P_MA_KTRA();
}
function ns_dt_taokh_P_HUYDANGKY() {
    var b_ma = $get(b_gocId).value;
    sns_dt.Fs_NS_DT_DANGKYKH_XOA(b_ma, ns_dt_taokh_P_HUYDANGKY_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_dt_taokh_P_HUYDANGKY_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else { alert("Hủy đăng ký thành công!"); }
    ns_dt_taokh_P_MA_KTRA();
}
function ns_dt_taokh_P_DONG() {
    var b_ma = $get(b_gocId).value;
    sns_dt.Fs_NS_DT_TAOKH_DONG(b_ma, ns_dt_taokh_P_DONG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_dt_taokh_P_DONG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else { alert("Đóng đăng ký thành công!"); }
    ns_dt_taokh_P_MA_KTRA();
}

function ns_dt_taokh_P_TOCHUC() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_check = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tinhtrang"));
    if (b_check != "Đủ học viên/Đóng ĐK") { alert('Phải đóng đăng ký trước khi tổ chức'); return; }
    else {
        var b_ma = $get(b_gocId).value;
        sns_dt.Fs_NS_DT_DANGKYKH_TOCHUC(b_ma, ns_dt_taokh_P_TOCHUC_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
}
function ns_dt_taokh_P_TOCHUC_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else { alert("Tổ chức khóa học thành công!"); }
    ns_dt_taokh_P_MA_KTRA();
}
function form_dong() {
    location.reload(false);
}