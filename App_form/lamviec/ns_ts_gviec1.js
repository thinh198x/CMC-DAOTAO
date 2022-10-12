var bhc_hoso_lkecho, b_tmf, b_vungid, b_slideid, b_so_idid, b_kt_ntnid,
    b_gchuid, b_lan_dcid, b_temp_id, b_ngaydid, b_ngaycid, b_sohsid, b_thang_nhap_id, b_ct_cho,
    b_so_hieu_hs_id, b_tg = 'C',
    b_grlkeid, b_timid, b_so_bhxh_id, b_so_bhxh_tk_id, b_ma_huyenid,
    b_ma_xaid, b_nguonid, b_ngay_qdid, b_ngay_sinhid, b_ngay_cap_cmtid, b_atmid, b_stkid,
    b_ngay_trcapid, b_loaiid, b_ma_ndid, b_tenid, b_ma_tpid, b_ma_dvi_dky_kcbid, b_ma_cvuid,
    b_ma_loai_cvuid, b_lanh_daoid, b_tru_quanid, b_ma_loai_qlid, b_ma_dlyid, b_tmp, b_tmp2,
    b_cho_control = 0,
    b_doi, b_ma_nh_id, b_maten_tmp, b_mode, b_ten_ctkId, b_ma_loai_dt_kcbId;
var bhc_hoso_choAct = 0,
    b_daily_cap_1Id, b_daily_cap_2Id, b_daily_cap_3Id;

function bhc_hoso_KD(b_tm) {
    try {
        b_tmf = b_tm;
        b_doi = 0;
        b_vungId = form_Fs_VUNG_ID('UPa_ct');
        b_grlkeId = form_Fs_VUNG_ID('GR_lke');
        b_slideId = b_grlkeId + '_slide';
        b_gchuId = form_Fs_VTEN_ID('', 'gchu');
        //b_timId = form_Fs_VTEN_ID('UPa_tk', 'tim');
        //b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
        //b_kt_ntnId = form_Fs_VTEN_ID('UPa_hi', 'kt_ntn');
        //b_so_hieu_hs_id = form_Fs_VTEN_ID('UPa_hi', 'so_hieu_hs');
        //b_lan_dcId = form_Fs_VTEN_ID('UPa_hi', 'lan_dc');
        //b_so_bhxh_ID = form_Fs_TEN_ID(b_vungId, 'SO_BHXH');
        //b_thang_nhap_Id = form_Fs_TEN_ID('UPa_tk', 'thang_nhap');
        //b_so_bhxh_tk_Id = form_Fs_TEN_ID('UPa_tk', 'so_bhxh_tk');
        //b_ma_huyenId = form_Fs_TEN_ID(b_vungId, 'ma_huyen');
        //b_ma_xaId = form_Fs_TEN_ID(b_vungId, 'ma_xa');
        //b_nguonId = form_Fs_TEN_ID(b_vungId, 'NGUON');
        //b_ngay_qdId = form_Fs_TEN_ID(b_vungId, 'NGAY_QD');
        //b_ngay_sinhId = form_Fs_TEN_ID(b_vungId, 'NGAY_SINH');
        //b_ngay_cap_cmtId = form_Fs_TEN_ID(b_vungId, 'ngay_cap_cmt');
        //b_atmId = form_Fs_TEN_ID(b_vungId, 'atm');
        //b_stkId = form_Fs_TEN_ID(b_vungId, 'stk');
        //b_ngay_trcapId = form_Fs_TEN_ID(b_vungId, 'ngay_trcap');
        //b_loaiId = form_Fs_TEN_ID(b_vungId, 'loai');
        //b_ma_ndId = form_Fs_TEN_ID(b_vungId, 'ma_nd');
        //b_tenId = form_Fs_TEN_ID(b_vungId, 'TEN');
        //b_ma_tpId = form_Fs_TEN_ID(b_vungId, 'ma_tp');
        //b_ma_dvi_dky_kcbId = form_Fs_TEN_ID(b_vungId, 'ma_dvi_dky_kcb');
        //b_ma_cvuId = form_Fs_TEN_ID(b_vungId, 'ma_cvu');
        //b_ma_loai_cvuId = form_Fs_TEN_ID(b_vungId, 'ma_loai_cvu');
        //b_lanh_daoId = form_Fs_TEN_ID(b_vungId, 'lanh_dao');
        //b_tru_quanId = form_Fs_TEN_ID(b_vungId, 'tru_quan');
        //b_ma_loai_qlId = form_Fs_TEN_ID(b_vungId, 'ma_loai_ql');
        //b_ma_dlyId = form_Fs_TEN_ID(b_vungId, 'ma_dly');
        //b_ma_nh_id = form_Fs_TEN_ID(b_vungId, 'ma_nh');
        //b_daily_cap_1Id = form_Fs_VTEN_ID(b_vungId, 'daily_cap_1');
        //b_daily_cap_2Id = form_Fs_VTEN_ID(b_vungId, 'daily_cap_2');
        //b_daily_cap_3Id = form_Fs_VTEN_ID(b_vungId, 'daily_cap_3');
        //b_ten_ctkId = form_Fs_VTEN_ID(b_vungId, 'ten_ctk');
        //b_ma_loai_dt_kcbId = form_Fs_VTEN_ID(b_vungId, 'ma_loai_dt_kcb');
    } catch (err) {
        dumpError(err);
    }
}

function P_MO_DANHGIA() {
    $get(form_Fs_VTEN_ID('UPa_ct', 'tab_pdanhgia')).style.display = '';
    return false;
}




function P_cho(b_id, b_lan_dc, b_so_bhxh, mode, check) {
    try {
        if (b_doi === 0) {
            if (b_id === 0) return;
            $get(b_so_idId).value = b_id;
            $get(b_lan_dcId).value = b_lan_dc;
            $get(b_so_bhxh_ID).value = b_so_bhxh;
            b_temp_id = b_id;
            b_doi = 1;
            b_mode = mode;
            b_ct_cho = setInterval("bhc_hoso_P_CT_CHO()", 200);
            if (check == 1) P_HIEN_AN();
            if (mode == 'Y') $get(form_Fs_VTEN_ID('Upa_bt', 'nhap')).style.display = '';
            clearTimeout(b_cho_control);
        }
    } catch (err) {
        b_doi = 0;
        dumpError(err);
    }
}

