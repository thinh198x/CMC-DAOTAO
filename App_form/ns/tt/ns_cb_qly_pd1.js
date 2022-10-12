var b_lkeCho = 0, b_choAct = 0, b_manv, b_vungId, b_vungNhapId, b_download1, b_download2, b_ma_dvi, b_so_id_qh, b_grlkeId_syll, b_slideId_syll, b_grlkeId_qtct, b_slideId_qtct, b_grlkeId_bccm, b_slideId_bccm, b_grlkeId_qhnt, b_slideId_qhnt, b_gocId;

function ns_cb_qly_pd_P_KD(b_nsd) {
    b_manv = b_nsd;
    b_lkeCho = setInterval('ns_cb_qly_pd_P_LKE_CHO()', 200);

}
function ns_cb_qly_pd_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(b_lkeCho);
        b_grlkeId_syll = form_Fs_VUNG_ID('GR_syll'); b_slideId_syll = $get(b_grlkeId_syll).getAttribute('slideId');
        b_grlkeId_qtct = form_Fs_VUNG_ID('GR_qtct'); b_slideId_qtct = $get(b_grlkeId_qtct).getAttribute('slideId');
        b_grlkeId_bccm = form_Fs_VUNG_ID('GR_bccm'); b_slideId_bccm = $get(b_grlkeId_bccm).getAttribute('slideId');
        b_grlkeId_cc = form_Fs_VUNG_ID('GR_cc'); b_slideId_cc = $get(b_grlkeId_cc).getAttribute('slideId');
        b_grlkeId_qhnt = form_Fs_VUNG_ID('GR_qhnt'); b_slideId_qhnt = $get(b_grlkeId_qhnt).getAttribute('slideId');
        b_vungNhapId = form_Fs_VUNG_ID('UPa_nhap'); b_download1 = form_Fs_TEN_ID(b_vungNhapId, 'download');
        b_download2 = form_Fs_TEN_ID(b_vungNhapId, 'download2');
        $get(b_download1).style.display = "";
        $get(b_download2).style.display = "none";
        ns_cb_qly_pd_P_LKE();
    }
}
function ns_cb_qly_pd_P_LKE() {
    try {
        var a_cot_syll = GridX_Fas_tenCot(b_grlkeId_syll), a_tso_syll = slide_Faobj_TUDEN(b_slideId_syll), b_so_the = b_manv;
        var a_cot_qtct = GridX_Fas_tenCot(b_grlkeId_qtct), a_tso_qtct = slide_Faobj_TUDEN(b_slideId_qtct);

        var a_cot_bccm = GridX_Fas_tenCot(b_grlkeId_bccm), a_tso_bccm = slide_Faobj_TUDEN(b_slideId_bccm);
        var a_cot_cc = GridX_Fas_tenCot(b_grlkeId_cc), a_tso_cc = slide_Faobj_TUDEN(b_slideId_cc);
        var a_cot_qhnt = GridX_Fas_tenCot(b_grlkeId_qhnt), a_tso_qhnt = slide_Faobj_TUDEN(b_slideId_qhnt);
        sns_hs.Fs_NS_CB_QL_PD_LKE(b_so_the, a_tso_syll, a_cot_syll, a_cot_qtct, a_cot_bccm, a_cot_cc, a_cot_qhnt, ns_cb_qly_pd_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_cb_qly_pd_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId_syll, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId_syll, a_kq[1]);
        slide_P_SOTRANG(b_slideId_qtct, CSO_SO(a_kq[2], 0)); GridX_datBang(b_grlkeId_qtct, a_kq[3]);
        slide_P_SOTRANG(b_slideId_bccm, CSO_SO(a_kq[4], 0)); GridX_datBang(b_grlkeId_bccm, a_kq[5]);
        slide_P_SOTRANG(b_slideId_cc, CSO_SO(a_kq[6], 0)); GridX_datBang(b_grlkeId_cc, a_kq[7]);
        slide_P_SOTRANG(b_slideId_qhnt, CSO_SO(a_kq[8], 0)); GridX_datBang(b_grlkeId_qhnt, a_kq[9]);

    }
}

function ns_cb_qly_pd_P_DUYET() {
    try {
        var a_cot_syll = GridX_Fas_tenCot(b_grlkeId_syll), a_tso_syll = slide_Faobj_TUDEN(b_slideId_syll), b_so_the = b_manv;
        var a_cot_qtct = GridX_Fas_tenCot(b_grlkeId_qtct), a_tso_qtct = slide_Faobj_TUDEN(b_slideId_qtct);

        var a_cot_bccm = GridX_Fas_tenCot(b_grlkeId_bccm), a_tso_bccm = slide_Faobj_TUDEN(b_slideId_bccm);
        var a_cot_cc = GridX_Fas_tenCot(b_grlkeId_cc), a_tso_cc = slide_Faobj_TUDEN(b_slideId_cc);
        var a_cot_qhnt = GridX_Fas_tenCot(b_grlkeId_qhnt), a_tso_qhnt = slide_Faobj_TUDEN(b_slideId_qhnt);
        var a_dt_hs = GridX_Fdt_cotGtri(b_grlkeId_syll), a_dt_congtac = GridX_Fdt_cotGtri(b_grlkeId_qtct), a_dt_bccm = GridX_Fdt_cotGtri(b_grlkeId_bccm),
            a_dt_qhnt = GridX_Fdt_cotGtri(b_grlkeId_qhnt), a_dt_cc = GridX_Fdt_cotGtri(b_grlkeId_cc);
        sns_hs.Fs_NS_CB_QL_PD_DUYET(b_so_the, a_tso_syll, a_cot_syll, a_cot_qtct, a_cot_bccm, a_cot_cc, a_cot_qhnt, a_dt_hs, a_dt_congtac, a_dt_bccm, a_dt_cc, a_dt_qhnt, ns_cb_qly_pd_P_DUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_cb_qly_pd_P_DUYET_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI("loi:Phê duyệt thành công!:loi");
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId_syll, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId_syll, a_kq[1]);
        slide_P_SOTRANG(b_slideId_qtct, CSO_SO(a_kq[2], 0)); GridX_datBang(b_grlkeId_qtct, a_kq[3]);
        slide_P_SOTRANG(b_slideId_bccm, CSO_SO(a_kq[4], 0)); GridX_datBang(b_grlkeId_bccm, a_kq[5]);
        slide_P_SOTRANG(b_slideId_cc, CSO_SO(a_kq[6], 0)); GridX_datBang(b_grlkeId_cc, a_kq[7]);
        slide_P_SOTRANG(b_slideId_qhnt, CSO_SO(a_kq[8], 0)); GridX_datBang(b_grlkeId_qhnt, a_kq[9]);
    }
}

