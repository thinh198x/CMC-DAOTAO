       function tl_pp_luong_P_LKE() {
           try {
               stl_ma.Fs_NS_TL_PP_LUONG_LKE(tl_pp_luong_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
           }
           catch (err) { form_P_LOI(err); }
       }
function tl_pp_luong_P_LKE_KQ(b_kq) {
    var b_pp = document.getElementsByTagName('input');
    if (b_kq != "") {
        for (var i = 0; i < b_pp.length; i++) {
            if (b_pp[i].type == 'radio' && b_pp[i].value == b_kq) {
                b_pp[i].checked = true;
                return;
            }
        }
    }
}
function tl_pp_luong_apdung() {
    var b_pp = document.getElementsByTagName('input');
    for (var i = 0; i < b_pp.length; i++) {
        if (b_pp[i].type == 'radio' && b_pp[i].checked) {
            stl_ma.Fs_NS_TL_PP_LUONG_APDUNG(b_pp[i].value, tl_pp_luong_apdung_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return;
        }
    }
    alert("Chưa chọn phương pháp tính lương");
}
function tl_pp_luong_apdung_KQ(b_kq) {
    alert("Đã áp dụng phương pháp tính lương mới");
}