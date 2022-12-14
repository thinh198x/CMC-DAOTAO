var ns_dt_tt_nghan_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_ten_cchiId, b_so_idId, b_sohieuId, b_gchuId, b_lkeCho,
    b_ngaycap, b_ngayd, b_ngayc, b_cho_control = 0, ns_dt_tt_nghan_choAct = 0, b_tenId, b_tu_ngayId, b_den_ngayId, b_ngay_hlId, b_ngay_hhlId, b_so_the_anId,
    b_loai_ccId, b_an_chungchi_khacId, b_an_chungchi_hanhngheId, b_an_chungchi_conId;
function ns_dt_tt_nghan_P_KD() {
    ns_dt_tt_nghan_lkeCho = setInterval('ns_dt_tt_nghan_P_LKE_CHO()', 200);
}


function checkanhien() {
    var b_loai_cc = form_Fs_TEN_GTRI(b_vungId, 'loai_cc');

    if (b_loai_cc == "CCHN") { // Quyết định lương
        $get(b_an_chungchi_khacId).style.display = "none";
        $get(b_an_chungchi_hanhngheId).style.display = "";
        $get(b_an_chungchi_conId).style.display = "none";
    } else if (b_loai_cc == "CCC") {
        $get(b_an_chungchi_khacId).style.display = "none";
        $get(b_an_chungchi_hanhngheId).style.display = "none";
        $get(b_an_chungchi_conId).style.display = "";
    }
    else {
        $get(b_an_chungchi_khacId).style.display = "";
        $get(b_an_chungchi_hanhngheId).style.display = "none";
        $get(b_an_chungchi_conId).style.display = "none";
    }
    return false;
}

function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_gocId).value = b_so_the;
            $get(b_so_the_anId).value = b_so_the;
            $get(b_tenId).value = b_ten;
            $get(b_ten_cchiId).focus();
            ns_dt_tt_nghan_P_LKE();
            b_doi = 1;
            clearTimeout(b_cho_control);
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
        var b_kq = a_tso[0];
        b_doi = 0;
        if (b_dtuong.indexOf("SO_THE") >= 0 || b_dtuong.indexOf("THAMSO") >= 0) {
            //$get(b_gocId).setAttribute("disabled", "disabled");
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
        }
        else if (b_dtuong.indexOf("NHOM_CNGANH") >= 0) {
            $get(b_nhomcnganhId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_cnganhId).focus();
        }
        else if (b_dtuong.indexOf("CNGANH") >= 0) {
            $get(b_cnganhId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_noidtId).focus();
        }
        else if (b_dtuong.indexOf("TEN_CCHI") >= 0) {
            $get(b_ten_cchiId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_noidungId).focus();
        }
        else if (b_dtuong.indexOf("XEPLOAI") >= 0) {
            $get(b_xeploaiId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_noidungId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_tt_nghan_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        b_mt = b_maTen;
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; form_P_MOI("", "XGL"); break;
            case "CNGANH": b_maId = b_cnganhId; break;
            case "NHOM_CNGANH": b_maId = b_nhomcnganhId; break;
            case "TEN_CCHI": b_maId = b_ten_cchiId; break;
            case "XEPLOAI": b_maId = b_xeploaiId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_dt_tt_nghan_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_dt_tt_nghan_P_LKE();
        }
        if (b_maTen == "TEN_CCHI" || b_maTen == "CNGANH" || b_maTen == "NHOM_CNGANH" || b_maTen == "XEPLOAI") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_dt_tt_nghan_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_dt_tt_nghan_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_tt_nghan_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}
