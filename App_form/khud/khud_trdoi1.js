var b_tmf, b_choLke = 0, b_cND = 0, b_cFI = 0, b_cGUI = 0, b_nsd, b_tdoL = '', b_tdoF, b_td_nen,
    b_fmo = true, b_lke_nd = true, b_Lke_fi = true, b_dndId, b_choAct = 0, b_grfiId,
    b_ndId, b_nenId, b_ndfiId, b_mdoId, b_bdoId, b_so_id = 0, b_ma_dvi = '', b_nd_c = 0, b_fi_c = 0, b_deg = 0, a_cotFi,
    b_tl = 0, b_dich = 0, b_chuyen = 0, b_td_anhDK, b_td_anhM, b_phimId, b_tiengId, b_tranh, b_can,
    a_g = [], a_ten = [], a_mr = [], a_tdo = [], a_kieuF = [], a_sImg = [],
    b_chG = -1, b_mrF = '', b_kieuF = 'K', b_cho_ch = 0, b_chV = 0, b_chB = -1, b_chN = 128000, b_fileId;
var b_nenM = 'K', b_choNen = 0, b_choImg = 0, b_imgL, b_hangL = 0, b_imgU = 'K', b_lkeId, b_choTdo = 0, b_imgLf, b_choImgf = 0;

var b_cNEN = 0, b_nenD = -1, a_fN = [], a_gN = [], a_mrN = [], a_tenN = [], a_tdoN = [], a_kieuFN = [], a_sImgN = [];

