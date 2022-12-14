var b_vungId, b_vung_gvId, b_vung_dgId, b_id_cutId, b_vung_tsId, b_so_idId, b_grlkeId, b_slideId, b_mode, b_gchuId, b_id_tsId, b_grdglkeId, b_slidetsId;
var b_doi = 0, b_cho_control = 0, b_tu_gioId, b_tu_phutId, b_vung_tcId, b_den_gioId, b_den_phutId, b_ma_du_an_id, b_so_phutId, b_skill_id, b_tmf, b_kqua_dgId, b_danh_giaId, b_btn_ct_id, b_huy_id, b_ts_id, b_danhgia_id, b_trao_doi_id, b_tong_lsx, b_tong_gio;
function ns_ts_KD(b_frm) {
    b_tmf = b_frm;
    b_vungId = form_Fs_VUNG_ID('UPa_ct');
    b_vung_gvId = form_Fs_VUNG_ID('tab_pgiaoviec');
    b_vung_dgId = form_Fs_VUNG_ID('tab_pnh_ts');
    b_vung_tsId = form_Fs_VUNG_ID('tab_pnh_ts');
    b_vung_tcId = form_Fs_VUNG_ID('tab_ptc');
    b_vung_bookId = form_Fs_VUNG_ID('tab_pbook');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_id_cutId = form_Fs_VTEN_ID('UPa_hi', 'id_cut');
    b_id_tsId = form_Fs_VTEN_ID('UPa_hi', 'id_ts');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_grlkeId = form_Fs_VUNG_ID('GR_lke');
    b_grbookId = form_Fs_VUNG_ID('GR_book');
    b_grdglkeId = form_Fs_VUNG_ID('GR_dg_lke');
    b_slideId = b_grlkeId + '_slide';
    b_slidetsId = b_grdglkeId + '_slide';
    b_btn_ct_id = form_Fs_VTEN_ID('', 'sua');
    b_huy_id = form_Fs_VTEN_ID('', 'huy');
    b_ts_id = form_Fs_VTEN_ID('', 'ts');
    b_danhgia_id = form_Fs_VTEN_ID('', 'danhgia');
    b_trao_doi_id = form_Fs_VTEN_ID('', 'trao_doi');
    b_ma_du_an_id = form_Fs_VTEN_ID('', 'ma_du_an');
    b_tong_lsx = form_Fs_VTEN_ID('', 'tong_gio_lsx');
    b_tong_gio = form_Fs_VTEN_ID('', 'TONG_GIO');
    b_skill_id = form_Fs_VTEN_ID('', 'SKILL');
    b_trao_doi_id = form_Fs_VTEN_ID('', 'trao_doi');
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        if (b_dtuong.indexOf('NG_NHAN') >= 0) {
            GridX_thoiA(b_grbookId);
            b_hang = GridX_Fi_themTra(b_grbookId, 'ng_nhan');
            GridX_datGtri(b_grbookId, b_hang, ['ng_nhan', 'ten'], [a_tso[2], a_tso[3]]);
        }
        else if (b_dtuong.indexOf('MA_DU_AN') >= 0) {
            $get(b_ma_du_an_id).value = a_tso[0];
        }
        else if (b_dtuong.indexOf('SKILL') >= 0) {
            $get(b_skill_id).value = a_tso[0];
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_ts_P_KTRA(b_maTen) {
    try {
        b_maTen = b_maTen.toUpperCase();
        if (b_maTen == "GIO") {
            if (C_NVL($get(b_tu_gioId).value, 0) * 1 >= 24 || C_NVL($get(b_den_gioId).value, 0) * 1 >= 24)
                form_P_LOI('loi:Giờ không quá 24:loi');
            if (C_NVL($get(b_tu_phutId).value, 0) * 1 >= 60 || C_NVL($get(b_den_phutId).value, 0) * 1 >= 60)
                form_P_LOI('loi:Phút không quá 60:loi');
            $get(b_so_phutId).value = -(C_NVL($get(b_tu_gioId).value, 0) * 60 + C_NVL($get(b_tu_phutId).value, 0) * 1 - C_NVL($get(b_den_gioId).value, 0) * 60 - C_NVL($get(b_den_phutId).value, 0) * 1);
        }
    } catch (err) { form_P_LOI(err); }
}

function ns_ts_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}

function ns_ts_gv_P_CT_MOI(b_dk) {
    form_P_MOI(b_vung_gvId, b_dk);
}

//giao việc với id_ct = id cấp trên của thằng đang focus

function ns_ts_gv_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vung_gvId);
    if (b_loi != "") form_P_LOI(b_loi);
    else {
        var a_dt = form_Faa_TEXT_ROW(b_vung_gvId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = 0; var b_id_ct = 0;
        a_dt[0].push('id_ct');
        //if (b_mode == 'GVC') {
        //    if (b_hang > 0) {
        //        b_so_id = '0';
        //        a_dt[1].push(C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id")));
        //    }
        //    else form_P_LOI('loi:Khong co viec cha:loi');
        //}
        if (b_mode == 'GV') {
            b_id_ct = b_hang < 1 ? 0 : C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id_ct"));
            if (b_id_ct === undefined)
                b_id_ct = 0;
        }
        if (b_mode == 'CT') {
            if (b_hang < 1) { form_P_LOI("loi:Bạn chưa chọn việc cần xem:loi"); return false };
            b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
            b_id_ct = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id_ct"));
        }
        if (b_mode == 'GVC') {
            if (b_hang < 1) { form_P_LOI("loi:Chưa chọn việc cần giao:loi"); return false };
            b_so_id = '0';
            b_id_ct = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
        }
        //var tong_lsx = $get(b_tong_lsx).value;
        //var tong_gio = $get(b_tong_gio).value;
        //if (tong_lsx != "") {
        //    if (tong_gio > tong_lsx) {
        //        form_P_LOI("loi:Tổng giờ giao không được lớn hơn tổng g   iờ lệnh sản xuất:loi");
        //        return false;
        //    }
        //}
        a_dt[1].push(b_id_ct);
        sns_ts.Fs_NS_TS_GV_NH(form_Fs_nsd(), b_so_id, a_dt, ns_ts_gv_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        ns_ts_gv_P_MO_GV(false, b_mode);

    }
    return false;
}

function ns_ts_gv_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        $get(b_so_idId).value = a_kq[0];
        ns_ts_gv_P_LKE(false);
        form_P_LOI("loi:Nhập thành công:loi");
        //ns_ts_gv_P_LKE_ID(a_kq[0]); return false;
    }
}

