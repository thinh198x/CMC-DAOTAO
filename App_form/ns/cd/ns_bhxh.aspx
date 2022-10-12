<%@ Page Title="ns_bhxh" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_bhxh.aspx.cs" Inherits="f_ns_bhxh" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Bảo hiểm" />
                        </td>
                        <td align="right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center" style="width: 50px;">
                                        <img id="Anh3" runat="server" alt="" src="~/images/nen/ke_va_ca.jpg" />
                                    </td>
                                    <td style="padding-right: 10px;" class="css_lket_dat">
                                        <img id="Img1" runat="server" alt="" src="~/images/icon/help.png" title="hướng dẫn sử dụng" onclick="return form_HELP();" />
                                    </td>
                                    <td style="padding-right: 10px;" class="css_lket_dat">
                                        <img id="Img2" runat="server" alt="" src="~/images/icon/gop.png" title="Góp ý" onclick="return form_GOP();" />
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
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left" valign="top" class="tab_content">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label10" runat="server" Text="Mã số CB" Width="75px" CssClass="css_gchu" />
                                                            </td>
                                                            <td>
                                                                <table cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td>
                                                                            <Cthuvien:ma ID="SO_THE" runat="server" kt_xoa="G" CssClass="css_ma" kieu_chu="true"
                                                                                gchu="gchu" ten="Mã số cán bộ" Width="150px" ToolTip="Mã số cán bộ" BackColor="#f6f7f7"
                                                                                ktra="ns_cb,so_the,ten" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" onchange="ns_bhxh_P_KTRA('SO_THE')" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="Label12" runat="server" Width="20px" Text=" " CssClass="css_gchu_c" />
                                                                        </td>
                                                                        <td>
                                                                            <Cthuvien:ma ID="ten" ten="Tên cán bộ" runat="server" kieu_unicode="true" Width="220px"
                                                                                kt_xoa="G" CssClass="css_ma" Enabled="false" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label15" runat="server" Text="Tham gia" Width="75px" CssClass="css_gchu" />
                                                            </td>
                                                            <td align="center">
                                                                <table cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label5" runat="server" Text="BHXH" Width="75px" CssClass="css_gchu_c" />
                                                                        </td>
                                                                        <td>
                                                                            <Cthuvien:kieu ID="bhxh" runat="server" lke="X," Width="30px" ToolTip="X - Tham gia,  - Không tham gia" CssClass="css_ma_c" Text="X" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="Label1" runat="server" Text="BHYT" Width="75px" CssClass="css_gchu_c" />
                                                                        </td>
                                                                        <td>
                                                                            <Cthuvien:kieu ID="bhyt" runat="server" lke="X," Width="30px" ToolTip="X - Có,  - Không tham gia" CssClass="css_ma_c" Text="X" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="Label6" runat="server" Text="BHTN" Width="75px" CssClass="css_gchu_c" />
                                                                        </td>
                                                                        <td>
                                                                            <Cthuvien:kieu ID="bhtn" runat="server" lke="X," Width="30px" ToolTip="X - Có,  - Không tham gia" CssClass="css_ma_c" Text="X" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label9" runat="server" Text="Đã cấp sổ" Width="75px" CssClass="css_gchu" />
                                                            </td>
                                                            <td>
                                                                <table cellpadding="0" cellspacing="0">
                                                                    <tr>

                                                                        <td>
                                                                            <table cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <Cthuvien:kieu ID="dcapso" runat="server" lke="X," Width="30px" ToolTip="X - Đã cấp,  - Chưa cấp" CssClass="css_ma_c" Text="X" />
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <asp:Label ID="Label11" runat="server" Text="Số sổ BH" Width="65px" CssClass="css_gchu_c" />
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <Cthuvien:ma ID="sobhxh" runat="server" CssClass="css_ma" kieu_chu="true" Width="100px" ToolTip="Số sổ bảo hiểm xã hội" kt_xoa="X" />
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <asp:Label ID="Label3" runat="server" Text="Ngày cấp sổ" Width="85px" CssClass="css_gchu_c" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_bhxh" runat="server" CssClass="css_ma_c" kieu_chu="true" Width="100px" ToolTip="Ngày cấp sổ hiểm xã hội" kt_xoa="X" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label7" runat="server" Text="Nơi cấp sổ" Width="75px" CssClass="css_gchu" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="noicap" runat="server" CssClass="css_ma" kieu_unicode="True" kt_xoa="X"
                                                                    gchu="gchu" ten="Đơn vị" ToolTip="Nơi cấp sổ bảo hiểm xã hội" Width="400px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label16" runat="server" Text="Ngày b.đầu đóng BHXH" Width="90px" CssClass="css_gchu" />
                                                            </td>
                                                            <td>
                                                                <table cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td align="left">
                                                                            <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ndongbhxh" runat="server" CssClass="css_ma_c" kt_xoa="X"
                                                                                gchu="gchu" ten="Đơn vị" ToolTip="Ngày bắt đầu đóng BHXH" Width="150px" />
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label17" runat="server" Text="Ngày b.đầu đóng BHTN" Width="90px" CssClass="css_gchu_c" />
                                                                        </td>
                                                                        <td align="left">
                                                                            <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ndongbhtn" runat="server" CssClass="css_ma_c" kt_xoa="X"
                                                                                gchu="gchu" ten="Đơn vị" ToolTip="Ngày bắt đầu đóng BHXH" Width="150px" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" Text="Số thẻ BHYT" Width="85px" CssClass="css_gchu" />
                                                            </td>
                                                            <td>
                                                                <table cellpadding="0" cellspacing="0">
                                                                    <tr>

                                                                        <td>
                                                                            <table cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        <Cthuvien:ma ID="sobhyt" runat="server" CssClass="css_ma" kieu_chu="true" Width="120px" ToolTip="Số sổ bảo hiểm xã hội" kt_xoa="X" />
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <asp:Label ID="Label13" runat="server" Text="Nơi đăng ký KCB" Width="105px" CssClass="css_gchu_c" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <Cthuvien:ma ID="dk_kcb" runat="server" CssClass="css_ma" kieu_chu="true" Width="165px" ToolTip="Nơi đăng ký khám chữa bệnh"
                                                                                            BackColor="#f6f7f7" ktra="ns_ma_bv,ma,ten" ten="Nơi đăng ký khám chữa bệnh" f_tkhao="~/App_form/ns/sk/ma/ns_ma_bv.aspx" onchange="ns_bhxh_P_KTRA('DK_KCB')" kt_xoa="X" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label4" runat="server" Text="Từ ngày" Width="85px" CssClass="css_gchu" />
                                                            </td>
                                                            <td>
                                                                <table cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayd" runat="server" CssClass="css_ma_c" Width="150px" ToolTip="Từ ngày" kt_xoa="X" />
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label14" runat="server" Text="Tới ngày" Width="90px" CssClass="css_gchu_c" />
                                                                        </td>
                                                                        <td>
                                                                            <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayc" runat="server" CssClass="css_ma_c" Width="150px" ToolTip="Tới ngày" kt_xoa="X" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label18" runat="server" Text="Đã trả sổ BHXH" Width="85px" CssClass="css_gchu" />
                                                            </td>
                                                            <td>
                                                                <table cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            <Cthuvien:kieu ID="trabhxh" runat="server" lke="X," Width="30px" ToolTip=" X - Đã trả ,  - Chưa trả" CssClass="css_ma_c" Text=" " />
                                                                        </td>
                                                                        <td>
                                                                            <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_trabhxh" runat="server" CssClass="css_ma_c" Width="114px" ToolTip="Ngày cấp sổ hiểm xã hội" kt_xoa="X" />
                                                                        </td>
                                                                        <td align="left">
                                                                <asp:Label ID="Label19" runat="server" Text="Đã trả thẻ BHYT" Width="90px" CssClass="css_gchu_c" />
                                                            </td>
                                                                         <td>
                                                                            <Cthuvien:kieu ID="trabhyt" runat="server" lke="X," Width="30px" ToolTip=" X - Đã trả ,  - Chưa trả" CssClass="css_ma_c" Text=" " />
                                                                        </td>
                                                                        <td>
                                                                            <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_trabhyt" runat="server" CssClass="css_ma_c" Width="114px" ToolTip="Ngày cấp sổ hiểm xã hội" kt_xoa="X" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label8" runat="server" Text="Ghi chú" CssClass="css_gchu" Width="75px" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="ghichu" runat="server" CssClass="css_ma" kieu_unicode="True" kt_xoa="X"
                                                                    Width="400px" TextMode="MultiLine" Height="50px" />
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
                                        <table id="UPa_nhap" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="center">
                                                    <Cthuvien:nhap ID="nhap" runat="server" Width="70px" CssClass="css_button" OnClick="return ns_bhxh_P_NH();form_P_LOI();"
                                                        Text="Nhập" />
                                                </td>
                                                <td align="center">
                                                    <Cthuvien:nhap ID="xoa" runat="server" Width="70px" CssClass="css_button" OnClick="return ns_bhxh_P_XOA();form_P_LOI();"
                                                        Text="Xóa" />
                                                </td>
                                                <%--<td align="center">
                                                    <Cthuvien:nhap ID="thaydoi" runat="server" Width="70px" CssClass="css_button" OnClick="return open_thaydoi();form_P_LOI();"
                                                        Text="Thay đổi thông tin" />
                                                </td>--%>
                                                <td align="center">
                                                    <Cthuvien:nhap ID="qt" runat="server" Width="80px" CssClass="css_button" OnClick="return open_quatrinh();form_P_LOI();"
                                                        Text="Quá trình" />
                                                </td>
                                                 <td>
                                                    <Cthuvien:nhap ID="file" runat="server" Text="File" Width="101px" class="css_button_l"
                                                        title="Thêm File" OnClick="return nhap_file();form_P_LOI();" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="css_border" colspan="2">
                            <div id="UPa_gchu">
                                <Cthuvien:gchu ID="gchu" runat="server" kt_xoa="X" />
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="550,420" />
    </div>
</asp:Content>
