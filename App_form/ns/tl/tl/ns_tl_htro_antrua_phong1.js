
var ns_tl_htro_antrua_phong_lkeCho, b_vungId, b_grlkeId, b_slideId, b_grctId, b_grDviId, b_ngaydId, b_ngaycId, b_gchuId, b_chon2Id, b_so_idId, b_so_theId, b_moiId,
    theodv, theonv, b_sotienId, b_tenphongId, b_phongId, b_phongId, b_img, b_chonId, b_an_grnvId, b_an_grDviId;
var ns_tl_htro_antrua_phong_choAct = 0, b_hangId, b_sodong_grDvi = 0;
function ns_tl_htro_antrua_phong_P_KD() {
    ns_tl_htro_antrua_phong_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct');
    b_grDviId = form_Fs_VUNG_ID('GR_Dvi'), b_tenphongId = form_Fs_VTEN_ID('UPa_hi', 'ten_phong'), b_phongId = form_Fs_TEN_ID(b_vungId, 'phong_tk');
    b_sotienId = form_Fs_TEN_ID(b_vungId, 'sotien'), b_ngaydId = form_Fs_TEN_ID(b_vungId, 'NG_HLUC'), b_ngaycId = form_Fs_TEN_ID(b_vungId, 'NG_HET_HLUC');
    theodv = form_Fs_TEN_ID(b_vungId, 'theo_dvi');
    theonv = form_Fs_TEN_ID(b_vungId, 'theo_nv');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_moiId = form_Fs_VTEN_ID('', 'moi');
    b_an_grnvId = form_Fs_VUNG_ID('an_grNv'), b_an_grDviId = form_Fs_VUNG_ID('an_grDvi'), b_slideId = b_grlkeId + '_slide';
    //b_so_theId = form_Fs_TEN_ID(b_vungId, 'SO_THE');
    ns_tl_htro_antrua_phong_lkeCho = setInterval('ns_tl_htro_antrua_phong_P_LKE_CHO()', 200);
    // ẩn control Phòng đi.
    $get(b_phongId).style.display = "none";
    $get(b_an_grDviId).style.display = "none";
    ////$get("ctl00_ContentPlaceHolder1_Label14").style.display = "none";
    $get("ctl00_ContentPlaceHolder1_img").style.display = "none";
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            if (a_tso[0] == "CMC-2M") {
                for (var i = 1; i < a_tso.length; i++) {
                    GridX_datGtri(b_grctId, b_hang, ["so_the"], [a_tso[i][0]], 'K');
                    GridX_datGtri(b_grctId, b_hang, ["ten"], [a_tso[i][1]], 'K');
                    GridX_datGtri(b_grctId, b_hang, ["phong"], [a_tso[i][2]], 'K');
                    GridX_datGtri(b_grctId, b_hang, ["ten_phong"], [a_tso[i][3]], 'K');
                    b_hang = b_hang + 1;
                }
                slide_P_SOTRANG(b_slideIdcn, CSO_SO(b_hang, 0));
            } else {
                GridX_datGtri(b_grctId, b_hang, ["so_the"], [a_tso[0]], 'K');
                GridX_datGtri(b_grctId, b_hang, ["ten"], [a_tso[1]], 'K');
                GridX_datGtri(b_grctId, b_hang, ["phong"], [a_tso[2]], 'K');
                GridX_datGtri(b_grctId, b_hang, ["ten_phong"], [a_tso[3]], 'K');
            }
            GridX_datA(b_grctId, b_hang + 1, "so_thenv");
        }
        else if (b_dtuong.indexOf("KQ") >= 0) {
            $get(b_gocId).value = a_tso[0];
            ns_tl_htro_antrua_phong_P_LKE('K');
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", a_tso[0]);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_tl_htro_antrua_phong_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_tl_htro_antrua_phong_P_CHUYEN_HANG(); }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cb_phong(check) {
    try {
        b_check = check;
        var b_tenf = form_Fs_TM() + '/App_form/ht/ht_maph.aspx';
        form_P_MO(b_tenf, null, ["ns_tl_htro_antrua_phong", [""]]);
        return false;
    }
    catch (err) { }
}
function ns_tl_htro_antrua_phong_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; form_P_MOI("", "XGL"); break;
            case "NHOMCN": b_maId = b_nhomcnId; break;
            case "MA_NTE": b_maId = b_ma_nteId; break;
            case "KINHPHI": b_maId = b_kinhphiId; break;
            case "PHONG_TK": b_maId = b_phongId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_tl_htro_antrua_phong_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_tl_htro_antrua_phong_P_CHUYEN_HANG(); }
        } else if (b_maTen == "PHONG_TK") {
            $get(b_tenphongId).value = lke_Fs_TRA(b_phongId);;
            ns_tl_htro_antrua_phong_P_NV();
        } else if (b_maTen == "GIATRI") {
            var b_hang = GridX_Fi_timHangT(b_grctId);
            if (b_hang < 0) {
                GridX_ThemHang(b_grctId);
                b_hang = GridX_Fi_timHangT(b_grctId);
            }
            GridX_datA(b_grctId, b_hang, "tt");
        }
        else skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_tl_htro_antrua_phong_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_htro_antrua_phong_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_tl.Fs_NS_TL_HTRO_ANTRUA_PHONG_MA(b_ma, b_TrangKt, a_cot, ns_tl_htro_antrua_phong_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_htro_antrua_phong_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang2(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_tl_htro_antrua_phong_P_CHUYEN_HANG(); }
}
function ns_cb_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_so_theId; break;
        }
        if (b_maTen == "NV") {
            //$get(b_phongId).style.display = "none";
            $get(b_an_grnvId).style.display = "";
            $get(b_an_grDviId).style.display = "none";
            $get(theodv).value = ""
            GridX_datTrang(b_grDviId);
            ns_tl_htro_antrua_phong_P_CHUYEN_HANG();
        }
        else if (b_maTen == "DVI") {
            //$get(b_phongId).style.display = "";
            $get(b_an_grnvId).style.display = "none";
            $get(b_an_grDviId).style.display = "";
            $get(theonv).value = ""
            GridX_datTrang(b_grctId);
            ns_tl_htro_antrua_phong_LKE_DVI();
            //ns_tl_htro_antrua_phong_P_KTRA("PHONG_TK");
        }
        b_chonId = b_maTen;
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        else if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), "Mã cán bộ", b_ma.value, "ns_cb,so_the,ten", ns_tl_htro_antrua_phong_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_kynang_cn_P_CHUYEN_HANG();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_htro_antrua_phong_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        if (b_chonId == "SO_THE") { $get(b_gocId).value = ""; $get(b_gocId).focus(); }
    } else {
        form_P_DatGchu(b_gchuId, b_kq);
    }
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
    if (a_kq != "") {
        var b_hang = GridX_Fi_timHangA(b_grctId);
        GridX_datGtri(b_grctId, b_hangId, "SO_THE", a_kq[1], 'K');
        GridX_datGtri(b_grctId, b_hangId, "TEN", a_kq[2], 'K');
        GridX_datGtri(b_grctId, b_hangId, "PHONG", a_kq[5], 'K');
        GridX_datGtri(b_grctId, b_hangId, "ten_phong", a_kq[6], 'K');
    }
    return false;
}
function ns_tl_htro_antrua_phong_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grctId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        if (b_value != "") {
            if (b_cot == "SO_THE") {
                b_hangId = b_hang;
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Số thẻ", b_value, "ns_cb,so_the,ten", ns_tl_htro_antrua_phong_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
                b_ctr.value = "";
                if (b_hang < 0) return;
                ns_thongtin_canbo(b_value);
            }
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_htro_antrua_phong_P_CB_HOI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var b_hang = GridX_Fi_timHangA(b_grctId);
    var a_kq = Fas_ChMang(b_kq, '#');
    GridX_datGtri(b_grctId, b_hang, ["so_the"], [a_kq[0]], 'K');
    GridX_datGtri(b_grctId, b_hang, ["phong"], [a_kq[1]], 'K');
    GridX_datGtri(b_grctId, b_hang, ["ten"], [a_kq[2]], 'K');
    GridX_ThemHang(b_grctId);
}
function ns_tl_htro_antrua_phong_GR_lke_RowChange() {
    if (ns_tl_htro_antrua_phong_choAct != 0) clearTimeout(ns_tl_htro_antrua_phong_choAct);
    ns_tl_htro_antrua_phong_choAct = setTimeout("ns_tl_htro_antrua_phong_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_tl_htro_antrua_phong_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    $get(theonv).value = "X";
    ns_cb_P_KTRA("NV");
    return false;
}
function ns_tl_htro_antrua_phong_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var ktra = ktra_ngay(parseDate($get(b_ngaydId).value).getTime(), parseDate($get(b_ngaycId).value).getTime(), 1, "Ngày hiệu lực", " ngày hết hiệu lực");
            if (ktra.length > 0) {
                ns_tl_htro_antrua_phong_P_NH_KQ(ktra);
                return false;
            }

            var b_dt = form_Faa_TEXT_ROW(b_vungId), b_hang = GridX_Fi_timHangA(b_grlkeId), b_so_id = '0', b_dt_ct = GridX_Fdt_cotGtri(b_grctId),
                b_dt_dvi = GridX_Fdt_cotGtri(b_grDviId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            if (b_hang > 0) b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
            sns_tl.Fs_NS_TL_HTRO_ANTRUA_PHONG_NH(b_TrangKt, b_so_id, b_dt, b_dt_ct, b_dt_dvi, a_cot_lke, ns_tl_htro_antrua_phong_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_tl_htro_antrua_phong_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang2(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_so_idId).focus();
        form_P_LOI('loi:Nhập thành công!:loi');
    }
    return false;
}
// lke
function ns_tl_htro_antrua_phong_P_NV() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grctId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_phong = $get(b_tenphongId).value;
        sns_tl.Fs_NS_TL_HTRO_ANTRUA_PHONG_P_NV(b_phong, a_tso, a_cot, ns_tl_htro_antrua_phong_P_NV_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_htro_antrua_phong_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ns_tl_htro_antrua_phong_lkeCho != 0) clearTimeout(ns_tl_htro_antrua_phong_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        b_slideIdDvi = $get(b_grDviId).getAttribute('slideId');
        ns_tl_htro_antrua_phong_P_LKE('K');
    }
}
function ns_tl_htro_antrua_phong_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_tl.Fs_NS_TL_HTRO_ANTRUA_PHONG_LKE(a_tso, a_cot, ns_tl_htro_antrua_phong_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_tl_htro_antrua_phong_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang2(b_grlkeId, a_kq[1]);
}
function ns_tl_htro_antrua_phong_P_NV_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    if (a_kq[1] == "") GridX_datTrang(b_grctId);
    else GridX_datBang2(b_grctId, a_kq[1]);
}
function ns_tl_htro_antrua_phong_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")),
        a_cot = GridX_Fas_tenCot(b_grctId), a_cot_dvi = GridX_Fas_tenCot(b_grDviId);
    if (b_so_id == "") ns_tl_htro_antrua_phong_P_MOI();
    else sns_tl.Fs_NS_TL_HTRO_ANTRUA_PHONG_CT(b_so_id, a_cot, a_cot_dvi, ns_tl_htro_antrua_phong_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    GridX_datA(b_grlkeId, b_hang);
    $get(b_so_idId).value = b_so_id;
}
function ns_tl_htro_antrua_phong_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang2(b_grctId, a_kq[1]);
    if (a_kq[3] == "") GridX_datTrang(b_grDviId); else { slide_P_SOTRANG(b_slideIdDvi, CSO_SO(a_kq[2], 0)); GridX_datBang(b_grDviId, a_kq[3]); }
    var b_nv = $get(theonv).value;
    if (b_nv != "") {
        $get(b_an_grnvId).style.display = "";
        $get(b_an_grDviId).style.display = "none";
        $get(theodv).value = ""
        GridX_datTrang(b_grDviId);
    } else {
        $get(b_an_grnvId).style.display = "none";
        $get(b_an_grDviId).style.display = "";
        $get(theonv).value = ""
        GridX_datTrang(b_grctId);
    }
}
function ns_tl_htro_antrua_phong_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); ns_tl_htro_antrua_phong_P_MOI(); return false; }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_tl.Fs_NS_TL_HTRO_ANTRUA_PHONG_XOA(b_so_id, a_tso, a_cot, ns_tl_htro_antrua_phong_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_tl_htro_antrua_phong_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang2(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_tl_htro_antrua_phong_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_tl_htro_antrua_phong_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
    return false;
}
function ns_tl_htro_antrua_phong_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_tl_htro_antrua_phong_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_tl_htro_antrua_phong_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function ns_tl_htro_antrua_phong_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}
function ns_tl_htro_antrua_phong_P_CHON() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_check = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tinhtrang"));
    //if (b_check == "Chưa phê duyệt") { alert('Không thể chọn khóa đào tạo chưa phê duyệt'); return; }
    //else
    form_P_TRA_CHON('MA,TEN');
}
function ns_tl_htro_antrua_phong_P_XUAT_EXEL() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function ktra_ngay(tungay, denngay, loai, ten1, ten2) {
    if (denngay == "" || denngay == null) {
        return "";
    }
    if (loai == 1 && tungay > denngay) {
        return "loi: " + ten1 + " không được lớn hơn " + ten2 + " :loi";
    } else if (loai == 2 && tungay >= denngay) {
        return "loi: " + ten1 + " không được lớn hơn hoặc bằng " + ten2 + " :loi";
    }
    return "";
}
function parseDate(str) {
    var mdy = str.split('/');
    return new Date(mdy[2], mdy[1], mdy[0]);
}
function CheckAll(oCheckbox) {
    if (oCheckbox.checked == true) {
        var b_so_tien = $get(b_sotienId).value;
        for (i = 1; i <= b_sodong_grDvi; i++) {
            var b_ma_phong = C_NVL(GridX_Fas_layGtri(b_grDviId, i, "ma_phong"));
            if (b_ma_phong != "") GridX_datGtri(b_grDviId, i, ["chon", "so_tien"], ['X', b_so_tien], 'K');
        }
    } else {
        for (i = 1; i <= b_sodong_grDvi; i++) {
            GridX_datGtri(b_grDviId, i, ["chon", "so_tien"], ['', '0'], 'K');
        }
    }
}

function ns_tl_htro_antrua_phong_LKE_DVI() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grDviId);
        hts_dungchung.Fdt_MA_PHONG_LKE_GR(a_cot, ns_tl_htro_antrua_phong_LKE_DVI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_htro_antrua_phong_LKE_DVI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideIdDvi, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grDviId, a_kq[1]);
        b_sodong_grDvi = CSO_SO(a_kq[0], 0);
    }
}


function form_dong() {
    location.reload(false);
}