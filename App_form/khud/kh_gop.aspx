<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kh_gop.aspx.cs" Inherits="f_kh_gop"
    Title="kh_gop" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td align="left">
                <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Góp ý" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <Cthuvien:nd ID="ND" runat="server" CssClass="css_nd" kieu_unicode="True" kt_xoa="X" Width="500px" Height="150px" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <div class="box3 txRight" style="vertical-align: top">
                    <a href="#" onclick="return kh_gop_P_NH();form_P_LOI();" class="bt bt-grey"><span class="txUnderline"></span>Gửi</a>
                </div>
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="600,300" />
</asp:Content>