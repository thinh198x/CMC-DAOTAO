function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (C_NVL(b_dtuong) != "") {
            var b_tf = form_Fs_TM() + "/helps/" + a_tso[0] + ".htm#" + b_dtuong.toUpperCase(), b_ctr = document.getElementById("nd");
            b_ctr.src = b_tf;
            b_ctr.width = (screen.availWidth - 50).toString();
            b_ctr.height = (screen.availHeight - 135).toString();
        }
    }
    catch (ex) { }
}