var b_ctr_dm, b_ctr_n;
function ed_vb_P_CTEN_VTRO(b_vuId, b_ma, b_vtro) {
    try {
        if (C_NVL(b_ma) == '') ed_vb_VTRO_dat(b_vtro, '_ten', '');
        else {
            b_ma = b_ma.replace(';', ',');
            var a_ma = Fas_ChMang(b_ma);
            b_ma = '';
            for (var i = 0; i < a_ma.length; i++) {
                if (C_NVL(a_ma[i]) != '') b_ma = kytu_Fs_themD(b_ma, C_NVL(a_ma[i]));
            }
            var b_maG=b_ma;
            if (b_ma != '' && b_vtro != 'C' && C_NVL(a_ma[a_ma.length - 1]) == '') b_maG += ',';
            form_Fctr_TEN_DTUONG(b_vuId, 'vtro' + b_vtro).value = b_maG;
            if (b_vtro == 'C' && b_ma.indexOf(',') > 0) form_P_LOI('loi:Chỉ được chọn 1 chủ trì:loi');
            else sed_vb_khac.Fs_CTEN_VTRO(b_nsd, b_vtro, b_ma, ed_vb_P_CTEN_VTRO_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ed_vb_P_CTEN_VTRO_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        ed_vb_VTRO_dat(a_kq[0], '_ten', a_kq[1]);
    }
}
function ed_vb_VTRO_dat(b_vtro, b_ten, b_gtri) {
    var b_ctr = form_Fctr_TEN_DTUONG(b_vuVtroId, 'vtro' + b_vtro + b_ten);
    if (b_ctr != null) {
        if (b_ten == '') b_ctr.value = b_gtri; else b_ctr.innerHTML = b_gtri;
    }
}
function ed_vb_khac_FILE_CHU(b_dk) {
    try {
        if (C_NVL(b_dk) == '') b_dk = 'VB';
        sed_vb_khac.Fs_FI_CHU(b_nsd, b_so_id, b_namP, b_dk, ed_vb_khac_FILE_CHU_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ed_vb_khac_FILE_CHU_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_div = form_Fctr_TENVUNG('chu_file');
        if (b_div == null) return;
        b_div.innerHTML = '';
        if (b_kq == '') return;
        var b_div = form_Fctr_TENVUNG('chu_file'), a_kq = Fas_ChMang(b_kq, '#');
        var b_ul = document.createElement('ul'), b_li, b_a, b_s, a_f = Fas_ChMang(a_kq[0]), a_s;
        for (var i = 0; i < a_f.length; i++) {
            a_s = Fas_ChMang(a_f[i], '{');
            b_li = document.createElement('li'); b_a = document.createElement('span');
            b_a.innerHTML = a_s[0]; b_li.appendChild(b_a);
            b_s = "ed_vb_khac_FI_XEM('" + a_s[1] + "')";
            Attribute_P_DAT(b_li, 'onclick', b_s);
            b_ul.appendChild(b_li);
        }
        b_a = document.createElement('span'); b_a.innerHTML = a_kq[1];
        b_ul.appendChild(b_a); b_div.appendChild(b_ul);
    }
}
function ed_vb_khac_FI_XEM(b_tso) {
    try {
        var a_tso = Fas_ChMang(b_tso, '|');
        sed_vb_khac.Fs_FI_XEM(b_nsd, a_tso, ed_vb_khac_FI_XEM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ed_vb_khac_FI_XEM_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else if (b_kq != '') form_P_MO(b_kq, null, null, 'C');
}
function ed_vb_khac_file() {
    form_P_MO(b_tmf + '/vb/ed_fileG.aspx', window.name, ['TSO', ['', b_so_id]]);
    form_chay = 0;
    return false;
}
function ed_vb_khac_tsoForm(b_lso, b_vtro) {
    try {
        sed_vb_khac.Fs_tsoForm(window.name, b_lso, b_vtro, ed_vb_khac_tsoForm_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ed_vb_khac_tsoForm_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else if (b_kq != '') {
        var a_ten = Fas_ChMang(b_kq, ';'), a_s, b_ctr;
        for (var i = 0; i < a_ten.length; i++) {
            a_s = Fas_ChMang(a_ten[i], '|');
            if (a_s[1] == 'D') {
                b_ctr = form_Fctr_TENVUNG(a_s[0]);
                if (b_ctr == null) b_ctr = form_Fctr_VTEN_DTUONG('', a_s[0]);
                if (b_ctr != null) b_ctr.style.display = (a_s[2] == 'C') ? '' : 'none';
            }
            else {
                b_ctr = form_Fctr_VTEN_DTUONG('', a_s[0]);
                if (b_ctr != null) b_ctr.disabled = (a_s[2] != 'C');
            }
        }
    }
}
function ed_vb_khac_P_DLKE(b_dk) {
    var b_goc = form_F_GOC(), b_sL = '', b_sM = 'M',
        b_div = form_Fctr_TENVUNG('div_center_icon');
    if (b_dk == 'D') { b_sL = 'none'; b_sM = ''; }
    b_div.children[0].style.display = (b_dk == 'D') ? '' : 'none';
    b_div.children[1].style.display = b_sL;
    form_Fctr_TENVUNG('divLke').style.display = b_sL;
    b_goc.P_MENUBd(b_sM);
}
function ed_vb_khac_Fs_Form(b_dk) {
    var b_f;
    if (b_dk == 'DE') b_f = 'de/ed_vb_de';
    else if (b_dk == 'DI') b_f = 'di/ed_vb_di';
    else if (b_dk == 'NB') b_f = 'nb/ed_vb_nb';
    else if (b_dk == 'TT') b_f = 'tt/ed_vb_tt';
    else if (b_dk == 'NV') b_f = 'nv/ed_vb_nvT';
    else if (b_dk == 'BB') b_f = 'nv/ed_vb_bb';
    return b_f = b_tmf + '/vb/' + b_f + '.aspx';
}
function ed_vb_SO_ID0(b_dk) {
    b_dk = O_NVL(b_dk, 'văn bản');
    form_P_LOI('loi:Chưa chọn ' + b_dk + ':loi'); return false;
}
function ed_vb_P_HIEN_THEM_DM(nsd, b_kieu, b_ctrl1, b_ctrl2) {
    try {
        b_ctr_dm = b_ctrl1; b_ctr_n = b_ctrl2;
        var b_nv = 'MA', b_kt = '2';
        sed_vb_chung.Fs_ED_VB_QU_KTRA(nsd, 'ED', b_nv, b_kt, ed_vb_P_HIEN_THEM_DM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    } catch (ex) { form_P_LOI(ex.message); }
}
function ed_vb_P_HIEN_THEM_DM_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) b_kq = 'K';
    if (b_kq != 'C') {
        var a_ctrl_dm = Fas_ChMang(b_ctr_dm, ','), a_ctr_n = Fas_ChMang(b_ctr_n, ','), b_ctrl;
        for (var i = 0; i < a_ctrl_dm.length; i++) {
            b_ctrl = form_Fctr_TEN_DTUONG(b_vungId, a_ctrl_dm[i]);
            if (b_ctrl != null) { b_ctrl.className = b_ctrl.className.replace('add', 'no'); b_ctrl.style.display = 'none'; }
            b_ctrl = form_Fctr_TEN_DTUONG(b_vungId, a_ctr_n[i]);
            if (b_ctrl != null) { b_ctrl.className = b_ctrl.className.replace('add', 'no'); }
        }
    }
    b_ctr_dm = ''; b_ctr_n = '';
}