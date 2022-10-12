var b_lkeCho, b_vungId, b_grctId, b_slideId, b_gocId, b_timId, b_choAct = 0, b_tt = '', b_laytextId, b_layvalueId, b_datgiatriId;

function daotao_gridn_P_KD() {
    b_vungId = form_Fs_VUNG_ID('UPa_tk');
    b_grctId = form_Fs_VUNG_ID('GR_ct');
    //b_lkeCho = setTimeout('daotao_gridn_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "")
            return;
        b_ten_form = b_dtuong;
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("ma_pc") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            var b_count = a_tso
            if (a_tso[0] == "CMC-2M") {
                for (var i = 1; i < a_tso.length; i++) {
                    GridX_datGtri(b_grctId, b_hang, ["ma_pc"], [a_tso[i][0]], 'K');
                    GridX_datGtri(b_grctId, b_hang, ["ten"], [a_tso[i][1]], 'K');
                    GridX_datGtri(b_grctId, b_hang, ["sotien"], [a_tso[i][2]], 'K');
                    b_hang = b_hang + 1;
                }
                slide_P_SOTRANG(b_slideIdct, CSO_SO(b_hang, 0));
            } else {
                GridX_datGtri(b_grctId, b_hang, ["ma_pc"], [a_tso[0]], 'K');
                GridX_datGtri(b_grctId, b_hang, ["ten"], [a_tso[1]], 'K');
                GridX_datGtri(b_grctId, b_hang, ["sotien"], [a_tso[2]], 'K');
            }
        }
    }
    catch (err) {
        form_P_LOI(err);
    }
}

function daotao_gridn() {
    try {
        form_P_LOI("loi:Gọi đến file js:loi");
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
 
function daotao_gridn_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}
function daotao_gridn_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function daotao_gridn_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function daotao_gridn_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}

function form_dong() {
    location.reload(false);
}