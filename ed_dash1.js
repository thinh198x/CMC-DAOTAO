var b_grlkeId, b_slideId,b_tke=true,b_dgia=true;
var b_lkeCho = setInterval('ed_dash_CHO()', 300);
function ed_dash_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(b_lkeCho);
        b_nsd = form_Fs_nsd();
        b_grlkeId = form_Fs_VUNG_ID('GR_lke'); b_slideId = $get(b_grlkeId).getAttribute('slideId');
        form_F_GOC().P_MENUBf(window.name, 'T');
        //ed_dash_TDOI('D');
    }
}
function ed_dash_TDOI(b_dk) {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        if (b_dk != 'L') slide_P_MOI(b_slideId);
        //sed_vb_chung.Fs_DASH_TDOI(b_nsd, window.name, b_dk, a_cot, a_tso, ed_dash_TDOI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ed_dash_TDOI_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
        else {
            var a_kq = Fas_ChMang(b_kq, '#'); slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
            if (b_tke) { b_tke = false; ed_dash_TKE(); }
        }
    }
    catch (ex) { }
}
function ed_dash_TKE() {
    try {
        //sed_vb_chung.Fs_DASH_TKE(ed_dash_TKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ed_dash_TKE_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
        else {
            var a_kq = Fas_ChMang(b_kq), b_divId = form_Fs_VUNG_ID('div_tke'), a_ten = Fas_ChMang('moi,dang,sap,qua');
            for (var i = 0; i < a_kq.length; i++) form_Fctr_TEN_DTUONG(b_divId, a_ten[i]).innerHTML = a_kq[i];
            if (b_dgia) { b_dgia = false; ed_dash_DGIA(); }
        }
    }
    catch (ex) { }
}
function ed_dash_DGIA() {
    try { sed_vb_chung.Fs_DASH_DGIA(ed_dash_DGIA_KQ, P_LOI_CSDL, P_LOI_TGIAN); }
    catch (ex) { form_P_LOI(ex.message); }
}
function ed_dash_DGIA_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
        else if (b_kq == '') return;
        var a_kq = Fas_ChMang(b_kq, '#'), a_s, b_ul, b_li, b_sp, b_divId, b_div, a_c;
        for (var j = 0; j < a_kq.length; j++) {
            if (a_kq[j] != '') {
                a_s = Fas_ChMang(a_kq[j]);
                b_ul = document.createElement('ul');
                for (var i = 0; i < a_s.length; i++) {
                    a_c = Fas_ChMang(a_s[i], ':');
                    b_li = document.createElement('li');
                    b_sp = document.createElement('span'); b_sp.innerHTML = a_c[0]; b_sp.className = 'b_left ten_dv';
                    b_li.appendChild(b_sp);
                    b_sp = document.createElement('span'); b_sp.innerHTML = a_c[1]; b_sp.className = 'b_right so_vb';
                    b_li.appendChild(b_sp);
                    b_ul.appendChild(b_li);
                }
                b_divId = form_Fs_VUNG_ID('div_dgia' + j.toString());
                b_div = $get(b_divId); b_div.appendChild(b_ul);
            }
        }
    }
    catch (ex) { }
}
function ed_dash_P_CT(b_event) {

}
