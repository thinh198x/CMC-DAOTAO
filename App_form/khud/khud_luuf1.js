var b_vuId, b_chId, b_moId, b_vtriY = 0, b_luuId, b_dongId, b_tmucId, b_tenId, b_ma_dviId;
document.onmousemove = function (event) {
    b_vtriY = (typeof event == 'undefined') ? window.event.clientY : event.clientY;
}
window.onbeforeunload = function () {
    if (b_vtriY <= 0) { $get(b_luuId).value = ""; $get(b_dongId).value = ""; }
}
function khud_luuf_KD(chId, moId) {
    b_chId = chId; b_moId = moId, b_vuId = form_Fs_VUNG_ID('UPa_hi');
    b_luuId = form_Fs_TEN_ID(b_vuId, 'tra_luu'), b_dongId = form_Fs_TEN_ID(b_vuId, 'tra_dong'),
        b_tmucId = form_Fs_TEN_ID(b_vuId, 'tmuc'), b_tenId = form_Fs_TEN_ID(b_vuId, 'ten'), b_ma_dviId = form_Fs_TEN_ID(b_vuId, 'ma_dvi');
}
function P_KET_QUA(b_dtuong, a_tso) {
    if (C_NVL(b_dtuong) == "TSO" && a_tso.length > 1) {
        form_Fctr_TEN_DTUONG(b_vuId, 'tmuc').value = a_tso[0];
        if (a_tso.length > 1) $get(b_tenId).value = a_tso[1];
        if (a_tso.length > 2) $get(b_luuId).value = a_tso[2];
        if (a_tso.length > 3) {
            form_Fctr_TEN_DTUONG(b_vuId, 'loai').value = a_tso[3];
            if (a_tso[3] == 'ID') {
                form_Fctr_TEN_DTUONG(b_vuId, 'ma_dvi').value = a_tso[4];
                form_Fctr_TEN_DTUONG(b_vuId, 'nd').value = a_tso[5];
            }
        }
    }
}
function khud_luuf_P_DAT() {
    try {
        var b_cf = C_NVL($get(b_chId).value);
        if (b_cf != "") {
            var b_i = b_cf.lastIndexOf('/'), b_j = b_cf.lastIndexOf('\\');
            if (b_i < b_j) b_i = b_j;
            b_cf = b_cf.substr(b_i + 1);
        }
        if (b_cf != "") {
            if (C_NVL($get(b_luuId).value) != "C") $get(b_dongId).value = b_cf;
            __doPostBack(b_moId, '');
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function khud_luuf_P_GCHU() {
    form_Fctr_VTEN_DTUONG('', 'gchu').innerHTML = C_NVL($get(b_chId).value);
}
function form_dong() {
    form_P_DAY(window.name, 'ns_hdns_dbien', 'TAI_IMPORT', ['CB', 1, 1]);
    window.close();
}