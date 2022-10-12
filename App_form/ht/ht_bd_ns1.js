var b_thongbao_hvId, b_thongbao_hdId, b_thongbao_gtId, b_tong_nsId, b_tong_nghiviecId, b_tong_tmId, b_tong_nv_tvId, b_loaiId, b_vungId, b_loaibdId, ns_thongbao_lkeCho;
function ns_thongbao_P_KD() {
    ns_thongbao_lkeCho;
    b_vungId = form_Fs_VUNG_ID('UPa_ct');
    b_loaibdId = form_Fs_TEN_ID(b_vungId, 'loai_bd');
    b_tong_nsId = form_Fs_TEN_ID(b_vungId, 'ld_tong_ns_td');
    b_tong_nghiviecId = form_Fs_TEN_ID(b_vungId, 'ld_tong_ns_nghiviec');
    b_tong_tmId = form_Fs_TEN_ID(b_vungId, 'ld_tong_ns_tm');
    b_tong_nv_tvId = form_Fs_TEN_ID(b_vungId, 'ld_tong_nghi_tt');
    ns_thongbao_lkeCho = setInterval('ns_thongbao_P_LKE_CHO()', 200);
}


function ns_thongbao_thongke() {
    var b_loai = $get(b_loaiId).value;
    if (b_loai == 'HD') {
        ns_tb_thongke_ns_P_LKE();
    }
    if (b_loai == 'GT') {
        chart_gt();
    }
    if (b_loai == 'HV') {
        chart_hv();
    }
}
function ns_thongbao_biendong() {
    ns_tb_thongke_BDNS_P_LKE();
}

function chart_hd() {
    Highcharts.chart('container', {
        chart: {
            plotBackgroundColor: null,
            plotBorderWidth: null,
            plotShadow: false,
            type: 'pie'
        },
        title: {
            text: "Thống kê % nhân sự các công ty"
        },
        tooltip: {
            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                    style: {
                        color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                    }
                }
            }
        },
        series: [{
            name: 'Chiếm',
            colorByPoint: true,
            data: [{
                name: 'Hợp đồng không xác định thời hạn',
                y: 56.33
            }, {
                name: 'Hợp đồng 3 năm',
                y: 24.03,
                sliced: true,
                selected: true
            }, {
                name: 'Hợp đồng 1 năm',
                y: 10.38
            }, {
                name: 'Hợp đồng thử việc',
                y: 4.77
            }, {
                name: 'Hợp đồng cộng tác viên',
                y: 0.91
            }, {
                name: 'Hợp đồng khoán việc',
                y: 0.2
            }]
        }]
    });
}

function chart_hv() {
    Highcharts.chart('container', {
        chart: {
            plotBackgroundColor: null,
            plotBorderWidth: null,
            plotShadow: false,
            type: 'pie'
        },
        title: {
            text: 'Thống kê trình độ học vấn'
        },
        tooltip: {
            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                    style: {
                        color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                    }
                }
            }
        },
        series: [{
            name: 'Chiếm',
            colorByPoint: true,
            data: [{
                name: 'Thạc sĩ',
                y: 4.2
            }, {
                name: 'Đại học',
                y: 81.3,
                sliced: true,
                selected: true
            }, {
                name: 'Cao đẳng',
                y: 12.1
            }, {
                name: 'Trung cấp',
                y: 2.0
            }, {
                name: 'Lao động phổ thông',
                y: 0.4
            }]
        }]
    });
}

function chart_gt() {
    Highcharts.chart('container', {
        chart: {
            plotBackgroundColor: null,
            plotBorderWidth: null,
            plotShadow: false,
            type: 'pie'
        },
        title: {
            text: 'Thống kê giới tính'
        },
        tooltip: {
            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                    style: {
                        color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                    }
                }
            }
        },
        series: [{
            name: 'Chiếm',
            colorByPoint: true,
            data: [{
                name: 'Nam',
                y: 56.92
            }, {
                name: 'Nữ',
                y: 43.08,
                sliced: true,
                selected: true
            }]
        }]
    });
}

