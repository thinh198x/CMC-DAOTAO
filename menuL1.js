var b_lkeCho = 0, form_nsd = '', b_qly_dviId, b_nv = 'C', b_duX = true, b_form_popUp = 'K', b_ttmhId;
var b_test = false;

function menu_KD(tm) {
    b_form_popUp = 'K'; form_P_TM(tm);
    b_lkeCho = setInterval('menu_CHO()', 300);
}
function menu_CHO() {
    if (document.readyState === 'complete' && form_nsd != '') {
        clearInterval(b_lkeCho); form_P_FraH('T'); P_MENUBd('');
        var b_vuId = form_Fs_VUNG_ID('divBar');
        b_qly_dviId = form_Fs_VTEN_ID('', 'qly_dvi');
        b_ttmhId = form_Fs_VTEN_ID('', 'ttmh');
        P_MENUB('B', b_vuId, '');
    }
}
function P_MENUB(b_loai, b_vuId, b_ma) {
    try { skhud.Fs_MENUB(form_nsd, window.name, b_loai, b_ma, b_vuId, P_MENUB_KQ, P_LOI_CSDL, P_LOI_TGIAN); }
    catch (ex) { form_P_LOI(ex.message); }
}
function P_MENUB_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_loai = a_kq[0], b_div = $get(a_kq[1]), b_ul = document.createElement('ul'), a_s, b_s, b_li, b_sp, b_f;
        var b_cap = (b_loai != 'G') ? 0 : CSO_SO(b_div.getAttribute('cap'), 0) + 1;
        if (b_loai != 'G' || a_kq[2] == '') { b_div.innerHTML = ''; form_P_FraD('', 'T'); }
        if (a_kq[2] != '') {
            if (b_cap < 2) form_Fctr_TENVUNG('divMenu').innerHTML = '';
            for (var i = 2; i < a_kq.length; i++) {
                b_sp = document.createElement('span'), b_li = document.createElement('li');
                a_s = Fas_ChMang(a_kq[i], '|');
                b_li.id = a_s[0]; b_sp.innerHTML = a_s[1];
                if (a_s[2] == 'ggg') b_li.className = 'gr_menu';
                else {
                    b_sp.style.cursor = 'pointer';
                    if (b_loai == 'G') b_li.className = (a_s[2] == '') ? 'css_Mlist' : 'css_Mma';
                    b_s = "P_MENUBc(event,'" + a_s[0] + "')";
                    Attribute_P_DAT(b_li, 'loai,cap,ftkhao,tso,kdo,onclick', [b_loai, b_cap, a_s[2], a_s[3], a_s[4], b_s]);
                }
                b_li.appendChild(b_sp); b_ul.appendChild(b_li);
            }
            b_div.appendChild(b_ul);
            if (b_loai != 'G' && a_kq.length > 2) {
                a_s = Fas_ChMang(a_kq[2], '|');
                b_li = $get(a_s[0]); b_li.className = 'selected';
                if (a_s[2].indexOf('.aspx') < 0) {
                    if (b_loai == 'B') { b_loai = 'N'; b_s = 'divDoc'; }
                    else { b_loai = 'G'; b_s = 'divMenu'; }
                    b_s = form_Fs_VUNG_ID(b_s);
                    P_MENUB(b_loai, b_s, a_s[0]);
                }
                else {
                    b_li.style.display = 'none';
                    b_s = (b_loai == 'B') ? 'T' : 'M';
                    P_MENUBd(b_s); form_P_MO(a_s[2], '');
                }
            }
            P_MENUkdo(b_ul, 'ul');
        }
    }
}
function P_MENUBc(b_event, b_id) {
    try {
        b_event.stopPropagation();
        var b_li = $get(b_id), b_dk = 'K', b_s;
        var b_loai = C_NVL(b_li.getAttribute('loai')), b_f = C_NVL(b_li.getAttribute('ftkhao'));
        if (b_loai != 'G' || b_f == '') {
            b_s = (b_loai != 'G') ? 'T' : 'G';
            form_P_FraH('T'); form_P_FraD('', b_s);
        }
        if (b_f != '') {
            if (b_loai == 'B') b_s = 'T';
            else if (b_loai == 'N') b_s = 'M';
            else b_s = '';
            P_MENUBd(b_s);
            b_s = C_NVL(b_li.getAttribute('tso'));
            var a_tso = (b_s != '') ? ['TSO', [b_s]] : '';

            // linhnv thêm để mở nhiều tab 04/03/2021
            //ở form menuL để là C và ở bảng kh_nsd_tso(thiết lập) để là T => tạo cửa sổ mới;
            //ở form menuL để là K và ở bảng kh_nsd_tso(thiết lập) để là C => tạo popup; 
            var b_kieuM = "K";
            if ($get(b_ttmhId).value == 'T') b_kieuM = "C";
            form_P_MO(b_f, '', a_tso, b_kieuM);

        }
        else if (b_loai != 'G') {
            if (b_loai == 'B') { b_loai = 'N'; b_s = 'divDoc'; }
            else { b_loai = 'G'; b_s = 'divMenu'; }
            b_s = form_Fs_VUNG_ID(b_s);
            P_MENUBd(''); P_MENUB(b_loai, b_s, b_id);
        }
        else {
            var a_ul = b_li.getElementsByTagName('ul');
            if (a_ul.length == 0) P_MENUB('G', b_id, b_id);
            else if (C_NVL(a_ul[0].style.display) == '') { b_dk = 'C'; P_MENUkdo(a_ul[0], 'ul'); }
        }
        P_MENUBs(b_id, b_dk);
        return false;
    }
    catch (ex) { }
}
function P_MENUBs(b_id, b_dk) {
    var b_li = $get(b_id);
    var b_div = b_li.parentNode;
    var a_li = b_div.getElementsByTagName('li'), b_loai = C_NVL(b_li.getAttribute('loai')), a_ul;
    for (var i = 0; i < a_li.length; i++) {
        if (b_loai != 'G') a_li[i].className = '';
        a_ul = a_li[i].getElementsByTagName('ul');
        if (a_ul.length > 0) a_ul[0].style.display = (a_li[i].id != b_id || b_dk == 'C') ? 'none' : '';
    }
    if (b_loai != 'G') b_li.className = 'selected';
    else {
        var a_sp = b_div.parentNode.getElementsByTagName('span');
        for (var i = 0; i < a_sp.length; i++) { a_sp[i].className = ''; }
        a_sp = b_li.getElementsByTagName('span');
        if (a_sp.length > 0) a_sp[0].className = 'css_MlistC';
    }
}
/* An vung menu T-An ca vung doc va menu chinh,M-An vung menu chinh */
function P_MENUBd(b_dk) {
    var b_sD = '', b_sM = '', b_sC = 'menu_frame';
    b_dk = C_NVL(b_dk);
    if (b_dk == 'T') { b_sD = 'none'; b_sM = 'none'; b_sC += '2'; }
    else if (b_dk == 'M') { b_sM = 'none'; b_sC += '1'; }

    form_Fctr_TENVUNG('divDoc').style.display = b_sD;
    form_Fctr_TENVUNG('divMenuM').style.display = b_sM;
    form_Fctr_TENVUNG('VFChinh').className = b_sC;
}
/* Dat kieu rong Form trong Frame */
function P_MENUBf(b_ten, b_dk) {
    var b_divV = form_Fctr_TENVUNG('VFChinh');
    var a_fra = b_divV.getElementsByTagName('iframe');
    b_ten = 'i' + b_ten;
    for (var i = 0; i < a_fra.length; i++) {
        if (a_fra[i].id == b_ten) { Attribute_P_DAT(a_fra[i], 'rongF', b_dk); break; }
    }
    P_MENUBd(b_dk);
}
/* gia tri khoi dong */
function P_MENUkdo(b_ctr, b_dk) {
    try {
        var a_id = [], a_kdo = [], b_kdo, a_li;
        if (b_dk == 'ul') a_li = b_ctr.getElementsByTagName('li');
        else if (b_dk == 'li') a_li = [b_ctr];
        else if (b_dk == 'uiId') a_li = $get(b_ctr).getElementsByTagName('li');
        else a_li = [$get(b_ctr)];
        for (var i = 0; i < a_li.length; i++) {
            b_kdo = C_NVL(a_li[i].getAttribute('kdo'));
            if (b_kdo != '') { a_id.push(a_li[i].id); a_kdo.push(b_kdo); }
        }
        //if (a_id.length > 0) skhud.Fs_MENUkdo(form_nsd, 'NS', a_id, a_kdo, P_MENUkdo_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function P_MENUkdo_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else if (b_kq != '') {
        var a_kq = Fas_ChMang(b_kq, '#'), a_s, b_sp, b_li, b_s, b_i;
        for (var i = 0; i < a_kq.length; i++) {
            a_s = Fas_ChMang(a_kq[i], '|');
            b_li = $get(a_s[0]);
            b_sp = b_li.getElementsByTagName('span')[0];
            b_s = C_NVL(b_sp.innerHTML);
            b_i = b_s.lastIndexOf('(');
            if (b_i > 0) b_s = C_NVL(b_s.substr(0, b_i));
            b_sp.innerHTML = b_s + ' (' + a_s[1] + ')';
        }
    }
}
/* Hien thong bao */
function menu_P_TBAO() {
    alert('Chua viet');
    return false;
}
/*An hien user setting*/
function sh_usermenu() {
    var usermenu = document.getElementsByClassName('dropdown-usermenu');
    for (var i = 0; i < usermenu.length; i += 1) {
        if (usermenu[i].style.display === 'none') {
            usermenu[i].style.display = 'block';
            usermenu[i].parentNode.classList.add("show");
        } else {
            usermenu[i].style.display = 'none';
            usermenu[i].parentNode.classList.remove("show");
        }
    }
}
/*An hien thongbao*/
function menu_tb() {
    var usermenu = document.getElementsByClassName('divTbao');
    for (var i = 0; i < usermenu.length; i += 1) {
        if (usermenu[i].style.display === 'none') {
            usermenu[i].style.display = 'block';
            usermenu[i].parentNode.classList.add("show");
        } else {
            usermenu[i].style.display = 'none';
            usermenu[i].parentNode.classList.remove("show");
        }
    }
}
function P_MENU(b_ma, b_f) {
    try {
        if (b_duX) {
            var b_x = 200, b_y = 200, b_rong = 240, b_cao = 34, b_tm = form_Fs_TM();
            skhud.Fs_MENUP2(form_nsd, window.name, b_ma, b_f, b_x, b_y, b_rong, b_cao, b_tm, P_MENU_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function P_MENU_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); }
        else {
            var a_kq = Fas_ChMang(b_kq, '#');
            var b_tkhao = a_kq[0], b_tso = a_kq[2];
            b_kq = b_kq.substr(b_tkhao.length + b_tso.length + 2);
            if (b_tkhao != '') {
                var a_tso = (b_tso != '') ? ['THAMSO', Fas_ChMang(b_tso, ',')] : null;
                form_P_MO(b_tkhao, null, a_tso, "C");
            }
        }
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function menu_P_MENU(b_dk) {
    try {
        var b_nv = b_dk;
        if (b_dk == 'C') {
            form_Fctr_TENVUNG('td_ct').className = 'css_MctAc';
            form_Fctr_TENVUNG('td_bc').className = 'css_Mbc';
            form_Fctr_TENVUNG('td_Mdau').className = 'css_MdauC';
            P_KTRA_QU('ctmenu');
        }
        else if (b_dk == 'B') {
            form_Fctr_TENVUNG('td_ct').className = 'css_Mct';
            form_Fctr_TENVUNG('td_bc').className = 'css_MbcAc';
            form_Fctr_TENVUNG('td_Mdau').className = 'css_MdauB';
            P_KTRA_QU('bcmenu');
        }
        else menu_P_LOGIN();
        return false;
    }
    catch (ex) { }
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
            location.assign('menuL.aspx');
            //location.assign('<%=this.ResolveUrl("~/menuM.aspx")%>');
        }
    }
    catch (ex) { }
}
function menu_P_LOGIN() {
    try {
        form_P_DONG('', null);
        location.assign('login.aspx');
    }
    catch (ex) { }
}

// Namtest
function nam_test(b_test) {
    //var s = '<iframe src="/App_form/test/test.aspx" style="width: 100%; height: 100%; border: none;"></iframe>';
    //var s_idaotao_ma = '<iframe id="idaotao_ma" src="/App_form/ns/ma/daotao_ma.aspx" style="width: 100%; height: 100%; border: none;"></iframe>';
    b_test = !b_test;
    if (b_test) {
        $('#VFChinh #test_iframe').show();
    } else {
        $('#VFChinh #test_iframe').hide();
    }
}