function ns_ts_gv_P_XOA() {
    try {
        if (confirm("Bạn có chắc chắn muốn xóa?") == true) {
            var b_hang = GridX_Fi_timHangA(b_grlkeId); if (b_hang < 1) return false;
            var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
            if (b_so_id == "0") ns_ts_P_MOI();
            else {
                var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId), b_dt = form_Faa_TEXT_ROW(b_vungId)
                    , b_path = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "path"));
                sns_ts.Fs_NS_TS_GV_XOA(form_Fs_nsd(), b_so_id, b_path, b_dt, a_cot, a_tso, ns_ts_gv_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        form_P_LOI('');
        return false;
    } catch (err) {
        form_P_LOI(err);
    }
}

function ns_ts_gv_P_XOA_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang == 1 && GridX_Fb_hangTrang(b_grlkeId, 2)) b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
        if (b_hang > 1 && GridX_Fb_hangTrang(b_grlkeId, b_hang)) b_hang--;
        if (b_hang < 1 || GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_ts_P_MOI();
        else {
            GridX_datA(b_grlkeId, b_hang); ns_ts_gv_P_CT();
            $get(b_so_idId).value = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
            $get(b_id_cutId).value = 0;
            form_P_DatGchu(b_gchuId, 'Di chuyển thành công!');
        }
        doimau();
        form_P_LOI("loi:Xóa thành công:loi");
    } catch (err) { form_P_LOI(err); }
}

