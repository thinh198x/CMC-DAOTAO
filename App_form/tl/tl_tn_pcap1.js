var tl_tn_pcap_lkeCho, b_vungId, b_grlkeId, b_grctId, b_gocId, b_mt, b_gchuId, b_so_idId,b_so_qd_id;
function tl_tn_pcap_P_KD(b_tm) {
    b_tmf = b_tm, tl_tn_pcap_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'), b_grcbId = form_Fs_VUNG_ID('GR_cb'),
    b_ngayId = form_Fs_TEN_ID(b_vungId, 'NGAY'), b_so_qdId = form_Fs_TEN_ID(b_vungId, 'SO_QD'), b_ngay_qdId = form_Fs_TEN_ID(b_vungId, 'NGAY_QD'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'MA_GOC'); b_phongId = form_Fs_TEN_ID(b_vungId, 'PHONG');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_so_qd_id = form_Fs_VTEN_ID('UPa_hi', 'SO_QD_ID'); 
    b_slideId = b_grlkeId + '_slide';
    b_gchuId = form_Fs_VTEN_ID('', 'gchu'); b_theoId = form_Fs_TEN_ID(b_vungId, 'theo');
    b_lblmaId = form_Fs_VTEN_ID('', 'lblma');
    b_tbgrctId = form_Fs_VUNG_ID('grct');
    b_tbgrcbId = form_Fs_VUNG_ID('grcb');
    b_gtriId = form_Fs_VTEN_ID('UPa_hi', 'gtri');
    b_hinhthucId = form_Fs_VTEN_ID('UPa_hi', 'hinhthuc');
    tl_tn_pcap_lkeCho = setInterval('tl_tn_pcap_P_LKE_CHO()', 200);
}

function tl_tn_pcap_hienan() {
    var b_theo = $get(b_theoId).value;

    if (b_theo == "PC") {
        $get(b_tbgrctId).style.display = "none";
        $get(b_tbgrcbId).style.display = "inline";
    }
    else {
        $get(b_tbgrctId).style.display = "inline";
        $get(b_tbgrcbId).style.display = "none";
    }
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("PHONG") >= 0) {
            tl_tn_pcap_P_MOI();
            tl_tn_pcap_P_LKE();
            $get(b_gocId).focus();
        }
        if (b_dtuong.indexOf("MA_GOC") >= 0) {
            tl_tn_pcap_P_MOI();
            $get(b_gocId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            var b_theo = $get(b_theoId).value;
            if (b_theo == "PC") {
                $get(b_gtriId).value = a_tso[2];
                $get(b_hinhthucId).value = a_tso[3];
            }
            tl_tn_pcap_P_LKE();
            $get(b_gocId).focus();
        }
        if (b_dtuong.indexOf("MAPC") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang > -1) {
                GridX_datGtri(b_grctId, b_hang, "mapc", b_kq);
                GridX_datGtri(b_grctId, b_hang, "tenpc", a_tso[1]);
                GridX_datGtri(b_grctId, b_hang, "giatri", a_tso[2]);
                GridX_datGtri(b_grctId, b_hang, "hinhthuc", a_tso[3]);
                $get(b_gchuId).innerHTML = a_tso[1];
                GridX_datA(b_grctId, b_hang, "giatri");
            }
        }
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grcbId);
            if (b_hang > -1) {
                GridX_datGtri(b_grcbId, b_hang, "so_the", b_kq);
                GridX_datGtri(b_grcbId, b_hang, "ten", a_tso[1]);
                GridX_datGtri(b_grcbId, b_hang, "giatri", $get(b_gtriId).value);
                GridX_datGtri(b_grcbId, b_hang, "hinhthuc", $get(b_hinhthucId).value);
                $get(b_gchuId).innerHTML = a_tso[1];
                GridX_datA(b_grcbId, b_hang, "giatri");
            }
        }
        if (b_dtuong.indexOf("SO_QD") >= 0) {
            $get(b_so_qd_id).value = a_tso[1];
            $get(b_so_qdId).value = b_kq;
        }
    }
    catch (err) { form_P_LOI(err); }
}

