<%@ Page Language="C#" AutoEventWireup="true" CodeFile="khud_Excel.aspx.cs" Inherits="f_khud_Excel"
    Title="khud_Excel" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:UpdatePanel ID="UpPa_chon_file" UpdateMode="Conditional" runat="server">
    <ContentTemplate>
        <table cellpadding="7" cellspacing="1">
            <tr>
                <td align="center">
                    <Cthuvien:luu ID="Label2" runat="server" Text="Mở File Excel, Dbf" CssClass="css_phude" />
                </td>
            </tr>
            <tr>
                <td>
                    <table cellpadding="1" cellspacing="1">
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label1" runat="server" CssClass="css_gchu" Width="60px" Text="Chọn file" />
                            </td>
                            <td align="left">
                                <asp:FileUpload ID="chon_file" runat="server" Width="350px" CssClass="css_ma" BackColor="White" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Label ID="ten" runat="server" CssClass="css_gchu" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <Cthuvien:nhap ID="mo" runat="server" Width="70px" Text="Mở" OnServerClick="nhap_Click" />
                </td>
            </tr>    
        </table>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="mo" />
    </Triggers>
</asp:UpdatePanel>
<Cthuvien:an ID="kthuoc" runat="server" Value="500,190" />
<Cthuvien:an ID="tra_dong" runat="server" Value="FILE_HTOAN" />
</asp:Content>
