var b_vungId, b_vung_gvId, b_vung_dgId, b_id_cutId, b_vung_tsId, b_so_idId, b_grlkeId, b_slideId, b_mode, b_gchuId, b_id_tsId, b_grtslkeId, b_slidetsId;
var b_doi = 0, b_cho_control = 0, b_tu_gioId, b_tu_phutId, b_den_gioId, b_den_phutId, b_so_phutId;
function ns_ts_timkiem_KD() {
    b_vungId = form_Fs_VUNG_ID('UPa_ct');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_id_cutId = form_Fs_VTEN_ID('UPa_hi', 'id_cut');
    b_id_tsId = form_Fs_VTEN_ID('UPa_hi', 'id_ts');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_grlkeId = form_Fs_VUNG_ID('GR_lke');
    b_ng_nhan_tkId = form_Fs_TEN_ID(b_vungId, 'NG_NHAN_TK');
    b_vung_gvId = form_Fs_VUNG_ID('tab_pgiaoviec');
    b_ng_nhanId = form_Fs_TEN_ID(b_vung_gvId, 'ng_nhan');
    b_ma_duanId = form_Fs_TEN_ID(b_vung_gvId, 'ma_du_an');
    b_hien_daihanId = form_Fs_VUNG_ID('hien_daihan');
    b_hien_nganhanId = form_Fs_VUNG_ID('hien_nganhan');
    b_grctId = form_Fs_VUNG_ID('GR_ct');
    b_slideId = b_grlkeId + '_slide';
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("MA") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang > -1) {
                GridX_datGtri(b_grctId, b_hang, "ma", b_kq);
                GridX_datGtri(b_grctId, b_hang, "ten", a_tso[1]);
            }
        }
    } catch (err) { form_P_LOI(err); }
}

function ns_ts_timkiem_P_KTRA(b_maTen) {
    try {
        b_maTen = b_maTen.toUpperCase();
        if (b_maTen == "GIO") {
            if (O_NVL($get(b_tu_gioId).value, 0) * 1 >= 24 || O_NVL($get(b_den_gioId).value, 0) * 1 >= 24)
                form_P_LOI('loi:Giờ không quá 24:loi');
            if (O_NVL($get(b_tu_phutId).value, 0) * 1 >= 60 || O_NVL($get(b_den_phutId).value, 0) * 1 >= 60)
                form_P_LOI('loi:Phút không quá 60:loi');
            $get(b_so_phutId).value = -(O_NVL($get(b_tu_gioId).value, 0) * 60 + O_NVL($get(b_tu_phutId).value, 0) * 1 - O_NVL($get(b_den_gioId).value, 0) * 60 - O_NVL($get(b_den_phutId).value, 0) * 1);
        }
    } catch (err) { form_P_LOI(err); }
}

function ns_ts_timkiem_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}

function ns_ts_timkiem_P_LKE() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_cot_ct = GridX_Fdt_cotGtri(b_grctId);
            var b_dt = form_Faa_TEXT_ROW(b_vungId); var a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_ts.Fs_NS_TS_TIMKIEM_LKE(form_Fs_nsd(), b_dt, a_cot, a_cot_ct, ns_ts_timkiem_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    } catch (err) {
        form_P_LOI(err);
    }
}

function ns_ts_timkiem_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#'); GridX_dat_hangkt(b_grlkeId, a_kq[1]); GridX_datBang(b_grlkeId, a_kq[0]);
}

function GridX_dat_hangkt(b_gridx, sodong) {
    try {
        var b_grid = $get(b_gridx);
        b_grid.setAttribute('hangKt', '15');
        var b_hangkt = GridX_Fi_hangKt(b_gridx);
        if (sodong > b_hangkt) {
            b_grid.setAttribute('hangKt', sodong - b_hangkt + 16);
        }
        return false;
    } catch (err) { form_P_LOI(err); }
}


