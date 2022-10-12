var ns_nl_cdanh_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_nhomId, b_so_idId, b_kq = 'NS_CB',b_ctr, b_hang, b_f_tkhao, ns_nl_cdanh_choAct = 0,
    b_nhom_nlId,b_nanglucId;
function ns_nl_cdanh_P_KD() {
    ns_nl_cdanh_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
    b_gtrdkId = form_Fs_VUNG_ID('GR_gtrdk'); b_td_dkId = form_Fs_VUNG_ID('id_tk'); b_td_checkId = form_Fs_VUNG_ID('id_check');
    b_slideId = b_grlkeId + '_slide';
   // ns_nl_cdanh_P_NPA('dk');
    b_nhomId = form_Fs_TEN_ID(b_vungId, 'NHOM');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_nhom_nlId = form_Fs_VTEN_ID(b_vungId, 'nhom_nl');b_nanglucId = form_Fs_VTEN_ID(b_vungId, 'nang_luc');
    ns_nl_cdanh_lkeCho = setInterval('ns_nl_cdanh_P_LKE_CHO()', 200);
}


function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if(b_dtuong.indexOf("NHOM") >= 0)
        {
            $get(b_nhomId).value = b_kq; $get(b_gchuId).innerHTML = a_tso[1];
            GridX_datBang(b_gtrdkId,'');
            GridX_datBang(b_grctId,'');
            ns_nl_cdanh_NHOM_NL();

        }
       
    }
    catch (err) { form_P_LOI(err); }
}