function chart_nhansu_bd() {
    Highcharts.chart('container_bd', {
        chart: {
            type: 'column'
        },
        title: {
            text: 'Tổng hợp biến động nhân sự của CapitalHouse'
        },
        subtitle: {
            text: ''
        },
        xAxis: {
            categories: [
                '05/2016',
                '06/2016',
                '07/2016',
                '08/2016',
                '09/2016',
                '10/2016',
                '11/2016',
                '12/2016',
                '01/2017',
                '02/2017',
                '03/2017',
                '04/2017'
            ],
            crosshair: true
        },
        yAxis: {
            min: 0,
            title: {
                text: 'Số lượng (người)'
            }
        },
        tooltip: {
            headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
            pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                '<td style="padding:0"><b>{point.y:.f} người</b></td></tr>',
            footerFormat: '</table>',
            shared: true,
            useHTML: true
        },
        plotOptions: {
            column: {
                pointPadding: 0.2,
                borderWidth: 0
            }
        },
        series: [{
            name: 'Tổng nhân sự',
            data: [215, 221, 234, 227, 226, 233, 229, 224, 226, 230, 225, 232]

        }, {
            name: 'Nhân sự nghỉ việc',
            data: [10, 11, 8, 9, 7, 18, 5, 8, 12, 11, 14, 5]

        }, {
            name: 'Nhân sự tăng mới',
            data: [12, 17, 21, 2, 6, 25, 1, 3, 14, 15, 9, 12]

        }]
    });
}

function chart_nhansu_ta() {
    Highcharts.chart('container_bd', {
        chart: {
            type: 'column'
        },
        title: {
            text: 'Tổng số lao động tăng theo tháng'
        },
        subtitle: {
            text: ''
        },
        xAxis: {
            type: 'category',
            labels: {
                rotation: -45,
                style: {
                    fontSize: '13px',
                    fontFamily: 'Verdana, sans-serif'
                }
            }
        },
        yAxis: {
            min: 0,
            title: {
                text: 'Số lượng (người)'
            }
        },
        legend: {
            enabled: false
        },
        tooltip: {
            pointFormat: 'Số lượng tăng: <b>{point.y:.f} người</b>'
        },
        series: [{
            name: 'Population',
            data: [
                ['05/2016', 12],
                ['06/2016', 17],
                ['07/2016', 21],
                ['08/2016', 2],
                ['09/2016', 6],
                ['10/2016', 25],
                ['11/2016', 1],
                ['12/2016', 3],
                ['01/2017', 14],
                ['02/2017', 15],
                ['03/2017', 9],
                ['04/2017', 12]
            ],
            dataLabels: {
                enabled: true,
                rotation: -90,
                color: '#FFFFFF',
                align: 'right',
                format: '{point.y:.f}', // one decimal
                y: 10, // 10 pixels down from the top
                style: {
                    fontSize: '13px',
                    fontFamily: 'Verdana, sans-serif'
                }
            }
        }]
    });
}

function chart_nhansu_nv() {
    Highcharts.chart('container_bd', {
        chart: {
            type: 'column'
        },
        title: {
            text: 'Tổng số lao động nghỉ việc theo tháng'
        },
        subtitle: {
            text: ''
        },
        xAxis: {
            type: 'category',
            labels: {
                rotation: -45,
                style: {
                    fontSize: '13px',
                    fontFamily: 'Verdana, sans-serif'
                }
            }
        },
        yAxis: {
            min: 0,
            title: {
                text: 'Số lượng (người)'
            }
        },
        legend: {
            enabled: false
        },
        tooltip: {
            pointFormat: 'Số lượng giảm: <b>{point.y:.f} người</b>'
        },
        series: [{
            name: 'Population',
            data: [
                ['05/2016', 10],
                ['06/2016', 11],
                ['07/2016', 8],
                ['08/2016', 9],
                ['09/2016', 7],
                ['10/2016', 18],
                ['11/2016', 5],
                ['12/2016', 8],
                ['01/2017', 12],
                ['02/2017', 11],
                ['03/2017', 14],
                ['04/2017', 5]
            ],
            dataLabels: {
                enabled: true,
                rotation: -90,
                color: '#FFFFFF',
                align: 'right',
                format: '{point.y:.f}', // one decimal
                y: 10, // 10 pixels down from the top
                style: {
                    fontSize: '13px',
                    fontFamily: 'Verdana, sans-serif'
                }
            }
        }]
    });
}

