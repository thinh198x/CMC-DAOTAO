var b_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timId, b_choAct = 0, b_tt = '';
function P_KD() {
    b_lkeCho = setInterval('P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_ten_form = b_dtuong;
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            b_tt = b_kq;
            P_LKE();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            $get(b_gocId).value = ($get(b_gocId).value).validate_Ma();
            var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN'); //Trả đối tượng theo 1 tên của vùng qua ID vùng
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); P_CHUYEN_HANG(); }
            b_ten.focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId); //Số hàng trong 1 trang của grid
            var a_cot = GridX_Fas_tenCot(b_grlkeId); //Trả mảng tên các cột của grid
            sns_ma_ch.Fdt_MA(b_ma, b_TrangKt, a_cot, P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); P_CHUYEN_HANG(); }
}
function P_MOI() {
    GridX_thoiA(b_grlkeId);
    form_P_MOI(b_vungId, "GXL");
    var b_drop = form_Fctr_TEN_DTUONG(b_vungId, 'ten_tt'); //Trả đối tượng theo 1 tên của vùng qua ID vùng
    list_P_DAT(b_drop, '1');
    var b_kytudau = "T", b_tenbang = "DAOTAO_BAI1", b_tencot = "MA";
    hts_dungchung.Fs_AutoGenCode(b_kytudau, b_tenbang, b_tencot, P_GENCODE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_gocId).focus();
    return false;
}
function P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_ma_ch.Fs_TIN_BAI1_NH(b_TrangKt, a_dt_ct, a_cot, P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_hang = GridX_Fi_timHangA(b_grlkeId); //Tìm hàng đang active trên lưới VD: 7
        form_P_LOI("loi:Ghi thành công!:loi"); //Hiện lỗi nếu có
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
    }
    return false;
}
function P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId); //Tìm hàng đang active trên lưới VD: 7
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    if (b_ma == "") { P_MOI(); form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    else {
        var message = confirm("Bạn có chắc chắn xóa không?");
        if (message == false) return false;
        var a_cot = GridX_Fas_tenCot(b_grlkeId); //Trả mảng tên các cột của grid
        var a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_TIN_BAI1_XOA(b_ma, a_tso, a_cot, P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI("loi:Xóa thành công!:loi");
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = GridX_Fi_timHangA(b_grlkeId); //Tìm hàng đang active trên lưới VD: 7
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId); //Số hàng đã nhập của grid
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) P_MOI(); //GridX_Fb_hangTrang(): Kiểm tra hàng tại vị trí được chỉ ra có phải là hàng trắng không
        else { GridX_datA(b_grlkeId, b_hang); P_CHUYEN_HANG(); } //GridX_datA(): Đặt active cell được chỉ định, có focus vào cột hay không
    }
}
function GR_lke_RowChange() {
    if (b_choAct != 0) clearTimeout(b_choAct);
    b_choAct = setTimeout("P_CHUYEN_HANG()", 300);
    return false;
}
function P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        if (b_ma == "") {
            form_P_MOI(b_vungId, "XGL");
            var b_drop = form_Fctr_TEN_DTUONG(b_vungId, 'tt');
            list_P_DAT(b_drop, '1');
            var b_kytudau = "T", b_tenbang = "DAOTAO_BAI1", b_tencot = "MA";
            hts_dungchung.Fs_AutoGenCode(b_kytudau, b_tenbang, b_tencot, P_GENCODE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        } else {
            sns_ma_ch.Fs_TIN_BAI1_CT(form_Fs_nsd(), b_ma, P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
function P_LKE_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(b_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'); // Trả Id vùng theo tên
        // "UPa_ct"
        b_grlkeId = form_Fs_VUNG_ID('GR_lke'); // Trả Id vùng theo tên
        // "ctl00_ContentPlaceHolder1_GR_lke"
        b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'); //Trả ID đối tượng nằm trong vùng theo Id vùng và tên đối tượng
        // "ctl00_ContentPlaceHolder1_ma"
        b_slideId = $get(b_grlkeId).getAttribute('slideId'), slide_P_MOI(b_slideId); P_LKE();
    }
}
function P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_TIN_BAI1_LKE(a_tso, a_cot, P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#'); //Convert chuỗi thành mảng chuỗi có ký tự cách
    //[] = ["2", "TINH001|THAIBINH|Áp dụng|CO|ADMIN|A;TINH003|HAIDUONG|Ngừng áp dụng|CO|ADMIN|N;"]
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); //Đặt lại số trang của lưới
    GridX_datBang(b_grlkeId, a_kq[1]); //Đặt bảng vào grid
}
function P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2'); //Trả ID đối tượng nằm trong vùng theo tên vùng và tên đối tượng
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function form_dong() { location.reload(false); }
function P_GENCODE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else { $get(b_gocId).value = b_kq; }
}