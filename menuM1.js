var b_lkeCho, b_tmId, b_gocId, b_duId, b_phuId, b_qly_dviId, b_nv = 'C', b_duX = true, form_nsd = '';
function menu_KD(tm) {
    form_P_TM(tm); b_tmId = form_Fs_VTEN_ID('', 'tm');
    b_gocId = form_Fs_VUNG_ID('td_goc'); b_phuId = form_Fs_VUNG_ID('div_phu'); b_duId = form_Fs_VUNG_ID('td_dung');
    b_lblnvuId = form_Fs_VTEN_ID('', 'lblnvu');
    b_qly_dviId = form_Fs_VTEN_ID('', 'qly_dvi');
    b_td_dungId = form_Fs_VUNG_ID('td_dung');
    b_td_tbId = form_Fs_VUNG_ID('td_tb');
    b_lkeCho = setInterval('menu_CHO()', 200);
}
function menu_CHO() {
    if (form_nsd != '') { clearInterval(b_lkeCho); P_MENUC(); }
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        alert("1");
        return false;
    } catch (ex) { form_P_LOI(ex.message); }
}
function P_REMOVE_ACTIVE() {
    $get("MENUQL").className = "";
    $get("MENUTT").className = "";
    $get("MENUCN").className = "";
    $get("MENUBC").className = "";
}
function menu_P_MENU(b_dk) {
    P_REMOVE_ACTIVE();
    if (b_dk == 'C') {
        form_Fctr_TENVUNG('td_ct').className = "css_MctAc";
        form_Fctr_TENVUNG('td_bc').className = "css_Mbc";
        form_Fctr_TENVUNG('td_ld').className = "css_Mld";
        form_Fctr_TENVUNG('td_nv').className = "css_Mnv";
        form_Fctr_TENVUNG('td_Mdau').className = "css_MdauC";
        $get(b_lblnvuId).innerHTML = "NGHIỆP VỤ THƯỜNG DÙNG";
        $get(b_td_tbId).style.display = "none";
        $get(b_td_dungId).style.display = "table-row";
        P_KTRA_QU('ctmenu');
        $get("MENUTT").className = "active";
    }
    else if (b_dk == 'B') {
        form_Fctr_TENVUNG('td_ct').className = "css_Mct";
        form_Fctr_TENVUNG('td_bc').className = "css_MbcAc";
        form_Fctr_TENVUNG('td_ld').className = "css_Mld";
        form_Fctr_TENVUNG('td_nv').className = "css_Mnv";
        form_Fctr_TENVUNG('td_Mdau').className = "css_MdauC";
        $get(b_lblnvuId).innerHTML = "NGHIỆP VỤ THƯỜNG DÙNG";
        $get(b_td_tbId).style.display = "none";
        $get(b_td_dungId).style.display = "table-row";
        P_KTRA_QU('bcmenu');
        $get("MENUBC").className = "active";
    }
    else if (b_dk == 'L') {
        form_Fctr_TENVUNG('td_ct').className = "css_Mct";
        form_Fctr_TENVUNG('td_bc').className = "css_Mbc";
        form_Fctr_TENVUNG('td_ld').className = "css_MldAc";
        form_Fctr_TENVUNG('td_nv').className = "css_Mnv";
        form_Fctr_TENVUNG('td_Mdau').className = "css_MdauC";
        var b = $get(b_lblnvuId).innerHTML;
        $get(b_lblnvuId).innerHTML = "THÔNG BÁO";
        $get(b_td_dungId).style.display = "none";
        $get(b_td_tbId).style.display = "table-row";
        P_KTRA_QU('ldmenu');
        $get("MENUQL").className = "active";
    }
    else if (b_dk == 'N') {
        form_Fctr_TENVUNG('td_ct').className = "css_Mct";
        form_Fctr_TENVUNG('td_bc').className = "css_Mbc";
        form_Fctr_TENVUNG('td_ld').className = "css_Mld";
        form_Fctr_TENVUNG('td_nv').className = "css_MnvAc";
        form_Fctr_TENVUNG('td_Mdau').className = "css_MdauC";
        $get(b_lblnvuId).innerHTML = "NGHIỆP VỤ THƯỜNG DÙNG";
        $get(b_td_tbId).style.display = "none";
        $get(b_td_dungId).style.display = "table-row";
        P_KTRA_QU('nvmenu');
        $get("MENUCN").className = "active";
    }
    else menu_P_LOGIN();
    b_nv = b_dk;
    return false;
}
function P_KTRA_QU(b_file) {
    try { skhud.Fs_KTRA_QU(form_nsd, window.name, b_file, P_KTRA_QU_KQ, P_LOI_CSDL, P_LOI_TGIAN); }
    catch (ex) { form_P_LOI(ex.message); menu_P_LOGIN(); }
}
function P_KTRA_QU_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); menu_P_LOGIN(); }
    else { $get(b_phuId).innerHTML = ''; P_MENUC(); }
}
function form_dong() {
    location.reload(false);
}
function menu_P_LOGIN() {
    location.reload(false);
}
function P_MENUC() {
    try {
        var b_tm = form_Fs_TM();
        skhud.Fs_MENUC(form_nsd, window.name, '0', b_tm, P_MENUC_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); menu_P_LOGIN(); }
}
function P_MENUC_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
        else {
            $get(b_gocId).innerHTML = b_kq;
            skhud.Fs_NSD_DU_LKE(form_nsd, b_nv, menu_P_PCH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function P_MENUC_XL(b_ma) {
    var b_grid = form_Fctr_TENVUNG('tab_menu'), b_cell;
    for (var i = 0; i < b_grid.rows.length; i++) {
        b_cell = b_grid.rows[i].cells[0];
        b_cell.className = (C_NVL(b_cell.getAttribute('ma')) == b_ma) ? "css_menuCf" : "css_menuC";
    }
    P_MENU(b_ma);
}
function P_MENU(b_ma) {
    try {
        if (b_duX) {
            var b_goc = $get(b_gocId);
            var b_pos = Sys.UI.DomElement.getBounds(b_goc);
            var b_x = 200, b_y = b_pos.y - 36, b_rong = 240, b_cao = 34, b_tm = form_Fs_TM();
            skhud.Fs_MENUP(form_nsd, window.name, b_ma, b_x, b_y, b_rong, b_cao, b_tm, P_MENU_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (ex) { form_P_LOI(ex.message); menu_P_LOGIN(); }
}
function P_MENU_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); menu_P_LOGIN(); }
        else {
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
    }
    catch (ex) { form_P_LOI(ex.message); menu_P_LOGIN(); }
}
function menu_P_PCH(b_ma, b_dk) {
    try {
        if (b_dk == 'C') { b_duX = false; skhud.Fs_NSD_DU_NH(form_nsd, window.name, b_nv, b_ma, menu_P_PCH_KQ, P_LOI_CSDL, P_LOI_TGIAN); }
        else {
            var b_cell = form_Fctr_TENVUNG(b_ma);
            b_cell.style.display = (b_dk == 'A') ? "none" : "";
        }
    }
    catch (ex) { b_duX = true; form_P_LOI(ex.message); }
}
function menu_P_PCH_KQ(b_kq) {
    b_duX = true;
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else $get(b_duId).innerHTML = b_kq;
}
function menu_P_TSO() {
    try {
        form_P_MO(form_Fs_TM('f') + '/khud/kh_tso.aspx');
        return false;
    }
    catch (ex) { }
}
function menu_P_DUX(b_ma, b_dk) {
    try {
        if (b_dk == 'D') $get(b_phuId).innerHTML = "";
        else if (b_dk == 'X') { b_duX = false; skhud.Fs_NSD_DU_XOA(form_nsd, b_nv, b_ma, menu_P_PCH_KQ, P_LOI_CSDL, P_LOI_TGIAN); }
        else if (b_dk == 'F') {
            if (b_duX) form_P_MO(form_Fs_TM() + b_ma);
        }
        else {
            var b_cell = form_Fctr_TENVUNG(b_ma);
            b_cell.style.display = (b_dk == 'A') ? "none" : "";
        }
    }
    catch (ex) { b_duX = true; form_P_LOI(ex.message); }
}

// Yên xử lý login lại khi thay đổi mã đơn vị
function login_P_NH_DVI() {
    try {
        //var b_duyet = '<%=this.Request.Browser.Browser%>';
        var b_duyet = "CHROME";
        var b_tm = "";
        var b_dvi = $get(b_qly_dviId).value;
        //b_tm = $get('<%=tm.ClientID%>').value;
        sht_ma.Fs_LOGIN_DVI('NS', b_duyet, b_tm, b_dvi, login_P_NH_DVI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function login_P_NH_DVI_KQ(b_kq) {
    try {

        if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
        else {
            form_P_DONG('', null);
            location.assign('menuM.aspx');
            //location.assign('<%=this.ResolveUrl("~/menuM.aspx")%>');
        }
    }
    catch (ex) { }
}

function P_DONG() {
    alert("1");
}

function form_dong() {
    location.reload(false);
}
