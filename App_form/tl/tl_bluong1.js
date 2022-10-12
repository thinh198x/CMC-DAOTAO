var tl_bluong_lkeCho, tl_bluong_lkecbCho, tl_bluong_lkecbCotCho, tl_bluong_lkecbCottkCho, b_vungId, b_grlkeId, b_grctId, b_grct2Id, b_mt, b_grmaId;
function tl_bluong_P_KD() {
    tl_bluong_lkeCho, tl_bluong_lkecbCho, tl_bluong_lkecbCotCho, tl_bluong_lkecbCottkCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'), b_grct2Id = form_Fs_VUNG_ID('GR_ct2');
    b_kyluongId = form_Fs_TEN_ID(b_vungId, 'KYLUONG'), b_phongId = form_Fs_TEN_ID(b_vungId, 'PHONG');
    b_grmaId = form_Fs_VUNG_ID('Gr_ma');
    b_slideId = b_grlkeId + '_slide';

    tl_bluong_lkecbCottkCho = setInterval('tl_bluong_P_LKE_KTAO_COTTK_CHO()', 200);
    tl_bluong_lkecbCotCho = setInterval('tl_bluong_P_LKE_KTAO_COT_CHO()', 200);
    tl_bluong_lkecbCho = setInterval('tl_bluong_P_LKE_KTAO_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        if (b_dtuong.indexOf("DAYPHONG") >= 0) {
            $get(b_phongId).value = a_tso[0];
            tl_bluong_P_MOI();
            tl_bluong_P_LKE();
            tl_bluong_P_LKE_CB();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function tl_bluong_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "PHONG": b_maId = b_phongId; break;
            case "KYLUONG": b_maId = b_kyluongId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null) return;
        if (b_maTen == "PHONG") {
            tl_bluong_P_MOI();
            tl_bluong_P_LKE_KHOITAO();
        } else if (b_maTen == "KYLUONG") {
            var b_kyluong = $get(b_kyluongId).value;
            tl_bluong_P_LKE_KHOITAO();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_danhsach_P_NAM() {
    try {
        var b_nam = form_Fs_TEN_GTRI(b_vungId, 'nam');
        stl_ch.Fs_DANHSACH_KYLUONG_LKE(b_nam, ns_danhsach_P_KYLUONG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_danhsach_P_KYLUONG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_kyluongId = form_Fs_TEN_ID(b_vungId, 'kyluong');
        drop_P_LKE(b_kyluongId, b_kq);
    }
    tl_bluong_P_KTRA("KYLUONG");
}
var tl_bluong_choAct = 0;
function tl_bluong_GR_lke_RowChange() {
    if (tl_bluong_choAct != 0) clearTimeout(tl_bluong_choAct);
    tl_bluong_choAct = setTimeout("tl_bluong_P_CHUYEN_HANG()", 300);
    return false;
}
function tl_bluong_P_LKE_CB_CHO() {
    if ($get(b_grctId) != null) { clearTimeout(tl_bluong_lkecbCho); tl_bluong_P_LKE_CB(); }
}
function tl_bluong_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grctId);
    GridX_datTrang(b_grctId);
}
function tl_bluong_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_dt = form_Faa_TEXT_ROW(b_vungId),
                a_cot_ct = GridX_Fdt_cotGtri(b_grctId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
            stl_ch.Fs_TL_BLUONG_NH(b_TrangKt, b_dt, a_cot_ct, a_cot_lke, tl_bluong_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function tl_bluong_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);

    }
    return false;
}
function tl_bluong_P_LKE_KTAO_COT_CHO() {
    if ($get(b_grctId) != null) { clearTimeout(tl_bluong_lkecbCotCho); tl_bluong_P_LKE_KHOITAO_COT(); }
}