function P_HIEN_AN() {
    document.getElementById("tong").style.display = "none";
    form_P_KTHUOC(650, 600);
    $get(form_Fs_VTEN_ID('Upa_bt', 'nhap')).style.display = 'none';
    $get(form_Fs_VTEN_ID('Upa_bt', 'xoa')).style.display = 'none';
    $get(form_Fs_VTEN_ID('Upa_bt', 'moi')).style.display = 'none';
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        b_doi = 0;
        if (b_dtuong.toUpperCase().indexOf("SO_ID") >= 0) {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "','" + a_tso[3] + "',0)", 200);
        } else if (b_dtuong.toUpperCase().indexOf("TKCT") >= 0) {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "','" + a_tso[3] + "',1)", 200);
            b_tg = 'K';
        } else if (b_dtuong.toUpperCase().indexOf("KCB") >= 0 || b_dtuong.toUpperCase().indexOf("MA_TP") >= 0) {
            $get(form_Fs_VTEN_ID('UPa_ct', 'ma_tp')).value = a_tso[1];
            $get(form_Fs_VTEN_ID('UPa_ct', 'ma_dvi_dky_kcb')).value = a_tso[0];
        } else if (b_dtuong.toUpperCase().indexOf("MA_NH") >= 0) {
            $get(form_Fs_VTEN_ID('UPa_ct', 'ma_nh')).value = a_tso[0];
            $get(b_gchuId).innerHTML = a_tso[1];
        } else if (b_dtuong.toUpperCase().indexOf("ATM") >= 0) {
            if (C_NVL(b_tmp) === '')
                bhc_hoso_P_LKE_DLY();
        } else if (b_dtuong.toUpperCase().indexOf("RELOAD") >= 0) {
            $get(form_Fs_VTEN_ID('UPa_ct', 'so_qd')).focus();
            bhc_hoso_P_CHUYEN_HANG();
        } else {
            $get(b_dtuong).value = a_tso[0];
            $get(b_dtuong).focus();
        }
    } catch (err) {
        dumpError(err);
    }
}

function bhc_hoso_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen_tmp = b_maTen;
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "THANG_NHAP":
                b_maId = form_Fs_VTEN_ID('UPa_tk', 'thang_nhap');
                break;
            case "NGAYQD":
                b_maId = b_ngay_qdId;
                break;
            case "NGAYSINH":
                b_maId = b_ngay_sinhId;
                break;
            case "NGAYCAPCMT":
                b_maId = b_ngay_cap_cmtId;
                break;
            case "NGAYTRCAP":
                b_maId = b_ngay_trcapId;
                break;
            case "LOAI":
                b_maId = b_loaiId;
                break;
            case "TEN":
                b_maId = b_tenId;
                break;
            case "MA_TP":
                b_maId = b_ma_tpId;
                break;
            case "MA_DVI_KCB":
                b_maId = b_ma_dvi_dky_kcbId;
                break;
            case "MAHUYEN":
                b_maId = b_ma_huyenId;
                break;
            case "MAXA":
                b_maId = b_ma_xaId;
                break;
            case "SOBHXH":
                b_maId = b_so_bhxh_ID;
                break;
            case "MA_NH":
                b_maId = b_ma_nh_id;
                break;
        }
        var b_ma = $get(b_maId);
        if (b_maTen.indexOf("MA_NH") >= 0) {
            if (C_NVL(b_ma.value) === "") return;
            skhac.Fs_MA_LOI_SON("Mã ngân hàng", b_ma.value, "kh_ma_nhang,ma,ten", bhc_hoso_P_DatGchu, P_LOI_CSDL_2, P_LOI_TGIAN);
        }
        if (b_maTen.indexOf("MA_TP") >= 0) {
            if (C_NVL(b_ma.value) === "") return;
            skhac.Fs_MA_LOI_SON("Mã thành phố", b_ma.value, "kh_ma_kvuc,ma,ten", bhc_hoso_P_DatGchu, P_LOI_CSDL_2, P_LOI_TGIAN);
        }
        if (b_maTen.indexOf("MAHUYEN") >= 0) {
            var b_ma_huyen = $get(b_ma_huyenId).value;
            if (b_ma_huyen === "") {
                form_P_LOI('loi:Phải chọn huyện!:loi');
                $get(b_ma_huyenId).focus();
            } else {
                bhc_hoso_P_LKE_XA();
            }
        }
        if (b_maTen.indexOf("MAXA") >= 0) {
            bhc_hoso_P_LKE_DLY();
        }
        if (b_maTen.indexOf("SOBHXH") >= 0) {
            var b_so_bhxh = $get(b_so_bhxh_ID).value;
            var b_so_id = $get(b_so_idId).value;
            if (b_so_bhxh === "") {
                form_P_LOI('loi:Không để trống số sổ!:loi');
                $get(b_so_bhxh_ID).focus();
            } else {
                if (b_so_id == "0" || b_so_id === "") {
                    sbhc_tk.Fs_HOSO_SO_ID(b_so_bhxh, bhc_hoso_P_MA, P_LOI_CSDL_2, P_LOI_TGIAN);
                    return false;
                }
            }
        }
        if (b_maTen.indexOf("MA_DVI_KCB") >= 0) {
            if (C_NVL(b_ma.value) === "") return;
            var b_ma_tp = $get(b_ma_tpId).value;
            var b_ma_dvi_kcb = $get(b_ma_dvi_dky_kcbId).value;
            sbhc_hoso.Fs_MA_KCB_CHECK(b_ma_tp, b_ma_dvi_kcb, bhc_hoso_P_DatGchu, P_LOI_CSDL_2, P_LOI_TGIAN);
        }
        if (b_maTen.indexOf("NGAYQD") >= 0) {
            if (C_NVL(b_ma.value) === "") return;
            var b_ngay_qd = $get(b_ngay_qdId).value;
            var b_ngay = b_ngay_qd.substring(0, 2),
                b_thang = b_ngay_qd.substring(3, 5),
                b_nam = b_ngay_qd.substring(6, 10);
            if (b_ngay > 31 || b_ngay < 1 || b_thang > 12 || b_thang < 1 || b_nam <= 1900) {
                form_P_LOI('loi:Phải nhập giá trị ngày từ 1->31 và tháng từ 1 -> 12 và năm lớn hơn 1900!:loi');
                $get(b_ngay_qdId).value = "";
                $get(b_ngay_qdId).focus();
                return false;
            }
        }
        if (b_maTen.indexOf("NGAYSINH") >= 0) {
            if (C_NVL(b_ma.value) === "") return;
            var b_ngay_sinh = $get(b_ngay_sinhId).value;
            var b_ngay = b_ngay_sinh.substring(0, 2),
                b_thang = b_ngay_sinh.substring(3, 5),
                b_nam = b_ngay_sinh.substring(6, 10);
            if (b_ngay > 31 || b_ngay < 1 || b_thang > 12 || b_thang < 1 || b_nam <= 1900) {
                form_P_LOI('loi:Phải nhập giá trị ngày từ 1->31 và tháng từ 1 -> 12 và năm lớn hơn 1900!:loi');
                $get(b_ngay_sinhId).value = "";
                $get(b_ngay_sinhId).focus();
                return false;
            }
        }
        if (b_maTen.indexOf("NGAYCAPCMT") >= 0) {
            if (C_NVL(b_ma.value) === "") return;
            var b_ngay_cap_cmt = $get(b_ngay_cap_cmtId).value;
            var b_ngay = b_ngay_cap_cmt.substring(0, 2),
                b_thang = b_ngay_cap_cmt.substring(3, 5),
                b_nam = b_ngay_cap_cmt.substring(6, 10);
            if (b_ngay > 31 || b_ngay < 1 || b_thang > 12 || b_thang < 1 || b_nam <= 1900) {
                form_P_LOI('loi:Phải nhập giá trị ngày từ 1->31 và tháng từ 1 -> 12 và năm lớn hơn 1900!:loi');
                $get(b_ngay_cap_cmtId).value = "";
                $get(b_ngay_cap_cmtId).focus();
                return false;
            }
        }
        if (b_maTen.indexOf("LOAI") >= 0) {
            if (C_NVL(b_ma.value) === "") return;
            var b_loai = $get(b_loaiId).value;
            if (b_loai == '60' || b_loai == '70' || b_loai == '80') {
                $get(form_Fs_VTEN_ID('', 'lblhoten')).innerHTML = "Họ và tên người chết";
                $get(form_Fs_VTEN_ID('', 'lblchuy')).innerHTML = "Tháng hưởng hưu, TCBHXH trước khi chết.Nếu đang công tác nhập tháng năm hưởng chế độ tuất!";
            } else {
                $get(form_Fs_VTEN_ID('', 'lblhoten')).innerHTML = "Họ và tên đối tượng";
                $get(form_Fs_VTEN_ID('', 'lblchuy')).innerHTML = "";
            }
            bhc_hoso_P_LKE_ND();
            bhc_hoso_P_LKE_CVU();
            bhc_hoso_P_LKE_LOAI_CVU();
            bhc_hoso_P_LKE_LOAI_DV();
            bhc_hoso_P_dt_BH();
            bhc_hoso_P_dt_QLBH();
        }
        if (b_maTen.indexOf("NGAYTRCAP") >= 0) {
            if (C_NVL(b_ma.value) === "") return;
            var b_ngay_trcap = $get(b_ngay_trcapId).value;
            var b_thang = b_ngay_trcap.substring(0, 2),
                b_nam = b_ngay_trcap.substring(3, 7);
            if (b_thang > 12 || b_thang < 1 || b_nam < 1900) {
                form_P_LOI('loi:Phải nhập tháng từ 1 -> 12 và năm > 1900!:loi');
                $get(b_ngay_trcapId).value = "";
                $get(b_ngay_trcapId).focus();
                return false;
            }
            var b_loai = $get(b_loaiId).value, // so ho so
                b_ma_nd = $get(b_ma_ndId).value; // ve theo
            if ((b_loai == "10") && (b_ma_nd == "01" || b_ma_nd == "03" || b_ma_nd == "04") && ((b_nam * 12 + parseFloat(b_thang)) >= (1995 * 12 + 10))) {
                form_P_LOI('loi:Những đối tượng về theo nghị định này không thuộc nguồn quỹ!:loi');
                return false;
            }
            if ((b_loai == "10") && (b_ma_nd == "21") && ((b_nam * 12 + parseFloat(b_thang)) < (2003 * 12 + 1))) {
                form_P_LOI('loi:Những đối tượng về theo nghị định 121 phải về sau 01/2003!:loi');
                $get(b_ngay_trcapId).focus();
                return false;
            }
            if ((b_loai == "12") && (b_ma_nd == "01" || b_ma_nd == "03" || b_ma_nd == "04") && ((b_nam * 12 + parseFloat(b_thang)) < (1995 * 12 + 10))) {
                form_P_LOI('loi:Những đối tượng về theo loại hồ sơ này tháng năm hưởng phải thuộc nguồn quỹ!Chọn lại tháng năm hưởng nếu đúng số hồ sơ!Chọn lại số hồ sơ là 10 nếu đúng tháng năm hưởng!:loi');
                $get(b_ngay_trcapId).focus();
                return false;
            }
            if ((b_loai == "20") && (b_ma_nd == "02" || b_ma_nd == "03" || b_ma_nd == "05") && ((b_nam * 12 + parseFloat(b_thang)) >= (1995 * 12 + 10))) {
                form_P_LOI('loi:Những đối tượng về theo nghị định này không thuộc nguồn quỹ.Chọn lại số hồ sơ là 22 nếu năm hưởng đúng hồ sơ!:loi');
                $get(b_ngay_trcapId).focus();
                return false;
            }
            if ((b_loai == "22") && (b_ma_nd == "59" || b_ma_nd == "60") && ((b_nam * 12 + parseFloat(b_thang)) < (2007 * 12 + 1))) {
                form_P_LOI('loi:Nghị định 159 & NĐ11 có hiệu lực từ ngày 01/01/2007. Chọn lại tháng năm hưởng!:loi');
                $get(b_ngay_trcapId).value = "";
                $get(b_ngay_trcapId).focus();
                return false;
            }
            if ((b_loai == "22") && (b_ma_nd == "02" || b_ma_nd == "03" || b_ma_nd == "05") && ((b_nam * 12 + parseFloat(b_thang)) < (1995 * 12 + 10))) {
                form_P_LOI('loi:Những đối tượng về theo loại hồ sơ này tháng năm hưởng phải thuộc nguồn quỹ!Chọn lại tháng năm hưởng nếu đúng số hồ sơ!Chọn lại số hồ sơ là 20 nếu đúng tháng năm hưởng!:loi');
                $get(b_ngay_trcapId).focus();
                return false;
            }
        }
        if (b_maTen.indexOf("TEN") >= 0) {
            var b_ten = $get(b_tenId).value;
            if (b_ten === "") {
                form_P_LOI('loi:Phải nhập tên!:loi');
                $get(b_tenId).focus();
                return false;
            } else {
                $get(b_tenId).value = ten_hoa(b_ten);
                if ($get(b_atmId).value === 'C')
                    $get(b_ten_ctkId).value = $get(b_tenId).value;
            }
        }
    } catch (err) {
        dumpError(err);
    }
}