function khud_trdoi_KD(fileId, phimId, tiengId, td_nen) {
    b_fileId = fileId; b_phimId = phimId; b_tiengId = tiengId; b_td_nen = td_nen;
}
function P_KET_QUA(b_dtuong, a_tso) {
    if (b_dtuong == 'TSO') {
        b_ma_dvi = C_NVL(a_tso[0]); b_so_id = a_tso[1];
        b_choLke = setInterval('khud_trdoi_CHO()', 300);
    }
}
function P_DONG() {
    b_fmo = false;
    clearTimeout(b_cND); clearTimeout(b_cFI); clearTimeout(b_cGUI); clearTimeout(b_cNEN);
}
function khud_trdoi_CHO() {
    try {
        if (document.readyState === 'complete') {
            clearTimeout(b_choLke);
            b_tmf = form_Fs_TM('f'); b_nsd = form_Fs_nsd();
            b_dndId = form_Fs_VUNG_ID('div_nd'); b_lkeId = form_Fs_VUNG_ID('div_lke');
            b_bdoId = form_Fs_VUNG_ID('bdo'); b_ndId = form_Fs_TEN_ID('', 'nd'); b_nenId = form_Fs_TEN_ID('', 'nen');
            b_td_anhDK = form_Fs_VUNG_ID('td_anhDK'); b_td_anhM = form_Fs_VUNG_ID('td_anhM');
            b_ndfiId = form_Fs_TEN_ID('', 'nd_fi');
            b_grfiId = form_Fs_VUNG_ID('GR_fi'); b_mdoId = form_Fs_VUNG_ID('td_mdo');
            b_can = img_Fimg('canvas', 640, 360);
            form_Fctr_TENVUNG('UPa_anh').appendChild(b_can);
            b_tranh = new Image();
            b_tranh.onload = function () { khud_trdoi_anhA(); };
            a_cotFi = GridX_Fas_tenCot(b_grfiId);
            if (form_br.match('CHROM')) $get(b_lkeId).style.height = '618px';
            b_cND = setInterval('khud_trdoi_ND_LKE()', 500);
            b_cFI = setInterval('khud_trdoi_FI_LKE()', 500);
            b_cGUI = setInterval('khud_trdoi_GUI()', 500);
            b_cNEN = setInterval('khud_trdoi_NEN()', 500);
            var b_sys = form_Fs_SYS();
            if ('IA'.indexOf(b_sys) >= 0) b_choTdo = setInterval('khud_trdoi_ToaDo()', 500);
            if (C_NVL(b_ma_dvi) == '') skhud.Fs_MA_DVI(b_nsd, khud_trdoi_MA_DVI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (ex) { form_P_LOI('Trình duyệt không hỗ trợ ảnh. Xin dùng từ IE9 hoặc FireFox, Chrome'); }
}
function khud_trdoi_MA_DVI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else b_ma_dvi = b_kq;
}
function khud_trdoi_ND_NH() {
    try {
        var b_nd = C_NVL($get(b_ndId).value);
        if (b_nd != '') skhud.Fs_TRDOI_NH(b_nsd, b_ma_dvi, b_so_id, b_nd, khud_trdoi_ND_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function khud_trdoi_ND_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_nd = $get(b_ndId);
        b_nd.value = ''; b_nd.focus();
    }
}
function khud_trdoi_ND_LKE() {
    try {
        if (b_fmo && b_lke_nd && b_ma_dvi != '' && b_so_id != 0) {
            b_lke_nd = false;
            skhud.Fs_TRDOI_LKE(b_nsd, b_ma_dvi, b_so_id, b_nd_c, khud_trdoi_ND_LKE_KQ, khud_trdoi_ND_LKE_KQ, P_LOI_TGIAN);
        }
    }
    catch (ex) { }
}
function khud_trdoi_ND_LKE_KQ(b_kq) {
    if (!Fb_LOI_KTRA(b_kq) && b_kq != '') {
        var a_kq = Fas_ChMang(b_kq, '#');
        b_nd_c = CSO_SO(a_kq[0], 0);
        b_div = $get(b_dndId);
        b_kq = C_NVL(b_div.innerHTML);
        if (b_kq != '') b_kq += '<br>';
        b_div.innerHTML = b_kq + a_kq[1];
        b_div.scrollTop = b_div.scrollHeight;
    }
    b_lke_nd = true;
}
function khud_trdoi_GR_fi_RowChange() {
    if (b_choAct != 0) clearTimeout(b_choAct);
    b_choAct = setTimeout('khud_trdoi_FI_CHUYEN()', 300);
    return false;
}
function khud_trdoi_Fs_FI_MR(b_goc) {
    if (b_goc == '') b_goc = C_NVL(GridX_Fas_layGtriA(b_grfiId, 'goc'));
    b_i = b_goc.lastIndexOf('.');
    var b_mr = (b_i > 0) ? b_goc.substr(b_i + 1) : '';
    return b_mr.toLowerCase();
}
function khud_trdoi_FI_CHUYEN() {
    try {
        khud_trdoi_anhT();
        $get(b_phimId).style.display = $get(b_tiengId).style.display = 'none';
        var b_nd = C_NVL(GridX_Fas_layGtriA(b_grfiId, 'ten')), b_goc = C_NVL(GridX_Fas_layGtriA(b_grfiId, 'goc'));
        var b_i = b_nd.indexOf('('), b_mr = khud_trdoi_Fs_FI_MR(b_goc);
        if (b_i > 0) b_nd = b_nd.substr(0, b_i);
        $get(b_ndfiId).value = b_nd;
        if (b_mr != '' && 'png,gif,bmp,jpg,jpeg'.indexOf(b_mr) >= 0)
            skhud.Fs_FI_TRA(b_nsd, b_goc, khud_trdoi_FI_CHUYEN_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { }
}
function khud_trdoi_FI_CHUYEN_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
        else {
            var b_mr = khud_trdoi_Fs_FI_MR('');
            if ('png,gif,bmp,jpg,jpeg'.indexOf(b_mr) >= 0) {
                b_can.style.display = '';
                b_tranh.src = b_kq + '?' + new Date().getTime();
                $get(b_td_anhDK).style.display = '';
            }
            else if ('mp4,ogg'.indexOf(b_mr) >= 0) {
                var b_phim = $get(b_phimId);
                b_phim.style.display = '';
                b_phim.src = b_kq + '?' + new Date().getTime();
            }
            else if ('mp3,mav,m4a'.indexOf(b_mr) >= 0) {
                var b_tieng = $get(b_tiengId);
                b_tieng.style.display = '';
                b_tieng.src = b_kq + '?' + new Date().getTime();
            }
            b_mr = 'none';
            if (C_NVL(GridX_Fas_layGtriA(b_grfiId, 'tdo')) != '') {
                $get(b_td_anhM).style.display = '';
                if (C_NVL(GridX_Fas_layGtriA(b_grfiId, 'mdo')) == 'I') b_mr = '';
            }
            $get(b_mdoId).style.display = b_mr;
        }
    }
    catch (ex) { form_P_LOI('Trình duyệt không hỗ trợ ảnh, âm thanh. Xin dùng từ IE9 hoặc FireFox, Chrome, Safari'); }
}
function khud_trdoi_FI_XEM() {
    try {
        var b_goc = C_NVL(GridX_Fas_layGtriA(b_grfiId, 'goc'));
        if (b_goc != '') skhud.Fs_FI_TRA(b_nsd, b_goc, khud_trdoi_FI_XEM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function khud_trdoi_FI_XEM_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else form_P_MO(b_tmf + b_kq, window.name, null, 'C');
}
function khud_trdoi_FI_LKE() {
    try {
        if (b_fmo && b_Lke_fi && b_ma_dvi != '' && b_so_id != 0) {
            var a_dt = GridX_Fdt_cotGtriH(b_grfiId, 'goc,chon');
            b_Lke_fi = false;
            skhud.Fs_FI_LKE(b_nsd, b_ma_dvi, b_so_id, b_fi_c, a_dt, khud_trdoi_FI_LKE_KQ, khud_trdoi_FI_LKE_KQ, P_LOI_TGIAN);
        }
    }
    catch (ex) { }
}
function khud_trdoi_FI_LKE_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
        else if (b_kq != '') {
            var a_kq = Fas_ChMang(b_kq, '#'), a_cot = ['ten', 'chon', 'goc', 'tdo', 'mdo', 'ngay_nh', 'anh'], a_s;
            b_fi_c = CSO_SO(a_kq[0], 0)
            var a_p = Fas_ChMang(a_kq[1], ';');
            for (var i = 0; i < a_p.length; i++) {
                a_s = Fas_ChMang(a_p[i] + '|', '|');
                GridX_datGtriK(b_grfiId, 'goc', [a_cot, a_s]);
            }
            var b_hang = GridX_Fi_hangSo(b_grfiId);
            if (b_hang > GridX_Fi_hangKt(b_grfiId)) {
                GridX_P_hangKt(b_grfiId, b_hang); GridX_datH(b_grfiId, 1, b_hang);
            }
            if (b_choNen != 0) b_nenM = 'C';
            else {
                b_hangL = 0; b_imgU = 'K';
                b_choNen = setInterval('khud_trdoi_NENcho()', 300);
            }
        }
        b_Lke_fi = true;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function khud_trdoi_FI_SUA() {
    try {
        var b_nd = C_NVL($get(b_ndfiId).value), b_goc = C_NVL(GridX_Fas_layGtriA(b_grfiId, 'goc'));
        if (b_goc != '' && b_nd != '') skhud.Fs_FI_SUA(b_nsd, b_ma_dvi, b_so_id, b_goc, b_nd, khud_trdoi_FI_SUA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function khud_trdoi_FI_SUA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_nd = C_NVL($get(b_ndfiId).value), b_hang = GridX_Fi_timHangD(b_grfiId, 'goc', b_kq);
        if (b_hang > 0) GridX_datGtri(b_grfiId, b_hang, 'ten', b_nd, 'K');
    }
}
function khud_trdoi_FI_XOA() {
    try {
        var b_goc = C_NVL(GridX_Fas_layGtriA(b_grfiId, 'goc'));
        if (b_goc != '') skhud.Fs_FI_XOA(b_nsd, b_ma_dvi, b_so_id, b_goc, khud_trdoi_FI_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function khud_trdoi_FI_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        $get(b_ndfiId).value = '';
        khud_trdoi_anhT(); GridX_boChon(b_grfiId);
    }
}
function khud_trdoi_FI_LAY_LLL() {
    try {
        var b_tmL = C_NVL($get(b_tmLId).value);
        if (b_tmL == '') form_P_LOI('loi:Nhập thư mục lưu File lấy về:loi');
        else {
            var a_dt = GridX_Fdt_cotGtriH(b_grfiId, 'goc,ten,chon');
            skhud.Fs_FI_TRAf(b_nsd, b_tmL, a_dt, P_LOI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function khud_trdoi_anhT() {
    $get(b_td_anhDK).style.display = $get(b_td_anhM).style.display = $get(b_mdoId).style.display = 'none';
    b_deg = 0; b_tl = 0; b_chuyen = 0; b_dich = 0; b_tranh.src = '';
    b_can.width = b_can.width; b_can.style.display = 'none';
    return false;
}
function khud_trdoi_anhX() {
    var b_ctx = b_can.getContext('2d');
    b_ctx.save();
    b_ctx.setTransform(1, 0, 0, 1, 0, 0);
    b_ctx.clearRect(0, 0, b_can.width, b_can.height);
    b_ctx.restore();
}
function khud_trdoi_anhQ(b_dk, b_doi) {
    try {
        var b_ctx = b_can.getContext('2d'), b_hs;
        khud_trdoi_anhX();
        if (b_dk == 'D') b_dich += b_doi;
        else if (b_dk == 'C') b_chuyen += b_doi;
        else if (b_dk == 'P') {
            if (b_doi != 1) { b_hs = 1 + b_doi; b_tl *= b_hs; }
            else {
                b_hs = 1 / b_tl; b_tl = 1;
                b_ctx.rotate((360 - b_deg) * Math.PI / 180);
                b_deg = 0; b_dich = 0; b_chuyen = 0;
            }
            b_ctx.scale(b_hs, b_hs);
        }
        else {
            b_deg += b_doi;
            if (b_deg >= 360) b_deg -= 360;
            b_ctx.rotate(b_doi * Math.PI / 180);
        }
        khud_trdoi_anhA();
        return false;
    }
    catch (ex) { }
}
function khud_trdoi_anhA() {
    try {
        var b_ctx = b_can.getContext('2d'), b_iw = b_tranh.width, b_ih = b_tranh.height, b_cw, b_tw, b_rw, b_ch, b_th, b_rh;
        if (b_deg == 0 || b_deg == 180) { b_cw = b_iw; b_ch = b_ih; } else { b_cw = b_ih; b_ch = b_iw; }
        if (b_tl == 0) {
            b_tw = 640 / b_cw; b_th = 360 / b_ch;
            b_tl = (b_tw < b_th) ? b_tw : b_th;
            b_ctx.scale(b_tl, b_tl);
        }
        b_rw = ROUNDN(b_tl * b_cw, 0); b_rh = ROUNDN(b_tl * b_ch, 0);
        b_tw = ROUNDN((640 - b_rw) / 2 / b_tl, 0); b_th = ROUNDN((360 - b_rh) / 2 / b_tl, 0);
        var b_cx = 0, b_cy = 0, b_d = b_dich, b_c = b_chuyen;
        switch (b_deg) {
            case 90:
                b_cx = 0; b_cy = -b_ih; b_i1 = b_tw; b_tw = b_th; b_th = -b_i1; b_d = b_c; b_c = -b_dich;
                break;
            case 180:
                b_cx = -b_iw; b_cy = -b_ih; b_tw = -b_tw; b_th = -b_th; b_d = -b_d; b_c = -b_c;
                break;
            case 270:
                b_cx = -b_iw; b_cy = 0; b_i1 = b_tw; b_tw = -b_th; b_th = b_i1; b_d = -b_c; b_c = b_dich;
                break;
        }
        b_ctx.drawImage(b_tranh, b_cx + b_tw + b_d, b_cy + b_th + b_c, b_iw, b_ih);
        return false;
    }
    catch (ex) { }
}
function khud_trdoi_CBI(b_event) {
    var b_tdo = form_vtriTdoi(b_event);
    //$get(b_ndId).value = b_tdo.x.toString() + ':' + b_tdo.y.toString();
    if (b_tdo.x < 32 && b_tdo.y < 24) khud_trdoi_anhQ('P', -0.1);
    else if (b_tdo.x > 72 && b_tdo.y < 24) khud_trdoi_anhQ('P', 0.1);
    else if (b_tdo.x > 72 && b_tdo.y > 24) khud_trdoi_anhQ('Q', 90);
    else if (b_tdo.x < 32 && b_tdo.y > 24) khud_trdoi_anhQ('Q', 270);
    else if (b_tdo.x > 46 && b_tdo.x < 57 && b_tdo.y < 17) khud_trdoi_anhQ('C', -10);
    else if (b_tdo.x > 46 && b_tdo.x < 57 && b_tdo.y > 33) khud_trdoi_anhQ('C', 10);
    else if (b_tdo.x > 32 && b_tdo.x < 43 && b_tdo.y > 20 && b_tdo.y < 31) khud_trdoi_anhQ('D', -10);
    else if (b_tdo.x > 60 && b_tdo.x < 70 && b_tdo.y > 20 && b_tdo.y < 31) khud_trdoi_anhQ('D', 10);
    else if (b_tdo.x > 47 && b_tdo.x < 57 && b_tdo.y > 20 && b_tdo.y < 31) khud_trdoi_anhQ('P', 1);
    return false;
}
function khud_trdoi_FI_GHEP() {
    if (b_so_id != 0) form_P_MO(b_tmf + '/bhkh/bhkh_ghep.aspx', window.name, ['TSO', [b_so_id]]);
    return false;
}
function khud_trdoi_CH() {
    if (C_NVL($get(b_ndfiId).value) == '') form_P_LOI('Nhập nội dung File');
    else { $get(b_fileId).click(); form_chay = 0; }
    return false;
}
function khud_trdoi_DOC() {
    try {
        var b_file = $get(b_fileId);
        if (C_NVL(b_file.value) != '') {
            for (var i = 0; i < b_file.files.length; i++) {
                var b_ndf = b_file.files[i];
                if (b_ndf) {
                    var b_reader = new FileReader(), b_i = b_ndf.name.lastIndexOf('.') + 1;
                    b_mrF = (b_i > 0) ? b_ndf.name.substr(b_i) : '';
                    b_kieuF = (b_ndf.type.match('image.*')) ? 'C' : 'K';
                    b_tdoF = (b_ndf.type.match('image.*') || b_ndf.type.match('video.*') || b_ndf.type.match('audio.*')) ? b_tdoL : '';
                    b_reader.readAsDataURL(b_ndf);
                    b_reader.onload = khud_trdoi_LUU;
                }
            }
            b_file.value = '';
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function khud_trdoi_LUU(b_reader) {
    try {
        var b_fi = b_reader.target.result, b_nd = C_NVL($get(b_ndfiId).value);
        if (b_fi.length > 0) {
            if (b_kieuF == 'C' && khud_trdoi_Fs_NEN() == 'C') {
                a_fN.push(b_fi); a_gN.push(b_fi); a_mrN.push(b_mrF); a_tenN.push(b_nd);
                a_tdoN.push(b_tdoF); a_kieuFN.push(b_kieuF); a_sImgN.push('K');
            }
            else {
                a_g.push(b_fi); a_mr.push(b_mrF); a_ten.push(b_nd);
                a_tdo.push(b_tdoF); a_kieuF.push(b_kieuF); a_sImg.push('K');
            }
        }
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function khud_trdoi_GUI() {
    try {
        if (b_fmo && b_chG < 0) {
            for (var i = 0; i < a_ten.length; i++) {
                if (a_ten[i] != null) {
                    b_chG = i; b_chV = 0; b_chB = -1; b_cho_ch = setInterval('khud_trdoi_CFI()', 50);
                    break;
                }
            }
        }
    }
    catch (ex) { }
}
function khud_trdoi_CFI() {
    try {
        if (b_fmo && b_chB < 0) {
            b_chB = 1;
            var b_dk = 'M', b_s = a_g[b_chG].substr(b_chV, b_chN);
            if (b_chV + b_chN > a_g[b_chG].length) {
                b_dk = a_ten[b_chG] + '|' + a_mr[b_chG] + '|' + a_kieuF[b_chG] + '|' + a_tdo[b_chG] + '|' + a_sImg[b_chG];
            }
            else if (b_chV != 0) b_dk = '';
            skhud.Fs_FI_CH(b_nsd, window.name, b_ma_dvi, b_so_id, b_s, b_dk, khud_trdoi_CFI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function khud_trdoi_CFI_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); b_chB = -1; }
        else {
            b_chV += b_chN;
            if (b_chV < a_g[b_chG].length) b_chB = -1;
            else {
                clearInterval(b_cho_ch);
                a_ten[b_chG] = null; a_g[b_chG] = null; a_mr[b_chG] = null; a_kieuF[b_chG] = null;
                b_chG = -1;
            }
        }
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function khud_trdoi_taoP() {
    var b_div = document.createElement('div');
    Attribute_P_DAT(b_div, 'class', 'css_div');
    b_div.innerHTML = 'Đóng bản đồ';
    b_div.addEventListener('click', function () { khud_trdoi_DONG(); });
    return b_div;
}
function khud_trdoi_latLng(b_s) {
    var a_s = Fas_ChMang(b_s);
    return { lat: CSO_SO(a_s[0], 6), lng: CSO_SO(a_s[1], 6) };
}
function khud_trdoi_DONG() {
    $get(b_bdoId).style.display = 'none';
    return false;
}
function khud_trdoi_anhM() {
    try {
        var b_ll = khud_trdoi_latLng(GridX_Fas_layGtriA(b_grfiId, 'tdo')), b_divB = $get(b_bdoId), b_divD = khud_trdoi_taoP();
        b_divB.style.display = '';
        var b_bdo = new google.maps.Map(b_divB, { zoom: 13, center: b_ll });
        b_bdo.controls[google.maps.ControlPosition.RIGHT_TOP].push(b_divD);
        new google.maps.Marker({ map: b_bdo, position: b_ll });
        return false;
    }
    catch (ex) { form_P_LOI('Chưa kết nối Internet'); }
}
function khud_trdoi_ToaDo() {
    var b_sys = form_Fs_SYS();
    if (navigator.geolocation)
        navigator.geolocation.getCurrentPosition(
            function (tdo) {
                clearTimeout(b_choTdo);
                b_tdoL = tdo.coords.latitude + '#' + tdo.coords.longitude;
            }, function (err) { }, { timeout: 1000 });
}
function khud_trdoi_P_NEN() {
    var b_nen = $get(b_nenId);
    b_nen.className = (b_nen.className == 'css_tong') ? 'css_ma' : 'css_tong';
    return false;
}
function khud_trdoi_Fs_NEN() {
    var b_mau = $get(b_nenId).className;
    return (b_mau == 'css_tong') ? 'C' : 'K';
}
function khud_trdoi_Fimg() {
    try {
        var b_kq = 'C', a_row = $get(b_grfiId).rows;
        var b_cell = a_row[b_hangL].cells[1];
        var a_ctr = b_cell.getElementsByTagName('nobr');
        if (a_ctr.length > 0) {
            var a_img = a_ctr[0].getElementsByTagName('img');
            if (a_img.length == 0) b_kq = 'K';
        }
        return b_kq;
    }
    catch (ex) { return 'C'; }
}
function khud_trdoi_Fb_QUA() {
    try { return ($get(b_grfiId).rows.length <= b_hangL); }
    catch (ex) { return true; }
}
function khud_trdoi_NENcho() {
    if (b_imgU == 'K') { b_hangL++; khud_trdoi_P_IMG(); }
}
function khud_trdoi_P_IMG() {
    try {
        b_imgU = 'C';
        if (khud_trdoi_Fb_QUA()) {
            if (b_nenM == 'C') { b_nenM = 'K'; b_hangL = 0; b_imgU = 'K'; }
            else { clearInterval(b_choNen); b_choNen = 0; }
        }
        else if (khud_trdoi_Fimg() == 'C') b_imgU = 'K';
        else {
            var b_goc = C_NVL(GridX_Fas_layGtri(b_grfiId, b_hangL, 'goc'));
            var b_mr = khud_trdoi_Fs_FI_MR(b_goc);
            if (b_mr == '' || 'png,gif,bmp,jpg,jpeg'.indexOf(b_mr) < 0) b_imgU = 'K';
            else skhud.Fs_FI_TRAs(b_nsd, b_goc, khud_trdoi_FI_TRAs_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function khud_trdoi_FI_TRAs_KQ(b_kq) {
    try {
        if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
        else if (b_kq != '') {
            var a_kq = Fas_ChMang(b_kq, '#');
            if (a_kq[0] == 'C') khud_trdoi_FI_TRA_NH(a_kq[1]);
            else khud_trdoi_NENimg(a_kq[1]);
        }
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function khud_trdoi_FI_TRA_NH(b_kq) {
    try {
        var a_row = $get(b_grfiId).rows;
        var b_cell = a_row[b_hangL].cells[1];
        var a_ctr = b_cell.getElementsByTagName('nobr');
        var b_img = img_Fimg('img');
        b_img.src = (b_kq.length < 500) ? b_kq + '?' + new Date().getTime() : b_kq;
        a_ctr[0].appendChild(b_img);
        b_imgU = 'K';
    }
    catch (ex) { }
}
function khud_trdoi_NENimg(b_fi) {
    b_imgL = null;
    b_imgL = img_Fimg('img');
    b_imgL.src = (b_fi.length < 500) ? b_fi + '?' + new Date().getTime() : b_fi;
    b_choImg = setInterval('khud_trdoi_NENcbi()', 300);
}
function khud_trdoi_NENcbi() {
    if (b_imgL.complete) {
        clearTimeout(b_choImg);
        var b_ten = C_NVL(GridX_Fas_layGtri(b_grfiId, b_hangL, 'goc')), b_fi = img_NEN(b_imgL, 64, 36);
        khud_trdoi_FI_TRA_NH(b_fi);
        a_tdo.push(''); a_kieuF.push('K'); a_sImg.push('C');
        a_g.push(b_fi); a_mr.push('jpeg'); a_ten.push(b_ten);
    }
}
function khud_trdoi_NEN() {
    try {
        if (b_nenD < 0) {
            for (var i = 0; i < a_tenN.length; i++) {
                if (a_tenN[i] != null) {
                    b_nenD = i;
                    b_imgLf = null;
                    b_imgLf = img_Fimg('img');
                    b_imgLf.src = (a_fN[i].length < 500) ? a_fN[i] + '?' + new Date().getTime() : a_fN[i];
                    b_choImgf = setInterval('khud_trdoi_NENcbif()', 300);
                    break;
                }
            }
        }
    }
    catch (ex) { }
}
function khud_trdoi_NENimgf(b_fi) {
    b_imgLf = null;
    b_imgLf = img_Fimg('img');
    b_imgLf.src = (b_fi.length < 500) ? b_fi + '?' + new Date().getTime() : b_fi;
    b_choImgf = setInterval('khud_trdoi_NENcbif()', 300);
}
function khud_trdoi_NENcbif() {
    if (b_imgLf.complete) {
        clearTimeout(b_choImgf);
        var b_fi = img_NEN(b_imgLf);
        a_tdo.push(a_tdoN[b_nenD]); a_kieuF.push(a_kieuFN[b_nenD]); a_sImg.push('K');
        a_g.push(b_fi); a_mr.push('jpeg'); a_ten.push(a_tenN[b_nenD]);
        a_tenN[b_nenD] = null; a_fN[b_nenD] = null;
        b_nenD = -1;
    }
}
function img_Fimg(b_l, b_w, b_h) {
    b_c = document.createElement(b_l);
    if (b_w != null) { b_c.width = b_w; b_c.height = b_h; }
    return b_c;
}
function img_NEN(b_img, b_mw, b_mh) {
    try {
        if (b_mw == null) b_mw = 640;
        if (b_mh == null) b_mh = 360;
        var b_wg = b_img.width, b_hg = b_img.height;
        var b_tw = b_mw / b_wg, b_th = b_mh / b_hg;
        var b_tl = (b_tw < b_th) ? b_tw : b_th;
        if (b_tl < 1) { b_wg = ROUNDN(b_tl * b_wg, 0); b_hg = ROUNDN(b_tl * b_hg, 0); }
        var b_canC = img_Fimg('canvas', b_wg, b_hg);
        b_img.width = b_wg; b_img.height = b_hg;
        b_canC.getContext('2d').drawImage(b_img, 0, 0, b_wg, b_hg);
        b_fn = b_canC.toDataURL('image/jpeg');
        b_canC = null; b_img = null;
        return b_fn;
    }
    catch (ex) { return ''; }
}
function khud_trdoi_FI_LAY_AAA() {
    try {
        var a_dt = GridX_Fdt_layGtri(b_grfiId, ['goc', 'ten', 'chon']), b_s = '', b_i;
        var b_goc, b_ten, b_goc_m, b_ten_m;
        for (var i = 0; i < a_dt.length; i++) {
            b_goc = C_NVL(a_dt[i][0]);
            if (b_goc == '') break;
            if (C_NVL(a_dt[i][2]) == 'x') {
                b_ten = a_dt[i][1];
                b_i = b_ten.lastIndexOf('(');
                if (b_i > 0) b_ten = b_ten.substr(0, b_i);
                b_goc_m = ''; b_ten_m = '';
                while (b_goc != b_goc_m) {
                    b_goc_m = b_goc;
                    b_goc = b_goc.replace('/', '|').replace('.', '!');
                }
                while (b_ten != b_ten_m) {
                    b_ten_m = b_ten;
                    b_ten = b_ten_m.replace('/', '').replace('.', '').replace('#', '').replace(' ', '_').replace('{', '').replace('}', '');
                }
                b_goc += '}' + b_ten;
                b_s = kytu_Fs_them(b_s, b_goc, '{');
            }
        }
        if (b_s != '') form_P_MO(b_tmf + '/khud/khud_layf.aspx?tso=' + b_s, window.name, null, 'C');
        form_chay = 0;
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function khud_trdoi_FI_LAY() {
    try {
        var b_goc = C_NVL(GridX_Fas_layGtriA(b_grfiId, 'goc')), b_ten = C_NVL(GridX_Fas_layGtriA(b_grfiId, 'ten'));
        if (b_goc != '') {
            var b_goc_m = '', b_ten_m = '', b_i = b_ten.indexOf('(');
            while (b_goc != b_goc_m) {
                b_goc_m = b_goc;
                b_goc = b_goc.replace('/', '|').replace('.', '!');
            }
            if (b_i > 0) b_ten = b_ten.substr(0, b_i);
            while (b_ten != b_ten_m) {
                b_ten_m = b_ten;
                b_ten = b_ten_m.replace('/', '').replace('.', '').replace('#', '').replace(' ', '_').replace('{', '').replace('}', '');
            }
            b_goc += '}' + b_ten;
            form_P_MO(b_tmf + '/khud/khud_layf.aspx?tso=' + b_goc, window.name, null, 'C');
        }
        form_chay = 0;
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
