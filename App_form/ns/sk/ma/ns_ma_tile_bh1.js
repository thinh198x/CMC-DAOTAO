var ns_ma_tile_bh_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timId, ns_ma_tile_bh_choAct = 0;
function ns_ma_tile_bh_P_KD() {
    ns_ma_tile_bh_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_gocId = form_Fs_TEN_ID(b_vungId, 'ngay_hl');
    b_slideId = b_grlkeId + '_slide'; b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    ns_ma_tile_bh_lkeCho = setInterval('ns_ma_tile_bh_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (typeof (b_dtuong) == "undefined") {
            return false;
        }
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("TINHTHANH") >= 0) {
            $get(b_tinhthanh).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_tinhthanh).focus();
        }
        else if (b_dtuong.indexOf("QUANHUYEN") >= 0) {
            $get(b_quanhuyen).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_quanhuyen).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_tile_bh_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        if (b_maTen.indexOf("MA") >= 0) {
            b_maId = b_gocId;
            var b_ma = $get(b_maId);
            if (C_NVL(b_ma.value) == "") return;
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ngay_hl", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_ma_tile_bh_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_ma_tile_bh_P_CHUYEN_HANG(); }
        }
        if (b_maTen.indexOf("CTY_BHXH") >= 0) {
            var a_kq = Fas_ChMang(b_maTen, ',');
            b_soid = form_Fs_TEN_ID(b_vungId, a_kq[0]);
            var b_so = $get(b_soid).value
            var b_csotp = CSO_SO(b_so, 2);
            if (b_csotp == 0 || b_csotp > 100) {
                form_P_LOI('loi:Phần trăm phải lớn hơn 0 và nhỏ hơn 100:loi');
                $get(form_Fs_TEN_ID(b_vungId, 'CTY_BHXH')).value = '';
            }
        }
        else if (b_maTen.indexOf("CTY_BHYT") >= 0) {
            var a_kq = Fas_ChMang(b_maTen, ',');
            b_soid = form_Fs_TEN_ID(b_vungId, a_kq[0]);
            var b_so = $get(b_soid).value
            var b_csotp = CSO_SO(b_so, 2);
            if (b_csotp == 0 || b_csotp > 100) {
                form_P_LOI('loi:Phần trăm phải lớn hơn 0 và nhỏ hơn 100:loi');
                $get(form_Fs_TEN_ID(b_vungId, 'CTY_BHYT')).value = '';
            }
        }
        //else if (b_maTen.indexOf("CTY_BHTN") >= 0) {
        //    var a_kq = Fas_ChMang(b_maTen, ',');
        //    b_soid = form_Fs_TEN_ID(b_vungId, a_kq[0]);
        //    var b_so = $get(b_soid).value
        //    var b_csotp = CSO_SO(b_so, 2);
        //    if (b_csotp == 0 || b_csotp > 100) {
        //        form_P_LOI('loi:Phần trăm phải lớn hơn 0 và nhỏ hơn 100:loi');
        //        $get(form_Fs_TEN_ID(b_vungId, 'CTY_BHTN')).value = '';
        //    }
        //}
        else if (b_maTen.indexOf("NV_BHXH") >= 0) {
            var a_kq = Fas_ChMang(b_maTen, ',');
            b_soid = form_Fs_TEN_ID(b_vungId, a_kq[0]);
            var b_so = $get(b_soid).value
            var b_csotp = CSO_SO(b_so, 2);
            if (b_csotp == 0 || b_csotp > 100) {
                form_P_LOI('loi:Phần trăm phải lớn hơn 0 và nhỏ hơn 100:loi');
                $get(form_Fs_TEN_ID(b_vungId, 'NV_BHXH')).value = '';
            }
        }
        else if (b_maTen.indexOf("NV_BHYT") >= 0) {
            var a_kq = Fas_ChMang(b_maTen, ',');
            b_soid = form_Fs_TEN_ID(b_vungId, a_kq[0]);
            var b_so = $get(b_soid).value
            var b_csotp = CSO_SO(b_so, 2);
            if (b_csotp == 0 || b_csotp > 100) {
                form_P_LOI('loi:Phần trăm phải lớn hơn 0 và nhỏ hơn 100:loi');
                $get(form_Fs_TEN_ID(b_vungId, 'NV_BHYT')).value = '';
            }
        }
        //else if (b_maTen.indexOf("NV_BHTN") >= 0) {
        //    var a_kq = Fas_ChMang(b_maTen, ',');
        //    b_soid = form_Fs_TEN_ID(b_vungId, a_kq[0]);
        //    var b_so = $get(b_soid).value
        //    var b_csotp = CSO_SO(b_so, 2);
        //    if (b_csotp == 0 || b_csotp > 100) {
        //        form_P_LOI('loi:Phần trăm phải lớn hơn 0 và nhỏ hơn 100:loi');
        //        $get(form_Fs_TEN_ID(b_vungId, 'NV_BHTN')).value = '';
        //    }
        //}
        else if (b_maTen.indexOf("HESO_OMDAU") >= 0) {
            var a_kq = Fas_ChMang(b_maTen, ',');
            b_soid = form_Fs_TEN_ID(b_vungId, a_kq[0]);
            var b_so = $get(b_soid).value
            var b_csotp = CSO_SO(b_so, 2);
            if (b_csotp == 0 || b_csotp > 100) {
                form_P_LOI('loi:Hệ số phải lớn hơn 0 và nhỏ hơn 100:loi');
                $get(form_Fs_TEN_ID(b_vungId, 'HESO_OMDAU')).value = '';
            }
        }
        else if (b_maTen.indexOf("HESO_THAISAN") >= 0) {
            var a_kq = Fas_ChMang(b_maTen, ',');
            b_soid = form_Fs_TEN_ID(b_vungId, a_kq[0]);
            var b_so = $get(b_soid).value
            var b_csotp = CSO_SO(b_so, 2);
            if (b_csotp == 0 || b_csotp > 100) {
                form_P_LOI('loi:Hệ số phải lớn hơn 0 và nhỏ hơn 100:loi');
                $get(form_Fs_TEN_ID(b_vungId, 'HESO_THAISAN')).value = '';
            }
        } else if (b_maTen.indexOf("NGHI_TAPTRUNG") >= 0) {
            var a_kq = Fas_ChMang(b_maTen, ',');
            b_soid = form_Fs_TEN_ID(b_vungId, a_kq[0]);
            var b_so = $get(b_soid).value
            var b_csotp = CSO_SO(b_so, 2);
            if (b_csotp == 0 || b_csotp > 100) {
                form_P_LOI('loi:Hệ số phải lớn hơn 0 và nhỏ hơn 100:loi');
                $get(form_Fs_TEN_ID(b_vungId, 'NGHI_TAPTRUNG')).value = '';
            }
        }
        else if (b_maTen.indexOf("NGHI_TAINHA") >= 0) {
            var a_kq = Fas_ChMang(b_maTen, ',');
            b_soid = form_Fs_TEN_ID(b_vungId, a_kq[0]);
            var b_so = $get(b_soid).value
            var b_csotp = CSO_SO(b_so, 2);
            if (b_csotp == 0 || b_csotp > 100) {
                form_P_LOI('loi:Hệ số phải lớn hơn 0 và nhỏ hơn 100:loi');
                $get(form_Fs_TEN_ID(b_vungId, 'NGHI_TAINHA')).value = '';
            }
        }
        else if (b_maTen.indexOf("NGHIHUU_NAM") >= 0) {
            var a_kq = Fas_ChMang(b_maTen, ',');
            b_soid = form_Fs_TEN_ID(b_vungId, a_kq[0]);
            var b_so = $get(b_soid).value
            var b_csotp = CSO_SO(b_so, 2);
            if (b_csotp == 0 || b_csotp > 100) {
                form_P_LOI('loi:Tuổi về hưu phải lớn hơn 0 và nhỏ hơn 100:loi');
                $get(form_Fs_TEN_ID(b_vungId, 'NGHIHUU_NAM')).value = '';
            }
        }
        else if (b_maTen.indexOf("NGHIHUU_NU") >= 0) {
            var a_kq = Fas_ChMang(b_maTen, ',');
            b_soid = form_Fs_TEN_ID(b_vungId, a_kq[0]);
            var b_so = $get(b_soid).value
            var b_csotp = CSO_SO(b_so, 2);
            if (b_csotp == 0 || b_csotp > 100) {
                form_P_LOI('loi:Tuổi về hưu phải lớn hơn 0 và nhỏ hơn 100:loi');
                $get(form_Fs_TEN_ID(b_vungId, 'NGHIHUU_NU')).value = '';
            }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_tile_bh_P_MA_KTRA() {
    try {
        var b_ngay_hl = C_NVL($get(b_gocId).value);
        if (b_ngay_hl != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_ma_ch.Fs_NS_MA_TYLE_BH_MA(b_ngay_hl, b_TrangKt, a_cot, ns_ma_tile_bh_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_tile_bh_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_ma_tile_bh_P_CHUYEN_HANG(); }
}
function ns_ma_tile_bh_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    var b_drop = form_Fctr_TEN_DTUONG(b_vungId, 'trangthai');
    list_P_DAT(b_drop, 'A');
    $get(b_gocId).focus();
    return false;
}
function ns_ma_tile_bh_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var b_so = $get(form_Fs_TEN_ID(b_vungId, 'CTY_BHYT')).value;
    if (CSO_SO(b_so, 2) == 0 || CSO_SO(b_so, 2) > 100) {
        form_P_LOI('loi:Phần trăm phải lớn hơn 0 và nhỏ hơn 100:loi');
        $get(form_Fs_TEN_ID(b_vungId, 'CTY_BHYT')).value = '';
        return false;
    }
    var b_so = $get(form_Fs_TEN_ID(b_vungId, 'CTY_BHXH')).value;
    if (CSO_SO(b_so, 2) == 0 || CSO_SO(b_so, 2) > 100) {
        form_P_LOI('loi:Phần trăm phải lớn hơn 0 và nhỏ hơn 100:loi');
        $get(form_Fs_TEN_ID(b_vungId, 'CTY_BHXH')).value = '';
        return false;
    }
    //var b_so = $get(form_Fs_TEN_ID(b_vungId, 'CTY_BHTN')).value;
    //if (CSO_SO(b_so, 2) == 0 || CSO_SO(b_so, 2) > 100) {
    //    form_P_LOI('loi:Phần trăm phải lớn hơn 0 và nhỏ hơn 100:loi');
    //    $get(form_Fs_TEN_ID(b_vungId, 'CTY_BHTN')).value = '';
    //    return false;
    //}
    var b_so = $get(form_Fs_TEN_ID(b_vungId, 'NV_BHYT')).value;
    if (CSO_SO(b_so, 2) == 0 || CSO_SO(b_so, 2) > 100) {
        form_P_LOI('loi:Phần trăm phải lớn hơn 0 và nhỏ hơn 100:loi');
        $get(form_Fs_TEN_ID(b_vungId, 'NV_BHYT')).value = '';
        return false;
    }
    var b_so = $get(form_Fs_TEN_ID(b_vungId, 'NV_BHXH')).value;
    if (CSO_SO(b_so, 2) == 0 || CSO_SO(b_so, 2) > 100) {
        form_P_LOI('loi:Phần trăm phải lớn hơn 0 và nhỏ hơn 100:loi');
        $get(form_Fs_TEN_ID(b_vungId, 'NV_BHXH')).value = '';
        return false;
    }
    //var b_so = $get(form_Fs_TEN_ID(b_vungId, 'NV_BHTN')).value;
    //if (CSO_SO(b_so, 2) == 0 || CSO_SO(b_so, 2) > 100) {
    //    form_P_LOI('loi:Phần trăm phải lớn hơn 0 và nhỏ hơn 100:loi');
    //    $get(form_Fs_TEN_ID(b_vungId, 'NV_BHTN')).value = '';
    //    return false;
    //}
    var b_so = $get(form_Fs_TEN_ID(b_vungId, 'HESO_OMDAU')).value;
    if (CSO_SO(b_so, 2) == 0 || CSO_SO(b_so, 2) > 100) {
        form_P_LOI('loi:Phần trăm phải lớn hơn 0 và nhỏ hơn 100:loi');
        $get(form_Fs_TEN_ID(b_vungId, 'HESO_OMDAU')).value = '';
        return false;
    }
    var b_so = $get(form_Fs_TEN_ID(b_vungId, 'HESO_THAISAN')).value;
    if (CSO_SO(b_so, 2) == 0 || CSO_SO(b_so, 2) > 100) {
        form_P_LOI('loi:Phần trăm phải lớn hơn 0 và nhỏ hơn 100:loi');
        $get(form_Fs_TEN_ID(b_vungId, 'HESO_THAISAN')).value = '';
        return false;
    }
    var b_so = $get(form_Fs_TEN_ID(b_vungId, 'NGHI_TAPTRUNG')).value;
    if (CSO_SO(b_so, 2) == 0 || CSO_SO(b_so, 2) > 100) {
        form_P_LOI('loi:Phần trăm phải lớn hơn 0 và nhỏ hơn 100:loi');
        $get(form_Fs_TEN_ID(b_vungId, 'NGHI_TAPTRUNG')).value = '';
        return false;
    }
    var b_so = $get(form_Fs_TEN_ID(b_vungId, 'NGHI_TAINHA')).value;
    if (CSO_SO(b_so, 2) == 0 || CSO_SO(b_so, 2) > 100) {
        form_P_LOI('loi:Phần trăm phải lớn hơn 0 và nhỏ hơn 100:loi');
        $get(form_Fs_TEN_ID(b_vungId, 'NGHI_TAINHA')).value = '';
        return false;
    }
    var b_so = $get(form_Fs_TEN_ID(b_vungId, 'NGHIHUU_NAM')).value;
    if (CSO_SO(b_so, 2) == 0 || CSO_SO(b_so, 2) > 100) {
        form_P_LOI('loi:Phần trăm phải lớn hơn 0 và nhỏ hơn 100:loi');
        $get(form_Fs_TEN_ID(b_vungId, 'NGHIHUU_NAM')).value = '';
        return false;
    }
    var b_so = $get(form_Fs_TEN_ID(b_vungId, 'NGHIHUU_NU')).value;
    if (CSO_SO(b_so, 2) == 0 || CSO_SO(b_so, 2) > 100) {
        form_P_LOI('loi:Phần trăm phải lớn hơn 0 và nhỏ hơn 100:loi');
        $get(form_Fs_TEN_ID(b_vungId, 'NGHIHUU_NU')).value = '';
        return false;
    }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_ma_ch.Fs_NS_MA_TYLE_BH_NH(b_TrangKt, a_dt_ct, a_cot, ns_ma_tile_bh_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_ma_tile_bh_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI("loi:Ghi thành công!:loi");
    }
}
function ns_ma_tile_bh_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    //var message = confirm("Bạn có chắc chắn xóa không?");
    //if (message == false) { return false; }
    var b_ngay_hl = GridX_Fas_layGtri(b_grlkeId, b_hang, "ngay_hl");
    if (b_ngay_hl == "") ns_ma_tile_bh_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_NS_MA_TYLE_BH_XOA(b_ngay_hl, a_tso, a_cot, ns_ma_tile_bh_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_ma_tile_bh_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_ma_tile_bh_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_ma_tile_bh_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
}
function ns_ma_tile_bh_GR_lke_RowChange() {
    if (ns_ma_tile_bh_choAct != 0) clearTimeout(ns_ma_tile_bh_choAct);
    ns_ma_tile_bh_choAct = setTimeout("ns_ma_tile_bh_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_ma_tile_bh_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ngay_hl"));
        if (b_ma == "") form_P_MOI(b_vungId, "XGL"); else form_P_GridX_TEXT(b_vungId, b_grlkeId);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_tile_bh_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        ns_ma_tile_bh_P_MOI();
        if (ns_ma_tile_bh_lkeCho != 0) clearTimeout(ns_ma_tile_bh_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_ma_tile_bh_P_LKE('K');
    }
}
function ns_ma_tile_bh_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_NS_MA_TYLE_BH_LKE(a_tso, a_cot, ns_ma_tile_bh_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_ma_tile_bh_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function form_dong() {
    location.reload(false);
}