function bhc_hoso_P_MA(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
        else {
            if (b_kq != "0") {
                var b_so_bhxh = $get(b_so_bhxh_ID).value;
                $get(b_so_bhxh_tk_Id).value = b_so_bhxh;
                bhc_hoso_P_LKE();
                form_P_LOI('loi:Trùng số sổ!:loi');
                return false;
            } else bhc_tk_moi();
        }
    } catch (err) {
        dumpError(err);
    }
}

function bhc_hoso_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        try {
            if (b_maTen_tmp == "MA_NH") {
                var b_ma_nh = $get(b_ma_nh_id).value;
                var b_tenf = b_tmf + "/khma/khma_manh.aspx";
                form_P_MO(b_tenf, null, ["MA_NH", [b_ma_nh]], "");
                return false;
            } else if (b_maTen_tmp == "MA_TP") {
                if (bhc_hoso_choAct !== 0) clearTimeout(bhc_hoso_choAct);
                bhc_hoso_choAct = setTimeout("bhc_check_SANG()", 300);
                return false;
            } else if (b_maTen_tmp == "MA_DVI_KCB") {
                if (bhc_hoso_choAct !== 0) clearTimeout(bhc_hoso_choAct);
                bhc_hoso_choAct = setTimeout("bhc_check_SANG()", 300);
                return false;
            }
        } catch (err) {
            dumpError(err);
        }
    } else {
        form_P_DatGchu(b_gchuId, b_kq);
    }
}

