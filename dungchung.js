function dodai(giatri,loai,ten) {   
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
function dodai(min,max,giatri, ten) {
    if (giatri.length > max || giatri.length <min) {
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
    $("input[placeholder='dd/MM/yyyy']").datepicker({
        dateFormat: 'dd/mm/yy'
    });
    $("input[placeholder='MM/yyyy']").datepicker({
        dateFormat: 'mm/yy'
    });
});