function ns_dt_tt_nghan_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = "";
    $get(b_ten_cchiId).focus();
    checkanhien();
    return false;
}
function ns_dt_tt_nghan_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var ktra = sosanh_Date($get(b_tu_ngayId).value, $get(b_den_ngayId).value);
        if (ktra != "false" && ktra < 0) {
            form_P_LOI('loi:Từ ngày không được lớn hơn đến ngày:loi');
            return false;
        }
        var ktra1 = sosanh_Date($get(b_ngay_hlId).value, $get(b_ngay_hhlId).value);
        if (ktra1 != "false" && ktra1 < 0) {
            form_P_LOI('loi:Ngày hiệu lực không được lớn hơn ngày hết hiệu lực:loi');
            return false;
        }
        else {
            var b_tt = null;
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang > 0) {
                b_tt = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tthai"));
                if (b_tt == 'G') { form_P_LOI('loi:Không thể sửa bản ghi đã ở trạng thái đã gửi:loi'); return false; }
            }
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var b_so_id = $get(b_so_idId).value;
            var a_dt_cchn = GridX_Fdt_cotGtri(b_grcchnId);
            var a_dt_ccc = GridX_Fdt_cotGtri(b_grcccId);
            sns_tt.Fs_NS_DT_NGHAN_TT_NH(CSO_SO(b_so_id, 0), b_TrangKt, a_dt_ct, a_dt_cchn, a_dt_ccc, a_cot_lke, ns_dt_tt_nghan_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_dt_tt_nghan_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_so_idId).value = a_kq[4];
        form_P_LOI("loi:Ghi thành công:loi");
    }
    return false;
}
function ns_dt_tt_nghan_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang == -1) return false;
    if (b_hang < 1) return;
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"), b_tt = GridX_Fas_layGtri(b_grlkeId, b_hang, "tthai"),
        b_so_the = $get(b_gocId).value;
    if (b_so_id == "") ns_dt_tt_nghan_P_MOI();
    else {
        if (b_tt == "0") {
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            sns_tt.Fs_NS_DT_NGHAN_TT_XOA(b_so_id, b_so_the, a_tso, a_cot, ns_dt_tt_nghan_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        } else {
            form_P_LOI("loi:Không thể xóa bản ghi đã ở trạng thái đã gửi hoặc phê duyệt:loi"); return false;
        }
    }
    return false;
}
function ns_dt_tt_nghan_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dt_tt_nghan_P_MOI();
        else {
            GridX_datA(b_grlkeId, b_hang); ns_dt_tt_nghan_P_CHUYEN_HANG();
        }
        form_P_LOI("loi:Xóa thành công:loi");
        return false;
    }
}
function ns_dt_tt_nghan_GR_lke_RowChange() {
    if (ns_dt_tt_nghan_choAct != 0) clearTimeout(ns_dt_tt_nghan_choAct);
    ns_dt_tt_nghan_choAct = setTimeout("ns_dt_tt_nghan_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_dt_tt_nghan_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    var a_cot_cchn = GridX_Fas_tenCot(b_grcchnId);
    var a_cot_ccc = GridX_Fas_tenCot(b_grcccId);
    if (b_so_id == "") form_P_MOI(b_vungId, "XGL");
    else sns_tt.Fs_NS_DT_NGHAN_TT_CT(b_so_id, a_cot_cchn, a_cot_ccc, ns_dt_tt_nghan_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = b_so_id;
    // return false;
}
function ns_dt_tt_nghan_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grcchnId); else { GridX_datBang2(b_grcchnId, a_kq[1]); }
    if (a_kq[2] == "") GridX_datTrang(b_grcccId); else { GridX_datBang2(b_grcccId, a_kq[2]); }
    checkanhien();
    //return false;
}
function ns_dt_tt_nghan_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        ns_dt_tt_nghan_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct');
        b_grlkeId = form_Fs_VUNG_ID('GR_lke');
        b_grcchnId = form_Fs_VUNG_ID('GR_cchn');
        b_grcccId = form_Fs_VUNG_ID('GR_ccc');
        b_gocId = form_Fs_TEN_ID(b_vungId, 'so_the');
        b_noidungId = form_Fs_TEN_ID(b_vungId, 'noidung');
        b_tenId = form_Fs_TEN_ID(b_vungId, 'ten');
        b_ten_cchiId = form_Fs_TEN_ID(b_vungId, 'TEN_CCHI');
        b_sohieuId = form_Fs_TEN_ID(b_vungId, 'sohieu');
        b_tu_ngayId = form_Fs_TEN_ID(b_vungId, 'tu_ngay');
        b_den_ngayId = form_Fs_TEN_ID(b_vungId, 'den_ngay');
        b_ngay_hlId = form_Fs_TEN_ID(b_vungId, 'ngay_hl');
        b_ngay_hhlId = form_Fs_TEN_ID(b_vungId, 'ngay_hhl');
        b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
        b_an_chungchi_khacId = form_Fs_VUNG_ID('an_chungchi_khac'), b_an_chungchi_hanhngheId = form_Fs_VUNG_ID('an_chungchi_hanhnghe'), b_an_chungchi_conId = form_Fs_VUNG_ID('an_chungchi_con');
        b_so_the_anId = form_Fs_VTEN_ID('UPa_hi', 'so_the_an');
        b_gchuId = form_Fs_VTEN_ID('', 'gchu');
        if (ns_dt_tt_nghan_lkeCho != 0) clearTimeout(ns_dt_tt_nghan_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        slide_P_MOI(b_slideId);
        ns_dt_tt_nghan_P_LKE();
        checkanhien();
    }
}
function ns_dt_tt_nghan_P_LKE() {
    try {
        var b_so_the = $get(b_gocId).value;
        if (b_so_the == null || b_so_the == "") { return false }
        else {
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            sns_tt.Fs_NS_DT_NGHAN_TT_LKE(b_so_the, a_tso, a_cot, ns_dt_tt_nghan_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_tt_nghan_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_dt_tt_nghan_FI_NH() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1 || C_NVL(GridX_Fas_layGtriA(b_grlkeId, "so_id")) == "") {
            form_P_LOI('loi:Chọn chứng chỉ:loi')
            return false;
        }
        var b_tenf = '/App_form/ns/hs/file_hs.aspx';
        form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "ns_dt_tt_nghan_IMP" + C_NVL(GridX_Fas_layGtriA(b_grlkeId, "so_id")), "ns_dt_tt_nghan_IMP" + C_NVL(GridX_Fas_layGtriA(b_grlkeId, "so_id")), "Lưu file chứng chỉ"]], null);
        form_P_LOI('');
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}

function ns_dt_tt_nghan_P_GUI() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"),
        b_so_the = $get(b_gocId).value;
    if (b_so_id == "") ns_dt_tt_nghan_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_tt.Fs_NS_DT_NGHAN_TT_GUI(b_so_id, b_so_the, a_tso, a_cot, ns_dt_tt_nghan_P_GUI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_dt_tt_nghan_P_GUI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        ns_dt_tt_nghan_P_CHUYEN_HANG();
        form_P_LOI("loi:gửi phê duyệt thành công:loi");
        return false;
    }
}
function sosanh_Date(str1, str2) {
    var kq;
    if (str1 == "" || str2 == "")
        kq = false;
    else {
        var mdy_str1 = str1.split('/');
        var mdy_str1 = mdy_str1[2] + mdy_str1[1] + mdy_str1[0];
        var mdy_str1 = parseInt(mdy_str1);
        var mdy_str2 = str2.split('/');
        var mdy_str2 = mdy_str2[2] + mdy_str2[1] + mdy_str2[0];
        var mdy_str2 = parseInt(mdy_str2);
        kq = mdy_str2 - mdy_str1;
    }
    return kq;
}
