function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (C_NVL(b_dtuong) != "") {
            var b_tf;
            if (b_dtuong.substr(0, 2).toUpperCase() == "HT" || b_dtuong.substr(0, 2).toUpperCase() == "KH" || b_dtuong.toUpperCase() == "KTKH_HAN"
                || b_dtuong.toUpperCase() == "KTKH_SLNV") {
                b_tf = form_Fs_TM() + "/helps/HT.htm#" + b_dtuong.toUpperCase();
            }
            else { b_tf = form_Fs_TM() + "/helps/" + b_dtuong.substr(2, 2) + ".htm#" + b_dtuong.toUpperCase(); }
            var b_ctr = document.getElementById("nd");
            b_ctr.src = b_tf;
            b_ctr.width = (screen.availWidth - 50).toString();
            b_ctr.height = (screen.availHeight - 135).toString();
        }
    }
    catch (ex) { }
}