function ns_ts_GR_lke_RowChange(b_event) {
    try {
        try {

            var b_ctr = form_Fctr_event(b_event);
            if (b_ctr.nodeName == 'NOBR') b_ctr = b_ctr.parentNode;
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            var b_value = C_NVL(b_ctr.innerText);
            var b_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
            ns_ts_gv_P_ENABLE("");

            var b_cot = b_ctr.getAttribute("cot");
            if (b_value != "") {
                if (b_cot == "loai") { ns_ts_gv_P_LKE(true); }
                else {
                    ns_ts_gv_P_CT_MOI('X');
                    var b_hang = GridX_Fi_timHangA(b_grlkeId); $get(b_so_idId).value = b_id;
                    ns_ts_gv_P_CT();
                    ns_ts_gv_BOOK_CT();
                    return false;
                }
            }
            else {
                ns_ts_gv_P_CT_MOI('X');
                doimau();
            }
        }
        catch (err) { }
    } catch (err) { form_P_LOI(err); }
}

function ns_ts_gv_P_CT() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
        if (b_so_id != "") sns_ts.Fs_NS_TS_GV_CT(form_Fs_nsd(), b_so_id, ns_ts_gv_P_CT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        else { form_P_LOI(''); return false; }
    } catch (err) { form_P_LOI(err); }
}

function ns_ts_gv_P_ENABLE(b_dk) {
    try {
        //if (b_dk == "GV") {
        //    $get("tdLTongLsx").style.display = "";
        //    $get("tdVTongLsx").style.display = "";
        //} else {
        //    $get("tdLTongLsx").style.display = "none";
        //    $get("tdVTongLsx").style.display = "none"; 
        //}
        var b_hang = GridX_Fi_timHangA(b_grlkeId);

        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
        var b_hien = '';
        if (b_so_id == "") b_hien = 'none';
        $get(b_btn_ct_id).style.display = b_hien;
        $get(b_huy_id).style.display = b_hien;
        $get(b_ts_id).style.display = b_hien;
        $get(b_danhgia_id).style.display = b_hien;
        $get(b_trao_doi_id).style.display = b_hien;
    } catch (err) { form_P_LOI(err); }
}

function ns_ts_gv_P_CT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else if (b_kq === "") ns_ts_gv_P_CT_MOI("XGL"); else {
        form_P_CH_TEXT(b_vung_gvId, b_kq);
        ns_ts_dg_P_LKE();
        form_P_CH_TEXT(b_vung_tcId, b_kq);
        doimau();
    }
}

function ns_ts_gv_BOOK_CT() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
        var a_cot = GridX_Fas_tenCot(b_grbookId);
        if (b_so_id != "") sns_ts.Fs_NS_TS_BOOK_CT(form_Fs_nsd(), b_so_id, a_cot, ns_ts_gv_BOOK_CT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        else { form_P_LOI(''); return false; }
    } catch (err) { form_P_LOI(err); }
}

function ns_ts_gv_BOOK_CT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang(b_grbookId, b_kq);
    return false;
}


function ns_ts_gv_P_LKE(b_dk) {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_dt = form_Faa_TEXT_ROW(b_vungId); var a_cot = GridX_Fas_tenCot(b_grlkeId); var a_tso = slide_Faobj_TUDEN(b_slideId);
            var b_hang = GridX_Fi_timHangA(b_grlkeId); var b_so_id = 0; var b_loai = ""; var b_path = "";
            if (b_hang > 0 && b_dk) {
                b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
                b_loai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "loai"));
                b_path = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "path"));
            }
            sns_ts.Fs_NS_TS_GV_LKE(form_Fs_nsd(), b_so_id, b_path, b_loai, b_dt, a_cot, a_tso, ns_ts_gv_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    } catch (err) {
        form_P_LOI(err);
    }
}
function ns_ts_gv_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#'); slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]); doimau();
}

