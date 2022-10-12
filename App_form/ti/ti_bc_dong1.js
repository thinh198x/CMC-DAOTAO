var ti_timkiem_lkeCho, ti_bc_dong_choAct, b_vungId, b_grlkeId, b_slideId, b_gocId, b_nhomId, b_so_idId, b_kq = 'NS_CB',
    b_ctr, b_hang, b_f_tkhao, ti_bc_dong_choAct = 0, b_tenId, b_chon_allId;
function ti_timkiem_P_KD() {
    ti_timkiem_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
        b_gtrdkId = form_Fs_VUNG_ID('GR_gtrdk'); b_td_dkId = form_Fs_VUNG_ID('id_tk');
    b_slideId = b_grlkeId + '_slide';
    ti_bc_dong_P_NPA('dk');
    b_tenId = form_Fs_TEN_ID(b_vungId, 'ten'), b_ng_moId = form_Fs_TEN_ID(b_vungId, 'NG_MO');
    b_nhomId = form_Fs_TEN_ID(b_vungId, 'NHOM'), b_khId = form_Fs_TEN_ID(b_vungId, 'KH');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'), b_anNhomId = form_Fs_VTEN_ID('UPa_hi', 'anNhom');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu'); b_chon_allId = form_Fs_VTEN_ID('UPa_hi', 'acheckall');
    ti_timkiem_lkeCho = setInterval('ti_timkiem_P_LKE_CHO()', 200);
    $get(b_anNhomId).value = lke_Fs_TRA($get(b_nhomId));
}

