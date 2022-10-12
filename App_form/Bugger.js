
function dumpError(err) {
    if (typeof err === 'object') {
        if (err.message) {
            clog('\nMessage: ' + err.message);
        }
        if (err.stack) {
            clog('\nStacktrace:');
            clog('====================');
            clog(err.stack);
        }
    } else {
        clog('dumpError :: argument is not an object');
    }
}

function clog(message) {
    try {
        console.log(message);
    }
    catch (ex) { }
}
function CheckExits(element) {
    try {
        if (element === null || element === "NULL" || element === undefined || element === false) {
            return true;
        }
        if (typeof (element) === 'object') {
            var i = 0;
            for (key in element) {
                i++;
            }
            if (i === 0) {
                return true;
            }
        }
        return false;
    }
    catch (err) {
        return true;
    }
}

String.prototype.endsWith = function (str) {
    var lastIndex = this.lastIndexOf(str);
    return (lastIndex != -1) && (lastIndex + str.length == this.length);
}
String.prototype.startWith = function (str) {
    return this.lastIndexOf(str, 0) === 0;
}
String.prototype.padLeft = function (l, c) { return Array(l - this.length + 1).join(c || " ") + this }

function P_Disable(b_control_id) {
    $get(b_control_id).setAttribute("disabled", "disabled");
    if (!$get(b_control_id).className.startWith('css_drop')) {
        if ($get(b_control_id).className.endsWith('_c'))
            $get(b_control_id).className = "css_tong_c";
        else $get(b_control_id).className = "css_tong";
    }
    else {
        $get(b_control_id).className = "css_drop_disable";
    }
}
function P_Enable(b_control_id) {
    if (!$get(b_control_id).className.startWith('css_drop')) {
        if ($get(b_control_id).className == "css_tong_c" || $get(b_control_id).className == "css_tong")
            $get(b_control_id).className = "css_ma_c";
    }
    else {
        $get(b_control_id).className = "css_drop";
    }
    $get(b_control_id).removeAttribute("disabled");
}

function P_Visalbe(b_control_id, b_hien) {
    if (b_hien)
        $get(b_control_id).style.visibility = 'hidden';
    else $get(b_control_id).style.visibility = '';
}

function setCaretPosition(elemId, caretPos) {
    var elem = document.getElementById(elemId);

    if (elem != null) {
        if (elem.createTextRange) {
            var range = elem.createTextRange();
            range.move('character', caretPos);
            range.select();
        }
        else {
            if (elem.selectionStart) {
                elem.focus();
                elem.setSelectionRange(caretPos, caretPos);
            }
            else
                elem.focus();
        }
    }
}


String.prototype.Tong_Thang = function () {
    var b_thang = this.substring(0, 2), b_nam = this.substring(3, 7);
    var b_tong_thang = CSO_SO(b_nam) * 12 + CSO_SO(b_thang);
    return b_tong_thang;
}

function Dem_Thang(tu_thang, den_thang) {
    return tu_thang.Tong_Thang() - den_thang.Tong_Thang();
}

Number.prototype.TongThang2Chu = function () {
    var b_nam_toi = (this - this % 12) / 12;
    var b_thang_toi = this % 12;
    if (b_thang_toi == 0) {
        b_thang_toi = 12;
        b_nam_toi = b_nam_toi - 1;
    }
    return SO_CSO(b_thang_toi).padLeft(2, '0') + "/" + b_nam_toi;
}
String.prototype.lpad = function (padString, length) {
    var str = this;
    while (str.length < length)
        str = padString + str;
    return str;
}
function drop_set_selected(b_id_ctl, b_giatri) {
    var n = b_id_ctl.length;
    for (var i = 0; i < n; i++) {
        if (b_id_ctl[i].value === b_giatri) {
            b_id_ctl[i].selected = true;
            break;
        }
    }
}

String.prototype.locdau = function () {
    var str = this;
    str = str.toLowerCase();
    str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
    str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
    str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
    str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
    str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
    str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
    str = str.replace(/đ/g, "d");
    //str= str.replace(/!|@|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\;|\'| |\"|\&|\#|\[|\]|~|$|_/g,"-");
    /* tìm và thay thế các kí tự đặc biệt trong chuỗi sang kí tự - */
    str = str.replace(/-+-/g, "-"); //thay thế 2- thành 1-
    str = str.replace(/^\-+|\-+$/g, "");
    //cắt bỏ ký tự - ở đầu và cuối chuỗi
    return str.toUpperCase();
}

String.prototype.validate_Ma = function () {
    var str = this;
    str = str.toLowerCase();
    str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
    str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
    str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
    str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
    str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
    str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
    str = str.replace(/đ/g, "d");
    str= str.replace(/!|@|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\;|\'| |\"|\&|\#|\[|\]|~|\$|_/g,"-");
    /* tìm và thay thế các kí tự đặc biệt trong chuỗi sang kí tự - */
    str = str.replace(/-+-/g, "-"); //thay thế 2- thành 1-
    str = str.replace(/^\-+|\-+$/g, "");
    str = str.replace(/-/g, "");
    //cắt bỏ ký tự - ở đầu và cuối chuỗi
    return str.toUpperCase();
}
//function ktra_ktdb(b_str) {
//    var format = /^[a-zA-Z0-9\.\-]/;
//    if (b_str.match(format)) return false;
//    return true;
//}
//function ktra_ktdb(str) {
//    var c = str.replace("N'", "");
//    var splChars = "*|,\":<>[]{}`\';()@&$#%";
//    for (var i = 0; i < c.length; i++) {
//        if (splChars.indexOf(c.charAt(i)) != -1) {
//            form_P_LOI("loi:Mã không được chứa ký tự đặc biệt:loi");
//            return false;
//        }
//    }
//    return true;
//}
function ktra_ktdb(str) {
    var c = str.replace("N'", "");
    var splChars = "~`!@#$%^&*()+={}[]|\\:;\"'<,>.?/";
    for (var i = 0; i < c.length; i++) {
        if (splChars.indexOf(c.charAt(i)) != -1) {
            return true;
        }
    }
    return false;
}

function ktra_email(b_str) {
    if (b_str != '') {
        b_str = C_NVL(b_str.replace("-", "").replace("N'", ""));
        var format = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        if (b_str.match(format)) return true;
        return false;
    } else return true;
}
function RadioGetSelectValue(b_id) {
    var radioButtonList = document.getElementById(b_id);
    var b_chon = radioButtonList.getElementsByTagName('input');
    for (var x = 0; x < b_chon.length; x++) {
        if (b_chon[x].checked) return b_chon[x].value;
    }
}