function bhc_check_SANG() {
    var b_ma_tp = $get(b_ma_tpId).value;
    var b_tenf = b_tmf + "/bhc/bhc_ht/bhc_ht_madvkcb.aspx";
    form_P_MO(b_tenf, null, ["MATP", [b_ma_tp]], "");
    return false;
}

function bhc_hoso_P_SOHS(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        if (CSO_SO(b_kq, 0) > 0) {
            $get(b_so_idId).value = b_kq;
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "so_id", b_kq);
            if (b_hang > 0) GridX_datA(b_grlkeId, b_hang);
            bhc_hoso_P_CHUYEN_HANG(b_kq);
        }
    }
}
//Nhap
function bhc_hoso_P_CT_MOI(b_dk) {
    form_P_MOI(b_vungId, b_dk);
    $get(b_so_idId).value = "0";
}

function bhc_hoso_P_MOI() {
    try {
        bhc_hoso_P_CT_MOI("XGL");
        GridX_thoiA(b_grlkeId);
        bhc_tk_moi();
        $get(form_Fs_VTEN_ID('UPa_ct', 'SO_QD')).focus();
        return false;
    } catch (err) {
        dumpError(err);
    }
}

function bhc_hoso_P_NH() {
    var loi = bhc_hoso_P_NH_CHECK();
    if (loi != false) {
        try {
            var b_loi = form_Fs_TEXT_KTRA(b_vungId);
            if (b_loi !== "") form_P_LOI(b_loi);
            else {
                var b_so_id = O_NVL($get(b_so_idId).value, "0"),
                    b_dt = form_Faa_TEXT_ROW(b_vungId);
                var b_lan_dc = O_NVL($get(b_lan_dcId).value, "0");
                sbhc_hoso.Fs_HOSO_NH(b_so_id, b_lan_dc, b_dt, bhc_hoso_P_NH_KQ, P_LOI_CSDL_2, P_LOI_TGIAN);
            }
            return false;
        } catch (err) {
            dumpError(err);
        }
    } else return false;
}

function bhc_hoso_P_NH_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
        else {
            form_P_LOI('loi:Nhập thành công!:loi');
            if (b_tg == 'C') {
                var arr = b_kq.split("#");
                $get(b_so_idId).value = arr[0];
                $get(b_lan_dcId).value = arr[1];
                $get(b_so_hieu_hs_id).value = form_Fs_VTEN_GTRI('', 'loai');
                bhc_tk_moi();
                $get(b_so_bhxh_tk_Id).value = $get(form_Fs_TEN_ID('UPa_ct', 'so_bhxh')).value;
                bhc_hoso_P_LKE_ID($get(b_so_idId).value);
            }
        }
        form_P_DAY(window.name, "bhc_tkdc", "RELOAD", ['1']);
    } catch (err) {
        dumpError(err);
    }
}

function bhc_hoso_P_NH_CHECK() {
    try {
        var tru_quan = $get(form_Fs_VTEN_ID('UPa_ct', 'tru_quan'));
        var huyen = $get(form_Fs_VTEN_ID('UPa_ct', 'ma_huyen'));
        var xa = $get(form_Fs_VTEN_ID('UPa_ct', 'ma_xa'));
        var b_loai = $get(b_loaiId).value,
            b_ma_nd = $get(b_ma_ndId).value;
        var b_ngay_trcap = $get(b_ngay_trcapId).value;
        var b_thang = b_ngay_trcap.substring(0, 2),
            b_nam = b_ngay_trcap.substring(3, 7);
        var b_ma_huyen = $get(b_ma_huyenId).value,
            b_ma_xa = $get(b_ma_xaId).value,
            b_nguon = $get(b_nguonId).value;
        var b_so_bhxh = $get(b_so_bhxh_ID).value;
        var b_ten = $get(b_tenId).value;
        var b_ngay_sinh = $get(b_ngay_sinhId).value;
        var b_ngay_trcap = $get(b_ngay_trcapId).value;
        if (b_ten === "") {
            form_P_LOI('loi:Phải nhập tên!:loi');
            $get(b_tenId).focus();
            return false;
        }
        if (b_ngay_sinh === "") {
            form_P_LOI('loi:Không để trống ngày sinh!:loi');
            $get(b_ngay_sinhId).focus();
            return false;
        }
        if (b_ngay_trcap === "") {
            form_P_LOI('loi:Không để trống ngày hưởng trợ cấp!:loi');
            $get(b_ngay_trcapId).focus();
            return false;
        }
        if (b_so_bhxh === "") {
            form_P_LOI('loi:Không để trống số sổ!:loi');
            $get(b_so_bhxh_ID).focus();
            return false;
        }
        if (C_NVL(tru_quan.value) === '') {
            var huyen_text = huyen.options[huyen.selectedIndex].text;
            var xa_text;
            if (huyen_text == "") {
                huyen_text = "";
                xa_text = "";
            } else xa_text = xa.options[xa.selectedIndex].text;
            var xa_index = xa_text.indexOf(' ');
            var huyen_index = huyen_text.indexOf(' ');
            tru_quan.value = xa_text.substring(xa_index, xa_text.lenght) + ', ' + huyen_text.substring(huyen_index, huyen_text.lenght);
        }
        if ((b_ma_nd == "59" || b_ma_nd == "60") && (b_loai != "22")) {
            form_P_LOI('loi:Đối tượng về theo NĐ159 & NĐ11 phải chọn số hồ sơ 22!:loi');
            $get(b_loaiId).focus();
            return false;
        }
        if (b_loai != "60" && b_loai != "70" && b_loai != "80" && (b_ma_nd == "52" || b_ma_nd == "68") && ((b_nam * 12 + parseFloat(b_thang)) < (2007 * 12 + 1))) {
            form_P_LOI('loi:Đối tượng về theo luật phải hưởng sau 01/2007!:loi');
            $get(b_ngay_trcapId).value = "";
            $get(b_ngay_trcapId).focus();
            return false;
        }
        if (b_loai == "92" && ((b_nam * 12 + parseFloat(b_thang)) < (2010 * 12 + 5))) {
            form_P_LOI('loi:Đối tượng về theo QĐ 613 phải hưởng từ 05/2010!:loi');
            $get(b_ngay_trcapId).value = "";
            $get(b_ngay_trcapId).focus();
            return false;
        }
        //if (b_ma_huyen === "" || b_ma_huyen == "") { form_P_LOI('loi:Phải chọn đại lý cấp 1!:loi'); $get(b_ma_huyenId).focus(); return false; }
        //if (b_ma_xa === "" || b_ma_xa == "") { form_P_LOI('loi:Phải chọn đại lý cấp 2!:loi'); $get(b_ma_xaId).focus(); return false; }
        // if (b_nguon === "") { form_P_LOI('loi:Phải chọn Nguồn chi trả!:loi'); $get(b_nguonId).focus(); return false; }
        var b_loai = $get(b_loaiId).value, // so ho so
            b_ma_nd = $get(b_ma_ndId).value; // ve theo
        if ((b_loai == "10") && (b_ma_nd == "01" || b_ma_nd == "03" || b_ma_nd == "04") && ((b_nam * 12 + parseFloat(b_thang)) >= (1995 * 12 + 10))) {
            form_P_LOI('loi:Những đối tượng về theo nghị định này không thuộc nguồn quỹ!:loi');
            $get(b_ngay_trcapId).focus();
            return false;
        }
        if ((b_loai == "10") && (b_ma_nd == "21") && ((b_nam * 12 + parseFloat(b_thang)) < (2003 * 12 + 1))) {
            form_P_LOI('loi:Những đối tượng về theo nghị định 121 phải về sau 01/2003!:loi');
            $get(b_ngay_trcapId).focus();
            return false;
        }
        if ((b_loai == "12") && (b_ma_nd == "01" || b_ma_nd == "03" || b_ma_nd == "04") && ((b_nam * 12 + parseFloat(b_thang)) < (1995 * 12 + 10))) {
            form_P_LOI('loi:Những đối tượng về theo loại hồ sơ này tháng năm hưởng phải thuộc nguồn quỹ!Chọn lại tháng năm hưởng nếu đúng số hồ sơ!Chọn lại số hồ sơ là 10 nếu đúng tháng năm hưởng!:loi');
            $get(b_ngay_trcapId).focus();
            return false;
        }
        if ((b_loai == "20") && (b_ma_nd == "02" || b_ma_nd == "03" || b_ma_nd == "05") && ((b_nam * 12 + parseFloat(b_thang)) >= (1995 * 12 + 10))) {
            form_P_LOI('loi:Những đối tượng về theo nghị định này không thuộc nguồn quỹ.Chọn lại số hồ sơ là 22 nếu năm hưởng đúng hồ sơ!:loi');
            $get(b_ngay_trcapId).focus();
            return false;
        }
        if ((b_loai == "22") && (b_ma_nd == "59" || b_ma_nd == "60") && ((b_nam * 12 + parseFloat(b_thang)) < (2007 * 12 + 1))) {
            form_P_LOI('loi:Nghị định 159 & NĐ11 có hiệu lực từ ngày 01/01/2007. Chọn lại tháng năm hưởng!:loi');
            $get(b_ngay_trcapId).focus();
            return false;
        }
        if ((b_loai == "22") && (b_ma_nd == "02" || b_ma_nd == "03" || b_ma_nd == "05") && ((b_nam * 12 + parseFloat(b_thang)) < (1995 * 12 + 10))) {
            form_P_LOI('loi:Những đối tượng về theo loại hồ sơ này tháng năm hưởng phải thuộc nguồn quỹ!Chọn lại tháng năm hưởng nếu đúng số hồ sơ!Chọn lại số hồ sơ là 20 nếu đúng tháng năm hưởng!:loi');
            $get(b_ngay_trcapId).focus();
            return false;
        }
        return true;
    } catch (err) {
        dumpError(err);
    }
}

