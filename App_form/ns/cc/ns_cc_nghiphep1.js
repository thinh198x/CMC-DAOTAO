var ns_cc_nghiphep_lkeCho, b_vungId, b_grlkeId, b_grctId, b_mt, b_kyluongId;
function ns_cc_nghiphep_P_KD() {
    b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct');
    b_namId = form_Fs_TEN_ID(b_vungId, 'NAM'), b_phongId = form_Fs_TEN_ID(b_vungId, 'PHONG'), b_kyluongId = form_Fs_TEN_ID(b_vungId, 'KYLUONG');
    b_slideId = b_grlkeId + '_slide'; b_slidectId = b_grctId + '_slide'; ns_cc_nghiphep_lkeCho = setInterval('ns_cc_nghiphep_P_LKE_CHO()', 200);
}
function ns_cc_nghiphep_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "PHONG": b_maId = b_phongId; break;
            case "NAM": b_maId = b_namId; break;
            case "KYLUONG": b_maId = b_kyluongId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null) return;
        if (b_maTen == "PHONG") {
            ns_cc_nghiphep_P_LKE();
            ns_cc_nghiphep_P_MA_KTRA();
        }
        if (b_maTen == "NAM") {
            var b_nam = $get(b_namId).value;
            if (b_nam != "") {
                var b_hang = GridX_Fi_timHangD(b_grlkeId, "nam", b_nam);
                if (b_hang > -1) {
                    GridX_datA(b_grlkeId, b_hang);
                    ns_cc_nghiphep_P_CHUYEN_HANG();
                }
                else {
                    GridX_thoiA(b_grlkeId);
                    ns_cc_nghiphep_P_MA_KTRA();
                }
            }
            //else $get(b_thangId).focus();
        } else if (b_maTen == "KYLUONG") {
            var b_kyluong = $get(b_namId).value;
            ns_cc_nghiphep_lkeCho = setInterval('ns_cc_nghiphep_P_LKE_CHO()', 200);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_nghiphep_P_LKE_CHO() {
    if ($get(b_grctId) != null) { clearTimeout(ns_cc_nghiphep_lkeCho); ns_cc_nghiphep_P_LKE(); }
}
function ns_cc_nghiphep_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    ns_cc_nghiphep_P_LKE_CB();
}
function ns_cc_nghiphep_P_LKE() {
    try {
        var b_phong = $get(b_phongId).value, b_kyluong = $get(b_kyluongId).value, a_cot = GridX_Fas_tenCot(b_grctId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_phep.Fs_NS_CC_NGHIPHEP_LKE(b_phong, b_kyluong, a_tso, a_cot, ns_cc_nghiphep_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_nghiphep_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grctId, a_kq[1]);
}

function ns_cc_nghiphep_TINH() {
    try {
        var b_phong = $get(b_phongId).value,
        b_nam = $get(b_namId).value;
        b_kyluong = $get(b_kyluongId).value;
        if (b_kyluong == null || b_kyluong == "") { alert("Phải chọn kỳ"); }
        else {
            var a_cot = GridX_Fas_tenCot(b_grctId), a_tso = slide_Faobj_TUDEN(b_slidectId);
            stl_phep.Fs_NS_CC_NGHIPHEP_TINH(b_phong, b_kyluong, a_cot, a_tso, ns_cc_nghiphep_P_TINH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_nghiphep_P_TINH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slidectId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grctId, a_kq[1]);
}
function ns_cc_phep_P_IN() {
    __doPostBack('ctl00$ContentPlaceHolder1$Xuat2', '');
}

function form_dong() {
    location.reload(false);
}