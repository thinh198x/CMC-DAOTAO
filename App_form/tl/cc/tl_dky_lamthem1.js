
var tl_dky_lamthem_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_sothe_tnId, b_tenId, b_tuoiId, b_so_idId, b_gchuId, b_moiId,b_nsd,b_ten,b_phong;
function tl_dky_lamthem_P_KD(nsd, phong) {
    b_nsd = nsd, b_phong = phong;
    tl_dky_lamthem_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
    b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE'); b_gio_bdId = form_Fs_TEN_ID(b_vungId, 'gio_bd'); b_gio_ktId = form_Fs_TEN_ID(b_vungId, 'gio_kt');
    b_so_idId = form_Fs_VTEN_ID('', 'so_id');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_thangId = form_Fs_VTEN_ID('', 'thang');
    b_ot_thoigianId = form_Fs_TEN_ID(b_vungId, 'ot_thoigian');
    b_hinhthucId = form_Fs_TEN_ID(b_vungId, 'hinhthuc');
    b_nt_thoigianId = form_Fs_TEN_ID(b_vungId, 'nt_thoigian');
    b_slideId = b_grlkeId + '_slide';
    tl_dky_lamthem_lkeCho = setInterval('tl_dky_lamthem_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            $get(b_gocId).value = b_nsd;
            //$get(b_gocId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            tl_dky_lamthem_P_LKE();
            $get(b_gocId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}

function tl_dky_lamthem_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_gocId; form_P_MOI("", "XGL"); break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "SO_THE") {
            skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), tl_dky_lamthem_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            tl_dky_lamthem_P_LKE();
        }
    }
    catch (err) { form_P_LOI(err); }
}

function tl_dky_lamthem_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}

var tl_dky_lamthem_choAct = 0;
function tl_dky_lamthem_GR_lke_RowChange() {
    if (tl_dky_lamthem_choAct != 0) clearTimeout(tl_dky_lamthem_choAct);
    tl_dky_lamthem_choAct = setTimeout("tl_dky_lamthem_P_CHUYEN_HANG()", 300);
    return false;
}

function tl_dky_lamthem_P_LKE_CHO() {
    $get(b_gocId).value = b_nsd;
    if ($get(b_grlkeId) != null) { clearTimeout(tl_dky_lamthem_lkeCho); tl_dky_lamthem_P_LKE(); }
}

function tl_dky_lamthem_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = "0";
    $get(b_gocId).focus();
    return false;
}

function tl_dky_lamthem_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_so_the = $get(b_gocId).value, b_thang = $get(b_thangId).value;
        stl_cc.Fs_NS_TL_DKY_LAMTHEM_LKE(b_so_the,b_thang, a_tso, a_cot, tl_dky_lamthem_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function tl_dky_lamthem_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}

function tinh_thoigian() {
    var b_gbd = $get(b_gio_bdId).value,
        b_gkt = $get(b_gio_ktId).value;
    var b_gio_bd = b_gbd.substring(0, 2), b_phut_bd = b_gbd.substring(3, 5);
    var b_gio_kt = b_gkt.substring(0, 2), b_phut_kt = b_gkt.substring(3, 5);
    var b_gio_them = 0,b_gio_dem = 0;
    var b_phut_dau = 0, b_phut_cuoi = 0;
    var b_hinhthuc = $get(b_hinhthucId).value;
    if (b_gio_bd > 0 && b_gio_kt > 0) {
        if (b_hinhthuc == "T") {
            if (b_phong == 'HN') {
                if (b_gio_bd < 17) {
                    form_P_LOI('loi:Đang thuộc ca làm việc trong khoảng thời gian này!:loi');
                    $get(b_gio_bdId).value = ""; $get(b_gio_bdId).focus;
                    return false;
                }
                else if (b_gio_bd == 17 && b_phut_bd < 15) {
                    form_P_LOI('loi:Đang thuộc ca làm việc trong khoảng thời gian này!:loi');
                    $get(b_gio_bdId).value = ""; $get(b_gio_bdId).focus;
                    return false;
                }
            }
            else {
                if (b_gio_bd < 16) {
                    form_P_LOI('loi:Đang thuộc ca làm việc trong khoảng thời gian này!:loi')
                    $get(b_gio_bdId).value = ""; $get(b_gio_bdId).focus;
                    return false;
                }
                else if (b_gio_bd == 16 && b_phut_bd < 45) {
                    form_P_LOI('loi:Đang thuộc ca làm việc trong khoảng thời gian này!:loi')
                    $get(b_gio_bdId).value = ""; $get(b_gio_bdId).focus;
                    return false;
                }
            }
        }
        if (b_gio_kt > 24 || b_gio_kt < 6) {
            form_P_LOI('loi:Chỉ đăng ký trong ngày!:loi')
            $get(b_gio_ktId).value = ""; $get(b_gio_ktId).focus;
            return false;
        }
        else if (b_gio_kt == 24 && b_phut_bd > 0) {
            form_P_LOI('loi:Chỉ đăng ký trong ngày!:loi')
            $get(b_gio_ktId).value = ""; $get(b_gio_ktId).focus;
            return false;
        }
        // lấy giờ làm 
        if (b_gio_kt >= 22) {
            b_gio_dem = ((parseFloat(b_gio_kt) - 22) * 60 + parseFloat(b_phut_kt)) / 60;
            b_gio_them = ((22 * 60) - (parseFloat(b_gio_bd) * 60 + parseFloat(b_phut_bd))) / 60;
        }
        else {
            b_gio_dem = 0;
            b_gio_them = ((parseFloat(b_gio_kt) * 60 + parseFloat(b_phut_kt)) - (parseFloat(b_gio_bd) * 60 + parseFloat(b_phut_bd)))/60;
        }
        var b_them_g = 0, b_them_p = 0, b_dem_g = 0, b_dem_p = 0;
        b_them_g = Math.floor(b_gio_them);
        b_them_p = parseFloat(b_gio_them) - parseFloat(b_them_g);
        if (b_them_p < 0.25) b_them_p = 0;
        if (b_them_p < 0.5 && b_them_p >= 0.25) b_them_p = 0.25;
        if (b_them_p < 0.75 && b_them_p >= 0.5) b_them_p = 0.5;
        if (b_them_p < 1 && b_them_p >= 0.75) b_them_p = 0.75;
        b_gio_them = parseFloat(b_them_g) + parseFloat(b_them_p);

        b_dem_g = Math.floor(b_gio_dem);
        b_dem_p = parseFloat(b_gio_dem) - parseFloat(b_dem_g);
        if (b_dem_p < 0.25) b_dem_p = 0;
        if (b_dem_p < 0.5 && b_dem_p >= 0.25) b_dem_p = 0.25;
        if (b_dem_p < 0.75 && b_dem_p >= 0.5) b_dem_p = 0.5;
        if (b_dem_p < 1 && b_dem_p >= 0.75) b_dem_p = 0.75;
        b_gio_dem = parseFloat(b_dem_g) + parseFloat(b_dem_p);

        $get(b_ot_thoigianId).value = b_gio_them;
        $get(b_nt_thoigianId).value = b_gio_dem;
    }
}