function chart_nhansu_ts() {
    Highcharts.chart('container_bd', {
        chart: {
            type: 'column'
        },
        title: {
            text: 'Tổng số lao động theo tháng'
        },
        subtitle: {
            text: ''
        },
        xAxis: {
            type: 'category',
            labels: {
                rotation: -45,
                style: {
                    fontSize: '13px',
                    fontFamily: 'Verdana, sans-serif'
                }
            }
        },
        yAxis: {
            min: 0,
            title: {
                text: 'Số lượng (người)'
            }
        },
        legend: {
            enabled: false
        },
        tooltip: {
            pointFormat: 'Số lượng: <b>{point.y:.f} người</b>'
        },
        series: [{
            name: 'Population',
            data: [
                ['05/2016', 215],
                ['06/2016', 221],
                ['07/2016', 234],
                ['08/2016', 227],
                ['09/2016', 226],
                ['10/2016', 233],
                ['11/2016', 229],
                ['12/2016', 224],
                ['01/2017', 226],
                ['02/2017', 230],
                ['03/2017', 225],
                ['04/2017', 232]
            ],
            dataLabels: {
                enabled: true,
                rotation: -90,
                color: '#FFFFFF',
                align: 'right',
                format: '{point.y:.f}', // one decimal
                y: 10, // 10 pixels down from the top
                style: {
                    fontSize: '13px',
                    fontFamily: 'Verdana, sans-serif'
                }
            }
        }]
    });
}

