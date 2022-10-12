var ns_tl_bluong_sale_lkeCho, ns_tl_bluong_sale_choAct = 0, ns_tl_bluong_sale_lke_CottkCho, ns_tl_bluong_sale_lke_CotCho, b_aphongId, b_akyluongId, b_slideId,
    b_so_the_tkId, b_slide_tkId, b_vungId, b_grlketkId, b_grlkeId, b_grtkId, b_grtmpId, b_grmaId, b_ctyValue, b_ctrbeforId;
function ns_tl_bluong_sale_P_KD() {
    ns_tl_bluong_sale_lkeCho, ns_tl_bluong_sale_lke_CottkCho, ns_tl_bluong_sale_lke_CotCho;
    b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grtkId = form_Fs_VUNG_ID('GR_tk'), b_grtmpId = form_Fs_VUNG_ID('GR_lke'), b_grmaId = form_Fs_VUNG_ID('Gr_ma');
    b_kyluongId = form_Fs_TEN_ID(b_vungId, 'KYLUONG'), b_so_the_tkId = form_Fs_TEN_ID(b_vungId, 'SO_THE_TK');
    b_aphongId = form_Fs_TEN_ID('UPa_hi', 'aphong'), b_akyluongId = form_Fs_TEN_ID('UPa_hi', 'akyluong');
    ns_tl_bluong_sale_lke_CottkCho = setInterval('ns_tl_bluong_sale_P_LKE_KTAO_COTTK_CHO()', 200);
    ns_tl_bluong_sale_lke_CotCho = setInterval('ns_tl_bluong_sale_P_LKE_KTAO_COT_CHO()', 200);
    ns_tl_bluong_sale_lkeCho = setInterval('ns_tl_bluong_sale_P_LKE_KTAO_CHO()', 600);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        if (b_dtuong.indexOf("DAYPHONG") >= 0) {
            b_ctyValue = a_tso[0];
            ns_tl_bluong_sale_P_MOI();
            ns_tl_bluong_sale_P_LKE();
            ns_tl_bluong_sale_tk_P_LKE();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_bluong_sale_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "KYLUONG": b_maId = b_kyluongId; break;
            case "SO_THE_TK": b_maId = b_so_the_tkId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null) return;
        if (b_maTen == "KYLUONG") {
            if (b_ma.value == "") return;
            $get(b_aphongId).value = b_ctyValue;
            $get(b_akyluongId).value = lke_Fs_TRA($get(b_kyluongId));
            ns_tl_bluong_sale_tk_P_LKE(); ns_tl_bluong_sale_P_LKE();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_bluong_sale_P_NAM() {
    try {
        form_P_MOI(b_vungId, "N");
        var b_nam = form_Fs_TEN_GTRI(b_vungId, 'NAM');
        hts_dungchung.Fs_NS_KYLUONG_CHUNG_LKE(form_Fs_nsd(), window.name, b_nam);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_tl_bluong_sale_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
}
// tao grid lương trong kỳ
function ns_tl_bluong_sale_P_LKE_KTAO_COTTK_CHO() {
    if ($get(b_grtkId) != null) {
        clearTimeout(ns_tl_bluong_sale_lke_CottkCho);
        form_F_GOC().P_MENUBf(window.name, 'M');
        vb_cctc_P_SL('', 'D', '0', ' ', ' ', 'T'); //  vb_cctc_P_SL('', 'A', '0', ' ', ' ', 'T'); -- Chỉ hiện đơn vị
        b_ctyValue = "TATCA";
        ns_tl_bluong_sale_P_LKE_KHOITAO_COTTK();
    }
}
function ns_tl_bluong_sale_P_LKE_KHOITAO_COTTK() {
    try {
        // NLD đối tượng bảng lương người lao động
        stl_ch.Fs_NS_TL_BLUONG_COTTK("SALE", ns_tl_bluong_sale_P_LKE_KHOITAO_COTTK_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_bluong_sale_P_LKE_KHOITAO_COTTK_KQ(b_kq) {
    try {
        if (b_kq != "") {
            var b_kqua = Fas_ChMang(b_kq, '#');
            var a_kq = list_Fas_CH(b_kqua[0]);
            var a_kq2 = list_Fas_CH(b_kqua[1]);
            var a_cot = Fas_ChMang(a_kq[1], ','), a_ten = Fas_ChMang(a_kq[0], ','), a_rong = Fas_ChMang(a_kq2[1], ','), a_align = Fas_ChMang(a_kq2[0], ','), a_cotan = [], b_hangkt = GridX_Fi_hangKt(b_grtkId);
            b_grlketkId = ns_khudtk_TAO(a_cot, a_ten, a_rong, a_align, 200, a_cotan, b_hangkt); clearTimeout(ns_tl_bluong_sale_lke_CottkCho);
        }
    }
    catch (err) { form_P_LOI(err); }
}
// tạo grid lương tổng hợp
function ns_tl_bluong_sale_P_LKE_KTAO_COT_CHO() {
    if ($get(b_grtmpId) != null) {
        clearTimeout(ns_tl_bluong_sale_lke_CotCho);
        form_F_GOC().P_MENUBf(window.name, 'M');
        vb_cctc_P_SL('', 'D', '0', ' ', ' ', 'T'); //  vb_cctc_P_SL('', 'A', '0', ' ', ' ', 'T'); -- Chỉ hiện đơn vị
        b_ctyValue = "TATCA";
        ns_tl_bluong_sale_P_LKE_KHOITAO_COT();
    }
}
function ns_tl_bluong_sale_P_LKE_KHOITAO_COT() {
    try {
        // NLD đối tượng bảng lương người lao động
        stl_ch.Fs_NS_TL_BLUONG_COT("SALE", ns_tl_bluong_sale_P_LKE_KHOITAO_COT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_bluong_sale_P_LKE_KHOITAO_COT_KQ(b_kq) {
    try {
        if (b_kq != "") {
            var b_kqua = Fas_ChMang(b_kq, '#');
            var a_kq = list_Fas_CH(b_kqua[0]);
            var a_kq2 = list_Fas_CH(b_kqua[1]);
            var a_cot = Fas_ChMang(a_kq[1], ','), a_ten = Fas_ChMang(a_kq[0], ','), a_rong = Fas_ChMang(a_kq2[1], ','), a_align = Fas_ChMang(a_kq2[0], ','), a_cotan = [], b_hangkt = GridX_Fi_hangKt(b_grtmpId);
            b_grlkeId = ns_khud_TAO(a_cot, a_ten, a_rong, a_align, 200, a_cotan, b_hangkt); clearTimeout(ns_tl_bluong_sale_lke_CotCho);
        }
    }
    catch (err) { form_P_LOI(err); }
}
// lấy kỳ lương 
function ns_tl_bluong_sale_P_LKE_KTAO_CHO() {
    if (document.readyState === 'complete') {
        if ($get(b_grtkId) != null) { clearTimeout(ns_tl_bluong_sale_lkeCho); }
        b_slide_tkId = $get(b_grtkId).getAttribute('slideId');
        b_slideId = $get(b_grtmpId).getAttribute('slideId');
        ns_tl_bluong_sale_P_LKE_KYLUONG();
    }
}
function ns_tl_bluong_sale_P_LKE_KYLUONG() {
    try {
        var b_form = "ns_tl_bluong_sale", b_nam = "DT_NAM", b_thang = "DT_KY";
        hts_dungchung.Fs_NS_CC_KY(form_Fs_nsd(), b_form, b_nam, b_thang, ns_tl_bluong_sale_P_LKE_KYLUONG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_bluong_sale_P_LKE_KYLUONG_KQ(b_kq) {
    if (b_kq != "") {
        form_P_CH_TEXT(b_vungId, b_kq);
        //ns_tl_bluong_sale_P_KTRA("KYLUONG");
    }
}
// liệt kê dữ liệu lương trong kỳ
function ns_tl_bluong_sale_tk_P_LKE() {
    try {
        var b_kyluong = lke_Fs_TRA($get(b_kyluongId));
        if (b_kyluong != null && b_kyluong != "") {
            var b_so_the_tk = $get(b_so_the_tkId).value, b_bluong = "", a_cot2 = GridX_Fas_tenCot(b_grlketkId), a_tso = slide_Faobj_TUDEN(b_slide_tkId);
            if (b_grlketkId === undefined) return;
            stl_ch.Fs_NS_TL_BLUONG_SALE_TK_CT(form_Fs_nsd(), b_ctyValue, b_kyluong, b_so_the_tk, a_cot2, a_tso, ns_tl_bluong_sale_tk_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        } else slide_P_SOTRANG(b_slide_tkId, 0);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_bluong_sale_tk_P_LKE_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slide_tkId, CSO_SO(a_kq[2], 0));
        if (b_kq == "") { GridX_datTrang(b_grlketkId); }
        else {
            if (a_kq[0] == "") GridX_datTrang(b_grlketkId);
            else GridX_datBang(b_grlketkId, a_kq[0]);
        }
    }
    catch (err) { form_P_LOI(err); }
}
// liệt kê dữ liệu lương tổng hợp
function ns_tl_bluong_sale_P_LKE() {
    try {
        var b_kyluong = lke_Fs_TRA($get(b_kyluongId));
        if (b_kyluong != null && b_kyluong != "") {
            var b_so_the_tk = $get(b_so_the_tkId).value, b_bluong = "", a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            if (b_grlkeId === undefined) return;
            stl_ch.Fs_NS_TL_BLUONG_SALE_CT(form_Fs_nsd(), b_ctyValue, b_kyluong, b_so_the_tk, a_cot, a_tso, ns_tl_bluong_sale_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        } else slide_P_SOTRANG(b_slideId, 0);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_bluong_sale_P_LKE_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[2], 0));
        if (b_kq == "") { GridX_datTrang(b_grlkeId); }
        else {
            if (a_kq[0] == "") GridX_datTrang(b_grlkeId);
            else GridX_datBang(b_grlkeId, a_kq[0]);
        }
    }
    catch (err) { form_P_LOI(err); }
}
// đóng mở bảng lương
function ns_tl_bluong_sale_P_MO() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_kyluong = lke_Fs_TRA($get(b_kyluongId));
            stl_ch.Fs_NS_TL_BLUONG_SALE_MO(form_Fs_nsd(), b_ctyValue, b_kyluong, ns_tl_bluong_sale_P_DONGMO_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_bluong_sale_P_DONG() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_kyluong = lke_Fs_TRA($get(b_kyluongId));
            stl_ch.Fs_NS_TL_BLUONG_SALE_DONG(form_Fs_nsd(), b_ctyValue, b_kyluong, ns_tl_bluong_sale_P_DONGMO_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_bluong_sale_P_DONGMO_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    return false;
}
function ns_tl_bluong_sale_P_DONG_VV() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_kyluong = lke_Fs_TRA($get(b_kyluongId));
            stl_ch.Fs_NS_TL_BLUONG_SALE_DONG_VV(form_Fs_nsd(), b_ctyValue, b_kyluong, ns_tl_bluong_sale_P_DONG_VV_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_bluong_sale_P_DONG_VV_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    return false;
}
// tính lương
function ns_tl_bluong_sale_TINH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var b_phong = form_Fs_TEN_GTRI(b_vungId, 'PHONG'),
            b_kyluong = form_Fs_TEN_GTRI(b_vungId, 'KYLUONG');
        var a_cottk = GridX_Fas_tenCot(b_grlketkId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_so_the_tk = $get(b_so_the_tkId).value;
        stl_ch.Fs_NS_TL_BLUONG_SALE_TINH(form_Fs_nsd(), b_ctyValue, b_kyluong, b_so_the_tk, a_cottk, a_cot, ns_tl_bluong_sale_P_TINH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_bluong_sale_P_TINH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == "") {
        form_P_LOI('loi:Tổng hợp dữ liệu thành công:loi');
        return false;
    } else {
        var a_kq = Fas_ChMang(b_kq, '#');
        if (a_kq[0] == "") GridX_datTrang(b_grlkeId);
        else GridX_datBang(b_grlkeId, a_kq[0]);
        if (a_kq[2] == "") GridX_datTrang(b_grlketkId);
        else GridX_datBang(b_grlketkId, a_kq[2]);
        form_P_LOI('loi:Tổng hợp dữ liệu thành công:loi');
    }
    return false;
}
// xuất excel
function ns_tl_bluong_sale_P_IN() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    form_P_LOI(''); return false;
}
// click sơ đồ tổ chức
function vb_cctc_P_CLICK(b_event, b_id) {
    b_event.stopPropagation();
    var b_targetClassNam = b_event.target.className;
    if (b_targetClassNam == "ico_bptt") {
        var b_ctr = $get(b_id), b_div = $get(b_id + '_Div');
        var a_tso = Attribute_Fas_LAY(b_ctr, 'loai,cap,dvi,ma,ma_ct');
        if (b_ctrbeforId != null) b_ctrbeforId.style.fontWeight = "100";
        b_ctr.style.fontWeight = "700";
        b_ctrbeforId = b_ctr;
        b_ctyValue = a_tso[3]; //  b_ctyValue = a_tso[2]; -- Chỉ hiện đơn vị
        ns_tl_bluong_sale_P_KTRA("KYLUONG");
        return false;
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