function tl_tn_pcap_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA_GOC": b_maId = b_gocId; form_P_MOI("", "XGL"); GridX_datTrang(b_grctId); break;
            case "NGAY": b_maId = b_ngayId; break;
            case "THEO": b_maId = b_theoId; break;
            case "PHONG": b_maId = b_phongId; break;
        }
        var b_ma = $get(b_maId);
        b_mt = b_maTen;
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA_GOC") {
            if (C_NVL(b_ma.value) != "GT") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), tl_tn_pcap_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
            tl_tn_pcap_P_MOI();
            tl_tn_pcap_P_LKE();
        }
        else if (b_maTen == "NGAY") {
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ngay", b_ma.value);
            if (b_hang < 0) { tl_tn_pcap_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); tl_tn_pcap_P_CHUYEN_HANG(); }
        }
        else if (b_maTen == "PHONG") {
            var b_theo = $get(b_theoId).value;
            if (b_theo == "PB") {
                $get(b_gocId).value = $get(b_phongId).value;
                $get(b_gocId).setAttribute("disabled", "disabled");
            }
            else $get(b_gocId).removeAttribute("disabled");
            tl_tn_pcap_P_MOI();
            tl_tn_pcap_P_LKE();
        }
        else if (b_maTen == "THEO") {
            var b_theo = $get(b_theoId).value;
            tl_tn_pcap_hienan();
            tl_tn_pcap_P_MOI();
            if (b_theo == "CB")
            {
                $get(b_gocId).setAttribute("f_tkhao",b_tmf+ "/ns/tt/ns_cb.aspx");
                $get(b_gocId).setAttribute("ktra", "ns_cb,so_the,ten");
                $get(b_lblmaId).innerHTML = "Mã số CB*";
                $get(b_gocId).setAttribute("ten", "Mã số cán bộ");
                $get(b_gocId).value = "";
                $get(b_gocId).removeAttribute("disabled");
                tl_tn_pcap_P_MOI();
            }
            else if (b_theo == "CD")
            {
                $get(b_gocId).setAttribute("f_tkhao", b_tmf + "/ns/ma/ns_ma_cdanh.aspx");
                $get(b_gocId).setAttribute("ktra", "ns_ma_cdanh,ma,ten");
                $get(b_lblmaId).innerHTML = "Mã chức danh*";
                $get(b_gocId).setAttribute("ten", "Chức danh");
                $get(b_gocId).value = "";
                $get(b_gocId).removeAttribute("disabled");
                tl_tn_pcap_P_MOI();
            }
            else if (b_theo == "CV") {
                $get(b_gocId).setAttribute("f_tkhao", b_tmf + "/ns/ma/ns_ma_cvu.aspx");
                $get(b_gocId).setAttribute("ktra", "ns_ma_cvu,ma,ten");
                $get(b_lblmaId).innerHTML = "Mã chức vụ*";
                $get(b_gocId).setAttribute("ten", "Chức vụ");
                $get(b_gocId).value = "";
                $get(b_gocId).removeAttribute("disabled");
                tl_tn_pcap_P_MOI();
            }
            else if (b_theo == "NH") {
                $get(b_gocId).setAttribute("f_tkhao", b_tmf + "/ns/ma/ns_ma_nh.aspx");
                $get(b_gocId).setAttribute("ktra", "ns_ma_nh,ma,ten");
                $get(b_lblmaId).innerHTML = "Mã nhóm*";
                $get(b_gocId).setAttribute("ten", "Mã nhóm");
                $get(b_gocId).value = "";
                $get(b_gocId).removeAttribute("disabled");
                tl_tn_pcap_P_MOI();
            }
            else if (b_theo == "PB") {
                $get(b_gocId).setAttribute("f_tkhao", b_tmf + "/ht/ht_maph.aspx");
                $get(b_gocId).setAttribute("ktra", "ht_ma_phong,ma,ten");
                $get(b_lblmaId).innerHTML = "Mã phòng ban*";
                $get(b_gocId).setAttribute("ten", "Mã phòng ban");
                $get(b_gocId).value = $get(b_phongId).value;
                $get(b_gocId).setAttribute("disabled", "disabled");
                tl_tn_pcap_P_MOI();
            }
            else if (b_theo == "PC") {
                $get(b_gocId).setAttribute("f_tkhao", b_tmf + "/tl/ma/tl_tlap_pcap.aspx");
                $get(b_gocId).setAttribute("ktra", "ns_tl_tlap_pcap,ma,ten");
                $get(b_gocId).setAttribute("ten", "Mã phụ cấp");
                $get(b_lblmaId).innerHTML = "Mã phụ cấp*";
                $get(b_gocId).value = "";
                $get(b_gocId).removeAttribute("disabled");
                tl_tn_pcap_P_MOI();
            }
            else if (b_theo == "GT") {
                $get(b_gocId).setAttribute("f_tkhao", "");
                $get(b_gocId).setAttribute("ktra", "");
                $get(b_lblmaId).innerHTML = "Giới tính*";
                $get(b_gocId).value = "";
                $get(b_gocId).removeAttribute("disabled");
                tl_tn_pcap_P_MOI();
            }
            tl_tn_pcap_P_LKE();
        }
    }
    catch (err) { form_P_LOI(err); }
}