function ns_thongbao_P_NPA(b_nv) {
    if (b_nv == "yc") {
        var b_hang = GridX_Fi_timHangA(b_grttId);
        if (b_hang > 0) { GridX_datA(b_grycId, b_hang); GridX_datA(b_grycId, b_hang, "bangcap"); }
        var b_gtri = GridX_Fdt_layGtri(b_grttId);
        var b_sott, b_nhom_cdanh, b_cdanh, b_ten_cdanh;
        for (var i = 1; i <= b_gtri.length; i++) {
            b_sott = GridX_Fas_layGtri(b_grttId, i, "sott");
            b_nhom_cdanh = GridX_Fas_layGtri(b_grttId, i, "nhom_cdanh");
            b_cdanh = GridX_Fas_layGtri(b_grttId, i, "cdanh")
            b_ten_cdanh = GridX_Fas_layGtri(b_grttId, i, "ten_cdanh")
            GridX_datGtri(b_grycId, i, ["sott", "nhom_cdanh", "cdanh", "ten_cdanh"], [b_sott, b_nhom_cdanh, b_cdanh, b_ten_cdanh]);
        }
    }
    if (b_nv == "tt") {
        var b_hang = GridX_Fi_timHangA(b_grycId);
        if (b_hang > 0) { GridX_datA(b_grttId, b_hang); GridX_datA(b_grttId, b_hang, "soluong") }
    }
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("NHOM_CDANH") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grttId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grttId, b_hang, ["nhom_cdanh"], [a_tso[0]], 'K');
            $get(b_gchuId).innerHTML = a_tso[1];
            GridX_datA(b_grttId, b_hang, "cdanh");
        }
        else if (b_dtuong.indexOf("CDANH") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grttId);
            if (b_hang < 0) return;
            //var b_nhom_cdanh = GridX_Fas_layGtri(b_grttId, b_hang, "nhom_cdanh")
            //if (b_nhom_cdanh != a_tso[2]) {
            //  alert("Vị trí công việc không thuộc nhóm chức danh đã chọn");
            //}
            //else {
            GridX_datGtri(b_grttId, b_hang, ["cdanh"], b_kq, 'K');
            GridX_datGtri(b_grttId, b_hang, ["nhom_cdanh"], a_tso[2], 'K');
            GridX_datGtri(b_grttId, b_hang, ["ten_cdanh"], a_tso[1], 'K');
            $get(b_gchuId).innerHTML = a_tso[1];
            GridX_datA(b_grttId, b_hang, "soluong");
            //}
        }
        else if (b_dtuong.indexOf("BANGCAP") >= 0) {
            //yencan
            var b_kq_cuoi = "";
            var b_hang = GridX_Fi_timHangA(b_grycId);
            var b_gtri_goc = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "bangcap"));
            if (b_gtri_goc != "") b_kq_cuoi = b_gtri_goc + "," + a_tso[0];
            else b_kq_cuoi = a_tso[0];
            if (b_hang < 0) return;
            GridX_datGtri(b_grycId, b_hang, ["bangcap"], [b_kq_cuoi], 'K');
            $get(b_gchuId).innerHTML = a_tso[1];
            GridX_datA(b_grycId, b_hang, "chuyenmon");
        }
        else if (b_dtuong.indexOf("CHUYENMON") >= 0) {
            var b_kq_cuoi = "";
            var b_hang = GridX_Fi_timHangA(b_grycId);
            var b_gtri_goc = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "chuyenmon"));
            if (b_gtri_goc != "") b_kq_cuoi = b_gtri_goc + "," + a_tso[0];
            else b_kq_cuoi = a_tso[0];
            if (b_hang < 0) return;
            GridX_datGtri(b_grycId, b_hang, ["chuyenmon"], [b_kq_cuoi], 'K');
            $get(b_gchuId).innerHTML = a_tso[1];
            GridX_datA(b_grycId, b_hang, "ngoaingu");
        }
        else if (b_dtuong.indexOf("NGOAINGU") >= 0) {
            var b_kq_cuoi = "";
            var b_hang = GridX_Fi_timHangA(b_grycId);
            var b_gtri_goc = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ngoaingu"));
            if (b_gtri_goc != "") b_kq_cuoi = b_gtri_goc + "," + a_tso[0];
            else b_kq_cuoi = a_tso[0];
            if (b_hang < 0) return;
            GridX_datGtri(b_grycId, b_hang, ["ngoaingu"], [b_kq_cuoi], 'K');
            $get(b_gchuId).innerHTML = a_tso[1];
            GridX_datA(b_grycId, b_hang, "uutien");
        }
        else if (b_dtuong.indexOf("MA_KH") >= 0) {
            $get(b_ma_khId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_gocId).focus();
            ns_td_dx_P_MAKH_KTRA(b_kq);
        }
        else if (b_dtuong.indexOf("KQ") >= 0) {
            $get(b_phongId).value = a_tso[0];
            $get(b_gocId).value = a_tso[1];
            $get(b_lanId).value = a_tso[2];
            ns_thongbao_P_LKE();
            var b_hang = GridX_Fi_timHangD(b_grlkeId, ["ma", "lan"], [a_tso[1], a_tso[2]]);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_thongbao_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_thongbao_P_CHUYEN_HANG(); }
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_td_dx_P_MAKH_KTRA(b_ma) {
    try {
        if (b_ma != "") {
            var a_cottt = GridX_Fas_tenCot(b_grttId),
                a_cotyc = GridX_Fas_tenCot(b_grycId);
            sns_td.Fs_NS_TD_MAKH_TRA(b_ma, a_cottt, a_cotyc, ns_td_dx_P_MAKH_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_dx_P_MAKH_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq != "") {
        var a_kq = Fas_ChMang(b_kq, '#');
        GridX_datBang(b_grttId, a_kq[0]);
        GridX_datBang(b_grycId, a_kq[1]);
    }
}
function ns_thongbao_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "PHONG": b_maId = b_phongId; form_P_MOI("", "XL"); break;
            case "MA": b_maId = b_gocId; break;
            case "LAN": b_maId = b_lanId; break;
            case "MA_KH": b_maId = b_ma_khId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            var b_lan = $get(b_lanId).value;
            if (b_lan != "") {
                var b_hang = GridX_Fi_timHangD(b_grlkeId, ["ma", "lan"], [b_ma_dx, b_ma.value]);
                if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_thongbao_P_MA_KTRA(); }
                else { GridX_datA(b_grlkeId, b_hang); ns_thongbao_P_CHUYEN_HANG(); }
            }
        }
        else if (b_maTen == "LAN") {
            var b_ma_dx = $get(b_gocId).value;
            if (b_ma_dx != "") {
                var b_hang = GridX_Fi_timHangD(b_grlkeId, ["ma", "lan"], [b_ma_dx, b_ma.value]);
                if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_thongbao_P_MA_KTRA(); }
                else { GridX_datA(b_grlkeId, b_hang); ns_thongbao_P_CHUYEN_HANG(); }
            }
        }
        else if (b_maTen == "PHONG") ns_thongbao_P_LKE();
        else if (b_maTen == "MA_KH") {
            ns_td_dx_P_MAKH_KTRA(b_ma)
        }
        else skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_thongbao_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function ns_thongbao_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_phong = $get(b_phongId).value, b_lan = $get(b_lanId).value;
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_td.Fs_ns_thongbao_MA(b_phong, b_ma, b_lan, b_TrangKt, a_cot, ns_thongbao_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_thongbao_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_thongbao_P_CHUYEN_HANG(); }
}

