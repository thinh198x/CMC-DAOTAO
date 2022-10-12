<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kh_dich.aspx.cs" Inherits="f_kh_dich"
    Title="kh_dich" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="7" cellspacing="1">
        <tr>
            <td align="center">
                <Cthuvien:luu ID="Label2" runat="server" Text="Mở Form hàng loạt" CssClass="css_phude" />
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Label1" runat="server" CssClass="css_gchu" Width="60px" Text="Thư mục" />
                        </td>
                        <td align="left">
                            <Cthuvien:ma ID="TMUC" runat="server" CssClass="css_ma" Width="200px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label runat="server" CssClass="css_gchu" Text="Loại" />
                        </td>
                        <td align="left">
                            <Cthuvien:kieu ID="loai" runat="server" CssClass="css_ma_c" Width="20px" lke="F,S" ToolTip="Loại: F-Form, S-SQL" Text="F" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <Cthuvien:nhap ID="nhap" runat="server" Width="70px" Text="Mở" onclick="return kh_dich_P_NH();" />
            </td>
        </tr>    
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="500,190" />
</asp:Content>
