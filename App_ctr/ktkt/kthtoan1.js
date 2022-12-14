var b_kthtoan_gridId, b_kthtoan_noId, b_kthtoan_coId;
function kthtoan_P_KD(b_grId, b_noId, b_coId) {
    b_kthtoan_gridId = b_grId; b_kthtoan_noId = b_noId; b_kthtoan_coId = b_coId;
}
function kthtoan_P_KET_QUA(b_dtuong, b_ma) {
    try {
        var b_hang = GridX_Fi_timHangA(b_kthtoan_gridId);
        if (b_hang < 1) return;
        b_dtuong = b_dtuong.toUpperCase();
        if (b_dtuong.indexOf("MA_TKE") >= 0) {
            GridX_datGtri(b_kthtoan_gridId, b_hang, ["ma_tke"], [b_ma], 'K'); GridX_datA(b_kthtoan_gridId, b_hang, "tien");
        }
        else if (b_dtuong.indexOf("MA_TK") >= 0) {
            GridX_datGtri(b_kthtoan_gridId, b_hang, ["ma_tk"], [b_ma], 'K');
            sktkt_ct.Fs_MA_TK(b_ma, kthtoan_MA_TK, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function kthtoan_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_kthtoan_gridId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        if (b_value != "") {
            if (b_cot == "KTOAN_NV") {
                var b_tien = CSO_SO(GridX_Fas_layGtri(b_kthtoan_gridId, b_hang, "tien"), 0);
                if (b_tien == 0) {
                    b_tien = CSO_SO($get(b_kthtoan_noId).innerHTML, 0) - CSO_SO($get(b_kthtoan_coId).innerHTML, 0);
                    if (b_tien != 0) {
                        if (b_value == "N") b_tien = -b_tien;
                        GridX_datGtri(b_kthtoan_gridId, b_hang, ["tien"], [SO_CSO(b_tien, 0)], 'K'); kthtoan_Tong();
                    }
                }
            }
            else if (b_cot == "KTOAN_MA_TK") sktkt_ct.Fs_MA_TK(b_value, kthtoan_MA_TK, P_LOI_CSDL, P_LOI_TGIAN);
            else if (b_cot == "KTOAN_MA_TKE") {
                var b_ma_tk = C_NVL(GridX_Fas_layGtri(b_kthtoan_gridId, b_hang, "ma_tk"));
                if (b_ma_tk != "") sktkt_ct.Fs_CT_TEN("MA_TKE", b_ma_tk, b_value, kthtoan_MA_TKE, P_LOI_CSDL, P_LOI_TGIAN);
            }
            GridX_ThemHang(b_kthtoan_gridId);
        }
        if (b_cot == "KTOAN_TIEN") kthtoan_Tong();
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function kthtoan_MA_TK(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '|');
    GridX_datGchu(b_kthtoan_gridId, a_kq[0]);
    if (a_kq[1].indexOf("TK:") < 0 || a_kq[1].indexOf("TK:K") >= 0) {
        var b_hang = GridX_Fi_timHangA(b_kthtoan_gridId);
        GridX_datA(b_kthtoan_gridId, b_hang, "tien");
    }
}
function kthtoan_MA_TKE(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else GridX_datGchu(b_kthtoan_gridId, b_kq);
}
function kthtoan_Tong() {
    try {
        var b_no = GridX_Fn_Tong(b_kthtoan_gridId, "tien", "NV", "N"), b_co = GridX_Fn_Tong(b_kthtoan_gridId, "tien", "NV", "C");
        $get(b_kthtoan_noId).innerHTML = SO_CSO(b_no, 0); $get(b_kthtoan_coId).innerHTML = SO_CSO(b_co, 0);
    }
    catch (ex) { }
}
function kthtoan_HangLen() {
    GridX_chuyenHang(b_kthtoan_gridId, -1);
    return false;
}
function kthtoan_HangXuong() {
    GridX_chuyenHang(b_kthtoan_gridId, 1);
    return false;
}
function kthtoan_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_kthtoan_gridId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_kthtoan_gridId);
    return false;
}
function kthtoan_CatDong() {
    GridX_boChon(b_kthtoan_gridId); kthtoan_Tong();
    return false;
}
function kthtoan_File() {
    form_P_MO(b_tmf + "/khud/khud_Excel.aspx", window.name + ",FILE_HTOAN", null);
    return false;
}
function kthtoan_P_NHAN_BANG(b_dt,b_dk) {
    GridX_datBang(b_kthtoan_gridId, b_dt); kthtoan_Tong();
    if (C_NVL(b_dk) == 'C') GridX_datA(b_kthtoan_gridId, 1, "nv");
}
//Lấy nhập
function kthtoan_Faa_LAY_NH() {
    return GridX_Fdt_cotGtriH(b_kthtoan_gridId);
}
function kthtoan_Fa_LAY_TIEN() {
    var b_no = CSO_SO($get(b_kthtoan_noId).innerHTML, 0), b_co = CSO_SO($get(b_kthtoan_coId).innerHTML, 0);
    return [b_no, b_co];
}
function kthtoan_Fs_LAY_COT() {
    return GridX_Fas_tenCot(b_kthtoan_gridId);
}
function kthtoan_datA(b_hang, b_cot) {
    if (GridX_Fi_timHangC(b_kthtoan_gridId) < 1) kthtoan_ChenDong('C');
    GridX_datA(b_kthtoan_gridId, b_hang, b_cot);
}
function kttoan_P_FILE() {
    try { sktkt_ct.Fs_FILE(kthtoan_P_FILE_KQ, P_LOI_CSDL, P_LOI_TGIAN); }
    catch (err) { form_P_LOI(err); }
}
function kthtoan_P_FILE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else kthtoan_P_NHAN_BANG(b_kq);
}
