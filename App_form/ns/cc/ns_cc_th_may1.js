var ns_cc_th_may_lkeCho, ns_cc_th_may_lkecbCho, b_akyluongId, b_aphongId, b_phongId, b_kyluongId,
    ns_cc_th_may_choAct = 0, b_vungId, b_grlkeId, b_grctId, b_mt, b_namId, b_so_theId, b_hotenId,
    b_ctyValue, b_ctrbeforId;;
function ns_cc_th_may_P_KD() {
    ns_cc_th_may_lkeCho, ns_cc_th_may_lkecbCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct');
    b_kyluongId = form_Fs_TEN_ID(b_vungId, 'KYLUONG'), b_phongId = form_Fs_TEN_ID(b_vungId, 'PHONG'), b_namId = form_Fs_TEN_ID(b_vungId, 'NAM');
    b_so_theId = form_Fs_TEN_ID(b_vungId, 'SO_THE'), b_hotenId = form_Fs_TEN_ID(b_vungId, 'HOTEN');
    b_slideId = b_grlkeId + '_slide';
    b_aphongId = form_Fs_TEN_ID('UPa_hi', 'aphong');
    b_akyluongId = form_Fs_TEN_ID('UPa_hi', 'akyluong');
    lke_P_DAT($get(b_phongId), 'TATCA' + '{' + 'Tất cả');
    ns_cc_th_may_lkecbCho = setInterval('ns_cc_th_may_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        if (b_dtuong.indexOf("DAYPHONG") >= 0) {
            lke_Fs_TRA($get(b_phongId)) = a_tso[0];
            ns_cc_th_may_P_LKE('K');
            ns_cc_th_may_P_LKE_CB();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_th_may_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "PHONG": b_maId = b_phongId; break;
            case "SO_THE": b_maId = b_so_theId; break;
            case "HOTEN": b_maId = b_hotenId; break;
            case "KYLUONG": b_maId = b_kyluongId; break;
            case "NAM": b_maId = b_namId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null) return;
        if (b_maTen == "PHONG") {
            $get(b_akyluongId).value = lke_Fs_TRA($get(b_kyluongId));
            $get(b_aphongId).value = b_ctyValue;
            ns_cc_th_may_P_LKE('K');
        } else if (b_maTen == "KYLUONG") {
            $get(b_akyluongId).value = lke_Fs_TRA($get(b_kyluongId));
            $get(b_aphongId).value = b_ctyValue;
            ns_cc_th_may_P_LKE('K');
        }
        if (b_maTen == "SO_THE" || b_maTen == "HOTEN") {
            ns_cc_th_may_P_LKE('K');
        } else if (b_maTen == "SO_THE") {
            ns_cc_th_may_P_LKE('K');
        } else if (b_maTen == "NAM") { form_P_MOI(b_vungId, "G"); var b_nam = form_Fs_TEN_GTRI(b_vungId, 'NAM'); hts_dungchung.Fs_NS_KT_NAM(window.name, b_nam); }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_th_may_EXCEL() {
    var b_kl = lke_Fs_TRA($get(b_kyluongId));
    if (b_kl == "") { form_P_LOI("loi:Chưa chọn kỳ công cần xuất dữ liệu:loi"); return false; }
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function ns_cc_th_may_GR_lke_RowChange() {
    if (ns_cc_th_may_choAct != 0) clearTimeout(ns_cc_th_may_choAct);
    ns_cc_th_may_choAct = setTimeout("ns_cc_th_may_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_cc_th_may_P_CHUYEN_HANG() {
    var b_kyluong = lke_Fs_TRA($get(b_kyluongId));
    if (b_kyluong == null || b_kyluong == "") { form_P_MOI("", "XGL"); ns_cc_th_may_P_LKE_CB(); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId), b_phong = b_ctyValue, b_so_the = $get(b_so_theId).value, b_hoten = $get(b_hotenId).value,
            a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_cc.Fs_NS_CC_TH_MAY_CT(b_phong, b_kyluong, b_so_the, b_hoten, a_cot_ct, a_tso, ns_cc_th_may_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function ns_cc_th_may_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    GridX_dat_hangkt(b_grctId, a_kq[1]);
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[0] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[0]);
}
function ns_cc_th_may_P_CHUYEN_TIEN() {
    try {
        var b_tenf = '<%= this.ResolveUrl("~/App_form/bc/tl_ngbc.aspx") %>',
            b_phong = b_ctyValue,
            b_thang = $get(b_thangId).value,
            b_ten_phong = document.getElementById(b_phongId)[document.getElementById(b_phongId).selectedIndex].innerText;
        if (b_thang == null || b_thang == "") { alert("Chưa chọn chi tiết"); }
        else {
            var b_tso = b_phong + "#" + b_thang + "#" + b_ten_phong;
            form_P_MO(b_tenf, null, ["BL", [b_tso]], null);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_th_may_P_LKE_CB_CHO() {
    if ($get(b_grctId) != null) { clearTimeout(ns_cc_th_may_lkecbCho); ns_cc_th_may_P_LKE_CB(); }
}
function ns_cc_th_may_P_LKE_CB() {
    var b_phong = b_ctyValue,
        b_kyluong = lke_Fs_TRA($get(b_kyluongId));
    var a_cot = GridX_Fas_tenCot(b_grlkeId);
    stl_cc.Fs_NS_CC_TH_MAY_LKE(b_phong, b_kyluong, a_cot, ns_cc_th_may_P_LKE_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function ns_cc_th_may_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ns_cc_th_may_lkecbCho != 0) clearTimeout(ns_cc_th_may_lkecbCho);
        b_slideId = $get(b_grctId).getAttribute('slideId');
        form_F_GOC().P_MENUBf(window.name, 'M');
        vb_cctc_P_SL('', 'D', '0', ' ', ' ', 'T');
        b_ctyValue = "TATCA";
        ns_cc_th_may_CT_KYLUONG();
    }
}
function ns_cc_th_may_CT_KYLUONG() {
    try {
        var b_form = "ns_cc_th_may", b_nam = "DT_NAM", b_thang = "DT_KYLUONG";
        hts_dungchung.Fs_NS_CC_KY(form_Fs_nsd(), b_form, b_nam, b_thang, ns_cc_th_may_KYLUONG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_th_may_KYLUONG_KQ(b_kq) {
    if (b_kq != "") {
        form_P_CH_TEXT(b_vungId, b_kq);
    }
    ns_cc_th_may_P_LKE('K');
}
function ns_cc_th_may_P_LKE(b_dk) {
    if (b_dk == 'C') slide_P_MOI(b_slideId);
    var b_kyluong = lke_Fs_TRA($get(b_kyluongId));

    if (b_kyluong != null && b_kyluong != "") {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId), b_phong = b_ctyValue, b_so_the = $get(b_so_theId).value, b_hoten = $get(b_hotenId).value;
        a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_cc.Fs_NS_CC_TH_MAY_LKE(b_phong, b_kyluong, b_so_the, b_hoten, a_cot_ct, a_tso, ns_cc_th_may_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    } else
        ns_cc_th_may_P_LKE_KQ("");
}
function ns_cc_th_may_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        if (a_kq[0] == "") GridX_datTrang(b_grctId);
        else GridX_datBang(b_grctId, a_kq[1]);
        return false;
    }
}

function ns_cc_th_may_TINH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var b_phong = b_ctyValue,
            b_kyluong = lke_Fs_TRA($get(b_kyluongId));
        var a_cot = GridX_Fas_tenCot(b_grctId), a_tso = slide_Faobj_TUDEN(b_slideId), b_so_the = $get(b_so_theId).value, b_hoten = $get(b_hotenId).value;
        stl_cc.Fs_NS_CC_TH_MAY_TINH(b_phong, b_kyluong, b_so_the, b_hoten, a_cot, a_tso, ns_cc_th_may_P_TINH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_th_may_P_TINH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    if (a_kq[0] == "") GridX_datTrang(b_grctId);
    else GridX_datBang(b_grctId, a_kq[1]);
    form_P_LOI("loi:Tổng hợp dữ liệu thành công:loi");
    return false;
}
function ns_cc_th_may_P_NAM() {
    try {
        var b_nam = form_Fs_TEN_GTRI(b_vungId, 'nam');
        stl_cc.Fs_DANHSACH_KYLUONG_LKE(b_nam, ns_cc_th_may_P_NAM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}

function ns_cc_th_may_P_IN() {
    var a_cot = GridX_Fdt_cotGtri(b_grctId);
    var b_ma_bc = 'ns_ns_cc_th_may.xml',
        b_ddan = '~/Templates/ns/', a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
    var b_kieu_in = 'E', b_ten_rp = b_ma_bc;
    var a_dt = GridX_Fdt_cotGtri(b_grctId);
    if (b_ten_rp == "") { form_P_LOI('Chưa chọn đúng báo cáo'); return; }
    sti_ch.Fs_EXCEL_TIENLUONG("ns_ngbc", "TT", b_ma_bc, b_ddan, b_ten_rp, b_kieu_in, a_dt_ct, a_dt, P_EXCEL_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function P_EXCEL_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_MO(form_Fs_TM() + '/App_form/bc/xexcel.aspx?md=TT', null, null, "C");
}
function GridX_dat_hangkt(b_gridx, sodong) {
    try {
        var b_grid = $get(b_gridx);
        b_grid.setAttribute('hangKt', '21');
        var b_hangkt = GridX_Fi_hangKt(b_gridx);
        if (sodong > b_hangkt) {
            b_grid.setAttribute('hangKt', sodong - b_hangkt + 22);
        }
        return false;
    } catch (err) { form_P_LOI(err); }
}
function ns_cc_th_may_phong() {
    try {
        var b_tenf = form_Fs_TM() + '/App_form/ht/ht_maph.aspx';
        form_P_MO(b_tenf, null, ["ns_cc_th_may", [""]]);
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
        $get(b_akyluongId).value = lke_Fs_TRA($get(b_kyluongId));
        $get(b_aphongId).value = b_ctyValue;
        ns_cc_th_may_P_LKE('K');
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