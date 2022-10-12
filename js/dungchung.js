function dodai(giatri, loai, ten) {
    if (loai == "MA" && giatri.length > 50) {
        return "loi: Giá trị không được vượt quá 50 ký tự:loi";
    } else if (loai == "SO" && giatri.length > 9) {
        return "loi:" + ten + " không được vượt quá 9999999999:loi";
    } else if (loai == "TEN" && giatri.length > 255) {
        return "loi:" + ten + " không được vượt quá 255 ký tự:loi";
    }
    else if (loai == "GHICHU" && giatri.length > 1024) {
        return "loi:" + ten + " không được vượt quá 1024 ký tự:loi";
    }
    return "";
}
function dodai(min, max, giatri, ten) {
    if (giatri.length > max || giatri.length < min) {
        return "loi:" + ten + " phải nằm trong khoảng từ " + min + " đến " + max + ":loi";
    }
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
function ktraso(n) {
    return !isNaN(parseFloat(n.replace(',', '.'))) && isFinite(replace(',', '.'));
}

$(function () {
    try {
        $("input[placeholder='dd/MM/yyyy']").datepicker({
            dateFormat: 'dd/mm/yy'
        });
        $("input[placeholder='MM/yyyy']").datepicker({
            dateFormat: 'mm/yy'
        });
        $("input[placeholder='dd/MM']").datepicker({
            dateFormat: 'dd/mm'
        });
        ns_cho = setTimeout('ns_rename_nobr()', 200);
    }
    catch (ex) {
        form_P_LOI(ex.message);
    }
});
function ns_rename_nobr() {
    try {

        var nobr_length = document.getElementsByTagName('nobr').length;
        for (var i = 0; i < nobr_length; i++) {
            var d = document.createElement('span');
            var str = document.getElementsByTagName('nobr')[i];
            if (typeof (str) == "undefined") break;
            d.innerHTML = str.innerHTML;
            str.parentNode.replaceChild(d, str);
        }
    }
    catch (ex) {
        form_P_LOI(ex.message);
    }
}
function GridX_datBang2(gridId, b_cot) {
    try {
        if (b_cot != "") {
            GridX_datTrang(gridId);
            var b_loai = GridX_Fs_loai(gridId), a_cotG = GridX_Fas_tenCot(gridId), a_cot, a_dt;
            a_cot = a_cotG; a_dt = Fdt_ChBang(b_cot);
            for (var i = 0; i < a_dt.length; i++) GridX_datGtri(gridId, i + 1, a_cot, a_dt[i]);
            GridX_laiMau(gridId);
            //if (b_loai == 'N') GridX_chenHang(gridId, 0, 1); 
        }
    }
    catch (ex) { form_P_LOI(ex.message); }
}

// đặt Tooltip
function GridX_datTooltip(b_grid, b_cot) {
    try {
        var i = 0;
        var b_hangT = GridX_Fi_timHangT(b_grid);
        var a_ten_cot = Fas_ChMang(b_cot, ',');
        for (i; i <= b_hangT; i++) {
            for (j = 0; j < a_ten_cot.length; j++) {
                var b_cot_dat = a_ten_cot[j];
                var b_noidung = GridX_Fas_layGtri(b_grid, i, b_cot_dat);
                if (b_noidung != '') {
                    var a_cot = GridX_Fas_tenCot(b_grid);
                    var b_icot = Fi_vtri_mang(a_cot, b_cot_dat) + 1;
                    var a_cell = $get(b_grid).rows[i].cells;
                    a_cell[b_icot].title = b_noidung;
                }
            }
        }
    } catch (ex) { throw (ex); }
}