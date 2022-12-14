var b_lkeCho, b_choAct = 0, b_vungId, b_vungtkId, b_grlkeId, b_slideId, b_gocId, b_ma_ctId, b_capId, b_ten_ctId, b_ten_form, b_tmf,
    b_ma_dvi, b_imgId, b_no_anhId, b_logoId, b_cdanh_qlId, b_ten_cdanh_qlId, b_gtId, b_phong_qlId;
function ht_maph_KD(b_tm, b_dvi, b_img) {
    try {
        b_ma_dvi = b_dvi;
        b_imgId = document.getElementById(b_img);
        b_tmf = b_tm;
        b_lkeCho = setTimeout('ht_maph_P_LKE_CHO()', 500);
    }
    catch (err) {
        alert(err);
    }
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        b_dtuong = C_NVL(b_dtuong).toUpperCase();
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
            if (a_tso[0] == 'FILE_HTOAN') {
                ht_maph_P_LKE('M');
            }
        }
        else
            if (b_dtuong.indexOf("PHONG_QL") >= 0) {
                b_dtuong = b_dtuong.toUpperCase();
                $get(b_phong_qlId).value = a_tso[0];
                $get(b_cdanh_qlId).value = a_tso[1];
                //$get(b_ten_cdanh_qlId).value = a_tso[2];
                // ht_maph_P_TTQL($get(b_cdanh_qlId).value);
            } else
                if (b_dtuong.indexOf("FLUU") >= 0) {
                    ht_maph_P_CHUYEN_HANG();
                }
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ht_maph_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId;
                break;
            case "MA_CT": b_maId = form_Fs_TEN_ID(b_vungId, 'ma_ct');
                break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "")
            return;
        var b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
        if (b_maTen == "MA") {
            if (b_hang < 1) {
                GridX_thoiA(b_grlkeId);
                form_P_MOI(b_vungId, "X");
            }
            else {
                GridX_datA(b_grlkeId, b_hang, null, "K");
                slide_P_vtri(b_slideId, b_hang);
                ht_maph_P_CHUYEN_HANG();
            }
            form_Fctr_TEN_DTUONG(b_vungId, 'TEN').focus();
        }
        else
            if (b_hang < 0)
                form_P_LOI_DICH("loi:Mã quản lý chưa đăng ký:loi");
    }
    catch (ex) {
        form_P_LOI(ex.message);
    }
}
function ht_maph_P_MA() {
    try {
        var b_ma = $get(b_gocId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId);
        var b_trangKT = GridX_Fi_hangKt(b_grlkeId);
        var b_gt = $get(b_gtId).value;
        sht_ma.Fs_MA_PH_MA(form_Fs_nsd(), window.name, b_ma, b_gt, b_trangKT, a_cot, ht_maph_P_MA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) {
        form_P_LOI(ex.message);
    }
}
function ht_maph_P_MA_KQ(b_kq) {
    try {

        if (Fb_LOI_KTRA(b_kq))
            form_P_LOI(b_kq);
        else {
            var a_kq = Fas_ChMang(b_kq, '#');
            var b_hang = CSO_SO(a_kq[0]) + 1;
            var b_trang = CSO_SO(a_kq[1]);
            var b_soDong = CSO_SO(a_kq[2]);
            GridX_datBang(b_grlkeId, a_kq[3]);
            slide_P_MOI(b_slideId, b_trang, b_soDong);
            //GridX_luiCot(b_grlkeId, 'ten', 'cap'); $get(b_timId).value = '';
            if (b_hang > 0)
                GridX_datA(b_grlkeId, b_hang);
            ht_maph_P_CHUYEN_HANG();
        }
    }
    catch (err) {
        alert(err);
    }
}
function ht_maph_P_MOI() {
    try {
        form_P_MOI(b_vungId, "GXL");
        GridX_thoiA(b_grlkeId);
        $get(b_gocId).focus();
        khud_trdoi_FI_CHUYEN();
        return false;
    }
    catch (err) {
        alert(err);
    }
}
function ht_maph_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "")
            form_P_LOI_DICH(b_loi);
        else {
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
            var a_cot = GridX_Fas_tenCot(b_grlkeId);
            sht_ma.Fs_MA_PH_NH(form_Fs_nsd(), a_dt_ct, a_cot, ht_maph_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (ex) {
        form_P_LOI(ex.message);
    }
}
function ht_maph_NH_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq))
            form_P_LOI(b_kq);
        else {
            $get(b_gocId).value = b_kq;
            ht_maph_P_MA();
            $get(b_gocId).focus();
            form_P_LOI("loi:Ghi thành công:loi");
            GridX_doiMauInActive(b_grlkeId);
        }
    }
    catch (err) {
        alert(err);
    }
}
function ht_maph_P_XOA() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId);
        var a_tso = slide_Faobj_TUDEN(b_slideId);
        if (b_hang < 1 || b_loi.length > 0) {
            form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi");
            return false;
        }
        var b_ma = C_NVL(GridX_Fas_layGtriA(b_grlkeId, "ma"));
        if (b_ma == "")
            ht_maph_P_MOI();
        else
            sht_ma.Fs_MA_PH_XOA(form_Fs_nsd(), b_ma, a_cot, a_tso, ht_maph_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) {
        form_P_LOI(ex.message);
    }
}
function ht_maph_P_XOA_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq))
            form_P_LOI(b_kq);
        else {
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            GridX_boChon(b_grlkeId);
            if (b_hang > 1 && GridX_Fb_hangTrang(b_grlkeId, b_hang))
                b_hang--;
            slide_P_vtri(b_slideId, b_hang);
            GridX_datA(b_grlkeId, b_hang, null, "K");
            ht_maph_P_CHUYEN_HANG();
        }
    }
    catch (err) {
        alert(err);
    }
}
function ht_maph_GR_lke_RowChange() {
    try {
        if (b_choAct != 0) clearTimeout(b_choAct);
        b_choAct = setTimeout("ht_maph_P_CHUYEN_HANG()", 300);
        return false;
    }
    catch (err) {
        alert(err);
    }
}
function ht_maph_P_CHUYEN_HANG() {
    try {
        var b_ma = C_NVL(GridX_Fas_layGtriA(b_grlkeId, 'ma'));
        if (b_ma == '') {
            form_P_MOI(b_vungId, 'GXL');
            khud_trdoi_FI_CHUYEN();
        }
        else
            sht_ma.Fs_MA_PH_CT(form_Fs_nsd(), b_ma, ht_maph_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) {
        form_P_LOI(ex.message);
    }
}
function ht_maph_P_CHUYEN_HANG_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq))
            form_P_LOI(b_kq);
        else
            if (b_kq == '')
                form_P_MOI(b_vungId, 'GXL');
            else form_P_CH_TEXT(b_vungId, b_kq);
        GridX_doiMauInActive(b_grlkeId);
        khud_trdoi_FI_CHUYEN();
    }
    catch (err) {
        alert(err);
    }
}
function ht_maph_P_LKE_CHO() {
    try {

        if (document.readyState === 'complete') {
            clearTimeout(b_lkeCho);
            b_vungId = form_Fs_VUNG_ID('UPa_ct');
            b_vungtkId = form_Fs_VUNG_ID('UPa_tk');
            b_grlkeId = form_Fs_VUNG_ID('GR_lke');
            b_slideId = $get(b_grlkeId).getAttribute('slideId');
            slide_P_MOI(b_slideId);
            b_gocId = form_Fs_TEN_ID(b_vungId, 'MA');
            b_ma_ctId = form_Fs_TEN_ID(b_vungId, 'ma_ct');
            b_ten_ctId = form_Fs_TEN_ID(b_vungId, 'ten_ct');
            b_capId = form_Fs_TEN_ID(b_vungId, 'cap');
            b_tenId = form_Fs_TEN_ID(b_vungId, 'TEN');
            b_phong_qlId = form_Fs_TEN_ID(b_vungId, 'phong_ql');
            b_cdanh_qlId = form_Fs_TEN_ID(b_vungId, 'cdanh_ql');
            b_timId = form_Fs_VTEN_ID('', 'tim_ten');
            b_gtId = form_Fs_TEN_ID(b_vungtkId, 'gt');
            b_no_anhId = form_Fs_TM() + "/images/no_image.png";
            b_logoId = form_Fs_TEN_ID(b_vungId, 'logo');
            GridX_taoScroll(b_grlkeId);
            ht_maph_P_LKE('M');
        }
    }
    catch (err) {
        alert(err);
    }
}
function ht_maph_P_LKE(b_dk) {
    try {
        if (b_dk == 'M') {
            GridX_thoiA(b_grlkeId);
            slide_P_MOI(b_slideId);
        }
        else
            if (b_dk == 'T') {
                var b_dk = C_NVL(GridX_Fas_layGtriA(b_grlkeId, 'tc'));
                if (b_dk == 'C' || b_dk == '')
                    return false;
            }
        var b_tim = C_NVL($get(b_timId).value);
        var a_cot = GridX_Fas_tenCot(b_grlkeId);
        var a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_ma = C_NVL(GridX_Fas_layGtriA(b_grlkeId, 'ma'));
        var b_gt = $get(b_gtId).value;
        sht_ma.Fs_MA_PH_LKE(form_Fs_nsd(), window.name, b_dk, b_ma, b_gt, a_cot, a_tso, ht_maph_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) {
        form_P_LOI(ex.message);
    }
}
function ht_maph_P_LKE_KQ(b_kq) {
    try {

        if (Fb_LOI_KTRA(b_kq))
            form_P_LOI(b_kq);
        else {
            var a_kq = Fas_ChMang(b_kq, '#');
            var b_ma = C_NVL(GridX_Fas_layGtriA(b_grlkeId, 'ma'));
            slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
            GridX_datBang(b_grlkeId, a_kq[1]);
            //GridX_luiCot(b_grlkeId, 'ten', 'cap');
            if (b_ma != '') {
                var b_hang = GridX_Fi_timHangD(b_grlkeId, 'ma', b_ma);
                if (b_hang > 0)
                    GridX_datA(b_grlkeId, b_hang);
            }
            GridX_laiMau(b_grlkeId);
            GridX_doiMauInActive(b_grlkeId);
            if (a_kq[1] == '' && C_NVL($get(b_timId).value) != '')
                form_P_LOI_DICH('loi:Không tìm thấy:loi');
        }
    }
    catch (ex) {
        form_P_LOI(ex.message);
    }
}
function khud_trdoi_FI_CHUYEN() {
    try {
        var b_goc = C_NVL($get(b_logoId).value);
        //if (b_goc != "" && b_goc != null) b_iurlId.src = b_loading_anhId;
        //else b_iurlId.src = b_no_anhId;
        var b_i = b_goc.lastIndexOf('.');
        if (b_i > 0) {
            var b_s = b_goc.substr(b_i + 1);
            if (b_s != "" && "png,PNG,gif,GIF,BMP,bmp,jpg,JPG,JPEG,jpeg".indexOf(b_s) >= 0)
                sns_tt.Fs_FI_LOGO_TRA(b_goc, khud_trdoi_FI_CHUYEN_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        } else
            b_imgId.src = b_no_anhId;
        return false;
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function khud_trdoi_FI_CHUYEN_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq))
            form_P_LOI(b_kq);
        else
            b_imgId.src = b_kq + "?" + new Date().getTime();
    }
    catch (err) {
        alert(err);
    }
}
function ht_maph_P_MOI_CON() {
    try {
        var b_cap = CSO_SO(GridX_Fas_layGtriA(b_grlkeId, "cap")) + 1;
        if (b_cap == 0) {
            form_P_LOI("loi:Chưa chọn đơn vị:loi");
        }
        else {
            form_P_MOI(b_vungId, "GXL");
            $get(b_capId).value = b_cap;
            $get(b_ma_ctId).value = GridX_Fas_layGtriA(b_grlkeId, "MA");
            $get(b_ten_ctId).value = GridX_Fas_layGtriA(b_grlkeId, "TEN");
            form_P_LOI('');
        }
        return false;
    }
    catch (err) {
        alert(err);
    }
}
function GridX_doiMauInActive(gridId) {
    try {
        var b_hang = 0;
        var a_row = $get(gridId).rows,
            a_cot = GridX_Fas_tenCot(gridId);
        var a_cell,
            b_nen,
            b_chu,
            a_ctr;
        for (var b_hang = 1; b_hang < a_row.length; b_hang++) {
            a_cell = a_row[b_hang].cells
            for (var i = 1; i < a_cell.length; i++) {
                if (C_NVL(GridX_Fas_layGtri(gridId, b_hang, 'tinh_trang')) != '0') {
                    if (b_hang == GridX_Fi_timHangA(b_grlkeId)) {
                        b_nen = 'LightCyan';
                        b_chu = 'blue';
                    }
                    else {
                        b_nen = 'White';
                        b_chu = 'Black';
                    }

                } else {
                    b_nen = 'Red'; b_chu = 'Black';
                }
                a_ctr = a_cell[i].getElementsByTagName('input');
                if (a_ctr == null || a_ctr.length < 1) {
                    a_ctr = a_cell[i].getElementsByTagName('span');
                    if (a_ctr == null || a_ctr.length < 1)
                        a_ctr = a_cell[i].getElementsByTagName('select');
                }
                if (a_ctr.length > 0) {
                    a_ctr[0].style.color = b_chu;
                    a_ctr[0].style.backgroundColor = b_nen;
                }
                a_cell[i].style.color = b_chu;
                a_cell[i].style.backgroundColor = b_nen;
            }
            b_icot = Fi_vtri_mang(a_cot, 'ccc') + 1;
            if (b_icot > 0)
                a_cell[b_icot].innerHTML = b_dk;
        }
    }
    catch (ex) {
        form_P_LOI(ex.message);
    }
}
function form_P_CHON() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 0 && C_NVL($get(b_gocId).value) != '') {
            var b_ma = $get(b_gocId).value,
                b_ten = $get(b_tenId).value;
            form_P_DAY(window.name, b_ten_form, "DAYPHONG", [b_ma, b_ten]);
            form_P_TRA_CHON('MA,TEN');
        }
        else
            form_P_LOI('loi:Bạn chưa chọn phòng ban:loi');
        return false;
    }
    catch (err) {
        alert(err);
    }
}
function khud_trdoi_FI_NH() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) {
            form_P_LOI('loi:Chọn công ty:loi')
            return false;
        }
        var b_nd = "Logo",
            b_f = $get(b_gocId).value
        if (b_f == '') {
            form_P_LOI('loi:Chọn công ty:loi')
            return false;
        }
        var b_cap = CSO_SO(GridX_Fas_layGtriA(b_grlkeId, 'cap'), 0);
        if (b_cap != 1) {
            form_P_LOI('loi:Chọn công ty:loi')
            return false;
        }

        b_t = "/" + b_f.substr(0, 4) + "/" + b_f.substr(4, 2) + "/" + b_f.substr(6, 2);
        form_P_MO(b_tmf + '/ns/tt/file_anh.aspx', window.name + ",FLUU", ["TSO", [b_t, b_f, null, 'LOGO', b_ma_dvi, b_nd]]);
        return false;
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function ht_maph_P_TTQL(b_ma_cd) {
    try {
        hts_dungchung.Fs_THONGTIN_CANBO_CDANH(b_ma_cd, ht_maph_P_TTQL_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) {
        alert(err);
    }
}
function ht_maph_P_TTQL_KQ(b_kq) {
    try {

        if (b_kq == "") {
            form_P_LOI(b_kq);
            return false;
        }
        form_P_CH_TEXT(b_vungId, b_kq);
        return false;
    }
    catch (err) {
        alert(err);
    }
}
function ht_maph_P_EXCEL() {
    try {
        var b_btn_excel = form_Fs_VTEN_ID('', 'XuatExcel');
        $get(b_btn_excel).click();
        form_chay = 0;
        return false;
    }
    catch (err) {
        alert(err);
    }
}
function ht_maph_P_MAU() {
    try {
        var b_btn_excel = form_Fs_VTEN_ID('', 'FileMau');
        $get(b_btn_excel).click();
        form_chay = 0;
        return false;
    }
    catch (err) {
        alert(err);
    }
}
function ht_maph_FILE_IMPORT() {//import từ file Excel
    try {
        var b_tenf = '/App_form/ns/ma/file_import_hdns.aspx';
        form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "HT_MAPH_IMP", "HT_MAPH_IMP", "Import cơ cấu tổ chức"]], null);
        form_P_LOI('');
        return false;
    }
    catch (err) {
        alert(err);
    }
}
function ht_maph_P_GT() {
    try {
        //var b_cap = CSO_SO(GridX_Fas_layGtriA(b_grlkeId, "cap"), -1) + 1;
        //if (b_cap < 2) { form_P_LOI("loi:Chọn đơn vị từ cấp 2 trở lên:loi"); }
        //else {
        var b_ma = GridX_Fas_layGtriA(b_grlkeId, "MA");
        b_ngay_gt = $get(form_Fs_TEN_ID(b_vungId, 'ngay_gt')).value;
        form_P_LOI('');
        a_cot = GridX_Fas_tenCot(b_grlkeId);
        if (b_ngay_gt == '') {
            form_P_LOI("loi:Chưa nhập ngày giải thể:loi");
        }
        else {
            sht_ma.Fs_MA_PH_GT(form_Fs_nsd(), b_ma, b_ngay_gt, a_cot, ht_maph_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        //}
        return false;
    }
    catch (ex) {
        form_P_LOI(ex.message);
    }
}
function form_dong() {
    location.reload(false);
}

function form_P_TRA_CHON_GRID(b_ten) {
    try {

        var b_grid = $get(b_grlkeId);
        var b_tbo = b_grid.getElementsByTagName('tbody')[0];
        var b_c = b_tbo.rows.length - 1;
        var b_chon = '';
        var b_kq = [], a_kq = [];
        b_kq[0] = "CMC-1M";
        var f = 1;
        b_r = b_tbo.rows[1].cloneNode(true);
        for (var i = b_c; i > 0; i--) {
            b_chon = GridX_Fb_hangChon(b_grlkeId, i);
            if (b_chon == true) {
                b_kq[f] = form_P_TRA_GTRI_GRID(b_ten, i);
                f++;
            }
        }
        var b_l = b_kq.length;
        if (b_l == 2) {
            a_kq = b_kq[1];
            form_P_DONG(window.name, a_kq);
        }
        else {
            b_kq[0] = "CMC-2M";
            form_P_DONG(window.name, b_kq);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
// Tra mang gia tri theo ten
function form_P_TRA_GTRI_GRID(b_ten, b_hang) {
    try {
        var a_ten = b_ten.split(','), a_kq = [];
        for (var i = 0; i < a_ten.length; i++) {
            var a_grid = a_ten[i].split(':');
            var b_gridId = form_Fs_VUNG_ID(a_grid[0]);
            a_kq[i] = GridX_Fas_layGtri(b_gridId, b_hang, a_grid[1]);
        }
        return a_kq;
    }
    catch (err) { return null; }
}