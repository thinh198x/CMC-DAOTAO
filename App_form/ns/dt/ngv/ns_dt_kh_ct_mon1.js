var ns_dt_kh_ct_mon_lkeCho, ns_dt_kh_ct_mon_gchuCho, b_grlkeId, b_ttin_kdtId, b_gchuId, b_so_id_kh, b_tt_pd, b_nsd;
function ns_dt_kh_ct_mon_P_KD() {
    b_grlkeId = form_Fs_VUNG_ID('GR_lke');       
    b_ttin_kdtId = form_Fs_VTEN_ID('', 'ttin_kdt');
    b_gchuId = form_Fs_VTEN_ID('UPa_gchu', 'gchu');
    b_nsd = form_Fs_nsd();
    //ns_dt_kh_ct_mon_lkeCho = setInterval('ns_dt_kh_ct_mon_P_LKE_CHO()', 200);

}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;            
        }
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            b_so_id_kh = a_tso[1];
            $get(b_ttin_kdtId).innerHTML = a_tso[2] + " - " + a_tso[3];
            b_tt_pd = a_tso[4];

            //var b_nhap_id = form_Fs_VTEN_ID('UPa_nhap', 'nhap');
            //var b_xoa_id = form_Fs_VTEN_ID('UPa_nhap', 'xoa');
            //var b_moi_id = form_Fs_VTEN_ID('UPa_nhap', 'moi');
            //$get(b_nhap_id).disabled = b_tt_pd != 0;
            //$get(b_xoa_id).disabled = b_tt_pd != 0;
            //$get(b_moi_id).disabled = b_tt_pd != 0;
            var ttpd = "Chưa gửi phê duyệt";
            switch (b_tt_pd) {
                case 1:
                    ttpd = "Chờ phê duyệt";
                    break;
                case 2:
                    ttpd = "Được phê duyệt";
                    break;
                case 3:
                    ttpd = "Không phê duyệt";
                    break;
                default:
                    break;
            }
            ns_dt_kh_ct_mon_P_DatGchu(false, ttpd);

            ns_dt_kh_ct_mon_P_LKE();                        
        }
        else if (b_dtuong.indexOf("MA") >= 0) {
            var b_hang1 = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang1 < 0) return;

            var b_hang2 = GridX_Fi_timHangD(b_grlkeId, "ma", a_tso[0]);
            if (b_hang2 > 0 && b_hang1 != b_hang2) {
                form_P_LOI("Đã có môn học này");
                return;
            }

            GridX_datGtri(b_grlkeId, b_hang1, ["ma"], [a_tso[0]], 'K');
            GridX_datGtri(b_grlkeId, b_hang1, ["ten"], [a_tso[1]], 'K');
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_dt_kh_ct_mon_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_dt_kh_ct_mon_lkeCho); ns_dt_kh_ct_mon_P_LKE(); }
}

function ns_dt_kh_ct_mon_P_NH() {
    if (b_tt_pd != 0) {
        form_P_LOI("Không thao tác được do đã gửi phê duyệt");
        return false;
    }
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_grlkeId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var a_cot_ct = GridX_Fdt_cotGtri(b_grlkeId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
        sns_dt.Fs_NS_DT_KH_CT_MON_NH(b_nsd, b_so_id_kh, a_cot_ct, a_cot_lke, ns_dt_kh_ct_mon_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
    return false;
}
function ns_dt_kh_ct_mon_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {        
        GridX_datBang(b_grlkeId, b_kq);
        ns_dt_kh_ct_mon_P_DatGchu(true, "Cập nhật thành công!");
    }
    return false;
}
function ns_dt_kh_ct_mon_P_MOI() {
    // xoa trang grid
    GridX_datTrang(b_grlkeId);
    return false;
}

function ns_dt_kh_ct_mon_P_XOA() {
    if (b_tt_pd != 0) {
        form_P_LOI("Không thao tác được do đã gửi phê duyệt");
        return false;
    }
    try {
        var message = confirm("Bạn có chắc chắn xóa toàn bộ danh sách môn thi không?");
        if (message == false) { return false; }
    
        sns_dt.Fs_NS_DT_KH_CT_MON_XOA(b_nsd, b_so_id_kh, ns_dt_kh_ct_mon_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
    return false;
}
function ns_dt_kh_ct_mon_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {        
        // xoa trang grid
        GridX_datTrang(b_grlkeId);
        ns_dt_kh_ct_mon_P_DatGchu(true, "Xóa thành công!");
    }
}

function ns_dt_kh_ct_mon_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId);
        sns_dt.Fs_NS_DT_KH_CT_MON_LKE(b_nsd, b_so_id_kh, a_cot, ns_dt_kh_ct_mon_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function ns_dt_kh_ct_mon_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }        
    GridX_datBang(b_grlkeId, b_kq);
}

function ns_dt_kh_ct_mon_GR_Update(b_event) {
    try {
        if (b_event.srcElement.id.indexOf("ma") < 0) return;

        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_ma_mon = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "MA"));
        if (b_ma_mon != "") {
            dt_thongtin_monHoc(b_ma_mon);
        }
        else {
            GridX_datTrang(b_grlkeId, b_hang, 1);
        }
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function dt_thongtin_monHoc(b_ma_mon) {
    try {
        sns_dt.Fs_NS_DT_MA_MON_CT_LUOI(b_ma_mon, dt_thongtin_monHoc_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function dt_thongtin_monHoc_kq(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        return false;
    }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_kq != "") {
        var a_kq = Fas_ChMang(b_kq, String.fromCharCode(1));
        GridX_datGtri(b_grlkeId, b_hang, "MA", a_kq[0]);
        GridX_datGtri(b_grlkeId, b_hang, "TEN", a_kq[1]);
    }
    else {
        form_P_LOI("Không tồn tại mã môn");
        //GridX_datTrang(b_grlkeId, b_hang, 1);
    }
    return false;
}

function ns_dt_kh_ct_mon_HangLen() {
    GridX_chuyenHang(b_grlkeId, -1);
    return false;
}
function ns_dt_kh_ct_mon_HangXuong() {
    GridX_chuyenHang(b_grlkeId, 1);

    return false;
}
function ns_dt_kh_ct_mon_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grlkeId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grlkeId);
    return false;
}
function ns_dt_kh_ct_mon_CatDong() {
    GridX_boChon(b_grlkeId, 'C');
    return false;
}

function ns_dt_kh_ct_mon_P_DatGchu(show, gchu) {
    form_P_DatGchu(b_gchuId, gchu);
    if (show) ns_dt_kh_ct_mon_gchuCho = setInterval('ns_dt_kh_ct_mon_P_DatGchu(false,".")', 2000);
    else if (ns_dt_kh_ct_mon_gchuCho) clearTimeout(ns_dt_kh_ct_mon_gchuCho);
}

function form_dong() {
    location.reload(false);
}