function ns_thongbao_Update_tt(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grttId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        var b_ktra = C_NVL(b_ctr.ktra), b_ten = C_NVL(b_ctr.ten);
        if (b_value != "") {
            if (b_cot == "NHOM_CDANH") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), b_ten, b_value, b_ktra, ns_thongbao_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
            if (b_cot == "CDANH") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), b_ten, b_value, b_ktra, ns_thongbao_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        if (b_value != "") GridX_ThemHang(b_grttId);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_thongbao_Update_yc(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grycId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        var b_ktra = C_NVL(b_ctr.ktra), b_ten = C_NVL(b_ctr.ten);
        if (b_value != "") {
            if (b_cot == "BANGCAP") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), b_ten, b_value, b_ktra, ns_thongbao_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
            if (b_cot == "CHUYENMON") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), b_ten, b_value, b_ktra, ns_thongbao_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
            if (b_cot == "NGOAINGU") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), b_ten, b_value, b_ktra, ns_thongbao_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        if (b_value != "") GridX_ThemHang(b_grttId);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_thongbao_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        if (a_kq.length > 1) { $get(b_cdanhId).value = a_kq[1]; $get(b_ma_cdanhId).value = a_kq[0]; }
        else form_P_DatGchu(b_gchuId, b_kq);
    }
}
var ns_thongbao_choAct = 0;
function ns_thongbao_GR_lke_RowChange() {
    if (ns_thongbao_choAct != 0) clearTimeout(ns_thongbao_choAct);
    ns_thongbao_choAct = setTimeout("ns_thongbao_P_CHUYEN_HANG()", 300);
    return false;
}


