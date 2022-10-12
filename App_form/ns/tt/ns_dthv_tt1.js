var ns_dthv_tt_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_so_the_an_Id, b_ten_Id, b_cnganhId, b_sohieuId,
    b_gchuId, b_so_idId, b_doi = 0, b_ngaycap, b_thangd, b_thangc, b_cho_control = 0, ns_dthv_tt_choAct = 0, b_nsd;
function ns_dthv_tt_P_KD() {
    ns_dthv_tt_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE'); b_so_the_an_Id = form_Fs_TEN_ID(b_vungId, 'so_the_an');
    b_ten_Id = form_Fs_TEN_ID(b_vungId, 'ten');
    b_cnganhId = form_Fs_TEN_ID(b_vungId, 'cnganh'),
    b_sohieuId = form_Fs_TEN_ID(b_vungId, 'sohieu');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_slideId = $get(b_grlkeId).getAttribute('slideId');
    b_ngaycap = form_Fs_TEN_ID(b_vungId, 'NGAYCAP');
    b_thangd = form_Fs_TEN_ID(b_vungId, 'thangd');
    b_thangc = form_Fs_TEN_ID(b_vungId, 'thangc');
    b_nsd = form_Fs_nsd();
}
function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_gocId).value = b_so_the;
            $get(b_so_the_an_Id).value = b_so_the;
            $get(b_ten_Id).value = b_ten;
            //$get(b_gchuId).innerHTML = b_ten;
            //$get(b_gocId).focus();
            ns_dthv_tt_P_LKE();
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
        //else if (b_dtuong.indexOf("NHOM_CNGANH") >= 0) {
        //    $get(b_nhomcnganhId).value = b_kq;
        //    $get(b_gchuId).innerHTML = a_tso[1];
        //    $get(b_cnganhId).focus();
        //}
        //else if (b_dtuong.indexOf("CNGANH") >= 0) {
        //    $get(b_cnganhId).value = b_kq;
        //    $get(b_gchuId).innerHTML = a_tso[1];
        //    $get(b_ten_cnganhId).innerHTML = a_tso[1];
        //    $get(b_noidtId).focus();
        //}
        //else if (b_dtuong.indexOf("VB") >= 0) {
        //    $get(b_vbId).value = b_kq;
        //    $get(b_gchuId).innerHTML = a_tso[1];
        //    $get(b_sohieuId).focus();
        //}
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dthv_tt_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; form_P_MOI("", "XGL"); break;
            case "CNGANH": b_maId = b_cnganhId; break;
            case "VB": b_maId = b_vbId; break;
            case "NHOM_CNGANH": b_maId = b_nhomcnganhId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_dthv_tt_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_dthv_tt_P_LKE();
        }
        else skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_dthv_tt_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dthv_tt_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    //else form_P_DatGchu(b_gchuId, b_kq);
}
function ns_dthv_tt_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = "0";
    $get(b_gocId).focus();
    return false;
}
function ns_dthv_tt_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") {
            form_P_LOI(b_loi);
            return false;
        }

        if (!sosanhNgayHieuLuc()) return false;
        var ktra = sosanh_withDateTimeNow($get(b_ngaycap).value);
        if (ktra > 0) {
            form_P_LOI('loi:Ngày cấp bằng nhỏ hơn ngày hiện tại:loi');
            return false;
        }
        var ktra = sosanh_Date($get(b_thangd).value, $get(b_thangc).value);
        if (ktra.length > 0) {
            form_P_LOI(ktra);
            return false;
        }
        else {
            var b_tt = null;
            if (b_hang > 0) {
                b_tt = GridX_Fas_layGtri(b_grlkeId, b_hang, "tthai");
            }
            if (b_tt == "G") {
                form_P_LOI("loi:Không thể sửa bản ghi đã ở trạng thái đã gửi:loi"); return false;
            } else {
                var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
                var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
                var b_hang = GridX_Fi_timHangA(b_grlkeId);
                var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
                sns_tt.Fs_NS_DTHV_TT_NH(b_nsd, b_so_id, b_TrangKt, a_dt_ct, a_cot_lke, ns_dthv_tt_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_dthv_tt_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI("loi:Ghi thành công:loi");
    }
    return false;
}
function ns_dthv_tt_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"), b_tt = GridX_Fas_layGtri(b_grlkeId, b_hang, "tthai"),
            b_so_the = $get(b_gocId).value;
    if (b_so_id == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); ns_dthv_tt_P_MOI(); }
    else {
        if (b_tt == "0") {
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            sns_tt.Fs_NS_DTHV_TT_XOA(b_nsd, b_so_id, b_so_the, a_tso, a_cot, ns_dthv_tt_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        } else {
            form_P_LOI("loi:Không thể xóa bản ghi đã ở trạng thái đã gửi hoặc phê duyệt:loi"); return false;
        }
    }
    return false;
}
function ns_dthv_tt_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_dong = CSO_SO(a_kq[0], 0);
        slide_P_SOTRANG(b_slideId, b_dong);
        GridX_datBang(b_grlkeId, a_kq[1]);
        var b_dong = CSO_SO(a_kq[0], 0);
        if (b_hang > b_dong) b_hang = b_dong;
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dthv_tt_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dthv_tt_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
}
function ns_dthv_tt_GR_lke_RowChange() {
    if (ns_dthv_tt_choAct != 0) clearTimeout(ns_dthv_tt_choAct);
    ns_dthv_tt_choAct = setTimeout("ns_dthv_tt_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_dthv_tt_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "") form_P_MOI(b_vungId, "XGL");
    else sns_tt.Fs_NS_DTHV_TT_CT(b_nsd, b_so_id, ns_dthv_tt_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = b_so_id;
}
function ns_dthv_tt_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
function ns_dthv_tt_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_dthv_tt_lkeCho); ns_dthv_tt_P_LKE(); }
}
function ns_dthv_tt_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
                b_so_the = $get(b_gocId).value;
        sns_tt.Fs_NS_DTHV_TT_LKE(b_nsd, b_so_the, a_tso, a_cot, ns_dthv_tt_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dthv_tt_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_dthv_tt_P_GUI() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1) { form_P_LOI("loi:Bạn phải chọn một bản ghi để gửi:loi"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"),
            b_so_the = $get(b_gocId).value;
    if (b_so_id == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để gửi:loi"); ns_dthv_tt_P_MOI(); }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_tt.Fs_NS_DTHV_TT_GUI(b_nsd, b_so_id, b_so_the, a_tso, a_cot, ns_dthv_tt_P_GUI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_dthv_tt_P_GUI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_dong = CSO_SO(a_kq[0], 0);
        slide_P_SOTRANG(b_slideId, b_dong);
        GridX_datBang(b_grlkeId, a_kq[1]);
        var b_dong = CSO_SO(a_kq[0], 0);
        if (b_hang > b_dong) b_hang = b_dong;
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dthv_tt_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dthv_tt_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Gửi phê duyệt thành công!:loi");
    }
}
function nhap_file() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) {
        form_P_LOI('loi:Chọn bản ghi trước:loi')
        return false;
    }
    var b_so_the = $get(b_gocId).value;
    var b_tenf = '/App_form/ns/ma/file_Import_chung.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, b_so_the, "FILE_DTHV", "Chungchi_daotao", "Import dữ liệu -Lưu văn bằng đào tạo"]], null);
    form_P_LOI('');
    return false;

}
function sosanh_withDateTimeNow(str) {
    var mdy_str = str.split('/');
    var mdy_str = mdy_str[2] + mdy_str[1] + mdy_str[0];
    var mdy_str = parseInt(mdy_str);
    var dateht = new Date();
    var m = "0" + (1 + dateht.getMonth());
    var y = parseInt("2" + dateht.getYear()) - 100;
    var d = "0" + dateht.getDate();
    var dmy = y + m + d;
    var dmy = parseInt(dmy);
    var kq = mdy_str - dmy;
    return kq;
}
function sosanh_Date(str1, str2) {
    if (str1 == "" || str2 == "")
        return "";
    else {
        var mdy_str1 = str1.split('/');
        if (mdy_str1[0] < 0 || mdy_str1[0] > 12) {
            return "loi:Tháng của từ tháng không được nhỏ hơn 0 và lơn hơn 12:loi";
        } else if (mdy_str1[1].length != 4) {
            return "loi:Năm của từ tháng không đúng định dạng:loi";
        }
        var mdy_str1 = mdy_str1[1] + mdy_str1[0];
        var mdy_str1 = parseInt(mdy_str1);


        var mdy_str2 = str2.split('/');
        if (mdy_str2[0] < 0 || mdy_str2[0] > 12) {
            return "loi: Tháng của đến tháng không được nhỏ hơn 0 và lơn hơn 12:loi";
        } else if (mdy_str2[1].length != 4) {
            return "loi:Năm của đến tháng không đúng định dạng:loi";
        }
        var mdy_str2 = mdy_str2[1] + mdy_str2[0];
        var mdy_str2 = parseInt(mdy_str2);
        if (mdy_str2 - mdy_str1 < 0) {
            return "loi:Từ tháng không được nhỏ hơn đến tháng:loi";
        } else return "";
    }
}
function sosanhNgayHieuLuc() {
    var b_ngay_hl = $get(b_ngaycap).value;
    if (b_ngay_hl != "") {
        b_ngay_hl = CNG_SO(b_ngay_hl);
        var b_thang_d = $get(b_thangd).value, b_thang_c = $get(b_thangc).value;
        if (b_thang_d != "") {
            b_thang_d = CNG_SO("01/" + b_thang_d);
            if (b_ngay_hl < b_thang_d) {
                form_P_LOI("loi:Ngày hiệu lực không được nhỏ hơn tháng bắt đầu học!:loi");
                return false;
            }
        }
        if (b_thang_c != "") {
            b_thang_c = CNG_SO("01/" + b_thang_c);
            if (b_ngay_hl < b_thang_c) {
                form_P_LOI("loi:Ngày hiệu lực không được nhỏ hơn tháng kết thúc học!:loi");
                return false;
            }
        }
    }
    return true;
}
