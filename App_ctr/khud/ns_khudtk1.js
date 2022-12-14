var b_ns_khudtk_taoCho = 0, b_ns_khudtk_nv, b_ns_khudtk_ps, b_kdvi = '', b_ns_khudtk_gchuId, b_ns_khudtk_gridId;

function ns_khudtk_KD(b_ps, b_nv, b_gcId, b_grId, kdvi) {
    b_ns_khudtk_ps = b_ps; b_ns_khudtk_nv = b_nv; b_kdvi = kdvi;
    b_ns_khudtk_gchuId = b_gcId; b_ns_khudtk_gridId = b_grId;
    //b_ns_khudtk_taoCho = setInterval('ns_khudtk_TAO_CHO()', 1000);
}
function ns_khudtk_TAO_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(b_ns_khudtk_taoCho);
        slide_P_MOI(b_ns_khudtk_gridId + '_slide');
        ns_khudtk_TAO();
    }
}
function ns_khudtk_P_KET_QUA(b_dtuong, a_tso) {
    if (C_NVL(dtuong) != '') form_NhanKq(b_dtuong, a_tso[0]);
}
function ns_khudtk_P_LUU(b_luu) {
    var a_s = Fas_ChMang(b_luu, ',');
    b_ns_khudtk_nv = a_s[0]; b_ns_khudtk_ps = a_s[1];
    b_ns_khudtk_gchuId = a_s[2]; b_ns_khudtk_gridId = a_s[3];
}
function ns_khudtk_Fs_LUU() {
    return b_ns_khudtk_nv + ',' + b_ns_khudtk_ps + ',' + b_ns_khudtk_gchuId + ',' + b_ns_khudtk_gridId;
}
function ns_khudtk_GR_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event);
        if (b_ctr != null) {
            var b_value = C_NVL(b_ctr.value), b_ktra = C_NVL(b_ctr.getAttribute('ktra'));
            if (b_value != '') {
                if (C_NVL(b_ctr.getAttribute('kieu_date')) != '') {
                    var b_loi = Fs_NGAY_LOI(b_value, 'C');
                    if (b_loi != '') form_P_LOI(b_loi);
                }
                else if (b_ktra != '') {
                    var b_ten = GridX_Fas_layGtriA(b_ns_khudtk_gridId, 'ten');
                    skhac.Fs_MA_LOI(form_Fs_nsd(), b_ten, b_value, b_ktra, ns_khudtk_LOI, P_LOI_CSDL, P_LOI_TGIAN);
                }
            }
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_khudtk_LOI(b_kq) {
    var b_loi = 'K';
    if (Fb_LOI_KTRA(b_kq)) { b_loi = 'C'; form_P_LOI(b_kq); }
    else if (b_kq != '') $get(b_ns_khudtk_gchuId).innerHTML = b_kq;
    GridX_datGtriA(b_ns_khudtk_gridId, 'loi', b_loi, 'K');
}
function ns_khudtk_P_DONG() {
    $get(b_ns_khudtk_gchuId).innerHTML = '.';
}
function ns_khudtk_P_MOI(b_dk) {
    b_dk = (C_NVL(b_dk) == 'M') ? null : 'ND';
    GridX_datTrang(b_ns_khudtk_gridId, null, null, b_dk);
    GridX_thoiA(b_ns_khudtk_gridId); ns_khudtk_MAU();
}
function ns_khudtk_Fdt_LAY_NH() {
    try {
        var a_dt = GridX_Fdt_cotGtriH(b_ns_khudtk_gridId), b_nd, b_loai, b_loi = '';
        if (a_dt[1] != null) {
            for (var i = 0; i < a_dt[1].length; i++) {
                b_nd = C_NVL(a_dt[1][i][1]); b_loai = C_NVL(a_dt[1][i][3]);
                if (C_NVL(a_dt[1][i][4]) == 'C' && C_NVL(a_dt[1][i][1]) == '') b_loi = 'Phải nhập:';
                else if (b_loai == 'N' && b_nd != '') {
                    b_loi = Fs_NGAY_LOI(b_nd, 'C');
                    if (b_loi != '') b_loi += ' :';
                }
                else if (C_NVL(a_dt[1][i][5]) == 'C') b_loi = 'Nhập sai:';
                if (b_loi != '') { form_P_LOI('loi:' + b_loi + C_NVL(a_dt[1][i][0]) + ':loi'); break; }
                if (b_loai == 'S') a_dt[1][i][1] = CSO_SO(b_nd, 6).toString();
            }
            a_dt = GridX_Fdt_cotGtriL(b_ns_khudtk_gridId, 'MA,nd', 'MA,nd,loai');
            if (a_dt[1] != null) {
                for (var i = 0; i < a_dt[1].length; i++) {
                    if (C_NVL(a_dt[1][i][2]) == 'S') a_dt[1][i][1] = CSO_SO(a_dt[1][i][1], 6).toString();
                }
            }
        }
        return a_dt;
    }
    catch (ex) { return [null, null]; }
}

function ns_khudtk_TAO(a_cot, a_ten, a_width, a_align, a_width_default, a_cotan, b_sodong) {
    try {
        deleteRows_tk();
        deleteColumns_tk();
        //var a_cotan = Fas_ChMang(b_cotan, ',');
        $get(b_ns_khudtk_gridId).setAttribute("cot", Fs_CONG(a_cot,','));
        $get(b_ns_khudtk_gridId).setAttribute("cotAn", Fs_CONG(a_cotan, ','));
        $get(b_ns_khudtk_gridId).setAttribute("hangkt", b_sodong);
        for (var i = 0 ; i < a_cot.length; i++) {
            var b_an = 0;
            for (var j = 0 ; j < a_cotan.length; j++) {
                if (a_cot[i] == a_cotan[j]) {
                    b_an = 1;
                }
            }
            appendColumn_tk(a_cot[i], a_ten[i], b_an);
        }
        for (var i = 0 ; i < b_sodong; i++) {
            appendRow_tk(i + 1, a_cot, a_align, a_ten, a_cotan);
        }
        var tbl = document.getElementById(b_ns_khudtk_gridId), // table reference
            a_row = $get(b_ns_khudtk_gridId).rows,
            b_width = a_width_default, b_canle = "css_gma";
        a_cell = a_row[0].cells; b_loai = 'GridX_P_ClCot(event)';
        for (var i = 1; i < a_cell.length; i++) {
            //Attribute_P_DAT(a_cell[i], 'onmousemove,onmousedown', [b_loai, b_loai]);
            b_width = a_width_default; b_canle = "css_gma";
            if (a_align[i - 1] != "") {
                b_canle = a_align[i - 1];
            }
            if (a_width[i - 1] != "") {
                b_width = a_width[i - 1];
            }
            Attribute_P_DAT(a_cell[i], 'width', [b_width]); //STT
        }
        return b_ns_khudtk_gridId;
        //b_ns_khudtk_ps = b_ps; b_ns_khudtk_nv = b_nv;
        //skhud_tknc.Fs_TTT_TAO(form_Fs_nsd(), b_ns_khudtk_ps, b_ns_khudtk_nv, b_kdvi, ns_khudtk_TAO_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) {return form_P_LOI(ex.message); }
}
function ns_khudtk2_TAO(a_cot, a_ten, a_cotan, b_sodong) {
    try {
        deleteRows_tk();
        deleteColumns_tk(); 
        $get(b_ns_khudtk_gridId).setAttribute("cot", Fs_CONG(a_cot, ','));
        $get(b_ns_khudtk_gridId).setAttribute("cotAn", Fs_CONG(a_cotan, ','));
        $get(b_ns_khudtk_gridId).setAttribute("hangkt", b_sodong);
        for (var i = 0 ; i < a_cot.length; i++) {
            var b_an = 0;
            for (var j = 0 ; j < a_cotan.length; j++) {
                if (a_cot[i] == a_cotan[j]) {
                    b_an = 1;
                }
            }
            appendColumn_tk(a_cot[i], a_ten[i], b_an);
        }
        for (var i = 0 ; i < b_sodong; i++) {
            appendRow_tk(i + 1, a_cot, a_ten, a_cotan);
        } 
        return b_ns_khudtk_gridId; 
    }
    catch (ex) { return form_P_LOI(ex.message); }
}
function ns_khudtk_TAO_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else if (b_kq != '') {
        var a_kq = (b_kq instanceof Array) ? b_kq : Fas_ChMang(b_kq, '#');
        b_kq = a_kq[0]; a_kq.splice(0, 1);
        GridX_dtuCot(b_ns_khudtk_gridId, 'ND', a_kq);
        GridX_datBang(b_ns_khudtk_gridId, b_kq); ns_khudtk_MAU();
        slide_P_SOTRANG(b_ns_khudtk_gridId + '_slide');
    }
}
function ns_khudtk_MAU() {
    var a_dt = GridX_Fdt_layGtri(b_ns_khudtk_gridId, 'loai');
    for (var i = 0; i < a_dt.length; i++) {
        if (C_NVL(a_dt[i]) == 'G') {
            GridX_datGtri(b_ns_khudtk_gridId, i + 1, 'mmm', 'ten,#EFEAD3,blue', 'K');
            GridX_MauCell(b_ns_khudtk_gridId, i + 1, 'ten', '#EFEAD3', 'blue');
        }
    }
}
function ns_khudtk_P_LKE(b_kq) {
    ns_khudtk_P_MOI();
    if (b_kq != '') GridX_thayGtri(b_ns_khudtk_gridId, 'MA', 'ND', 'MA,ND', b_kq);
}
function ns_khudtk_Fb_XONG() {
    return ($get(b_ns_khudtk_gridId) != null);
}

// append row to the HTML table
function appendRow_tk(b_hang, a_cot,a_align, a_giatri, a_cotan) {
    var tbl = document.getElementById(b_ns_khudtk_gridId), // table reference
        row = tbl.insertRow(tbl.rows.length),      // append table row
        i;
    row.setAttribute('onkeydown', "GridX_key(event)");
    row.setAttribute('onclick', "GridX_click(event,'K')");
    row.setAttribute('tabindex', -1);
    row.setAttribute('hang', b_hang);
    // insert table cells to the new row
    for (i = 0; i < tbl.rows[0].cells.length; i++) {
        var b_an = 0;
        if (i > 0) {
            for (var j = 0; j < a_cotan.length; j++) {
                if (a_cot[i - 1] == a_cotan[j]) {
                    b_an = 1;
                }
            }
            if (b_an == 1) {
                //createCellRow_tk(row.insertCell(i), a_giatri[i - 1], 'style', 'display:none', a_cot[j - 1]);
                createCellRow_tk(row.insertCell(i), i, '', 'style', 'display:none', a_cot[i - 1]);
            }
            else {
                //createCellRow_tk(row.insertCell(i), a_giatri[i - 1], 'style', 'color: black; background-color: white', a_cot[j - 1]);
                if (i > 0)
                    createCellRow_tk(row.insertCell(i), i, '', 'style', 'color: black; background-color: white', a_align[i - 1], a_cot[i - 1]);
                else
                    createCellRow_tk(row.insertCell(i), i, '', 'style', 'color: black; background-color: white', "css_Gma", a_cot[i - 1]);
            }
        }
        else {
            if (i > 0)
                createCellRow_tk(row.insertCell(i), i, '', 'style', 'color: black; background-color: white', a_align[i - 1], a_cot[i - 1]);
            else
                createCellRow_tk(row.insertCell(i), i, '', 'style', 'color: black; background-color: white', "css_Gma", a_cot[i - 1]);
        } 
    }
}

// create DIV element and append to the table cell
function createCellCol_tk(cell, text, b_type, style) {
    var div = document.createElement('b'), // create DIV element
        txt = document.createTextNode(text); // create text node
    div.appendChild(txt);                    // append text node to the DIV
    //div.setAttribute('class', style);        // set DIV class attribute
    //div.setAttribute('className', style);    // set DIV class attribute for IE (?!)
    cell.appendChild(div)
    if (b_type == 'style') {
        cell.setAttribute('style', style);
    }
    else {
        cell.setAttribute('class', style);        // set DIV class attribute
        cell.setAttribute('className', style);    // set DIV class attribute for IE (?!)
        //cell.setAttribute('style', 'width:' + (txt.length * 7) + 'px');
    }
}

// create DIV element and append to the table cell
function createCellRow_tk(cell, col, text, b_type, style, classNam, b_cot) {
    var div, txt;
    if (col == 0) {
        div = document.createElement('img'), // create DIV element
        txt = document.createTextNode(text); // create text node
        div.setAttribute("style", "display:none");
        div.setAttribute("onclick", "return false");
        div.setAttribute("src", "../../../images/bitmaps/phai.gif");
    } else {
        cell.setAttribute('cot', b_cot);
        div = document.createElement('b'), // create DIV element
        txt = document.createTextNode(text); // create text node
        div.appendChild(txt);                    // append text node to the DIV
    }
    //div.setAttribute('class', style);        // set DIV class attribute
    //div.setAttribute('className', style);    // set DIV class attribute for IE (?!)
    cell.appendChild(div)
    if (b_type == 'style') {
        cell.setAttribute('style', style); 
        cell.setAttribute('class', classNam);
    }
    else {
        cell.setAttribute('class', style);        // set DIV class attribute
        cell.setAttribute('className', style);    // set DIV class attribute for IE (?!)
    }

}


// append column to the HTML table
function appendColumn_tk(b_cot, b_tencot, b_an) {
    var tbl = document.getElementById(b_ns_khudtk_gridId), // table reference
        i;
    // open loop for each row and append cell
    for (i = 0; i < tbl.rows.length; i++) {
        if (b_an == 1) {
            createCellCol_tk(tbl.rows[i].insertCell(tbl.rows[i].cells.length), b_tencot, 'style', 'display:none');
        }
        else {
            createCellCol_tk(tbl.rows[i].insertCell(tbl.rows[i].cells.length), b_tencot, 'class', 'gridX_cot');
        }
    }
}


// delete table rows with index greater then 0
function deleteRows_tk() {
    var tbl = document.getElementById(b_ns_khudtk_gridId), // table reference
        lastRow = tbl.rows.length - 1,             // set the last row index
        i;
    // delete rows with index greater then 0
    for (i = lastRow; i > 0; i--) {
        tbl.deleteRow(i);
    }
}

// delete table columns with index greater then 0
function deleteColumns_tk() {
    var tbl = document.getElementById(b_ns_khudtk_gridId), // table reference
        lastCol = tbl.rows[0].cells.length - 1,    // set the last column index
        i, j;
    // delete cells with index greater then 0 (for each row)
    for (i = 0; i < tbl.rows.length; i++) {
        for (j = lastCol; j > 0; j--) {
            tbl.rows[i].deleteCell(j);
        }
    }
}