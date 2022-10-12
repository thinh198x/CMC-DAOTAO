var ns_tl_pcap_ds_lkeCho, b_vungId, b_grlkeId, b_slideId, b_so_theId, b_so_idId, ns_tl_pcap_ds_choAct = 0;
function ns_tl_pcap_ds_P_KD() {
    ns_tl_pcap_ds_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grctId = form_Fs_VUNG_ID('GR_ct');
    b_slideId = b_grlkeId + '_slide';
    b_so_theId = form_Fs_TEN_ID(b_vungId, 'SO_THE'); b_thangId = form_Fs_TEN_ID(b_vungId, 'THANG');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
}
var b_cho_control = 0;
function P_cho(b_so_the, b_ten) {
    try {
        if (b_doi == 0) {
            $get(b_so_theId).value = b_so_the;
            $get(b_gchuId).innerHTML = b_ten;
            $get(b_so_theId).focus();
            ns_tl_pcap_ds_P_CHUYEN_HANG();
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
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "')", 200);
        }
        else if (b_dtuong.indexOf("MA") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang > -1) {
                GridX_datGtri(b_grctId, b_hang, "ma", b_kq);
                GridX_datGtri(b_grctId, b_hang, "ten", a_tso[1]);
                GridX_datA(b_grctId, b_hang, "kinhnghiem");
            }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_pcap_ds_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_mt = b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_so_theId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        else if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(),"Mã cán bộ", b_ma.value, "ns_cb,so_the,ten", ns_tl_pcap_ds_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_tl_pcap_ds_P_CHUYEN_HANG();
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_tl_pcap_ds_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_mt == "MA") {
        var b_hang = GridX_Fi_timHangA(b_grctId);
        GridX_datGtri(b_grctId, b_hang, "ten", b_kq);
        GridX_datA(b_grctId, b_hang, "kinhnghiem");
    }
    if (b_mt == "SO_THE") {
        $get(b_gchuId).innerHTML = b_kq;
    }
}
function ns_tl_pcap_ds_P_CHUYEN_HANG() {
    var b_so_the = $get(b_so_theId).value;
    if (b_so_the == null || b_so_the == "") { return false }
    else {
        var b_thang = $get(b_thangId).value;
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        stl_ch.Fs_TL_TN_PCAP_DSACH(b_so_the,b_thang, a_cot_ct, ns_tl_pcap_ds_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function ns_tl_pcap_ds_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    //var a_kq = b_kq.split('#');
    //form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (b_kq == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, b_kq);
    return false;
}