function tl_bluong_P_LKE_KHOITAO_COT() {
    try {
        stl_ch.Fs_NS_TL_BLUONG_COT(tl_bluong_P_LKE_KHOITAO_COT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function tl_bluong_P_LKE_KHOITAO_COT_KQ(b_kq) {

    try {
        if (b_kq == "") GridX_datTrang(b_grctId);
        else {
            var a_kq = b_kq.split('#');
            for (var i = 0; i < a_kq.length; i++) {
                $get("ctl00_ContentPlaceHolder1_Label" + (i + 6)).innerHTML = a_kq[i];
            }
            for (var i = a_kq.length ; i < 51; i++) {
                $get("td" + (i + 5)).style.display = "none";
            }
            for (var i = a_kq.length ; i < 55; i++) {
                GridX_anCot(b_grctId, "LUONG_" + (i), "none");
            }
            Attribute_P_DAT($get(b_grctId), "WIDTH", "1600px");
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function tl_bluong_P_LKE_KTAO_COTTK_CHO() {
    if ($get(b_grctId) != null) { clearTimeout(tl_bluong_lkecbCottkCho); tl_bluong_P_LKE_KHOITAO_COTTK(); }
}
function tl_bluong_P_LKE_KHOITAO_COTTK() {
    try {
        stl_ch.Fs_NS_TL_BLUONG_COTTK(tl_bluong_P_LKE_KHOITAO_COTTK_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        stl_ch.Fs_NS_TL_BLUONG_COT(tl_bluong_P_LKE_KHOITAO_COT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function tl_bluong_P_LKE_KHOITAO_COTTK_KQ(b_kq) {
    try {
        if (b_kq == "") GridX_datTrang(b_grct2Id);
        else {
            var a_kq = b_kq.split('#');
            for (var i = 0; i < a_kq.length; i++) {
                $get("ctl00_ContentPlaceHolder1_Label" + (i + 75)).innerHTML = a_kq[i];
            }
            for (var i = a_kq.length ; i < 21; i++) {
                $get("tk" + (i + 6)).style.display = "none";
            }
            for (var i = a_kq.length ; i < 27; i++) {
                GridX_anCot(b_grct2Id, "CONG_" + (i), "none");
            }
            Attribute_P_DAT($get(b_grct2Id), "WIDTH", "1600px");
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}


function tl_bluong_P_LKE_KTAO_CHO() {
    if ($get(b_grctId) != null) { clearTimeout(tl_bluong_lkecbCho); tl_bluong_P_LKE_KHOITAO(); }
}
function tl_bluong_P_LKE_KHOITAO() {
    try {
        var b_kyluong = $get(b_kyluongId).value;
        if (b_kyluong != null && b_kyluong != "") {
            var a_cot_ct = GridX_Fas_tenCot(b_grctId), b_phong = $get(b_phongId).value, a_cot_ct2 = GridX_Fas_tenCot(b_grct2Id);
            stl_ch.Fs_TL_BLUONG_CT(b_phong, b_kyluong, a_cot_ct, a_cot_ct2, tl_bluong_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function tl_bluong_P_CHUYEN_HANG() {
    try {
        var b_kyluong = $get(b_kyluongId).value;
        if (b_kyluong == null || b_kyluong == "") { form_P_MOI("", "XGL"); tl_bluong_P_LKE_CB(); }
        else {
            var a_cot_ct = GridX_Fas_tenCot(b_grctId), b_phong = $get(b_phongId).value;
            stl_ch.Fs_TL_BLUONG_CT(b_phong, b_kyluong, a_cot_ct, tl_bluong_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function tl_bluong_P_CHUYEN_HANG_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        var a_kq = b_kq.split('#');
        if (b_kq == "") {
            GridX_datTrang(b_grctId);
            GridX_datTrang(b_grct2Id)
        } else {
            GridX_dat_hangkt(b_grctId, a_kq[1]);
            form_P_CH_TEXT(b_vungId, a_kq[0]);

            if (a_kq[0] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[0]);
            if (a_kq[2] == "") GridX_datTrang(b_grct2Id); else GridX_datBang(b_grct2Id, a_kq[2]);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function tl_bluong_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_thang = GridX_Fas_layGtri(b_grlkeId, b_hang, "thang");
    if (b_thang == "") tl_bluong_P_MOI();
    else {
        var b_phong = $get(b_phongId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_ch.Fs_TL_BLUONG_XOA(b_phong, b_thang, a_tso, a_cot, tl_bluong_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function tl_bluong_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) tl_bluong_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); tl_bluong_P_CHUYEN_HANG(); }
    }
}


function tl_bluong_P_CHUYEN_TIEN() {
    try {
        var b_tenf = '<%= this.ResolveUrl("~/App_form/bc/tl_ngbc.aspx") %>',
            b_phong = $get(b_phongId).value,
            b_thang = $get(b_thangId).value,
            b_ten_phong = document.getElementById(b_phongId)[document.getElementById(b_phongId).selectedIndex].innerText;
        if (b_thang == null || b_thang == "") { alert("Chưa chọn chi tiết"); }
        else {
            var b_tso = b_phong + "#" + b_thang + "#" + b_ten_phong;
            form_P_MO(b_tenf, null, ["BL", [b_tso]], null);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_tonghop_P_MO() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_phong = $get(b_phongId).value, b_kyluong = $get(b_kyluongId).value;

            stl_ch.Fs_TL_BLUONG_MO(b_phong, b_kyluong, ns_cc_tonghop_P_DONGMO_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_tonghop_P_DONG() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_phong = $get(b_phongId).value, b_kyluong = $get(b_kyluongId).value;
            stl_ch.Fs_NS_TL_BLUONG_DONG(b_phong, b_kyluong, ns_cc_tonghop_P_DONGMO_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function tl_bluong_TINH() {
    try {
        var b_phong = $get(b_phongId).value,
        b_kyluong = $get(b_kyluongId).value;
        if (b_kyluong == null || b_kyluong == "") { alert("Phải nhập tháng tính lương"); }
        else {
            var a_cot = GridX_Fas_tenCot(b_grctId);
            var a_cot2 = GridX_Fas_tenCot(b_grct2Id);
            stl_ch.Fs_TL_BLUONG_TINH(b_phong, b_kyluong, a_cot, a_cot2, tl_bluong_P_TINH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function tl_bluong_P_TINH_KQ(b_kq) {

    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    GridX_dat_hangkt(b_grctId, a_kq[1]);
    if (a_kq[0] == "") GridX_datTrang(b_grctId);
    else GridX_datBang(b_grctId, a_kq[0]);
   // if (a_kq[2] == "") GridX_datTrang(b_grct2Id);
   // else GridX_datBang(b_grct2Id, a_kq[2]);
    form_P_LOI('loi:Tổng hợp dữ liệu thành công:loi');
    return false;
}

function tl_bluong_P_IN() {


    __doPostBack('ctl00$ContentPlaceHolder1$Nhap2', '');

    //var b_dvi = $get(b_phongId).value,
    //    b_kyluong = $get(b_kyluongId).value,
    //    b_dt_grid = GridX_Fdt_cotGtri(b_grctId);
    //sti_ch.Fs_EXCEL_TIENLUONG("ns_tl_bluong",".xls",b_dt_grid, P_EXCEL_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    //return false;
}
function P_EXCEL_KQ(b_kq) {
    //?md=TT
    //if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    //form_P_MO(form_Fs_TM() + '/App_form/bc/xexcel.aspx?md=TT', null, null, "C");
}

function GridX_dat_hangkt(b_gridx, sodong) {
    try {
        var b_grid = $get(b_gridx);
        b_grid.setAttribute('hangKt', '21');
        var b_hangkt = GridX_Fi_hangKt(b_gridx);
        if (sodong > b_hangkt) {
            b_grid.setAttribute('hangKt', sodong - b_hangkt + 22);
        }
        return false;
    } catch (err) { form_P_LOI(err); }
}
function tl_bluong_phong() {
    try {
        var b_tenf = form_Fs_TM() + '/App_form/ht/ht_maph.aspx';
        form_P_MO(b_tenf, null, ["tl_bluong", [""]]);
        return false;
    }
    catch (err) { }
}
function form_dong() {
    location.reload(false);
}