function ns_thongbao_P_LKE_CHO() {
    clearTimeout(ns_thongbao_lkeCho); //ns_tb_thongke_ns_P_LKE();
    ns_tb_thongke_BDNS_P_LKE();
}
function ns_tb_thongke_BDNS_P_LKE() {
    try {
        var b_loaibd = $get(b_loaibdId).value;
        sns_td.Fs_NS_THONGBAO_BDSNS_CT(b_loaibd, ns_tb_thongke_BDNS_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}


function ns_tb_thongke_BDNS_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    //b_kq = JSON.parse(b_kq);
    var a_kq = Fas_ChMang(b_kq, '#');
    var arrx = [];
    var arrx0 = [];
    var arrx2 = [];
    var arrx3 = [];
    var arrx4 = [];
    var a_kq_1 = Fas_ChMang(a_kq[1], ',');
    for (var i = 0; i < a_kq_1.length; i++) {
        var tempValue = parseInt(a_kq_1[i]);
        arrx.push(tempValue);
    }
    var a_kq_0 = Fas_ChMang(a_kq[0], ',');;
    for (var i = 0; i < a_kq_0.length; i++) {
        var tempValue = a_kq_0[i];
        arrx0.push(tempValue);
    }
    var a_kq_2 = Fas_ChMang(a_kq[2], ',');;
    for (var i = 0; i < a_kq_2.length; i++) {
        var tempValue = parseInt(a_kq_2[i]);
        arrx2.push(tempValue);
    }
    var a_kq_3 = Fas_ChMang(a_kq[3], ',');;
    for (var i = 0; i < a_kq_3.length; i++) {
        var tempValue = parseInt(a_kq_3[i]);
        arrx3.push(tempValue);
    }
    var a_kq_4 = Fas_ChMang(a_kq[4], ',');;
    for (var i = 0; i < a_kq_4.length; i++) {
        var tempValue = parseInt(a_kq_4[i]);
        arrx4.push(tempValue);
    }

    var b_tong_ns = a_kq[5];
    var b_tong_tang_moi = a_kq[6];
    var b_tong_nghiviec = a_kq[7];
    var b_tong_nv_tv = a_kq[8];
    $get(b_tong_nsId).innerHTML = "Tổng số nhân sự : " + b_tong_ns;
    $get(b_tong_tmId).innerHTML = "Tổng số nhân sự tăng mới: " + b_tong_tang_moi;
    $get(b_tong_nghiviecId).innerHTML = "Tổng số nhân sự nghỉ việc: " + b_tong_nghiviec;
    $get(b_tong_nv_tvId).innerHTML = "Tổng số nhân sự nghỉ việc trong thời gian thử việc: " + b_tong_nv_tv;
    Highcharts.chart('container_bd', {
        chart: {
            type: 'column'
        },
        title: {
            text: 'Tổng hợp biến động nhân sự'
        },
        subtitle: {
            text: ''
        },
        xAxis: {
            categories: arrx0,
            crosshair: true
        },
        yAxis: {
            min: 0,
            title: {
                text: 'Số lượng (người)'
            }
        },
        tooltip: {
            headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
            pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                '<td style="padding:0"><b>{point.y:.f} người</b></td></tr>',
            footerFormat: '</table>',
            shared: true,
            useHTML: true
        },
        plotOptions: {
            column: {
                pointPadding: 0.2,
                borderWidth: 0
            }
        },
        series: [{
            name: 'Tổng nhân sự',
            data: arrx

        }, {
            name: 'Nhân sự tăng mới',
            data: arrx3

        }, {
            name: 'Nhân sự nghỉ việc',
            data: arrx2

        }, {
            name: 'Nhân sự nghỉ việc trong thời gian thử việc',
            data: arrx4

        }]
    });
}
function ns_tb_thongke_ns_P_LKE() {
    try {
        sns_td.Fs_NS_THONGBAO_THONGKE_CT("", ns_tb_thongke_ns_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tb_thongke_ns_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    b_kq = JSON.parse(b_kq);
    Highcharts.chart('container', {
        chart: {
            plotBackgroundColor: null,
            plotBorderWidth: null,
            plotShadow: false,
            type: 'pie'
        },
        title: {
            text: "Thống kê % nhân sự các công ty"
        },
        tooltip: {
            pointFormat: '{series.name}: <b>{point.percentage:.2f}%</b>'
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '<b>{point.name}</b>: {point.percentage:.2f} %',
                    style: {
                        color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                    }
                }
            }
        },
        series: [{
            name: 'Chiếm',
            colorByPoint: true,
            data: b_kq,
            innerSize: '40%',
            showInLegend: true,
            dataLabels: {
                enabled: true,
                padding: 0
            }
        }]
    });
}
function ns_thongbao_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grttId);
    GridX_datTrang(b_grycId);
    $get(b_so_idId).value = "0";
    $get(b_phongId).focus();
    return false;
}
function ns_thongbao_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_phong = $get(b_phongId).value;
        sns_td.Fs_ns_thongbao_LKE(b_phong, a_tso, a_cot, ns_thongbao_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_thongbao_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_thongbao_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_dt = form_Faa_TEXT_ROW(b_vungId), b_so_id = $get(b_so_idId).value, b_dt_tt = GridX_Fdt_cotGtri(b_grttId), b_dt_yc = GridX_Fdt_cotGtri(b_grycId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            sns_td.Fs_ns_thongbao_NH(b_TrangKt, b_so_id, b_dt, b_dt_tt, b_dt_yc, a_cot_lke, ns_thongbao_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}

function ns_thongbao_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[1]) + 1, b_trang = CSO_SO(a_kq[2]), b_soDong = CSO_SO(a_kq[3]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[4]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_phongId).focus(); $get(b_ykienId).value = '';
        sendMail(a_kq[0]);
    }
    return false;
}

