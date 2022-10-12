var ns_menu_tbao_ct_lkeCho, b_choAct = 0, b_grlkeId, b_grtdlkeId, b_slidetdId, b_loai, b_tm, b_han, b_lkectId, b_lkecdanhId, b_grlkeId_td, b_grlkeId_hs, b_slideId, b_slideId_td, b_slideId_hs,
    b_tt = '', b_grlkeId_cchn, b_slideId_cchn, b_grlkeId_con, b_slideId_con;
function ns_menu_tbao_ct_P_KD(b_tm) {
    b_tmf = b_tm;

    b_grlkeId = form_Fs_VUNG_ID('GR_lke');
    b_grlkeId_td = form_Fs_VUNG_ID('GR_td');
    b_grlkeId_hs = form_Fs_VUNG_ID('GR_hs');
    b_grlkeId_cchn = form_Fs_VUNG_ID('Gr_lke_cchn');
    b_grctId_cchn = form_Fs_VUNG_ID('Gr_ct_cchn');
    b_grlkeId_con = form_Fs_VUNG_ID('Gr_con');

    b_vungId = form_Fs_VUNG_ID('UPa_ct');
    b_han = form_Fs_TEN_ID(b_vungId, 'NV_SN');

    b_slideId = $get(b_grlkeId).getAttribute('slideId');
    b_slideId_td = $get(b_grlkeId_td).getAttribute('slideId');
    b_slideId_hs = $get(b_grlkeId_hs).getAttribute('slideId');
    b_slideId_cchn = $get(b_grlkeId_cchn).getAttribute('slideId');
    b_slideId_cchn_ct = $get(b_grctId_cchn).getAttribute('slideId');
    b_slideId_con = $get(b_grlkeId_con).getAttribute('slideId');

    ns_menu_tbao_ct_lkeCho = setInterval('ns_menu_tbao_ct_P_LKE_CHO()', 200);

}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            b_loai = a_tso[0];
            //$get(b_han).value = b_loai;
            list_P_DAT(b_han, b_loai);
            if (b_loai == "CCHN") {
                ns_menu_tbao_ct_cchn_P_LKE();
            }
            else if (b_loai == "CON") {
                ns_menu_tbao_ct_con_P_LKE();
            }
            else {
                ns_menu_tbao_ct_P_LKE();
            }
        }
    }
    catch (err) { form_P_LOI(err); }
}
//
function ns_menu_tbao_ct_P_KTRA(b_maTen) {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var a_cot_td = GridX_Fas_tenCot(b_grlkeId_td), a_tso_td = slide_Faobj_TUDEN(b_slideId_td);
        var a_cot_hs = GridX_Fas_tenCot(b_grlkeId_hs), a_tso_hs = slide_Faobj_TUDEN(b_slideId_hs);

        b_maTen = b_maTen.toUpperCase();
        if (b_maTen == null || b_maTen == "") return;
        if (b_maTen == "NV_SN") {
            //b_hann = $get(b_han).value;
            b_hann = form_Fs_TEN_GTRI(b_vungId, 'NV_SN');
            if (b_hann != "" || b_hann != null) {
                if (b_hann == "CCHN") {
                    ns_menu_tbao_ct_cchn_P_LKE();
                }
                else if (b_hann == "CON") {
                    ns_menu_tbao_ct_con_P_LKE();
                }
                else {
                    sns_tt.Fs_MENU_TBAO_CT(form_Fs_nsd(), b_hann, a_cot, a_cot_td, a_cot_hs, a_tso, a_tso_td, a_tso_hs, ns_menu_tbao_ct_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                }
            }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_menu_tbao_ct_GR_lke_cchn_RowChange() {
    try {
        if (b_choAct != 0)
            clearTimeout(b_choAct);
        b_choAct = setTimeout("ns_menu_tbao_ct_cchn_ct_P_CHUYEN_HANG()", 300);
        return false;
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_menu_tbao_ct_cchn_ct_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId_cchn);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId_cchn, b_hang, "ma_cchn"));
        if (b_ma == "") {
            form_P_MOI(b_vungId, "XGL");
            GridX_datTrang(b_grctId_cchn);
        }
        else {
            var a_cot = GridX_Fas_tenCot(b_grctId_cchn);
            var a_tso = slide_Faobj_TUDEN(b_slideId_cchn_ct);

            sns_tt.Fs_MENU_TBAO_CT_CCHN(form_Fs_nsd(), b_ma, a_cot, a_tso, ns_menu_tbao_ct_cchn_ct_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_menu_tbao_ct_cchn_ct_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_loai = form_Fs_TEN_GTRI(b_vungId, 'NV_SN');
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId_cchn_ct, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grctId_cchn, a_kq[1]);
    }
}

//Liệt kê
function ns_menu_tbao_ct_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ns_menu_tbao_ct_lkeCho != 0) clearTimeout(ns_menu_tbao_ct_lkeCho);
        ns_menu_tbao_ct_P_LKE();
    }
}
function ns_menu_tbao_ct_P_LKE() {
    if (b_loai != null && b_loai != undefined && b_loai != "") {
        try {
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            var a_cot_td = GridX_Fas_tenCot(b_grlkeId_td), a_tso_td = slide_Faobj_TUDEN(b_slideId_td);
            var a_cot_hs = GridX_Fas_tenCot(b_grlkeId_hs), a_tso_hs = slide_Faobj_TUDEN(b_slideId_hs);

            b_loai = form_Fs_TEN_GTRI(b_vungId, 'NV_SN');
            sns_tt.Fs_MENU_TBAO_CT(form_Fs_nsd(), b_loai, a_cot, a_cot_td, a_cot_hs, a_tso, a_tso_td, a_tso_hs, ns_menu_tbao_ct_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        catch (err) { form_P_LOI(err); }
    }
    else return false;
}
function ns_menu_tbao_ct_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_loai = form_Fs_TEN_GTRI(b_vungId, 'NV_SN');
        var a_kq = Fas_ChMang(b_kq, '#');
        if (b_loai == "TD") {
            $get("lke_cdanh").style.display = "";
            $get("lke_cb").style.display = "none";
            $get("lke_hs").style.display = "none";
            $get("lke_cchn").style.display = "none";
            $get("lke_con").style.display = "none";
            slide_P_SOTRANG(b_slideId_td, CSO_SO(a_kq[0], 0));
            GridX_datBang(b_grlkeId_td, a_kq[1]);
        } else if (b_loai == "HS") {
            $get("lke_cdanh").style.display = "none";
            $get("lke_cb").style.display = "none";
            $get("lke_hs").style.display = "";
            $get("lke_cchn").style.display = "none";
            $get("lke_con").style.display = "none";
            slide_P_SOTRANG(b_slideId_hs, CSO_SO(a_kq[0], 0));
            GridX_datBang(b_grlkeId_hs, a_kq[1]);
        } else {
            $get("lke_cdanh").style.display = "none";
            $get("lke_cb").style.display = "";
            $get("lke_hs").style.display = "none";
            $get("lke_cchn").style.display = "none";
            $get("lke_con").style.display = "none";
            slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
            GridX_datBang(b_grlkeId, a_kq[1]);
        }
    }
}
function ns_menu_tbao_ct_cchn_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId_cchn);
        var a_tso = slide_Faobj_TUDEN(b_slideId_cchn);
        sns_ma_ch.Fs_NS_TL_CCHN_LKE(a_tso, a_cot, b_tt, ns_menu_tbao_ct_cchn_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_menu_tbao_ct_cchn_P_LKE_KQ(b_kq) {
    try {

        if (Fb_LOI_KTRA(b_kq)) {
            form_P_LOI(b_kq);
            return;
        }
        $get("lke_cdanh").style.display = "none";
        $get("lke_cb").style.display = "none";
        $get("lke_hs").style.display = "none";
        $get("lke_cchn").style.display = "";
        $get("lke_con").style.display = "none";

        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId_cchn, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId_cchn, a_kq[1]);
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_menu_tbao_ct_con_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId_con);
        var a_tso = slide_Faobj_TUDEN(b_slideId_con);
        sns_tt.Fs_MENU_TBAO_CT_CON(form_Fs_nsd(), a_cot, a_tso, ns_menu_tbao_ct_con_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_menu_tbao_ct_con_P_LKE_KQ(b_kq) {
    try {

        if (Fb_LOI_KTRA(b_kq)) {
            form_P_LOI(b_kq);
            return;
        }
        $get("lke_cdanh").style.display = "none";
        $get("lke_cb").style.display = "none";
        $get("lke_hs").style.display = "none";
        $get("lke_cchn").style.display = "none";
        $get("lke_con").style.display = "";

        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId_con, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId_con, a_kq[1]);
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ns_menu_tbao_ct_EXCEL() {
    var b_han_ctr = form_Fctr_TEN_DTUONG(b_vungId, "NV_SN");
    if (b_han_ctr.value == "" || b_han_ctr.value == null) { form_P_LOI("loi:Chưa chọn điều kiện :loi"); return; }
    else {
        __doPostBack('ctl00$ContentPlaceHolder1$Nhap2', '');
    }
}
function P_EXCEL_KQ(b_kq) {
    //?md=TT
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_MO(b_tmf + '/App_form/bc/xexcel.aspx?md=TT', null, null, "C");
}
function form_caidat() {
    var b_tf = form_Fs_TM() + "/App_form/ns/ma/ns_tbao_menu_tlap.aspx";
    form_P_MO(b_tf, null, null, "C");
}

function ns_menu_tbao_ct_CB() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI('loi:Chọn cán bộ:loi'); return false; }
    else {
        var b_so_the = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the");
        var b_tenf = form_Fs_TM('f') + '/ns/tt/ns_cb.aspx';
        form_P_MO(b_tenf, window.name, ["THONGKE", [b_so_the]]);
        return false;
    }
}

function ns_menu_tbao_ct_P_CB() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) {
        form_P_LOI('loi:Chưa chọn cán bộ:loi');
        return false;
    }
    try {
        var b_loaign = form_Fs_TEN_GTRI(b_vungId, 'NV_SN');
        var b_so_the = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the");
        var b_tenf = form_Fs_TM('f') + '/ns/qt/ns_hd.aspx';
        form_P_MO(b_tenf, null, ["CHITIET_HD", [b_so_the]], "");
        form_P_LOI();
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
