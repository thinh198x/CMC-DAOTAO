<%@ Page Title="ti_thongke" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ti_thongke.aspx.cs" Inherits="f_ti_thongke" %>

<%@ Register Src="~/App_ctr/khud/khud_scrl.ascx" TagName="khud_scrl" TagPrefix="khud_scrl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td>
                            <table cellpadding="1" cellspacing="1" width="100%">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Thống kê số liệu " />
                                    </td>
                                    <td align="right">
                                        <div class="acc">
                                            <ul>
                                                <li><a href="#" onclick="return form_dong();"><i class="fa fa-sign-out"></i></a></li>
                                                <li><a href="#" onclick="return form_GOP();"><i class="fa fa-envelope-o"></i></a></li>
                                                <li><a href="#" onclick="return form_HELP();"><i class="fa fa-question"></i></a></li>
                                            </ul>
                                            <div class="clear"></div>
                                        </div>

                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="form_right">
                            <table id="UPa_ct" runat="server" border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label6" runat="server" Text="Thâm niên làm việc:" CssClass="css_gchu" Width="130px" />
                                    </td>
                                    <td align="left">
                                        <table>
                                            <tr>
                                                <td>
                                                    <Cthuvien:DR_nhap ID="dk_thamnien" runat="server" CssClass="css_form" Width="45px">
                                                        <asp:ListItem Text="" Value="0" />
                                                        <asp:ListItem Text="=" Value="=" />
                                                        <asp:ListItem Text=">" Value=">" />
                                                        <asp:ListItem Text="<" Value="<" />
                                                        <asp:ListItem Text=">=" Value=">=" />
                                                        <asp:ListItem Text="<=" Value="<=" />
                                                    </Cthuvien:DR_nhap>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="thamnien" runat="server" CssClass="css_form_c" Width="50px" kieu_so="true" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lb" runat="server" Text="/" />
                                                </td>
                                                <td>
                                                    <Cthuvien:kieu ID="loai_thamnien" runat="server" CssClass="css_form_c" Width="60px" Text="Năm" lke="Năm,Tháng" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label1" runat="server" Text="Thâm niên công việc:" CssClass="css_gchu" Width="140px" />
                                    </td>
                                    <td align="left">
                                        <table>
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="cdanh" ten="Mã chức danh" runat="server" CssClass="css_form" BackColor="#f6f7f7"
                                                        ktra="ns_ma_cdanh,ma,ten" ToolTip="Mã chức danh" kieu_chu="true" Width="110px"
                                                        f_tkhao="~/App_form/ns/ma/ns_ma_cdanh.aspx" onchange="ti_thongke_P_KTRA('CDANH')" gchu="gchu" placeholder="Nhấn F1" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Text="/" />
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_nhap ID="dk_cdanh" runat="server" CssClass="css_form" Width="45px">
                                                        <asp:ListItem Text="" Value="0" />
                                                        <asp:ListItem Text="=" Value="=" />
                                                        <asp:ListItem Text=">" Value=">" />
                                                        <asp:ListItem Text="<" Value="<" />
                                                        <asp:ListItem Text=">=" Value=">=" />
                                                        <asp:ListItem Text="<=" Value="<=" />
                                                    </Cthuvien:DR_nhap>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma kieu_so="true" ID="thamnien_cdanh" runat="server" CssClass="css_form_c" Width="50px" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text="/" />
                                                </td>
                                                <td>
                                                    <Cthuvien:kieu ID="loai_tncdanh" runat="server" CssClass="css_form_c" Width="60px" Text="Dự án" lke="Dự án,Năm,Tháng" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label4" runat="server" Text="Trình độ học vấn:" CssClass="css_gchu" Width="130px" />
                                    </td>
                                    <td align="left">
                                        <table>
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="capdt" ten="Mã trình độ đào tạo" runat="server" CssClass="css_form" BackColor="#f6f7f7"
                                                        ktra="ns_ma_capdt,ma,ten" ToolTip="Mã trình độ đào tạo" kieu_chu="true" Width="110px"
                                                        f_tkhao="~/App_form/ns/ma/ns_ma_capdt.aspx" onchange="ti_thongke_P_KTRA('CAPDT')" gchu="gchu" placeholder="Nhấn F1" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label5" runat="server" Text="Mức lương:" CssClass="css_gchu" Width="130px" />
                                    </td>
                                    <td align="left">
                                        <table>
                                            <tr>
                                                <td>
                                                    <Cthuvien:DR_nhap ID="dkien_luong" runat="server" CssClass="css_form" Width="45px">
                                                        <asp:ListItem Text="" Value="0" />
                                                        <asp:ListItem Text="=" Value="=" />
                                                        <asp:ListItem Text=">" Value=">" />
                                                        <asp:ListItem Text="<" Value="<" />
                                                        <asp:ListItem Text=">=" Value=">=" />
                                                        <asp:ListItem Text="<=" Value="<=" />
                                                    </Cthuvien:DR_nhap>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma kieu_so="true" ID="mucluong" runat="server" CssClass="css_form_r" Width="150px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label7" runat="server" Text="Thời gian chưa lên lương:" CssClass="css_gchu" Width="165px" />
                                    </td>
                                    <td align="left">
                                        <table>
                                            <tr>
                                                <td>
                                                    <Cthuvien:DR_nhap ID="dk_chualenluong" runat="server" CssClass="css_form" Width="45px">
                                                        <asp:ListItem Text="" Value="0" />
                                                        <asp:ListItem Text="=" Value="=" />
                                                        <asp:ListItem Text=">" Value=">" />
                                                        <asp:ListItem Text="<" Value="<" />
                                                        <asp:ListItem Text=">=" Value=">=" />
                                                        <asp:ListItem Text="<=" Value="<=" />
                                                    </Cthuvien:DR_nhap>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma kieu_so="true" ID="tg_chualenluong" runat="server" CssClass="css_form_c" Width="50px" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" Text="/" />
                                                </td>
                                                <td>
                                                    <Cthuvien:kieu ID="loai_chualenluong" runat="server" CssClass="css_form_c" Width="60px" Text="Năm" lke="Năm,Tháng" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>

                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table id="gridkn" runat="server" border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label9" runat="server" Text="Kỹ năng:" CssClass="css_gchu_c" Width="160px" />
                                    </td>
                                    <td align="left">
                                        <table>
                                            <tr>
                                                <td>
                                                    <Cthuvien:GridX ID="GR_kn" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                        CssClass="table gridX" loai="N" cot="ma,ten" hangKt="3" gchuId="gchu" hamUp="ti_thongke_Update">
                                                        <Columns>
                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                            <asp:TemplateField HeaderText="Mã kỹ năng" HeaderStyle-Width="80px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="ma" kieu_chu="true" runat="server" Width="80px" CssClass="css_Gma"
                                                                        f_tkhao="~/App_form/ns/ma/ns_ma_kynang.aspx" ktra="ns_ma_kynang,ma,ten" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Tên kỹ năng" DataField="ten" HeaderStyle-Width="170px" ItemStyle-CssClass="css_Gnd" />
                                                        </Columns>
                                                    </Cthuvien:GridX>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table class="tableButton">
                                <tr>
                                    <td style="padding-top: 5px">
                                        <div class="box3 txRight2">
                                            <a href="#" class="bt bt-grey" onclick="return ti_thongke_P_TIM();form_P_LOI();"><span class="txUnderline">T</span>hống kê</a>
                                        </div>
                                    </td>
                                    <%--<td align="center">
                                        <Cthuvien:nhap ID="tim" runat="server" Text="Thống kê" CssClass="css_button" OnClick="return ti_thongke_P_TIM();form_P_LOI();"
                                            Width="100px" />
                                    </td>--%>
                                    <td align="center" valign="middle" style="border: gray 1px solid; width: 20px; height:20px;">
                                        <img id="Img3" runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ti_thongke_HangLen();" />
                                    </td>
                                    <td style="border: gray 1px solid; width: 20px; height:20px;" align="center" valign="middle">
                                        <img id="Img4" runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ti_thongke_HangXuong();" />
                                    </td>
                                    <td style="border: gray 1px solid; width: 20px; height:20px;" align="center" valign="middle">
                                        <img id="Img5" runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ti_thongke_CatDong();" />
                                    </td>
                                    <td style="border: gray 1px solid; width: 20px; height:20px;" align="center" valign="middle">
                                        <img id="Img6" runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ti_thongke_ChenDong('C');" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="css_border" align="left">
                <div id="UPa_gchu">
                    <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                </div>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="500,420" />
    </div>
    <script language="javascript" type="text/javascript">
        var ti_thongke_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_nhomId, b_so_idId, b_mt,
            b_ctr, b_hang, b_f_tkhao, ti_thongke_choAct = 0;
        function ti_thongke_P_KD() {
            ti_thongke_lkeCho;
            b_vungId = form_Fs_VUNG_ID('UPa_ct');
            b_grknId = form_Fs_VUNG_ID('GR_kn');
            b_dk_cdanhId = form_Fs_TEN_ID(b_vungId, 'dk_cdanh');
            b_cdanhId = form_Fs_TEN_ID(b_vungId, 'cdanh');
            b_capdtId = form_Fs_TEN_ID(b_vungId, 'capdt');

            b_dk_thamnienId = form_Fs_TEN_ID(b_vungId, 'dk_thamnien');
            b_thamnienId = form_Fs_TEN_ID(b_vungId, 'thamnien');
            b_dkien_luongId = form_Fs_TEN_ID(b_vungId, 'dkien_luong');
            b_mucluongId = form_Fs_TEN_ID(b_vungId, 'mucluong');

            b_dk_chualenluongId = form_Fs_TEN_ID(b_vungId, 'dk_chualenluong');
            b_tg_chualenluongId = form_Fs_TEN_ID(b_vungId, 'tg_chualenluong');
            b_gchuId = form_Fs_VTEN_ID('', 'gchu');
        }


        function P_KET_QUA(b_dtuong, a_tso) {
            try {
                if (b_dtuong == null || b_dtuong == "") return;
                b_dtuong = b_dtuong.toUpperCase();
                var b_kq = a_tso[0];
                if (b_dtuong.indexOf("CDANH") >= 0) {
                    $get(b_cdanhId).value = b_kq;
                    $get(b_gchuId).innerHTML = a_tso[1];
                }
                if (b_dtuong.indexOf("CAPDT") >= 0) {
                    $get(b_capdtId).value = b_kq;
                    $get(b_gchuId).innerHTML = a_tso[1];
                }
                if (b_dtuong.indexOf("MA") >= 0) {
                    var b_hang = GridX_Fi_timHangA(b_grknId);
                    if (b_hang > -1) {
                        GridX_datGtri(b_grknId, b_hang, "ma", b_kq);
                        GridX_datGtri(b_grknId, b_hang, "ten", a_tso[1]);
                    }
                }
            }
            catch (err) { form_P_LOI(err); }
        }


        function ti_thongke_Update(b_event) {
            try {
                var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grknId);
                var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
                b_mt = b_cot;
                if (b_value != "") {
                    if (b_cot == "MA") {
                        skhac.Fs_MA_LOI(form_Fs_nsd(), "Mã kỹ năng cá nhân", b_value, "ns_ma_kynang,ma,ten", ti_thongke_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
                    }
                }
                if (b_value != "") GridX_ThemHang(b_grknId);
                return false;
            }
            catch (err) { form_P_LOI(err); }
        }


        function ti_thongke_P_KTRA(b_maTen) {
            try {
                var b_maId = "";
                b_mt = b_maTen = b_maTen.toUpperCase();
                switch (b_maTen) {
                    case "CDANH": b_maId = b_cdanhId; break;
                    case "CAPDT": b_maId = b_capdtId; break;
                }
                var b_ma = $get(b_maId);
                if (b_ma == null || C_NVL(b_ma.value) == "") return;
                else if (b_maTen == "CDANH") {
                    skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ti_thongke_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
                }
                else if (b_maTen == "CAPDT") {
                    skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ti_thongke_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
                }
            }
            catch (err) { form_P_LOI(err); }
        }

        function ti_thongke_P_DatGchu(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            if (b_mt == "MA") {
                var b_hang = GridX_Fi_timHangA(b_grknId);
                GridX_datGtri(b_grknId, b_hang - 1, "ten", b_kq);
            }
            if (b_mt == "CDANH" || b_mt == "CAPDT") {
                $get(b_gchuId).innerHTML = b_kq;
            }
        }

        function ti_thongke_P_LKE_CHO() {
            if ($get(b_grlkeId) != null) { clearTimeout(ti_thongke_lkeCho); }
        }

        function ti_thongke_P_TIM() {
            try {
                // kiem tra du lieu vao 

                if ($get(b_thamnienId).value != "" && $get(b_dk_thamnienId).value == '0') {
                    form_P_LOI('loi:Vui lòng chọn điều kiện thâm niên làm việc:loi');
                    $get(b_dk_thamnienId).focus();
                    return false;
                }
                if ($get(b_mucluongId).value != "" && $get(b_dkien_luongId).value == '0') {
                    form_P_LOI('loi:Vui lòng chọn điều kiện mức lương:loi');
                    $get(b_dkien_luongId).focus();
                    return false;
                }
                if ($get(b_tg_chualenluongId).value != "" && $get(b_dk_chualenluongId).value == '0') {
                    form_P_LOI('loi:Vui lòng chọn điều kiện chưa lên lương:loi');
                    $get(b_dk_chualenluongId).focus();
                    return false;
                }
                if ($get(b_cdanhId).value != "" && $get(b_dk_cdanhId).value == '0') {
                    form_P_LOI('loi:Vui lòng chọn điều kiện chưa lên lương:loi');
                    $get(b_dk_cdanhId).focus();
                    return false;
                }
                //thuc hien tim kiem
                var b_loi = form_Fs_TEXT_KTRA(b_vungId);
                if (b_loi != "") form_P_LOI(b_loi);
                else {
                    var b_dt = form_Faa_TEXT_ROW(b_vungId),
                        a_cot_ct = GridX_Fdt_cotGtri(b_grknId);
                    sti_ch.Fs_TI_THONGKE_TIM(b_dt, a_cot_ct, ti_thongke_P_TIM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                }
                return false;
            }
            catch (err) { form_P_LOI(err); }
        }

        function ti_thongke_P_TIM_KQ(b_kq) {
            // thamnien_ct, thamnien_cd, trinhdo, mucluong, kynang, chualenluong
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            else {

                form_P_MO("ti_thongke_kq.aspx", null, ["KQ", [b_kq]]);
            }
            return false;
        }

        function ti_thongke_HangLen() {
            GridX_chuyenHang(b_grknId, -1);
            return false;
        }
        function ti_thongke_HangXuong() {
            GridX_chuyenHang(b_grknId, 1);
            return false;
        }
        function ti_thongke_ChenDong(b_dk) {
            if (GridX_Fi_timHangC(b_grknId) < 1) {
                var b_ctr = eval(window.name + '_P_HTOAN');
                if (b_ctr != null) b_ctr('C');
            }
            else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grknId);
            return false;
        }
        function ti_thongke_CatDong() {
            GridX_boChon(b_grknId, 'C');
            return false;
        }
        function form_dong() {
            location.reload(false);
        }
    </script>
</asp:Content>
