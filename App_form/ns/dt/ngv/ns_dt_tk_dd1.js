var ns_dt_tk_dd_lkeCho, b_grlkeId, b_slideId, b_gchuId, b_so_id_tk, b_so_id_tkb, b_nsd;

function ns_dt_tk_dd_P_KD() {
    b_grlkeId = form_Fs_VUNG_ID('GR_lke'),    
    b_slideId = b_grlkeId + '_slide';
    b_gchuId = form_Fs_VTEN_ID('UPa_gchu', 'gchu');
    b_nsd = form_Fs_nsd();
    //ns_dt_tk_dd_lkeCho = setInterval('ns_dt_tk_dd_P_LKE_CHO()', 200);
}
// use
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
        }
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            b_so_id_tk = a_tso[1];
            var b_ttin_kdtId = form_Fs_VTEN_ID('', 'ttin_kdt');
            $get(b_ttin_kdtId).innerHTML = a_tso[2] + " - " + a_tso[3];
            ns_dt_tk_dd_P_KQDD_DM();            
        }
        else if (b_dtuong.indexOf("GVIEN") >= 0) {
            $get(b_so_id_gvId).value = a_tso[0];
            $get(b_gvienId).value = a_tso[1];
        }
    }
    catch (err) { form_P_LOI(err); }
}

// use
function ns_dt_tk_dd_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_dt_tk_dd_lkeCho); ns_dt_tk_dd_P_LKE(); }
}
// use
function ns_dt_tk_dd_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.Fs_NS_DT_TK_DD_LKE(b_nsd, b_so_id_tk, a_tso, a_cot, ns_dt_tk_dd_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
// use
function ns_dt_tk_dd_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    b_so_id_tkb = a_kq[2].split(",");
}
// use: danh mục kết quả điểm danh
function ns_dt_tk_dd_P_KQDD_DM() {
    try {        
        sns_ma_ch.Fs_NS_MA_CHUNG_LKE_DR("KQDD", ns_dt_tk_dd_P_KQDD_DM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
// use
function ns_dt_tk_dd_P_KQDD_DM_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }

    var a_kq = Fas_ChMang(b_kq, '#');
    GridX_listCot(b_grlkeId, "kq", a_kq[1], a_kq[0]);// b_lke = mảng text, b_tra = mảng value    
    ns_dt_tk_dd_P_LKE();
}

// use
function ns_dt_tk_dd_GR_Update(b_event) {
    try {
        var b_hang = b_event.srcElement.parentNode.parentNode.rowIndex;
        var b_so_the = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the");
        if (b_so_the == "") {
            GridX_datTrang(b_grlkeId, b_hang);
            return;
        }
        var b_id = b_event.srcElement.id;
        var b_dd = false;
        for (var i = 0; i < b_so_id_tkb.length; i++) {
            if (b_id.indexOf(b_so_id_tkb[i]) > 0) {
                b_dd = true;
                break;
            }
        }
        if (!b_dd) return;
        
        var b_coMat = 0;
        for (var i = 0; i < b_so_id_tkb.length; i++) {
            var b_tt = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, b_so_id_tkb[i]));
            if (b_tt == "P")
                b_coMat++;
        }
        var b_tl = Math.round((b_coMat / b_so_id_tkb.length) * 100);
        GridX_datGtri(b_grlkeId, b_hang, ["tl"], b_tl, 'K');        
    }
    catch (ex) { form_P_LOI(ex.message); }
}
//// use
//function ns_dt_tk_dd_P_TK() {
//    var b_so_id = '';
//    var b_hang = GridX_Fi_timHangA(b_grlkeId);
//    if (b_hang > 0) {
//        b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
//    }
//    if (b_so_id == '' || b_so_id == '0') {
//        form_P_LOI('Bạn chưa chọn kế hoạch đào tạo nào!');
//        return false;
//    }
//    form_P_MO('/App_form/ns/dt/ngv/ns_dt_tk.aspx', window.name, ["THAMSO", [window.name, b_so_id]]);
//    return false;
//}
// use
function ns_dt_tk_dd_P_NH() {
    try {        
        var a_dt_ct = GridX_Fdt_cotGtri(b_grlkeId);
        sns_dt.Fs_NS_DT_TK_DD_NH(b_nsd, b_so_id_tk, b_so_id_tkb, a_dt_ct, ns_dt_tk_dd_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { throw (err); }
}

// use
function ns_dt_tk_dd_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    else ns_dt_tk_dd_P_DatGchu(true, "Cập nhật thành công!");
    return false;
}

// use
function ns_dt_tk_dd_P_MOI() {
    form_P_MOI(b_grlkeId, "XL");
    //Số hàng đã nhập của grid
    //gridId(string): Id lưới
    var b_hang = GridX_Fi_hangSo(b_grlkeId);
    var b_cot = b_so_id_tkb.length + 9;
    //GridX_datTrang(b_grlkeId,6);
    GridX_thayGtriT(b_grlkeId, "", "");
    //for (var i = 0; i < b_hang; i++) {
    //    GridX_datTrang(b_grlkeId, 2, i);
    //}
    
    //GridX_datTrang(b_grlke_cpId);
    return false;
}

// use
function ns_dt_tk_dd_P_XOA() {
    if (b_so_id_tk == 0) { form_P_LOI("Chưa có thông tin triển khai lớp đào tạo để xóa"); return false; }
    sns_dt.Fs_NS_DT_TK_DD_XOA(b_nsd, b_so_id_tk, ns_dt_tk_dd_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
// use
function ns_dt_tk_dd_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        ns_dt_tk_dd_P_MOI();
    }
    return false;
}
function ns_dt_tk_dd_P_DatGchu(show, gchu) {
    form_P_DatGchu(b_gchuId, gchu);
    if (show) ns_dt_tk_diem_gchuCho = setInterval('ns_dt_tk_dd_P_DatGchu(false,".")', 2000);
    else clearTimeout(ns_dt_tk_diem_gchuCho);
}
// use
function ns_dt_tk_dd_P_EXCEL() {

}
// use
function form_dong() {
    location.reload(false);
}