function ns_ts_gv_P_LKE_ID(b_so_id) {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), b_hangKt = GridX_Fi_hangKt(b_grlkeId); var b_dt = form_Faa_TEXT_ROW(b_vungId);
        sns_ts.Fs_NS_TS_GV_LKE_ID(form_Fs_nsd(), b_so_id, b_dt, b_hangKt, a_cot, ns_ts_gv_P_LKE_ID_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    } catch (err) { form_P_LOI(err); }
}

function ns_ts_gv_P_LKE_ID_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]), b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]); GridX_datBang(b_grlkeId, a_kq[3]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        if (b_hang > 0) { GridX_datA(b_grlkeId, b_hang); $get(b_so_idId).value = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id")); }
        doimau();
    } catch (err) { form_P_LOI(err); }
}

function ns_ts_gv_P_MO_DG(b_mo) {
    if (b_mo) { $get(b_vung_dgId).style.display = ''; ns_ts_dg_P_LKE(); }
    else { $get(b_vung_dgId).style.display = 'none'; }
    form_P_LOI(''); return false;
}

function ns_ts_gv_P_MO_TC(b_mo) {
    if (b_mo) {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
        if (b_id != "") $get(b_vung_tcId).style.display = '';
    }
    else $get(b_vung_tcId).style.display = 'none';
    form_P_LOI(''); return false;
}

function ns_ts_gv_P_MO_BOOK(b_mo) {
    if (b_mo) {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
        if (b_id != "") $get(b_vung_bookId).style.display = '';
    }
    else $get(b_vung_bookId).style.display = 'none';
    form_P_LOI(''); return false;
}

function ns_ts_gv_P_MO_GV(b_mo, b_dk) {
    if (b_mo) {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
         
        b_mode = b_dk;
        if (b_dk == 'GV') {

            $get(b_so_idId).value = '0';
            GridX_thoiA(b_grlkeId);
        }
        if (b_dk == 'CT') ns_ts_gv_P_CT();
        else ns_ts_gv_P_CT_MOI('X');

        if (b_hang < 0) {
            if (b_dk == "GVC") {
                form_P_LOI("loi:Bạn chưa chọn việc cần giao:loi"); return false;
            }
            if (b_dk == "CT") {
                form_P_LOI("loi:Bạn chưa chọn việc cần xem:loi"); return false;
            }
        } else if (b_dk == "GVC") {
            var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
            if (b_so_id == "0" || b_so_id == "") {
                form_P_LOI("loi:Bạn chưa chọn việc cần giao:loi"); return false;
            }
        }
        $get(b_vung_gvId).style.display = '';
        ns_ts_gv_P_ENABLE(b_dk);
    }
    else $get(b_vung_gvId).style.display = 'none';
    form_P_LOI(''); return false;
}
function ns_ts_gv_P_MO_TS(b_mo) {
    var b_hang = GridX_Fi_timHangA(b_grlkeId); if (b_hang < 1) return false;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
    if (b_so_id != "0") form_P_MO("ns_ts_nh.aspx", null, ["SO_ID", [b_so_id]], "");
    form_P_LOI('');
    return false;
}

function ns_ts_gv_P_DC() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId); if (b_hang < 1) return false;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
        if (b_so_id == "0") ns_ts_P_MOI();
        else {
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId), b_dt = form_Faa_TEXT_ROW(b_vungId), b_path = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "path"));
            sns_ts.Fs_NS_TS_GV_DC(form_Fs_nsd(), $get(b_id_cutId).value, b_so_id, b_path, b_dt, a_cot, a_tso, ns_ts_gv_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    } catch (err) {
        form_P_LOI(err);
    }
}