function bhc_tk_moi() {
    $get(b_timId).value = "";
    $get(b_so_bhxh_tk_Id).value = "";
    $get(form_Fs_VTEN_ID('UPa_tk', 'thang_nhap')).value = '';
}

function bhc_hoso_P_LKE_ID(b_so_id) {
    try {
        var b_so_bhxh_tk = $get(b_so_bhxh_tk_Id).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId),
            b_hangKt = GridX_Fi_hangKt(b_grlkeId);
        var b_thang_nhap = O_NVL($get(b_thang_nhap_Id).value, "0");
        var b_tim = $get(form_Fs_VTEN_ID('UPa_tk', 'tim')).value;
        var b_sohieu = $get(form_Fs_VTEN_ID('UPa_tk', 'sohieu_hs')).value;
        sbhc_hoso.Fs_HOSO_LKE_ID(b_so_id, b_so_bhxh_tk, b_thang_nhap, b_tim, b_sohieu, b_hangKt, a_cot, bhc_hoso_P_LKE_ID_KQ, P_LOI_CSDL_2, P_LOI_TGIAN);
    } catch (err) {
        dumpError(err);
    }
}

function bhc_hoso_P_LKE_ID_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) {
            form_P_LOI(b_kq);
            return;
        }
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]),
            b_trang = CSO_SO(a_kq[1]),
            b_soDong = CSO_SO(a_kq[2]);
        GridX_datBang(b_grlkeId, a_kq[3]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        if (b_hang > 0) GridX_datA(b_grlkeId, b_hang);
        form_Fctr_VTEN_DTUONG('', 'moi').focus();
    } catch (err) {
        dumpError(err);
    }
}

function bhc_hoso_P_XOA() {
    try {
        var b_so_id = O_NVL($get(b_so_idId).value, "0");
        if (b_so_id == "0") bhc_hoso_P_MOI();
        else {
            var a_cot = GridX_Fas_tenCot(b_grlkeId),
                a_tso = slide_Faobj_TUDEN(b_slideId);
            var b_tim = $get(form_Fs_VTEN_ID('UPa_tk', 'tim')).value;
            var b_sohieu = $get(form_Fs_VTEN_ID('UPa_tk', 'sohieu_hs')).value;
            var b_thang_nhap = O_NVL($get(b_thang_nhap_Id).value, "0");
            var b_lan_dc = $get(b_lan_dcId).value;
            sbhc_hoso.Fs_HOSO_XOA(b_so_id, b_lan_dc, b_thang_nhap, b_sohieu, b_tim, a_cot, a_tso, bhc_hoso_P_XOA_KQ, P_LOI_CSDL_2, P_LOI_TGIAN);
        }
        return false;
    } catch (err) {
        dumpError(err);
    }
}

function bhc_hoso_P_XOA_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) {
            form_P_LOI(b_kq);
            return;
        }
        var a_kq = Fas_ChMang(b_kq, '#'),
            b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang == 1 && GridX_Fb_hangTrang(b_grlkeId, 2)) b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
        if (b_hang > 1 && GridX_Fb_hangTrang(b_grlkeId, b_hang)) b_hang--;
        if (b_hang < 1 || GridX_Fb_hangTrang(b_grlkeId, b_hang)) bhc_hoso_P_MOI();
        else {
            GridX_datA(b_grlkeId, b_hang);
            bhc_hoso_P_CHUYEN_HANG();
        }
        bhc_tk_moi();
    } catch (err) {
        dumpError(err);
    }
}