function ns_nl_cdanh_Update(b_event) {
    try {
        b_ctr = form_Fctr_event(b_event);
        b_hang = GridX_Fi_timHangA(b_grctId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase(), b_ktra = b_ctr.getAttribute('ktra');
        b_f_tkhao = b_ctr.getAttribute('f_tkhao');
        var b_ten = C_NVL(GridX_Fas_layGtri(b_grctId, b_hang, "ten"));
        if (b_f_tkhao == null) return false;
        if (b_value != "") {
            if (b_cot == "GTRI_TU" || b_cot == "GTRI_TOI") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), b_ten, b_value, b_ktra, ns_nl_cdanh_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        if (b_value != "") GridX_ThemHang(b_grctId);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_nl_cdanh_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq.substring(0, b_kq.length - 4) + ",Vui lòng nhấn F1 để lựa chọn:loi");
        GridX_datA(b_grctId, b_hang, b_ctr.getAttribute('ten_goc'));
        b_ctr.value = "";
        return false;
    }
    $get(b_gchuId).innerHTML = b_kq;
}
var b_mnhom = ["NS_CB"];
var b_dk = 0;
function ns_nl_cdanh_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "NHOM": b_maId = b_nhomId; break;
            case "NHOM_NL": b_maId = b_nhom_nlId; break;
            case "NANG_LUC": b_maId =b_nanglucId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "NHOM") {
            var b_kq = b_ma.value;
            ns_nl_cdanh_P_LKE_CT(b_kq);
            ns_nl_cdanh_P_LKE_HIENTHI(b_kq);            
        }
        else if (b_maTen == "NHOM_NL") ns_nl_cdanh_NHOM_NL();
        else if (b_maTen == "NANG_LUC") ns_nl_cdanh_NANGLUC();

    }
    catch (err) { form_P_LOI(err); }
}
function ns_nl_cdanh_CHECKNHOM(b_kq) {
    try {
        for (var i = 0; i < b_mnhom.length; i++) {
            if (b_kq == b_mnhom[i]) {
                b_dk = 1;
            }
        }
        if (b_dk == 0) {
            ns_nl_cdanh_P_LKE_CT(b_kq);
            ns_nl_cdanh_P_LKE_HIENTHI(b_kq);
            var i = b_mnhom.length;
            b_mnhom[i] = b_kq;
            return;
        } else return;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_nl_cdanh_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_nl_cdanh_lkeCho); ns_nl_cdanh_P_LKE(); }
}
function ns_nl_cdanh_P_LKE() {
    var b_nhom = $get(b_nhomId).value;
    ns_nl_cdanh_P_LKE_CT(b_nhom);
    ns_nl_cdanh_P_LKE_HIENTHI(b_nhom);
}
function ns_nl_cdanh_P_LKE_CT(b_nhom) {
    try {
        var a_cot = GridX_Fas_tenCot(b_gtrdkId);
        sti_ch.Fs_NS_TK_LKE_CT(b_nhom, a_cot, ns_nl_cdanh_P_LKE_CT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function ns_nl_cdanh_P_LKE_CT_KQ(b_kq) {
    b_dt_dk = GridX_Fdt_cotGtri(b_grctId);
    var a_kq = Fas_ChMang(b_kq, '#');
    if (a_kq[0] == "") GridX_datTrang(b_gtrdkId);
    else {       
        GridX_dat_hangkt(b_gtrdkId, a_kq[1]);
        GridX_datBang(b_gtrdkId, a_kq[0]);
    }
}
function ns_nl_cdanh_P_NL_LKE() {
    try {
        var b_ma_nhom = $get(b_nhomId).value, a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_DGNL_DM_NL_LKE(b_ma_nhom, a_tso, a_cot, dgnl_dm_nl_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function dgnl_dm_nl_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_nl_cdanh_P_LKE_HIENTHI(b_nhom) {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId);
        sti_ch.Fs_NS_MA_KQ_HIENTHI_CT(b_nhom, a_cot, ns_nl_cdanh_P_LKE_HIENTHI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_nl_cdanh_P_LKE_HIENTHI_KQ(b_kq) {
    var b_dt_dk = GridX_Fdt_cotGtri(b_grlkeId);
    var a_kq = Fas_ChMang(b_kq, '#');
    if (b_kq[0] == "") GridX_datTrang(b_grlkeId);
    else {
        GridX_dat_hangkt(b_grlkeId, a_kq[1]);
        GridX_datBang(b_grlkeId, a_kq[0]);        
    }
}
function ns_nl_cdanh_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var b_nhnl = form_Fs_TEN_GTRI(b_vungId, 'nhom_nl'), b_nangluc = form_Fs_TEN_GTRI(b_vungId, 'nang_luc'), b_nhom = $get(b_nhomId).value;
    var a_cot_ct = GridX_Fdt_cotGtri(b_grctId);
    sns_hdns.Fs_LKE_NL_NH(b_nhom, b_nhnl, b_nangluc, a_cot_ct, ns_nl_cdanh_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function ns_nl_cdanh_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else { form_P_LOI("loi:Nhập thành công:loi");}
}
function ns_nl_cdanh_P_TIM_KQ(b_kq) {
    var tencot = "";
    var b_ktra = GridX_Fdt_cotGtri(b_grlkeId, ["chon", "nhom", "ma"]);
    var b_gt = b_ktra[1];
    for (var i = 0; i < b_gt.length; i++) {
        if (b_gt[i][0] == "X") {
            tencot = tencot + "," + b_gt[i][2];
        }
    }
    tencot = "sott" + tencot;
    form_P_MO("ti_ketqua_tk.aspx", null, ["KQ", [b_kq, tencot]]);
}

function ns_nl_cdanh_GR_gtrdk_ActiveRowChange(gridId, rowId) {
    if (ns_nl_cdanh_choAct != 0) { clearTimeout(ns_nl_cdanh_choAct); ns_nl_cdanh_choAct = 0; }
    ns_nl_cdanh_choAct = setTimeout("ns_nl_cdanh_GR_gtrdk_P_CHO()", 300);
    return true;
}
function ns_nl_cdanh_GR_gtrdk_CHUYEN() {
    var b_i = GridX_Fi_timHangA(b_gtrdkId);
    var b_ten_nhom_nl = C_NVL(GridX_Fas_layGtri(b_gtrdkId, b_i, "ten_nhom_nl")),
        b_ten_nang_luc = C_NVL(GridX_Fas_layGtri(b_gtrdkId, b_i, "ten_nang_luc")),
        b_muc_nl = C_NVL(GridX_Fas_layGtri(b_gtrdkId, b_i, "muc_nl")),
        b_mota_theomuc = C_NVL(GridX_Fas_layGtri(b_gtrdkId, b_i, "mota_theomuc")),
        b_nhom_nl = C_NVL(GridX_Fas_layGtri(b_gtrdkId, b_i, "nhom_nl")),
        b_nang_luc = C_NVL(GridX_Fas_layGtri(b_gtrdkId, b_i, "nang_luc"));
    var b_hang = GridX_Fi_timHangT(b_grctId);
    if (b_hang < 0) { GridX_ThemHang(b_grctId); b_hang = GridX_Fi_timHangT(b_grctId); }
    else GridX_chenHang(b_grctId, b_hang);   
    GridX_datGtri(b_grctId, b_hang, ["ten_nhom_nl", "ten_nang_luc", "muc_nl", "mota_theomuc", "nhom_nl", "nang_luc"], [b_ten_nhom_nl, b_ten_nang_luc, b_muc_nl, b_mota_theomuc, b_nhom_nl, b_nang_luc]);
    GridX_boChon(b_gtrdkId);
}
function ns_nl_cdanh_GR_ct_CHUYEN() {
    var b_i = GridX_Fi_timHangA(b_grctId);
    var b_ten_nhom_nl = C_NVL(GridX_Fas_layGtri(b_grctId, b_i, "ten_nhom_nl")),
        b_ten_nang_luc = C_NVL(GridX_Fas_layGtri(b_grctId, b_i, "ten_nang_luc")),
        b_muc_nl = C_NVL(GridX_Fas_layGtri(b_grctId, b_i, "muc_nl")),
        b_mota_theomuc = C_NVL(GridX_Fas_layGtri(b_grctId, b_i, "mota_theomuc")),
        b_nhom_nl = C_NVL(GridX_Fas_layGtri(b_grctId, b_i, "nhom_nl")),
        b_nang_luc = C_NVL(GridX_Fas_layGtri(b_grctId, b_i, "nang_luc"));
    var b_hang = GridX_Fi_timHangT(b_gtrdkId);
    if (b_hang < 0) { GridX_ThemHang(b_gtrdkId); b_hang = GridX_Fi_timHangT(b_gtrdkId); }
    else GridX_chenHang(b_gtrdkId, b_hang);
    GridX_datGtri(b_gtrdkId, b_hang, ["ten_nhom_nl", "ten_nang_luc", "muc_nl", "mota_theomuc", "nhom_nl", "nang_luc"], [b_ten_nhom_nl, b_ten_nang_luc, b_muc_nl, b_mota_theomuc, b_nhom_nl, b_nang_luc]);
    GridX_boChon(b_grctId);
}
function ns_nl_cdanh_NHOM_NL()
{
    var b_nhnl = form_Fs_TEN_GTRI(b_vungId, 'nhom_nl');
    sdg.Fs_DGNL_DM_NL_LKE_DK(b_nhnl, dgnl_dm_n_nl_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function dgnl_dm_n_nl_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else
    {
        list_P_LKE(form_Fs_TEN_ID(b_vungId, 'nang_luc'), b_kq);
        GridX_datTrang(b_grctId); GridX_datTrang(b_gtrdkId);
    }
}
function ns_nl_cdanh_NANGLUC() {
    var b_nhnl = form_Fs_TEN_GTRI(b_vungId, 'nhom_nl'), b_nangluc = form_Fs_TEN_GTRI(b_vungId, 'nang_luc');   
    sns_hdns.Fs_LKE_NL(b_nhnl,b_nangluc, ns_nl_cdanh_NANGLUC_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_nl_cdanh_NANGLUC_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else
    {
        GridX_datBang(b_gtrdkId, b_kq);
        var b_nhnl = form_Fs_TEN_GTRI(b_vungId, 'nhom_nl'), b_nangluc = form_Fs_TEN_GTRI(b_vungId, 'nang_luc'), b_nhom = $get(b_nhomId).value;
        var a_cot_ct = GridX_Fdt_cotGtri(b_gtrdkId);
        sns_hdns.Fs_LKE_NL_CDANH(b_nhom,b_nhnl, b_nangluc,a_cot_ct, ns_nl_cdanh_NANGLUC_KQ_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function ns_nl_cdanh_NANGLUC_KQ_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else
    {
        var a_kq = Fas_ChMang(b_kq, '#');
        GridX_datBang(b_gtrdkId, a_kq[0]);
        GridX_datBang(b_grctId, a_kq[1]);
        
    }
}
function ns_nl_cdanh_CatDong() {
    var b_active = GridX_Fi_timHangA(b_grctId);
    GridX_datA(b_grctId, b_active);
    var b_nhom = C_NVL(GridX_Fas_layGtriA(b_grctId, "nhom")),
       b_ma = C_NVL(GridX_Fas_layGtriA(b_grctId, "ma")),
       b_ten = C_NVL(GridX_Fas_layGtriA(b_grctId, "ten")),
       b_loai = C_NVL(GridX_Fas_layGtriA(b_grctId, "loai")),
        b_ktra = C_NVL(GridX_Fas_layGtriA(b_grctId, "ktra")),
        b_f_tkhao = C_NVL(GridX_Fas_layGtriA(b_grctId, "f_tkhao"));
    var b_hang = GridX_Fi_timHangT(b_gtrdkId);
    if (b_hang < 0) { GridX_ThemHang(b_gtrdkId); b_hang = GridX_Fi_timHangT(b_gtrdkId); }
    GridX_datGtri(b_gtrdkId, b_hang, ["nhom", "ma", "ten", "loai", "ktra", "f_tkhao"], [b_nhom, b_ma, b_ten, b_loai, b_ktra, b_f_tkhao]);
    GridX_thoiA(b_gtrdkId);
    GridX_boChon(b_grctId);
    return false;
}

function ns_nl_cdanh_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_nl_cdanh_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_nl_cdanh_CHON() {
    var j = 0;
    var b_ktra = GridX_Fdt_cotGtri(b_grlkeId, ["chon", "nhom"]);
    var b_gt = b_ktra[1];
    for (var i = 0; i < b_gt.length; i++) {
        if (b_gt[i][0] == "X") { j++; }
    }
    if (j == 0) {
        for (var i = 0; i < b_gt.length; i++) {
            if (b_gt[i][1] != "") {
                GridX_datGtri(b_grlkeId, i + 1, ["chon"], ["X"]);
            }
        }
    }
    else {
        for (var i = 0; i < b_gt.length; i++) {
            GridX_datGtri(b_grlkeId, i + 1, ["chon"], [""]);
        }
    }
}

function GridX_Fctr_TimCtr(gridId, b_hang, b_cot) {
    try {
        var a_cot = GridX_Fas_tenCot(gridId);
        var b_icot = Fi_vtri_mang(a_cot, b_cot) + 1;
        var b_cell = $get(gridId).rows[b_hang].cells[b_icot], b_kq = null
        var a_ctr = b_cell.getElementsByTagName('input');
        if (a_ctr.length > 0) b_kq = a_ctr[0];
        else {
            a_ctr = b_cell.getElementsByTagName('select');
            if (a_ctr.length > 0) b_kq = a_ctr[0];
            else {
                a_ctr = b_cell.getElementsByTagName('span');
                if (a_ctr.length > 0) b_kq = a_ctr[0];
            }
        }
        return b_kq;
    }
    catch (err) { return null; }
}

function GridX_dat_hangkt(b_gridx, sodong) {
    try {
        var b_grid = $get(b_gridx);
        b_grid.setAttribute('hangKt', '18');
        var b_hangkt = GridX_Fi_hangKt(b_gridx);
        if (sodong > b_hangkt) {
            b_grid.setAttribute('hangKt', sodong - b_hangkt + 19);
        }
        return false;
    } catch (err) { form_P_LOI(err); }
}

function form_dong() {
    location.reload(false);
}