function ns_ts_gv_P_BACK() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId); if (b_hang < 1) return false;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
        if (b_so_id == "0") ns_ts_P_MOI();
        else {
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            var b_dt = form_Faa_TEXT_ROW(b_vungId); var b_path = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "path"));
            sns_ts.Fs_NS_TS_GV_BACK(form_Fs_nsd(), b_so_id, b_path, b_dt, a_cot, a_tso, ns_ts_gv_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    } catch (err) {
        form_P_LOI(err);
    }
}
function ns_ts_gv_P_NEXT() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId); if (b_hang < 2) return false;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang - 1, "id"));
        var b_id_cut = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
        if (b_so_id == "0") ns_ts_P_MOI();
        else {
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId), b_dt = form_Faa_TEXT_ROW(b_vungId), b_path = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "path"));
            sns_ts.Fs_NS_TS_GV_DC(form_Fs_nsd(), b_id_cut, b_so_id, b_path, b_dt, a_cot, a_tso, ns_ts_gv_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    } catch (err) {
        form_P_LOI(err);
    }
}

function ns_ts_gv_CatDong() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return false;
    var b_so_id_cut = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
    if (b_so_id_cut === undefined) form_P_LOI('loi:Chưa chọn dòng cut:loi');;
    $get(b_id_cutId).value = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
    form_P_DatGchu(b_gchuId, 'Di chuyển: ' + C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "nd")));
    return false;
}

function ns_ts_gv_TT_P_NH(b_dk) {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return false;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
    if (b_so_id != "") sns_ts.Fs_NS_TS_TT_NH(form_Fs_nsd(),b_dk, b_so_id, b_dk, ns_ts_gv_TT_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    if (b_dk == "DN") {
        form_P_LOI("loi:Bạn đã nhận việc thành công:loi");
    } else if (b_dk == "CDG") {
        form_P_LOI("loi:Công việc đã được kết thúc:loi");
    }
    return false;
}

function ns_ts_gv_TT_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        ns_ts_gv_P_LKE(false);

        //ns_ts_gv_P_LKE_ID($get(b_so_idId).value);
    };
    return false;
}

function ns_ts_gv_P_TC_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vung_tcId);
    if (b_loi != "") form_P_LOI(b_loi);
    else {
        var a_dt = form_Faa_TEXT_ROW(b_vung_tcId); var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return false;
        else {
            var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
            sns_ts.Fs_NS_TS_GV_TC(form_Fs_nsd(), b_so_id, a_dt, ns_ts_gv_P_TC_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    ns_ts_gv_P_LKE(false);

    return false;
}

function ns_ts_gv_P_TC_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        ns_ts_gv_P_MO_TC(false);
        form_P_LOI("loi:Từ chối việc thành công:loi");
        //ns_ts_gv_P_LKE_ID($get(b_so_idId).value);
        ns_ts_gv_P_LKE(false);
    }
}

function doimau() {

    var so_hang = GridX_Fi_timHangS(b_grlkeId);
    var b_ngay_con, b_ttrang;
    for (var i = 1; i <= so_hang; i++) {
        b_ngay_con = GridX_Fas_layGtri(b_grlkeId, i, "ngay_con");
        b_ttrang = GridX_Fas_layGtri(b_grlkeId, i, "ma_ttrang");
        if (CSO_SO(b_ngay_con) <= 3 && (b_ttrang == 'DN' || b_ttrang == 'CDG')) GridX_P_MauCell(b_grlkeId, i, '', "#FFE87C", "#000000")
        else GridX_P_MauCell(b_grlkeId, i, '', "#FFFFFF", "#000000");
    }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    GridX_P_MauCell(b_grlkeId, b_hang, '', "lightcyan", "#000000")
    return false;
}

function GridX_P_MauCell(gridId, b_hang, b_cot, b_nen, b_chu) {
    try {
        var a_cell = $get(gridId).rows[b_hang].cells;
        var a_cot = (b_cot == "") ? GridX_Fas_tenCot(gridId) : b_cot.split(',');
        var b_row = $get(gridId).rows[b_hang],
            b_cellId = "";
        for (var i = 1; i <= a_cot.length; i++) {
            //b_cellId = b_row.getCellFromKey(a_cot[i]).Id;
            //var b_cell = $get(b_cellId);
            if (C_NVL(b_nen) != "") a_cell[i].style.backgroundColor = b_nen;
            if (C_NVL(b_chu) != "") a_cell[i].style.color = b_chu;
        }
    } catch (ex) { }
}

