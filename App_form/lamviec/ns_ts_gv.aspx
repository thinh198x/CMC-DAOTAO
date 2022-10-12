<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_ts_gv.aspx.cs" Inherits="f_ht_macvu"
    Title="ht_macvu" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Giao việc" />
                        </td>
                        <td align="right">
                            <table id="UPa_dau" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center" style="width: 50px;">
                                        <img runat="server" alt="" src="~/images/bitmaps/ke_va_ca.jpg" />
                                    </td>
                                    <td style="padding-right: 10px;" class="css_lket_dat">
                                        <img runat="server" alt="" src="~/images/icon/help.png" title="hướng dẫn sử dụng" onclick="return form_HELP();" />
                                    </td>
                                    <td style="padding-right: 10px;" class="css_lket_dat">
                                        <img runat="server" alt="" src="~/images/icon/gop.png" title="Góp ý" onclick="return form_GOP();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="middle">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td>
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Bbuoc4" runat="server" CssClass="css_gchu" Text="Dự án" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:DR_nhap ID="DR_nhap1" runat="server" CssClass="css_drop" Width="206px"
                                            DataTextField="ten" DataValueField="ma" onchange="dc_datlich_P_BV_LKE()" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Bbuoc6" runat="server" CssClass="css_gchu" Text="Nhân viên" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:DR_nhap ID="DR_nhap2" runat="server" CssClass="css_drop" Width="206px"
                                            DataTextField="ten" DataValueField="ma" onchange="dc_datlich_P_BV_LKE()" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Bbuoc1" runat="server" CssClass="css_gchu" Text="Công việc" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="Ma2" runat="server" CssClass="css_nd" kieu_unicode="True" kt_xoa="X" Width="200px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Label1" runat="server" CssClass="css_gchu" Text="Bắt đầu từ ngày" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="Ma1" runat="server" CssClass="css_nd" kieu_unicode="True" kt_xoa="X" Width="200px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu" Text="Đến ngày" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="Ma3" runat="server" CssClass="css_nd" kieu_unicode="True" kt_xoa="X" Width="200px" />
                                    </td>

                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Bbuoc3" runat="server" CssClass="css_gchu" Text="Nội dung" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="Ma4" runat="server" CssClass="css_nd" kieu_unicode="True" kt_xoa="X" Width="200px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Bbuoc5" runat="server" CssClass="css_gchu" Text="Công việc QL" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="Ma5" runat="server" CssClass="css_nd" kieu_unicode="True" kt_xoa="X" Width="200px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <Cthuvien:nhap ID="nhap" runat="server" Width="70px" Text="Nhập" OnClick="return ht_macvu_P_NH();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="775,430" />
</asp:Content>