function ti_bc_dong_P_NPA(b_nv) {
    if (b_nv != "dk") {
        $get(b_td_dkId).style.display = "none";
    }
    else {
        $get(b_td_dkId).style.display = "inline";
    }
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("GTRI_TU") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang > -1) { GridX_datGtri(b_grctId, b_hang, "gtri_tu", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
        }
        if (b_dtuong.indexOf("GTRI_TOI") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang > -1) { GridX_datGtri(b_grctId, b_hang, "gtri_toi", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ti_bc_dong_Update(b_event) {
    try {
        b_ctr = form_Fctr_event(b_event);
        b_hang = GridX_Fi_timHangA(b_grctId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase(), b_ktra = b_ctr.getAttribute('ktra');
        b_f_tkhao = b_ctr.getAttribute('f_tkhao');
        var b_ten = C_NVL(GridX_Fas_layGtri(b_grctId, b_hang, "ten"));
        if (b_f_tkhao == null) return false;
        if (b_value != "") {
            if (b_cot == "GTRI_TU" || b_cot == "GTRI_TOI") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), b_ten, b_value, b_ktra, ti_bc_dong_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        if (b_value != "") GridX_ThemHang(b_grctId);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ti_bc_dong_P_DatGchu(b_kq) {
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
function ti_bc_dong_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "NHOM": b_maId = b_nhomId; break;
            case "NG_MO": b_maId = b_ng_moId; break;
        }
        var b_ma = $get(b_maId);
        if (b_maTen == "NHOM") {
            if (b_ma == null || C_NVL(b_ma.value) == "") return;
            $get(b_anNhomId).value = lke_Fs_TRA($get(b_nhomId))
            var b_kq = lke_Fs_TRA($get(b_nhomId));
            GridX_datTrang(b_grctId);
            ti_bc_dong_P_LKE_HIENTHI(b_kq);
        } else if (b_maTen == "NG_MO") {
            if (C_NVL(b_ma.value) == "") {
                var b_drop = form_Fctr_TEN_DTUONG(b_vungId, 'kh');
                list_P_DAT(b_drop, 'AND');
                $get(b_khId).removeAttribute("disabled");
            } else {
                $get(b_khId).value = ""; $get(b_khId).text = "";
                Attribute_P_DAT(form_Fctr_TEN_DTUONG(b_vungId, 'kh'), "BackColor", "#f6f7f7");
                Attribute_P_DAT(form_Fctr_TEN_DTUONG(b_vungId, 'kh'), "disabled", true);
            }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ti_bc_dong_CHECKNHOM(b_kq) {
    try {
        for (var i = 0; i < b_mnhom.length; i++) {
            if (b_kq == b_mnhom[i]) {
                b_dk = 1;
            }
        }
        if (b_dk == 0) {
            ti_bc_dong_P_LKE_CT(b_kq);
            ti_bc_dong_P_LKE_HIENTHI(b_kq);
            var i = b_mnhom.length;
            b_mnhom[i] = b_kq;
            return;
        } else return;
    }
    catch (err) { form_P_LOI(err); }
}
function ti_timkiem_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ti_timkiem_lkeCho); ti_timkiem_P_LKE(); }
}
function ti_timkiem_P_LKE() {
    var b_nhom = lke_Fs_TRA($get(b_nhomId));
    //ti_bc_dong_P_LKE_CT(b_nhom);
    ti_bc_dong_P_LKE_HIENTHI(b_nhom);
    GridX_datGtri(b_grctId, 1, ["dk"], [""]);
}
function ti_bc_dong_P_LKE_CT(b_nhom) {
    try {
        var a_cot = GridX_Fas_tenCot(b_gtrdkId);
        sti_ch.Fs_NS_TK_LKE_CT(b_nhom, a_cot, ti_bc_dong_P_LKE_CT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function ti_bc_dong_P_LKE_CT_KQ(b_kq) {
    b_dt_dk = GridX_Fdt_cotGtri(b_grctId);
    var a_kq = Fas_ChMang(b_kq, '#');
    if (a_kq[0] == "") GridX_datTrang(b_gtrdkId);
    else {
        GridX_dat_hangkt(b_gtrdkId, a_kq[1]);
        GridX_datBang(b_gtrdkId, a_kq[0]);
    }
}

function ti_bc_dong_P_LKE_HIENTHI(b_nhom) {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId);
        sti_ch.Fs_NS_MA_KQ_HIENTHI_CT(b_nhom, a_cot, ti_bc_dong_P_LKE_HIENTHI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ti_bc_dong_P_LKE_HIENTHI_KQ(b_kq) {
    var b_dt_dk = GridX_Fdt_cotGtri(b_grlkeId);
    var a_kq = Fas_ChMang(b_kq, '#');
    if (b_kq[0] == "") GridX_datTrang(b_grlkeId);
    else {
        drop_P_LKE(b_tenId, a_kq[0]);
        GridX_dat_hangkt(b_grlkeId, a_kq[1]);
        GridX_datBang(b_grlkeId, a_kq[0]);
    }
}
function ti_bc_dong_P_TIM() {
    var a_cot = Array(), j = 1; a_cot[0] = "sott";
    var b_ktra = GridX_Fdt_cotGtri(b_grlkeId, ["chon", "nhom", "ma"]);
    var b_gt = b_ktra[1];
    for (var i = 0; i < b_gt.length; i++) {
        if (b_gt[i][0] == "X") {
            a_cot[j] = b_gt[i][2];
            j++;
        }
    }
    var b_nhom = lke_Fs_TRA($get(b_nhomId));
    if (j == 1) { alert("Chưa chọn dữ liệu hiển thị!"); return false; }
    else {
        var b_dt_dk = GridX_Fdt_cotGtri(b_grctId);
        var b_dt_kq = GridX_Fdt_cotGtri(b_grlkeId);
        sti_ch.Fs_NS_BC_DONG(b_nhom, b_dt_dk, b_dt_kq, a_cot, ti_bc_dong_P_TIM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
}
function ti_bc_dong_P_TIM_KQ(b_kq) {
    ti_bc_P_MAU();
    //var tencot = "";
    //var b_ktra = GridX_Fdt_cotGtri(b_grlkeId, ["chon", "nhom", "ma"]);
    //var b_gt = b_ktra[1];
    //for (var i = 0; i < b_gt.length; i++) {
    //    if (b_gt[i][0] == "X") {
    //        tencot = tencot + "," + b_gt[i][2];
    //    }
    //}
    //tencot = "sott" + tencot;
    //form_P_MO("ti_ketqua_tk.aspx", null, ["KQ", [b_kq, tencot]]);
}

function ti_bc_dong_GR_gtrdk_ActiveRowChange(gridId, rowId) {
    if (ti_bc_dong_choAct != 0) { clearTimeout(ti_bc_dong_choAct); ti_bc_dong_choAct = 0; }
    ti_bc_dong_choAct = setTimeout("ti_bc_dong_GR_gtrdk_P_CHO()", 300);
    return true;
}
function ti_bc_dong_GR_gtrdk_CHUYEN() {
    var b_f1 = "";
    var b_i = GridX_Fi_timHangA(b_gtrdkId);
    var b_nhom = C_NVL(GridX_Fas_layGtri(b_gtrdkId, b_i, "nhom")),
        b_ma = C_NVL(GridX_Fas_layGtri(b_gtrdkId, b_i, "ma")),
        b_ten = C_NVL(GridX_Fas_layGtri(b_gtrdkId, b_i, "ten")),
        b_loai = C_NVL(GridX_Fas_layGtri(b_gtrdkId, b_i, "loai")),
        b_ktra = C_NVL(GridX_Fas_layGtri(b_gtrdkId, b_i, "ktra")),
        b_f_tkhao = C_NVL(GridX_Fas_layGtri(b_gtrdkId, b_i, "f_tkhao"));
    var b_hang = GridX_Fi_timHangT(b_grctId);
    if (b_hang < 0) { GridX_ThemHang(b_grctId); b_hang = GridX_Fi_timHangT(b_grctId); }
    else GridX_chenHang(b_grctId, b_hang);
    b_ctr_gtu = GridX_Fctr_TimCtr(b_grctId, b_hang, "gtri_tu");
    b_ctr_gtoi = GridX_Fctr_TimCtr(b_grctId, b_hang, "gtri_toi");
    if (b_f_tkhao != "") {
        b_ctr_gtu.setAttribute("f_tkhao", form_Fs_TM() + b_f_tkhao);
        b_ctr_gtoi.setAttribute("f_tkhao", form_Fs_TM() + b_f_tkhao);
        b_f1 = "(F1)";
    }
    if (b_ktra != "") {
        b_ctr_gtu.setAttribute("ktra", b_ktra);
        b_ctr_gtoi.setAttribute("ktra", b_ktra);
    }
    switch (b_loai) {
        case "C":
            b_ctr_gtu.setAttribute("kieu_unicode", "C");
            break;
        case "H":
            b_ctr_gtu.setAttribute("kieu_chu", "C");
            break;
        case "S":
            b_ctr_gtu.setAttribute("kieu_so", "C");
            break;
        case "N":
            b_ctr_gtu.setAttribute("kieu_date", "C");
            break;
    }
    GridX_datGtri(b_grctId, b_hang, ["f1", "nhom", "ma", "ten", "loai", "ktra", "f_tkhao"], [b_f1, b_nhom, b_ma, b_ten, b_loai, b_ktra, b_f_tkhao]);
    GridX_datA(b_grctId, b_hang, "gtri_tu");
}
function ti_bc_dong_CatDong() {
    var b_active = GridX_Fi_timHangA(b_grctId);
    GridX_datA(b_grctId, b_active);
    GridX_boChon(b_grctId, 'C');
    return false;
}
function ti_bc_dong_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ti_bc_dong_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}

function ti_bc_dong_CHON() {
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

function ti_bc_dong_THEM_DK() {
    if (ti_bc_dong_choAct != 0) clearTimeout(ti_bc_dong_choAct);
    ti_bc_dong_choAct = setTimeout("ti_bc_dong_P_THEM_DK()", 300);
    return false;
}
function ti_bc_dong_P_THEM_DK() {
    try {
        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
        sti_ch.Fs_TI_BC_DONG_THEM_DK(a_dt_ct, ti_bc_dong_P_THEM_DK_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ti_bc_dong_P_THEM_DK_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#'), a_cot = Fas_ChMang(a_kq[0], ','), a_gtri = Fas_ChMang(a_kq[1], '|');
    var b_hang = GridX_Fi_timHangT(b_grctId);
    if (b_hang < 1) {
        b_hang = 1;
    }
    GridX_datGtri(b_grctId, b_hang, a_cot, a_gtri, 'K'); form_P_LOI("");
    return false;
}

function ti_bc_P_MAU() {
    __doPostBack('ctl00$ContentPlaceHolder1$XuatExcel', '');
}
function CheckAll(oCheckbox) {
    var b_count = GridX_Fi_timHangT(b_grlkeId);
    if (oCheckbox.checked == true) {
        $get(b_chon_allId).value = 'TATCA';
        for (i = 1; i < b_count; i++) {
            var b_so_the = C_NVL(GridX_Fas_layGtri(b_grlkeId, i, "ma"));
            if (b_so_the != "") GridX_datGtri(b_grlkeId, i, ["chon"], ['X'], 'K');
        }
    } else {
        for (i = 1; i < b_count; i++) {
            GridX_datGtri(b_grlkeId, i, ["chon"], [''], 'K');
        }
    }
}
function form_dong() {
    location.reload(false);
}