function ns_ts_TRDOI() {
    var b_nsd = form_Fs_nsd();
    var b_hang = GridX_Fi_timHangA(b_grlkeId); if (b_hang < 1) return false;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
    form_P_MO(b_tmf + '/khud/khud_trdoi.aspx', null, ['TSO', ['', b_so_id]]);
    return false;
}


function ns_ts_gv_P_DG_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vung_tsId);
    if (b_loi != "") form_P_LOI(b_loi);
    else {
        var a_dt = form_Faa_TEXT_ROW(b_vung_tsId); var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return false;
        else {
            var b_hang2 = GridX_Fi_timHangA(b_grdglkeId);
            if (b_hang2 < 1) {
                var b_so_id = 0;
            }
            else { var b_so_id = C_NVL(GridX_Fas_layGtri(b_grdglkeId, b_hang2, "so_id")); }
            var b_so_id_cv = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
            sns_ts.Fs_NS_TS_DG_NH(form_Fs_nsd(), b_so_id_cv, b_so_id, a_dt, ns_ts_gv_P_DG_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    ns_ts_gv_P_LKE(false);
    return false;
}

function ns_ts_gv_P_BOOK_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang < 1) return false;
            else {
                var b_so_id_cv = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
                var b_dt_ct = GridX_Fdt_cotGtri(b_grbookId);
                sns_ts.Fs_NS_TS_BOOK_NH(b_so_id_cv, b_dt_ct, ns_ts_gv_P_BOOK_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        ns_ts_gv_P_LKE(false);
        return false;
    }
    catch (err) { throw (err); }
}
function ns_ts_gv_P_BOOK_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI("loi:Nhập thành công!:loi");
    }
}


function ns_ts_gv_P_DG_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        ns_ts_dg_P_LKE();
        ns_ts_gv_P_LKE();
    }
}
//function ns_ts_gv_P_DG_LKE() {
//	try {
//		var a_cot = GridX_Fas_tenCot(b_grdglkeId);
//		var b_hang = GridX_Fi_timHangA(b_grlkeId);
//		if (b_hang < 1) return false;
//		var b_so_id_cv = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "id"));
//		sns_ts.Fs_NS_TS_DG_LKE(form_Fs_nsd(), b_so_id_cv, a_cot, ns_ts_gv_P_DG_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
//		return false;
//	}
//	catch (err) { form_P_LOI(err); }
//}
//function ns_ts_gv_P_DG_LKE_KQ(b_kq) {
//	if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
//	GridX_datBang(b_grdglkeId, b_kq);
//	return false;
//}


function ns_ts_gv_P_DG_CT() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grdglkeId);
        if (b_hang < 1) return false;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grdglkeId, b_hang, "so_id"));
        if (b_so_id != "")
            sns_ts.Fs_NS_TS_DG_CT(form_Fs_nsd(), b_so_id, ns_ts_gv_P_DG_CT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        else form_P_MOI(b_vung_dgId, 'X');
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ts_gv_P_DG_CT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vung_tsId, b_kq);
    return false;
}

function ns_danhsach_P_IN() {
    var a_cot = GridX_Fdt_cotGtri(b_grlkeId);
    //var b_ma_bc = 'ns_tl_bluong.xml',
    var b_ma_bc = 'ns_ts_lke.xml',
        b_ddan = '~/Templates/ns/', a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
    var b_kieu_in = 'E', b_ten_rp = b_ma_bc;
    var a_dt = GridX_Fdt_cotGtri(b_grlkeId);
    if (b_ten_rp == "") { form_P_LOI('Chưa chọn đúng báo cáo'); return; }
    sns_tt.Fs_EXCEL("ns_ngbc", "TT", b_ma_bc, b_ddan, b_ten_rp, b_kieu_in, a_dt_ct, a_dt, P_EXCEL_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function P_EXCEL_KQ(b_kq) {
    //?md=TT
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_MO(form_Fs_TM() + '/App_form/bc/xexcel.aspx?md=TT', null, null, "C");
}

function form_dong() {
    location.reload(false);
}