var ns_bhxh_chedo_lkeCho, b_vungId, b_vung_tkId, b_grlkeId, b_gocId, b_mt, b_gchuId, b_luongcs, b_luyke = 0,
    b_grctId, b_ngaydId, b_ngaycId, b_ngaynhapId, b_gocId, b_tenId, b_mabvId, b_lydoId, b_tenbvId, b_luongbhxhId, b_luykeId, b_trongkyId, b_tiennhanId,
    b_so_idId, b_slideId, b_nghingoiId, b_tainhaId, b_taptrungId, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C', b_so_the_tkId, b_hoten_tkId;
function ns_bhxh_chedo_P_KD() {
    ns_bhxh_chedo_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vung_tkId = form_Fs_VUNG_ID('UPa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct');
    b_so_the_tkId = form_Fs_TEN_ID(b_vung_tkId, 'SO_THE_TK'), b_hoten_tkId = form_Fs_TEN_ID(b_vung_tkId, 'ten_tk');
    b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE'); b_tenId = form_Fs_TEN_ID(b_vungId, 'HO_TEN'); b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_so_idId = form_Fs_VTEN_ID('UPa_hidden', 'so_id'); b_slideId = b_grlkeId + '_slide';
    ns_bhxh_chedo_lkeCho = setInterval('ns_bhxh_chedo_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            $get(b_gocId).value = b_kq;
            ns_bhxh_chedo_P_CHEDO_CB();
        }
    }
    catch (err) { form_P_LOI(err); }
}

function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}

function ns_bhxh_chedo_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; break;
        }
        b_mt = b_maTen;
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "SO_THE") {
            ns_bhxh_chedo_P_CHEDO_CB();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_bhxh_chedo_P_MA_KTRA() {
    try {
        var b_ngay = C_NVL($get(b_ngayId).value);
        if (b_ngay != "") {
            var b_ngayd = $get(b_ngaydId).value, b_ngayc = $get(b_ngaycId).value,
                b_so_the = $get(b_gocId).value, b_masp = $get(b_maspId).value;
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_cd.Fs_NS_BHXH_CHEDO_MA(b_so_the, b_masp, b_ngayd, b_ngayc, b_ngay, b_TrangKt, a_cot, ns_bhxh_chedo_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_bhxh_chedo_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        form_P_MOI(b_vungId, "X");
        $get(b_tienId).focus();
        $get(b_so_idId).value = "0";
    }
    else { GridX_datA(b_grlkeId, b_hang); ns_bhxh_chedo_P_CHUYEN_HANG(); }
}

function ns_bhxh_chedo_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); $get(b_gocId).value = ""; return false; }
    if (b_mt == "MABV") {
        $get(b_gchuId).innerHTML = b_kq;
    }
    else if (b_mt == "SO_THE") {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
        $get(b_tenId).value = b_kq;
    }
}

var ns_bhxh_chedo_choAct = 0;
function ns_bhxh_chedo_GR_lke_RowChange() {
    if (ns_bhxh_chedo_choAct != 0) clearTimeout(ns_bhxh_chedo_choAct);
    ns_bhxh_chedo_choAct = setTimeout("ns_bhxh_chedo_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_bhxh_chedo_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (ns_bhxh_chedo_lkeCho != 0) clearTimeout(ns_bhxh_chedo_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_bhxh_chedo_P_LKE('K');
    }
}

function ns_bhxh_chedo_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = "0";
    return false;
}
function ns_bhxh_chedo_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var b_so_the = $get(b_so_the_tkId).value, b_ho_ten = $get(b_hoten_tkId).value,
            a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_cd.Fs_NS_BHXH_CHEDO_LKE(b_so_the, b_ho_ten, a_tso, a_cot, ns_bhxh_chedo_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_bhxh_chedo_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    b_fcho = 'X';
    ns_bhxh_chedo_P_TIENCOSO();
    return false;
}

function ns_bhxh_chedo_P_CHEDO_CB() {
    var b_so_the = $get(b_gocId).value;
    sns_cd.Fs_NS_BHXH_CHEDO_CB(b_so_the, ns_bhxh_chedo_P_CHEDO_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}

function ns_bhxh_chedo_P_CHEDO_CB_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return;
}

function ns_bhxh_chedo_P_TIENCOSO() {
    try {
        sns_cd.Fs_NS_TL_LUONGNN_TIEN(ns_bhxh_chedo_P_TIENCOSO_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_bhxh_chedo_P_TIENCOSO_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    b_luongcs = b_kq;
}

function ns_bhxh_chedo_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_so_id = $get(b_so_idId).value, b_dt = form_Faa_TEXT_ROW(b_vungId),
                b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
            sns_cd.Fs_NS_BHXH_CHEDO_NH(b_so_id, b_TrangKt, b_dt, a_cot_lke, ns_bhxh_chedo_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_bhxh_chedo_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        ns_bhxh_chedo_P_LKE();
        $get(b_gocId).focus();
        form_P_LOI('loi:Nhập thành công:loi');
    }
    return false;
}


function ns_bhxh_chedo_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == null || b_so_id == "") { form_P_MOI("", "XGL"); }
    else {
        sns_cd.Fs_NS_BHXH_CHEDO_CT(b_so_id, ns_bhxh_chedo_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function ns_bhxh_chedo_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    $get(b_so_idId).value = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    return;
}
function ns_bhxh_chedo_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }

    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") ns_bhxh_chedo_P_MOI();
    else {
        var b_so_the = $get(b_so_the_tkId).value, b_hoten_tk = $get(b_hoten_tkId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_cd.Fs_NS_BHXH_CHEDO_XOA(b_so_id, b_so_the, b_hoten_tk, a_tso, a_cot, ns_bhxh_chedo_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_bhxh_chedo_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_bhxh_chedo_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_bhxh_chedo_P_CHUYEN_HANG(); }
        form_P_LOI('loi:Xóa thành công:loi');
    }
    return;
}



function form_dong() {
    location.reload(false);
}