function tl_dky_lamthem_P_NH() {
    var b_gio_bd = $get(b_gio_bdId).value;
    var b_gio = b_gio_bd.substring(0, 2), b_phut = b_gio_bd.substring(3, 4);
    if ((b_gio * 60 + parseFloat(b_phut)) <= (17 * 60 + 30))
    {
        //form_P_LOI('loi:Đang thuộc ca làm việc trong khoảng ngày và thời gian này!:loi')
        //return false;
    }
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { alert(b_loi); return false; }
        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) b_hang = -1;
        var b_so_id = $get(b_so_idId).value;
        var b_tinhtrang = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tinhtrang_id")) == "" ? 0 : C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tinhtrang_id"));
        stl_cc.Fs_NS_TL_DKY_LAMTHEM_NH(b_so_id, b_tinhtrang, b_TrangKt, a_dt_ct, a_cot_lke, tl_dky_lamthem_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { throw (err); }
}
function tl_dky_lamthem_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        tl_dky_lamthem_P_LKE();
        form_P_LOI('loi:Nhập thành công!:loi')
        
    }
    return false;
}

function sendMail(b_tso) {
    var a_tso = Fas_ChMang(b_tso, ';');
    var b_toAddress = a_tso[0],
        b_subject = a_tso[1],
        b_body = a_tso[2];
    if (b_toAddress == "" || b_toAddress == null || b_toAddress == undefined) return false;
    else {
        sSmtpMail.SendMail(b_toAddress, b_subject, b_body, sendMail_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
}
function sendMail_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); return false;
}


function tl_dky_lamthem_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "") form_P_MOI(b_vungId, "XGL");
    else stl_cc.Fs_NS_TL_DKY_LAMTHEM_CT(b_so_id, tl_dky_lamthem_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_so_idId).value = b_so_id;
}

function tl_dky_lamthem_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}

function tl_dky_lamthem_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"),
        b_so_the = $get(b_gocId).value,
        b_thang = $get(b_thangId).value;
    if (b_so_id == "") tl_dky_lamthem_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_cc.Fs_NS_TL_DKY_LAMTHEM_XOA(b_so_id, b_so_the,b_thang, a_tso, a_cot, tl_dky_lamthem_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function tl_dky_lamthem_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) tl_dky_lamthem_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); tl_dky_lamthem_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
    return false;
}
function tl_dky_lamthem_P_HUY() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") { form_P_MOI(b_vungId, "X"); }
    else stl_cc.Fs_NS_TL_DKY_LAMTHEM_HUY(b_so_id, tl_dky_lamthem_P_HUY_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function tl_dky_lamthem_P_HUY_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        tl_dky_lamthem_P_LKE();
        form_P_LOI('loi:Hủy thành công:loi');
        return false;
    }
}
function form_dong() {
    location.reload(false);
}