function ns_thongbao_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")),
        a_cot_tt = GridX_Fas_tenCot(b_grttId),
        a_cot_yc = GridX_Fas_tenCot(b_grycId);
    if (b_so_id == "") ns_thongbao_P_MOI();
    else sns_td.Fs_ns_thongbao_CT(b_so_id, a_cot_tt, a_cot_yc, ns_thongbao_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    GridX_datA(b_grlkeId, b_hang);
    $get(b_so_idId).value = b_so_id;
}
function ns_thongbao_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grttId);
    else GridX_datBang(b_grttId, a_kq[1]);
    if (a_kq[2] == "") GridX_datTrang(b_grycId);
    else GridX_datBang(b_grycId, a_kq[2]);
}
function ns_thongbao_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") ns_thongbao_P_MOI();
    else {
        var b_phong = $get(b_phongId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_td.Fs_ns_thongbao_XOA(b_so_id, b_phong, a_tso, a_cot, ns_thongbao_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_thongbao_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_thongbao_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_thongbao_P_CHUYEN_HANG(); }
    }
}
function ns_thongbao_HangLen() {
    var b_hang = GridX_Fi_timHangA(b_grttId);
    if (b_hang < 0) b_hang = GridX_Fi_timHangA(b_grycId);
    if (b_hang > 0) {
        GridX_datA(b_grttId, b_hang);
        GridX_datA(b_grycId, b_hang);
        GridX_chuyenHang(b_grycId, -1);
        GridX_chuyenHang(b_grttId, -1);
    }
    return false;
}
function ns_thongbao_HangXuong() {
    var b_hang = GridX_Fi_timHangA(b_grttId);
    if (b_hang < 0) b_hang = GridX_Fi_timHangA(b_grycId);
    if (b_hang > 0) {
        GridX_datA(b_grttId, b_hang);
        GridX_datA(b_grycId, b_hang);
        GridX_chuyenHang(b_grycId, 1);
        GridX_chuyenHang(b_grttId, 1);
    }
    return false;
}
function ns_thongbao_ChenDong(b_dk) {
    var b_hang = GridX_Fi_timHangA(b_grttId);
    if (b_hang < 0) b_hang = GridX_Fi_timHangA(b_grycId);
    if (b_hang > 0) {
        GridX_datA(b_grttId, b_hang);
        GridX_datA(b_grycId, b_hang);
        if (GridX_Fi_timHangC(b_grttId) < 1 || GridX_Fi_timHangC(b_grycId) < 1) {
            var b_ctr = eval(window.name + '_P_HTOAN');
            if (b_ctr != null) b_ctr('C');
        }
        else if (C_NVL(b_dk) == 'C') { GridX_chenHang(b_grttId); GridX_chenHang(b_grycId); }
    }
    return false;
}
function ns_thongbao_CatDong() {
    var b_hang = GridX_Fi_timHangA(b_grttId);
    if (b_hang < 0) b_hang = GridX_Fi_timHangA(b_grycId);
    if (b_hang > 0) {
        GridX_datA(b_grttId, b_hang);
        GridX_datA(b_grycId, b_hang);
        GridX_boChon(b_grttId, 'C');
        GridX_boChon(b_grycId, 'C');
    }
    return false;
}

function ns_thongbao_P_CHON() {
    var b_hang = GridX_Fi_timHangA(b_grttId);
    if (b_hang > 0) {
        form_P_TRA_CHON_GRID('GR_tt:nhom_cdanh,GR_tt:cdanh,GR_tt:loai,GR_tt:soluong,GR_tt:noi_lv');
    }
    else form_P_TRA_CHON('SO_ID,MA');
}

// START: Trả giá trị chọn trên lưới //       
// Tra gia tri chon cho form goi
function form_P_TRA_CHON_GRID(b_ten) {
    try {
        var b_kq = [];
        b_kq[0] = "lưới";
        b_kq[1] = $get(b_gocId).value;
        var a_kq = form_P_TRA_GTRI_GRID(b_ten);
        b_kq = b_kq + "," + a_kq; b_kq = Fas_ChMang(b_kq, ',');
        form_P_DONG(window.name, b_kq);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
// Tra mang gia tri theo ten
function form_P_TRA_GTRI_GRID(b_ten) {
    try {
        var a_ten = b_ten.split(','), a_kq = [];
        for (var i = 0; i < a_ten.length; i++) {
            var a_grid = a_ten[i].split(':');
            var b_gridId = form_Fs_VUNG_ID(a_grid[0]);
            var b_hang = GridX_Fi_timHangA(b_gridId);
            a_kq[i] = GridX_Fas_layGtri(b_gridId, b_hang, a_grid[1]);
        }
        return a_kq;
    }
    catch (err) { return null; }
}
// END: Trả giá trị chọn trên lưới // 

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

function form_dong() {
    location.reload(false);
}