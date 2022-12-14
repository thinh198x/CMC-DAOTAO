var ns_phucloi_cn_lkeCho, b_vungId, b_vung_tk_Id, b_vung_tl_Id, b_grlkeId, b_slideId, b_gocId, b_plId, b_lblNam_Id, b_namId, b_lblKyLuong_Id, b_kyluongId, b_sotienId, b_cDanhId, b_phongId, b_tlId, b_tenId, b_tuoiId,
    b_so_idId, b_gchuId, b_moiId, b_luong_chiuthue_Id, b_luong_khongchiuthue_Id, b_phong_tk_Id, b_ctyValue, b_ctrbeforId, b_so_the_tk_Id, b_hoten_tk_Id, b_ma_phong_Id, b_doi = 0, b_cho_control = 0,  ns_phucloi_cn_choAct = 0, b_nsd;
function ns_phucloi_cn_P_KD() { 
    ns_phucloi_cn_lkeCho = setInterval('ns_phucloi_cn_P_LKE_CHO()', 200); 
}
function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_gocId).value = b_so_the;
            $get(b_tenId).value = b_ten;
            $get(b_phongId).value = b_phong;
            $get(b_gchuId).innerHTML = b_ten;
            $get(b_gocId).focus();
            ns_phucloi_cn_P_LKE('K');
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
            $get(b_gocId).value = a_tso[0];
            $get(b_tenId).value = a_tso[1];
            $get(b_phongId).value = a_tso[2];
            $get(b_cDanhId).value = a_tso[6];           
        }
        else if (b_dtuong.indexOf("DAYPHONG") >= 0) {
            var b_phong_tk = form_Fctr_TEN_DTUONG(b_vung_tk_Id, 'dr_phongban');
            lke_P_DAT(b_phong_tk, a_tso[0] + "{" + a_tso[1]);
            $get(b_ma_phong_Id).value = a_tso[0];
        }        
    }
    catch (err) { form_P_LOI(err); }
}
function ns_phucloi_cn_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId;
                break;
            case "MAPL": b_maId = b_plId;
                break;
            case "TINHLUONG": b_maId = b_tlId; break;
            case "NAM": b_maId = b_namId; break;
            case "LUONG_CHIUTHUE": b_maId = b_luong_chiuthue_Id; break;
            case "LUONG_KHONGCHIUTHUE": b_maId = b_luong_khongchiuthue_Id; break;
            case "DR_PHONGBAN": b_maId = b_phong_tk_Id; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || (b_maTen != 'LUONG_CHIUTHUE' && b_maTen != 'LUONG_KHONGCHIUTHUE' && C_NVL(b_ma.value) == "")) return;
        if (b_maTen == "SO_THE") { 
            ns_phucloi_cn_P_TTNV();
            $get(b_plId).focus();
        } 
        else if (b_maTen == "LUONG_CHIUTHUE" || b_maTen == "LUONG_KHONGCHIUTHUE") {
            if (b_maTen == "LUONG_CHIUTHUE" && $get(b_luong_chiuthue_Id).value == 'X')
                $get(b_luong_khongchiuthue_Id).value = "";
            else if (b_maTen == "LUONG_KHONGCHIUTHUE" && $get(b_luong_khongchiuthue_Id).value == 'X')
                $get(b_luong_chiuthue_Id).value = "";
            var tinhLuong = $get(b_luong_chiuthue_Id).value == 'X' || $get(b_luong_khongchiuthue_Id).value == 'X';
            ns_phucloi_cn_P_Show_TL(tinhLuong);            
        }
        else if (b_maTen == "NAM") {
            if (b_ma.value == "") {
                $get(b_kyluongId).value = null;
            }
            else {
                ns_danhsach_P_NAM();
            }
        }
        else if (b_maTen == "DR_PHONGBAN") {
            $get(b_ma_phong_Id).value = lke_Fs_TRA(b_maId);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_phucloi_cn_P_TTNV() {
    var b_so_the = C_NVL($get(b_gocId).value);
    hts_dungchung.Fs_THONGTIN_CANBO(b_so_the, ns_phucloi_cn_P_TTNV_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function ns_phucloi_cn_P_TTNV_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        b_kq = b_kq.replace("HO_TEN", "TEN").replace("TEN_CDANH", "CDANH").replace("TEN_PHONG", "PHONG");
        form_P_CH_TEXT(b_vungId, b_kq);
    } 
}
function ns_danhsach_P_NAM() {
    try {
        var b_nam = form_Fs_TEN_GTRI(b_vungId, 'nam');
        if (b_nam == "") {
            $get(b_kyluongId).value = null;
        }
        else{
            stl_cc.Fs_DANHSACH_KYLUONG_DR(window.name, b_nam, ns_danhsach_P_KYLUONG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_danhsach_P_KYLUONG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);   
}
function ns_phucloi_cn_P_MA_KTRA2(so_the) {
    try {
        var b_ma = so_the;
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_tt.Fs_NS_PHUCLOI_CN_MA(b_ma, b_TrangKt, a_cot, ns_phucloi_cn_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_phucloi_cn_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_tt.Fs_NS_PHUCLOI_CN_MA(b_ma,b_TrangKt, a_cot, ns_phucloi_cn_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_phucloi_cn_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_MOI(b_vungId, "GXL");
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        form_P_MOI(b_vungId, "GXL"); $get(b_so_idId).value = "0";
        $get(b_tlId).selectedIndex = 0;
    }
    else { GridX_datA(b_grlkeId, b_hang); ns_phucloi_cn_P_CHUYEN_HANG(); }
}
function ns_phucloi_cn_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}
function ns_phucloi_cn_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    ns_phucloi_cn_P_Show_TL(false);
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = "0";
    $get(b_gocId).focus();
    return false;
}
function ns_phucloi_cn_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
            var b_so_id = $get(b_so_idId).value, b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var b_phong = lke_Fs_TRA(b_phong_tk_Id), b_so_the = C_NVL($get(b_so_the_tk_Id).value), b_ten = C_NVL($get(b_hoten_tk_Id).value);
            sns_tt.Fs_NS_PHUCLOI_CN_NH(b_nsd, b_ctyValue, b_so_the, b_ten, b_so_id, b_TrangKt, a_dt_ct, a_cot_lke, ns_phucloi_cn_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_phucloi_cn_NH_KQ(b_kq) {
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
    return false;
}
function ns_phucloi_cn_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); ns_phucloi_cn_P_MOI(); }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_phong = lke_Fs_TRA(b_phong_tk_Id), b_so_the = C_NVL($get(b_so_the_tk_Id).value), b_ten = C_NVL($get(b_hoten_tk_Id).value);
        sns_tt.Fs_NS_PHUCLOI_CN_XOA(b_nsd, b_ctyValue, b_so_the, b_ten, b_so_id, a_tso, a_cot, ns_phucloi_cn_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_phucloi_cn_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_dong = CSO_SO(a_kq[0], 0);
        slide_P_SOTRANG(b_slideId, b_dong);
        GridX_datBang(b_grlkeId, a_kq[1]);
        if (b_hang > b_dong) b_hang = b_dong;
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_phucloi_cn_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_phucloi_cn_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
}
function ns_phucloi_cn_GR_lke_RowChange() {
    if (ns_phucloi_cn_choAct != 0) clearTimeout(ns_phucloi_cn_choAct);
    ns_phucloi_cn_choAct = setTimeout("ns_phucloi_cn_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_phucloi_cn_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "") { ns_phucloi_cn_P_MOI(); GridX_datA(b_grlkeId, b_hang); return; }
    else sns_tt.Fs_NS_PHUCLOI_CN_CT(b_nsd, b_so_id, ns_phucloi_cn_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = b_so_id;
}
function ns_phucloi_cn_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    var tinhLuong = $get(b_luong_chiuthue_Id).value == 'X' || $get(b_luong_khongchiuthue_Id).value == 'X';
    ns_phucloi_cn_P_Show_TL(tinhLuong);
}
function ns_phucloi_cn_P_LKE_CHO() { 
    if (document.readyState === 'complete') {
        if (ns_phucloi_cn_lkeCho != 0) clearTimeout(ns_phucloi_cn_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vung_tk_Id = form_Fs_VUNG_ID('UPa_tk'),
        b_vung_tl_Id = form_Fs_VUNG_ID('UPa_tl'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE'),
        b_lblNam_Id = "ctl00_ContentPlaceHolder1_lblNam",
        b_namId = form_Fs_TEN_ID(b_vungId, 'nam'),
        b_lblKyLuong_Id = "ctl00_ContentPlaceHolder1_lblKyLuong",
        b_kyluongId = form_Fs_TEN_ID(b_vungId, 'kyluong'),
        b_tenId = form_Fs_TEN_ID(b_vungId, 'ten'),
        b_plId = form_Fs_TEN_ID(b_vungId, 'LOAI_PL'),
        b_sotienId = form_Fs_TEN_ID(b_vungId, 'SOTIEN'),
        b_cDanhId = form_Fs_TEN_ID(b_vungId, 'cdanh'),
        b_phongId = form_Fs_TEN_ID(b_vungId, 'phong'),
        b_luong_chiuthue_Id = form_Fs_TEN_ID(b_vungId, 'luong_chiuthue'),
        b_luong_khongchiuthue_Id = form_Fs_TEN_ID(b_vungId, 'luong_khongchiuthue'),
        b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
        b_ma_phong_Id = form_Fs_VTEN_ID('UPa_hi', 'ma_phong');
        b_gchuId = form_Fs_VTEN_ID('', 'gchu');
        b_moiId = form_Fs_VTEN_ID('', 'moi');
        b_phong_tk_Id = form_Fs_TEN_ID(b_vung_tk_Id, 'dr_phongban');
        b_so_the_tk_Id = form_Fs_TEN_ID(b_vung_tk_Id, 'so_the_tk');
        b_hoten_tk_Id = form_Fs_TEN_ID(b_vung_tk_Id, 'hoten_tk');
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        b_nsd = form_Fs_nsd();
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        form_F_GOC().P_MENUBf(window.name, 'M');
        vb_cctc_P_SL('', 'D', '0', ' ', ' ', 'T');
        b_ctyValue = "TATCA";
        ns_phucloi_cn_P_Show_TL(false);
        ns_phucloi_cn_P_LKE('K');
    } 
}
function ns_phucloi_cn_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_phong = lke_Fs_TRA(b_phong_tk_Id), b_so_the = C_NVL($get(b_so_the_tk_Id).value), b_ten = C_NVL($get(b_hoten_tk_Id).value);       
        sns_tt.Fs_NS_PHUCLOI_CN_LKE(b_nsd, b_ctyValue, b_so_the, b_ten, a_tso, a_cot, ns_phucloi_cn_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_phucloi_cn_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    return false;
}
function ns_phucloi_cn_P_Show_TL(show) {
    $get(b_kyluongId).style.display = show ? "inline" : "none";
    $get(b_namId).style.display = show ? "inline" : "none";
    $get(b_lblNam_Id).style.display = show ? "inline" : "none";
    $get(b_lblKyLuong_Id).style.display = show ? "inline" : "none";  
}
function ns_phucloi_cn_P_Phong() {
    try {
        var b_tenf = form_Fs_TM() + '/App_form/ht/ns_hs_cctc_quyen.aspx';
        form_P_MO(b_tenf, null, [window.name, [""]]);
        return false;
    }
    catch (err) { }
}
function vb_cctc_P_CLICK(b_event, b_id) {
    b_event.stopPropagation();
    var b_targetClassNam = b_event.target.className;
    if (b_targetClassNam == "ico_bptt") {
        var b_ctr = $get(b_id), b_div = $get(b_id + '_Div');
        var a_tso = Attribute_Fas_LAY(b_ctr, 'loai,cap,dvi,ma,ma_ct');
        if (b_ctrbeforId != null) b_ctrbeforId.style.fontWeight = "100";
        b_ctr.style.fontWeight = "700";
        b_ctrbeforId = b_ctr;
        b_ctyValue = a_tso[3];
        ns_phucloi_cn_P_LKE('K'); return false;
    }
    else {
        var b_ctr = $get(b_id), b_div = $get(b_id + '_Div');
        var a_tso = Attribute_Fas_LAY(b_ctr, 'loai,cap,dvi,ma,ma_ct');
        if (a_tso[0] == 'A') return false;
        if (a_tso[0] != 'C') {
            if (b_div == null) vb_cctc_P_SL(b_id, a_tso[0], a_tso[1], a_tso[2], a_tso[3]);
            else {
                b_id = (C_NVL(b_div.style.display) == '') ? '' : b_id;
                vb_cctc_HIEN(a_tso[4], b_id);
            }
        }
    }
    return false;
}
function form_dong() {
    location.reload(false);
}