function ns_cb_qly_pd_P_KO_DUYET() {
    try {
        var a_cot_syll = GridX_Fas_tenCot(b_grlkeId_syll), a_tso_syll = slide_Faobj_TUDEN(b_slideId_syll), b_so_the = b_manv;
        var a_cot_qtct = GridX_Fas_tenCot(b_grlkeId_qtct), a_tso_qtct = slide_Faobj_TUDEN(b_slideId_qtct);

        var a_cot_bccm = GridX_Fas_tenCot(b_grlkeId_bccm), a_tso_bccm = slide_Faobj_TUDEN(b_slideId_bccm);
        var a_cot_cc = GridX_Fas_tenCot(b_grlkeId_cc), a_tso_cc = slide_Faobj_TUDEN(b_slideId_cc);
        var a_cot_qhnt = GridX_Fas_tenCot(b_grlkeId_qhnt), a_tso_qhnt = slide_Faobj_TUDEN(b_slideId_qhnt);
        var a_dt_hs = GridX_Fdt_cotGtri(b_grlkeId_syll), a_dt_congtac = GridX_Fdt_cotGtri(b_grlkeId_qtct), a_dt_bccm = GridX_Fdt_cotGtri(b_grlkeId_bccm),
            a_dt_qhnt = GridX_Fdt_cotGtri(b_grlkeId_qhnt), a_dt_cc = GridX_Fdt_cotGtri(b_grlkeId_cc);
        sns_hs.Fs_NS_CB_QL_PD_KO_DUYET(b_so_the, a_tso_syll, a_cot_syll, a_cot_qtct, a_cot_bccm, a_cot_cc, a_cot_qhnt, a_dt_hs, a_dt_congtac, a_dt_bccm, a_dt_cc, a_dt_qhnt, ns_cb_qly_pd_P_KO_DUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_cb_qly_pd_P_KO_DUYET_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI("loi:Không Phê duyệt thành công!:loi");
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId_syll, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId_syll, a_kq[1]);
        slide_P_SOTRANG(b_slideId_qtct, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId_qtct, a_kq[2]);
        slide_P_SOTRANG(b_slideId_bccm, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId_bccm, a_kq[3]);
        slide_P_SOTRANG(b_slideId_cc, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId_cc, a_kq[4]);
        slide_P_SOTRANG(b_slideId_qhnt, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId_qhnt, a_kq[5]);
    }
}
function ns_cb_qly_pd_P_Download() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId_syll);
        if (b_hang < 1) { form_P_LOI("loi:Chưa có file đính kèm:loi"); return false; }
        var b_url = C_NVL(GridX_Fas_layGtri(b_grlkeId_syll, b_hang, "url"));
        var b_href = window.location.href.toString();
        var b_path = window.location.pathname.toString();
        var b_host = b_href.substring(0, b_href.length - b_path.length);
        if (b_url == "") { form_P_LOI("loi:Chưa có file đính kèm:loi"); return false; }
        b_url = b_host + form_Fs_TM() + "/file_import/" + b_url;
        window.open(b_url, null, null, null);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_cb_qly_pd_P_Download_QHTN() {
    try {
        var b_tenf = '/App_form/ns/ma/file_Import_chung.aspx';
        form_P_MO(b_tenf, window.name, ["THAMSO", ["ns_qhe_tt", b_so_id_qh, "Quanhe_nhanthan", "Quan hệ nhân thân"]], null);
        form_P_LOI('');
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
var file_import_choAct = 0;
function ns_cb_qly_pd_GR_lke_RowChange() {
    if (file_import_choAct != 0) clearTimeout(file_import_choAct);
    file_import_choAct = setTimeout("ns_cb_qly_pd_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_cb_qly_pd_GR_khac_RowChange() {
    // $get(b_download1).style.display = "none";
    //$get(b_download2).style.display = "none";
    return false;
}

function ns_cb_qly_pd_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId_syll);
        if (b_hang < 1) return;
        var b_url = C_NVL(GridX_Fas_layGtri(b_grlkeId_syll, b_hang, "url")),
            b_ten = C_NVL(GridX_Fas_layGtri(b_grlkeId_syll, b_hang, "ten"));
        $get(b_download1).style.display = "";
        $get(b_download2).style.display = "none";

        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cb_qly_pd_GR_qtct_RowChange() {
    ns_cb_qly_pd_GR_qtct_P_CHUYEN_HANG();
}

function ns_cb_qly_pd_GR_qtct_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId_qhnt);
        if (b_hang < 1) return;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId_qhnt, b_hang, "so_id"));
        b_so_id_qh = b_so_id;
        $get(b_download1).style.display = "none";
        $get(b_download2).style.display = "";
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function form_dong() {
    location.reload(false);
}