function bhc_hoso_P_SANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1 && b_mode == undefined) return false;
        var b_so_id = O_NVL($get(b_so_idId).value, "0");
        var b_tenf = '';
        var b_so_hieu_hs = $get(b_so_hieu_hs_id).value;
        var b_thang_huong = $get(form_Fs_VTEN_ID('UPa_ct', 'NGAY_TRCAP')).value;
        var b_nd = $get(form_Fs_VTEN_ID('UPa_ct', 'ma_nd')).value;
        var b_gtinh = $get(form_Fs_VTEN_ID('UPa_ct', 'GIOI_TINH')).value;
        var b_ngaysinh = $get(form_Fs_VTEN_ID('UPa_ct', 'NGAY_SINH')).value;
        var b_ma_loai_dvi = $get(form_Fs_TEN_ID('UPa_ct', 'ma_loai_dvi')).value;
        var b_loai = $get(form_Fs_TEN_ID('UPa_ct', 'loai')).value;
        var b_luong_cb = (b_hang < 1) ? $get(form_Fs_TEN_ID('UPa_ct', 'lcb')).value : O_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "lcb"))
        //var b_luong_cb = $get(form_Fs_TEN_ID('UPa_ct', 'lcb')).value;
        switch (b_so_hieu_hs) {
            case "10":
                b_tenf = b_tmf + "/bhc/bhc_huu/bhc_huu_hs.aspx";
                break;
            case "12":
                b_tenf = b_tmf + "/bhc/bhc_huu/bhc_huu_hs.aspx";
                break;
            case "13":
                b_tenf = b_tmf + "/bhc/bhc_huu/bhc_huu_hs.aspx";
                break;
            case "20":
                b_tenf = b_tmf + "/bhc/bhc_huu/bhc_huu_hs.aspx";
                break;
            case "22":
                b_tenf = b_tmf + "/bhc/bhc_huu/bhc_huu_hs.aspx";
                break;
            case "30":
                b_tenf = b_tmf + "/bhc/bhc_msld/bhc_msld_hs.aspx";
                break;
            case "40":
                b_tenf = b_tmf + "/bhc/bhc_tn/bhc_tn_hs.aspx";
                break;
            case "45":
                b_tenf = b_tmf + "/bhc/bhc_cncs/bhc_cncs_hs.aspx";
                break;
            case "50":
                b_tenf = b_tmf + "/bhc/bhc_tn/bhc_tn_hs.aspx";
                break;
            case "60":
                b_tenf = b_tmf + "/bhc/bhc_tuat/bhc_tuat_hs.aspx";
                break;
            case "70":
                b_tenf = b_tmf + "/bhc/bhc_tuat/bhc_tuat_hs.aspx";
                break;
            case "80":
                b_tenf = b_tmf + "/bhc/bhc_tuat/bhc_tuat_hs.aspx";
                break;
            case "90":
                b_tenf = b_tmf + "/bhc/bhc_cbxp/bhc_cbxp_hs.aspx";
                break;
            case "91":
                b_tenf = b_tmf + "/bhc/bhc_qd/bhc_qd_hs.aspx";
                break;
            case "92":
                b_tenf = b_tmf + "/bhc/bhc_qd/bhc_qd_hs.aspx";
                break;
            default:
                b_tenf = '';
        }
        if (b_so_id != "0") form_P_MO(b_tenf, null, ["SO_ID", [b_so_id, $get(b_lan_dcId).value, b_mode, b_thang_huong, b_nd, b_ngaysinh, b_gtinh, b_ma_loai_dvi, b_loai, b_luong_cb]], "");
        return false;
    } catch (err) {
        form_P_LOI(err);
    }
}

function bhc_hoso_P_TIM() {
    form_P_MO(b_tmf + '/bhc/bhc_hoso/bhc_hosotim.aspx', null, null);
    return false;
}

function bhc_hoso_GR_lke_RowChange() {
    try {
        if (bhc_hoso_choAct !== 0) clearTimeout(bhc_hoso_choAct);
        bhc_hoso_choAct = setTimeout("bhc_hoso_P_CHUYEN_HANG()", 300);
        return false;
    } catch (err) {
        dumpError(err);
    }
}

function bhc_hoso_P_CHUYEN_HANG(b_so_id) {
    try {
        var b_lan_dc = $get(b_lan_dcId).value;
        if (O_NVL(b_so_id, "0") == "0") {
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            var b_so_id = (b_hang < 1) ? O_NVL($get(b_so_idId).value) : O_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
            b_lan_dc = (b_hang < 1) ? O_NVL($get(b_lan_dcId).value) : O_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "lan_dc"));
        }
        if (b_so_id == "0" || b_so_id == null) bhc_hoso_P_CT_MOI("XGL");
        else sbhc_hoso.Fs_HOSO_CT(b_so_id, b_lan_dc, bhc_hoso_P_CHUYEN_HANG_KQ, P_LOI_CSDL_2, P_LOI_TGIAN);
    } catch (err) {
        dumpError(err);
    }
}
var b_tmp2;

function bhc_hoso_P_CHUYEN_HANG_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
        else if (b_kq === "") bhc_hoso_P_CT_MOI("XGL");
        else {
            b_tmp = b_kq;
            b_tmp2 = b_kq;
            b_tmp3 = b_kq;
            b_tmp4 = b_kq;
            b_tmp5 = b_kq;
            var a_kq = Fas_ChMang(b_kq, '#');
            form_P_CH_TEXT(b_vungId, a_kq[1]);
            $get(b_so_idId).value = a_kq[0];
            $get(b_so_hieu_hs_id).value = form_Fs_VTEN_GTRI('', 'loai');
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang > 0 && b_tg == 'C')
                $get(b_lan_dcId).value = bhc_hoso_P_lay_gtr_grid_A('lan_dc');
            //  bhc_hoso_P_LKE_XA();
            bhc_hoso_P_LKE_DL_C2();
            bhc_hoso_P_LKE_CVU();
            bhc_hoso_P_LKE_LOAI_DV();
            bhc_hoso_P_LKE_LOAI_CVU();
            bhc_hoso_P_LKE_NH();
        }
        bhc_hoso_P_LKE_ND();
        var b_loai = $get(b_loaiId).value;
        if (b_loai == '60' || b_loai == '70' || b_loai == '80') {
            $get(form_Fs_VTEN_ID('', 'lblhoten')).innerHTML = "Họ tên người chết";
            $get(form_Fs_VTEN_ID('', 'lblchuy')).innerHTML = "Chú ý: Nhập tháng năm hưởng hưu, TCBHXH trước khi chết.Nếu đang công tác nhập tháng năm hưởng chế độ tuất!";
        } else {
            $get(form_Fs_VTEN_ID('', 'lblhoten')).innerHTML = "Họ tên đối tượng";
            $get(form_Fs_VTEN_ID('', 'lblchuy')).innerHTML = "";
        }
    } catch (err) {
        dumpError(err);
    }
}

function bhc_hoso_P_lay_gtr_grid_A(b_truong) {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        return O_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, b_truong));
    } catch (err) {
        dumpError(err);
    }
}

function bhc_hoso_P_LKE_ND() {
    try {
        var b_chedo = $get(form_Fs_VTEN_ID('UPa_ct', 'loai')).value;
        sbhc_ht_ma.Fs_MA_ND_LKE_2(b_chedo, bhc_hoso_P_LKE_ND_KQ, P_LOI_CSDL_2, P_LOI_TGIAN);
    } catch (err) {
        dumpError(err);
    }
}

