var b_ps, b_nv, b_so_id, b_so_the, b_ten, b_ngayd, b_ngayc, b_gridId, b_grsanId, b_ngay_tl;
function ns_hd_tl_KD() {
    b_gridId = form_Fs_VUNG_ID('GR_dk'); b_grsanId = form_Fs_VUNG_ID('GR_san');
    b_so_the = form_Fs_VTEN_ID('UPa_ct', 'so_the');
    b_ten = form_Fs_VTEN_ID('UPa_ct', 'ten');
    b_ngayd = form_Fs_VTEN_ID('UPa_ct', 'ngayd');
    b_ngayc = form_Fs_VTEN_ID('UPa_ct', 'ngayc');
    b_ngay_tl = form_Fs_VTEN_ID('UPa_ct', 'ngay_tl');
    b_ps = 'NS'; b_nv = 'TT';


}

function P_KET_QUA(b_dtuong, a_tso) {
    if (b_dtuong.toUpperCase() == "THAMSO") {
        var a_s = a_tso[0].split(',');
        if (a_s.length > 2) {
            b_ps = a_s[0]; b_nv = a_s[1]; form_Fctr_VTEN_DTUONG('', 'ten_form').innerHTML = a_s[2]; b_so_id = a_s[3];
            $get(b_so_the).value = a_s[4];
            $get(b_ten).value = a_s[5];
            $get(b_ngayd).value = a_s[6];
            $get(b_ngayc).value = a_s[7];
            $get(b_ngay_tl).value = a_s[8];
            //ns_hd_tl_P_LKE();
        }
    }
}
function khud_ttt_P_DONG() {
    $get(b_khud_ttt_gchuId).value = ".";
    var b_dt_ct = GridX_Fdt_cotGtri(b_grsanId);

}
function ns_hd_tl_GR_Update(b_event) {
    var b_ctr = form_Fctr_event(b_event);
    if (C_NVL(b_ctr.value) != "") GridX_ThemHang(b_gridId);
    return false;
}
function ns_hd_tl_P_SAN() {
    try {
        var a_dt = GridX_Fdt_cotGtriL(b_gridId, "MA", "MA");
        sns_khud.Fs_TTT_SAN(form_Fs_nsd(), b_ps, b_nv, a_dt, ns_hd_tl_P_SAN_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_hd_tl_P_SAN_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else if (b_kq == "") form_P_LOI_DICH("Đã chọn hết");
    else {
        GridX_datBang(b_grsanId, b_kq);
        form_Fctr_TENVUNG('UPa_san').style.display = "";
    }
}
function ns_hd_tl_P_CHON() {
    var a_cot = ["ma", "ten", "loai"];
    var a_dt = GridX_Fdt_cotGtriC(b_grsanId, a_cot);
    if (a_dt.length > 0) {
        var b_hangSo = GridX_Fi_hangSo(b_gridId), b_hang;
        a_cot[3] = "bb";
        for (var i = 0; i < a_dt.length; i++) {
            b_hang = GridX_Fi_timHangT(b_gridId); a_dt[i][3] = "K";
            if (b_hang < 1) { b_hangSo++; b_hang = b_hangSo; GridX_chenHang(b_gridId, 0, 1); }
            GridX_datGtri(b_gridId, b_hang, a_cot, a_dt[i]);
        }
        if (!GridX_Fb_hangTrang(b_gridId, b_hangSo, "ma")) GridX_chenHang(b_gridId, 0, 1);
    }
    form_Fctr_TENVUNG('UPa_san').style.display = "none";
    return false;
}
function ns_hd_tl_DONG() {
    form_Fctr_TENVUNG('UPa_san').style.display = "none";
    return false;
}


function ktra_ngay(tungay, denngay, ngay_tl) {
    if (denngay.toString() == "NaN") {
        if (ngay_tl < tungay) {
            return "loi:Ngày thanh lý phải lơn hơn ngày bắt đầu hợp đồng:loi";
        }
        return ""
    }
    if (ngay_tl > tungay && ngay_tl < denngay) {
        return "";
    } else {
        return "loi:Ngày thanh lý phải nằm trong khoảng thời gian hiệu lực của hợp đồng:loi";
    }
    return "";
}

function ns_hd_tl_P_NH() {
    try {
        var ktra = ktra_ngay(Date.parse($get(b_ngayd).value), Date.parse($get(b_ngayc).value), Date.parse($get(b_ngay_tl).value));
        if (ktra.length > 0) {
            ns_hd_tl_P_NH_KQ(ktra);
            return false;
        }
        var b_dt = GridX_Fdt_cotGtri(b_gridId), ngay_tl = $get(b_ngay_tl).value;
        sns_qt.Fs_NS_HD_TL(b_so_id, ngay_tl, ns_hd_tl_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        form_P_DAY(window.name, "ns_hd", "SO_THE,TEN,SO_ID", [$get(b_so_the).value, $get(b_ten).value, b_so_id]);
        //return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}

function ns_hd_tl_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DONG(window.name, null);
}
function ns_hd_tl_P_HUY() {
    try {
        return true;
    }
    catch (ex) { form_P_LOI(ex.message); }
}

function ns_hd_tl_len() {
    GridX_chuyenHang(b_gridId, -1);
    return false;
}
function ns_hd_tl_xuong() {
    GridX_chuyenHang(b_gridId, 1);
    return false;
}
function ns_hd_tl_chen() {
    GridX_chenHang(b_gridId);
    return false;
}
function ns_hd_tl_cat() {
    GridX_boChon(b_gridId);
    return false;
}
