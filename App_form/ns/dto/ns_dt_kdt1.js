
var ns_dt_kdt_lkeCho, b_vungId, b_grlkeId, b_slideId, b_grnhucauId, b_grcdanhId, b_grctId, b_gchuId, b_ma_dtId, b_loaiDtId, b_so_idId, b_moiId, b_ldt_Id,
     b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C';
function ns_dt_kdt_P_KD() {
    ns_dt_kdt_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_nv'),
    b_grcdanhId = form_Fs_VUNG_ID('GR_cdanh'), b_grnhucauId = form_Fs_VUNG_ID('GR_nhucau'),
    b_chuyennganhId = form_Fs_TEN_ID(b_vungId, 'CHUYENNGANH'), b_noidtId = form_Fs_TEN_ID(b_vungId, 'noidt'),
    b_ngaytrinhId = form_Fs_TEN_ID(b_vungId, 'ngaytrinh'), b_tenId = form_Fs_TEN_ID(b_vungId, 'ten'), b_tyleId = form_Fs_TEN_ID(b_vungId, 'tyle'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'), b_ykienId = form_Fs_TEN_ID(b_vungId, 'ykien'), b_nhomcnId = form_Fs_TEN_ID(b_vungId, 'nhomcn'),
    b_quocgiaId = form_Fs_TEN_ID(b_vungId, 'quocgia'), b_ngaydId = form_Fs_TEN_ID(b_vungId, 'NGAYD'),
    b_ma_dtId = form_Fs_TEN_ID(b_vungId, 'ma_nhucau'), b_loaiDtId = form_Fs_TEN_ID(b_vungId, 'LOAIDT'),
    b_ngaycId = form_Fs_TEN_ID(b_vungId, 'NGAYC'), b_cap_dtId = form_Fs_TEN_ID(b_vungId, 'cap_dt'), b_hinhthucId = form_Fs_TEN_ID(b_vungId, 'hinhthuc'),
    b_kinhphiId = form_Fs_TEN_ID(b_vungId, 'kinhphi'), b_giatriId = form_Fs_TEN_ID(b_vungId, 'giatri'), b_ma_nteId = form_Fs_TEN_ID(b_vungId, 'ma_nte');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'); b_gchuId = form_Fs_VTEN_ID('', 'gchu'); b_moiId = form_Fs_VTEN_ID('', 'moi');
    b_slideId = b_grlkeId + '_slide'; b_ldt_Id = form_Fs_TEN_ID(b_vungId, 'hincd'),
    ns_dt_kdt_lkeCho = setInterval('ns_dt_kdt_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("MA_NHUCAU") >= 0) {
            $get(b_ma_dtId).value = a_tso[0];
            $get(b_gchuId).innerHTML = a_tso[1];
            ns_dt_kdt_P_NV_CDANH();
        } else if (b_dtuong.indexOf("MA") >= 0) {
            $get(b_gocId).value = b_kq;
            $get(b_tenId).value = a_tso[1];
            ns_dt_kdt_P_MA_KTRA();
            $get(b_tyleId).focus();
        }
        else if (b_dtuong.indexOf("NHOMCN") >= 0) {
            $get(b_nhomcnId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_chuyennganhId).focus();
        }
        else if (b_dtuong.indexOf("CHUYENNGANH") >= 0) {
            $get(b_chuyennganhId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_noidtId).focus();
        }
        else if (b_dtuong.indexOf("QUOCGIA") >= 0) {
            $get(b_quocgiaId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_ngaydId).focus();
        }
        else if (b_dtuong.indexOf("CAP_DT") >= 0) {
            $get(b_cap_dtId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_hinhthucId).focus();
        }
        else if (b_dtuong.indexOf("HINHTHUC") >= 0) {
            $get(b_hinhthucId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_kinhphiId).focus();
        }
        else if (b_dtuong.indexOf("KINHPHI") >= 0) {
            $get(b_kinhphiId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_giatriId).focus();
        }
        else if (b_dtuong.indexOf("SO_THE") >= 0 && b_dtuong.indexOf("GR_NV_CT") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return; ns_thongtin_canbo(a_tso[0]);
        } else if (b_dtuong.indexOf("SO_THE") >= 0 && b_dtuong.indexOf("GR_CDANH_CT") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grcdanhId);
            if (b_hang < 0) return; ns_thongtin_canbo_cdanh(a_tso[0]);
        } else if (b_dtuong.indexOf("SO_THE") >= 0 && b_dtuong.indexOf("GR_NHUCAU_CT") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grnhucauId);
            if (b_hang < 0) return; ns_thongtin_canbo_nhucau(a_tso[0]);
        }
        else if (b_dtuong.indexOf("MA_NTE") >= 0) {
            $get(b_ma_nteId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_ma_nteId).focus();
        }
        else if (b_dtuong.indexOf("KQ") >= 0) {
            $get(b_gocId).value = a_tso[0];
            ns_dt_kdt_P_LKE();
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", a_tso[0]);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_dt_kdt_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_dt_kdt_P_CHUYEN_HANG(); }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}
function ns_dt_kdt_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; form_P_MOI("", "XGL"); break;
            case "NHOMCN": b_maId = b_nhomcnId; break;
            case "CHUYENNGANH": b_maId = b_chuyennganhId; break;
            case "QUOCGIA": b_maId = b_quocgiaId; break;
            case "CAP_DT": b_maId = b_cap_dtId; break;
            case "HINHTHUC": b_maId = b_hinhthucId; break;
            case "GIATRI": b_maId = b_giatriId; break;
            case "MA_NTE": b_maId = b_ma_nteId; break;
            case "KINHPHI": b_maId = b_kinhphiId; break;
            case "MA_NHUCAU": b_maId = b_ma_dtId; break;
            case "LDT": b_maId = b_ma_dtId; break;
        }
        if (b_maTen == "LDT") {
            var b_ma = $get(b_maId);
            $get(b_ldt_Id).value = $get(b_loaiDtId).value;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_dt_kdt_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_dt_kdt_P_CHUYEN_HANG(); }
        } else if (b_maTen == "MA_NHUCAU") {
            ns_dt_kdt_P_NV_CDANH();
        }
        else if (b_maTen == "GIATRI") {
            var b_hang = GridX_Fi_timHangT(b_grctId);
            if (b_hang < 0) {
                GridX_ThemHang(b_grctId);
                b_hang = GridX_Fi_timHangT(b_grctId);
            }
            GridX_datA(b_grctId, b_hang, "tt");
        }

        else skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_dt_kdt_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_kdt_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_dto.Fs_NS_DT_KDT_MA(b_ma, b_TrangKt, a_cot, ns_dt_kdt_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_kdt_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    if (b_hang <= 0) { ns_dt_kdt_P_NV_MOI(); }
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_dt_kdt_P_CHUYEN_HANG(); }
}
function ns_dt_kdt_P_NV_MOI() {
    try {
        var b_ma = C_NVL($get(b_gocId).value), b_ma_dt = C_NVL($get(b_ma_dtId).value), b_loaidt = C_NVL($get(b_loaiDtId).value);
        if (b_ma != "") {
            var a_cot_nv = GridX_Fas_tenCot(b_grctId), a_cot_cdanh = GridX_Fas_tenCot(b_grcdanhId), a_cot_nhucau = GridX_Fas_tenCot(b_grnhucauId);
            sns_dto.Fs_NS_DT_KDT_CT2(b_ma, b_ma_dt, b_loaidt, a_cot_nv, a_cot_cdanh, a_cot_nhucau, ns_dt_kdt_P_NV_MOI_QK, P_LOI_CSDL, P_LOI_TGIAN);
        }
    } catch (err) { form_P_LOI(err); }
}
function ns_dt_kdt_P_NV_MOI_QK(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    if (a_kq[0] == "") GridX_datTrang(b_grctId);
    else GridX_datBang(b_grctId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grcdanhId);
    else GridX_datBang(b_grcdanhId, a_kq[1]);
    if (a_kq[2] == "") GridX_datTrang(b_grnhucauId);
    else GridX_datBang(b_grnhucauId, a_kq[2]);
}
function ns_dt_kdt_P_NV_CDANH() {
    try {
        var b_ma = C_NVL($get(b_gocId).value), b_ma_dt = C_NVL($get(b_ma_dtId).value), b_loaidt = C_NVL($get(b_loaiDtId).value);
        if (b_ma_dt != "") {
            var a_cot_nv = GridX_Fas_tenCot(b_grctId), a_cot_cdanh = GridX_Fas_tenCot(b_grcdanhId), a_cot_nhucau = GridX_Fas_tenCot(b_grnhucauId);
            sns_dto.Fs_NS_DT_KDT_CDANH(b_ma, b_ma_dt, b_loaidt, a_cot_nv, a_cot_cdanh, a_cot_nhucau, ns_dt_kdt_P_NV_CDANH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    } catch (err) { form_P_LOI(err); }
}
function ns_dt_kdt_P_NV_CDANH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    if (a_kq[0] == "") GridX_datTrang(b_grcdanhId);
    else GridX_datBang(b_grcdanhId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grnhucauId);
    else GridX_datBang(b_grnhucauId, a_kq[1]);
}

function ns_thongtin_canbo(b_so_the) {
    try {
        hts_dungchung.Fs_THONGTIN_CANBO_LUOI(b_so_the, ns_thongtin_canbo_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_thongtin_canbo_kq(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = GridX_Fi_timHangA(b_grctId) -1;
    GridX_datGtri(b_grctId, b_hang, "SO_THE", a_kq[1]);
    GridX_datGtri(b_grctId, b_hang, "TEN", a_kq[2]);
    GridX_datGtri(b_grctId, b_hang, "TEN_PHONG", a_kq[4]);
    GridX_datGtri(b_grctId, b_hang, "PHONG", a_kq[4]);
    return false;
}

function ns_thongtin_canbo_cdanh(b_so_the) {
    try {
        hts_dungchung.Fs_THONGTIN_CANBO_LUOI(b_so_the, ns_thongtin_canbo_cdanh_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_thongtin_canbo_cdanh_kq(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = GridX_Fi_timHangA(b_grcdanhId) -1;
    GridX_datGtri(b_grcdanhId, b_hang, "SO_THE", a_kq[1]);
    GridX_datGtri(b_grcdanhId, b_hang, "TEN", a_kq[2]);
    GridX_datGtri(b_grcdanhId, b_hang, "TEN_PHONG", a_kq[4]);
    GridX_datGtri(b_grcdanhId, b_hang, "PHONG", a_kq[4]);
    return false;
}

function ns_thongtin_canbo_nhucau(b_so_the) {
    try {
        hts_dungchung.Fs_THONGTIN_CANBO_LUOI(b_so_the, ns_thongtin_canbo_nhucau_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_thongtin_canbo_nhucau_kq(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = GridX_Fi_timHangA(b_grnhucauId)-1;
    GridX_datGtri(b_grnhucauId, b_hang, "SO_THE", a_kq[1]);
    GridX_datGtri(b_grnhucauId, b_hang, "TEN", a_kq[2]);
    GridX_datGtri(b_grnhucauId, b_hang, "TEN_PHONG", a_kq[4]);
    GridX_datGtri(b_grnhucauId, b_hang, "PHONG", a_kq[4]);
    return false;
}

function ns_dt_kdt_P_CHO_DK() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("loi:Bạn chưa chọn khóa học:loi"); return false; }
    var b_loaidt = $get(b_loaiDtId).value;
    if (b_loaidt == "HN" || b_loaidt == "BN") { form_P_LOI("loi:Bạn chọn sai loại đào tạo:loi"); return false; }
    var b_tinhtrang = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tt"));
    var b_ma = $get(b_gocId).value;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"))
    sns_dto.Fs_NS_DT_KDT_CHO_DK(b_ma, b_tinhtrang, ns_dt_kdt_P_CHO_DK_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_dt_kdt_P_CHO_DK_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    else { ns_dt_kdt_P_LKE(); form_P_LOI("loi:Cho đăng ký thành công:loi"); return false; }
    
}
function ns_dt_kdt_P_KHOA_DK() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("loi:Bạn chưa chọn khóa học:loi"); return false; }
    //var b_loaidt = $get(b_loaiDtId).value;
    //if (b_loaidt == "HN" || b_loaidt == "BN") { form_P_LOI("loi:Bạn chọn sai loại đào tạo:loi"); return false; }
    var b_tinhtrang = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tt"));
    var b_ma = $get(b_gocId).value;
    sns_dto.Fs_NS_DT_KDT_KHOA_DK(b_ma, b_tinhtrang, ns_dt_kdt_P_KHOA_DK_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_dt_kdt_P_KHOA_DK_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    else { ns_dt_kdt_P_LKE(); form_P_LOI("loi:Khóa đăng ký thành công:loi"); return false; }
    
}
function ns_dt_kdt_P_TRINH_PD() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("loi:Bạn chưa chọn khóa học:loi"); return false; }
    var b_tinhtrang = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tt"));

    var b_ma = $get(b_gocId).value;
    sns_dto.Fs_NS_DT_KDT_TRINH_PD(b_ma, b_tinhtrang, ns_dt_kdt_P_TRINH_PD_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_dt_kdt_P_TRINH_PD_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    else { form_P_LOI("loi:Trình phê duyệt thành công:loi"); return false; }
    ns_dt_kdt_P_LKE();
}
function ns_dt_kdt_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}
function ns_dt_kdt_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grctId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        if (b_value != "") {
            if (b_cot == "SO_THE") {
                //sns_tt.Fs_NS_CB_HOI(b_value, ns_dt_kdt_P_CB_HOI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Mã nhân viên", b_value, "ns_cb,so_the,ten", ns_dt_kdt_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
                b_ctr.value = ""
            }
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_kdt_P_CB_HOI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var b_hang = GridX_Fi_timHangA(b_grctId);
    var a_kq = Fas_ChMang(b_kq, '#');
    GridX_datGtri(b_grctId, b_hang, ["so_the"], [a_kq[0]], 'K');
    GridX_datGtri(b_grctId, b_hang, ["phong"], [a_kq[1]], 'K');
    GridX_datGtri(b_grctId, b_hang, ["ten"], [a_kq[2]], 'K');
    GridX_ThemHang(b_grctId);
}
var ns_dt_kdt_choAct = 0;
function ns_dt_kdt_GR_lke_RowChange() {
    if (ns_dt_kdt_choAct != 0) clearTimeout(ns_dt_kdt_choAct);
    ns_dt_kdt_choAct = setTimeout("ns_dt_kdt_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_dt_kdt_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (ns_dt_kdt_lkeCho != 0) clearTimeout(ns_dt_kdt_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_dt_kdt_P_LKE('K');
    }
}
function ns_dt_kdt_P_MOI() {
    form_P_MOI(b_vungId, "KGXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    GridX_datTrang(b_grcdanhId);
    GridX_datTrang(b_grnhucauId);
    $get(b_so_idId).value = "0";
    $get(b_gocId).focus();
    return false;
}
function ns_dt_kdt_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dto.Fs_NS_DT_KDT_LKE(a_tso, a_cot, ns_dt_kdt_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_kdt_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}
function ktra_ngay(tungay, denngay, loai, ten1, ten2) {
    if (denngay == "" || denngay == null) { return ""; }
    if (loai == 1 && tungay > denngay) { return "loi: " + ten1 + " không được lớn hơn " + ten2 + " :loi"; }
    else if (loai == 2 && tungay >= denngay) { return "loi: " + ten1 + " không được lớn hơn hoặc bằng " + ten2 + " :loi"; }
    return "";
}
function parseDate(str) {
    var mdy = str.split('/');
    return new Date(mdy[2], mdy[1], mdy[0]);
}
function ns_dt_kdt_P_NH() {
    try {
        var ktra = ktra_ngay(parseDate($get(b_ngaydId).value).getTime(), parseDate($get(b_ngaycId).value).getTime(), 1, "Từ ngày", "Đến ngày");
        if (ktra.length > 0) {
            ns_dt_kdt_P_NH_KQ(ktra);
            return false;
        }
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_dt = form_Faa_TEXT_ROW(b_vungId), b_dt_ct = GridX_Fdt_cotGtri(b_grctId), b_dt_ct_cdanh = GridX_Fdt_cotGtri(b_grcdanhId), b_dt_ct_nc = GridX_Fdt_cotGtri(b_grnhucauId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var b_hang = GridX_Fi_timHangA(b_grlkeId), b_so_id = 0;
            if (b_hang > 0) b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
            sns_dto.Fs_NS_DT_KDT_NH(b_TrangKt, b_so_id, b_dt, b_dt_ct, b_dt_ct_cdanh, b_dt_ct_nc, a_cot_lke, ns_dt_kdt_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}

function ns_dt_kdt_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus(); $get(b_ykienId).value = '';
        form_P_LOI("loi:Nhập thành công!:loi");
    }
    return false;
}
function ns_dt_kdt_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")),
        a_cot = GridX_Fas_tenCot(b_grctId);
    if (b_so_id == "") ns_dt_kdt_P_MOI();
    else sns_dto.Fs_NS_DT_KDT_CT(b_so_id, a_cot, ns_dt_kdt_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    GridX_datA(b_grlkeId, b_hang);
    $get(b_so_idId).value = b_so_id;
}
function ns_dt_kdt_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId);
    else GridX_datBang(b_grctId, a_kq[1]);
    if (a_kq[2] == "") GridX_datTrang(b_grcdanhId);
    else GridX_datBang(b_grcdanhId, a_kq[2]);
    if (a_kq[3] == "") GridX_datTrang(b_grnhucauId);
    else GridX_datBang(b_grnhucauId, a_kq[3]);
}
function ns_dt_kdt_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") ns_dt_kdt_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dto.Fs_NS_DT_KDT_XOA(b_so_id, a_tso, a_cot, ns_dt_kdt_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_dt_kdt_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dt_kdt_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dt_kdt_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
}
function ns_dt_kdt_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_dt_kdt_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_dt_kdt_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function ns_dt_kdt_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}
function ns_dt_kdt_P_CHON() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_check = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tt"));
    if (b_check != "1") { alert('Không thể chọn khóa đào tạo Chờ phê duyệt'); return; }
    else
        form_P_TRA_CHON('MA,TEN');
}
//nv mới
function ns_dt_kdt_nvm_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_dt_kdt_nvm_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_dt_kdt_nvm_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function ns_dt_kdt_nvm_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}
// nv theo chức danh
function ns_dt_kdt_cdanh_HangLen() {
    GridX_chuyenHang(b_grcdanhId, -1);
    return false;
}
function ns_dt_kdt_cdanh_HangXuong() {
    GridX_chuyenHang(b_grcdanhId, 1);
    return false;
}
function ns_dt_kdt_cdanh_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grcdanhId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grcdanhId);
    return false;
}
function ns_dt_kdt_cdanh_CatDong() {
    GridX_boChon(b_grcdanhId, 'C');
    return false;
}
// nv theo nhu cầu
function ns_dt_kdt_ncau_HangLen() {
    GridX_chuyenHang(b_grnhucauId, -1);
    return false;
}
function ns_dt_kdt_ncau_HangXuong() {
    GridX_chuyenHang(b_grnhucauId, 1);
    return false;
}
function ns_dt_kdt_ncau_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grnhucauId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grnhucauId);
    return false;
}
function ns_dt_kdt_ncau_CatDong() {
    GridX_boChon(b_grnhucauId, 'C');
    return false;
}
function form_dong() {
    location.reload(false);
}