function bhc_hoso_P_dt_BH() {
    try {
        var b_loai = $get(b_loaiId).value;
        if (["10", "12", "13", "20", "22", "30"].indexOf(b_loai) >= 0)
            drop_set_selected($get(b_ma_loai_dt_kcbId), 'HT');
        else if (["40", "50"].indexOf(b_loai) >= 0)
            drop_set_selected($get(b_ma_loai_dt_kcbId), 'TB');
        else if (["90"].indexOf(b_loai) >= 0)
            drop_set_selected($get(b_ma_loai_dt_kcbId), 'XB');
        else if (["91", "92"].indexOf(b_loai) >= 0)
            drop_set_selected($get(b_ma_loai_dt_kcbId), 'MS');
        else
            drop_set_selected($get(b_ma_loai_dt_kcbId), '');
    } catch (err) {
        dumpError(err);
    }
}

function bhc_hoso_P_dt_QLBH() {
    try {
        var b_loai = $get(b_loaiId).value;
        if (["10", "12", "13", "20", "22", "30"].indexOf(b_loai) >= 0)
            drop_set_selected($get(b_ma_loai_qlId), '005');
        else
            drop_set_selected($get(b_ma_loai_qlId), '007');
    } catch (err) {
        dumpError(err);
    }
}

function bhc_hoso_P_LKE_ND_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
        else {
            drop_P_LKE(form_Fs_VTEN_ID('UPa_ct', 'ma_nd'), b_kq);
            if (b_tmp2 !== "") {
                var a_kq = Fas_ChMang(b_tmp2, '#');
                form_P_CH_TEXT(b_vungId, a_kq[1]);
                b_tmp2 = '';
            }
        }
    } catch (err) {
        dumpError(err);
    }
}
var b_tmp3;

function bhc_hoso_P_LKE_CVU() {
    try {
        var b_chedo = $get(form_Fs_VTEN_ID('UPa_ct', 'loai')).value;
        sbhc_ht_ma.Fs_MA_CVU_LKE2(b_chedo, bhc_hoso_P_LKE_CVU_KQ, P_LOI_CSDL_2, P_LOI_TGIAN);
    } catch (err) {
        dumpError(err);
    }
}

function bhc_hoso_P_LKE_CVU_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
        else {
            drop_P_LKE(form_Fs_VTEN_ID('UPa_ct', 'ma_cvu'), b_kq);
            if (b_tmp3 !== "") {
                var a_kq = Fas_ChMang(b_tmp3, '#');
                form_P_CH_TEXT(b_vungId, a_kq[1]);
                b_tmp3 = '';
            }
        }
    } catch (err) {
        dumpError(err);
    }
}
var b_tmp4;

function bhc_hoso_P_LKE_LOAI_CVU() {
    try {
        var b_chedo = $get(form_Fs_VTEN_ID('UPa_ct', 'loai')).value;
        var b_ma_cvu = $get(form_Fs_VTEN_ID('UPa_ct', 'ma_cvu')).value;
        sbhc_ht_ma.Fs_MA_CVU_LOAI_LKE2(b_chedo, b_ma_cvu, bhc_hoso_P_LKE_LOAI_CVU_KQ, P_LOI_CSDL_2, P_LOI_TGIAN);
    } catch (err) {
        dumpError(err);
    }
}

function bhc_hoso_P_LKE_LOAI_CVU_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
        else {
            drop_P_LKE(form_Fs_VTEN_ID('UPa_ct', 'ma_loai_cvu'), b_kq);
            if (b_tmp4 !== "") {
                var a_kq = Fas_ChMang(b_tmp4, '#');
                form_P_CH_TEXT(b_vungId, a_kq[1]);
                b_tmp4 = '';
            }
        }
    } catch (err) {
        dumpError(err);
    }
}
var b_tmp5;

function bhc_hoso_P_LKE_LOAI_DV() {
    try {
        var b_chedo = $get(form_Fs_VTEN_ID('UPa_ct', 'loai')).value;
        sbhc_ht_ma.Fs_MA_LOAI_DVI_LKE(b_chedo, bhc_hoso_P_LKE_LOAI_DV_KQ, P_LOI_CSDL_2, P_LOI_TGIAN);
    } catch (err) {
        dumpError(err);
    }
}

function bhc_hoso_P_LKE_LOAI_DV_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
        else {
            drop_P_LKE(form_Fs_VTEN_ID('UPa_ct', 'ma_loai_dvi'), b_kq);
            if (b_tmp5 !== "") {
                var a_kq = Fas_ChMang(b_tmp5, '#');
                form_P_CH_TEXT(b_vungId, a_kq[1]);
                b_tmp5 = '';
            }
        }
    } catch (err) {
        dumpError(err);
    }
}

function bhc_hoso_P_CT_CHO() {
    if (b_grlkeId !== null && $get(b_grlkeId) !== null) {
        if (GridX_Fi_hangKt(b_grlkeId) > 0) {
            try {
                clearTimeout(b_ct_cho);
                var b_so_id = O_NVL(b_temp_id, "0");
                var b_hang = (b_so_id != "0") ? GridX_Fi_timHangD(b_grlkeId, "so_id", b_so_id) : 0;
                if (b_hang < 1) GridX_thoiA(b_grlkeId);
                else {
                    GridX_datA(b_grlkeId, b_hang);
                }
                bhc_hoso_P_CHUYEN_HANG(b_so_id);
            } catch (err) {
                dumpError(err);
            }
        }
    }
}

function bhc_hoso_P_LKE() {
    try {
        var b_so_bhxh_tk = O_NVL($get(b_so_bhxh_tk_Id).value, "0");
        var b_sohieu = $get(form_Fs_VTEN_ID('UPa_tk', 'sohieu_hs')).value;
        var b_thang_dc = $get(b_thang_nhap_Id).value,
            b_tim = C_NVL($get(b_timId).value),
            a_cot = GridX_Fas_tenCot(b_grlkeId),
            a_tso = slide_Faobj_TUDEN(b_slideId);
        sbhc_hoso.Fs_HOSO_LKE(b_thang_dc, b_so_bhxh_tk, b_sohieu, b_tim, a_cot, a_tso, bhc_hoso_P_LKE_KQ, P_LOI_CSDL_2, P_LOI_TGIAN);
    } catch (err) {
        dumpError(err);
    }
}

function bhc_hoso_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        return false;
    }
    var b_so_id = O_NVL($get(b_so_idId).value, "0"),
        a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    return false;
}

function bhc_hoso_P_LKE_DLY() {
    try {
        var b_ma_huyen = $get(form_Fs_VTEN_ID('UPa_ct', 'ma_xa')).value;
        sbhc_ht_ma.Fs_MA_DLY_LK(b_ma_huyen, "K", bhc_hoso_P_LKE_DLY_KQ, P_LOI_CSDL_2, P_LOI_TGIAN);
    } catch (err) {
        form_P_LOI(err);
    }
}

