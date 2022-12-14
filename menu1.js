var b_tmId, b_gocId, b_phuId, b_barId;
function menu_KD(tm) {
    window.form_modal = true; form_P_TM(tm); b_tmId = form_Fs_VTEN_ID('', 'tm');
    b_gocId = form_Fs_VUNG_ID('div_goc'); b_phuId = form_Fs_VUNG_ID('div_phu'); b_barId = form_Fs_VUNG_ID('div_bar');
    menu_BAR();
}
function P_KTRA_QU(b_file) {
    try {
        b_file = $get(b_tmId).value + "/" + b_file;
        skhud.Fs_KTRA_QU(window.name, b_file, P_KTRA_QU_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); P_LOGIN(); }
}
function P_KTRA_QU_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); P_LOGIN(); }
    else {
        $get(b_gocId).innerHTML = $get(b_phuId).innerHTML = "";
        if (C_NVL($get(b_barId).innerHTML) == "") P_BAR(); else P_MENU('0');
    }
}
function P_LOGIN() {
    try { form_P_DONG("", null); location.reload(false); }
    catch (err) { }
}
function menu_BAR() {
    try {
        var b_x = 0, b_rong = 130;
        skhud.Fs_BAR(window.name, b_x, b_rong, menu_BAR_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); P_LOGIN(); }
}
function menu_BAR_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
        else {
            $get(b_gocId).innerHTML = $get(b_phuId).innerHTML = "";
            $get(b_barId).innerHTML = b_kq;
        }
    }
    catch (err) { form_P_LOI(err); P_LOGIN(); }
}
function P_MENU(b_ma) {
    try {
        if (b_ma.indexOf("login") >= 0) P_LOGIN();
        else {
            var b_div_goc = $get(b_gocId);
            var b_pos = Sys.UI.DomElement.getBounds(b_div_goc);
            var b_x = menu_Fi_TAB(), b_y = b_pos.y, b_rong = 135, b_cao = 24, b_tm = form_Fs_TM();
            skhud.Fs_MENU(window.name, b_ma, b_x, b_y, b_rong, b_cao, screen.availWidth, b_tm, P_MENU_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); P_LOGIN(); }
}
function P_MENU_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        var a_kq = Fas_ChMang(b_kq, "#");
        var b_tkhao = a_kq[0], b_tso = a_kq[1], b_div = $get(b_gocId);
        b_kq = b_kq.substr(b_tkhao.length + b_tso.length + 2);
        if (C_NVL(b_div.innerHTML) == "") b_div.innerHTML = b_kq;
        else $get(b_phuId).innerHTML = b_kq;
        if (b_tkhao != "") {
            var a_tso = (b_tso != "") ? ["THAMSO", Fas_ChMang(b_tso, ",")] : null;
            form_P_MO(b_tkhao, null, a_tso);
        }
    }
    catch (err) { form_P_LOI(err); P_LOGIN(); }
}
function menu_Fi_TAB() {
    var a_ctr = $get(b_barId).getElementsByTagName("span"), b_css = "", b_i = 0;
    for (var i = 0; i < a_ctr.length; i++) {
        b_css = C_NVL(a_ctr[i].className);
        if (a_ctr[i].id.indexOf("login") < 0 && b_css != "") {
            b_i = b_css.lastIndexOf("_"); b_css = b_css.substr(b_i);
            if (b_css == "_ac") return CSO_SO(a_ctr[i].getAttribute("trai"), 0);
        }
    }
    return 0;
}
