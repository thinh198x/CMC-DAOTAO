var ctr_khud_cayChon = 'K', b_ctr_khud_cayHam='', ctr_khud_cayID;
function ctr_khud_cay_KD(chon,ham, Id) {
    ctr_khud_cayChon = chon; b_ctr_khud_cayHam = ham; ctr_khud_cayID = Id;
}
// Lay ve
function ctr_khud_cay_P_SL(b_id,b_cap,b_ma) {
    try {
        skhud.Fs_CAY(form_Fs_nsd(), b_id, b_cap, b_ma, b_ctr_khud_cayHam, ctr_khud_cay_P_SL_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ctr_khud_cay_P_SL_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_ul = document.createElement('ul'), a_s, b_li, b_sp, b_s, b_id, b_chk,
        b_ctrId = (a_kq[0] == '') ? ctr_khud_cayID : a_kq[0];
    if (a_kq[2] != '') {
        a_kq = Fas_ChMang(a_kq[2], ';');
        for (var i = 0; i < a_kq.length; i++) {
            a_s = Fas_ChMang(a_kq[i], '|');     // 0-ma; 1-ten; 2-loai;
            b_id = 'ctr_'+ a_s[0];
            b_sp = document.createElement('span');
            b_sp.innerHTML = a_s[1]; b_sp.style.cursor = 'pointer';
            b_sp.id = b_id + '_Ch';
            b_li = document.createElement('li');
            b_li.id = b_id; b_li.appendChild(b_sp);
            Attribute_P_DAT(b_li, 'loai,cap,ma,ma_ct', [a_s[2], a_kq[1], a_s[0], b_ctrId]);
            b_log = (ctr_khud_cayChon == 'T' || ctr_khud_cayChon == a_s[2]);
            if (b_log) {
                b_s = "ctr_khud_cay_P_CHON(event,'" + b_sp.id + "')";
                b_sp.className = 'ico_bptt';
            }
            else b_s = "ctr_khud_cay_P_CLICK(event,'" + b_id + "')";
            Attribute_P_DAT(b_li, 'onclick', b_s);
            if (a_s[2] != 'C') {
                b_i = document.createElement('i');
                b_i.id = b_id + '_Tre'; b_i.className = 'collapsed';
                if (b_log) {
                    b_s = "ctr_khud_cay_P_CLICK(event,'" + b_id + "')";
                    Attribute_P_DAT(b_i, 'onclick', b_s);
                }
                b_li.appendChild(b_i);
            }
            b_ul.appendChild(b_li);
        }
    }
    var b_ctr = $get(b_ctrId)
    if (b_ctrId == ctr_khud_cayID) {
        b_ctr.innerHTML = ''; b_ctr.appendChild(b_ul);
    }
    else {
        var b_div = document.createElement('div');
        b_div.id = b_ctrId + '_Div'; b_div.appendChild(b_ul);
        b_ctr.appendChild(b_div);
        b_s = b_ctr.getAttribute('ma_ct');
        ctr_khud_cay_HIEN(b_s, b_ctrId);
    }
}
// Click
function ctr_khud_cay_P_CLICK(b_event, b_id) {
    b_event.stopPropagation();
    var b_ctr = $get(b_id);
    var a_tso = Attribute_Fas_LAY(b_ctr, 'loai,cap,ma,ma_ct');
    if (a_tso[0] != 'C') {
        var b_div = $get(b_id + '_Div');
        if (b_div == null) ctr_khud_cay_P_SL(b_id, a_tso[1], a_tso[2]);
        else {
            b_id = (C_NVL(b_div.style.display) == '') ? '' : b_id;
            ctr_khud_cay_HIEN(a_tso[3], b_id);
        }
    }
    if (b_ctr.tagName != 'SPAN') b_id += '_Ch';
    ctr_khud_cay_P_BTTR(b_id);
    return false;
}
function ctr_khud_cay_HIEN(b_IdM, b_idC) {
    var b_ctrM = $get(b_IdM), b_css, b_h, b_div, b_i;
    var a_li = b_ctrM.getElementsByTagName('li');
    for (var i = 0; i < a_li.length; i++) {
        if (a_li[i].id != b_idC) { b_h = 'none'; b_css = 'collapsed'; }
        else { b_h = ''; b_css = 'expanded'; }
        b_div = $get(a_li[i].id + '_Div');
        if (b_div != null) b_div.style.display = b_h;
        b_i = $get(a_li[i].id + '_Tre');
        if (b_i != null) b_i.className = b_css;
    }
}
function ctr_khud_cay_P_CHON(b_event, b_id) {
    b_event.stopPropagation();
    var b_ctr = $get(b_id);
    var b_css = b_ctr.className;
    var b_i = b_css.indexOf('_chon');
    if (b_i < 0) b_css += '_chon'; else b_css = b_css.substr(0, b_i);
    b_ctr.className = b_css;
    ctr_khud_cay_P_BTTR(b_id);
    return false;
}
function ctr_khud_cay_P_LAY(b_dk) {
    var b_div = $get(ctr_khud_cayID);
    var a_li = b_div.getElementsByTagName('li'), b_id, b_sp, b_i, a_kq = [], b_ma,b_ten;
    for (var i = 0; i < a_li.length; i++) {
        b_id = a_li[i].id + '_Ch';
        b_sp = $get(b_id);
        if (b_sp != null) {
            b_i = b_sp.className.indexOf('_chon');
            if ((b_dk == 'C' && b_i > 0) || (b_dk == 'K' && b_i < 0)) {
                b_ma = a_li[i].getAttribute('ma'); b_ten = b_sp.innerHTML;
                a_kq.push([b_ma,b_ten]);
            }
        }
    }
    return a_kq;
}
// Bo chon
function ctr_khud_cay_P_BCHON() {
    var b_div = $get(ctr_khud_cayID);
    var a_li = b_div.getElementsByTagName('li'), b_id, b_sp, b_i, b_css;
    for (var i = 0; i < a_li.length; i++) {
        b_id = a_li[i].id + '_Ch';
        b_sp = $get(b_id);
        if (b_sp != null) {
            b_css = b_sp.className;
            b_i = b_css.indexOf('_chon');
            if (b_i > 0) { b_css = b_css.substr(0, b_i); b_sp.className = b_css; }
        }
    }
    ctr_khud_cay_P_BTTR();
    return false;
}
// Bo focus va dat moi neu co b_chId
function ctr_khud_cay_P_BTTR(b_chId) {
    var b_div = $get(ctr_khud_cayID);
    var a_li = b_div.getElementsByTagName('li'), b_id, b_sp;
    for (var i = 0; i < a_li.length; i++) {
        b_id = a_li[i].id + '_Ch';
        b_sp = $get(b_id);
        if (b_sp != null && b_sp.style.color.toLowerCase() == 'blue') b_sp.style.color = 'black';
    }
    if (C_NVL(b_chId) != '') {
        b_sp = $get(b_chId);
        if (b_sp != null) b_sp.style.color = 'blue';
    }
    return false;
}
function ctr_khud_cay_Fs_ma() {
    var b_div = $get(ctr_khud_cayID),b_ma='';
    var a_li = b_div.getElementsByTagName('li'), b_id, b_sp;
    for (var i = 0; i < a_li.length; i++) {
        b_id = a_li[i].id + '_Ch';
        b_sp = $get(b_id);
        if (b_sp != null && b_sp.style.color.toLowerCase() == 'blue') {
            b_ma = C_NVL(a_li[i].getAttribute('ma')); break;
        }
    }
    return b_ma;
}