function bhc_hoso_P_LKE_NH() {
    try {
        var b_atm = $get(b_atmId).value;
        if (b_atm == "K") {
            P_Disable(b_stkId);
            P_Disable(b_ma_nh_id);
            P_Disable(b_ten_ctkId);
            $get(b_stkId).value = "";
            $get(b_ma_nh_id).value = "";
            $get(b_ten_ctkId).value = "";
        } else {
            P_Enable(b_stkId);
            P_Enable(b_ma_nh_id);
            P_Enable(b_ten_ctkId);
        }
    } catch (err) {
        form_P_LOI(err);
    }
}

function bhc_hoso_P_LKE_DLY_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
        else {
            drop_P_LKE(form_Fs_VTEN_ID('UPa_ct', 'ma_dly'), b_kq);
            if (C_NVL(b_tmp) != '') {
                var a_kq = Fas_ChMang(b_tmp, '#');
                form_P_CH_TEXT(b_vungId, a_kq[1]);
                b_tmp = "";
            } else {
                var tru_quan = $get(form_Fs_VTEN_ID('UPa_ct', 'tru_quan'));
                var huyen = $get(form_Fs_VTEN_ID('UPa_ct', 'ma_huyen'));
                var xa = $get(form_Fs_VTEN_ID('UPa_ct', 'ma_xa'));
                var xa_text = xa.options[xa.selectedIndex].text;
                var xa_index = xa_text.indexOf(' ');
                var huyen_text = huyen.options[huyen.selectedIndex].text;
                var huyen_index = huyen_text.indexOf(' ');
                tru_quan.value = xa_text.substring(xa_index, xa_text.lenght) + ', ' + huyen_text.substring(huyen_index, huyen_text.lenght);
            }
        }
    } catch (err) { }
}

function bhc_hoso_dieuchinh_P_SUA() {
    try {
        var b_sohs = "1";
        var b_hs_id = $get(b_so_idId).value;
        if (b_hs_id <= 0) {
            form_P_LOI('loi:Chưa chọn sổ:loi');
            return false;
        }
        b_tenf = b_tmf + "/bhc/bhc_tg/bhc_tkdc.aspx";
        var now = new Date();
        if (b_sohs !== null || b_sohs != "0") {
            form_P_MO(b_tenf, null, ["SUA", [b_sohs, b_hs_id, (now.getMonth() + 1).toString().lpad('0', 2) + "/" + now.getFullYear()]], "");
        }
        return false;
    } catch (err) {
        form_P_LOI(err);
    }
}

function ten_hoa(b_input) {
    newVal = '';
    b_input = b_input.split(' ');
    for (var c = 0; c < b_input.length; c++) {
        newVal += b_input[c].substring(0, 1).toUpperCase() + b_input[c].substring(1, b_input[c].length) + ' ';
    }
    return newVal;
}

function bhc_hoso_VT() {
    try {
        var b_sohs = "1";
        var b_hs_id = $get(b_so_idId).value;
        if (b_hs_id <= 0) {
            form_P_LOI('loi:Chưa chọn sổ:loi');
            return false;
        }
        b_tenf = b_tmf + "/bhc/bhc_hoso/bhc_hoso_vt.aspx";
        var now = new Date();
        if (b_sohs !== null || b_sohs != "0") {
            form_P_MO(b_tenf, null, ["SO_ID", [b_hs_id]], "");
        }
        return false;
    } catch (err) {
        form_P_LOI(err);
    }
}

function bhc_hoso_P_LKE_DL_C1() {
    try {
        sbhc_ht_ma.Fs_DLY_LK("", $get(b_atmId).value, bhc_hoso_P_LKE_DL_C1_KQ, P_LOI_CSDL_2, P_LOI_TGIAN);
        bhc_hoso_P_KHOI_TAO_DROP(b_daily_cap_2Id);
        bhc_hoso_P_KHOI_TAO_DROP(b_daily_cap_3Id);
    } catch (err) {
        form_P_LOI(err);
    }
}

function bhc_hoso_P_LKE_DL_C1_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
        else {
            b_kq = (C_NVL(b_kq) == "") ? '|' : '|;' + b_kq;
            drop_P_LKE(b_daily_cap_1Id, b_kq);
        }
    } catch (err) { }
}

function bhc_hoso_P_LKE_DL_C2() {
    try {
        if (C_NVL($get(b_daily_cap_1Id).value) != '')
            sbhc_ht_ma.Fs_DLY_LK($get(b_daily_cap_1Id).value, $get(b_atmId).value, bhc_hoso_P_LKE_DL_C2_KQ, P_LOI_CSDL_2, P_LOI_TGIAN);
        bhc_hoso_P_KHOI_TAO_DROP(b_daily_cap_2Id);
        bhc_hoso_P_KHOI_TAO_DROP(b_daily_cap_3Id);
    } catch (err) {
        form_P_LOI(err);
    }
}

function bhc_hoso_P_LKE_DL_C2_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
        else {
            b_kq = (C_NVL(b_kq) == "") ? '|' : '|;' + b_kq;
            drop_P_LKE(b_daily_cap_2Id, b_kq);
            if (b_tmp !== "") {
                var a_kq = Fas_ChMang(b_tmp, '#');
                form_P_CH_TEXT(b_vungId, a_kq[1]);
                bhc_hoso_P_LKE_DL_C3();
            }
        }
    } catch (err) { }
}

function bhc_hoso_P_LKE_DL_C3() {
    try {
        if (C_NVL($get(b_daily_cap_2Id).value) != '')
            sbhc_ht_ma.Fs_DLY_LK($get(b_daily_cap_2Id).value, $get(b_atmId).value, bhc_hoso_P_LKE_DL_C3_KQ, P_LOI_CSDL_2, P_LOI_TGIAN);
        bhc_hoso_P_KHOI_TAO_DROP(b_daily_cap_3Id);
    } catch (err) {
        form_P_LOI(err);
    }
}

function bhc_hoso_P_LKE_DL_C3_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
        else {
            b_kq = (C_NVL(b_kq) == "") ? '|' : '|;' + b_kq;
            drop_P_LKE(b_daily_cap_3Id, b_kq);
            if (C_NVL(b_tmp) != '') {
                var a_kq = Fas_ChMang(b_tmp, '#');
                form_P_CH_TEXT(b_vungId, a_kq[1]);
                b_tmp = "";
            } else {
                sbhc_ht_ma.Fs_TEN_TR_QUAN($get(b_daily_cap_2Id).value, bhc_hoso_P_TRUQUAN_KQ, P_LOI_CSDL_2, P_LOI_TGIAN);
            }
        }
    } catch (err) { }
}

function bhc_hoso_P_TRUQUAN_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
        else {
            if (C_NVL(b_tmp) != '') {
                var a_kq = Fas_ChMang(b_tmp, '#');
                form_P_CH_TEXT(b_vungId, a_kq[1]);
                b_tmp = "";
            } else {
                var tru_quan = $get(form_Fs_VTEN_ID('UPa_ct', 'tru_quan'));
                tru_quan.value = b_kq;
            }
        }
    } catch (err) { }
}

function bhc_hoso_P_KHOI_TAO_DROP(b_id_control) {
    try {
        drop_P_LKE(b_id_control, '|');
    } catch (err) {
        dumpError(err);
    }
}