function ns_ts_tim_P_CHON() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang > 0) {
        form_P_TRA_CHON_GRID('GR_lke:ng_nhan,GR_lke:ten');
    }
    else form_P_TRA_CHON('NG_NHAN_TK');
}

// START: Trả giá trị chọn trên lưới //       
// Tra gia tri chon cho form goi
function form_P_TRA_CHON_GRID(b_ten) {
    try {
        var b_kq = [];
        b_kq[0] = "lưới";
        b_kq[1] = "GIATRI";
        var a_kq = form_P_TRA_GTRI_GRID(b_ten);
        b_kq = b_kq + "," + a_kq; b_kq = Fas_ChMang(b_kq, ',');
        form_P_DONG(window.name, b_kq);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
// Tra mang gia tri theo ten
function form_P_TRA_GTRI_GRID(b_ten) {
    try {
        var a_ten = b_ten.split(','), a_kq = [];
        for (var i = 0; i < a_ten.length; i++) {
            var a_grid = a_ten[i].split(':');
            var b_gridId = form_Fs_VUNG_ID(a_grid[0]);
            var b_hang = GridX_Fi_timHangA(b_gridId);
            a_kq[i] = GridX_Fas_layGtri(b_gridId, b_hang, a_grid[1]);
        }
        return a_kq;
    }
    catch (err) { return null; }
}

function ns_ts_gv_P_MO_GV(b_mo, b_dk) {
    if (b_mo) {
        var b_ng_nhan = $get(b_ng_nhan_tkId).value;
        if (b_ng_nhan != "TC") $get(b_ng_nhanId).value = b_ng_nhan;
        else {
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang > 0) {
                b_ng_nhan = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ng_nhan"))
                $get(b_ng_nhanId).value = b_ng_nhan;
            }
            else { form_P_LOI("loi:Chưa chọn nhân sự book:loi"); return; }
        }
        $get(b_vung_gvId).style.display = '';
    }
    else $get(b_vung_gvId).style.display = 'none';
    form_P_LOI(''); return false;
}
function ns_ts_gv_P_CT_MOI(b_dk) {
    form_P_MOI(b_vung_gvId, b_dk);
}

function ns_ts_gv_P_ENABLE() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
        var b_hien = '';
        if (b_so_id == "") b_hien = 'none';
        $get(b_btn_ct_id).style.display = b_hien;
        $get(b_huy_id).style.display = b_hien;
        $get(b_ts_id).style.display = b_hien;
        $get(b_danhgia_id).style.display = b_hien;
        $get(b_trao_doi_id).style.display = b_hien;
    } catch (err) { form_P_LOI(err); }
}

function ns_ts_timkiem_anhien() {
    var b_ma_duan = $get(b_ma_duanId).value;
    if (b_ma_duan == "NH") {
        $get(b_hien_daihanId).style.display = "none";
        $get(b_hien_nganhanId).style.display = "table-row";
    }
    else {
        $get(b_hien_daihanId).style.display = "table-row";
        $get(b_hien_nganhanId).style.display = "none";
    }
}


function ns_bookns_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vung_gvId);
    if (b_loi != "") form_P_LOI(b_loi);
    else {
        var a_dt = form_Faa_TEXT_ROW(b_vung_gvId);
        var b_so_id = 0;
        sns_ts.Fs_NS_TS_BOOKNS_NH(form_Fs_nsd(), b_so_id, a_dt, ns_bookns_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    return false;
}

function ns_bookns_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI("loi:Book nhân sự thành công:loi"); return false;
    }
}

function ns_ts_gv_P_TT() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_the = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ng_nhan"));
        if (b_so_the == "") { form_P_LOI('loi:Chưa chọn cán bộ xem!:loi'); return false; }
        else {
            var b_tenf = form_Fs_TM('f') + '/ns/tt/ns_cb.aspx';
            form_P_MO(b_tenf, window.name, ["THOIVIEC", [b_so_the]], null);
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function form_dong() {
    location.reload(false);
}