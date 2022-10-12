var b_vuId, b_chId, b_moId, b_vtriY = 0, b_luuId, b_formId, b_dongId, b_tmucId, b_tenId, b_ma_dviId;
document.onmousemove = function (event) {
    b_vtriY = (typeof event == 'undefined') ? window.event.clientY : event.clientY;
}
window.onbeforeunload = function () {
    if (b_vtriY <= 0) { $get(b_luuId).value = ""; $get(b_dongId).value = ""; }
}
function file_anh_KD(chId, moId) {
    b_chId = chId; b_moId = moId, b_vuId = form_Fs_VUNG_ID('UPa_hi');
    b_luuId = form_Fs_TEN_ID(b_vuId, 'tra_luu'), b_dongId = form_Fs_TEN_ID(b_vuId, 'tra_dong'),
        b_tmucId = form_Fs_TEN_ID(b_vuId, 'tmuc'), b_tenId = form_Fs_TEN_ID(b_vuId, 'ten'), b_ma_dviId = form_Fs_TEN_ID(b_vuId, 'ma_dvi'),
        b_formId = form_Fs_TEN_ID(b_vuId, 'b_form');
}
function P_KET_QUA(b_dtuong, a_tso) {
    if (C_NVL(b_dtuong) == "TSO" && a_tso.length > 1) {
        form_Fctr_TEN_DTUONG(b_vuId, 'tmuc').value = a_tso[0];
        if (a_tso.length > 1) $get(b_tenId).value = a_tso[1];
        if (a_tso.length > 2) $get(b_luuId).value = a_tso[2];
        if (a_tso.length == 7) $get(b_formId).value = a_tso[6];
        if (a_tso.length > 3) {
            form_Fctr_TEN_DTUONG(b_vuId, 'loai').value = a_tso[3];
            if (a_tso[3] == 'ID') {
                form_Fctr_TEN_DTUONG(b_vuId, 'ma_dvi').value = a_tso[4];
                form_Fctr_TEN_DTUONG(b_vuId, 'nd').value = a_tso[5];
            }
        }
    }
}
function file_anh_P_DAT() {
    try {
        var file = document.getElementById("ctl00_ContentPlaceHolder1_chon_file");
        if (file.value == "") {
            form_P_LOI("loi:Chưa chọn file ảnh:loi");
            return false;
        } else if (file.files[0].size > 1048576) {
            form_P_LOI("loi:File vượt quá dung lương cho phép:loi");
            return false;
        }
        var b_type = file.files[0].type;
        if (b_type != 'image/png' && b_type != 'image/jpeg' && b_type != 'image/pjpeg') {
            form_P_LOI("loi:File ảnh không đúng định dạng:loi");
            return false;
        }
        var b_cf = C_NVL($get(b_chId).value);
        if (b_cf != "") {
            var b_i = b_cf.lastIndexOf('/'), b_j = b_cf.lastIndexOf('\\');
            if (b_i < b_j) b_i = b_j;
            b_cf = b_cf.substr(b_i + 1);
        }
        if (b_cf != "") {
            if (C_NVL($get(b_luuId).value) != "C") $get(b_dongId).value = b_cf;
            var b_btn_excel = form_Fs_VTEN_ID('', 'mo');
            $get(b_btn_excel).click(); form_chay = 0; form_P_LOI('');
        }
        day();
        form_P_LOI('');
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function day() {
    try {
        var b_form = $get(b_formId).value;
        if (b_form == "ht_madvi") {
            var b_link = $get(form_Fs_VTEN_ID('UPa_hi', 'b_link')).value;
            form_P_DAY(window.name, 'ht_madvi', 'ANH_THE', b_link); 
        }
        else {
            var b_link = $get(form_Fs_VTEN_ID('UPa_hi', 'b_link')).value;
            form_P_DAY(window.name, "ns_cb", "ANH_THE", b_link);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function file_anh_P_GCHU() {
    form_Fctr_VTEN_DTUONG('', 'gchu').innerHTML = C_NVL($get(b_chId).value);

}
function form_dong() {
    form_P_DONG('file_anh');
    window.close();
}

// lay dung luong anh
function findSize() {
    var fileInput = document.getElementById("chon_file");
    try {
        alert(fileInput.files[0].size); // Size returned in bytes.
    } catch (e) {
        var objFSO = new ActiveXObject("Scripting.FileSystemObject");
        var e = objFSO.getFile(fileInput.value);
        var fileSize = e.size;
        return fileSize;
        //alert(fileSize);
    }
}