<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kh_help.aspx.cs" Inherits="f_kh_help" 
    Title="kh_help" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td align="left" colspan="2">
                <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Hướng dẫn sử dụng" />
            </td>
        </tr>
    </table>
    <iframe src="" id="nd" />
</asp:Content>