function tl_tn_pcap_P_MA_KTRA() {
    try {
        var b_ngay = C_NVL($get(b_ngayId).value);
        if (b_ngay != "") {
            var b_so_the = $get(b_gocId).value;
            var b_phong = $get(b_phongId).value;
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            var b_theo = $get(b_theoId).value;
            stl_ch.Fs_TL_TN_PCAP_MA(b_so_the, b_phong, b_ngay,b_theo, b_TrangKt, a_cot, tl_tn_pcap_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function tl_tn_pcap_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        form_P_MOI(b_vungId, "X"); GridX_datTrang(b_grctId);
        $get(b_so_idId).value = "0";
    }
    else { GridX_datA(b_grlkeId, b_hang); tl_tn_pcap_P_CHUYEN_HANG(); }
}
function tl_tn_pcap_sp_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grctId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        b_mt = b_cot;
        if (b_value != "") {
            if (b_cot == "MAPC") {
                skhac.Fs_MA_LOI(form_Fs_nsd(),"Mã phụ cấp", b_value, "ns_tl_tlap_pcap,ma,ten,gtri", tl_tn_pcap_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        if (b_value != "") GridX_ThemHang(b_grctId);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function tl_tn_pcap_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_mt == "MAPC") {
        var b_hang = GridX_Fi_timHangA(b_grctId);
        GridX_datGtri(b_grctId, b_hang, "tenpc", b_kq);
        GridX_datA(b_grctId, b_hang, "giatri");
    }
    else if (b_mt == "SO_THE") {
        $get(b_gchuId).innerHTML = b_kq;
        GridX_datA(b_grctId, 0, "mapc");
    }
}

var tl_tn_pcap_choAct = 0;
function tl_tn_pcap_GR_lke_RowChange() {
    if (tl_tn_pcap_choAct != 0) clearTimeout(tl_tn_pcap_choAct);
    tl_tn_pcap_choAct = setTimeout("tl_tn_pcap_P_CHUYEN_HANG()", 300);
    return false;
}

function tl_tn_pcap_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(tl_tn_pcap_lkeCho); tl_tn_pcap_P_LKE(); }
}

function tl_tn_pcap_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    $get(b_so_idId).value = "0";
    $get(b_gocId).focus();
    return false;
}
function tl_tn_pcap_P_LKE() {
    try {
        var b_so_the = $get(b_gocId).value,
            a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_phong = $get(b_phongId).value,
            b_theo = $get(b_theoId).value;
        stl_ch.Fs_TL_TN_PCAP_LKE(b_so_the, b_phong,b_theo, a_tso, a_cot, tl_tn_pcap_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function tl_tn_pcap_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function tl_tn_pcap_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        var b_theo = $get(b_theoId).value;
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_so_id = $get(b_so_idId).value, b_so_qdid = $get(b_so_qd_id).value, b_dt = form_Faa_TEXT_ROW(b_vungId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
            if (b_theo == "PC") {
                var a_cot_ct = GridX_Fdt_cotGtri(b_grcbId);
                stl_ch.Fs_TL_TN_PCAP_NH2(b_so_id, b_TrangKt, b_dt, a_cot_ct, a_cot_lke, tl_tn_pcap_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
            else {
                var a_cot_ct = GridX_Fdt_cotGtri(b_grctId);
                stl_ch.Fs_TL_TN_PCAP_NH(b_so_id,b_so_qdid, b_TrangKt, b_dt, a_cot_ct, a_cot_lke, tl_tn_pcap_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function tl_tn_pcap_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI('loi:Nhập thành công:loi');
    }
    return false;
}
function tl_tn_pcap_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == null || b_so_id == "") { form_P_MOI("", "XGL"); GridX_datTrang(b_grctId); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        stl_ch.Fs_TL_TN_PCAP_CT(b_so_id, a_cot_ct, tl_tn_pcap_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function tl_tn_pcap_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    $get(b_so_idId).value = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
}
function tl_tn_pcap_P_XOA() {
    var r = confirm("Bạn có chắc chắn xóa không?");
    if (r == false) {
        return false;
    }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") tl_tn_pcap_P_MOI();
    else {
        var b_so_the = $get(b_gocId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_phong = $get(b_phongId).value;
        var b_theo = $get(b_theoId).value;
        stl_ch.Fs_TL_TN_PCAP_XOA(b_so_id, b_so_the, b_phong,b_theo, a_tso, a_cot, tl_tn_pcap_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function tl_tn_pcap_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) tl_tn_pcap_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); tl_tn_pcap_P_CHUYEN_HANG(); }
    }
}
function tl_tn_pcap_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function tl_tn_pcap_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function tl_tn_pcap_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function tl_tn_pcap_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}
function form_dong() {
    location.reload(false);
}