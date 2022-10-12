var b_cctcId, b_cctcTao = 'C', b_cctcVtro = '';        // Tao: X-Xem, C-Chon
function khud_cctc_KD(tao, Id) {
    b_cctcTao = tao; b_cctcId = Id;
}
// Lay ve
function khud_cctc_P_SL(b_id, b_loai, b_cap, b_dvi, b_ma) {
    try {
        if (b_id == '') b_id = b_cctcId;
        sed_vb_khac.Fs_CCTC(form_Fs_nsd(), b_id, b_loai, b_cap, b_dvi, b_ma, b_cctcVtro, khud_cctc_P_SL_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function khud_cctc_P_SL_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else khud_cctc_P_TAO(b_kq);
}
// Tao
function khud_cctc_P_TAO(b_kq) {
    try {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_ctrId = a_kq[0], b_cap = a_kq[1],
            b_ul = document.createElement('ul'), a_s, b_li, b_sp, b_s, b_id, b_chk;
        if (a_kq[2] != '') {
            a_kq = Fas_ChMang(a_kq[2], ';');
            // loai:D-dvi,B-bphan,C-canhan  tc:C-xanh vang,K-vang;
            for (var i = 0; i < a_kq.length; i++) {
                a_s = Fas_ChMang(a_kq[i], '|');     // 0-ma; 1-ten; 2-tc; 3-loai; 4-dvi
                b_id = 'ctr_' + a_s[3] + '_' + a_s[0];
                b_sp = document.createElement('span');
                b_sp.innerHTML = a_s[1]; b_sp.style.cursor = 'pointer';
                if (a_s[3] == 'D') b_s = 'ico_dvpn';
                else if (a_s[3] == 'C') b_s = (b_cctcTao == 'C') ? 'ico_canhan' : 'ico_k_canhan';
                else b_s = (a_s[2] == 'C') ? 'ico_bppn' : 'ico_bptt';
                b_sp.className = b_s; b_sp.id = b_id + '_Ch';
                b_li = document.createElement('li');
                b_li.id = b_id; b_li.appendChild(b_sp);
                Attribute_P_DAT(b_li, 'loai,cap,dvi,ma,tc,ma_ct,ma_nh', [a_s[3], b_cap, a_s[4], a_s[0], a_s[2], b_ctrId, a_s[5]]);
                b_log = (b_cctcTao == 'C' && (a_s[3] == 'C' || 'DYK'.indexOf(b_cctc_Vtro) < 0));
                if (b_log) b_s = "khud_cctc_P_CHON(event,'" + b_sp.id + "')";
                else if (a_s[3] != 'C') b_s = "khud_cctc_P_CLICK(event,'" + b_id + "')";
                else b_s = '';
                if (b_s != '') Attribute_P_DAT(b_li, 'onclick', b_s);
                if (a_s[3] != 'C') {
                    b_i = document.createElement('i');
                    b_i.id = b_id + '_Tre'; b_i.className = 'collapsed';
                    if (b_log) {
                        b_s = "khud_cctc_P_CLICK(event,'" + b_id + "')";
                        Attribute_P_DAT(b_i, 'onclick', b_s);
                    }
                    b_li.appendChild(b_i);
                }
                b_ul.appendChild(b_li);
            }
        }
        var b_ctr = $get(b_ctrId);
        if (b_ctrId == b_cctcId) b_ctr.appendChild(b_ul);
        else {
            var b_div = document.createElement('div');
            b_div.id = b_ctrId + '_Div'; b_div.appendChild(b_ul);
            b_ctr.appendChild(b_div);
            b_s = b_ctr.getAttribute('ma_ct');
            khud_cctc_HIEN(b_s, b_ctrId);
        }
    }
    catch (ex) { form_P_LOI(ex.message); }
}
// Click
function khud_cctc_P_CLICK(b_event, b_id) {
    b_event.stopPropagation();
    var b_ctr = $get(b_id), b_div = $get(b_id + '_Div');
    var a_tso = Attribute_Fas_LAY(b_ctr, 'loai,cap,dvi,ma,ma_ct');
    if (a_tso[0] != 'C') {
        if (b_div == null) khud_cctc_P_SL(b_id, a_tso[0], a_tso[1], a_tso[2], a_tso[3]);
        else {
            b_id = (C_NVL(b_div.style.display) == '') ? '' : b_id;
            khud_cctc_HIEN(a_tso[4], b_id);
        }
    }
    return false;
}
function khud_cctc_HIEN(b_IdM, b_idC) {
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
function khud_cctc_P_CHON(b_event, b_id) {
    b_event.stopPropagation();
    var b_ctr = $get(b_id);
    var b_css = b_ctr.className;
    var b_i = b_css.indexOf('_chon');
    if (b_i < 0) b_css += '_chon'; else b_css = b_css.substr(0, b_i);
    b_ctr.className = b_css;
    return false;
}
function khud_cctc_P_LAY(b_dk) {
    var b_div = $get(b_cctcId);
    var a_li = b_div.getElementsByTagName('li'), b_id, b_sp, b_i, a_kq = [], a_tso;
    for (var i = 0; i < a_li.length; i++) {
        b_id = a_li[i].id + '_Ch';
        b_sp = $get(b_id);
        if (b_sp != null) {
            b_i = b_sp.className.indexOf('_chon');
            if ((b_dk == 'C' && b_i > 0) || (b_dk == 'K' && b_i < 0)) {
                a_tso = Attribute_Fas_LAY(a_li[i], 'loai,dvi,ma,ma_nh');
                a_tso.push(b_sp.innerHTML); a_kq.push(a_tso);
            }
        }
    }
    return a_kq;
}
// Bo chon
function khud_cctc_P_BCHON() {
    var b_div = $get(b_cctcId);
    var a_li = b_div.getElementsByTagName('li'), b_id, b_sp, b_i, a_kq = [], a_tso, b_css;
    for (var i = 0; i < a_li.length; i++) {
        b_id = a_li[i].id + '_Ch';
        b_sp = $get(b_id);
        if (b_sp != null) {
            b_css = b_sp.className;
            b_i = b_css.indexOf('_chon');
            if (b_i > 0) { b_css = b_css.substr(0, b_i); b_ctr.className = b_css; }
        }
    }
    return a_kq;
}

