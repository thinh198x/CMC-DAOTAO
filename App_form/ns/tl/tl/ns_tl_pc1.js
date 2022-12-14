
var ns_tl_pc_lkeCho, b_vungId, b_grlkeId, b_slideId, b_grtdId, b_grcdId, b_grnvId, b_grpbId, b_ngaydId, b_ngaycId, b_gchuId, b_so_idId, b_thietlapId, b_ma_pcId;
var ns_tl_pc_choAct = 0, b_hangId;
function ns_tl_pc_P_KD() {
    ns_tl_pc_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_grtdId = form_Fs_VUNG_ID('GR_TD'),
    b_grcdId = form_Fs_VUNG_ID('GR_CD'),
    b_grnvId = form_Fs_VUNG_ID('GR_NV'),
    b_grpbId = form_Fs_VUNG_ID('GR_PB'),
    b_ngaydId = form_Fs_TEN_ID(b_vungId, 'NG_HLUC'), b_ngaycId = form_Fs_TEN_ID(b_vungId, 'NG_HET_HLUC');
    b_thietlapId = form_Fs_TEN_ID(b_vungId, 'thietlap');
    b_ma_pcId = form_Fs_TEN_ID(b_vungId, 'ma_pc');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    ns_tl_pc_lkeCho = setInterval('ns_tl_pc_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grnvId);
            if (b_hang < 0) return;
            b_hangId = b_hang;
            ns_thongtin_canbo(a_tso[0]);
            
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_tl_pc_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA_PC": b_maId = b_ma_pcId; break;
            case "THIETLAP": b_maId = b_thietlapId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA_PC") {
            GridX_thoiA(b_grlkeId); ns_tl_pc_P_MA_KTRA();
        } else if (b_maTen == "NG_HLUC") {
            GridX_thoiA(b_grlkeId); ns_tl_pc_P_MA_KTRA();
        }
        else if (b_maTen == "THIETLAP") {
            $get("Div-TN").style.display = "none";
            $get("Div-CD").style.display = "none";
            $get("Div-PB").style.display = "none";
            $get("Div-TD").style.display = "none";
            $get("Div-NV").style.display = "none";
            var b_thietlap = list_Fs_TRA(b_thietlapId);
            switch (b_thietlap) {
                case "TN": $get("Div-TN").style.display = ""; break;
                case "CD": $get("Div-CD").style.display = ""; break;
                case "PB": $get("Div-PB").style.display = ""; break;
                case "TD": $get("Div-TD").style.display = ""; break;
                case "NV": $get("Div-NV").style.display = ""; break;
                default:

            }
        }
        else skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_tl_pc_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_pc_P_MA_KTRA() {
    try {
        var b_ma_pc = list_Fs_TRA(b_ma_pcId);
        var b_ng_hluc = C_NVL($get(b_ngaydId).value);
        if (b_ma_pc != "" && b_ng_hluc != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_tl.Fs_NS_TL_PC_MA(b_ma_pc, b_ng_hluc, b_TrangKt, a_cot, ns_tl_pc_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_pc_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_tl_pc_P_CHUYEN_HANG(); }
}

function ns_tl_pc_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
    } else {
        form_P_DatGchu(b_gchuId, b_kq);
    }
}
function ns_thongtin_canbo(b_so_the) {
    try {
        hts_dungchung.Fs_THONGTIN_CANBO_LUOI(b_so_the, ns_thongtin_canbo_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_thongtin_canbo_kq(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var a_kq = Fas_ChMang(b_kq, '#');
    if (a_kq !="") {
        GridX_datGtri(b_grnvId, b_hangId, "SO_THE", a_kq[1], 'K');
        GridX_datGtri(b_grnvId, b_hangId, "TEN", a_kq[2], 'K');
        GridX_datGtri(b_grnvId, b_hangId, "CDANH", a_kq[3], 'K');
        GridX_datGtri(b_grnvId, b_hangId, "PHONG", a_kq[4], 'K');
    }
    return false;
}
function ns_tl_pc_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grnvId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        if (b_value != "") {
            if (b_cot == "SO_THE") {
                b_hangId = b_hang;
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Số thẻ", b_value, "ns_cb,so_the,ten", ns_tl_pc_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
                b_ctr.value = "";
                if (b_hang < 0) return;
                ns_thongtin_canbo(b_value);
            }
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_tl_pc_GR_lke_RowChange() {
    if (ns_tl_pc_choAct != 0) clearTimeout(ns_tl_pc_choAct);
    ns_tl_pc_choAct = setTimeout("ns_tl_pc_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_tl_pc_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grnvId);
    ns_tl_pc_P_KTRA('THIETLAP');
    return false;
}
function ns_tl_pc_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var ktra = ktra_ngay(parseDate($get(b_ngaydId).value).getTime(), parseDate($get(b_ngaycId).value).getTime(), 1, "Ngày hiệu lực", " ngày hết hiệu lực");
            if (ktra.length > 0) {
                ns_tl_pc_P_NH_KQ(ktra);
                return false;
            }

            var b_dt = form_Faa_TEXT_ROW(b_vungId), b_hang = GridX_Fi_timHangA(b_grlkeId), b_so_id = '0', b_dt_nv = GridX_Fdt_cotGtri(b_grnvId),
                b_dt_td = GridX_Fdt_cotGtri(b_grtdId), b_dt_pb = GridX_Fdt_cotGtri(b_grpbId), b_dt_cd = GridX_Fdt_cotGtri(b_grcdId),
                a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId), b_thietlap = list_Fs_TRA(b_thietlapId);
            if (b_hang > 0) b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
            sns_tl.Fs_NS_TL_PC_NH(b_TrangKt, b_so_id, b_thietlap, b_dt, b_dt_nv, b_dt_td, b_dt_pb, b_dt_cd, a_cot_lke, ns_tl_pc_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_tl_pc_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_ma_pcId).focus();
        form_P_LOI('loi:Nhập thành công!:loi');
    }
    return false;
}

function ns_tl_pc_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ns_tl_pc_lkeCho != 0) clearTimeout(ns_tl_pc_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_tl_pc_P_LKE('K');
    }
}
function ns_tl_pc_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
        a_cot_pb = GridX_Fas_tenCot(b_grpbId), a_cot_cd = GridX_Fas_tenCot(b_grcdId), a_cot_td = GridX_Fas_tenCot(b_grtdId);
        sns_tl.Fs_NS_TL_PC_LKE(a_tso, a_cot, a_cot_pb, a_cot_cd, a_cot_td, ns_tl_pc_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_tl_pc_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    GridX_datBang(b_grpbId, a_kq[2]);
    GridX_datBang(b_grcdId, a_kq[3]);
    GridX_datBang(b_grtdId, a_kq[4]);
}

function ns_tl_pc_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")),
        a_cot_pb = GridX_Fas_tenCot(b_grpbId),
        a_cot_cd = GridX_Fas_tenCot(b_grcdId),
        a_cot_td = GridX_Fas_tenCot(b_grtdId),
        a_cot_nv = GridX_Fas_tenCot(b_grnvId);
    if (b_so_id == "") ns_tl_pc_P_MOI();
    else sns_tl.Fs_NS_TL_PC_CT(b_so_id, a_cot_pb, a_cot_cd, a_cot_td, a_cot_nv, ns_tl_pc_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    GridX_datA(b_grlkeId, b_hang);
    $get(b_so_idId).value = b_so_id;
}
function ns_tl_pc_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    ns_tl_pc_P_KTRA('THIETLAP');
    if (a_kq[1] == "") {
        GridX_datTrang(b_grpbId);
    }
    else {
        GridX_datBang(b_grpbId, a_kq[1]);
    }
    if (a_kq[2] == "") {
        GridX_datTrang(b_grcdId);
    }
    else {
        GridX_datBang(b_grcdId, a_kq[2]);
    }
    if (a_kq[3] == "") {
        GridX_datTrang(b_grtdId);
    }
    else {
        GridX_datBang(b_grtdId, a_kq[3]);
    }
    if (a_kq[4] == "") {
        GridX_datTrang(b_grnvId);
    }
    else {
        GridX_datBang(b_grnvId, a_kq[4]);
    }
}
function ns_tl_pc_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); ns_tl_pc_P_MOI(); return false; }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            a_cot_pb = GridX_Fas_tenCot(b_grpbId), a_cot_cd = GridX_Fas_tenCot(b_grcdId), a_cot_td = GridX_Fas_tenCot(b_grtdId);
        sns_tl.Fs_NS_TL_PC_XOA(b_so_id, a_tso, a_cot, a_cot_pb, a_cot_cd, a_cot_td, ns_tl_pc_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_tl_pc_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_tl_pc_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_tl_pc_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
    return false;
}
function ns_tl_pc_HangLen(b_ten_Gr) {
    var b_grId = form_Fs_VUNG_ID(b_ten_Gr);
    GridX_chuyenHang(b_grId, -1);
    return false;
}
function ns_tl_pc_HangXuong(b_ten_Gr) {
    var b_grId = form_Fs_VUNG_ID(b_ten_Gr);
    GridX_chuyenHang(b_grId, 1);
    return false;
}
function ns_tl_pc_ChenDong(b_dk, b_ten_Gr) {
    var b_grId = form_Fs_VUNG_ID(b_ten_Gr);
    if (GridX_Fi_timHangC(b_grId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grId);
    return false;
}
function ns_tl_pc_CatDong(b_ten_Gr) {
    var b_grId = form_Fs_VUNG_ID(b_ten_Gr);
    GridX_boChon(b_grId, 'C');
    return false;
}
function ns_tl_pc_P_CHON() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_check = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tinhtrang"));
    //if (b_check == "Chưa phê duyệt") { alert('Không thể chọn khóa đào tạo chưa phê duyệt'); return; }
    //else
    form_P_TRA_CHON('MA,TEN');
}
function ns_tl_pc_P_XUAT_EXEL() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function ktra_ngay(tungay, denngay, loai, ten1, ten2) {
    if (denngay == "" || denngay == null) {
        return "";
    }
    if (loai == 1 && tungay > denngay) {
        return "loi: " + ten1 + " không được lớn hơn " + ten2 + " :loi";
    } else if (loai == 2 && tungay >= denngay) {
        return "loi: " + ten1 + " không được lớn hơn hoặc bằng " + ten2 + " :loi";
    }
    return "";
}
function parseDate(str) {
    var mdy = str.split('/');
    return new Date(mdy[2], mdy[1], mdy[0]);
}
function CheckAll(oCheckbox,grid) {
    if (oCheckbox.checked == true) {
        var b_grid = form_Fs_VUNG_ID(grid);
        var b_sohang = GridX_Fi_hangSo(b_grid);
        for (i = 1; i < b_sohang; i++) {
            if (grid == "GR_NV") {
                var b_so_the = C_NVL(GridX_Fas_layGtri(b_grid, i, "so_the"));
                if (b_so_the != "") GridX_datGtri(b_grid, i, ["chon"], ['X'], 'K');
            }
            else {
                var b_so_the = C_NVL(GridX_Fas_layGtri(b_grid, i, "ma"));
                if (b_so_the != "") GridX_datGtri(b_grid, i, ["chon"], ['X'], 'K');
            }
            
        }
    } else {
        var b_grid = form_Fs_VUNG_ID(grid);
        var b_sohang = GridX_Fi_hangSo(b_grid);
        for (i = 1; i < b_sohang; i++) {
            GridX_datGtri(b_grid, i, ["chon"], [''], 'K');
        }
    }
}
function form_dong() {
    location.reload(false);
}