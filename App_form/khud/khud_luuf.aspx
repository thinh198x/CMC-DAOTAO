<%@ Page Language="C#" AutoEventWireup="true" CodeFile="khud_luuf.aspx.cs" Inherits="f_khud_luuf"
    Title="khud_luuf" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:UpdatePanel ID="UpPa_chon_file" UpdateMode="Conditional" runat="server">
    <ContentTemplate>
        <table cellpadding="7" cellspacing="1">
            <tr>
                <td align="center">
                    <Cthuvien:luu ID="Label2" runat="server" Text="Lưu File" CssClass="css_phude" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:FileUpload ID="chon_file" runat="server" BackColor="White" onchange="khud_luuf_P_GCHU()"  />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <Cthuvien:nhap ID="luu" runat="server" Width="70px" Text="Lưu" OnClick="return khud_luuf_P_DAT();" />
                </td>
            </tr>    
            <tr>
                <td align="center" style="width:400px;">
                    <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" />
                </td>
            </tr>    
            <tr style="display:none;">
                <td align="center">
                    <Cthuvien:nhap ID="mo" runat="server" Width="70px" Text="Lưu" OnServerClick="mo_ServerClick" />
                </td>
            </tr>    
        </table>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="mo" />
    </Triggers>
</asp:UpdatePanel>
<Cthuvien:an ID="kthuoc" runat="server" Value="550,220" />
<div id="UPa_hi">
    <Cthuvien:an ID="tmuc" runat="server" />
    <Cthuvien:an ID="ten" runat="server" />
    <Cthuvien:an ID="loai" runat="server" />
    <Cthuvien:an ID="ma_dvi" runat="server" />
    <Cthuvien:an ID="nd" runat="server" />
    <Cthuvien:an ID="tra_luu" runat="server" />
    <Cthuvien:an ID="tra_dong" runat="server" />
</div>
</asp:Content>
